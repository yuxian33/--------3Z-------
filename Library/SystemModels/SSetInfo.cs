using MirDB;

namespace Library.SystemModels
{
    public class SSetInfo : DBObject
    {
        public string SetName
        {
            get { return _SetName; }
            set
            {
                if (_SetName == value) return;

                var oldValue = _SetName;
                _SetName = value;

                OnChanged(oldValue, value, "SetName");
            }
        }
        private string _SetName;

        [Association("SSet")]
        public DBBindingList<ItemInfo> Items { get; set; }

        [Association("SetStats")]
        public DBBindingList<SSetInfoStat> SetStats { get; set; }
    }
}
