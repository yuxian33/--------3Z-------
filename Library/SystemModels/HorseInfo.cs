using CartoonMirDB;

namespace Library.SystemModels
{
	public class HorseInfo : DBObject
	{
		private HorseType _Horse;

		private MonsterInfo _MonsterInfo;

		private int _Price;

		private bool _Available;

		public HorseType Horse
		{
			get
			{
				return _Horse;
			}
			set
			{
				if (_Horse != value)
				{
					HorseType oldValue = _Horse;
					_Horse = value;
					OnChanged(oldValue, value, "Horse");
				}
			}
		}

		public MonsterInfo MonsterInfo
		{
			get
			{
				return _MonsterInfo;
			}
			set
			{
				if (_MonsterInfo != value)
				{
					MonsterInfo oldValue = _MonsterInfo;
					_MonsterInfo = value;
					OnChanged(oldValue, value, "MonsterInfo");
				}
			}
		}

		public int Price
		{
			get
			{
				return _Price;
			}
			set
			{
				if (_Price != value)
				{
					int oldValue = _Price;
					_Price = value;
					OnChanged(oldValue, value, "Price");
				}
			}
		}

		public bool Available
		{
			get
			{
				return _Available;
			}
			set
			{
				if (_Available != value)
				{
					bool oldValue = _Available;
					_Available = value;
					OnChanged(oldValue, value, "Available");
				}
			}
		}
	}
}
