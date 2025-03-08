using System;
using System.Drawing;
using Library;
using Library.SystemModels;
using CartoonMirDB;
using Server.Envir;

namespace Server.DBModels
{
    [UserObject]
    public sealed class UserItem : DBObject
    {
        public ItemInfo Info
        {
            get { return _Info; }
            set
            {
                if (_Info == value) return;

                var oldValue = _Info;
                _Info = value;

                OnChanged(oldValue, value, "Info");
            }
        }
        private ItemInfo _Info;
        
        public int CurrentDurability
        {
            get { return _CurrentDurability; }
            set
            {
                if (_CurrentDurability == value) return;

                var oldValue = _CurrentDurability;
                _CurrentDurability = value;

                OnChanged(oldValue, value, "CurrentDurability");
            }
        }
        private int _CurrentDurability;

        public int MaxDurability
        {
            get { return _MaxDurability; }
            set
            {
                if (_MaxDurability == value) return;

                var oldValue = _MaxDurability;
                _MaxDurability = value;

                OnChanged(oldValue, value, "MaxDurability");
            }
        }
        private int _MaxDurability;

        public long Count
        {
            get { return _Count; }
            set
            {
                if (_Count == value) return;

                var oldValue = _Count;
                _Count = value;

                OnChanged(oldValue, value, "Count");
            }
        }
        private long _Count;

        public int Slot
        {
            get { return _Slot; }
            set
            {
                if (_Slot == value) return;

                var oldValue = _Slot;
                _Slot = value;

                OnChanged(oldValue, value, "Slot");
            }
        }
        private int _Slot;

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

        public Color Colour
        {
            get { return _Colour; }
            set
            {
                if (_Colour == value) return;

                var oldValue = _Colour;
                _Colour = value;

                OnChanged(oldValue, value, "Colour");
            }
        }
        private Color _Colour;

        public DateTime SpecialRepairCoolDown
        {
            get { return _specialRepairCoolDown; }
            set
            {
                if (_specialRepairCoolDown == value) return;

                var oldValue = _specialRepairCoolDown;
                _specialRepairCoolDown = value;

                OnChanged(oldValue, value, "SpecialRepairCoolDown");
            }
        }
        private DateTime _specialRepairCoolDown;

        public DateTime ResetCoolDown
        {
            get { return _ResetCoolDown; }
            set
            {
                if (_ResetCoolDown == value) return;

                var oldValue = _ResetCoolDown;
                _ResetCoolDown = value;

                OnChanged(oldValue, value, "ResetCoolDown");
            }
        }
        private DateTime _ResetCoolDown;


        public Rarity Rarity
        {
            get
            {
                return _Rarity;
            }
            set
            {
                if (_Rarity != value)
                {
                    Rarity oldValue = _Rarity;
                    _Rarity = value;
                    OnChanged(oldValue, value, "Rarity");
                }
            }
        }
        public Rarity _Rarity;


        public UserQuestTask UserTask;

        public MeiriUserQuestTask MeiriUserTask;


        [Association("Items")]
        public CharacterInfo Character
        {
            get { return _Character; }
            set
            {
                if (_Character == value) return;

                var oldValue = _Character;
                _Character = value;

                OnChanged(oldValue, value, "Character");
            }
        }
        private CharacterInfo _Character;

        [Association("Items")]
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

        [Association("Items")]
        public GuildInfo Guild
        {
            get { return _Guild; }
            set
            {
                if (_Guild == value) return;

                var oldValue = _Guild;
                _Guild = value;

                OnChanged(oldValue, value, "Guild");
            }
        }
        private GuildInfo _Guild;

        [Association("Items")]
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


        [Association("Refine")]
        public RefineInfo Refine
        {
            get { return _Refine; }
            set
            {
                if (_Refine == value) return;

                var oldValue = _Refine;
                _Refine = value;

                OnChanged(oldValue, value, "Refine");
            }
        }
        private RefineInfo _Refine;
        
        [Association("Auction")]
        public AuctionInfo Auction
        {
            get { return _Auction; }
            set
            {
                if (_Auction == value) return;

                var oldValue = _Auction;
                _Auction = value;

                OnChanged(oldValue, value, "Auction");
            }
        }
        private AuctionInfo _Auction;

        [Association("Mail")]
        public MailInfo Mail
        {
            get { return _Mail; }
            set
            {
                if (_Mail == value) return;

                var oldValue = _Mail;
                _Mail = value;

                OnChanged(oldValue, value, "Mail");
            }
        }
        private MailInfo _Mail;

        public UserItemFlags Flags
        {
            get { return _Flags; }
            set
            {
                if (_Flags == value) return;

                var oldValue = _Flags;
                _Flags = value;

                OnChanged(oldValue, value, "Flags");
            }
        }
        private UserItemFlags _Flags;

        public BaoshiMaYi BaoshiMaYi
        {
            get { return _BaoshiMaYi; }
            set
            {
                if (_BaoshiMaYi == value) return;

                var oldValue = _BaoshiMaYi;
                _BaoshiMaYi = value;

                OnChanged(oldValue, value, "BaoshiMaYi");
            }
        }
        private BaoshiMaYi _BaoshiMaYi;

        public BaoshiMaEr BaoshiMaEr
        {
            get { return _BaoshiMaEr; }
            set
            {
                if (_BaoshiMaEr == value) return;

                var oldValue = _BaoshiMaEr;
                _BaoshiMaEr = value;

                OnChanged(oldValue, value, "BaoshiMaEr");
            }
        }
        private BaoshiMaEr _BaoshiMaEr;

        public BaoshiMaSan BaoshiMaSan
        {
            get { return _BaoshiMaSan; }
            set
            {
                if (_BaoshiMaSan == value) return;

                var oldValue = _BaoshiMaSan;
                _BaoshiMaSan = value;

                OnChanged(oldValue, value, "BaoshiMaSan");
            }
        }
        private BaoshiMaSan _BaoshiMaSan;

        public BaoshiMaSi BaoshiMaSi
        {
            get { return _BaoshiMaSi; }
            set
            {
                if (_BaoshiMaSi == value) return;

                var oldValue = _BaoshiMaSi;
                _BaoshiMaSi = value;

                OnChanged(oldValue, value, "BaoshiMaSi");
            }
        }
        private BaoshiMaSi _BaoshiMaSi;

        public BaoshiMaWu BaoshiMaWu
        {
            get { return _BaoshiMaWu; }
            set
            {
                if (_BaoshiMaWu == value) return;

                var oldValue = _BaoshiMaWu;
                _BaoshiMaWu = value;

                OnChanged(oldValue, value, "BaoshiMaWu");
            }
        }
        private BaoshiMaWu _BaoshiMaWu;

        public BaoshiMaLiu BaoshiMaLiu
        {
            get { return _BaoshiMaLiu; }
            set
            {
                if (_BaoshiMaLiu == value) return;

                var oldValue = _BaoshiMaLiu;
                _BaoshiMaLiu = value;

                OnChanged(oldValue, value, "BaoshiMaLiu");
            }
        }
        private BaoshiMaLiu _BaoshiMaLiu;

        public BaoshiMaQi BaoshiMaQi
        {
            get { return _BaoshiMaQi; }
            set
            {
                if (_BaoshiMaQi == value) return;

                var oldValue = _BaoshiMaQi;
                _BaoshiMaQi = value;

                OnChanged(oldValue, value, "BaoshiMaQi");
            }
        }
        private BaoshiMaQi _BaoshiMaQi;

        public BaoshiMaBa BaoshiMaBa
        {
            get { return _BaoshiMaBa; }
            set
            {
                if (_BaoshiMaBa == value) return;

                var oldValue = _BaoshiMaBa;
                _BaoshiMaBa = value;

                OnChanged(oldValue, value, "BaoshiMaBa");
            }
        }
        private BaoshiMaBa _BaoshiMaBa;

        public BaoshiMaJiu BaoshiMaJiu
        {
            get { return _BaoshiMaJiu; }
            set
            {
                if (_BaoshiMaJiu == value) return;

                var oldValue = _BaoshiMaJiu;
                _BaoshiMaJiu = value;

                OnChanged(oldValue, value, "BaoshiMaJiu");
            }
        }
        private BaoshiMaJiu _BaoshiMaJiu;

        public BaoshiMaShi BaoshiMaShi
        {
            get { return _BaoshiMaShi; }
            set
            {
                if (_BaoshiMaShi == value) return;

                var oldValue = _BaoshiMaShi;
                _BaoshiMaShi = value;

                OnChanged(oldValue, value, "BaoshiMaShi");
            }
        }
        private BaoshiMaShi _BaoshiMaShi;

        public BaoshiMaShiyi BaoshiMaShiyi
        {
            get { return _BaoshiMaShiyi; }
            set
            {
                if (_BaoshiMaShiyi == value) return;

                var oldValue = _BaoshiMaShiyi;
                _BaoshiMaShiyi = value;

                OnChanged(oldValue, value, "BaoshiMaShiyi");
            }
        }
        private BaoshiMaShiyi _BaoshiMaShiyi;

        public BaoshiMaShier BaoshiMaShier
        {
            get { return _BaoshiMaShier; }
            set
            {
                if (_BaoshiMaShier == value) return;

                var oldValue = _BaoshiMaShier;
                _BaoshiMaShier = value;

                OnChanged(oldValue, value, "BaoshiMaShier");
            }
        }
        private BaoshiMaShier _BaoshiMaShier;

        public BaoshiMaShisan BaoshiMaShisan
        {
            get { return _BaoshiMaShisan; }
            set
            {
                if (_BaoshiMaShisan == value) return;

                var oldValue = _BaoshiMaShisan;
                _BaoshiMaShisan = value;

                OnChanged(oldValue, value, "BaoshiMaShisan");
            }
        }
        private BaoshiMaShisan _BaoshiMaShisan;

        public BaoshiMaShisi BaoshiMaShisi
        {
            get { return _BaoshiMaShisi; }
            set
            {
                if (_BaoshiMaShisi == value) return;

                var oldValue = _BaoshiMaShisi;
                _BaoshiMaShisi = value;

                OnChanged(oldValue, value, "BaoshiMaShisi");
            }
        }
        private BaoshiMaShisi _BaoshiMaShisi;

        
        public decimal MingwenExp
        {
            get { return _MingwenExp; }
            set
            {
                if (_MingwenExp == value) return;

                var oldValue = _MingwenExp;
                _MingwenExp = value;

                OnChanged(oldValue, value, "MingwenExp");
            }
        }
        private decimal _MingwenExp;

        
        public int MingwenLv
        {
            get { return _MingwenLv; }
            set
            {
                if (_MingwenLv == value) return;

                var oldValue = _MingwenLv;
                _MingwenLv = value;

                OnChanged(oldValue, value, "MingwenLv");
            }
        }
        private int _MingwenLv;

        
        public MingwenMaYi MingwenMaYi
        {
            get { return _MingwenMaYi; }
            set
            {
                if (_MingwenMaYi == value) return;

                var oldValue = _MingwenMaYi;
                _MingwenMaYi = value;

                OnChanged(oldValue, value, "MingwenMaYi");
            }
        }
        private MingwenMaYi _MingwenMaYi;

        
        public MingwenMaEr MingwenMaEr
        {
            get { return _MingwenMaEr; }
            set
            {
                if (_MingwenMaEr == value) return;

                var oldValue = _MingwenMaEr;
                _MingwenMaEr = value;

                OnChanged(oldValue, value, "MingwenMaEr");
            }
        }
        private MingwenMaEr _MingwenMaEr;

        
        public MingwenMaSan MingwenMaSan
        {
            get { return _MingwenMaSan; }
            set
            {
                if (_MingwenMaSan == value) return;

                var oldValue = _MingwenMaSan;
                _MingwenMaSan = value;

                OnChanged(oldValue, value, "MingwenMaSan");
            }
        }
        private MingwenMaSan _MingwenMaSan;

        
        public MingwenMaSi MingwenMaSi
        {
            get { return _MingwenMaSi; }
            set
            {
                if (_MingwenMaSi == value) return;

                var oldValue = _MingwenMaSi;
                _MingwenMaSi = value;

                OnChanged(oldValue, value, "MingwenMaSi");
            }
        }
        private MingwenMaSi _MingwenMaSi;

        
        public MingwenMaWu MingwenMaWu
        {
            get { return _MingwenMaWu; }
            set
            {
                if (_MingwenMaWu == value) return;

                var oldValue = _MingwenMaWu;
                _MingwenMaWu = value;

                OnChanged(oldValue, value, "MingwenMaWu");
            }
        }
        private MingwenMaWu _MingwenMaWu;

        
        public MingwenMaLiu MingwenMaLiu
        {
            get { return _MingwenMaLiu; }
            set
            {
                if (_MingwenMaLiu == value) return;

                var oldValue = _MingwenMaLiu;
                _MingwenMaLiu = value;

                OnChanged(oldValue, value, "MingwenMaLiu");
            }
        }
        private MingwenMaLiu _MingwenMaLiu;

        
        public MingwenMaQi MingwenMaQi
        {
            get { return _MingwenMaQi; }
            set
            {
                if (_MingwenMaQi == value) return;

                var oldValue = _MingwenMaQi;
                _MingwenMaQi = value;

                OnChanged(oldValue, value, "MingwenMaQi");
            }
        }
        private MingwenMaQi _MingwenMaQi;

        
        public MingwenMaBa MingwenMaBa
        {
            get { return _MingwenMaBa; }
            set
            {
                if (_MingwenMaBa == value) return;

                var oldValue = _MingwenMaBa;
                _MingwenMaBa = value;

                OnChanged(oldValue, value, "MingwenMaBa");
            }
        }
        private MingwenMaBa _MingwenMaBa;

        
        public MingwenMaJiu MingwenMaJiu
        {
            get { return _MingwenMaJiu; }
            set
            {
                if (_MingwenMaJiu == value) return;

                var oldValue = _MingwenMaJiu;
                _MingwenMaJiu = value;

                OnChanged(oldValue, value, "MingwenMaJiu");
            }
        }
        private MingwenMaJiu _MingwenMaJiu;

        
        public MingwenMaShi MingwenMaShi
        {
            get { return _MingwenMaShi; }
            set
            {
                if (_MingwenMaShi == value) return;

                var oldValue = _MingwenMaShi;
                _MingwenMaShi = value;

                OnChanged(oldValue, value, "MingwenMaShi");
            }
        }
        private MingwenMaShi _MingwenMaShi;

        
        public MingwenMaShiyi MingwenMaShiyi
        {
            get { return _MingwenMaShiyi; }
            set
            {
                if (_MingwenMaShiyi == value) return;

                var oldValue = _MingwenMaShiyi;
                _MingwenMaShiyi = value;

                OnChanged(oldValue, value, "MingwenMaShiyi");
            }
        }
        private MingwenMaShiyi _MingwenMaShiyi;

        
        public MingwenMaShier MingwenMaShier
        {
            get { return _MingwenMaShier; }
            set
            {
                if (_MingwenMaShier == value) return;

                var oldValue = _MingwenMaShier;
                _MingwenMaShier = value;

                OnChanged(oldValue, value, "MingwenMaShier");
            }
        }
        private MingwenMaShier _MingwenMaShier;

        
        public MingwenMaShisan MingwenMaShisan
        {
            get { return _MingwenMaShisan; }
            set
            {
                if (_MingwenMaShisan == value) return;

                var oldValue = _MingwenMaShisan;
                _MingwenMaShisan = value;

                OnChanged(oldValue, value, "MingwenMaShisan");
            }
        }
        private MingwenMaShisan _MingwenMaShisan;

        
        public MingwenMaShisi MingwenMaShisi
        {
            get { return _MingwenMaShisi; }
            set
            {
                if (_MingwenMaShisi == value) return;

                var oldValue = _MingwenMaShisi;
                _MingwenMaShisi = value;

                OnChanged(oldValue, value, "MingwenMaShisi");
            }
        }
        private MingwenMaShisi _MingwenMaShisi;

        
        public MingwenMaShiwu MingwenMaShiwu
        {
            get { return _MingwenMaShiwu; }
            set
            {
                if (_MingwenMaShiwu == value) return;

                var oldValue = _MingwenMaShiwu;
                _MingwenMaShiwu = value;

                OnChanged(oldValue, value, "MingwenMaShiwu");
            }
        }
        private MingwenMaShiwu _MingwenMaShiwu;

        
        public MingwenMaShiliu MingwenMaShiliu
        {
            get { return _MingwenMaShiliu; }
            set
            {
                if (_MingwenMaShiliu == value) return;

                var oldValue = _MingwenMaShiliu;
                _MingwenMaShiliu = value;

                OnChanged(oldValue, value, "MingwenMaShiliu");
            }
        }
        private MingwenMaShiliu _MingwenMaShiliu;

        
        public MingwenMaShiqi MingwenMaShiqi
        {
            get { return _MingwenMaShiqi; }
            set
            {
                if (_MingwenMaShiqi == value) return;

                var oldValue = _MingwenMaShiqi;
                _MingwenMaShiqi = value;

                OnChanged(oldValue, value, "MingwenMaShiqi");
            }
        }
        private MingwenMaShiqi _MingwenMaShiqi;

        
        public MingwenMaShiba MingwenMaShiba
        {
            get { return _MingwenMaShiba; }
            set
            {
                if (_MingwenMaShiba == value) return;

                var oldValue = _MingwenMaShiba;
                _MingwenMaShiba = value;

                OnChanged(oldValue, value, "MingwenMaShiba");
            }
        }
        private MingwenMaShiba _MingwenMaShiba;

        
        public MingwenMaShijiu MingwenMaShijiu
        {
            get { return _MingwenMaShijiu; }
            set
            {
                if (_MingwenMaShijiu == value) return;

                var oldValue = _MingwenMaShijiu;
                _MingwenMaShijiu = value;

                OnChanged(oldValue, value, "MingwenMaShijiu");
            }
        }
        private MingwenMaShijiu _MingwenMaShijiu;

        
        public MingwenMaErshi MingwenMaErshi
        {
            get { return _MingwenMaErshi; }
            set
            {
                if (_MingwenMaErshi == value) return;

                var oldValue = _MingwenMaErshi;
                _MingwenMaErshi = value;

                OnChanged(oldValue, value, "MingwenMaErshi");
            }
        }
        private MingwenMaErshi _MingwenMaErshi;

        
        public MingwenMaErshiyi MingwenMaErshiyi
        {
            get { return _MingwenMaErshiyi; }
            set
            {
                if (_MingwenMaErshiyi == value) return;

                var oldValue = _MingwenMaErshiyi;
                _MingwenMaErshiyi = value;

                OnChanged(oldValue, value, "MingwenMaErshiyi");
            }
        }
        private MingwenMaErshiyi _MingwenMaErshiyi;

        
        public MingwenMaErshier MingwenMaErshier
        {
            get { return _MingwenMaErshier; }
            set
            {
                if (_MingwenMaErshier == value) return;

                var oldValue = _MingwenMaErshier;
                _MingwenMaErshier = value;

                OnChanged(oldValue, value, "MingwenMaErshier");
            }
        }
        private MingwenMaErshier _MingwenMaErshier;

        
        public MingwenMaErshisan MingwenMaErshisan
        {
            get { return _MingwenMaErshisan; }
            set
            {
                if (_MingwenMaErshisan == value) return;

                var oldValue = _MingwenMaErshisan;
                _MingwenMaErshisan = value;

                OnChanged(oldValue, value, "MingwenMaErshisan");
            }
        }
        private MingwenMaErshisan _MingwenMaErshisan;

        
        public MingwenMaErshisi MingwenMaErshisi
        {
            get { return _MingwenMaErshisi; }
            set
            {
                if (_MingwenMaErshisi == value) return;

                var oldValue = _MingwenMaErshisi;
                _MingwenMaErshisi = value;

                OnChanged(oldValue, value, "MingwenMaErshisi");
            }
        }
        private MingwenMaErshisi _MingwenMaErshisi;

        
        public MingwenMaErshiwu MingwenMaErshiwu
        {
            get { return _MingwenMaErshiwu; }
            set
            {
                if (_MingwenMaErshiwu == value) return;

                var oldValue = _MingwenMaErshiwu;
                _MingwenMaErshiwu = value;

                OnChanged(oldValue, value, "MingwenMaErshiwu");
            }
        }
        private MingwenMaErshiwu _MingwenMaErshiwu;

        
        public MingwenMaErshiliu MingwenMaErshiliu
        {
            get { return _MingwenMaErshiliu; }
            set
            {
                if (_MingwenMaErshiliu == value) return;

                var oldValue = _MingwenMaErshiliu;
                _MingwenMaErshiliu = value;

                OnChanged(oldValue, value, "MingwenMaErshiliu");
            }
        }
        private MingwenMaErshiliu _MingwenMaErshiliu;

        
        public MingwenMaErshiqi MingwenMaErshiqi
        {
            get { return _MingwenMaErshiqi; }
            set
            {
                if (_MingwenMaErshiqi == value) return;

                var oldValue = _MingwenMaErshiqi;
                _MingwenMaErshiqi = value;

                OnChanged(oldValue, value, "MingwenMaErshiqi");
            }
        }
        private MingwenMaErshiqi _MingwenMaErshiqi;

        
        public MingwenMaErshiba MingwenMaErshiba
        {
            get { return _MingwenMaErshiba; }
            set
            {
                if (_MingwenMaErshiba == value) return;

                var oldValue = _MingwenMaErshiba;
                _MingwenMaErshiba = value;

                OnChanged(oldValue, value, "MingwenMaErshiba");
            }
        }
        private MingwenMaErshiba _MingwenMaErshiba;

        
        public MingwenMaErshijiu MingwenMaErshijiu
        {
            get { return _MingwenMaErshijiu; }
            set
            {
                if (_MingwenMaErshijiu == value) return;

                var oldValue = _MingwenMaErshijiu;
                _MingwenMaErshijiu = value;

                OnChanged(oldValue, value, "MingwenMaErshijiu");
            }
        }
        private MingwenMaErshijiu _MingwenMaErshijiu;

        
        public MingwenMaSanshi MingwenMaSanshi
        {
            get { return _MingwenMaSanshi; }
            set
            {
                if (_MingwenMaSanshi == value) return;

                var oldValue = _MingwenMaSanshi;
                _MingwenMaSanshi = value;

                OnChanged(oldValue, value, "MingwenMaSanshi");
            }
        }
        private MingwenMaSanshi _MingwenMaSanshi;

        public TimeSpan ExpireTime
        {
            get { return _ExpireTime; }
            set
            {
                if (_ExpireTime == value) return;

                var oldValue = _ExpireTime;
                _ExpireTime = value;

                OnChanged(oldValue, value, "ExpireTime");
            }
        }
        private TimeSpan _ExpireTime;

        
        
        [Association("AddedStats", true)]
        public DBBindingList<UserItemStat> AddedStats { get; set; }

        [IgnoreProperty]
        public int Weight
        {
            get
            {
                switch (Info.ItemType)
                {
                    case ItemType.Poison:
                    case ItemType.Amulet:
                        return Info.Weight;
                    default:
                        return (int)Math.Min(int.MaxValue, Info.Weight * Count);
                }
            }
        }

        public Stats Stats = new Stats();

        protected override void OnChanged(object oldValue, object newValue, string propertyName)
        {
            base.OnChanged(oldValue, newValue, propertyName);

            switch (propertyName)
            {
                case "Account":
                    if (Account != null)
                    {
                        Character = null;
                        Refine = null;
                        Auction = null;
                        Mail = null;
                        Guild = null;
                        Companion = null;
                    }
                    break;
                case "Character":
                    if (Character != null)
                    {
                        Account = null;
                        Refine = null;
                        Auction = null;
                        Mail = null;
                        Guild = null;
                        Companion = null;
                    }
                    break;
                case "Refine":
                    if (Refine != null)
                    {
                        Account = null;
                        Character = null;
                        Auction = null;
                        Mail = null;
                        Guild = null;
                        Companion = null;
                    }
                    break;
                case "Auction":
                    if (Auction != null)
                    {
                        Account = null;
                        Character = null;
                        Refine = null;
                        Mail = null;
                        Guild = null;
                        Companion = null;
                    }
                    break;
                case "Mail":
                    if (Mail != null)
                    {
                        Account = null;
                        Character = null;
                        Refine = null;
                        Auction = null;
                        Guild = null;
                        Companion = null;
                    }
                    break;
                case "Guild":
                    if (Guild != null)
                    {
                        Character = null;
                        Account = null;
                        Refine = null;
                        Auction = null;
                        Mail = null;
                        Companion = null;
                    }
                    break;
                case "Companion":
                    if (Companion != null)
                    {
                        Character = null;
                        Account = null;
                        Refine = null;
                        Auction = null;
                        Mail = null;
                        Guild = null;
                    }
                    break;

            }
        }

        protected override void OnDeleted()
        {
            Info = null;

            Character = null;
            Account = null;
            Guild = null;
            Companion = null;
            Refine = null;
            Auction = null;
            Mail = null;
            UserTask = null;
            MeiriUserTask = null;

            for (int i = AddedStats.Count - 1; i >= 0; i--)
                AddedStats[i].Delete();

            UserTask = null;
            MeiriUserTask = null;

            base.OnDeleted();
        }


        protected override void OnCreated()
        {
            base.OnCreated();

            Count = 1;
            Slot = -1;
            Level = 1;
            MingwenLv = 1;
        }
        protected override void OnLoaded()
        {
            base.OnLoaded();

            StatsChanged();
        }

        public void StatsChanged()
        {
            Stats.Clear();

            foreach (UserItemStat stat in AddedStats)
                Stats[stat.Stat] += stat.Amount;
        }
        public void AddStat(Stat stat, int amount, StatSource source)
        {
            foreach (UserItemStat addedStat in AddedStats)
            {
                if (addedStat.Stat != stat || addedStat.StatSource != source) continue;


                addedStat.Amount += amount;

                return;
            }

            if (amount == 0) return;

            UserItemStat newStat = SEnvir.UserItemStatsList.CreateNewObject();

            newStat.StatSource = source;
            newStat.Stat = stat;
            newStat.Amount = amount;
            newStat.Item = this;
        }

        public ClientUserItem ToClientInfo()
        {
            return new ClientUserItem
            {
                Index =  Index,

                InfoIndex = Info.Index,

                CurrentDurability = CurrentDurability,
                MaxDurability = MaxDurability,

                Count = Count,
                
                Slot = Slot,

                Level = Level,
                Experience = Experience,

                Colour = Colour,

                SpecialRepairCoolDown = SpecialRepairCoolDown > SEnvir.Now ? SpecialRepairCoolDown - SEnvir.Now : TimeSpan.Zero,
                ResetCoolDown = ResetCoolDown > SEnvir.Now ? ResetCoolDown - SEnvir.Now : TimeSpan.Zero,

                AddedStats = new Stats(Stats),

                Flags = Flags,

                BaoshiMaYi = BaoshiMaYi,
                BaoshiMaEr = BaoshiMaEr,
                BaoshiMaSan = BaoshiMaSan,
                BaoshiMaSi = BaoshiMaSi,
                BaoshiMaWu = BaoshiMaWu,
                BaoshiMaLiu = BaoshiMaLiu,
                BaoshiMaQi = BaoshiMaQi,
                BaoshiMaBa = BaoshiMaBa,
                BaoshiMaJiu = BaoshiMaJiu,
                BaoshiMaShi = BaoshiMaShi,
                BaoshiMaShiyi = BaoshiMaShiyi,
                BaoshiMaShier = BaoshiMaShier,
                BaoshiMaShisan = BaoshiMaShisan,
                BaoshiMaShisi = BaoshiMaShisi,
                
                MingwenMaYi = MingwenMaYi,
                MingwenMaEr = MingwenMaEr,
                MingwenMaSan = MingwenMaSan,
                MingwenMaSi = MingwenMaSi,
                MingwenMaWu = MingwenMaWu,
                MingwenMaLiu = MingwenMaLiu,
                MingwenMaQi = MingwenMaQi,
                MingwenMaBa = MingwenMaBa,
                MingwenMaJiu = MingwenMaJiu,
                MingwenMaShi = MingwenMaShi,
                MingwenMaShiyi = MingwenMaShiyi,
                MingwenMaShier = MingwenMaShier,
                MingwenMaShisan = MingwenMaShisan,
                MingwenMaShisi = MingwenMaShisi,
                MingwenMaShiwu = MingwenMaShiwu,
                MingwenMaShiliu = MingwenMaShiliu,
                MingwenMaShiqi = MingwenMaShiqi,
                MingwenMaShiba = MingwenMaShiba,
                MingwenMaShijiu = MingwenMaShijiu,
                MingwenMaErshi = MingwenMaErshi,
                MingwenMaErshiyi = MingwenMaErshiyi,
                MingwenMaErshier = MingwenMaErshier,
                MingwenMaErshisan = MingwenMaErshisan,
                MingwenMaErshisi = MingwenMaErshisi,
                MingwenMaErshiwu = MingwenMaErshiwu,
                MingwenMaErshiliu = MingwenMaErshiliu,
                MingwenMaErshiqi = MingwenMaErshiqi,
                MingwenMaErshiba = MingwenMaErshiba,
                MingwenMaErshijiu = MingwenMaErshijiu,
                MingwenMaSanshi = MingwenMaSanshi,

                ExpireTime =  ExpireTime,
                
                MingwenLv = MingwenLv,
                
                MingwenExp = MingwenExp,
            };
        }
        
        public long Price(long count)
        {
            if (Info == null) return 0;
            if ((Flags & UserItemFlags.Worthless) == UserItemFlags.Worthless) return 0;

            decimal p = Info.Price;

            if (Info.Durability > 0)
            {
                decimal r = Info.Price / 2M / Info.Durability;

                p = MaxDurability * r;

                r = MaxDurability > 0 ? CurrentDurability / (decimal)MaxDurability : 0;

                p = Math.Floor(p / 2M + p / 2M * r + Info.Price / 2M);
            }

            p = p * (Stats.Count * 0.1M + 1M);

            if (Info.Stats[Stat.SaleBonus20] > 0 && Info.Stats[Stat.SaleBonus20] <= count)
                p *= 1.2M;
            else if (Info.Stats[Stat.SaleBonus15] > 0 && Info.Stats[Stat.SaleBonus15] <= count)
                p *= 1.15M;
            else if (Info.Stats[Stat.SaleBonus10] > 0 && Info.Stats[Stat.SaleBonus10] <= count)
                p *= 1.1M;
            else if (Info.Stats[Stat.SaleBonus5] > 0 && Info.Stats[Stat.SaleBonus5] <= count)
                p *= 1.05M;

            return (long)(p * count * Info.SellRate);
        }
        
        public long Exp(long count)
        {
            if (Info == null) return 0;
            if ((Flags & UserItemFlags.Worthless) == UserItemFlags.Worthless) return 0;

            decimal p = Info.Exp;

            if (Info.Durability > 0)
            {
                decimal r = Info.Exp / 2M / Info.Durability;

                p = MaxDurability * r;

                r = MaxDurability > 0 ? CurrentDurability / (decimal)MaxDurability : 0;

                p = Math.Floor(p / 2M + p / 2M * r + Info.Exp / 2M);
            }

            

            return (long)(p * count);
        }
        public long RepairCost(bool special)
        {
            if (Info.Durability == 0 || CurrentDurability >= MaxDurability) return 0;

            int rate = special ? 2 : 1;

            decimal p = Math.Floor(MaxDurability * (Info.Price / 2M / Info.Durability) + Info.Price / 2M);
            p = p * (Stats.Count * 0.1M + 1M);

            return (long)(p * Count - Price(Count)) * rate;
        }
        public bool CanFragment()
        {
            if ((Flags & UserItemFlags.Worthless) == UserItemFlags.Worthless || (Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable) return false;

            switch (Info.Rarity)
            {
                case Rarity.Common:
                    if (Info.RequiredAmount <= 15) return false;
                    break;
                case Rarity.Superior:
                    break;
                case Rarity.Elite:
                    break;
            }

            switch (Info.ItemType)
            {
                case ItemType.Weapon:
                case ItemType.Armour:
                case ItemType.Helmet:
                case ItemType.Necklace:
                case ItemType.Bracelet:
                case ItemType.Ring:
                case ItemType.Shoes:
                    break;
                default:
                    return false;
            }

            return true;
        }
        public int FragmentCost()
        {
            switch (Info.Rarity)
            {
                case Rarity.Common:
                    switch (Info.ItemType)
                    {
                        case ItemType.Armour:
                        case ItemType.Weapon:
                        case ItemType.Helmet:
                        case ItemType.Necklace:
                        case ItemType.Bracelet:
                        case ItemType.Ring:
                        case ItemType.Shoes:
                            return Info.RequiredAmount * 10000 / 9;
                      /*  case ItemType.Helmet:
                        case ItemType.Necklace:
                        case ItemType.Bracelet:
                        case ItemType.Ring:
                        case ItemType.Shoes:
                            return Info.RequiredAmount * 7000 / 9;*/
                        default:
                            return 0;
                    }
                case Rarity.Superior:
                    switch (Info.ItemType)
                    {
                        case ItemType.Armour:
                        case ItemType.Weapon:
                        case ItemType.Helmet:
                        case ItemType.Necklace:
                        case ItemType.Bracelet:
                        case ItemType.Ring:
                        case ItemType.Shoes:
                            return Info.RequiredAmount * 10000 / 2;
                      /*  case ItemType.Helmet:
                        case ItemType.Necklace:
                        case ItemType.Bracelet:
                        case ItemType.Ring:
                        case ItemType.Shoes:
                            return Info.RequiredAmount * 10000 / 10;*/
                        default:
                            return 0;
                    }
                case Rarity.Elite:
                    switch (Info.ItemType)
                    {
                        case ItemType.Weapon:
                        case ItemType.Armour:
                            return 250000;
                        case ItemType.Helmet:
                            return 50000;
                        case ItemType.Necklace:
                        case ItemType.Bracelet:
                        case ItemType.Ring:
                            return 150000;
                        case ItemType.Shoes:
                            return 30000;
                        default:
                            return 0;
                    }
                default:
                    return 0;
            }
        }
        
        public int ZaixianFragmentCost()
        {
            switch (Info.Rarity)
            {
                case Rarity.Common:
                    switch (Info.ItemType)
                    {
                        case ItemType.Armour:
                        case ItemType.Weapon:
                        case ItemType.Helmet:
                        case ItemType.Necklace:
                        case ItemType.Bracelet:
                        case ItemType.Ring:
                        case ItemType.Shoes:
                            return Info.RequiredAmount * 30000 / 9;
                        /* case ItemType.Helmet:
                         case ItemType.Necklace:
                         case ItemType.Bracelet:
                         case ItemType.Ring:
                         case ItemType.Shoes:
                             return Info.RequiredAmount * 7000 / 9;*/
                        default:
                            return 0;
                    }
                case Rarity.Superior:
                    switch (Info.ItemType)
                    {
                        case ItemType.Weapon:
                        case ItemType.Armour:
                        case ItemType.Helmet:
                        case ItemType.Necklace:
                        case ItemType.Bracelet:
                        case ItemType.Ring:
                        case ItemType.Shoes:
                            return Info.RequiredAmount * 30000 / 2;
                        /*  case ItemType.Helmet:
                          case ItemType.Necklace:
                          case ItemType.Bracelet:
                          case ItemType.Ring:
                          case ItemType.Shoes:
                              return Info.RequiredAmount * 10000 / 10;*/
                        default:
                            return 0;
                    }
                case Rarity.Elite:
                    switch (Info.ItemType)
                    {
                        case ItemType.Weapon:
                        case ItemType.Armour:
                            return 750000;
                        case ItemType.Helmet:
                            return 150000;
                        case ItemType.Necklace:
                        case ItemType.Bracelet:
                        case ItemType.Ring:
                            return 450000;
                        case ItemType.Shoes:
                            return 90000;
                        default:
                            return 0;
                    }
                default:
                    return 0;
            }
        }
        public int FragmentCount()
        {
            switch (Info.Rarity)
            {
                case Rarity.Common:
                    switch (Info.ItemType)
                    {
                        case ItemType.Armour:
                        case ItemType.Weapon:
                        case ItemType.Helmet:
                        case ItemType.Necklace:
                        case ItemType.Bracelet:
                        case ItemType.Ring:
                        case ItemType.Shoes:
                            return Math.Max(1, Info.RequiredAmount / 2 + 5);
                      /*  case ItemType.Helmet:
                            return Math.Max(1, (Info.RequiredAmount - 30) / 6);
                        case ItemType.Necklace:
                            return Math.Max(1, Info.RequiredAmount / 8);
                        case ItemType.Bracelet:
                            return Math.Max(1, Info.RequiredAmount / 15);
                        case ItemType.Ring:
                            return Math.Max(1, Info.RequiredAmount / 9);
                        case ItemType.Shoes:
                            return Math.Max(1, (Info.RequiredAmount - 35) / 6);*/
                        default:
                            return 0;
                    }
                case Rarity.Superior:
                    switch (Info.ItemType)
                    {
                        case ItemType.Armour:
                        case ItemType.Weapon:
                        case ItemType.Helmet:
                        case ItemType.Necklace:
                        case ItemType.Bracelet:
                        case ItemType.Ring:
                        case ItemType.Shoes:
                            return Math.Max(1, Info.RequiredAmount / 2 + 5);
                     /*   case ItemType.Helmet:
                            return Math.Max(1, (Info.RequiredAmount - 30) / 6);
                        case ItemType.Necklace:
                            return Math.Max(1, Info.RequiredAmount / 10);
                        case ItemType.Bracelet:
                            return Math.Max(1, Info.RequiredAmount / 15);
                        case ItemType.Ring:
                            return Math.Max(1, Info.RequiredAmount / 10);
                        case ItemType.Shoes:
                            return Math.Max(1, (Info.RequiredAmount - 35) / 6);*/
                        default:
                            return 0;
                    }
                case Rarity.Elite:
                    switch (Info.ItemType)
                    {
                        case ItemType.Armour:
                        case ItemType.Weapon:
                            return 50;
                        case ItemType.Helmet:
                            return 5;
                        case ItemType.Necklace:
                        case ItemType.Bracelet:
                        case ItemType.Ring:
                            return 10;
                        case ItemType.Shoes:
                            return 3;
                        default:
                            return 0;
                    }
                default:
                    return 0;
            }
        }

        public bool CraftInfoOnly
        {
            get { return _CraftInfoOnly; }
            set
            {
                if (_CraftInfoOnly == value) return;

                var oldValue = _CraftInfoOnly;
                _CraftInfoOnly = value;

                OnChanged(oldValue, value, "CraftInfoOnly");
            }
        }
        private bool _CraftInfoOnly;

        public int MergeRefineElements(out Stat element)
        {
            int value = 0;
            element = Stats.GetWeaponElement();

            for (int i = AddedStats.Count - 1; i >= 0; i--)
            {
                UserItemStat stat = AddedStats[i];
                if (stat.StatSource != StatSource.Refine) continue;

                switch (stat.Stat)
                {
                    case Stat.FireAttack:
                    case Stat.IceAttack:
                    case Stat.LightningAttack:
                    case Stat.WindAttack:
                    case Stat.HolyAttack:
                    case Stat.DarkAttack:
                    case Stat.PhantomAttack:
                        value += stat.Amount;
                        stat.Delete();
                        break;
                }

            }

            if (value > 0 && element != Stat.None)
                AddStat(element, value, StatSource.Refine);

            return value;
        }


        public override string ToString()
        {
            return Info.ToString();
        }

        public static implicit operator UserItem(long v)
        {
            throw new NotImplementedException();
        }
    }
}
