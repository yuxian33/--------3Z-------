using Library;
using CartoonMirDB;

namespace Server.DBModels
{
	[UserObject]
	public sealed class UserShenmiCount : DBObject
	{
		private AccountInfo _Account;


		[Association("ShenmiCount")]
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

		public long ShenmiCountyi
		{
			get
			{
				return _ShenmiCountyi;
			}
			set
			{
				if (_ShenmiCountyi != value)
				{
                    long oldValue = _ShenmiCountyi;
                    _ShenmiCountyi = value;
					OnChanged(oldValue, value, "ShenmiCountyi");
				}
			}
		}
        public long _ShenmiCountyi;

        public long ShenmiCounter
        {
            get
            {
                return _ShenmiCounter;
            }
            set
            {
                if (_ShenmiCounter != value)
                {
                    long oldValue = _ShenmiCounter;
                    _ShenmiCounter = value;
                    OnChanged(oldValue, value, "ShenmiCounter");
                }
            }
        }
        public long _ShenmiCounter;

        public long ShenmiCountsan
        {
            get
            {
                return _ShenmiCountsan;
            }
            set
            {
                if (_ShenmiCountsan != value)
                {
                    long oldValue = _ShenmiCountsan;
                    _ShenmiCountsan = value;
                    OnChanged(oldValue, value, "ShenmiCountsan");
                }
            }
        }
        public long _ShenmiCountsan;

        public long ShenmiCountsi
        {
            get
            {
                return _ShenmiCountsi;
            }
            set
            {
                if (_ShenmiCountsi != value)
                {
                    long oldValue = _ShenmiCountsi;
                    _ShenmiCountsi = value;
                    OnChanged(oldValue, value, "ShenmiCountsi");
                }
            }
        }
        public long _ShenmiCountsi;

        public long ShenmiCountwu
        {
            get
            {
                return _ShenmiCountwu;
            }
            set
            {
                if (_ShenmiCountwu != value)
                {
                    long oldValue = _ShenmiCountwu;
                    _ShenmiCountwu = value;
                    OnChanged(oldValue, value, "ShenmiCountwu");
                }
            }
        }
        public long _ShenmiCountwu;

        public long ShenmiCountliu
        {
            get
            {
                return _ShenmiCountliu;
            }
            set
            {
                if (_ShenmiCountliu != value)
                {
                    long oldValue = _ShenmiCountliu;
                    _ShenmiCountliu = value;
                    OnChanged(oldValue, value, "ShenmiCountliu");
                }
            }
        }
        public long _ShenmiCountliu;

        public long ShenmiCountqi
        {
            get
            {
                return _ShenmiCountqi;
            }
            set
            {
                if (_ShenmiCountqi != value)
                {
                    long oldValue = _ShenmiCountqi;
                    _ShenmiCountqi = value;
                    OnChanged(oldValue, value, "ShenmiCountqi");
                }
            }
        }
        public long _ShenmiCountqi;

        public long ShenmiCountba
        {
            get
            {
                return _ShenmiCountba;
            }
            set
            {
                if (_ShenmiCountba != value)
                {
                    long oldValue = _ShenmiCountba;
                    _ShenmiCountba = value;
                    OnChanged(oldValue, value, "ShenmiCountba");
                }
            }
        }
        public long _ShenmiCountba;

        public long ShenmiCountjiu
        {
            get
            {
                return _ShenmiCountjiu;
            }
            set
            {
                if (_ShenmiCountjiu != value)
                {
                    long oldValue = _ShenmiCountjiu;
                    _ShenmiCountjiu = value;
                    OnChanged(oldValue, value, "ShenmiCountjiu");
                }
            }
        }
        public long _ShenmiCountjiu;

        public long ShenmiCountshi
        {
            get
            {
                return _ShenmiCountshi;
            }
            set
            {
                if (_ShenmiCountshi != value)
                {
                    long oldValue = _ShenmiCountshi;
                    _ShenmiCountshi = value;
                    OnChanged(oldValue, value, "ShenmiCountshi");
                }
            }
        }
        public long _ShenmiCountshi;

	}
}
