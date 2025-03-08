using CartoonMirDB;

namespace Library.SystemModels
{
    public sealed class MonsterInfo : DBObject
    {
        public string MonsterName
        {
            get { return _MonsterName; }
            set
            {
                if (_MonsterName == value) return;

                var oldValue = _MonsterName;
                _MonsterName = value;

                OnChanged(oldValue, value, "MonsterName");
            }
        }
        private string _MonsterName;

        public MonsterImage Image
        {
            get { return _Image; }
            set
            {
                if (_Image == value) return;

                var oldValue = _Image;
                _Image = value;

                OnChanged(oldValue, value, "Image");
            }
        }
        private MonsterImage _Image;

        public LibraryFile File
        {
            get
            {
                return this._File;
            }
            set
            {
                if (this._File == value)
                    return;
                LibraryFile file = this._File;
                this._File = value;
                this.OnChanged((object)file, (object)value, nameof(File));
            }
        }
        private LibraryFile _File;

        public SoundIndex AttackSound
        {
            get
            {
                return this._AttackSound;
            }
            set
            {
                if (this._AttackSound == value)
                    return;
                SoundIndex attackSound = this._AttackSound;
                this._AttackSound = value;
                this.OnChanged((object)attackSound, (object)value, nameof(AttackSound));
            }
        }
        private SoundIndex _AttackSound;

        public SoundIndex StruckSound
        {
            get
            {
                return this._StruckSound;
            }
            set
            {
                if (this._StruckSound == value)
                    return;
                SoundIndex struckSound = this._StruckSound;
                this._StruckSound = value;
                this.OnChanged((object)struckSound, (object)value, nameof(StruckSound));
            }
        }
        private SoundIndex _StruckSound;

        public SoundIndex DieSound
        {
            get
            {
                return this._DieSound;
            }
            set
            {
                if (this._DieSound == value)
                    return;
                SoundIndex dieSound = this._DieSound;
                this._DieSound = value;
                this.OnChanged((object)dieSound, (object)value, nameof(DieSound));
            }
        }
        private SoundIndex _DieSound;

        public int BodyShape
        {
            get
            {
                return this._BodyShape;
            }
            set
            {
                if (this._BodyShape == value)
                    return;
                int bodyShape = this._BodyShape;
                this._BodyShape = value;
                this.OnChanged((object)bodyShape, (object)value, nameof(BodyShape));
            }
        }
        private int _BodyShape;

        public int AI
        {
            get { return _AI; }
            set
            {
                if (_AI == value) return;

                var oldValue = _AI;
                _AI = value;

                OnChanged(oldValue, value, "AI");
            }
        }
        private int _AI;

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

        public int ViewRange
        {
            get { return _ViewRange; }
            set
            {
                if (_ViewRange == value) return;

                var oldValue = _ViewRange;
                _ViewRange = value;

                OnChanged(oldValue, value, "ViewRange");
            }
        }
        private int _ViewRange;

        public int CoolEye
        {
            get { return _CoolEye; }
            set
            {
                if (_CoolEye == value) return;

                var oldValue = _CoolEye;
                _CoolEye = value;

                OnChanged(oldValue, value, "CoolEye");
            }
        }
        private int _CoolEye;

        public decimal Experience
        {
            get { return _Experience; }
            set
            {
                if (_Experience == value) return;

                var oldValue = _Experience;
                _Experience = value;

                OnChanged(oldValue, value, "Experience");
            }
        }
        private decimal _Experience;

   
        public int Shengwang
        {
            get { return _Shengwang; }
            set
            {
                if (_Shengwang == value) return;

                var oldValue = _Shengwang;
                _Shengwang = value;

                OnChanged(oldValue, value, "Shengwang");
            }
        }
        private int _Shengwang;

        public bool Undead
        {
            get { return _Undead; }
            set
            {
                if (_Undead == value) return;

                var oldValue = _Undead;
                _Undead = value;

                OnChanged(oldValue, value, "Undead");
            }
        }
        private bool _Undead;


        public bool CanPush
        {
            get { return _CanPush; }
            set
            {
                if (_CanPush == value) return;

                var oldValue = _CanPush;
                _CanPush = value;

                OnChanged(oldValue, value, "CanPush");
            }
        }
        private bool _CanPush;

        public bool CanTame
        {
            get { return _CanTame; }
            set
            {
                if (_CanTame == value) return;

                var oldValue = _CanTame;
                _CanTame = value;

                OnChanged(oldValue, value, "CanTame");
            }
        }
        private bool _CanTame;
        

        public int AttackDelay
        {
            get { return _AttackDelay; }
            set
            {
                if (_AttackDelay == value) return;

                var oldValue = _AttackDelay;
                _AttackDelay = value;

                OnChanged(oldValue, value, "AttackDelay");
            }
        }
        private int _AttackDelay;

        public int MoveDelay
        {
            get { return _MoveDelay; }
            set
            {
                if (_MoveDelay == value) return;

                var oldValue = _MoveDelay;
                _MoveDelay = value;

                OnChanged(oldValue, value, "MoveDelay");
            }
        }
        private int _MoveDelay;

        public bool IsBoss
        {
            get { return _IsBoss; }
            set
            {
                if (_IsBoss == value) return;

                var oldValue = _IsBoss;
                _IsBoss = value;

                OnChanged(oldValue, value, "IsBoss");
            }
        }
        private bool _IsBoss;

        public MonsterFlag Flag
        {
            get { return _Flag; }
            set
            {
                if (_Flag == value) return;

                var oldValue = _Flag;
                _Flag = value;

                OnChanged(oldValue, value, "Flag");
            }
        }
        private MonsterFlag _Flag;
        public MonsterRarity Rarity
        {
            get { return _Rarity; }
            set
            {
                if (_Rarity == value) return;

                var oldValue = _Rarity;
                _Rarity = value;

                OnChanged(oldValue, value, "Rarity");
            }
        }
        private MonsterRarity _Rarity;

        /*
        public MonsterEffect Effect
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
        private MonsterEffect _Effect;*/


        [Association("MonsterInfoStats", true)]
        public DBBindingList<MonsterInfoStat> MonsterInfoStats { get; set; }

        [Association("Respawns", true)]
        public DBBindingList<RespawnInfo> Respawns { get; set; }

        [Association("Drops", true)]
        public DBBindingList<DropInfo> Drops { get; set; }

        [Association("MonsterCostomInfo", true)]
        public DBBindingList<MonsterCostomInfo> MonsterCustomInfos { get; set; }

        [Association("Events", true)]
        public DBBindingList<EventTarget> Events { get; set; }

        [Association("QuestDetails", true)]
        public DBBindingList<QuestTaskMonsterDetails> QuestDetails { get; set; }

        [Association("QuestDetails", true)]
        public DBBindingList<MeiriQuestTaskMonsterDetails> MeiriQuestDetails { get; set; }

        public Stats Stats = new Stats();

        protected internal override void OnCreated()
        {
            base.OnCreated();

            CanPush = true;

            ViewRange = 7;

            AttackDelay = 2500;
            MoveDelay = 1800;
        }

        protected internal override void OnLoaded()
        {
            base.OnLoaded();
            StatsChanged();
        }

        public void StatsChanged()
        {
            Stats.Clear();
            foreach (MonsterInfoStat stat in MonsterInfoStats)
                Stats[stat.Stat] += stat.Amount;
        }
    }
}
