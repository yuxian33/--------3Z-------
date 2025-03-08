using Library;
using Library.Network.ServerPackets;
using Server.DBModels;
using Server.Envir;
using System.Linq;

namespace Server.Models.Monsters
{
	public class CTFFlag : MonsterObject
	{
		public CaptureTheFlag CTFGame;

		public override bool CanMove => false;

		public CTFFlag()
		{
			Direction = MirDirection.Up;
		}

		public override int Attacked(MapObject attacker, int power, Element element, bool canReflect = true, bool ignoreShield = false, bool canCrit = true, bool canStruck = true)
		{
			if (attacker == null || attacker.Race != ObjectType.Player || !Functions.InRange(attacker.CurrentLocation, CurrentLocation, 2))
			{
				return 0;
			}
			PlayerObject player = (PlayerObject)attacker;
			if (CTFGame == null)
			{
				return 0;
			}
			int result = 0;
			if (EventTeam == 1 && CTFGame.TeamB.Contains(player.Character))
			{
				result = base.Attacked(attacker, 1, element, canReflect, ignoreShield, canCrit, canStruck: true);
				foreach (CharacterInfo chara2 in CTFGame.TeamA)
				{
					PlayerObject teamplayer2 = SEnvir.Players.FirstOrDefault((PlayerObject x) => x.Character == chara2);
					teamplayer2.Connection.ReceiveChat("Your flag is under attack", MessageType.System);
				}
			}
			if (EventTeam == 2 && CTFGame.TeamA.Contains(player.Character))
			{
				result = base.Attacked(attacker, 1, element, canReflect, ignoreShield, canCrit, canStruck: true);
				foreach (CharacterInfo chara in CTFGame.TeamB)
				{
					PlayerObject teamplayer = SEnvir.Players.FirstOrDefault((PlayerObject x) => x.Character == chara);
					teamplayer.Connection.ReceiveChat("Your flag is under attack", MessageType.System);
				}
			}
			if (result > 0)
			{
				base.EXPOwner = player;
			}
			else
			{
				base.EXPOwner = null;
			}
			return result;
		}

		public override bool ApplyPoison(Poison p)
		{
			return false;
		}

		public override void ProcessRegen()
		{
		}

		public override bool ShouldAttackTarget(MapObject ob)
		{
			return false;
		}

		public override bool CanAttackTarget(MapObject ob)
		{
			return false;
		}

		public override void Die()
		{
			if (CTFGame != null)
			{
				if (base.EXPOwner.HasNoNode())
				{
					base.Die();
					return;
				}
				base.EXPOwner.HasFlag = true;
				UserArenaPvPStats stats = SEnvir.GetArenaPvPStats(base.EXPOwner);
				if (stats != null)
				{
					stats.FlagCaptures++;
				}
				foreach (PlayerObject player in CTFGame.Players)
				{
					player.Enqueue(new HasFlag
					{
						ObjectID = base.EXPOwner.ObjectID,
						hasFLag = true
					});
				}
				if (EventTeam == 1)
				{
					CTFGame.FlagAHolder = base.EXPOwner;
					foreach (PlayerObject teamplayer2 in CTFGame.Players)
					{
						teamplayer2.Connection.ReceiveChat($"Team A flag was captured by {base.EXPOwner.Character.CharacterName}", MessageType.System);
					}
				}
				if (EventTeam == 2)
				{
					CTFGame.FlagBHolder = base.EXPOwner;
					foreach (PlayerObject teamplayer in CTFGame.Players)
					{
						teamplayer.Connection.ReceiveChat($"Team B flag was captured by {base.EXPOwner.Character.CharacterName}", MessageType.System);
					}
				}
			}
			base.Die();
		}
	}
}
