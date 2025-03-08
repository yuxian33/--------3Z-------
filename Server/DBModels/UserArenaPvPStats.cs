using Library;
using Library.SystemModels;
using CartoonMirDB;
using System;

namespace Server.DBModels
{
	[UserObject]
	public class UserArenaPvPStats : DBObject
	{
		private CharacterInfo _Character;

		private DateTime _PvPEventTime;

		private MiniGames _MiniGame;

		private string _CharacterName;

		private string _GuildName;

		private int _Level;

		private MirClass _Class;

		private int _PvPDamageTaken;

		private int _PvPDamageDealt;

		private int _PvPKillCount;

		private int _PvPDeathCount;

		private int _FlagCaptures;

		private int _FlagSaves;

		public CharacterInfo Character
		{
			get
			{
				return _Character;
			}
			set
			{
				if (_Character != value)
				{
					CharacterInfo oldValue = _Character;
					_Character = value;
					OnChanged(oldValue, value, "Character");
				}
			}
		}

		public DateTime PvPEventTime
		{
			get
			{
				return _PvPEventTime;
			}
			set
			{
				if (!(_PvPEventTime == value))
				{
					DateTime oldValue = _PvPEventTime;
					_PvPEventTime = value;
					OnChanged(oldValue, value, "PvPEventTime");
				}
			}
		}

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

		public string CharacterName
		{
			get
			{
				return _CharacterName;
			}
			set
			{
				if (!(_CharacterName == value))
				{
					string oldValue = _CharacterName;
					_CharacterName = value;
					OnChanged(oldValue, value, "CharacterName");
				}
			}
		}

		public string GuildName
		{
			get
			{
				return _GuildName;
			}
			set
			{
				if (!(_GuildName == value))
				{
					string oldValue = _GuildName;
					_GuildName = value;
					OnChanged(oldValue, value, "GuildName");
				}
			}
		}

		public int Level
		{
			get
			{
				return _Level;
			}
			set
			{
				if (_Level != value)
				{
					int oldValue = _Level;
					_Level = value;
					OnChanged(oldValue, value, "Level");
				}
			}
		}

		public MirClass Class
		{
			get
			{
				return _Class;
			}
			set
			{
				if (_Class != value)
				{
					MirClass oldValue = _Class;
					_Class = value;
					OnChanged(oldValue, value, "Class");
				}
			}
		}

		public int PvPDamageTaken
		{
			get
			{
				return _PvPDamageTaken;
			}
			set
			{
				if (_PvPDamageTaken != value)
				{
					int oldValue = _PvPDamageTaken;
					_PvPDamageTaken = value;
					OnChanged(oldValue, value, "PvPDamageTaken");
				}
			}
		}

		public int PvPDamageDealt
		{
			get
			{
				return _PvPDamageDealt;
			}
			set
			{
				if (_PvPDamageDealt != value)
				{
					int oldValue = _PvPDamageDealt;
					_PvPDamageDealt = value;
					OnChanged(oldValue, value, "PvPDamageDealt");
				}
			}
		}

		public int PvPKillCount
		{
			get
			{
				return _PvPKillCount;
			}
			set
			{
				if (_PvPKillCount != value)
				{
					int oldValue = _PvPKillCount;
					_PvPKillCount = value;
					OnChanged(oldValue, value, "PvPKillCount");
				}
			}
		}

		public int PvPDeathCount
		{
			get
			{
				return _PvPDeathCount;
			}
			set
			{
				if (_PvPDeathCount != value)
				{
					int oldValue = _PvPDeathCount;
					_PvPDeathCount = value;
					OnChanged(oldValue, value, "PvPDeathCount");
				}
			}
		}

		public int FlagCaptures
		{
			get
			{
				return _FlagCaptures;
			}
			set
			{
				if (_FlagCaptures != value)
				{
					int oldValue = _FlagCaptures;
					_FlagCaptures = value;
					OnChanged(oldValue, value, "FlagCaptures");
				}
			}
		}

		public int FlagSaves
		{
			get
			{
				return _FlagSaves;
			}
			set
			{
				if (_FlagSaves != value)
				{
					int oldValue = _FlagSaves;
					_FlagSaves = value;
					OnChanged(oldValue, value, "FlagSaves");
				}
			}
		}
	}
}
