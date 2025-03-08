using Library;

namespace Server.Envir.Translations
{
    [ConfigPath(@".\Translations\ChineseMessages.ini")]
    public class ChineseMessages : StringMessages
    {
        public override string BannedWrongPassword { get; set; } = "错误密码登录尝试次数太多";


        public override string PaymentComplete { get; set; } = "你成功购买 {0} 元宝";
        public override string PaymentFailed { get; set; } = "你被扣除 {0} 元宝";
        public override string ReferralPaymentComplete { get; set; } = "你推荐的一个用户购买了元宝，你因此获得 {0} 赏金奖励";
        public override string ReferralPaymentFailed { get; set; } = "你推荐的用户购买元宝失败，你被扣除之前得到的 {0} 赏金奖励";
        public override string GameGoldLost { get; set; } = "你被移除 {0} 元宝";
        public override string GameGoldRefund { get; set; } = "你获得 {0} 元宝返还";
        public override string HuntGoldRefund { get; set; } = "你获得 {0} 赏金返还";
        public override string Zengjiaswd { get; set; } = "你获得 {0} 点声望";
        public override string kouchuswd { get; set; } = "你被移除 {0} 点声望";
        public override string Zengjiazanzhujilu { get; set; } = "你获得了 {0} 元的赞助记录，你目前总共有 {1} 点赞助记录";
        public override string Jianshaozanzhujilu { get; set; } = "你被移除 {0} 元的赞助记录，你目前总共有 {1} 点赞助记录";
        public override string Chakanzanzhujilu { get; set; } = "玩家 {0} 目前有 {1} 元的赞助记录";
        public override string zanzhujilu { get; set; } = "您目前有 {0} 元的赞助记录";



        public override string Welcome { get; set; } = "欢迎来到欢乐世界传奇3，购买元宝联系QQ:37086243，技术QQ：15114424，玩家群：124385013【版本号：21.07.20】这次服务器启动时间【 {0} 】";
        public override string WelcomeObserver { get; set; } = "你正在使用观察者模式观看 {0} 的视角，想要退出观察者模式请退出登录";
        public override string ObserverChangeFail { get; set; } = "你只能在安全区设置自己是否允许他人观看你的视角";
        public override string OnlineCount { get; set; } = "当前在线人数: {0} ，观察者在线人数: {1}";
        public override string ObserverCount { get; set; } = "现在有 {0} 个观察者正在观看你的视角";
        public override string CannotFindPlayer { get; set; } = "无法找到角色: {0} ";
        public override string AlreadyBlocked { get; set; } = " {0} 已经在你的黑名单上";
        public override string BlockingWhisper { get; set; } = "你当前拒绝他人跟你私聊";
        public override string PlayerBlockingWhisper { get; set; } = "玩家: {0} 当前拒绝私聊";
        public override string GlobalDelay { get; set; } = "你需要在 {0} 秒之后才能下一次全服喊话";
        public override string GlobalLevel { get; set; } = "你需要达到33级才能全服喊话";
        public override string ShoutDelay { get; set; } = "你需要在 {0} 秒之后才能下一次喊话";
        public override string ShoutLevel { get; set; } = "你需要达到2级才能喊话";
        public override string DiceRoll { get; set; } = "[ROLL] - {0} 掷骰子在 {1} 点里掷出 {2} 点";
        public override string TradingEnabled { get; set; } = "允许交易";
        public override string TradingDisabled { get; set; } = "拒绝交易";
        public override string WhisperEnabled { get; set; } = "允许私聊";
        public override string WhisperDisabled { get; set; } = "拒绝私聊";
        public override string GuildInviteEnabled { get; set; } = "允许加入公会";
        public override string GuildInviteDisabled { get; set; } = "拒绝加入公会";
        public override string ObserverNotLoggedIn { get; set; } = "你需要登录账户才能在观察者模式下聊天";
        public override string Poisoned { get; set; } = "你中毒了";
        public override string MurderedBy { get; set; } = "你被 {0} 杀死了";
        public override string Curse { get; set; } = "你杀死了 {0} ，厄运将伴随你..";
        public override string Murdered { get; set; } = "你杀死了 {0}";
        public override string Protected { get; set; } = "你受到正当防卫规则的保护";
        public override string Killed { get; set; } = "你被 {0} 正当防卫击杀";
        public override string Died { get; set; } = "你在战斗中阵亡了";
        public override string GroupRecallEnabled { get; set; } = "允许天地合一";
        public override string GroupRecallDisabled { get; set; } = "拒绝天地合一";
        public override string Xinjuesetishi { get; set; } = "新玩家 【{0}】 加入了欢乐世界传奇3";
        public override string Wanjiashangxiantishi { get; set; } = "玩家 【{0}】 登陆游戏";
        public override string Wanjiaxiaxiantishi { get; set; } = "玩家 【{0}】 离开游戏";
        public override string ClassChangeSafeZone { get; set; } = "你在非安全区域无法使用";

        public override string NeedLevel { get; set; } = "你需要达到 {0} 等级才能进入";
        public override string NeedMaxLevel { get; set; } = "你需要达到 {0} 或更低级别才能继续";
        public override string NeedItem { get; set; } = "你需要 '{0}' '{1}'个才能进入";
        public override string NeedMonster { get; set; } = "入口被封印了..";
        public override string GiveItem { get; set; } = "给你一个： '{0}' 请你查收";
        public override string MonsterSpawn { get; set; } = "小心点，{0} 已出现在地图的某个地方";
        public override string CurrentMapBoos { get; set; } = "地图内还有 {0} 个Boss，杀完才能进入";
        public override string CurrentMapMon { get; set; } = "地图内还有 {0} 个怪物，杀完才能进入";
        public override string UserTeleportNeedItem { get; set; } = "你需要 '{0}' 才能传送";
        public override string MovementGroupOK { get; set; } = "进去失败，你要去的地图时组队才能进去的地图";
        public override string MovementGroup { get; set; } = "进去失败，你不是组队队长，首先队长 {0} 进去开门";
        public override string MovementGroupDuizhanghuiqu { get; set; } = "进去失败，你的组队队长 {0} 不在副本地图里，把他退出队伍后再继续副本";
        public override string GroupNearby { get; set; } = "你和其他组队成员离得太远了，等他们跟上你";
        public override string MovementGeren { get; set; } = "进去失败，你要去的地图时单人才能进去的地图，请退出组队后再进去";
        public override string Shijianbufu { get; set; } = "你要去的 {0} 地图 {1} 开启";


        public override string ConquestStarted { get; set; } = " {0} 攻城战开始了";
        public override string ConquestFinished { get; set; } = " {0} 攻城战结束了";
        public override string ConquestCapture { get; set; } = " {0} 占领了 {1}";
        public override string ConquestOwner { get; set; } = " {0} 是 {1} 的占领者";
        public override string ConquestLost { get; set; } = " {0} 失去了 {1}";


        public override string BossSpawn { get; set; } = "领主刷新在 {0}";
        public override string HarvestRare { get; set; } = "有价值的珍稀物品需要在 {0} 的尸体里挖取";
        public override string NetherGateOpen { get; set; } = "通往神舰的异界之门开启，地图：{0}，坐标：{1}";
        public override string NetherGateClosed { get; set; } = "通往神舰的异界之门关闭";
        public override string HarvestNothing { get; set; } = "没有获得任何物品";
        public override string HarvestCarry { get; set; } = "你背包已满，无法再装载任何物品";
        public override string HarvestOwner { get; set; } = "你无法挖取当前怪物尸体";
        public override string LairGateOpen { get; set; } = "通往赤龙城的赤龙石门开启，地图：{0}，坐标：{1}";
        public override string LairGateClosed { get; set; } = "通往赤龙城的赤龙石门关闭";
        public override string YaotaOpen { get; set; } = "通往比奇地下城的小石门开启，地图：{0}，坐标：{1}";
        public override string YaotaClosed { get; set; } = "通往比奇地下城的小石门关闭";
        public override string MotaOpen { get; set; } = "通往魔虫洞的魔法石门开启，地图：{0}，坐标：{1}";
        public override string MotaClosed { get; set; } = "通往魔虫洞的魔法石门关闭";
        public override string Huodong01Open { get; set; } = "";
        public override string Huodong01Closed { get; set; } = "通往尸王殿的石门关闭";
        public override string Huodong02Open { get; set; } = "";
        public override string Huodong02Closed { get; set; } = "通往宝藏殿的石门关闭";
        public override string Huodong03Open { get; set; } = "通往活动03副本石门开启，地图：{0}，坐标：{1}";
        public override string Huodong03Closed { get; set; } = "通往活动03副本石门关闭";
        public override string Huodong04Open { get; set; } = "通往活动04副本石门开启，地图：{0}，坐标：{1}";
        public override string Huodong04Closed { get; set; } = "通往活动04副本石门关闭";
        public override string Huodong05Open { get; set; } = "通往活动05副本石门开启，地图：{0}，坐标：{1}";
        public override string Huodong05Closed { get; set; } = "通往活动05副本石门关闭";
        public override string Huodong06Open { get; set; } = "通往活动06副本石门开启，地图：{0}，坐标：{1}";
        public override string Huodong06Closed { get; set; } = "通往活动06副本石门关闭";
        public override string Huodong07Open { get; set; } = "通往活动07副本石门开启，地图：{0}，坐标：{1}";
        public override string Huodong07Closed { get; set; } = "通往活动07副本石门关闭";
        public override string Huodong08Open { get; set; } = "通往活动08副本石门开启，地图：{0}，坐标：{1}";
        public override string Huodong08Closed { get; set; } = "通往活动08副本石门关闭";
        public override string Huodong09Open { get; set; } = "通往活动09副本石门开启，地图：{0}，坐标：{1}";
        public override string Huodong09Closed { get; set; } = "通往活动09副本石门关闭";
        public override string Huodong10Open { get; set; } = "通往活动10副本石门开启，地图：{0}，坐标：{1}";
        public override string Huodong10Closed { get; set; } = "通往活动10副本石门关闭";
        public override string Huodong11Open { get; set; } = "";
        public override string Huodong11Closed { get; set; } = "";
        public override string Huodong12Open { get; set; } = "";
        public override string Huodong12Closed { get; set; } = "";


        public override string Expired { get; set; } = "你的 {0} 失效了";
        public override string CannotTownTeleport { get; set; } = "无法传送到该地图";
        public override string CannotRandomTeleport { get; set; } = "当前地图无法使用随机传送卷";
        public override string ConnotResetCompanionSkill { get; set; } = "为了避免误操作，要使用 {0} 请输入 '@宠物技能{1}' ";
        public override string LearnBookFailed { get; set; } = "技能书成功率太低,修炼技能失败了";
        public override string LearnBookSuccess { get; set; } = "恭喜你，你已经成功地学会了 {0}";
        public override string LearnBook4Failed { get; set; } = "学习 {0} 等级技能失败";
        public override string LearnBook4Success { get; set; } = "恭喜你，你已经学好了 {1} {0}";
        public override string StorageSafeZone { get; set; } = "你在非安全区无法使用仓库";
        public override string GuildStoragePermission { get; set; } = "你没有从公会仓库取出物品的权限";
        public override string GuildStorageSafeZone { get; set; } = "你在非安全区无法使用公会仓库";
        public override string CompanionNoRoom { get; set; } = "你的宠物已经无法携带更多物品";
        public override string StorageLimit { get; set; } = "你不能再扩展存储空间了";
        public override string CannotTownAlive { get; set; } = "当前地图无法使用回生丸";
        public override string CannotTownPotion { get; set; } = "当前地图无法使用药水";
        public override string CannotTownHP { get; set; } = "当前地图无法使用体力药水";
        public override string CannotTownMP { get; set; } = "当前地图无法使用魔法药水";
        public override string PatchGridLimit { get; set; } = "你不能再扩展碎片包裹了";
        public override string BaoshiGridLimit { get; set; } = "你不能再扩展宝石包裹了";
        public override string NotCanStorage { get; set; } = "{0}是不能放仓库、公会仓库和宠物包裹的物品。";
        public override string NotCastleOwner { get; set; } = "你没有所属于的公会城堡所以不能使用。";
        public override string CannotCastleTeleport { get; set; } = "无法在此地图上使用城堡传送。";
        public override string CannotTownJiedu { get; set; } = "当前地图无法使用紧急解毒药";
        public override string SuipianHecheng { get; set; } = "无法合成，你目前包裹空位数量没有 {0} 个";


        public override string MarryAlreadyMarried { get; set; } = "你已经结婚了";
        public override string MarryNeedLevel { get; set; } = "你需要达到22级才能结婚";
        public override string MarryNeedGold { get; set; } = "你没有足够的 500,000 金币支付结婚费用";
        public override string MarryNotFacing { get; set; } = "你需要面对你的伴侣才能求婚";
        public override string MarryTargetAlreadyMarried { get; set; } = " {0} 已经结婚了";
        public override string MarryTargetHasProposal { get; set; } = "已经有人向 {0} 求婚了";
        public override string MarryTargetNeedLevel { get; set; } = " {0} 需要达到22级才能结婚";
        public override string MarryTargetNeedGold { get; set; } = " {0} 没有足够的金币无法和你结婚";
        public override string MarryDead { get; set; } = "你不能和死人结婚";
        public override string MarryComplete { get; set; } = "恭喜你，你现在和 {0} 结婚了";
        public override string MarryDivorce { get; set; } = "你和 {0} 离婚了";
        public override string MarryDivorced { get; set; } = " {0} 和你离婚了";
        public override string MarryTeleportDead { get; set; } = "你处于死亡状态，无法传送到你的配偶身边";
        public override string MarryTeleportPK { get; set; } = "你处于红名状态，无法传送到你的配偶身边";
        public override string MarryTeleportDelay { get; set; } = "你需要等待 {0} 才能传送到你的配偶身边";
        public override string MarryTeleportOffline { get; set; } = "你的配偶处于离线状态，无法传送到你的配偶身边";
        public override string MarryTeleportPartnerDead { get; set; } = "你的配偶处于死亡状态，无法传送到你的配偶身边";
        public override string MarryTeleportMap { get; set; } = "你配偶所在的区域拒绝夫妻传送，无法传送到你的配偶身边";
        public override string MarryTeleportMapEscape { get; set; } = "你所在的区域拒绝夫妻传送";
        public override string MoveTeleportDead { get; set; } = "你处于死亡状态，无法传送";
        public override string MoveTeleportPK { get; set; } = "你处于红名状态，无法传送";
        public override string MoveTeleportDelay { get; set; } = "你需要等待 {0} 才能传送";


        public override string CompanionAppearanceAlready { get; set; } = "新的宠物 {0} 已经可以领养";
        public override string CompanionNeedTicket { get; set; } = "你需要在商城购买一张宠物解锁券来解锁这只新宠物";
        public override string CompanionSkillEnabled { get; set; } = "宠物可以使用 {0} 级的技能";
        public override string CompanionSkillDisabled { get; set; } = "宠物不能使用 {0} 级的技能";
        public override string CompanionAppearanceLocked { get; set; } = "新宠物 {0} 目前尚未解锁，你无法购买";
        public override string CompanionNeedGold { get; set; } = "当前金币不足无法购买宠物";
        public override string CompanionBadName { get; set; } = "该名称不符合宠物命名的规则";
        public override string CompanionRetrieveFailed { get; set; } = "无法获得 {0} 宠物，该宠物当前跟随着 {1}";
        public override string QuestSelectReward { get; set; } = "你必须选择奖励";
        public override string QuestNeedSpace { get; set; } = "无法完成任务，你的背包空间不足";


        public override string MailSafeZone { get; set; } = "无法从邮件中获得物品，你不在安全区";
        public override string MailNeedSpace { get; set; } = "无法从邮件中获得物品，背包空间不足";
        public override string MailHasItems { get; set; } = "无法删除包含附件物品的邮件";
        public override string MailNotFound { get; set; } = " {0} 不存在";
        public override string MailSelfMail { get; set; } = "你不能给自己发邮件";
        public override string MailMailCost { get; set; } = "金币不足无法发送邮件";
        public override string MailSendSafeZone { get; set; } = "你不在安全区无法发送带有附件物品的邮件";
        public override string MailMailMaxCost { get; set; } = "发送的金币数量太多无法发送邮件";


        public override string ConsignSafeZone { get; set; } = "你必须在安全区内才可以寄售物品";
        public override string ConsignLimit { get; set; } = "你已达到最大寄售数量";
        public override string ConsignGuildFundsGuild { get; set; } = "你还没有加入公会，无法使用公会基金购买寄售物品";
        public override string ConsignGuildFundsPermission { get; set; } = "你没有足够的权限，无法使用公会基金购买寄售物品";
        public override string ConsignGuildFundsCost { get; set; } = "公会基金不足，无法使用公会基金购买寄售物品";
        public override string ConsignGuildFundsUsed { get; set; } = " {0} 使用 {1:#,##0} 公会基金以每个 {4} 寄售 {2} x{3} ";
        public override string ConsignCost { get; set; } = "你的金币不足";
        public override string ConsignComplete { get; set; } = "商品寄售成功";
        public override string ConsignAlreadySold { get; set; } = "此商品已售出";
        public override string ConsignNotEnough { get; set; } = "没有商品在寄售";
        public override string ConsignBuyOwnItem { get; set; } = "你无法购买自己寄售的商品";
        public override string ConsignBuyGuildFundsGuild { get; set; } = "你还没有加入公会，无法使用公会基金购买物品";
        public override string ConsignBuyGuildFundsPermission { get; set; } = "你没有足够的权限，无法使用公会基金购买物品";
        public override string ConsignBuyGuildFundsCost { get; set; } = "公会基金不足，无法使用公会基金购买物品";
        public override string ConsignBuyGuildFundsUsed { get; set; } = " {0} 使用 {1:#,##0} 公会基金购买了 {2} x{3}";
        public override string ConsignBuyCost { get; set; } = "你买不起这商品";


        public override string StoreNotAvailable { get; set; } = "你无法购买此商品，该商品已经下架或者售出";
        public override string StoreNeedSpace { get; set; } = "你不能携带更多商品，你的包裹空间不足";
        public override string StoreCost { get; set; } = "你买不起这商品";
        public override string MarketPlaceBuyMaxGold { get; set; } = "你当前金币数量超出了最大金额范围";


        public override string GuildNeedHorn { get; set; } = "创建公会失败，你没有沃玛号角";
        public override string GuildNeedGold { get; set; } = "创建公会失败，你没有足够的金币";
        public override string GuildBadName { get; set; } = "创建公会失败，公会名称不符合命名规则";
        public override string GuildNameTaken { get; set; } = "创建公会失败，该公会名称已经被使用";
        public override string GuildNoticePermission { get; set; } = "你没有更改公会公告的权限";
        public override string GuildEditMemberPermission { get; set; } = "你没有更改公会成员信息的权限";
        public override string GuildMemberLength { get; set; } = "更改公会头衔失败，公会头衔太长无法编辑";
        public override string GuildMemberNotFound { get; set; } = "找不到公会成员";
        public override string GuildKickPermission { get; set; } = "你没有权限驱逐公会成员";
        public override string GuildKickSelf { get; set; } = "你无法将自己驱逐出公会";
        public override string GuildMemberKicked { get; set; } = " {0} 被 {1} 驱逐出公会";
        public override string GuildKicked { get; set; } = "你被 {0} 驱逐出公会";
        public override string GuildManagePermission { get; set; } = "你没有管理公会的权限";
        public override string GuildMemberLimit { get; set; } = "公会已达到最大成员上限";
        public override string GuildMemberCost { get; set; } = "公会没有足够的资金来扩展公会成员上限";
        public override string GuildStorageLimit { get; set; } = "公会仓库已达到最大空间上限";
        public override string GuildStorageCost { get; set; } = "公会没有足够的资金来扩展公会仓库空间";
        public override string GuildInvitePermission { get; set; } = "你没有邀请新成员的权限";
        public override string GuildInviteGuild { get; set; } = "玩家: {0}，已经在另一个公会";
        public override string GuildInviteInvited { get; set; } = "玩家: {0}，正在被邀请加入另一个公会";
        public override string GuildInviteNotAllowed { get; set; } = "玩家: {0}，目前拒绝加入公会";
        public override string GuildInvitedNotAllowed { get; set; } = " {0} 希望邀请你加入他的公会 {1}，但你目前拒绝加入公会. 请输入命令 @允许加入公会";
        public override string GuildInviteRoom { get; set; } = "你的公会已经达到成员上限了";
        public override string GuildNoGuild { get; set; } = "你当前没有加入任何公会";
        public override string GuildWarPermission { get; set; } = "你没有权限申请开启公会战";
        public override string GuildNotFoundGuild { get; set; } = "无法找到公会 {0}";
        public override string GuildWarOwnGuild { get; set; } = "你不能和自己的公会进行公会战";
        public override string GuildAlreadyWar { get; set; } = "你的公会正与 {0} 进行公会战";
        public override string GuildWarCost { get; set; } = "你的公会金币不足无法申请公会战";
        public override string GuildWarFunds { get; set; } = " {0} 使用 {1:#,##0} 公会基金提交与 {2} 的公会战";
        public override string GuildConquestCastle { get; set; } = "你已经是城主，无法申请攻城战";
        public override string GuildConquestExists { get; set; } = "你已经申请攻城战";
        public override string GuildConquestBadCastle { get; set; } = "攻城失败";
        public override string GuildConquestProgress { get; set; } = "攻城战期间无法提交申请攻城战";
        public override string GuildConquestNeedItem { get; set; } = "你需要 {0} 来提交申请 {1} 攻城战";
        public override string GuildConquestSuccess { get; set; } = "一个公会提交了对你所占领城堡的攻城战";
        public override string GuildConquestDate { get; set; } = "你的公会提交了对 {0} 的攻城战申请";
        public override string GuildJoinGuild { get; set; } = "你已经加入了公会";
        public override string GuildJoinTime { get; set; } = "你不能加入另一个公会 {0}";
        public override string GuildJoinNoGuild { get; set; } = "玩家: {0}，已经离开公会";
        public override string GuildJoinPermission { get; set; } = "玩家: {0}，没有足够的权限邀请你加入公会";
        public override string GuildJoinNoRoom { get; set; } = " {0} 的公会已经满员";
        public override string GuildJoinWelcome { get; set; } = "欢迎加入公会: {0}";
        public override string GuildMemberJoined { get; set; } = " {0} 邀请 {1} 加入公会";
        public override string GuildLeaveFailed { get; set; } = "无法离开公会，你目前是公会会长不能离开";
        public override string GuildLeave { get; set; } = "你已经离开了公会";
        public override string GuildMemberLeave { get; set; } = " {0} 已经离开公会";
        public override string GuildWarDeath { get; set; } = "{1} 公会的 {0} 被 {3} 公会的 {2} 在公会战里击败";
        public override string GuildMaxGold { get; set; } = "你公会当前经费数量超出了最大范围";
        public override string GuildWarDate { get; set; } = "最近的沙巴克攻城时间是 {0} ，还有 {1} 时间";


        public override string GroupNoGroup { get; set; } = "你不在一个队伍中";
        public override string GroupNotLeader { get; set; } = "你不是队长";
        public override string GroupMemberNotFound { get; set; } = "无法在队伍中找到 {0} ";
        public override string GroupAlreadyGrouped { get; set; } = "玩家: {0}，已在其他队伍中";
        public override string GroupAlreadyInvited { get; set; } = "玩家: {0}，正被其他队伍邀请加入组队";
        public override string GroupInviteNotAllowed { get; set; } = "玩家: {0}，拒绝加入组队";
        public override string GroupSelf { get; set; } = "你不可以组自己";
        public override string GroupMemberLimit { get; set; } = " {0} 的队伍已经满组";
        public override string GroupRecallDelay { get; set; } = "你无法传送队员 {0}";
        public override string GroupRecallMap { get; set; } = "你无法在当前地图使用天地合一";
        public override string GroupRecallNotAllowed { get; set; } = "你拒绝使用天地合一传送";
        public override string GroupRecallMemberNotAllowed { get; set; } = " {0} 当前拒绝天地合一";
        public override string GroupRecallFromMap { get; set; } = "你所在的地图无法使用天地合一";
        public override string GroupRecallMemberFromMap { get; set; } = " {0} 无法从该地图天地合一传送出去";
        public override string FubenMapNoGroup { get; set; } = "在副本地图下不允许添加组队成员";
        public override string FubenMapNoGroupInvite { get; set; } = "玩家 {0} 在副本地图，不允许加入组队";


        public override string TradeAlreadyTrading { get; set; } = "你已经在和别人交易了";
        public override string TradeAlreadyHaveRequest { get; set; } = "你已经申请交易";
        public override string TradeNeedFace { get; set; } = "你需要面对玩家来申请交易";
        public override string TradeTargetNotAllowed { get; set; } = " {0} 拒绝交易请求";
        public override string TradeTargetAlreadyTrading { get; set; } = " {0} 已经在交易中";
        public override string TradeTargetAlreadyHaveRequest { get; set; } = " {0} 已经有交易申请";
        public override string TradeNotAllowed { get; set; } = " {0} 希望与你交易，但你拒绝交易申请. 如果需要交易请输入命令 @允许交易";
        public override string TradeTargetDead { get; set; } = "你不能跟死亡的玩家交易";
        public override string TradeRequested { get; set; } = "你已将交易申请发送给 {0}..";
        public override string TradeWaiting { get; set; } = "等待对方交易确认..";
        public override string TradePartnerWaiting { get; set; } = "对方在等你确认交易..";
        public override string TradeNoGold { get; set; } = "你的金币不足无法交易...";
        public override string TradePartnerNoGold { get; set; } = "对方没有足够的金币交易";
        public override string TradeTooMuchGold { get; set; } = "你无法持有更多的金币";
        public override string TradePartnerTooMuchGold { get; set; } = "对方的金币已经限额无法交易..";
        public override string TradeFailedItemsChanged { get; set; } = "你的物品更换，交易取消";
        public override string TradeFailedPartnerItemsChanged { get; set; } = " {0} 的物品更换，交易取消";
        public override string TradeNotEnoughSpace { get; set; } = "你不能携带更多的物品，请整理背包然后在申请交易";
        public override string TradeComplete { get; set; } = "交易完成";
        public override string TradeMaxGold { get; set; } = "你当前金币数量超出了最大金额范围";
        public override string TradePartnerMaxGold { get; set; } = "对方当前金币数量超出了最大金额范围";


        public override string NPCFundsGuild { get; set; } = "你无法使用公会基金，因为你还没有公会";
        public override string NPCFundsPermission { get; set; } = "你无法使用公会基金，因为你没有权限";
        public override string NPCFundsCost { get; set; } = "无法购买商品，你的公会需要支付 {0:#,##0} 金币";
        public override string NPCShengwang { get; set; } = "无法购买商品，你需要支付 {0:#,##0} 点声望";
        public override string NPCCost { get; set; } = "无法购买商品，你需要支付 {0:#,##0} 金币";
        public override string NPCNoRoom { get; set; } = "你的背包空间不足";
        public override string NPCFundsBuy { get; set; } = " {0} 使用 {1:#,##0} 公会基金购买 {2} x{3}";
        public override string NPCSellWorthless { get; set; } = "无法出售该商品";
        public override string NPCSellTooMuchGold { get; set; } = "无法出售该商品，你的金币已经达到上限";
        public override string NPCSellResult { get; set; } = "你出售 {0} 件商品获得 {1:#,##0} 金币";
        public override string FragmentCost { get; set; } = "无法分解该道具，你需要支付 {0:#,##0} 金币";
        public override string FragmentSpace { get; set; } = "无法分解该道具，你的背包空间不足";
        public override string FragmentResult { get; set; } = "你将 {0} 道具 (s) 分解，支付 {1:#,##0} 金币";
        public override string AccessoryLevelCost { get; set; } = "该道具无法提升更高的等级";
        public override string AccessoryLeveled { get; set; } = "恭喜你的 {0} 已经升级，现在可以提升属性";
        public override string RepairFail { get; set; } = "你无法修理 {0}";
        public override string RepairFailRepaired { get; set; } = "你无法修理 {0}，它已经修好了";
        public override string RepairFailLocation { get; set; } = "你无法在这里修理 {0} ";
        public override string RepairFailCooldown { get; set; } = "你无法特修 {0} 需要等待 {1} 的时间";
        public override string NPCRepairGuild { get; set; } = "你无法使用公会基金进行修理，因为你还没有公会";
        public override string NPCRepairPermission { get; set; } = "你无法使用公会基金进行修理，因为你没有权限";
        public override string NPCRepairGuildCost { get; set; } = "无法修理该道具，你的公会需要支付 {0:#,##0} 金币";
        public override string NPCRepairCost { get; set; } = "无法修理该道具，你需要支付 {0:#,##0} 金币";
        public override string NPCRepairResult { get; set; } = "你普通修理 {0} 道具 (s) 支付 {1:#,##0} 金币";
        public override string NPCRepairSpecialResult { get; set; } = "你特殊修理 {0} 道具 (s) 支付 {1:#,##0} 金币";
        public override string NPCRepairGuildResult { get; set; } = " {0} 使用 {1:#,##0} 公会基金修理 {2} 道具 (s)";
        public override string NPCRefinementGold { get; set; } = "你没有足够的金币";
        public override string NPCRefinementStoneFailedRoom { get; set; } = "你包裹没有空，无法获得该道具";
        public override string NPCRefinementStoneFailed { get; set; } = "合成精炼石失败";
        public override string NPCRefineNotReady { get; set; } = "无法取出武器，还没炼制完成";
        public override string NPCRefineNoRoom { get; set; } = "无法取出武器，你的背包空间不足";
        public override string NPCRefineSuccess { get; set; } = "恭喜你，你的武器升级成功";
        public override string NPCRefineFailed { get; set; } = "真遗憾，你的武器升级失败";
        public override string NPCMasterRefineGold { get; set; } = "你的金币不足无法完成大师级炼制成功率评估，需要支付: {0:#,##0}";
        public override string NPCMasterRefineChance { get; set; } = "你的成功率是: {0}%";
        public override string NPCJyChangeWorthless { get; set; } = "无法回收该商品";
        public override string NPCJyChangeResult { get; set; } = "你回收 {0} 件商品获得 {1:#,##0} 经验";
        public override string GuildJyChangeWorthless { get; set; } = "无法贡献回收该商品";
        public override string GuildJyChangeResult { get; set; } = "你回收 {0} 件商品获得 {1:#,##0} 贡献";
        public override string NPCItemAmount { get; set; } = "无法购买商品，该物品还剩下 {0} 个";
        public override string NPCRefinementShengwang { get; set; } = "你没有足够的声望";
        public override string BaoshiHechengSpace { get; set; } = "无法合成该道具，你的背包空间不足";
        public override string BaoshiFenjieResult { get; set; } = "你总共分解成功了 {0} 个宝石，其中 {1} 个普通宝石、 {2} 个1级宝石、 {3} 个2级宝石、 {4} 个3级宝石、 {5} 个4级宝石";
        public override string MingwenLevelGold { get; set; } = "铭文洗炼失败，你包裹没有 {0} 的金币";


        public override string ChargeExpire { get; set; } = " {0} 的能量已经从你的武器上消失";
        public override string ChargeFail { get; set; } = "无法积蓄 {0} 的能量";
        public override string CloakCombat { get; set; } = "你无法在战斗中潜行";
        public override string DashFailed { get; set; } = "你的等级不够无法移动对方";
        public override string WraithLevel { get; set; } = " {0} 的等级比你高，你无法使用亡灵束缚";
        public override string AbyssLevel { get; set; } = " {0} 的等级比你高，你无法使用深渊";
        public override string SkillEffort { get; set; } = "在这个地图使用 {0} 需要花费更多的能量，你在 {1} 的时间内无法使用";
        public override string SkillBadMap { get; set; } = "在这个地图无法使用 {0} ";


        public override string HorseDead { get; set; } = "你处于死亡状态无法骑马";
        public override string HorseOwner { get; set; } = "你没有马可以骑";
        public override string HorseMap { get; set; } = "你所在的地图无法骑马";

        public override string Referralshezhicheng { get; set; } = "你推荐的 {0} 介绍人设置你的账号设置成功。";
    }
}
