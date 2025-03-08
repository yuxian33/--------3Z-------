using CartoonMirDB;

namespace Library.SystemModels
{
    public sealed class FubenInfo : DBObject
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
        /*
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
        */
        public FubenSchool School
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
        private FubenSchool _School;

        public MonsterInfo Monster
        {
            get { return _Monster; }
            set
            {
                if (_Monster == value) return;

                var oldValue = _Monster;
                _Monster = value;

                OnChanged(oldValue, value, "Monster");
            }
        }
        private MonsterInfo _Monster;

        public int Icon
        {
            get { return _Icon; }
            set
            {
                if (_Icon == value) return;

                var oldValue = _Icon;
                _Icon = value;

                OnChanged(oldValue, value, "Icon");
            }
        }
        private int _Icon;

        public int FubenDian
        {
            get { return _FubenDian; }
            set
            {
                if (_FubenDian == value) return;

                var oldValue = _FubenDian;
                _FubenDian = value;

                OnChanged(oldValue, value, "FubenDian");
            }
        }
        private int _FubenDian;

        public int Level
        {
            get { return _Level; }
            set
            {
                if (_Level == value) return;

                var oldValue = _Level;
                _Level = value;

                OnChanged(oldValue, value, "Level");
            }
        }
        private int _Level;

        public int JiangliDian
        {
            get { return _JiangliDian; }
            set
            {
                if (_JiangliDian == value) return;

                var oldValue = _JiangliDian;
                _JiangliDian = value;

                OnChanged(oldValue, value, "JiangliDian");
            }
        }
        private int _JiangliDian;

        public MapInfo MapParameter1
        {
            get { return _MapParameter1; }
            set
            {
                if (_MapParameter1 == value) return;

                var oldValue = _MapParameter1;
                _MapParameter1 = value;

                OnChanged(oldValue, value, "MapParameter1");
            }
        }
        private MapInfo _MapParameter1;

        public int Xdian
        {
            get { return _Xdian; }
            set
            {
                if (_Xdian == value) return;

                var oldValue = _Xdian;
                _Xdian = value;

                OnChanged(oldValue, value, "Xdian");
            }
        }
        private int _Xdian;

        public int Ydian
        {
            get { return _Ydian; }
            set
            {
                if (_Ydian == value) return;

                var oldValue = _Ydian;
                _Ydian = value;

                OnChanged(oldValue, value, "Ydian");
            }
        }
        private int _Ydian;

        public int MoveGold
        {
            get { return _MoveGold; }
            set
            {
                if (_MoveGold == value) return;

                var oldValue = _MoveGold;
                _MoveGold = value;

                OnChanged(oldValue, value, "MoveGold");
            }
        }
        private int _MoveGold;

        public string Description
        {
            get { return _Description; }
            set
            {
                if (_Description == value) return;

                var oldValue = _Description;
                _Description = value;

                OnChanged(oldValue, value, "Description");
            }
        }
        private string _Description;

    }
}
