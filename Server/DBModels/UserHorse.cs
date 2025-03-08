using Library.SystemModels;
using CartoonMirDB;

namespace Server.DBModels
{
	[UserObject]
	public sealed class UserHorse : DBObject
	{
		private AccountInfo _Account;

		private HorseInfo _Info;

		private int _HorseNum;

		[Association("Horses")]
		public AccountInfo Account
		{
			get
			{
				return _Account;
			}
			set
			{
				if (_Account != value)
				{
					AccountInfo oldValue = _Account;
					_Account = value;
					OnChanged(oldValue, value, "Account");
				}
			}
		}

		public HorseInfo Info
		{
			get
			{
				return _Info;
			}
			set
			{
				if (_Info != value)
				{
					HorseInfo oldValue = _Info;
					_Info = value;
					OnChanged(oldValue, value, "Info");
				}
			}
		}

		public int HorseNum
		{
			get
			{
				return _HorseNum;
			}
			set
			{
				if (_HorseNum != value)
				{
					int oldValue = _HorseNum;
					_HorseNum = value;
					OnChanged(oldValue, value, "HorseNum");
				}
			}
		}

		protected override void OnDeleted()
		{
			Account = null;
			Info = null;
			base.OnDeleted();
		}

		public int ToClientInfo()
		{
			return HorseNum;
		}

		public override string ToString()
		{
			return Account?.EMailAddress ?? string.Empty;
		}
	}
}
