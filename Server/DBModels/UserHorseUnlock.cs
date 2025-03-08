using Library.SystemModels;
using CartoonMirDB;

namespace Server.DBModels
{
	[UserObject]
	public sealed class UserHorseUnlock : DBObject
	{
		private AccountInfo _Account;

		private HorseInfo _HorseInfo;

		[Association("HorseUnlocks")]
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

		public HorseInfo HorseInfo
		{
			get
			{
				return _HorseInfo;
			}
			set
			{
				if (_HorseInfo != value)
				{
					HorseInfo oldValue = _HorseInfo;
					_HorseInfo = value;
					OnChanged(oldValue, value, "HorseInfo");
				}
			}
		}

		protected override void OnDeleted()
		{
			Account = null;
			base.OnDeleted();
		}
	}
}
