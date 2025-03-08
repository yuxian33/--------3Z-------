using System;
using CartoonMirDB;

namespace Library.SystemModels
{

    public sealed class NPCInfo : DBObject
    {
        public MapRegion Region
        {
            get { return _Region; }
            set
            {
                if (_Region == value) return;

                var oldValue = _Region;
                _Region = value;

                OnChanged(oldValue, value, "Region");
            }
        }
        private MapRegion _Region;

        public string NPCName
        {
            get { return _NPCName; }
            set
            {
                if (_NPCName == value) return;

                var oldValue = _NPCName;
                _NPCName = value;

                OnChanged(oldValue, value, "NPCName");
            }
        }
        private string _NPCName;

        public int Image
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
        private int _Image;
        
        public NPCPage EntryPage
        {
            get { return _EntryPage; }
            set
            {
                if (_EntryPage == value) return;

                var oldValue = _EntryPage;
                _EntryPage = value;

                OnChanged(oldValue, value, "EntryPage");
            }
        }
        private NPCPage _EntryPage;

        [IgnoreProperty]
        public string RegionName => Region?.ServerDescription ?? string.Empty;

        [Association("StartQuests")]
        public DBBindingList<QuestInfo> StartQuests { get; set; }

        [Association("MeiriStartQuests")]
        public DBBindingList<MeiriQuestInfo> MeiriStartQuests { get; set; }

        [Association("FinishQuests")]
        public DBBindingList<QuestInfo> FinishQuests { get; set; }

        [Association("MeiriFinishQuests")]
        public DBBindingList<MeiriQuestInfo> MeiriFinishQuests { get; set; }


        public QuestIcon CurrentIcon;
    }

    public sealed class NPCPage : DBObject
    {
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

        public NPCDialogType DialogType
        {
            get { return _DialogType; }
            set
            {
                if (_DialogType == value) return;

                var oldValue = _DialogType;
                _DialogType = value;

                OnChanged(oldValue, value, "DialogType");
            }
        }
        private NPCDialogType _DialogType;

        public string Say
        {
            get { return _Say; }
            set
            {
                if (_Say == value) return;

                var oldValue = _Say;
                _Say = value;

                OnChanged(oldValue, value, "Say");
            }
        }
        private string _Say;

        public NPCPage SuccessPage
        {
            get { return _SuccessPage; }
            set
            {
                if (_SuccessPage == value) return;

                var oldValue = _SuccessPage;
                _SuccessPage = value;

                OnChanged(oldValue, value, "SuccessPage");
            }
        }
        private NPCPage _SuccessPage;

        public string Arguments
        {
            get { return _Arguments; }
            set
            {
                if (_Arguments == value) return;

                var oldValue = _Arguments;
                _Arguments = value;

                OnChanged(oldValue, value, "Arguments");
            }
        }
        private string _Arguments;

        [Association("Checks", true)]
        public DBBindingList<NPCCheck> Checks { get; set; }

        [Association("Actions", true)]
        public DBBindingList<NPCAction> Actions { get; set; }

        [Association("Buttons", true)]
        public DBBindingList<NPCButton> Buttons { get; set; }

        [Association("Goods", true)]
        public DBBindingList<NPCGood> Goods { get; set; }

        [Association("Types", true)]
        public DBBindingList<NPCType> Types { get; set; }
    }

    public sealed class NPCGood : DBObject
    {
        [Association("Goods")]
        public NPCPage Page
        {
            get { return _Page; }
            set
            {
                if (_Page == value) return;

                var oldValue = _Page;
                _Page = value;

                OnChanged(oldValue, value, "Page");
            }
        }
        private NPCPage _Page;

        public long Amount;

        [Association("Amount")]
        public ItemInfo Item
        {
            get { return _Item; }
            set
            {
                if (_Item == value) return;

                var oldValue = _Item;
                _Item = value;

                OnChanged(oldValue, value, "Item");
            }
        }
        private ItemInfo _Item;

        public decimal Rate
        {
            get { return _Rate; }
            set
            {
                if (_Rate == value) return;

                var oldValue = _Rate;
                _Rate = value;

                OnChanged(oldValue, value, "Rate");
            }
        }
        private decimal _Rate;

        public int Shengwangdian
        {
            get { return _Shengwangdian; }
            set
            {
                if (_Shengwangdian == value) return;

                var oldValue = _Shengwangdian;
                _Shengwangdian = value;

                OnChanged(oldValue, value, "Shengwangdian");
            }
        }
        private int _Shengwangdian;

        public bool Shifoushengwang
        {
            get { return _Shifoushengwang; }
            set
            {
                if (_Shifoushengwang == value) return;

                var oldValue = _Shifoushengwang;
                _Shifoushengwang = value;

                OnChanged(oldValue, value, "Shifoushengwang");
            }
        }
        private bool _Shifoushengwang;


        public int Shibiema
        {
            get { return _Shibiema; }
            set
            {
                if (_Shibiema == value) return;

                var oldValue = _Shibiema;
                _Shibiema = value;

                OnChanged(oldValue, value, "Shibiema");
            }
        }
        private int _Shibiema;

        public long ItemCount
        {
            get { return _ItemCount; }
            set
            {
                if (_ItemCount == value) return;

                var oldValue = _ItemCount;
                _ItemCount = value;

                OnChanged(oldValue, value, "ItemCount");
            }
        }
        private long _ItemCount;

        protected internal override void OnCreated()
        {
            base.OnCreated();

            Rate = 1M;
            Shengwangdian = 0;
            Shifoushengwang = false;
        }


        [IgnoreProperty]
        public int Cost => (int)Math.Round(Item.Price * Rate);
    }

    public sealed class NPCType : DBObject
    {
        [Association("Types")]
        public NPCPage Page
        {
            get { return _Page; }
            set
            {
                if (_Page == value) return;

                var oldValue = _Page;
                _Page = value;

                OnChanged(oldValue, value, "Page");
            }
        }
        private NPCPage _Page;

        public ItemType ItemType
        {
            get { return _ItemType; }
            set
            {
                if (_ItemType == value) return;

                var oldValue = _ItemType;
                _ItemType = value;

                OnChanged(oldValue, value, "ItemType");
            }
        }
        private ItemType _ItemType;
    }



    public sealed class NPCCheck : DBObject
    {
        [Association("Checks")]
        public NPCPage Page
        {
            get { return _Page; }
            set
            {
                if (_Page == value) return;

                var oldValue = _Page;
                _Page = value;

                OnChanged(oldValue, value, "Page");
            }
        }
        private NPCPage _Page;

        public NPCCheckType CheckType
        {
            get { return _CheckType; }
            set
            {
                if (_CheckType == value) return;

                var oldValue = _CheckType;
                _CheckType = value;

                OnChanged(oldValue, value, "CheckType");
            }
        }
        private NPCCheckType _CheckType;

        public Operator Operator
        {
            get { return _Operator; }
            set
            {
                if (_Operator == value) return;

                var oldValue = _Operator;
                _Operator = value;

                OnChanged(oldValue, value, "Operator");
            }
        }
        private Operator _Operator;

        public string StringParameter1
        {
            get { return _StringParameter1; }
            set
            {
                if (_StringParameter1 == value) return;

                var oldValue = _StringParameter1;
                _StringParameter1 = value;

                OnChanged(oldValue, value, "StringParameter1");
            }
        }
        private string _StringParameter1;

        public int IntParameter1
        {
            get { return _IntParameter1; }
            set
            {
                if (_IntParameter1 == value) return;

                var oldValue = _IntParameter1;
                _IntParameter1 = value;

                OnChanged(oldValue, value, "IntParameter1");
            }
        }
        private int _IntParameter1;

        public int IntParameter2
        {
            get { return _IntParameter2; }
            set
            {
                if (_IntParameter2 == value) return;

                var oldValue = _IntParameter2;
                _IntParameter2 = value;

                OnChanged(oldValue, value, "IntParameter2");
            }
        }
        private int _IntParameter2;

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

        public ItemInfo ItemParameter1
        {
            get { return _ItemParameter1; }
            set
            {
                if (_ItemParameter1 == value) return;

                var oldValue = _ItemParameter1;
                _ItemParameter1 = value;

                OnChanged(oldValue, value, "ItemParameter1");
            }
        }
        private ItemInfo _ItemParameter1;


        public Stat StatParameter1
        {
            get { return _StatParameter1; }
            set
            {
                if (_StatParameter1 == value) return;

                var oldValue = _StatParameter1;
                _StatParameter1 = value;

                OnChanged(oldValue, value, "StatParameter1");
            }
        }
        private Stat _StatParameter1;

        public QuestInfo QuestParameter
        {
            get { return _QuestParameter; }
            set
            {
                if (_QuestParameter == value) return;

                var oldValue = _QuestParameter;
                _QuestParameter = value;

                OnChanged(oldValue, value, "QuestParameter");
            }
        }
        private QuestInfo _QuestParameter;

        public MeiriQuestInfo MeiriQuest
        {
            get { return _MeiriQuest; }
            set
            {
                if (_MeiriQuest == value) return;

                var oldValue = _MeiriQuest;
                _MeiriQuest = value;

                OnChanged(oldValue, value, "MeiriQuest");
            }
        }
        private MeiriQuestInfo _MeiriQuest;

        public DateTime Accept
        {
            get { return _Accept; }
            set
            {
                if (_Accept == value) return;
                var oldValue = _Accept;
                _Accept = value;
                OnChanged(oldValue, value, "Accept");
            }
        }
        private DateTime _Accept;

        public DateTime Complete
        {
            get { return _Complete; }
            set
            {
                if (_Complete == value) return;
                var oldValue = _Complete;
                _Complete = value;
                OnChanged(oldValue, value, "Complete");
            }
        }
        private DateTime _Complete;

        public NPCPage FailPage
        {
            get { return _FailPage; }
            set
            {
                if (_FailPage == value) return;

                var oldValue = _FailPage;
                _FailPage = value;

                OnChanged(oldValue, value, "FailPage");
            }
        }
        private NPCPage _FailPage;
    }

    public sealed class NPCAction : DBObject
    {
        [Association("Actions")]
        public NPCPage Page
        {
            get { return _Page; }
            set
            {
                if (_Page == value) return;

                var oldValue = _Page;
                _Page = value;

                OnChanged(oldValue, value, "Page");
            }
        }
        private NPCPage _Page;

        public NPCActionType ActionType
        {
            get { return _ActionType; }
            set
            {
                if (_ActionType == value) return;

                var oldValue = _ActionType;
                _ActionType = value;

                OnChanged(oldValue, value, "ActionType");
            }
        }
        private NPCActionType _ActionType;

        public string StringParameter1
        {
            get { return _StringParameter1; }
            set
            {
                if (_StringParameter1 == value) return;

                var oldValue = _StringParameter1;
                _StringParameter1 = value;

                OnChanged(oldValue, value, "StringParameter1");
            }
        }
        private string _StringParameter1;

        public int IntParameter1
        {
            get { return _IntParameter1; }
            set
            {
                if (_IntParameter1 == value) return;

                var oldValue = _IntParameter1;
                _IntParameter1 = value;

                OnChanged(oldValue, value, "IntParameter1");
            }
        }
        private int _IntParameter1;

        public int IntParameter2
        {
            get { return _IntParameter2; }
            set
            {
                if (_IntParameter2 == value) return;

                var oldValue = _IntParameter2;
                _IntParameter2 = value;

                OnChanged(oldValue, value, "IntParameter2");
            }
        }
        private int _IntParameter2;

        public ItemInfo ItemParameter1
        {
            get { return _ItemParameter1; }
            set
            {
                if (_ItemParameter1 == value) return;

                var oldValue = _ItemParameter1;
                _ItemParameter1 = value;

                OnChanged(oldValue, value, "ItemParameter1");
            }
        }
        private ItemInfo _ItemParameter1;
        
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
        
        public Stat StatParameter1
        {
            get { return _StatParameter1; }
            set
            {
                if (_StatParameter1 == value) return;

                var oldValue = _StatParameter1;
                _StatParameter1 = value;

                OnChanged(oldValue, value, "StatParameter1");
            }
        }
        private Stat _StatParameter1;

        public MonsterInfo MonsterParameter1
        {
            get { return _MonsterParameter1; }
            set
            {
                if (_MonsterParameter1 == value) return;

                var oldValue = _MonsterParameter1;
                _MonsterParameter1 = value;

                OnChanged(oldValue, value, "MonsterParameter1");
            }
        }
        private MonsterInfo _MonsterParameter1;

        public int Count1
        {
            get { return _Count1; }
            set
            {
                if (_Count1 == value) return;

                var oldValue = _Count1;
                _Count1 = value;

                OnChanged(oldValue, value, "Count1");
            }
        }
        private int _Count1;

        public int DropSet1
        {
            get { return _DropSet1; }
            set
            {
                if (_DropSet1 == value) return;

                var oldValue = _DropSet1;
                _DropSet1 = value;

                OnChanged(oldValue, value, "DropSet1");
            }
        }
        private int _DropSet1;

        public int Count2
        {
            get { return _Count2; }
            set
            {
                if (_Count2 == value) return;

                var oldValue = _Count2;
                _Count2 = value;

                OnChanged(oldValue, value, "Count2");
            }
        }
        private int _Count2;

        public int DropSet2
        {
            get { return _DropSet2; }
            set
            {
                if (_DropSet2 == value) return;

                var oldValue = _DropSet2;
                _DropSet2 = value;

                OnChanged(oldValue, value, "DropSet2");
            }
        }
        private int _DropSet2;

        public int Count3
        {
            get { return _Count3; }
            set
            {
                if (_Count3 == value) return;

                var oldValue = _Count3;
                _Count3 = value;

                OnChanged(oldValue, value, "Count3");
            }
        }
        private int _Count3;

        public int DropSet3
        {
            get { return _DropSet3; }
            set
            {
                if (_DropSet3 == value) return;

                var oldValue = _DropSet3;
                _DropSet3 = value;

                OnChanged(oldValue, value, "DropSet3");
            }
        }
        private int _DropSet3;

        public long Count4
        {
            get { return _Count4; }
            set
            {
                if (_Count4 == value) return;

                var oldValue = _Count4;
                _Count4 = value;

                OnChanged(oldValue, value, "Count4");
            }
        }
        private long _Count4;

        public int DropSet4
        {
            get { return _DropSet4; }
            set
            {
                if (_DropSet4 == value) return;

                var oldValue = _DropSet4;
                _DropSet4 = value;

                OnChanged(oldValue, value, "DropSet4");
            }
        }
        private int _DropSet4;

        public long Count5
        {
            get { return _Count5; }
            set
            {
                if (_Count5 == value) return;

                var oldValue = _Count5;
                _Count5 = value;

                OnChanged(oldValue, value, "Count5");
            }
        }
        private long _Count5;

        public int DropSet5
        {
            get { return _DropSet5; }
            set
            {
                if (_DropSet5 == value) return;

                var oldValue = _DropSet5;
                _DropSet5 = value;

                OnChanged(oldValue, value, "DropSet5");
            }
        }
        private int _DropSet5;
    }

    public sealed class NPCButton : DBObject
    {
        [Association("Buttons")]
        public NPCPage Page
        {
            get { return _Page; }
            set
            {
                if (_Page == value) return;

                var oldValue = _Page;
                _Page = value;

                OnChanged(oldValue, value, "Page");
            }
        }
        private NPCPage _Page;

        public int ButtonID
        {
            get { return _ButtonID; }
            set
            {
                if (_ButtonID == value) return;

                var oldValue = _ButtonID;
                _ButtonID = value;

                OnChanged(oldValue, value, "ButtonID");
            }
        }
        private int _ButtonID;

        public NPCPage DestinationPage
        {
            get { return _DestinationPage; }
            set
            {
                if (_DestinationPage == value) return;

                var oldValue = _DestinationPage;
                _DestinationPage = value;

                OnChanged(oldValue, value, "DestinationPage");
            }
        }
        private NPCPage _DestinationPage;



    }


    public enum NPCCheckType
    {
        Level,
        Class,
        Gender,
        Gold,
        HasItem,
        PKPoints,

        HasWeapon,
        WeaponLevel,
        WeaponElement,
        WeaponCanRefine,

        Horse,

        Marriage,
        WeddingRing,

        CanGainItem,
        CanResetWeapon,

        Random,

        WeaponAddedStats,

        Daily,
        Hour,
        Minute,
        DayOfWeek,
        PlayerTeleport,
        BoosTeleport,
        Groupleader,
        GroupCount,
        GroupCheckNearby,
        InGuild,
        CheckNameList,
        CheckMon,
        CheckBoss,
        CheckPlayer,
        CheckNameListFan,
        GroupCheckNameLists,
        CheckEMailList,
        GroupCheckLevel,
        CheckBagSpace,
        CheckBuff,
        InGroupfan,
        CheckEMailListFan,
        GroupCheckEMailList,
        CheckShengwang,
        CheckShangjin,
        CheckYuanbao,
        CheckQuest,

        CheckMeiriQuest,

        CheckGuildFunds,
        CheckGuildNameList,
        CheckGuildleader,
        CheckGuildLevel,
        CheckGuildNameListFan,
        Rebirth,
        GroupHasItem, 
        InGroup, 
        CompanionLevel,
        CompanionRebirth,
        CheckFubendian,
        GroupCheckFubendian, 
        CheckSabukleader,
        CheckSabukMember,

    }
    public enum Operator
    {
        Equal,
        NotEqual,
        LessThan,
        LessThanOrEqual,
        GreaterThan,
        GreaterThanOrEqual,
    }
    public enum NPCActionType
    {
        Teleport,
        GiveGold,
        TakeGold,
        GiveItem,
        TakeItem,
        ChangeElement,
        ChangeHorse,
        Message,

        Marriage,
        Divorce,
        RemoveWeddingRing,

        ResetWeapon,
        GiveItemExperience,

        SpecialRefine,
        Rebirth,

        MonGen,
        MonGenCountb,
        MonGenCounti,
        MonGenCountu,
        MonGenCountt,
        MonGenCountbax,
        CreateNpc,
        CreateMap,
        GroupRecall,
        GroupTeleportDT,
        AddNameList,
        DelNameList,
        ClearNameList,
        GiveLvExp,
        GroupAddNameLists,
        AddEMailList,
        ClearGroup,
        GiveLvGold,
        CurrentMapMonGen,
        DelallNpc,
        GiveBuff,
        ClearBuff,
        GroupTeleport,
        GroupAddEMailList,
        GiveShengwang,
        TakeShengwang,
        GiveShangjin,
        TakeShangjin,
        GiveYuanbao,
        TakeYuanbao,
        TeleportGuildJidi,
        TakeGuildFunds,
        AddGuildNameList,
        DelGuildNameList,
        ClearGuildNameList,
        GuildBossMonGen, 
        GuildFubenMonGen,  
        GuildJiacheng,
        DelEmailList,  
        GroupTakeItem,
        CompanionRebirth, 
        TakeFubendian,
        GroupTakeFubendian, 
        WarDate, 
    }
}
