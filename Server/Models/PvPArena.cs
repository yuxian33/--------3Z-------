using Library;
using Library.SystemModels;
using Server.DBModels;
using Server.Envir;
using System;
using System.Collections.Generic;

namespace Server.Models
{
	public sealed class PvPArena : MiniGame
	{
		public int topRewards = 1;

		private List<UserItem> Items = new List<UserItem>();

		private List<UserItem> Items1 = new List<UserItem>();

		private List<UserItem> Items2 = new List<UserItem>();

		private List<UserItem> Items3 = new List<UserItem>();

		public List<CharacterInfo> PlayersDead = new List<CharacterInfo>();

		public List<CharacterInfo> PlayersAlive = new List<CharacterInfo>();

		public DateTime RevivalEnd;

		public override void Process()
		{
			base.Process();
			if (!Started)
			{
				return;
			}
			if (SEnvir.Now > RevivalEnd && CanRevive)
			{
				CanRevive = false;
				foreach (PlayerObject player in Players)
				{
					player.Connection.ReceiveChat("You can no longer revive on death, may the best fighters win", MessageType.System);
				}
			}
			if (!MGInfo.TeamGame)
			{
				if (PlayersAlive.Count == 1)
				{
					EndTime = SEnvir.Now;
					populateRewards();
					foreach (CharacterInfo chara3 in PlayersAlive)
					{
						MailRewards(chara3, Items);
					}
					rewardTopPlayers();
				}
			}
			else
			{
				int countA = 0;
				int countB = 0;
				foreach (PlayerObject player2 in Players)
				{
					if (PlayersDead.Contains(player2.Character))
					{
						if (player2.EventTeam == 0)
						{
							countA++;
						}
						if (player2.EventTeam == 1)
						{
							countB++;
						}
						if (countA >= TeamA.Count || countB >= TeamB.Count)
						{
							EndTime = SEnvir.Now;
							populateRewards();
							if (countA >= TeamA.Count)
							{
								foreach (CharacterInfo chara2 in TeamB)
								{
									MailRewards(chara2, Items);
								}
							}
							else
							{
								foreach (CharacterInfo chara in TeamB)
								{
									MailRewards(chara, Items);
								}
							}
							rewardTopPlayers(TeamA);
							rewardTopPlayers(TeamB);
						}
					}
				}
			}
		}

		public void rewardTopPlayers(List<CharacterInfo> team = null)
		{
			int kills = 0;
			int kills2 = 0;
			int kills4 = 0;
			List<CharacterInfo> Top1Char = new List<CharacterInfo>();
			List<CharacterInfo> Top2Char = new List<CharacterInfo>();
			List<CharacterInfo> Top3Char = new List<CharacterInfo>();
			foreach (KeyValuePair<CharacterInfo, UserArenaPvPStats> entry in Stats)
			{
				if (!MGInfo.TeamGame || team.Contains(entry.Key))
				{
					int kills3 = entry.Value.PvPKillCount;
					if (kills3 > kills)
					{
						if (Top1Char.Count > 0)
						{
							if (Top2Char.Count > 0)
							{
								kills4 = kills2;
								Top3Char.Clear();
								Top3Char = Top2Char;
							}
							kills2 = kills;
							Top2Char.Clear();
							Top2Char = Top1Char;
						}
						kills = kills3;
						Top1Char.Clear();
						Top1Char.Add(entry.Key);
					}
					else if (kills3 == kills)
					{
						Top1Char.Add(entry.Key);
					}
					else if (kills3 > kills2)
					{
						kills4 = kills2;
						Top3Char.Clear();
						Top3Char = Top2Char;
						kills2 = kills3;
						Top2Char.Clear();
						Top2Char.Add(entry.Key);
					}
					else if (kills3 == kills2)
					{
						kills2 = kills3;
					}
					else if (kills3 > kills4)
					{
						kills4 = kills3;
						Top3Char.Clear();
						Top3Char.Add(entry.Key);
					}
					else if (kills3 == kills4)
					{
						kills4 = kills3;
					}
				}
			}
			if (Top1Char.Count > 2)
			{
				Top2Char.Clear();
				Top3Char.Clear();
			}
			if (Top1Char.Count > 1)
			{
				Top3Char.Clear();
			}
			if (Top2Char.Count > 1 || MGInfo.TeamGame)
			{
				Top3Char.Clear();
			}
			foreach (CharacterInfo chara3 in Top1Char)
			{
				MailRewards(chara3, Items1);
			}
			foreach (CharacterInfo chara2 in Top2Char)
			{
				MailRewards(chara2, Items2);
			}
			foreach (CharacterInfo chara in Top3Char)
			{
				MailRewards(chara, Items3);
			}
		}

		public void populateRewards()
		{
			foreach (RewardInfo info in MGInfo.Rewards)
			{
				int amount = info.Amount;
				if (info.Top1 || info.Top2 || info.Top3)
				{
					if (SEnvir.Random.Next(100) <= info.Chance)
					{
						while (amount > 0)
						{
							UserItem item2 = SEnvir.CreateFreshItem(info.Item);
							if (item2.Info.Effect == ItemEffect.Gold)
							{
								item2.Count = amount;
							}
							else
							{
								item2.Count = Math.Min(info.Item.StackSize, info.Amount);
							}
							amount -= (int)item2.Count;
							if (info.Top1)
							{
								Items1.Add(item2);
							}
							if (info.Top2)
							{
								Items2.Add(item2);
							}
							if (info.Top3)
							{
								Items3.Add(item2);
							}
						}
					}
				}
				else if (SEnvir.Random.Next(100) <= info.Chance)
				{
					while (amount > 0)
					{
						UserItem item2 = SEnvir.CreateFreshItem(info.Item);
						if (item2.Info.Effect == ItemEffect.Gold)
						{
							item2.Count = amount;
						}
						else
						{
							item2.Count = Math.Min(info.Item.StackSize, info.Amount);
						}
						amount -= (int)item2.Count;
						Items.Add(item2);
					}
				}
			}
		}

		public override void StartGame()
		{
			base.StartGame();
			if (Players.Count > MGInfo.MinPlayers * 2)
			{
				topRewards = 2;
			}
			if (Players.Count > MGInfo.MinPlayers * 3)
			{
				topRewards = 3;
			}
			foreach (PlayerObject player in Players)
			{
				PlayersAlive.Add(player.Character);
			}
			RevivalEnd = StartTime.AddSeconds(MGInfo.Duration * 30);
		}

		public override bool ReJoinGame(PlayerObject player)
		{
			if (CanRevive)
			{
				base.ReJoinGame(player);
				if (PlayersDead.Contains(player.Character))
				{
					PlayersDead.Remove(player.Character);
				}
				if (!PlayersAlive.Contains(player.Character))
				{
					PlayersAlive.Add(player.Character);
				}
			}
			return false;
		}
	}
}
