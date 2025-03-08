using System;
using System.Collections.Generic;
using System.Drawing;
using Library;
using Library.SystemModels;
using CartoonMirDB;
using Server.Envir;
using Server.Models;

namespace Server.DBModels
{
    [UserObject]
    public sealed class CharacterInfo : DBObject
    {
        [Association("Characters")]
        public AccountInfo Account
        {
            get { return _Account; }
            set
            {
                if (_Account == value) return;

                var oldValue = _Account;
                _Account = value;

                OnChanged(oldValue, value, "Account");
            }
        }
        private AccountInfo _Account;

        public string CharacterName
        {
            get { return _CharacterName; }
            set
            {
                if (_CharacterName == value) return;

                var oldValue = _CharacterName;
                _CharacterName = value;

                OnChanged(oldValue, value, "CharacterName");
            }
        }
        private string _CharacterName;

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

        public MirGender Gender
        {
            get { return _Gender; }
            set
            {
                if (_Gender == value) return;

                var oldValue = _Gender;
                _Gender = value;

                OnChanged(oldValue, value, "Gender");
            }
        }
        private MirGender _Gender;

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

        public int PatchGridSize
        {
            get
            {
                return _PatchGridSize;
            }
            set
            {
                if (_PatchGridSize == value)
                    return;
                int patchGridSize = _PatchGridSize;
                _PatchGridSize = value;
                OnChanged((object)patchGridSize, (object)value, nameof(PatchGridSize));
            }
        }
        private int _PatchGridSize;

        
        public int BaoshiGridSize
        {
            get
            {
                return _BaoshiGridSize;
            }
            set
            {
                if (_BaoshiGridSize == value)
                    return;
                int baoshiGridSize = _BaoshiGridSize;
                _BaoshiGridSize = value;
                OnChanged((object)baoshiGridSize, (object)value, nameof(BaoshiGridSize));
            }
        }
        private int _BaoshiGridSize;


        public int HairType
        {
            get { return _HairType; }
            set
            {
                if (_HairType == value) return;

                var oldValue = _HairType;
                _HairType = value;

                OnChanged(oldValue, value, "HairType");
            }
        }
        private int _HairType;

        public Color HairColour
        {
            get { return _HairColour; }
            set
            {
                if (_HairColour == value) return;

                var oldValue = _HairColour;
                _HairColour = value;

                OnChanged(oldValue, value, "HairColour");
            }
        }
        private Color _HairColour;

        public Color ArmourColour
        {
            get { return _ArmourColour; }
            set
            {
                if (_ArmourColour == value) return;

                var oldValue = _ArmourColour;
                _ArmourColour = value;

                OnChanged(oldValue, value, "ArmourColour");
            }
        }
        private Color _ArmourColour;
        
        public DateTime LastLogin
        {
            get { return _LastLogin; }
            set
            {
                if (_LastLogin == value) return;

                var oldValue = _LastLogin;
                _LastLogin = value;

                OnChanged(oldValue, value, "LastLogin");
            }
        }
        private DateTime _LastLogin;

        public bool Deleted
        {
            get { return _Deleted; }
            set
            {
                if (_Deleted == value) return;

                var oldValue = _Deleted;
                _Deleted = value;

                OnChanged(oldValue, value, "Deleted");
            }
        }
        private bool _Deleted;

        public DateTime CreationDate
        {
            get { return _CreationDate; }
            set
            {
                if (_CreationDate == value) return;

                var oldValue = _CreationDate;
                _CreationDate = value;

                OnChanged(oldValue, value, "CreationDate");
            }
        }
        private DateTime _CreationDate;

        public string CreationIP
        {
            get { return _CreationIP; }
            set
            {
                if (_CreationIP == value) return;

                var oldValue = _CreationIP;
                _CreationIP = value;

                OnChanged(oldValue, value, "CreationIP");
            }
        }
        private string _CreationIP;

        public Point CurrentLocation
        {
            get { return _CurrentLocation; }
            set
            {
                if (_CurrentLocation == value) return;

                var oldValue = _CurrentLocation;
                _CurrentLocation = value;

                OnChanged(oldValue, value, "CurrentLocation");
            }
        }
        private Point _CurrentLocation;
        
        public MapInfo CurrentMap
        {
            get { return _CurrentMap; }
            set
            {
                if (_CurrentMap == value) return;

                var oldValue = _CurrentMap;
                _CurrentMap = value;

                OnChanged(oldValue, value, "CurrentMap");
            }
        }
        private MapInfo _CurrentMap;

        public MirDirection Direction
        {
            get { return _Direction; }
            set
            {
                if (_Direction == value) return;

                var oldValue = _Direction;
                _Direction = value;

                OnChanged(oldValue, value, "Direction");
            }
        }
        private MirDirection _Direction;
        
        public SafeZoneInfo BindPoint
        {
            get { return _BindPoint; }
            set
            {
                if (_BindPoint == value) return;

                var oldValue = _BindPoint;
                _BindPoint = value;

                OnChanged(oldValue, value, "BindPoint");
            }
        }
        private SafeZoneInfo _BindPoint;

        public int CurrentHP
        {
            get { return _CurrentHP; }
            set
            {
                if (_CurrentHP == value) return;

                var oldValue = _CurrentHP;
                _CurrentHP = value;

                OnChanged(oldValue, value, "CurrentHP");
            }
        }
        private int _CurrentHP;

        public int CurrentMP
        {
            get { return _CurrentMP; }
            set
            {
                if (_CurrentMP == value) return;

                var oldValue = _CurrentMP;
                _CurrentMP = value;

                OnChanged(oldValue, value, "CurrentMP");
            }
        }
        private int _CurrentMP;

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

        
        public decimal Exphuishou
        {
            get { return _Exphuishou; }
            set
            {
                if (_Exphuishou == value) return;

                var oldValue = _Exphuishou;
                _Exphuishou = value;

                OnChanged(oldValue, value, "Exphuishou");
            }
        }
        private decimal _Exphuishou;
        
        public int Jyhuishoulevel
        {
            get { return _Jyhuishoulevel; }
            set
            {
                if (_Jyhuishoulevel == value) return;

                var oldValue = _Jyhuishoulevel;
                _Jyhuishoulevel = value;

                OnChanged(oldValue, value, "Jyhuishoulevel");
            }
        }
        private int _Jyhuishoulevel;

        public double Expshuaijian
        {
            get { return _Expshuaijian; }
            set
            {
                if (_Expshuaijian == value) return;

                var oldValue = _Expshuaijian;
                _Expshuaijian = value;

                OnChanged(oldValue, value, "Expshuaijian");
            }
        }
        private double _Expshuaijian;

        public bool CanThrusting
        {
            get { return _canThrusting; }
            set
            {
                if (_canThrusting == value) return;

                var oldValue = _canThrusting;
                _canThrusting = value;

                OnChanged(oldValue, value, "CanThrusting");
            }
        }
        private bool _canThrusting;

        public bool CanHalfMoon
        {
            get { return _CanHalfMoon; }
            set
            {
                if (_CanHalfMoon == value) return;

                var oldValue = _CanHalfMoon;
                _CanHalfMoon = value;

                OnChanged(oldValue, value, "CanHalfMoon");
            }
        }
        private bool _CanHalfMoon;

        public bool CanDestructiveSurge
        {
            get { return _canDestructiveSurge; }
            set
            {
                if (_canDestructiveSurge == value) return;

                var oldValue = _canDestructiveSurge;
                _canDestructiveSurge = value;

                OnChanged(oldValue, value, "CanDestructiveSurge");
            }
        }
        private bool _canDestructiveSurge;

        public bool CanFlameSplash
        {
            get { return _CanFlameSplash; }
            set
            {
                if (_CanFlameSplash == value) return;

                var oldValue = _CanFlameSplash;
                _CanFlameSplash = value;

                OnChanged(oldValue, value, "CanFlameSplash");
            }
        }
        private bool _CanFlameSplash;
        
        public Stats LastStats
        {
            get { return _LastStats; }
            set
            {
                if (_LastStats == value) return;

                var oldValue = _LastStats;
                _LastStats = value;

                OnChanged(oldValue, value, "LastStats");
            }
        }
        private Stats _LastStats;

        public Stats HermitStats
        {
            get { return _HermitStats; }
            set
            {
                if (_HermitStats == value) return;

                var oldValue = _HermitStats;
                _HermitStats = value;

                OnChanged(oldValue, value, "HermitStats");
            }
        }
        private Stats _HermitStats;

        public int SpentPoints
        {
            get { return _SpentPoints; }
            set
            {
                if (_SpentPoints == value) return;

                var oldValue = _SpentPoints;
                _SpentPoints = value;

                OnChanged(oldValue, value, "SpentPoints");
            }
        }
        private int _SpentPoints;

        public AttackMode AttackMode
        {
            get { return _AttackMode; }
            set
            {
                if (_AttackMode == value) return;

                var oldValue = _AttackMode;
                _AttackMode = value;

                OnChanged(oldValue, value, "AttackMode");
            }
        }
        private AttackMode _AttackMode;

        public PetMode PetMode
        {
            get { return _PetMode; }
            set
            {
                if (_PetMode == value) return;

                var oldValue = _PetMode;
                _PetMode = value;

                OnChanged(oldValue, value, "PetMode");
            }
        }
        private PetMode _PetMode;
        
        public bool Observable
        {
            get { return _Observable; }
            set
            {
                if (_Observable == value) return;

                var oldValue = _Observable;
                _Observable = value;

                OnChanged(oldValue, value, "Observable");
            }
        }
        private bool _Observable;

        public DateTime ItemReviveTime
        {
            get { return _ItemReviveTime; }
            set
            {
                if (_ItemReviveTime == value) return;

                var oldValue = _ItemReviveTime;
                _ItemReviveTime = value;

                OnChanged(oldValue, value, "ItemReviveTime");
            }
        }
        private DateTime _ItemReviveTime;

        public DateTime ReincarnationPillTime
        {
            get { return _ReincarnationPillTime; }
            set
            {
                if (_ReincarnationPillTime == value) return;

                var oldValue = _ReincarnationPillTime;
                _ReincarnationPillTime = value;

                OnChanged(oldValue, value, "ReincarnationPillTime");
            }
        }
        private DateTime _ReincarnationPillTime;

        public DateTime MarriageTeleportTime
        {
            get { return _MarriageTeleportTime; }
            set
            {
                if (_MarriageTeleportTime == value) return;

                var oldValue = _MarriageTeleportTime;
                _MarriageTeleportTime = value;

                OnChanged(oldValue, value, "MarriageTeleportTime");
            }
        }
        private DateTime _MarriageTeleportTime;

        public DateTime MoveTeleportTime
        {
            get { return _MoveTeleportTime; }
            set
            {
                if (_MoveTeleportTime == value) return;

                var oldValue = _MoveTeleportTime;
                _MoveTeleportTime = value;

                OnChanged(oldValue, value, "MoveTeleportTime");
            }
        }
        private DateTime _MoveTeleportTime;

        public DateTime GroupRecallTime
        {
            get { return _GroupRecallTime; }
            set
            {
                if (_GroupRecallTime == value) return;

                var oldValue = _GroupRecallTime;
                _GroupRecallTime = value;

                OnChanged(oldValue, value, "GroupRecallTime");
            }
        }
        private DateTime _GroupRecallTime;


        public DateTime FBTeleportTime
        {
            get { return _FBTeleportTime; }
            set
            {
                if (_FBTeleportTime == value) return;

                var oldValue = _FBTeleportTime;
                _FBTeleportTime = value;

                OnChanged(oldValue, value, "FBTeleportTime");
            }
        }
        private DateTime _FBTeleportTime;

        public DateTime TulingfuTime
        {
            get { return _TulingfuTime; }
            set
            {
                if (_TulingfuTime == value) return;

                var oldValue = _TulingfuTime;
                _TulingfuTime = value;

                OnChanged(oldValue, value, "TulingfuTime");
            }
        }
        private DateTime _TulingfuTime;

        public long DailyContribution
        {
            get { return _DailyContribution; }
            set
            {
                if (_DailyContribution == value) return;

                var oldValue = _DailyContribution;
                _DailyContribution = value;

                OnChanged(oldValue, value, "DailyContribution");
            }
        }
        private long _DailyContribution;

        
        public LinkedListNode<CharacterInfo> GuildGerenMankingNode;

        
        public bool HideShizhuang
        {
            get { return _HideShizhuang; }
            set
            {
                if (_HideShizhuang == value) return;

                var oldValue = _HideShizhuang;
                _HideShizhuang = value;

                OnChanged(oldValue, value, "HideShizhuang");
            }
        }
        private bool _HideShizhuang;

        
        public bool HideHelmet
        {
            get { return _HideHelmet; }
            set
            {
                if (_HideHelmet == value) return;

                var oldValue = _HideHelmet;
                _HideHelmet = value;

                OnChanged(oldValue, value, "HideHelmet");
            }
        }
        private bool _HideHelmet;

        
        public bool Dun
        {
            get { return _Dun; }
            set
            {
                if (_Dun == value) return;

                var oldValue = _Dun;
                _Dun = value;

                OnChanged(oldValue, value, "Dun");
            }
        }
        private bool _Dun;

        public bool CanDeathDrop
        {
            get { return _CanDeathDrop; }
            set
            {
                if (_CanDeathDrop == value) return;

                var oldValue = _CanDeathDrop;
                _CanDeathDrop = value;

                OnChanged(oldValue, value, "CanDeathDrop");
            }
        }
        private bool _CanDeathDrop;
        
        public int Rebirth
        {
            get => _Rebirth;
            set
            {
                if (_Rebirth == value) return;

                int oldValue = _Rebirth;
                _Rebirth = value;

                OnChanged(oldValue, value, "Rebirth");
            }
        }
        private int _Rebirth;

        
        public int Mingwen01
        {
            get { return _Mingwen01; }
            set
            {
                if (_Mingwen01 == value) return;

                var oldValue = _Mingwen01;
                _Mingwen01 = value;

                OnChanged(oldValue, value, "Mingwen01");
            }
        }
        private int _Mingwen01;
        
        public int Mingwen02
        {
            get { return _Mingwen02; }
            set
            {
                if (_Mingwen02 == value) return;

                var oldValue = _Mingwen02;
                _Mingwen02 = value;

                OnChanged(oldValue, value, "Mingwen02");
            }
        }
        private int _Mingwen02;
        
        public int Mingwen03
        {
            get { return _Mingwen03; }
            set
            {
                if (_Mingwen03 == value) return;

                var oldValue = _Mingwen03;
                _Mingwen03 = value;

                OnChanged(oldValue, value, "Mingwen03");
            }
        }
        private int _Mingwen03;


        public DateTime NextDeathDropChange
        {
            get { return _NextDeathDropChange; }
            set
            {
                if (_NextDeathDropChange == value) return;

                var oldValue = _NextDeathDropChange;
                _NextDeathDropChange = value;

                OnChanged(oldValue, value, "NextDeathDropChange");
            }
        }
        private DateTime _NextDeathDropChange;
        
        
        
        [Association("Companion")]
        public UserCompanion Companion
        {
            get { return _Companion; }
            set
            {
                if (_Companion == value) return;

                var oldValue = _Companion;
                _Companion = value;

                OnChanged(oldValue, value, "Companion");
            }
        }
        private UserCompanion _Companion;
        
        [Association("Items", true)]
        public DBBindingList<UserItem> Items { get; set; }

        [Association("BeltLinks", true)]
        public DBBindingList<CharacterBeltLink> BeltLinks { get; set; }

        [Association("AutoPotionLinks", true)]
        public DBBindingList<AutoPotionLink> AutoPotionLinks { get; set; }

        [Association("AutoFightLinks", true)]
        public DBBindingList<AutoFightConfig> AutoFightLinks { get; set; }
        
        [Association("UserTeleports", true)]
        public DBBindingList<UserTeleport> UserTeleports { get; set; }

        [Association("Magics", true)]
        public DBBindingList<UserMagic> Magics { get; set; }

        [Association("Buffs", true)]
        public DBBindingList<BuffInfo> Buffs { get; set; }
        
        [Association("Refines", true)]
        public DBBindingList<RefineInfo> Refines { get; set; }

        [Association("Quests", true)]
        public DBBindingList<UserQuest> Quests { get; set; }

        [Association("Marriage")]
        public CharacterInfo Partner
        {
            get { return _Partner; }
            set
            {
                if (_Partner == value) return;

                var oldValue = _Partner;
                _Partner = value;

                OnChanged(oldValue, value, "Partner");
            }
        }
        private CharacterInfo _Partner;


        protected override void OnDeleted()
        {
            Account = null;
            Companion = null;
            Partner = null;
            
            base.OnDeleted();
        }




        public PlayerObject Player;
        public LinkedListNode<CharacterInfo> RankingNode;

        public SelectInfo ToSelectInfo()
        {
            return new SelectInfo
            {
                CharacterIndex = Index,
                CharacterName = CharacterName,
                Class = Class,
                Gender = Gender,
                Level = Level,
                Location = CurrentMap?.Index ?? 0,
                LastLogin = LastLogin,
            };
        }

        protected override void OnCreated()
        {
            base.OnCreated();

            LastStats = new Stats();
            HermitStats = new Stats();

            Observable = true;

           
        }


        public override string ToString()
        {
            return CharacterName;
        }

    }
}
