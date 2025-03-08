using CartoonMirDB;

namespace Library.SystemModels
{
	public sealed class RewardInfo : DBObject
	{
		private MiniGameInfo _MiniGame;

		private ItemInfo _Item;

		private int _Chance;

		private int _Amount;

		private bool _Top1;

		private bool _Top2;

		private bool _Top3;

		[Association("Rewards")]
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

		public ItemInfo Item
		{
			get
			{
				return _Item;
			}
			set
			{
				if (_Item != value)
				{
					ItemInfo oldValue = _Item;
					_Item = value;
					OnChanged(oldValue, value, "Item");
				}
			}
		}

		public int Chance
		{
			get
			{
				return _Chance;
			}
			set
			{
				if (_Chance != value)
				{
					int oldValue = _Chance;
					_Chance = value;
					OnChanged(oldValue, value, "Chance");
				}
			}
		}

		public int Amount
		{
			get
			{
				return _Amount;
			}
			set
			{
				if (_Amount != value)
				{
					int oldValue = _Amount;
					_Amount = value;
					OnChanged(oldValue, value, "Amount");
				}
			}
		}

		public bool Top1
		{
			get
			{
				return _Top1;
			}
			set
			{
				if (_Top1 != value)
				{
					bool oldValue = _Top1;
					_Top1 = value;
					OnChanged(oldValue, value, "Top1");
				}
			}
		}

		public bool Top2
		{
			get
			{
				return _Top2;
			}
			set
			{
				if (_Top2 != value)
				{
					bool oldValue = _Top2;
					_Top2 = value;
					OnChanged(oldValue, value, "Top2");
				}
			}
		}

		public bool Top3
		{
			get
			{
				return _Top3;
			}
			set
			{
				if (_Top3 != value)
				{
					bool oldValue = _Top3;
					_Top3 = value;
					OnChanged(oldValue, value, "Top3");
				}
			}
		}
	}
}
