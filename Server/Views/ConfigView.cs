using System;
using System.ComponentModel;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraEditors.Controls;
using Library;
using Library.SystemModels;
using Server.Envir;
using Server.Models;
using S = Library.Network.ServerPackets;

namespace Server.Views
{
    public partial class ConfigView : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public ConfigView()
        {
            InitializeComponent();

            SyncronizeButton.Click += SyncronizeButton_Click;
            MysteryShipRegionIndexEdit.Properties.DataSource = SMain.Session.GetCollection<MapRegion>().Binding;
            LairRegionIndexEdit.Properties.DataSource = SMain.Session.GetCollection<MapRegion>().Binding;
            yaotaEdit.Properties.DataSource = SMain.Session.GetCollection<MapRegion>().Binding;
            MotaEdit.Properties.DataSource = SMain.Session.GetCollection<MapRegion>().Binding;
            Huodong01Edit.Properties.DataSource = SMain.Session.GetCollection<MapRegion>().Binding;
            Huodong02Edit.Properties.DataSource = SMain.Session.GetCollection<MapRegion>().Binding;
            Huodong03Edit.Properties.DataSource = SMain.Session.GetCollection<MapRegion>().Binding;
            Huodong04Edit.Properties.DataSource = SMain.Session.GetCollection<MapRegion>().Binding;
            Huodong05Edit.Properties.DataSource = SMain.Session.GetCollection<MapRegion>().Binding;
            Huodong06Edit.Properties.DataSource = SMain.Session.GetCollection<MapRegion>().Binding;
            Huodong07Edit.Properties.DataSource = SMain.Session.GetCollection<MapRegion>().Binding;
            Huodong08Edit.Properties.DataSource = SMain.Session.GetCollection<MapRegion>().Binding;
            Huodong09Edit.Properties.DataSource = SMain.Session.GetCollection<MapRegion>().Binding;
            Huodong10Edit.Properties.DataSource = SMain.Session.GetCollection<MapRegion>().Binding;
            Huodong11Edit.Properties.DataSource = SMain.Session.GetCollection<MapRegion>().Binding;
            Huodong12Edit.Properties.DataSource = SMain.Session.GetCollection<MapRegion>().Binding;
        }

        private void SyncronizeButton_Click(object sender, EventArgs e)
        {
            var form = new SyncForm();
            form.ShowDialog();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            LoadSettings();
        }
        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);

            SaveSettings();
        }

        public void LoadSettings()
        {
            
            IPAddressEdit.EditValue = Config.IPAddress;
            PortEdit.EditValue = Config.Port;
            TimeOutEdit.EditValue = Config.TimeOut;
            PingDelayEdit.EditValue = Config.PingDelay;
            UserCountPortEdit.EditValue = Config.UserCountPort;
            MaxPacketEdit.EditValue = Config.MaxPacket;
            PacketBanTimeEdit.EditValue = Config.PacketBanTime;

            
            AllowNewAccountEdit.EditValue = Config.AllowNewAccount;
            AllowChangePasswordEdit.EditValue = Config.AllowChangePassword;
            AllowLoginEdit.EditValue = Config.AllowLogin;
            AllowNewCharacterEdit.EditValue = Config.AllowNewCharacter;
            AllowDeleteCharacterEdit.EditValue = Config.AllowDeleteCharacter;
            AllowStartGameEdit.EditValue = Config.AllowStartGame;
            AllowWarriorEdit.EditValue = Config.AllowWarrior;
            AllowWizardEdit.EditValue = Config.AllowWizard;
            AllowTaoistEdit.EditValue = Config.AllowTaoist;
            AllowAssassinEdit.EditValue = Config.AllowAssassin;
            Shangxianxiaxiantishi.EditValue = Config.玩家上线下线提示;
            Xinjuesetishi.EditValue = Config.新玩家上线提示;
            RelogDelayEdit.EditValue = Config.RelogDelay;
            AllowRequestPasswordResetEdit.EditValue = Config.AllowRequestPasswordReset;
            AllowWebResetPasswordEdit.EditValue = Config.AllowWebResetPassword;
            AllowManualResetPasswordEdit.EditValue = Config.AllowManualResetPassword;
            AllowDeleteAccountEdit.EditValue = Config.AllowDeleteAccount;
            AllowManualActivationEdit.EditValue = Config.AllowManualActivation;
            AllowWebActivationEdit.EditValue = Config.AllowWebActivation;
            AllowRequestActivationEdit.EditValue = Config.AllowRequestActivation;
            Dinghaoxiugaimimaok.EditValue = Config.是否顶号自动修改密码;
            ShifouGongce.EditValue = Config.是否公测开启游戏;
            ShifouNeice.EditValue = Config.是否内测开启游戏;
            Guajixunzhaodiyi.EditValue = Config.挂机寻找怪物模式01;
            Guajixunzhaodier.EditValue = Config.挂机寻找怪物模式02;

            
            CheckVersionEdit.EditValue = Config.CheckVersion;
            VersionPathEdit.EditValue = Config.VersionPath;
            DBSaveDelayEdit.EditValue = Config.DBSaveDelay;
            MapPathEdit.EditValue = Config.MapPath;
            MasterPasswordEdit.EditValue = Config.MasterPassword;
            ClientPathEdit.EditValue = Config.ClientPath;
            ReleaseDateEdit.EditValue = Config.ReleaseDate;
            RabbitEventEndEdit.EditValue = Config.EasterEventEnd;
            Daojishiok.EditValue = Config.是否关闭服务器时倒计时;
            Tishiok.EditValue = Config.关闭提示;
            XingyunNPCOK.EditValue = Config.是否开启神秘商人活动;
            ShenmiNpcTime.EditValue = Config.神秘商人NPC移除时间;
            Jueseshujukuhequ.EditValue = Config.需要合并的角色数据库路径地址;
            Huodonglanok.EditValue = Config.是否开启活动栏;
            GuanggaoKuanduok.EditValue = Config.活动栏宽度;
            GuanggaoGaoduok.EditValue = Config.活动栏高度;
            Biaomingok.EditValue = Config.活动栏标题;

            
            MailServerEdit.EditValue = Config.MailServer;
            MailPortEdit.EditValue = Config.MailPort;
            MailUseSSLEdit.EditValue = Config.MailUseSSL;
            MailAccountEdit.EditValue = Config.MailAccount;
            MailPasswordEdit.EditValue = Config.MailPassword;
            MailFromEdit.EditValue = Config.MailFrom;
            MailDisplayNameEdit.EditValue = Config.MailDisplayName;

            
            WebPrefixEdit.EditValue = Config.WebPrefix;
            WebCommandLinkEdit.EditValue = Config.WebCommandLink;
            ActivationSuccessLinkEdit.EditValue = Config.ActivationSuccessLink;
            ActivationFailLinkEdit.EditValue = Config.ActivationFailLink;
            ResetSuccessLinkEdit.EditValue = Config.ResetSuccessLink;
            ResetFailLinkEdit.EditValue = Config.ResetFailLink;
            DeleteSuccessLinkEdit.EditValue = Config.DeleteSuccessLink;
            DeleteFailLinkEdit.EditValue = Config.DeleteFailLink;

            BuyPrefixEdit.EditValue = Config.BuyPrefix;
            BuyAddressEdit.EditValue = Config.BuyAddress;
            IPNPrefixEdit.EditValue = Config.IPNPrefix;
            ReceiverEMailEdit.EditValue = Config.ReceiverEMail;
            ProcessGameGoldEdit.EditValue = Config.ProcessGameGold;
            AllowBuyGammeGoldEdit.EditValue = Config.AllowBuyGammeGold;
            RequireActivationEdit.EditValue = Config.RequireActivation;

            
            MaxViewRangeEdit.EditValue = Config.MaxViewRange;
            ShoutDelayEdit.EditValue = Config.ShoutDelay;
            GlobalDelayEdit.EditValue = Config.GlobalDelay;
            MaxLevelEdit.EditValue = Config.MaxLevel;
            DayCycleCountEdit.EditValue = Config.DayCycleCount;
            SkillExpEdit.EditValue = Config.SkillExp;
            AllowObservationEdit.EditValue = Config.AllowObservation;
            BrownDurationEdit.EditValue = Config.BrownDuration;
            PKPointRateEdit.EditValue = Config.PKPointRate;
            PKPointTickRateEdit.EditValue = Config.PKPointTickRate;
            RedPointEdit.EditValue = Config.RedPoint;
            PvPCurseDurationEdit.EditValue = Config.PvPCurseDuration;
            PvPCurseRateEdit.EditValue = Config.PvPCurseRate;
            AutoReviveDelayEdit.EditValue = Config.AutoReviveDelay;
            Yunxujieshaoren.EditValue = Config.YunxuXiugaiJieshaoren;
            Jieshaorenzuxinrenjingyan.EditValue = Config.介绍人组新人经验加成;
            Jieshaorenzubeijsrjingyan.EditValue = Config.介绍人组被介绍人经验加成;
            Jieshaorenzubeijsrgerenjingyan.EditValue = Config.介绍人组被介绍人个人经验加成;
            YaoqiuJSRjihuozhanghao.EditValue = Config.要求介绍人激活账号;
            JihuowanjiaJYjiacheng.EditValue = Config.激活玩家经验加成;
            JYhuishou.EditValue = Config.开启经验回收等级;
            GuildLevel.EditValue = Config.是否开启公会等级;
            XinshouLiwu.EditValue = Config.是否送新手礼物;
            GunghuiPaihang.EditValue = Config.是否开启公会排行榜Buff;
            GunghuiGerenPaihang.EditValue = Config.是否开启公会个人排行榜Buff;
            ZaixianFenjie.EditValue = Config.包裹远程装备分解功能开启玩家转生次数;
            Xiudikang.EditValue = Config.是否开启优化最后抵抗技能伤害;
            Yidaoyihua.EditValue = Config.是否开启一刀一花;
            DikangEdit.EditValue = Config.刺客最后抵抗;
            SihuaEdit.EditValue = Config.刺客四花技能;
            Liujizhuansheng.EditValue = Config.是否开启留级转生;
            ZhuangbeiHuanhua.EditValue = Config.是否开启装备幻化时镶嵌宝石挂钩玩家转生次数;
            Huanhuabangding.EditValue = Config.是否幻化装备后绑定装备;
            KaiqiBaoshi5432.EditValue = Config.是否开启5433合成宝石;
            Siwangbaolv.EditValue = Config.是否开启死亡爆率;
            Baoguodiaobv.EditValue = Config.包裹中的物品掉率;
            Putongwupindiaobv.EditValue = Config.普通物品的掉率;
            Gaojiwupindiaobv.EditValue = Config.高级物品的掉率;
            Xishiwupindiaobv.EditValue = Config.稀世物品的掉率;
            Hongmingwupindiaobv.EditValue = Config.红名物品掉率;
            BeiguaiSiwangbaolv.EditValue = Config.是否开启被怪死亡身上装备爆率;
            ChuanranBoss.EditValue = Config.是否传染技能伤害对Boss开启;
            ShidushuGuagou.EditValue = Config.是否开启施毒术技能挂钩道士属性;
            ShidushuMax.EditValue = Config.施毒术技能伤害最高值;
            MingwenBangding.EditValue = Config.是否开启绑定铭文来洗武器时武器改为绑定武器机制;
            Shifoujilubaokaqingk.EditValue = Config.是否日志记录玩家一般包裹物品卡位情况;

            
            DeadDurationEdit.EditValue = Config.DeadDuration;
            HarvestDurationEdit.EditValue = Config.HarvestDuration;
            MysteryShipRegionIndexEdit.EditValue = Config.MysteryShipRegionIndex;
            MysteryShipOpenEdit.EditValue = Config.MysteryShipOpen;
            Chuanshifou.EditValue = Config.神舰是否记录;
            Chuanjiluming.EditValue = Config.神舰记录名称;
            LairRegionIndexEdit.EditValue = Config.LairRegionIndex;
            LairRegionOpenEdit.EditValue = Config.LairRegionOpen;
            Rongyanshifou.EditValue = Config.熔岩是否记录;
            Rongyanjiluming.EditValue = Config.熔岩记录名称;
            yaotaEdit.EditValue = Config.Yaota;
            YaotaOpenEdit.EditValue = Config.YaotaOpen;
            Yaotashifou.EditValue = Config.比奇地下城是否记录;
            Yaotajiluming.EditValue = Config.比奇地下城记录名称;
            MotaEdit.EditValue = Config.Mota;
            MotaOpenEdit.EditValue = Config.MotaOpen;
            Motashifou.EditValue = Config.魔虫洞是否记录;
            Motajiluming.EditValue = Config.魔虫洞记录名称;
            Huodong01Edit.EditValue = Config.Huodong01;
            Huodong01OpenEdit.EditValue = Config.Huodong01Open;
            Hd01shifou.EditValue = Config.活动01是否记录;
            Hd01jiluming.EditValue = Config.活动01记录名称;
            Huodong02Edit.EditValue = Config.Huodong02;
            Huodong02OpenEdit.EditValue = Config.Huodong02Open;
            Hd02shifou.EditValue = Config.活动02是否记录;
            Hd02jiluming.EditValue = Config.活动02记录名称;
            Huodong03Edit.EditValue = Config.Huodong03;
            Huodong03OpenEdit.EditValue = Config.Huodong03Open;
            Hd03shifou.EditValue = Config.活动03是否记录;
            Hd03jiluming.EditValue = Config.活动03记录名称;
            Huodong04Edit.EditValue = Config.Huodong04;
            Huodong04OpenEdit.EditValue = Config.Huodong04Open;
            Hd04shifou.EditValue = Config.活动04是否记录;
            Hd04jiluming.EditValue = Config.活动04记录名称;
            Huodong05Edit.EditValue = Config.Huodong05;
            Huodong05OpenEdit.EditValue = Config.Huodong05Open;
            Hd05shifou.EditValue = Config.活动05是否记录;
            Hd05jiluming.EditValue = Config.活动05记录名称;
            Huodong06Edit.EditValue = Config.Huodong06;
            Huodong06OpenEdit.EditValue = Config.Huodong06Open;
            Hd06shifou.EditValue = Config.活动06是否记录;
            Hd06jiluming.EditValue = Config.活动06记录名称;
            Huodong07Edit.EditValue = Config.Huodong07;
            Huodong07OpenEdit.EditValue = Config.Huodong07Open;
            Hd07shifou.EditValue = Config.活动07是否记录;
            Hd07jiluming.EditValue = Config.活动07记录名称;
            Huodong08Edit.EditValue = Config.Huodong08;
            Huodong08OpenEdit.EditValue = Config.Huodong08Open;
            Hd08shifou.EditValue = Config.活动08是否记录;
            Hd08jiluming.EditValue = Config.活动08记录名称;
            Huodong09Edit.EditValue = Config.Huodong09;
            Huodong09OpenEdit.EditValue = Config.Huodong09Open;
            Hd09shifou.EditValue = Config.活动09是否记录;
            Hd09jiluming.EditValue = Config.活动09记录名称;
            Huodong10Edit.EditValue = Config.Huodong10;
            Huodong10OpenEdit.EditValue = Config.Huodong10Open;
            Hd10shifou.EditValue = Config.活动10是否记录;
            Hd10jiluming.EditValue = Config.活动10记录名称;
            Huodong11Edit.EditValue = Config.Huodong11;
            Huodong11OpenEdit.EditValue = Config.Huodong11Open;
            Hd11shifou.EditValue = Config.活动11是否记录;
            Hd11jiluming.EditValue = Config.活动11记录名称;
            Huodong12Edit.EditValue = Config.Huodong12;
            Huodong12OpenEdit.EditValue = Config.Huodong12Open;
            Hd12shifou.EditValue = Config.活动12是否记录;
            Hd12jiluming.EditValue = Config.活动12记录名称;
            ShuaguaiBodong.EditValue = Config.是否开启刷怪时间波动;


            
            wakuangbangding.EditValue = Config.是否挖矿物品绑定;
            DropDurationEdit.EditValue = Config.DropDuration;
            DropDistanceEdit.EditValue = Config.DropDistance;
            DropLayersEdit.EditValue = Config.DropLayers;
            TorchRateEdit.EditValue = Config.TorchRate;
            SpecialRepairDelayEdit.EditValue = Config.SpecialRepairDelay;
            MaxLuckEdit.EditValue = Config.MaxLuck;
            LuckRateEdit.EditValue = Config.LuckRate;
            MaxCurseEdit.EditValue = Config.MaxCurse;
            LabelControl88TaxSani.EditValue = Config.宝箱抽奖;
            LabelControl90TaxSani.EditValue = Config.宝箱重置;
            Mfguajishijianzi.EditValue = Config.每天免费挂机时间;
            Jipindebaolv.EditValue = Config.极品的爆率;
            Jipindaxiaoy.EditValue = Config.极品的大小1;
            Jipindaxiaoe.EditValue = Config.极品的大小2;
            Jipindaxiaos.EditValue = Config.极品的大小3;
            Jipindaxiaosi.EditValue = Config.极品的大小4;
            Jipindaxiaow.EditValue = Config.极品的大小5;
            Jipindaxiaol.EditValue = Config.极品的大小6;
            Jipindaxiaogailvy.EditValue = Config.武器攻击自然灵魂大小产生概率1;
            Jipindaxiaogailve.EditValue = Config.武器攻击自然灵魂大小产生概率2;
            Jipindaxiaogailvs.EditValue = Config.武器攻击自然灵魂大小产生概率3;
            Jipindaxiaogailvsi.EditValue = Config.武器攻击自然灵魂大小产生概率4;
            Jipindaxiaogailvw.EditValue = Config.武器攻击自然灵魂大小产生概率5;
            Jipindaxiaogailvl.EditValue = Config.武器攻击自然灵魂大小产生概率6;
            GyJipindaxiaogailvy.EditValue = Config.所有攻击元素极品大小产生概率1;
            GyJipindaxiaogailve.EditValue = Config.所有攻击元素极品大小产生概率2;
            GyJipindaxiaogailvs.EditValue = Config.所有攻击元素极品大小产生概率3;
            GyJipindaxiaogailvsi.EditValue = Config.所有攻击元素极品大小产生概率4;
            GyJipindaxiaogailvw.EditValue = Config.所有攻击元素极品大小产生概率5;
            GyJipindaxiaogailvl.EditValue = Config.所有攻击元素极品大小产生概率6;
            DunJipindaxiaogailvy.EditValue = Config.盾牌攻击自然灵魂格挡闪避毒系抵抗几率的大小生产概率1;
            DunJipindaxiaogailve.EditValue = Config.盾牌攻击自然灵魂格挡闪避毒系抵抗几率的大小生产概率2;
            DunJipindaxiaogailvs.EditValue = Config.盾牌攻击自然灵魂格挡闪避毒系抵抗几率的大小生产概率3;
            DunJipindaxiaogailvsi.EditValue = Config.盾牌攻击自然灵魂格挡闪避毒系抵抗几率的大小生产概率4;
            DunJipindaxiaogailvw.EditValue = Config.盾牌攻击自然灵魂格挡闪避毒系抵抗几率的大小生产概率5;
            DunJipindaxiaogailvl.EditValue = Config.盾牌攻击自然灵魂格挡闪避毒系抵抗几率的大小生产概率6;
            YiJipindaxiaogailvy.EditValue = Config.衣服戒指防御魔御戒指拾取范围的大小生产概率1;
            YiJipindaxiaogailve.EditValue = Config.衣服戒指防御魔御戒指拾取范围的大小生产概率2;
            YiJipindaxiaogailvs.EditValue = Config.衣服戒指防御魔御戒指拾取范围的大小生产概率3;
            YiJipindaxiaogailvsi.EditValue = Config.衣服戒指防御魔御戒指拾取范围的大小生产概率4;
            YiJipindaxiaogailvw.EditValue = Config.衣服戒指防御魔御戒指拾取范围的大小生产概率5;
            YiJipindaxiaogailvl.EditValue = Config.衣服戒指防御魔御戒指拾取范围的大小生产概率6;
            TouJipindaxiaogailvy.EditValue = Config.头防魔首饰攻自灵链手准确敏捷鞋子舒适的大小生产概率1;
            TouJipindaxiaogailve.EditValue = Config.头防魔首饰攻自灵链手准确敏捷鞋子舒适的大小生产概率2;
            TouJipindaxiaogailvs.EditValue = Config.头防魔首饰攻自灵链手准确敏捷鞋子舒适的大小生产概率3;
            TouJipindaxiaogailvsi.EditValue = Config.头防魔首饰攻自灵链手准确敏捷鞋子舒适的大小生产概率4;
            TouJipindaxiaogailvw.EditValue = Config.头防魔首饰攻自灵链手准确敏捷鞋子舒适的大小生产概率5;
            TouJipindaxiaogailvl.EditValue = Config.头防魔首饰攻自灵链手准确敏捷鞋子舒适的大小生产概率6;
            XieJipindaxiaogailvy.EditValue = Config.鞋子手镯防御魔御的大小生产概率1;
            XieJipindaxiaogailve.EditValue = Config.鞋子手镯防御魔御的大小生产概率2;
            XieJipindaxiaogailvs.EditValue = Config.鞋子手镯防御魔御的大小生产概率3;
            XieJipindaxiaogailvsi.EditValue = Config.鞋子手镯防御魔御的大小生产概率4;
            XieJipindaxiaogailvw.EditValue = Config.鞋子手镯防御魔御的大小生产概率5;
            XieJipindaxiaogailvl.EditValue = Config.鞋子手镯防御魔御的大小生产概率6;
            CurseRateEdit.EditValue = Config.CurseRate;
            MaxStrengthEdit.EditValue = Config.MaxStrength;
            StrengthAddRateEdit.EditValue = Config.StrengthAddRate;
            StrengthLossRateEdit.EditValue = Config.StrengthLossRate;

            
            ExperienceRateEdit.EditValue = Config.ExperienceRate;
            Ewaijingyan.EditValue = Config.额外经验加成;
            EwaijingyanOK.EditValue = Config.是否开启额外经验加成;
            DropRateEdit.EditValue = Config.DropRate;
            Ewaibaolv.EditValue = Config.额外爆率加成;
            EwaibaolvOK.EditValue = Config.是否开启额外爆率加成;
            GoldRateEdit.EditValue = Config.GoldRate;
            Ewaijinbi.EditValue = Config.额外金币加成;
            EwaijinbiOK.EditValue = Config.是否开启额外金币加成;
            SkillRateEdit.EditValue = Config.SkillRate;
            CompanionRateEdit.EditValue = Config.CompanionRate;
            Jingliancglvc.EditValue = Config.Jinglianchenggonglv;
            Ghquanc3039.EditValue = Config.Jingyanquan3039;
            Ghquanc4049.EditValue = Config.Jingyanquan4049;
            Ghquanc5059.EditValue = Config.Jingyanquan5059;
            Ghquanc6069.EditValue = Config.Jingyanquan6069;
            Ghquanc7079.EditValue = Config.Jingyanquan7079;
            Ghquanc8089.EditValue = Config.Jingyanquan8089;
            Ghquanc9099.EditValue = Config.Jingyanquan9099;
            Ghquanc0109.EditValue = Config.Jingyanquan0109;
            Ghquanc1019.EditValue = Config.Jingyanquan1019;
            Ghquanc2029.EditValue = Config.Jingyanquan2029;
            Gjbsshu.EditValue = Config.青铜会员经验;
            Zrbsshu.EditValue = Config.青铜会员爆率;
            Lhbsshu.EditValue = Config.青铜会员金币;
            Gjjlbsshu.EditValue = Config.白银会员经验;
            Zrjlbsshu.EditValue = Config.白银会员爆率;
            Lhjlbsshu.EditValue = Config.白银会员金币;
            Smjlbsshu.EditValue = Config.黄金会员经验;
            Mfbsshu.EditValue = Config.黄金会员爆率;
            Sdbsshu.EditValue = Config.黄金会员金币;
            Fybsshu.EditValue = Config.青铜回收倍率;
            Mybsshu.EditValue = Config.白银回收倍率;
            Jybsshu.EditValue = Config.黄金回收倍率;
            Xxbsshu.EditValue = Config.武器基础爆率;
            Ghuoshu.EditValue = Config.衣服基础爆率;
            Gbingshu.EditValue = Config.头盔基础爆率;
            Gleishu.EditValue = Config.项链基础爆率;
            Gfengshu.EditValue = Config.手镯基础爆率;
            Gshengshu.EditValue = Config.戒指基础爆率;
            Ganshu.EditValue = Config.靴子基础爆率;
            Ghuanshu.EditValue = Config.矿石基础爆率;
            Qhuoshu.EditValue = Config.书籍基础爆率;
            Qbingshu.EditValue = Config.盾牌基础爆率;
            Qleishu.EditValue = Config.徽章基础爆率;
            Qfengshu.EditValue = Config.宝石基础爆率;
            Qshenshu.EditValue = Config.轴卷基础爆率;
            Qanshu.EditValue = Config.公会泉回收经验3039;
            Qhuanshu.EditValue = Config.公会泉回收经验4049;
            Qmofadunshu.EditValue = Config.公会泉回收经验5059;
            Qbingdongshu.EditValue = Config.公会泉回收经验6069;
            Qmabishu.EditValue = Config.公会泉回收经验7079;
            Qyidongshu.EditValue = Config.公会泉回收经验8089;
            Qchenmoshu.EditValue = Config.公会泉回收经验90以上;
            Qgedangshu.EditValue = Config.公会泉回收经验0109;
            Qduobishu.EditValue = Config.公会泉回收经验1019;
            Lvdushu.EditValue = Config.公会泉回收经验2029;
            Jieshaorendjshishu.EditValue = Config.介绍人等级10时;
            Jieshaorendjershishu.EditValue = Config.介绍人等级20时;
            Jieshaorendjsanshishu.EditValue = Config.介绍人等级30时;
            Jieshaorendjsishishu.EditValue = Config.介绍人等级40时;
            Jieshaorendjwushishu.EditValue = Config.介绍人等级50时;
            Bjieshaorendjshu.EditValue = Config.被介绍人第一阶段等级;
            Bjieshaorensjshu.EditValue = Config.被介绍人第一阶段赏金;
            Bjieshaorenswshu.EditValue = Config.被介绍人第一阶段声望;
            Jieshaorensjshu.EditValue = Config.介绍人第一阶段赏金;
            Jieshaorenswshu.EditValue = Config.介绍人第一阶段声望;
            Bjieshaorendjeshu.EditValue = Config.被介绍人第二阶段等级;
            Bjieshaorensjeshu.EditValue = Config.被介绍人第二阶段赏金;
            Bjieshaorensweshu.EditValue = Config.被介绍人第二阶段声望;
            Jieshaorensjeshu.EditValue = Config.介绍人第二阶段赏金;
            Jieshaorensweshu.EditValue = Config.介绍人第二阶段声望;
            Bjieshaorendjsshu.EditValue = Config.被介绍人第三阶段等级;
            Bjieshaorensjsshu.EditValue = Config.被介绍人第三阶段赏金;
            Bjieshaorenswsshu.EditValue = Config.被介绍人第三阶段声望;
            Jieshaorensjsshu.EditValue = Config.介绍人第三阶段赏金;
            Jieshaorenswsshu.EditValue = Config.介绍人第三阶段声望;
            Bjieshaorendjsishu.EditValue = Config.被介绍人第四阶段等级;
            Bjieshaorensjsishu.EditValue = Config.被介绍人第四阶段赏金;
            Bjieshaorenswsishu.EditValue = Config.被介绍人第四阶段声望;
            Jieshaorensjsishu.EditValue = Config.介绍人第四阶段赏金;
            Jieshaorenswsishu.EditValue = Config.介绍人第四阶段声望;
            XGuilddjshu.EditValue = Config.新收公会角色等级低于;
            XGuildjyshu.EditValue = Config.新收公会经验加成;
            XGuildblshu.EditValue = Config.新收公会爆率加成;
            XGuildjbshu.EditValue = Config.新收公会金币加成;
            YiGuildrsshu.EditValue = Config.其他公会人数限制一;
            YiGuildjyshu.EditValue = Config.其他公会经验加成一;
            YiGuildblshu.EditValue = Config.其他公会爆率加成一;
            YiGuildjbshu.EditValue = Config.其他公会金币加成一;
            ErGuildrsshu.EditValue = Config.其他公会人数限制二;
            ErGuildjyshu.EditValue = Config.其他公会经验加成二;
            ErGuildblshu.EditValue = Config.其他公会爆率加成二;
            ErGuildjbshu.EditValue = Config.其他公会金币加成二;
            SanGuildrsshu.EditValue = Config.其他公会人数限制三;
            SanGuildjyshu.EditValue = Config.其他公会经验加成三;
            SanGuildblshu.EditValue = Config.其他公会爆率加成三;
            SanGuildjbshu.EditValue = Config.其他公会金币加成三;
            SiGuildrsshu.EditValue = Config.其他公会人数限制四;
            SiGuildjyshu.EditValue = Config.其他公会经验加成四;
            SiGuildblshu.EditValue = Config.其他公会爆率加成四;
            SiGuildjbshu.EditValue = Config.其他公会金币加成四;
            ShaGuildjyshu.EditValue = Config.沙巴克公会经验加成;
            ShaGuildblshu.EditValue = Config.沙巴克公会爆率加成;
            ShaGuildjbshu.EditValue = Config.沙巴克公会金币加成;


        }
        public void SaveSettings()
        {
            
            Config.IPAddress = (string) IPAddressEdit.EditValue;
            Config.Port = (ushort) PortEdit.EditValue;
            Config.TimeOut = (TimeSpan) TimeOutEdit.EditValue;
            Config.PingDelay = (TimeSpan)PingDelayEdit.EditValue;
            Config.UserCountPort = (ushort)UserCountPortEdit.EditValue;
            Config.MaxPacket = (int)MaxPacketEdit.EditValue;
            Config.PacketBanTime = (TimeSpan)PacketBanTimeEdit.EditValue;


            
            Config.AllowNewAccount = (bool) AllowNewAccountEdit.EditValue;
            Config.AllowChangePassword = (bool) AllowChangePasswordEdit.EditValue;
            Config.AllowLogin = (bool) AllowLoginEdit.EditValue;
            Config.AllowNewCharacter = (bool) AllowNewCharacterEdit.EditValue;
            Config.AllowDeleteCharacter = (bool) AllowDeleteCharacterEdit.EditValue;
            Config.AllowStartGame = (bool) AllowStartGameEdit.EditValue;
            Config.AllowWarrior = (bool) AllowWarriorEdit.EditValue;
            Config.AllowWizard = (bool) AllowWizardEdit.EditValue;
            Config.AllowTaoist = (bool) AllowTaoistEdit.EditValue;
            Config.AllowAssassin = (bool) AllowAssassinEdit.EditValue;
            Config.玩家上线下线提示 = (bool)Shangxianxiaxiantishi.EditValue;
            Config.新玩家上线提示 = (bool)Xinjuesetishi.EditValue;
            Config.RelogDelay = (TimeSpan) RelogDelayEdit.EditValue;
            Config.AllowRequestPasswordReset = (bool) AllowRequestPasswordResetEdit.EditValue;
            Config.AllowWebResetPassword = (bool) AllowWebResetPasswordEdit.EditValue;
            Config.AllowManualResetPassword = (bool) AllowManualResetPasswordEdit.EditValue;
            Config.AllowDeleteAccount = (bool) AllowDeleteAccountEdit.EditValue;
            Config.AllowManualActivation = (bool) AllowManualActivationEdit.EditValue;
            Config.AllowWebActivation = (bool) AllowWebActivationEdit.EditValue;
            Config.AllowRequestActivation = (bool) AllowRequestActivationEdit.EditValue;
            Config.是否顶号自动修改密码 = (bool)Dinghaoxiugaimimaok.EditValue;
            Config.是否公测开启游戏 = (bool)ShifouGongce.EditValue;
            Config.是否内测开启游戏 = (bool)ShifouNeice.EditValue;
            Config.挂机寻找怪物模式01 = (bool)Guajixunzhaodiyi.EditValue;
            Config.挂机寻找怪物模式02 = (bool)Guajixunzhaodier.EditValue;


            
            Config.CheckVersion = (bool)CheckVersionEdit.EditValue;
            Config.VersionPath = (string)VersionPathEdit.EditValue;
            Config.DBSaveDelay = (TimeSpan)DBSaveDelayEdit.EditValue;
            Config.MapPath = (string)MapPathEdit.EditValue;
            Config.MasterPassword = (string)MasterPasswordEdit.EditValue;
            Config.ClientPath = (string)ClientPathEdit.EditValue;
            Config.ReleaseDate = (DateTime)ReleaseDateEdit.EditValue;
            Config.EasterEventEnd = (DateTime)RabbitEventEndEdit.EditValue;
            Config.是否关闭服务器时倒计时 = (bool)Daojishiok.EditValue; 
            Config.关闭提示 = (string)Tishiok.EditValue;
            Config.是否开启神秘商人活动 = (bool)XingyunNPCOK.EditValue;
            Config.神秘商人NPC移除时间 = (int)ShenmiNpcTime.EditValue;
            Config.需要合并的角色数据库路径地址 = (string)Jueseshujukuhequ.EditValue;
            Config.是否开启活动栏 = (bool)Huodonglanok.EditValue;
            Config.活动栏宽度 = (int)GuanggaoKuanduok.EditValue;
            Config.活动栏高度 = (int)GuanggaoGaoduok.EditValue;
            Config.活动栏标题 = (string)Biaomingok.EditValue;

            
            Config.MailServer = (string) MailServerEdit.EditValue;
            Config.MailPort = (int) MailPortEdit.EditValue;
            Config.MailUseSSL = (bool) MailUseSSLEdit.EditValue;
            Config.MailAccount = (string) MailAccountEdit.EditValue;
            Config.MailPassword = (string) MailPasswordEdit.EditValue;
            Config.MailFrom = (string) MailFromEdit.EditValue;
            Config.MailDisplayName = (string) MailDisplayNameEdit.EditValue;

            
            Config.WebPrefix = (string) WebPrefixEdit.EditValue;
            Config.WebCommandLink = (string)WebCommandLinkEdit.EditValue;
            Config.ActivationSuccessLink = (string)ActivationSuccessLinkEdit.EditValue;
            Config.ActivationFailLink = (string)ActivationFailLinkEdit.EditValue;
            Config.ResetSuccessLink = (string)ResetSuccessLinkEdit.EditValue;
            Config.ResetFailLink = (string)ResetFailLinkEdit.EditValue;
            Config.DeleteSuccessLink = (string)DeleteSuccessLinkEdit.EditValue;
            Config.DeleteFailLink = (string)DeleteFailLinkEdit.EditValue;

            Config.BuyPrefix = (string)BuyPrefixEdit.EditValue;
            Config.BuyAddress = (string)BuyAddressEdit.EditValue;
            Config.IPNPrefix = (string)IPNPrefixEdit.EditValue;
            Config.ReceiverEMail = (string)ReceiverEMailEdit.EditValue;
            Config.ProcessGameGold = (bool)ProcessGameGoldEdit.EditValue;
            Config.AllowBuyGammeGold = (bool)AllowBuyGammeGoldEdit.EditValue;
			Config.RequireActivation = (bool)RequireActivationEdit.EditValue;


            
            Config.MaxViewRange = (int)MaxViewRangeEdit.EditValue;
            Config.ShoutDelay = (TimeSpan)ShoutDelayEdit.EditValue;
            Config.GlobalDelay = (TimeSpan)GlobalDelayEdit.EditValue;
            Config.MaxLevel = (int)MaxLevelEdit.EditValue;
            Config.DayCycleCount = (int)DayCycleCountEdit.EditValue;
            Config.SkillExp = (int)SkillExpEdit.EditValue;
            Config.AllowObservation = (bool) AllowObservationEdit.EditValue;
            Config.BrownDuration = (TimeSpan)BrownDurationEdit.EditValue;
            Config.PKPointRate = (int)PKPointRateEdit.EditValue;
            Config.PKPointTickRate = (TimeSpan)PKPointTickRateEdit.EditValue;
            Config.RedPoint = (int)RedPointEdit.EditValue;
            Config.PvPCurseDuration = (TimeSpan)PvPCurseDurationEdit.EditValue;
            Config.PvPCurseRate = (int)PvPCurseRateEdit.EditValue;
            Config.AutoReviveDelay = (TimeSpan)AutoReviveDelayEdit.EditValue;
            Config.YunxuXiugaiJieshaoren = (bool)Yunxujieshaoren.EditValue;
            Config.介绍人组新人经验加成 = (int)Jieshaorenzuxinrenjingyan.EditValue;
            Config.介绍人组被介绍人经验加成 = (int)Jieshaorenzubeijsrjingyan.EditValue;
            Config.介绍人组被介绍人个人经验加成 = (int)Jieshaorenzubeijsrgerenjingyan.EditValue;
            Config.要求介绍人激活账号 = (bool)YaoqiuJSRjihuozhanghao.EditValue;
            Config.激活玩家经验加成 = (int)JihuowanjiaJYjiacheng.EditValue;
            Config.开启经验回收等级 = (int)JYhuishou.EditValue;
            Config.是否开启公会等级 = (bool)GuildLevel.EditValue;
            Config.是否送新手礼物 = (bool)XinshouLiwu.EditValue;
            Config.是否开启公会排行榜Buff = (bool)GunghuiPaihang.EditValue;
            Config.是否开启公会个人排行榜Buff = (bool)GunghuiGerenPaihang.EditValue;
            Config.包裹远程装备分解功能开启玩家转生次数 = (int)ZaixianFenjie.EditValue;
            Config.是否开启优化最后抵抗技能伤害 = (bool)Xiudikang.EditValue;
            Config.是否开启一刀一花 = (bool)Yidaoyihua.EditValue;
            Config.刺客最后抵抗 = (Decimal)DikangEdit.EditValue;
            Config.刺客四花技能 = (Decimal)SihuaEdit.EditValue;
            Config.是否开启留级转生 = (bool)Liujizhuansheng.EditValue;
            Config.是否开启装备幻化时镶嵌宝石挂钩玩家转生次数 = (bool)ZhuangbeiHuanhua.EditValue;
            Config.是否幻化装备后绑定装备 = (bool)Huanhuabangding.EditValue;
            Config.是否开启5433合成宝石 = (bool)KaiqiBaoshi5432.EditValue;
            Config.是否开启死亡爆率 = (bool)Siwangbaolv.EditValue;
            Config.包裹中的物品掉率 = (int)Baoguodiaobv.EditValue;
            Config.普通物品的掉率 = (int)Putongwupindiaobv.EditValue;
            Config.高级物品的掉率 = (int)Gaojiwupindiaobv.EditValue;
            Config.稀世物品的掉率 = (int)Xishiwupindiaobv.EditValue;
            Config.红名物品掉率 = (int)Hongmingwupindiaobv.EditValue;
            Config.是否开启被怪死亡身上装备爆率 = (bool)BeiguaiSiwangbaolv.EditValue;
            Config.是否传染技能伤害对Boss开启 = (bool)ChuanranBoss.EditValue;
            Config.是否开启施毒术技能挂钩道士属性 = (bool)ShidushuGuagou.EditValue;
            Config.施毒术技能伤害最高值 = (int)ShidushuMax.EditValue;
            Config.是否开启绑定铭文来洗武器时武器改为绑定武器机制 = (bool)MingwenBangding.EditValue;
            Config.是否日志记录玩家一般包裹物品卡位情况 = (bool)Shifoujilubaokaqingk.EditValue;

            
            Config.DeadDuration = (TimeSpan)DeadDurationEdit.EditValue;
            Config.HarvestDuration = (TimeSpan)HarvestDurationEdit.EditValue;
            Config.MysteryShipRegionIndex = (int)MysteryShipRegionIndexEdit.EditValue;
            Config.MysteryShipOpen = (int)MysteryShipOpenEdit.EditValue;
            Config.神舰是否记录 = (bool)Chuanshifou.EditValue;
            Config.神舰记录名称 = (string)Chuanjiluming.EditValue;
            Config.LairRegionIndex = (int)LairRegionIndexEdit.EditValue;
            Config.LairRegionOpen = (int)LairRegionOpenEdit.EditValue;
            Config.熔岩是否记录 = (bool)Rongyanshifou.EditValue;
            Config.熔岩记录名称 = (string)Rongyanjiluming.EditValue;
            Config.Yaota = (int)yaotaEdit.EditValue;
            Config.YaotaOpen = (int)YaotaOpenEdit.EditValue;
            Config.比奇地下城是否记录 = (bool)Yaotashifou.EditValue;
            Config.比奇地下城记录名称 = (string)Yaotajiluming.EditValue;
            Config.Mota = (int)MotaEdit.EditValue;
            Config.MotaOpen = (int)MotaOpenEdit.EditValue;
            Config.魔虫洞是否记录 = (bool)Motashifou.EditValue;
            Config.魔虫洞记录名称 = (string)Motajiluming.EditValue;
            Config.Huodong01 = (int)Huodong01Edit.EditValue;
            Config.Huodong01Open = (int)Huodong01OpenEdit.EditValue;
            Config.活动01是否记录 = (bool)Hd01shifou.EditValue;
            Config.活动01记录名称 = (string)Hd01jiluming.EditValue;
            Config.Huodong02 = (int)Huodong02Edit.EditValue;
            Config.Huodong02Open = (int)Huodong02OpenEdit.EditValue;
            Config.活动02是否记录 = (bool)Hd02shifou.EditValue;
            Config.活动02记录名称 = (string)Hd02jiluming.EditValue;
            Config.Huodong03 = (int)Huodong03Edit.EditValue;
            Config.Huodong03Open = (int)Huodong03OpenEdit.EditValue;
            Config.活动03是否记录 = (bool)Hd03shifou.EditValue;
            Config.活动03记录名称 = (string)Hd03jiluming.EditValue;
            Config.Huodong04 = (int)Huodong04Edit.EditValue;
            Config.Huodong04Open = (int)Huodong04OpenEdit.EditValue;
            Config.活动04是否记录 = (bool)Hd04shifou.EditValue;
            Config.活动04记录名称 = (string)Hd04jiluming.EditValue;
            Config.Huodong05 = (int)Huodong05Edit.EditValue;
            Config.Huodong05Open = (int)Huodong05OpenEdit.EditValue;
            Config.活动05是否记录 = (bool)Hd05shifou.EditValue;
            Config.活动05记录名称 = (string)Hd05jiluming.EditValue;
            Config.Huodong06 = (int)Huodong06Edit.EditValue;
            Config.Huodong06Open = (int)Huodong06OpenEdit.EditValue;
            Config.活动06是否记录 = (bool)Hd06shifou.EditValue;
            Config.活动06记录名称 = (string)Hd06jiluming.EditValue;
            Config.Huodong07 = (int)Huodong07Edit.EditValue;
            Config.Huodong07Open = (int)Huodong07OpenEdit.EditValue;
            Config.活动07是否记录 = (bool)Hd07shifou.EditValue;
            Config.活动07记录名称 = (string)Hd07jiluming.EditValue;
            Config.Huodong08 = (int)Huodong08Edit.EditValue;
            Config.Huodong08Open = (int)Huodong08OpenEdit.EditValue;
            Config.活动08是否记录 = (bool)Hd08shifou.EditValue;
            Config.活动08记录名称 = (string)Hd08jiluming.EditValue;
            Config.Huodong09 = (int)Huodong09Edit.EditValue;
            Config.Huodong09Open = (int)Huodong09OpenEdit.EditValue;
            Config.活动09是否记录 = (bool)Hd09shifou.EditValue;
            Config.活动09记录名称 = (string)Hd09jiluming.EditValue;
            Config.Huodong10 = (int)Huodong10Edit.EditValue;
            Config.Huodong10Open = (int)Huodong10OpenEdit.EditValue;
            Config.活动10是否记录 = (bool)Hd10shifou.EditValue;
            Config.活动10记录名称 = (string)Hd10jiluming.EditValue;
            Config.Huodong11 = (int)Huodong11Edit.EditValue;
            Config.Huodong11Open = (int)Huodong11OpenEdit.EditValue;
            Config.活动11是否记录 = (bool)Hd11shifou.EditValue;
            Config.活动11记录名称 = (string)Hd11jiluming.EditValue;
            Config.Huodong12 = (int)Huodong12Edit.EditValue;
            Config.Huodong12Open = (int)Huodong12OpenEdit.EditValue;
            Config.活动12是否记录 = (bool)Hd12shifou.EditValue;
            Config.活动12记录名称 = (string)Hd12jiluming.EditValue;
            Config.是否开启刷怪时间波动 = (bool)ShuaguaiBodong.EditValue;

            
            Config.是否挖矿物品绑定 = (bool)wakuangbangding.EditValue;
            Config.DropDuration = (TimeSpan)DropDurationEdit.EditValue;
            Config.DropDistance = (int)DropDistanceEdit.EditValue;
            Config.DropLayers = (int)DropLayersEdit.EditValue;
            Config.TorchRate = (int)TorchRateEdit.EditValue;
            Config.SpecialRepairDelay = (TimeSpan)SpecialRepairDelayEdit.EditValue;
            Config.MaxLuck = (int)MaxLuckEdit.EditValue;
            Config.LuckRate = (int)LuckRateEdit.EditValue;
            Config.MaxCurse = (int)MaxCurseEdit.EditValue;
            Config.宝箱抽奖 = (int)LabelControl88TaxSani.EditValue;
            Config.宝箱重置 = (int)LabelControl90TaxSani.EditValue;
            Config.每天免费挂机时间 = (int)Mfguajishijianzi.EditValue;
            Config.极品的爆率 = (int)Jipindebaolv.EditValue;
            Config.极品的大小1 = (int)Jipindaxiaoy.EditValue;
            Config.极品的大小2 = (int)Jipindaxiaoe.EditValue;
            Config.极品的大小3 = (int)Jipindaxiaos.EditValue;
            Config.极品的大小4 = (int)Jipindaxiaosi.EditValue;
            Config.极品的大小5 = (int)Jipindaxiaow.EditValue;
            Config.极品的大小6 = (int)Jipindaxiaol.EditValue;
            Config.武器攻击自然灵魂大小产生概率1 = (int)Jipindaxiaogailvy.EditValue;
            Config.武器攻击自然灵魂大小产生概率2 = (int)Jipindaxiaogailve.EditValue;
            Config.武器攻击自然灵魂大小产生概率3 = (int)Jipindaxiaogailvs.EditValue;
            Config.武器攻击自然灵魂大小产生概率4 = (int)Jipindaxiaogailvsi.EditValue;
            Config.武器攻击自然灵魂大小产生概率5 = (int)Jipindaxiaogailvw.EditValue;
            Config.武器攻击自然灵魂大小产生概率6 = (int)Jipindaxiaogailvl.EditValue;
            Config.所有攻击元素极品大小产生概率1 = (int)GyJipindaxiaogailvy.EditValue;
            Config.所有攻击元素极品大小产生概率2 = (int)GyJipindaxiaogailve.EditValue;
            Config.所有攻击元素极品大小产生概率3 = (int)GyJipindaxiaogailvs.EditValue;
            Config.所有攻击元素极品大小产生概率4 = (int)GyJipindaxiaogailvsi.EditValue;
            Config.所有攻击元素极品大小产生概率5 = (int)GyJipindaxiaogailvw.EditValue;
            Config.所有攻击元素极品大小产生概率6 = (int)GyJipindaxiaogailvl.EditValue;
            Config.盾牌攻击自然灵魂格挡闪避毒系抵抗几率的大小生产概率1 = (int)DunJipindaxiaogailvy.EditValue;
            Config.盾牌攻击自然灵魂格挡闪避毒系抵抗几率的大小生产概率2 = (int)DunJipindaxiaogailve.EditValue;
            Config.盾牌攻击自然灵魂格挡闪避毒系抵抗几率的大小生产概率3 = (int)DunJipindaxiaogailvs.EditValue;
            Config.盾牌攻击自然灵魂格挡闪避毒系抵抗几率的大小生产概率4 = (int)DunJipindaxiaogailvsi.EditValue;
            Config.盾牌攻击自然灵魂格挡闪避毒系抵抗几率的大小生产概率5 = (int)DunJipindaxiaogailvw.EditValue;
            Config.盾牌攻击自然灵魂格挡闪避毒系抵抗几率的大小生产概率6 = (int)DunJipindaxiaogailvl.EditValue;
            Config.衣服戒指防御魔御戒指拾取范围的大小生产概率1 = (int)YiJipindaxiaogailvy.EditValue;
            Config.衣服戒指防御魔御戒指拾取范围的大小生产概率2 = (int)YiJipindaxiaogailve.EditValue;
            Config.衣服戒指防御魔御戒指拾取范围的大小生产概率3 = (int)YiJipindaxiaogailvs.EditValue;
            Config.衣服戒指防御魔御戒指拾取范围的大小生产概率4 = (int)YiJipindaxiaogailvsi.EditValue;
            Config.衣服戒指防御魔御戒指拾取范围的大小生产概率5 = (int)YiJipindaxiaogailvw.EditValue;
            Config.衣服戒指防御魔御戒指拾取范围的大小生产概率6 = (int)YiJipindaxiaogailvl.EditValue;
            Config.头防魔首饰攻自灵链手准确敏捷鞋子舒适的大小生产概率1 = (int)TouJipindaxiaogailvy.EditValue;
            Config.头防魔首饰攻自灵链手准确敏捷鞋子舒适的大小生产概率2 = (int)TouJipindaxiaogailve.EditValue;
            Config.头防魔首饰攻自灵链手准确敏捷鞋子舒适的大小生产概率3 = (int)TouJipindaxiaogailvs.EditValue;
            Config.头防魔首饰攻自灵链手准确敏捷鞋子舒适的大小生产概率4 = (int)TouJipindaxiaogailvsi.EditValue;
            Config.头防魔首饰攻自灵链手准确敏捷鞋子舒适的大小生产概率5 = (int)TouJipindaxiaogailvw.EditValue;
            Config.头防魔首饰攻自灵链手准确敏捷鞋子舒适的大小生产概率6 = (int)TouJipindaxiaogailvl.EditValue;
            Config.鞋子手镯防御魔御的大小生产概率1 = (int)XieJipindaxiaogailvy.EditValue;
            Config.鞋子手镯防御魔御的大小生产概率2 = (int)XieJipindaxiaogailve.EditValue;
            Config.鞋子手镯防御魔御的大小生产概率3 = (int)XieJipindaxiaogailvs.EditValue;
            Config.鞋子手镯防御魔御的大小生产概率4 = (int)XieJipindaxiaogailvsi.EditValue;
            Config.鞋子手镯防御魔御的大小生产概率5 = (int)XieJipindaxiaogailvw.EditValue;
            Config.鞋子手镯防御魔御的大小生产概率6 = (int)XieJipindaxiaogailvl.EditValue;
            Config.CurseRate = (int)CurseRateEdit.EditValue;
            Config.MaxStrength = (int)MaxStrengthEdit.EditValue;
            Config.StrengthAddRate = (int)StrengthAddRateEdit.EditValue;
            Config.StrengthLossRate = (int)StrengthLossRateEdit.EditValue;

            
            Config.ExperienceRate = (int)ExperienceRateEdit.EditValue;
            Config.额外经验加成 = (int)Ewaijingyan.EditValue;
            Config.是否开启额外经验加成 = (bool)EwaijingyanOK.EditValue;
            Config.DropRate = (int)DropRateEdit.EditValue;
            Config.额外爆率加成 = (int)Ewaibaolv.EditValue;
            Config.是否开启额外爆率加成 = (bool)EwaibaolvOK.EditValue;
            Config.GoldRate = (int)GoldRateEdit.EditValue;
            Config.额外金币加成 = (int)Ewaijinbi.EditValue;
            Config.是否开启额外金币加成 = (bool)EwaijinbiOK.EditValue;
            Config.SkillRate = (int)SkillRateEdit.EditValue;
            Config.CompanionRate = (int)CompanionRateEdit.EditValue;
            Config.Jinglianchenggonglv = (int)Jingliancglvc.EditValue;
            Config.Jingyanquan3039 = (int)Ghquanc3039.EditValue;
            Config.Jingyanquan4049 = (int)Ghquanc4049.EditValue;
            Config.Jingyanquan5059 = (int)Ghquanc5059.EditValue;
            Config.Jingyanquan6069 = (int)Ghquanc6069.EditValue;
            Config.Jingyanquan7079 = (int)Ghquanc7079.EditValue;
            Config.Jingyanquan8089 = (int)Ghquanc8089.EditValue;
            Config.Jingyanquan9099 = (int)Ghquanc9099.EditValue;
            Config.Jingyanquan0109 = (int)Ghquanc0109.EditValue;
            Config.Jingyanquan1019 = (int)Ghquanc1019.EditValue;
            Config.Jingyanquan2029 = (int)Ghquanc2029.EditValue;
            Config.青铜会员经验 = (int)Gjbsshu.EditValue;
            Config.青铜会员爆率 = (int)Zrbsshu.EditValue;
            Config.青铜会员金币 = (int)Lhbsshu.EditValue;
            Config.白银会员经验 = (int)Gjjlbsshu.EditValue;
            Config.白银会员爆率 = (int)Zrjlbsshu.EditValue;
            Config.白银会员金币 = (int)Lhjlbsshu.EditValue;
            Config.黄金会员经验 = (int)Smjlbsshu.EditValue;
            Config.黄金会员爆率 = (int)Mfbsshu.EditValue;
            Config.黄金会员金币 = (int)Sdbsshu.EditValue;
            Config.青铜回收倍率 = (int)Fybsshu.EditValue;
            Config.白银回收倍率 = (int)Mybsshu.EditValue;
            Config.黄金回收倍率 = (int)Jybsshu.EditValue;
            Config.武器基础爆率 = (int)Xxbsshu.EditValue;
            Config.衣服基础爆率 = (int)Ghuoshu.EditValue;
            Config.头盔基础爆率 = (int)Gbingshu.EditValue;
            Config.项链基础爆率 = (int)Gleishu.EditValue;
            Config.手镯基础爆率 = (int)Gfengshu.EditValue;
            Config.戒指基础爆率 = (int)Gshengshu.EditValue;
            Config.靴子基础爆率 = (int)Ganshu.EditValue;
            Config.矿石基础爆率 = (int)Ghuanshu.EditValue;
            Config.书籍基础爆率 = (int)Qhuoshu.EditValue;
            Config.盾牌基础爆率 = (int)Qbingshu.EditValue;
            Config.徽章基础爆率 = (int)Qleishu.EditValue;
            Config.宝石基础爆率 = (int)Qfengshu.EditValue;
            Config.轴卷基础爆率 = (int)Qshenshu.EditValue;
            Config.公会泉回收经验3039 = (int)Qanshu.EditValue;
            Config.公会泉回收经验4049 = (int)Qhuanshu.EditValue;
            Config.公会泉回收经验5059 = (int)Qmofadunshu.EditValue;
            Config.公会泉回收经验6069 = (int)Qbingdongshu.EditValue;
            Config.公会泉回收经验7079 = (int)Qmabishu.EditValue;
            Config.公会泉回收经验8089 = (int)Qyidongshu.EditValue;
            Config.公会泉回收经验90以上 = (int)Qchenmoshu.EditValue;
            Config.公会泉回收经验0109 = (int)Qgedangshu.EditValue;
            Config.公会泉回收经验1019 = (int)Qduobishu.EditValue;
            Config.公会泉回收经验2029 = (int)Lvdushu.EditValue;
            Config.介绍人等级10时 = (int)Jieshaorendjshishu.EditValue;
            Config.介绍人等级20时 = (int)Jieshaorendjershishu.EditValue;
            Config.介绍人等级30时 = (int)Jieshaorendjsanshishu.EditValue;
            Config.介绍人等级40时 = (int)Jieshaorendjsishishu.EditValue;
            Config.介绍人等级50时 = (int)Jieshaorendjwushishu.EditValue;
            Config.被介绍人第一阶段等级 = (int)Bjieshaorendjshu.EditValue;
            Config.被介绍人第一阶段赏金 = (int)Bjieshaorensjshu.EditValue;
            Config.被介绍人第一阶段声望 = (int)Bjieshaorenswshu.EditValue;
            Config.介绍人第一阶段赏金 = (int)Jieshaorensjshu.EditValue;
            Config.介绍人第一阶段声望 = (int)Jieshaorenswshu.EditValue;
            Config.被介绍人第二阶段等级 = (int)Bjieshaorendjeshu.EditValue;
            Config.被介绍人第二阶段赏金 = (int)Bjieshaorensjeshu.EditValue;
            Config.被介绍人第二阶段声望 = (int)Bjieshaorensweshu.EditValue;
            Config.介绍人第二阶段赏金 = (int)Jieshaorensjeshu.EditValue;
            Config.介绍人第二阶段声望 = (int)Jieshaorensweshu.EditValue;
            Config.被介绍人第三阶段等级 = (int)Bjieshaorendjsshu.EditValue;
            Config.被介绍人第三阶段赏金 = (int)Bjieshaorensjsshu.EditValue;
            Config.被介绍人第三阶段声望 = (int)Bjieshaorenswsshu.EditValue;
            Config.介绍人第三阶段赏金 = (int)Jieshaorensjsshu.EditValue;
            Config.介绍人第三阶段声望 = (int)Jieshaorenswsshu.EditValue;
            Config.被介绍人第四阶段等级 = (int)Bjieshaorendjsishu.EditValue;
            Config.被介绍人第四阶段赏金 = (int)Bjieshaorensjsishu.EditValue;
            Config.被介绍人第四阶段声望 = (int)Bjieshaorenswsishu.EditValue;
            Config.介绍人第四阶段赏金 = (int)Jieshaorensjsishu.EditValue;
            Config.介绍人第四阶段声望 = (int)Jieshaorenswsishu.EditValue;
            Config.新收公会角色等级低于 = (int)XGuilddjshu.EditValue;
            Config.新收公会经验加成 = (int)XGuildjyshu.EditValue;
            Config.新收公会爆率加成 = (int)XGuildblshu.EditValue;
            Config.新收公会金币加成 = (int)XGuildjbshu.EditValue;
            Config.其他公会人数限制一 = (int)YiGuildrsshu.EditValue;
            Config.其他公会经验加成一 = (int)YiGuildjyshu.EditValue;
            Config.其他公会爆率加成一 = (int)YiGuildblshu.EditValue;
            Config.其他公会金币加成一 = (int)YiGuildjbshu.EditValue;
            Config.其他公会人数限制二 = (int)ErGuildrsshu.EditValue;
            Config.其他公会经验加成二 = (int)ErGuildjyshu.EditValue;
            Config.其他公会爆率加成二 = (int)ErGuildblshu.EditValue;
            Config.其他公会金币加成二 = (int)ErGuildjbshu.EditValue;
            Config.其他公会人数限制三 = (int)SanGuildrsshu.EditValue;
            Config.其他公会经验加成三 = (int)SanGuildjyshu.EditValue;
            Config.其他公会爆率加成三 = (int)SanGuildblshu.EditValue;
            Config.其他公会金币加成三 = (int)SanGuildjbshu.EditValue;
            Config.其他公会人数限制四 = (int)SiGuildrsshu.EditValue;
            Config.其他公会经验加成四 = (int)SiGuildjyshu.EditValue;
            Config.其他公会爆率加成四 = (int)SiGuildblshu.EditValue;
            Config.其他公会金币加成四 = (int)SiGuildjbshu.EditValue;
            Config.沙巴克公会经验加成 = (int)ShaGuildjyshu.EditValue;
            Config.沙巴克公会爆率加成 = (int)ShaGuildblshu.EditValue;
            Config.沙巴克公会金币加成 = (int)ShaGuildjbshu.EditValue;


            if (SEnvir.Started)
            {
                SEnvir.ServerBuffChanged = true;
            }




            ConfigReader.Save();
        }


        private void SaveButton_ItemClick(object sender, ItemClickEventArgs e)
        {
            SaveSettings();
        }
        private void ReloadButton_ItemClick(object sender, ItemClickEventArgs e)
        {
            LoadSettings();
        }


        private void CheckVersionButton_Click(object sender, EventArgs e)
        {
            byte[] old = Config.ClientHash;

            Config.LoadVersion();

            if (Functions.IsMatch(old, Config.ClientHash) || !SEnvir.Started) return;

            SEnvir.Broadcast(new S.Chat { Text = "已提供新版本，请尽快更新。", Type = MessageType.Announcement });
        }
        private void VersionPathEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (OpenDialog.ShowDialog() != DialogResult.OK) return;

            VersionPathEdit.EditValue = OpenDialog.FileName;
        }
        private void MapPathEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (FolderDialog.ShowDialog() != DialogResult.OK) return;

            MapPathEdit.EditValue = FolderDialog.SelectedPath;
        }

        private void ClientPathEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (FolderDialog.ShowDialog() != DialogResult.OK) return;

            ClientPathEdit.EditValue = FolderDialog.SelectedPath;
        }

        private void MergeButton_Click(object sender, EventArgs e)
        {
        }

        private void ServerMergeEdit_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (FolderDialog.ShowDialog() != DialogResult.OK)
                return;
            ServerMergeEdit.EditValue = FolderDialog.SelectedPath;
        }
    }
}