using System.Collections.Generic;
using System.Drawing;
using CartoonMirDB;

namespace Library.SystemModels
{
    public sealed class MovementInfo : DBObject
    {
        public MapRegion SourceRegion
        {
            get { return _SourceRegion; }
            set
            {
                if (_SourceRegion == value) return;

                var oldValue = _SourceRegion;
                _SourceRegion = value;

                OnChanged(oldValue, value, "SourceRegion");
            }
        }
        private MapRegion _SourceRegion;

        public MapRegion DestinationRegion
        {
            get { return _DestinationRegion; }
            set
            {
                if (_DestinationRegion == value) return;

                var oldValue = _DestinationRegion;
                _DestinationRegion = value;

                OnChanged(oldValue, value, "DestinationRegion");
            }
        }
        private MapRegion _DestinationRegion;

        public MapIcon Icon
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
        private MapIcon _Icon;
        public bool Fuben
        {
            get { return _Fuben; }
            set
            {
                if (_Fuben == value) return;

                var oldValue = _Fuben;
                _Fuben = value;

                OnChanged(oldValue, value, "Fuben");
            }
        }
        private bool _Fuben;
        public bool Group
        {
            get { return _Group; }
            set
            {
                if (_Group == value) return;

                var oldValue = _Group;
                _Group = value;

                OnChanged(oldValue, value, "Group");
            }
        }
        private bool _Group;
        public bool Geren
        {
            get { return _Geren; }
            set
            {
                if (_Geren == value) return;

                var oldValue = _Geren;
                _Geren = value;

                OnChanged(oldValue, value, "Geren");
            }
        }
        private bool _Geren;

        public int Days
        {
            get { return _Days; }
            set
            {
                if (_Days == value) return;

                var oldValue = _Days;
                _Days = value;

                OnChanged(oldValue, value, "Days");
            }
        }
        private int _Days;
        public ItemInfo NeedItem
        {
            get { return _NeedItem; }
            set
            {
                if (_NeedItem == value) return;

                var oldValue = _NeedItem;
                _NeedItem = value;

                OnChanged(oldValue, value, "NeedItem");
            }
        }
        private ItemInfo _NeedItem;

        public RespawnInfo NeedSpawn
        {
            get { return _NeedSpawn; }
            set
            {
                if (_NeedSpawn == value) return;

                var oldValue = _NeedSpawn;
                _NeedSpawn = value;

                OnChanged(oldValue, value, "NeedSpawn");
            }
        }
        private RespawnInfo _NeedSpawn;

        public MovementEffect Effect
        {
            get { return _Effect; }
            set
            {
                if (_Effect == value) return;

                var oldValue = _Effect;
                _Effect = value;

                OnChanged(oldValue, value, "Effect");
            }
        }
        private MovementEffect _Effect;

        public RequiredClass RequiredClass
        {
            get { return _RequiredClass; }
            set
            {
                if (_RequiredClass == value) return;

                var oldValue = _RequiredClass;
                _RequiredClass = value;

                OnChanged(oldValue, value, "RequiredClass");
            }
        }
        private RequiredClass _RequiredClass;


        public RespawnInfo MonsterSpawn
        {
            get { return _MonsterSpawn; }
            set
            {
                if (_MonsterSpawn == value) return;

                var oldValue = _MonsterSpawn;
                _MonsterSpawn = value;

                OnChanged(oldValue, value, "MonsterSpawn");
            }
        }
        private RespawnInfo _MonsterSpawn;

        public ItemInfo GiveItem
        {
            get { return _GiveItem; }
            set
            {
                if (_GiveItem == value) return;

                var oldValue = _GiveItem;
                _GiveItem = value;

                OnChanged(oldValue, value, "GiveItem");
            }
        }
        private ItemInfo _GiveItem;

        public int GiveItemCount
        {
            get { return _GiveItemCount; }
            set
            {
                if (_GiveItemCount == value) return;

                var oldValue = _GiveItemCount;
                _GiveItemCount = value;

                OnChanged(oldValue, value, "GiveItemCount");
            }
        }
        private int _GiveItemCount;

        public int NeedItemCount
        {
            get { return _NeedItemCount; }
            set
            {
                if (_NeedItemCount == value) return;

                var oldValue = _NeedItemCount;
                _NeedItemCount = value;

                OnChanged(oldValue, value, "NeedItemCount");
            }
        }
        private int _NeedItemCount;

        public bool CurrentMapBoos
        {
            get { return _CurrentMapBoos; }
            set
            {
                if (_CurrentMapBoos == value) return;

                var oldValue = CurrentMapBoos;
                _CurrentMapBoos = value;

                OnChanged(oldValue, value, "CurrentMapBoos");
            }
        }
        private bool _CurrentMapBoos;

        public bool CurrentMapMon
        {
            get { return _CurrentMapMon; }
            set
            {
                if (_CurrentMapMon == value) return;

                var oldValue = _CurrentMapMon;
                _CurrentMapMon = value;

                OnChanged(oldValue, value, "CurrentMapMon");
            }
        }
        private bool _CurrentMapMon;

        public bool Jilu
        {
            get { return _Jilu; }
            set
            {
                if (_Jilu == value) return;

                var oldValue = _Jilu;
                _Jilu = value;

                OnChanged(oldValue, value, "Jilu");
            }
        }
        private bool _Jilu;

        public string JiluName
        {
            get { return _JiluName; }
            set
            {
                if (_JiluName == value) return;

                var oldValue = _JiluName;
                _JiluName = value;

                OnChanged(oldValue, value, "JiluName");
            }
        }
        private string _JiluName;



        protected internal override void OnCreated()
        {
            base.OnCreated();

            RequiredClass = RequiredClass.All;
        }
    }

}
