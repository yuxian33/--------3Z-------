using Library;
using Library.Network.ServerPackets;
using Library.SystemModels;
using Server.DBModels;
using Server.Envir;
using Server.Models.Monsters;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Server.Models
{
	public sealed class CaptureTheFlag : MiniGame
	{
		public CTFFlag FlagA = new CTFFlag();

		public CTFFlag FlagB = new CTFFlag();

		public CTFInfo gameInfo = new CTFInfo();

		public PlayerObject FlagAHolder;

		public PlayerObject FlagBHolder;

		public override void Process()
		{
			base.Process();
			foreach (CharacterInfo chara2 in TeamA)
			{
				PlayerObject player2 = SEnvir.Players.FirstOrDefault((PlayerObject x) => x.Character == chara2);
				if (player2 != null && player2.CurrentMap.Info == MGInfo.MapParameter && FlagBHolder != null && gameInfo.TeamAFlagReturn.PointList.Contains(player2.CurrentLocation) && FlagBHolder == player2)
				{
					EndGame(TeamA);
				}
			}
			foreach (CharacterInfo chara in TeamB)
			{
				PlayerObject player = SEnvir.Players.FirstOrDefault((PlayerObject x) => x.Character == chara);
				if (player != null && player.CurrentMap.Info == MGInfo.MapParameter && FlagAHolder != null && gameInfo.TeamBFlagReturn.PointList.Contains(player.CurrentLocation) && FlagAHolder == player)
				{
					EndGame(TeamB);
				}
			}
		}

		public void EndGame(List<CharacterInfo> winners)
		{
			if (winners != null)
			{
				MailRewards(winners);
			}
			if (!FlagA.Dead)
			{
				FlagA.EXPOwner = null;
				FlagA.Die();
			}
			if (!FlagB.Dead)
			{
				FlagB.EXPOwner = null;
				FlagB.Die();
			}
			EndGame(didntstart: false);
		}

		public override void StartGame()
		{
			gameInfo = MGInfo.CTFInfo.FirstOrDefault((CTFInfo x) => x.MiniGame == MGInfo);
			if (gameInfo != null && gameInfo.FlagMonster != null)
			{
				FlagA = new CTFFlag
				{
					MonsterInfo = gameInfo.FlagMonster,
					CTFGame = this
				};
				FlagA.FlagColour = Color.Yellow;
				FlagA.FlagShape = SEnvir.Random.Next(0, 5);
				FlagA.Name = "TeamA";
				FlagA.EventTeam = 1;
				FlagA.Spawn(gameInfo.TeamAFlagSpawn);
				foreach (PlayerObject MO2 in Map.Players)
				{
					MO2.Broadcast(new ObjectFlagColour
					{
						ObjectID = FlagA.ObjectID,
						FlagColour = FlagA.FlagColour,
						FlagShape = FlagA.FlagShape,
						name = FlagA.Name
					});
				}
				FlagB = new CTFFlag
				{
					MonsterInfo = gameInfo.FlagMonster,
					CTFGame = this
				};
				FlagB.FlagColour = Color.Blue;
				FlagB.FlagShape = SEnvir.Random.Next(6, 10);
				FlagB.Name = "TeamB";
				FlagB.EventTeam = 2;
				FlagB.Spawn(gameInfo.TeamBFlagSpawn);
				foreach (PlayerObject MO in Map.Players)
				{
					MO.Broadcast(new ObjectFlagColour
					{
						ObjectID = FlagB.ObjectID,
						FlagColour = FlagB.FlagColour,
						FlagShape = FlagB.FlagShape,
						name = FlagB.Name
					});
				}
				base.StartGame();
			}
		}

		public void RespawnFlag(int team, Point location)
		{
			if (team == 1)
			{
				FlagA = new CTFFlag
				{
					MonsterInfo = gameInfo.FlagMonster,
					CTFGame = this
				};
				FlagA.FlagColour = Color.Yellow;
				FlagA.FlagShape = SEnvir.Random.Next(0, 5);
				FlagA.Name = "TeamA";
				FlagA.EventTeam = 1;
				FlagA.Spawn(MGInfo.MapParameter, location);
				foreach (PlayerObject MO2 in Map.Players)
				{
					MO2.Broadcast(new ObjectFlagColour
					{
						ObjectID = FlagA.ObjectID,
						FlagColour = FlagA.FlagColour,
						FlagShape = FlagA.FlagShape,
						name = FlagA.Name
					});
				}
				foreach (PlayerObject player2 in Players)
				{
					player2.Connection.ReceiveChat($"TeamA Flag has respawned at {location}", MessageType.System);
				}
			}
			if (team == 2)
			{
				FlagB = new CTFFlag
				{
					MonsterInfo = gameInfo.FlagMonster,
					CTFGame = this
				};
				FlagB.FlagColour = Color.Blue;
				FlagB.FlagShape = SEnvir.Random.Next(6, 10);
				FlagB.Name = "TeamB";
				FlagB.EventTeam = 2;
				FlagB.Spawn(MGInfo.MapParameter, location);
				foreach (PlayerObject MO in Map.Players)
				{
					MO.Broadcast(new ObjectFlagColour
					{
						ObjectID = FlagB.ObjectID,
						FlagColour = FlagB.FlagColour,
						FlagShape = FlagB.FlagShape,
						name = FlagB.Name
					});
				}
				foreach (PlayerObject player in Players)
				{
					player.Connection.ReceiveChat($"TeamA Flag has respawned at {location}", MessageType.System);
				}
			}
		}
	}
}
