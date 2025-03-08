using CartoonMirDB;

namespace Library.SystemModels
{
	public sealed class CraftItemInfo : DBObject
	{
		private CraftType _Type;

		private int _Level;

		private ItemInfo _Item;

		private ItemInfo _Ingredient1;

		private int _Ingredient1Amount;

		private ItemInfo _Ingredient2;

		private int _Ingredient2Amount;

		private ItemInfo _Ingredient3;

		private int _Ingredient3Amount;

		private ItemInfo _Ingredient4;

		private int _Ingredient4Amount;

		private int _Cost;

		private int _Chance;

		private int _Amount;

		private int _Exp;

		public CraftType Type
		{
			get
			{
				return _Type;
			}
			set
			{
				if (_Type != value)
				{
					CraftType oldValue = _Type;
					_Type = value;
					OnChanged(oldValue, value, "Type");
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

		[Association("Crafting")]
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

		public ItemInfo Ingredient1
		{
			get
			{
				return _Ingredient1;
			}
			set
			{
				if (_Ingredient1 != value)
				{
					ItemInfo oldValue = _Ingredient1;
					_Ingredient1 = value;
					OnChanged(oldValue, value, "Ingredient1");
				}
			}
		}

		public int Ingredient1Amount
		{
			get
			{
				return _Ingredient1Amount;
			}
			set
			{
				if (_Ingredient1Amount != value)
				{
					int oldValue = _Ingredient1Amount;
					_Ingredient1Amount = value;
					OnChanged(oldValue, value, "Ingredient1Amount");
				}
			}
		}

		public ItemInfo Ingredient2
		{
			get
			{
				return _Ingredient2;
			}
			set
			{
				if (_Ingredient2 != value)
				{
					ItemInfo oldValue = _Ingredient2;
					_Ingredient2 = value;
					OnChanged(oldValue, value, "Ingredient2");
				}
			}
		}

		public int Ingredient2Amount
		{
			get
			{
				return _Ingredient2Amount;
			}
			set
			{
				if (_Ingredient2Amount != value)
				{
					int oldValue = _Ingredient2Amount;
					_Ingredient2Amount = value;
					OnChanged(oldValue, value, "Ingredient2Amount");
				}
			}
		}

		public ItemInfo Ingredient3
		{
			get
			{
				return _Ingredient3;
			}
			set
			{
				if (_Ingredient3 != value)
				{
					ItemInfo oldValue = _Ingredient3;
					_Ingredient3 = value;
					OnChanged(oldValue, value, "Ingredient3");
				}
			}
		}

		public int Ingredient3Amount
		{
			get
			{
				return _Ingredient3Amount;
			}
			set
			{
				if (_Ingredient3Amount != value)
				{
					int oldValue = _Ingredient3Amount;
					_Ingredient3Amount = value;
					OnChanged(oldValue, value, "Ingredient3Amount");
				}
			}
		}

		public ItemInfo Ingredient4
		{
			get
			{
				return _Ingredient4;
			}
			set
			{
				if (_Ingredient4 != value)
				{
					ItemInfo oldValue = _Ingredient4;
					_Ingredient4 = value;
					OnChanged(oldValue, value, "Ingredient4");
				}
			}
		}

		public int Ingredient4Amount
		{
			get
			{
				return _Ingredient4Amount;
			}
			set
			{
				if (_Ingredient4Amount != value)
				{
					int oldValue = _Ingredient4Amount;
					_Ingredient4Amount = value;
					OnChanged(oldValue, value, "Ingredient4Amount");
				}
			}
		}

		public int Cost
		{
			get
			{
				return _Cost;
			}
			set
			{
				if (_Cost != value)
				{
					int oldValue = _Cost;
					_Cost = value;
					OnChanged(oldValue, value, "Cost");
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

		public int Exp
		{
			get
			{
				return _Exp;
			}
			set
			{
				if (_Exp != value)
				{
					int oldValue = _Exp;
					_Exp = value;
					OnChanged(oldValue, value, "Exp");
				}
			}
		}

		protected internal override void OnCreated()
		{
			base.OnCreated();
			Amount = 1;
		}
	}
}
