using CartoonMirDB;
using System;

namespace Library.SystemModels
{
    public sealed class MapInfo : DBObject, ICloneable
    {
        public string FileName
        {
            get { return _FileName; }
            set
            {
                if (_FileName == value) return;

                var oldValue = _FileName;
                _FileName = value;

                OnChanged(oldValue, value, "FileName");
            }
        }
        private string _FileName;

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

        public int MiniMap
        {
            get { return _MiniMap; }
            set
            {
                if (_MiniMap == value) return;

                var oldValue = _MiniMap;
                _MiniMap = value;

                OnChanged(oldValue, value, "MiniMap");
            }
        }
        private int _MiniMap;

        public LightSetting Light
        {
            get { return _Light; }
            set
            {
                if (_Light == value) return;

                var oldValue = _Light;
                _Light = value;

                OnChanged(oldValue, value, "Light");
            }
        }
        private LightSetting _Light;

        public WeatherSetting Weather
        {
            get { return _Weather; }
            set
            {
                if (_Weather == value) return;

                var oldValue = _Weather;
                _Weather = value;

                OnChanged(oldValue, value, "Weather");
            }
        }
        private WeatherSetting _Weather;

        public FightSetting Fight
        {
            get { return _Fight; }
            set
            {
                if (_Fight == value) return;

                var oldValue = _Fight;
                _Fight = value;

                OnChanged(oldValue, value, "Fight");
            }
        }
        private FightSetting _Fight;

        public bool AllowRT
        {
            get { return _AllowRT; }
            set
            {
                if (_AllowRT == value) return;

                var oldValue = _AllowRT;
                _AllowRT = value;

                OnChanged(oldValue, value, "AllowRT");
            }
        }
        private bool _AllowRT;
        
        public int SkillDelay
        {
            get { return _SkillDelay; }
            set
            {
                if (_SkillDelay == value) return;

                var oldValue = _SkillDelay;
                _SkillDelay = value;

                OnChanged(oldValue, value, "SkillDelay");
            }
        }
        private int _SkillDelay;

        public bool CanHorse
        {
            get { return _CanHorse; }
            set
            {
                if (_CanHorse == value) return;

                var oldValue = _CanHorse;
                _CanHorse = value;

                OnChanged(oldValue, value, "CanHorse");
            }
        }
        private bool _CanHorse;

        public bool AllowTT
        {
            get { return _AllowTT; }
            set
            {
                if (_AllowTT == value) return;

                var oldValue = _AllowTT;
                _AllowTT = value;

                OnChanged(oldValue, value, "AllowTT");
            }
        }
        private bool _AllowTT;

        public bool CanMine
        {
            get { return _CanMine; }
            set
            {
                if (_CanMine == value) return;

                var oldValue = _CanMine;
                _CanMine = value;

                OnChanged(oldValue, value, "CanMine");
            }
        }
        private bool _CanMine;

        public bool CanMarriageRecall
        {
            get { return _CanMarriageRecall; }
            set
            {
                if (_CanMarriageRecall == value) return;

                var oldValue = _CanMarriageRecall;
                _CanMarriageRecall = value;

                OnChanged(oldValue, value, "CanMarriageRecall");
            }
        }
        private bool _CanMarriageRecall;

        public bool AllowRecall
        {
            get => _AllowRecall;
            set
            {
                if (_AllowRecall == value) return;

                bool oldValue = _AllowRecall;
                _AllowRecall = value;

                OnChanged(oldValue, value, "AllowRecall");
            }
        }
        private bool _AllowRecall;
        
        
        public int MinimumLevel{
            get { return _MinimumLevel; }
            set
            {
                if (_MinimumLevel == value) return;

                var oldValue = _MinimumLevel;
                _MinimumLevel = value;

                OnChanged(oldValue, value, "MinimumLevel");
            }
        }
        private int _MinimumLevel;

        public int MaximumLevel
        {
            get { return _MaximumLevel; }
            set
            {
                if (_MaximumLevel == value) return;

                var oldValue = _MaximumLevel;
                _MaximumLevel = value;

                OnChanged(oldValue, value, "MaximumLevel");
            }
        }
        private int _MaximumLevel;
        
        public MapInfo ReconnectMap
        {
            get { return _ReconnectMap; }
            set
            {
                if (_ReconnectMap == value) return;

                var oldValue = _ReconnectMap;
                _ReconnectMap = value;

                OnChanged(oldValue, value, "ReconnectMap");
            }
        }
        private MapInfo _ReconnectMap;

        public SoundIndex Music
        {
            get { return _Music; }
            set
            {
                if (_Music == value) return;

                var oldValue = _Music;
                _Music = value;

                OnChanged(oldValue, value, "Music");
            }
        }
        private SoundIndex _Music;




        public int MonsterHealth
        {
            get { return _MonsterHealth; }
            set
            {
                if (_MonsterHealth == value) return;

                var oldValue = _MonsterHealth;
                _MonsterHealth = value;

                OnChanged(oldValue, value, "MonsterHealth");
            }
        }
        private int _MonsterHealth;

        public int MonsterDamage
        {
            get { return _MonsterDamage; }
            set
            {
                if (_MonsterDamage == value) return;

                var oldValue = _MonsterDamage;
                _MonsterDamage = value;

                OnChanged(oldValue, value, "MonsterDamage");
            }
        }
        private int _MonsterDamage;

        public int DropRate
        {
            get { return _DropRate; }
            set
            {
                if (_DropRate == value) return;

                var oldValue = _DropRate;
                _DropRate = value;

                OnChanged(oldValue, value, "DropRate");
            }
        }
        private int _DropRate;

        public int ExperienceRate
        {
            get { return _ExperienceRate; }
            set
            {
                if (_ExperienceRate == value) return;

                var oldValue = _ExperienceRate;
                _ExperienceRate = value;

                OnChanged(oldValue, value, "ExperienceRate");
            }
        }
        private int _ExperienceRate;

        public int InstanceIndex
        {
            get;
            set;
        }

        public int GoldRate
        {
            get { return _GoldRate; }
            set
            {
                if (_GoldRate == value) return;

                var oldValue = _GoldRate;
                _GoldRate = value;

                OnChanged(oldValue, value, "GoldRate");
            }
        }
        private int _GoldRate;

        public int MaxMonsterHealth
        {
            get { return _MaxMonsterHealth; }
            set
            {
                if (_MaxMonsterHealth == value) return;

                var oldValue = _MaxMonsterHealth;
                _MaxMonsterHealth = value;

                OnChanged(oldValue, value, "MaxMonsterHealth");
            }
        }
        private int _MaxMonsterHealth;

        public int MaxMonsterDamage
        {
            get { return _MaxMonsterDamage; }
            set
            {
                if (_MaxMonsterDamage == value) return;

                var oldValue = _MaxMonsterDamage;
                _MaxMonsterDamage = value;

                OnChanged(oldValue, value, "MaxMonsterDamage");
            }
        }
        private int _MaxMonsterDamage;

        public int MaxDropRate
        {
            get { return _MaxDropRate; }
            set
            {
                if (_MaxDropRate == value) return;

                var oldValue = _MaxDropRate;
                _MaxDropRate = value;

                OnChanged(oldValue, value, "MaxDropRate");
            }
        }
        private int _MaxDropRate;
        
        public int MaxExperienceRate
        {
            get { return _MaxExperienceRate; }
            set
            {
                if (_MaxExperienceRate == value) return;

                var oldValue = _MaxExperienceRate;
                _MaxExperienceRate = value;

                OnChanged(oldValue, value, "MaxExperienceRate");
            }
        }
        private int _MaxExperienceRate;

        public int MaxGoldRate
        {
            get { return _MaxGoldRate; }
            set
            {
                if (_MaxGoldRate == value) return;

                var oldValue = _MaxGoldRate;
                _MaxGoldRate = value;

                OnChanged(oldValue, value, "MaxGoldRate");
            }
        }
        private int _MaxGoldRate;

        public bool BuffJianshao
        {
            get { return _BuffJianshao; }
            set
            {
                if (_BuffJianshao == value) return;

                var oldValue = _BuffJianshao;
                _BuffJianshao = value;

                OnChanged(oldValue, value, "BuffJianshao");
            }
        }
        private bool _BuffJianshao;

        public bool AllowTulingfu
        {
            get { return _AllowTulingfu; }
            set
            {
                if (_AllowTulingfu == value) return;

                var oldValue = _AllowTulingfu;
                _AllowTulingfu = value;

                OnChanged(oldValue, value, "AllowTulingfu");
            }
        }
        private bool _AllowTulingfu;

        public bool AllowGuaji
        {
            get { return _AllowGuaji; }
            set
            {
                if (_AllowGuaji == value) return;

                var oldValue = _AllowGuaji;
                _AllowGuaji = value;

                OnChanged(oldValue, value, "AllowGuaji");
            }
        }
        private bool _AllowGuaji;

        public bool AllowAlive
        {
            get { return _AllowAlive; }
            set
            {
                if (_AllowAlive == value) return;

                var oldValue = _AllowAlive;
                _AllowAlive = value;

                OnChanged(oldValue, value, "AllowAlive");
            }
        }
        private bool _AllowAlive;

        public bool AllowJiedu
        {
            get { return _AllowJiedu; }
            set
            {
                if (_AllowJiedu == value) return;

                var oldValue = _AllowJiedu;
                _AllowJiedu = value;

                OnChanged(oldValue, value, "AllowJiedu");
            }
        }
        private bool _AllowJiedu;

        public bool AllowPotion
        {
            get { return _AllowPotion; }
            set
            {
                if (_AllowPotion == value) return;

                var oldValue = _AllowPotion;
                _AllowPotion = value;

                OnChanged(oldValue, value, "AllowPotion");
            }
        }
        private bool _AllowPotion;

        public bool PotionHP
        {
            get { return _PotionHP; }
            set
            {
                if (_PotionHP == value) return;

                var oldValue = _PotionHP;
                _PotionHP = value;

                OnChanged(oldValue, value, "PotionHP");
            }
        }
        private bool _PotionHP;

        public bool PotionMP
        {
            get { return _PotionMP; }
            set
            {
                if (_PotionMP == value) return;

                var oldValue = _PotionMP;
                _PotionMP = value;

                OnChanged(oldValue, value, "PotionMP");
            }
        }
        private bool _PotionMP;

        public int PlyBuff
        {
            get { return _PlyBuff; }
            set
            {
                if (_PlyBuff == value) return;

                var oldValue = _PlyBuff;
                _PlyBuff = value;

                OnChanged(oldValue, value, "PlyBuff");
            }
        }
        private int _PlyBuff;

        public bool IsDynamic
        {
            get
            {
                return this._IsDynamic;
            }
            set
            {
                if (this._IsDynamic == value)
                    return;
                bool isDynamic = this._IsDynamic;
                this._IsDynamic = value;
                OnChanged(isDynamic, value, nameof(IsDynamic));
            }
        }
        private bool _IsDynamic;

        public int MonBuff
        {
            get { return _MonBuff; }
            set
            {
                if (_MonBuff == value) return;

                var oldValue = _MonBuff;
                _MonBuff = value;

                OnChanged(oldValue, value, "MonBuff");
            }
        }
        private int _MonBuff;

        public bool FBMon
        {
            get { return _FBMon; }
            set
            {
                if (_FBMon == value) return;

                var oldValue = _FBMon;
                _FBMon = value;

                OnChanged(oldValue, value, "FBMon");
            }
        }
        private bool _FBMon;

        public int NpcIndex
        {
            get { return _NpcIndex; }
            set
            {
                if (_NpcIndex == value) return;

                var oldValue = _NpcIndex;
                _NpcIndex = value;

                OnChanged(oldValue, value, "NpcIndex");
            }
        }
        private int _NpcIndex;

        public bool FBNpc
        {
            get { return _FBNpc; }
            set
            {
                if (_FBNpc == value) return;

                var oldValue = _FBNpc;
                _FBNpc = value;

                OnChanged(oldValue, value, "FBNpc");
            }
        }
        private bool _FBNpc;

        public int RenshuBuff
        {
            get { return _RenshuBuff; }
            set
            {
                if (_RenshuBuff == value) return;

                var oldValue = _RenshuBuff;
                _RenshuBuff = value;

                OnChanged(oldValue, value, "RenshuBuff");
            }
        }
        private int _RenshuBuff;

        public bool FBRenshu
        {
            get { return _FBRenshu; }
            set
            {
                if (_FBRenshu == value) return;

                var oldValue = _FBRenshu;
                _FBRenshu = value;

                OnChanged(oldValue, value, "FBRenshu");
            }
        }
        private bool _FBRenshu;

        public int ExpBuff
        {
            get { return _ExpBuff; }
            set
            {
                if (_ExpBuff == value) return;

                var oldValue = _ExpBuff;
                _ExpBuff = value;

                OnChanged(oldValue, value, "ExpBuff");
            }
        }
        private int _ExpBuff;

        public bool FBExp
        {
            get { return _FBExp; }
            set
            {
                if (_FBExp == value) return;

                var oldValue = _FBExp;
                _FBExp = value;

                OnChanged(oldValue, value, "FBExp");
            }
        }
        private bool _FBExp;

        public int GoldExpBuff
        {
            get { return _GoldExpBuff; }
            set
            {
                if (_GoldExpBuff == value) return;

                var oldValue = _GoldExpBuff;
                _GoldExpBuff = value;

                OnChanged(oldValue, value, "GoldExpBuff");
            }
        }
        private int _GoldExpBuff;

        public bool FBGoldExp
        {
            get { return _FBGoldExp; }
            set
            {
                if (_FBGoldExp == value) return;

                var oldValue = _FBGoldExp;
                _FBGoldExp = value;

                OnChanged(oldValue, value, "FBGoldExp");
            }
        }
        private bool _FBGoldExp;

        public bool FBBossCount
        {
            get { return _FBBossCount; }
            set
            {
                if (_FBBossCount == value) return;

                var oldValue = _FBBossCount;
                _FBBossCount = value;

                OnChanged(oldValue, value, "FBBossCount");
            }
        }
        private bool _FBBossCount;

        public bool FBMonCount
        {
            get { return _FBMonCount; }
            set
            {
                if (_FBMonCount == value) return;

                var oldValue = _FBMonCount;
                _FBMonCount = value;

                OnChanged(oldValue, value, "FBMonCount");
            }
        }
        private bool _FBMonCount;

        public int BJMap
        {
            get { return _BJMap; }
            set
            {
                if (_BJMap == value) return;

                var oldValue = _BJMap;
                _BJMap = value;

                OnChanged(oldValue, value, "BJMap");
            }
        }
        private int _BJMap;


        [Association("Guards", true)]
        public DBBindingList<GuardInfo> Guards { get; set; }

        [Association("Regions",true)]
        public DBBindingList<MapRegion> Regions { get; set; }

        [Association("Mining", true)]
        public DBBindingList<MineInfo> Mining { get; set; }

        protected internal override void OnCreated()
        {
            base.OnCreated();

            AllowRT = true;
            AllowTT = true;
            CanMarriageRecall = true;
            AllowRecall = true;
            PotionMP = true;
            PotionHP = true;
            AllowTulingfu = true;
            AllowAlive = true;
            AllowJiedu = true;
            AllowPotion = true;
            BuffJianshao = false;
            AllowGuaji = false;
        }



        public bool Expanded = true;

        [IgnoreProperty]
        public int fubenIndex { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
