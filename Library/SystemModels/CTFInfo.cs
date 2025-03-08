using CartoonMirDB;

namespace Library.SystemModels
{
	public sealed class CTFInfo : DBObject
	{
		private MiniGameInfo _MiniGame;

		private MapRegion _TeamAFlagSpawn;

		private MapRegion _TeamBFlagSpawn;

		private MapRegion _TeamAFlagReturn;

		private MapRegion _TeamBFlagReturn;

		private MonsterInfo _FlagMonster;

		[Association("CTF")]
		public MiniGameInfo MiniGame
		{
			get
			{
				return _MiniGame;
			}
			set
			{
				if (_MiniGame != value)
				{
					MiniGameInfo oldValue = _MiniGame;
					_MiniGame = value;
					OnChanged(oldValue, value, "MiniGame");
				}
			}
		}

		public MapRegion TeamAFlagSpawn
		{
			get
			{
				return _TeamAFlagSpawn;
			}
			set
			{
				if (_TeamAFlagSpawn != value)
				{
					MapRegion oldValue = _TeamAFlagSpawn;
					_TeamAFlagSpawn = value;
					OnChanged(oldValue, value, "TeamAFlagSpawn");
				}
			}
		}

		public MapRegion TeamBFlagSpawn
		{
			get
			{
				return _TeamBFlagSpawn;
			}
			set
			{
				if (_TeamBFlagSpawn != value)
				{
					MapRegion oldValue = _TeamBFlagSpawn;
					_TeamBFlagSpawn = value;
					OnChanged(oldValue, value, "TeamBFlagSpawn");
				}
			}
		}

		public MapRegion TeamAFlagReturn
		{
			get
			{
				return _TeamAFlagReturn;
			}
			set
			{
				if (_TeamAFlagReturn != value)
				{
					MapRegion oldValue = _TeamAFlagReturn;
					_TeamAFlagReturn = value;
					OnChanged(oldValue, value, "TeamAFlagReturn");
				}
			}
		}

		public MapRegion TeamBFlagReturn
		{
			get
			{
				return _TeamBFlagReturn;
			}
			set
			{
				if (_TeamBFlagReturn != value)
				{
					MapRegion oldValue = _TeamBFlagReturn;
					_TeamBFlagReturn = value;
					OnChanged(oldValue, value, "TeamBFlagReturn");
				}
			}
		}

		public MonsterInfo FlagMonster
		{
			get
			{
				return _FlagMonster;
			}
			set
			{
				if (_FlagMonster != value)
				{
					MonsterInfo oldValue = _FlagMonster;
					_FlagMonster = value;
					OnChanged(oldValue, value, "FlagMonster");
				}
			}
		}
	}
}
