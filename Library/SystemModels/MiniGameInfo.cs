using CartoonMirDB;

namespace Library.SystemModels
{
	public sealed class MiniGameInfo : DBObject
	{
		private MiniGames _MiniGame;

		private MapInfo _MapParameter;

		private MapInfo _MapLobby;

		private int _MinLevel;

		private MapRegion _TeamASpawn;

		private MapRegion _TeamBSpawn;

		private int _MaxLevel;

		private int _EntryFee;

		private int _Duration;

		private bool _TeamGame;

		private bool _CanRevive;

		private int _ReviveDelay;

		private int _MinPlayers;

		private int _MaxPlayers;

		public MiniGames MiniGame
		{
			get
			{
				return _MiniGame;
			}
			set
			{
				if (_MiniGame != value)
				{
					MiniGames oldValue = _MiniGame;
					_MiniGame = value;
					OnChanged(oldValue, value, "MiniGame");
				}
			}
		}

		public MapInfo MapParameter
		{
			get
			{
				return _MapParameter;
			}
			set
			{
				if (_MapParameter != value)
				{
					MapInfo oldValue = _MapParameter;
					_MapParameter = value;
					OnChanged(oldValue, value, "MapParameter");
				}
			}
		}

		public MapInfo MapLobby
		{
			get
			{
				return _MapLobby;
			}
			set
			{
				if (_MapLobby != value)
				{
					MapInfo oldValue = _MapLobby;
					_MapLobby = value;
					OnChanged(oldValue, value, "MapLobby");
				}
			}
		}

		public int MinLevel
		{
			get
			{
				return _MinLevel;
			}
			set
			{
				if (_MinLevel != value)
				{
					int oldValue = _MinLevel;
					_MinLevel = value;
					OnChanged(oldValue, value, "MinLevel");
				}
			}
		}

		public MapRegion TeamASpawn
		{
			get
			{
				return _TeamASpawn;
			}
			set
			{
				if (_TeamASpawn != value)
				{
					MapRegion oldValue = _TeamASpawn;
					_TeamASpawn = value;
					OnChanged(oldValue, value, "TeamASpawn");
				}
			}
		}

		public MapRegion TeamBSpawn
		{
			get
			{
				return _TeamBSpawn;
			}
			set
			{
				if (_TeamBSpawn != value)
				{
					MapRegion oldValue = _TeamBSpawn;
					_TeamBSpawn = value;
					OnChanged(oldValue, value, "TeamBSpawn");
				}
			}
		}

		public int MaxLevel
		{
			get
			{
				return _MaxLevel;
			}
			set
			{
				if (_MaxLevel != value)
				{
					int oldValue = _MaxLevel;
					_MaxLevel = value;
					OnChanged(oldValue, value, "MaxLevel");
				}
			}
		}

		public int EntryFee
		{
			get
			{
				return _EntryFee;
			}
			set
			{
				if (_EntryFee != value)
				{
					int oldValue = _EntryFee;
					_EntryFee = value;
					OnChanged(oldValue, value, "EntryFee");
				}
			}
		}

		public int Duration
		{
			get
			{
				return _Duration;
			}
			set
			{
				if (_Duration != value)
				{
					int oldValue = _Duration;
					_Duration = value;
					OnChanged(oldValue, value, "Duration");
				}
			}
		}

		public bool TeamGame
		{
			get
			{
				return _TeamGame;
			}
			set
			{
				if (_TeamGame != value)
				{
					bool oldValue = _TeamGame;
					_TeamGame = value;
					OnChanged(oldValue, value, "TeamGame");
				}
			}
		}

		public bool CanRevive
		{
			get
			{
				return _CanRevive;
			}
			set
			{
				if (_CanRevive != value)
				{
					bool oldValue = _CanRevive;
					_CanRevive = value;
					OnChanged(oldValue, value, "CanRevive");
				}
			}
		}

		public int ReviveDelay
		{
			get
			{
				return _ReviveDelay;
			}
			set
			{
				if (_ReviveDelay != value)
				{
					int oldValue = _ReviveDelay;
					_ReviveDelay = value;
					OnChanged(oldValue, value, "ReviveDelay");
				}
			}
		}

		public int MinPlayers
		{
			get
			{
				return _MinPlayers;
			}
			set
			{
				if (_MinPlayers != value)
				{
					int oldValue = _MinPlayers;
					_MinPlayers = value;
					OnChanged(oldValue, value, "MinPlayers");
				}
			}
		}

		public int MaxPlayers
		{
			get
			{
				return _MaxPlayers;
			}
			set
			{
				if (_MaxPlayers != value)
				{
					int oldValue = _MaxPlayers;
					_MaxPlayers = value;
					OnChanged(oldValue, value, "MaxPlayers");
				}
			}
		}

		[Association("Rewards", true)]
		public DBBindingList<RewardInfo> Rewards
		{
			get;
			set;
		}

		[Association("CTF", true)]
		public DBBindingList<CTFInfo> CTFInfo
		{
			get;
			set;
		}
	}
}
