using System;
using System.Drawing;
using System.IO;
using System.Security.Cryptography;
using Library;

namespace Server.Envir
{
    [ConfigPath(@".\Server.ini")]
    public static class Config
    {
        [ConfigSection("*******【Network】*******")]
        public static string IPAddress { get; set; } = "127.0.0.1";
        public static ushort Port { get; set; } = 7000;
        public static TimeSpan TimeOut { get; set; } = TimeSpan.FromSeconds(20);
        public static TimeSpan PingDelay { get; set; } = TimeSpan.FromSeconds(2);
        public static ushort UserCountPort { get; set; } = 3000;
        public static int MaxPacket { get; set; } = 50;
        public static TimeSpan PacketBanTime { get; set; } = TimeSpan.FromMinutes(5);
        public static string SyncRemotePreffix { get; set; } = "http://127.0.0.1:80/Command/";


        [ConfigSection("*******【System】*******")]
        public static bool CheckVersion { get; set; } = true;
        public static string VersionPath { get; set; } = @".\Zircon.exe";
        public static TimeSpan DBSaveDelay { get; set; } = TimeSpan.FromMinutes(5);
        public static string MapPath { get; set; } = @".\Map\";
        public static byte[] ClientHash;
        public static string MasterPassword { get; set; } = @"REDACTED";
        public static string SyncKey { get; set; } = "REDACTED";
        public static string ClientPath { get; set; }
        public static DateTime ReleaseDate { get; set; } = new DateTime(2017, 12, 22, 18, 00, 00, DateTimeKind.Utc);
        public static bool TestServer { get; set; } = false;
        public static string StarterGuildName { get; set; } = "新手公会";
        public static DateTime EasterEventTime { get; set; } = new DateTime(2018, 04, 08, 00, 00, 00, DateTimeKind.Utc);
        public static DateTime EasterEventEnd { get; set; } = new DateTime(2018, 04, 09, 00, 00, 00, DateTimeKind.Utc);
        public static DateTime HalloweenEventTime { get; set; } = new DateTime(2016, 12, 25, 19, 30, 00, DateTimeKind.Utc);
        public static DateTime HalloweenEventEnd { get; set; } = new DateTime(2016, 12, 25, 00, 00, 00, DateTimeKind.Utc);
        public static DateTime ChristmasEventTime { get; set; } = new DateTime(2018, 12, 25, 20, 30, 00, DateTimeKind.Utc);
        public static DateTime ChristmasEventEnd { get; set; } = new DateTime(2018, 12, 25, 20, 50, 00, DateTimeKind.Utc);
        public static bool 是否关闭服务器时倒计时 { get; set; } = false;
        public static string 关闭提示 { get; set; } = "请注意，服务器即将关闭！！！倒计时 {0} 秒 ";
        public static bool 是否开启神秘商人活动 { get; set; } = true;
        public static int 神秘商人NPC移除时间 { get; set; } = 120;
        public static string 需要合并的角色数据库路径地址 { get; set; } = ".\\ServerHebing";
        public static bool 是否开启活动栏 { get; set; } = false;
        public static int 活动栏宽度 { get; set; } = 420;
        public static int 活动栏高度 { get; set; } = 300;
        public static string 活动栏标题 { get; set; } = "圣诞节活动";
        public static string OrderPath { get; set; } = "./DyxPay/Order.ini";

        [ConfigSection("*******【防挂机验证系统】*******")]
        
        public static bool 是否开启防挂机验证系统 { get; set; } = false;
        
        public static int 第一次多长分钟后出现防挂机验证窗口 { get; set; } = 10;
        
        public static TimeSpan 每隔分钟出现防挂机验证窗口 { get; set; } = TimeSpan.FromMinutes(10.0);
        
        public static TimeSpan 答题多少秒中回答完毕 { get; set; } = TimeSpan.FromSeconds(40.0);
        
        public static int 回答错误几次强制退出游戏 { get; set; } = 2;
        
        public static int 回答正确时的奖励赏金 { get; set; } = 0;
        
        public static int 回答错误时的罚款赏金 { get; set; } = 0;
        
        public static int 回答正确时的奖励元宝 { get; set; } = 0;
        
        public static int 回答错误时的罚款元宝 { get; set; } = 0;
        
        public static int 回答正确时的奖励金币 { get; set; } = 5000;
        
        public static int 回答错误时的罚款金币 { get; set; } = 5000;

        [ConfigSection("*******【Control】*******")]
        public static bool AllowLogin { get; set; } = true;
        public static bool AllowNewAccount { get; set; } = true;
        public static bool AllowChangePassword { get; set; } = true;

        public static bool AllowRequestPasswordReset { get; set; } = true;
        public static bool AllowWebResetPassword { get; set; } = true;
        public static bool AllowManualResetPassword { get; set; } = true;

        public static bool AllowDeleteAccount { get; set; } = true;

        public static bool AllowManualActivation { get; set; } = true;
        public static bool AllowWebActivation { get; set; } = true;
        public static bool AllowRequestActivation { get; set; } = true;
        public static bool 是否顶号自动修改密码 { get; set; } = true;
        public static bool AllowSystemDBSync { get; set; } = false;

        public static bool AllowNewCharacter { get; set; } = true;
        public static bool AllowDeleteCharacter { get; set; } = true;
        public static bool AllowStartGame { get; set; }
        public static TimeSpan RelogDelay { get; set; } = TimeSpan.FromSeconds(10);
        public static bool AllowWarrior { get; set; } = true;
        public static bool AllowWizard { get; set; } = true;
        public static bool AllowTaoist { get; set; } = true;
        public static bool AllowAssassin { get; set; } = true;
        public static bool 玩家上线下线提示 { get; set; } = true;
        public static bool 新玩家上线提示 { get; set; } = true;

        public static bool 是否公测开启游戏 { get; set; } = true;
        public static bool 是否内测开启游戏 { get; set; } = false;
        public static bool 挂机寻找怪物模式01 { get; set; } = false;
        public static bool 挂机寻找怪物模式02 { get; set; } = true;
        public static bool 是否自动挂机功能下班期间关闭 { get; set; } = false;


        [ConfigSection("*******【Mail】*******")]
        public static string MailServer { get; set; } = @"smtp.qq.com";
        public static int MailPort { get; set; } = 587;
        public static bool MailUseSSL { get; set; } = true;
        public static string MailAccount { get; set; } = @"";
        public static string MailPassword { get; set; } = @"";
        public static string MailFrom { get; set; } = "";
        public static string MailDisplayName { get; set; } = "Admin";

        [ConfigSection("*******【WebServer】*******")]
        public static string WebPrefix { get; set; } = @"http://*:80/Command/";
        public static string WebCommandLink { get; set; } = @"https://www.walijan.com/Command";

        public static string ActivationSuccessLink { get; set; } = @"https://www.walijan.com/activation-successful/";
        public static string ActivationFailLink { get; set; } = @"https://www.walijan.com/activation-unsuccessful/";
        public static string ResetSuccessLink { get; set; } = @"https://www.walijan.com/password-reset-successful/";
        public static string ResetFailLink { get; set; } = @"https://www.walijan.com/password-reset-unsuccessful/";
        public static string DeleteSuccessLink { get; set; } = @"https://www.walijan.com/account-deletetion-successful/";
        public static string DeleteFailLink { get; set; } = @"https://www.walijan.com/account-deletetion-unsuccessful/";

        public static string BuyPrefix { get; set; } = @"http://*:80/BuyGameGold/";
        public static string BuyAddress { get; set; } = @"http://www.walijan.com/BuyGameGold";
        public static string IPNPrefix { get; set; } = @"http://*:80/IPN/";
        public static string ReceiverEMail { get; set; } = @"REDACTED";
        public static bool ProcessGameGold { get; set; } = true;
        public static bool AllowBuyGammeGold { get; set; } = true;
        public static bool RequireActivation { get; set; } = false;

        [ConfigSection("*******【Players】*******")]
        public static int MaxViewRange { get; set; } = 18;
        public static TimeSpan ShoutDelay { get; set; } = TimeSpan.FromSeconds(10);
        public static TimeSpan GlobalDelay { get; set; } = TimeSpan.FromSeconds(60);
        public static int MaxLevel { get; set; } = 10;
        public static int DayCycleCount { get; set; } = 3;
        public static int SkillExp { get; set; } = 3;
        public static bool AllowObservation { get; set; } = true;
        public static TimeSpan BrownDuration { get; set; } = TimeSpan.FromSeconds(60);
        public static int PKPointRate { get; set; } = 50;
        public static TimeSpan PKPointTickRate { get; set; } = TimeSpan.FromSeconds(60);
        public static int RedPoint { get; set; } = 200;
        public static TimeSpan PvPCurseDuration { get; set; } = TimeSpan.FromMinutes(60);
        public static int PvPCurseRate { get; set; } = 4;
        public static TimeSpan AutoReviveDelay { get; set; } = TimeSpan.FromMinutes(10);
        public static bool YunxuXiugaiJieshaoren { get; set; } = true;
        public static int 介绍人组新人经验加成 { get; set; } = 20;
        public static int 介绍人组被介绍人经验加成 { get; set; } = 1;
        public static int 介绍人组被介绍人个人经验加成 { get; set; } = 1;
        public static bool 要求介绍人激活账号 { get; set; } = false;
        public static int 激活玩家经验加成 { get; set; } = 20;
        public static int 开启经验回收等级 { get; set; } = 30;
        public static bool 是否开启公会等级 { get; set; } = true;
        public static bool 是否送新手礼物 { get; set; } = false;
        public static bool 是否开启公会排行榜Buff { get; set; } = false;
        public static bool 是否开启公会个人排行榜Buff { get; set; } = false;
        public static int 包裹远程装备分解功能开启玩家转生次数 { get; set; } = 3;
        public static Decimal 刺客最后抵抗 { get; set; } = new Decimal(20, 0, 0, false, (byte)2);
        public static Decimal 刺客四花技能 { get; set; } = new Decimal(60, 0, 0, false, (byte)2);
        public static bool 是否开启一刀一花 { get; set; } = false;
        public static bool 是否开启优化最后抵抗技能伤害 { get; set; } = false;
        public static bool 是否开启留级转生 { get; set; } = false;
        public static bool 是否开启装备幻化时镶嵌宝石挂钩玩家转生次数 { get; set; } = true;
        public static bool 是否幻化装备后绑定装备 { get; set; } = true;
        public static bool 是否开启5433合成宝石 { get; set; } = false;
        public static bool 是否开启死亡爆率 { get; set; } = true;
        public static int 包裹中的物品掉率 { get; set; } = 10;
        public static int 普通物品的掉率 { get; set; } = 20;
        public static int 高级物品的掉率 { get; set; } = 75;
        public static int 稀世物品的掉率 { get; set; } = 500;
        public static int 红名物品掉率 { get; set; } = 1;
        public static bool 是否开启被怪死亡身上装备爆率 { get; set; } = true;
        public static bool 是否传染技能伤害对Boss开启 { get; set; } = false;
        public static bool 是否开启施毒术技能挂钩道士属性 { get; set; } = false;
        public static int 施毒术技能伤害最高值 { get; set; } = 100;
        public static bool 是否开启绑定铭文来洗武器时武器改为绑定武器机制 { get; set; } = false;
        public static bool 是否开启复古模式铭文系统 { get; set; } = false;
        public static bool 是否开启隐藏经验加成功能 { get; set; } = false;
        public static string 给隐藏经验加成的玩家 { get; set; } = "Admin";
        public static int 添加经验加成 { get; set; } = 50;
        public static bool 是否日志记录玩家一般包裹物品卡位情况 { get; set; } = false;
        public static bool 是否开启技能书成功率 { get; set; } = true;


        [ConfigSection("*******【Monsters】******")]
        public static TimeSpan DeadDuration { get; set; } = TimeSpan.FromMinutes(1);
        public static TimeSpan HarvestDuration { get; set; } = TimeSpan.FromMinutes(5);
        public static int MysteryShipRegionIndex { get; set; } = 711;
        public static int MysteryShipOpen { get; set; } = 20;
        public static bool 神舰是否记录 { get; set; } = false;
        public static string 神舰记录名称 { get; set; } = "";
        public static int LairRegionIndex { get; set; } = 1570;
        public static int LairRegionOpen { get; set; } = 20;
        public static bool 熔岩是否记录 { get; set; } = false;
        public static string 熔岩记录名称 { get; set; } = "";
        public static int Yaota { get; set; } = 1876;
        public static int YaotaOpen { get; set; } = 20;
        public static bool 比奇地下城是否记录 { get; set; } = false;
        public static string 比奇地下城记录名称 { get; set; } = "";
        public static int Mota { get; set; } = 1916;
        public static int MotaOpen { get; set; } = 20;
        public static bool 魔虫洞是否记录 { get; set; } = true;
        public static string 魔虫洞记录名称 { get; set; } = "魔虫洞记录";
        public static int Huodong01 { get; set; } = 1918;
        public static int Huodong01Open { get; set; } = 20;
        public static bool 活动01是否记录 { get; set; } = true;
        public static string 活动01记录名称 { get; set; } = "尸王殿记录";
        public static int Huodong02 { get; set; } = 1926;
        public static int Huodong02Open { get; set; } = 20;
        public static bool 活动02是否记录 { get; set; } = true;
        public static string 活动02记录名称 { get; set; } = "宝藏殿记录";
        public static int Huodong03 { get; set; } = 0;
        public static int Huodong03Open { get; set; } = 20;
        public static bool 活动03是否记录 { get; set; } = false;
        public static string 活动03记录名称 { get; set; } = "";
        public static int Huodong04 { get; set; } = 0;
        public static int Huodong04Open { get; set; } = 20;
        public static bool 活动04是否记录 { get; set; } = false;
        public static string 活动04记录名称 { get; set; } = "";
        public static int Huodong05 { get; set; } = 0;
        public static int Huodong05Open { get; set; } = 20;
        public static bool 活动05是否记录 { get; set; } = false;
        public static string 活动05记录名称 { get; set; } = "";
        public static int Huodong06 { get; set; } = 0;
        public static int Huodong06Open { get; set; } = 20;
        public static bool 活动06是否记录 { get; set; } = false;
        public static string 活动06记录名称 { get; set; } = "";
        public static int Huodong07 { get; set; } = 0;
        public static int Huodong07Open { get; set; } = 20;
        public static bool 活动07是否记录 { get; set; } = false;
        public static string 活动07记录名称 { get; set; } = "";
        public static int Huodong08 { get; set; } = 0;
        public static int Huodong08Open { get; set; } = 20;
        public static bool 活动08是否记录 { get; set; } = false;
        public static string 活动08记录名称 { get; set; } = "";
        public static int Huodong09 { get; set; } = 0;
        public static int Huodong09Open { get; set; } = 20;
        public static bool 活动09是否记录 { get; set; } = false;
        public static string 活动09记录名称 { get; set; } = "";
        public static int Huodong10 { get; set; } = 1963;
        public static int Huodong10Open { get; set; } = 20;
        public static bool 活动10是否记录 { get; set; } = false;
        public static string 活动10记录名称 { get; set; } = "";
        public static int Huodong11 { get; set; } = 1955;
        public static int Huodong11Open { get; set; } = 1;
        public static bool 活动11是否记录 { get; set; } = false;
        public static string 活动11记录名称 { get; set; } = "";
        public static int Huodong12 { get; set; } = 1942;
        public static int Huodong12Open { get; set; } = 1;
        public static bool 活动12是否记录 { get; set; } = false;
        public static string 活动12记录名称 { get; set; } = "";
        public static bool 是否开启刷怪时间波动 { get; set; } = false;

        [ConfigSection("*******【Items】*******")]
        public static bool 是否挖矿物品绑定 { get; set; } = true;
        public static TimeSpan DropDuration { get; set; } = TimeSpan.FromMinutes(60);
        public static int DropDistance { get; set; } = 5;
        public static int DropLayers { get; set; } = 5;
        public static int TorchRate { get; set; } = 10;
        public static TimeSpan SpecialRepairDelay { get; set; } = TimeSpan.FromHours(8);
        public static int MaxLuck { get; set; } = 7;
        public static int MaxCurse { get; set; } = -10;
        public static int 宝箱抽奖 { get; set; } = 500;
        public static int 宝箱重置 { get; set; } = 500;
        public static int 每天免费挂机时间 { get; set; } = 4;
        public static int 极品的爆率 { get; set; } = 15;
        public static int 极品的大小1 { get; set; } = 1;
        public static int 极品的大小2 { get; set; } = 2;
        public static int 极品的大小3 { get; set; } = 3;
        public static int 极品的大小4 { get; set; } = 4;
        public static int 极品的大小5 { get; set; } = 5;
        public static int 极品的大小6 { get; set; } = 6;
        public static int 武器攻击自然灵魂大小产生概率1 { get; set; } = 5;
        public static int 武器攻击自然灵魂大小产生概率2 { get; set; } = 50;
        public static int 武器攻击自然灵魂大小产生概率3 { get; set; } = 250;
        public static int 武器攻击自然灵魂大小产生概率4 { get; set; } = 450;
        public static int 武器攻击自然灵魂大小产生概率5 { get; set; } = 650;
        public static int 武器攻击自然灵魂大小产生概率6 { get; set; } = 1000;
        public static int 所有攻击元素极品大小产生概率1 { get; set; } = 3;
        public static int 所有攻击元素极品大小产生概率2 { get; set; } = 5;
        public static int 所有攻击元素极品大小产生概率3 { get; set; } = 25;
        public static int 所有攻击元素极品大小产生概率4 { get; set; } = 75;
        public static int 所有攻击元素极品大小产生概率5 { get; set; } = 250;
        public static int 所有攻击元素极品大小产生概率6 { get; set; } = 600;
        public static int 盾牌攻击自然灵魂格挡闪避毒系抵抗几率的大小生产概率1 { get; set; } = 10;
        public static int 盾牌攻击自然灵魂格挡闪避毒系抵抗几率的大小生产概率2 { get; set; } = 50;
        public static int 盾牌攻击自然灵魂格挡闪避毒系抵抗几率的大小生产概率3 { get; set; } = 250;
        public static int 盾牌攻击自然灵魂格挡闪避毒系抵抗几率的大小生产概率4 { get; set; } = 450;
        public static int 盾牌攻击自然灵魂格挡闪避毒系抵抗几率的大小生产概率5 { get; set; } = 650;
        public static int 盾牌攻击自然灵魂格挡闪避毒系抵抗几率的大小生产概率6 { get; set; } = 1000;
        public static int 衣服戒指防御魔御戒指拾取范围的大小生产概率1 { get; set; } = 2;
        public static int 衣服戒指防御魔御戒指拾取范围的大小生产概率2 { get; set; } = 15;
        public static int 衣服戒指防御魔御戒指拾取范围的大小生产概率3 { get; set; } = 150;
        public static int 衣服戒指防御魔御戒指拾取范围的大小生产概率4 { get; set; } = 275;
        public static int 衣服戒指防御魔御戒指拾取范围的大小生产概率5 { get; set; } = 675;
        public static int 衣服戒指防御魔御戒指拾取范围的大小生产概率6 { get; set; } = 1000;
        public static int 头防魔首饰攻自灵链手准确敏捷鞋子舒适的大小生产概率1 { get; set; } = 5;
        public static int 头防魔首饰攻自灵链手准确敏捷鞋子舒适的大小生产概率2 { get; set; } = 25;
        public static int 头防魔首饰攻自灵链手准确敏捷鞋子舒适的大小生产概率3 { get; set; } = 250;
        public static int 头防魔首饰攻自灵链手准确敏捷鞋子舒适的大小生产概率4 { get; set; } = 450;
        public static int 头防魔首饰攻自灵链手准确敏捷鞋子舒适的大小生产概率5 { get; set; } = 650;
        public static int 头防魔首饰攻自灵链手准确敏捷鞋子舒适的大小生产概率6 { get; set; } = 1000;
        public static int 鞋子手镯防御魔御的大小生产概率1 { get; set; } = 5;
        public static int 鞋子手镯防御魔御的大小生产概率2 { get; set; } = 15;
        public static int 鞋子手镯防御魔御的大小生产概率3 { get; set; } = 150;
        public static int 鞋子手镯防御魔御的大小生产概率4 { get; set; } = 275;
        public static int 鞋子手镯防御魔御的大小生产概率5 { get; set; } = 675;
        public static int 鞋子手镯防御魔御的大小生产概率6 { get; set; } = 1000;
        public static int CurseRate { get; set; } = 20;
        public static int LuckRate { get; set; } = 10;
        public static int MaxStrength { get; set; } = 5;
        public static int StrengthAddRate { get; set; } = 10;
        public static int StrengthLossRate { get; set; } = 20;
        public static int 用道具每次碎片合成数量 { get; set; } = 40;

        [ConfigSection("*******【Rates】*******")]
        public static int ExperienceRate { get; set; } = 0;
        public static int 额外经验加成 { get; set; } = 50;
        public static bool 是否开启额外经验加成 { get; set; } = false;
        public static int DropRate { get; set; } = 0;
        public static int 额外爆率加成 { get; set; } = 50;
        public static bool 是否开启额外爆率加成 { get; set; } = false;
        public static int GoldRate { get; set; } = 0;
        public static int 额外金币加成 { get; set; } = 50;
        public static bool 是否开启额外金币加成 { get; set; } = false;
        public static int SkillRate { get; set; } = 0;
        public static int CompanionRate { get; set; } = 0;
        public static int Jinglianchenggonglv { get; set; } = 40;
        public static int Jingyanquan3039 { get; set; } = 5000;
        public static int Jingyanquan4049 { get; set; } = 10000;
        public static int Jingyanquan5059 { get; set; } = 15000;
        public static int Jingyanquan6069 { get; set; } = 25000;
        public static int Jingyanquan7079 { get; set; } = 45000;
        public static int Jingyanquan8089 { get; set; } = 90000;
        public static int Jingyanquan9099 { get; set; } = 220000;
        public static int Jingyanquan0109 { get; set; } = 79;
        public static int Jingyanquan1019 { get; set; } = 1600;
        public static int Jingyanquan2029 { get; set; } = 4000;
        public static int 青铜会员经验 { get; set; } = 30;
        public static int 青铜会员爆率 { get; set; } = 30;
        public static int 青铜会员金币 { get; set; } = 30;
        public static int 白银会员经验 { get; set; } = 50;
        public static int 白银会员爆率 { get; set; } = 50;
        public static int 白银会员金币 { get; set; } = 50;
        public static int 黄金会员经验 { get; set; } = 100;
        public static int 黄金会员爆率 { get; set; } = 100;
        public static int 黄金会员金币 { get; set; } = 100;
        public static int 青铜回收倍率 { get; set; } = 120;
        public static int 白银回收倍率 { get; set; } = 140;
        public static int 黄金回收倍率 { get; set; } = 160;
        public static int 武器基础爆率 { get; set; } = 0;
        public static int 衣服基础爆率 { get; set; } = 0;
        public static int 头盔基础爆率 { get; set; } = 0;
        public static int 项链基础爆率 { get; set; } = 0;
        public static int 手镯基础爆率 { get; set; } = 0;
        public static int 戒指基础爆率 { get; set; } = 0;
        public static int 靴子基础爆率 { get; set; } = 0;
        public static int 矿石基础爆率 { get; set; } = 0;
        public static int 书籍基础爆率 { get; set; } = 0;
        public static int 盾牌基础爆率 { get; set; } = 0;
        public static int 徽章基础爆率 { get; set; } = 0;
        public static int 宝石基础爆率 { get; set; } = 0;
        public static int 轴卷基础爆率 { get; set; } = 0;
        public static int 公会泉回收经验3039 { get; set; } = 700;
        public static int 公会泉回收经验4049 { get; set; } = 1000;
        public static int 公会泉回收经验5059 { get; set; } = 1600;
        public static int 公会泉回收经验6069 { get; set; } = 2200;
        public static int 公会泉回收经验7079 { get; set; } = 2700;
        public static int 公会泉回收经验8089 { get; set; } = 3300;
        public static int 公会泉回收经验90以上 { get; set; } = 4200;
        public static int 公会泉回收经验0109 { get; set; } = 0;
        public static int 公会泉回收经验1019 { get; set; } = 0;
        public static int 公会泉回收经验2029 { get; set; } = 500;
        public static int 介绍人等级10时 { get; set; } = 50;
        public static int 介绍人等级20时 { get; set; } = 100;
        public static int 介绍人等级30时 { get; set; } = 200;
        public static int 介绍人等级40时 { get; set; } = 300;
        public static int 介绍人等级50时 { get; set; } = 500;
        public static int 被介绍人第一阶段等级 { get; set; } = 50;
        public static int 被介绍人第一阶段赏金 { get; set; } = 100;
        public static int 被介绍人第一阶段声望 { get; set; } = 5;
        public static int 介绍人第一阶段赏金 { get; set; } = 70;
        public static int 介绍人第一阶段声望 { get; set; } = 10;
        public static int 被介绍人第二阶段等级 { get; set; } = 60;
        public static int 被介绍人第二阶段赏金 { get; set; } = 150;
        public static int 被介绍人第二阶段声望 { get; set; } = 7;
        public static int 介绍人第二阶段赏金 { get; set; } = 100;
        public static int 介绍人第二阶段声望 { get; set; } = 15;
        public static int 被介绍人第三阶段等级 { get; set; } = 70;
        public static int 被介绍人第三阶段赏金 { get; set; } = 200;
        public static int 被介绍人第三阶段声望 { get; set; } = 9;
        public static int 介绍人第三阶段赏金 { get; set; } = 125;
        public static int 介绍人第三阶段声望 { get; set; } = 20;
        public static int 被介绍人第四阶段等级 { get; set; } = 80;
        public static int 被介绍人第四阶段赏金 { get; set; } = 200;
        public static int 被介绍人第四阶段声望 { get; set; } = 12;
        public static int 介绍人第四阶段赏金 { get; set; } = 150;
        public static int 介绍人第四阶段声望 { get; set; } = 25;
        public static int 新收公会角色等级低于 { get; set; } = 50;
        public static int 新收公会经验加成 { get; set; } = 50;
        public static int 新收公会爆率加成 { get; set; } = 50;
        public static int 新收公会金币加成 { get; set; } = 50;
        public static int 其他公会人数限制一 { get; set; } = 15;
        public static int 其他公会经验加成一 { get; set; } = 30;
        public static int 其他公会爆率加成一 { get; set; } = 30;
        public static int 其他公会金币加成一 { get; set; } = 30;
        public static int 其他公会人数限制二 { get; set; } = 30;
        public static int 其他公会经验加成二 { get; set; } = 23;
        public static int 其他公会爆率加成二 { get; set; } = 23;
        public static int 其他公会金币加成二 { get; set; } = 23;
        public static int 其他公会人数限制三 { get; set; } = 45;
        public static int 其他公会经验加成三 { get; set; } = 18;
        public static int 其他公会爆率加成三 { get; set; } = 18;
        public static int 其他公会金币加成三 { get; set; } = 18;
        public static int 其他公会人数限制四 { get; set; } = 46;
        public static int 其他公会经验加成四 { get; set; } = 13;
        public static int 其他公会爆率加成四 { get; set; } = 13;
        public static int 其他公会金币加成四 { get; set; } = 13;
        public static int 沙巴克公会经验加成 { get; set; } = 10;
        public static int 沙巴克公会爆率加成 { get; set; } = 10;
        public static int 沙巴克公会金币加成 { get; set; } = 10;

        [ConfigSection("*******【极品爆率设置】*******")]

        public static int 高级产生极品的概率 { get; set; } = 15;
        
        
        public static int 高级武器攻击极品属性产生概率 { get; set; } = 5;
        public static int 高级武器产生攻击极品属性的大小 { get; set; } = 1;
        public static int 高级武器攻击加二极品属性的产生率 { get; set; } = 20;
        public static int 高级武器攻击加三极品属性的产生率 { get; set; } = 250;
        public static int 高级武器攻击加四极品属性的产生率 { get; set; } = 450;
        public static int 高级武器攻击加五极品属性的产生率 { get; set; } = 650;
        
        public static int 高级武器自然灵魂极品属性产生概率 { get; set; } = 5;
        public static int 高级武器产生自然灵魂极品属性的大小 { get; set; } = 1;
        public static int 高级武器自然灵魂加二极品属性的产生率 { get; set; } = 20;
        public static int 高级武器自然灵魂加三极品属性的产生率 { get; set; } = 250;
        public static int 高级武器自然灵魂加四极品属性的产生率 { get; set; } = 450;
        public static int 高级武器自然灵魂加五极品属性的产生率 { get; set; } = 650;

        
        public static int 高级武器准确极品属性产生概率 { get; set; } = 5;
        public static int 高级武器产生准确极品属性的大小 { get; set; } = 1;
        public static int 高级武器准确加二极品属性的产生率 { get; set; } = 20;
        public static int 高级武器准确加三极品属性的产生率 { get; set; } = 250;
        public static int 高级武器准确加四极品属性的产生率 { get; set; } = 450;
        public static int 高级武器准确加五极品属性的产生率 { get; set; } = 650;

        
        public static int 高级武器攻击元素极品属性产生概率 { get; set; } = 3;
        public static int 高级武器产生攻击元素极品属性的大小 { get; set; } = 1;
        public static int 高级武器攻击元素加二极品属性的产生率 { get; set; } = 5;
        public static int 高级武器攻击元素加三极品属性的产生率 { get; set; } = 25;
        public static int 高级武器攻击元素加四极品属性的产生率 { get; set; } = 75;
        public static int 高级武器攻击元素加五极品属性的产生率 { get; set; } = 250;

        
        
        public static int 高级盾牌攻击几率极品属性产生概率 { get; set; } = 10;
        public static int 高级盾牌产生攻击几率极品属性的大小 { get; set; } = 1;
        public static int 高级盾牌攻击几率加二极品属性的产生率 { get; set; } = 50;
        public static int 高级盾牌攻击几率加三极品属性的产生率 { get; set; } = 250;
        public static int 高级盾牌攻击几率加四极品属性的产生率 { get; set; } = 450;
        public static int 高级盾牌攻击几率加五极品属性的产生率 { get; set; } = 650;

        
        public static int 高级盾牌自然灵魂几率极品属性产生概率 { get; set; } = 10;
        public static int 高级盾牌产生自然灵魂几率极品属性的大小 { get; set; } = 1;
        public static int 高级盾牌自然灵魂几率加二极品属性的产生率 { get; set; } = 50;
        public static int 高级盾牌自然灵魂几率加三极品属性的产生率 { get; set; } = 250;
        public static int 高级盾牌自然灵魂几率加四极品属性的产生率 { get; set; } = 450;
        public static int 高级盾牌自然灵魂几率加五极品属性的产生率 { get; set; } = 650;

        
        public static int 高级盾牌格挡几率极品属性产生概率 { get; set; } = 10;
        public static int 高级盾牌产生格挡几率极品属性的大小 { get; set; } = 1;
        public static int 高级盾牌格挡几率加二极品属性的产生率 { get; set; } = 50;
        public static int 高级盾牌格挡几率加三极品属性的产生率 { get; set; } = 250;
        public static int 高级盾牌格挡几率加四极品属性的产生率 { get; set; } = 450;
        public static int 高级盾牌格挡几率加五极品属性的产生率 { get; set; } = 650;

        
        public static int 高级盾牌闪避几率极品属性产生概率 { get; set; } = 10;
        public static int 高级盾牌产生闪避几率极品属性的大小 { get; set; } = 1;
        public static int 高级盾牌闪避几率加二极品属性的产生率 { get; set; } = 50;
        public static int 高级盾牌闪避几率加三极品属性的产生率 { get; set; } = 250;
        public static int 高级盾牌闪避几率加四极品属性的产生率 { get; set; } = 450;
        public static int 高级盾牌闪避几率加五极品属性的产生率 { get; set; } = 650;

        
        public static int 高级盾牌毒系抵抗几率极品属性产生概率 { get; set; } = 10;
        public static int 高级盾牌产生毒系抵抗几率极品属性的大小 { get; set; } = 1;
        public static int 高级盾牌毒系抵抗几率加二极品属性的产生率 { get; set; } = 50;
        public static int 高级盾牌毒系抵抗几率加三极品属性的产生率 { get; set; } = 250;
        public static int 高级盾牌毒系抵抗几率加四极品属性的产生率 { get; set; } = 450;
        public static int 高级盾牌毒系抵抗几率加五极品属性的产生率 { get; set; } = 650;

        
        public static int 高级盾牌强元素极品属性产生概率 { get; set; } = 10;
        public static int 高级盾牌产生强元素属性的大小 { get; set; } = 2;
        public static int 高级盾牌弱元素第二属性的产生率 { get; set; } = 2;
        public static int 高级盾牌强元素第三属性产生概率 { get; set; } = 45;
        public static int 高级盾牌弱元素第四属性的产生率 { get; set; } = 2;
        public static int 高级盾牌强元素第五属性产生概率 { get; set; } = 60;
        public static int 高级盾牌弱元素第六属性产生概率 { get; set; } = 2;
        public static int 高级盾牌弱元素第五属性产生概率 { get; set; } = 60;
        public static int 高级盾牌弱元素第三属性产生概率 { get; set; } = 45;
        public static int 高级盾牌弱元素极品属性产生概率 { get; set; } = 10;

        
        
        public static int 高级衣服防御极品属性产生概率 { get; set; } = 2;
        public static int 高级衣服产生防御极品属性的大小 { get; set; } = 1;
        public static int 高级衣服防御加二极品属性的产生率 { get; set; } = 15;
        public static int 高级衣服防御加三极品属性的产生率 { get; set; } = 150;
        public static int 高级衣服防御加四极品属性的产生率 { get; set; } = 450;
        public static int 高级衣服防御加五极品属性的产生率 { get; set; } = 750;
        
        public static int 高级衣服魔御极品属性产生概率 { get; set; } = 2;
        public static int 高级衣服产生魔御极品属性的大小 { get; set; } = 1;
        public static int 高级衣服魔御加二极品属性的产生率 { get; set; } = 15;
        public static int 高级衣服魔御加三极品属性的产生率 { get; set; } = 150;
        public static int 高级衣服魔御加四极品属性的产生率 { get; set; } = 450;
        public static int 高级衣服魔御加五极品属性的产生率 { get; set; } = 750;
        
        public static int 高级衣服强元素极品属性产生概率 { get; set; } = 10;
        public static int 高级衣服产生强元素属性的大小 { get; set; } = 2;
        public static int 高级衣服弱元素第二属性的产生率 { get; set; } = 2;
        public static int 高级衣服强元素第三属性产生概率 { get; set; } = 45;
        public static int 高级衣服弱元素第四属性的产生率 { get; set; } = 2;
        public static int 高级衣服强元素第五属性产生概率 { get; set; } = 60;
        public static int 高级衣服弱元素第六属性产生概率 { get; set; } = 2;
        public static int 高级衣服弱元素第五属性产生概率 { get; set; } = 60;
        public static int 高级衣服弱元素第三属性产生概率 { get; set; } = 45;
        public static int 高级衣服弱元素极品属性产生概率 { get; set; } = 10;

        
        
        public static int 高级头盔防御极品属性产生概率 { get; set; } = 2;
        public static int 高级头盔产生防御极品属性的大小 { get; set; } = 1;
        public static int 高级头盔防御加二极品属性的产生率 { get; set; } = 15;
        public static int 高级头盔防御加三极品属性的产生率 { get; set; } = 150;
        public static int 高级头盔防御加四极品属性的产生率 { get; set; } = 450;
        public static int 高级头盔防御加五极品属性的产生率 { get; set; } = 750;

        
        public static int 高级头盔魔御极品属性产生概率 { get; set; } = 2;
        public static int 高级头盔产生魔御极品属性的大小 { get; set; } = 1;
        public static int 高级头盔魔御加二极品属性的产生率 { get; set; } = 15;
        public static int 高级头盔魔御加三极品属性的产生率 { get; set; } = 150;
        public static int 高级头盔魔御加四极品属性的产生率 { get; set; } = 450;
        public static int 高级头盔魔御加五极品属性的产生率 { get; set; } = 750;

        
        public static int 高级头盔强元素极品属性产生概率 { get; set; } = 10;
        public static int 高级头盔产生强元素属性的大小 { get; set; } = 1;
        public static int 高级头盔弱元素第二属性的产生率 { get; set; } = 2;
        public static int 高级头盔强元素第三属性产生概率 { get; set; } = 45;
        public static int 高级头盔弱元素第四属性的产生率 { get; set; } = 2;
        public static int 高级头盔强元素第五属性产生概率 { get; set; } = 60;
        public static int 高级头盔弱元素第六属性产生概率 { get; set; } = 2;
        public static int 高级头盔弱元素第五属性产生概率 { get; set; } = 60;
        public static int 高级头盔弱元素第三属性产生概率 { get; set; } = 45;
        public static int 高级头盔弱元素极品属性产生概率 { get; set; } = 10;

        
        public static int 高级头盔攻击元素极品属性产生概率 { get; set; } = 3;
        public static int 高级头盔产生攻击元素极品属性的大小 { get; set; } = 1;
        public static int 高级头盔攻击元素加二极品属性的产生率 { get; set; } = 5;
        public static int 高级头盔攻击元素加三极品属性的产生率 { get; set; } = 25;
        public static int 高级头盔攻击元素加四极品属性的产生率 { get; set; } = 75;
        public static int 高级头盔攻击元素加五极品属性的产生率 { get; set; } = 250;

        
        
        public static int 高级项链攻击极品属性产生概率 { get; set; } = 5;
        public static int 高级项链产生攻击极品属性的大小 { get; set; } = 1;
        public static int 高级项链攻击加二极品属性的产生率 { get; set; } = 25;
        public static int 高级项链攻击加三极品属性的产生率 { get; set; } = 250;
        public static int 高级项链攻击加四极品属性的产生率 { get; set; } = 450;
        public static int 高级项链攻击加五极品属性的产生率 { get; set; } = 650;
        
        public static int 高级项链自然灵魂极品属性产生概率 { get; set; } = 5;
        public static int 高级项链产生自然灵魂极品属性的大小 { get; set; } = 1;
        public static int 高级项链自然灵魂加二极品属性的产生率 { get; set; } = 25;
        public static int 高级项链自然灵魂加三极品属性的产生率 { get; set; } = 250;
        public static int 高级项链自然灵魂加四极品属性的产生率 { get; set; } = 450;
        public static int 高级项链自然灵魂加五极品属性的产生率 { get; set; } = 650;

        
        public static int 高级项链准确极品属性产生概率 { get; set; } = 5;
        public static int 高级项链产生准确极品属性的大小 { get; set; } = 1;
        public static int 高级项链准确加二极品属性的产生率 { get; set; } = 25;
        public static int 高级项链准确加三极品属性的产生率 { get; set; } = 250;
        public static int 高级项链准确加四极品属性的产生率 { get; set; } = 450;
        public static int 高级项链准确加五极品属性的产生率 { get; set; } = 650;

        
        public static int 高级项链敏捷极品属性产生概率 { get; set; } = 15;
        public static int 高级项链产生敏捷极品属性的大小 { get; set; } = 1;
        public static int 高级项链敏捷加二极品属性的产生率 { get; set; } = 75;
        public static int 高级项链敏捷加三极品属性的产生率 { get; set; } = 450;
        public static int 高级项链敏捷加四极品属性的产生率 { get; set; } = 650;
        public static int 高级项链敏捷加五极品属性的产生率 { get; set; } = 1000;

        
        public static int 高级项链攻击元素极品属性产生概率 { get; set; } = 3;
        public static int 高级项链产生攻击元素极品属性的大小 { get; set; } = 1;
        public static int 高级项链攻击元素加二极品属性的产生率 { get; set; } = 5;
        public static int 高级项链攻击元素加三极品属性的产生率 { get; set; } = 25;
        public static int 高级项链攻击元素加四极品属性的产生率 { get; set; } = 75;
        public static int 高级项链攻击元素加五极品属性的产生率 { get; set; } = 250;

        
        
        public static int 高级手镯防御极品属性产生概率 { get; set; } = 2;
        public static int 高级手镯产生防御极品属性的大小 { get; set; } = 1;
        public static int 高级手镯防御加二极品属性的产生率 { get; set; } = 15;
        public static int 高级手镯防御加三极品属性的产生率 { get; set; } = 150;
        public static int 高级手镯防御加四极品属性的产生率 { get; set; } = 450;
        public static int 高级手镯防御加五极品属性的产生率 { get; set; } = 750;

        
        public static int 高级手镯魔御极品属性产生概率 { get; set; } = 2;
        public static int 高级手镯产生魔御极品属性的大小 { get; set; } = 1;
        public static int 高级手镯魔御加二极品属性的产生率 { get; set; } = 15;
        public static int 高级手镯魔御加三极品属性的产生率 { get; set; } = 150;
        public static int 高级手镯魔御加四极品属性的产生率 { get; set; } = 450;
        public static int 高级手镯魔御加五极品属性的产生率 { get; set; } = 750;

        
        public static int 高级手镯攻击极品属性产生概率 { get; set; } = 5;
        public static int 高级手镯产生攻击极品属性的大小 { get; set; } = 1;
        public static int 高级手镯攻击加二极品属性的产生率 { get; set; } = 25;
        public static int 高级手镯攻击加三极品属性的产生率 { get; set; } = 250;
        public static int 高级手镯攻击加四极品属性的产生率 { get; set; } = 450;
        public static int 高级手镯攻击加五极品属性的产生率 { get; set; } = 650;

        
        public static int 高级手镯自然灵魂极品属性产生概率 { get; set; } = 5;
        public static int 高级手镯产生自然灵魂极品属性的大小 { get; set; } = 1;
        public static int 高级手镯自然灵魂加二极品属性的产生率 { get; set; } = 25;
        public static int 高级手镯自然灵魂加三极品属性的产生率 { get; set; } = 250;
        public static int 高级手镯自然灵魂加四极品属性的产生率 { get; set; } = 450;
        public static int 高级手镯自然灵魂加五极品属性的产生率 { get; set; } = 650;

        
        public static int 高级手镯准确极品属性产生概率 { get; set; } = 5;
        public static int 高级手镯产生准确极品属性的大小 { get; set; } = 1;
        public static int 高级手镯准确加二极品属性的产生率 { get; set; } = 25;
        public static int 高级手镯准确加三极品属性的产生率 { get; set; } = 2500000;
        public static int 高级手镯准确加四极品属性的产生率 { get; set; } = 4500000;
        public static int 高级手镯准确加五极品属性的产生率 { get; set; } = 6500000;

        
        public static int 高级手镯敏捷极品属性产生概率 { get; set; } = 15;
        public static int 高级手镯产生敏捷极品属性的大小 { get; set; } = 1;
        public static int 高级手镯敏捷加二极品属性的产生率 { get; set; } = 75;
        public static int 高级手镯敏捷加三极品属性的产生率 { get; set; } = 4500000;
        public static int 高级手镯敏捷加四极品属性的产生率 { get; set; } = 6500000;
        public static int 高级手镯敏捷加五极品属性的产生率 { get; set; } = 1000000;

        
        public static int 高级手镯强元素极品属性产生概率 { get; set; } = 10;
        public static int 高级手镯产生强元素属性的大小 { get; set; } = 1;
        public static int 高级手镯弱元素第二属性的产生率 { get; set; } = 2;
        public static int 高级手镯强元素第三属性产生概率 { get; set; } = 30;
        public static int 高级手镯弱元素第四属性的产生率 { get; set; } = 2;
        public static int 高级手镯强元素第五属性产生概率 { get; set; } = 40;
        public static int 高级手镯弱元素第六属性产生概率 { get; set; } = 2;
        public static int 高级手镯弱元素第五属性产生概率 { get; set; } = 40;
        public static int 高级手镯弱元素第三属性产生概率 { get; set; } = 30;
        public static int 高级手镯弱元素极品属性产生概率 { get; set; } = 10;

        
        public static int 高级手镯攻击元素极品属性产生概率 { get; set; } = 3;
        public static int 高级手镯产生攻击元素极品属性的大小 { get; set; } = 1;
        public static int 高级手镯攻击元素加二极品属性的产生率 { get; set; } = 5;
        public static int 高级手镯攻击元素加三极品属性的产生率 { get; set; } = 25;
        public static int 高级手镯攻击元素加四极品属性的产生率 { get; set; } = 75;
        public static int 高级手镯攻击元素加五极品属性的产生率 { get; set; } = 250;

        
        public static int 高级戒指攻击极品属性产生概率 { get; set; } = 5;
        public static int 高级戒指产生攻击极品属性的大小 { get; set; } = 1;
        public static int 高级戒指攻击加二极品属性的产生率 { get; set; } = 25;
        public static int 高级戒指攻击加三极品属性的产生率 { get; set; } = 250;
        public static int 高级戒指攻击加四极品属性的产生率 { get; set; } = 450;
        public static int 高级戒指攻击加五极品属性的产生率 { get; set; } = 650;

        
        public static int 高级戒指自然灵魂极品属性产生概率 { get; set; } = 5;
        public static int 高级戒指产生自然灵魂极品属性的大小 { get; set; } = 1;
        public static int 高级戒指自然灵魂加二极品属性的产生率 { get; set; } = 25;
        public static int 高级戒指自然灵魂加三极品属性的产生率 { get; set; } = 250;
        public static int 高级戒指自然灵魂加四极品属性的产生率 { get; set; } = 450;
        public static int 高级戒指自然灵魂加五极品属性的产生率 { get; set; } = 650;

        
        public static int 高级戒指拾取范围极品属性产生概率 { get; set; } = 20;
        public static int 高级戒指产生拾取范围极品属性的大小 { get; set; } = 1;
        public static int 高级戒指拾取范围加二极品属性的产生率 { get; set; } = 75;
        public static int 高级戒指拾取范围加三极品属性的产生率 { get; set; } = 450;
        public static int 高级戒指拾取范围加四极品属性的产生率 { get; set; } = 750;
        public static int 高级戒指拾取范围加五极品属性的产生率 { get; set; } = 1050;

        
        public static int 高级戒指攻击元素极品属性产生概率 { get; set; } = 3;
        public static int 高级戒指产生攻击元素极品属性的大小 { get; set; } = 1;
        public static int 高级戒指攻击元素加二极品属性的产生率 { get; set; } = 5;
        public static int 高级戒指攻击元素加三极品属性的产生率 { get; set; } = 25;
        public static int 高级戒指攻击元素加四极品属性的产生率 { get; set; } = 75;
        public static int 高级戒指攻击元素加五极品属性的产生率 { get; set; } = 250;

        
        
        public static int 高级鞋子防御极品属性产生概率 { get; set; } = 3;
        public static int 高级鞋子产生防御极品属性的大小 { get; set; } = 1;
        public static int 高级鞋子防御加二极品属性的产生率 { get; set; } = 25;
        public static int 高级鞋子防御加三极品属性的产生率 { get; set; } = 250;
        public static int 高级鞋子防御加四极品属性的产生率 { get; set; } = 450;
        public static int 高级鞋子防御加五极品属性的产生率 { get; set; } = 750;

        
        public static int 高级鞋子魔御极品属性产生概率 { get; set; } = 3;
        public static int 高级鞋子产生魔御极品属性的大小 { get; set; } = 1;
        public static int 高级鞋子魔御加二极品属性的产生率 { get; set; } = 25;
        public static int 高级鞋子魔御加三极品属性的产生率 { get; set; } = 250;
        public static int 高级鞋子魔御加四极品属性的产生率 { get; set; } = 450;
        public static int 高级鞋子魔御加五极品属性的产生率 { get; set; } = 750;

        
        public static int 高级鞋子舒适极品属性产生概率 { get; set; } = 75;
        public static int 高级鞋子产生舒适极品属性的大小 { get; set; } = 1;
        public static int 高级鞋子舒适加二极品属性的产生率 { get; set; } = 450;
        public static int 高级鞋子舒适加三极品属性的产生率 { get; set; } = 750;
        public static int 高级鞋子舒适加四极品属性的产生率 { get; set; } = 1050;
        public static int 高级鞋子舒适加五极品属性的产生率 { get; set; } = 1250;

        
        public static int 高级鞋子强元素极品属性产生概率 { get; set; } = 10;
        public static int 高级鞋子产生强元素属性的大小 { get; set; } = 1;
        public static int 高级鞋子弱元素第二属性的产生率 { get; set; } = 2;
        public static int 高级鞋子强元素第三属性产生概率 { get; set; } = 45;
        public static int 高级鞋子弱元素第四属性的产生率 { get; set; } = 2;
        public static int 高级鞋子强元素第五属性产生概率 { get; set; } = 60;
        public static int 高级鞋子弱元素第六属性产生概率 { get; set; } = 2;
        public static int 高级鞋子弱元素第五属性产生概率 { get; set; } = 60;
        public static int 高级鞋子弱元素第三属性产生概率 { get; set; } = 45;
        public static int 高级鞋子弱元素极品属性产生概率 { get; set; } = 10;


        public static int 稀世产生极品的概率 { get; set; } = 15;
        
        
        public static int 稀世武器攻击极品属性产生概率 { get; set; } = 5;
        public static int 稀世武器产生攻击极品属性的大小 { get; set; } = 1;
        public static int 稀世武器攻击加二极品属性的产生率 { get; set; } = 20;
        public static int 稀世武器攻击加三极品属性的产生率 { get; set; } = 250;
        public static int 稀世武器攻击加四极品属性的产生率 { get; set; } = 450;
        public static int 稀世武器攻击加五极品属性的产生率 { get; set; } = 650;
        
        public static int 稀世武器自然灵魂极品属性产生概率 { get; set; } = 5;
        public static int 稀世武器产生自然灵魂极品属性的大小 { get; set; } = 1;
        public static int 稀世武器自然灵魂加二极品属性的产生率 { get; set; } = 20;
        public static int 稀世武器自然灵魂加三极品属性的产生率 { get; set; } = 250;
        public static int 稀世武器自然灵魂加四极品属性的产生率 { get; set; } = 450;
        public static int 稀世武器自然灵魂加五极品属性的产生率 { get; set; } = 650;

        
        public static int 稀世武器准确极品属性产生概率 { get; set; } = 5;
        public static int 稀世武器产生准确极品属性的大小 { get; set; } = 1;
        public static int 稀世武器准确加二极品属性的产生率 { get; set; } = 20;
        public static int 稀世武器准确加三极品属性的产生率 { get; set; } = 250;
        public static int 稀世武器准确加四极品属性的产生率 { get; set; } = 450;
        public static int 稀世武器准确加五极品属性的产生率 { get; set; } = 650;

        
        public static int 稀世武器攻击元素极品属性产生概率 { get; set; } = 3;
        public static int 稀世武器产生攻击元素极品属性的大小 { get; set; } = 1;
        public static int 稀世武器攻击元素加二极品属性的产生率 { get; set; } = 5;
        public static int 稀世武器攻击元素加三极品属性的产生率 { get; set; } = 25;
        public static int 稀世武器攻击元素加四极品属性的产生率 { get; set; } = 75;
        public static int 稀世武器攻击元素加五极品属性的产生率 { get; set; } = 250;

        
        
        public static int 稀世盾牌攻击几率极品属性产生概率 { get; set; } = 10;
        public static int 稀世盾牌产生攻击几率极品属性的大小 { get; set; } = 1;
        public static int 稀世盾牌攻击几率加二极品属性的产生率 { get; set; } = 50;
        public static int 稀世盾牌攻击几率加三极品属性的产生率 { get; set; } = 250;
        public static int 稀世盾牌攻击几率加四极品属性的产生率 { get; set; } = 450;
        public static int 稀世盾牌攻击几率加五极品属性的产生率 { get; set; } = 650;

        
        public static int 稀世盾牌自然灵魂几率极品属性产生概率 { get; set; } = 10;
        public static int 稀世盾牌产生自然灵魂几率极品属性的大小 { get; set; } = 1;
        public static int 稀世盾牌自然灵魂几率加二极品属性的产生率 { get; set; } = 50;
        public static int 稀世盾牌自然灵魂几率加三极品属性的产生率 { get; set; } = 250;
        public static int 稀世盾牌自然灵魂几率加四极品属性的产生率 { get; set; } = 450;
        public static int 稀世盾牌自然灵魂几率加五极品属性的产生率 { get; set; } = 650;

        
        public static int 稀世盾牌格挡几率极品属性产生概率 { get; set; } = 10;
        public static int 稀世盾牌产生格挡几率极品属性的大小 { get; set; } = 1;
        public static int 稀世盾牌格挡几率加二极品属性的产生率 { get; set; } = 50;
        public static int 稀世盾牌格挡几率加三极品属性的产生率 { get; set; } = 250;
        public static int 稀世盾牌格挡几率加四极品属性的产生率 { get; set; } = 450;
        public static int 稀世盾牌格挡几率加五极品属性的产生率 { get; set; } = 650;

        
        public static int 稀世盾牌闪避几率极品属性产生概率 { get; set; } = 10;
        public static int 稀世盾牌产生闪避几率极品属性的大小 { get; set; } = 1;
        public static int 稀世盾牌闪避几率加二极品属性的产生率 { get; set; } = 50;
        public static int 稀世盾牌闪避几率加三极品属性的产生率 { get; set; } = 250;
        public static int 稀世盾牌闪避几率加四极品属性的产生率 { get; set; } = 450;
        public static int 稀世盾牌闪避几率加五极品属性的产生率 { get; set; } = 650;

        
        public static int 稀世盾牌毒系抵抗几率极品属性产生概率 { get; set; } = 10;
        public static int 稀世盾牌产生毒系抵抗几率极品属性的大小 { get; set; } = 1;
        public static int 稀世盾牌毒系抵抗几率加二极品属性的产生率 { get; set; } = 50;
        public static int 稀世盾牌毒系抵抗几率加三极品属性的产生率 { get; set; } = 250;
        public static int 稀世盾牌毒系抵抗几率加四极品属性的产生率 { get; set; } = 450;
        public static int 稀世盾牌毒系抵抗几率加五极品属性的产生率 { get; set; } = 650;

        
        public static int 稀世盾牌强元素极品属性产生概率 { get; set; } = 10;
        public static int 稀世盾牌产生强元素属性的大小 { get; set; } = 2;
        public static int 稀世盾牌弱元素第二属性的产生率 { get; set; } = 2;
        public static int 稀世盾牌强元素第三属性产生概率 { get; set; } = 45;
        public static int 稀世盾牌弱元素第四属性的产生率 { get; set; } = 2;
        public static int 稀世盾牌强元素第五属性产生概率 { get; set; } = 60;
        public static int 稀世盾牌弱元素第六属性产生概率 { get; set; } = 2;
        public static int 稀世盾牌弱元素第五属性产生概率 { get; set; } = 60;
        public static int 稀世盾牌弱元素第三属性产生概率 { get; set; } = 45;
        public static int 稀世盾牌弱元素极品属性产生概率 { get; set; } = 10;

        
        
        public static int 稀世衣服防御极品属性产生概率 { get; set; } = 2;
        public static int 稀世衣服产生防御极品属性的大小 { get; set; } = 1;
        public static int 稀世衣服防御加二极品属性的产生率 { get; set; } = 15;
        public static int 稀世衣服防御加三极品属性的产生率 { get; set; } = 150;
        public static int 稀世衣服防御加四极品属性的产生率 { get; set; } = 450;
        public static int 稀世衣服防御加五极品属性的产生率 { get; set; } = 750;
        
        public static int 稀世衣服魔御极品属性产生概率 { get; set; } = 2;
        public static int 稀世衣服产生魔御极品属性的大小 { get; set; } = 1;
        public static int 稀世衣服魔御加二极品属性的产生率 { get; set; } = 15;
        public static int 稀世衣服魔御加三极品属性的产生率 { get; set; } = 150;
        public static int 稀世衣服魔御加四极品属性的产生率 { get; set; } = 450;
        public static int 稀世衣服魔御加五极品属性的产生率 { get; set; } = 750;
        
        public static int 稀世衣服强元素极品属性产生概率 { get; set; } = 10;
        public static int 稀世衣服产生强元素属性的大小 { get; set; } = 2;
        public static int 稀世衣服弱元素第二属性的产生率 { get; set; } = 2;
        public static int 稀世衣服强元素第三属性产生概率 { get; set; } = 45;
        public static int 稀世衣服弱元素第四属性的产生率 { get; set; } = 2;
        public static int 稀世衣服强元素第五属性产生概率 { get; set; } = 60;
        public static int 稀世衣服弱元素第六属性产生概率 { get; set; } = 2;
        public static int 稀世衣服弱元素第五属性产生概率 { get; set; } = 60;
        public static int 稀世衣服弱元素第三属性产生概率 { get; set; } = 45;
        public static int 稀世衣服弱元素极品属性产生概率 { get; set; } = 10;

        
        
        public static int 稀世头盔防御极品属性产生概率 { get; set; } = 2;
        public static int 稀世头盔产生防御极品属性的大小 { get; set; } = 1;
        public static int 稀世头盔防御加二极品属性的产生率 { get; set; } = 15;
        public static int 稀世头盔防御加三极品属性的产生率 { get; set; } = 150;
        public static int 稀世头盔防御加四极品属性的产生率 { get; set; } = 450;
        public static int 稀世头盔防御加五极品属性的产生率 { get; set; } = 750;

        
        public static int 稀世头盔魔御极品属性产生概率 { get; set; } = 2;
        public static int 稀世头盔产生魔御极品属性的大小 { get; set; } = 1;
        public static int 稀世头盔魔御加二极品属性的产生率 { get; set; } = 15;
        public static int 稀世头盔魔御加三极品属性的产生率 { get; set; } = 150;
        public static int 稀世头盔魔御加四极品属性的产生率 { get; set; } = 450;
        public static int 稀世头盔魔御加五极品属性的产生率 { get; set; } = 750;

        
        public static int 稀世头盔强元素极品属性产生概率 { get; set; } = 10;
        public static int 稀世头盔产生强元素属性的大小 { get; set; } = 1;
        public static int 稀世头盔弱元素第二属性的产生率 { get; set; } = 2;
        public static int 稀世头盔强元素第三属性产生概率 { get; set; } = 45;
        public static int 稀世头盔弱元素第四属性的产生率 { get; set; } = 2;
        public static int 稀世头盔强元素第五属性产生概率 { get; set; } = 60;
        public static int 稀世头盔弱元素第六属性产生概率 { get; set; } = 2;
        public static int 稀世头盔弱元素第五属性产生概率 { get; set; } = 60;
        public static int 稀世头盔弱元素第三属性产生概率 { get; set; } = 45;
        public static int 稀世头盔弱元素极品属性产生概率 { get; set; } = 10;

        
        public static int 稀世头盔攻击元素极品属性产生概率 { get; set; } = 3;
        public static int 稀世头盔产生攻击元素极品属性的大小 { get; set; } = 1;
        public static int 稀世头盔攻击元素加二极品属性的产生率 { get; set; } = 5;
        public static int 稀世头盔攻击元素加三极品属性的产生率 { get; set; } = 25;
        public static int 稀世头盔攻击元素加四极品属性的产生率 { get; set; } = 75;
        public static int 稀世头盔攻击元素加五极品属性的产生率 { get; set; } = 250;

        
        
        public static int 稀世项链攻击极品属性产生概率 { get; set; } = 5;
        public static int 稀世项链产生攻击极品属性的大小 { get; set; } = 1;
        public static int 稀世项链攻击加二极品属性的产生率 { get; set; } = 25;
        public static int 稀世项链攻击加三极品属性的产生率 { get; set; } = 250;
        public static int 稀世项链攻击加四极品属性的产生率 { get; set; } = 450;
        public static int 稀世项链攻击加五极品属性的产生率 { get; set; } = 650;
        
        public static int 稀世项链自然灵魂极品属性产生概率 { get; set; } = 5;
        public static int 稀世项链产生自然灵魂极品属性的大小 { get; set; } = 1;
        public static int 稀世项链自然灵魂加二极品属性的产生率 { get; set; } = 25;
        public static int 稀世项链自然灵魂加三极品属性的产生率 { get; set; } = 250;
        public static int 稀世项链自然灵魂加四极品属性的产生率 { get; set; } = 450;
        public static int 稀世项链自然灵魂加五极品属性的产生率 { get; set; } = 650;

        
        public static int 稀世项链准确极品属性产生概率 { get; set; } = 5;
        public static int 稀世项链产生准确极品属性的大小 { get; set; } = 1;
        public static int 稀世项链准确加二极品属性的产生率 { get; set; } = 25;
        public static int 稀世项链准确加三极品属性的产生率 { get; set; } = 250;
        public static int 稀世项链准确加四极品属性的产生率 { get; set; } = 450;
        public static int 稀世项链准确加五极品属性的产生率 { get; set; } = 650;

        
        public static int 稀世项链敏捷极品属性产生概率 { get; set; } = 15;
        public static int 稀世项链产生敏捷极品属性的大小 { get; set; } = 1;
        public static int 稀世项链敏捷加二极品属性的产生率 { get; set; } = 75;
        public static int 稀世项链敏捷加三极品属性的产生率 { get; set; } = 450;
        public static int 稀世项链敏捷加四极品属性的产生率 { get; set; } = 650;
        public static int 稀世项链敏捷加五极品属性的产生率 { get; set; } = 1000;

        
        public static int 稀世项链攻击元素极品属性产生概率 { get; set; } = 3;
        public static int 稀世项链产生攻击元素极品属性的大小 { get; set; } = 1;
        public static int 稀世项链攻击元素加二极品属性的产生率 { get; set; } = 5;
        public static int 稀世项链攻击元素加三极品属性的产生率 { get; set; } = 25;
        public static int 稀世项链攻击元素加四极品属性的产生率 { get; set; } = 75;
        public static int 稀世项链攻击元素加五极品属性的产生率 { get; set; } = 250;

        
        
        public static int 稀世手镯防御极品属性产生概率 { get; set; } = 2;
        public static int 稀世手镯产生防御极品属性的大小 { get; set; } = 1;
        public static int 稀世手镯防御加二极品属性的产生率 { get; set; } = 15;
        public static int 稀世手镯防御加三极品属性的产生率 { get; set; } = 150;
        public static int 稀世手镯防御加四极品属性的产生率 { get; set; } = 450;
        public static int 稀世手镯防御加五极品属性的产生率 { get; set; } = 750;

        
        public static int 稀世手镯魔御极品属性产生概率 { get; set; } = 2;
        public static int 稀世手镯产生魔御极品属性的大小 { get; set; } = 1;
        public static int 稀世手镯魔御加二极品属性的产生率 { get; set; } = 15;
        public static int 稀世手镯魔御加三极品属性的产生率 { get; set; } = 150;
        public static int 稀世手镯魔御加四极品属性的产生率 { get; set; } = 450;
        public static int 稀世手镯魔御加五极品属性的产生率 { get; set; } = 750;

        
        public static int 稀世手镯攻击极品属性产生概率 { get; set; } = 5;
        public static int 稀世手镯产生攻击极品属性的大小 { get; set; } = 1;
        public static int 稀世手镯攻击加二极品属性的产生率 { get; set; } = 25;
        public static int 稀世手镯攻击加三极品属性的产生率 { get; set; } = 250;
        public static int 稀世手镯攻击加四极品属性的产生率 { get; set; } = 450;
        public static int 稀世手镯攻击加五极品属性的产生率 { get; set; } = 650;

        
        public static int 稀世手镯自然灵魂极品属性产生概率 { get; set; } = 5;
        public static int 稀世手镯产生自然灵魂极品属性的大小 { get; set; } = 1;
        public static int 稀世手镯自然灵魂加二极品属性的产生率 { get; set; } = 25;
        public static int 稀世手镯自然灵魂加三极品属性的产生率 { get; set; } = 250;
        public static int 稀世手镯自然灵魂加四极品属性的产生率 { get; set; } = 450;
        public static int 稀世手镯自然灵魂加五极品属性的产生率 { get; set; } = 650;

        
        public static int 稀世手镯准确极品属性产生概率 { get; set; } = 5;
        public static int 稀世手镯产生准确极品属性的大小 { get; set; } = 1;
        public static int 稀世手镯准确加二极品属性的产生率 { get; set; } = 25;
        public static int 稀世手镯准确加三极品属性的产生率 { get; set; } = 2500000;
        public static int 稀世手镯准确加四极品属性的产生率 { get; set; } = 4500000;
        public static int 稀世手镯准确加五极品属性的产生率 { get; set; } = 6500000;

        
        public static int 稀世手镯敏捷极品属性产生概率 { get; set; } = 15;
        public static int 稀世手镯产生敏捷极品属性的大小 { get; set; } = 1;
        public static int 稀世手镯敏捷加二极品属性的产生率 { get; set; } = 75;
        public static int 稀世手镯敏捷加三极品属性的产生率 { get; set; } = 4500000;
        public static int 稀世手镯敏捷加四极品属性的产生率 { get; set; } = 6500000;
        public static int 稀世手镯敏捷加五极品属性的产生率 { get; set; } = 1000000;

        
        public static int 稀世手镯强元素极品属性产生概率 { get; set; } = 10;
        public static int 稀世手镯产生强元素属性的大小 { get; set; } = 1;
        public static int 稀世手镯弱元素第二属性的产生率 { get; set; } = 2;
        public static int 稀世手镯强元素第三属性产生概率 { get; set; } = 30;
        public static int 稀世手镯弱元素第四属性的产生率 { get; set; } = 2;
        public static int 稀世手镯强元素第五属性产生概率 { get; set; } = 40;
        public static int 稀世手镯弱元素第六属性产生概率 { get; set; } = 2;
        public static int 稀世手镯弱元素第五属性产生概率 { get; set; } = 40;
        public static int 稀世手镯弱元素第三属性产生概率 { get; set; } = 30;
        public static int 稀世手镯弱元素极品属性产生概率 { get; set; } = 10;

        
        public static int 稀世手镯攻击元素极品属性产生概率 { get; set; } = 3;
        public static int 稀世手镯产生攻击元素极品属性的大小 { get; set; } = 1;
        public static int 稀世手镯攻击元素加二极品属性的产生率 { get; set; } = 5;
        public static int 稀世手镯攻击元素加三极品属性的产生率 { get; set; } = 25;
        public static int 稀世手镯攻击元素加四极品属性的产生率 { get; set; } = 75;
        public static int 稀世手镯攻击元素加五极品属性的产生率 { get; set; } = 250;

        
        public static int 稀世戒指攻击极品属性产生概率 { get; set; } = 5;
        public static int 稀世戒指产生攻击极品属性的大小 { get; set; } = 1;
        public static int 稀世戒指攻击加二极品属性的产生率 { get; set; } = 25;
        public static int 稀世戒指攻击加三极品属性的产生率 { get; set; } = 250;
        public static int 稀世戒指攻击加四极品属性的产生率 { get; set; } = 450;
        public static int 稀世戒指攻击加五极品属性的产生率 { get; set; } = 650;

        
        public static int 稀世戒指自然灵魂极品属性产生概率 { get; set; } = 5;
        public static int 稀世戒指产生自然灵魂极品属性的大小 { get; set; } = 1;
        public static int 稀世戒指自然灵魂加二极品属性的产生率 { get; set; } = 25;
        public static int 稀世戒指自然灵魂加三极品属性的产生率 { get; set; } = 250;
        public static int 稀世戒指自然灵魂加四极品属性的产生率 { get; set; } = 450;
        public static int 稀世戒指自然灵魂加五极品属性的产生率 { get; set; } = 650;

        
        public static int 稀世戒指拾取范围极品属性产生概率 { get; set; } = 20;
        public static int 稀世戒指产生拾取范围极品属性的大小 { get; set; } = 1;
        public static int 稀世戒指拾取范围加二极品属性的产生率 { get; set; } = 75;
        public static int 稀世戒指拾取范围加三极品属性的产生率 { get; set; } = 450;
        public static int 稀世戒指拾取范围加四极品属性的产生率 { get; set; } = 750;
        public static int 稀世戒指拾取范围加五极品属性的产生率 { get; set; } = 1050;

        
        public static int 稀世戒指攻击元素极品属性产生概率 { get; set; } = 3;
        public static int 稀世戒指产生攻击元素极品属性的大小 { get; set; } = 1;
        public static int 稀世戒指攻击元素加二极品属性的产生率 { get; set; } = 5;
        public static int 稀世戒指攻击元素加三极品属性的产生率 { get; set; } = 25;
        public static int 稀世戒指攻击元素加四极品属性的产生率 { get; set; } = 75;
        public static int 稀世戒指攻击元素加五极品属性的产生率 { get; set; } = 250;

        
        
        public static int 稀世鞋子防御极品属性产生概率 { get; set; } = 3;
        public static int 稀世鞋子产生防御极品属性的大小 { get; set; } = 1;
        public static int 稀世鞋子防御加二极品属性的产生率 { get; set; } = 25;
        public static int 稀世鞋子防御加三极品属性的产生率 { get; set; } = 250;
        public static int 稀世鞋子防御加四极品属性的产生率 { get; set; } = 450;
        public static int 稀世鞋子防御加五极品属性的产生率 { get; set; } = 750;

        
        public static int 稀世鞋子魔御极品属性产生概率 { get; set; } = 3;
        public static int 稀世鞋子产生魔御极品属性的大小 { get; set; } = 1;
        public static int 稀世鞋子魔御加二极品属性的产生率 { get; set; } = 25;
        public static int 稀世鞋子魔御加三极品属性的产生率 { get; set; } = 250;
        public static int 稀世鞋子魔御加四极品属性的产生率 { get; set; } = 450;
        public static int 稀世鞋子魔御加五极品属性的产生率 { get; set; } = 750;

        
        public static int 稀世鞋子舒适极品属性产生概率 { get; set; } = 75;
        public static int 稀世鞋子产生舒适极品属性的大小 { get; set; } = 1;
        public static int 稀世鞋子舒适加二极品属性的产生率 { get; set; } = 450;
        public static int 稀世鞋子舒适加三极品属性的产生率 { get; set; } = 750;
        public static int 稀世鞋子舒适加四极品属性的产生率 { get; set; } = 1050;
        public static int 稀世鞋子舒适加五极品属性的产生率 { get; set; } = 1250;

        
        public static int 稀世鞋子强元素极品属性产生概率 { get; set; } = 10;
        public static int 稀世鞋子产生强元素属性的大小 { get; set; } = 1;
        public static int 稀世鞋子弱元素第二属性的产生率 { get; set; } = 2;
        public static int 稀世鞋子强元素第三属性产生概率 { get; set; } = 45;
        public static int 稀世鞋子弱元素第四属性的产生率 { get; set; } = 2;
        public static int 稀世鞋子强元素第五属性产生概率 { get; set; } = 60;
        public static int 稀世鞋子弱元素第六属性产生概率 { get; set; } = 2;
        public static int 稀世鞋子弱元素第五属性产生概率 { get; set; } = 60;
        public static int 稀世鞋子弱元素第三属性产生概率 { get; set; } = 45;
        public static int 稀世鞋子弱元素极品属性产生概率 { get; set; } = 10;


        [ConfigSection("*******【公会等级Buff有关】*******")]
        public static int 公会等级3级时成员们享受的公会Buff中的生命值Buff { get; set; } = 10;
        public static int 公会等级3级时成员们享受的公会Buff中的魔法值Buff { get; set; } = 10;
        public static int 公会等级3级时成员们享受的公会Buff中的Min防御Buff { get; set; } = 1;
        public static int 公会等级3级时成员们享受的公会Buff中的Min魔御Buff { get; set; } = 1;
        public static int 公会等级4级时成员们享受的公会Buff中的生命值Buff { get; set; } = 20;
        public static int 公会等级4级时成员们享受的公会Buff中的魔法值Buff { get; set; } = 20;
        public static int 公会等级4级时成员们享受的公会Buff中的Min防御Buff { get; set; } = 1;
        public static int 公会等级4级时成员们享受的公会Buff中的Max防御Buff { get; set; } = 1;
        public static int 公会等级4级时成员们享受的公会Buff中的Min魔御Buff { get; set; } = 1;
        public static int 公会等级4级时成员们享受的公会Buff中的Max魔御Buff { get; set; } = 1;
        public static int 公会等级5级时成员们享受的公会Buff中的生命值Buff { get; set; } = 30;
        public static int 公会等级5级时成员们享受的公会Buff中的魔法值Buff { get; set; } = 30;
        public static int 公会等级5级时成员们享受的公会Buff中的Min防御Buff { get; set; } = 2;
        public static int 公会等级5级时成员们享受的公会Buff中的Max防御Buff { get; set; } = 2;
        public static int 公会等级5级时成员们享受的公会Buff中的Min魔御Buff { get; set; } = 2;
        public static int 公会等级5级时成员们享受的公会Buff中的Max魔御Buff { get; set; } = 2;
        public static int 公会等级6级时成员们享受的公会Buff中的生命值Buff { get; set; } = 30;
        public static int 公会等级6级时成员们享受的公会Buff中的魔法值Buff { get; set; } = 30;
        public static int 公会等级6级时成员们享受的公会Buff中的Min防御Buff { get; set; } = 2;
        public static int 公会等级6级时成员们享受的公会Buff中的Max防御Buff { get; set; } = 2;
        public static int 公会等级6级时成员们享受的公会Buff中的Min魔御Buff { get; set; } = 2;
        public static int 公会等级6级时成员们享受的公会Buff中的Max魔御Buff { get; set; } = 2;
        public static int 公会等级6级时成员们享受的公会Buff中的经验加成Buff { get; set; } = 3;
        public static int 公会等级7级时成员们享受的公会Buff中的生命值Buff { get; set; } = 50;
        public static int 公会等级7级时成员们享受的公会Buff中的魔法值Buff { get; set; } = 50;
        public static int 公会等级7级时成员们享受的公会Buff中的Min防御Buff { get; set; } = 4;
        public static int 公会等级7级时成员们享受的公会Buff中的Max防御Buff { get; set; } = 4;
        public static int 公会等级7级时成员们享受的公会Buff中的Min魔御Buff { get; set; } = 4;
        public static int 公会等级7级时成员们享受的公会Buff中的Max魔御Buff { get; set; } = 4;
        public static int 公会等级7级时成员们享受的公会Buff中的经验加成Buff { get; set; } = 5;
        public static int 公会等级8级时成员们享受的公会Buff中的生命值Buff { get; set; } = 60;
        public static int 公会等级8级时成员们享受的公会Buff中的魔法值Buff { get; set; } = 60;
        public static int 公会等级8级时成员们享受的公会Buff中的Min防御Buff { get; set; } = 4;
        public static int 公会等级8级时成员们享受的公会Buff中的Max防御Buff { get; set; } = 5;
        public static int 公会等级8级时成员们享受的公会Buff中的Min魔御Buff { get; set; } = 4;
        public static int 公会等级8级时成员们享受的公会Buff中的Max魔御Buff { get; set; } = 5;
        public static int 公会等级8级时成员们享受的公会Buff中的经验加成Buff { get; set; } = 6;
        public static int 公会等级9级时成员们享受的公会Buff中的生命值Buff { get; set; } = 80;
        public static int 公会等级9级时成员们享受的公会Buff中的魔法值Buff { get; set; } = 80;
        public static int 公会等级9级时成员们享受的公会Buff中的Min防御Buff { get; set; } = 5;
        public static int 公会等级9级时成员们享受的公会Buff中的Max防御Buff { get; set; } = 5;
        public static int 公会等级9级时成员们享受的公会Buff中的Min魔御Buff { get; set; } = 5;
        public static int 公会等级9级时成员们享受的公会Buff中的Max魔御Buff { get; set; } = 5;
        public static int 公会等级9级时成员们享受的公会Buff中的经验加成Buff { get; set; } = 6;
        public static int 公会等级10级时成员们享受的公会Buff中的生命值Buff { get; set; } = 100;
        public static int 公会等级10级时成员们享受的公会Buff中的魔法值Buff { get; set; } = 100;
        public static int 公会等级10级时成员们享受的公会Buff中的Min防御Buff { get; set; } = 5;
        public static int 公会等级10级时成员们享受的公会Buff中的Max防御Buff { get; set; } = 6;
        public static int 公会等级10级时成员们享受的公会Buff中的Min魔御Buff { get; set; } = 5;
        public static int 公会等级10级时成员们享受的公会Buff中的Max魔御Buff { get; set; } = 6;
        public static int 公会等级10级时成员们享受的公会Buff中的经验加成Buff { get; set; } = 7;
        public static int 公会等级11级时成员们享受的公会Buff中的生命值Buff { get; set; } = 120;
        public static int 公会等级11级时成员们享受的公会Buff中的魔法值Buff { get; set; } = 120;
        public static int 公会等级11级时成员们享受的公会Buff中的Min防御Buff { get; set; } = 6;
        public static int 公会等级11级时成员们享受的公会Buff中的Max防御Buff { get; set; } = 6;
        public static int 公会等级11级时成员们享受的公会Buff中的Min魔御Buff { get; set; } = 6;
        public static int 公会等级11级时成员们享受的公会Buff中的Max魔御Buff { get; set; } = 6;
        public static int 公会等级11级时成员们享受的公会Buff中的经验加成Buff { get; set; } = 7;
        public static int 公会等级12级时成员们享受的公会Buff中的生命值Buff { get; set; } = 130;
        public static int 公会等级12级时成员们享受的公会Buff中的魔法值Buff { get; set; } = 130;
        public static int 公会等级12级时成员们享受的公会Buff中的Min防御Buff { get; set; } = 6;
        public static int 公会等级12级时成员们享受的公会Buff中的Max防御Buff { get; set; } = 7;
        public static int 公会等级12级时成员们享受的公会Buff中的Min魔御Buff { get; set; } = 6;
        public static int 公会等级12级时成员们享受的公会Buff中的Max魔御Buff { get; set; } = 7;
        public static int 公会等级12级时成员们享受的公会Buff中的经验加成Buff { get; set; } = 8;
        public static int 公会等级13级时成员们享受的公会Buff中的生命值Buff { get; set; } = 140;
        public static int 公会等级13级时成员们享受的公会Buff中的魔法值Buff { get; set; } = 140;
        public static int 公会等级13级时成员们享受的公会Buff中的Min防御Buff { get; set; } = 7;
        public static int 公会等级13级时成员们享受的公会Buff中的Max防御Buff { get; set; } = 7;
        public static int 公会等级13级时成员们享受的公会Buff中的Min魔御Buff { get; set; } = 7;
        public static int 公会等级13级时成员们享受的公会Buff中的Max魔御Buff { get; set; } = 7;
        public static int 公会等级13级时成员们享受的公会Buff中的经验加成Buff { get; set; } = 8;
        public static int 公会等级14级时成员们享受的公会Buff中的生命值Buff { get; set; } = 140;
        public static int 公会等级14级时成员们享受的公会Buff中的魔法值Buff { get; set; } = 140;
        public static int 公会等级14级时成员们享受的公会Buff中的Min防御Buff { get; set; } = 7;
        public static int 公会等级14级时成员们享受的公会Buff中的Max防御Buff { get; set; } = 8;
        public static int 公会等级14级时成员们享受的公会Buff中的Min魔御Buff { get; set; } = 7;
        public static int 公会等级14级时成员们享受的公会Buff中的Max魔御Buff { get; set; } = 8;
        public static int 公会等级14级时成员们享受的公会Buff中的经验加成Buff { get; set; } = 9;
        public static int 公会等级15级时成员们享受的公会Buff中的生命值Buff { get; set; } = 180;
        public static int 公会等级15级时成员们享受的公会Buff中的魔法值Buff { get; set; } = 180;
        public static int 公会等级15级时成员们享受的公会Buff中的Min防御Buff { get; set; } = 10;
        public static int 公会等级15级时成员们享受的公会Buff中的Max防御Buff { get; set; } = 10;
        public static int 公会等级15级时成员们享受的公会Buff中的Min魔御Buff { get; set; } = 10;
        public static int 公会等级15级时成员们享受的公会Buff中的Max魔御Buff { get; set; } = 10;
        public static int 公会等级15级时成员们享受的公会Buff中的经验加成Buff { get; set; } = 10;


        [ConfigSection("*******【回收等级Buff有关】*******")]
        public static int 经验回收等级2级时享受的回收Buff中的生命值Buff { get; set; } = 10;
        public static int 经验回收等级2级时享受的回收Buff中的魔法值Buff { get; set; } = 10;
        public static int 经验回收等级2级时享受的回收Buff中的Max防御Buff { get; set; } = 2;
        public static int 经验回收等级2级时享受的回收Buff中的Max魔御Buff { get; set; } = 2;
        public static int 经验回收等级3级时享受的回收Buff中的生命值Buff { get; set; } = 20;
        public static int 经验回收等级3级时享受的回收Buff中的魔法值Buff { get; set; } = 20;
        public static int 经验回收等级3级时享受的回收Buff中的Max防御Buff { get; set; } = 3;
        public static int 经验回收等级3级时享受的回收Buff中的Max魔御Buff { get; set; } = 3;
        public static int 经验回收等级3级时享受的回收Buff中的Max攻击Buff { get; set; } = 2;
        public static int 经验回收等级3级时享受的回收Buff中的Max自然Buff { get; set; } = 2;
        public static int 经验回收等级3级时享受的回收Buff中的Max灵魂Buff { get; set; } = 2;
        public static int 经验回收等级4级时享受的回收Buff中的生命值Buff { get; set; } = 40;
        public static int 经验回收等级4级时享受的回收Buff中的魔法值Buff { get; set; } = 40;
        public static int 经验回收等级4级时享受的回收Buff中的Max防御Buff { get; set; } = 4;
        public static int 经验回收等级4级时享受的回收Buff中的Max魔御Buff { get; set; } = 4;
        public static int 经验回收等级4级时享受的回收Buff中的Max攻击Buff { get; set; } = 4;
        public static int 经验回收等级4级时享受的回收Buff中的Max自然Buff { get; set; } = 4;
        public static int 经验回收等级4级时享受的回收Buff中的Max灵魂Buff { get; set; } = 4;
        public static int 经验回收等级5级时享受的回收Buff中的生命值Buff { get; set; } = 60;
        public static int 经验回收等级5级时享受的回收Buff中的魔法值Buff { get; set; } = 60;
        public static int 经验回收等级5级时享受的回收Buff中的Max防御Buff { get; set; } = 6;
        public static int 经验回收等级5级时享受的回收Buff中的Max魔御Buff { get; set; } = 6;
        public static int 经验回收等级5级时享受的回收Buff中的Max攻击Buff { get; set; } = 6;
        public static int 经验回收等级5级时享受的回收Buff中的Max自然Buff { get; set; } = 6;
        public static int 经验回收等级5级时享受的回收Buff中的Max灵魂Buff { get; set; } = 6;
        public static int 经验回收等级6级时享受的回收Buff中的生命值Buff { get; set; } = 80;
        public static int 经验回收等级6级时享受的回收Buff中的魔法值Buff { get; set; } = 80;
        public static int 经验回收等级6级时享受的回收Buff中的Max防御Buff { get; set; } = 7;
        public static int 经验回收等级6级时享受的回收Buff中的Max魔御Buff { get; set; } = 7;
        public static int 经验回收等级6级时享受的回收Buff中的Max攻击Buff { get; set; } = 7;
        public static int 经验回收等级6级时享受的回收Buff中的Max自然Buff { get; set; } = 7;
        public static int 经验回收等级6级时享受的回收Buff中的Max灵魂Buff { get; set; } = 7;
        public static int 经验回收等级6级时享受的回收Buff中的怪物暴击伤害Buff { get; set; } = 3;
        public static int 经验回收等级7级时享受的回收Buff中的生命值Buff { get; set; } = 100;
        public static int 经验回收等级7级时享受的回收Buff中的魔法值Buff { get; set; } = 100;
        public static int 经验回收等级7级时享受的回收Buff中的Max防御Buff { get; set; } = 8;
        public static int 经验回收等级7级时享受的回收Buff中的Max魔御Buff { get; set; } = 8;
        public static int 经验回收等级7级时享受的回收Buff中的Max攻击Buff { get; set; } = 8;
        public static int 经验回收等级7级时享受的回收Buff中的Max自然Buff { get; set; } = 8;
        public static int 经验回收等级7级时享受的回收Buff中的Max灵魂Buff { get; set; } = 8;
        public static int 经验回收等级7级时享受的回收Buff中的怪物暴击伤害Buff { get; set; } = 6;
        public static int 经验回收等级7级时享受的回收Buff中的攻击速度Buff { get; set; } = 1;
        public static int 经验回收等级8级时享受的回收Buff中的生命值Buff { get; set; } = 120;
        public static int 经验回收等级8级时享受的回收Buff中的魔法值Buff { get; set; } = 120;
        public static int 经验回收等级8级时享受的回收Buff中的Max防御Buff { get; set; } = 10;
        public static int 经验回收等级8级时享受的回收Buff中的Max魔御Buff { get; set; } = 10;
        public static int 经验回收等级8级时享受的回收Buff中的Max攻击Buff { get; set; } = 10;
        public static int 经验回收等级8级时享受的回收Buff中的Max自然Buff { get; set; } = 10;
        public static int 经验回收等级8级时享受的回收Buff中的Max灵魂Buff { get; set; } = 10;
        public static int 经验回收等级8级时享受的回收Buff中的怪物暴击伤害Buff { get; set; } = 8;
        public static int 经验回收等级8级时享受的回收Buff中的攻击速度Buff { get; set; } = 1;
        public static int 经验回收等级9级时享受的回收Buff中的生命值Buff { get; set; } = 140;
        public static int 经验回收等级9级时享受的回收Buff中的魔法值Buff { get; set; } = 140;
        public static int 经验回收等级9级时享受的回收Buff中的Max防御Buff { get; set; } = 12;
        public static int 经验回收等级9级时享受的回收Buff中的Max魔御Buff { get; set; } = 12;
        public static int 经验回收等级9级时享受的回收Buff中的Max攻击Buff { get; set; } = 12;
        public static int 经验回收等级9级时享受的回收Buff中的Max自然Buff { get; set; } = 12;
        public static int 经验回收等级9级时享受的回收Buff中的Max灵魂Buff { get; set; } = 12;
        public static int 经验回收等级9级时享受的回收Buff中的怪物暴击伤害Buff { get; set; } = 10;
        public static int 经验回收等级9级时享受的回收Buff中的攻击速度Buff { get; set; } = 2;
        public static int 经验回收等级9级时享受的回收Buff中的暴击几率Buff { get; set; } = 1;
        public static int 经验回收等级10级时享受的回收Buff中的生命值Buff { get; set; } = 150;
        public static int 经验回收等级10级时享受的回收Buff中的魔法值Buff { get; set; } = 150;
        public static int 经验回收等级10级时享受的回收Buff中的Max防御Buff { get; set; } = 13;
        public static int 经验回收等级10级时享受的回收Buff中的Max魔御Buff { get; set; } = 13;
        public static int 经验回收等级10级时享受的回收Buff中的Max攻击Buff { get; set; } = 15;
        public static int 经验回收等级10级时享受的回收Buff中的Max自然Buff { get; set; } = 15;
        public static int 经验回收等级10级时享受的回收Buff中的Max灵魂Buff { get; set; } = 15;
        public static int 经验回收等级10级时享受的回收Buff中的怪物暴击伤害Buff { get; set; } = 12;
        public static int 经验回收等级10级时享受的回收Buff中的攻击速度Buff { get; set; } = 2;
        public static int 经验回收等级10级时享受的回收Buff中的暴击几率Buff { get; set; } = 1;
        public static int 经验回收等级10级时享受的回收Buff中的幸运Buff { get; set; } = 1;
        public static int 经验回收等级10级时享受的回收Buff中的精炼成功率Buff { get; set; } = 0;



        [ConfigSection("*******【称号Buff有关】*******")]
        public static int 江湖初出称号享受的Buff中的生命值Buff { get; set; } = 10;
        public static int 江湖初出称号享受的Buff中的魔法值Buff { get; set; } = 10;
        public static int 江湖初出称号享受的Buff中的Max防御Buff { get; set; } = 1;
        public static int 江湖初出称号享受的Buff中的Max魔御Buff { get; set; } = 1;
        public static int 新進高手称号享受的Buff中的生命值Buff { get; set; } = 20;
        public static int 新進高手称号享受的Buff中的魔法值Buff { get; set; } = 20;
        public static int 新進高手称号享受的Buff中的Max防御Buff { get; set; } = 2;
        public static int 新進高手称号享受的Buff中的Max魔御Buff { get; set; } = 2;
        public static int 新進高手称号享受的Buff中的Max攻击Buff { get; set; } = 2;
        public static int 新進高手称号享受的Buff中的Max自然Buff { get; set; } = 2;
        public static int 新進高手称号享受的Buff中的Max灵魂Buff { get; set; } = 2;
        public static int 江湖侠客称号享受的Buff中的生命值Buff { get; set; } = 30;
        public static int 江湖侠客称号享受的Buff中的魔法值Buff { get; set; } = 30;
        public static int 江湖侠客称号享受的Buff中的Max防御Buff { get; set; } = 4;
        public static int 江湖侠客称号享受的Buff中的Max魔御Buff { get; set; } = 4;
        public static int 江湖侠客称号享受的Buff中的Max攻击Buff { get; set; } = 4;
        public static int 江湖侠客称号享受的Buff中的Max自然Buff { get; set; } = 4;
        public static int 江湖侠客称号享受的Buff中的Max灵魂Buff { get; set; } = 4;
        public static int 武林名宿称号享受的Buff中的生命值Buff { get; set; } = 50;
        public static int 武林名宿称号享受的Buff中的魔法值Buff { get; set; } = 50;
        public static int 武林名宿称号享受的Buff中的Max防御Buff { get; set; } = 5;
        public static int 武林名宿称号享受的Buff中的Max魔御Buff { get; set; } = 5;
        public static int 武林名宿称号享受的Buff中的Max攻击Buff { get; set; } = 6;
        public static int 武林名宿称号享受的Buff中的Max自然Buff { get; set; } = 6;
        public static int 武林名宿称号享受的Buff中的Max灵魂Buff { get; set; } = 6;
        public static int 武林名宿称号享受的Buff中的怪物暴击伤害Buff { get; set; } = 5;
        public static int 仁义大侠称号享受的Buff中的生命值Buff { get; set; } = 80;
        public static int 仁义大侠称号享受的Buff中的魔法值Buff { get; set; } = 80;
        public static int 仁义大侠称号享受的Buff中的Max防御Buff { get; set; } = 7;
        public static int 仁义大侠称号享受的Buff中的Max魔御Buff { get; set; } = 7;
        public static int 仁义大侠称号享受的Buff中的Max攻击Buff { get; set; } = 8;
        public static int 仁义大侠称号享受的Buff中的Max自然Buff { get; set; } = 8;
        public static int 仁义大侠称号享受的Buff中的Max灵魂Buff { get; set; } = 8;
        public static int 仁义大侠称号享受的Buff中的怪物暴击伤害Buff { get; set; } = 5;
        public static int 仁义大侠称号享受的Buff中的攻击元素火Buff { get; set; } = 2;
        public static int 仁义大侠称号享受的Buff中的攻击元素雷Buff { get; set; } = 2;
        public static int 仁义大侠称号享受的Buff中的攻击元素冰Buff { get; set; } = 2;
        public static int 仁义大侠称号享受的Buff中的攻击元素风Buff { get; set; } = 2;
        public static int 仁义大侠称号享受的Buff中的攻击元素神圣Buff { get; set; } = 2;
        public static int 仁义大侠称号享受的Buff中的攻击元素暗黑Buff { get; set; } = 2;
        public static int 仁义大侠称号享受的Buff中的攻击元素幻影Buff { get; set; } = 2;
        public static int 英雄豪杰称号享受的Buff中的生命值Buff { get; set; } = 100;
        public static int 英雄豪杰称号享受的Buff中的魔法值Buff { get; set; } = 100;
        public static int 英雄豪杰称号享受的Buff中的Max防御Buff { get; set; } = 8;
        public static int 英雄豪杰称号享受的Buff中的Max魔御Buff { get; set; } = 8;
        public static int 英雄豪杰称号享受的Buff中的Max攻击Buff { get; set; } = 10;
        public static int 英雄豪杰称号享受的Buff中的Max自然Buff { get; set; } = 10;
        public static int 英雄豪杰称号享受的Buff中的Max灵魂Buff { get; set; } = 10;
        public static int 英雄豪杰称号享受的Buff中的怪物暴击伤害Buff { get; set; } = 7;
        public static int 英雄豪杰称号享受的Buff中的攻击元素火Buff { get; set; } = 3;
        public static int 英雄豪杰称号享受的Buff中的攻击元素雷Buff { get; set; } = 3;
        public static int 英雄豪杰称号享受的Buff中的攻击元素冰Buff { get; set; } = 3;
        public static int 英雄豪杰称号享受的Buff中的攻击元素风Buff { get; set; } = 3;
        public static int 英雄豪杰称号享受的Buff中的攻击元素神圣Buff { get; set; } = 3;
        public static int 英雄豪杰称号享受的Buff中的攻击元素暗黑Buff { get; set; } = 3;
        public static int 英雄豪杰称号享受的Buff中的攻击元素幻影Buff { get; set; } = 3;
        public static int 武林至尊称号享受的Buff中的生命值Buff { get; set; } = 150;
        public static int 武林至尊称号享受的Buff中的魔法值Buff { get; set; } = 150;
        public static int 武林至尊称号享受的Buff中的Max防御Buff { get; set; } = 10;
        public static int 武林至尊称号享受的Buff中的Max魔御Buff { get; set; } = 10;
        public static int 武林至尊称号享受的Buff中的Max攻击Buff { get; set; } = 12;
        public static int 武林至尊称号享受的Buff中的Max自然Buff { get; set; } = 12;
        public static int 武林至尊称号享受的Buff中的Max灵魂Buff { get; set; } = 12;
        public static int 武林至尊称号享受的Buff中的怪物暴击伤害Buff { get; set; } = 10;
        public static int 武林至尊称号享受的Buff中的攻击元素火Buff { get; set; } = 5;
        public static int 武林至尊称号享受的Buff中的攻击元素雷Buff { get; set; } = 5;
        public static int 武林至尊称号享受的Buff中的攻击元素冰Buff { get; set; } = 5;
        public static int 武林至尊称号享受的Buff中的攻击元素风Buff { get; set; } = 5;
        public static int 武林至尊称号享受的Buff中的攻击元素神圣Buff { get; set; } = 5;
        public static int 武林至尊称号享受的Buff中的攻击元素暗黑Buff { get; set; } = 5;
        public static int 武林至尊称号享受的Buff中的攻击元素幻影Buff { get; set; } = 5;


        [ConfigSection("*******【玩家转生后触发属性】*******")]
        public static int 每次转生后额外增加的物品爆率百分之加成 { get; set; } = 20;
        public static int 每次转生后额外增加的金币爆率百分之加成 { get; set; } = 20;
        public static int 每次转生后额外增加的怪物暴击伤害百分之加成 { get; set; } = 50;
        public static int 每次转生后额外增加的玩家暴击伤害百分之加成 { get; set; } = 20;


        [ConfigSection("*******【玩家转生后给的种子情况】*******")]
        public static bool 玩家转生时是否种子免费赠送 { get; set; } = false;


        [ConfigSection("*******【马属性】*******")]
        public static int 棕色马增加的背包重量 { get; set; } = 50;

        public static int 白色马增加的舒适 { get; set; } = 2;
        public static int 白色马增加的背包重量 { get; set; } = 100;
        public static int 白色马增加的Max防御 { get; set; } = 5;
        public static int 白色马增加的Max魔御 { get; set; } = 5;
        public static int 白色马增加的Max攻击 { get; set; } = 5;
        public static int 白色马增加的Max自然 { get; set; } = 5;
        public static int 白色马增加的Max灵魂 { get; set; } = 5;

        public static int 红色马增加的舒适 { get; set; } = 5;
        public static int 红色马增加的背包重量 { get; set; } = 150;
        public static int 红色马增加的Max防御 { get; set; } = 12;
        public static int 红色马增加的Max魔御 { get; set; } = 12;
        public static int 红色马增加的Max攻击 { get; set; } = 12;
        public static int 红色马增加的Max自然 { get; set; } = 12;
        public static int 红色马增加的Max灵魂 { get; set; } = 12;

        public static int 黑色马增加的舒适 { get; set; } = 7;
        public static int 黑色马增加的背包重量 { get; set; } = 200;
        public static int 黑色马增加的Max防御 { get; set; } = 25;
        public static int 黑色马增加的Max魔御 { get; set; } = 25;
        public static int 黑色马增加的Max攻击 { get; set; } = 25;
        public static int 黑色马增加的Max自然 { get; set; } = 25;
        public static int 黑色马增加的Max灵魂 { get; set; } = 25;

        public static int 白色独角兽增加的舒适 { get; set; } = 7;
        public static int 白色独角兽增加的背包重量 { get; set; } = 250;
        public static int 白色独角兽增加的Max防御 { get; set; } = 40;
        public static int 白色独角兽增加的Max魔御 { get; set; } = 40;
        public static int 白色独角兽增加的Max攻击 { get; set; } = 40;
        public static int 白色独角兽增加的Max自然 { get; set; } = 40;
        public static int 白色独角兽增加的Max灵魂 { get; set; } = 40;

        public static int 红色独角兽增加的舒适 { get; set; } = 7;
        public static int 红色独角兽增加的背包重量 { get; set; } = 300;
        public static int 红色独角兽增加的Max防御 { get; set; } = 60;
        public static int 红色独角兽增加的Max魔御 { get; set; } = 60;
        public static int 红色独角兽增加的Max攻击 { get; set; } = 60;
        public static int 红色独角兽增加的Max自然 { get; set; } = 60;
        public static int 红色独角兽增加的Max灵魂 { get; set; } = 60;


        [ConfigSection("*******【套装Buff有关】*******")]
        public static int 优良套装Buff中增加的生命值 { get; set; } = 30;
        public static int 优良套装Buff中增加的魔法值 { get; set; } = 30;
        public static int 优良套装Buff中增加的Max攻击 { get; set; } = 5;
        public static int 优良套装Buff中增加的Max自然 { get; set; } = 5;
        public static int 优良套装Buff中增加的Max灵魂 { get; set; } = 5;
        public static int 精致套装Buff中增加的生命值 { get; set; } = 70;
        public static int 精致套装Buff中增加的魔法值 { get; set; } = 70;
        public static int 精致套装Buff中增加的Max防御 { get; set; } = 3;
        public static int 精致套装Buff中增加的Max魔御 { get; set; } = 3;
        public static int 精致套装Buff中增加的Max攻击 { get; set; } = 10;
        public static int 精致套装Buff中增加的Max自然 { get; set; } = 10;
        public static int 精致套装Buff中增加的Max灵魂 { get; set; } = 10;
        public static int 精致套装Buff中增加的攻击速度 { get; set; } = 1;
        public static int 传说套装Buff中增加的生命值 { get; set; } = 100;
        public static int 传说套装Buff中增加的魔法值 { get; set; } = 100;
        public static int 传说套装Buff中增加的Max防御 { get; set; } = 5;
        public static int 传说套装Buff中增加的Max魔御 { get; set; } = 5;
        public static int 传说套装Buff中增加的Max攻击 { get; set; } = 12;
        public static int 传说套装Buff中增加的Max自然 { get; set; } = 12;
        public static int 传说套装Buff中增加的Max灵魂 { get; set; } = 12;
        public static int 传说套装Buff中增加的攻击速度 { get; set; } = 2;
        public static int 神话套装Buff中增加的生命值 { get; set; } = 150;
        public static int 神话套装Buff中增加的魔法值 { get; set; } = 150;
        public static int 神话套装Buff中增加的Max防御 { get; set; } = 10;
        public static int 神话套装Buff中增加的Max魔御 { get; set; } = 10;
        public static int 神话套装Buff中增加的Max攻击 { get; set; } = 15;
        public static int 神话套装Buff中增加的Max自然 { get; set; } = 15;
        public static int 神话套装Buff中增加的Max灵魂 { get; set; } = 15;
        public static int 神话套装Buff中增加的攻击速度 { get; set; } = 3;
        public static int 神话套装Buff中增加的吸血 { get; set; } = 2;
        public static int 神话套装Buff中增加的舒适 { get; set; } = 1;
        public static bool 神话套装Buff中战士刺客职业是否开启麻痹戒指属性 { get; set; } = false;
        public static bool 神话套装Buff中战士刺客职业是否开启神力戒指属性 { get; set; } = false;
        public static bool 神话套装Buff中法师职业是否开启护身戒指属性 { get; set; } = false;
        public static bool 神话套装Buff中法师职业是否开启复活戒指属性 { get; set; } = false;
        public static bool 神话套装Buff中道士职业是否开启复活戒指属性 { get; set; } = false;



        [ConfigSection("*******【吸血效果】******")]
        public static bool 战士和刺客吸血效果是否开启微变模式 { get; set; } = false;
        public static int 复古吸血时每秒最大回复的血量值 { get; set; } = 10;

        [ConfigSection("*******【CDkey】******")]
        
        public static string CDkey01礼包名称 { get; set; } = "青铜CDkey";
        public static bool CDkey01给的第一物品 { get; set; } = false;
        public static int CDkey01金币 { get; set; } = 1000000;
        public static bool CDkey01给的第二物品 { get; set; } = false;
        public static int CDkey01声望点 { get; set; } = 100;
        public static bool CDkey01给的第三物品 { get; set; } = false;
        public static int CDkey01赏金 { get; set; } = 5000;
        public static bool CDkey01给的第四物品 { get; set; } = false;
        public static int CDkey01元宝 { get; set; } = 500;
        public static bool CDkey01给的第五物品 { get; set; } = false;
        public static string CDkey01物品名称01 { get; set; } = "牛角戒指";
        public static int CDkey01物品01多少个 { get; set; } = 1;
        public static bool CDkey01给的第六物品 { get; set; } = false;
        public static string CDkey01物品名称02 { get; set; } = "钢手镯";
        public static int CDkey01物品02多少个 { get; set; } = 1;
        public static bool CDkey01给的第七物品 { get; set; } = false;
        public static string CDkey01物品名称03 { get; set; } = "皮制手套";
        public static int CDkey01物品03多少个 { get; set; } = 1;
        public static bool CDkey01给的第八物品 { get; set; } = false;
        public static string CDkey01物品名称04 { get; set; } = "金项链";
        public static int CDkey01物品04多少个 { get; set; } = 1;
        public static bool CDkey01给的第九物品 { get; set; } = false;
        public static string CDkey01物品名称05 { get; set; } = "六绝星环";
        public static int CDkey01物品05多少个 { get; set; } = 1;
        public static bool CDkey01给的第十物品 { get; set; } = false;
        public static string CDkey01物品名称06 { get; set; } = "乌木剑";
        public static int CDkey01物品06多少个 { get; set; } = 1;


        
        public static string CDkey02礼包名称 { get; set; } = "白银CDkey";
        public static bool CDkey02给的第一物品 { get; set; } = false;
        public static int CDkey02金币 { get; set; } = 1000000;
        public static bool CDkey02给的第二物品 { get; set; } = false;
        public static int CDkey02声望点 { get; set; } = 100;
        public static bool CDkey02给的第三物品 { get; set; } = false;
        public static int CDkey02赏金 { get; set; } = 5000;
        public static bool CDkey02给的第四物品 { get; set; } = false;
        public static int CDkey02元宝 { get; set; } = 500;
        public static bool CDkey02给的第五物品 { get; set; } = false;
        public static string CDkey02物品名称01 { get; set; } = "牛角戒指";
        public static int CDkey02物品01多少个 { get; set; } = 1;
        public static bool CDkey02给的第六物品 { get; set; } = false;
        public static string CDkey02物品名称02 { get; set; } = "钢手镯";
        public static int CDkey02物品02多少个 { get; set; } = 1;
        public static bool CDkey02给的第七物品 { get; set; } = false;
        public static string CDkey02物品名称03 { get; set; } = "皮制手套";
        public static int CDkey02物品03多少个 { get; set; } = 1;
        public static bool CDkey02给的第八物品 { get; set; } = false;
        public static string CDkey02物品名称04 { get; set; } = "金项链";
        public static int CDkey02物品04多少个 { get; set; } = 1;
        public static bool CDkey02给的第九物品 { get; set; } = false;
        public static string CDkey02物品名称05 { get; set; } = "六绝星环";
        public static int CDkey02物品05多少个 { get; set; } = 1;
        public static bool CDkey02给的第十物品 { get; set; } = false;
        public static string CDkey02物品名称06 { get; set; } = "乌木剑";
        public static int CDkey02物品06多少个 { get; set; } = 1;


        
        public static string CDkey03礼包名称 { get; set; } = "黄金CDkey";
        public static bool CDkey03给的第一物品 { get; set; } = false;
        public static int CDkey03金币 { get; set; } = 1000000;
        public static bool CDkey03给的第二物品 { get; set; } = false;
        public static int CDkey03声望点 { get; set; } = 100;
        public static bool CDkey03给的第三物品 { get; set; } = false;
        public static int CDkey03赏金 { get; set; } = 5000;
        public static bool CDkey03给的第四物品 { get; set; } = false;
        public static int CDkey03元宝 { get; set; } = 500;
        public static bool CDkey03给的第五物品 { get; set; } = false;
        public static string CDkey03物品名称01 { get; set; } = "牛角戒指";
        public static int CDkey03物品01多少个 { get; set; } = 1;
        public static bool CDkey03给的第六物品 { get; set; } = false;
        public static string CDkey03物品名称02 { get; set; } = "钢手镯";
        public static int CDkey03物品02多少个 { get; set; } = 1;
        public static bool CDkey03给的第七物品 { get; set; } = false;
        public static string CDkey03物品名称03 { get; set; } = "皮制手套";
        public static int CDkey03物品03多少个 { get; set; } = 1;
        public static bool CDkey03给的第八物品 { get; set; } = false;
        public static string CDkey03物品名称04 { get; set; } = "金项链";
        public static int CDkey03物品04多少个 { get; set; } = 1;
        public static bool CDkey03给的第九物品 { get; set; } = false;
        public static string CDkey03物品名称05 { get; set; } = "六绝星环";
        public static int CDkey03物品05多少个 { get; set; } = 1;
        public static bool CDkey03给的第十物品 { get; set; } = false;
        public static string CDkey03物品名称06 { get; set; } = "乌木剑";
        public static int CDkey03物品06多少个 { get; set; } = 1;


        [ConfigSection("*******【宠物有关】******")]
        public static int 宠物所有技能满值时额外增加攻击几率 { get; set; } = 1;
        public static int 宠物所有技能满值时额外增加自然几率 { get; set; } = 1;
        public static int 宠物所有技能满值时额外增加灵魂几率 { get; set; } = 1;



        [ConfigSection("*******【宝宝升级有关】******")]
        public static bool 是否开启宝宝升级功能 { get; set; } = false;
        public static int 宝宝最高等级 { get; set; } = 7;
        public static bool 按照杀死的怪物经验来升级 { get; set; } = true;
        public static int 宝宝每级别升级经验 { get; set; } = 2000000;
        public static bool 按照杀死的怪物数量来升级 { get; set; } = false;
        public static int 宝宝每级别升级数量 { get; set; } = 40;
        public static float 宝宝1级加血 { get; set; } = 0.2F;
        public static float 宝宝2级加血 { get; set; } = 0.4F;
        public static float 宝宝3级加血 { get; set; } = 0.6F;
        public static float 宝宝4级加血 { get; set; } = 1F;
        public static float 宝宝5级加血 { get; set; } = 1.4F;
        public static float 宝宝6级加血 { get; set; } = 1.8F;
        public static float 宝宝7级加血 { get; set; } = 2.8F;
        public static int 宝宝每级别增加的最低防御 { get; set; } = 4;
        public static int 宝宝每级别增加的最高防御 { get; set; } = 5;
        public static int 宝宝每级别增加的最低魔御 { get; set; } = 4;
        public static int 宝宝每级别增加的最高魔御 { get; set; } = 5;
        public static int 宝宝每级别增加的最低攻击 { get; set; } = 2;
        public static int 宝宝每级别增加的最高攻击 { get; set; } = 2;
        public static int 宝宝每级别增加的最低自然 { get; set; } = 2;
        public static int 宝宝每级别增加的最高自然 { get; set; } = 2;
        public static int 宝宝每级别增加的最低灵魂 { get; set; } = 2;
        public static int 宝宝每级别增加的最高灵魂 { get; set; } = 2;
        public static int 宝宝每级别增加的准确 { get; set; } = 5;
        public static int 宝宝每级别增加的敏捷 { get; set; } = 5;
        public static int 宝宝每级别增加的移动速度 { get; set; } = 10;
        public static int 宝宝每级别增加的攻击速度 { get; set; } = 80;
        public static int 焰魔宝宝每级别增加的攻击速度 { get; set; } = 80;
        public static Color 宝宝1级名字颜色 { get; set; } = Color.Aqua;
        public static Color 宝宝2级名字颜色 { get; set; } = Color.Aquamarine;
        public static Color 宝宝3级名字颜色 { get; set; } = Color.LightSeaGreen;
        public static Color 宝宝4级名字颜色 { get; set; } = Color.SlateBlue;
        public static Color 宝宝5级名字颜色 { get; set; } = Color.SteelBlue;
        public static Color 宝宝6级名字颜色 { get; set; } = Color.Blue;
        public static Color 宝宝7级名字颜色 { get; set; } = Color.Fuchsia;


        [ConfigSection("*******【武器精炼】******")]

        public static int 精炼石合成时金币购买最高成功率 { get; set; } = 30;
        
        public static int 精炼石合成时每百分之一成功率需要的金币 { get; set; } = 333333;
        
        public static int 精炼石合成时铁矿提取的最高成功率 { get; set; } = 23;
        public static int 精炼石合成时每百分之一成功率需要的铁矿吨度{ get; set; } = 4350;
        
        public static int 精炼石合成时银矿提取的最高成功率 { get; set; } = 23;
        public static int 精炼石合成时每百分之一成功率需要的银矿吨度 { get; set; } = 3475;
        
        public static int 精炼石合成时金刚石提取的最高成功率 { get; set; } = 23;
        public static int 精炼石合成时每百分之一成功率需要的金刚石吨度 { get; set; } = 2600;
        
        public static int 精炼石合成时金矿提取的最高成功率 { get; set; } = 31;
        public static int 精炼石合成时每百分之一成功率需要的金矿吨度 { get; set; } = 1600;



        [ConfigSection("*******【技能有关】******")]
        
        public static int 强化灭魂火符技能对玩家增加的伤害 { get; set; } = 20;
        public static int 强化灭魂火符技能对怪物增加的伤害 { get; set; } = 40;
        public static int 强化灭魂火符技能对Boss增加的伤害 { get; set; } = 60;

        [ConfigSection("*******【其他】******")]
        public static bool 是否开启黑龙地图设置导入功能 { get; set; } = false;



        public static void LoadVersion()
        {
            try
            {
                if (File.Exists(VersionPath))
                    using (FileStream stream = File.OpenRead(VersionPath))
                    using (MD5 md5 = MD5.Create())
                        ClientHash = md5.ComputeHash(stream);
                else ClientHash = null;
            }
            catch (Exception ex)
            {
                SEnvir.Log(ex.ToString());
            }
        }
    }
}
