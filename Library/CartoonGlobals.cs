using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Library.Network;
using Library.Network.ServerPackets;
using Library.SystemModels;
using CartoonMirDB;

namespace Library
{
    public static class CartoonGlobals
    {
        public static ItemInfo GoldInfo;

        public static DBCollection<ItemInfo> ItemInfoList;
        public static DBCollection<MagicInfo> MagicInfoList;
        
        public static DBCollection<FubenInfo> FubenInfoList;
        
        public static DBCollection<MingwenInfo> MingwenInfoList;
        public static DBCollection<MapInfo> MapInfoList;
        public static DBCollection<NPCPage> NPCPageList;
        public static DBCollection<MonsterInfo> MonsterInfoList;
        public static DBCollection<StoreInfo> StoreInfoList;
        public static DBCollection<NPCInfo> NPCInfoList;
        public static DBCollection<MovementInfo> MovementInfoList;
        public static DBCollection<QuestInfo> QuestInfoList;
        public static DBCollection<QuestTask> QuestTaskList;
        public static DBCollection<MeiriQuestInfo> MeiriQuestInfoList;
        public static DBCollection<MeiriQuestTask> MeiriQuestTaskList;
        public static DBCollection<CompanionInfo> CompanionInfoList;
        public static DBCollection<CompanionLevelInfo> CompanionLevelInfoList;
        public static DBCollection<CraftLevelInfo> CraftingLevelsInfoList;
        public static DBCollection<CraftItemInfo> CraftingItemInfoList;
        public static DBCollection<DropInfo> DropInfoList;
        public static DBCollection<MonsterCostomInfo> MonCustomInfoList;
        public static DBCollection<MiniGameInfo> MiniGameInfoList;
        public static DBCollection<HorseInfo> HorseInfoList;


        public static Random Random  = new Random();

        public static readonly Regex EMailRegex = new Regex(@"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", RegexOptions.Compiled);
        public static readonly Regex PasswordRegex = new Regex(@"^[\S]{" + MinPasswordLength + "," + MaxPasswordLength + "}$", RegexOptions.Compiled);
        public static readonly Regex CharacterReg = new Regex(@"^[A-Za-z0-9\u4e00-\u9fa5]{" + MinCharacterNameLength + "," + MaxCharacterNameLength + @"}$", RegexOptions.Compiled);
        public static readonly Regex GuildNameRegex = new Regex(@"^[A-Za-z0-9\u4e00-\u9fa5]{" + MinGuildNameLength + "," + MaxGuildNameLength + "}$", RegexOptions.Compiled);
        
        public static readonly Regex CDkeyReg = new Regex(@"^[A-Za-z0-9\u4e00-\u9fa5]{" + MinCDkeyLength + "," + MaxCDkeyLength + @"}$", RegexOptions.Compiled);

        public static Color NoneColour = Color.White,
                            FireColour = Color.OrangeRed,
                            IceColour = Color.PaleTurquoise,
                            LightningColour = Color.LightSkyBlue,
                            WindColour = Color.LightSeaGreen,
                            HolyColour = Color.DarkKhaki,
                            DarkColour = Color.SaddleBrown,
                            PhantomColour = Color.Purple,

                            BrownNameColour = Color.Brown,
                            RedNameColour = Color.Red,


                            PoorColour = Color.FromArgb(157, 157, 157),
                            CommonColour = Color.White,
                            UncommonColour = Color.FromArgb(30, (int)byte.MaxValue, 0),
                            RareColour = Color.FromArgb(0, 112, 221),
                            EpicColour = Color.FromArgb(163, 53, 238),
                            LegendaryColour = Color.FromArgb((int)byte.MaxValue, 149, 0),
                            ArtifactColour = Color.FromArgb((int)byte.MaxValue, 234, 0),
                            HeirloomColour = Color.FromArgb(0, (int)byte.MaxValue, 242);

        public const int
            MinPasswordLength = 5,
            MaxPasswordLength = 15,

            MinRealNameLength = 2,
            MaxRealNameLength = 12,

            MaxEMailLength = 50,

            MinCharacterNameLength = 2,
            MaxCharacterNameLength = 7,
            MaxCharacterCount = 4,

            MinGuildNameLength = 2,
            MaxGuildNameLength = 7,

            MaxChatLength = 120,
            MaxGuildNoticeLength = 4000,

            MaxBeltCount = 10,
            MaxAutoPotionCount = 8,
            
            MaxTeleportCount = 10,

            Fubendian = 5,

            MagicRange = 10,

            DuraLossRate = 15,

            GroupLimit = 15,

            CloakRange = 3,
            MarketPlaceFee = 0,
            AccessoryLevelCost = 0,
            AccessoryResetCost = 1000000,
            
            DunLevelCost = 0,
            DunResetCost = 5000,
            
            HuiLevelCost = 0,
            HuiResetCost = 5000,

            MaxDailyRandomQuestResets = 2,

            CraftWeaponPercentCost = 1000000,

            CommonCraftWeaponPercentCost = 30000000,
            SuperiorCraftWeaponPercentCost = 60000000,
            EliteCraftWeaponPercentCost = 80000000,

            XiangKanGJSTLevelCost = 0,
            FlagIndexCount = 1999,

            
            MinCDkeyLength = 16,
            MaxCDkeyLength = 16,

            
            MingwenFeiyong = 10000,

            ChaoticHeavenGlaiveImageOffset = 10000000;




        public static decimal MarketPlaceTax = 0.05M;  


        public static long
            GuildCreationCost = 7500000,
            GuildMemberCost = 1000000,
            GuildStorageCost = 350000,
            GuildWarCost = 200000;

        public static long
            MasterRefineCost = 50000,
            MasterRefineEvaluateCost = 500000;

        public static long
            MaxGold = 1001000000;


        public static List<Size> ValidResolutions = new List<Size>
        {
            new Size(1024, 600),
            new Size(1024, 768),
            new Size(1280, 720),
            new Size(1280, 768),
            new Size(1280, 800),
            new Size(1280, 960),
            new Size(1280, 1024),
            new Size(1360, 768),
            new Size(1360, 1024),
            new Size(1366, 768),
            new Size(1440, 900),
            new Size(1600, 900),
            new Size(1680, 1050),
            new Size(1920, 1080),
        };

        public static List<string> Languages = new List<string>
        {
            
            "Chinese",
        };








        public static List<decimal> ExperienceList = new List<decimal>
        {
           
            0,
           17,
           33,
           50,
           67,
           100,
           150,
           200,
           283,
           417,
           1000,
           1333,
           1667,
           2500,
           5000,
           6667,
           8333,
           11667,
           16667,
           20000,
           23333,
           41667,
           50000,
           58333,
           66667,
           83333,
           116667,
           166667,
           233333,
           300000,
           500000,
           600000,
           700000,
           800000,
           900000,
           1000000,
           1200000,
           1400000,
           2050000,
           2250000,
           2750000,
           3500000,
           6250000,
           11250000,
           17500000,
           22500000,
           27500000,
           32500000,
           37500000,
           42500000,
           47500000,
           52500000,
           57500000,
           67500000,
           77500000,
           82500000,
           87500000,
           100000000,
           100000000,
           100000000,
           100000000,
           100000000,
           100000000,
           100000000,
           100000000,
           100000000,
           100000000,
           100000000,
           100000000,
           100000000,
           100000000,
           160000000,
           280000000,
           440000000,
           640000000,
           720000000,
           800000000,
           900000000,
           1000000000,
           3000000000,
           7500000000,
           8333333333,
           9166666667,
           10000000000,
           16666666667,
           20000000000,
           147067727692,
           164567727692,
           229567727692,
           302067727692,
           322067727692,
           332067727692,
           375401061025,
           440401061025,
           460401061025,
           540401061025,
           580401061025,
           620401061025,
           753067727692,
           828967727692,
           916252727692,
           1089963811025,
           1205398223525,
           1338147797900,
           1567476475098,
           1743037787209,
           1944933296137,
           2258779798070,
           2525786608627,
           2832844440767,
           3289294281062,
           3695378264067,
           4162374844524,
           4809420912048,
           5427023889702,
           6137267314003,
           7074047251950,
           8013344180588,
           9093535648523,
           10469089169981,
           11897642386324,
           13540478585119,
           15576406880400,
           17749057753306,
           20247606257148,
           23289603703233,
           26593934099564,
           30393914055345,
           34957857671159,
           39983331162679,
           45762625677927,
           52631876037129,
           60274993033545,
           69064577579423,
           79429120723849,
           91053346285772,
           104421205681984,
           120089243041794,
           137768237093285,
           158099080252499,
           181818798797886,
           208706338875947,
           239627009965717,
           275575917968087,
           316468505484307,
           363494981127960,
           418024084804667,
           480216598843399,
           551737989987940,
           634503544993645,

           
           /*
            0,
           17,
           33,
           50,
           67,
           100,
           150,
           200,
           283,
           417,
           1000,
           1333,
           1667,
           2500,
           5000,
           6667,
           8333,
           11667,
           16667,
           20000,
           23333,
           41667,
           50000,
           58333,
           66667,
           83333,
           116667,
           166667,
           233333,
           300000,
           500000,
           600000,
           700000,
           800000,
           900000,
           1000000,
           1200000,
           1400000,
           2050000,
           2250000,
           2750000,
           3500000,
           6250000,
           11250000,
           17500000,
           22500000,
           27500000,
           32500000,
           37500000,
           42500000,
           190000000,
           210000000,
           230000000,
           270000000,
           310000000,
           330000000,
           350000000,
           400000000,
           400000000,
           400000000,
           400000000,
           400000000,
           400000000,
           400000000,
           400000000,
           400000000,
           400000000,
           400000000,
           400000000,
           400000000,
           400000000,
           800000000,
           1400000000,
           2200000000,
           3200000000,
           3600000000,
           4000000000,
           4500000000,
           5000000000,
           15000000000,
           45000000000,
           50000000000,
           55000000000,
           60000000000,
           100000000000,
           120000000000,
           294135455384,
           329135455384,
           459135455384,
           604135455384,
           644135455384,
           664135455384,
           750802122050,
           880802122050,
           920802122050,
           1080802122050,
           1160802122050,
           1240802122050,
           1506135455384,
           1657935455384,
           1832505455384,
           2179927622050,
           2410796447050,
           2676295595800,
           3134952950196,
           3486075574418,
           3889866592273,
           4517559596140,
           5051573217253,
           5665688881534,
           6578588562123,
           7390756528134,
           8324749689047,
           9618841824096,
           10854047779403,
           12274534628006,
           14148094503899,
           16026688361176,
           18187071297045,
           20938178339961,
           23795284772648,
           27080957170237,
           31152813760799,
           35498115506611,
           40495212514295,
           46579207406465,
           53187868199127,
           60787828110689,
           69915715342318,
           79966662325358,
           91525251355854,
           105263752074258,
           120549986067089,
           138129155158845,
           158858241447697,
           182106692571544,
           208842411363968,
           240178486083589,
           275536474186570,
           316198160504998,
           363637597595773,
           417412677751894,
           479254019931434,
           551151835936174,
           632937010968615,
           726989962255921,
           836048169609335,
           960433197686798,
           1103475979975880,
           1269007089987290,
           */

            
            /*
            0,
            17,
            33,
            50,
            67,
            100,
            150,
            200,
            283,
            417,
            1000,
            1333,
            1667,
            2500,
            5000,
            6667,
            8333,
            11667,
            16667,
            20000,
            23333,
            41667,
            50000,
            58333,
            66667,
            83333,
            116667,
            166667,
            233333,
            300000,
            500000,
            600000,
            700000,
            800000,
            900000,
            1000000,
            1200000,
            1400000,
            2050000,
            2250000,
            2750000,
            3500000,
            6250000,
            11250000,
            17500000,
            22500000,
            27500000,
            32500000,
            37500000,
            42500000,
            190000000,
            210000000,
            230000000,
            270000000,
            310000000,
            330000000,
            350000000,
            400000000,
            400000000,
            400000000,
            400000000,
            400000000,
            400000000,
            400000000,
            400000000,
            400000000,
            400000000,
            400000000,
            400000000,
            400000000,
            400000000,
            800000000,
            1400000000,
            2200000000,
            3200000000,
            3600000000,
            4000000000,
            4500000000,
            5000000000,
            15000000000,
            45000000000,
            50000000000,
            55000000000,
            60000000000,
            100000000000,
            120000000000,
            135000000000,
            170000000000,
            300000000000,
            400000000000,
            440000000000,
            460000000000,
            490000000000,
            620000000000,
            660000000000,
            720000000000,
            800000000000,
            880000000000,
            999999999999,
            1880000000000,
            2000000000000,
            */
            
            /*
            0,
            100,
            200,
            300,
            400,
            600,
            900,
            1200,
            1700,
            2500,
            6000,
            8000,
            10000,
            15000,
            30000,
            40000,
            50000,
            70000,
            100000,
            120000,
            140000,
            250000,
            300000,
            350000,
            400000,
            500000,
            700000,
            1000000,
            1400000,
            1800000,
            2000000,
            2400000,
            2800000,
            3200000,
            3600000,
            4000000,
            4800000,
            5600000,
            8200000,
            9000000,
            11000000,
            14000000,
            25000000,
            45000000,
            70000000,
            90000000,
            110000000,
            130000000,
            150000000,
            170000000,
            190000000,
            210000000,
            230000000,
            270000000,
            310000000,
            330000000,
            350000000,
            400000000,
            400000000,
            400000000,
            400000000,
            400000000,
            400000000,
            400000000,
            400000000,
            400000000,
            400000000,
            400000000,
            400000000,
            400000000,
            400000000,
            800000000,
            1400000000,
            2200000000,
            3200000000,
            3600000000,
            4000000000,
            4500000000,
            5000000000,
            15000000000,
            45000000000,
            50000000000,
            55000000000,
            60000000000,
            100000000000,
            120000000000,
            135000000000,
            170000000000,
            300000000000,
            400000000000,
            440000000000,
            460000000000,
            490000000000,
            620000000000,
            660000000000,
            720000000000,
            800000000000,
            880000000000,
            999999999999,
            1880000000000,
            2000000000000,
            */
        };

        public static List<decimal> OldExperienceList = new List<decimal>
        {
            0, 
            100,
            200,
            300,
            400,
            600,
            900,
            1200,
            1700,
            2500,
            6000,
            8000,
            10000,
            15000,
            30000,
            40000,
            50000,
            70000,
            100000,
            120000,
            140000,
            250000,
            300000,
            350000,
            400000,
            500000,
            700000,
            1000000,
            1400000,
            1800000,
            2000000,
            2400000,
            2800000,
            3200000,
            3600000,
            4000000,
            4800000,
            5600000,
            8200000,
            9000000,
            11000000,
            14000000,
            25000000,
            45000000,
            70000000,
            90000000,
            110000000,
            130000000,
            150000000,
            170000000,
            210000000,
            230000000,
            250000000,
            270000000,
            310000000,
            330000000,
            350000000,
            370000000,
            400000000,
            400000000,
            400000000,
            400000000,
            400000000,
            400000000,
            400000000,
            400000000,
            400000000,
            400000000,
            400000000,
            400000000,
            400000000,
            400000000,
            800000000,
            1400000000,
            2200000000,
            3200000000,
            3600000000,
            4000000000,
            4500000000,
            5000000000,
            15000000000,
            45000000000,
            50000000000,
            55000000000,
            60000000000,
            100000000000,
            120000000000,
            135000000000,
            150000000000,
            170000000000,
            300000000000,
            400000000000,
            440000000000,
            460000000000,
            490000000000,
            620000000000,
            660000000000,
            720000000000,
            800000000000,
            880000000000,
            1000000000000,
        };

        public static List<decimal> WeaponExperienceList = new List<decimal>
        {
            0, 

            300000,
            350000,
            400000,
            450000,
            500000,
            550000,
            600000,
            650000,
            700000,
            750000, 

            800000,
            850000,
            900000,
            1000000,
            1300000,
            2000000,
        };

        
        public static List<long> GonghuiContributionList = new List<long>
        {
            0,

            100000,
            300000,
            700000,
            1200000,
            1800000,
            2500000,
            3000000,
            6000000,
            10000000,
            15000000,
            22000000,
            50000000,
            80000000,
            150000000,
            250000000,
        };

        
        public static List<decimal> JyhuishouExperienceList = new List<decimal>
        {
            0,

            1000000,
            3000000,
            7000000,
            12000000,
            18000000,
            25000000,
            30000000,
            45000000,
            60000000,
            100000000,
        };
        
        public static List<decimal> AccessoryExperienceList = new List<decimal>
        {
            0,

            5,
            20,
            80,
            350,
            1500,
            6200,
            26500,
            114000,
            490000,
            2090000,
        };
        
        public static List<decimal> DunExperienceList = new List<decimal>
        {
            0,

            5000,
            15000,
            30000,
            50000,
            75000,
            120000,
            150000,
            200000,
            290000,
            500000,
        };
        
        public static List<decimal> HuiExperienceList = new List<decimal>
        {
            0,

            5000,
            15000,
            30000,
            50000,
            75000,
            120000,
            150000,
            200000,
            290000,
            500000,
        };
        public static List<decimal> XiangKanGJSTExperienceList = new List<decimal>
        {
            0,
            20900000000000,
            59090000000000,
            20,
            80,
            350,
            1500,
            6200,
            26500,
            114000,
            490000,
            2090000,
        };

        
        public static List<decimal> MingwenExperienceList = new List<decimal>
        {
            0,

            100,
            150,
            100000000,
        };


        public const int InventorySize = 289,
                         PatchGridSize = 21,
                         EquipmentSize = 19,
                         CompanionInventorySize = 60,
                         CompanionEquipmentSize = 4,
                         EquipmentOffSet = 1000, 
                         PatchOffSet = 2000,
                         StorageSize = 100,
                         BaoshiGridSize = 7;



        public const int AttackDelay = 1500,
                         ASpeedRate = 47,
                         ProjectileSpeed = 48;

        public static TimeSpan TurnTime = TimeSpan.FromMilliseconds(300),
                               HarvestTime = TimeSpan.FromMilliseconds(600),
                               MoveTime = TimeSpan.FromMilliseconds(600),
                               AttackTime = TimeSpan.FromMilliseconds(600),
                               CastTime = TimeSpan.FromMilliseconds(600),
                               MagicDelay = TimeSpan.FromMilliseconds(2000);


        public static bool RealNameRequired = false,
                           BirthDateRequired = false;

        public static Dictionary<RefineQuality, TimeSpan> RefineTimes = new Dictionary<RefineQuality, TimeSpan>
        {
            [RefineQuality.Rush] = TimeSpan.FromMinutes(1),
            [RefineQuality.Quick] = TimeSpan.FromMinutes(30),
            [RefineQuality.Standard] = TimeSpan.FromHours(1),
            [RefineQuality.Careful] = TimeSpan.FromHours(6),
            [RefineQuality.Precise] = TimeSpan.FromDays(1),
        };
    }

    public sealed class ClientAutoFightLink
    {
        public AutoSetConf Slot { get; set; }

        public MagicType MagicIndex { get; set; }

        public bool Enabled { get; set; }

        public int TimeCount { get; set; }
    }
    
    public sealed class ClientUserCrafting
    {
        public CraftType Type
        {
            get;
            set;
        }

        public int Level
        {
            get;
            set;
        }

        public int Exp
        {
            get;
            set;
        }
    }

    public sealed class SelectInfo
    {
        public int CharacterIndex { get; set; }
        public string CharacterName { get; set; }
        public int Level { get; set; }
        public MirGender Gender { get; set; }
        public MirClass Class { get; set; }
        public int Location { get; set; }
        public DateTime LastLogin { get; set; }
    }

    public sealed class StartInformation
    {
        public int Index { get; set; }
        public uint ObjectID { get; set; }
        public string Name { get; set; }
        public Color NameColour { get; set; }
        public string GuildName { get; set; }
        public string GuildRank { get; set; }

        public MirClass Class { get; set; }
        public MirGender Gender { get; set; }
        public Point Location { get; set; }
        public MirDirection Direction { get; set; }

        public int MapIndex { get; set; }

        public long Gold { get; set; }
        public int GameGold { get; set; }

        public int Level { get; set; }
        public int HairType { get; set; }
        public Color HairColour { get; set; }
        public int Weapon { get; set; }
        public int Armour { get; set; }
        public int Shield { get; set; }
        public int Emblem { get; set; }
        public Color ArmourColour { get; set; }
        public int ArmourImage { get; set; }
        public int WeaponImage { get; set; }

        
        public int Shizhuang { get; set; }
        public int ShizhuangImage { get; set; }

        public decimal Experience { get; set; }

        
        public int Jyhuishoulevel { get; set; }
        public decimal Exphuishou { get; set; }

        
        public int GuildLevel { get; set; }
        public long TotalContribution { get; set; }
        public long DailyContribution { get; set; }

        public int CurrentHP { get; set; }
        public int CurrentMP { get; set; }

        public AttackMode AttackMode { get; set; }
        public PetMode PetMode { get; set; }

        public int HermitPoints { get; set; }

        public float DayTime { get; set; }
        public bool AllowGroup { get; set; }

        public List<ClientUserItem> Items { get; set; }
        public List<ClientBeltLink> BeltLinks { get; set; }
        public List<ClientAutoPotionLink> AutoPotionLinks { get; set; }
        public List<ClientAutoFightLink> AutoFightLinks { get; set; }
        
        public List<ClientTeleport> Teleports { get; set; }
        public List<ClientUserMagic> Magics { get; set; }
        public List<ClientBuffInfo> Buffs { get; set; }
        public List<ClientMapInfo> MapInfos { get; set; }
        public List<ClientMiniGames> CMiniGames{ get; set;}

        public PoisonType Poison { get; set; }

        public bool InSafeZone { get; set; }
        public bool Observable { get; set; }

        public bool Dead { get; set; }

        public HorseType Horse { get; set; } 

        public int HelmetShape { get; set; }
        public int HorseShape { get; set; }

        public List<ClientUserQuest> Quests { get; set; }

        public List<ClientMeiriUserQuest> MeiriQuests { get; set; }

        public List<int> CompanionUnlocks { get; set; }
        public List<CompanionInfo> AvailableCompanions = new List<CompanionInfo>();

        public List<HorseInfo> AvailableHorses = new List<HorseInfo>();

        public List<ClientUserCompanion> Companions { get; set; }

        public List<int> HorseUnlocks
        {
            get;
            set;
        }
        public List<int> Horses
        {
            get;
            set;
        }

        public int PatchGridSize { get; set; }

        public int BaoshiGridSize { get; set; }

        public int Companion { get; set; }

        public int StorageSize { get; set; }

        public List<ClientUserCrafting> CraftInfo { get; set; }

        public int DailyRandomQuestResets { get; set; }

        public bool HasDailyRandom { get; set; }

        
        public int Mingwen01 { get; set; }
        
        public int Mingwen02 { get; set; }
        
        public int Mingwen03 { get; set; }
        
        public bool Kaiqi01 { get; set; }
        
        public bool Kaiqi02 { get; set; }
        
        public bool Kaiqi03 { get; set; }

        public int Huiyuan { get; set; }

        [CompleteObject]
        public void OnComplete()
        {
            foreach (int index in CompanionUnlocks)
                AvailableCompanions.Add(CartoonGlobals.CompanionInfoList.Binding.First(x => x.Index == index));
            foreach (int index2 in HorseUnlocks)
                AvailableHorses.Add(CartoonGlobals.HorseInfoList.Binding.First((HorseInfo x) => x.Index == index2));
        }
    }
    
    public sealed class ClientUserItem
    {
        public ItemInfo Info;

        public bool CraftInfoOnly;

        public int Index { get; set; } 
        public int InfoIndex { get; set; }

        public int CurrentDurability { get; set; }
        public int MaxDurability { get; set; }

        public long Count { get; set; }
        
        public int Slot { get; set; }

        public int Level { get; set; }
        public decimal Experience { get; set; }

        public Color Colour { get; set; }

        public TimeSpan SpecialRepairCoolDown { get; set; }
        public TimeSpan ResetCoolDown { get; set; }

        public bool New;
        public DateTime NextSpecialRepair, NextReset;

        public Stats AddedStats { get; set; }

        public UserItemFlags Flags { get; set; }
        public TimeSpan ExpireTime { get; set; }

        public BaoshiMaYi BaoshiMaYi { get; set; }
        public BaoshiMaEr BaoshiMaEr { get; set; }
        public BaoshiMaSan BaoshiMaSan { get; set; }
        public BaoshiMaSi BaoshiMaSi { get; set; }
        public BaoshiMaWu BaoshiMaWu { get; set; }
        public BaoshiMaLiu BaoshiMaLiu { get; set; }
        public BaoshiMaQi BaoshiMaQi { get; set; }
        public BaoshiMaBa BaoshiMaBa { get; set; }
        public BaoshiMaJiu BaoshiMaJiu { get; set; }
        public BaoshiMaShi BaoshiMaShi { get; set; }
        public BaoshiMaShiyi BaoshiMaShiyi { get; set; }
        public BaoshiMaShier BaoshiMaShier { get; set; }
        public BaoshiMaShisan BaoshiMaShisan { get; set; }
        public BaoshiMaShisi BaoshiMaShisi { get; set; }

        
        public MingwenMaYi MingwenMaYi { get; set; }
        public MingwenMaEr MingwenMaEr { get; set; }
        public MingwenMaSan MingwenMaSan { get; set; }
        public MingwenMaSi MingwenMaSi { get; set; }
        public MingwenMaWu MingwenMaWu { get; set; }
        public MingwenMaLiu MingwenMaLiu { get; set; }
        public MingwenMaQi MingwenMaQi { get; set; }
        public MingwenMaBa MingwenMaBa { get; set; }
        public MingwenMaJiu MingwenMaJiu { get; set; }
        public MingwenMaShi MingwenMaShi { get; set; }
        public MingwenMaShiyi MingwenMaShiyi { get; set; }
        public MingwenMaShier MingwenMaShier { get; set; }
        public MingwenMaShisan MingwenMaShisan { get; set; }
        public MingwenMaShisi MingwenMaShisi { get; set; }
        public MingwenMaShiwu MingwenMaShiwu { get; set; }
        public MingwenMaShiliu MingwenMaShiliu { get; set; }
        public MingwenMaShiqi MingwenMaShiqi { get; set; }
        public MingwenMaShiba MingwenMaShiba { get; set; }
        public MingwenMaShijiu MingwenMaShijiu { get; set; }
        public MingwenMaErshi MingwenMaErshi { get; set; }
        public MingwenMaErshiyi MingwenMaErshiyi { get; set; }
        public MingwenMaErshier MingwenMaErshier { get; set; }
        public MingwenMaErshisan MingwenMaErshisan { get; set; }
        public MingwenMaErshisi MingwenMaErshisi { get; set; }
        public MingwenMaErshiwu MingwenMaErshiwu { get; set; }
        public MingwenMaErshiliu MingwenMaErshiliu { get; set; }
        public MingwenMaErshiqi MingwenMaErshiqi { get; set; }
        public MingwenMaErshiba MingwenMaErshiba { get; set; }
        public MingwenMaErshijiu MingwenMaErshijiu { get; set; }
        public MingwenMaSanshi MingwenMaSanshi { get; set; }

        
        public int MingwenLv { get; set; }
        
        public decimal MingwenExp { get; set; }


        [IgnorePropertyPacket]
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
                        return (int) Math.Min(int.MaxValue, Info.Weight * Count);
                }
            }
        }

        [CompleteObject]
        public void Complete()
        {
            Info = CartoonGlobals.ItemInfoList.Binding.FirstOrDefault(x => x.Index == InfoIndex);

            NextSpecialRepair = Time.Now + SpecialRepairCoolDown;
            NextReset = Time.Now + ResetCoolDown;
        }

        public ClientUserItem()
        { }
        public ClientUserItem(ItemInfo info, long count)
        {
            Info = info;
            Count = count;
            MaxDurability = info.Durability;
            CurrentDurability = info.Durability;
            Level = 1;
            AddedStats = new Stats();
            CraftInfoOnly = false;
        }
        public ClientUserItem(ClientUserItem item, long count)
        {
            Info = item.Info;

            Index = item.Index;
            InfoIndex = item.InfoIndex;

            CurrentDurability = item.CurrentDurability;
            MaxDurability = item.MaxDurability;

            Count = count;
            
            Slot = item.Slot;

            Level = item.Level;
            Experience = item.Experience;

            Colour = item.Colour;

            SpecialRepairCoolDown = item.SpecialRepairCoolDown;

            Flags = item.Flags;
            ExpireTime = item.ExpireTime;

            BaoshiMaYi = item.BaoshiMaYi;
            BaoshiMaEr = item.BaoshiMaEr;
            BaoshiMaSan = item.BaoshiMaSan;
            BaoshiMaSi = item.BaoshiMaSi;
            BaoshiMaWu = item.BaoshiMaWu;
            BaoshiMaLiu = item.BaoshiMaLiu;
            BaoshiMaQi = item.BaoshiMaQi;
            BaoshiMaBa = item.BaoshiMaBa;
            BaoshiMaJiu = item.BaoshiMaJiu;
            BaoshiMaShi = item.BaoshiMaShi;
            BaoshiMaShiyi = item.BaoshiMaShiyi;
            BaoshiMaShier = item.BaoshiMaShier;
            BaoshiMaShisan = item.BaoshiMaShisan;
            BaoshiMaShisi = item.BaoshiMaShisi;
            
            MingwenMaYi = item.MingwenMaYi;
            MingwenMaEr = item.MingwenMaEr;
            MingwenMaSan = item.MingwenMaSan;
            MingwenMaSi = item.MingwenMaSi;
            MingwenMaWu = item.MingwenMaWu;
            MingwenMaLiu = item.MingwenMaLiu;
            MingwenMaQi = item.MingwenMaQi;
            MingwenMaBa = item.MingwenMaBa;
            MingwenMaJiu = item.MingwenMaJiu;
            MingwenMaShi = item.MingwenMaShi;
            MingwenMaShiyi = item.MingwenMaShiyi;
            MingwenMaShier = item.MingwenMaShier;
            MingwenMaShisan = item.MingwenMaShisan;
            MingwenMaShisi = item.MingwenMaShisi;
            MingwenMaShiwu = item.MingwenMaShiwu;
            MingwenMaShiliu = item.MingwenMaShiliu;
            MingwenMaShiqi = item.MingwenMaShiqi;
            MingwenMaShiba = item.MingwenMaShiba;
            MingwenMaShijiu = item.MingwenMaShijiu;
            MingwenMaErshi = item.MingwenMaErshi;
            MingwenMaErshiyi = item.MingwenMaErshiyi;
            MingwenMaErshier = item.MingwenMaErshier;
            MingwenMaErshisan = item.MingwenMaErshisan;
            MingwenMaErshisi = item.MingwenMaErshisi;
            MingwenMaErshiwu = item.MingwenMaErshiwu;
            MingwenMaErshiliu = item.MingwenMaErshiliu;
            MingwenMaErshiqi = item.MingwenMaErshiqi;
            MingwenMaErshiba = item.MingwenMaErshiba;
            MingwenMaErshijiu = item.MingwenMaErshijiu;
            MingwenMaSanshi = item.MingwenMaSanshi;
            
            MingwenLv = item.MingwenLv;
            
            MingwenExp = item.MingwenExp;



            New = item.New;
            NextSpecialRepair = item.NextSpecialRepair;
            
            AddedStats = new Stats(item.AddedStats);

            CraftInfoOnly = false;
        }


        public long Price(long count)
        {
            if ((Flags & UserItemFlags.Worthless) == UserItemFlags.Worthless) return 0;

            decimal p = Info.Price;

            if (Info.Durability > 0)
            {
                decimal r = Info.Price / 2M / Info.Durability;

                p = MaxDurability * r;

                r = MaxDurability > 0 ? CurrentDurability / (decimal)MaxDurability : 0;

                p = Math.Floor(p / 2M + p / 2M * r + Info.Price / 2M);
            }

            p = p * (AddedStats.Count * 0.1M + 1M);

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

        public int RepairCost(bool special)
        {
            if (Info.Durability == 0 || CurrentDurability >= MaxDurability) return 0;

            int rate = special ? 2 : 1;
            
            decimal p = Math.Floor(MaxDurability*(Info.Price/2M/Info.Durability) + Info.Price/2M);
            p = p*(AddedStats.Count*0.1M + 1M);

            return (int) (p*Count - Price(Count))*rate;


        }
        public bool CanAccessoryUpgrade()
        {
            switch (Info.ItemType)
            {
                case ItemType.Ring:
                case ItemType.Bracelet:
                case ItemType.Necklace:
                    break;
                default: return false;

            }

            return (Flags & UserItemFlags.NonRefinable) != UserItemFlags.NonRefinable && (Flags & UserItemFlags.Refinable) == UserItemFlags.Refinable;
        }
        
        public bool CanDunUpgrade()
        {
            switch (Info.ItemType)
            {
                case ItemType.Shield:
                    break;
                default: return false;

            }

            return (Flags & UserItemFlags.NonRefinable) != UserItemFlags.NonRefinable && (Flags & UserItemFlags.Refinable) == UserItemFlags.Refinable;
        }
        
        public bool CanHuiUpgrade()
        {
            switch (Info.ItemType)
            {
                case ItemType.Emblem:
                    break;
                default: return false;

            }

            return (Flags & UserItemFlags.NonRefinable) != UserItemFlags.NonRefinable && (Flags & UserItemFlags.Refinable) == UserItemFlags.Refinable;
        }
        
        public bool CanMingwenUpgrade()
        {
            switch (Info.ItemType)
            {
                case ItemType.Weapon:
                    break;
                default: return false;

            }

            return (Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable && (Flags & UserItemFlags.Refinable) == UserItemFlags.Refinable;
        }
        public bool CanXiangKanGJSTUpgrade()
        {
            switch (Info.ItemType)
            {
                case ItemType.Ring:
                case ItemType.Bracelet:
                case ItemType.Necklace:
                    break;
                default: return false;

            }

            return (Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable && (Flags & UserItemFlags.Refinable) == UserItemFlags.Refinable;
        }
        public bool CanXiangKanGJBSTUpgrade()
        {
            switch (Info.ItemType)
            {
                case ItemType.Ring:
                case ItemType.Bracelet:
                case ItemType.Necklace:
                    break;
                default: return false;

            }

            return (Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable && (Flags & UserItemFlags.Refinable) == UserItemFlags.Refinable;
        }
        public bool CanXiangKanZRSTUpgrade()
        {
            switch (Info.ItemType)
            {
                case ItemType.Ring:
                case ItemType.Bracelet:
                case ItemType.Necklace:
                    break;
                default: return false;

            }

            return (Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable && (Flags & UserItemFlags.Refinable) == UserItemFlags.Refinable;
        }
        public bool CanXiangKanZRBSTUpgrade()
        {
            switch (Info.ItemType)
            {
                case ItemType.Ring:
                case ItemType.Bracelet:
                case ItemType.Necklace:
                    break;
                default: return false;

            }

            return (Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable && (Flags & UserItemFlags.Refinable) == UserItemFlags.Refinable;
        }
        public bool CanXiangKanLHSTUpgrade()
        {
            switch (Info.ItemType)
            {
                case ItemType.Ring:
                case ItemType.Bracelet:
                case ItemType.Necklace:
                    break;
                default: return false;

            }

            return (Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable && (Flags & UserItemFlags.Refinable) == UserItemFlags.Refinable;
        }
        public bool CanXiangKanLHBSTUpgrade()
        {
            switch (Info.ItemType)
            {
                case ItemType.Ring:
                case ItemType.Bracelet:
                case ItemType.Necklace:
                    break;
                default: return false;

            }

            return (Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable && (Flags & UserItemFlags.Refinable) == UserItemFlags.Refinable;
        }
        public bool CanXiangKanSMSTUpgrade()
        {
            switch (Info.ItemType)
            {
                case ItemType.Ring:
                case ItemType.Bracelet:
                case ItemType.Necklace:
                    break;
                default: return false;

            }

            return (Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable && (Flags & UserItemFlags.Refinable) == UserItemFlags.Refinable;
        }
        public bool CanXiangKanMFSTUpgrade()
        {
            switch (Info.ItemType)
            {
                case ItemType.Ring:
                case ItemType.Bracelet:
                case ItemType.Necklace:
                    break;
                default: return false;

            }

            return (Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable && (Flags & UserItemFlags.Refinable) == UserItemFlags.Refinable;
        }
        public bool CanXiangKanSDSTUpgrade()
        {
            switch (Info.ItemType)
            {
                case ItemType.Ring:
                case ItemType.Bracelet:
                case ItemType.Necklace:
                    break;
                default: return false;

            }

            return (Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable && (Flags & UserItemFlags.Refinable) == UserItemFlags.Refinable;
        }
        public bool CanXiangKanFYSTUpgrade()
        {
            switch (Info.ItemType)
            {
                case ItemType.Ring:
                case ItemType.Bracelet:
                case ItemType.Necklace:
                    break;
                default: return false;

            }

            return (Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable && (Flags & UserItemFlags.Refinable) == UserItemFlags.Refinable;
        }
        public bool CanXiangKanMYSTUpgrade()
        {
            switch (Info.ItemType)
            {
                case ItemType.Ring:
                case ItemType.Bracelet:
                case ItemType.Necklace:
                    break;
                default: return false;

            }

            return (Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable && (Flags & UserItemFlags.Refinable) == UserItemFlags.Refinable;
        }
        public bool CanXiangKanGJESTUpgrade()
        {
            switch (Info.ItemType)
            {
                case ItemType.Ring:
                case ItemType.Bracelet:
                case ItemType.Necklace:
                    break;
                default: return false;

            }

            return (Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable && (Flags & UserItemFlags.Refinable) == UserItemFlags.Refinable;
        }
        public bool CanXiangKanGJSSTUpgrade()
        {
            switch (Info.ItemType)
            {
                case ItemType.Ring:
                case ItemType.Bracelet:
                case ItemType.Necklace:
                    break;
                default: return false;

            }

            return (Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable && (Flags & UserItemFlags.Refinable) == UserItemFlags.Refinable;
        }
        public bool CanXiangKanGJBETUpgrade()
        {
            switch (Info.ItemType)
            {
                case ItemType.Ring:
                case ItemType.Bracelet:
                case ItemType.Necklace:
                    break;
                default: return false;

            }

            return (Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable && (Flags & UserItemFlags.Refinable) == UserItemFlags.Refinable;
        }
        public bool CanXiangKanGJBSSTUpgrade()
        {
            switch (Info.ItemType)
            {
                case ItemType.Ring:
                case ItemType.Bracelet:
                case ItemType.Necklace:
                    break;
                default: return false;

            }

            return (Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable && (Flags & UserItemFlags.Refinable) == UserItemFlags.Refinable;
        }
        public bool CanXiangKanZRESTUpgrade()
        {
            switch (Info.ItemType)
            {
                case ItemType.Ring:
                case ItemType.Bracelet:
                case ItemType.Necklace:
                    break;
                default: return false;

            }

            return (Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable && (Flags & UserItemFlags.Refinable) == UserItemFlags.Refinable;
        }
        public bool CanXiangKanZRSSTUpgrade()
        {
            switch (Info.ItemType)
            {
                case ItemType.Ring:
                case ItemType.Bracelet:
                case ItemType.Necklace:
                    break;
                default: return false;

            }

            return (Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable && (Flags & UserItemFlags.Refinable) == UserItemFlags.Refinable;
        }
        public bool CanXiangKanZRBESTUpgrade()
        {
            switch (Info.ItemType)
            {
                case ItemType.Ring:
                case ItemType.Bracelet:
                case ItemType.Necklace:
                    break;
                default: return false;

            }

            return (Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable && (Flags & UserItemFlags.Refinable) == UserItemFlags.Refinable;
        }
        public bool CanXiangKanZRBSSTUpgrade()
        {
            switch (Info.ItemType)
            {
                case ItemType.Ring:
                case ItemType.Bracelet:
                case ItemType.Necklace:
                    break;
                default: return false;

            }

            return (Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable && (Flags & UserItemFlags.Refinable) == UserItemFlags.Refinable;
        }
        public bool CanXiangKanLHESTUpgrade()
        {
            switch (Info.ItemType)
            {
                case ItemType.Ring:
                case ItemType.Bracelet:
                case ItemType.Necklace:
                    break;
                default: return false;

            }

            return (Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable && (Flags & UserItemFlags.Refinable) == UserItemFlags.Refinable;
        }
        public bool CanXiangKanLHSSTUpgrade()
        {
            switch (Info.ItemType)
            {
                case ItemType.Ring:
                case ItemType.Bracelet:
                case ItemType.Necklace:
                    break;
                default: return false;

            }

            return (Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable && (Flags & UserItemFlags.Refinable) == UserItemFlags.Refinable;
        }
        public bool CanXiangKanLHBESTUpgrade()
        {
            switch (Info.ItemType)
            {
                case ItemType.Ring:
                case ItemType.Bracelet:
                case ItemType.Necklace:
                    break;
                default: return false;

            }

            return (Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable && (Flags & UserItemFlags.Refinable) == UserItemFlags.Refinable;
        }
        public bool CanXiangKanLHBSSTUpgrade()
        {
            switch (Info.ItemType)
            {
                case ItemType.Ring:
                case ItemType.Bracelet:
                case ItemType.Necklace:
                    break;
                default: return false;

            }

            return (Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable && (Flags & UserItemFlags.Refinable) == UserItemFlags.Refinable;
        }
        public bool CanXiangKanSMESTTUpgrade()
        {
            switch (Info.ItemType)
            {
                case ItemType.Ring:
                case ItemType.Bracelet:
                case ItemType.Necklace:
                    break;
                default: return false;

            }

            return (Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable && (Flags & UserItemFlags.Refinable) == UserItemFlags.Refinable;
        }
        public bool CanXiangKanSMSSTUpgrade()
        {
            switch (Info.ItemType)
            {
                case ItemType.Ring:
                case ItemType.Bracelet:
                case ItemType.Necklace:
                    break;
                default: return false;

            }

            return (Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable && (Flags & UserItemFlags.Refinable) == UserItemFlags.Refinable;
        }
        public bool CanXiangKanMFESTTUpgrade()
        {
            switch (Info.ItemType)
            {
                case ItemType.Ring:
                case ItemType.Bracelet:
                case ItemType.Necklace:
                    break;
                default: return false;

            }

            return (Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable && (Flags & UserItemFlags.Refinable) == UserItemFlags.Refinable;
        }
        public bool CanXiangKanMFSSTUpgrade()
        {
            switch (Info.ItemType)
            {
                case ItemType.Ring:
                case ItemType.Bracelet:
                case ItemType.Necklace:
                    break;
                default: return false;

            }

            return (Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable && (Flags & UserItemFlags.Refinable) == UserItemFlags.Refinable;
        }
        public bool CanXiangKanSDESTUpgrade()
        {
            switch (Info.ItemType)
            {
                case ItemType.Ring:
                case ItemType.Bracelet:
                case ItemType.Necklace:
                    break;
                default: return false;

            }

            return (Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable && (Flags & UserItemFlags.Refinable) == UserItemFlags.Refinable;
        }
        public bool CanXiangKanSDSSTUpgrade()
        {
            switch (Info.ItemType)
            {
                case ItemType.Ring:
                case ItemType.Bracelet:
                case ItemType.Necklace:
                    break;
                default: return false;

            }

            return (Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable && (Flags & UserItemFlags.Refinable) == UserItemFlags.Refinable;
        }
        public bool CanXiangKanFYESTUpgrade()
        {
            switch (Info.ItemType)
            {
                case ItemType.Ring:
                case ItemType.Bracelet:
                case ItemType.Necklace:
                    break;
                default: return false;

            }

            return (Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable && (Flags & UserItemFlags.Refinable) == UserItemFlags.Refinable;
        }
        public bool CanXiangKanFYSSTUpgrade()
        {
            switch (Info.ItemType)
            {
                case ItemType.Ring:
                case ItemType.Bracelet:
                case ItemType.Necklace:
                    break;
                default: return false;

            }

            return (Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable && (Flags & UserItemFlags.Refinable) == UserItemFlags.Refinable;
        }
        public bool CanXiangKanMYESTTUpgrade()
        {
            switch (Info.ItemType)
            {
                case ItemType.Ring:
                case ItemType.Bracelet:
                case ItemType.Necklace:
                    break;
                default: return false;

            }

            return (Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable && (Flags & UserItemFlags.Refinable) == UserItemFlags.Refinable;
        }
        public bool CanXiangKanMYSSTUpgrade()
        {
            switch (Info.ItemType)
            {
                case ItemType.Ring:
                case ItemType.Bracelet:
                case ItemType.Necklace:
                    break;
                default: return false;

            }

            return (Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable && (Flags & UserItemFlags.Refinable) == UserItemFlags.Refinable;
        }
        public bool CanGZLKaikongyUpgrade()
        {
            switch (Info.ItemType)
            {
                case ItemType.Ring:
                case ItemType.Bracelet:
                case ItemType.Necklace:
                    break;
                default: return false;

            }

            return (Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable && (Flags & UserItemFlags.Refinable) == UserItemFlags.Refinable;
        }
        public bool CanGZLKaikongeUpgrade()
        {
            switch (Info.ItemType)
            {
                case ItemType.Ring:
                case ItemType.Bracelet:
                case ItemType.Necklace:
                    break;
                default: return false;

            }

            return (Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable && (Flags & UserItemFlags.Refinable) == UserItemFlags.Refinable;
        }
        public bool CanGZLKaikongsUpgrade()
        {
            switch (Info.ItemType)
            {
                case ItemType.Ring:
                case ItemType.Bracelet:
                case ItemType.Necklace:
                    break;
                default: return false;

            }

            return (Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable && (Flags & UserItemFlags.Refinable) == UserItemFlags.Refinable;
        }
        public bool CanGZLBKaikongyUpgrade()
        {
            switch (Info.ItemType)
            {
                case ItemType.Ring:
                case ItemType.Bracelet:
                case ItemType.Necklace:
                    break;
                default: return false;

            }

            return (Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable && (Flags & UserItemFlags.Refinable) == UserItemFlags.Refinable;
        }
        public bool CanGZLBKaikongeUpgrade()
        {
            switch (Info.ItemType)
            {
                case ItemType.Ring:
                case ItemType.Bracelet:
                case ItemType.Necklace:
                    break;
                default: return false;

            }

            return (Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable && (Flags & UserItemFlags.Refinable) == UserItemFlags.Refinable;
        }
        public bool CanGZLBKaikongsUpgrade()
        {
            switch (Info.ItemType)
            {
                case ItemType.Ring:
                case ItemType.Bracelet:
                case ItemType.Necklace:
                    break;
                default: return false;

            }

            return (Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable && (Flags & UserItemFlags.Refinable) == UserItemFlags.Refinable;
        }
        public bool CanQTKaikongyUpgrade()
        {
            switch (Info.ItemType)
            {
                case ItemType.Ring:
                case ItemType.Bracelet:
                case ItemType.Necklace:
                    break;
                default: return false;

            }

            return (Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable && (Flags & UserItemFlags.Refinable) == UserItemFlags.Refinable;
        }
        public bool CanQTKaikongeUpgrade()
        {
            switch (Info.ItemType)
            {
                case ItemType.Ring:
                case ItemType.Bracelet:
                case ItemType.Necklace:
                    break;
                default: return false;

            }

            return (Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable && (Flags & UserItemFlags.Refinable) == UserItemFlags.Refinable;
        }
        public bool CanQTKaikongsUpgrade()
        {
            switch (Info.ItemType)
            {
                case ItemType.Ring:
                case ItemType.Bracelet:
                case ItemType.Necklace:
                    break;
                default: return false;

            }

            return (Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable && (Flags & UserItemFlags.Refinable) == UserItemFlags.Refinable;
        }

        public bool CanYouliangUpgrade()
        {
            switch (Info.ItemType)
            {
                case ItemType.Ring:
                case ItemType.Bracelet:
                case ItemType.Necklace:
                    break;
                default: return false;

            }

            return (Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable && (Flags & UserItemFlags.Refinable) == UserItemFlags.Refinable;
        }
        public bool CanJingzhiUpgrade()
        {
            switch (Info.ItemType)
            {
                case ItemType.Ring:
                case ItemType.Bracelet:
                case ItemType.Necklace:
                    break;
                default: return false;

            }

            return (Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable && (Flags & UserItemFlags.Refinable) == UserItemFlags.Refinable;
        }
        public bool CanShenhuaUpgrade()
        {
            switch (Info.ItemType)
            {
                case ItemType.Ring:
                case ItemType.Bracelet:
                case ItemType.Necklace:
                    break;
                default: return false;

            }

            return (Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable && (Flags & UserItemFlags.Refinable) == UserItemFlags.Refinable;
        }
        public bool CanChuanshuoUpgrade()
        {
            switch (Info.ItemType)
            {
                case ItemType.Ring:
                case ItemType.Bracelet:
                case ItemType.Necklace:
                    break;
                default: return false;

            }

            return (Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable && (Flags & UserItemFlags.Refinable) == UserItemFlags.Refinable;
        }
        public bool CanXiangkanjystyUpgrade()
        {
            switch (Info.ItemType)
            {
                case ItemType.Armour:
                case ItemType.Shoes:
                case ItemType.Helmet:
                    break;
                default: return false;

            }

            return (Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable && (Flags & UserItemFlags.Refinable) == UserItemFlags.Refinable;
        }
        public bool CanXiangkanjysteUpgrade()
        {
            switch (Info.ItemType)
            {
                case ItemType.Armour:
                case ItemType.Shoes:
                case ItemType.Helmet:
                    break;
                default: return false;

            }

            return (Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable && (Flags & UserItemFlags.Refinable) == UserItemFlags.Refinable;
        }
        public bool CanXiangkanjystsUpgrade()
        {
            switch (Info.ItemType)
            {
                case ItemType.Armour:
                case ItemType.Shoes:
                case ItemType.Helmet:
                    break;
                default: return false;

            }

            return (Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable && (Flags & UserItemFlags.Refinable) == UserItemFlags.Refinable;
        }
        public bool CanXiangkanxxstyUpgrade()
        {
            switch (Info.ItemType)
            {
                case ItemType.Armour:
                case ItemType.Shoes:
                case ItemType.Helmet:
                    break;
                default: return false;

            }

            return (Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable && (Flags & UserItemFlags.Refinable) == UserItemFlags.Refinable;
        }
        public bool CanXiangkanxxsteUpgrade()
        {
            switch (Info.ItemType)
            {
                case ItemType.Armour:
                case ItemType.Shoes:
                case ItemType.Helmet:
                    break;
                default: return false;

            }

            return (Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable && (Flags & UserItemFlags.Refinable) == UserItemFlags.Refinable;
        }
        public bool CanXiangkanxxstsUpgrade()
        {
            switch (Info.ItemType)
            {
                case ItemType.Armour:
                case ItemType.Shoes:
                case ItemType.Helmet:
                    break;
                default: return false;

            }

            return (Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable && (Flags & UserItemFlags.Refinable) == UserItemFlags.Refinable;
        }
        public bool CanXiangKanghuoyUpgrade()
        {
            switch (Info.ItemType)
            {
                case ItemType.Weapon:
                    break;
                default: return false;

            }

            return (Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable && (Flags & UserItemFlags.Refinable) == UserItemFlags.Refinable;
        }
        public bool CanXiangKanghuoeUpgrade()
        {
            switch (Info.ItemType)
            {
                case ItemType.Weapon:
                    break;
                default: return false;

            }

            return (Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable && (Flags & UserItemFlags.Refinable) == UserItemFlags.Refinable;
        }
        public bool CanXiangKanghuosUpgrade()
        {
            switch (Info.ItemType)
            {
                case ItemType.Weapon:
                    break;
                default: return false;

            }

            return (Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable && (Flags & UserItemFlags.Refinable) == UserItemFlags.Refinable;
        }
        public bool CanXiangKangbingyUpgrade()
        {
            switch (Info.ItemType)
            {
                case ItemType.Weapon:
                    break;
                default: return false;

            }

            return (Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable && (Flags & UserItemFlags.Refinable) == UserItemFlags.Refinable;
        }
        public bool CanXiangKangbingeUpgrade()
        {
            switch (Info.ItemType)
            {
                case ItemType.Weapon:
                    break;
                default: return false;

            }

            return (Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable && (Flags & UserItemFlags.Refinable) == UserItemFlags.Refinable;
        }
        public bool CanXiangKangbingsUpgrade()
        {
            switch (Info.ItemType)
            {
                case ItemType.Weapon:
                    break;
                default: return false;

            }

            return (Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable && (Flags & UserItemFlags.Refinable) == UserItemFlags.Refinable;
        }
        public bool CanXiangKangleiyUpgrade()
        {
            switch (Info.ItemType)
            {
                case ItemType.Weapon:
                    break;
                default: return false;

            }

            return (Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable && (Flags & UserItemFlags.Refinable) == UserItemFlags.Refinable;
        }
        public bool CanXiangKangleieUpgrade()
        {
            switch (Info.ItemType)
            {
                case ItemType.Weapon:
                    break;
                default: return false;

            }

            return (Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable && (Flags & UserItemFlags.Refinable) == UserItemFlags.Refinable;
        }
        public bool CanXiangKangleisUpgrade()
        {
            switch (Info.ItemType)
            {
                case ItemType.Weapon:
                    break;
                default: return false;

            }

            return (Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable && (Flags & UserItemFlags.Refinable) == UserItemFlags.Refinable;
        }
        public bool CanXiangKangfengyUpgrade()
        {
            switch (Info.ItemType)
            {
                case ItemType.Weapon:
                    break;
                default: return false;

            }

            return (Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable && (Flags & UserItemFlags.Refinable) == UserItemFlags.Refinable;
        }
        public bool CanXiangKangfengeUpgrade()
        {
            switch (Info.ItemType)
            {
                case ItemType.Weapon:
                    break;
                default: return false;

            }

            return (Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable && (Flags & UserItemFlags.Refinable) == UserItemFlags.Refinable;
        }
        public bool CanXiangKangfengsUpgrade()
        {
            switch (Info.ItemType)
            {
                case ItemType.Weapon:
                    break;
                default: return false;

            }

            return (Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable && (Flags & UserItemFlags.Refinable) == UserItemFlags.Refinable;
        }
        public bool CanXiangKangshenyUpgrade()
        {
            switch (Info.ItemType)
            {
                case ItemType.Weapon:
                    break;
                default: return false;

            }

            return (Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable && (Flags & UserItemFlags.Refinable) == UserItemFlags.Refinable;
        }
        public bool CanXiangKangsheneUpgrade()
        {
            switch (Info.ItemType)
            {
                case ItemType.Weapon:
                    break;
                default: return false;

            }

            return (Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable && (Flags & UserItemFlags.Refinable) == UserItemFlags.Refinable;
        }
        public bool CanXiangKangshensUpgrade()
        {
            switch (Info.ItemType)
            {
                case ItemType.Weapon:
                    break;
                default: return false;

            }

            return (Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable && (Flags & UserItemFlags.Refinable) == UserItemFlags.Refinable;
        }
        public bool CanXiangKanganyUpgrade()
        {
            switch (Info.ItemType)
            {
                case ItemType.Weapon:
                    break;
                default: return false;

            }

            return (Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable && (Flags & UserItemFlags.Refinable) == UserItemFlags.Refinable;
        }
        public bool CanXiangKanganeUpgrade()
        {
            switch (Info.ItemType)
            {
                case ItemType.Weapon:
                    break;
                default: return false;

            }

            return (Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable && (Flags & UserItemFlags.Refinable) == UserItemFlags.Refinable;
        }
        public bool CanXiangKangansUpgrade()
        {
            switch (Info.ItemType)
            {
                case ItemType.Weapon:
                    break;
                default: return false;

            }

            return (Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable && (Flags & UserItemFlags.Refinable) == UserItemFlags.Refinable;
        }
        public bool CanXiangKanghuanyUpgrade()
        {
            switch (Info.ItemType)
            {
                case ItemType.Weapon:
                    break;
                default: return false;

            }

            return (Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable && (Flags & UserItemFlags.Refinable) == UserItemFlags.Refinable;
        }
        public bool CanXiangKanghuaneUpgrade()
        {
            switch (Info.ItemType)
            {
                case ItemType.Weapon:
                    break;
                default: return false;

            }

            return (Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable && (Flags & UserItemFlags.Refinable) == UserItemFlags.Refinable;
        }
        public bool CanXiangKanghuansUpgrade()
        {
            switch (Info.ItemType)
            {
                case ItemType.Weapon:
                    break;
                default: return false;

            }

            return (Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable && (Flags & UserItemFlags.Refinable) == UserItemFlags.Refinable;
        }
        public bool CanXiangKanmofadunyUpgrade()
        {
            switch (Info.ItemType)
            {
                case ItemType.Weapon:
                    break;
                default: return false;

            }

            return (Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable && (Flags & UserItemFlags.Refinable) == UserItemFlags.Refinable;
        }
        public bool CanXiangKanmofaduneUpgrade()
        {
            switch (Info.ItemType)
            {
                case ItemType.Weapon:
                    break;
                default: return false;

            }

            return (Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable && (Flags & UserItemFlags.Refinable) == UserItemFlags.Refinable;
        }
        public bool CanXiangKanmofadunsUpgrade()
        {
            switch (Info.ItemType)
            {
                case ItemType.Weapon:
                    break;
                default: return false;

            }

            return (Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable && (Flags & UserItemFlags.Refinable) == UserItemFlags.Refinable;
        }
        public bool CanXiangKanbingdongyUpgrade()
        {
            switch (Info.ItemType)
            {
                case ItemType.Weapon:
                    break;
                default: return false;

            }

            return (Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable && (Flags & UserItemFlags.Refinable) == UserItemFlags.Refinable;
        }
        public bool CanXiangKanbingdongeUpgrade()
        {
            switch (Info.ItemType)
            {
                case ItemType.Weapon:
                    break;
                default: return false;

            }

            return (Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable && (Flags & UserItemFlags.Refinable) == UserItemFlags.Refinable;
        }
        public bool CanXiangKanbingdongsUpgrade()
        {
            switch (Info.ItemType)
            {
                case ItemType.Weapon:
                    break;
                default: return false;

            }

            return (Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable && (Flags & UserItemFlags.Refinable) == UserItemFlags.Refinable;
        }
        public bool CanXiangKanmabiyUpgrade()
        {
            switch (Info.ItemType)
            {
                case ItemType.Weapon:
                    break;
                default: return false;

            }

            return (Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable && (Flags & UserItemFlags.Refinable) == UserItemFlags.Refinable;
        }
        public bool CanXiangKanmabieUpgrade()
        {
            switch (Info.ItemType)
            {
                case ItemType.Weapon:
                    break;
                default: return false;

            }

            return (Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable && (Flags & UserItemFlags.Refinable) == UserItemFlags.Refinable;
        }
        public bool CanXiangKanmabisUpgrade()
        {
            switch (Info.ItemType)
            {
                case ItemType.Weapon:
                    break;
                default: return false;

            }

            return (Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable && (Flags & UserItemFlags.Refinable) == UserItemFlags.Refinable;
        }
        public bool CanXiangKanyidongyUpgrade()
        {
            switch (Info.ItemType)
            {
                case ItemType.Weapon:
                    break;
                default: return false;

            }

            return (Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable && (Flags & UserItemFlags.Refinable) == UserItemFlags.Refinable;
        }
        public bool CanXiangKanyidongeUpgrade()
        {
            switch (Info.ItemType)
            {
                case ItemType.Weapon:
                    break;
                default: return false;

            }

            return (Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable && (Flags & UserItemFlags.Refinable) == UserItemFlags.Refinable;
        }
        public bool CanXiangKanyidongsUpgrade()
        {
            switch (Info.ItemType)
            {
                case ItemType.Weapon:
                    break;
                default: return false;

            }

            return (Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable && (Flags & UserItemFlags.Refinable) == UserItemFlags.Refinable;
        }
        public bool CanXiangKanchenmoyUpgrade()
        {
            switch (Info.ItemType)
            {
                case ItemType.Weapon:
                    break;
                default: return false;

            }

            return (Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable && (Flags & UserItemFlags.Refinable) == UserItemFlags.Refinable;
        }
        public bool CanXiangKanchenmoeUpgrade()
        {
            switch (Info.ItemType)
            {
                case ItemType.Weapon:
                    break;
                default: return false;

            }

            return (Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable && (Flags & UserItemFlags.Refinable) == UserItemFlags.Refinable;
        }
        public bool CanXiangKanchenmosUpgrade()
        {
            switch (Info.ItemType)
            {
                case ItemType.Weapon:
                    break;
                default: return false;

            }

            return (Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable && (Flags & UserItemFlags.Refinable) == UserItemFlags.Refinable;
        }
        public bool CanXiangKangedangyUpgrade()
        {
            switch (Info.ItemType)
            {
                case ItemType.Weapon:
                    break;
                default: return false;

            }

            return (Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable && (Flags & UserItemFlags.Refinable) == UserItemFlags.Refinable;
        }
        public bool CanXiangKangedangeUpgrade()
        {
            switch (Info.ItemType)
            {
                case ItemType.Weapon:
                    break;
                default: return false;

            }

            return (Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable && (Flags & UserItemFlags.Refinable) == UserItemFlags.Refinable;
        }
        public bool CanXiangKangedangsUpgrade()
        {
            switch (Info.ItemType)
            {
                case ItemType.Weapon:
                    break;
                default: return false;

            }

            return (Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable && (Flags & UserItemFlags.Refinable) == UserItemFlags.Refinable;
        }
        public bool CanXiangKanduobiyUpgrade()
        {
            switch (Info.ItemType)
            {
                case ItemType.Weapon:
                    break;
                default: return false;

            }

            return (Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable && (Flags & UserItemFlags.Refinable) == UserItemFlags.Refinable;
        }
        public bool CanXiangKanduobieUpgrade()
        {
            switch (Info.ItemType)
            {
                case ItemType.Weapon:
                    break;
                default: return false;

            }

            return (Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable && (Flags & UserItemFlags.Refinable) == UserItemFlags.Refinable;
        }
        public bool CanXiangKanduobisUpgrade()
        {
            switch (Info.ItemType)
            {
                case ItemType.Weapon:
                    break;
                default: return false;

            }

            return (Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable && (Flags & UserItemFlags.Refinable) == UserItemFlags.Refinable;
        }
        public bool CanXiangKanqhuoyUpgrade()
        {
            switch (Info.ItemType)
            {
                case ItemType.Armour:
                case ItemType.Shoes:
                case ItemType.Helmet:
                    break;
                default: return false;

            }

            return (Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable && (Flags & UserItemFlags.Refinable) == UserItemFlags.Refinable;
        }
        public bool CanXiangKanqhuoeUpgrade()
        {
            switch (Info.ItemType)
            {
                case ItemType.Armour:
                case ItemType.Shoes:
                case ItemType.Helmet:
                    break;
                default: return false;

            }

            return (Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable && (Flags & UserItemFlags.Refinable) == UserItemFlags.Refinable;
        }
        public bool CanXiangKanqhuosUpgrade()
        {
            switch (Info.ItemType)
            {
                case ItemType.Armour:
                case ItemType.Shoes:
                case ItemType.Helmet:
                    break;
                default: return false;

            }

            return (Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable && (Flags & UserItemFlags.Refinable) == UserItemFlags.Refinable;
        }
        public bool CanXiangKanqbingyUpgrade()
        {
            switch (Info.ItemType)
            {
                case ItemType.Armour:
                case ItemType.Shoes:
                case ItemType.Helmet:
                    break;
                default: return false;

            }

            return (Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable && (Flags & UserItemFlags.Refinable) == UserItemFlags.Refinable;
        }
        public bool CanXiangKanqbingeUpgrade()
        {
            switch (Info.ItemType)
            {
                case ItemType.Armour:
                case ItemType.Shoes:
                case ItemType.Helmet:
                    break;
                default: return false;

            }

            return (Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable && (Flags & UserItemFlags.Refinable) == UserItemFlags.Refinable;
        }
        public bool CanXiangKanqbingsUpgrade()
        {
            switch (Info.ItemType)
            {
                case ItemType.Armour:
                case ItemType.Shoes:
                case ItemType.Helmet:
                    break;
                default: return false;

            }

            return (Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable && (Flags & UserItemFlags.Refinable) == UserItemFlags.Refinable;
        }
        public bool CanXiangKanqleiyUpgrade()
        {
            switch (Info.ItemType)
            {
                case ItemType.Armour:
                case ItemType.Shoes:
                case ItemType.Helmet:
                    break;
                default: return false;

            }

            return (Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable && (Flags & UserItemFlags.Refinable) == UserItemFlags.Refinable;
        }
        public bool CanXiangKanqleieUpgrade()
        {
            switch (Info.ItemType)
            {
                case ItemType.Armour:
                case ItemType.Shoes:
                case ItemType.Helmet:
                    break;
                default: return false;

            }

            return (Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable && (Flags & UserItemFlags.Refinable) == UserItemFlags.Refinable;
        }
        public bool CanXiangKanqleisUpgrade()
        {
            switch (Info.ItemType)
            {
                case ItemType.Armour:
                case ItemType.Shoes:
                case ItemType.Helmet:
                    break;
                default: return false;

            }

            return (Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable && (Flags & UserItemFlags.Refinable) == UserItemFlags.Refinable;
        }
        public bool CanXiangKanqfengyUpgrade()
        {
            switch (Info.ItemType)
            {
                case ItemType.Armour:
                case ItemType.Shoes:
                case ItemType.Helmet:
                    break;
                default: return false;

            }

            return (Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable && (Flags & UserItemFlags.Refinable) == UserItemFlags.Refinable;
        }
        public bool CanXiangKanqfengeUpgrade()
        {
            switch (Info.ItemType)
            {
                case ItemType.Armour:
                case ItemType.Shoes:
                case ItemType.Helmet:
                    break;
                default: return false;

            }

            return (Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable && (Flags & UserItemFlags.Refinable) == UserItemFlags.Refinable;
        }
        public bool CanXiangKanqfengsUpgrade()
        {
            switch (Info.ItemType)
            {
                case ItemType.Armour:
                case ItemType.Shoes:
                case ItemType.Helmet:
                    break;
                default: return false;

            }

            return (Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable && (Flags & UserItemFlags.Refinable) == UserItemFlags.Refinable;
        }
        public bool CanXiangKanqshenyUpgrade()
        {
            switch (Info.ItemType)
            {
                case ItemType.Armour:
                case ItemType.Shoes:
                case ItemType.Helmet:
                    break;
                default: return false;

            }

            return (Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable && (Flags & UserItemFlags.Refinable) == UserItemFlags.Refinable;
        }
        public bool CanXiangKanqsheneUpgrade()
        {
            switch (Info.ItemType)
            {
                case ItemType.Armour:
                case ItemType.Shoes:
                case ItemType.Helmet:
                    break;
                default: return false;

            }

            return (Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable && (Flags & UserItemFlags.Refinable) == UserItemFlags.Refinable;
        }
        public bool CanXiangKanqshensUpgrade()
        {
            switch (Info.ItemType)
            {
                case ItemType.Armour:
                case ItemType.Shoes:
                case ItemType.Helmet:
                    break;
                default: return false;

            }

            return (Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable && (Flags & UserItemFlags.Refinable) == UserItemFlags.Refinable;
        }
        public bool CanXiangKanqanyUpgrade()
        {
            switch (Info.ItemType)
            {
                case ItemType.Armour:
                case ItemType.Shoes:
                case ItemType.Helmet:
                    break;
                default: return false;

            }

            return (Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable && (Flags & UserItemFlags.Refinable) == UserItemFlags.Refinable;
        }
        public bool CanXiangKanqaneUpgrade()
        {
            switch (Info.ItemType)
            {
                case ItemType.Armour:
                case ItemType.Shoes:
                case ItemType.Helmet:
                    break;
                default: return false;

            }

            return (Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable && (Flags & UserItemFlags.Refinable) == UserItemFlags.Refinable;
        }
        public bool CanXiangKanqansUpgrade()
        {
            switch (Info.ItemType)
            {
                case ItemType.Armour:
                case ItemType.Shoes:
                case ItemType.Helmet:
                    break;
                default: return false;

            }

            return (Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable;
        }
        public bool CanXiangKanqhuanyUpgrade()
        {
            switch (Info.ItemType)
            {
                case ItemType.Armour:
                case ItemType.Shoes:
                case ItemType.Helmet:
                    break;
                default: return false;

            }

            return (Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable && (Flags & UserItemFlags.Refinable) == UserItemFlags.Refinable;
        }
        public bool CanXiangKanqhuaneUpgrade()
        {
            switch (Info.ItemType)
            {
                case ItemType.Armour:
                case ItemType.Shoes:
                case ItemType.Helmet:
                    break;
                default: return false;

            }

            return (Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable && (Flags & UserItemFlags.Refinable) == UserItemFlags.Refinable;
        }
        public bool CanXiangKanqhuansUpgrade()
        {
            switch (Info.ItemType)
            {
                case ItemType.Armour:
                case ItemType.Shoes:
                case ItemType.Helmet:
                    break;
                default: return false;

            }

            return (Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable && (Flags & UserItemFlags.Refinable) == UserItemFlags.Refinable;
        }
        public bool CanXiangKanlvduyUpgrade()
        {
            switch (Info.ItemType)
            {
                
                case ItemType.Shoes:
                
                    break;
                default: return false;

            }

            return (Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable && (Flags & UserItemFlags.Refinable) == UserItemFlags.Refinable;
        }
        public bool CanXiangKanlvdueUpgrade()
        {
            switch (Info.ItemType)
            {
                
                case ItemType.Shoes:
                
                    break;
                default: return false;

            }

            return (Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable && (Flags & UserItemFlags.Refinable) == UserItemFlags.Refinable;
        }
        public bool CanXiangKanlvdusUpgrade()
        {
            switch (Info.ItemType)
            {
                
                case ItemType.Shoes:
                
                    break;
                default: return false;

            }

            return (Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable && (Flags & UserItemFlags.Refinable) == UserItemFlags.Refinable;
        }
        public bool CanXiangKanzymyUpgrade()
        {
            switch (Info.ItemType)
            {
                case ItemType.Weapon:
                    break;
                default: return false;

            }

            return (Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable && (Flags & UserItemFlags.Refinable) == UserItemFlags.Refinable;
        }
        public bool CanXiangKanzymeUpgrade()
        {
            switch (Info.ItemType)
            {
                case ItemType.Weapon:
                    break;
                default: return false;

            }

            return (Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable && (Flags & UserItemFlags.Refinable) == UserItemFlags.Refinable;
        }
        public bool CanXiangKanzymsUpgrade()
        {
            switch (Info.ItemType)
            {
                case ItemType.Weapon:
                    break;
                default: return false;

            }

            return (Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable && (Flags & UserItemFlags.Refinable) == UserItemFlags.Refinable;
        }
        public bool CanXiangKanmhhfyUpgrade()
        {
            switch (Info.ItemType)
            {
                case ItemType.Shoes:
                    break;
                default: return false;

            }

            return (Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable && (Flags & UserItemFlags.Refinable) == UserItemFlags.Refinable;
        }
        public bool CanXiangKanmhhfeUpgrade()
        {
            switch (Info.ItemType)
            {
                case ItemType.Shoes:
                    break;
                default: return false;

            }

            return (Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable && (Flags & UserItemFlags.Refinable) == UserItemFlags.Refinable;
        }
        public bool CanXiangKanmhhfsUpgrade()
        {
            switch (Info.ItemType)
            {
                case ItemType.Shoes:
                    break;
                default: return false;

            }

            return (Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable && (Flags & UserItemFlags.Refinable) == UserItemFlags.Refinable;
        }
        
        public bool CanHuanhuaUpgrade()
        {
            switch (Info.ItemType)
            {
                case ItemType.Weapon:
                case ItemType.Armour:
                case ItemType.Shoes:
                case ItemType.Helmet:
                case ItemType.Ring:
                case ItemType.Bracelet:
                case ItemType.Necklace:
                case ItemType.Shizhuang:
                    break;
                default: return false;

            }

            return (Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable && (Flags & UserItemFlags.Refinable) == UserItemFlags.Refinable;
        }
        
        public bool CanXiangKanjinglianyUpgrade()
        {
            switch (Info.ItemType)
            {
                case ItemType.Shizhuang:
                    break;
                default: return false;

            }

            return (Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable && (Flags & UserItemFlags.Refinable) == UserItemFlags.Refinable;
        }
        
        public bool CanXiangKanjinglianeUpgrade()
        {
            switch (Info.ItemType)
            {
                case ItemType.Shizhuang:
                    break;
                default: return false;

            }

            return (Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable && (Flags & UserItemFlags.Refinable) == UserItemFlags.Refinable;
        }
        
        public bool CanXiangKanjingliansUpgrade()
        {
            switch (Info.ItemType)
            {
                case ItemType.Shizhuang:
                    break;
                default: return false;

            }

            return (Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable && (Flags & UserItemFlags.Refinable) == UserItemFlags.Refinable;
        }
        public bool CanXiangKanChaichustUpgrade()
        {
            switch (Info.ItemType)
            {
                case ItemType.Weapon:
                case ItemType.Armour:
                case ItemType.Shoes:
                case ItemType.Helmet:
                case ItemType.Ring:
                case ItemType.Bracelet:
                case ItemType.Necklace:
                    break;
                default: return false;

            }

            return (Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable && (Flags & UserItemFlags.Refinable) == UserItemFlags.Refinable;
        }

        public bool CanFragment()
        {
            if ((Flags & UserItemFlags.NonRefinable) == UserItemFlags.NonRefinable || (Flags & UserItemFlags.Worthless) == UserItemFlags.Worthless) return false;

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
                      /*  case ItemType.Helmet:
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
    }
    
    public sealed class ClientBeltLink
    {
        public int Slot { get; set; }
        public int LinkInfoIndex { get; set; }
        public int LinkItemIndex { get; set; }
    }

    public sealed class ClientAutoPotionLink
    {
        public int Slot { get; set; }
        public int LinkInfoIndex { get; set; }
        public int Health { get; set; }
        public int Mana { get; set; }
        public bool Enabled { get; set; }
    }
    
    public sealed class ClientTeleport
    {
        public int Index { get; set; }
        public int MapId { get; set; }
        public string Beizhu { get; set; }
        public Point TelePos { get; set; }
    }

    public class MagicHelper
    {
        public MagicType TypeID { get; set; }

        public string Name { get; set; }

        public SpellKey Key { get; set; }

        public bool LockPlayer { get; set; }

        public bool LockMonster { get; set; }

        public int Amulet { get; set; }

        public object obj { get; set; }
    }

    public class ClientUserMagic
    {
        public int Index { get; set; }
        public int InfoIndex { get; set; }
        public MagicInfo Info;

        public SpellKey Set1Key { get; set; }
        public SpellKey Set2Key { get; set; }
        public SpellKey Set3Key { get; set; }
        public SpellKey Set4Key { get; set; }

        public int Level { get; set; }
        public long Experience { get; set; }

        public TimeSpan Cooldown { get; set; }

        public DateTime NextCast;
        

        [IgnorePropertyPacket]
        public int Cost => Info.BaseCost + Level * Info.LevelCost / 3;

        [CompleteObject]
        public void Complete()
        {
            NextCast = Time.Now + Cooldown;
            Info = CartoonGlobals.MagicInfoList.Binding.FirstOrDefault(x => x.Index == InfoIndex);
        }
    }

    public class ClientUserHorse
    {
        public int HorseNum
        {
            get;
            set;
        }

        [IgnorePropertyPacket]
        public HorseInfo HorseInfo
        {
            get;
            set;
        }
    }


    public class CellLinkInfo
    {
        public GridType GridType { get; set; }
        public int Slot { get; set; }
        public long Count { get; set; }
    }
    
    public class ClientBuffInfo
    {
        public int Index { get; set; }
        public BuffType Type { get; set; }
        public TimeSpan RemainingTime { get; set; }
        public TimeSpan TickFrequency { get; set; }
        public Stats Stats { get; set; }
        public bool Pause { get; set; }
        public int ItemIndex { get; set; }
    }

    public class ClientRefineInfo
    {
        public int Index { get; set; }
        public ClientUserItem Weapon { get; set; }
        public RefineType Type { get; set; }
        public RefineQuality Quality { get; set; }
        public int Chance { get; set; }
        public int MaxChance { get; set; }
        public TimeSpan ReadyDuration { get; set; }

        public DateTime RetrieveTime;

        [CompleteObject]
        public void Complete()
        {
            RetrieveTime = Time.Now + ReadyDuration;
        }
    }


    public sealed class RankInfo
    {
        public int Rank { get; set; }
        public int Index { get; set; }
        public string Name { get; set; }
        public MirClass Class { get; set; }
        public int Level { get; set; }
        public decimal Experience { get; set; }
        public int Zhuanshen { get; set; }
        public bool Online { get; set; }
        public bool Observable { get; set; }
    }
    
    public sealed class GuildRankInfo
    {
        public int Rank { get; set; }
        public int Index { get; set; }
        public string GuildName { get; set; }
        public string GuildLeaderName { get; set; }
        public int Level { get; set; }
        public decimal Experience { get; set; }
        public int MemberLimit { get; set; }
        public int MembersCount { get; set; }
        public long GuildFunds { get; set; }
    }
    
    public sealed class GuildGerenRankInfo
    {
        public int Rank { get; set; }
        public int Index { get; set; }
        public string GuildName { get; set; }
        public string CharacterName { get; set; }
        public long TotalContribution { get; set; }
        public long DailyContribution { get; set; }
        public string Chenghao { get; set; }
    }

    public class ClientMarketPlaceInfo
    {
        public int Index { get; set; }
        public ClientUserItem Item { get; set; }
        
        public int Price { get; set; }
        public CurrencyType PriceType { get; set; }

        public string Seller { get; set; }
        public string Message { get; set; }
        public bool IsOwner { get; set; }

        public bool Loading;
    }

    public class ClientMailInfo
    {
        public int Index { get; set; }
        public bool Opened { get; set; }
        public bool HasItem { get; set; }
        public DateTime Date { get; set; }

        public string Sender { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }

        public int Gold { get; set; }
        public List<ClientUserItem> Items { get; set; }
    }

    public sealed class ClientMapInfo
    {
        public string FileName
        {
            get;
            set;
        }

        public string Description
        {
            get;
            set;
        }

        public int MiniMap
        {
            get;
            set;
        }

        public LightSetting Light
        {
            get;
            set;
        }

        public FightSetting Fight
        {
            get;
            set;
        }

        public bool AllowRT
        {
            get;
            set;
        }

        public int SkillDelay
        {
            get;
            set;
        }

        public bool CanHorse
        {
            get;
            set;
        }

        public bool AllowTT
        {
            get;
            set;
        }

        public bool CanMine
        {
            get;
            set;
        }

        public bool CanMarriageRecall
        {
            get;
            set;
        }

        public bool AllowRecall
        {
            get;
            set;
        }

        public int MinimumLevel
        {
            get;
            set;
        }

        public int MaximumLevel
        {
            get;
            set;
        }

        public MapInfo ReconnectMap
        {
            get;
            set;
        }

        public SoundIndex Music
        {
            get;
            set;
        }

        public int MonsterHealth
        {
            get;
            set;
        }

        public int MonsterDamage
        {
            get;
            set;
        }

        public int DropRate
        {
            get;
            set;
        }

        public int ExperienceRate
        {
            get;
            set;
        }

        public int KillStreakExperienceRate
        {
            get;
            set;
        }

        public DateTime KillStreakEndTime
        {
            get;
            set;
        }

        public bool KillSteakActive
        {
            get;
            set;
        }

        public int InstanceIndex
        {
            get;
            set;
        }

        public int GoldRate
        {
            get;
            set;
        }

        public int MaxMonsterHealth
        {
            get;
            set;
        }

        public int MaxMonsterDamage
        {
            get;
            set;
        }

        public int MaxDropRate
        {
            get;
            set;
        }

        public int MaxExperienceRate
        {
            get;
            set;
        }

        public int MaxGoldRate
        {
            get;
            set;
        }

        public List<MapRegion> Regions
        {
            get;
            set;
        }

        public List<MineInfo> Mining
        {
            get;
            set;
        }
    }

    public class ClientGuildInfo
    {
        public string GuildName { get; set; }

        public string Notice { get; set; }

        public int MemberLimit { get; set; }

        public long GuildFunds { get; set; }
        public long DailyGrowth { get; set; }
        
        public long TotalContribution { get; set; }
        public long JyTotalContribution { get; set; }
        public long DailyContribution { get; set; }

        public int GuildLevel { get; set; }

        public int UserIndex { get; set; }

        public int StorageLimit { get; set; }
        public int Tax { get; set; }

        public string DefaultRank { get; set; }
        
        public int ShuangGongxian { get; set; }
        
        public int GuildBosshd01 { get; set; }
        
        public int GuildBosshdrenshu { get; set; }

        
        public int GuildQuanhd02 { get; set; }
        
        public int GuildQuanhdrenshu { get; set; }

        
        public int GuildFubenhd03 { get; set; }
        
        public int GuildFubenhdrenshu { get; set; }

        
        public int GuildJiachenghd04 { get; set; }
        
        public int GuildJiachenghdrenshu { get; set; }

        public GuildPermission DefaultPermission { get; set; }

        public List<ClientGuildMemberInfo> Members { get; set; }

        public List<ClientUserItem> Storage { get; set; }

        [IgnorePropertyPacket]
        public GuildPermission Permission => Members.FirstOrDefault(x => x.Index == UserIndex)?.Permission ?? GuildPermission.None;
    }

    public class ClientGuildMemberInfo
    {
        public int Index { get; set; }
        public string Name { get; set; }
        public string Rank { get; set; }
        public long TotalContribution { get; set; }
        public long JyTotalContribution { get; set; }
        public long DailyContribution { get; set; }
        public TimeSpan Online { get; set; }
        public string MapName { get; set; }

        public GuildPermission Permission { get; set; }

        public DateTime LastOnline;
        public uint ObjectID { get; set; }

        [CompleteObject]
        public void Complete()
        {
            if (Online == TimeSpan.MinValue)
                LastOnline = DateTime.MaxValue;
            else
                LastOnline = Time.Now - Online;
        }

    }

    public class ClientUserQuest
    {
        public int Index { get; set; }

        [IgnorePropertyPacket]
        public QuestInfo Quest { get; set; }

        public int QuestIndex { get; set; }

        public bool Track { get; set; }

        public bool Completed { get; set; }

        public int SelectedReward { get; set; }

        [IgnorePropertyPacket]
        public bool IsComplete => Tasks.Count == Quest.Tasks.Count && Tasks.All(x => x.Completed);

        public List<ClientUserQuestTask> Tasks { get; set; }

        [CompleteObject]
        public void Complete()
        {
            Quest = CartoonGlobals.QuestInfoList.Binding.First(x => x.Index == QuestIndex);
        }
    }

    public class ClientMeiriUserQuest
    {
        public int Index { get; set; }

        [IgnorePropertyPacket]
        public MeiriQuestInfo Quest { get; set; }

        public int QuestIndex { get; set; }

        public bool Track { get; set; }

        public bool Completed { get; set; }

        public int SelectedReward { get; set; }

        [IgnorePropertyPacket]
        public bool IsComplete => Tasks.Count == Quest.Tasks.Count && Tasks.All(x => x.Completed);

        public List<ClientMeiriUserQuestTask> Tasks { get; set; }

        [CompleteObject]
        public void Complete()
        {
            Quest = CartoonGlobals.MeiriQuestInfoList.Binding.First(x => x.Index == QuestIndex);
        }
    }

    public class ClientUserQuestTask
    {
        public int Index { get; set; }

        [IgnorePropertyPacket]
        public QuestTask Task { get; set; }

        public int TaskIndex { get; set; }

        public long Amount { get; set; }

        [IgnorePropertyPacket]
        public bool Completed => Amount >= Task.Amount;

        [CompleteObject]
        public void Complete()
        {
            Task = CartoonGlobals.QuestTaskList.Binding.First(x => x.Index == TaskIndex);
        }
    }

    public class ClientMeiriUserQuestTask
    {
        public int Index { get; set; }

        [IgnorePropertyPacket]
        public MeiriQuestTask Task { get; set; }

        public int TaskIndex { get; set; }

        public long Amount { get; set; }

        [IgnorePropertyPacket]
        public bool Completed => Amount >= Task.Amount;

        [CompleteObject]
        public void Complete()
        {
            Task = CartoonGlobals.MeiriQuestTaskList.Binding.First(x => x.Index == TaskIndex);
        }
    }

    public class ClientCompanionObject
    {
        public string Name { get; set; }

        public int HeadShape { get; set; }
        public int BackShape { get; set; }
    }

    public class ClientUserCompanion
    {
        public int Index { get; set; }
        public string Name { get; set; }

        public int CompanionIndex { get; set; }
        public CompanionInfo CompanionInfo;

        public int Rebirth { get; set; }
        public int Level { get; set; }
        public int Hunger { get; set; }
        public int Experience { get; set; }

        public Stats Level3 { get; set; }
        public Stats Level5 { get; set; }
        public Stats Level7 { get; set; }
        public Stats Level10 { get; set; }
        public Stats Level11 { get; set; }
        public Stats Level13 { get; set; }
        public Stats Level15 { get; set; }
        public Stats Level17 { get; set; }
        public Stats Level20 { get; set; }
        public Stats Level23 { get; set; }
        public Stats Level25 { get; set; }
        public Stats Level27 { get; set; }
        public Stats Level30 { get; set; }
        public Stats Level33 { get; set; }
        public Stats Level35 { get; set; }
        public Stats Level37 { get; set; }
        public Stats Level40 { get; set; }
        public int ImgIndex3 { get; set; }
        public int ImgIndex5 { get; set; }
        public int ImgIndex7 { get; set; }
        public int ImgIndex10 { get; set; }
        public int ImgIndex11 { get; set; }
        public int ImgIndex13 { get; set; }
        public int ImgIndex15 { get; set; }
        public int ImgIndex17 { get; set; }
        public int ImgIndex20 { get; set; }
        public int ImgIndex23 { get; set; }
        public int ImgIndex25 { get; set; }
        public int ImgIndex27 { get; set; }
        public int ImgIndex30 { get; set; }
        public int ImgIndex33 { get; set; }
        public int ImgIndex35 { get; set; }
        public int ImgIndex37 { get; set; }
        public int ImgIndex40 { get; set; }
        public bool Maxzhi3 { get; set; }
        public bool Maxzhi5 { get; set; }
        public bool Maxzhi7 { get; set; }
        public bool Maxzhi10 { get; set; }
        public bool Maxzhi11 { get; set; }
        public bool Maxzhi13 { get; set; }
        public bool Maxzhi15 { get; set; }

        public string CharacterName { get; set; }

        public List<ClientUserItem> Items { get; set; }

        public ClientUserItem[] EquipmentArray = new ClientUserItem[CartoonGlobals.CompanionEquipmentSize], InventoryArray = new ClientUserItem[CartoonGlobals.CompanionInventorySize];


        [CompleteObject]
        public void OnComplete()
        {
            CompanionInfo = CartoonGlobals.CompanionInfoList.Binding.First(x => x.Index == CompanionIndex);


            foreach (ClientUserItem item in Items)
            {
                if (item.Slot < CartoonGlobals.EquipmentOffSet)
                    InventoryArray[item.Slot] = item;
                else
                    EquipmentArray[item.Slot - CartoonGlobals.EquipmentOffSet] = item;
            }

        }

    }

    public sealed class ClientMiniGames
    {
        public int index
        {
            get;
            set;
        }

        public DateTime StartTime
        {
            get;
            set;
        }

        public DateTime EndTime
        {
            get;
            set;
        }

        public bool Started
        {
            get;
            set;
        }
    }

    public class ClientPlayerInfo 
    {
        public uint ObjectID { get; set; }

        public string Name { get; set; }

        public MirClass Class { get; set; }
    }
    public class ClientObjectData
    {
        public uint ObjectID;

        public int MapIndex;
        public Point Location;

        public string Name;
        public MirClass Class { get; set; }

        
        public MonsterInfo MonsterInfo;
        public ItemInfo ItemInfo;

        public string PetOwner;

        public int Health;
        public int MaxHealth;

        public int Mana;
        public int MaxMana;
        public Stats Stats { get; set; }

        public bool Dead;
    }

    public class ClientBlockInfo
    {
        public int Index { get; set; }
        public string Name { get; set; }
    }

    public class ClientFortuneInfo
    {
        public int ItemIndex { get; set; }
        public ItemInfo ItemInfo;

        public TimeSpan CheckTime { get; set; }
        public long DropCount { get; set; }
        public decimal Progress { get; set; }

        public DateTime CheckDate;

        [CompleteObject]
        public void OnComplete()
        {
            ItemInfo = CartoonGlobals.ItemInfoList.Binding.First(x => x.Index == ItemIndex);

            CheckDate = Time.Now - CheckTime;
        }
    }
}


