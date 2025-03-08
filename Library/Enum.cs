using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    
    public enum MirGender : byte    
    {
        [Description("男")]
        Male,
        [Description("女")]
        Female
    }

    public enum MirClass : byte       
    {
        /*
        Warrior,
        Wizard,
        Taoist,
        Assassin,
         */

        [Description("战士")]
        Warrior,
        [Description("法师")]
        Wizard,
        [Description("道士")]
        Taoist,
        [Description("刺客")]
        Assassin,

    }

    public enum AttackMode : byte         
    {
        [Description("[和平攻击模式]")] Peace,
        [Description("[组队攻击模式]")] Group,
        [Description("[行会攻击模式]")] Guild,
        [Description("[善恶攻击模式]")] WarRedBrown,
        [Description("[全体攻击模式]")] All,
    }

    public enum PetMode : byte              
    {
        [Description("[宠物:跟随,攻击]")] Both,
        [Description("[宠物:跟随]")] Move,
        [Description("[宠物:攻击]")] Attack,
        [Description("[宠物:竞技]")] PvP,
        [Description("[宠物:停止]")] None,
    }

    public enum MirDirection : byte         
    {
        [Description("向上")] Up,
        [Description("右上")] UpRight,
        [Description("向右")] Right,
        [Description("右下")] DownRight,
        [Description("向下")] Down,
        [Description("左下")] DownLeft,
        [Description("向左")] Left,
        [Description("左上")] UpLeft,
    }

    [Flags]
    public enum RequiredClass : byte  
    {
        [Description("无")]
        None = 0,
        [Description("战士")]
        Warrior = 1,
        [Description("法师")]
        Wizard = 2,
        [Description("道士")]
        Taoist = 4,
        [Description("刺客")]
        Assassin = 8,
        [Description("战士/法师/道士")]
        WarWizTao = Warrior | Wizard | Taoist,
        [Description("法师/道士")]
        WizTao = Wizard | Taoist,
        [Description("战士/刺客")]
        AssWar = Warrior | Assassin,
        [Description("通用")]
        All = WarWizTao | Assassin
        /*
        None = 0,
        Warrior = 1,
        Wizard = 2,
        Taoist = 4,
        Assassin = 8,
        WarWizTao = Warrior | Wizard | Taoist,
        WizTao = Wizard | Taoist,
        AssWar = Warrior | Assassin,
        All = WarWizTao | Assassin
         */

    }

    [Flags]
    public enum RequiredGender : byte   
    {
        [Description("男")]
        Male = 1,
        [Description("女")]
        Female = 2,
        [Description("通用")]
        None = Male | Female
    }

    public enum EquipmentSlot         
    {
        Weapon = 0,                   
        Armour = 1,                   
        Helmet = 2,                   
        Torch = 3,                    
        Necklace = 4,                 
        BraceletL = 5,                
        BraceletR = 6,                
        RingL = 7,                    
        RingR = 8,                    
        Shoes = 9,                    
        Poison = 10,                  
        Amulet = 11,                  
        Flower = 12,                  
        HorseArmour = 13,             
        Emblem = 14,                  
        Shield = 15,                  
        SwChenghao = 16,              
        Shizhuang = 17,               
        Fabao = 18,                   
    }

    public enum CompanionSlot        
    {
        Bag = 0,                     
        Head = 1,                    
        Back = 2,                    
        Food = 3,                    
    }


    public enum GridType
    {
        None,
        Inventory,
        Equipment,
        Belt,
        Sell,
        Repair,
        Storage,
        AutoPotion,
        RefineBlackIronOre,
        RefineAccessory,
        RefineSpecial,
        Inspect,
        Consign,
        SendMail,
        TradeUser,
        TradePlayer,
        GuildStorage,
        CompanionInventory,
        CompanionEquipment,
        WeddingRing,
        RefinementStoneIronOre,
        RefinementStoneSilverOre,
        RefinementStoneDiamond,
        RefinementStoneGoldOre,
        RefinementStoneCrystal,
        ItemFragment,
        AccessoryRefineUpgradeTarget,
        AccessoryRefineLevelTarget,
        AccessoryRefineLevelItems,
        MasterRefineFragment1,
        MasterRefineFragment2,
        MasterRefineFragment3,
        MasterRefineStone,
        MasterRefineSpecial,
        AccessoryReset,
        WeaponCraftTemplate,
        WeaponCraftYellow,
        WeaponCraftBlue,
        WeaponCraftRed,
        WeaponCraftPurple,
        WeaponCraftGreen,
        WeaponCraftGrey,
        XiangKanGJST,
        XiangKanGJSTItems,
        XiangKanGJBST,
        XiangKanGJBSTItems,
        XiangKanZRST,
        XiangKanZRSTItems,
        XiangKanZRBST,
        XiangKanZRBSTItems,
        XiangKanLHST,
        XiangKanLHSTItems,
        XiangKanLHBST,
        XiangKanLHBSTItems,
        XiangKanSMST,
        XiangKanSMSTItems,
        XiangKanMFST,
        XiangKanMFSTItems,
        XiangKanSDST,
        XiangKanSDSTItems,
        XiangKanFYST,
        XiangKanFYSTItems,
        XiangKanMYST,
        XiangKanMYSTItems,
        GZLKaikong,
        GZLKaikongItems,
        GZLBKaikong,
        GZLBKaikongItems,
        QTKaikong,
        QTKaikongItems,
        Chaichust,
        Chaichustitems,
        Xiangkanjyst,
        Xiangkanjystitems,
        Xiangkanxxst,
        Xiangkanxxstitems,
        XiangKanghuo,
        XiangKanghuoitems,
        XiangKangbing,
        XiangKangbingitems,
        XiangKanglei,
        XiangKangleiitems,
        XiangKangfeng,
        XiangKangfengitems,
        XiangKangshen,
        XiangKangshenitems,
        XiangKangan,
        XiangKanganitems,
        XiangKanghuan,
        XiangKanghuanitems,
        XiangKanmofadun,
        XiangKanmofadunitems,
        XiangKanbingdong,
        XiangKanbingdongitems,
        XiangKanmabi,
        XiangKanmabiitems,
        XiangKanyidong,
        XiangKanyidongitems,
        XiangKanchenmo,
        XiangKanchenmoitems,
        XiangKangedang,
        XiangKangedangitems,
        XiangKanduobi,
        XiangKanduobiitems,
        XiangKanqhuo,
        XiangKanqhuoitems,
        XiangKanqbing,
        XiangKanqbingitems,
        XiangKanqlei,
        XiangKanqleiitems,
        XiangKanqfeng,
        XiangKanqfengitems,
        XiangKanqshen,
        XiangKanqshenitems,
        XiangKanqan,
        XiangKanqanitems,
        XiangKanqhuan,
        XiangKanqhuanitems,
        XiangKanlvdu,
        XiangKanlvduitems,
        XiangKanzym,
        XiangKanzymitems,
        XiangKanmhhf,
        XiangKanmhhfitems,
        PatchGrid,
        FishingEquipment,
        Jyhuishou,
        GuildContribution,
        hechengbaoshi,  
        Huanhua,   
        Huanhuaitems,  
        duihuanbaoshi,  
        XiangKanjinglian,  
        XiangKanjinglianitems,  
        CraftItem,
        CraftIngredients,
        BaoshiItems,
        Zhongzi,
        ZhongziItems,
        DunRefineUpgradeItems,
        DunRefineLevelTarget,
        DunRefineLevelItems,
        DunRefineUpgradeTarget,
        DunReset,
        HuiRefineUpgradeItems,
        HuiRefineLevelTarget,
        HuiRefineLevelItems,
        HuiRefineUpgradeTarget,
        HuiReset,
        Mingwen, 
        MingwenItems, 
        Xiaohui,  
    }

    public enum BuffType         
    {
        [Description("置空")] None = 0,

        [Description("服务器BUFF")] Server = 1,
        [Description("赏金BUFF")] HuntGold = 2,
        [Description("观察者BUFF")] Observable = 3,
        [Description("灰名BUFF")] Brown = 4,
        [Description("PKBUFF")] PKPoint = 5,
        [Description("PVPBUFF")] PvPCurse = 6,
        [Description("救赎BUFF")] Redemption = 7,
        [Description("宠物BUFF")] Companion = 8,
        [Description("沙巴克城主BUFF")] Castle = 9,
        [Description("时效道具属性BUFF")] ItemBuff = 10, 
        [Description("永久道具属性BUFF")] ItemBuffPermanent = 11, 
        [Description("排行版BUFF")] Ranking = 12, 
        [Description("管理员BUFF")] Developer = 13, 
        [Description("回归者BUFF")] Veteran = 14, 
        [Description("地图附加属性BUFF")] MapEffect = 15, 
        [Description("行会BUFF")] Guild = 16, 
        [Description("死亡药水BUFF")] DeathDrops = 17, 

        [Description("铁布衫BUFF")] Defiance = 100, 
        [Description("破血狂杀BUFF")] Might = 101, 
        [Description("金刚之躯BUFF")] Endurance = 102, 
        [Description("移花接木BUFF")] ReflectDamage = 103, 
        Invincibility = 104,

        [Description("凝血离魂BUFF")] Renounce = 200, 
        [Description("魔法盾BUFF")] MagicShield = 201, 
        [Description("天打雷劈BUFF")] JudgementOfHeaven = 202, 
        SuperiorMagicShield = 203,


        [Description("治愈术BUFF")] Heal = 300, 
        [Description("隐身术BUFF")] Invisibility = 301, 
        [Description("幽灵盾BUFF")] MagicResistance = 302, 
        [Description("神圣战甲术BUFF")] Resilience = 303, 
        [Description("强震魔法BUFF")] ElementalSuperiority = 304, 
        [Description("猛虎强势BUFF")] BloodLust = 305, 
        [Description("移花接玉BUFF")] StrengthOfFaith = 306, 
        [Description("阴阳法环BUFF")] CelestialLight = 307, 
        [Description("妙影无踪BUFF")] Transparency = 308, 
        [Description("吸星大法BUFF")] LifeSteal = 309, 
        Mana = 310,

        [Description("毒云BUFF")] PoisonousCloud = 400, 

        [Description("盛开BUFF")] FullBloom = 401, 
        [Description("白莲BUFF")] WhiteLotus = 402, 
        [Description("红莲BUFF")] RedLotus = 403, 
        [Description("潜行BUFF")] Cloak = 404, 
        [Description("鬼灵步BUFF")] GhostWalk = 405, 
        [Description("心击一转BUFF")] TheNewBeginning = 406, 
        [Description("黄泉旅者BUFF")] DarkConversion = 407, 
        [Description("狂涛涌泉BUFF")] DragonRepulse = 408, 
        [Description("风之闪避BUFF")] Evasion = 409, 
        [Description("风之守护BUFF")] RagingWind = 410, 
        [Description("护身冰环BUFF")] FrostBite = 411, 
        ElementalHurricane = 412,
        Concentration = 413,

        MagicWeakness = 500,
        Mapplayer = 501,
        Mapmonster = 502,
        Mapnpc = 503,
        Renshu = 504,    
        BossCount = 505,
        Exp = 506,
        GoldExp = 507,
        RWBuffyi = 509,
        RWBuffer = 510,
        RWBuffsan = 511,
        RWBuffsi = 512,
        RWBuffwu = 513,
        RWBuffliu = 514,
        RWBuffqi = 515,
        RWBuffba = 516,
        RWBuffjiu = 517,
        RWBuffshi = 518,
        MonCount = 519,   
        Youliang = 520,   
        Jingzhi = 521,    
        Chuanshuo = 522,  
        Shenhua = 523,    
        GuildLv = 524,    
        GuildJiacheng = 525,    
        GuildGongxian = 526,    
        GuildPaihang = 527,    
        VipMapYi = 528,   
        VipMapEr = 529,   
        VipMapSan = 530,  
        VipMapY = 531,   
        VipMapE = 532,   
        VipMapS = 533,  
        
        
        KongxiangYin = 534,
        
        LifeStealHeal = 535,
        MoveSpeed = 536,
        
        
        ChongzhuangYin = 537,
        
        
        MiaoyinYin = 538,
        
        
        HuoliMassHeal = 539,

    }

    public enum RequiredType : byte  
    {
        [Description("等级")] Level,
        [Description("最高等级")] MaxLevel,
        [Description("物理防御")] AC,
        [Description("魔法防御")] MR,
        [Description("破坏")] DC,
        [Description("自然")] MC,
        [Description("灵魂")] SC,
        [Description("生命值")] Health,
        [Description("魔法值")] Mana,
        [Description("准确")] Accuracy,
        [Description("敏捷")] Agility,
        [Description("宠物等级")] CompanionLevel,
        [Description("最高宠物等级")] MaxCompanionLevel,
        [Description("转生等级")] RebirthLevel,
        [Description("最高转生等级")] MaxRebirthLevel,
    }

    public enum Rarity : byte   
    {
        [Description("普通物品")]
        Common,
        [Description("高级物品")]
        Superior,
        [Description("稀世物品")]
        Elite,
    }

    public enum LightSetting : byte
    {
        [Description("默认")] Default,
        [Description("白天")] Light,
        [Description("夜晚")] Night,
        [Description("黄昏")] Twilight,
    }

    public enum WeatherSetting : byte
    {
        [Description("空")] None,
        [Description("默认")] Default,
        [Description("雾")] Fog,
        [Description("燃烧的雾")] BurningFog,
        [Description("小雪")] Snow, 
        [Description("花瓣雨")] Everfall,
        [Description("雨")] Rain,
        [Description("大雪")] Heavysnow,
    }

    public enum FightSetting : byte
    {
        [Description("普通")] None,
        [Description("安全")] Safe,
        [Description("战斗")] Fight,
        [Description("战斗")] Event,
    }

    public enum ObjectType : byte
    {
        [Description("无")] None,
        [Description("玩家")] Player,
        [Description("道具")] Item,
        [Description("NPC")] NPC,
        [Description("物体施法对象")] Spell,
        [Description("怪物")] Monster,
    }

    public enum ItemType : byte  
    {
        [Description("无")]
        Nothing,
        [Description("消耗品")]
        Consumable,
        [Description("武器")]
        Weapon,
        [Description("衣服")]
        Armour,
        [Description("火把")]
        Torch,
        [Description("头盔")]
        Helmet,
        [Description("项链")]
        Necklace,
        [Description("手镯")]
        Bracelet,
        [Description("戒指")]
        Ring,
        [Description("鞋子")]
        Shoes,
        [Description("毒药")]
        Poison,
        [Description("护身符")]
        Amulet,
        [Description("肉")]
        Meat,
        [Description("矿石")]
        Ore,
        [Description("书籍")]
        Book,
        [Description("卷轴")]
        Scroll,
        [Description("元素石")]
        DarkStone,
        [Description("特殊精炼")]
        RefineSpecial,
        [Description("马甲")]
        HorseArmour,
        [Description("鲜花")]
        Flower,
        [Description("宠物粮食")]
        CompanionFood,
        [Description("宠物背包")]
        CompanionBag,
        [Description("宠物头盔")]
        CompanionHead,
        [Description("宠物背带")]
        CompanionBack,
        [Description("系统")]
        System,
        [Description("物品碎片")]
        ItemPart,
        [Description("徽章")]
        Emblem,
        [Description("盾牌")]
        Shield,
        [Description("宝石")]
        Baoshi,
        [Description("声望称号")]
        SwChenghao,
        [Description("时装")]
        Shizhuang,
        [Description("法宝")]
        Fabao,
    }

    public enum MirAction : byte
    {
        /*
        Standing,
        Moving,
        Pushed,
        Attack,
        RangeAttack,
        Spell,
        Harvest,
        
        Die,
        Dead,
        Show,
        Hide,
        Mount,
        Mining,
        */
        [Description("站立")] Standing,
        [Description("移动")] Moving,
        [Description("推")] Pushed,
        [Description("攻击")] Attack,
        [Description("范围攻击")] RangeAttack,
        [Description("技能")] Spell,
        [Description("收割")] Harvest,
        
        [Description("死亡消失过程")] Die,
        [Description("死亡地面尸体")] Dead,
        [Description("出现")] Show,
        [Description("消失")] Hide,
        [Description("坐骑")] Mount,
        [Description("挖矿")] Mining,

    }

    public enum MirAnimation : byte
    {
        /*
        Standing,
        Walking,
        CreepStanding,
        CreepWalkSlow,
        CreepWalkFast,
        Running,
        Pushed,
        Combat1,
        Combat2,
        Combat3,
        Combat4,
        Combat5,
        Combat6,
        Combat7,
        Combat8,
        Combat9,
        Combat10,
        Combat11,
        Combat12,
        Combat13,
        Combat14,
        Combat15,
        Harvest,
        Stance,
        Struck,
        Die,
        Dead,
        Skeleton,
        Show,
        Hide,
        HorseStanding,
        HorseWalking,
        HorseRunning,
        HorseStruck,
        StoneStanding,
        DragonRepulseStart,
        DragonRepulseMiddle,
        DragonRepulseEnd,
        ChannellingStart,
        ChannellingMiddle,
        ChannellingEnd,
        */
        [Description("站立")] Standing,
        [Description("行走")] Walking,
        [Description("缓慢站立")] CreepStanding,
        [Description("缓慢走")] CreepWalkSlow,
        [Description("缓慢走变快")] CreepWalkFast,
        [Description("跑")] Running,
        [Description("推")] Pushed,
        [Description("双手攻击")] Combat1,
        [Description("人物动作2")] Combat2,
        [Description("人物动作3")] Combat3,
        [Description("人物动作4")] Combat4,
        [Description("人物动作5")] Combat5,
        [Description("人物动作6")] Combat6,
        [Description("人物动作7")] Combat7,
        [Description("人物动作8")] Combat8,
        [Description("人物动作9")] Combat9,
        [Description("人物动作10")] Combat10,
        [Description("人物动作11")] Combat11,
        [Description("人物动作12")] Combat12,
        [Description("人物动作13")] Combat13,
        [Description("人物动作14")] Combat14,
        [Description("人物动作15")] Combat15,
        [Description("收割")] Harvest,
        [Description("站立姿势")] Stance,
        [Description("被击中")] Struck,
        [Description("死亡消失过程")] Die,
        [Description("死亡地面尸体")] Dead,
        [Description("其他类死亡")] Skeleton,
        [Description("出现")] Show,
        [Description("消失")] Hide,
        [Description("骑马站立")] HorseStanding,
        [Description("骑马行走")] HorseWalking,
        [Description("骑马跑")] HorseRunning,
        [Description("骑马撞")] HorseStruck,
        [Description("石化")] StoneStanding,
        [Description("狂涛泉涌开始")] DragonRepulseStart,
        [Description("狂涛泉涌过程")] DragonRepulseMiddle,
        [Description("狂涛泉涌结束")] DragonRepulseEnd,
        [Description("咒语开始")] ChannellingStart,
        [Description("咒语过程")] ChannellingMiddle,
        [Description("咒语结束")] ChannellingEnd,

    }


    public enum MessageAction
    {
        None,
        Revive,
    }

    public enum MessageType
    {
        Normal,
        Shout,
        WhisperIn,
        GMWhisperIn,
        WhisperOut,
        Group,
        Global,
        Hint,
        System,
        Announcement,
        Combat,
        ObserverChat,
        Guild,
        Notice,
        Union,
        Mentor,
        ItemTips,
        BossTips,
    }

    public enum NPCDialogType
    {
        None,
        BuySell,
        Repair,
        Refine,
        RefineRetrieve,
        CompanionManage,
        WeddingRing,
        RefinementStone,
        MasterRefine,
        WeaponReset,
        ItemFragment,
        AccessoryRefineUpgrade,
        AccessoryRefineLevel,
        AccessoryReset,
        WeaponCraft,
        XiangKanGJST,
        XiangKanGJBST,
        XiangKanZRST,
        XiangKanZRBST,
        XiangKanLHST,
        XiangKanLHBST,
        XiangKanSMST,
        XiangKanMFST,
        XiangKanSDST,
        XiangKanFYST,
        XiangKanMYST,
        GZLKaikong,
        GZLBKaikong,
        QTKaikong,
        Chaichust,
        Xiangkanjyst,
        Xiangkanxxst,
        XiangKanghuo,
        XiangKangbing,
        XiangKanglei,
        XiangKangfeng,
        XiangKangshen,
        XiangKangan,
        XiangKanghuan,
        XiangKanmofadun,
        XiangKanbingdong,
        XiangKanmabi,
        XiangKanyidong,
        XiangKanchenmo,
        XiangKangedang,
        XiangKanduobi,
        XiangKanqhuo,
        XiangKanqbing,
        XiangKanqlei,
        XiangKanqfeng,
        XiangKanqshen,
        XiangKanqan,
        XiangKanqhuan,
        XiangKanlvdu,
        XiangKanzym,
        XiangKanmhhf,
        JyhuishouBox,
        NPCGuildhuishouBox,
        NPChechengbaoshi,
        Huanhua,  
        BuyBaoshi, 
        NPCduihuanbaoshi, 
        XiangKanjinglian, 
        ZaixianItemFragment,  
        Zhongzi,  
        BuyGSell, 
        BuyYSell, 
        ShenmiShangren, 
        DunRefineUpgrade, 
        DunRefineLevel,
        DunReset,
        HuiRefineUpgrade,
        HuiRefineLevel,
        HuiReset,
        Mingwen, 
        HorseManage,
        FubenBiBuy,
        CDkey01, 
        CDkey02, 
        CDkey03, 
        Xiaohui,  
        MingwenChuancheng, 
    }

    public enum MagicSchool   
    {
        /*
        None,         
        Passive,      
        WeaponSkills, 
        Neutral,      
        Fire,         
        Ice,          
        Lightning,    
        Wind,         
        Holy,         
        Dark,         
        Phantom,      
        Combat,       
        Assassination, 
        */

        [Description("空置")] None,
        [Description("被动")] Passive,
        [Description("武技")] WeaponSkills,
        [Description("转换")] Neutral,
        [Description("火(火焰)")] Fire,
        [Description("冰(冰寒)")] Ice,
        [Description("雷(电击)")] Lightning,
        [Description("风(风)")] Wind,
        [Description("神圣(神圣)")] Holy,
        [Description("暗黑(暗黑)")] Dark,
        [Description("幻影(幻影)")] Phantom,
        [Description("刺杀")] Assassination,
        [Description("暗杀")] Assassinatie,
        [Description("无条件")] Unconditional,
        [Description("格斗")] Combat,

    }
    public enum Passive   
    {

        [Description("主动性")]
        Zhudong,
        [Description("被动型")]
        Beidong,
    }
    public enum FubenSchool
    {
        [Description("普通")]
        Common,
        [Description("地狱")]
        Hell,
        [Description("剧情")]
        Juqing,
        [Description("挑战")]
        Tiaozhan,
    }


    public enum Element : byte   
    {
        [Description("无")] None,
        [Description("火(火焰)")] Fire,
        [Description("冰(冰寒)")] Ice,
        [Description("雷(电击)")] Lightning,
        [Description("风(风)")] Wind,
        [Description("圣(神圣)")] Holy,
        [Description("暗黑(暗黑)")] Dark,
        [Description("幻影(幻影)")] Phantom,
    }

    public enum MagicType   
    {
        None,

        Swordsmanship = 100,
        PotionMastery = 101,
        Slaying = 102,
        Thrusting = 103,
        HalfMoon = 104,
        ShoulderDash = 105,
        FlamingSword = 106,
        DragonRise = 107,
        BladeStorm = 108,
        DestructiveSurge = 109,
        Interchange = 110,
        Defiance = 111,
        Beckon = 112,
        Might = 113,
        SwiftBlade = 114,
        Assault = 115,
        Endurance = 116,
        ReflectDamage = 117,
        Fetter = 118,
        SwirlingBlade = 119,
        ReigningStep = 120,
        MaelstromBlade = 121,
        AdvancedPotionMastery = 122,
        MassBeckon = 123,
        SeismicSlam = 124,
        Invincibility = 125,
        CrushingWave = 126,

        FireBall = 201,
        LightningBall = 202,
        IceBolt = 203,
        GustBlast = 204,
        Repulsion = 205,
        ElectricShock = 206,
        Teleportation = 207,
        AdamantineFireBall = 208,
        ThunderBolt = 209,
        IceBlades = 210,
        Cyclone = 211,
        ScortchedEarth = 212,
        LightningBeam = 213,
        FrozenEarth = 214,
        BlowEarth = 215,
        FireWall = 216,
        ExpelUndead = 217,
        GeoManipulation = 218,
        MagicShield = 219,
        FireStorm = 220,
        LightningWave = 221,
        IceStorm = 222,
        DragonTornado = 223,
        GreaterFrozenEarth = 224,
        ChainLightning = 225,
        MeteorShower = 226,
        Renounce = 227,
        Tempest = 228,
        JudgementOfHeaven = 229,
        ThunderStrike = 230,
        RayOfLight = 231,
        BurstOfEnergy = 232,
        ShieldOfPreservation = 233,
        RetrogressionOfEnergy = 234,
        FuryBlast = 235,
        TempestOfUnstableEnergy = 236,
        MirrorImage = 237,
        AdvancedRenounce = 238,
        FrostBite = 239,
        Asteroid = 240,
        ElementalHurricane = 241,
        SuperiorMagicShield = 242,

        Heal = 300,
        SpiritSword = 301,
        PoisonDust = 302,
        ExplosiveTalisman = 303,
        EvilSlayer = 304,
        Invisibility = 305,
        MagicResistance = 306,
        MassInvisibility = 307,
        GreaterEvilSlayer = 308,
        Resilience = 309,
        TrapOctagon = 310,
        TaoistCombatKick = 311,
        ElementalSuperiority = 312,
        MassHeal = 313,
        BloodLust = 314,
        Resurrection = 315,
        Purification = 316,
        Transparency = 317,
        CelestialLight = 318,
        EmpoweredHealing = 319,
        LifeSteal = 320,
        ImprovedExplosiveTalisman = 321,
        GreaterPoisonDust = 322,
        Scarecrow = 323,
        ThunderKick = 324,
        DragonBreath = 325,
        MassTransparency = 326,
        GreaterHolyStrike = 327,
        AugmentExplosiveTalisman = 328,
        AugmentEvilSlayer = 329,
        AugmentPurification = 330,
        OathOfThePerished = 331,
        SummonSkeleton = 332,
        SummonShinsu = 333,
        SummonJinSkeleton = 334,
        StrengthOfFaith = 335,
        SummonDemonicCreature = 336,
        DemonExplosion = 337,
        Infection = 338,
        DemonicRecovery = 339,
        Neutralize = 340,
        AugmentNeutralize = 341,
        DarkSoulPrison = 342,
        AugmentImprovedExplosiveTalisman = 343,
        CrazyImprovedExplosiveTalisman = 344,

        WillowDance = 401,
        VineTreeDance = 402,
        Discipline = 403,
        PoisonousCloud = 404,
        FullBloom = 405,
        Cloak = 406,
        WhiteLotus = 407,
        CalamityOfFullMoon = 408,
        WraithGrip = 409,
        RedLotus = 410,
        HellFire = 411,
        PledgeOfBlood = 412,
        Rake = 413,
        SweetBrier = 414,
        SummonPuppet = 415,
        Karma = 416,
        TouchOfTheDeparted = 417,
        WaningMoon = 418,
        GhostWalk = 419,
        ElementalPuppet = 420,
        Rejuvenation = 421,
        Resolution = 422,
        ChangeOfSeasons = 423,
        Release = 424,
        FlameSplash = 425,
        BloodyFlower = 426,
        TheNewBeginning = 427,
        DanceOfSwallow = 428,
        DarkConversion = 429,
        DragonRepulse = 430,
        AdventOfDemon = 431,
        AdventOfDevil = 432,
        Abyss = 433,
        FlashOfLight = 434,
        Stealth = 435,
        Evasion = 436,
        RagingWind = 437,
        AdvancedBloodyFlower = 438,
        Massacre = 439,
        ArtOfShadows = 440,
        Concentration = 441,
        SwordOfVengeance = 442,

        MonsterScortchedEarth = 501,
        MonsterIceStorm = 502,
        MonsterDeathCloud = 503,
        MonsterThunderStorm = 504,

        SamaGuardianFire = 505,
        SamaGuardianIce = 506,
        SamaGuardianLightning = 507,
        SamaGuardianWind = 508,

        SamaPhoenixFire = 509,
        SamaBlackIce = 510,
        SamaBlueLightning = 511,
        SamaWhiteWind = 512,

        SamaProphetFire = 513,
        SamaProphetLightning = 514,
        SamaProphetWind = 515,

        DoomClawLeftPinch = 520,
        DoomClawLeftSwipe = 521,
        DoomClawRightPinch = 522,
        DoomClawRightSwipe = 523,
        DoomClawWave = 524,
        DoomClawSpit = 525,

        PinkFireBall = 530,
        GreenSludgeBall = 540,

        HellBringerBats = 550,
        PoisonousGolemLineAoE = 551,
        IgyuScorchedEarth = 552,
        IgyuCyclone = 553,

        Wolongbianfuhuojineng = 554,  

        
        
        XueshaSlaying = 600, 

        
        
        GuanyueHalfMoon = 601,

        
        
        JiyueHalfMoon = 602,
        
        
        ShenquDragonRise = 603,
        
        
        ShenglongDragonRise = 604,

        
        
        ZhanchuiSeismicSlam = 605,
        
        
        TianshenSeismicSlam = 606,
    }

    public enum MonsterImage  
    {
        [Description("置空")] None,
        [Description("Mon3-6 卫士")] Guard,
        [Description("Mon3-0 鸡")] Chicken,
        [Description("Mon12-9 猪")] Pig,
        [Description("Mon3-1 鹿")] Deer,
        [Description("Mon13-1 牛")] Cow,
        [Description("Mon6-8 羊")] Sheep,
        [Description("Mon4-8 多钩猫")] ClawCat,
        [Description("Mon7-5 狼")] Wolf,
        [Description("Mon4-0 森林雪人")] ForestYeti,
        [Description("Mon13-7 栗子树")] ChestnutTree,
        [Description("Mon4-1 食人花")] CarnivorousPlant,
        [Description("Mon3-3 半兽战士")] Oma,
        [Description("Mon6-7 虎蛇")] TigerSnake,
        [Description("Mon3-5 毒蜘蛛")] SpittingSpider,
        [Description("Mon5-0 稻草人")] Scarecrow,
        [Description("Mon3-4 半兽勇士")] OmaHero,
        [Description("Mon3-9 山洞蝙蝠")] CaveBat,
        [Description("Mon3-8 蝎子")] Scorpion,
        [Description("Mon4-2 骷髅")] Skeleton,
        [Description("Mon4-4 骷髅战士")] SkeletonAxeMan,
        [Description("Mon4-3 掷斧骷髅")] SkeletonAxeThrower,
        [Description("Mon4-5 骷髅战将")] SkeletonWarrior,
        [Description("Mon4-6 骷髅精灵")] SkeletonLord,
        [Description("Mon4-7 洞蛆")] CaveMaggot,
        [Description("Mon5-8 老道僵尸")] GhostSorcerer,
        [Description("Mon5-9 法鬼")] GhostMage,
        [Description("Mon6-0 牛鬼")] VoraciousGhost,
        [Description("Mon6-1 食鬼")] DevouringGhost,
        [Description("Mon6-2 尸鬼")] CorpseRaisingGhost,
        [Description("Mon6-3 尸王")] GhoulChampion,
        [Description("Mon1-8 盔甲蚂蚁")] ArmoredAnt,
        [Description("Mon2-4 蚂蚁战士")] AntSoldier,
        [Description("Mon1-7 蚂蚁道士")] AntHealer,
        [Description("Mon10-6 爆毒蚂蚁")] AntNeedler,
        [Description("Mon7-0 盔甲虫")] ShellNipper,
        [Description("Mon7-3 多角虫")] Beetle,
        [Description("Mon7-1 威思尔小虫")] VisceralWorm,
        [Description("Mon15-5 多脚虫")] MutantFlea,
        [Description("Mon15-9 蜘蛛蛙")] PoisonousMutantFlea,
        [Description("Mon15-7 胞眼虫")] BlasterMutantFlea,
        [Description("Mon8-1 跳跳蜂")] WasHatchling,
        [Description("Mon7-6 蜈蚣")] Centipede,
        [Description("Mon8-2 蝴蝶虫")] ButterflyWorm,
        [Description("Mon7-8 黑色恶蛆")] MutantMaggot,
        [Description("Mon7-9 钳虫")] Earwig,
        [Description("Mon8-0 邪恶钳虫")] IronLance,
        [Description("Mon7-7 触龙神")] LordNiJae,
        [Description("Mon14-8 浪子人鬼")] RottingGhoul,
        [Description("Mon14-2 腐蚀人鬼")] DecayingGhoul,
        [Description("Mon5-2 吸血鬼")] BloodThirstyGhoul,
        [Description("Mon5-6 暗黑战士")] SpinedDarkLizard,
        [Description("Mon5-1 沃玛战士")] UmaInfidel,
        [Description("Mon5-3 火焰沃玛")] UmaFlameThrower,
        [Description("Mon5-4 沃玛卫士")] UmaAnguisher,
        [Description("Mon5-5 沃玛教主")] UmaKing,
        [Description("Mon11-1 月魔蜘蛛")] SpiderBat,
        [Description("Mon11-6 幻影蜘蛛")] ArachnidGazer,
        [Description("Mon11-5 爆裂蜘蛛")] Larva,
        [Description("Mon11-7 血巨人")] RedMoonGuardian,
        [Description("Mon11-8 血金刚")] RedMoonProtector,
        [Description("Mon12-1 花色蜘蛛")] VenomousArachnid,
        [Description("Mon12-2黑角蜘蛛")] DarkArachnid,
        [Description("Mon11-4 赤月恶魔")] RedMoonTheFallen,
        [Description("Mon9-2 祖玛弓箭手")] ZumaSharpShooter,
        [Description("Mon9-3 祖玛雕像")] ZumaFanatic,
        [Description("Mon9-4 祖玛卫士")] ZumaGuardian,
        [Description("Mon9-1 大老鼠")] ViciousRat,
        [Description("Mon9-5 祖玛教主")] ZumaKing,
        [Description("Mon16-7 东魔神怪")] EvilFanatic,
        [Description("Mon16-4 猿猴战士")] Monkey,
        [Description("Mon16-8 巨象兽")] EvilElephant,
        [Description("Mon16-6 西魔神怪")] CannibalFanatic,
        [Description("Mon7-4 巨型多角虫")] SpikedBeetle,
        [Description("Mon13-8 诺玛")] NumaGrunt,
        [Description("Mon2-3 诺玛法老")] NumaMage,
        [Description("Mon2-7 诺玛将士")] NumaElite,
        [Description("Mon10-4 沙漠鱼魔")] SandShark,
        [Description("Mon1-4 沙漠石人")] StoneGolem,
        [Description("Mon10-7 沙漠风魔")] WindfurySorceress,
        [Description("Mon10-7 沙漠树魔")] CursedCactus,
        [Description("Mon1-5 异界之门")] NetherWorldGate,
        [Description("Mon20-1 变异迅猛蜥")] RagingLizard,
        [Description("Mon20-2 变异刺骨蜥")] SawToothLizard,
        [Description("Mon20-3 变异丑蜥")] MutantLizard,
        [Description("Mon20-4 变异毒蜥")] VenomSpitter,
        [Description("Mon20-5 魔石咆哮者")] SonicLizard,
        [Description("Mon20-6 魔石狂热者")] GiantLizard,
        [Description("Mon20-9 变异利爪蜥")] CrazedLizard,
        [Description("Mon20-7 魔石守护神")] TaintedTerror,
        [Description("Mon20-8 地天灭王")] DeathLordJichon,
        [Description("Mon14-7 潘夜战士")] Minotaur,
        [Description("Mon14-3 潘夜冰魔")] FrostMinotaur,
        [Description("Mon14-4 潘夜云魔")] ShockMinotaur,
        [Description("Mon14-6 潘夜火魔")] FlameMinotaur,
        [Description("Mon14-5 潘夜风魔")] FuryMinotaur,
        [Description("Mon14-1 潘夜左护卫")] BanyaLeftGuard,
        [Description("Mon14-0 潘夜右护卫")] BanyaRightGuard,
        [Description("Mon14-9 潘夜牛魔王")] EmperorSaWoo,
        [Description("Mon15-4 骷髅弓箭手")] BoneArcher,
        [Description("Mon15-3 骷髅武士")] BoneBladesman,
        [Description("Mon15-0 骷髅武将")] BoneCaptain,
        [Description("Mon15-2 骷髅士兵")] BoneSoldier,
        [Description("Mon15-1 骷髅教主")] ArchLichTaedu,
        [Description("Mon8-3 角蝇")] WedgeMothLarva,
        [Description("Mon8-4 蝙蝠")] LesserWedgeMoth,
        [Description("Mon8-5 楔蛾")] WedgeMoth,
        [Description("Mon8-6 红野猪")] RedBoar,
        [Description("Mon8-9 蝎蛇")] ClawSerpent,
        [Description("Mon8-7 黑野猪")] BlackBoar,
        [Description("Mon8-8 白野猪")] TuskLord,
        [Description("Mon16-0 超级黑猪王")] RazorTusk,
        [Description("Mon17-2 黑度紫红女神")] PinkGoddess,
        [Description("Mon17-3 黑度绿荫女神")] GreenGoddess,
        [Description("Mon17-1 武力魔神将")] MutantCaptain,
        [Description("Mon17-0 石像狮子")] StoneGriffin,
        [Description("Mon16-9 火焰狮子")] FlameGriffin,
        [Description("Mon6-6 变异骷髅")] WhiteBone,
        [Description("Mon10-0 神兽")] Shinsu,
        [Description("Mon26-2 炎魔")] InfernalSoldier,
        [Description("镜像")] InfernalGuardian,
        [Description("地狱战士")] InfernalWarrior,
        [Description("Mon2-2 犬猴魔")] CorpseStalker,
        [Description("Mon1-6 轻甲守卫")] LightArmedSoldier,
        [Description("Mon10-3 爆毒神魔")] CorrosivePoisonSpitter,
        [Description("Mon10-9 神舰守卫")] PhantomSoldier,
        [Description("Mon1-2 触角神魔")] MutatedOctopus,
        [Description("Mon10-2 恶形鬼")] AquaLizard,
        [Description("Mon1-9 海神将领")] Stomper,
        [Description("Mon2-9 红衣法师")] CrimsonNecromancer,
        [Description("Mon2-0 霸王守卫")] ChaosKnight,
        [Description("Mon13-0 霸王教主")] PachonTheChaosBringer,
        [Description("Mon19-0 诺玛骑兵")] NumaCavalry,
        [Description("Mon19-4 诺玛司令")] NumaHighMage,
        [Description("Mon19-3 诺玛抛石兵")] NumaStoneThrower,
        [Description("Mon19-5 诺玛斧兵")] NumaRoyalGuard,
        [Description("Mon19-1 诺玛装甲兵")] NumaArmoredSoldier,
        [Description("Mon21-0 冰魂弓箭手")] IcyRanger,
        [Description("Mon18-0 魄冰女神")] IcyGoddess,
        [Description("Mon21-2 冰魂鬼武士")] IcySpiritWarrior,
        [Description("Mon21-3 冰魂鬼武将")] IcySpiritGeneral,
        [Description("Mon21-4 幽灵骑士")] GhostKnight,
        [Description("Mon21-6 冰魂鬼卒")] IcySpiritSpearman,
        [Description("Mon21-7 狼人")] Werewolf,
        [Description("Mon21-8 雪狼")] Whitefang,
        [Description("Mon21-9 冰魂卫士")] IcySpiritSolider,
        [Description("Mon18-1 野猪")] WildBoar,
        [Description("Mon23-9 赤龙石门")] JinamStoneGate,
        [Description("Mon21-5 火影")] FrostLordHwa,
        [Description("Mon34-0 宠物小花猪")] Companion_Pig,
        [Description("Mon34-1 宠物可爱的白猪")] Companion_TuskLord,
        [Description("Mon34-2 宠物小骷髅战士")] Companion_SkeletonLord,
        [Description("Mon34-3 宠物幼狮")] Companion_Griffin,
        [Description("Mon34-4 宠物小银龙")] Companion_Dragon,
        [Description("Mon34-5 宠物毛驴")] Companion_Donkey,
        [Description("Mon34-6 宠物山羊")] Companion_Sheep,
        [Description("Mon34-7 宠物霸主")] Companion_BanyoLordGuzak,
        [Description("Mon34-8 宠物熊猫酒仙")] Companion_Panda,
        [Description("Mon34-9 宠物韩版兔子")] Companion_Rabbit,
        [Description("Mon17-4 震天魔神")] JinchonDevil,
        [Description("Mon3-7 半兽首将")] OmaWarlord,
        [Description("Mon22-0 卫护将首")] EscortCommander,
        [Description("Mon22-2 红衣舞姬")] FieryDancer,
        [Description("Mon22-3 绿衣舞姬")] EmeraldDancer,
        [Description("Mon22-1 黎明女王")] QueenOfDawn,
        [Description("Mon23-3 雾影魔卒")] OYoungBeast,
        [Description("Mon23-6 阎昆魔女")] YumgonWitch,
        [Description("Mon23-4 魔大将")] MaWarlord,
        [Description("Mon23-7 真幻鬼")] JinhwanSpirit,
        [Description("Mon23-8 真幻鬼婢")] JinhwanGuardian,
        [Description("Mon23-5 阎昆魔军")] YumgonGeneral,
        [Description("Mon23-0 蚩尤将军")] ChiwooGeneral,
        [Description("Mon23-2 赤龙女王")] DragonQueen,
        [Description("Mon23-1 赤龙魔王")] DragonLord,
        [Description("Mon21-1 冰湖白魔兽")] FerociousIceTiger,
        [Description("Mon25-0 火系士兵")] SamaFireGuardian,
        [Description("Mon25-1 冰系士兵")] SamaIceGuardian,
        [Description("Mon25-2 雷系士兵")] SamaLightningGuardian,
        [Description("Mon25-3 风系士兵")] SamaWindGuardian,
        [Description("Mon25-4 朱雀天王")] Phoenix,
        [Description("Mon25-5 玄武天王")] BlackTortoise,
        [Description("Mon25-6 青龙天王")] BlueDragon,
        [Description("Mon25-7 白虎天王")] WhiteTiger,
        [Description("Mon27-0 剑客神徒")] SamaCursedBladesman,
        [Description("Mon27-1 法术神徒")] SamaCursedSlave,
        [Description("Mon27-2 烈火神徒")] SamaCursedFlameMage,
        [Description("Mon27-3 魔灵神主")] SamaProphet,
        [Description("Mon27-4 魔法师")] SamaSorcerer,
        [Description("Mon27-5 封印盒")] EnshrinementBox,
        [Description("Mon19-7 灵石")] BloodStone,
        [Description("Mon35-0 纯虎")] OrangeTiger,
        [Description("Mon35-1 黄虎")] RegularTiger,
        [Description("Mon35-2 褐虎")] RedTiger,
        [Description("Mon35-3 雪虎")] SnowTiger,
        [Description("Mon35-4 黑虎")] BlackTiger,
        [Description("Mon35-5 黑翼虎")] BigBlackTiger,
        [Description("Mon35-6 白翼虎")] BigWhiteTiger,
        [Description("Mon35-7 虎将军")] OrangeBossTiger,
        [Description("Mon35-8 虎老板")] BigBossTiger,
        [Description("Mon30-0 暴戾猿猴战士")] WildMonkey,
        [Description("Mon30-1 霜冻雪人")] FrostYeti,
        [Description("Mon9-0 邪恶毒蛇")] EvilSnake,
        [Description("Mon28-0沙漠蜥蜴")] Salamander,
        [Description("Mon28-1 沙鬼")] SandGolem,
        [Description("Mon29-0")] SDMob4,
        [Description("Mon29-1")] SDMob5,
        [Description("Mon29-2")] SDMob6,
        [Description("Mon29-8 半兽武士")] SDMob7,
        [Description("半兽法师")] OmaMage,
        [Description("Mon32-1")] SDMob9,
        [Description("Mon32-5")] SDMob10,
        [Description("Mon32-6")] SDMob11,
        [Description("Mon32-7")] SDMob12,
        [Description("Mon32-8")] SDMob13,
        [Description("Mon32-9")] SDMob14,
        [Description("Mon40-0 水晶傀儡")] CrystalGolem,
        [Description("Mon41-1 尘土恶魔")] DustDevil,
        [Description("Mon41-2 双尾蝎子")] TwinTailScorpion,
        [Description("Mon41-3 嗜血鼹")] BloodyMole,
        [Description("Mon44-3 异魔族战士")] SDMob19,
        [Description("Mon44-4 异魔族兵卒")] SDMob20,
        [Description("Mon44-5 异魔族弓手")] SDMob21,
        [Description("Mon44-6 异魔族骤术师")] SDMob22,
        [Description("Mon44-7 异魔族百夫长")] SDMob23,
        [Description("Mon44-8 灰饕餮")] SDMob24,
        [Description("Mon44-9 绿饕餮")] SDMob25,
        [Description("Mon28-8 独眼蜘蛛")] GangSpider,
        [Description("Mon28-9 天狼蜘蛛")] VenomSpider,
        [Description("Mon45-0 异魔族族长")] SDMob26,
        [Description("Mon45-3 龙虾王")] LobsterLord,
        [Description("龙虾脚")] LobsterSpawn,
        [Description("Mon47-0 水晶火虫")] NewMob1,
        [Description("Mon47-1 水晶蠕虫")] NewMob2,
        [Description("Mon47-2 水晶蝙蝠")] NewMob3,
        [Description("Mon47-3 水晶魔像")] NewMob4,
        [Description("Mon47-4 水晶金魔像")] NewMob5,
        [Description("Mon47-5 水晶长枪狂徒")] NewMob6,
        [Description("Mon47-6 水晶魔法狂徒")] NewMob7,
        [Description("Mon47-7 水晶玄武")] NewMob8,
        [Description("Mon47-8 水晶小玄武")] NewMob9,
        [Description("Mon47-9 水晶守护树")] NewMob10,
        [Description("Mon49-0 小僵尸")] MonasteryMon0,
        [Description("Mon49-1 僵尸")] MonasteryMon1,
        [Description("Mon49-2 怨魂僵尸")] MonasteryMon2,
        [Description("Mon49-3 血灵僵尸")] MonasteryMon3,
        [Description("Mon49-4 魔道道士")] MonasteryMon4,
        [Description("Mon49-5 魔气僵尸魔道")] MonasteryMon5,
        [Description("Mon49-6 魔气大僵尸")] MonasteryMon6,
        Yue1,
        Yue2,
        Yue3,
        Yue4,
        Yue5,
        Yue6,
        YuexiaoBoss,
        YueBoss,
        Wl1,
        Wl2,
        WolongBianfu01,
        WolongBianfu02,
        Wl5,
        Wl6,
        Wlzz,
        Wlwz,
        Wlbw,
        BmBz,
        Bm1,
        Bm2,
        Bm3,
        Bm4,
        Hd1,
        Hd2,
        Hd3,
        Hd4,
        Hd5,
        Hd6,
        HdxiaoBoss,
        HdBoss,
        yaotaStoneGate,
        MotaStoneGate,
        Huodong01StoneGate,
        Huodong02StoneGate,
        Huodong03StoneGate,
        Huodong04StoneGate,
        Huodong05StoneGate,
        Huodong06StoneGate,
        Huodong07StoneGate,
        Huodong08StoneGate,
        Huodong09StoneGate,
        Huodong10StoneGate,
        Huodong11StoneGate,
        Huodong12StoneGate,

        GardenSoldier,  
        GardenDefender,
        RedBlossom,
        BlueBlossom,
        FireBird,
        TYsiweihonggui,
        TYsiweilangui,
        TYhua,
        TYlanfenghuang,
        Zhenyanmo,
        GuildBoss01,  
        GuildFbBoss,  
        Taishan01,
        Taishan02,
        Taishan03,
        Taishan04,
        Taishan05,
        Taishan06,
        Taishan07,
        Benma01,
        Benma02,
        Benma03,
        Qinling01,
        Qinling02,
        Qinling03,
        Qinling04,
        Qinling05,
        Qinling06,
        Qinling07,
        Qinling08,
        Qinling09,
        Qinling10,
        Companion_Snow,
        CrazedPrimate,
        HellBringer,
        YurinMon0,
        YurinMon1,
        WhiteBeardedTiger,
        BlackBeardedTiger,
        HardenedRhino,
        Mammoth,
        CursedSlave1,
        CursedSlave2,
        CursedSlave3,
        PoisonousGolem,
        Huanjingsamll,
        
        [Description("自定义")] Custom,
        HdBoss2,
        [Description("Mon76-3 君王")] Junwang,
        [Description("Mon77-4 偷天")] Toutian,
        [Description("Mon78-2 迦兰")] Jialan,
        [Description("Mon68-1 灵兽")] LingShou,
        [Description("Mon70-1 血兽")] XueShou,
        [Description("Mon72-1 圣兽")] ShengShou,
        Horse_Brown,
        Horse_White,
        Horse_Red,
        Horse_Black,
        Horse_Dark,
        Horse_WhiteUni,
        Horse_RedUni,
        Horse_Blue,
        Horse_ArmBrown,
        Horse_ArmWhite,
        Horse_ArmRed,
        Horse_ArmBlack,
        Horse_SnowLion,
        Horse_Lion,
        [Description("Mon56-3 远古尸王")] FubenShiwang,
        [Description("Mon58-0 密林教主")] OmaKing,
        [Description("Mon59-1 小攻乌龟")] XGongWugui,
        [Description("Mon60-1 小魔乌龟")] MoWugui,
        [Description("Mon61-1 大攻乌龟")] DGongWugui,
        [Description("Mon62-1 地狱杀手")] HellSlasher,
        [Description("Mon63-1 地狱海盗")] HellPirate,
        [Description("Mon64-1 食人魔")] HellCannibal,
        [Description("Mon65-1 地狱守护者")] HellKeeper,
        [Description("Mon66-1 地狱螺栓")] HellBolt,
        [Description("Mon67-1 巫医")] WitchDoctor,
        [Description("Mon75-8 红月炎魔")] Hongyue,
        [Description("Mon74-0 火焰炎魔")] Huoyan,

    }

    public enum MonsterRarity : byte   
    {
        [Description("普通怪物")]
        Common,
        [Description("高级怪物")]
        Superior,
        [Description("稀世怪物")]
        Elite,
    }

    public enum MapIcon
    {
        [Description("空置")] None,
        [Description("洞穴")] Cave,
        [Description("出口")] Exit,
        [Description("进下层")] Down,
        [Description("回上层")] Up,
        [Description("省份")] Province,
        [Description("建筑")] Building,
        [Description("入口550小骷髅")] Entrance550,
        [Description("入口551大骷髅")] Entrance551,
        [Description("入口552矿")] Entrance552,
        [Description("入口553蚂蚁")] Entrance553,
        [Description("入口554牛头")] Entrance554,
        [Description("入口555大牛头")] Entrance555,
        [Description("入口556迷宫")] Entrance556,
        [Description("入口557小三角")] Entrance557,
        [Description("入口558大三角")] Entrance558,
        [Description("入口559佛头")] Entrance559,
        [Description("入口560四角头")] Entrance560,
        [Description("入口561船")] Entrance561,
        [Description("入口562花")] Entrance562,
        [Description("入口563大密林")] Entrance563,
        [Description("连接100图标小城")] Connect100,
        [Description("连接102图标树")] Connect102,
        [Description("连接103图标迷宫")] Connect103,
        [Description("连接104图标蛇")] Connect104,
        [Description("连接120图标金字塔")] Connect120,
        [Description("连接121图标弓塔")] Connect121,
        [Description("连接122图标π")] Connect122,
        [Description("连接123图标迷雾")] Connect123,
        [Description("连接140图标沙漠1")] Connect140,
        [Description("连接141图标沙漠2")] Connect141,
        [Description("连接142图标沙漠3")] Connect142,
        [Description("连接143图标沙漠4")] Connect143,
        [Description("连接160图标密林1")] Connect160,
        [Description("连接161图标密林2")] Connect161,
        [Description("连接162图标密林3")] Connect162,
        [Description("连接300图标六角形")] Connect300,
        [Description("连接301图标山谷")] Connect301,
        [Description("连接302图标解锁")] Connect302,
        [Description("连接510图标小山洞")] Connect510,
        [Description("连接511图标四方门")] Connect511,
        [Description("连接570图标蜈蚣地宫")] Connect570,
        [Description("连接571图标猪洞地宫")] Connect571,
        [Description("连接572图标祖玛地宫")] Connect572,
    }

    public enum Effect
    {
        TeleportOut,
        TeleportIn,

        
        FullBloom,
        WhiteLotus,
        RedLotus,
        SweetBrier,
        Karma,

        Puppet,
        PuppetFire,
        PuppetIce,
        PuppetLightning,
        PuppetWind,

        SummonSkeleton,
        SummonShinsu,

        ThunderBolt,
        DanceOfSwallow,
        FlashOfLight,

        DemonExplosion,
        FrostBiteEnd,
        DemonicRecovery,
    }

    [Flags]
    public enum PoisonType
    {
        None = 0,
        Green = 1,
        Red = 2,
        Slow = 4,
        Paralysis = 8,
        WraithGrip = 16,
        HellFire = 32,
        Silenced = 64,
        Abyss = 128,
        Infection = 256,
        Neutralize = 512,
        
        Flamed = 1024,
        
        Thunder = 2048,
    }

    [Flags]
    public enum MonsterBiaoji
    {
        None = 0,
        Koushao = 1,
    }

    public enum SpellEffect
    {
        None,

        SafeZone,


        FireWall,
        MonsterFireWall,
        Tempest,

        TrapOctagon,

        PoisonousCloud,
        DarkSoulPrison,

        SwordOfVengeance,

        Rubble,

        MonsterDeathCloud,
        LightningWall,

        
        
        LingshanPoisonousCloud,
        
        
        JunhengPoisonousCloud,
        
        
        HuoliMassHeal,
    }

    public enum MarketPlaceSort
    {
        [Description("最新上架")] Newest,
        [Description("旧的商品")] Oldest,
        [Description("最高价格")] HighestPrice,
        [Description("最低价格")] LowestPrice,
    }


    public enum MarketPlaceStoreSort
    {
        [Description("按字母顺序")]
        Alphabetical,
        [Description("最高价格")]
        HighestPrice,
        [Description("最低价格")]
        LowestPrice,
        [Description("最受欢迎")]
        Favourite
    }

    public enum RefineType : byte
    {
        None,
        Durability,
        DC,
        SpellPower,
        Fire,
        Ice,
        Lightning,
        Wind,
        Holy,
        Dark,
        Phantom,
        Reset,
        Health,
        Mana,
        AC,
        MR,
        Accuracy,
        Agility,
        DCPercent,
        SPPercent,
        HealthPercent,
        ManaPercent,
    }

    public enum RefineQuality : byte  
    {
        Rush,          
        Quick,         
        Standard,      
        Careful,       
        Precise,       
    }

    public enum CurrencyType : byte   
    {
        None,
        Gold,                        
        GameGold,                    
    }

    public enum ItemEffect : byte   
    {
        None,

        Gold = 1,
        Experience = 2,
        CompanionTicket = 3,
        BasicCompanionBag = 4,
        PickAxe = 5,
        UmaKingHorn = 6,
        ItemPart = 7,
        Carrot = 8,
        HorseTicket = 9,
        DestructionElixir = 10,
        HasteElixir = 11,
        LifeElixir = 12,
        ManaElixir = 13,
        NatureElixir = 14,
        SpiritElixir = 15,

        BlackIronOre = 20,
        GoldOre = 21,
        Diamond = 22,
        SilverOre = 23,
        IronOre = 24,
        Corundum = 25,

        ElixirOfPurification = 30,
        PillOfReincarnation = 31,

        Crystal = 40,
        RefinementStone = 41,
        Fragment1 = 42,
        Fragment2 = 43,
        Fragment3 = 44,

        ClassChange = 49,
        GenderChange = 50,
        HairChange = 51,
        ArmourDye = 52,
        NameChange = 53,
        FortuneChecker = 54,
        Teleport = 55, 
        TeleportHD = 56, 

        WeaponTemplate = 60,
        WarriorWeapon = 61,
        WizardWeapon = 63,
        TaoistWeapon = 64,
        AssassinWeapon = 65,

        YellowSlot = 70,
        BlueSlot = 71,
        RedSlot = 72,
        PurpleSlot = 73,
        GreenSlot = 74,
        GreySlot = 75,

        FootballArmour = 80,
        FootBallWhistle = 81,

        StatExtractor = 90,
        SpiritBlade = 91,
        RefineExtractor = 92,
        ChaoticHeavenBlade = 93,
        ChaoticHeavenGlaive = 94,
        Level75ArmourUpgrade = 95,
        Level75ArmourBase = 96,
        GuildAllianceTreaty = 97,
        ItemRenameScroll = 98,

        GameGold = 100,
        Shengwang = 101,

        FabaoSpiritBlade = 102,
        FabaoStatExtractor = 103,

        HuizhangRefineExtractor = 104,
        DunpaiRefineExtractor = 105,

        WeaponRefineExtractoryi = 106,
        WeaponRefineExtractorer = 107,
        WeaponRefineExtractorsan = 108,

    }

    [Flags]
    public enum UserItemFlags
    {
        [Description("空")] None = 0,
        [Description("锁定")] Locked = 1,
        [Description("绑定")] Bound = 2,
        [Description("不能出售")] Worthless = 4,
        [Description("可精炼")] Refinable = 8,
        [Description("时间限制")] Expirable = 16, 
        [Description("任务道具")] QuestItem = 32, 
        [Description("GM制作")] GameMaster = 64, 
        [Description("结婚戒指")] Marriage = 128, 
        [Description("不可精炼")] NonRefinable = 256, 
    }

    [Flags]
    public enum BaoshiMaYi
    {
        None = 0,

        XiangKanGJST = 1,
        XiangKanGJBST = 2,
        XiangKanZRST = 4,
        XiangKanZRBST = 8,
        XiangKanLHST = 16,
        XiangKanLHBST = 32,
        XiangKanSMST = 64,
        XiangKanMFST = 128,
        XiangKanSDST = 256,
        XiangKanFYST = 512,
        XiangKanMYST = 1024,
        XiangKanXXY = 2048,
        XiangKanGJEST = 4096,
        XiangKanGJSST = 8192,
        XiangKanGJBEST = 16384,
        XiangKanGJBSST = 32768,
        XiangKanZREST = 65536,
        XiangKanZRSST = 131072,
        XiangKanZRBEST = 262144,
        XiangKanZRBSST = 524288,
        XiangKanLHEST = 1048576,
        XiangKanLHSST = 2097152,
        XiangKanLHBEST = 4194304,
        XiangKanLHBSST = 8388608,
        XiangKanSMEST = 16777216,
        XiangKanSMSST = 33554432,
        XiangKanMFEST = 67108864,
        XiangKanMFSST = 134217728,
        XiangKanSDEST = 268435456,
        XiangKanSDSST = 536870912,
        XiangKanFYEST = 1073741824,
    }

    [Flags]
    public enum BaoshiMaEr
    {
        None = 0,

        XiangKanFYSST = 1,
        XiangKanMYEST = 2,
        XiangKanMYSST = 4,
        XiangKanXXE = 8,
        XiangKanXXS = 16,
        Youliang = 32,
        Jingzhi = 64,
        Shenhua = 128,
        Chuanshuo = 256,
        Kaikongxxy = 512,
        Kaikongxxe = 1024,
        Kaikongxxs = 2048,
        GZLKaikongy = 4096,
        GZLKaikonge = 8192,
        GZLKaikongs = 16384,
        GZLBKaikongy = 32768,
        GZLBKaikonge = 65536,
        GZLBKaikongs = 131072,
        QTKaikongy = 262144,
        QTKaikonge = 524288,
        QTKaikongs = 1048576,
        XiangKanghuoy = 2097152,
        XiangKanghuoe = 4194304,
        XiangKanghuos = 8388608,
        Xiangkanjysty = 16777216,
        Xiangkanjyste = 33554432,
        Xiangkanjysts = 67108864,
        Xiangkanxxsty = 134217728,
        Xiangkanxxste = 268435456,
        Xiangkanxxsts = 536870912,
        XiangKangbingy = 1073741824,

    }

    [Flags]
    public enum BaoshiMaSan
    {
        None = 0,

        XiangKangbinge = 1,
        XiangKangbings = 2,
        XiangKangleiy = 4,
        XiangKangleie = 8,
        XiangKangleis = 16,
        XiangKangfengy = 32,
        XiangKangfenge = 64,
        XiangKangfengs = 128,
        XiangKangsheny = 256,
        XiangKangshene = 512,
        XiangKangshens = 1024,
        XiangKangany = 2048,
        XiangKangane = 4096,
        XiangKangans = 8192,
        XiangKanghuany = 16384,
        XiangKanghuane = 32768,
        XiangKanghuans = 65536,
        XiangKanmofaduny = 131072,
        XiangKanmofadune = 262144,
        XiangKanmofaduns = 524288,
        XiangKanbingdongy = 1048576,
        XiangKanbingdonge = 2097152,
        XiangKanbingdongs = 4194304,
        XiangKanmabiy = 8388608,
        XiangKanmabie = 16777216,
        XiangKanmabis = 33554432,
        XiangKanyidongy = 67108864,
        XiangKanyidonge = 134217728,
        XiangKanyidongs = 268435456,
        XiangKanchenmoy = 536870912,
        XiangKanchenmoe = 1073741824,

    }

    [Flags]
    public enum BaoshiMaSi
    {
        None = 0,

        XiangKanchenmos = 1,
        XiangKangedangy = 2,
        XiangKangedange = 4,
        XiangKangedangs = 8,
        XiangKanduobiy = 16,
        XiangKanduobie = 32,
        XiangKanduobis = 64,
        XiangKanqhuoy = 128,
        XiangKanqhuoe = 256,
        XiangKanqhuos = 512,
        XiangKanqbingy = 1024,
        XiangKanqbinge = 2048,
        XiangKanqbings = 4096,
        XiangKanqleiy = 8192,
        XiangKanqleie = 16384,
        XiangKanqleis = 32768,
        XiangKanqfengy = 65536,
        XiangKanqfenge = 131072,
        XiangKanqfengs = 262144,
        XiangKanqsheny = 524288,
        XiangKanqshene = 1048576,
        XiangKanqshens = 2097152,
        XiangKanqany = 4194304,
        XiangKanqane = 8388608,
        XiangKanqans = 16777216,
        XiangKanqhuany = 33554432,
        XiangKanqhuane = 67108864,
        XiangKanqhuans = 134217728,
        XiangKanlvduy = 268435456,
        XiangKanlvdue = 536870912,
        XiangKanlvdus = 1073741824,

    }

    [Flags]
    public enum BaoshiMaWu
    {
        None = 0,

        XiangKanzymy = 1,
        XiangKanzyme = 2,
        XiangKanzyms = 4,
        XiangKanmhhfy = 8,
        XiangKanmhhfe = 16,
        XiangKanmhhfs = 32,
        XiangKangjstyijiy = 64,
        XiangKangjstyijie = 128,
        XiangKangjstyijis = 256,
        XiangKangjsterjiy = 512,
        XiangKangjsterjie = 1024,
        XiangKangjsterjis = 2048,
        XiangKangjstsanjiy = 4096,
        XiangKangjstsanjie = 8192,
        XiangKangjstsanjis = 16384,
        XiangKangjstsijiy = 32768,
        XiangKangjstsijie = 65536,
        XiangKangjstsijis = 131072,
        XiangKangjbstyijiy = 262144,
        XiangKangjbstyijie = 524288,
        XiangKangjbstyijis = 1048576,
        XiangKangjbsterjiy = 2097152,
        XiangKangjbsterjie = 4194304,
        XiangKangjbsterjis = 8388608,
        XiangKangjbstsanjiy = 16777216,
        XiangKangjbstsanjie = 33554432,
        XiangKangjbstsanjis = 67108864,
        XiangKangjbstsijiy = 134217728,
        XiangKangjbstsijie = 268435456,
        XiangKangjbstsijis = 536870912,
        XiangKanzrstyijiy = 1073741824,

    }

    [Flags]
    public enum BaoshiMaLiu
    {
        None = 0,

        XiangKanzrstyijie = 1,
        XiangKanzrstyijis = 2,
        XiangKanzrsterjiy = 4,
        XiangKanzrsterjie = 8,
        XiangKanzrsterjis = 16,
        XiangKanzrstsanjiy = 32,
        XiangKanzrstsanjie = 64,
        XiangKanzrstsanjis = 128,
        XiangKanzrstsijiy = 256,
        XiangKanzrstsijie = 512,
        XiangKanzrstsijis = 1024,
        XiangKanzrbstyijiy = 2048,
        XiangKanzrbstyijie = 4096,
        XiangKanzrbstyijis = 8192,
        XiangKanzrbsterjiy = 16384,
        XiangKanzrbsterjie = 32768,
        XiangKanzrbsterjis = 65536,
        XiangKanzrbstsanjiy = 131072,
        XiangKanzrbstsanjie = 262144,
        XiangKanzrbstsanjis = 524288,
        XiangKanzrbstsijiy = 1048576,
        XiangKanzrbstsijie = 2097152,
        XiangKanzrbstsijis = 4194304,
        XiangKanlhstyijiy = 8388608,
        XiangKanlhstyijie = 16777216,
        XiangKanlhstyijis = 33554432,
        XiangKanlhsterjiy = 67108864,
        XiangKanlhsterjie = 134217728,
        XiangKanlhsterjis = 268435456,
        XiangKanlhstsanjiy = 536870912,
        XiangKanlhstsanjie = 1073741824,

    }

    [Flags]
    public enum BaoshiMaQi
    {
        None = 0,

        XiangKanlhstsanjis = 1,
        XiangKanlhstsijiy = 2,
        XiangKanlhstsijie = 4,
        XiangKanlhstsijis = 8,
        XiangKanlhbstyijiy = 16,
        XiangKanlhbstyijie = 32,
        XiangKanlhbstyijis = 64,
        XiangKanlhbsterjiy = 128,
        XiangKanlhbsterjie = 256,
        XiangKanlhbsterjis = 512,
        XiangKanlhbstsanjiy = 1024,
        XiangKanlhbstsanjie = 2048,
        XiangKanlhbstsanjis = 4096,
        XiangKanlhbstsijiy = 8192,
        XiangKanlhbstsijie = 16384,
        XiangKanlhbstsijis = 32768,
        XiangKansmstyijiy = 65536,
        XiangKansmstyijie = 131072,
        XiangKansmstyijis = 262144,
        XiangKansmsterjiy = 524288,
        XiangKansmsterjie = 1048576,
        XiangKansmsterjis = 2097152,
        XiangKansmstsanjiy = 4194304,
        XiangKansmstsanjie = 8388608,
        XiangKansmstsanjis = 16777216,
        XiangKansmstsijiy = 33554432,
        XiangKansmstsijie = 67108864,
        XiangKansmstsijis = 134217728,
        XiangKanmfstyijiy = 268435456,
        XiangKanmfstyijie = 536870912,
        XiangKanmfstyijis = 1073741824,

    }

    [Flags]
    public enum BaoshiMaBa
    {
        None = 0,

        XiangKanmfsterjiy = 1,
        XiangKanmfsterjie = 2,
        XiangKanmfsterjis = 4,
        XiangKanmfstsanjiy = 8,
        XiangKanmfstsanjie = 16,
        XiangKanmfstsanjis = 32,
        XiangKanmfstsijiy = 64,
        XiangKanmfstsijie = 128,
        XiangKanmfstsijis = 256,
        XiangKansdstyijiy = 512,
        XiangKansdstyijie = 1024,
        XiangKansdstyijis = 2048,
        XiangKansdsterjiy = 4096,
        XiangKansdsterjie = 8192,
        XiangKansdsterjis = 16384,
        XiangKansdstsanjiy = 32768,
        XiangKansdstsanjie = 65536,
        XiangKansdstsanjis = 131072,
        XiangKansdstsijiy = 262144,
        XiangKansdstsijie = 524288,
        XiangKansdstsijis = 1048576,
        XiangKanfystyijiy = 2097152,
        XiangKanfystyijie = 4194304,
        XiangKanfystyijis = 8388608,
        XiangKanfysterjiy = 16777216,
        XiangKanfysterjie = 33554432,
        XiangKanfysterjis = 67108864,
        XiangKanfystsanjiy = 134217728,
        XiangKanfystsanjie = 268435456,
        XiangKanfystsanjis = 536870912,
        XiangKanfystsijiy = 1073741824,

    }

    [Flags]
    public enum BaoshiMaJiu
    {
        None = 0,

        XiangKanfystsijie = 1,
        XiangKanfystsijis = 2,
        XiangKanmystyijiy = 4,
        XiangKanmystyijie = 8,
        XiangKanmystyijis = 16,
        XiangKanmysterjiy = 32,
        XiangKanmysterjie = 64,
        XiangKanmysterjis = 128,
        XiangKanmystsanjiy = 256,
        XiangKanmystsanjie = 512,
        XiangKanmystsanjis = 1024,
        XiangKanmystsijiy = 2048,
        XiangKanmystsijie = 4096,
        XiangKanmystsijis = 8192,
        XiangKanjystyijiy = 16384,
        XiangKanjystyijie = 32768,
        XiangKanjystyijis = 65536,
        XiangKanjysterjiy = 131072,
        XiangKanjysterjie = 262144,
        XiangKanjysterjis = 524288,
        XiangKanjystsanjiy = 1048576,
        XiangKanjystsanjie = 2097152,
        XiangKanjystsanjis = 4194304,
        XiangKanjystsijiy = 8388608,
        XiangKanjystsijie = 16777216,
        XiangKanjystsijis = 33554432,
        XiangKangbingstyijiy = 67108864,
        XiangKangbingstyijie = 134217728,
        XiangKangbingstyijis = 268435456,
        XiangKangbingsterjiy = 536870912,
        XiangKangbingsterjie = 1073741824,

    }

    [Flags]
    public enum BaoshiMaShi
    {
        None = 0,

        XiangKangbingsterjis = 1,
        XiangKangbingstsanjiy = 2,
        XiangKangbingstsanjie = 4,
        XiangKangbingstsanjis = 8,
        XiangKangbingstsijiy = 16,
        XiangKangbingstsijie = 32,
        XiangKangbingstsijis = 64,
        XiangKanghuostyijiy = 128,
        XiangKanghuostyijie = 256,
        XiangKanghuostyijis = 512,
        XiangKanghuosterjiy = 1024,
        XiangKanghuosterjie = 2048,
        XiangKanghuosterjis = 4096,
        XiangKanghuostsanjiy = 8192,
        XiangKanghuostsanjie = 16384,
        XiangKanghuostsanjis = 32768,
        XiangKanghuostsijiy = 65536,
        XiangKanghuostsijie = 131072,
        XiangKanghuostsijis = 262144,
        XiangKangleistyijiy = 524288,
        XiangKangleistyijie = 1048576,
        XiangKangleistyijis = 2097152,
        XiangKangleisterjiy = 4194304,
        XiangKangleisterjie = 8388608,
        XiangKangleisterjis = 16777216,
        XiangKangleistsanjiy = 33554432,
        XiangKangleistsanjie = 67108864,
        XiangKangleistsanjis = 134217728,
        XiangKangleistsijiy = 268435456,
        XiangKangleistsijie = 536870912,
        XiangKangleistsijis = 1073741824,

    }

    [Flags]
    public enum BaoshiMaShiyi
    {
        None = 0,

        XiangKangfengstyijiy = 1,
        XiangKangfengstyijie = 2,
        XiangKangfengstyijis = 4,
        XiangKangfengsterjiy = 8,
        XiangKangfengsterjie = 16,
        XiangKangfengsterjis = 32,
        XiangKangfengstsanjiy = 64,
        XiangKangfengstsanjie = 128,
        XiangKangfengstsanjis = 256,
        XiangKangfengstsijiy = 512,
        XiangKangfengstsijie = 1024,
        XiangKangfengstsijis = 2048,
        XiangKangshenstyijiy = 4096,
        XiangKangshenstyijie = 8192,
        XiangKangshenstyijis = 16384,
        XiangKangshensterjiy = 32768,
        XiangKangshensterjie = 65536,
        XiangKangshensterjis = 131072,
        XiangKangshenstsanjiy = 262144,
        XiangKangshenstsanjie = 524288,
        XiangKangshenstsanjis = 1048576,
        XiangKangshenstsijiy = 2097152,
        XiangKangshenstsijie = 4194304,
        XiangKangshenstsijis = 8388608,
        XiangKanganstyijiy = 16777216,
        XiangKanganstyijie = 33554432,
        XiangKanganstyijis = 67108864,
        XiangKangansterjiy = 134217728,
        XiangKangansterjie = 268435456,
        XiangKangansterjis = 536870912,
        XiangKanganstsanjiy = 1073741824,

    }

    [Flags]
    public enum BaoshiMaShier
    {
        None = 0,

        XiangKanganstsanjie = 1,
        XiangKanganstsanjis = 2,
        XiangKanganstsijiy = 4,
        XiangKanganstsijie = 8,
        XiangKanganstsijis = 16,
        XiangKanghuanstyijiy = 32,
        XiangKanghuanstyijie = 64,
        XiangKanghuanstyijis = 128,
        XiangKanghuansterjiy = 256,
        XiangKanghuansterjie = 512,
        XiangKanghuansterjis = 1024,
        XiangKanghuanstsanjiy = 2048,
        XiangKanghuanstsanjie = 4096,
        XiangKanghuanstsanjis = 8192,
        XiangKanghuanstsijiy = 16384,
        XiangKanghuanstsijie = 32768,
        XiangKanghuanstsijis = 65536,
        XiangKanmofadunstyijiy = 131072,
        XiangKanmofadunstyijie = 262144,
        XiangKanmofadunstyijis = 524288,
        XiangKanmofadunsterjiy = 1048576,
        XiangKanmofadunsterjie = 2097152,
        XiangKanmofadunsterjis = 4194304,
        XiangKanmofadunstsanjiy = 8388608,
        XiangKanmofadunstsanjie = 16777216,
        XiangKanmofadunstsanjis = 33554432,
        XiangKanmofadunstsijiy = 67108864,
        XiangKanmofadunstsijie = 134217728,
        XiangKanmofadunstsijis = 268435456,
        XiangKanbingdongstyijiy = 536870912,
        XiangKanbingdongstyijie = 1073741824,

    }

    [Flags]
    public enum BaoshiMaShisan
    {
        None = 0,

        XiangKanbingdongstyijis = 1,
        XiangKanbingdongsterjiy = 2,
        XiangKanbingdongsterjie = 4,
        XiangKanbingdongsterjis = 8,
        XiangKanbingdongstsanjiy = 16,
        XiangKanbingdongstsanjie = 32,
        XiangKanbingdongstsanjis = 64,
        XiangKanbingdongstsijiy = 128,
        XiangKanbingdongstsijie = 256,
        XiangKanbingdongstsijis = 512,
        Huanhua = 1024,
        XiangKanjingliany = 2048,
        XiangKanjingliane = 4096,
        XiangKanjinglians = 8192,
        XiangKanjinglianstyijiy = 16384,
        XiangKanjinglianstyijie = 32768,
        XiangKanjinglianstyijis = 65536,
        XiangKanjingliansterjiy = 131072,
        XiangKanjingliansterjie = 262144,
        XiangKanjingliansterjis = 524288,
        XiangKanjinglianstsanjiy = 1048576,
        XiangKanjinglianstsanjie = 2097152,
        XiangKanjinglianstsanjis = 4194304,
        XiangKanjinglianstsijiy = 8388608,
        XiangKanjinglianstsijie = 16777216,
        XiangKanjinglianstsijis = 33554432,
        XiangKanlvdustyijiy = 67108864,
        XiangKanlvdustyijie = 134217728,
        XiangKanlvdustyijis = 268435456,
        XiangKanlvdusterjiy = 536870912,
        XiangKanlvdusterjie = 1073741824,
    }

    [Flags]
    public enum BaoshiMaShisi
    {
        None = 0,

        XiangKanlvdusterjis = 1,
        XiangKanlvdustsanjiy = 2,
        XiangKanlvdustsanjie = 4,
        XiangKanlvdustsanjis = 8,
        XiangKanlvdustsijiy = 16,
        XiangKanlvdustsijie = 32,
        XiangKanlvdustsijis = 64,
        XiangKanzymstyijiy = 128,
        XiangKanzymstyijie = 256,
        XiangKanzymstyijis = 512,
        XiangKanzymsterjiy = 1024,
        XiangKanzymsterjie = 2048,
        XiangKanzymsterjis = 4096,
        XiangKanzymstsanjiy = 8192,
        XiangKanzymstsanjie = 16384,
        XiangKanzymstsanjis = 32768,
        XiangKanzymstsijiy = 65536,
        XiangKanzymstsijie = 131072,
        XiangKanzymstsijis = 262144,
    }

    [Flags]
    public enum MingwenMaYi
    {
        None = 0,

        Mingwenweiyi = 1,
        Mingwenxinxiyi = 2,
        Mingwenxinxier = 4,
        Mingwenxinxisan = 8,
        Mingwenweier = 16,
        Mingwenxinxisi = 32,
        Mingwenxinxiwu = 64,
        Mingwenxinxiliu = 128,

        ShenRuoYinY = 256,  
        ShenRuoYinE = 512,  
        ShenRuoYinS = 1024,  
        ShenShuYinY = 2048,  
        ShenShuYinE = 4096,  
        ShenShuYinS = 8192,  
        ShenBaoYinY = 16384,
        ShenBaoYinE = 32768,
        ShenBaoYinS = 65536,
        MiaoShouYinY = 131072,
        MiaoShouYinE = 262144,
        MiaoShouYinS = 524288,

        LingJiYinY = 1048576,
        LingJiYinE = 2097152,
        LingJiYinS = 4194304,

        DaoFaYinY = 8388608,
        DaoFaYinE = 16777216,
        DaoFaYinS = 33554432,

        LingBaoYinY = 67108864,
        LingBaoYinE = 134217728,
        LingBaoYinS = 268435456,

    }

    [Flags]
    public enum MingwenMaEr
    {
        None = 0,

        LingBoYinY = 1,
        LingBoYinE = 2,
        LingBoYinS = 4,

        LingFengYinY = 8,
        LingFengYinE = 16,
        LingFengYinS = 32,

        LingYunYinY = 64,
        LingYunYinE = 128,
        LingYunYinS = 256,

        LingQuYinY = 512,
        LingQuYinE = 1024,
        LingQuYinS = 2048,

        HuosheYinY = 4096,
        HuosheYinE = 8192,
        HuosheYinS = 16384,

        TansheYinY = 32768, 
        TansheYinE = 65536, 
        TansheYinS = 131072, 

        QunsheYinY = 134217728, 
        QunsheYinE = 268435456, 
        QunsheYinS = 536870912, 

        LingkongYinY = 262144, 
        LingkongYinE = 524288, 
        LingkongYinS = 1048576, 

        FuzhenYinY = 2097152, 
        FuzhenYinE = 4194304, 
        FuzhenYinS = 8388608, 

        YulongYinY = 16777216,
        YulongYinE = 33554432,
        YulongYinS = 67108864,
    }

    [Flags]
    public enum MingwenMaSan
    {
        None = 0,

        LongwangYinY = 1,
        LongwangYinE = 2,
        LongwangYinS = 4,

        JunwangYinY = 8,
        JunwangYinE = 16,
        JunwangYinS = 32,

        ToutianYinY = 64,
        ToutianYinE = 128,
        ToutianYinS = 256,

        JialanYinY = 512,
        JialanYinE = 1024,
        JialanYinS = 2048,

        KongxiangYinY = 4096,
        KongxiangYinE = 8192,
        KongxiangYinS = 16384,

        LiuxingYinY = 32768,
        LiuxingYinE = 65536,
        LiuxingYinS = 131072,

        LingxieYinY = 262144,
        LingxieYinE = 524288,
        LingxieYinS = 1048576,

        LingbaoYinY = 2097152,
        LingbaoYinE = 4194304,
        LingbaoYinS = 8388608,

        YouqiangYinY = 16777216,
        YouqiangYinE = 33554432,
        YouqiangYinS = 67108864,

        GongsheYinY = 134217728,
        GongsheYinE = 268435456,
        GongsheYinS = 536870912,
    }

    [Flags]
    public enum MingwenMaSi
    {
        None = 0,

        YingjiYinY = 1,
        YingjiYinE = 2,
        YingjiYinS = 4,

        JizhongYinY = 8,
        JizhongYinE = 16,
        JizhongYinS = 32,

        DusheYinY = 64,
        DusheYinE = 128,
        DusheYinS = 256,

        ShesheYinY = 512,
        ShesheYinE = 1024,
        ShesheYinS = 2048,

        QiangsheYinY = 134217728,
        QiangsheYinE = 268435456,
        QiangsheYinS = 536870912,

        HunkongYinY = 4096,
        HunkongYinE = 8192,
        HunkongYinS = 16384,

        HunzhenYinY = 32768,
        HunzhenYinE = 65536,
        HunzhenYinS = 131072,

        NingdanYinY = 262144,
        NingdanYinE = 524288,
        NingdanYinS = 1048576,

        NingbaoYinY = 2097152,
        NingbaoYinE = 4194304,
        NingbaoYinS = 8388608,

        NingxiaoYinY = 16777216,
        NingxiaoYinE = 33554432,
        NingxiaoYinS = 67108864,
    }

    [Flags]
    public enum MingwenMaWu
    {
        None = 0,

        XiezhouYinY = 1,
        XiezhouYinE = 2,
        XiezhouYinS = 4,

        ZhengzhouYinY = 8,
        ZhengzhouYinE = 16,
        ZhengzhouYinS = 32,

        KongquanYinY = 64,
        KongquanYinE = 128,
        KongquanYinS = 256,

        QuanbaYinY = 512,
        QuanbaYinE = 1024,
        QuanbaYinS = 2048,

        QuanjiYinY = 4096,
        QuanjiYinE = 8192,
        QuanjiYinS = 16384,

        QiangfaYinY = 32768,
        QiangfaYinE = 65536,
        QiangfaYinS = 131072,

        QiangbaoYinY = 262144,
        QiangbaoYinE = 524288,
        QiangbaoYinS = 1048576,

        LingshouYinY = 2097152,
        LingshouYinE = 4194304,
        LingshouYinS = 8388608,

        XueshouYinY = 16777216,
        XueshouYinE = 33554432,
        XueshouYinS = 67108864,

        MiaoyinYinY = 134217728,
        MiaoyinYinE = 268435456,
        MiaoyinYinS = 536870912,
    }
    [Flags]
    public enum MingwenMaLiu
    {
        None = 0,

        ShengshouYinY = 1,
        ShengshouYinE = 2,
        ShengshouYinS = 4,

        YaoguangYinY = 8,
        YaoguangYinE = 16,
        YaoguangYinS = 32,

        ChaojunwangYinY = 64,
        ChaojunwangYinE = 128,
        ChaojunwangYinS = 256,

        ChaotoutianYinY = 512,
        ChaotoutianYinE = 1024,
        ChaotoutianYinS = 2048,

        ChaojialanYinY = 4096,
        ChaojialanYinE = 8192,
        ChaojialanYinS = 16384,

        MengshiYinY = 32768,
        MengshiYinE = 65536,
        MengshiYinS = 131072,

        QiangshiYinY = 262144,
        QiangshiYinE = 524288,
        QiangshiYinS = 1048576,

        BaohuYinY = 2097152,
        BaohuYinE = 4194304,
        BaohuYinS = 8388608,

        DaozunYinY = 16777216,
        DaozunYinE = 33554432,
        DaozunYinS = 67108864,

        JiesuYinY = 134217728,
        JiesuYinE = 268435456,
        JiesuYinS = 536870912,
    }

    [Flags]
    public enum MingwenMaQi
    {
        None = 0,

        LunhuiYinY = 1,
        LunhuiYinE = 2,
        LunhuiYinS = 4,

        ZongbaoYinY = 8,
        ZongbaoYinE = 16,
        ZongbaoYinS = 32,

        SusheYinY = 64,
        SusheYinE = 128,
        SusheYinS = 256,

        BaosheYinY = 512,
        BaosheYinE = 1024,
        BaosheYinS = 2048,

        MiehunYinY = 4096,
        MiehunYinE = 8192,
        MiehunYinS = 16384,

        MiezhenYinY = 32768,
        MiezhenYinE = 65536,
        MiezhenYinS = 131072,

        HongyueYinY = 262144,
        HongyueYinE = 524288,
        HongyueYinS = 1048576,

        HuoyanYinY = 2097152,
        HuoyanYinE = 4194304,
        HuoyanYinS = 8388608,

        ZhenqiangYinY = 16777216,
        ZhenqiangYinE = 33554432,
        ZhenqiangYinS = 67108864,

        XiongzhaoYinY = 134217728,
        XiongzhaoYinE = 268435456,
        XiongzhaoYinS = 536870912,
    }

    [Flags]
    public enum MingwenMaBa
    {
        None = 0,

        HuoyuanYinY = 1,
        HuoyuanYinE = 2,
        HuoyuanYinS = 4,

        SumingYinY = 8,
        SumingYinE = 16,
        SumingYinS = 32,

        SheshouYinY = 64,
        SheshouYinE = 128,
        SheshouYinS = 256,

        ChuansheYinY = 512,
        ChuansheYinE = 1024,
        ChuansheYinS = 2048,
        
        HuoliYinY = 4096,
        HuoliYinE = 8192,
        HuoliYinS = 16384,
        /*
        MiezhenYinY = 32768,
        MiezhenYinE = 65536,
        MiezhenYinS = 131072,
        
        HongyueYinY = 262144,
        HongyueYinE = 524288,
        HongyueYinS = 1048576,

        HuoyanYinY = 2097152,
        HuoyanYinE = 4194304,
        HuoyanYinS = 8388608,

        ZhenQiangYinY = 16777216,
        ZhenQiangYinE = 33554432,
        ZhenQiangYinS = 67108864,

        XiongzhaoYinY = 134217728,
        XiongzhaoYinE = 268435456,
        XiongzhaoYinS = 536870912,*/
    }

    [Flags]
    public enum MingwenMaJiu
    {
        None = 0,

        HuotuiYinY = 1,
        HuotuiYinE = 2,
        HuotuiYinS = 4,

        HuoqiuYinY = 8,
        HuoqiuYinE = 16,
        HuoqiuYinS = 32,

        ChaofanYinY = 64,
        ChaofanYinE = 128,
        ChaofanYinS = 256,

        YiduanYinY = 512,
        YiduanYinE = 1024,
        YiduanYinS = 2048,

        BingxueYinY = 4096,
        BingxueYinE = 8192,
        BingxueYinS = 16384,

        BingqiangYinY = 32768,
        BingqiangYinE = 65536,
        BingqiangYinS = 131072,

        YanhuaYinY = 262144,
        YanhuaYinE = 524288,
        YanhuaYinS = 1048576,

        HuohuanYinY = 2097152,
        HuohuanYinE = 4194304,
        HuohuanYinS = 8388608,

        JunshiYinY = 16777216,
        JunshiYinE = 33554432,
        JunshiYinS = 67108864,

        MoyuYinY = 134217728,
        MoyuYinE = 268435456,
        MoyuYinS = 536870912,

    }

    [Flags]
    public enum MingwenMaShi
    {
        None = 0,

        MoyanYinY = 1,
        MoyanYinE = 2,
        MoyanYinS = 4,

        XueqiYinY = 8,
        XueqiYinE = 16,
        XueqiYinS = 32,

        YidongYinY = 64,
        YidongYinE = 128,
        YidongYinS = 256,

        XunjieYinY = 512,
        XunjieYinE = 1024,
        XunjieYinS = 2048,

        DuoluoYinY = 4096,
        DuoluoYinE = 8192,
        DuoluoYinS = 16384,

        ChumeiYinY = 32768,
        ChumeiYinE = 65536,
        ChumeiYinS = 131072,

        TianfaYinY = 262144,
        TianfaYinE = 524288,
        TianfaYinS = 1048576,

        TiannuYinY = 2097152,
        TiannuYinE = 4194304,
        TiannuYinS = 8388608,

        BumieYinY = 16777216,
        BumieYinE = 33554432,
        BumieYinS = 67108864,

        HuguangYinY = 134217728,
        HuguangYinE = 268435456,
        HuguangYinS = 536870912,
    }

    [Flags]
    public enum MingwenMaShiyi
    {
        None = 0,

        JingmoYinY = 1,
        JingmoYinE = 2,
        JingmoYinS = 4,

        YanlongYinY = 8,
        YanlongYinE = 16,
        YanlongYinS = 32,

        LeishenYinY = 64,
        LeishenYinE = 128,
        LeishenYinS = 256,

        LeizhuYinY = 512,
        LeizhuYinE = 1024,
        LeizhuYinS = 2048,

        LeizhouYinY = 4096,
        LeizhouYinE = 8192,
        LeizhouYinS = 16384,

        BingdaoYinY = 32768,
        BingdaoYinE = 65536,
        BingdaoYinS = 131072,

        BingshuangYinY = 262144,
        BingshuangYinE = 524288,
        BingshuangYinS = 1048576,

        FengboYinY = 2097152,
        FengboYinE = 4194304,
        FengboYinS = 8388608,

        ShanfengYinY = 16777216,
        ShanfengYinE = 33554432,
        ShanfengYinS = 67108864,

        GuanhuoYinY = 134217728,
        GuanhuoYinE = 268435456,
        GuanhuoYinS = 536870912,

    }

    [Flags]
    public enum MingwenMaShier
    {
        None = 0,

        ZhenhongYinY = 1,
        ZhenhongYinE = 2,
        ZhenhongYinS = 4,

        ShenglingYinY = 8,
        ShenglingYinE = 16,
        ShenglingYinS = 32,

        MizhouYinY = 64,
        MizhouYinE = 128,
        MizhouYinS = 256,

        YixingYinY = 512,
        YixingYinE = 1024,
        YixingYinS = 2048,

        TianshouYinY = 4096,
        TianshouYinE = 8192,
        TianshouYinS = 16384,

        ShuangguYinY = 32768,
        ShuangguYinE = 65536,
        ShuangguYinS = 131072,

        FengshengYinY = 262144,
        FengshengYinE = 524288,
        FengshengYinS = 1048576,

        JihuoYinY = 2097152,
        JihuoYinE = 4194304,
        JihuoYinS = 8388608,

        LeilongYinY = 16777216,
        LeilongYinE = 33554432,
        LeilongYinS = 67108864,

        LongxingYinY = 134217728,
        LongxingYinE = 268435456,
        LongxingYinS = 536870912,

    }

    [Flags]
    public enum MingwenMaShisan
    {
        None = 0,

        LonghunYinY = 1,
        LonghunYinE = 2,
        LonghunYinS = 4,

        XuanfengYinY = 8,
        XuanfengYinE = 16,
        XuanfengYinS = 32,

        ZhuzaiYinY = 64,
        ZhuzaiYinE = 128,
        ZhuzaiYinS = 256,

        YousuYinY = 512,
        YousuYinE = 1024,
        YousuYinS = 2048,

        YazhiYinY = 4096,
        YazhiYinE = 8192,
        YazhiYinS = 16384,

        YinguangYinY = 32768,
        YinguangYinE = 65536,
        YinguangYinS = 131072,

        BaojunYinY = 262144,
        BaojunYinE = 524288,
        BaojunYinS = 1048576,

        XueshaYinY = 2097152,
        XueshaYinE = 4194304,
        XueshaYinS = 8388608,

        HuanglongYinY = 16777216,
        HuanglongYinE = 33554432,
        HuanglongYinS = 67108864,

        YaoguangYinY = 134217728,
        YaoguangYinE = 268435456,
        YaoguangYinS = 536870912,

    }

    [Flags]
    public enum MingwenMaShisi
    {
        None = 0,

        PoshanYinY = 1,
        PoshanYinE = 2,
        PoshanYinS = 4,

        YuehuaYinY = 8,
        YuehuaYinE = 16,
        YuehuaYinS = 32,

        GuanyueYinY = 64,
        GuanyueYinE = 128,
        GuanyueYinS = 256,

        JiyueYinY = 512,
        JiyueYinE = 1024,
        JiyueYinS = 2048,

        LiefengYinY = 4096,
        LiefengYinE = 8192,
        LiefengYinS = 16384,

        JvhuoYinY = 32768,
        JvhuoYinE = 65536,
        JvhuoYinS = 131072,

        JibuYinY = 262144,
        JibuYinE = 524288,
        JibuYinS = 1048576,

        ChongzhuangYinY = 2097152,
        ChongzhuangYinE = 4194304,
        ChongzhuangYinS = 8388608,

        YeyongYinY = 16777216,
        YeyongYinE = 33554432,
        YeyongYinS = 67108864,

        ZhanyueYinY = 134217728,
        ZhanyueYinE = 268435456,
        ZhanyueYinS = 536870912,

    }
    [Flags]
    public enum MingwenMaShiwu
    {
        None = 0,

        DuohuoYinY = 1,
        DuohuoYinE = 2,
        DuohuoYinS = 4,

        RanshaoYinY = 8,
        RanshaoYinE = 16,
        RanshaoYinS = 32,

        KaijiangYinY = 64,
        KaijiangYinE = 128,
        KaijiangYinS = 256,

        ShenquYinY = 512,
        ShenquYinE = 1024,
        ShenquYinS = 2048,

        ShenglongYinY = 4096,
        ShenglongYinE = 8192,
        ShenglongYinS = 16384,
      
        ZengqiangYinY = 32768,
        ZengqiangYinE = 65536,
        ZengqiangYinS = 131072,

        QiangdaYinY = 262144,
        QiangdaYinE = 524288,
        QiangdaYinS = 1048576,

        DaofaYinY = 2097152,
        DaofaYinE = 4194304,
        DaofaYinS = 8388608,
        
        KuaidaoYinY = 16777216,
        KuaidaoYinE = 33554432,
        KuaidaoYinS = 67108864,

        BadaoYinY = 134217728,
        BadaoYinE = 268435456,
        BadaoYinS = 536870912,
    }

    [Flags]
    public enum MingwenMaShiliu
    {
        None = 0,
        
        ChuiziYinY = 1,
        ChuiziYinE = 2,
        ChuiziYinS = 4,

        ZhanchuiYinY = 8,
        ZhanchuiYinE = 16,
        ZhanchuiYinS = 32,

        TianshenYinY = 64,
        TianshenYinE = 128,
        TianshenYinS = 256,

        JianzhuangYinY = 512,
        JianzhuangYinE = 1024,
        JianzhuangYinS = 2048,

        TiebuYinY = 4096,
        TiebuYinE = 8192,
        TiebuYinS = 16384,

        NuoyiYinY = 32768,
        NuoyiYinE = 65536,
        NuoyiYinS = 131072,
        
        DouzhuanYinY = 262144,
        DouzhuanYinE = 524288,
        DouzhuanYinS = 1048576,
        
        PoxueYinY = 2097152,
        PoxueYinE = 4194304,
        PoxueYinS = 8388608,

        KuangmoYinY = 16777216,
        KuangmoYinE = 33554432,
        KuangmoYinS = 67108864,
        
        JingangYinY = 134217728,
        JingangYinE = 268435456,
        JingangYinS = 536870912,
        
    }

    [Flags]
    public enum MingwenMaShiqi
    {
        None = 0,
        
        SumingYinY = 1,
        SumingYinE = 2,
        SumingYinS = 4,
        
        JingweiYinY = 8,
        JingweiYinE = 16,
        JingweiYinS = 32,

        HuishengYinY = 64,
        HuishengYinE = 128,
        HuishengYinS = 256,

        XinyanYinY = 512,
        XinyanYinE = 1024,
        XinyanYinS = 2048,

        XukongYinY = 4096,
        XukongYinE = 8192,
        XukongYinS = 16384,

        ShoulieYinY = 32768,
        ShoulieYinE = 65536,
        ShoulieYinS = 131072,

        TiaoheYinY = 262144,
        TiaoheYinE = 524288,
        TiaoheYinS = 1048576,

        LianminYinY = 2097152,
        LianminYinE = 4194304,
        LianminYinS = 8388608,

        LianyueYinY = 16777216,
        LianyueYinE = 33554432,
        LianyueYinS = 67108864,

        WushuangYinY = 134217728,
        WushuangYinE = 268435456,
        WushuangYinS = 536870912,
        
    }

    [Flags]
    public enum MingwenMaShiba
    {
        None = 0,

        YunjiYinY = 1,
        YunjiYinE = 2,
        YunjiYinS = 4,
        
        YisuYinY = 8,
        YisuYinE = 16,
        YisuYinS = 32,
        
        XixueYinY = 64,
        XixueYinE = 128,
        XixueYinS = 256,
        
        FahuanYinY = 512,
        FahuanYinE = 1024,
        FahuanYinS = 2048,

        YinxueYinY = 4096,
        YinxueYinE = 8192,
        YinxueYinS = 16384,
        
        XixingYinY = 32768,
        XixingYinE = 65536,
        XixingYinS = 131072,
        
        XueyinYinY = 262144,
        XueyinYinE = 524288,
        XueyinYinS = 1048576,
        
        ZhouyuYinY = 2097152,
        ZhouyuYinE = 4194304,
        ZhouyuYinS = 8388608,
        
        DiyuYinY = 16777216,
        DiyuYinE = 33554432,
        DiyuYinS = 67108864,
        
        YantianYinY = 134217728,
        YantianYinE = 268435456,
        YantianYinS = 536870912,
        
    }

    [Flags]
    public enum MingwenMaShijiu
    {
        None = 0,
        
        QunhuoYinY = 1,
        QunhuoYinE = 2,
        QunhuoYinS = 4,

        BaohuoYinY = 8,
        BaohuoYinE = 16,
        BaohuoYinS = 32,
        
        ShengrenYinY = 64,
        ShengrenYinE = 128,
        ShengrenYinS = 256,

        NuhuoYinY = 512,
        NuhuoYinE = 1024,
        NuhuoYinS = 2048,
        
        BingciYinY = 4096,
        BingciYinE = 8192,
        BingciYinS = 16384,

        BinghuaYinY = 32768,
        BinghuaYinE = 65536,
        BinghuaYinS = 131072,
        
        BingshenYinY = 262144,
        BingshenYinE = 524288,
        BingshenYinS = 1048576,

        BinghuanYinY = 2097152,
        BinghuanYinE = 4194304,
        BinghuanYinS = 8388608,
        
        PiliYinY = 16777216,
        PiliYinE = 33554432,
        PiliYinS = 67108864,
        
        ZhengyiYinY = 134217728,
        ZhengyiYinE = 268435456,
        ZhengyiYinS = 536870912,
        
    }

    [Flags]
    public enum MingwenMaErshi
    {
        None = 0,
        
        FanjiYinY = 1,
        FanjiYinE = 2,
        FanjiYinS = 4,
        
        MingzhongYinY = 8,
        MingzhongYinE = 16,
        MingzhongYinS = 32,
        
        FengbaoYinY = 64,
        FengbaoYinE = 128,
        FengbaoYinS = 256,
        
        BaofengYinY = 512,
        BaofengYinE = 1024,
        BaofengYinS = 2048,
        
        BenghuaiYinY = 4096,
        BenghuaiYinE = 8192,
        BenghuaiYinS = 16384,
        
        FengnuYinY = 32768,
        FengnuYinE = 65536,
        FengnuYinS = 131072,
        
        ChangshengYinY = 262144,
        ChangshengYinE = 524288,
        ChangshengYinS = 1048576,
        
        DuocuiYinY = 2097152,
        DuocuiYinE = 4194304,
        DuocuiYinS = 8388608,

        YinniYinY = 16777216,
        YinniYinE = 33554432,
        YinniYinS = 67108864,

        TanlanYinY = 134217728,
        TanlanYinE = 268435456,
        TanlanYinS = 536870912,
        
    }

    [Flags]
    public enum MingwenMaErshiyi
    {
        None = 0,
        
        LingshanYinY = 1,
        LingshanYinE = 2,
        LingshanYinS = 4,

        JvnhengYinY = 8,
        JvnhengYinE = 16,
        JvnhengYinS = 32,
        
        MingxinagYinY = 64,
        MingxinagYinE = 128,
        MingxinagYinS = 256,

        FenzhengYinY = 512,
        FenzhengYinE = 1024,
        FenzhengYinS = 2048,
        
        YibianYinY = 4096,
        YibianYinE = 8192,
        YibianYinS = 16384,

        YexingYinY = 32768,
        YexingYinE = 65536,
        YexingYinS = 131072,
        
        QiannengYinY = 262144,
        QiannengYinE = 524288,
        QiannengYinS = 1048576,

        QinshiYinY = 2097152,
        QinshiYinE = 4194304,
        QinshiYinS = 8388608,
        
        XianjiYinY = 16777216,
        XianjiYinE = 33554432,
        XianjiYinS = 67108864,

        ZengwuYinY = 134217728,
        ZengwuYinE = 268435456,
        ZengwuYinS = 536870912,
        
    }

    [Flags]
    public enum MingwenMaErshier
    {
        None = 0,
        
        BihuYinY = 1,
        BihuYinE = 2,
        BihuYinS = 4,

        QixiYinY = 8,
        QixiYinE = 16,
        QixiYinS = 32,
        
        WuweiYinY = 64,
        WuweiYinE = 128,
        WuweiYinS = 256,

        TiequYinY = 512,
        TiequYinE = 1024,
        TiequYinS = 2048,
        
        ZishengYinY = 4096,
        ZishengYinE = 8192,
        ZishengYinS = 16384,

        TunshiYinY = 32768,
        TunshiYinE = 65536,
        TunshiYinS = 131072,
        
        JijiuYinY = 262144,
        JijiuYinE = 524288,
        JijiuYinS = 1048576,

        KexueYinY = 2097152,
        KexueYinE = 4194304,
        KexueYinS = 8388608,
        
        FusuYinY = 16777216,
        FusuYinE = 33554432,
        FusuYinS = 67108864,

        ChanaYinY = 134217728,
        ChanaYinE = 268435456,
        ChanaYinS = 536870912,
        
    }

    [Flags]
    public enum MingwenMaErshisan
    {
        None = 0,
        
        ChengjieYinY = 1,
        ChengjieYinE = 2,
        ChengjieYinS = 4,

        QishuYinY = 8,
        QishuYinE = 16,
        QishuYinS = 32,
        
        KuangreYinY = 64,
        KuangreYinE = 128,
        KuangreYinS = 256,

        YangyanYinY = 512,
        YangyanYinE = 1024,
        YangyanYinS = 2048,
        
        JielvYinY = 4096,
        JielvYinE = 8192,
        JielvYinS = 16384,

        JingjiYinY = 32768,
        JingjiYinE = 65536,
        JingjiYinS = 131072,
        
        BaoliYinY = 262144,
        BaoliYinE = 524288,
        BaoliYinS = 1048576,

        ShuaibaiYinY = 2097152,
        ShuaibaiYinE = 4194304,
        ShuaibaiYinS = 8388608,
        
        TujinYinY = 16777216,
        TujinYinE = 33554432,
        TujinYinS = 67108864,

        ShougeYinY = 134217728,
        ShougeYinE = 268435456,
        ShougeYinS = 536870912,
        
    }

    [Flags]
    public enum MingwenMaErshisi
    {
        None = 0,
        
        PomoYinY = 1,
        PomoYinE = 2,
        PomoYinS = 4,

        GuanchuanYinY = 8,
        GuanchuanYinE = 16,
        GuanchuanYinS = 32,
        
        ZhanfangYinY = 64,
        ZhanfangYinE = 128,
        ZhanfangYinS = 256,

        ShensuYinY = 512,
        ShensuYinE = 1024,
        ShensuYinS = 2048,
        
        GanyingYinY = 4096,
        GanyingYinE = 8192,
        GanyingYinS = 16384,

        QiangjianYinY = 32768,
        QiangjianYinE = 65536,
        QiangjianYinS = 131072,
        
        ZhuanhuanYinY = 262144,
        ZhuanhuanYinE = 524288,
        ZhuanhuanYinS = 1048576,

        YishanYinY = 2097152,
        YishanYinE = 4194304,
        YishanYinS = 8388608,
        
        ZhenfenYinY = 16777216,
        ZhenfenYinE = 33554432,
        ZhenfenYinS = 67108864,

        XinnianYinY = 134217728,
        XinnianYinE = 268435456,
        XinnianYinS = 536870912,
        
    }

    [Flags]
    public enum MingwenMaErshiwu
    {
        None = 0,
        
        ZhengjiuYinY = 1,
        ZhengjiuYinE = 2,
        ZhengjiuYinS = 4,

        ZhimingYinY = 8,
        ZhimingYinE = 16,
        ZhimingYinS = 32,
        
        DongchaYinY = 64,
        DongchaYinE = 128,
        DongchaYinS = 256,

        PojiaYinY = 512,
        PojiaYinE = 1024,
        PojiaYinS = 2048,
        
        JiantaYinY = 4096,
        JiantaYinE = 8192,
        JiantaYinS = 16384,

        ZhenjiYinY = 32768,
        ZhenjiYinE = 65536,
        ZhenjiYinS = 131072,
        
        GangyiYinY = 262144,
        GangyiYinE = 524288,
        GangyiYinS = 1048576,

        TongkuYinY = 2097152,
        TongkuYinE = 4194304,
        TongkuYinS = 8388608,
        
        YuheYinY = 16777216,
        YuheYinE = 33554432,
        YuheYinS = 67108864,

        JianbiYinY = 134217728,
        JianbiYinE = 268435456,
        JianbiYinS = 536870912,
        
    }

    [Flags]
    public enum MingwenMaErshiliu
    {
        None = 0,
        
        ZhuanzhuYinY = 1,
        ZhuanzhuYinE = 2,
        ZhuanzhuYinS = 4,

        YingjiYinY = 8,
        YingjiYinE = 16,
        YingjiYinS = 32,
        /*
        DongchaYinY = 64,
        DongchaYinE = 128,
        DongchaYinS = 256,

        PojiaYinY = 512,
        PojiaYinE = 1024,
        PojiaYinS = 2048,

        JiantaYinY = 4096,
        JiantaYinE = 8192,
        JiantaYinS = 16384,

        ZhenjiYinY = 32768,
        ZhenjiYinE = 65536,
        ZhenjiYinS = 131072,

        GangyiYinY = 262144,
        GangyiYinE = 524288,
        GangyiYinS = 1048576,

        TongkuYinY = 2097152,
        TongkuYinE = 4194304,
        TongkuYinS = 8388608,

        YuheYinY = 16777216,
        YuheYinE = 33554432,
        YuheYinS = 67108864,

        JianbiYinY = 134217728,
        JianbiYinE = 268435456,
        JianbiYinS = 536870912,
        */
    }
   
    [Flags]
    public enum MingwenMaErshiqi
    {
        None = 0,
        /*
        ZhengjiuYinY = 1,
        ZhengjiuYinE = 2,
        ZhengjiuYinS = 4,

        ZhimingYinY = 8,
        ZhimingYinE = 16,
        ZhimingYinS = 32,

        DongchaYinY = 64,
        DongchaYinE = 128,
        DongchaYinS = 256,

        PojiaYinY = 512,
        PojiaYinE = 1024,
        PojiaYinS = 2048,

        JiantaYinY = 4096,
        JiantaYinE = 8192,
        JiantaYinS = 16384,

        ZhenjiYinY = 32768,
        ZhenjiYinE = 65536,
        ZhenjiYinS = 131072,

        GangyiYinY = 262144,
        GangyiYinE = 524288,
        GangyiYinS = 1048576,

        TongkuYinY = 2097152,
        TongkuYinE = 4194304,
        TongkuYinS = 8388608,

        YuheYinY = 16777216,
        YuheYinE = 33554432,
        YuheYinS = 67108864,

        JianbiYinY = 134217728,
        JianbiYinE = 268435456,
        JianbiYinS = 536870912,
        */
    }

    [Flags]
    public enum MingwenMaErshiba
    {
        None = 0,
        /*
        ZhengjiuYinY = 1,
        ZhengjiuYinE = 2,
        ZhengjiuYinS = 4,

        ZhimingYinY = 8,
        ZhimingYinE = 16,
        ZhimingYinS = 32,

        DongchaYinY = 64,
        DongchaYinE = 128,
        DongchaYinS = 256,

        PojiaYinY = 512,
        PojiaYinE = 1024,
        PojiaYinS = 2048,

        JiantaYinY = 4096,
        JiantaYinE = 8192,
        JiantaYinS = 16384,

        ZhenjiYinY = 32768,
        ZhenjiYinE = 65536,
        ZhenjiYinS = 131072,

        GangyiYinY = 262144,
        GangyiYinE = 524288,
        GangyiYinS = 1048576,

        TongkuYinY = 2097152,
        TongkuYinE = 4194304,
        TongkuYinS = 8388608,

        YuheYinY = 16777216,
        YuheYinE = 33554432,
        YuheYinS = 67108864,

        JianbiYinY = 134217728,
        JianbiYinE = 268435456,
        JianbiYinS = 536870912,
        */
    }

    [Flags]
    public enum MingwenMaErshijiu
    {
        None = 0,
        /*
        ZhengjiuYinY = 1,
        ZhengjiuYinE = 2,
        ZhengjiuYinS = 4,

        ZhimingYinY = 8,
        ZhimingYinE = 16,
        ZhimingYinS = 32,

        DongchaYinY = 64,
        DongchaYinE = 128,
        DongchaYinS = 256,

        PojiaYinY = 512,
        PojiaYinE = 1024,
        PojiaYinS = 2048,

        JiantaYinY = 4096,
        JiantaYinE = 8192,
        JiantaYinS = 16384,

        ZhenjiYinY = 32768,
        ZhenjiYinE = 65536,
        ZhenjiYinS = 131072,

        GangyiYinY = 262144,
        GangyiYinE = 524288,
        GangyiYinS = 1048576,

        TongkuYinY = 2097152,
        TongkuYinE = 4194304,
        TongkuYinS = 8388608,

        YuheYinY = 16777216,
        YuheYinE = 33554432,
        YuheYinS = 67108864,

        JianbiYinY = 134217728,
        JianbiYinE = 268435456,
        JianbiYinS = 536870912,
        */
    }

    [Flags]
    public enum MingwenMaSanshi
    {
        None = 0,
        /*
        ZhengjiuYinY = 1,
        ZhengjiuYinE = 2,
        ZhengjiuYinS = 4,

        ZhimingYinY = 8,
        ZhimingYinE = 16,
        ZhimingYinS = 32,

        DongchaYinY = 64,
        DongchaYinE = 128,
        DongchaYinS = 256,

        PojiaYinY = 512,
        PojiaYinE = 1024,
        PojiaYinS = 2048,

        JiantaYinY = 4096,
        JiantaYinE = 8192,
        JiantaYinS = 16384,

        ZhenjiYinY = 32768,
        ZhenjiYinE = 65536,
        ZhenjiYinS = 131072,

        GangyiYinY = 262144,
        GangyiYinE = 524288,
        GangyiYinS = 1048576,

        TongkuYinY = 2097152,
        TongkuYinE = 4194304,
        TongkuYinS = 8388608,

        YuheYinY = 16777216,
        YuheYinE = 33554432,
        YuheYinS = 67108864,

        JianbiYinY = 134217728,
        JianbiYinE = 268435456,
        JianbiYinS = 536870912,
        */
    }


    public enum AutoSetConf
    {
        None = 0,
        SuijisBox = 1,
        SetShiftBox = 2,
        SetDisplayBox = 3,
        SetBrightBox = 4,
        SetCorpseBox = 5,
        SetFlamingSwordBox = 6,
        SetDragobRiseBox = 7,
        SetBladeStormBox = 8,
        SetMagicShieldBox = 9,
        SetRenounceBox = 10,
        SetPoisonDustBox = 11,
        SetCelestialBox = 12,
        SetFourFlowersBox = 13,
        SetMagicskillsBox = 14,
        SetMagicskills1Box = 15,
        SetAutoOnHookBox = 16,
        SuijiBox = 17,
        SetAutoPoisonBox = 18,
        SetAutoAvoidBox = 19,
        SetDeathResurrectionBox = 20,
        SetSingleHookSkillsBox = 21,
        SetGroupHookSkillsBox = 22,
        SetSummoningSkillsBox = 23,
        SetRandomItemBox = 24,
        SetHomeItemBox = 25,
        SetDefianceBox = 27,
        SetMightBox = 28,
        SetShowHealth = 29,
        SetEvasionBox = 30,
        SerRagingWindBox = 31,
        SetJsPickUpBox = 32,
        Kuaisuxiaotui = 33,
        SetAutojinpiaoBox = 34,
        SetMaxConf = 35,
    }


    public enum HorseType : byte
    {
        None,
        Brown,
        White,
        Red,
        Black,
        WhiteUni,
        RedUni,
        Dark,
        Blue,
        ArmBrown,
        ArmWhite,
        ArmRed,
        ArmBlack,
        SnowLion,
        MountainLion
    }

    [Flags]
    public enum GuildPermission
    {
        None = 0,

        Leader = -1,

        EditNotice = 1,
        AddMember = 2,
        RemoveMember = 4,
        Storage = 8,
        FundsRepair = 16,
        FundsMerchant = 32,
        FundsMarket = 64,
        StartWar = 128,
    }

    [Flags]
    public enum QuestIcon
    {
        None = 0,

        NewQuest = 1,
        QuestIncomplete = 2,
        QuestComplete = 4,


        NewRepeatable = 8,
        RepeatableComplete = 16,
    }

    
    public enum CraftType
    {
        Smithing,
        Clothing,
        Jewelry,
        Consumables,
        Rusted
    }

    public enum MovementEffect
    {
        None = 0,

        SpecialRepair = 1,
    }

    public enum SpellKey : byte    
    {
        None,

        [Description("F1")]
        Spell01,
        [Description("F2")]
        Spell02,
        [Description("F3")]
        Spell03,
        [Description("F4")]
        Spell04,
        [Description("F5")]
        Spell05,
        [Description("F6")]
        Spell06,
        [Description("F7")]
        Spell07,
        [Description("F8")]
        Spell08,
        [Description("F9")]
        Spell09,
        [Description("F10")]
        Spell10,
        [Description("F11")]
        Spell11,
        [Description("F12")]
        Spell12,

        [Description("F1")]
        Spell13,
        [Description("F2")]
        Spell14,
        [Description("F3")]
        Spell15,
        [Description("F4")]
        Spell16,
        [Description("F5")]
        Spell17,
        [Description("F6")]
        Spell18,
        [Description("F7")]
        Spell19,
        [Description("F8")]
        Spell20,
        [Description("F9")]
        Spell21,
        [Description("F10")]
        Spell22,
        [Description("F11")]
        Spell23,
        [Description("F12")]
        Spell24,
    }

    public enum MonsterFlag
    {
        None = 0,

        Skeleton = 1,
        JinSkeleton = 2,
        Shinsu = 3,
        InfernalSoldier = 4,
        Scarecrow = 5,

        SummonPuppet = 6,

        MirrorImage = 7,

        HongyueYi = 8,
        HongyueEr = 9,
        HongyueSan = 10,

        HuoyanYi = 11,
        HuoyanEr = 12,

        JunwangYi = 13,
        JunwangEr = 14,
        JunwangSan = 15,
        ToutianYi = 16,
        ToutianEr = 17,
        ToutianSan = 18,
        JialanYi = 19,
        JialanEr = 20,
        JialanSan = 21,
        LingShouYi = 22,
        LingShouEr = 23,
        LingShouSan = 24,
        XueShouYi = 25,
        XueShouEr = 26,
        XueShouSan = 27,
        ShengShouYi = 28,
        ShengShouEr = 29,
        ShengShouSan = 30,
        ChaoJunwangYi = 31,
        ChaoJunwangEr = 32,
        ChaoJunwangSan = 33,
        ChaoToutianYi = 34,
        ChaoToutianEr = 35,
        ChaoToutianSan = 36,
        ChaoJialanYi = 37,
        ChaoJialanEr = 38,
        ChaoJialanSan = 39,

        HuoyanSan = 40,

        ZhenqiangYi = 41,
        ZhenqiangEr = 42,
        ZhenqiangSan = 43,


        Larva = 100,

        LesserWedgeMoth = 110,

        ZumaArcherMonster = 120,
        ZumaGuardianMonster = 121,
        ZumaFanaticMonster = 122,
        ZumaKeeperMonster = 123,

        BoneArcher = 130,
        BoneCaptain = 131,
        BoneBladesman = 132,
        BoneSoldier = 133,
        SkeletonEnforcer = 134,

        MatureEarwig = 140,
        GoldenArmouredBeetle = 141,
        Millipede = 142,

        FerociousFlameDemon = 150,
        FlameDemon = 151,

        GoruSpearman = 160,
        GoruArcher = 161,
        GoruGeneral = 162,

        DragonLord = 170,
        OYoungBeast = 171,
        YumgonWitch = 172,
        MaWarden = 173,
        MaWarlord = 174,
        JinhwanSpirit = 175,
        JinhwanGuardian = 176,
        OyoungGeneral = 177,
        YumgonGeneral = 178,

        BanyoCaptain = 180,

        SamaSorcerer = 190,
        BloodStone = 191,

        QuartzPinkBat = 200,
        QuartzBlueBat = 201,
        QuartzBlueCrystal = 202,
        QuartzRedHood = 203,
        QuartzMiniTurtle = 204,
        QuartzTurtleSub = 205,

        Sacrafice = 210,

        HellishBat = 211,

        HaidiGuicha = 212,
        HaidiFengjing = 213,
        HaidiMoling = 214,
        HaidiPixia = 215,

    }

    #region Packet Enums

    public enum NewAccountResult : byte
    {
        Disabled,
        BadEMail,
        BadPassword,
        BadRealName,
        AlreadyExists,
        BadReferral,
        ReferralNotFound,
        ReferralNotActivated,
        Success
    }

    public enum ChangePasswordResult : byte
    {
        Disabled,
        BadEMail,
        BadCurrentPassword,
        BadNewPassword,
        AccountNotFound,
        AccountNotActivated,
        WrongPassword,
        Banned,
        Success
    }
    public enum RequestPasswordResetResult : byte
    {
        Disabled,
        BadEMail,
        AccountNotFound,
        AccountNotActivated,
        ResetDelay,
        Banned,
        Success
    }
    public enum ResetPasswordResult : byte
    {
        Disabled,
        AccountNotFound,
        BadNewPassword,
        KeyExpired,
        Success
    }


    public enum ActivationResult : byte
    {
        Disabled,
        AccountNotFound,
        Success,
    }

    public enum RequestActivationKeyResult : byte
    {
        Disabled,
        BadEMail,
        AccountNotFound,
        AlreadyActivated,
        RequestDelay,
        Success,
    }

    public enum LoginResult : byte
    {
        Disabled,
        BadEMail,
        BadPassword,
        AccountNotExists,
        AccountNotActivated,
        WrongPassword,
        Banned,
        AlreadyLoggedIn,
        AlreadyLoggedInPassword,
        AlreadyLoggedInAdmin,
        Success
    }

    public enum NewCharacterResult : byte
    {
        Disabled,
        BadCharacterName,
        BadGender,
        BadClass,
        BadHairType,
        BadHairColour,
        BadArmourColour,
        ClassDisabled,
        MaxCharacters,
        AlreadyExists,
        Success
    }

    public enum DeleteCharacterResult : byte
    {
        Disabled,
        AlreadyDeleted,
        NotFound,
        Success
    }

    public enum StartGameResult : byte
    {
        Disabled,
        Deleted,
        Delayed,
        UnableToSpawn,
        NotFound,
        Success
    }

    public enum DisconnectReason : byte
    {
        Unknown,
        TimedOut,
        WrongVersion,
        ServerClosing,
        AnotherUser,
        AnotherUserPassword,
        AnotherUserAdmin,
        Banned,
        Crashed,
        TestGJAnswerFail,
    }




    #endregion

    #region Sound

    public enum SoundIndex     
    {
        None,
        LoginScene,
        SelectScene,

        
        B000,
        B2,
        B8,
        B009D,
        B009N,
        B0014D,
        B0014N,
        B100,
        B122,
        B300,
        B400,
        B14001,
        BD00,
        BD01,
        BD02,
        BD041,
        BD042,
        BD50,
        BD60,
        BD70,
        BD99,
        BD100,
        BD101,
        BD210,
        BD211,
        BDUnderseaCave,
        BDUnderseaCaveBoss,
        D3101,
        D3102,
        D3400,
        Dungeon_1,
        Dungeon_2,
        ID1_001,
        ID1_002,
        ID1_003,
        TS001,
        TS002,
        TS003,

        ButtonA,
        ButtonB,
        ButtonC,

        SelectWarriorMale,
        SelectWarriorFemale,
        SelectWizardMale,
        SelectWizardFemale,
        SelectTaoistMale,
        SelectTaoistFemale,
        SelectAssassinMale,
        SelectAssassinFemale,

        TeleportOut,
        TeleportIn,

        ItemPotion,
        ItemWeapon,
        ItemArmour,
        ItemRing,
        ItemBracelet,
        ItemNecklace,
        ItemHelmet,
        ItemShoes,
        ItemDefault,

        GoldPickUp,
        GoldGained,

        DaggerSwing,
        WoodSwing,
        IronSwordSwing,
        ShortSwordSwing,
        AxeSwing,
        ClubSwing,
        WandSwing,
        FistSwing,
        GlaiveAttack,
        ClawAttack,

        GenericStruckPlayer,
        GenericStruckMonster,

        Foot1,
        Foot2,
        Foot3,
        Foot4,
        HorseWalk1,
        HorseWalk2,
        HorseRun,

        MaleStruck,
        FemaleStruck,

        MaleDie,
        FemaleDie,

        #region Magics

        SlayingMale,
        SlayingFemale,

        EnergyBlast,

        HalfMoon,

        FlamingSword,

        DragonRise,

        BladeStorm,

        DestructiveBlow,

        DefianceStart,

        AssaultStart,

        SwiftBladeEnd,


        FireBallStart,
        FireBallTravel,
        FireBallEnd,

        ThunderBoltStart,
        ThunderBoltTravel,
        ThunderBoltEnd,

        IceBoltStart,
        IceBoltTravel,
        IceBoltEnd,

        GustBlastStart,
        GustBlastTravel,
        GustBlastEnd,

        RepulsionEnd,

        ElectricShockStart,
        ElectricShockEnd,

        GreaterFireBallStart,
        GreaterFireBallTravel,
        GreaterFireBallEnd,

        LightningStrikeStart,
        LightningStrikeEnd,

        GreaterIceBoltStart,
        GreaterIceBoltTravel,
        GreaterIceBoltEnd,

        CycloneStart,
        CycloneEnd,

        TeleportationStart,

        LavaStrikeStart,
        

        LightningBeamEnd,


        FrozenEarthStart,
        FrozenEarthEnd,

        BlowEarthStart,
        BlowEarthEnd,
        BlowEarthTravel,

        FireWallStart,
        FireWallEnd,

        ExpelUndeadStart,
        ExpelUndeadEnd,

        MagicShieldStart,

        FireStormStart,
        FireStormEnd,

        LightningWaveStart,
        LightningWaveEnd,

        IceStormStart,
        IceStormEnd,

        DragonTornadoStart,
        DragonTornadoEnd,

        GreaterFrozenEarthStart,
        GreaterFrozenEarthEnd,

        ChainLightningStart,
        ChainLightningEnd,

        FrostBiteStart,


        HealStart,
        HealEnd,

        PoisonDustStart,
        PoisonDustEnd,

        ExplosiveTalismanStart,
        ExplosiveTalismanTravel,
        ExplosiveTalismanEnd,

        HolyStrikeStart,
        HolyStrikeTravel,
        HolyStrikeEnd,

        ImprovedHolyStrikeStart,
        ImprovedHolyStrikeTravel,
        ImprovedHolyStrikeEnd,

        MagicResistanceTravel,
        MagicResistanceEnd,

        ResilienceTravel,
        ResilienceEnd,

        ShacklingTalismanStart,
        ShacklingTalismanEnd,

        SummonSkeletonStart,
        SummonSkeletonEnd,

        InvisibilityEnd,

        MassInvisibilityTravel,
        MassInvisibilityEnd,

        TaoistCombatKickStart,

        MassHealStart,
        MassHealEnd,

        BloodLustTravel,
        BloodLustEnd,

        ResurrectionStart,

        PurificationStart,
        PurificationEnd,

        SummonShinsuStart,
        SummonShinsuEnd,

        StrengthOfFaithStart,
        StrengthOfFaithEnd,

        NeutralizeEnd,


        PoisonousCloudStart,

        CloakStart,

        WraithGripStart,
        WraithGripEnd,

        HellFireStart,

        FullBloom,
        WhiteLotus,
        RedLotus,
        SweetBrier,
        SweetBrierMale,
        SweetBrierFemale,

        Karma,

        TheNewBeginning,

        SummonPuppet,

        DanceOfSwallowsEnd,
        DragonRepulseStart,
        AbyssStart,
        FlashOfLightEnd,
        EvasionStart,
        RagingWindStart,
        Concentration,

        #endregion

        #region Monsters

        ChickenAttack,
        ChickenStruck,
        ChickenDie,

        PigAttack,
        PigStruck,
        PigDie,

        DeerAttack,
        DeerStruck,
        DeerDie,

        CowAttack,
        CowStruck,
        CowDie,

        SheepAttack,
        SheepStruck,
        SheepDie,

        ClawCatAttack,
        ClawCatStruck,
        ClawCatDie,

        WolfAttack,
        WolfStruck,
        WolfDie,

        ForestYetiAttack,
        ForestYetiStruck,
        ForestYetiDie,

        CarnivorousPlantAttack,
        CarnivorousPlantStruck,
        CarnivorousPlantDie,

        OmaAttack,
        OmaStruck,
        OmaDie,

        TigerSnakeAttack,
        TigerSnakeStruck,
        TigerSnakeDie,

        SpittingSpiderAttack,
        SpittingSpiderStruck,
        SpittingSpiderDie,

        ScarecrowAttack,
        ScarecrowStruck,
        ScarecrowDie,

        OmaHeroAttack,
        OmaHeroStruck,
        OmaHeroDie,

        CaveBatAttack,
        CaveBatStruck,
        CaveBatDie,

        ScorpionAttack,
        ScorpionStruck,
        ScorpionDie,

        SkeletonAttack,
        SkeletonStruck,
        SkeletonDie,

        SkeletonAxeManAttack,
        SkeletonAxeManStruck,
        SkeletonAxeManDie,

        SkeletonAxeThrowerAttack,
        SkeletonAxeThrowerStruck,
        SkeletonAxeThrowerDie,

        SkeletonWarriorAttack,
        SkeletonWarriorStruck,
        SkeletonWarriorDie,

        SkeletonLordAttack,
        SkeletonLordStruck,
        SkeletonLordDie,

        CaveMaggotAttack,
        CaveMaggotStruck,
        CaveMaggotDie,

        GhostSorcererAttack,
        GhostSorcererStruck,
        GhostSorcererDie,

        GhostMageAppear,
        GhostMageAttack,
        GhostMageStruck,
        GhostMageDie,

        VoraciousGhostAttack,
        VoraciousGhostStruck,
        VoraciousGhostDie,

        GhoulChampionAttack,
        GhoulChampionStruck,
        GhoulChampionDie,

        ArmoredAntAttack,
        ArmoredAntStruck,
        ArmoredAntDie,

        AntNeedlerAttack,
        AntNeedlerStruck,
        AntNeedlerDie,


        KeratoidAttack,
        KeratoidStruck,
        KeratoidDie,

        ShellNipperAttack,
        ShellNipperStruck,
        ShellNipperDie,

        VisceralWormAttack,
        VisceralWormStruck,
        VisceralWormDie,


        MutantFleaAttack,
        MutantFleaStruck,
        MutantFleaDie,

        PoisonousMutantFleaAttack,
        PoisonousMutantFleaStruck,
        PoisonousMutantFleaDie,

        BlasterMutantFleaAttack,
        BlasterMutantFleaStruck,
        BlasterMutantFleaDie,


        WasHatchlingAttack,
        WasHatchlingStruck,
        WasHatchlingDie,

        CentipedeAttack,
        CentipedeStruck,
        CentipedeDie,

        ButterflyWormAttack,
        ButterflyWormStruck,
        ButterflyWormDie,

        MutantMaggotAttack,
        MutantMaggotStruck,
        MutantMaggotDie,

        EarwigAttack,
        EarwigStruck,
        EarwigDie,

        IronLanceAttack,
        IronLanceStruck,
        IronLanceDie,

        LordNiJaeAttack,
        LordNiJaeStruck,
        LordNiJaeDie,

        RottingGhoulAttack,
        RottingGhoulStruck,
        RottingGhoulDie,

        DecayingGhoulAttack,
        DecayingGhoulStruck,
        DecayingGhoulDie,

        BloodThirstyGhoulAttack,
        BloodThirstyGhoulStruck,
        BloodThirstyGhoulDie,


        SpinedDarkLizardAttack,
        SpinedDarkLizardStruck,
        SpinedDarkLizardDie,

        UmaInfidelAttack,
        UmaInfidelStruck,
        UmaInfidelDie,

        UmaFlameThrowerAttack,
        UmaFlameThrowerStruck,
        UmaFlameThrowerDie,

        UmaAnguisherAttack,
        UmaAnguisherStruck,
        UmaAnguisherDie,

        UmaKingAttack,
        UmaKingStruck,
        UmaKingDie,

        SpiderBatAttack,
        SpiderBatStruck,
        SpiderBatDie,

        ArachnidGazerStruck,
        ArachnidGazerDie,

        LarvaAttack,
        LarvaStruck,

        RedMoonGuardianAttack,
        RedMoonGuardianStruck,
        RedMoonGuardianDie,

        RedMoonProtectorAttack,
        RedMoonProtectorStruck,
        RedMoonProtectorDie,

        VenomousArachnidAttack,
        VenomousArachnidStruck,
        VenomousArachnidDie,

        DarkArachnidAttack,
        DarkArachnidStruck,
        DarkArachnidDie,

        RedMoonTheFallenAttack,
        RedMoonTheFallenStruck,
        RedMoonTheFallenDie,


        ViciousRatAttack,
        ViciousRatStruck,
        ViciousRatDie,

        ZumaSharpShooterAttack,
        ZumaSharpShooterStruck,
        ZumaSharpShooterDie,

        ZumaFanaticAttack,
        ZumaFanaticStruck,
        ZumaFanaticDie,

        ZumaGuardianAttack,
        ZumaGuardianStruck,
        ZumaGuardianDie,

        ZumaKingAppear,
        ZumaKingAttack,
        ZumaKingStruck,
        ZumaKingDie,

        EvilFanaticAttack,
        EvilFanaticStruck,
        EvilFanaticDie,

        MonkeyAttack,
        MonkeyStruck,
        MonkeyDie,

        EvilElephantAttack,
        EvilElephantStruck,
        EvilElephantDie,

        CannibalFanaticAttack,
        CannibalFanaticStruck,
        CannibalFanaticDie,

        SpikedBeetleAttack,
        SpikedBeetleStruck,
        SpikedBeetleDie,

        NumaGruntAttack,
        NumaGruntStruck,
        NumaGruntDie,

        NumaMageAttack,
        NumaMageStruck,
        NumaMageDie,

        NumaEliteAttack,
        NumaEliteStruck,
        NumaEliteDie,

        SandSharkAttack,
        SandSharkStruck,
        SandSharkDie,

        StoneGolemAppear,
        StoneGolemAttack,
        StoneGolemStruck,
        StoneGolemDie,

        WindfurySorceressAttack,
        WindfurySorceressStruck,
        WindfurySorceressDie,

        CursedCactusAttack,
        CursedCactusStruck,
        CursedCactusDie,

        RagingLizardAttack,
        RagingLizardStruck,
        RagingLizardDie,

        SawToothLizardAttack,
        SawToothLizardStruck,
        SawToothLizardDie,

        MutantLizardAttack,
        MutantLizardStruck,
        MutantLizardDie,

        VenomSpitterAttack,
        VenomSpitterStruck,
        VenomSpitterDie,

        SonicLizardAttack,
        SonicLizardStruck,
        SonicLizardDie,

        GiantLizardAttack,
        GiantLizardStruck,
        GiantLizardDie,

        CrazedLizardAttack,
        CrazedLizardStruck,
        CrazedLizardDie,

        TaintedTerrorAttack,
        TaintedTerrorStruck,
        TaintedTerrorDie,
        TaintedTerrorAttack2,

        DeathLordJichonAttack,
        DeathLordJichonStruck,
        DeathLordJichonDie,
        DeathLordJichonAttack2,
        DeathLordJichonAttack3,


        MinotaurAttack,
        MinotaurStruck,
        MinotaurDie,

        FrostMinotaurAttack,
        FrostMinotaurStruck,
        FrostMinotaurDie,

        BanyaLeftGuardAttack,
        BanyaLeftGuardStruck,
        BanyaLeftGuardDie,

        EmperorSaWooAttack,
        EmperorSaWooStruck,
        EmperorSaWooDie,



        BoneArcherAttack,
        BoneArcherStruck,
        BoneArcherDie,

        BoneCaptainAttack,
        BoneCaptainStruck,
        BoneCaptainDie,

        ArchLichTaeduAttack,
        ArchLichTaeduStruck,
        ArchLichTaeduDie,

        WedgeMothLarvaAttack,
        WedgeMothLarvaStruck,
        WedgeMothLarvaDie,

        LesserWedgeMothAttack,
        LesserWedgeMothStruck,
        LesserWedgeMothDie,

        WedgeMothAttack,
        WedgeMothStruck,
        WedgeMothDie,

        RedBoarAttack,
        RedBoarStruck,
        RedBoarDie,

        ClawSerpentAttack,
        ClawSerpentStruck,
        ClawSerpentDie,

        BlackBoarAttack,
        BlackBoarStruck,
        BlackBoarDie,

        TuskLordAttack,
        TuskLordStruck,
        TuskLordDie,

        RazorTuskAttack,
        RazorTuskStruck,
        RazorTuskDie,


        PinkGoddessAttack,
        PinkGoddessStruck,
        PinkGoddessDie,

        GreenGoddessAttack,
        GreenGoddessStruck,
        GreenGoddessDie,

        MutantCaptainAttack,
        MutantCaptainStruck,
        MutantCaptainDie,

        StoneGriffinAttack,
        StoneGriffinStruck,
        StoneGriffinDie,

        FlameGriffinAttack,
        FlameGriffinStruck,
        FlameGriffinDie,

        WhiteBoneAttack,
        WhiteBoneStruck,
        WhiteBoneDie,

        ShinsuSmallStruck,
        ShinsuSmallDie,

        ShinsuBigAttack,
        ShinsuBigStruck,
        ShinsuBigDie,

        ShinsuShow,


        CorpseStalkerAttack,
        CorpseStalkerStruck,
        CorpseStalkerDie,

        LightArmedSoldierAttack,
        LightArmedSoldierStruck,
        LightArmedSoldierDie,

        CorrosivePoisonSpitterAttack,
        CorrosivePoisonSpitterStruck,
        CorrosivePoisonSpitterDie,

        PhantomSoldierAttack,
        PhantomSoldierStruck,
        PhantomSoldierDie,

        MutatedOctopusAttack,
        MutatedOctopusStruck,
        MutatedOctopusDie,

        AquaLizardAttack,
        AquaLizardStruck,
        AquaLizardDie,


        CrimsonNecromancerAttack,
        CrimsonNecromancerStruck,
        CrimsonNecromancerDie,

        ChaosKnightAttack,
        ChaosKnightStruck,
        ChaosKnightDie,

        PachontheChaosbringerAttack,
        PachontheChaosbringerStruck,
        PachontheChaosbringerDie,


        NumaCavalryAttack,
        NumaCavalryStruck,
        NumaCavalryDie,

        NumaHighMageAttack,
        NumaHighMageStruck,
        NumaHighMageDie,

        NumaStoneThrowerAttack,
        NumaStoneThrowerStruck,
        NumaStoneThrowerDie,

        NumaRoyalGuardAttack,
        NumaRoyalGuardStruck,
        NumaRoyalGuardDie,

        NumaArmoredSoldierAttack,
        NumaArmoredSoldierStruck,
        NumaArmoredSoldierDie,



        IcyRangerAttack,
        IcyRangerStruck,
        IcyRangerDie,

        IcyGoddessAttack,
        IcyGoddessStruck,
        IcyGoddessDie,

        IcySpiritWarriorAttack,
        IcySpiritWarriorStruck,
        IcySpiritWarriorDie,

        IcySpiritGeneralAttack,
        IcySpiritGeneralStruck,
        IcySpiritGeneralDie,

        GhostKnightAttack,
        GhostKnightStruck,
        GhostKnightDie,

        IcySpiritSpearmanAttack,
        IcySpiritSpearmanStruck,
        IcySpiritSpearmanDie,

        WerewolfAttack,
        WerewolfStruck,
        WerewolfDie,

        WhitefangAttack,
        WhitefangStruck,
        WhitefangDie,

        IcySpiritSoliderAttack,
        IcySpiritSoliderStruck,
        IcySpiritSoliderDie,

        WildBoarAttack,
        WildBoarStruck,
        WildBoarDie,

        FrostLordHwaAttack,
        FrostLordHwaStruck,
        FrostLordHwaDie,

        JinchonDevilAttack,
        JinchonDevilAttack2,
        JinchonDevilAttack3,
        JinchonDevilStruck,
        JinchonDevilDie,

        EscortCommanderAttack,
        EscortCommanderStruck,
        EscortCommanderDie,

        FieryDancerAttack,
        FieryDancerStruck,
        FieryDancerDie,

        EmeraldDancerAttack,
        EmeraldDancerStruck,
        EmeraldDancerDie,

        QueenOfDawnAttack,
        QueenOfDawnStruck,
        QueenOfDawnDie,



        OYoungBeastAttack,
        OYoungBeastStruck,
        OYoungBeastDie,

        YumgonWitchAttack,
        YumgonWitchStruck,
        YumgonWitchDie,

        MaWarlordAttack,
        MaWarlordStruck,
        MaWarlordDie,

        JinhwanSpiritAttack,
        JinhwanSpiritStruck,
        JinhwanSpiritDie,

        JinhwanGuardianAttack,
        JinhwanGuardianStruck,
        JinhwanGuardianDie,

        YumgonGeneralAttack,
        YumgonGeneralStruck,
        YumgonGeneralDie,

        ChiwooGeneralAttack,
        ChiwooGeneralStruck,
        ChiwooGeneralDie,

        DragonQueenAttack,
        DragonQueenStruck,
        DragonQueenDie,

        DragonLordAttack,
        DragonLordStruck,
        DragonLordDie,

        FerociousIceTigerAttack,
        FerociousIceTigerStruck,
        FerociousIceTigerDie,



        SamaFireGuardianAttack,
        SamaFireGuardianStruck,
        SamaFireGuardianDie,

        SamaIceGuardianAttack,
        SamaIceGuardianStruck,
        SamaIceGuardianDie,

        SamaLightningGuardianAttack,
        SamaLightningGuardianStruck,
        SamaLightningGuardianDie,

        SamaWindGuardianAttack,
        SamaWindGuardianStruck,
        SamaWindGuardianDie,


        PhoenixAttack,
        PhoenixStruck,
        PhoenixDie,

        BlackTortoiseAttack,
        BlackTortoiseStruck,
        BlackTortoiseDie,

        BlueDragonAttack,
        BlueDragonStruck,
        BlueDragonDie,

        WhiteTigerAttack,
        WhiteTigerStruck,
        WhiteTigerDie,




        #endregion

        ThunderKickEnd,

        ThunderKickStart,
        RakeStart,

        CrazedPrimateAttack,
        CrazedPrimateStruck,
        CrazedPrimateDie,
        HellBringerAttack,
        HellBringerAttack2,
        HellBringerAttack3,
        HellBringerStruck,
        HellBringerDie,
        YurinHoundAttack,
        YurinHoundStruck,
        YurinHoundDie,
        YurinTigerAttack,
        YurinTigerStruck,
        YurinTigerDie,
        HardenedRhinoAttack,
        HardenedRhinoStruck,
        HardenedRhinoDie,
        MammothAttack,
        MammothStruck,
        MammothDie,
        CursedSlave1Attack,
        CursedSlave1Attack2,
        CursedSlave1Struck,
        CursedSlave1Die,
        CursedSlave2Attack,
        CursedSlave2Struck,
        CursedSlave2Die,
        CursedSlave3Attack,
        CursedSlave3Attack2,
        CursedSlave3Struck,
        CursedSlave3Die,
        PoisonousGolemAttack,
        PoisonousGolemAttack2,
        PoisonousGolemStruck,
        PoisonousGolemDie,

        ElementalHurricane,
        DarkSoulPrison,

        GardenSoldierAttack,
        GardenSoldierAttack2,
        GardenSoldierStruck,
        GardenSoldierDie,

        GardenDefenderAttack,
        GardenDefenderAttack2,
        GardenDefenderStruck,
        GardenDefenderDie,

        RedBlossomAttack,
        RedBlossomAttack2,
        RedBlossomStruck,
        RedBlossomDie,

        BlueBlossomAttack,
        BlueBlossomStruck,
        BlueBlossomDie,

        FireBirdAttack,
        FireBirdAttack2,
        FireBirdAttack3,
        FireBirdStruck,
        FireBirdDie,

        
        WolongbianfuAttack,
        WolongbianfuAttack2,
        WolongbianfuStruck,
        WolongbianfuDie,

        
        OmaKingAttack,
        OmaKingAttack2,
        OmaKingStruck,
        OmaKingDie,

        
        WuguiAttack,
        WuguiAttack2,
        WuguiStruck,
        WuguiDie,


    }
    #endregion

    
    /*
    public enum MirGender : byte    
    {
        Male,
        Female,
    }

    public enum MirClass : byte       
    {
        Warrior,
        Wizard,
        Taoist,
        Assassin,
    }

    public enum AttackMode : byte         
    {
        Peace,
        Group,
        Guild,
        WarRedBrown,
        All
    }

    public enum PetMode : byte              
    {
        Both,
        Move,
        Attack,
        PvP,
        None,
    }

    public enum MirDirection : byte         
    {
        Up = 0,
        UpRight = 1,
        Right = 2,
        DownRight = 3,
        Down = 4,
        DownLeft = 5,
        Left = 6,
        UpLeft = 7
    }

    [Flags]
    public enum RequiredClass : byte  
    {
        None = 0,
        Warrior = 1,
        Wizard = 2,
        Taoist = 4,
        Assassin = 8,
        WarWizTao = Warrior | Wizard | Taoist,
        WizTao = Wizard | Taoist,
        AssWar = Warrior | Assassin,
        All = WarWizTao | Assassin


    }

    [Flags]
    public enum RequiredGender : byte   
    {

        Male = 1,
        Female = 2,
        None = Male | Female,

    }

    public enum EquipmentSlot         
    {
        Weapon = 0,                   
        Armour = 1,                   
        Helmet = 2,                   
        Torch = 3,                    
        Necklace = 4,                 
        BraceletL = 5,                
        BraceletR = 6,                
        RingL = 7,                    
        RingR = 8,                    
        Shoes = 9,                    
        Poison = 10,                  
        Amulet = 11,                  
        Flower = 12,                  
        HorseArmour = 13,             
        Emblem = 14,                  
        Shield = 15,                  
        SwChenghao = 16,              
        Shizhuang = 17,               
        Fabao = 18,                   
    }

    public enum CompanionSlot        
    {
        Bag = 0,                     
        Head = 1,                    
        Back = 2,                    
        Food = 3,                    
    }


    public enum GridType
    {
        None,
        Inventory,
        Equipment,
        Belt,
        Sell,
        Repair,
        Storage,
        AutoPotion,
        RefineBlackIronOre,
        RefineAccessory,
        RefineSpecial,
        Inspect,
        Consign,
        SendMail,
        TradeUser,
        TradePlayer,
        GuildStorage,
        CompanionInventory,
        CompanionEquipment,
        WeddingRing,
        RefinementStoneIronOre,
        RefinementStoneSilverOre,
        RefinementStoneDiamond,
        RefinementStoneGoldOre,
        RefinementStoneCrystal,
        ItemFragment,
        AccessoryRefineUpgradeTarget,
        AccessoryRefineLevelTarget,
        AccessoryRefineLevelItems,
        MasterRefineFragment1,
        MasterRefineFragment2,
        MasterRefineFragment3,
        MasterRefineStone,
        MasterRefineSpecial,
        AccessoryReset,
        WeaponCraftTemplate,
        WeaponCraftYellow,
        WeaponCraftBlue,
        WeaponCraftRed,
        WeaponCraftPurple,
        WeaponCraftGreen,
        WeaponCraftGrey,
        XiangKanGJST,
        XiangKanGJSTItems,
        XiangKanGJBST,
        XiangKanGJBSTItems,
        XiangKanZRST,
        XiangKanZRSTItems,
        XiangKanZRBST,
        XiangKanZRBSTItems,
        XiangKanLHST,
        XiangKanLHSTItems,
        XiangKanLHBST,
        XiangKanLHBSTItems,
        XiangKanSMST,
        XiangKanSMSTItems,
        XiangKanMFST,
        XiangKanMFSTItems,
        XiangKanSDST,
        XiangKanSDSTItems,
        XiangKanFYST,
        XiangKanFYSTItems,
        XiangKanMYST,
        XiangKanMYSTItems,
        GZLKaikong,
        GZLKaikongItems,
        GZLBKaikong,
        GZLBKaikongItems,
        QTKaikong,
        QTKaikongItems,
        Chaichust,
        Chaichustitems,
        Xiangkanjyst,
        Xiangkanjystitems,
        Xiangkanxxst,
        Xiangkanxxstitems,
        XiangKanghuo,
        XiangKanghuoitems,
        XiangKangbing,
        XiangKangbingitems,
        XiangKanglei,
        XiangKangleiitems,
        XiangKangfeng,
        XiangKangfengitems,
        XiangKangshen,
        XiangKangshenitems,
        XiangKangan,
        XiangKanganitems,
        XiangKanghuan,
        XiangKanghuanitems,
        XiangKanmofadun,
        XiangKanmofadunitems,
        XiangKanbingdong,
        XiangKanbingdongitems,
        XiangKanmabi,
        XiangKanmabiitems,
        XiangKanyidong,
        XiangKanyidongitems,
        XiangKanchenmo,
        XiangKanchenmoitems,
        XiangKangedang,
        XiangKangedangitems,
        XiangKanduobi,
        XiangKanduobiitems,
        XiangKanqhuo,
        XiangKanqhuoitems,
        XiangKanqbing,
        XiangKanqbingitems,
        XiangKanqlei,
        XiangKanqleiitems,
        XiangKanqfeng,
        XiangKanqfengitems,
        XiangKanqshen,
        XiangKanqshenitems,
        XiangKanqan,
        XiangKanqanitems,
        XiangKanqhuan,
        XiangKanqhuanitems,
        XiangKanlvdu,
        XiangKanlvduitems,
        XiangKanzym,
        XiangKanzymitems,
        XiangKanmhhf,
        XiangKanmhhfitems,
        PatchGrid,
        FishingEquipment,
        Jyhuishou,
        GuildContribution,
        hechengbaoshi,  
        Huanhua,   
        Huanhuaitems,  
        duihuanbaoshi,  
        XiangKanjinglian,  
        XiangKanjinglianitems,  
        CraftItem,
        CraftIngredients,
        BaoshiItems,
        Zhongzi,
        ZhongziItems,
        DunRefineUpgradeItems,
        DunRefineLevelTarget,
        DunRefineLevelItems,
        DunRefineUpgradeTarget,
        DunReset,
        HuiRefineUpgradeItems,
        HuiRefineLevelTarget,
        HuiRefineLevelItems,
        HuiRefineUpgradeTarget,
        HuiReset,
        Mingwen, 
        MingwenItems, 
        Xiaohui,  
    }

    public enum BuffType         
    {
        None,

        Server = 1,
        HuntGold = 2,

        Observable = 3,
        Brown = 4,
        PKPoint = 5,
        PvPCurse = 6,
        Redemption = 7,
        Companion = 8,

        Castle = 9,



        ItemBuff = 10,
        ItemBuffPermanent = 11,

        Ranking = 12,
        Developer = 13,
        Veteran = 14,

        MapEffect = 15,
        Guild = 16,

        DeathDrops = 17,

        Defiance = 100,
        Might = 101,
        Endurance = 102,
        ReflectDamage = 103,
        Invincibility = 104,

        Renounce = 200,
        MagicShield = 201,
        JudgementOfHeaven = 202,
        SuperiorMagicShield = 203,


        Heal = 300,
        Invisibility = 301,
        MagicResistance = 302,
        Resilience = 303,
        ElementalSuperiority = 304,
        BloodLust = 305,
        StrengthOfFaith = 306,
        CelestialLight = 307,
        Transparency = 308,
        LifeSteal = 309,
        Mana = 310,

        PoisonousCloud = 400,

        FullBloom = 401,
        WhiteLotus = 402,
        RedLotus = 403,
        Cloak = 404,
        GhostWalk = 405,
        TheNewBeginning = 406,
        DarkConversion = 407,
        DragonRepulse = 408,
        Evasion = 409,
        RagingWind = 410,
        FrostBite = 411,
        ElementalHurricane = 412,
        Concentration = 413,

        MagicWeakness = 500,
        Mapplayer = 501,
        Mapmonster = 502,
        Mapnpc = 503,
        Renshu = 504,    
        BossCount = 505,
        Exp = 506,
        GoldExp = 507,
        RWBuffyi = 509,
        RWBuffer = 510,
        RWBuffsan = 511,
        RWBuffsi = 512,
        RWBuffwu = 513,
        RWBuffliu = 514,
        RWBuffqi = 515,
        RWBuffba = 516,
        RWBuffjiu = 517,
        RWBuffshi = 518,
        MonCount = 519,   
        Youliang = 520,   
        Jingzhi = 521,    
        Chuanshuo = 522,  
        Shenhua = 523,    
        GuildLv = 524,    
        GuildJiacheng = 525,    
        GuildGongxian = 526,    
        GuildPaihang = 527,    
        VipMapYi = 528,   
        VipMapEr = 529,   
        VipMapSan = 530,  
        VipMapY = 531,   
        VipMapE = 532,   
        VipMapS = 533,  
                        
                        
        KongxiangYin = 534,
        
        LifeStealHeal = 535,
        MoveSpeed = 536,
        
        
        ChongzhuangYin = 537,
        
        
        MiaoyinYin = 538,

        HuoliMassHeal = 539,
    }

    public enum RequiredType : byte  
    {
        Level,
        MaxLevel,
        AC,
        MR,
        DC,
        MC,
        SC,
        Health,
        Mana,
        Accuracy,
        Agility,
        CompanionLevel,
        MaxCompanionLevel,
        RebirthLevel,
        MaxRebirthLevel,
    }

    public enum Rarity : byte   
    {
        Common,
        Superior,
        Elite,
    }

    public enum LightSetting : byte
    {
        Default,
        Light,
        Night,
        Twilight,
    }

    public enum WeatherSetting : byte
    {
        None,
        Default,
        Fog,
        BurningFog,
    }

    public enum FightSetting : byte
    {
        None,
        Safe,
        Fight,
        Event,
    }

    public enum ObjectType : byte
    {
        None, 

        Player,
        Item,
        NPC,
        Spell,
        Monster
    }

    public enum ItemType : byte  
    {

        Nothing,
        Consumable,
        Weapon,
        Armour,
        Torch,
        Helmet,
        Necklace,
        Bracelet,
        Ring,
        Shoes,
        Poison,
        Amulet,
        Meat,
        Ore,
        Book,
        Scroll,
        DarkStone,
        RefineSpecial,
        HorseArmour,
        Flower,
        CompanionFood,
        CompanionBag,
        CompanionHead,
        CompanionBack,
        System,
        ItemPart,
        Emblem,
        Shield,
        Baoshi,
        SwChenghao,
        Shizhuang,
        Fabao,
    }

    public enum MirAction : byte
    {

        Standing,
        Moving,
        Pushed,
        Attack,
        RangeAttack,
        Spell,
        Harvest,
        
        Die,
        Dead,
        Show,
        Hide,
        Mount,
        Mining,

    }

    public enum MirAnimation : byte
    {

        Standing,
        Walking,
        CreepStanding,
        CreepWalkSlow,
        CreepWalkFast,
        Running,
        Pushed,
        Combat1,
        Combat2,
        Combat3,
        Combat4,
        Combat5,
        Combat6,
        Combat7,
        Combat8,
        Combat9,
        Combat10,
        Combat11,
        Combat12,
        Combat13,
        Combat14,
        Combat15,
        Harvest,
        Stance,
        Struck,
        Die,
        Dead,
        Skeleton,
        Show,
        Hide,
        HorseStanding,
        HorseWalking,
        HorseRunning,
        HorseStruck,
        StoneStanding,
        DragonRepulseStart,
        DragonRepulseMiddle,
        DragonRepulseEnd,
        ChannellingStart,
        ChannellingMiddle,
        ChannellingEnd,
    }


    public enum MessageAction
    {
        None,
        Revive,
    }

    public enum MessageType
    {
        Normal,
        Shout,
        WhisperIn,
        GMWhisperIn,
        WhisperOut,
        Group,
        Global,
        Hint,
        System,
        Announcement,
        Combat,
        ObserverChat,
        Guild,
        Notice,
    }

    public enum NPCDialogType
    {
        None,
        BuySell,
        Repair,
        Refine,
        RefineRetrieve,
        CompanionManage,
        WeddingRing,
        RefinementStone,
        MasterRefine,
        WeaponReset,
        ItemFragment,
        AccessoryRefineUpgrade,
        AccessoryRefineLevel,
        AccessoryReset,
        WeaponCraft,
        XiangKanGJST,
        XiangKanGJBST,
        XiangKanZRST,
        XiangKanZRBST,
        XiangKanLHST,
        XiangKanLHBST,
        XiangKanSMST,
        XiangKanMFST,
        XiangKanSDST,
        XiangKanFYST,
        XiangKanMYST,
        GZLKaikong,
        GZLBKaikong,
        QTKaikong,
        Chaichust,
        Xiangkanjyst,
        Xiangkanxxst,
        XiangKanghuo,
        XiangKangbing,
        XiangKanglei,
        XiangKangfeng,
        XiangKangshen,
        XiangKangan,
        XiangKanghuan,
        XiangKanmofadun,
        XiangKanbingdong,
        XiangKanmabi,
        XiangKanyidong,
        XiangKanchenmo,
        XiangKangedang,
        XiangKanduobi,
        XiangKanqhuo,
        XiangKanqbing,
        XiangKanqlei,
        XiangKanqfeng,
        XiangKanqshen,
        XiangKanqan,
        XiangKanqhuan,
        XiangKanlvdu,
        XiangKanzym,
        XiangKanmhhf,
        JyhuishouBox,
        NPCGuildhuishouBox,
        NPChechengbaoshi,
        Huanhua,  
        BuyBaoshi, 
        NPCduihuanbaoshi, 
        XiangKanjinglian, 
        ZaixianItemFragment,  
        Zhongzi,  
        BuyGSell, 
        BuyYSell, 
        ShenmiShangren, 
        DunRefineUpgrade, 
        DunRefineLevel,
        DunReset,
        HuiRefineUpgrade,
        HuiRefineLevel,
        HuiReset,
        Mingwen, 
        HorseManage,
        FubenBiBuy,
    }

    public enum MagicSchool   
    {

        None,         
        Passive,      
        WeaponSkills, 
        Neutral,      
        Fire,         
        Ice,          
        Lightning,    
        Wind,         
        Holy,         
        Dark,         
        Phantom,      
        Combat,       
        Assassination, 

    }
    public enum Passive   
    {

        Zhudong,
        Beidong,

    }
    public enum FubenSchool
    {
        Common,
        Hell,
        Juqing,
        Tiaozhan,
    }


    public enum Element : byte   
    {

        None,
        Fire,
        Ice,
        Lightning,
        Wind,
        Holy,
        Dark,
        Phantom,

    }

    public enum MagicType   
    {
        None,

        Swordsmanship = 100,
        PotionMastery = 101,
        Slaying = 102,
        Thrusting = 103,
        HalfMoon = 104,
        ShoulderDash = 105,
        FlamingSword = 106,
        DragonRise = 107,
        BladeStorm = 108,
        DestructiveSurge = 109,
        Interchange = 110,
        Defiance = 111,
        Beckon = 112,
        Might = 113,
        SwiftBlade = 114,
        Assault = 115,
        Endurance = 116,
        ReflectDamage = 117,
        Fetter = 118,
        SwirlingBlade = 119,
        ReigningStep = 120,
        MaelstromBlade = 121,
        AdvancedPotionMastery = 122,
        MassBeckon = 123,
        SeismicSlam = 124,
        Invincibility = 125,
        CrushingWave = 126,

        FireBall = 201,
        LightningBall = 202,
        IceBolt = 203,
        GustBlast = 204,
        Repulsion = 205,
        ElectricShock = 206,
        Teleportation = 207,
        AdamantineFireBall = 208,
        ThunderBolt = 209,
        IceBlades = 210,
        Cyclone = 211,
        ScortchedEarth = 212,
        LightningBeam = 213,
        FrozenEarth = 214,
        BlowEarth = 215,
        FireWall = 216,
        ExpelUndead = 217,
        GeoManipulation = 218,
        MagicShield = 219,
        FireStorm = 220,
        LightningWave = 221,
        IceStorm = 222,
        DragonTornado = 223,
        GreaterFrozenEarth = 224,
        ChainLightning = 225,
        MeteorShower = 226,
        Renounce = 227,
        Tempest = 228,
        JudgementOfHeaven = 229,
        ThunderStrike = 230,
        RayOfLight = 231,
        BurstOfEnergy = 232,
        ShieldOfPreservation = 233,
        RetrogressionOfEnergy = 234,
        FuryBlast = 235,
        TempestOfUnstableEnergy = 236,
        MirrorImage = 237,
        AdvancedRenounce = 238,
        FrostBite = 239,
        Asteroid = 240,
        ElementalHurricane = 241,
        SuperiorMagicShield = 242,

        Heal = 300,
        SpiritSword = 301,
        PoisonDust = 302,
        ExplosiveTalisman = 303,
        EvilSlayer = 304,
        Invisibility = 305,
        MagicResistance = 306,
        MassInvisibility = 307,
        GreaterEvilSlayer = 308,
        Resilience = 309,
        TrapOctagon = 310,
        TaoistCombatKick = 311,
        ElementalSuperiority = 312,
        MassHeal = 313,
        BloodLust = 314,
        Resurrection = 315,
        Purification = 316,
        Transparency = 317,
        CelestialLight = 318,
        EmpoweredHealing = 319,
        LifeSteal = 320,
        ImprovedExplosiveTalisman = 321,
        GreaterPoisonDust = 322,
        Scarecrow = 323,
        ThunderKick = 324,
        DragonBreath = 325,
        MassTransparency = 326,
        GreaterHolyStrike = 327,
        AugmentExplosiveTalisman = 328,
        AugmentEvilSlayer = 329,
        AugmentPurification = 330,
        OathOfThePerished = 331,
        SummonSkeleton = 332,
        SummonShinsu = 333,
        SummonJinSkeleton = 334,
        StrengthOfFaith = 335,
        SummonDemonicCreature = 336,
        DemonExplosion = 337,
        Infection = 338,
        DemonicRecovery = 339,
        Neutralize = 340,
        AugmentNeutralize = 341,
        DarkSoulPrison = 342,
        AugmentImprovedExplosiveTalisman = 343,
        CrazyImprovedExplosiveTalisman = 344,

        WillowDance = 401,
        VineTreeDance = 402,
        Discipline = 403,
        PoisonousCloud = 404,
        FullBloom = 405,
        Cloak = 406,
        WhiteLotus = 407,
        CalamityOfFullMoon = 408,
        WraithGrip = 409,
        RedLotus = 410,
        HellFire = 411,
        PledgeOfBlood = 412,
        Rake = 413,
        SweetBrier = 414,
        SummonPuppet = 415,
        Karma = 416,
        TouchOfTheDeparted = 417,
        WaningMoon = 418,
        GhostWalk = 419,
        ElementalPuppet = 420,
        Rejuvenation = 421,
        Resolution = 422,
        ChangeOfSeasons = 423,
        Release = 424,
        FlameSplash = 425,
        BloodyFlower = 426,
        TheNewBeginning = 427,
        DanceOfSwallow = 428,
        DarkConversion = 429,
        DragonRepulse = 430,
        AdventOfDemon = 431,
        AdventOfDevil = 432,
        Abyss = 433,
        FlashOfLight = 434,
        Stealth = 435,
        Evasion = 436,
        RagingWind = 437,
        AdvancedBloodyFlower = 438,
        Massacre = 439,
        ArtOfShadows = 440,
        Concentration = 441,
        SwordOfVengeance = 442,

        MonsterScortchedEarth = 501,
        MonsterIceStorm = 502,
        MonsterDeathCloud = 503,
        MonsterThunderStorm = 504,

        SamaGuardianFire = 505,
        SamaGuardianIce = 506,
        SamaGuardianLightning = 507,
        SamaGuardianWind = 508,

        SamaPhoenixFire = 509,
        SamaBlackIce = 510,
        SamaBlueLightning = 511,
        SamaWhiteWind = 512,

        SamaProphetFire = 513,
        SamaProphetLightning = 514,
        SamaProphetWind = 515,

        DoomClawLeftPinch = 520,
        DoomClawLeftSwipe = 521,
        DoomClawRightPinch = 522,
        DoomClawRightSwipe = 523,
        DoomClawWave = 524,
        DoomClawSpit = 525,

        PinkFireBall = 530,
        GreenSludgeBall = 540,

        HellBringerBats = 550,
        PoisonousGolemLineAoE = 551,
        IgyuScorchedEarth = 552,
        IgyuCyclone = 553,

        Wolongbianfuhuojineng = 554,  

        
        
        XueshaSlaying = 600, 

        
        
        GuanyueHalfMoon = 601, 

        
        
        JiyueHalfMoon = 602,

        
        
        ShenquDragonRise = 603,
        
        
        ShenglongDragonRise = 604,
    }

    public enum MonsterImage  
    {
        None,

        Guard,

        Chicken,
        Pig,
        Deer,
        Cow,
        Sheep,
        ClawCat,
        Wolf,
        ForestYeti,
        ChestnutTree,
        CarnivorousPlant,
        Oma,
        TigerSnake,
        SpittingSpider,
        Scarecrow,
        OmaHero,

        CaveBat,
        Scorpion,
        Skeleton,
        SkeletonAxeMan,
        SkeletonAxeThrower,
        SkeletonWarrior,
        SkeletonLord,

        CaveMaggot,
        GhostSorcerer,
        GhostMage,
        VoraciousGhost,
        DevouringGhost,
        CorpseRaisingGhost,
        GhoulChampion,

        ArmoredAnt,
        AntSoldier,
        AntHealer,
        AntNeedler,

        ShellNipper,
        Beetle,
        VisceralWorm,

        MutantFlea,
        PoisonousMutantFlea,
        BlasterMutantFlea,

        WasHatchling,
        Centipede,
        ButterflyWorm,
        MutantMaggot,
        Earwig,
        IronLance,
        LordNiJae,

        RottingGhoul,
        DecayingGhoul,
        BloodThirstyGhoul,

        SpinedDarkLizard,
        UmaInfidel,
        UmaFlameThrower,
        UmaAnguisher,
        UmaKing,

        SpiderBat,
        ArachnidGazer,
        Larva,
        RedMoonGuardian,
        RedMoonProtector,
        VenomousArachnid,
        DarkArachnid,
        RedMoonTheFallen,

        ZumaSharpShooter,
        ZumaFanatic,
        ZumaGuardian,
        ViciousRat,
        ZumaKing,

        EvilFanatic,
        Monkey,
        EvilElephant,
        CannibalFanatic,

        SpikedBeetle,
        NumaGrunt,
        NumaMage,
        NumaElite,
        SandShark,
        StoneGolem,
        WindfurySorceress,
        CursedCactus,
        NetherWorldGate,

        RagingLizard,
        SawToothLizard,
        MutantLizard,
        VenomSpitter,
        SonicLizard,
        GiantLizard,
        CrazedLizard,
        TaintedTerror,
        DeathLordJichon,

        Minotaur,
        FrostMinotaur,
        ShockMinotaur,
        FlameMinotaur,
        FuryMinotaur,
        BanyaLeftGuard,
        BanyaRightGuard,
        EmperorSaWoo,

        BoneArcher,
        BoneBladesman,
        BoneCaptain,
        BoneSoldier,
        ArchLichTaedu,

        WedgeMothLarva,
        LesserWedgeMoth,
        WedgeMoth,
        RedBoar,
        ClawSerpent,
        BlackBoar,
        TuskLord,
        RazorTusk,

        PinkGoddess,
        GreenGoddess,
        MutantCaptain,
        StoneGriffin,
        FlameGriffin,

        WhiteBone,
        Shinsu,
        InfernalSoldier,
        InfernalGuardian,
        InfernalWarrior,

        CorpseStalker,
        LightArmedSoldier,
        CorrosivePoisonSpitter,
        PhantomSoldier,
        MutatedOctopus,
        AquaLizard,
        Stomper,
        CrimsonNecromancer,
        ChaosKnight,
        PachonTheChaosBringer,

        NumaCavalry,
        NumaHighMage,
        NumaStoneThrower,
        NumaRoyalGuard,
        NumaArmoredSoldier,

        IcyRanger,
        IcyGoddess,
        IcySpiritWarrior,
        IcySpiritGeneral,
        GhostKnight,
        IcySpiritSpearman,
        Werewolf,
        Whitefang,
        IcySpiritSolider,
        WildBoar,
        JinamStoneGate,
        FrostLordHwa,

        Companion_Pig,
        Companion_TuskLord,
        Companion_SkeletonLord,
        Companion_Griffin,
        Companion_Dragon,
        Companion_Donkey,
        Companion_Sheep,
        Companion_BanyoLordGuzak,
        Companion_Panda,
        Companion_Rabbit,

        JinchonDevil,
        OmaWarlord,

        EscortCommander,
        FieryDancer,
        EmeraldDancer,
        QueenOfDawn,

        OYoungBeast,
        YumgonWitch,
        MaWarlord,
        JinhwanSpirit,
        JinhwanGuardian,
        YumgonGeneral,
        ChiwooGeneral,
        DragonQueen,
        DragonLord,

        FerociousIceTiger,

        SamaFireGuardian,
        SamaIceGuardian,
        SamaLightningGuardian,
        SamaWindGuardian,
        Phoenix,
        BlackTortoise,
        BlueDragon,
        WhiteTiger,
        SamaCursedBladesman,
        SamaCursedSlave,
        SamaCursedFlameMage,
        SamaProphet,
        SamaSorcerer,
        EnshrinementBox,
        BloodStone,

        OrangeTiger,
        RegularTiger,
        RedTiger,
        SnowTiger,
        BlackTiger,
        BigBlackTiger,
        BigWhiteTiger,
        OrangeBossTiger,
        BigBossTiger,
        WildMonkey,
        FrostYeti,

        EvilSnake,
        Salamander,
        SandGolem,
        SDMob4,
        SDMob5,
        SDMob6,
        SDMob7,
        OmaMage,
        SDMob9,
        SDMob10,
        SDMob11,
        SDMob12,
        SDMob13,
        SDMob14,
        CrystalGolem,
        DustDevil,
        TwinTailScorpion,
        BloodyMole,
        SDMob19,
        SDMob20,
        SDMob21,
        SDMob22,
        SDMob23,
        SDMob24,
        SDMob25,
        GangSpider,
        VenomSpider,
        SDMob26,

        LobsterLord,
        LobsterSpawn,

        NewMob1,
        NewMob2,
        NewMob3,
        NewMob4,
        NewMob5,
        NewMob6,
        NewMob7,
        NewMob8,
        NewMob9,
        NewMob10,

        MonasteryMon0,
        MonasteryMon1,
        MonasteryMon2,
        MonasteryMon3,
        MonasteryMon4,
        MonasteryMon5,
        MonasteryMon6,

        Yue1,
        Yue2,
        Yue3,
        Yue4,
        Yue5,
        Yue6,
        YuexiaoBoss,
        YueBoss,
        Wl1,
        Wl2,
        WolongBianfu01,
        WolongBianfu02,
        Wl5,
        Wl6,
        Wlzz,
        Wlwz,
        Wlbw,
        BmBz,
        Bm1,
        Bm2,
        Bm3,
        Bm4,
        Hd1,
        Hd2,
        Hd3,
        Hd4,
        Hd5,
        Hd6,
        HdxiaoBoss,
        HdBoss,

        yaotaStoneGate,
        MotaStoneGate,
        Huodong01StoneGate,
        Huodong02StoneGate,
        Huodong03StoneGate,
        Huodong04StoneGate,
        Huodong05StoneGate,
        Huodong06StoneGate,
        Huodong07StoneGate,
        Huodong08StoneGate,
        Huodong09StoneGate,
        Huodong10StoneGate,
        Huodong11StoneGate,
        Huodong12StoneGate,

        GardenSoldier,  
        GardenDefender,
        RedBlossom,
        BlueBlossom,
        FireBird,
        TYsiweihonggui,
        TYsiweilangui,
        TYhua,
        TYlanfenghuang,

        Zhenyanmo,
        GuildBoss01,  
        GuildFbBoss,  

        Taishan01,
        Taishan02,
        Taishan03,
        Taishan04,
        Taishan05,
        Taishan06,
        Taishan07,
        Benma01,
        Benma02,
        Benma03,
        Qinling01,
        Qinling02,
        Qinling03,
        Qinling04,
        Qinling05,
        Qinling06,
        Qinling07,
        Qinling08,
        Qinling09,
        Qinling10,
        Companion_Snow,
        CrazedPrimate,
        HellBringer,
        YurinMon0,
        YurinMon1,
        WhiteBeardedTiger,
        BlackBeardedTiger,
        HardenedRhino,
        Mammoth,
        CursedSlave1,
        CursedSlave2,
        CursedSlave3,
        PoisonousGolem,
        Huanjingsamll,

        

        Custom,

        HdBoss2,

        Junwang,
        Toutian,
        Jialan,

        LingShou,
        XueShou,
        ShengShou,

        Horse_Brown,
        Horse_White,
        Horse_Red,
        Horse_Black,
        Horse_Dark,
        Horse_WhiteUni,
        Horse_RedUni,
        Horse_Blue,
        Horse_ArmBrown,
        Horse_ArmWhite,
        Horse_ArmRed,
        Horse_ArmBlack,
        Horse_SnowLion,
        Horse_Lion,

        FubenShiwang,


    }

    public enum MapIcon
    {
        None,
        Cave,
        Exit,
        Down,
        Up,
        Province,
        Building
    }

    public enum Effect
    {
        TeleportOut,
        TeleportIn,

        
        FullBloom,
        WhiteLotus,
        RedLotus,
        SweetBrier,
        Karma,

        Puppet,
        PuppetFire,
        PuppetIce,
        PuppetLightning,
        PuppetWind,

        SummonSkeleton,
        SummonShinsu,

        ThunderBolt,
        DanceOfSwallow,
        FlashOfLight,

        DemonExplosion,
        FrostBiteEnd,
        DemonicRecovery,
    }

    [Flags]
    public enum PoisonType
    {
        None = 0,
        Green = 1,
        Red = 2,
        Slow = 4,
        Paralysis = 8,
        WraithGrip = 16,
        HellFire = 32,
        Silenced = 64,
        Abyss = 128,
        Infection = 256,
        Neutralize = 512,
    }

    public enum SpellEffect
    {
        None,

        SafeZone,


        FireWall,
        MonsterFireWall,
        Tempest,

        TrapOctagon,

        PoisonousCloud,
        DarkSoulPrison,

        SwordOfVengeance,

        Rubble,

        MonsterDeathCloud,
    }

    public enum MarketPlaceSort
    {
        Newest,
        Oldest,
        HighestPrice,
        LowestPrice,
    }


    public enum MarketPlaceStoreSort
    {
        Alphabetical,
        HighestPrice,
        LowestPrice,
        Favourite
    }

    public enum RefineType : byte
    {
        None,
        Durability,
        DC,
        SpellPower,
        Fire,
        Ice,
        Lightning,
        Wind,
        Holy,
        Dark,
        Phantom,
        Reset,
        Health,
        Mana,
        AC,
        MR,
        Accuracy,
        Agility,
        DCPercent,
        SPPercent,
        HealthPercent,
        ManaPercent,
    }

    public enum RefineQuality : byte  
    {
        Rush,          
        Quick,         
        Standard,      
        Careful,       
        Precise,       
    }

    public enum CurrencyType : byte   
    {
        None,
        Gold,                        
        GameGold,                    
    }

    public enum ItemEffect : byte   
    {
        None,

        Gold = 1,
        Experience = 2,
        CompanionTicket = 3,
        BasicCompanionBag = 4,
        PickAxe = 5,
        UmaKingHorn = 6,
        ItemPart = 7,
        Carrot = 8,
        HorseTicket = 9,
        DestructionElixir = 10,
        HasteElixir = 11,
        LifeElixir = 12,
        ManaElixir = 13,
        NatureElixir = 14,
        SpiritElixir = 15,

        BlackIronOre = 20,
        GoldOre = 21,
        Diamond = 22,
        SilverOre = 23,
        IronOre = 24,
        Corundum = 25,

        ElixirOfPurification = 30,
        PillOfReincarnation = 31,

        Crystal = 40,
        RefinementStone = 41,
        Fragment1 = 42,
        Fragment2 = 43,
        Fragment3 = 44,

        ClassChange = 49,
        GenderChange = 50,
        HairChange = 51,
        ArmourDye = 52,
        NameChange = 53,
        FortuneChecker = 54,
        Teleport = 55, 
        TeleportHD = 56, 

        WeaponTemplate = 60,
        WarriorWeapon = 61,
        WizardWeapon = 63,
        TaoistWeapon = 64,
        AssassinWeapon = 65,

        YellowSlot = 70,
        BlueSlot = 71,
        RedSlot = 72,
        PurpleSlot = 73,
        GreenSlot = 74,
        GreySlot = 75,

        FootballArmour = 80,
        FootBallWhistle = 81,

        StatExtractor = 90,
        SpiritBlade = 91,
        RefineExtractor = 92,
        ChaoticHeavenBlade = 93,
        ChaoticHeavenGlaive = 94,
        Level75ArmourUpgrade = 95,
        Level75ArmourBase = 96,
        GuildAllianceTreaty = 97,
        ItemRenameScroll = 98,

        GameGold = 100,
        Shengwang = 101,

        FabaoSpiritBlade = 102,
        FabaoStatExtractor = 103,

    }

    [Flags]
    public enum UserItemFlags
    {
        None = 0,

        Locked = 1,
        Bound = 2,
        Worthless = 4,
        Refinable = 8,
        Expirable = 16,
        QuestItem = 32,
        GameMaster = 64,
        Marriage = 128,
        NonRefinable = 256,
    }

    [Flags]
    public enum BaoshiMaYi
    {
        None = 0,

        XiangKanGJST = 1,
        XiangKanGJBST = 2,
        XiangKanZRST = 4,
        XiangKanZRBST = 8,
        XiangKanLHST = 16,
        XiangKanLHBST = 32,
        XiangKanSMST = 64,
        XiangKanMFST = 128,
        XiangKanSDST = 256,
        XiangKanFYST = 512,
        XiangKanMYST = 1024,
        XiangKanXXY = 2048,
        XiangKanGJEST = 4096,
        XiangKanGJSST = 8192,
        XiangKanGJBEST = 16384,
        XiangKanGJBSST = 32768,
        XiangKanZREST = 65536,
        XiangKanZRSST = 131072,
        XiangKanZRBEST = 262144,
        XiangKanZRBSST = 524288,
        XiangKanLHEST = 1048576,
        XiangKanLHSST = 2097152,
        XiangKanLHBEST = 4194304,
        XiangKanLHBSST = 8388608,
        XiangKanSMEST = 16777216,
        XiangKanSMSST = 33554432,
        XiangKanMFEST = 67108864,
        XiangKanMFSST = 134217728,
        XiangKanSDEST = 268435456,
        XiangKanSDSST = 536870912,
        XiangKanFYEST = 1073741824,
    }

    [Flags]
    public enum BaoshiMaEr
    {
        None = 0,

        XiangKanFYSST = 1,
        XiangKanMYEST = 2,
        XiangKanMYSST = 4,
        XiangKanXXE = 8,
        XiangKanXXS = 16,
        Youliang = 32,
        Jingzhi = 64,
        Shenhua = 128,
        Chuanshuo = 256,
        Kaikongxxy = 512,
        Kaikongxxe = 1024,
        Kaikongxxs = 2048,
        GZLKaikongy = 4096,
        GZLKaikonge = 8192,
        GZLKaikongs = 16384,
        GZLBKaikongy = 32768,
        GZLBKaikonge = 65536,
        GZLBKaikongs = 131072,
        QTKaikongy = 262144,
        QTKaikonge = 524288,
        QTKaikongs = 1048576,
        XiangKanghuoy = 2097152,
        XiangKanghuoe = 4194304,
        XiangKanghuos = 8388608,
        Xiangkanjysty = 16777216,
        Xiangkanjyste = 33554432,
        Xiangkanjysts = 67108864,
        Xiangkanxxsty = 134217728,
        Xiangkanxxste = 268435456,
        Xiangkanxxsts = 536870912,
        XiangKangbingy = 1073741824,

    }

    [Flags]
    public enum BaoshiMaSan
    {
        None = 0,

        XiangKangbinge = 1,
        XiangKangbings = 2,
        XiangKangleiy = 4,
        XiangKangleie = 8,
        XiangKangleis = 16,
        XiangKangfengy = 32,
        XiangKangfenge = 64,
        XiangKangfengs = 128,
        XiangKangsheny = 256,
        XiangKangshene = 512,
        XiangKangshens = 1024,
        XiangKangany = 2048,
        XiangKangane = 4096,
        XiangKangans = 8192,
        XiangKanghuany = 16384,
        XiangKanghuane = 32768,
        XiangKanghuans = 65536,
        XiangKanmofaduny = 131072,
        XiangKanmofadune = 262144,
        XiangKanmofaduns = 524288,
        XiangKanbingdongy = 1048576,
        XiangKanbingdonge = 2097152,
        XiangKanbingdongs = 4194304,
        XiangKanmabiy = 8388608,
        XiangKanmabie = 16777216,
        XiangKanmabis = 33554432,
        XiangKanyidongy = 67108864,
        XiangKanyidonge = 134217728,
        XiangKanyidongs = 268435456,
        XiangKanchenmoy = 536870912,
        XiangKanchenmoe = 1073741824,

    }

    [Flags]
    public enum BaoshiMaSi
    {
        None = 0,

        XiangKanchenmos = 1,
        XiangKangedangy = 2,
        XiangKangedange = 4,
        XiangKangedangs = 8,
        XiangKanduobiy = 16,
        XiangKanduobie = 32,
        XiangKanduobis = 64,
        XiangKanqhuoy = 128,
        XiangKanqhuoe = 256,
        XiangKanqhuos = 512,
        XiangKanqbingy = 1024,
        XiangKanqbinge = 2048,
        XiangKanqbings = 4096,
        XiangKanqleiy = 8192,
        XiangKanqleie = 16384,
        XiangKanqleis = 32768,
        XiangKanqfengy = 65536,
        XiangKanqfenge = 131072,
        XiangKanqfengs = 262144,
        XiangKanqsheny = 524288,
        XiangKanqshene = 1048576,
        XiangKanqshens = 2097152,
        XiangKanqany = 4194304,
        XiangKanqane = 8388608,
        XiangKanqans = 16777216,
        XiangKanqhuany = 33554432,
        XiangKanqhuane = 67108864,
        XiangKanqhuans = 134217728,
        XiangKanlvduy = 268435456,
        XiangKanlvdue = 536870912,
        XiangKanlvdus = 1073741824,

    }

    [Flags]
    public enum BaoshiMaWu
    {
        None = 0,

        XiangKanzymy = 1,
        XiangKanzyme = 2,
        XiangKanzyms = 4,
        XiangKanmhhfy = 8,
        XiangKanmhhfe = 16,
        XiangKanmhhfs = 32,
        XiangKangjstyijiy = 64,
        XiangKangjstyijie = 128,
        XiangKangjstyijis = 256,
        XiangKangjsterjiy = 512,
        XiangKangjsterjie = 1024,
        XiangKangjsterjis = 2048,
        XiangKangjstsanjiy = 4096,
        XiangKangjstsanjie = 8192,
        XiangKangjstsanjis = 16384,
        XiangKangjstsijiy = 32768,
        XiangKangjstsijie = 65536,
        XiangKangjstsijis = 131072,
        XiangKangjbstyijiy = 262144,
        XiangKangjbstyijie = 524288,
        XiangKangjbstyijis = 1048576,
        XiangKangjbsterjiy = 2097152,
        XiangKangjbsterjie = 4194304,
        XiangKangjbsterjis = 8388608,
        XiangKangjbstsanjiy = 16777216,
        XiangKangjbstsanjie = 33554432,
        XiangKangjbstsanjis = 67108864,
        XiangKangjbstsijiy = 134217728,
        XiangKangjbstsijie = 268435456,
        XiangKangjbstsijis = 536870912,
        XiangKanzrstyijiy = 1073741824,

    }

    [Flags]
    public enum BaoshiMaLiu
    {
        None = 0,

        XiangKanzrstyijie = 1,
        XiangKanzrstyijis = 2,
        XiangKanzrsterjiy = 4,
        XiangKanzrsterjie = 8,
        XiangKanzrsterjis = 16,
        XiangKanzrstsanjiy = 32,
        XiangKanzrstsanjie = 64,
        XiangKanzrstsanjis = 128,
        XiangKanzrstsijiy = 256,
        XiangKanzrstsijie = 512,
        XiangKanzrstsijis = 1024,
        XiangKanzrbstyijiy = 2048,
        XiangKanzrbstyijie = 4096,
        XiangKanzrbstyijis = 8192,
        XiangKanzrbsterjiy = 16384,
        XiangKanzrbsterjie = 32768,
        XiangKanzrbsterjis = 65536,
        XiangKanzrbstsanjiy = 131072,
        XiangKanzrbstsanjie = 262144,
        XiangKanzrbstsanjis = 524288,
        XiangKanzrbstsijiy = 1048576,
        XiangKanzrbstsijie = 2097152,
        XiangKanzrbstsijis = 4194304,
        XiangKanlhstyijiy = 8388608,
        XiangKanlhstyijie = 16777216,
        XiangKanlhstyijis = 33554432,
        XiangKanlhsterjiy = 67108864,
        XiangKanlhsterjie = 134217728,
        XiangKanlhsterjis = 268435456,
        XiangKanlhstsanjiy = 536870912,
        XiangKanlhstsanjie = 1073741824,

    }

    [Flags]
    public enum BaoshiMaQi
    {
        None = 0,

        XiangKanlhstsanjis = 1,
        XiangKanlhstsijiy = 2,
        XiangKanlhstsijie = 4,
        XiangKanlhstsijis = 8,
        XiangKanlhbstyijiy = 16,
        XiangKanlhbstyijie = 32,
        XiangKanlhbstyijis = 64,
        XiangKanlhbsterjiy = 128,
        XiangKanlhbsterjie = 256,
        XiangKanlhbsterjis = 512,
        XiangKanlhbstsanjiy = 1024,
        XiangKanlhbstsanjie = 2048,
        XiangKanlhbstsanjis = 4096,
        XiangKanlhbstsijiy = 8192,
        XiangKanlhbstsijie = 16384,
        XiangKanlhbstsijis = 32768,
        XiangKansmstyijiy = 65536,
        XiangKansmstyijie = 131072,
        XiangKansmstyijis = 262144,
        XiangKansmsterjiy = 524288,
        XiangKansmsterjie = 1048576,
        XiangKansmsterjis = 2097152,
        XiangKansmstsanjiy = 4194304,
        XiangKansmstsanjie = 8388608,
        XiangKansmstsanjis = 16777216,
        XiangKansmstsijiy = 33554432,
        XiangKansmstsijie = 67108864,
        XiangKansmstsijis = 134217728,
        XiangKanmfstyijiy = 268435456,
        XiangKanmfstyijie = 536870912,
        XiangKanmfstyijis = 1073741824,

    }

    [Flags]
    public enum BaoshiMaBa
    {
        None = 0,

        XiangKanmfsterjiy = 1,
        XiangKanmfsterjie = 2,
        XiangKanmfsterjis = 4,
        XiangKanmfstsanjiy = 8,
        XiangKanmfstsanjie = 16,
        XiangKanmfstsanjis = 32,
        XiangKanmfstsijiy = 64,
        XiangKanmfstsijie = 128,
        XiangKanmfstsijis = 256,
        XiangKansdstyijiy = 512,
        XiangKansdstyijie = 1024,
        XiangKansdstyijis = 2048,
        XiangKansdsterjiy = 4096,
        XiangKansdsterjie = 8192,
        XiangKansdsterjis = 16384,
        XiangKansdstsanjiy = 32768,
        XiangKansdstsanjie = 65536,
        XiangKansdstsanjis = 131072,
        XiangKansdstsijiy = 262144,
        XiangKansdstsijie = 524288,
        XiangKansdstsijis = 1048576,
        XiangKanfystyijiy = 2097152,
        XiangKanfystyijie = 4194304,
        XiangKanfystyijis = 8388608,
        XiangKanfysterjiy = 16777216,
        XiangKanfysterjie = 33554432,
        XiangKanfysterjis = 67108864,
        XiangKanfystsanjiy = 134217728,
        XiangKanfystsanjie = 268435456,
        XiangKanfystsanjis = 536870912,
        XiangKanfystsijiy = 1073741824,

    }

    [Flags]
    public enum BaoshiMaJiu
    {
        None = 0,

        XiangKanfystsijie = 1,
        XiangKanfystsijis = 2,
        XiangKanmystyijiy = 4,
        XiangKanmystyijie = 8,
        XiangKanmystyijis = 16,
        XiangKanmysterjiy = 32,
        XiangKanmysterjie = 64,
        XiangKanmysterjis = 128,
        XiangKanmystsanjiy = 256,
        XiangKanmystsanjie = 512,
        XiangKanmystsanjis = 1024,
        XiangKanmystsijiy = 2048,
        XiangKanmystsijie = 4096,
        XiangKanmystsijis = 8192,
        XiangKanjystyijiy = 16384,
        XiangKanjystyijie = 32768,
        XiangKanjystyijis = 65536,
        XiangKanjysterjiy = 131072,
        XiangKanjysterjie = 262144,
        XiangKanjysterjis = 524288,
        XiangKanjystsanjiy = 1048576,
        XiangKanjystsanjie = 2097152,
        XiangKanjystsanjis = 4194304,
        XiangKanjystsijiy = 8388608,
        XiangKanjystsijie = 16777216,
        XiangKanjystsijis = 33554432,
        XiangKangbingstyijiy = 67108864,
        XiangKangbingstyijie = 134217728,
        XiangKangbingstyijis = 268435456,
        XiangKangbingsterjiy = 536870912,
        XiangKangbingsterjie = 1073741824,

    }

    [Flags]
    public enum BaoshiMaShi
    {
        None = 0,

        XiangKangbingsterjis = 1,
        XiangKangbingstsanjiy = 2,
        XiangKangbingstsanjie = 4,
        XiangKangbingstsanjis = 8,
        XiangKangbingstsijiy = 16,
        XiangKangbingstsijie = 32,
        XiangKangbingstsijis = 64,
        XiangKanghuostyijiy = 128,
        XiangKanghuostyijie = 256,
        XiangKanghuostyijis = 512,
        XiangKanghuosterjiy = 1024,
        XiangKanghuosterjie = 2048,
        XiangKanghuosterjis = 4096,
        XiangKanghuostsanjiy = 8192,
        XiangKanghuostsanjie = 16384,
        XiangKanghuostsanjis = 32768,
        XiangKanghuostsijiy = 65536,
        XiangKanghuostsijie = 131072,
        XiangKanghuostsijis = 262144,
        XiangKangleistyijiy = 524288,
        XiangKangleistyijie = 1048576,
        XiangKangleistyijis = 2097152,
        XiangKangleisterjiy = 4194304,
        XiangKangleisterjie = 8388608,
        XiangKangleisterjis = 16777216,
        XiangKangleistsanjiy = 33554432,
        XiangKangleistsanjie = 67108864,
        XiangKangleistsanjis = 134217728,
        XiangKangleistsijiy = 268435456,
        XiangKangleistsijie = 536870912,
        XiangKangleistsijis = 1073741824,

    }

    [Flags]
    public enum BaoshiMaShiyi
    {
        None = 0,

        XiangKangfengstyijiy = 1,
        XiangKangfengstyijie = 2,
        XiangKangfengstyijis = 4,
        XiangKangfengsterjiy = 8,
        XiangKangfengsterjie = 16,
        XiangKangfengsterjis = 32,
        XiangKangfengstsanjiy = 64,
        XiangKangfengstsanjie = 128,
        XiangKangfengstsanjis = 256,
        XiangKangfengstsijiy = 512,
        XiangKangfengstsijie = 1024,
        XiangKangfengstsijis = 2048,
        XiangKangshenstyijiy = 4096,
        XiangKangshenstyijie = 8192,
        XiangKangshenstyijis = 16384,
        XiangKangshensterjiy = 32768,
        XiangKangshensterjie = 65536,
        XiangKangshensterjis = 131072,
        XiangKangshenstsanjiy = 262144,
        XiangKangshenstsanjie = 524288,
        XiangKangshenstsanjis = 1048576,
        XiangKangshenstsijiy = 2097152,
        XiangKangshenstsijie = 4194304,
        XiangKangshenstsijis = 8388608,
        XiangKanganstyijiy = 16777216,
        XiangKanganstyijie = 33554432,
        XiangKanganstyijis = 67108864,
        XiangKangansterjiy = 134217728,
        XiangKangansterjie = 268435456,
        XiangKangansterjis = 536870912,
        XiangKanganstsanjiy = 1073741824,

    }

    [Flags]
    public enum BaoshiMaShier
    {
        None = 0,

        XiangKanganstsanjie = 1,
        XiangKanganstsanjis = 2,
        XiangKanganstsijiy = 4,
        XiangKanganstsijie = 8,
        XiangKanganstsijis = 16,
        XiangKanghuanstyijiy = 32,
        XiangKanghuanstyijie = 64,
        XiangKanghuanstyijis = 128,
        XiangKanghuansterjiy = 256,
        XiangKanghuansterjie = 512,
        XiangKanghuansterjis = 1024,
        XiangKanghuanstsanjiy = 2048,
        XiangKanghuanstsanjie = 4096,
        XiangKanghuanstsanjis = 8192,
        XiangKanghuanstsijiy = 16384,
        XiangKanghuanstsijie = 32768,
        XiangKanghuanstsijis = 65536,
        XiangKanmofadunstyijiy = 131072,
        XiangKanmofadunstyijie = 262144,
        XiangKanmofadunstyijis = 524288,
        XiangKanmofadunsterjiy = 1048576,
        XiangKanmofadunsterjie = 2097152,
        XiangKanmofadunsterjis = 4194304,
        XiangKanmofadunstsanjiy = 8388608,
        XiangKanmofadunstsanjie = 16777216,
        XiangKanmofadunstsanjis = 33554432,
        XiangKanmofadunstsijiy = 67108864,
        XiangKanmofadunstsijie = 134217728,
        XiangKanmofadunstsijis = 268435456,
        XiangKanbingdongstyijiy = 536870912,
        XiangKanbingdongstyijie = 1073741824,

    }

    [Flags]
    public enum BaoshiMaShisan
    {
        None = 0,

        XiangKanbingdongstyijis = 1,
        XiangKanbingdongsterjiy = 2,
        XiangKanbingdongsterjie = 4,
        XiangKanbingdongsterjis = 8,
        XiangKanbingdongstsanjiy = 16,
        XiangKanbingdongstsanjie = 32,
        XiangKanbingdongstsanjis = 64,
        XiangKanbingdongstsijiy = 128,
        XiangKanbingdongstsijie = 256,
        XiangKanbingdongstsijis = 512,
        Huanhua = 1024,
        XiangKanjingliany = 2048,
        XiangKanjingliane = 4096,
        XiangKanjinglians = 8192,
        XiangKanjinglianstyijiy = 16384,
        XiangKanjinglianstyijie = 32768,
        XiangKanjinglianstyijis = 65536,
        XiangKanjingliansterjiy = 131072,
        XiangKanjingliansterjie = 262144,
        XiangKanjingliansterjis = 524288,
        XiangKanjinglianstsanjiy = 1048576,
        XiangKanjinglianstsanjie = 2097152,
        XiangKanjinglianstsanjis = 4194304,
        XiangKanjinglianstsijiy = 8388608,
        XiangKanjinglianstsijie = 16777216,
        XiangKanjinglianstsijis = 33554432,
        XiangKanlvdustyijiy = 67108864,
        XiangKanlvdustyijie = 134217728,
        XiangKanlvdustyijis = 268435456,
        XiangKanlvdusterjiy = 536870912,
        XiangKanlvdusterjie = 1073741824,
    }

    [Flags]
    public enum BaoshiMaShisi
    {
        None = 0,

        XiangKanlvdusterjis = 1,
        XiangKanlvdustsanjiy = 2,
        XiangKanlvdustsanjie = 4,
        XiangKanlvdustsanjis = 8,
        XiangKanlvdustsijiy = 16,
        XiangKanlvdustsijie = 32,
        XiangKanlvdustsijis = 64,
        XiangKanzymstyijiy = 128,
        XiangKanzymstyijie = 256,
        XiangKanzymstyijis = 512,
        XiangKanzymsterjiy = 1024,
        XiangKanzymsterjie = 2048,
        XiangKanzymsterjis = 4096,
        XiangKanzymstsanjiy = 8192,
        XiangKanzymstsanjie = 16384,
        XiangKanzymstsanjis = 32768,
        XiangKanzymstsijiy = 65536,
        XiangKanzymstsijie = 131072,
        XiangKanzymstsijis = 262144,
    }

    [Flags]
    public enum MingwenMaYi
    {
        None = 0,

        Mingwenweiyi = 1,
        Mingwenxinxiyi = 2,
        Mingwenxinxier = 4,
        Mingwenxinxisan = 8,
        Mingwenweier = 16,
        Mingwenxinxisi = 32,
        Mingwenxinxiwu = 64,
        Mingwenxinxiliu = 128,

        ShenRuoYinY = 256,  
        ShenRuoYinE = 512,  
        ShenRuoYinS = 1024,  
        ShenShuYinY = 2048,  
        ShenShuYinE = 4096,  
        ShenShuYinS = 8192,  
        ShenBaoYinY = 16384,
        ShenBaoYinE = 32768,
        ShenBaoYinS = 65536,
        MiaoShouYinY = 131072,
        MiaoShouYinE = 262144,
        MiaoShouYinS = 524288,

        LingJiYinY = 1048576,
        LingJiYinE = 2097152,
        LingJiYinS = 4194304,

        DaoFaYinY = 8388608,
        DaoFaYinE = 16777216,
        DaoFaYinS = 33554432,

        LingBaoYinY = 67108864,
        LingBaoYinE = 134217728,
        LingBaoYinS = 268435456,

    }

    [Flags]
    public enum MingwenMaEr
    {
        None = 0,

        LingBoYinY = 1,
        LingBoYinE = 2,
        LingBoYinS = 4,

        LingFengYinY = 8,
        LingFengYinE = 16,
        LingFengYinS = 32,

        LingYunYinY = 64,
        LingYunYinE = 128,
        LingYunYinS = 256,

        LingQuYinY = 512,
        LingQuYinE = 1024,
        LingQuYinS = 2048,

        HuosheYinY = 4096,
        HuosheYinE = 8192,
        HuosheYinS = 16384,

        TansheYinY = 32768, 
        TansheYinE = 65536, 
        TansheYinS = 131072, 

        LingkongYinY = 262144, 
        LingkongYinE = 524288, 
        LingkongYinS = 1048576, 

        FuzhenYinY = 2097152, 
        FuzhenYinE = 4194304, 
        FuzhenYinS = 8388608, 

        YulongYinY = 16777216,
        YulongYinE = 33554432,
        YulongYinS = 67108864,
    }

    [Flags]
    public enum MingwenMaSan
    {
        None = 0,

        LongwangYinY = 1,
        LongwangYinE = 2,
        LongwangYinS = 4,

        JunwangYinY = 8,
        JunwangYinE = 16,
        JunwangYinS = 32,

        ToutianYinY = 64,
        ToutianYinE = 128,
        ToutianYinS = 256,

        JialanYinY = 512,
        JialanYinE = 1024,
        JialanYinS = 2048,

        KongxiangYinY = 4096,
        KongxiangYinE = 8192,
        KongxiangYinS = 16384,

        LiuxingYinY = 32768,
        LiuxingYinE = 65536,
        LiuxingYinS = 131072,

        LingxieYinY = 262144,
        LingxieYinE = 524288,
        LingxieYinS = 1048576,

        LingbaoYinY = 2097152,
        LingbaoYinE = 4194304,
        LingbaoYinS = 8388608,

        YouqiangYinY = 16777216,
        YouqiangYinE = 33554432,
        YouqiangYinS = 67108864,
    }

    [Flags]
    public enum MingwenMaSi
    {
        None = 0,

        YingjiYinY = 1,
        YingjiYinE = 2,
        YingjiYinS = 4,

        JizhongYinY = 8,
        JizhongYinE = 16,
        JizhongYinS = 32,

        DusheYinY = 64,
        DusheYinE = 128,
        DusheYinS = 256,

        ShesheYinY = 512,
        ShesheYinE = 1024,
        ShesheYinS = 2048,

        HunkongYinY = 4096,
        HunkongYinE = 8192,
        HunkongYinS = 16384,

        HunzhenYinY = 32768,
        HunzhenYinE = 65536,
        HunzhenYinS = 131072,

        NingdanYinY = 262144,
        NingdanYinE = 524288,
        NingdanYinS = 1048576,

        NingbaoYinY = 2097152,
        NingbaoYinE = 4194304,
        NingbaoYinS = 8388608,

        NingxiaoYinY = 16777216,
        NingxiaoYinE = 33554432,
        NingxiaoYinS = 67108864,
    }

    [Flags]
    public enum MingwenMaWu
    {
        None = 0,

        XiezhouYinY = 1,
        XiezhouYinE = 2,
        XiezhouYinS = 4,

        ZhengzhouYinY = 8,
        ZhengzhouYinE = 16,
        ZhengzhouYinS = 32,

        KongquanYinY = 64,
        KongquanYinE = 128,
        KongquanYinS = 256,

        QuanbaYinY = 512,
        QuanbaYinE = 1024,
        QuanbaYinS = 2048,

        QuanjiYinY = 4096,
        QuanjiYinE = 8192,
        QuanjiYinS = 16384,

        QiangfaYinY = 32768,
        QiangfaYinE = 65536,
        QiangfaYinS = 131072,

        QiangbaoYinY = 262144,
        QiangbaoYinE = 524288,
        QiangbaoYinS = 1048576,

        LingshouYinY = 2097152,
        LingshouYinE = 4194304,
        LingshouYinS = 8388608,

        XueshouYinY = 16777216,
        XueshouYinE = 33554432,
        XueshouYinS = 67108864,
    }
    [Flags]
    public enum MingwenMaLiu
    {
        None = 0,

        ShengshouYinY = 1,
        ShengshouYinE = 2,
        ShengshouYinS = 4,

        YaoguangYinY = 8,
        YaoguangYinE = 16,
        YaoguangYinS = 32,

        ChaojunwangYinY = 64,
        ChaojunwangYinE = 128,
        ChaojunwangYinS = 256,

        ChaotoutianYinY = 512,
        ChaotoutianYinE = 1024,
        ChaotoutianYinS = 2048,

        ChaojialanYinY = 4096,
        ChaojialanYinE = 8192,
        ChaojialanYinS = 16384,

        MengshiYinY = 32768,
        MengshiYinE = 65536,
        MengshiYinS = 131072,

        QiangshiYinY = 262144,
        QiangshiYinE = 524288,
        QiangshiYinS = 1048576,

        BaohuYinY = 2097152,
        BaohuYinE = 4194304,
        BaohuYinS = 8388608,

        DaozunYinY = 16777216,
        DaozunYinE = 33554432,
        DaozunYinS = 67108864,

        JiesuYinY = 134217728,
        JiesuYinE = 268435456,
        JiesuYinS = 536870912,
    }

    [Flags]
    public enum MingwenMaQi
    {
        None = 0,

        LunhuiYinY = 1,
        LunhuiYinE = 2,
        LunhuiYinS = 4,

        ZongbaoYinY = 8,
        ZongbaoYinE = 16,
        ZongbaoYinS = 32,

        SusheYinY = 64,
        SusheYinE = 128,
        SusheYinS = 256,

        BaosheYinY = 512,
        BaosheYinE = 1024,
        BaosheYinS = 2048,

        MiehunYinY = 4096,
        MiehunYinE = 8192,
        MiehunYinS = 16384,

        MiezhenYinY = 32768,
        MiezhenYinE = 65536,
        MiezhenYinS = 131072,

        HongyueYinY = 262144,
        HongyueYinE = 524288,
        HongyueYinS = 1048576,

        HuoyanYinY = 2097152,
        HuoyanYinE = 4194304,
        HuoyanYinS = 8388608,

        ZhenmoYinY = 16777216,
        ZhenmoYinE = 33554432,
        ZhenmoYinS = 67108864,

        XiongzhaoYinY = 134217728,
        XiongzhaoYinE = 268435456,
        XiongzhaoYinS = 536870912,
    }

    [Flags]
    public enum MingwenMaBa
    {
        None = 0,

        HuoyuanYinY = 1,
        HuoyuanYinE = 2,
        HuoyuanYinS = 4,

        SumingYinY = 8,
        SumingYinE = 16,
        SumingYinS = 32,

        SheshouYinY = 64,
        SheshouYinE = 128,
        SheshouYinS = 256,

        ChuansheYinY = 512,
        ChuansheYinE = 1024,
        ChuansheYinS = 2048,

        
        
        

        
        
        

        
        
        

        
        
        

        
        
        

        
        
        
    }

    [Flags]
    public enum MingwenMaJiu
    {
        None = 0,
    }

    [Flags]
    public enum MingwenMaShi
    {
        None = 0,
    }

    [Flags]
    public enum MingwenMaShiyi
    {
        None = 0,
    }

    [Flags]
    public enum MingwenMaShier
    {
        None = 0,
    }

    [Flags]
    public enum MingwenMaShisan
    {
        None = 0,
    }

    [Flags]
    public enum MingwenMaShisi
    {
        None = 0,
    }
    [Flags]
    public enum MingwenMaShiwu
    {
        None = 0,
    }

    public enum AutoSetConf
    {
        None = 0,
        SuijisBox = 1,
        SetShiftBox = 2,
        SetDisplayBox = 3,
        SetBrightBox = 4,
        SetCorpseBox = 5,
        SetFlamingSwordBox = 6,
        SetDragobRiseBox = 7,
        SetBladeStormBox = 8,
        SetMagicShieldBox = 9,
        SetRenounceBox = 10,
        SetPoisonDustBox = 11,
        SetCelestialBox = 12,
        SetFourFlowersBox = 13,
        SetMagicskillsBox = 14,
        SetMagicskills1Box = 15,
        SetAutoOnHookBox = 16,
        SuijiBox = 17,
        SetAutoPoisonBox = 18,
        SetAutoAvoidBox = 19,
        SetDeathResurrectionBox = 20,
        SetSingleHookSkillsBox = 21,
        SetGroupHookSkillsBox = 22,
        SetSummoningSkillsBox = 23,
        SetRandomItemBox = 24,
        SetHomeItemBox = 25,
        SetMaxConf = 26,
        SetDefianceBox = 27,
        SetMightBox = 28,
        SetShowHealth = 29,
        SetEvasionBox = 30,
        SerRagingWindBox = 31,
        SetJsPickUpBox = 32,
        SetCwPickUpBox = 33,
    }


    public enum HorseType : byte
    {
        None,
        Brown,
        White,
        Red,
        Black,
        WhiteUni,
        RedUni,
        Dark,
        Blue,
        ArmBrown,
        ArmWhite,
        ArmRed,
        ArmBlack,
        SnowLion,
        MountainLion
    }

    [Flags]
    public enum GuildPermission
    {
        None = 0,

        Leader = -1,

        EditNotice = 1,
        AddMember = 2,
        RemoveMember = 4,
        Storage = 8,
        FundsRepair = 16,
        FundsMerchant = 32,
        FundsMarket = 64,
        StartWar = 128,
    }

    [Flags]
    public enum QuestIcon
    {
        None = 0,

        NewQuest = 1,
        QuestIncomplete = 2,
        QuestComplete = 4,


        NewRepeatable = 8,
        RepeatableComplete = 16,
    }

    
    public enum CraftType
    {
        Smithing,
        Clothing,
        Jewelry,
        Consumables,
        Rusted
    }

    public enum MovementEffect
    {
        None = 0,

        SpecialRepair = 1,
    }

    public enum SpellKey : byte    
    {
        None,

        [Description("F1")]
        Spell01,
        [Description("F2")]
        Spell02,
        [Description("F3")]
        Spell03,
        [Description("F4")]
        Spell04,
        [Description("F5")]
        Spell05,
        [Description("F6")]
        Spell06,
        [Description("F7")]
        Spell07,
        [Description("F8")]
        Spell08,
        [Description("F9")]
        Spell09,
        [Description("F10")]
        Spell10,
        [Description("F11")]
        Spell11,
        [Description("F12")]
        Spell12,

        [Description("F1")]
        Spell13,
        [Description("F2")]
        Spell14,
        [Description("F3")]
        Spell15,
        [Description("F4")]
        Spell16,
        [Description("F5")]
        Spell17,
        [Description("F6")]
        Spell18,
        [Description("F7")]
        Spell19,
        [Description("F8")]
        Spell20,
        [Description("F9")]
        Spell21,
        [Description("F10")]
        Spell22,
        [Description("F11")]
        Spell23,
        [Description("F12")]
        Spell24,
    }

    public enum MonsterFlag
    {
        None = 0,

        Skeleton = 1,
        JinSkeleton = 2,
        Shinsu = 3,
        InfernalSoldier = 4,
        Scarecrow = 5,

        SummonPuppet = 6,

        MirrorImage = 7,

        Zhenyanmo = 8,
        Zhenyanmoyi = 9,
        Zhenyanmoer = 10,
        Zhenyanmosan = 11,
        Zhenyanmosi = 12,
        JunwangYi = 13,
        JunwangEr = 14,
        JunwangSan = 15,
        ToutianYi = 16,
        ToutianEr = 17,
        ToutianSan = 18,
        JialanYi = 19,
        JialanEr = 20,
        JialanSan = 21,
        LingShouYi = 22,
        LingShouEr = 23,
        LingShouSan = 24,
        XueShouYi = 25,
        XueShouEr = 26,
        XueShouSan = 27,
        ShengShouYi = 28,
        ShengShouEr = 29,
        ShengShouSan = 30,


        Larva = 100,

        LesserWedgeMoth = 110,

        ZumaArcherMonster = 120,
        ZumaGuardianMonster = 121,
        ZumaFanaticMonster = 122,
        ZumaKeeperMonster = 123,

        BoneArcher = 130,
        BoneCaptain = 131,
        BoneBladesman = 132,
        BoneSoldier = 133,
        SkeletonEnforcer = 134,

        MatureEarwig = 140,
        GoldenArmouredBeetle = 141,
        Millipede = 142,

        FerociousFlameDemon = 150,
        FlameDemon = 151,

        GoruSpearman = 160,
        GoruArcher = 161,
        GoruGeneral = 162,

        DragonLord = 170,
        OYoungBeast = 171,
        YumgonWitch = 172,
        MaWarden = 173,
        MaWarlord = 174,
        JinhwanSpirit = 175,
        JinhwanGuardian = 176,
        OyoungGeneral = 177,
        YumgonGeneral = 178,

        BanyoCaptain = 180,

        SamaSorcerer = 190,
        BloodStone = 191,

        QuartzPinkBat = 200,
        QuartzBlueBat = 201,
        QuartzBlueCrystal = 202,
        QuartzRedHood = 203,
        QuartzMiniTurtle = 204,
        QuartzTurtleSub = 205,

        Sacrafice = 210,

        HellishBat = 211,

        HaidiGuicha = 212,
        HaidiFengjing = 213,
        HaidiMoling = 214,
        HaidiPixia = 215,

    }

    #region Packet Enums

    public enum NewAccountResult : byte
    {
        Disabled,
        BadEMail,
        BadPassword,
        BadRealName,
        AlreadyExists,
        BadReferral,
        ReferralNotFound,
        ReferralNotActivated,
        Success
    }

    public enum ChangePasswordResult : byte
    {
        Disabled,
        BadEMail,
        BadCurrentPassword,
        BadNewPassword,
        AccountNotFound,
        AccountNotActivated,
        WrongPassword,
        Banned,
        Success
    }
    public enum RequestPasswordResetResult : byte
    {
        Disabled,
        BadEMail,
        AccountNotFound,
        AccountNotActivated,
        ResetDelay,
        Banned,
        Success
    }
    public enum ResetPasswordResult : byte
    {
        Disabled,
        AccountNotFound,
        BadNewPassword,
        KeyExpired,
        Success
    }


    public enum ActivationResult : byte
    {
        Disabled,
        AccountNotFound,
        Success,
    }

    public enum RequestActivationKeyResult : byte
    {
        Disabled,
        BadEMail,
        AccountNotFound,
        AlreadyActivated,
        RequestDelay,
        Success,
    }

    public enum LoginResult : byte
    {
        Disabled,
        BadEMail,
        BadPassword,
        AccountNotExists,
        AccountNotActivated,
        WrongPassword,
        Banned,
        AlreadyLoggedIn,
        AlreadyLoggedInPassword,
        AlreadyLoggedInAdmin,
        Success
    }

    public enum NewCharacterResult : byte
    {
        Disabled,
        BadCharacterName,
        BadGender,
        BadClass,
        BadHairType,
        BadHairColour,
        BadArmourColour,
        ClassDisabled,
        MaxCharacters,
        AlreadyExists,
        Success
    }

    public enum DeleteCharacterResult : byte
    {
        Disabled,
        AlreadyDeleted,
        NotFound,
        Success
    }

    public enum StartGameResult : byte
    {
        Disabled,
        Deleted,
        Delayed,
        UnableToSpawn,
        NotFound,
        Success
    }

    public enum DisconnectReason : byte
    {
        Unknown,
        TimedOut,
        WrongVersion,
        ServerClosing,
        AnotherUser,
        AnotherUserPassword,
        AnotherUserAdmin,
        Banned,
        Crashed,
        TestGJAnswerFail,
    }




    #endregion

    #region Sound

    public enum SoundIndex     
    {
        None,
        LoginScene,
        SelectScene,

        
        B000,
        B2,
        B8,
        B009D,
        B009N,
        B0014D,
        B0014N,
        B100,
        B122,
        B300,
        B400,
        B14001,
        BD00,
        BD01,
        BD02,
        BD041,
        BD042,
        BD50,
        BD60,
        BD70,
        BD99,
        BD100,
        BD101,
        BD210,
        BD211,
        BDUnderseaCave,
        BDUnderseaCaveBoss,
        D3101,
        D3102,
        D3400,
        Dungeon_1,
        Dungeon_2,
        ID1_001,
        ID1_002,
        ID1_003,
        TS001,
        TS002,
        TS003,

        ButtonA,
        ButtonB,
        ButtonC,

        SelectWarriorMale,
        SelectWarriorFemale,
        SelectWizardMale,
        SelectWizardFemale,
        SelectTaoistMale,
        SelectTaoistFemale,
        SelectAssassinMale,
        SelectAssassinFemale,

        TeleportOut,
        TeleportIn,

        ItemPotion,
        ItemWeapon,
        ItemArmour,
        ItemRing,
        ItemBracelet,
        ItemNecklace,
        ItemHelmet,
        ItemShoes,
        ItemDefault,

        GoldPickUp,
        GoldGained,

        DaggerSwing,
        WoodSwing,
        IronSwordSwing,
        ShortSwordSwing,
        AxeSwing,
        ClubSwing,
        WandSwing,
        FistSwing,
        GlaiveAttack,
        ClawAttack,

        GenericStruckPlayer,
        GenericStruckMonster,

        Foot1,
        Foot2,
        Foot3,
        Foot4,
        HorseWalk1,
        HorseWalk2,
        HorseRun,

        MaleStruck,
        FemaleStruck,

        MaleDie,
        FemaleDie,

        #region Magics

        SlayingMale,
        SlayingFemale,

        EnergyBlast,

        HalfMoon,

        FlamingSword,

        DragonRise,

        BladeStorm,

        DestructiveBlow,

        DefianceStart,

        AssaultStart,

        SwiftBladeEnd,


        FireBallStart,
        FireBallTravel,
        FireBallEnd,

        ThunderBoltStart,
        ThunderBoltTravel,
        ThunderBoltEnd,

        IceBoltStart,
        IceBoltTravel,
        IceBoltEnd,

        GustBlastStart,
        GustBlastTravel,
        GustBlastEnd,

        RepulsionEnd,

        ElectricShockStart,
        ElectricShockEnd,

        GreaterFireBallStart,
        GreaterFireBallTravel,
        GreaterFireBallEnd,

        LightningStrikeStart,
        LightningStrikeEnd,

        GreaterIceBoltStart,
        GreaterIceBoltTravel,
        GreaterIceBoltEnd,

        CycloneStart,
        CycloneEnd,

        TeleportationStart,

        LavaStrikeStart,
        

        LightningBeamEnd,


        FrozenEarthStart,
        FrozenEarthEnd,

        BlowEarthStart,
        BlowEarthEnd,
        BlowEarthTravel,

        FireWallStart,
        FireWallEnd,

        ExpelUndeadStart,
        ExpelUndeadEnd,

        MagicShieldStart,

        FireStormStart,
        FireStormEnd,

        LightningWaveStart,
        LightningWaveEnd,

        IceStormStart,
        IceStormEnd,

        DragonTornadoStart,
        DragonTornadoEnd,

        GreaterFrozenEarthStart,
        GreaterFrozenEarthEnd,

        ChainLightningStart,
        ChainLightningEnd,

        FrostBiteStart,


        HealStart,
        HealEnd,

        PoisonDustStart,
        PoisonDustEnd,

        ExplosiveTalismanStart,
        ExplosiveTalismanTravel,
        ExplosiveTalismanEnd,

        HolyStrikeStart,
        HolyStrikeTravel,
        HolyStrikeEnd,

        ImprovedHolyStrikeStart,
        ImprovedHolyStrikeTravel,
        ImprovedHolyStrikeEnd,

        MagicResistanceTravel,
        MagicResistanceEnd,

        ResilienceTravel,
        ResilienceEnd,

        ShacklingTalismanStart,
        ShacklingTalismanEnd,

        SummonSkeletonStart,
        SummonSkeletonEnd,

        InvisibilityEnd,

        MassInvisibilityTravel,
        MassInvisibilityEnd,

        TaoistCombatKickStart,

        MassHealStart,
        MassHealEnd,

        BloodLustTravel,
        BloodLustEnd,

        ResurrectionStart,

        PurificationStart,
        PurificationEnd,

        SummonShinsuStart,
        SummonShinsuEnd,

        StrengthOfFaithStart,
        StrengthOfFaithEnd,

        NeutralizeEnd,


        PoisonousCloudStart,

        CloakStart,

        WraithGripStart,
        WraithGripEnd,

        HellFireStart,

        FullBloom,
        WhiteLotus,
        RedLotus,
        SweetBrier,
        SweetBrierMale,
        SweetBrierFemale,

        Karma,

        TheNewBeginning,

        SummonPuppet,

        DanceOfSwallowsEnd,
        DragonRepulseStart,
        AbyssStart,
        FlashOfLightEnd,
        EvasionStart,
        RagingWindStart,
        Concentration,

        #endregion

        #region Monsters

        ChickenAttack,
        ChickenStruck,
        ChickenDie,

        PigAttack,
        PigStruck,
        PigDie,

        DeerAttack,
        DeerStruck,
        DeerDie,

        CowAttack,
        CowStruck,
        CowDie,

        SheepAttack,
        SheepStruck,
        SheepDie,

        ClawCatAttack,
        ClawCatStruck,
        ClawCatDie,

        WolfAttack,
        WolfStruck,
        WolfDie,

        ForestYetiAttack,
        ForestYetiStruck,
        ForestYetiDie,

        CarnivorousPlantAttack,
        CarnivorousPlantStruck,
        CarnivorousPlantDie,

        OmaAttack,
        OmaStruck,
        OmaDie,

        TigerSnakeAttack,
        TigerSnakeStruck,
        TigerSnakeDie,

        SpittingSpiderAttack,
        SpittingSpiderStruck,
        SpittingSpiderDie,

        ScarecrowAttack,
        ScarecrowStruck,
        ScarecrowDie,

        OmaHeroAttack,
        OmaHeroStruck,
        OmaHeroDie,

        CaveBatAttack,
        CaveBatStruck,
        CaveBatDie,

        ScorpionAttack,
        ScorpionStruck,
        ScorpionDie,

        SkeletonAttack,
        SkeletonStruck,
        SkeletonDie,

        SkeletonAxeManAttack,
        SkeletonAxeManStruck,
        SkeletonAxeManDie,

        SkeletonAxeThrowerAttack,
        SkeletonAxeThrowerStruck,
        SkeletonAxeThrowerDie,

        SkeletonWarriorAttack,
        SkeletonWarriorStruck,
        SkeletonWarriorDie,

        SkeletonLordAttack,
        SkeletonLordStruck,
        SkeletonLordDie,

        CaveMaggotAttack,
        CaveMaggotStruck,
        CaveMaggotDie,

        GhostSorcererAttack,
        GhostSorcererStruck,
        GhostSorcererDie,

        GhostMageAppear,
        GhostMageAttack,
        GhostMageStruck,
        GhostMageDie,

        VoraciousGhostAttack,
        VoraciousGhostStruck,
        VoraciousGhostDie,

        GhoulChampionAttack,
        GhoulChampionStruck,
        GhoulChampionDie,

        ArmoredAntAttack,
        ArmoredAntStruck,
        ArmoredAntDie,

        AntNeedlerAttack,
        AntNeedlerStruck,
        AntNeedlerDie,


        KeratoidAttack,
        KeratoidStruck,
        KeratoidDie,

        ShellNipperAttack,
        ShellNipperStruck,
        ShellNipperDie,

        VisceralWormAttack,
        VisceralWormStruck,
        VisceralWormDie,


        MutantFleaAttack,
        MutantFleaStruck,
        MutantFleaDie,

        PoisonousMutantFleaAttack,
        PoisonousMutantFleaStruck,
        PoisonousMutantFleaDie,

        BlasterMutantFleaAttack,
        BlasterMutantFleaStruck,
        BlasterMutantFleaDie,


        WasHatchlingAttack,
        WasHatchlingStruck,
        WasHatchlingDie,

        CentipedeAttack,
        CentipedeStruck,
        CentipedeDie,

        ButterflyWormAttack,
        ButterflyWormStruck,
        ButterflyWormDie,

        MutantMaggotAttack,
        MutantMaggotStruck,
        MutantMaggotDie,

        EarwigAttack,
        EarwigStruck,
        EarwigDie,

        IronLanceAttack,
        IronLanceStruck,
        IronLanceDie,

        LordNiJaeAttack,
        LordNiJaeStruck,
        LordNiJaeDie,

        RottingGhoulAttack,
        RottingGhoulStruck,
        RottingGhoulDie,

        DecayingGhoulAttack,
        DecayingGhoulStruck,
        DecayingGhoulDie,

        BloodThirstyGhoulAttack,
        BloodThirstyGhoulStruck,
        BloodThirstyGhoulDie,


        SpinedDarkLizardAttack,
        SpinedDarkLizardStruck,
        SpinedDarkLizardDie,

        UmaInfidelAttack,
        UmaInfidelStruck,
        UmaInfidelDie,

        UmaFlameThrowerAttack,
        UmaFlameThrowerStruck,
        UmaFlameThrowerDie,

        UmaAnguisherAttack,
        UmaAnguisherStruck,
        UmaAnguisherDie,

        UmaKingAttack,
        UmaKingStruck,
        UmaKingDie,

        SpiderBatAttack,
        SpiderBatStruck,
        SpiderBatDie,

        ArachnidGazerStruck,
        ArachnidGazerDie,

        LarvaAttack,
        LarvaStruck,

        RedMoonGuardianAttack,
        RedMoonGuardianStruck,
        RedMoonGuardianDie,

        RedMoonProtectorAttack,
        RedMoonProtectorStruck,
        RedMoonProtectorDie,

        VenomousArachnidAttack,
        VenomousArachnidStruck,
        VenomousArachnidDie,

        DarkArachnidAttack,
        DarkArachnidStruck,
        DarkArachnidDie,

        RedMoonTheFallenAttack,
        RedMoonTheFallenStruck,
        RedMoonTheFallenDie,


        ViciousRatAttack,
        ViciousRatStruck,
        ViciousRatDie,

        ZumaSharpShooterAttack,
        ZumaSharpShooterStruck,
        ZumaSharpShooterDie,

        ZumaFanaticAttack,
        ZumaFanaticStruck,
        ZumaFanaticDie,

        ZumaGuardianAttack,
        ZumaGuardianStruck,
        ZumaGuardianDie,

        ZumaKingAppear,
        ZumaKingAttack,
        ZumaKingStruck,
        ZumaKingDie,

        EvilFanaticAttack,
        EvilFanaticStruck,
        EvilFanaticDie,

        MonkeyAttack,
        MonkeyStruck,
        MonkeyDie,

        EvilElephantAttack,
        EvilElephantStruck,
        EvilElephantDie,

        CannibalFanaticAttack,
        CannibalFanaticStruck,
        CannibalFanaticDie,

        SpikedBeetleAttack,
        SpikedBeetleStruck,
        SpikedBeetleDie,

        NumaGruntAttack,
        NumaGruntStruck,
        NumaGruntDie,

        NumaMageAttack,
        NumaMageStruck,
        NumaMageDie,

        NumaEliteAttack,
        NumaEliteStruck,
        NumaEliteDie,

        SandSharkAttack,
        SandSharkStruck,
        SandSharkDie,

        StoneGolemAppear,
        StoneGolemAttack,
        StoneGolemStruck,
        StoneGolemDie,

        WindfurySorceressAttack,
        WindfurySorceressStruck,
        WindfurySorceressDie,

        CursedCactusAttack,
        CursedCactusStruck,
        CursedCactusDie,

        RagingLizardAttack,
        RagingLizardStruck,
        RagingLizardDie,

        SawToothLizardAttack,
        SawToothLizardStruck,
        SawToothLizardDie,

        MutantLizardAttack,
        MutantLizardStruck,
        MutantLizardDie,

        VenomSpitterAttack,
        VenomSpitterStruck,
        VenomSpitterDie,

        SonicLizardAttack,
        SonicLizardStruck,
        SonicLizardDie,

        GiantLizardAttack,
        GiantLizardStruck,
        GiantLizardDie,

        CrazedLizardAttack,
        CrazedLizardStruck,
        CrazedLizardDie,

        TaintedTerrorAttack,
        TaintedTerrorStruck,
        TaintedTerrorDie,
        TaintedTerrorAttack2,

        DeathLordJichonAttack,
        DeathLordJichonStruck,
        DeathLordJichonDie,
        DeathLordJichonAttack2,
        DeathLordJichonAttack3,


        MinotaurAttack,
        MinotaurStruck,
        MinotaurDie,

        FrostMinotaurAttack,
        FrostMinotaurStruck,
        FrostMinotaurDie,

        BanyaLeftGuardAttack,
        BanyaLeftGuardStruck,
        BanyaLeftGuardDie,

        EmperorSaWooAttack,
        EmperorSaWooStruck,
        EmperorSaWooDie,



        BoneArcherAttack,
        BoneArcherStruck,
        BoneArcherDie,

        BoneCaptainAttack,
        BoneCaptainStruck,
        BoneCaptainDie,

        ArchLichTaeduAttack,
        ArchLichTaeduStruck,
        ArchLichTaeduDie,

        WedgeMothLarvaAttack,
        WedgeMothLarvaStruck,
        WedgeMothLarvaDie,

        LesserWedgeMothAttack,
        LesserWedgeMothStruck,
        LesserWedgeMothDie,

        WedgeMothAttack,
        WedgeMothStruck,
        WedgeMothDie,

        RedBoarAttack,
        RedBoarStruck,
        RedBoarDie,

        ClawSerpentAttack,
        ClawSerpentStruck,
        ClawSerpentDie,

        BlackBoarAttack,
        BlackBoarStruck,
        BlackBoarDie,

        TuskLordAttack,
        TuskLordStruck,
        TuskLordDie,

        RazorTuskAttack,
        RazorTuskStruck,
        RazorTuskDie,


        PinkGoddessAttack,
        PinkGoddessStruck,
        PinkGoddessDie,

        GreenGoddessAttack,
        GreenGoddessStruck,
        GreenGoddessDie,

        MutantCaptainAttack,
        MutantCaptainStruck,
        MutantCaptainDie,

        StoneGriffinAttack,
        StoneGriffinStruck,
        StoneGriffinDie,

        FlameGriffinAttack,
        FlameGriffinStruck,
        FlameGriffinDie,

        WhiteBoneAttack,
        WhiteBoneStruck,
        WhiteBoneDie,

        ShinsuSmallStruck,
        ShinsuSmallDie,

        ShinsuBigAttack,
        ShinsuBigStruck,
        ShinsuBigDie,

        ShinsuShow,


        CorpseStalkerAttack,
        CorpseStalkerStruck,
        CorpseStalkerDie,

        LightArmedSoldierAttack,
        LightArmedSoldierStruck,
        LightArmedSoldierDie,

        CorrosivePoisonSpitterAttack,
        CorrosivePoisonSpitterStruck,
        CorrosivePoisonSpitterDie,

        PhantomSoldierAttack,
        PhantomSoldierStruck,
        PhantomSoldierDie,

        MutatedOctopusAttack,
        MutatedOctopusStruck,
        MutatedOctopusDie,

        AquaLizardAttack,
        AquaLizardStruck,
        AquaLizardDie,


        CrimsonNecromancerAttack,
        CrimsonNecromancerStruck,
        CrimsonNecromancerDie,

        ChaosKnightAttack,
        ChaosKnightStruck,
        ChaosKnightDie,

        PachontheChaosbringerAttack,
        PachontheChaosbringerStruck,
        PachontheChaosbringerDie,


        NumaCavalryAttack,
        NumaCavalryStruck,
        NumaCavalryDie,

        NumaHighMageAttack,
        NumaHighMageStruck,
        NumaHighMageDie,

        NumaStoneThrowerAttack,
        NumaStoneThrowerStruck,
        NumaStoneThrowerDie,

        NumaRoyalGuardAttack,
        NumaRoyalGuardStruck,
        NumaRoyalGuardDie,

        NumaArmoredSoldierAttack,
        NumaArmoredSoldierStruck,
        NumaArmoredSoldierDie,



        IcyRangerAttack,
        IcyRangerStruck,
        IcyRangerDie,

        IcyGoddessAttack,
        IcyGoddessStruck,
        IcyGoddessDie,

        IcySpiritWarriorAttack,
        IcySpiritWarriorStruck,
        IcySpiritWarriorDie,

        IcySpiritGeneralAttack,
        IcySpiritGeneralStruck,
        IcySpiritGeneralDie,

        GhostKnightAttack,
        GhostKnightStruck,
        GhostKnightDie,

        IcySpiritSpearmanAttack,
        IcySpiritSpearmanStruck,
        IcySpiritSpearmanDie,

        WerewolfAttack,
        WerewolfStruck,
        WerewolfDie,

        WhitefangAttack,
        WhitefangStruck,
        WhitefangDie,

        IcySpiritSoliderAttack,
        IcySpiritSoliderStruck,
        IcySpiritSoliderDie,

        WildBoarAttack,
        WildBoarStruck,
        WildBoarDie,

        FrostLordHwaAttack,
        FrostLordHwaStruck,
        FrostLordHwaDie,

        JinchonDevilAttack,
        JinchonDevilAttack2,
        JinchonDevilAttack3,
        JinchonDevilStruck,
        JinchonDevilDie,

        EscortCommanderAttack,
        EscortCommanderStruck,
        EscortCommanderDie,

        FieryDancerAttack,
        FieryDancerStruck,
        FieryDancerDie,

        EmeraldDancerAttack,
        EmeraldDancerStruck,
        EmeraldDancerDie,

        QueenOfDawnAttack,
        QueenOfDawnStruck,
        QueenOfDawnDie,



        OYoungBeastAttack,
        OYoungBeastStruck,
        OYoungBeastDie,

        YumgonWitchAttack,
        YumgonWitchStruck,
        YumgonWitchDie,

        MaWarlordAttack,
        MaWarlordStruck,
        MaWarlordDie,

        JinhwanSpiritAttack,
        JinhwanSpiritStruck,
        JinhwanSpiritDie,

        JinhwanGuardianAttack,
        JinhwanGuardianStruck,
        JinhwanGuardianDie,

        YumgonGeneralAttack,
        YumgonGeneralStruck,
        YumgonGeneralDie,

        ChiwooGeneralAttack,
        ChiwooGeneralStruck,
        ChiwooGeneralDie,

        DragonQueenAttack,
        DragonQueenStruck,
        DragonQueenDie,

        DragonLordAttack,
        DragonLordStruck,
        DragonLordDie,

        FerociousIceTigerAttack,
        FerociousIceTigerStruck,
        FerociousIceTigerDie,



        SamaFireGuardianAttack,
        SamaFireGuardianStruck,
        SamaFireGuardianDie,

        SamaIceGuardianAttack,
        SamaIceGuardianStruck,
        SamaIceGuardianDie,

        SamaLightningGuardianAttack,
        SamaLightningGuardianStruck,
        SamaLightningGuardianDie,

        SamaWindGuardianAttack,
        SamaWindGuardianStruck,
        SamaWindGuardianDie,


        PhoenixAttack,
        PhoenixStruck,
        PhoenixDie,

        BlackTortoiseAttack,
        BlackTortoiseStruck,
        BlackTortoiseDie,

        BlueDragonAttack,
        BlueDragonStruck,
        BlueDragonDie,

        WhiteTigerAttack,
        WhiteTigerStruck,
        WhiteTigerDie,




        #endregion

        ThunderKickEnd,

        ThunderKickStart,
        RakeStart,

        CrazedPrimateAttack,
        CrazedPrimateStruck,
        CrazedPrimateDie,
        HellBringerAttack,
        HellBringerAttack2,
        HellBringerAttack3,
        HellBringerStruck,
        HellBringerDie,
        YurinHoundAttack,
        YurinHoundStruck,
        YurinHoundDie,
        YurinTigerAttack,
        YurinTigerStruck,
        YurinTigerDie,
        HardenedRhinoAttack,
        HardenedRhinoStruck,
        HardenedRhinoDie,
        MammothAttack,
        MammothStruck,
        MammothDie,
        CursedSlave1Attack,
        CursedSlave1Attack2,
        CursedSlave1Struck,
        CursedSlave1Die,
        CursedSlave2Attack,
        CursedSlave2Struck,
        CursedSlave2Die,
        CursedSlave3Attack,
        CursedSlave3Attack2,
        CursedSlave3Struck,
        CursedSlave3Die,
        PoisonousGolemAttack,
        PoisonousGolemAttack2,
        PoisonousGolemStruck,
        PoisonousGolemDie,

        ElementalHurricane,
        DarkSoulPrison,

        GardenSoldierAttack,
        GardenSoldierAttack2,
        GardenSoldierStruck,
        GardenSoldierDie,

        GardenDefenderAttack,
        GardenDefenderAttack2,
        GardenDefenderStruck,
        GardenDefenderDie,

        RedBlossomAttack,
        RedBlossomAttack2,
        RedBlossomStruck,
        RedBlossomDie,

        BlueBlossomAttack,
        BlueBlossomStruck,
        BlueBlossomDie,

        FireBirdAttack,
        FireBirdAttack2,
        FireBirdAttack3,
        FireBirdStruck,
        FireBirdDie,

        
        WolongbianfuAttack,
        WolongbianfuAttack2,
        WolongbianfuStruck,
        WolongbianfuDie,

    }
    #endregion
    */
}