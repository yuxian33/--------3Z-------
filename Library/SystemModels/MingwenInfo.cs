using CartoonMirDB;

namespace Library.SystemModels
{
    public sealed class MingwenInfo : DBObject
    {
        public string Name
        {
            get { return _Name; }
            set
            {
                if (_Name == value) return;

                var oldValue = _Name;
                _Name = value;

                OnChanged(oldValue, value, "Name");
            }
        }
        private string _Name;

        public MagicType Magic
        {
            get { return _Magic; }
            set
            {
                if (_Magic == value) return;

                var oldValue = _Magic;
                _Magic = value;

                OnChanged(oldValue, value, "Magic");
            }
        }
        private MagicType _Magic;

        public MirClass Class
        {
            get { return _Class; }
            set
            {
                if (_Class == value) return;

                var oldValue = _Class;
                _Class = value;

                OnChanged(oldValue, value, "Class");
            }
        }
        private MirClass _Class;

        public MagicSchool School
        {
            get { return _School; }
            set
            {
                if (_School == value) return;

                var oldValue = _School;
                _School = value;

                OnChanged(oldValue, value, "School");
            }
        }
        private MagicSchool _School;

        public int XiGailv
        {
            get { return _XiGailv; }
            set
            {
                if (_XiGailv == value) return;

                var oldValue = _XiGailv;
                _XiGailv = value;

                OnChanged(oldValue, value, "XiGailv");
            }
        }
        private int _XiGailv;
        public int Canshu0
        {
            get { return _Canshu0; }
            set
            {
                if (_Canshu0 == value) return;

                var oldValue = _Canshu0;
                _Canshu0 = value;

                OnChanged(oldValue, value, "Canshu0");
            }
        }
        private int _Canshu0;

        public int Canshu1
        {
            get { return _Canshu1; }
            set
            {
                if (_Canshu1 == value) return;

                var oldValue = _Canshu1;
                _Canshu1 = value;

                OnChanged(oldValue, value, "Canshu1");
            }
        }
        private int _Canshu1;
        public int Canshu2
        {
            get { return _Canshu2; }
            set
            {
                if (_Canshu2 == value) return;

                var oldValue = _Canshu2;
                _Canshu2 = value;

                OnChanged(oldValue, value, "Canshu2");
            }
        }
        private int _Canshu2;

        public int Canshu3
        {
            get { return _Canshu3; }
            set
            {
                if (_Canshu3 == value) return;

                var oldValue = _Canshu3;
                _Canshu3 = value;

                OnChanged(oldValue, value, "Canshu3");
            }
        }
        private int _Canshu3;

        public int Canshu4
        {
            get { return _Canshu4; }
            set
            {
                if (_Canshu4 == value) return;

                var oldValue = _Canshu4;
                _Canshu4 = value;

                OnChanged(oldValue, value, "Canshu4");
            }
        }
        private int _Canshu4;

        public int Canshu5
        {
            get { return _Canshu5; }
            set
            {
                if (_Canshu5 == value) return;

                var oldValue = _Canshu5;
                _Canshu5 = value;

                OnChanged(oldValue, value, "Canshu5");
            }
        }
        private int _Canshu5;

        public decimal Canshu6
        {
            get { return _Canshu6; }
            set
            {
                if (_Canshu6 == value) return;

                var oldValue = _Canshu6;
                _Canshu6 = value;

                OnChanged(oldValue, value, "Canshu6");
            }
        }
        private decimal _Canshu6;

        public int Canshu7
        {
            get { return _Canshu7; }
            set
            {
                if (_Canshu7 == value) return;

                var oldValue = _Canshu7;
                _Canshu7 = value;

                OnChanged(oldValue, value, "Canshu7");
            }
        }
        private int _Canshu7;

        public int Canshu8
        {
            get { return _Canshu8; }
            set
            {
                if (_Canshu8 == value) return;

                var oldValue = _Canshu8;
                _Canshu8 = value;

                OnChanged(oldValue, value, "Canshu8");
            }
        }
        private int _Canshu8;

        public int Canshu9
        {
            get { return _Canshu9; }
            set
            {
                if (_Canshu9 == value) return;

                var oldValue = _Canshu9;
                _Canshu9 = value;

                OnChanged(oldValue, value, "Canshu9");
            }
        }
        private int _Canshu9;

        public int Canshu10
        {
            get { return _Canshu10; }
            set
            {
                if (_Canshu10 == value) return;

                var oldValue = _Canshu10;
                _Canshu10 = value;

                OnChanged(oldValue, value, "Canshu10");
            }
        }
        private int _Canshu10;

        public int Canshu11
        {
            get { return _Canshu11; }
            set
            {
                if (_Canshu11 == value) return;

                var oldValue = _Canshu11;
                _Canshu11 = value;

                OnChanged(oldValue, value, "Canshu11");
            }
        }
        private int _Canshu11;

        public string Canshu12
        {
            get { return _Canshu12; }
            set
            {
                if (_Canshu12 == value) return;

                var oldValue = _Canshu12;
                _Canshu12 = value;

                OnChanged(oldValue, value, "Canshu12");
            }
        }
        private string _Canshu12;

        public int MingWenID
        {
            get { return _MingWenID; }
            set
            {
                if (_MingWenID == value) return;

                var oldValue = _MingWenID;
                _MingWenID = value;

                OnChanged(oldValue, value, "MingWenID");
            }
        }
        private int _MingWenID;

        public string MwJieshi
        {
            get { return _MwJieshi; }
            set
            {
                if (_MwJieshi == value) return;

                var oldValue = _MwJieshi;
                _MwJieshi = value;

                OnChanged(oldValue, value, "MwJieshi");
            }
        }
        private string _MwJieshi;

        public string CsShuoming
        {
            get { return _CsShuoming; }
            set
            {
                if (_CsShuoming == value) return;

                var oldValue = _CsShuoming;
                _CsShuoming = value;

                OnChanged(oldValue, value, "CsShuoming");
            }
        }
        private string _CsShuoming;

    }
}
