using CartoonMirDB;

namespace Library.SystemModels
{
	public sealed class CraftLevelInfo : DBObject
	{
		private CraftType _Type;

		private int _Level;

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
	}
}
