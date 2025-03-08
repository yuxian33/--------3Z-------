using Library;
using Library.Network.ServerPackets;
using Library.SystemModels;
using Server.DBModels;
using Server.Envir;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Server.Models
{
	public class MiniGame
	{
		public DateTime StartTime;

		public DateTime EndTime;

		public List<CharacterInfo> TeamA;

		public List<CharacterInfo> TeamB;

		public List<CharacterInfo> MGChars;

		public List<PlayerObject> Players;

		public Map Map;

		public Map LobbyMap;

		public bool Started;

		public bool Ended;

		public bool NextMessage;

		public bool CanRevive;

		public MiniGameInfo MGInfo;

		public Dictionary<CharacterInfo, UserArenaPvPStats> Stats = new Dictionary<CharacterInfo, UserArenaPvPStats>();

		public Dictionary<CharacterInfo, bool> EntryFeePass = new Dictionary<CharacterInfo, bool>();

		public bool CreateGame(PlayerObject player, MiniGameInfo info)
		{
			if (info == null)
			{
				return false;
			}
			if (player == null)
			{
				return false;
			}
			foreach (MiniGame mgs in SEnvir.MiniGames)
			{
				if (mgs.MGChars.Contains(player.Character))
				{
					player.Connection.ReceiveChat($"你已经进入了 {mgs.MGInfo.MiniGame.DescriptionToString()} ，等级要求 {mgs.MGInfo.MinLevel} - {mgs.MGInfo.MaxLevel}", MessageType.System);
					return false;
				}
			}
			MGChars = new List<CharacterInfo>();
			MGInfo = info;
			LobbyMap = SEnvir.GetMap(MGInfo.MapLobby);
			Map = SEnvir.GetMap(MGInfo.MapParameter);
			if (LobbyMap == null || Map == null)
			{
				return false;
			}
			if (!player.RemoveFreePass())
			{
				return false;
			}
			Players = new List<PlayerObject>();
			TeamA = new List<CharacterInfo>();
			TeamB = new List<CharacterInfo>();
			NextMessage = false;
			StartTime = SEnvir.Now.AddMinutes(1.0);
			EndTime = StartTime.AddMinutes(MGInfo.Duration);
			CanRevive = info.CanRevive;
			foreach (SConnection con in SEnvir.Connections)
			{
				con.ReceiveChat($"这里是 【{MGInfo.MiniGame.DescriptionToString()}】 ，等级 {MGInfo.MinLevel}-{MGInfo.MaxLevel} 级玩家游戏 {Functions.ToString(StartTime - SEnvir.Now, details: true, small: true)} 秒后开始", MessageType.Announcement);
			}
			SEnvir.MiniGames.Add(this);
			return true;
		}

		public virtual bool ReJoinGame(PlayerObject player)
		{
			bool exists = false;
			if (MGChars.Contains(player.Character))
			{
				exists = true;
			}
			if (exists)
			{
				if (Started)
				{
					if (MGInfo.TeamGame && CanRevive)
					{
						if (TeamA.Contains(player.Character))
						{
							player.EventTeam = 1;
							player.Teleport(MGInfo.TeamASpawn);
							return true;
						}
						if (TeamB.Contains(player.Character))
						{
							player.EventTeam = 2;
							player.Teleport(MGInfo.TeamBSpawn);
							return true;
						}
					}
					if (CanRevive)
					{
						Players.Add(player);
						player.Teleport(MGInfo.TeamASpawn);
						return true;
					}
				}
				else if (player.Teleport(LobbyMap, LobbyMap.GetRandomLocation()))
				{
					return true;
				}
				MGChars.Remove(player.Character);
				return false;
			}
			return false;
		}

		public bool JoinGame(PlayerObject player, bool FreePass)
		{
			foreach (MiniGame mgs in SEnvir.MiniGames)
			{
				if (mgs.MGChars.Contains(player.Character))
				{
					if (mgs.MGInfo == MGInfo)
					{
						ReJoinGame(player);
					}
					player.Connection.ReceiveChat($"你已经进入了 {mgs.MGInfo.MiniGame.DescriptionToString()} 等级要求 {mgs.MGInfo.MinLevel} - {mgs.MGInfo.MaxLevel}", MessageType.System);
					return false;
				}
			}
			if (FreePass)
			{
				Players.Add(player);
				MGChars.Add(player.Character);
				EntryFeePass[player.Character] = true;
				return true;
			}
			foreach (CharacterInfo MGPlayers in MGChars)
			{
				if (MGPlayers == player.Character)
				{
					return false;
				}
			}
			if (player.Gold >= MGInfo.EntryFee)
			{
				player.Gold -= MGInfo.EntryFee;
				player.GoldChanged();
				Players.Add(player);
				MGChars.Add(player.Character);
				EntryFeePass[player.Character] = false;
				return true;
			}
			return false;
		}

		public virtual void StartGame()
		{
			if (MGInfo == null)
			{
				SEnvir.Log("[错误] 无法启动小游戏");
				foreach (PlayerObject player in Players)
				{
					player?.Connection.ReceiveChat("无法启动小游戏", MessageType.System);
				}
				TTPlayers();
				return;
			}
			if (Players.Count < MGInfo.MinPlayers)
			{
				RefundEntry();
				return;
			}
			foreach (PlayerObject player2 in Players)
			{
				player2?.Connection.ReceiveChat($"{MGInfo.MiniGame.DescriptionToString()} 游戏已经开始了，祝你好运", MessageType.System);
			}
			Started = true;
			if (MGInfo.TeamGame)
			{
				SetTeams();
			}
			PingPlayers();
			SEnvir.SendMiniGamesUpdate();
		}

		public virtual void RefundEntry()
		{
			foreach (KeyValuePair<CharacterInfo, bool> pair in EntryFeePass)
			{
				List<UserItem> Items = new List<UserItem>();
				UserItem item2 = new UserItem();
				ItemInfo info2 = new ItemInfo();
				info2 = (!pair.Value) ? SEnvir.ItemInfoList.Binding.FirstOrDefault((ItemInfo x) => x.Effect == ItemEffect.Gold) : SEnvir.ItemInfoList.Binding.FirstOrDefault((ItemInfo x) => x.ItemName == "自由通行证");
				item2 = SEnvir.CreateFreshItem(info2);
				if (item2.Info.Effect == ItemEffect.Gold)
				{
					item2.Count = MGInfo.EntryFee;
				}
				else
				{
					item2.Count = 1L;
				}
				Items.Add(item2);
				if (Items.Count > 0)
				{
					MailRewards(pair.Key, Items);
				}
			}
			EndGame(didntstart: true);
		}

		public virtual void Process()
		{
			CheckConnections();
			if (!Started)
			{
				if (SEnvir.Now >= StartTime)
				{
					StartGame();
					return;
				}
				if (!NextMessage)
				{
					TimeSpan ts = StartTime - SEnvir.Now;
					if (ts >= TimeSpan.FromSeconds(240.0) && ts < TimeSpan.FromSeconds(241.0))
					{
						NextMessage = true;
					}
					if (ts >= TimeSpan.FromSeconds(180.0) && ts < TimeSpan.FromSeconds(181.0))
					{
						NextMessage = true;
					}
					if (ts >= TimeSpan.FromSeconds(120.0) && ts < TimeSpan.FromSeconds(121.0))
					{
						NextMessage = true;
					}
					if (ts >= TimeSpan.FromSeconds(60.0) && ts < TimeSpan.FromSeconds(61.0))
					{
						NextMessage = true;
					}
					if (ts >= TimeSpan.FromSeconds(30.0) && ts < TimeSpan.FromSeconds(31.0))
					{
						NextMessage = true;
					}
					if (ts >= TimeSpan.FromSeconds(20.0) && ts < TimeSpan.FromSeconds(21.0))
					{
						NextMessage = true;
					}
					if (ts >= TimeSpan.FromSeconds(1.0) && ts < TimeSpan.FromSeconds(11.0))
					{
						NextMessage = true;
					}
					if (NextMessage)
					{
						if (ts >= TimeSpan.FromSeconds(10.0))
						{
							foreach (SConnection con in SEnvir.Connections)
							{
								con.ReceiveChat($"这里是 {MGInfo.MiniGame.DescriptionToString()} 等级 {MGInfo.MinLevel}-{MGInfo.MaxLevel} 级玩家游戏 {Functions.ToString(StartTime - SEnvir.Now, details: true, small: true)}秒后开始", MessageType.Announcement);
							}
						}
						else
						{
							foreach (PlayerObject player in Players)
							{
								player.Connection?.ReceiveChat($"这里是 {MGInfo.MiniGame.DescriptionToString()} 等级 {MGInfo.MinLevel}-{MGInfo.MaxLevel} 级玩家游戏 {Functions.ToString(StartTime - SEnvir.Now, details: true, small: true)}秒后开始", MessageType.Announcement);
							}
						}
						NextMessage = false;
					}
				}
			}
			if (!(SEnvir.Now < EndTime))
			{
				EndGame(didntstart: false);
			}
		}

		public virtual void CheckConnections()
		{
			bool refreshplayers = false;
			List<PlayerObject> newList = new List<PlayerObject>();
			foreach (PlayerObject Player in Players)
			{
				if (Player.HasNode())
				{
					newList.Add(Player);
				}
				else
				{
					refreshplayers = true;
				}
			}
			if (refreshplayers)
			{
				Players.Clear();
				foreach (PlayerObject player in newList)
				{
					Players.Add(player);
				}
			}
		}

		public virtual void EndGame(bool didntstart)
		{
			Ended = true;
			if (didntstart)
			{
				foreach (SConnection con2 in SEnvir.Connections)
				{
					con2.ReceiveChat($"这【{MGInfo.MiniGame.ToString()}】 由于参加游戏的玩家数量未达到要求原因无法启动", MessageType.Announcement);
				}
			}
			else
			{
				foreach (SConnection con in SEnvir.Connections)
				{
					con.ReceiveChat($"这【{MGInfo.MiniGame.ToString()}】 游戏已结束", MessageType.Announcement);
				}
			}
			foreach (PlayerObject player in Players)
			{
				if (MGInfo.TeamGame)
				{
					player.EventTeam = 0;
					player.TeamA = false;
					player.TeamB = false;
					player.Enqueue(new SetTeam
					{
						ObjectID = player.ObjectID,
						team = 0
					}); 
				}
				if (MGInfo.MiniGame == MiniGames.CaptureTheFlag)
				{
					player.HasFlag = false;
					player.Enqueue(new HasFlag
					{
						ObjectID = player.ObjectID,
						hasFLag = false
					});
				}
			}
			TTPlayers();
			SEnvir.MiniGames.Remove(this);
			SEnvir.SendMiniGamesUpdate();
		}

		public void SetTeams()
		{
			List<PlayerObject> War = new List<PlayerObject>();
			List<PlayerObject> Wiz = new List<PlayerObject>();
			List<PlayerObject> Tao = new List<PlayerObject>();
			List<PlayerObject> Sin = new List<PlayerObject>();
			List<MirClass> ListClasses = new List<MirClass>();
			int count = SEnvir.Random.Next(5);
			foreach (PlayerObject player6 in Players)
			{
				switch (player6.Class)
				{
				case MirClass.Warrior:
					War.Add(player6);
					if (!ListClasses.Contains(MirClass.Warrior))
					{
						ListClasses.Add(MirClass.Warrior);
					}
					break;
				case MirClass.Wizard:
					Wiz.Add(player6);
					if (!ListClasses.Contains(MirClass.Wizard))
					{
						ListClasses.Add(MirClass.Wizard);
					}
					break;
				case MirClass.Taoist:
					Tao.Add(player6);
					if (!ListClasses.Contains(MirClass.Taoist))
					{
						ListClasses.Add(MirClass.Taoist);
					}
					break;
				case MirClass.Assassin:
					Sin.Add(player6);
					if (!ListClasses.Contains(MirClass.Assassin))
					{
						ListClasses.Add(MirClass.Assassin);
					}
					break;
				}
			}
			for (int loop = ListClasses.Count; loop > 0; loop = ListClasses.Count)
			{
				switch (ListClasses[SEnvir.Random.Next(ListClasses.Count)])
				{
				case MirClass.Warrior:
					foreach (PlayerObject player in War)
					{
						if (count % 2 == 0)
						{
							TeamA.Add(player.Character);
						}
						else
						{
							TeamB.Add(player.Character);
						}
						player.EventTeam = count % 2 + 1;
						count++;
					}
					ListClasses.Remove(MirClass.Warrior);
					break;
				case MirClass.Wizard:
					foreach (PlayerObject player2 in Wiz)
					{
						if (count % 2 == 0)
						{
							TeamA.Add(player2.Character);
						}
						else
						{
							TeamB.Add(player2.Character);
						}
						player2.EventTeam = count % 2 + 1;
						count++;
					}
					ListClasses.Remove(MirClass.Wizard);
					break;
				case MirClass.Taoist:
					foreach (PlayerObject player3 in Tao)
					{
						if (count % 2 == 0)
						{
							TeamA.Add(player3.Character);
						}
						else
						{
							TeamB.Add(player3.Character);
						}
						player3.EventTeam = count % 2 + 1;
						count++;
					}
					ListClasses.Remove(MirClass.Taoist);
					break;
				case MirClass.Assassin:
					foreach (PlayerObject player4 in Sin)
					{
						if (count % 2 == 0)
						{
							TeamA.Add(player4.Character);
						}
						else
						{
							TeamB.Add(player4.Character);
						}
						player4.EventTeam = count % 2 + 1;
						count++;
					}
					ListClasses.Remove(MirClass.Assassin);
					break;
				}
			}
			foreach (PlayerObject player5 in Players)
			{
				player5.Enqueue(new SetTeam
				{
					ObjectID = player5.ObjectID,
					team = player5.EventTeam
				});
			}
		}

		public void PingPlayers()
		{
			if (MGInfo.TeamGame)
			{
				foreach (CharacterInfo chara in TeamA)
				{
					PlayerObject player3 = SEnvir.Players.FirstOrDefault((PlayerObject x) => x.Character == chara);
					if (player3.CurrentMap == LobbyMap)
					{
						player3.Teleport(MGInfo.TeamASpawn);
					}
				}
				foreach (CharacterInfo chara2 in TeamB)
				{
					PlayerObject player2 = SEnvir.Players.FirstOrDefault((PlayerObject x) => x.Character == chara2);
					if (player2.CurrentMap == LobbyMap)
					{
						player2.Teleport(MGInfo.TeamBSpawn);
					}
				}
			}
			else
			{
				foreach (PlayerObject player in Players)
				{
					player.Teleport(MGInfo.TeamASpawn);
				}
			}
		}

		public void TTPlayers()
		{
			foreach (PlayerObject Player in Players)
			{
				if ((Player.CurrentMap == Map || Player.CurrentMap == LobbyMap) && Player.Teleport(SEnvir.Maps[Player.Character.BindPoint.BindRegion.Map], Player.Character.BindPoint.ValidBindPoints[SEnvir.Random.Next(Player.Character.BindPoint.ValidBindPoints.Count)]))
				{
				}
			}
		}

		public void MailRewards(List<PlayerObject> winners)
		{
			List<CharacterInfo> chars = new List<CharacterInfo>();
			foreach (PlayerObject player in winners)
			{
				chars.Add(player.Character);
			}
			if (chars != null)
			{
				MailRewards(chars);
			}
		}

		public void MailRewards(List<CharacterInfo> winners)
		{
			if (winners != null)
			{
				foreach (CharacterInfo Character in winners)
				{
					List<UserItem> Items = new List<UserItem>();
					foreach (RewardInfo info in MGInfo.Rewards)
					{
						if (SEnvir.Random.Next(100) <= info.Chance)
						{
							int amount = info.Amount;
							while (amount > 0)
							{
								UserItem item = SEnvir.CreateFreshItem(info.Item);
								if (item.Info.Effect == ItemEffect.Gold)
								{
									item.Count = amount;
								}
								else
								{
									item.Count = Math.Min(info.Item.StackSize, info.Amount);
								}
								amount -= (int)item.Count;
								Items.Add(item);
							}
						}
					}
					if (Items.Count > 0)
					{
						MailRewards(Character, Items);
					}
				}
			}
		}

		public void MailRewards(CharacterInfo winners, List<UserItem> items)
		{
			if (winners != null && items != null)
			{
				MailInfo mail = SEnvir.MailInfoList.CreateNewObject();
				mail.Account = winners.Account;
				mail.Sender = "小游戏奖励";
				mail.Subject = MGInfo.MiniGame.ToString() + " 奖励";
				mail.Message = MGInfo.MiniGame.ToString() + " 等级: " + MGInfo.MinLevel + " 到 " + MGInfo.MaxLevel + " 奖励";
				foreach (UserItem item in items)
				{
					item.Slot = mail.Items.Count;
					item.Mail = mail;
					mail.HasItem = true;
				}
				if (winners.Account.Connection?.Player != null)
				{
					winners.Account.Connection.Enqueue(new MailNew
					{
						Mail = mail.ToClientInfo(),
						ObserverPacket = false
					});
				}
			}
		}

		public UserArenaPvPStats GetStat(CharacterInfo character)
		{
			if (!Stats.TryGetValue(character, out UserArenaPvPStats user))
			{
				user = SEnvir.UserArenaPvPStatsList.CreateNewObject();
				user.Character = character;
				user.PvPEventTime = StartTime;
				user.GuildName = (character.Account.GuildMember?.Guild.GuildName ?? "你还没有公会.");
				user.CharacterName = character.CharacterName;
				user.Class = character.Class;
				user.Level = character.Level;
				user.MiniGame = MGInfo.MiniGame;
				Stats[character] = user;
			}
			return user;
		}
	}
}
