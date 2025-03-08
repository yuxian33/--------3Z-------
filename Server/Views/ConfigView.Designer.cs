using DevExpress.Utils;
using DevExpress.Utils.Menu;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Mask;
using System.Windows.Forms;

namespace Server.Views
{
    partial class ConfigView
    {
        
        
        
        private System.ComponentModel.IContainer components = null;
        
        
        
        
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        
        
        
        
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigView));
            ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            SaveButton = new DevExpress.XtraBars.BarButtonItem();
            ReloadButton = new DevExpress.XtraBars.BarButtonItem();
            ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            PacketBanTimeEdit = new DevExpress.XtraEditors.TimeSpanEdit();
            SyncronizeButton = new DevExpress.XtraEditors.SimpleButton();
            labelControl86 = new DevExpress.XtraEditors.LabelControl();
            labelControl87 = new DevExpress.XtraEditors.LabelControl();
            MaxPacketEdit = new DevExpress.XtraEditors.TextEdit();
            labelControl51 = new DevExpress.XtraEditors.LabelControl();
            UserCountPortEdit = new DevExpress.XtraEditors.TextEdit();
            labelControl6 = new DevExpress.XtraEditors.LabelControl();
            PingDelayEdit = new DevExpress.XtraEditors.TimeSpanEdit();
            TimeOutEdit = new DevExpress.XtraEditors.TimeSpanEdit();
            labelControl3 = new DevExpress.XtraEditors.LabelControl();
            labelControl2 = new DevExpress.XtraEditors.LabelControl();
            PortEdit = new DevExpress.XtraEditors.TextEdit();
            IPAddressEdit = new DevExpress.XtraEditors.TextEdit();
            labelControl1 = new DevExpress.XtraEditors.LabelControl();
            xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            Dinghaoxiugaimima = new DevExpress.XtraEditors.LabelControl();
            Dinghaoxiugaimimaok = new DevExpress.XtraEditors.CheckEdit();
            labelControl16 = new DevExpress.XtraEditors.LabelControl();
            AllowRequestActivationEdit = new DevExpress.XtraEditors.CheckEdit();
            labelControl22 = new DevExpress.XtraEditors.LabelControl();
            AllowWebActivationEdit = new DevExpress.XtraEditors.CheckEdit();
            labelControl17 = new DevExpress.XtraEditors.LabelControl();
            AllowManualActivationEdit = new DevExpress.XtraEditors.CheckEdit();
            labelControl18 = new DevExpress.XtraEditors.LabelControl();
            AllowDeleteAccountEdit = new DevExpress.XtraEditors.CheckEdit();
            labelControl19 = new DevExpress.XtraEditors.LabelControl();
            AllowManualResetPasswordEdit = new DevExpress.XtraEditors.CheckEdit();
            labelControl20 = new DevExpress.XtraEditors.LabelControl();
            AllowWebResetPasswordEdit = new DevExpress.XtraEditors.CheckEdit();
            labelControl21 = new DevExpress.XtraEditors.LabelControl();
            AllowRequestPasswordResetEdit = new DevExpress.XtraEditors.CheckEdit();
            labelControl40 = new DevExpress.XtraEditors.LabelControl();
            AllowWizardEdit = new DevExpress.XtraEditors.CheckEdit();
            labelControl39 = new DevExpress.XtraEditors.LabelControl();
            AllowTaoistEdit = new DevExpress.XtraEditors.CheckEdit();
            Shangxianxiaxiantishizi = new DevExpress.XtraEditors.LabelControl();
            Shangxianxiaxiantishi = new DevExpress.XtraEditors.CheckEdit();
            Xinjuesetishizi = new DevExpress.XtraEditors.LabelControl();
            Xinjuesetishi = new DevExpress.XtraEditors.CheckEdit();
            labelControl38 = new DevExpress.XtraEditors.LabelControl();
            AllowAssassinEdit = new DevExpress.XtraEditors.CheckEdit();
            labelControl36 = new DevExpress.XtraEditors.LabelControl();
            AllowWarriorEdit = new DevExpress.XtraEditors.CheckEdit();
            ShifouNeicezi = new DevExpress.XtraEditors.LabelControl();
            ShifouNeice = new DevExpress.XtraEditors.CheckEdit();
            ShifouGongcezi = new DevExpress.XtraEditors.LabelControl();
            ShifouGongce = new DevExpress.XtraEditors.CheckEdit();
            GuajixunzhaodiyiZi = new DevExpress.XtraEditors.LabelControl();
            Guajixunzhaodiyi = new DevExpress.XtraEditors.CheckEdit();
            GuajixunzhaodierZi = new DevExpress.XtraEditors.LabelControl();
            Guajixunzhaodier = new DevExpress.XtraEditors.CheckEdit();
            labelControl15 = new DevExpress.XtraEditors.LabelControl();
            RelogDelayEdit = new DevExpress.XtraEditors.TimeSpanEdit();
            labelControl14 = new DevExpress.XtraEditors.LabelControl();
            AllowStartGameEdit = new DevExpress.XtraEditors.CheckEdit();
            labelControl12 = new DevExpress.XtraEditors.LabelControl();
            AllowDeleteCharacterEdit = new DevExpress.XtraEditors.CheckEdit();
            labelControl11 = new DevExpress.XtraEditors.LabelControl();
            AllowNewCharacterEdit = new DevExpress.XtraEditors.CheckEdit();
            labelControl9 = new DevExpress.XtraEditors.LabelControl();
            AllowLoginEdit = new DevExpress.XtraEditors.CheckEdit();
            labelControl8 = new DevExpress.XtraEditors.LabelControl();
            AllowChangePasswordEdit = new DevExpress.XtraEditors.CheckEdit();
            labelControl7 = new DevExpress.XtraEditors.LabelControl();
            AllowNewAccountEdit = new DevExpress.XtraEditors.CheckEdit();
            xtraTabPage3 = new DevExpress.XtraTab.XtraTabPage();
            GuanggaoGaoduok = new DevExpress.XtraEditors.TextEdit();
            GuanggaoKuanduok = new DevExpress.XtraEditors.TextEdit();
            Biaomingok = new DevExpress.XtraEditors.TextEdit();
            ShenmiNpcTimezi = new DevExpress.XtraEditors.LabelControl();
            ShenmiNpcTime = new DevExpress.XtraEditors.TextEdit();
            Huodonglan = new DevExpress.XtraEditors.LabelControl();
            Huodonglanok = new DevExpress.XtraEditors.CheckEdit();
            Yijianhequ = new DevExpress.XtraEditors.SimpleButton();
            Jueseshujukuhequ = new DevExpress.XtraEditors.ButtonEdit();
            Jueseshujukuhequzi = new DevExpress.XtraEditors.LabelControl();
            XingyunNPC = new DevExpress.XtraEditors.LabelControl();
            XingyunNPCOK = new DevExpress.XtraEditors.CheckEdit();
            Tishiok = new DevExpress.XtraEditors.TextEdit();
            Tishi = new DevExpress.XtraEditors.LabelControl();
            Daojishi = new DevExpress.XtraEditors.LabelControl();
            Daojishiok = new DevExpress.XtraEditors.CheckEdit();
            RabbitEventEndEdit = new DevExpress.XtraEditors.TextEdit();
            labelControl85 = new DevExpress.XtraEditors.LabelControl();
            ReleaseDateEdit = new DevExpress.XtraEditors.TextEdit();
            labelControl70 = new DevExpress.XtraEditors.LabelControl();
            ClientPathEdit = new DevExpress.XtraEditors.ButtonEdit();
            labelControl96 = new DevExpress.XtraEditors.LabelControl();
            MasterPasswordEdit = new DevExpress.XtraEditors.TextEdit();
            labelControl67 = new DevExpress.XtraEditors.LabelControl();
            MapPathEdit = new DevExpress.XtraEditors.ButtonEdit();
            labelControl13 = new DevExpress.XtraEditors.LabelControl();
            labelControl10 = new DevExpress.XtraEditors.LabelControl();
            DBSaveDelayEdit = new DevExpress.XtraEditors.TimeSpanEdit();
            CheckVersionButton = new DevExpress.XtraEditors.SimpleButton();
            VersionPathEdit = new DevExpress.XtraEditors.ButtonEdit();
            labelControl5 = new DevExpress.XtraEditors.LabelControl();
            labelControl4 = new DevExpress.XtraEditors.LabelControl();
            CheckVersionEdit = new DevExpress.XtraEditors.CheckEdit();
            xtraTabPage4 = new DevExpress.XtraTab.XtraTabPage();
            MailDisplayNameEdit = new DevExpress.XtraEditors.TextEdit();
            labelControl31 = new DevExpress.XtraEditors.LabelControl();
            MailFromEdit = new DevExpress.XtraEditors.TextEdit();
            labelControl30 = new DevExpress.XtraEditors.LabelControl();
            MailPasswordEdit = new DevExpress.XtraEditors.TextEdit();
            labelControl29 = new DevExpress.XtraEditors.LabelControl();
            MailAccountEdit = new DevExpress.XtraEditors.TextEdit();
            labelControl28 = new DevExpress.XtraEditors.LabelControl();
            labelControl27 = new DevExpress.XtraEditors.LabelControl();
            MailUseSSLEdit = new DevExpress.XtraEditors.CheckEdit();
            labelControl25 = new DevExpress.XtraEditors.LabelControl();
            MailPortEdit = new DevExpress.XtraEditors.TextEdit();
            MailServerEdit = new DevExpress.XtraEditors.TextEdit();
            labelControl26 = new DevExpress.XtraEditors.LabelControl();
            xtraTabPage5 = new DevExpress.XtraTab.XtraTabPage();
            labelControl81 = new DevExpress.XtraEditors.LabelControl();
            AllowBuyGammeGoldEdit = new DevExpress.XtraEditors.CheckEdit();
            labelControl97 = new DevExpress.XtraEditors.LabelControl();
            RequireActivationEdit = new DevExpress.XtraEditors.CheckEdit();
            labelControl80 = new DevExpress.XtraEditors.LabelControl();
            ProcessGameGoldEdit = new DevExpress.XtraEditors.CheckEdit();
            ReceiverEMailEdit = new DevExpress.XtraEditors.TextEdit();
            labelControl79 = new DevExpress.XtraEditors.LabelControl();
            IPNPrefixEdit = new DevExpress.XtraEditors.TextEdit();
            labelControl73 = new DevExpress.XtraEditors.LabelControl();
            BuyAddressEdit = new DevExpress.XtraEditors.TextEdit();
            labelControl72 = new DevExpress.XtraEditors.LabelControl();
            BuyPrefixEdit = new DevExpress.XtraEditors.TextEdit();
            labelControl71 = new DevExpress.XtraEditors.LabelControl();
            DeleteFailLinkEdit = new DevExpress.XtraEditors.TextEdit();
            labelControl37 = new DevExpress.XtraEditors.LabelControl();
            DeleteSuccessLinkEdit = new DevExpress.XtraEditors.TextEdit();
            labelControl43 = new DevExpress.XtraEditors.LabelControl();
            ResetFailLinkEdit = new DevExpress.XtraEditors.TextEdit();
            labelControl32 = new DevExpress.XtraEditors.LabelControl();
            ResetSuccessLinkEdit = new DevExpress.XtraEditors.TextEdit();
            labelControl33 = new DevExpress.XtraEditors.LabelControl();
            ActivationFailLinkEdit = new DevExpress.XtraEditors.TextEdit();
            labelControl34 = new DevExpress.XtraEditors.LabelControl();
            ActivationSuccessLinkEdit = new DevExpress.XtraEditors.TextEdit();
            labelControl35 = new DevExpress.XtraEditors.LabelControl();
            labelControl41 = new DevExpress.XtraEditors.LabelControl();
            WebCommandLinkEdit = new DevExpress.XtraEditors.TextEdit();
            WebPrefixEdit = new DevExpress.XtraEditors.TextEdit();
            labelControl42 = new DevExpress.XtraEditors.LabelControl();
            xtraTabPage6 = new DevExpress.XtraTab.XtraTabPage();
            Hongmingwupindiaobv = new DevExpress.XtraEditors.TextEdit();
            Hongmingwupindiaobvzi = new DevExpress.XtraEditors.LabelControl();
            Putongwupindiaobv = new DevExpress.XtraEditors.TextEdit();
            Putongwupindiaobvzi = new DevExpress.XtraEditors.LabelControl();
            Xishiwupindiaobv = new DevExpress.XtraEditors.TextEdit();
            Xishiwupindiaobvzi = new DevExpress.XtraEditors.LabelControl();
            Gaojiwupindiaobv = new DevExpress.XtraEditors.TextEdit();
            Gaojiwupindiaobvzi = new DevExpress.XtraEditors.LabelControl();
            Baoguodiaobv = new DevExpress.XtraEditors.TextEdit();
            Baoguodiaobvzi = new DevExpress.XtraEditors.LabelControl();
            BeiguaiSiwangbaolvzi = new DevExpress.XtraEditors.LabelControl();
            BeiguaiSiwangbaolv = new DevExpress.XtraEditors.CheckEdit();
            MingwenBangdingzi = new DevExpress.XtraEditors.LabelControl();
            MingwenBangding = new DevExpress.XtraEditors.CheckEdit();
            Sanmingwenzi = new DevExpress.XtraEditors.LabelControl();
            Sanmingwen = new DevExpress.XtraEditors.CheckEdit();
            Siwangbaolvzi = new DevExpress.XtraEditors.LabelControl();
            Siwangbaolv = new DevExpress.XtraEditors.CheckEdit();
            KaiqiBaoshi5432zi = new DevExpress.XtraEditors.LabelControl();
            KaiqiBaoshi5432 = new DevExpress.XtraEditors.CheckEdit();
            Huanhuabangdingzi = new DevExpress.XtraEditors.LabelControl();
            Huanhuabangding = new DevExpress.XtraEditors.CheckEdit();
            ZhuangbeiHuanhuazi = new DevExpress.XtraEditors.LabelControl();
            ZhuangbeiHuanhua = new DevExpress.XtraEditors.CheckEdit();
            Liujizhuanshengzi = new DevExpress.XtraEditors.LabelControl();
            Liujizhuansheng = new DevExpress.XtraEditors.CheckEdit();
            ZaixianFenjiezi = new DevExpress.XtraEditors.LabelControl();
            ZaixianFenjie = new DevExpress.XtraEditors.TextEdit();
            GunghuiGerenPaihangzi = new DevExpress.XtraEditors.LabelControl();
            GunghuiGerenPaihang = new DevExpress.XtraEditors.CheckEdit();
            GunghuiPaihangzi = new DevExpress.XtraEditors.LabelControl();
            GunghuiPaihang = new DevExpress.XtraEditors.CheckEdit();
            XinshouLiwuzi = new DevExpress.XtraEditors.LabelControl();
            XinshouLiwu = new DevExpress.XtraEditors.CheckEdit();
            GuildLevelzi = new DevExpress.XtraEditors.LabelControl();
            GuildLevel = new DevExpress.XtraEditors.CheckEdit();
            labelControl91 = new DevExpress.XtraEditors.LabelControl();
            JihuowanjiaJYjiacheng = new DevExpress.XtraEditors.TextEdit();
            JYhuishouzi = new DevExpress.XtraEditors.LabelControl();
            JYhuishou = new DevExpress.XtraEditors.TextEdit();
            labelControl98 = new DevExpress.XtraEditors.LabelControl();
            YaoqiuJSRjihuozhanghao = new DevExpress.XtraEditors.CheckEdit();
            labelControl95 = new DevExpress.XtraEditors.LabelControl();
            Jieshaorenzubeijsrgerenjingyan = new DevExpress.XtraEditors.TextEdit();
            labelControl94 = new DevExpress.XtraEditors.LabelControl();
            Jieshaorenzubeijsrjingyan = new DevExpress.XtraEditors.TextEdit();
            labelControl93 = new DevExpress.XtraEditors.LabelControl();
            Jieshaorenzuxinrenjingyan = new DevExpress.XtraEditors.TextEdit();
            labelControl92 = new DevExpress.XtraEditors.LabelControl();
            Yunxujieshaoren = new DevExpress.XtraEditors.CheckEdit();
            labelControl69 = new DevExpress.XtraEditors.LabelControl();
            AutoReviveDelayEdit = new DevExpress.XtraEditors.TimeSpanEdit();
            daoshigroupBox1 = new GroupBox();
            ChuanranBosszi = new DevExpress.XtraEditors.LabelControl();
            ChuanranBoss = new DevExpress.XtraEditors.CheckEdit();
            ShidushuGuagouzi = new DevExpress.XtraEditors.LabelControl();
            ShidushuGuagou = new DevExpress.XtraEditors.CheckEdit();
            ShidushuMax = new TextEdit();
            ShidushuMaxzi = new LabelControl();
            cikegroupBox1 = new GroupBox();
            Yidaoyihuazi = new DevExpress.XtraEditors.LabelControl();
            Yidaoyihua = new DevExpress.XtraEditors.CheckEdit();
            Xiudikangzi = new DevExpress.XtraEditors.LabelControl();
            Xiudikang = new DevExpress.XtraEditors.CheckEdit();
            DikangEdit = new TextEdit();
            DikangEditZi = new LabelControl();
            SihuaEdit = new TextEdit();
            SihuaEditZi = new LabelControl();
            PvPCurseRateEdit = new DevExpress.XtraEditors.TextEdit();
            labelControl83 = new DevExpress.XtraEditors.LabelControl();
            labelControl84 = new DevExpress.XtraEditors.LabelControl();
            PvPCurseDurationEdit = new DevExpress.XtraEditors.TimeSpanEdit();
            RedPointEdit = new DevExpress.XtraEditors.TextEdit();
            labelControl77 = new DevExpress.XtraEditors.LabelControl();
            labelControl78 = new DevExpress.XtraEditors.LabelControl();
            PKPointTickRateEdit = new DevExpress.XtraEditors.TimeSpanEdit();
            PKPointRateEdit = new DevExpress.XtraEditors.TextEdit();
            labelControl76 = new DevExpress.XtraEditors.LabelControl();
            labelControl75 = new DevExpress.XtraEditors.LabelControl();
            BrownDurationEdit = new DevExpress.XtraEditors.TimeSpanEdit();
            labelControl99 = new DevExpress.XtraEditors.LabelControl();
            Shifoujilubaokaqingk = new DevExpress.XtraEditors.CheckEdit();
            labelControl24 = new DevExpress.XtraEditors.LabelControl();
            AllowObservationEdit = new DevExpress.XtraEditors.CheckEdit();
            SkillExpEdit = new DevExpress.XtraEditors.TextEdit();
            labelControl53 = new DevExpress.XtraEditors.LabelControl();
            DayCycleCountEdit = new DevExpress.XtraEditors.TextEdit();
            labelControl52 = new DevExpress.XtraEditors.LabelControl();
            MaxLevelEdit = new DevExpress.XtraEditors.TextEdit();
            labelControl46 = new DevExpress.XtraEditors.LabelControl();
            labelControl45 = new DevExpress.XtraEditors.LabelControl();
            GlobalDelayEdit = new DevExpress.XtraEditors.TimeSpanEdit();
            labelControl44 = new DevExpress.XtraEditors.LabelControl();
            ShoutDelayEdit = new DevExpress.XtraEditors.TimeSpanEdit();
            MaxViewRangeEdit = new DevExpress.XtraEditors.TextEdit();
            labelControl23 = new DevExpress.XtraEditors.LabelControl();
            xtraTabPage7 = new DevExpress.XtraTab.XtraTabPage();
            ShuaguaiBodongzi = new DevExpress.XtraEditors.LabelControl();
            ShuaguaiBodong = new DevExpress.XtraEditors.CheckEdit();
            Shifoujilu = new DevExpress.XtraEditors.LabelControl();
            Chuanshifou = new DevExpress.XtraEditors.CheckEdit();
            Rongyanshifou = new DevExpress.XtraEditors.CheckEdit();
            Yaotashifou = new DevExpress.XtraEditors.CheckEdit();
            Motashifou = new DevExpress.XtraEditors.CheckEdit();
            Hd01shifou = new DevExpress.XtraEditors.CheckEdit();
            Hd02shifou = new DevExpress.XtraEditors.CheckEdit();
            Hd03shifou = new DevExpress.XtraEditors.CheckEdit();
            Hd04shifou = new DevExpress.XtraEditors.CheckEdit();
            Hd05shifou = new DevExpress.XtraEditors.CheckEdit();
            Hd06shifou = new DevExpress.XtraEditors.CheckEdit();
            Hd07shifou = new DevExpress.XtraEditors.CheckEdit();
            Hd08shifou = new DevExpress.XtraEditors.CheckEdit();
            Hd09shifou = new DevExpress.XtraEditors.CheckEdit();
            Hd10shifou = new DevExpress.XtraEditors.CheckEdit();
            Hd11shifou = new DevExpress.XtraEditors.CheckEdit();
            Hd12shifou = new DevExpress.XtraEditors.CheckEdit();
            Wendangming = new DevExpress.XtraEditors.LabelControl();
            Chuanjiluming = new DevExpress.XtraEditors.TextEdit();
            Rongyanjiluming = new DevExpress.XtraEditors.TextEdit();
            Yaotajiluming = new DevExpress.XtraEditors.TextEdit();
            Motajiluming = new DevExpress.XtraEditors.TextEdit();
            Hd01jiluming = new DevExpress.XtraEditors.TextEdit();
            Hd02jiluming = new DevExpress.XtraEditors.TextEdit();
            Hd03jiluming = new DevExpress.XtraEditors.TextEdit();
            Hd04jiluming = new DevExpress.XtraEditors.TextEdit();
            Hd05jiluming = new DevExpress.XtraEditors.TextEdit();
            Hd06jiluming = new DevExpress.XtraEditors.TextEdit();
            Hd07jiluming = new DevExpress.XtraEditors.TextEdit();
            Hd08jiluming = new DevExpress.XtraEditors.TextEdit();
            Hd09jiluming = new DevExpress.XtraEditors.TextEdit();
            Hd10jiluming = new DevExpress.XtraEditors.TextEdit();
            Hd11jiluming = new DevExpress.XtraEditors.TextEdit();
            Hd12jiluming = new DevExpress.XtraEditors.TextEdit();
            Huodong12OpenEdit = new DevExpress.XtraEditors.TextEdit();
            Huodong11OpenEdit = new DevExpress.XtraEditors.TextEdit();
            Huodong10OpenEdit = new DevExpress.XtraEditors.TextEdit();
            Huodong09OpenEdit = new DevExpress.XtraEditors.TextEdit();
            Huodong08OpenEdit = new DevExpress.XtraEditors.TextEdit();
            Huodong07OpenEdit = new DevExpress.XtraEditors.TextEdit();
            Huodong06OpenEdit = new DevExpress.XtraEditors.TextEdit();
            Huodong05OpenEdit = new DevExpress.XtraEditors.TextEdit();
            Huodong04OpenEdit = new DevExpress.XtraEditors.TextEdit();
            Huodong03OpenEdit = new DevExpress.XtraEditors.TextEdit();
            Huodong02OpenEdit = new DevExpress.XtraEditors.TextEdit();
            Huodong01OpenEdit = new DevExpress.XtraEditors.TextEdit();
            MotaOpenEdit = new DevExpress.XtraEditors.TextEdit();
            YaotaOpenEdit = new DevExpress.XtraEditors.TextEdit();
            LairRegionOpenEdit = new DevExpress.XtraEditors.TextEdit();
            MysteryShipOpenEdit = new DevExpress.XtraEditors.TextEdit();
            labelControl315 = new DevExpress.XtraEditors.LabelControl();
            Huodong12Edit = new DevExpress.XtraEditors.LookUpEdit();
            labelControl314 = new DevExpress.XtraEditors.LabelControl();
            Huodong11Edit = new DevExpress.XtraEditors.LookUpEdit();
            labelControl312 = new DevExpress.XtraEditors.LabelControl();
            Huodong10Edit = new DevExpress.XtraEditors.LookUpEdit();
            labelControl310 = new DevExpress.XtraEditors.LabelControl();
            Huodong09Edit = new DevExpress.XtraEditors.LookUpEdit();
            labelControl308 = new DevExpress.XtraEditors.LabelControl();
            Huodong08Edit = new DevExpress.XtraEditors.LookUpEdit();
            labelControl306 = new DevExpress.XtraEditors.LabelControl();
            Huodong07Edit = new DevExpress.XtraEditors.LookUpEdit();
            labelControl304 = new DevExpress.XtraEditors.LabelControl();
            Huodong06Edit = new DevExpress.XtraEditors.LookUpEdit();
            labelControl302 = new DevExpress.XtraEditors.LabelControl();
            Huodong05Edit = new DevExpress.XtraEditors.LookUpEdit();
            labelControl300 = new DevExpress.XtraEditors.LabelControl();
            Huodong04Edit = new DevExpress.XtraEditors.LookUpEdit();
            labelControl298 = new DevExpress.XtraEditors.LabelControl();
            Huodong03Edit = new DevExpress.XtraEditors.LookUpEdit();
            labelControl296 = new DevExpress.XtraEditors.LabelControl();
            Huodong02Edit = new DevExpress.XtraEditors.LookUpEdit();
            labelControl294 = new DevExpress.XtraEditors.LabelControl();
            Huodong01Edit = new DevExpress.XtraEditors.LookUpEdit();
            labelControl292 = new DevExpress.XtraEditors.LabelControl();
            MotaEdit = new DevExpress.XtraEditors.LookUpEdit();
            labelControl290 = new DevExpress.XtraEditors.LabelControl();
            yaotaEdit = new DevExpress.XtraEditors.LookUpEdit();
            labelControl289 = new DevExpress.XtraEditors.LabelControl();
            LairRegionIndexEdit = new DevExpress.XtraEditors.LookUpEdit();
            labelControl82 = new DevExpress.XtraEditors.LabelControl();
            MysteryShipRegionIndexEdit = new DevExpress.XtraEditors.LookUpEdit();
            labelControl89 = new DevExpress.XtraEditors.LabelControl();
            labelControl74 = new DevExpress.XtraEditors.LabelControl();
            HarvestDurationEdit = new DevExpress.XtraEditors.TimeSpanEdit();
            labelControl47 = new DevExpress.XtraEditors.LabelControl();
            DeadDurationEdit = new DevExpress.XtraEditors.TimeSpanEdit();
            xtraTabPage8 = new DevExpress.XtraTab.XtraTabPage();
            StrengthLossRateEdit = new DevExpress.XtraEditors.TextEdit();
            labelControl64 = new DevExpress.XtraEditors.LabelControl();
            StrengthAddRateEdit = new DevExpress.XtraEditors.TextEdit();
            labelControl65 = new DevExpress.XtraEditors.LabelControl();
            MaxStrengthEdit = new DevExpress.XtraEditors.TextEdit();
            labelControl66 = new DevExpress.XtraEditors.LabelControl();
            CurseRateEdit = new DevExpress.XtraEditors.TextEdit();
            labelControl63 = new DevExpress.XtraEditors.LabelControl();
            labelControl88 = new DevExpress.XtraEditors.LabelControl();
            LabelControl88TaxSani = new DevExpress.XtraEditors.TextEdit();
            XieJipindaxiaogailvzi = new DevExpress.XtraEditors.LabelControl();
            XieJipindaxiaogailvy = new DevExpress.XtraEditors.TextEdit();
            XieJipindaxiaogailve = new DevExpress.XtraEditors.TextEdit();
            XieJipindaxiaogailvs = new DevExpress.XtraEditors.TextEdit();
            XieJipindaxiaogailvsi = new DevExpress.XtraEditors.TextEdit();
            XieJipindaxiaogailvw = new DevExpress.XtraEditors.TextEdit();
            XieJipindaxiaogailvl = new DevExpress.XtraEditors.TextEdit();
            TouJipindaxiaogailvzi = new DevExpress.XtraEditors.LabelControl();
            TouJipindaxiaogailvy = new DevExpress.XtraEditors.TextEdit();
            TouJipindaxiaogailve = new DevExpress.XtraEditors.TextEdit();
            TouJipindaxiaogailvs = new DevExpress.XtraEditors.TextEdit();
            TouJipindaxiaogailvsi = new DevExpress.XtraEditors.TextEdit();
            TouJipindaxiaogailvw = new DevExpress.XtraEditors.TextEdit();
            TouJipindaxiaogailvl = new DevExpress.XtraEditors.TextEdit();
            YiJipindaxiaogailvzi = new DevExpress.XtraEditors.LabelControl();
            YiJipindaxiaogailvy = new DevExpress.XtraEditors.TextEdit();
            YiJipindaxiaogailve = new DevExpress.XtraEditors.TextEdit();
            YiJipindaxiaogailvs = new DevExpress.XtraEditors.TextEdit();
            YiJipindaxiaogailvsi = new DevExpress.XtraEditors.TextEdit();
            YiJipindaxiaogailvw = new DevExpress.XtraEditors.TextEdit();
            YiJipindaxiaogailvl = new DevExpress.XtraEditors.TextEdit();
            DunJipindaxiaogailvzi = new DevExpress.XtraEditors.LabelControl();
            DunJipindaxiaogailvy = new DevExpress.XtraEditors.TextEdit();
            DunJipindaxiaogailve = new DevExpress.XtraEditors.TextEdit();
            DunJipindaxiaogailvs = new DevExpress.XtraEditors.TextEdit();
            DunJipindaxiaogailvsi = new DevExpress.XtraEditors.TextEdit();
            DunJipindaxiaogailvw = new DevExpress.XtraEditors.TextEdit();
            DunJipindaxiaogailvl = new DevExpress.XtraEditors.TextEdit();
            GyJipindaxiaogailvzi = new DevExpress.XtraEditors.LabelControl();
            GyJipindaxiaogailvy = new DevExpress.XtraEditors.TextEdit();
            GyJipindaxiaogailve = new DevExpress.XtraEditors.TextEdit();
            GyJipindaxiaogailvs = new DevExpress.XtraEditors.TextEdit();
            GyJipindaxiaogailvsi = new DevExpress.XtraEditors.TextEdit();
            GyJipindaxiaogailvw = new DevExpress.XtraEditors.TextEdit();
            GyJipindaxiaogailvl = new DevExpress.XtraEditors.TextEdit();
            Jipindaxiaogailvzi = new DevExpress.XtraEditors.LabelControl();
            Jipindaxiaogailvy = new DevExpress.XtraEditors.TextEdit();
            Jipindaxiaogailve = new DevExpress.XtraEditors.TextEdit();
            Jipindaxiaogailvs = new DevExpress.XtraEditors.TextEdit();
            Jipindaxiaogailvsi = new DevExpress.XtraEditors.TextEdit();
            Jipindaxiaogailvw = new DevExpress.XtraEditors.TextEdit();
            Jipindaxiaogailvl = new DevExpress.XtraEditors.TextEdit();
            Jipindaxiaozi = new DevExpress.XtraEditors.LabelControl();
            Jipindaxiaoy = new DevExpress.XtraEditors.TextEdit();
            Jipindaxiaoe = new DevExpress.XtraEditors.TextEdit();
            Jipindaxiaos = new DevExpress.XtraEditors.TextEdit();
            Jipindaxiaosi = new DevExpress.XtraEditors.TextEdit();
            Jipindaxiaow = new DevExpress.XtraEditors.TextEdit();
            Jipindaxiaol = new DevExpress.XtraEditors.TextEdit();
            Jipindebaolvzi = new DevExpress.XtraEditors.LabelControl();
            Jipindebaolv = new DevExpress.XtraEditors.TextEdit();
            Mfguajishijian = new DevExpress.XtraEditors.LabelControl();
            Mfguajishijianzi = new DevExpress.XtraEditors.TextEdit();
            labelControl90 = new DevExpress.XtraEditors.LabelControl();
            LabelControl90TaxSani = new DevExpress.XtraEditors.TextEdit();
            MaxCurseEdit = new DevExpress.XtraEditors.TextEdit();
            labelControl62 = new DevExpress.XtraEditors.LabelControl();
            LuckRateEdit = new DevExpress.XtraEditors.TextEdit();
            labelControl61 = new DevExpress.XtraEditors.LabelControl();
            MaxLuckEdit = new DevExpress.XtraEditors.TextEdit();
            labelControl60 = new DevExpress.XtraEditors.LabelControl();
            labelControl59 = new DevExpress.XtraEditors.LabelControl();
            SpecialRepairDelayEdit = new DevExpress.XtraEditors.TimeSpanEdit();
            TorchRateEdit = new DevExpress.XtraEditors.TextEdit();
            labelControl54 = new DevExpress.XtraEditors.LabelControl();
            DropLayersEdit = new DevExpress.XtraEditors.TextEdit();
            labelControl50 = new DevExpress.XtraEditors.LabelControl();
            DropDistanceEdit = new DevExpress.XtraEditors.TextEdit();
            labelControl49 = new DevExpress.XtraEditors.LabelControl();
            labelControl48 = new DevExpress.XtraEditors.LabelControl();
            DropDurationEdit = new DevExpress.XtraEditors.TimeSpanEdit();
            wakuangbangdingZi = new DevExpress.XtraEditors.LabelControl();
            wakuangbangding = new DevExpress.XtraEditors.CheckEdit();
            xtraTabPage9 = new DevExpress.XtraTab.XtraTabPage();
            Lvduzi = new DevExpress.XtraEditors.LabelControl();
            Lvdushu = new DevExpress.XtraEditors.TextEdit();
            Qduobizi = new DevExpress.XtraEditors.LabelControl();
            Qduobishu = new DevExpress.XtraEditors.TextEdit();
            Qgedangzi = new DevExpress.XtraEditors.LabelControl();
            Qgedangshu = new DevExpress.XtraEditors.TextEdit();
            Qchenmozi = new DevExpress.XtraEditors.LabelControl();
            Qchenmoshu = new DevExpress.XtraEditors.TextEdit();
            Qyidongzi = new DevExpress.XtraEditors.LabelControl();
            Qyidongshu = new DevExpress.XtraEditors.TextEdit();
            Qmabizi = new DevExpress.XtraEditors.LabelControl();
            Qmabishu = new DevExpress.XtraEditors.TextEdit();
            Qbingdongzi = new DevExpress.XtraEditors.LabelControl();
            Qbingdongshu = new DevExpress.XtraEditors.TextEdit();
            Qmofadunzi = new DevExpress.XtraEditors.LabelControl();
            Qmofadunshu = new DevExpress.XtraEditors.TextEdit();
            Qhuanzi = new DevExpress.XtraEditors.LabelControl();
            Qhuanshu = new DevExpress.XtraEditors.TextEdit();
            Qanzi = new DevExpress.XtraEditors.LabelControl();
            Qanshu = new DevExpress.XtraEditors.TextEdit();

            ShaGuildzi = new DevExpress.XtraEditors.LabelControl();

            ShaGuildjy = new DevExpress.XtraEditors.LabelControl();
            ShaGuildjyshu = new DevExpress.XtraEditors.TextEdit();
            ShaGuildbl = new DevExpress.XtraEditors.LabelControl();
            ShaGuildblshu = new DevExpress.XtraEditors.TextEdit();
            ShaGuildjb = new DevExpress.XtraEditors.LabelControl();
            ShaGuildjbshu = new DevExpress.XtraEditors.TextEdit();

            QitaGuildzi = new DevExpress.XtraEditors.LabelControl();

            YiGuildrs = new DevExpress.XtraEditors.LabelControl();
            YiGuildrsshu = new DevExpress.XtraEditors.TextEdit();
            YiGuildjy = new DevExpress.XtraEditors.LabelControl();
            YiGuildjyshu = new DevExpress.XtraEditors.TextEdit();
            YiGuildbl = new DevExpress.XtraEditors.LabelControl();
            YiGuildblshu = new DevExpress.XtraEditors.TextEdit();
            YiGuildjb = new DevExpress.XtraEditors.LabelControl();
            YiGuildjbshu = new DevExpress.XtraEditors.TextEdit();

            ErGuildrs = new DevExpress.XtraEditors.LabelControl();
            ErGuildrsshu = new DevExpress.XtraEditors.TextEdit();
            ErGuildjy = new DevExpress.XtraEditors.LabelControl();
            ErGuildjyshu = new DevExpress.XtraEditors.TextEdit();
            ErGuildbl = new DevExpress.XtraEditors.LabelControl();
            ErGuildblshu = new DevExpress.XtraEditors.TextEdit();
            ErGuildjb = new DevExpress.XtraEditors.LabelControl();
            ErGuildjbshu = new DevExpress.XtraEditors.TextEdit();

            SanGuildrs = new DevExpress.XtraEditors.LabelControl();
            SanGuildrsshu = new DevExpress.XtraEditors.TextEdit();
            SanGuildjy = new DevExpress.XtraEditors.LabelControl();
            SanGuildjyshu = new DevExpress.XtraEditors.TextEdit();
            SanGuildbl = new DevExpress.XtraEditors.LabelControl();
            SanGuildblshu = new DevExpress.XtraEditors.TextEdit();
            SanGuildjb = new DevExpress.XtraEditors.LabelControl();
            SanGuildjbshu = new DevExpress.XtraEditors.TextEdit();

            SiGuildrs = new DevExpress.XtraEditors.LabelControl();
            SiGuildrsshu = new DevExpress.XtraEditors.TextEdit();
            SiGuildjy = new DevExpress.XtraEditors.LabelControl();
            SiGuildjyshu = new DevExpress.XtraEditors.TextEdit();
            SiGuildbl = new DevExpress.XtraEditors.LabelControl();
            SiGuildblshu = new DevExpress.XtraEditors.TextEdit();
            SiGuildjb = new DevExpress.XtraEditors.LabelControl();
            SiGuildjbshu = new DevExpress.XtraEditors.TextEdit();

            XinshouGuildzi = new DevExpress.XtraEditors.LabelControl();

            XGuilddj = new DevExpress.XtraEditors.LabelControl();
            XGuilddjshu = new DevExpress.XtraEditors.TextEdit();
            XGuildjy = new DevExpress.XtraEditors.LabelControl();
            XGuildjyshu = new DevExpress.XtraEditors.TextEdit();
            XGuildbl = new DevExpress.XtraEditors.LabelControl();
            XGuildblshu = new DevExpress.XtraEditors.TextEdit();
            XGuildjb = new DevExpress.XtraEditors.LabelControl();
            XGuildjbshu = new DevExpress.XtraEditors.TextEdit();

            Jieshaorendjwushi = new DevExpress.XtraEditors.LabelControl();
            Jieshaorendjwushishu = new DevExpress.XtraEditors.TextEdit();
            Jieshaorendjsishi = new DevExpress.XtraEditors.LabelControl();
            Jieshaorendjsishishu = new DevExpress.XtraEditors.TextEdit();
            Jieshaorendjsanshi = new DevExpress.XtraEditors.LabelControl();
            Jieshaorendjsanshishu = new DevExpress.XtraEditors.TextEdit();
            Jieshaorendjershi = new DevExpress.XtraEditors.LabelControl();
            Jieshaorendjershishu = new DevExpress.XtraEditors.TextEdit();
            Jieshaorendjshi = new DevExpress.XtraEditors.LabelControl();
            Jieshaorendjshishu = new DevExpress.XtraEditors.TextEdit();
            Jieshaorendjjieshao = new DevExpress.XtraEditors.LabelControl();
            Jieshaorenswsi = new DevExpress.XtraEditors.LabelControl();
            Jieshaorenswsishu = new DevExpress.XtraEditors.TextEdit();
            Jieshaorensjsi = new DevExpress.XtraEditors.LabelControl();
            Jieshaorensjsishu = new DevExpress.XtraEditors.TextEdit();
            Bjieshaorenswsi = new DevExpress.XtraEditors.LabelControl();
            Bjieshaorenswsishu = new DevExpress.XtraEditors.TextEdit();
            Bjieshaorensjsi = new DevExpress.XtraEditors.LabelControl();
            Bjieshaorensjsishu = new DevExpress.XtraEditors.TextEdit();
            Bjieshaorendjsi = new DevExpress.XtraEditors.LabelControl();
            Bjieshaorendjsishu = new DevExpress.XtraEditors.TextEdit();
            Jieshaorensws = new DevExpress.XtraEditors.LabelControl();
            Jieshaorenswsshu = new DevExpress.XtraEditors.TextEdit();
            Jieshaorensjs = new DevExpress.XtraEditors.LabelControl();
            Jieshaorensjsshu = new DevExpress.XtraEditors.TextEdit();
            Bjieshaorensws = new DevExpress.XtraEditors.LabelControl();
            Bjieshaorenswsshu = new DevExpress.XtraEditors.TextEdit();
            Bjieshaorensjs = new DevExpress.XtraEditors.LabelControl();
            Bjieshaorensjsshu = new DevExpress.XtraEditors.TextEdit();
            Bjieshaorendjs = new DevExpress.XtraEditors.LabelControl();
            Bjieshaorendjsshu = new DevExpress.XtraEditors.TextEdit();
            Jieshaorenswe = new DevExpress.XtraEditors.LabelControl();
            Jieshaorensweshu = new DevExpress.XtraEditors.TextEdit();
            Jieshaorensje = new DevExpress.XtraEditors.LabelControl();
            Jieshaorensjeshu = new DevExpress.XtraEditors.TextEdit();
            Bjieshaorenswe = new DevExpress.XtraEditors.LabelControl();
            Bjieshaorensweshu = new DevExpress.XtraEditors.TextEdit();
            Bjieshaorensje = new DevExpress.XtraEditors.LabelControl();
            Bjieshaorensjeshu = new DevExpress.XtraEditors.TextEdit();
            Bjieshaorendje = new DevExpress.XtraEditors.LabelControl();
            Bjieshaorendjeshu = new DevExpress.XtraEditors.TextEdit();
            Jieshaorensw = new DevExpress.XtraEditors.LabelControl();
            Jieshaorenswshu = new DevExpress.XtraEditors.TextEdit();
            Jieshaorensj = new DevExpress.XtraEditors.LabelControl();
            Jieshaorensjshu = new DevExpress.XtraEditors.TextEdit();
            Bjieshaorensw = new DevExpress.XtraEditors.LabelControl();
            Bjieshaorenswshu = new DevExpress.XtraEditors.TextEdit();
            Bjieshaorensj = new DevExpress.XtraEditors.LabelControl();
            Bjieshaorensjshu = new DevExpress.XtraEditors.TextEdit();
            Bjieshaorendj = new DevExpress.XtraEditors.LabelControl();
            Bjieshaorendjshu = new DevExpress.XtraEditors.TextEdit();
            Qshenzi = new DevExpress.XtraEditors.LabelControl();
            Qshenshu = new DevExpress.XtraEditors.TextEdit();
            Qfengzi = new DevExpress.XtraEditors.LabelControl();
            Qfengshu = new DevExpress.XtraEditors.TextEdit();
            Qleizi = new DevExpress.XtraEditors.LabelControl();
            Qleishu = new DevExpress.XtraEditors.TextEdit();
            Qbingzi = new DevExpress.XtraEditors.LabelControl();
            Qbingshu = new DevExpress.XtraEditors.TextEdit();
            Qhuozi = new DevExpress.XtraEditors.LabelControl();
            Qhuoshu = new DevExpress.XtraEditors.TextEdit();
            Ghuanzi = new DevExpress.XtraEditors.LabelControl();
            Ghuanshu = new DevExpress.XtraEditors.TextEdit();
            Ganzi = new DevExpress.XtraEditors.LabelControl();
            Ganshu = new DevExpress.XtraEditors.TextEdit();
            Gshengzi = new DevExpress.XtraEditors.LabelControl();
            Gshengshu = new DevExpress.XtraEditors.TextEdit();
            Gfengzi = new DevExpress.XtraEditors.LabelControl();
            Gfengshu = new DevExpress.XtraEditors.TextEdit();
            Gleizi = new DevExpress.XtraEditors.LabelControl();
            Gleishu = new DevExpress.XtraEditors.TextEdit();
            Gbingzi = new DevExpress.XtraEditors.LabelControl();
            Gbingshu = new DevExpress.XtraEditors.TextEdit();
            Ghuozi = new DevExpress.XtraEditors.LabelControl();
            Ghuoshu = new DevExpress.XtraEditors.TextEdit();
            Xxbszi = new DevExpress.XtraEditors.LabelControl();
            Xxbsshu = new DevExpress.XtraEditors.TextEdit();
            Jybszi = new DevExpress.XtraEditors.LabelControl();
            Jybsshu = new DevExpress.XtraEditors.TextEdit();
            Mybszi = new DevExpress.XtraEditors.LabelControl();
            Mybsshu = new DevExpress.XtraEditors.TextEdit();
            Fybszi = new DevExpress.XtraEditors.LabelControl();
            Fybsshu = new DevExpress.XtraEditors.TextEdit();
            Sdbszi = new DevExpress.XtraEditors.LabelControl();
            Sdbsshu = new DevExpress.XtraEditors.TextEdit();
            Mfbszi = new DevExpress.XtraEditors.LabelControl();
            Mfbsshu = new DevExpress.XtraEditors.TextEdit();
            Smjlbszi = new DevExpress.XtraEditors.LabelControl();
            Smjlbsshu = new DevExpress.XtraEditors.TextEdit();
            Lhjlbszi = new DevExpress.XtraEditors.LabelControl();
            Lhjlbsshu = new DevExpress.XtraEditors.TextEdit();
            Zrjlbszi = new DevExpress.XtraEditors.LabelControl();
            Zrjlbsshu = new DevExpress.XtraEditors.TextEdit();
            Gjjlbszi = new DevExpress.XtraEditors.LabelControl();
            Gjjlbsshu = new DevExpress.XtraEditors.TextEdit();
            Lhbszi = new DevExpress.XtraEditors.LabelControl();
            Lhbsshu = new DevExpress.XtraEditors.TextEdit();
            Zrbszi = new DevExpress.XtraEditors.LabelControl();
            Zrbsshu = new DevExpress.XtraEditors.TextEdit();
            Gjbszi = new DevExpress.XtraEditors.LabelControl();
            Gjbsshu = new DevExpress.XtraEditors.TextEdit();
            EwaijinbiOK = new DevExpress.XtraEditors.CheckEdit();
            Ewaijinbi = new DevExpress.XtraEditors.TextEdit();
            EwaibaolvOK = new DevExpress.XtraEditors.CheckEdit();
            Ewaibaolv = new DevExpress.XtraEditors.TextEdit();
            EwaijingyanOK = new DevExpress.XtraEditors.CheckEdit();
            Ewaijingyan = new DevExpress.XtraEditors.TextEdit();
            Ghquan2029 = new DevExpress.XtraEditors.LabelControl();
            Ghquanc2029 = new DevExpress.XtraEditors.TextEdit();
            Ghquan1019 = new DevExpress.XtraEditors.LabelControl();
            Ghquanc1019 = new DevExpress.XtraEditors.TextEdit();
            Ghquan0109 = new DevExpress.XtraEditors.LabelControl();
            Ghquanc0109 = new DevExpress.XtraEditors.TextEdit();
            Ghquan9099 = new DevExpress.XtraEditors.LabelControl();
            Ghquanc9099 = new DevExpress.XtraEditors.TextEdit();
            Ghquan8089 = new DevExpress.XtraEditors.LabelControl();
            Ghquanc8089 = new DevExpress.XtraEditors.TextEdit();
            Ghquan7079 = new DevExpress.XtraEditors.LabelControl();
            Ghquanc7079 = new DevExpress.XtraEditors.TextEdit();
            Ghquan6069 = new DevExpress.XtraEditors.LabelControl();
            Ghquanc6069 = new DevExpress.XtraEditors.TextEdit();
            Ghquan5059 = new DevExpress.XtraEditors.LabelControl();
            Ghquanc5059 = new DevExpress.XtraEditors.TextEdit();
            Ghquan4049 = new DevExpress.XtraEditors.LabelControl();
            Ghquanc4049 = new DevExpress.XtraEditors.TextEdit();
            Ghquan3039 = new DevExpress.XtraEditors.LabelControl();
            Ghquanc3039 = new DevExpress.XtraEditors.TextEdit();
            Jingliancglv = new DevExpress.XtraEditors.LabelControl();
            Jingliancglvc = new DevExpress.XtraEditors.TextEdit();
            CompanionRateEdit = new DevExpress.XtraEditors.TextEdit();
            labelControl68 = new DevExpress.XtraEditors.LabelControl();
            SkillRateEdit = new DevExpress.XtraEditors.TextEdit();
            labelControl58 = new DevExpress.XtraEditors.LabelControl();
            GoldRateEdit = new DevExpress.XtraEditors.TextEdit();
            labelControl57 = new DevExpress.XtraEditors.LabelControl();
            DropRateEdit = new DevExpress.XtraEditors.TextEdit();
            labelControl56 = new DevExpress.XtraEditors.LabelControl();
            ExperienceRateEdit = new DevExpress.XtraEditors.TextEdit();
            labelControl55 = new DevExpress.XtraEditors.LabelControl();
            OpenDialog = new System.Windows.Forms.OpenFileDialog();
            FolderDialog = new System.Windows.Forms.FolderBrowserDialog();
            ((System.ComponentModel.ISupportInitialize)(ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(xtraTabControl1)).BeginInit();
            xtraTabControl1.SuspendLayout();
            xtraTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(PacketBanTimeEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(MaxPacketEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(UserCountPortEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(PingDelayEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(TimeOutEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(PortEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(IPAddressEdit.Properties)).BeginInit();
            xtraTabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(Dinghaoxiugaimimaok.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(AllowRequestActivationEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(AllowWebActivationEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(AllowManualActivationEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(AllowDeleteAccountEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(AllowManualResetPasswordEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(AllowWebResetPasswordEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(AllowRequestPasswordResetEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(AllowWizardEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(AllowTaoistEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(Shangxianxiaxiantishi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(Xinjuesetishi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(AllowAssassinEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(AllowWarriorEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(ShifouGongce.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(ShifouNeice.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(Guajixunzhaodiyi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(Guajixunzhaodier.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(RelogDelayEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(AllowStartGameEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(AllowDeleteCharacterEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(AllowNewCharacterEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(AllowLoginEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(AllowChangePasswordEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(AllowNewAccountEdit.Properties)).BeginInit();
            xtraTabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(ShenmiNpcTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(GuanggaoGaoduok.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(GuanggaoKuanduok.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(Biaomingok.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(Huodonglanok.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(Jueseshujukuhequ.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(XingyunNPCOK.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(Tishiok.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(Daojishiok.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(RabbitEventEndEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(ReleaseDateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(ClientPathEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(MasterPasswordEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(MapPathEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(DBSaveDelayEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(VersionPathEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(CheckVersionEdit.Properties)).BeginInit();
            xtraTabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(MailDisplayNameEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(MailFromEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(MailPasswordEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(MailAccountEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(MailUseSSLEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(MailPortEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(MailServerEdit.Properties)).BeginInit();
            xtraTabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(AllowBuyGammeGoldEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(RequireActivationEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(ProcessGameGoldEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(ReceiverEMailEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(IPNPrefixEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(BuyAddressEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(BuyPrefixEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(DeleteFailLinkEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(DeleteSuccessLinkEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(ResetFailLinkEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(ResetSuccessLinkEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(ActivationFailLinkEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(ActivationSuccessLinkEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(WebCommandLinkEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(WebPrefixEdit.Properties)).BeginInit();
            xtraTabPage6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(MingwenBangding.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(Sanmingwen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(ShidushuGuagou.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(ChuanranBoss.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(BeiguaiSiwangbaolv.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(Hongmingwupindiaobv.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(Putongwupindiaobv.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(Xishiwupindiaobv.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(Gaojiwupindiaobv.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(Baoguodiaobv.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(Siwangbaolv.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(KaiqiBaoshi5432.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(Huanhuabangding.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(ZhuangbeiHuanhua.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(Liujizhuansheng.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(ZaixianFenjie.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(GunghuiGerenPaihang.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(GunghuiPaihang.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(XinshouLiwu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(GuildLevel.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(JYhuishou.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(JihuowanjiaJYjiacheng.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(YaoqiuJSRjihuozhanghao.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(Jieshaorenzubeijsrgerenjingyan.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(Jieshaorenzubeijsrjingyan.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(Jieshaorenzuxinrenjingyan.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(Yunxujieshaoren.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(AutoReviveDelayEdit.Properties)).BeginInit();
            daoshigroupBox1.SuspendLayout();
            cikegroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(ShidushuMax.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(Xiudikang.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(Yidaoyihua.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(DikangEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(SihuaEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(PvPCurseRateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(PvPCurseDurationEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(RedPointEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(PKPointTickRateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(PKPointRateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(Shifoujilubaokaqingk.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(BrownDurationEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(AllowObservationEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(SkillExpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(DayCycleCountEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(MaxLevelEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(GlobalDelayEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(ShoutDelayEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(MaxViewRangeEdit.Properties)).BeginInit();
            xtraTabPage7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(ShuaguaiBodong.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(Chuanjiluming.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(Rongyanjiluming.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(Yaotajiluming.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(Motajiluming.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(Hd01jiluming.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(Hd02jiluming.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(Hd03jiluming.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(Hd04jiluming.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(Hd05jiluming.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(Hd06jiluming.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(Hd07jiluming.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(Hd08jiluming.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(Hd09jiluming.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(Hd10jiluming.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(Hd11jiluming.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(Hd12jiluming.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(Chuanshifou.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(Rongyanshifou.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(Yaotashifou.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(Motashifou.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(Hd01shifou.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(Hd02shifou.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(Hd03shifou.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(Hd04shifou.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(Hd05shifou.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(Hd06shifou.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(Hd07shifou.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(Hd08shifou.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(Hd09shifou.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(Hd10shifou.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(Hd11shifou.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(Hd12shifou.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(Huodong12OpenEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(Huodong11OpenEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(Huodong10OpenEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(Huodong09OpenEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(Huodong08OpenEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(Huodong07OpenEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(Huodong06OpenEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(Huodong05OpenEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(Huodong04OpenEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(Huodong03OpenEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(Huodong02OpenEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(Huodong01OpenEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(MotaOpenEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(YaotaOpenEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(LairRegionOpenEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(MysteryShipOpenEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(Huodong12Edit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(Huodong11Edit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(Huodong10Edit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(Huodong09Edit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(Huodong08Edit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(Huodong07Edit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(Huodong06Edit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(Huodong05Edit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(Huodong04Edit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(Huodong03Edit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(Huodong02Edit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(Huodong01Edit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(MotaEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(yaotaEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(LairRegionIndexEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(MysteryShipRegionIndexEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(HarvestDurationEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(DeadDurationEdit.Properties)).BeginInit();
            xtraTabPage8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(StrengthLossRateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(StrengthAddRateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(MaxStrengthEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(CurseRateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(LabelControl88TaxSani.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(XieJipindaxiaogailvy.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(XieJipindaxiaogailve.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(XieJipindaxiaogailvs.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(XieJipindaxiaogailvsi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(XieJipindaxiaogailvw.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(XieJipindaxiaogailvl.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(TouJipindaxiaogailvy.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(TouJipindaxiaogailve.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(TouJipindaxiaogailvs.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(TouJipindaxiaogailvsi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(TouJipindaxiaogailvw.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(TouJipindaxiaogailvl.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(YiJipindaxiaogailvy.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(YiJipindaxiaogailve.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(YiJipindaxiaogailvs.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(YiJipindaxiaogailvsi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(YiJipindaxiaogailvw.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(YiJipindaxiaogailvl.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(DunJipindaxiaogailvy.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(DunJipindaxiaogailve.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(DunJipindaxiaogailvs.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(DunJipindaxiaogailvsi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(DunJipindaxiaogailvw.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(DunJipindaxiaogailvl.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(GyJipindaxiaogailvy.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(GyJipindaxiaogailve.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(GyJipindaxiaogailvs.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(GyJipindaxiaogailvsi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(GyJipindaxiaogailvw.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(GyJipindaxiaogailvl.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(Jipindaxiaogailvy.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(Jipindaxiaogailve.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(Jipindaxiaogailvs.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(Jipindaxiaogailvsi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(Jipindaxiaogailvw.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(Jipindaxiaogailvl.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(Jipindaxiaoy.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(Jipindaxiaoe.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(Jipindaxiaos.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(Jipindaxiaosi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(Jipindaxiaow.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(Jipindaxiaol.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(Jipindebaolv.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(Mfguajishijianzi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(LabelControl90TaxSani.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(MaxCurseEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(LuckRateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(MaxLuckEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(SpecialRepairDelayEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(TorchRateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(DropLayersEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(DropDistanceEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(DropDurationEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(wakuangbangding.Properties)).BeginInit();
            xtraTabPage9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(Lvdushu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(Qduobishu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(Qgedangshu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(Qchenmoshu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(Qyidongshu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(Qmabishu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(Qbingdongshu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(Qmofadunshu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(Qhuanshu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(Qanshu.Properties)).BeginInit();

            ((System.ComponentModel.ISupportInitialize)(ShaGuildjyshu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(ShaGuildblshu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(ShaGuildjbshu.Properties)).BeginInit();

            ((System.ComponentModel.ISupportInitialize)(YiGuildrsshu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(YiGuildjyshu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(YiGuildblshu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(YiGuildjbshu.Properties)).BeginInit();

            ((System.ComponentModel.ISupportInitialize)(ErGuildrsshu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(ErGuildjyshu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(ErGuildblshu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(ErGuildjbshu.Properties)).BeginInit();

            ((System.ComponentModel.ISupportInitialize)(SanGuildrsshu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(SanGuildjyshu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(SanGuildblshu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(SanGuildjbshu.Properties)).BeginInit();

            ((System.ComponentModel.ISupportInitialize)(SiGuildrsshu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(SiGuildjyshu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(SiGuildblshu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(SiGuildjbshu.Properties)).BeginInit();

            ((System.ComponentModel.ISupportInitialize)(XGuilddjshu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(XGuildjyshu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(XGuildblshu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(XGuildjbshu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(Jieshaorendjwushishu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(Jieshaorendjsishishu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(Jieshaorendjsanshishu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(Jieshaorendjershishu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(Jieshaorendjshishu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(Jieshaorenswsishu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(Jieshaorensjsishu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(Bjieshaorenswsishu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(Bjieshaorensjsishu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(Bjieshaorendjsishu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(Jieshaorenswsshu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(Jieshaorensjsshu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(Bjieshaorenswsshu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(Bjieshaorensjsshu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(Bjieshaorendjsshu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(Jieshaorensweshu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(Jieshaorensjeshu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(Bjieshaorensweshu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(Bjieshaorensjeshu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(Bjieshaorendjeshu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(Jieshaorenswshu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(Jieshaorensjshu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(Bjieshaorenswshu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(Bjieshaorensjshu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(Bjieshaorendjshu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(Qshenshu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(Qfengshu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(Qleishu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(Qbingshu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(Qhuoshu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(Ghuanshu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(Ganshu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(Gshengshu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(Gfengshu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(Gleishu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(Gbingshu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(Ghuoshu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(Xxbsshu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(Jybsshu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(Mybsshu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(Fybsshu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(Sdbsshu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(Mfbsshu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(Smjlbsshu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(Lhjlbsshu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(Zrjlbsshu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(Gjjlbsshu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(Lhbsshu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(Zrbsshu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(Gjbsshu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(EwaijinbiOK.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(Ewaijinbi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(EwaibaolvOK.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(Ewaibaolv.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(EwaijingyanOK.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(Ewaijingyan.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(Ghquanc2029.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(Ghquanc1019.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(Ghquanc0109.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(Ghquanc9099.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(Ghquanc8089.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(Ghquanc7079.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(Ghquanc6069.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(Ghquanc5059.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(Ghquanc4049.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(Ghquanc3039.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(Jingliancglvc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(CompanionRateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(SkillRateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(GoldRateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(DropRateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(ExperienceRateEdit.Properties)).BeginInit();
            SuspendLayout();
            
            
            
            ribbon.ExpandCollapseItem.Id = 0;
            ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            ribbon.ExpandCollapseItem,
            SaveButton,
            ReloadButton});
            ribbon.Location = new System.Drawing.Point(0, 0);
            ribbon.MaxItemId = 4;
            ribbon.Name = "ribbon";
            ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            ribbonPage1});
            ribbon.Size = new System.Drawing.Size(904, 147);
            
            
            
            SaveButton.Caption = "保存";
            SaveButton.Id = 1;
            SaveButton.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("SaveButton.ImageOptions.Image")));
            SaveButton.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("SaveButton.ImageOptions.LargeImage")));
            SaveButton.Name = "SaveButton";
            SaveButton.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(SaveButton_ItemClick);
            
            
            
            ReloadButton.Caption = "撤回";
            ReloadButton.Id = 2;
            ReloadButton.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("ReloadButton.ImageOptions.Image")));
            ReloadButton.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("ReloadButton.ImageOptions.LargeImage")));
            ReloadButton.Name = "ReloadButton";
            ReloadButton.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(ReloadButton_ItemClick);
            
            
            
            ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            ribbonPageGroup1});
            ribbonPage1.Name = "ribbonPage1";
            ribbonPage1.Text = "Home";
            
            
            
            ribbonPageGroup1.AllowTextClipping = false;
            ribbonPageGroup1.ItemLinks.Add(SaveButton);
            ribbonPageGroup1.ItemLinks.Add(ReloadButton);
            ribbonPageGroup1.Name = "ribbonPageGroup1";
            ribbonPageGroup1.ShowCaptionButton = false;
            ribbonPageGroup1.Text = "Actions";
            
            
            
            xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            xtraTabControl1.Location = new System.Drawing.Point(0, 147);
            xtraTabControl1.Name = "xtraTabControl1";
            xtraTabControl1.SelectedTabPage = xtraTabPage1;
            xtraTabControl1.Size = new System.Drawing.Size(904, 464);
            xtraTabControl1.TabIndex = 2;
            xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            xtraTabPage1,
            xtraTabPage2,
            xtraTabPage3,
            xtraTabPage4,
            xtraTabPage5,
            xtraTabPage6,
            xtraTabPage7,
            xtraTabPage8,
            xtraTabPage9});
            
            
            
            xtraTabPage1.Controls.Add(PacketBanTimeEdit);
            xtraTabPage1.Controls.Add(SyncronizeButton);
            xtraTabPage1.Controls.Add(labelControl86);
            xtraTabPage1.Controls.Add(labelControl87);
            xtraTabPage1.Controls.Add(MaxPacketEdit);
            xtraTabPage1.Controls.Add(labelControl51);
            xtraTabPage1.Controls.Add(UserCountPortEdit);
            xtraTabPage1.Controls.Add(labelControl6);
            xtraTabPage1.Controls.Add(PingDelayEdit);
            xtraTabPage1.Controls.Add(TimeOutEdit);
            xtraTabPage1.Controls.Add(labelControl3);
            xtraTabPage1.Controls.Add(labelControl2);
            xtraTabPage1.Controls.Add(PortEdit);
            xtraTabPage1.Controls.Add(IPAddressEdit);
            xtraTabPage1.Controls.Add(labelControl1);
            xtraTabPage1.Name = "xtraTabPage1";
            xtraTabPage1.Size = new System.Drawing.Size(898, 435);
            xtraTabPage1.Text = "网络";
            
            
            
            PacketBanTimeEdit.EditValue = System.TimeSpan.Parse("00:00:00");
            PacketBanTimeEdit.Location = new System.Drawing.Point(126, 187);
            PacketBanTimeEdit.MenuManager = ribbon;
            PacketBanTimeEdit.Name = "PacketBanTimeEdit";
            PacketBanTimeEdit.Properties.AllowEditDays = false;
            PacketBanTimeEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            PacketBanTimeEdit.Properties.Mask.EditMask = "HH:mm:ss";
            PacketBanTimeEdit.Size = new System.Drawing.Size(117, 20);
            PacketBanTimeEdit.TabIndex = 40;
            
            
            
            SyncronizeButton.Text = "数据库-远程同步";
            SyncronizeButton.Location = new System.Drawing.Point(44, 220);
            SyncronizeButton.Width = 200;
            
            
            
            labelControl86.Location = new System.Drawing.Point(51, 190);
            labelControl86.Name = "labelControl86";
            labelControl86.Size = new System.Drawing.Size(64, 14);
            labelControl86.TabIndex = 39;
            labelControl86.Text = "数据包时间:";
            
            
            
            labelControl87.Location = new System.Drawing.Point(51, 162);
            labelControl87.Name = "labelControl87";
            labelControl87.Size = new System.Drawing.Size(64, 14);
            labelControl87.TabIndex = 38;
            labelControl87.Text = "最大数据包:";
            
            
            
            MaxPacketEdit.Location = new System.Drawing.Point(126, 159);
            MaxPacketEdit.MenuManager = ribbon;
            MaxPacketEdit.Name = "MaxPacketEdit";
            MaxPacketEdit.Properties.Appearance.Options.UseTextOptions = true;
            MaxPacketEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            MaxPacketEdit.Properties.Mask.EditMask = "n0";
            MaxPacketEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            MaxPacketEdit.Properties.Mask.UseMaskAsDisplayFormat = true;
            MaxPacketEdit.Size = new System.Drawing.Size(117, 20);
            MaxPacketEdit.TabIndex = 37;
            
            
            
            labelControl51.Location = new System.Drawing.Point(39, 134);
            labelControl51.Name = "labelControl51";
            labelControl51.Size = new System.Drawing.Size(76, 14);
            labelControl51.TabIndex = 36;
            labelControl51.Text = "用户计数端口:";
            
            
            
            UserCountPortEdit.Location = new System.Drawing.Point(126, 131);
            UserCountPortEdit.MenuManager = ribbon;
            UserCountPortEdit.Name = "UserCountPortEdit";
            UserCountPortEdit.Properties.Appearance.Options.UseTextOptions = true;
            UserCountPortEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            UserCountPortEdit.Properties.Mask.EditMask = "n0";
            UserCountPortEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            UserCountPortEdit.Properties.Mask.UseMaskAsDisplayFormat = true;
            UserCountPortEdit.Size = new System.Drawing.Size(117, 20);
            UserCountPortEdit.TabIndex = 35;
            
            
            
            labelControl6.Location = new System.Drawing.Point(63, 106);
            labelControl6.Name = "labelControl6";
            labelControl6.Size = new System.Drawing.Size(52, 14);
            labelControl6.TabIndex = 34;
            labelControl6.Text = "网络延迟:";
            
            
            
            PingDelayEdit.EditValue = System.TimeSpan.Parse("00:00:00");
            PingDelayEdit.Location = new System.Drawing.Point(126, 103);
            PingDelayEdit.MenuManager = ribbon;
            PingDelayEdit.Name = "PingDelayEdit";
            PingDelayEdit.Properties.AllowEditDays = false;
            PingDelayEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            PingDelayEdit.Properties.Mask.EditMask = "HH:mm:ss";
            PingDelayEdit.Size = new System.Drawing.Size(117, 20);
            PingDelayEdit.TabIndex = 33;
            
            
            
            TimeOutEdit.EditValue = System.TimeSpan.Parse("00:00:00");
            TimeOutEdit.Location = new System.Drawing.Point(126, 75);
            TimeOutEdit.MenuManager = ribbon;
            TimeOutEdit.Name = "TimeOutEdit";
            TimeOutEdit.Properties.AllowEditDays = false;
            TimeOutEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            TimeOutEdit.Properties.Mask.EditMask = "HH:mm:ss";
            TimeOutEdit.Size = new System.Drawing.Size(117, 20);
            TimeOutEdit.TabIndex = 32;
            
            
            
            labelControl3.Location = new System.Drawing.Point(63, 78);
            labelControl3.Name = "labelControl3";
            labelControl3.Size = new System.Drawing.Size(52, 14);
            labelControl3.TabIndex = 31;
            labelControl3.Text = "关闭时间:";
            
            
            
            labelControl2.Location = new System.Drawing.Point(87, 50);
            labelControl2.Name = "labelControl2";
            labelControl2.Size = new System.Drawing.Size(28, 14);
            labelControl2.TabIndex = 30;
            labelControl2.Text = "端口:";
            
            
            
            PortEdit.Location = new System.Drawing.Point(126, 47);
            PortEdit.MenuManager = ribbon;
            PortEdit.Name = "PortEdit";
            PortEdit.Properties.Appearance.Options.UseTextOptions = true;
            PortEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            PortEdit.Properties.Mask.EditMask = "n0";
            PortEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            PortEdit.Properties.Mask.UseMaskAsDisplayFormat = true;
            PortEdit.Size = new System.Drawing.Size(117, 20);
            PortEdit.TabIndex = 29;
            
            
            
            IPAddressEdit.Location = new System.Drawing.Point(126, 19);
            IPAddressEdit.MenuManager = ribbon;
            IPAddressEdit.Name = "IPAddressEdit";
            IPAddressEdit.Properties.Appearance.Options.UseTextOptions = true;
            IPAddressEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            IPAddressEdit.Size = new System.Drawing.Size(117, 20);
            IPAddressEdit.TabIndex = 27;
            
            
            
            labelControl1.Location = new System.Drawing.Point(76, 22);
            labelControl1.Name = "labelControl1";
            labelControl1.Size = new System.Drawing.Size(39, 14);
            labelControl1.TabIndex = 28;
            labelControl1.Text = "IP地址:";
            
            
            
            xtraTabPage2.Controls.Add(Dinghaoxiugaimima);
            xtraTabPage2.Controls.Add(Dinghaoxiugaimimaok);
            xtraTabPage2.Controls.Add(labelControl16);
            xtraTabPage2.Controls.Add(AllowRequestActivationEdit);
            xtraTabPage2.Controls.Add(labelControl22);
            xtraTabPage2.Controls.Add(AllowWebActivationEdit);
            xtraTabPage2.Controls.Add(labelControl17);
            xtraTabPage2.Controls.Add(AllowManualActivationEdit);
            xtraTabPage2.Controls.Add(labelControl18);
            xtraTabPage2.Controls.Add(AllowDeleteAccountEdit);
            xtraTabPage2.Controls.Add(labelControl19);
            xtraTabPage2.Controls.Add(AllowManualResetPasswordEdit);
            xtraTabPage2.Controls.Add(labelControl20);
            xtraTabPage2.Controls.Add(AllowWebResetPasswordEdit);
            xtraTabPage2.Controls.Add(labelControl21);
            xtraTabPage2.Controls.Add(AllowRequestPasswordResetEdit);
            xtraTabPage2.Controls.Add(labelControl40);
            xtraTabPage2.Controls.Add(AllowWizardEdit);
            xtraTabPage2.Controls.Add(labelControl39);
            xtraTabPage2.Controls.Add(AllowTaoistEdit);
            xtraTabPage2.Controls.Add(Shangxianxiaxiantishizi);
            xtraTabPage2.Controls.Add(Shangxianxiaxiantishi);
            xtraTabPage2.Controls.Add(Xinjuesetishizi);
            xtraTabPage2.Controls.Add(Xinjuesetishi);
            xtraTabPage2.Controls.Add(labelControl38);
            xtraTabPage2.Controls.Add(AllowAssassinEdit);
            xtraTabPage2.Controls.Add(labelControl36);
            xtraTabPage2.Controls.Add(AllowWarriorEdit);
            xtraTabPage2.Controls.Add(ShifouNeicezi);
            xtraTabPage2.Controls.Add(ShifouNeice);
            xtraTabPage2.Controls.Add(ShifouGongcezi);
            xtraTabPage2.Controls.Add(ShifouGongce);
            xtraTabPage2.Controls.Add(GuajixunzhaodiyiZi);
            xtraTabPage2.Controls.Add(Guajixunzhaodiyi);
            xtraTabPage2.Controls.Add(GuajixunzhaodierZi);
            xtraTabPage2.Controls.Add(Guajixunzhaodier);
            xtraTabPage2.Controls.Add(labelControl15);
            xtraTabPage2.Controls.Add(RelogDelayEdit);
            xtraTabPage2.Controls.Add(labelControl14);
            xtraTabPage2.Controls.Add(AllowStartGameEdit);
            xtraTabPage2.Controls.Add(labelControl12);
            xtraTabPage2.Controls.Add(AllowDeleteCharacterEdit);
            xtraTabPage2.Controls.Add(labelControl11);
            xtraTabPage2.Controls.Add(AllowNewCharacterEdit);
            xtraTabPage2.Controls.Add(labelControl9);
            xtraTabPage2.Controls.Add(AllowLoginEdit);
            xtraTabPage2.Controls.Add(labelControl8);
            xtraTabPage2.Controls.Add(AllowChangePasswordEdit);
            xtraTabPage2.Controls.Add(labelControl7);
            xtraTabPage2.Controls.Add(AllowNewAccountEdit);
            xtraTabPage2.Name = "xtraTabPage2";
            xtraTabPage2.Size = new System.Drawing.Size(898, 435);
            xtraTabPage2.Text = "控制";
            
            
            
            Dinghaoxiugaimima.Location = new System.Drawing.Point(526, 208);
            Dinghaoxiugaimima.Name = "Dinghaoxiugaimima";
            Dinghaoxiugaimima.Size = new System.Drawing.Size(76, 14);
            Dinghaoxiugaimima.TabIndex = 369;
            Dinghaoxiugaimima.Text = "顶号修改密码:";
            
            
            
            Dinghaoxiugaimimaok.Location = new System.Drawing.Point(614, 205);
            Dinghaoxiugaimimaok.MenuManager = ribbon;
            Dinghaoxiugaimimaok.Name = "Dinghaoxiugaimimaok";
            Dinghaoxiugaimimaok.Properties.Caption = "";
            Dinghaoxiugaimimaok.Size = new System.Drawing.Size(117, 19);
            Dinghaoxiugaimimaok.TabIndex = 368;
            
            
            
            labelControl16.Location = new System.Drawing.Point(526, 180);
            labelControl16.Name = "labelControl16";
            labelControl16.Size = new System.Drawing.Size(76, 14);
            labelControl16.TabIndex = 95;
            labelControl16.Text = "允许手动激活:";
            
            
            
            AllowRequestActivationEdit.Location = new System.Drawing.Point(614, 177);
            AllowRequestActivationEdit.MenuManager = ribbon;
            AllowRequestActivationEdit.Name = "AllowRequestActivationEdit";
            AllowRequestActivationEdit.Properties.Caption = "";
            AllowRequestActivationEdit.Size = new System.Drawing.Size(117, 19);
            AllowRequestActivationEdit.TabIndex = 94;
            
            
            
            labelControl22.Location = new System.Drawing.Point(526, 152);
            labelControl22.Name = "labelControl22";
            labelControl22.Size = new System.Drawing.Size(76, 14);
            labelControl22.TabIndex = 93;
            labelControl22.Text = "允许网页激活:";
            
            
            
            AllowWebActivationEdit.Location = new System.Drawing.Point(614, 150);
            AllowWebActivationEdit.MenuManager = ribbon;
            AllowWebActivationEdit.Name = "AllowWebActivationEdit";
            AllowWebActivationEdit.Properties.Caption = "";
            AllowWebActivationEdit.Size = new System.Drawing.Size(117, 19);
            AllowWebActivationEdit.TabIndex = 92;
            
            
            
            labelControl17.Location = new System.Drawing.Point(526, 125);
            labelControl17.Name = "labelControl17";
            labelControl17.Size = new System.Drawing.Size(76, 14);
            labelControl17.TabIndex = 91;
            labelControl17.Text = "允许申请激活:";
            
            
            
            AllowManualActivationEdit.Location = new System.Drawing.Point(614, 123);
            AllowManualActivationEdit.MenuManager = ribbon;
            AllowManualActivationEdit.Name = "AllowManualActivationEdit";
            AllowManualActivationEdit.Properties.Caption = "";
            AllowManualActivationEdit.Size = new System.Drawing.Size(117, 19);
            AllowManualActivationEdit.TabIndex = 90;
            
            
            
            labelControl18.Location = new System.Drawing.Point(526, 101);
            labelControl18.Name = "labelControl18";
            labelControl18.Size = new System.Drawing.Size(76, 14);
            labelControl18.TabIndex = 89;
            labelControl18.Text = "允许删除帐户:";
            
            
            
            AllowDeleteAccountEdit.Location = new System.Drawing.Point(614, 96);
            AllowDeleteAccountEdit.MenuManager = ribbon;
            AllowDeleteAccountEdit.Name = "AllowDeleteAccountEdit";
            AllowDeleteAccountEdit.Properties.Caption = "";
            AllowDeleteAccountEdit.Size = new System.Drawing.Size(117, 19);
            AllowDeleteAccountEdit.TabIndex = 88;
            
            
            
            labelControl19.Location = new System.Drawing.Point(526, 71);
            labelControl19.Name = "labelControl19";
            labelControl19.Size = new System.Drawing.Size(76, 14);
            labelControl19.TabIndex = 87;
            labelControl19.Text = "允许手动重置:";
            
            
            
            AllowManualResetPasswordEdit.Location = new System.Drawing.Point(614, 69);
            AllowManualResetPasswordEdit.MenuManager = ribbon;
            AllowManualResetPasswordEdit.Name = "AllowManualResetPasswordEdit";
            AllowManualResetPasswordEdit.Properties.Caption = "";
            AllowManualResetPasswordEdit.Size = new System.Drawing.Size(117, 19);
            AllowManualResetPasswordEdit.TabIndex = 86;
            
            
            
            labelControl20.Location = new System.Drawing.Point(526, 44);
            labelControl20.Name = "labelControl20";
            labelControl20.Size = new System.Drawing.Size(76, 14);
            labelControl20.TabIndex = 85;
            labelControl20.Text = "允许网页重置:";
            
            
            
            AllowWebResetPasswordEdit.Location = new System.Drawing.Point(614, 42);
            AllowWebResetPasswordEdit.MenuManager = ribbon;
            AllowWebResetPasswordEdit.Name = "AllowWebResetPasswordEdit";
            AllowWebResetPasswordEdit.Properties.Caption = "";
            AllowWebResetPasswordEdit.Size = new System.Drawing.Size(117, 19);
            AllowWebResetPasswordEdit.TabIndex = 84;
            
            
            
            labelControl21.Location = new System.Drawing.Point(526, 17);
            labelControl21.Name = "labelControl21";
            labelControl21.Size = new System.Drawing.Size(76, 14);
            labelControl21.TabIndex = 83;
            labelControl21.Text = "允许修改密码:";
            
            
            
            AllowRequestPasswordResetEdit.Location = new System.Drawing.Point(614, 15);
            AllowRequestPasswordResetEdit.MenuManager = ribbon;
            AllowRequestPasswordResetEdit.Name = "AllowRequestPasswordResetEdit";
            AllowRequestPasswordResetEdit.Properties.Caption = "";
            AllowRequestPasswordResetEdit.Size = new System.Drawing.Size(117, 19);
            AllowRequestPasswordResetEdit.TabIndex = 82;
            
            
            
            Xinjuesetishizi.Location = new System.Drawing.Point(263, 152);
            Xinjuesetishizi.Name = "Xinjuesetishizi";
            Xinjuesetishizi.Size = new System.Drawing.Size(76, 14);
            Xinjuesetishizi.TabIndex = 474;
            Xinjuesetishizi.Text = "新角色提示:";
            
            
            
            Xinjuesetishi.Location = new System.Drawing.Point(342, 150);
            Xinjuesetishi.MenuManager = ribbon;
            Xinjuesetishi.Name = "Xinjuesetishi";
            Xinjuesetishi.Properties.Caption = "";
            Xinjuesetishi.Size = new System.Drawing.Size(117, 19);
            Xinjuesetishi.TabIndex = 473;
            
            
            
            Shangxianxiaxiantishizi.Location = new System.Drawing.Point(251, 125);
            Shangxianxiaxiantishizi.Name = "Shangxianxiaxiantishizi";
            Shangxianxiaxiantishizi.Size = new System.Drawing.Size(76, 14);
            Shangxianxiaxiantishizi.TabIndex = 472;
            Shangxianxiaxiantishizi.Text = "上线下线提示:";
            
            
            
            Shangxianxiaxiantishi.Location = new System.Drawing.Point(342, 123);
            Shangxianxiaxiantishi.MenuManager = ribbon;
            Shangxianxiaxiantishi.Name = "Shangxianxiaxiantishi";
            Shangxianxiaxiantishi.Properties.Caption = "";
            Shangxianxiaxiantishi.Size = new System.Drawing.Size(117, 19);
            Shangxianxiaxiantishi.TabIndex = 471;
            
            
            
            labelControl40.Location = new System.Drawing.Point(251, 44);
            labelControl40.Name = "labelControl40";
            labelControl40.Size = new System.Drawing.Size(76, 14);
            labelControl40.TabIndex = 81;
            labelControl40.Text = "允许创建法师:";
            
            
            
            AllowWizardEdit.Location = new System.Drawing.Point(342, 42);
            AllowWizardEdit.MenuManager = ribbon;
            AllowWizardEdit.Name = "AllowWizardEdit";
            AllowWizardEdit.Properties.Caption = "";
            AllowWizardEdit.Size = new System.Drawing.Size(117, 19);
            AllowWizardEdit.TabIndex = 80;
            
            
            
            labelControl39.Location = new System.Drawing.Point(251, 71);
            labelControl39.Name = "labelControl39";
            labelControl39.Size = new System.Drawing.Size(76, 14);
            labelControl39.TabIndex = 79;
            labelControl39.Text = "允许创建道士:";
            
            
            
            AllowTaoistEdit.Location = new System.Drawing.Point(342, 69);
            AllowTaoistEdit.MenuManager = ribbon;
            AllowTaoistEdit.Name = "AllowTaoistEdit";
            AllowTaoistEdit.Properties.Caption = "";
            AllowTaoistEdit.Size = new System.Drawing.Size(117, 19);
            AllowTaoistEdit.TabIndex = 78;
            
            
            
            labelControl38.Location = new System.Drawing.Point(251, 98);
            labelControl38.Name = "labelControl38";
            labelControl38.Size = new System.Drawing.Size(76, 14);
            labelControl38.TabIndex = 77;
            labelControl38.Text = "允许创建刺客:";
            
            
            
            AllowAssassinEdit.Location = new System.Drawing.Point(342, 96);
            AllowAssassinEdit.MenuManager = ribbon;
            AllowAssassinEdit.Name = "AllowAssassinEdit";
            AllowAssassinEdit.Properties.Caption = "";
            AllowAssassinEdit.Size = new System.Drawing.Size(117, 19);
            AllowAssassinEdit.TabIndex = 76;
            
            
            
            labelControl36.Location = new System.Drawing.Point(251, 17);
            labelControl36.Name = "labelControl36";
            labelControl36.Size = new System.Drawing.Size(76, 14);
            labelControl36.TabIndex = 73;
            labelControl36.Text = "允许创建战士:";
            
            
            
            AllowWarriorEdit.Location = new System.Drawing.Point(342, 15);
            AllowWarriorEdit.MenuManager = ribbon;
            AllowWarriorEdit.Name = "AllowWarriorEdit";
            AllowWarriorEdit.Properties.Caption = "";
            AllowWarriorEdit.Size = new System.Drawing.Size(117, 19);
            AllowWarriorEdit.TabIndex = 72;
            
            
            
            ShifouNeicezi.Location = new System.Drawing.Point(15, 236);
            ShifouNeicezi.Name = "ShifouNeicezi";
            ShifouNeicezi.Size = new System.Drawing.Size(76, 14);
            ShifouNeicezi.TabIndex = 523;
            ShifouNeicezi.Text = "是否内测开启游戏:";
            
            
            
            ShifouNeice.Location = new System.Drawing.Point(126, 233);
            ShifouNeice.MenuManager = ribbon;
            ShifouNeice.Name = "ShifouNeice";
            ShifouNeice.Properties.Caption = "";
            ShifouNeice.Size = new System.Drawing.Size(117, 19);
            ShifouNeice.TabIndex = 522;
            
            
            
            ShifouGongcezi.Location = new System.Drawing.Point(15, 208);
            ShifouGongcezi.Name = "ShifouGongcezi";
            ShifouGongcezi.Size = new System.Drawing.Size(76, 14);
            ShifouGongcezi.TabIndex = 521;
            ShifouGongcezi.Text = "是否公测开启游戏:";
            
            
            
            ShifouGongce.Location = new System.Drawing.Point(126, 205);
            ShifouGongce.MenuManager = ribbon;
            ShifouGongce.Name = "ShifouGongce";
            ShifouGongce.Properties.Caption = "";
            ShifouGongce.Size = new System.Drawing.Size(117, 19);
            ShifouGongce.TabIndex = 520;
            
            
            
            GuajixunzhaodiyiZi.Location = new System.Drawing.Point(15, 264);
            GuajixunzhaodiyiZi.Name = "GuajixunzhaodiyiZi";
            GuajixunzhaodiyiZi.Size = new System.Drawing.Size(76, 14);
            GuajixunzhaodiyiZi.TabIndex = 530;
            GuajixunzhaodiyiZi.Text = "挂机找怪物模式01:";
            
            
            
            Guajixunzhaodiyi.Location = new System.Drawing.Point(126, 261);
            Guajixunzhaodiyi.MenuManager = ribbon;
            Guajixunzhaodiyi.Name = "Guajixunzhaodiyi";
            Guajixunzhaodiyi.Properties.Caption = "";
            Guajixunzhaodiyi.Size = new System.Drawing.Size(117, 19);
            Guajixunzhaodiyi.TabIndex = 531;
            
            
            
            GuajixunzhaodierZi.Location = new System.Drawing.Point(15, 292);
            GuajixunzhaodierZi.Name = "GuajixunzhaodierZi";
            GuajixunzhaodierZi.Size = new System.Drawing.Size(76, 14);
            GuajixunzhaodierZi.TabIndex = 532;
            GuajixunzhaodierZi.Text = "挂机找怪物模式02:";
            
            
            
            Guajixunzhaodier.Location = new System.Drawing.Point(126, 289);
            Guajixunzhaodier.MenuManager = ribbon;
            Guajixunzhaodier.Name = "Guajixunzhaodier";
            Guajixunzhaodier.Properties.Caption = "";
            Guajixunzhaodier.Size = new System.Drawing.Size(117, 19);
            Guajixunzhaodier.TabIndex = 533;
            
            
            
            labelControl15.Location = new System.Drawing.Point(63, 180);
            labelControl15.Name = "labelControl15";
            labelControl15.Size = new System.Drawing.Size(52, 14);
            labelControl15.TabIndex = 71;
            labelControl15.Text = "重启延时:";
            
            
            
            RelogDelayEdit.EditValue = System.TimeSpan.Parse("00:00:00");
            RelogDelayEdit.Location = new System.Drawing.Point(126, 177);
            RelogDelayEdit.MenuManager = ribbon;
            RelogDelayEdit.Name = "RelogDelayEdit";
            RelogDelayEdit.Properties.AllowEditDays = false;
            RelogDelayEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            RelogDelayEdit.Properties.Mask.EditMask = "HH:mm:ss";
            RelogDelayEdit.Size = new System.Drawing.Size(117, 20);
            RelogDelayEdit.TabIndex = 70;
            
            
            
            labelControl14.Location = new System.Drawing.Point(63, 152);
            labelControl14.Name = "labelControl14";
            labelControl14.Size = new System.Drawing.Size(52, 14);
            labelControl14.TabIndex = 69;
            labelControl14.Text = "开始游戏:";
            
            
            
            AllowStartGameEdit.Location = new System.Drawing.Point(126, 150);
            AllowStartGameEdit.MenuManager = ribbon;
            AllowStartGameEdit.Name = "AllowStartGameEdit";
            AllowStartGameEdit.Properties.Caption = "";
            AllowStartGameEdit.Size = new System.Drawing.Size(117, 19);
            AllowStartGameEdit.TabIndex = 68;
            
            
            
            labelControl12.Location = new System.Drawing.Point(63, 125);
            labelControl12.Name = "labelControl12";
            labelControl12.Size = new System.Drawing.Size(52, 14);
            labelControl12.TabIndex = 67;
            labelControl12.Text = "删除角色:";
            
            
            
            AllowDeleteCharacterEdit.Location = new System.Drawing.Point(126, 123);
            AllowDeleteCharacterEdit.MenuManager = ribbon;
            AllowDeleteCharacterEdit.Name = "AllowDeleteCharacterEdit";
            AllowDeleteCharacterEdit.Properties.Caption = "";
            AllowDeleteCharacterEdit.Size = new System.Drawing.Size(117, 19);
            AllowDeleteCharacterEdit.TabIndex = 66;
            
            
            
            labelControl11.Location = new System.Drawing.Point(75, 98);
            labelControl11.Name = "labelControl11";
            labelControl11.Size = new System.Drawing.Size(40, 14);
            labelControl11.TabIndex = 65;
            labelControl11.Text = "新角色:";
            
            
            
            AllowNewCharacterEdit.Location = new System.Drawing.Point(126, 96);
            AllowNewCharacterEdit.MenuManager = ribbon;
            AllowNewCharacterEdit.Name = "AllowNewCharacterEdit";
            AllowNewCharacterEdit.Properties.Caption = "";
            AllowNewCharacterEdit.Size = new System.Drawing.Size(117, 19);
            AllowNewCharacterEdit.TabIndex = 64;
            
            
            
            labelControl9.Location = new System.Drawing.Point(87, 72);
            labelControl9.Name = "labelControl9";
            labelControl9.Size = new System.Drawing.Size(28, 14);
            labelControl9.TabIndex = 63;
            labelControl9.Text = "登录:";
            
            
            
            AllowLoginEdit.Location = new System.Drawing.Point(126, 69);
            AllowLoginEdit.MenuManager = ribbon;
            AllowLoginEdit.Name = "AllowLoginEdit";
            AllowLoginEdit.Properties.Caption = "";
            AllowLoginEdit.Size = new System.Drawing.Size(117, 19);
            AllowLoginEdit.TabIndex = 62;
            
            
            
            labelControl8.Location = new System.Drawing.Point(65, 44);
            labelControl8.Name = "labelControl8";
            labelControl8.Size = new System.Drawing.Size(52, 14);
            labelControl8.TabIndex = 61;
            labelControl8.Text = "修改密码:";
            
            
            
            AllowChangePasswordEdit.Location = new System.Drawing.Point(126, 42);
            AllowChangePasswordEdit.MenuManager = ribbon;
            AllowChangePasswordEdit.Name = "AllowChangePasswordEdit";
            AllowChangePasswordEdit.Properties.Caption = "";
            AllowChangePasswordEdit.Size = new System.Drawing.Size(117, 19);
            AllowChangePasswordEdit.TabIndex = 60;
            
            
            
            labelControl7.Location = new System.Drawing.Point(75, 17);
            labelControl7.Name = "labelControl7";
            labelControl7.Size = new System.Drawing.Size(40, 14);
            labelControl7.TabIndex = 59;
            labelControl7.Text = "新帐户:";
            
            
            
            AllowNewAccountEdit.Location = new System.Drawing.Point(126, 15);
            AllowNewAccountEdit.MenuManager = ribbon;
            AllowNewAccountEdit.Name = "AllowNewAccountEdit";
            AllowNewAccountEdit.Properties.Caption = "";
            AllowNewAccountEdit.Size = new System.Drawing.Size(117, 19);
            AllowNewAccountEdit.TabIndex = 58;
            
            
            
            xtraTabPage3.Controls.Add(ShenmiNpcTime);
            xtraTabPage3.Controls.Add(ShenmiNpcTimezi);
            xtraTabPage3.Controls.Add(GuanggaoGaoduok);
            xtraTabPage3.Controls.Add(GuanggaoKuanduok);
            xtraTabPage3.Controls.Add(Biaomingok);
            xtraTabPage3.Controls.Add(Huodonglan);
            xtraTabPage3.Controls.Add(Huodonglanok);
            xtraTabPage3.Controls.Add(Yijianhequ);
            xtraTabPage3.Controls.Add(Jueseshujukuhequ);
            xtraTabPage3.Controls.Add(Jueseshujukuhequzi);
            xtraTabPage3.Controls.Add(XingyunNPC);
            xtraTabPage3.Controls.Add(XingyunNPCOK);
            xtraTabPage3.Controls.Add(Tishiok);
            xtraTabPage3.Controls.Add(Tishi);
            xtraTabPage3.Controls.Add(Daojishi);
            xtraTabPage3.Controls.Add(Daojishiok);
            xtraTabPage3.Controls.Add(RabbitEventEndEdit);
            xtraTabPage3.Controls.Add(labelControl85);
            xtraTabPage3.Controls.Add(ReleaseDateEdit);
            xtraTabPage3.Controls.Add(labelControl70);
            xtraTabPage3.Controls.Add(ClientPathEdit);
            xtraTabPage3.Controls.Add(labelControl96);
            xtraTabPage3.Controls.Add(MasterPasswordEdit);
            xtraTabPage3.Controls.Add(labelControl67);
            xtraTabPage3.Controls.Add(MapPathEdit);
            xtraTabPage3.Controls.Add(labelControl13);
            xtraTabPage3.Controls.Add(labelControl10);
            xtraTabPage3.Controls.Add(DBSaveDelayEdit);
            xtraTabPage3.Controls.Add(CheckVersionButton);
            xtraTabPage3.Controls.Add(VersionPathEdit);
            xtraTabPage3.Controls.Add(labelControl5);
            xtraTabPage3.Controls.Add(labelControl4);
            xtraTabPage3.Controls.Add(CheckVersionEdit);
            xtraTabPage3.Name = "xtraTabPage3";
            xtraTabPage3.Size = new System.Drawing.Size(898, 435);
            xtraTabPage3.Text = "系统";
            
            
            
            Biaomingok.Location = new System.Drawing.Point(256, 470);
            Biaomingok.MenuManager = ribbon;
            Biaomingok.Name = "Biaomingok";
            Biaomingok.Properties.Appearance.Options.UseTextOptions = true;
            Biaomingok.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            Biaomingok.Size = new System.Drawing.Size(157, 20);
            Biaomingok.TabIndex = 468;
            
            
            
            GuanggaoGaoduok.Location = new System.Drawing.Point(203, 470);
            GuanggaoGaoduok.MenuManager = ribbon;
            GuanggaoGaoduok.Name = "GuanggaoGaoduok";
            GuanggaoGaoduok.Properties.Appearance.Options.UseTextOptions = true;
            GuanggaoGaoduok.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            GuanggaoGaoduok.Properties.Mask.EditMask = "n0";
            GuanggaoGaoduok.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            GuanggaoGaoduok.Properties.Mask.UseMaskAsDisplayFormat = true;
            GuanggaoGaoduok.Size = new System.Drawing.Size(50, 20);
            GuanggaoGaoduok.TabIndex = 467;
            
            
            
            GuanggaoKuanduok.Location = new System.Drawing.Point(150, 470);
            GuanggaoKuanduok.MenuManager = ribbon;
            GuanggaoKuanduok.Name = "GuanggaoKuanduok";
            GuanggaoKuanduok.Properties.Appearance.Options.UseTextOptions = true;
            GuanggaoKuanduok.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            GuanggaoKuanduok.Properties.Mask.EditMask = "n0";
            GuanggaoKuanduok.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            GuanggaoKuanduok.Properties.Mask.UseMaskAsDisplayFormat = true;
            GuanggaoKuanduok.Size = new System.Drawing.Size(50, 20);
            GuanggaoKuanduok.TabIndex = 466;
            
            
            
            Huodonglan.Location = new System.Drawing.Point(20, 473);
            Huodonglan.Name = "Huodonglan";
            Huodonglan.Size = new System.Drawing.Size(52, 14);
            Huodonglan.TabIndex = 465;
            Huodonglan.Text = "是否开启活动栏:";
            
            
            
            Huodonglanok.Location = new System.Drawing.Point(120, 470);
            Huodonglanok.MenuManager = ribbon;
            Huodonglanok.Name = "Huodonglanok";
            Huodonglanok.Properties.Caption = "";
            Huodonglanok.Size = new System.Drawing.Size(117, 19);
            Huodonglanok.TabIndex = 464;
            
            
            
            Yijianhequ.Location = new System.Drawing.Point(120, 439);
            Yijianhequ.Name = "Yijianhequ";
            Yijianhequ.Size = new System.Drawing.Size(100, 25);
            Yijianhequ.TabIndex = 26;
            Yijianhequ.Text = "一键合区";
            Yijianhequ.Click += new System.EventHandler(MergeButton_Click);
            
            
            
            Jueseshujukuhequ.Location = new System.Drawing.Point(120, 408);
            Jueseshujukuhequ.MenuManager = ribbon;
            Jueseshujukuhequ.Name = "Jueseshujukuhequ";
            Jueseshujukuhequ.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            Jueseshujukuhequ.Size = new System.Drawing.Size(292, 20);
            Jueseshujukuhequ.TabIndex = 241;
            Jueseshujukuhequ.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(ServerMergeEdit_ButtonClick);
            
            
            
            Jueseshujukuhequzi.Location = new System.Drawing.Point(6, 411);
            Jueseshujukuhequzi.Name = "Jueseshujukuhequzi";
            Jueseshujukuhequzi.Size = new System.Drawing.Size(64, 14);
            Jueseshujukuhequzi.TabIndex = 240;
            Jueseshujukuhequzi.Text = "选择合区角色库路径:";
            
            
            
            ShenmiNpcTime.Location = new System.Drawing.Point(272, 380);
            ShenmiNpcTime.MenuManager = ribbon;
            ShenmiNpcTime.Name = "ShenmiNpcTime";
            ShenmiNpcTime.Properties.Appearance.Options.UseTextOptions = true;
            ShenmiNpcTime.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            ShenmiNpcTime.Properties.Mask.EditMask = "n0";
            ShenmiNpcTime.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            ShenmiNpcTime.Properties.Mask.UseMaskAsDisplayFormat = true;
            ShenmiNpcTime.Size = new System.Drawing.Size(50, 20);
            ShenmiNpcTime.TabIndex = 517;
            
            
            
            ShenmiNpcTimezi.Location = new System.Drawing.Point(166, 383);
            ShenmiNpcTimezi.Name = "ShenmiNpcTimezi";
            ShenmiNpcTimezi.Size = new System.Drawing.Size(52, 14);
            ShenmiNpcTimezi.TabIndex = 516;
            ShenmiNpcTimezi.Text = "神秘商人移除时间:";
            
            
            
            XingyunNPCOK.Location = new System.Drawing.Point(120, 380);
            XingyunNPCOK.MenuManager = ribbon;
            XingyunNPCOK.Name = "XingyunNPCOK";
            XingyunNPCOK.Properties.Caption = "";
            XingyunNPCOK.Size = new System.Drawing.Size(30, 19);
            XingyunNPCOK.TabIndex = 231;
            
            
            
            XingyunNPC.Location = new System.Drawing.Point(32, 383);
            XingyunNPC.Name = "XingyunNPC";
            XingyunNPC.Size = new System.Drawing.Size(76, 14);
            XingyunNPC.TabIndex = 230;
            XingyunNPC.Text = "神秘商人开启:";
            
            
            
            Tishiok.Location = new System.Drawing.Point(120, 352);
            Tishiok.MenuManager = ribbon;
            Tishiok.Name = "Tishiok";
            Tishiok.Properties.Appearance.Options.UseTextOptions = true;
            Tishiok.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            Tishiok.Size = new System.Drawing.Size(292, 20);
            Tishiok.TabIndex = 161;
            
            
            
            Tishi.Location = new System.Drawing.Point(20, 355);
            Tishi.Name = "Tishi";
            Tishi.Size = new System.Drawing.Size(30, 14);
            Tishi.TabIndex = 162;
            Tishi.Text = "关闭服务端提示:";
            
            
            
            Daojishi.Location = new System.Drawing.Point(14, 327);
            Daojishi.Name = "Daojishi";
            Daojishi.Size = new System.Drawing.Size(52, 14);
            Daojishi.TabIndex = 160;
            Daojishi.Text = "100秒开始倒计时:";
            
            
            
            Daojishiok.Location = new System.Drawing.Point(120, 324);
            Daojishiok.MenuManager = ribbon;
            Daojishiok.Name = "Daojishiok";
            Daojishiok.Properties.Caption = "";
            Daojishiok.Size = new System.Drawing.Size(117, 19);
            Daojishiok.TabIndex = 159;
            
            
            
            RabbitEventEndEdit.Location = new System.Drawing.Point(120, 296);
            RabbitEventEndEdit.MenuManager = ribbon;
            RabbitEventEndEdit.Name = "RabbitEventEndEdit";
            RabbitEventEndEdit.Properties.Appearance.Options.UseTextOptions = true;
            RabbitEventEndEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            RabbitEventEndEdit.Properties.Mask.EditMask = "f";
            RabbitEventEndEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            RabbitEventEndEdit.Properties.Mask.UseMaskAsDisplayFormat = true;
            RabbitEventEndEdit.Size = new System.Drawing.Size(292, 20);
            RabbitEventEndEdit.TabIndex = 74;
            
            
            
            labelControl85.Location = new System.Drawing.Point(32, 299);
            labelControl85.Name = "labelControl85";
            labelControl85.Size = new System.Drawing.Size(76, 14);
            labelControl85.TabIndex = 75;
            labelControl85.Text = "兔子活动日期:";
            
            
            
            ReleaseDateEdit.Location = new System.Drawing.Point(120, 268);
            ReleaseDateEdit.MenuManager = ribbon;
            ReleaseDateEdit.Name = "ReleaseDateEdit";
            ReleaseDateEdit.Properties.Appearance.Options.UseTextOptions = true;
            ReleaseDateEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            ReleaseDateEdit.Properties.Mask.EditMask = "f";
            ReleaseDateEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            ReleaseDateEdit.Properties.Mask.UseMaskAsDisplayFormat = true;
            ReleaseDateEdit.Size = new System.Drawing.Size(292, 20);
            ReleaseDateEdit.TabIndex = 72;
            
            
            
            labelControl70.Location = new System.Drawing.Point(56, 271);
            labelControl70.Name = "labelControl70";
            labelControl70.Size = new System.Drawing.Size(52, 14);
            labelControl70.TabIndex = 73;
            labelControl70.Text = "开区时间:";
            
            
            
            ClientPathEdit.Location = new System.Drawing.Point(120, 101);
            ClientPathEdit.MenuManager = ribbon;
            ClientPathEdit.Name = "ClientPathEdit";
            ClientPathEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            ClientPathEdit.Size = new System.Drawing.Size(292, 20);
            ClientPathEdit.TabIndex = 71;
            ClientPathEdit.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(ClientPathEdit_ButtonClick);
            
            
            
            labelControl96.Location = new System.Drawing.Point(44, 104);
            labelControl96.Name = "labelControl96";
            labelControl96.Size = new System.Drawing.Size(64, 14);
            labelControl96.TabIndex = 70;
            labelControl96.Text = "客户端路径:";
            
            
            
            MasterPasswordEdit.Location = new System.Drawing.Point(120, 213);
            MasterPasswordEdit.MenuManager = ribbon;
            MasterPasswordEdit.Name = "MasterPasswordEdit";
            MasterPasswordEdit.Properties.Appearance.Options.UseTextOptions = true;
            MasterPasswordEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            MasterPasswordEdit.Properties.PasswordChar = '*';
            MasterPasswordEdit.Size = new System.Drawing.Size(117, 20);
            MasterPasswordEdit.TabIndex = 68;
            
            
            
            labelControl67.Location = new System.Drawing.Point(68, 216);
            labelControl67.Name = "labelControl67";
            labelControl67.Size = new System.Drawing.Size(40, 14);
            labelControl67.TabIndex = 69;
            labelControl67.Text = "主密码:";
            
            
            
            MapPathEdit.Location = new System.Drawing.Point(120, 185);
            MapPathEdit.MenuManager = ribbon;
            MapPathEdit.Name = "MapPathEdit";
            MapPathEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            MapPathEdit.Size = new System.Drawing.Size(292, 20);
            MapPathEdit.TabIndex = 30;
            MapPathEdit.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(MapPathEdit_ButtonClick);
            
            
            
            labelControl13.Location = new System.Drawing.Point(56, 188);
            labelControl13.Name = "labelControl13";
            labelControl13.Size = new System.Drawing.Size(52, 14);
            labelControl13.TabIndex = 29;
            labelControl13.Text = "地图路径:";
            
            
            
            labelControl10.Location = new System.Drawing.Point(20, 160);
            labelControl10.Name = "labelControl10";
            labelControl10.Size = new System.Drawing.Size(88, 14);
            labelControl10.TabIndex = 28;
            labelControl10.Text = "数据库保存延迟:";
            
            
            
            DBSaveDelayEdit.EditValue = System.TimeSpan.Parse("00:00:00");
            DBSaveDelayEdit.Location = new System.Drawing.Point(120, 157);
            DBSaveDelayEdit.MenuManager = ribbon;
            DBSaveDelayEdit.Name = "DBSaveDelayEdit";
            DBSaveDelayEdit.Properties.AllowEditDays = false;
            DBSaveDelayEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            DBSaveDelayEdit.Properties.Mask.EditMask = "HH:mm:ss";
            DBSaveDelayEdit.Size = new System.Drawing.Size(117, 20);
            DBSaveDelayEdit.TabIndex = 27;
            
            
            
            CheckVersionButton.Location = new System.Drawing.Point(120, 70);
            CheckVersionButton.Name = "CheckVersionButton";
            CheckVersionButton.Size = new System.Drawing.Size(100, 25);
            CheckVersionButton.TabIndex = 26;
            CheckVersionButton.Text = "检查版本";
            CheckVersionButton.Click += new System.EventHandler(CheckVersionButton_Click);
            
            
            
            VersionPathEdit.Location = new System.Drawing.Point(120, 42);
            VersionPathEdit.MenuManager = ribbon;
            VersionPathEdit.Name = "VersionPathEdit";
            VersionPathEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            VersionPathEdit.Size = new System.Drawing.Size(292, 20);
            VersionPathEdit.TabIndex = 25;
            VersionPathEdit.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(VersionPathEdit_ButtonClick);
            
            
            
            labelControl5.Location = new System.Drawing.Point(56, 45);
            labelControl5.Name = "labelControl5";
            labelControl5.Size = new System.Drawing.Size(52, 14);
            labelControl5.TabIndex = 24;
            labelControl5.Text = "版本路径:";
            
            
            
            labelControl4.Location = new System.Drawing.Point(56, 17);
            labelControl4.Name = "labelControl4";
            labelControl4.Size = new System.Drawing.Size(52, 14);
            labelControl4.TabIndex = 23;
            labelControl4.Text = "检查版本:";
            
            
            
            CheckVersionEdit.Location = new System.Drawing.Point(120, 15);
            CheckVersionEdit.MenuManager = ribbon;
            CheckVersionEdit.Name = "CheckVersionEdit";
            CheckVersionEdit.Properties.Caption = "";
            CheckVersionEdit.Size = new System.Drawing.Size(117, 19);
            CheckVersionEdit.TabIndex = 22;
            
            
            
            xtraTabPage4.Controls.Add(MailDisplayNameEdit);
            xtraTabPage4.Controls.Add(labelControl31);
            xtraTabPage4.Controls.Add(MailFromEdit);
            xtraTabPage4.Controls.Add(labelControl30);
            xtraTabPage4.Controls.Add(MailPasswordEdit);
            xtraTabPage4.Controls.Add(labelControl29);
            xtraTabPage4.Controls.Add(MailAccountEdit);
            xtraTabPage4.Controls.Add(labelControl28);
            xtraTabPage4.Controls.Add(labelControl27);
            xtraTabPage4.Controls.Add(MailUseSSLEdit);
            xtraTabPage4.Controls.Add(labelControl25);
            xtraTabPage4.Controls.Add(MailPortEdit);
            xtraTabPage4.Controls.Add(MailServerEdit);
            xtraTabPage4.Controls.Add(labelControl26);
            xtraTabPage4.Name = "xtraTabPage4";
            xtraTabPage4.Size = new System.Drawing.Size(898, 435);
            xtraTabPage4.Text = "邮件";
            
            
            
            MailDisplayNameEdit.Location = new System.Drawing.Point(126, 186);
            MailDisplayNameEdit.MenuManager = ribbon;
            MailDisplayNameEdit.Name = "MailDisplayNameEdit";
            MailDisplayNameEdit.Properties.Appearance.Options.UseTextOptions = true;
            MailDisplayNameEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            MailDisplayNameEdit.Size = new System.Drawing.Size(117, 20);
            MailDisplayNameEdit.TabIndex = 70;
            
            
            
            labelControl31.Location = new System.Drawing.Point(65, 189);
            labelControl31.Name = "labelControl31";
            labelControl31.Size = new System.Drawing.Size(52, 14);
            labelControl31.TabIndex = 71;
            labelControl31.Text = "显示名字:";
            
            
            
            MailFromEdit.Location = new System.Drawing.Point(126, 158);
            MailFromEdit.MenuManager = ribbon;
            MailFromEdit.Name = "MailFromEdit";
            MailFromEdit.Properties.Appearance.Options.UseTextOptions = true;
            MailFromEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            MailFromEdit.Size = new System.Drawing.Size(117, 20);
            MailFromEdit.TabIndex = 68;
            
            
            
            labelControl30.Location = new System.Drawing.Point(89, 161);
            labelControl30.Name = "labelControl30";
            labelControl30.Size = new System.Drawing.Size(28, 14);
            labelControl30.TabIndex = 69;
            labelControl30.Text = "来源:";
            
            
            
            MailPasswordEdit.Location = new System.Drawing.Point(126, 130);
            MailPasswordEdit.MenuManager = ribbon;
            MailPasswordEdit.Name = "MailPasswordEdit";
            MailPasswordEdit.Properties.Appearance.Options.UseTextOptions = true;
            MailPasswordEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            MailPasswordEdit.Properties.PasswordChar = '*';
            MailPasswordEdit.Size = new System.Drawing.Size(117, 20);
            MailPasswordEdit.TabIndex = 66;
            
            
            
            labelControl29.Location = new System.Drawing.Point(77, 133);
            labelControl29.Name = "labelControl29";
            labelControl29.Size = new System.Drawing.Size(40, 14);
            labelControl29.TabIndex = 67;
            labelControl29.Text = "授权码:";
            
            
            
            MailAccountEdit.Location = new System.Drawing.Point(126, 102);
            MailAccountEdit.MenuManager = ribbon;
            MailAccountEdit.Name = "MailAccountEdit";
            MailAccountEdit.Properties.Appearance.Options.UseTextOptions = true;
            MailAccountEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            MailAccountEdit.Size = new System.Drawing.Size(117, 20);
            MailAccountEdit.TabIndex = 64;
            
            
            
            labelControl28.Location = new System.Drawing.Point(89, 105);
            labelControl28.Name = "labelControl28";
            labelControl28.Size = new System.Drawing.Size(28, 14);
            labelControl28.TabIndex = 65;
            labelControl28.Text = "账号:";
            
            
            
            labelControl27.Location = new System.Drawing.Point(71, 77);
            labelControl27.Name = "labelControl27";
            labelControl27.Size = new System.Drawing.Size(48, 14);
            labelControl27.TabIndex = 63;
            labelControl27.Text = "使用SSL:";
            
            
            
            MailUseSSLEdit.Location = new System.Drawing.Point(126, 75);
            MailUseSSLEdit.MenuManager = ribbon;
            MailUseSSLEdit.Name = "MailUseSSLEdit";
            MailUseSSLEdit.Properties.Caption = "";
            MailUseSSLEdit.Size = new System.Drawing.Size(117, 19);
            MailUseSSLEdit.TabIndex = 62;
            
            
            
            labelControl25.Location = new System.Drawing.Point(89, 50);
            labelControl25.Name = "labelControl25";
            labelControl25.Size = new System.Drawing.Size(28, 14);
            labelControl25.TabIndex = 34;
            labelControl25.Text = "端口:";
            
            
            
            MailPortEdit.Location = new System.Drawing.Point(126, 47);
            MailPortEdit.MenuManager = ribbon;
            MailPortEdit.Name = "MailPortEdit";
            MailPortEdit.Properties.Appearance.Options.UseTextOptions = true;
            MailPortEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            MailPortEdit.Properties.Mask.EditMask = "n0";
            MailPortEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            MailPortEdit.Properties.Mask.UseMaskAsDisplayFormat = true;
            MailPortEdit.Size = new System.Drawing.Size(117, 20);
            MailPortEdit.TabIndex = 33;
            
            
            
            MailServerEdit.Location = new System.Drawing.Point(126, 19);
            MailServerEdit.MenuManager = ribbon;
            MailServerEdit.Name = "MailServerEdit";
            MailServerEdit.Properties.Appearance.Options.UseTextOptions = true;
            MailServerEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            MailServerEdit.Size = new System.Drawing.Size(117, 20);
            MailServerEdit.TabIndex = 31;
            
            
            
            labelControl26.Location = new System.Drawing.Point(77, 22);
            labelControl26.Name = "labelControl26";
            labelControl26.Size = new System.Drawing.Size(40, 14);
            labelControl26.TabIndex = 32;
            labelControl26.Text = "服务器:";
            
            
            
            xtraTabPage5.Controls.Add(labelControl81);
            xtraTabPage5.Controls.Add(AllowBuyGammeGoldEdit);
            xtraTabPage5.Controls.Add(labelControl97);
            xtraTabPage5.Controls.Add(RequireActivationEdit);
            xtraTabPage5.Controls.Add(labelControl80);
            xtraTabPage5.Controls.Add(ProcessGameGoldEdit);
            xtraTabPage5.Controls.Add(ReceiverEMailEdit);
            xtraTabPage5.Controls.Add(labelControl79);
            xtraTabPage5.Controls.Add(IPNPrefixEdit);
            xtraTabPage5.Controls.Add(labelControl73);
            xtraTabPage5.Controls.Add(BuyAddressEdit);
            xtraTabPage5.Controls.Add(labelControl72);
            xtraTabPage5.Controls.Add(BuyPrefixEdit);
            xtraTabPage5.Controls.Add(labelControl71);
            xtraTabPage5.Controls.Add(DeleteFailLinkEdit);
            xtraTabPage5.Controls.Add(labelControl37);
            xtraTabPage5.Controls.Add(DeleteSuccessLinkEdit);
            xtraTabPage5.Controls.Add(labelControl43);
            xtraTabPage5.Controls.Add(ResetFailLinkEdit);
            xtraTabPage5.Controls.Add(labelControl32);
            xtraTabPage5.Controls.Add(ResetSuccessLinkEdit);
            xtraTabPage5.Controls.Add(labelControl33);
            xtraTabPage5.Controls.Add(ActivationFailLinkEdit);
            xtraTabPage5.Controls.Add(labelControl34);
            xtraTabPage5.Controls.Add(ActivationSuccessLinkEdit);
            xtraTabPage5.Controls.Add(labelControl35);
            xtraTabPage5.Controls.Add(labelControl41);
            xtraTabPage5.Controls.Add(WebCommandLinkEdit);
            xtraTabPage5.Controls.Add(WebPrefixEdit);
            xtraTabPage5.Controls.Add(labelControl42);
            xtraTabPage5.Name = "xtraTabPage5";
            xtraTabPage5.Size = new System.Drawing.Size(898, 435);
            xtraTabPage5.Text = "网络服务器";
            
            
            
            labelControl81.Location = new System.Drawing.Point(480, 217);
            labelControl81.Name = "labelControl81";
            labelControl81.Size = new System.Drawing.Size(76, 14);
            labelControl81.TabIndex = 101;
            labelControl81.Text = "允许购买元宝:";
            
            
            
            AllowBuyGammeGoldEdit.Location = new System.Drawing.Point(566, 215);
            AllowBuyGammeGoldEdit.MenuManager = ribbon;
            AllowBuyGammeGoldEdit.Name = "AllowBuyGammeGoldEdit";
            AllowBuyGammeGoldEdit.Properties.Caption = "";
            AllowBuyGammeGoldEdit.Size = new System.Drawing.Size(117, 19);
            AllowBuyGammeGoldEdit.TabIndex = 100;
            
            
            
            labelControl97.Location = new System.Drawing.Point(480, 295);
            labelControl97.Name = "labelControl97";
            labelControl97.Size = new System.Drawing.Size(76, 14);
            labelControl97.TabIndex = 104;
            labelControl97.Text = "允许邮箱激活:";
            
            
            
            RequireActivationEdit.Location = new System.Drawing.Point(566, 293);
            RequireActivationEdit.MenuManager = ribbon;
            RequireActivationEdit.Name = "RequireActivationEdit";
            RequireActivationEdit.Properties.Caption = "";
            RequireActivationEdit.Size = new System.Drawing.Size(117, 19);
            RequireActivationEdit.TabIndex = 102;
            
            
            
            labelControl80.Location = new System.Drawing.Point(504, 189);
            labelControl80.Name = "labelControl80";
            labelControl80.Size = new System.Drawing.Size(52, 14);
            labelControl80.TabIndex = 99;
            labelControl80.Text = "元宝流程:";
            
            
            
            ProcessGameGoldEdit.Location = new System.Drawing.Point(566, 187);
            ProcessGameGoldEdit.MenuManager = ribbon;
            ProcessGameGoldEdit.Name = "ProcessGameGoldEdit";
            ProcessGameGoldEdit.Properties.Caption = "";
            ProcessGameGoldEdit.Size = new System.Drawing.Size(117, 19);
            ProcessGameGoldEdit.TabIndex = 98;
            
            
            
            ReceiverEMailEdit.Location = new System.Drawing.Point(566, 131);
            ReceiverEMailEdit.MenuManager = ribbon;
            ReceiverEMailEdit.Name = "ReceiverEMailEdit";
            ReceiverEMailEdit.Properties.Appearance.Options.UseTextOptions = true;
            ReceiverEMailEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            ReceiverEMailEdit.Size = new System.Drawing.Size(245, 20);
            ReceiverEMailEdit.TabIndex = 96;
            
            
            
            labelControl79.Location = new System.Drawing.Point(480, 134);
            labelControl79.Name = "labelControl79";
            labelControl79.Size = new System.Drawing.Size(76, 14);
            labelControl79.TabIndex = 97;
            labelControl79.Text = "接收邮件地址:";
            
            
            
            IPNPrefixEdit.Location = new System.Drawing.Point(566, 103);
            IPNPrefixEdit.MenuManager = ribbon;
            IPNPrefixEdit.Name = "IPNPrefixEdit";
            IPNPrefixEdit.Properties.Appearance.Options.UseTextOptions = true;
            IPNPrefixEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            IPNPrefixEdit.Size = new System.Drawing.Size(245, 20);
            IPNPrefixEdit.TabIndex = 94;
            
            
            
            labelControl73.Location = new System.Drawing.Point(509, 106);
            labelControl73.Name = "labelControl73";
            labelControl73.Size = new System.Drawing.Size(47, 14);
            labelControl73.TabIndex = 95;
            labelControl73.Text = "IPN路径:";
            
            
            
            BuyAddressEdit.Location = new System.Drawing.Point(566, 47);
            BuyAddressEdit.MenuManager = ribbon;
            BuyAddressEdit.Name = "BuyAddressEdit";
            BuyAddressEdit.Properties.Appearance.Options.UseTextOptions = true;
            BuyAddressEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            BuyAddressEdit.Size = new System.Drawing.Size(245, 20);
            BuyAddressEdit.TabIndex = 92;
            
            
            
            labelControl72.Location = new System.Drawing.Point(504, 50);
            labelControl72.Name = "labelControl72";
            labelControl72.Size = new System.Drawing.Size(52, 14);
            labelControl72.TabIndex = 93;
            labelControl72.Text = "充值地址:";
            
            
            
            BuyPrefixEdit.Location = new System.Drawing.Point(566, 19);
            BuyPrefixEdit.MenuManager = ribbon;
            BuyPrefixEdit.Name = "BuyPrefixEdit";
            BuyPrefixEdit.Properties.Appearance.Options.UseTextOptions = true;
            BuyPrefixEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            BuyPrefixEdit.Size = new System.Drawing.Size(245, 20);
            BuyPrefixEdit.TabIndex = 90;
            
            
            
            labelControl71.Location = new System.Drawing.Point(504, 22);
            labelControl71.Name = "labelControl71";
            labelControl71.Size = new System.Drawing.Size(52, 14);
            labelControl71.TabIndex = 91;
            labelControl71.Text = "充值路径:";
            
            
            
            DeleteFailLinkEdit.Location = new System.Drawing.Point(174, 299);
            DeleteFailLinkEdit.MenuManager = ribbon;
            DeleteFailLinkEdit.Name = "DeleteFailLinkEdit";
            DeleteFailLinkEdit.Properties.Appearance.Options.UseTextOptions = true;
            DeleteFailLinkEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            DeleteFailLinkEdit.Size = new System.Drawing.Size(245, 20);
            DeleteFailLinkEdit.TabIndex = 88;
            
            
            
            labelControl37.Location = new System.Drawing.Point(87, 302);
            labelControl37.Name = "labelControl37";
            labelControl37.Size = new System.Drawing.Size(76, 14);
            labelControl37.TabIndex = 89;
            labelControl37.Text = "删除失败链接:";
            
            
            
            DeleteSuccessLinkEdit.Location = new System.Drawing.Point(174, 271);
            DeleteSuccessLinkEdit.MenuManager = ribbon;
            DeleteSuccessLinkEdit.Name = "DeleteSuccessLinkEdit";
            DeleteSuccessLinkEdit.Properties.Appearance.Options.UseTextOptions = true;
            DeleteSuccessLinkEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            DeleteSuccessLinkEdit.Size = new System.Drawing.Size(245, 20);
            DeleteSuccessLinkEdit.TabIndex = 86;
            
            
            
            labelControl43.Location = new System.Drawing.Point(87, 274);
            labelControl43.Name = "labelControl43";
            labelControl43.Size = new System.Drawing.Size(76, 14);
            labelControl43.TabIndex = 87;
            labelControl43.Text = "删除成功链接:";
            
            
            
            ResetFailLinkEdit.Location = new System.Drawing.Point(174, 215);
            ResetFailLinkEdit.MenuManager = ribbon;
            ResetFailLinkEdit.Name = "ResetFailLinkEdit";
            ResetFailLinkEdit.Properties.Appearance.Options.UseTextOptions = true;
            ResetFailLinkEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            ResetFailLinkEdit.Size = new System.Drawing.Size(245, 20);
            ResetFailLinkEdit.TabIndex = 84;
            
            
            
            labelControl32.Location = new System.Drawing.Point(87, 217);
            labelControl32.Name = "labelControl32";
            labelControl32.Size = new System.Drawing.Size(76, 14);
            labelControl32.TabIndex = 85;
            labelControl32.Text = "重置失败链接:";
            
            
            
            ResetSuccessLinkEdit.Location = new System.Drawing.Point(174, 187);
            ResetSuccessLinkEdit.MenuManager = ribbon;
            ResetSuccessLinkEdit.Name = "ResetSuccessLinkEdit";
            ResetSuccessLinkEdit.Properties.Appearance.Options.UseTextOptions = true;
            ResetSuccessLinkEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            ResetSuccessLinkEdit.Size = new System.Drawing.Size(245, 20);
            ResetSuccessLinkEdit.TabIndex = 82;
            
            
            
            labelControl33.Location = new System.Drawing.Point(87, 189);
            labelControl33.Name = "labelControl33";
            labelControl33.Size = new System.Drawing.Size(76, 14);
            labelControl33.TabIndex = 83;
            labelControl33.Text = "重置成功链接:";
            
            
            
            ActivationFailLinkEdit.Location = new System.Drawing.Point(174, 131);
            ActivationFailLinkEdit.MenuManager = ribbon;
            ActivationFailLinkEdit.Name = "ActivationFailLinkEdit";
            ActivationFailLinkEdit.Properties.Appearance.Options.UseTextOptions = true;
            ActivationFailLinkEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            ActivationFailLinkEdit.Size = new System.Drawing.Size(245, 20);
            ActivationFailLinkEdit.TabIndex = 80;
            
            
            
            labelControl34.Location = new System.Drawing.Point(87, 134);
            labelControl34.Name = "labelControl34";
            labelControl34.Size = new System.Drawing.Size(76, 14);
            labelControl34.TabIndex = 81;
            labelControl34.Text = "激活失败链接:";
            
            
            
            ActivationSuccessLinkEdit.Location = new System.Drawing.Point(174, 103);
            ActivationSuccessLinkEdit.MenuManager = ribbon;
            ActivationSuccessLinkEdit.Name = "ActivationSuccessLinkEdit";
            ActivationSuccessLinkEdit.Properties.Appearance.Options.UseTextOptions = true;
            ActivationSuccessLinkEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            ActivationSuccessLinkEdit.Size = new System.Drawing.Size(245, 20);
            ActivationSuccessLinkEdit.TabIndex = 78;
            
            
            
            labelControl35.Location = new System.Drawing.Point(87, 106);
            labelControl35.Name = "labelControl35";
            labelControl35.Size = new System.Drawing.Size(76, 14);
            labelControl35.TabIndex = 79;
            labelControl35.Text = "激活成功链接:";
            
            
            
            labelControl41.Location = new System.Drawing.Point(111, 50);
            labelControl41.Name = "labelControl41";
            labelControl41.Size = new System.Drawing.Size(52, 14);
            labelControl41.TabIndex = 75;
            labelControl41.Text = "命令链接:";
            
            
            
            WebCommandLinkEdit.Location = new System.Drawing.Point(174, 47);
            WebCommandLinkEdit.MenuManager = ribbon;
            WebCommandLinkEdit.Name = "WebCommandLinkEdit";
            WebCommandLinkEdit.Properties.Appearance.Options.UseTextOptions = true;
            WebCommandLinkEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            WebCommandLinkEdit.Properties.Mask.EditMask = "n0";
            WebCommandLinkEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            WebCommandLinkEdit.Properties.Mask.UseMaskAsDisplayFormat = true;
            WebCommandLinkEdit.Size = new System.Drawing.Size(245, 20);
            WebCommandLinkEdit.TabIndex = 74;
            
            
            
            WebPrefixEdit.Location = new System.Drawing.Point(174, 19);
            WebPrefixEdit.MenuManager = ribbon;
            WebPrefixEdit.Name = "WebPrefixEdit";
            WebPrefixEdit.Properties.Appearance.Options.UseTextOptions = true;
            WebPrefixEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            WebPrefixEdit.Size = new System.Drawing.Size(245, 20);
            WebPrefixEdit.TabIndex = 72;
            
            
            
            labelControl42.Location = new System.Drawing.Point(111, 23);
            labelControl42.Name = "labelControl42";
            labelControl42.Size = new System.Drawing.Size(52, 14);
            labelControl42.TabIndex = 73;
            labelControl42.Text = "网络路径:";
            
            
            
            xtraTabPage6.Controls.Add(ShidushuGuagou);
            xtraTabPage6.Controls.Add(ShidushuGuagouzi);
            xtraTabPage6.Controls.Add(ChuanranBoss);
            xtraTabPage6.Controls.Add(ChuanranBosszi);
            xtraTabPage6.Controls.Add(BeiguaiSiwangbaolv);
            xtraTabPage6.Controls.Add(BeiguaiSiwangbaolvzi);
            xtraTabPage6.Controls.Add(MingwenBangding);
            xtraTabPage6.Controls.Add(MingwenBangdingzi);
            xtraTabPage6.Controls.Add(Sanmingwen);
            xtraTabPage6.Controls.Add(Sanmingwenzi);
            xtraTabPage6.Controls.Add(Hongmingwupindiaobv);
            xtraTabPage6.Controls.Add(Hongmingwupindiaobvzi);
            xtraTabPage6.Controls.Add(Putongwupindiaobv);
            xtraTabPage6.Controls.Add(Putongwupindiaobvzi);
            xtraTabPage6.Controls.Add(Xishiwupindiaobv);
            xtraTabPage6.Controls.Add(Xishiwupindiaobvzi);
            xtraTabPage6.Controls.Add(Gaojiwupindiaobv);
            xtraTabPage6.Controls.Add(Gaojiwupindiaobvzi);
            xtraTabPage6.Controls.Add(Baoguodiaobv);
            xtraTabPage6.Controls.Add(Baoguodiaobvzi);
            xtraTabPage6.Controls.Add(Siwangbaolv);
            xtraTabPage6.Controls.Add(Siwangbaolvzi);
            xtraTabPage6.Controls.Add(KaiqiBaoshi5432);
            xtraTabPage6.Controls.Add(KaiqiBaoshi5432zi);
            xtraTabPage6.Controls.Add(Huanhuabangding);
            xtraTabPage6.Controls.Add(Huanhuabangdingzi);
            xtraTabPage6.Controls.Add(ZhuangbeiHuanhua);
            xtraTabPage6.Controls.Add(ZhuangbeiHuanhuazi);
            xtraTabPage6.Controls.Add(Liujizhuansheng);
            xtraTabPage6.Controls.Add(Liujizhuanshengzi);
            xtraTabPage6.Controls.Add(ZaixianFenjie);
            xtraTabPage6.Controls.Add(ZaixianFenjiezi);
            xtraTabPage6.Controls.Add(GunghuiGerenPaihang);
            xtraTabPage6.Controls.Add(GunghuiGerenPaihangzi);
            xtraTabPage6.Controls.Add(GunghuiPaihang);
            xtraTabPage6.Controls.Add(GunghuiPaihangzi);
            xtraTabPage6.Controls.Add(XinshouLiwu);
            xtraTabPage6.Controls.Add(XinshouLiwuzi);
            xtraTabPage6.Controls.Add(GuildLevel);
            xtraTabPage6.Controls.Add(GuildLevelzi);
            xtraTabPage6.Controls.Add(JYhuishou);
            xtraTabPage6.Controls.Add(JYhuishouzi);
            xtraTabPage6.Controls.Add(JihuowanjiaJYjiacheng);
            xtraTabPage6.Controls.Add(labelControl98);
            xtraTabPage6.Controls.Add(YaoqiuJSRjihuozhanghao);
            xtraTabPage6.Controls.Add(labelControl95);
            xtraTabPage6.Controls.Add(Jieshaorenzubeijsrgerenjingyan);
            xtraTabPage6.Controls.Add(labelControl94);
            xtraTabPage6.Controls.Add(Jieshaorenzubeijsrjingyan);
            xtraTabPage6.Controls.Add(labelControl93);
            xtraTabPage6.Controls.Add(Jieshaorenzuxinrenjingyan);
            xtraTabPage6.Controls.Add(labelControl92);
            xtraTabPage6.Controls.Add(labelControl91);
            xtraTabPage6.Controls.Add(Yunxujieshaoren);
            xtraTabPage6.Controls.Add(labelControl69);
            
            xtraTabPage6.Controls.Add(AutoReviveDelayEdit);
            xtraTabPage6.Controls.Add(daoshigroupBox1);
            xtraTabPage6.Controls.Add(ShidushuMax);
            xtraTabPage6.Controls.Add(ShidushuMaxzi);
            xtraTabPage6.Controls.Add(cikegroupBox1);
            xtraTabPage6.Controls.Add(Xiudikang);
            xtraTabPage6.Controls.Add(Xiudikangzi);
            xtraTabPage6.Controls.Add(Yidaoyihua);
            xtraTabPage6.Controls.Add(Yidaoyihuazi);
            xtraTabPage6.Controls.Add(DikangEdit);
            xtraTabPage6.Controls.Add(DikangEditZi);
            xtraTabPage6.Controls.Add(SihuaEdit);
            xtraTabPage6.Controls.Add(SihuaEditZi);
            xtraTabPage6.Controls.Add(PvPCurseRateEdit);
            xtraTabPage6.Controls.Add(labelControl83);
            xtraTabPage6.Controls.Add(labelControl84);
            xtraTabPage6.Controls.Add(PvPCurseDurationEdit);
            xtraTabPage6.Controls.Add(RedPointEdit);
            xtraTabPage6.Controls.Add(labelControl77);
            xtraTabPage6.Controls.Add(labelControl78);
            xtraTabPage6.Controls.Add(PKPointTickRateEdit);
            xtraTabPage6.Controls.Add(PKPointRateEdit);
            xtraTabPage6.Controls.Add(labelControl76);
            xtraTabPage6.Controls.Add(labelControl75);
            xtraTabPage6.Controls.Add(BrownDurationEdit);
            xtraTabPage6.Controls.Add(labelControl99);
            xtraTabPage6.Controls.Add(Shifoujilubaokaqingk);
            xtraTabPage6.Controls.Add(labelControl24);
            xtraTabPage6.Controls.Add(AllowObservationEdit);
            xtraTabPage6.Controls.Add(SkillExpEdit);
            xtraTabPage6.Controls.Add(labelControl53);
            xtraTabPage6.Controls.Add(DayCycleCountEdit);
            xtraTabPage6.Controls.Add(labelControl52);
            xtraTabPage6.Controls.Add(MaxLevelEdit);
            xtraTabPage6.Controls.Add(labelControl46);
            xtraTabPage6.Controls.Add(labelControl45);
            xtraTabPage6.Controls.Add(GlobalDelayEdit);
            xtraTabPage6.Controls.Add(labelControl44);
            xtraTabPage6.Controls.Add(ShoutDelayEdit);
            xtraTabPage6.Controls.Add(MaxViewRangeEdit);
            xtraTabPage6.Controls.Add(labelControl23);
            xtraTabPage6.Name = "xtraTabPage6";
            xtraTabPage6.Size = new System.Drawing.Size(898, 435);
            xtraTabPage6.Text = "玩家";
            
            
            
            KaiqiBaoshi5432.Location = new System.Drawing.Point(136, 662);
            KaiqiBaoshi5432.MenuManager = ribbon;
            KaiqiBaoshi5432.Name = "KaiqiBaoshi5432";
            KaiqiBaoshi5432.Properties.Caption = "";
            KaiqiBaoshi5432.Size = new System.Drawing.Size(117, 19);
            KaiqiBaoshi5432.TabIndex = 519;
            
            
            
            KaiqiBaoshi5432zi.Location = new System.Drawing.Point(3, 665);
            KaiqiBaoshi5432zi.Name = "KaiqiBaoshi5432zi";
            KaiqiBaoshi5432zi.Size = new System.Drawing.Size(64, 14);
            KaiqiBaoshi5432zi.TabIndex = 518;
            KaiqiBaoshi5432zi.Text = "是否开启5433合成宝石:";
            
            
            
            Huanhuabangding.Location = new System.Drawing.Point(136, 634);
            Huanhuabangding.MenuManager = ribbon;
            Huanhuabangding.Name = "Huanhuabangding";
            Huanhuabangding.Properties.Caption = "";
            Huanhuabangding.Size = new System.Drawing.Size(117, 19);
            Huanhuabangding.TabIndex = 515;
            
            
            
            Huanhuabangdingzi.Location = new System.Drawing.Point(3, 637);
            Huanhuabangdingzi.Name = "Huanhuabangdingzi";
            Huanhuabangdingzi.Size = new System.Drawing.Size(64, 14);
            Huanhuabangdingzi.TabIndex = 514;
            Huanhuabangdingzi.Text = "是否幻化装备后绑定装备:";
            
            
            
            ZhuangbeiHuanhua.Location = new System.Drawing.Point(136, 606);
            ZhuangbeiHuanhua.MenuManager = ribbon;
            ZhuangbeiHuanhua.Name = "ZhuangbeiHuanhua";
            ZhuangbeiHuanhua.Properties.Caption = "";
            ZhuangbeiHuanhua.Size = new System.Drawing.Size(117, 19);
            ZhuangbeiHuanhua.TabIndex = 490;
            
            
            
            ZhuangbeiHuanhuazi.Location = new System.Drawing.Point(3, 609);
            ZhuangbeiHuanhuazi.Name = "ZhuangbeiHuanhuazi";
            ZhuangbeiHuanhuazi.Size = new System.Drawing.Size(64, 14);
            ZhuangbeiHuanhuazi.TabIndex = 489;
            ZhuangbeiHuanhuazi.Text = "是否开启幻化挂钩转生:";
            
            
            
            Liujizhuansheng.Location = new System.Drawing.Point(136, 578);
            Liujizhuansheng.MenuManager = ribbon;
            Liujizhuansheng.Name = "Liujizhuansheng";
            Liujizhuansheng.Properties.Caption = "";
            Liujizhuansheng.Size = new System.Drawing.Size(117, 19);
            Liujizhuansheng.TabIndex = 488;
            
            
            
            Liujizhuanshengzi.Location = new System.Drawing.Point(27, 581);
            Liujizhuanshengzi.Name = "Liujizhuanshengzi";
            Liujizhuanshengzi.Size = new System.Drawing.Size(64, 14);
            Liujizhuanshengzi.TabIndex = 487;
            Liujizhuanshengzi.Text = "是否开启留级转生:";
            
            
            
            ZaixianFenjie.Location = new System.Drawing.Point(184, 550);
            ZaixianFenjie.MenuManager = ribbon;
            ZaixianFenjie.Name = "ZaixianFenjie";
            ZaixianFenjie.Properties.Appearance.Options.UseTextOptions = true;
            ZaixianFenjie.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            ZaixianFenjie.Properties.Mask.EditMask = "n0";
            ZaixianFenjie.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            ZaixianFenjie.Properties.Mask.UseMaskAsDisplayFormat = true;
            ZaixianFenjie.Size = new System.Drawing.Size(69, 20);
            ZaixianFenjie.TabIndex = 152;
            
            
            
            ZaixianFenjiezi.Location = new System.Drawing.Point(3, 553);
            ZaixianFenjiezi.Name = "ZaixianFenjiezi";
            ZaixianFenjiezi.Size = new System.Drawing.Size(52, 14);
            ZaixianFenjiezi.TabIndex = 479;
            ZaixianFenjiezi.Text = "包裹装备分解开启玩家转生次数:";
            
            
            
            GunghuiGerenPaihang.Location = new System.Drawing.Point(136, 522);
            GunghuiGerenPaihang.MenuManager = ribbon;
            GunghuiGerenPaihang.Name = "GunghuiGerenPaihang";
            GunghuiGerenPaihang.Properties.Caption = "";
            GunghuiGerenPaihang.Size = new System.Drawing.Size(117, 19);
            GunghuiGerenPaihang.TabIndex = 478;
            
            
            
            GunghuiGerenPaihangzi.Location = new System.Drawing.Point(3, 525);
            GunghuiGerenPaihangzi.Name = "GunghuiPaihangzi";
            GunghuiGerenPaihangzi.Size = new System.Drawing.Size(52, 14);
            GunghuiGerenPaihangzi.TabIndex = 477;
            GunghuiGerenPaihangzi.Text = "是否开启公会排行Buff:";
            
            
            
            GunghuiPaihang.Location = new System.Drawing.Point(136, 494);
            GunghuiPaihang.MenuManager = ribbon;
            GunghuiPaihang.Name = "GunghuiPaihang";
            GunghuiPaihang.Properties.Caption = "";
            GunghuiPaihang.Size = new System.Drawing.Size(117, 19);
            GunghuiPaihang.TabIndex = 476;
            
            
            
            GunghuiPaihangzi.Location = new System.Drawing.Point(3, 497);
            GunghuiPaihangzi.Name = "GunghuiPaihangzi";
            GunghuiPaihangzi.Size = new System.Drawing.Size(52, 14);
            GunghuiPaihangzi.TabIndex = 475;
            GunghuiPaihangzi.Text = "是否开启个人排行Buff:";
            
            
            
            XinshouLiwu.Location = new System.Drawing.Point(136, 466);
            XinshouLiwu.MenuManager = ribbon;
            XinshouLiwu.Name = "XinshouLiwu";
            XinshouLiwu.Properties.Caption = "";
            XinshouLiwu.Size = new System.Drawing.Size(117, 19);
            XinshouLiwu.TabIndex = 470;
            
            
            
            XinshouLiwuzi.Location = new System.Drawing.Point(27, 469);
            XinshouLiwuzi.Name = "XinshouLiwuzi";
            XinshouLiwuzi.Size = new System.Drawing.Size(76, 14);
            XinshouLiwuzi.TabIndex = 469;
            XinshouLiwuzi.Text = "是否送新手礼物:";
            
            
            
            GuildLevel.Location = new System.Drawing.Point(136, 438);
            GuildLevel.MenuManager = ribbon;
            GuildLevel.Name = "GuildLevel";
            GuildLevel.Properties.Caption = "";
            GuildLevel.Size = new System.Drawing.Size(117, 19);
            GuildLevel.TabIndex = 371;
            
            
            
            GuildLevelzi.Location = new System.Drawing.Point(27, 441);
            GuildLevelzi.Name = "GuildLevelzi";
            GuildLevelzi.Size = new System.Drawing.Size(64, 14);
            GuildLevelzi.TabIndex = 370;
            GuildLevelzi.Text = "是否开启公会等级:";
            
            
            
            JYhuishou.Location = new System.Drawing.Point(136, 410);
            JYhuishou.MenuManager = ribbon;
            JYhuishou.Name = "JYhuishou";
            JYhuishou.Properties.Appearance.Options.UseTextOptions = true;
            JYhuishou.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            JYhuishou.Properties.Mask.EditMask = "n0";
            JYhuishou.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            JYhuishou.Properties.Mask.UseMaskAsDisplayFormat = true;
            JYhuishou.Size = new System.Drawing.Size(117, 20);
            JYhuishou.TabIndex = 242;
            
            
            
            JYhuishouzi.Location = new System.Drawing.Point(27, 413);
            JYhuishouzi.Name = "JYhuishouzi";
            JYhuishouzi.Size = new System.Drawing.Size(52, 14);
            JYhuishouzi.TabIndex = 243;
            JYhuishouzi.Text = "经验回收开启等级:";
            
            
            
            JihuowanjiaJYjiacheng.Location = new System.Drawing.Point(136, 382);
            JihuowanjiaJYjiacheng.MenuManager = ribbon;
            JihuowanjiaJYjiacheng.Name = "JihuowanjiaJYjiacheng";
            JihuowanjiaJYjiacheng.Properties.Appearance.Options.UseTextOptions = true;
            JihuowanjiaJYjiacheng.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            JihuowanjiaJYjiacheng.Properties.Mask.EditMask = "n0";
            JihuowanjiaJYjiacheng.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            JihuowanjiaJYjiacheng.Properties.Mask.UseMaskAsDisplayFormat = true;
            JihuowanjiaJYjiacheng.Size = new System.Drawing.Size(117, 20);
            JihuowanjiaJYjiacheng.TabIndex = 158;
            
            
            
            labelControl98.Location = new System.Drawing.Point(27, 385);
            labelControl98.Name = "labelControl98";
            labelControl98.Size = new System.Drawing.Size(52, 14);
            labelControl98.TabIndex = 157;
            labelControl98.Text = "激活玩家经验加成:";
            
            
            
            YaoqiuJSRjihuozhanghao.Location = new System.Drawing.Point(136, 354);
            YaoqiuJSRjihuozhanghao.MenuManager = ribbon;
            YaoqiuJSRjihuozhanghao.Name = "YaoqiuJSRjihuozhanghao";
            YaoqiuJSRjihuozhanghao.Properties.Caption = "";
            YaoqiuJSRjihuozhanghao.Size = new System.Drawing.Size(117, 19);
            YaoqiuJSRjihuozhanghao.TabIndex = 156;
            
            
            
            labelControl95.Location = new System.Drawing.Point(15, 357);
            labelControl95.Name = "labelControl95";
            labelControl95.Size = new System.Drawing.Size(64, 14);
            labelControl95.TabIndex = 155;
            labelControl95.Text = "要求介绍人激活账号:";
            
            
            
            Jieshaorenzubeijsrgerenjingyan.Location = new System.Drawing.Point(184, 326);
            Jieshaorenzubeijsrgerenjingyan.MenuManager = ribbon;
            Jieshaorenzubeijsrgerenjingyan.Name = "Jieshaorenzubeijsrgerenjingyan";
            Jieshaorenzubeijsrgerenjingyan.Properties.Appearance.Options.UseTextOptions = true;
            Jieshaorenzubeijsrgerenjingyan.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            Jieshaorenzubeijsrgerenjingyan.Properties.Mask.EditMask = "n0";
            Jieshaorenzubeijsrgerenjingyan.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            Jieshaorenzubeijsrgerenjingyan.Properties.Mask.UseMaskAsDisplayFormat = true;
            Jieshaorenzubeijsrgerenjingyan.Size = new System.Drawing.Size(69, 20);
            Jieshaorenzubeijsrgerenjingyan.TabIndex = 154;
            
            
            
            labelControl94.Location = new System.Drawing.Point(3, 329);
            labelControl94.Name = "labelControl94";
            labelControl94.Size = new System.Drawing.Size(52, 14);
            labelControl94.TabIndex = 153;
            labelControl94.Text = "介绍人组被介绍人个人经验增幅:";
            
            
            
            Jieshaorenzubeijsrjingyan.Location = new System.Drawing.Point(184, 298);
            Jieshaorenzubeijsrjingyan.MenuManager = ribbon;
            Jieshaorenzubeijsrjingyan.Name = "Jieshaorenzubeijsrjingyan";
            Jieshaorenzubeijsrjingyan.Properties.Appearance.Options.UseTextOptions = true;
            Jieshaorenzubeijsrjingyan.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            Jieshaorenzubeijsrjingyan.Properties.Mask.EditMask = "n0";
            Jieshaorenzubeijsrjingyan.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            Jieshaorenzubeijsrjingyan.Properties.Mask.UseMaskAsDisplayFormat = true;
            Jieshaorenzubeijsrjingyan.Size = new System.Drawing.Size(69, 20);
            Jieshaorenzubeijsrjingyan.TabIndex = 152;
            
            
            
            labelControl93.Location = new System.Drawing.Point(3, 301);
            labelControl93.Name = "labelControl93";
            labelControl93.Size = new System.Drawing.Size(52, 14);
            labelControl93.TabIndex = 151;
            labelControl93.Text = "介绍人组被介绍人基本经验增幅:";
            
            
            
            Jieshaorenzuxinrenjingyan.Location = new System.Drawing.Point(136, 270);
            Jieshaorenzuxinrenjingyan.MenuManager = ribbon;
            Jieshaorenzuxinrenjingyan.Name = "Jieshaorenzuxinrenjingyan";
            Jieshaorenzuxinrenjingyan.Properties.Appearance.Options.UseTextOptions = true;
            Jieshaorenzuxinrenjingyan.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            Jieshaorenzuxinrenjingyan.Properties.Mask.EditMask = "n0";
            Jieshaorenzuxinrenjingyan.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            Jieshaorenzuxinrenjingyan.Properties.Mask.UseMaskAsDisplayFormat = true;
            Jieshaorenzuxinrenjingyan.Size = new System.Drawing.Size(117, 20);
            Jieshaorenzuxinrenjingyan.TabIndex = 150;
            
            
            
            labelControl92.Location = new System.Drawing.Point(3, 273);
            labelControl92.Name = "labelControl92";
            labelControl92.Size = new System.Drawing.Size(52, 14);
            labelControl92.TabIndex = 149;
            labelControl92.Text = "介绍人组新人经验增幅:";
            
            
            
            labelControl91.Location = new System.Drawing.Point(39, 245);
            labelControl91.Name = "labelControl91";
            labelControl91.Size = new System.Drawing.Size(64, 14);
            labelControl91.TabIndex = 147;
            labelControl91.Text = "允许修改介绍人:";
            
            
            
            Yunxujieshaoren.Location = new System.Drawing.Point(136, 242);
            Yunxujieshaoren.MenuManager = ribbon;
            Yunxujieshaoren.Name = "Yunxujieshaoren";
            Yunxujieshaoren.Properties.Caption = "";
            Yunxujieshaoren.Size = new System.Drawing.Size(117, 19);
            Yunxujieshaoren.TabIndex = 148;
            
            
            
            labelControl69.Location = new System.Drawing.Point(51, 217);
            labelControl69.Name = "labelControl69";
            labelControl69.Size = new System.Drawing.Size(76, 14);
            labelControl69.TabIndex = 126;
            labelControl69.Text = "自动恢复延迟:";
            
            
            
            AutoReviveDelayEdit.EditValue = System.TimeSpan.Parse("00:00:00");
            AutoReviveDelayEdit.Location = new System.Drawing.Point(136, 214);
            AutoReviveDelayEdit.MenuManager = ribbon;
            AutoReviveDelayEdit.Name = "AutoReviveDelayEdit";
            AutoReviveDelayEdit.Properties.AllowEditDays = false;
            AutoReviveDelayEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            AutoReviveDelayEdit.Properties.Mask.EditMask = "HH:mm:ss";
            AutoReviveDelayEdit.Size = new System.Drawing.Size(117, 20);
            AutoReviveDelayEdit.TabIndex = 125;
            
            
            
            labelControl99.Location = new System.Drawing.Point(716, 22);
            labelControl99.Name = "labelControl99";
            labelControl99.Size = new System.Drawing.Size(64, 14);
            labelControl99.TabIndex = 535;
            labelControl99.Text = "是否记录包卡情况:";
            
            
            
            Shifoujilubaokaqingk.Location = new System.Drawing.Point(824, 19);
            Shifoujilubaokaqingk.MenuManager = ribbon;
            Shifoujilubaokaqingk.Name = "Shifoujilubaokaqingk";
            Shifoujilubaokaqingk.Properties.Caption = "";
            Shifoujilubaokaqingk.Size = new System.Drawing.Size(117, 19);
            Shifoujilubaokaqingk.TabIndex = 534;
            
            
            
            
            MingwenBangding.Location = new System.Drawing.Point(576, 661);
            MingwenBangding.MenuManager = ribbon;
            MingwenBangding.Name = "MingwenBangding";
            MingwenBangding.Properties.Caption = "";
            MingwenBangding.Size = new System.Drawing.Size(117, 19);
            MingwenBangding.TabIndex = 527;
            
            
            
            MingwenBangdingzi.Location = new System.Drawing.Point(396, 664);
            MingwenBangdingzi.Name = "MingwenBangdingzi";
            MingwenBangdingzi.Size = new System.Drawing.Size(64, 14);
            MingwenBangdingzi.TabIndex = 526;
            MingwenBangdingzi.Text = "是否开启绑定铭文绑定武器机制:";
            
            
            
            Sanmingwen.Location = new System.Drawing.Point(494, 633);
            Sanmingwen.MenuManager = ribbon;
            Sanmingwen.Name = "Sanmingwen";
            Sanmingwen.Properties.Caption = "";
            Sanmingwen.Size = new System.Drawing.Size(117, 19);
            Sanmingwen.TabIndex = 525;
            
            
            
            Sanmingwenzi.Location = new System.Drawing.Point(396, 636);
            Sanmingwenzi.Name = "Sanmingwenzi";
            Sanmingwenzi.Size = new System.Drawing.Size(64, 14);
            Sanmingwenzi.TabIndex = 524;
            Sanmingwenzi.Text = "是否开启三铭文:";
            
            
            
            ShidushuMax.Location = new System.Drawing.Point(136, 83);
            ShidushuMax.MenuManager = ribbon;
            ShidushuMax.Name = "ShidushuMax";
            ShidushuMax.Properties.Appearance.Options.UseTextOptions = true;
            ShidushuMax.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            ShidushuMax.Properties.Mask.EditMask = "n0";
            ShidushuMax.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            ShidushuMax.Properties.Mask.UseMaskAsDisplayFormat = true;
            ShidushuMax.Size = new System.Drawing.Size(50, 20);
            ShidushuMax.TabIndex = 513;
            
            
            
            ShidushuMaxzi.Location = new System.Drawing.Point(30, 86);
            ShidushuMaxzi.Name = "Hongmingwupindiaobvzi";
            ShidushuMaxzi.Size = new System.Drawing.Size(72, 14);
            ShidushuMaxzi.TabIndex = 512;
            ShidushuMaxzi.Text = "施毒术伤害Max值:";
            
            
            
            ShidushuGuagou.Location = new System.Drawing.Point(170, 55);
            ShidushuGuagou.MenuManager = ribbon;
            ShidushuGuagou.Name = "ShidushuGuagou";
            ShidushuGuagou.Properties.Caption = "";
            ShidushuGuagou.Size = new System.Drawing.Size(117, 19);
            ShidushuGuagou.TabIndex = 511;
            
            
            
            ShidushuGuagouzi.Location = new System.Drawing.Point(30, 58);
            ShidushuGuagouzi.Name = "ShidushuGuagouzi";
            ShidushuGuagouzi.Size = new System.Drawing.Size(64, 14);
            ShidushuGuagouzi.TabIndex = 510;
            ShidushuGuagouzi.Text = "是否开启施毒术挂钩属性:";
            
            
            
            ChuanranBoss.Location = new System.Drawing.Point(170, 27);
            ChuanranBoss.MenuManager = ribbon;
            ChuanranBoss.Name = "ChuanranBoss";
            ChuanranBoss.Properties.Caption = "";
            ChuanranBoss.Size = new System.Drawing.Size(117, 19);
            ChuanranBoss.TabIndex = 509;
            
            
            
            ChuanranBosszi.Location = new System.Drawing.Point(30, 30);
            ChuanranBosszi.Name = "ChuanranBosszi";
            ChuanranBosszi.Size = new System.Drawing.Size(64, 14);
            ChuanranBosszi.TabIndex = 508;
            ChuanranBosszi.Text = "是否传染伤害对Boss开启:";
            
            
            
            daoshigroupBox1.Controls.Add((Control)ChuanranBoss);
            daoshigroupBox1.Controls.Add((Control)ChuanranBosszi);
            daoshigroupBox1.Controls.Add((Control)ShidushuGuagou);
            daoshigroupBox1.Controls.Add((Control)ShidushuGuagouzi);
            daoshigroupBox1.Controls.Add((Control)ShidushuMax);
            daoshigroupBox1.Controls.Add((Control)ShidushuMaxzi);
            daoshigroupBox1.Location = new System.Drawing.Point(395, 495);
            daoshigroupBox1.Name = "daoshigroupBox1";
            daoshigroupBox1.Size = new System.Drawing.Size(222, 120);
            daoshigroupBox1.TabIndex = 507;
            daoshigroupBox1.TabStop = false;
            daoshigroupBox1.Text = "道士设置";
            
            
            
            BeiguaiSiwangbaolv.Location = new System.Drawing.Point(560, 467);
            BeiguaiSiwangbaolv.MenuManager = ribbon;
            BeiguaiSiwangbaolv.Name = "BeiguaiSiwangbaolv";
            BeiguaiSiwangbaolv.Properties.Caption = "";
            BeiguaiSiwangbaolv.Size = new System.Drawing.Size(117, 19);
            BeiguaiSiwangbaolv.TabIndex = 504;
            
            
            
            BeiguaiSiwangbaolvzi.Location = new System.Drawing.Point(396, 470);
            BeiguaiSiwangbaolvzi.Name = "BeiguaiSiwangbaolvzi";
            BeiguaiSiwangbaolvzi.Size = new System.Drawing.Size(64, 14);
            BeiguaiSiwangbaolvzi.TabIndex = 503;
            BeiguaiSiwangbaolvzi.Text = "是否开启被怪死亡掉身上装备:";
            
            
            
            Hongmingwupindiaobv.Location = new System.Drawing.Point(500, 439);
            Hongmingwupindiaobv.MenuManager = ribbon;
            Hongmingwupindiaobv.Name = "Hongmingwupindiaobv";
            Hongmingwupindiaobv.Properties.Appearance.Options.UseTextOptions = true;
            Hongmingwupindiaobv.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            Hongmingwupindiaobv.Properties.Mask.EditMask = "n0";
            Hongmingwupindiaobv.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            Hongmingwupindiaobv.Properties.Mask.UseMaskAsDisplayFormat = true;
            Hongmingwupindiaobv.Size = new System.Drawing.Size(117, 20);
            Hongmingwupindiaobv.TabIndex = 502;
            
            
            
            Hongmingwupindiaobvzi.Location = new System.Drawing.Point(420, 442);
            Hongmingwupindiaobvzi.Name = "Hongmingwupindiaobvzi";
            Hongmingwupindiaobvzi.Size = new System.Drawing.Size(72, 14);
            Hongmingwupindiaobvzi.TabIndex = 501;
            Hongmingwupindiaobvzi.Text = "红名物品掉率:";
            
            
            
            Putongwupindiaobv.Location = new System.Drawing.Point(500, 411);
            Putongwupindiaobv.MenuManager = ribbon;
            Putongwupindiaobv.Name = "Putongwupindiaobv";
            Putongwupindiaobv.Properties.Appearance.Options.UseTextOptions = true;
            Putongwupindiaobv.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            Putongwupindiaobv.Properties.Mask.EditMask = "n0";
            Putongwupindiaobv.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            Putongwupindiaobv.Properties.Mask.UseMaskAsDisplayFormat = true;
            Putongwupindiaobv.Size = new System.Drawing.Size(117, 20);
            Putongwupindiaobv.TabIndex = 500;
            
            
            
            Putongwupindiaobvzi.Location = new System.Drawing.Point(408, 414);
            Putongwupindiaobvzi.Name = "Putongwupindiaobvzi";
            Putongwupindiaobvzi.Size = new System.Drawing.Size(72, 14);
            Putongwupindiaobvzi.TabIndex = 499;
            Putongwupindiaobvzi.Text = "普通物品的掉率:";
            
            
            
            Gaojiwupindiaobv.Location = new System.Drawing.Point(500, 383);
            Gaojiwupindiaobv.MenuManager = ribbon;
            Gaojiwupindiaobv.Name = "Gaojiwupindiaobv";
            Gaojiwupindiaobv.Properties.Appearance.Options.UseTextOptions = true;
            Gaojiwupindiaobv.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            Gaojiwupindiaobv.Properties.Mask.EditMask = "n0";
            Gaojiwupindiaobv.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            Gaojiwupindiaobv.Properties.Mask.UseMaskAsDisplayFormat = true;
            Gaojiwupindiaobv.Size = new System.Drawing.Size(117, 20);
            Gaojiwupindiaobv.TabIndex = 498;
            
            
            
            Gaojiwupindiaobvzi.Location = new System.Drawing.Point(408, 386);
            Gaojiwupindiaobvzi.Name = "Baoguodiaobvzi";
            Gaojiwupindiaobvzi.Size = new System.Drawing.Size(72, 14);
            Gaojiwupindiaobvzi.TabIndex = 497;
            Gaojiwupindiaobvzi.Text = "高级物品的掉率:";
            
            
            
            Xishiwupindiaobv.Location = new System.Drawing.Point(500, 355);
            Xishiwupindiaobv.MenuManager = ribbon;
            Xishiwupindiaobv.Name = "Xishiwupindiaobv";
            Xishiwupindiaobv.Properties.Appearance.Options.UseTextOptions = true;
            Xishiwupindiaobv.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            Xishiwupindiaobv.Properties.Mask.EditMask = "n0";
            Xishiwupindiaobv.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            Xishiwupindiaobv.Properties.Mask.UseMaskAsDisplayFormat = true;
            Xishiwupindiaobv.Size = new System.Drawing.Size(117, 20);
            Xishiwupindiaobv.TabIndex = 496;
            
            
            
            Xishiwupindiaobvzi.Location = new System.Drawing.Point(408, 358);
            Xishiwupindiaobvzi.Name = "Xishiwupindiaobvzi";
            Xishiwupindiaobvzi.Size = new System.Drawing.Size(72, 14);
            Xishiwupindiaobvzi.TabIndex = 495;
            Xishiwupindiaobvzi.Text = "稀世物品的掉率:";
            
            
            
            Baoguodiaobv.Location = new System.Drawing.Point(500, 327);
            Baoguodiaobv.MenuManager = ribbon;
            Baoguodiaobv.Name = "Baoguodiaobv";
            Baoguodiaobv.Properties.Appearance.Options.UseTextOptions = true;
            Baoguodiaobv.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            Baoguodiaobv.Properties.Mask.EditMask = "n0";
            Baoguodiaobv.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            Baoguodiaobv.Properties.Mask.UseMaskAsDisplayFormat = true;
            Baoguodiaobv.Size = new System.Drawing.Size(117, 20);
            Baoguodiaobv.TabIndex = 494;
            
            
            
            Baoguodiaobvzi.Location = new System.Drawing.Point(396, 330);
            Baoguodiaobvzi.Name = "Baoguodiaobvzi";
            Baoguodiaobvzi.Size = new System.Drawing.Size(72, 14);
            Baoguodiaobvzi.TabIndex = 493;
            Baoguodiaobvzi.Text = "包裹中的物品掉率:";
            
            
            
            Siwangbaolv.Location = new System.Drawing.Point(500, 299);
            Siwangbaolv.MenuManager = ribbon;
            Siwangbaolv.Name = "Siwangbaolv";
            Siwangbaolv.Properties.Caption = "";
            Siwangbaolv.Size = new System.Drawing.Size(117, 19);
            Siwangbaolv.TabIndex = 492;
            
            
            
            Siwangbaolvzi.Location = new System.Drawing.Point(396, 302);
            Siwangbaolvzi.Name = "Siwangbaolvzi";
            Siwangbaolvzi.Size = new System.Drawing.Size(64, 14);
            Siwangbaolvzi.TabIndex = 491;
            Siwangbaolvzi.Text = "是否开启死亡掉率:";
            
            
            
            Xiudikang.Location = new System.Drawing.Point(190, 75);
            Xiudikang.MenuManager = ribbon;
            Xiudikang.Name = "Xiudikang";
            Xiudikang.Properties.Caption = "";
            Xiudikang.Size = new System.Drawing.Size(117, 19);
            Xiudikang.TabIndex = 529;
            
            
            
            Xiudikangzi.Location = new System.Drawing.Point(120, 78);
            Xiudikangzi.Name = "Xiudikangzi";
            Xiudikangzi.Size = new System.Drawing.Size(28, 14);
            Xiudikangzi.TabIndex = 528;
            Xiudikangzi.Text = "修抵抗伤害:";
            
            
            
            Yidaoyihua.Location = new System.Drawing.Point(87, 75);
            Yidaoyihua.MenuManager = ribbon;
            Yidaoyihua.Name = "Yidaoyihua";
            Yidaoyihua.Properties.Caption = "";
            Yidaoyihua.Size = new System.Drawing.Size(117, 19);
            Yidaoyihua.TabIndex = 492;
            
            
            
            Yidaoyihuazi.Location = new System.Drawing.Point(15, 78);
            Yidaoyihuazi.Name = "Yidaoyihuazi";
            Yidaoyihuazi.Size = new System.Drawing.Size(28, 14);
            Yidaoyihuazi.TabIndex = 491;
            Yidaoyihuazi.Text = "开一刀一花:";
            
            
            
            DikangEdit.EditValue = (object)"0.20";
            DikangEdit.Location = new System.Drawing.Point(112, 47);
            DikangEdit.MenuManager = (IDXMenuManager)ribbon;
            DikangEdit.Name = "DikangEdit";
            DikangEdit.Properties.Appearance.Options.UseTextOptions = true;
            DikangEdit.Properties.Appearance.TextOptions.HAlignment = HorzAlignment.Far;
            DikangEdit.Properties.Mask.EditMask = "p";
            DikangEdit.Properties.Mask.MaskType = MaskType.Numeric;
            DikangEdit.Properties.Mask.UseMaskAsDisplayFormat = true;
            DikangEdit.Size = new System.Drawing.Size(69, 20);
            DikangEdit.TabIndex = 486;
            
            
            
            DikangEditZi.Location = new System.Drawing.Point(30, 50);
            DikangEditZi.Name = "labelControl88";
            DikangEditZi.Size = new System.Drawing.Size(52, 14);
            DikangEditZi.TabIndex = 485;
            DikangEditZi.Text = "最后抵抗技能:";
            
            
            
            SihuaEdit.EditValue = (object)"0.60";
            SihuaEdit.Location = new System.Drawing.Point(88, 19);
            SihuaEdit.MenuManager = (IDXMenuManager)ribbon;
            SihuaEdit.Name = "SihuaEdit";
            SihuaEdit.Properties.Appearance.Options.UseTextOptions = true;
            SihuaEdit.Properties.Appearance.TextOptions.HAlignment = HorzAlignment.Far;
            SihuaEdit.Properties.Mask.EditMask = "p";
            SihuaEdit.Properties.Mask.MaskType = MaskType.Numeric;
            SihuaEdit.Properties.Mask.UseMaskAsDisplayFormat = true;
            SihuaEdit.Size = new System.Drawing.Size(92, 20);
            SihuaEdit.TabIndex = 484;
            
            
            
            SihuaEditZi.Location = new System.Drawing.Point(30, 22);
            SihuaEditZi.Name = "SihuaEditZi";
            SihuaEditZi.Size = new System.Drawing.Size(52, 14);
            SihuaEditZi.TabIndex = 483;
            SihuaEditZi.Text = "四花技能:";
            
            
            
            cikegroupBox1.Controls.Add((Control)Xiudikang);
            cikegroupBox1.Controls.Add((Control)Xiudikangzi);
            cikegroupBox1.Controls.Add((Control)Yidaoyihua);
            cikegroupBox1.Controls.Add((Control)Yidaoyihuazi);
            cikegroupBox1.Controls.Add((Control)DikangEdit);
            cikegroupBox1.Controls.Add((Control)DikangEditZi);
            cikegroupBox1.Controls.Add((Control)SihuaEdit);
            cikegroupBox1.Controls.Add((Control)SihuaEditZi);
            cikegroupBox1.Location = new System.Drawing.Point(395, 190);
            cikegroupBox1.Name = "cikegroupBox1";
            cikegroupBox1.Size = new System.Drawing.Size(222, 100);
            cikegroupBox1.TabIndex = 482;
            cikegroupBox1.TabStop = false;
            cikegroupBox1.Text = "刺客设置";
            
            
            
            PvPCurseRateEdit.Location = new System.Drawing.Point(500, 159);
            PvPCurseRateEdit.MenuManager = ribbon;
            PvPCurseRateEdit.Name = "PvPCurseRateEdit";
            PvPCurseRateEdit.Properties.Appearance.Options.UseTextOptions = true;
            PvPCurseRateEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            PvPCurseRateEdit.Properties.Mask.EditMask = "n0";
            PvPCurseRateEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            PvPCurseRateEdit.Properties.Mask.UseMaskAsDisplayFormat = true;
            PvPCurseRateEdit.Size = new System.Drawing.Size(117, 20);
            PvPCurseRateEdit.TabIndex = 124;
            
            
            
            labelControl83.Location = new System.Drawing.Point(420, 162);
            labelControl83.Name = "labelControl83";
            labelControl83.Size = new System.Drawing.Size(72, 14);
            labelControl83.TabIndex = 123;
            labelControl83.Text = "PvP诅咒几率:";
            
            
            
            labelControl84.Location = new System.Drawing.Point(396, 134);
            labelControl84.Name = "labelControl84";
            labelControl84.Size = new System.Drawing.Size(96, 14);
            labelControl84.TabIndex = 122;
            labelControl84.Text = "pvp诅咒持续时间:";
            
            
            
            PvPCurseDurationEdit.EditValue = System.TimeSpan.Parse("00:00:00");
            PvPCurseDurationEdit.Location = new System.Drawing.Point(500, 131);
            PvPCurseDurationEdit.MenuManager = ribbon;
            PvPCurseDurationEdit.Name = "PvPCurseDurationEdit";
            PvPCurseDurationEdit.Properties.AllowEditDays = false;
            PvPCurseDurationEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            PvPCurseDurationEdit.Properties.Mask.EditMask = "HH:mm:ss";
            PvPCurseDurationEdit.Size = new System.Drawing.Size(117, 20);
            PvPCurseDurationEdit.TabIndex = 121;
            
            
            
            RedPointEdit.Location = new System.Drawing.Point(500, 103);
            RedPointEdit.MenuManager = ribbon;
            RedPointEdit.Name = "RedPointEdit";
            RedPointEdit.Properties.Appearance.Options.UseTextOptions = true;
            RedPointEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            RedPointEdit.Properties.Mask.EditMask = "n0";
            RedPointEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            RedPointEdit.Properties.Mask.UseMaskAsDisplayFormat = true;
            RedPointEdit.Size = new System.Drawing.Size(117, 20);
            RedPointEdit.TabIndex = 112;
            
            
            
            labelControl77.Location = new System.Drawing.Point(464, 106);
            labelControl77.Name = "labelControl77";
            labelControl77.Size = new System.Drawing.Size(28, 14);
            labelControl77.TabIndex = 111;
            labelControl77.Text = "红毒:";
            
            
            
            labelControl78.Location = new System.Drawing.Point(414, 78);
            labelControl78.Name = "labelControl78";
            labelControl78.Size = new System.Drawing.Size(78, 14);
            labelControl78.TabIndex = 110;
            labelControl78.Text = "PK点计时比率:";
            
            
            
            PKPointTickRateEdit.EditValue = System.TimeSpan.Parse("00:00:00");
            PKPointTickRateEdit.Location = new System.Drawing.Point(500, 75);
            PKPointTickRateEdit.MenuManager = ribbon;
            PKPointTickRateEdit.Name = "PKPointTickRateEdit";
            PKPointTickRateEdit.Properties.AllowEditDays = false;
            PKPointTickRateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            PKPointTickRateEdit.Properties.Mask.EditMask = "HH:mm:ss";
            PKPointTickRateEdit.Size = new System.Drawing.Size(117, 20);
            PKPointTickRateEdit.TabIndex = 109;
            
            
            
            PKPointRateEdit.Location = new System.Drawing.Point(500, 47);
            PKPointRateEdit.MenuManager = ribbon;
            PKPointRateEdit.Name = "PKPointRateEdit";
            PKPointRateEdit.Properties.Appearance.Options.UseTextOptions = true;
            PKPointRateEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            PKPointRateEdit.Properties.Mask.EditMask = "n0";
            PKPointRateEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            PKPointRateEdit.Properties.Mask.UseMaskAsDisplayFormat = true;
            PKPointRateEdit.Size = new System.Drawing.Size(117, 20);
            PKPointRateEdit.TabIndex = 108;
            
            
            
            labelControl76.Location = new System.Drawing.Point(438, 50);
            labelControl76.Name = "labelControl76";
            labelControl76.Size = new System.Drawing.Size(54, 14);
            labelControl76.TabIndex = 107;
            labelControl76.Text = "PK点比率:";
            
            
            
            labelControl75.Location = new System.Drawing.Point(416, 22);
            labelControl75.Name = "labelControl75";
            labelControl75.Size = new System.Drawing.Size(76, 14);
            labelControl75.TabIndex = 106;
            labelControl75.Text = "中毒持续时间:";
            
            
            
            BrownDurationEdit.EditValue = System.TimeSpan.Parse("00:00:00");
            BrownDurationEdit.Location = new System.Drawing.Point(500, 19);
            BrownDurationEdit.MenuManager = ribbon;
            BrownDurationEdit.Name = "BrownDurationEdit";
            BrownDurationEdit.Properties.AllowEditDays = false;
            BrownDurationEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            BrownDurationEdit.Properties.Mask.EditMask = "HH:mm:ss";
            BrownDurationEdit.Size = new System.Drawing.Size(117, 20);
            BrownDurationEdit.TabIndex = 105;
            
            
            
            labelControl24.Location = new System.Drawing.Point(63, 189);
            labelControl24.Name = "labelControl24";
            labelControl24.Size = new System.Drawing.Size(64, 14);
            labelControl24.TabIndex = 83;
            labelControl24.Text = "允许观察者:";
            
            
            
            AllowObservationEdit.Location = new System.Drawing.Point(136, 187);
            AllowObservationEdit.MenuManager = ribbon;
            AllowObservationEdit.Name = "AllowObservationEdit";
            AllowObservationEdit.Properties.Caption = "";
            AllowObservationEdit.Size = new System.Drawing.Size(117, 19);
            AllowObservationEdit.TabIndex = 82;
            
            
            
            SkillExpEdit.Location = new System.Drawing.Point(136, 159);
            SkillExpEdit.MenuManager = ribbon;
            SkillExpEdit.Name = "SkillExpEdit";
            SkillExpEdit.Properties.Appearance.Options.UseTextOptions = true;
            SkillExpEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            SkillExpEdit.Properties.Mask.EditMask = "n0";
            SkillExpEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            SkillExpEdit.Properties.Mask.UseMaskAsDisplayFormat = true;
            SkillExpEdit.Size = new System.Drawing.Size(117, 20);
            SkillExpEdit.TabIndex = 81;
            
            
            
            labelControl53.Location = new System.Drawing.Point(75, 162);
            labelControl53.Name = "labelControl53";
            labelControl53.Size = new System.Drawing.Size(52, 14);
            labelControl53.TabIndex = 80;
            labelControl53.Text = "技能经验:";
            
            
            
            DayCycleCountEdit.Location = new System.Drawing.Point(136, 131);
            DayCycleCountEdit.MenuManager = ribbon;
            DayCycleCountEdit.Name = "DayCycleCountEdit";
            DayCycleCountEdit.Properties.Appearance.Options.UseTextOptions = true;
            DayCycleCountEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            DayCycleCountEdit.Properties.Mask.EditMask = "n0";
            DayCycleCountEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            DayCycleCountEdit.Properties.Mask.UseMaskAsDisplayFormat = true;
            DayCycleCountEdit.Size = new System.Drawing.Size(117, 20);
            DayCycleCountEdit.TabIndex = 79;
            
            
            
            labelControl52.Location = new System.Drawing.Point(51, 134);
            labelControl52.Name = "labelControl52";
            labelControl52.Size = new System.Drawing.Size(76, 14);
            labelControl52.TabIndex = 78;
            labelControl52.Text = "每天循环计数:";
            
            
            
            MaxLevelEdit.Location = new System.Drawing.Point(136, 103);
            MaxLevelEdit.MenuManager = ribbon;
            MaxLevelEdit.Name = "MaxLevelEdit";
            MaxLevelEdit.Properties.Appearance.Options.UseTextOptions = true;
            MaxLevelEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            MaxLevelEdit.Properties.Mask.EditMask = "n0";
            MaxLevelEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            MaxLevelEdit.Properties.Mask.UseMaskAsDisplayFormat = true;
            MaxLevelEdit.Size = new System.Drawing.Size(117, 20);
            MaxLevelEdit.TabIndex = 77;
            
            
            
            labelControl46.Location = new System.Drawing.Point(75, 106);
            labelControl46.Name = "labelControl46";
            labelControl46.Size = new System.Drawing.Size(52, 14);
            labelControl46.TabIndex = 76;
            labelControl46.Text = "最高等级:";
            
            
            
            labelControl45.Location = new System.Drawing.Point(75, 78);
            labelControl45.Name = "labelControl45";
            labelControl45.Size = new System.Drawing.Size(52, 14);
            labelControl45.TabIndex = 75;
            labelControl45.Text = "全局延迟:";
            
            
            
            GlobalDelayEdit.EditValue = System.TimeSpan.Parse("00:00:00");
            GlobalDelayEdit.Location = new System.Drawing.Point(136, 75);
            GlobalDelayEdit.MenuManager = ribbon;
            GlobalDelayEdit.Name = "GlobalDelayEdit";
            GlobalDelayEdit.Properties.AllowEditDays = false;
            GlobalDelayEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            GlobalDelayEdit.Properties.Mask.EditMask = "HH:mm:ss";
            GlobalDelayEdit.Size = new System.Drawing.Size(117, 20);
            GlobalDelayEdit.TabIndex = 74;
            
            
            
            labelControl44.Location = new System.Drawing.Point(75, 51);
            labelControl44.Name = "labelControl44";
            labelControl44.Size = new System.Drawing.Size(52, 14);
            labelControl44.TabIndex = 73;
            labelControl44.Text = "喊话延迟:";
            
            
            
            ShoutDelayEdit.EditValue = System.TimeSpan.Parse("00:00:00");
            ShoutDelayEdit.Location = new System.Drawing.Point(136, 47);
            ShoutDelayEdit.MenuManager = ribbon;
            ShoutDelayEdit.Name = "ShoutDelayEdit";
            ShoutDelayEdit.Properties.AllowEditDays = false;
            ShoutDelayEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            ShoutDelayEdit.Properties.Mask.EditMask = "HH:mm:ss";
            ShoutDelayEdit.Size = new System.Drawing.Size(117, 20);
            ShoutDelayEdit.TabIndex = 72;
            
            
            
            MaxViewRangeEdit.Location = new System.Drawing.Point(136, 19);
            MaxViewRangeEdit.MenuManager = ribbon;
            MaxViewRangeEdit.Name = "MaxViewRangeEdit";
            MaxViewRangeEdit.Properties.Appearance.Options.UseTextOptions = true;
            MaxViewRangeEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            MaxViewRangeEdit.Properties.Mask.EditMask = "n0";
            MaxViewRangeEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            MaxViewRangeEdit.Properties.Mask.UseMaskAsDisplayFormat = true;
            MaxViewRangeEdit.Size = new System.Drawing.Size(117, 20);
            MaxViewRangeEdit.TabIndex = 35;
            
            
            
            labelControl23.Location = new System.Drawing.Point(51, 22);
            labelControl23.Name = "labelControl23";
            labelControl23.Size = new System.Drawing.Size(76, 14);
            labelControl23.TabIndex = 34;
            labelControl23.Text = "最大视野范围:";
            
            
            
            xtraTabPage7.Controls.Add(ShuaguaiBodong);
            xtraTabPage7.Controls.Add(ShuaguaiBodongzi);
            xtraTabPage7.Controls.Add(Shifoujilu);
            xtraTabPage7.Controls.Add(Chuanshifou);
            xtraTabPage7.Controls.Add(Rongyanshifou);
            xtraTabPage7.Controls.Add(Yaotashifou);
            xtraTabPage7.Controls.Add(Motashifou);
            xtraTabPage7.Controls.Add(Hd01shifou);
            xtraTabPage7.Controls.Add(Hd02shifou);
            xtraTabPage7.Controls.Add(Hd03shifou);
            xtraTabPage7.Controls.Add(Hd04shifou);
            xtraTabPage7.Controls.Add(Hd05shifou);
            xtraTabPage7.Controls.Add(Hd06shifou);
            xtraTabPage7.Controls.Add(Hd07shifou);
            xtraTabPage7.Controls.Add(Hd08shifou);
            xtraTabPage7.Controls.Add(Hd09shifou);
            xtraTabPage7.Controls.Add(Hd10shifou);
            xtraTabPage7.Controls.Add(Hd11shifou);
            xtraTabPage7.Controls.Add(Hd12shifou);
            xtraTabPage7.Controls.Add(Wendangming);
            xtraTabPage7.Controls.Add(Chuanjiluming);
            xtraTabPage7.Controls.Add(Rongyanjiluming);
            xtraTabPage7.Controls.Add(Yaotajiluming);
            xtraTabPage7.Controls.Add(Motajiluming);
            xtraTabPage7.Controls.Add(Hd01jiluming);
            xtraTabPage7.Controls.Add(Hd02jiluming);
            xtraTabPage7.Controls.Add(Hd03jiluming);
            xtraTabPage7.Controls.Add(Hd04jiluming);
            xtraTabPage7.Controls.Add(Hd05jiluming);
            xtraTabPage7.Controls.Add(Hd06jiluming);
            xtraTabPage7.Controls.Add(Hd07jiluming);
            xtraTabPage7.Controls.Add(Hd08jiluming);
            xtraTabPage7.Controls.Add(Hd09jiluming);
            xtraTabPage7.Controls.Add(Hd10jiluming);
            xtraTabPage7.Controls.Add(Hd11jiluming);
            xtraTabPage7.Controls.Add(Hd12jiluming);
            xtraTabPage7.Controls.Add(Huodong12OpenEdit);
            xtraTabPage7.Controls.Add(Huodong11OpenEdit);
            xtraTabPage7.Controls.Add(Huodong10OpenEdit);
            xtraTabPage7.Controls.Add(Huodong09OpenEdit);
            xtraTabPage7.Controls.Add(Huodong08OpenEdit);
            xtraTabPage7.Controls.Add(Huodong07OpenEdit);
            xtraTabPage7.Controls.Add(Huodong06OpenEdit);
            xtraTabPage7.Controls.Add(Huodong05OpenEdit);
            xtraTabPage7.Controls.Add(Huodong04OpenEdit);
            xtraTabPage7.Controls.Add(Huodong03OpenEdit);
            xtraTabPage7.Controls.Add(Huodong02OpenEdit);
            xtraTabPage7.Controls.Add(Huodong01OpenEdit);
            xtraTabPage7.Controls.Add(MotaOpenEdit);
            xtraTabPage7.Controls.Add(YaotaOpenEdit);
            xtraTabPage7.Controls.Add(LairRegionOpenEdit);
            xtraTabPage7.Controls.Add(MysteryShipOpenEdit);
            xtraTabPage7.Controls.Add(labelControl315);
            xtraTabPage7.Controls.Add(Huodong12Edit);
            xtraTabPage7.Controls.Add(labelControl314);
            xtraTabPage7.Controls.Add(Huodong11Edit);
            xtraTabPage7.Controls.Add(labelControl312);
            xtraTabPage7.Controls.Add(Huodong10Edit);
            xtraTabPage7.Controls.Add(labelControl310);
            xtraTabPage7.Controls.Add(Huodong09Edit);
            xtraTabPage7.Controls.Add(labelControl308);
            xtraTabPage7.Controls.Add(Huodong08Edit);
            xtraTabPage7.Controls.Add(labelControl306);
            xtraTabPage7.Controls.Add(Huodong07Edit);
            xtraTabPage7.Controls.Add(labelControl304);
            xtraTabPage7.Controls.Add(Huodong06Edit);
            xtraTabPage7.Controls.Add(labelControl302);
            xtraTabPage7.Controls.Add(Huodong05Edit);
            xtraTabPage7.Controls.Add(labelControl300);
            xtraTabPage7.Controls.Add(Huodong04Edit);
            xtraTabPage7.Controls.Add(labelControl298);
            xtraTabPage7.Controls.Add(Huodong03Edit);
            xtraTabPage7.Controls.Add(labelControl296);
            xtraTabPage7.Controls.Add(Huodong02Edit);
            xtraTabPage7.Controls.Add(labelControl294);
            xtraTabPage7.Controls.Add(Huodong01Edit);
            xtraTabPage7.Controls.Add(labelControl292);
            xtraTabPage7.Controls.Add(MotaEdit);
            xtraTabPage7.Controls.Add(labelControl290);
            xtraTabPage7.Controls.Add(yaotaEdit);
            xtraTabPage7.Controls.Add(labelControl289);
            xtraTabPage7.Controls.Add(LairRegionIndexEdit);
            xtraTabPage7.Controls.Add(labelControl82);
            xtraTabPage7.Controls.Add(MysteryShipRegionIndexEdit);
            xtraTabPage7.Controls.Add(labelControl89);
            xtraTabPage7.Controls.Add(labelControl74);
            xtraTabPage7.Controls.Add(HarvestDurationEdit);
            xtraTabPage7.Controls.Add(labelControl47);
            xtraTabPage7.Controls.Add(DeadDurationEdit);
            xtraTabPage7.Name = "xtraTabPage7";
            xtraTabPage7.Size = new System.Drawing.Size(898, 435);
            xtraTabPage7.Text = "怪物";
            
            
            
            LairRegionIndexEdit.Location = new System.Drawing.Point(166, 103);
            LairRegionIndexEdit.MenuManager = ribbon;
            LairRegionIndexEdit.Name = "LairRegionIndexEdit";
            LairRegionIndexEdit.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            LairRegionIndexEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            LairRegionIndexEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Index", "Index"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ServerDescription", "Server Description"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Size", "Size")});
            LairRegionIndexEdit.Properties.DisplayMember = "ServerDescription";
            LairRegionIndexEdit.Properties.NullText = "[Region is null]";
            LairRegionIndexEdit.Properties.ValueMember = "Index";
            LairRegionIndexEdit.Size = new System.Drawing.Size(203, 20);
            LairRegionIndexEdit.TabIndex = 125;
            
            
            
            labelControl82.Location = new System.Drawing.Point(126, 106);
            labelControl82.Name = "labelControl82";
            labelControl82.Size = new System.Drawing.Size(28, 14);
            labelControl82.TabIndex = 124;
            labelControl82.Text = "熔岩:";
            
            
            
            MysteryShipRegionIndexEdit.Location = new System.Drawing.Point(166, 75);
            MysteryShipRegionIndexEdit.MenuManager = ribbon;
            MysteryShipRegionIndexEdit.Name = "MysteryShipRegionIndexEdit";
            MysteryShipRegionIndexEdit.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            MysteryShipRegionIndexEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            MysteryShipRegionIndexEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Index", "Index"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ServerDescription", "Server Description"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Size", "Size")});
            MysteryShipRegionIndexEdit.Properties.DisplayMember = "ServerDescription";
            MysteryShipRegionIndexEdit.Properties.NullText = "[Region is null]";
            MysteryShipRegionIndexEdit.Properties.ValueMember = "Index";
            MysteryShipRegionIndexEdit.Size = new System.Drawing.Size(203, 20);
            MysteryShipRegionIndexEdit.TabIndex = 123;
            
            
            
            labelControl89.Location = new System.Drawing.Point(126, 78);
            labelControl89.Name = "labelControl89";
            labelControl89.Size = new System.Drawing.Size(28, 14);
            labelControl89.TabIndex = 117;
            labelControl89.Text = "神舰:";
            
            
            
            yaotaEdit.Location = new System.Drawing.Point(166, 131);
            yaotaEdit.MenuManager = ribbon;
            yaotaEdit.Name = "yaotaEdit";
            yaotaEdit.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            yaotaEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            yaotaEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Index", "Index"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ServerDescription", "Server Description"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Size", "Size")});
            yaotaEdit.Properties.DisplayMember = "ServerDescription";
            yaotaEdit.Properties.NullText = "[Region is null]";
            yaotaEdit.Properties.ValueMember = "Index";
            yaotaEdit.Size = new System.Drawing.Size(203, 20);
            yaotaEdit.TabIndex = 289;
            
            
            
            labelControl289.Location = new System.Drawing.Point(90, 134);
            labelControl289.Name = "labelControl289";
            labelControl289.Size = new System.Drawing.Size(28, 14);
            labelControl289.TabIndex = 288;
            labelControl289.Text = "比奇地下城:";
            
            
            
            MotaEdit.Location = new System.Drawing.Point(166, 159);
            MotaEdit.MenuManager = ribbon;
            MotaEdit.Name = "MotaEdit";
            MotaEdit.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            MotaEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            MotaEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Index", "Index"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ServerDescription", "Server Description"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Size", "Size")});
            MotaEdit.Properties.DisplayMember = "ServerDescription";
            MotaEdit.Properties.NullText = "[Region is null]";
            MotaEdit.Properties.ValueMember = "Index";
            MotaEdit.Size = new System.Drawing.Size(203, 20);
            MotaEdit.TabIndex = 290;
            
            
            
            labelControl290.Location = new System.Drawing.Point(112, 162);
            labelControl290.Name = "labelControl290";
            labelControl290.Size = new System.Drawing.Size(28, 14);
            labelControl290.TabIndex = 291;
            labelControl290.Text = "魔虫洞:";
            
            
            
            Huodong01Edit.Location = new System.Drawing.Point(166, 187);
            Huodong01Edit.MenuManager = ribbon;
            Huodong01Edit.Name = "Huodong01Edit";
            Huodong01Edit.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            Huodong01Edit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            Huodong01Edit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Index", "Index"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ServerDescription", "Server Description"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Size", "Size")});
            Huodong01Edit.Properties.DisplayMember = "ServerDescription";
            Huodong01Edit.Properties.NullText = "[Region is null]";
            Huodong01Edit.Properties.ValueMember = "Index";
            Huodong01Edit.Size = new System.Drawing.Size(203, 20);
            Huodong01Edit.TabIndex = 292;
            
            
            
            labelControl292.Location = new System.Drawing.Point(112, 190);
            labelControl292.Name = "labelControl292";
            labelControl292.Size = new System.Drawing.Size(28, 14);
            labelControl292.TabIndex = 293;
            labelControl292.Text = "活动01:";
            
            
            
            Huodong02Edit.Location = new System.Drawing.Point(166, 215);
            Huodong02Edit.MenuManager = ribbon;
            Huodong02Edit.Name = "Huodong02Edit";
            Huodong02Edit.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            Huodong02Edit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            Huodong02Edit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Index", "Index"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ServerDescription", "Server Description"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Size", "Size")});
            Huodong02Edit.Properties.DisplayMember = "ServerDescription";
            Huodong02Edit.Properties.NullText = "[Region is null]";
            Huodong02Edit.Properties.ValueMember = "Index";
            Huodong02Edit.Size = new System.Drawing.Size(203, 20);
            Huodong02Edit.TabIndex = 294;
            
            
            
            labelControl294.Location = new System.Drawing.Point(112, 218);
            labelControl294.Name = "labelControl294";
            labelControl294.Size = new System.Drawing.Size(28, 14);
            labelControl294.TabIndex = 295;
            labelControl294.Text = "活动02:";
            
            
            
            Huodong03Edit.Location = new System.Drawing.Point(166, 243);
            Huodong03Edit.MenuManager = ribbon;
            Huodong03Edit.Name = "Huodong03Edit";
            Huodong03Edit.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            Huodong03Edit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            Huodong03Edit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Index", "Index"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ServerDescription", "Server Description"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Size", "Size")});
            Huodong03Edit.Properties.DisplayMember = "ServerDescription";
            Huodong03Edit.Properties.NullText = "[Region is null]";
            Huodong03Edit.Properties.ValueMember = "Index";
            Huodong03Edit.Size = new System.Drawing.Size(203, 20);
            Huodong03Edit.TabIndex = 296;
            
            
            
            labelControl296.Location = new System.Drawing.Point(112, 246);
            labelControl296.Name = "labelControl296";
            labelControl296.Size = new System.Drawing.Size(28, 14);
            labelControl296.TabIndex = 297;
            labelControl296.Text = "活动03:";
            
            
            
            Huodong04Edit.Location = new System.Drawing.Point(166, 271);
            Huodong04Edit.MenuManager = ribbon;
            Huodong04Edit.Name = "Huodong04Edit";
            Huodong04Edit.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            Huodong04Edit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            Huodong04Edit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Index", "Index"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ServerDescription", "Server Description"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Size", "Size")});
            Huodong04Edit.Properties.DisplayMember = "ServerDescription";
            Huodong04Edit.Properties.NullText = "[Region is null]";
            Huodong04Edit.Properties.ValueMember = "Index";
            Huodong04Edit.Size = new System.Drawing.Size(203, 20);
            Huodong04Edit.TabIndex = 298;
            
            
            
            labelControl298.Location = new System.Drawing.Point(112, 274);
            labelControl298.Name = "labelControl298";
            labelControl298.Size = new System.Drawing.Size(28, 14);
            labelControl298.TabIndex = 299;
            labelControl298.Text = "活动04:";
            
            
            
            Huodong05Edit.Location = new System.Drawing.Point(166, 299);
            Huodong05Edit.MenuManager = ribbon;
            Huodong05Edit.Name = "Huodong05Edit";
            Huodong05Edit.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            Huodong05Edit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            Huodong05Edit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Index", "Index"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ServerDescription", "Server Description"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Size", "Size")});
            Huodong05Edit.Properties.DisplayMember = "ServerDescription";
            Huodong05Edit.Properties.NullText = "[Region is null]";
            Huodong05Edit.Properties.ValueMember = "Index";
            Huodong05Edit.Size = new System.Drawing.Size(203, 20);
            Huodong05Edit.TabIndex = 300;
            
            
            
            labelControl300.Location = new System.Drawing.Point(112, 302);
            labelControl300.Name = "labelControl300";
            labelControl300.Size = new System.Drawing.Size(28, 14);
            labelControl300.TabIndex = 301;
            labelControl300.Text = "活动05:";
            
            
            
            Huodong06Edit.Location = new System.Drawing.Point(166, 327);
            Huodong06Edit.MenuManager = ribbon;
            Huodong06Edit.Name = "Huodong06Edit";
            Huodong06Edit.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            Huodong06Edit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            Huodong06Edit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Index", "Index"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ServerDescription", "Server Description"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Size", "Size")});
            Huodong06Edit.Properties.DisplayMember = "ServerDescription";
            Huodong06Edit.Properties.NullText = "[Region is null]";
            Huodong06Edit.Properties.ValueMember = "Index";
            Huodong06Edit.Size = new System.Drawing.Size(203, 20);
            Huodong06Edit.TabIndex = 302;
            
            
            
            labelControl302.Location = new System.Drawing.Point(112, 330);
            labelControl302.Name = "labelControl302";
            labelControl302.Size = new System.Drawing.Size(28, 14);
            labelControl302.TabIndex = 303;
            labelControl302.Text = "活动06:";
            
            
            
            Huodong07Edit.Location = new System.Drawing.Point(166, 355);
            Huodong07Edit.MenuManager = ribbon;
            Huodong07Edit.Name = "Huodong07Edit";
            Huodong07Edit.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            Huodong07Edit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            Huodong07Edit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Index", "Index"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ServerDescription", "Server Description"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Size", "Size")});
            Huodong07Edit.Properties.DisplayMember = "ServerDescription";
            Huodong07Edit.Properties.NullText = "[Region is null]";
            Huodong07Edit.Properties.ValueMember = "Index";
            Huodong07Edit.Size = new System.Drawing.Size(203, 20);
            Huodong07Edit.TabIndex = 304;
            
            
            
            labelControl304.Location = new System.Drawing.Point(112, 358);
            labelControl304.Name = "labelControl304";
            labelControl304.Size = new System.Drawing.Size(28, 14);
            labelControl304.TabIndex = 305;
            labelControl304.Text = "活动07:";
            
            
            
            Huodong08Edit.Location = new System.Drawing.Point(166, 383);
            Huodong08Edit.MenuManager = ribbon;
            Huodong08Edit.Name = "Huodong08Edit";
            Huodong08Edit.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            Huodong08Edit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            Huodong08Edit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Index", "Index"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ServerDescription", "Server Description"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Size", "Size")});
            Huodong08Edit.Properties.DisplayMember = "ServerDescription";
            Huodong08Edit.Properties.NullText = "[Region is null]";
            Huodong08Edit.Properties.ValueMember = "Index";
            Huodong08Edit.Size = new System.Drawing.Size(203, 20);
            Huodong08Edit.TabIndex = 306;
            
            
            
            labelControl306.Location = new System.Drawing.Point(112, 386);
            labelControl306.Name = "labelControl306";
            labelControl306.Size = new System.Drawing.Size(28, 14);
            labelControl306.TabIndex = 307;
            labelControl306.Text = "活动08:";
            
            
            
            Huodong09Edit.Location = new System.Drawing.Point(166, 411);
            Huodong09Edit.MenuManager = ribbon;
            Huodong09Edit.Name = "Huodong09Edit";
            Huodong09Edit.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            Huodong09Edit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            Huodong09Edit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Index", "Index"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ServerDescription", "Server Description"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Size", "Size")});
            Huodong09Edit.Properties.DisplayMember = "ServerDescription";
            Huodong09Edit.Properties.NullText = "[Region is null]";
            Huodong09Edit.Properties.ValueMember = "Index";
            Huodong09Edit.Size = new System.Drawing.Size(203, 20);
            Huodong09Edit.TabIndex = 308;
            
            
            
            labelControl308.Location = new System.Drawing.Point(112, 414);
            labelControl308.Name = "labelControl308";
            labelControl308.Size = new System.Drawing.Size(28, 14);
            labelControl308.TabIndex = 309;
            labelControl308.Text = "活动09:";
            
            
            
            Huodong10Edit.Location = new System.Drawing.Point(166, 439);
            Huodong10Edit.MenuManager = ribbon;
            Huodong10Edit.Name = "Huodong10Edit";
            Huodong10Edit.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            Huodong10Edit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            Huodong10Edit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Index", "Index"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ServerDescription", "Server Description"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Size", "Size")});
            Huodong10Edit.Properties.DisplayMember = "ServerDescription";
            Huodong10Edit.Properties.NullText = "[Region is null]";
            Huodong10Edit.Properties.ValueMember = "Index";
            Huodong10Edit.Size = new System.Drawing.Size(203, 20);
            Huodong10Edit.TabIndex = 310;
            
            
            
            labelControl310.Location = new System.Drawing.Point(112, 442);
            labelControl310.Name = "labelControl310";
            labelControl310.Size = new System.Drawing.Size(28, 14);
            labelControl310.TabIndex = 311;
            labelControl310.Text = "活动10:";
            
            
            
            Huodong11Edit.Location = new System.Drawing.Point(166, 467);
            Huodong11Edit.MenuManager = ribbon;
            Huodong11Edit.Name = "Huodong11Edit";
            Huodong11Edit.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            Huodong11Edit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            Huodong11Edit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Index", "Index"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ServerDescription", "Server Description"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Size", "Size")});
            Huodong11Edit.Properties.DisplayMember = "ServerDescription";
            Huodong11Edit.Properties.NullText = "[Region is null]";
            Huodong11Edit.Properties.ValueMember = "Index";
            Huodong11Edit.Size = new System.Drawing.Size(203, 20);
            Huodong11Edit.TabIndex = 312;
            
            
            
            labelControl312.Location = new System.Drawing.Point(112, 470);
            labelControl312.Name = "labelControl312";
            labelControl312.Size = new System.Drawing.Size(28, 14);
            labelControl312.TabIndex = 313;
            labelControl312.Text = "活动11:";
            
            
            
            Huodong12Edit.Location = new System.Drawing.Point(166, 495);
            Huodong12Edit.MenuManager = ribbon;
            Huodong12Edit.Name = "Huodong12Edit";
            Huodong12Edit.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            Huodong12Edit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            Huodong12Edit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Index", "Index"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ServerDescription", "Server Description"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Size", "Size")});
            Huodong12Edit.Properties.DisplayMember = "ServerDescription";
            Huodong12Edit.Properties.NullText = "[Region is null]";
            Huodong12Edit.Properties.ValueMember = "Index";
            Huodong12Edit.Size = new System.Drawing.Size(203, 20);
            Huodong12Edit.TabIndex = 314;
            
            
            
            ShuaguaiBodongzi.Location = new System.Drawing.Point(30, 526);
            ShuaguaiBodongzi.Name = "ShuaguaiBodongzi";
            ShuaguaiBodongzi.Size = new System.Drawing.Size(76, 14);
            ShuaguaiBodongzi.TabIndex = 506;
            ShuaguaiBodongzi.Text = "是否开启刷怪时间延迟:";
            
            
            
            ShuaguaiBodong.Location = new System.Drawing.Point(165, 523);
            ShuaguaiBodong.MenuManager = ribbon;
            ShuaguaiBodong.Name = "ShuaguaiBodong";
            ShuaguaiBodong.Properties.Caption = "";
            ShuaguaiBodong.Size = new System.Drawing.Size(117, 19);
            ShuaguaiBodong.TabIndex = 505;
            
            
            
            labelControl314.Location = new System.Drawing.Point(112, 498);
            labelControl314.Name = "labelControl314";
            labelControl314.Size = new System.Drawing.Size(28, 14);
            labelControl314.TabIndex = 315;
            labelControl314.Text = "活动12:";
            
            
            
            MysteryShipOpenEdit.Location = new System.Drawing.Point(376, 75);
            MysteryShipOpenEdit.MenuManager = ribbon;
            MysteryShipOpenEdit.Name = "MysteryShipOpenEdit";
            MysteryShipOpenEdit.Properties.Appearance.Options.UseTextOptions = true;
            MysteryShipOpenEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            MysteryShipOpenEdit.Properties.Mask.EditMask = "n0";
            MysteryShipOpenEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            MysteryShipOpenEdit.Properties.Mask.UseMaskAsDisplayFormat = true;
            MysteryShipOpenEdit.Size = new System.Drawing.Size(40, 20);
            MysteryShipOpenEdit.TabIndex = 316;
            
            
            
            LairRegionOpenEdit.Location = new System.Drawing.Point(376, 103);
            LairRegionOpenEdit.MenuManager = ribbon;
            LairRegionOpenEdit.Name = "LairRegionOpenEdit";
            LairRegionOpenEdit.Properties.Appearance.Options.UseTextOptions = true;
            LairRegionOpenEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            LairRegionOpenEdit.Properties.Mask.EditMask = "n0";
            LairRegionOpenEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            LairRegionOpenEdit.Properties.Mask.UseMaskAsDisplayFormat = true;
            LairRegionOpenEdit.Size = new System.Drawing.Size(40, 20);
            LairRegionOpenEdit.TabIndex = 318;
            
            
            
            YaotaOpenEdit.Location = new System.Drawing.Point(376, 131);
            YaotaOpenEdit.MenuManager = ribbon;
            YaotaOpenEdit.Name = "YaotaOpenEdit";
            YaotaOpenEdit.Properties.Appearance.Options.UseTextOptions = true;
            YaotaOpenEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            YaotaOpenEdit.Properties.Mask.EditMask = "n0";
            YaotaOpenEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            YaotaOpenEdit.Properties.Mask.UseMaskAsDisplayFormat = true;
            YaotaOpenEdit.Size = new System.Drawing.Size(40, 20);
            YaotaOpenEdit.TabIndex = 319;
            
            
            
            MotaOpenEdit.Location = new System.Drawing.Point(376, 159);
            MotaOpenEdit.MenuManager = ribbon;
            MotaOpenEdit.Name = "MotaOpenEdit";
            MotaOpenEdit.Properties.Appearance.Options.UseTextOptions = true;
            MotaOpenEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            MotaOpenEdit.Properties.Mask.EditMask = "n0";
            MotaOpenEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            MotaOpenEdit.Properties.Mask.UseMaskAsDisplayFormat = true;
            MotaOpenEdit.Size = new System.Drawing.Size(40, 20);
            MotaOpenEdit.TabIndex = 320;
            
            
            
            Huodong01OpenEdit.Location = new System.Drawing.Point(376, 187);
            Huodong01OpenEdit.MenuManager = ribbon;
            Huodong01OpenEdit.Name = "Huodong01OpenEdit";
            Huodong01OpenEdit.Properties.Appearance.Options.UseTextOptions = true;
            Huodong01OpenEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            Huodong01OpenEdit.Properties.Mask.EditMask = "n0";
            Huodong01OpenEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            Huodong01OpenEdit.Properties.Mask.UseMaskAsDisplayFormat = true;
            Huodong01OpenEdit.Size = new System.Drawing.Size(40, 20);
            Huodong01OpenEdit.TabIndex = 321;
            
            
            
            Huodong02OpenEdit.Location = new System.Drawing.Point(376, 215);
            Huodong02OpenEdit.MenuManager = ribbon;
            Huodong02OpenEdit.Name = "Huodong02OpenEdit";
            Huodong02OpenEdit.Properties.Appearance.Options.UseTextOptions = true;
            Huodong02OpenEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            Huodong02OpenEdit.Properties.Mask.EditMask = "n0";
            Huodong02OpenEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            Huodong02OpenEdit.Properties.Mask.UseMaskAsDisplayFormat = true;
            Huodong02OpenEdit.Size = new System.Drawing.Size(40, 20);
            Huodong02OpenEdit.TabIndex = 322;
            
            
            
            Huodong03OpenEdit.Location = new System.Drawing.Point(376, 243);
            Huodong03OpenEdit.MenuManager = ribbon;
            Huodong03OpenEdit.Name = "Huodong03OpenEdit";
            Huodong03OpenEdit.Properties.Appearance.Options.UseTextOptions = true;
            Huodong03OpenEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            Huodong03OpenEdit.Properties.Mask.EditMask = "n0";
            Huodong03OpenEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            Huodong03OpenEdit.Properties.Mask.UseMaskAsDisplayFormat = true;
            Huodong03OpenEdit.Size = new System.Drawing.Size(40, 20);
            Huodong03OpenEdit.TabIndex = 323;
            
            
            
            Huodong04OpenEdit.Location = new System.Drawing.Point(376, 271);
            Huodong04OpenEdit.MenuManager = ribbon;
            Huodong04OpenEdit.Name = "Huodong04OpenEdit";
            Huodong04OpenEdit.Properties.Appearance.Options.UseTextOptions = true;
            Huodong04OpenEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            Huodong04OpenEdit.Properties.Mask.EditMask = "n0";
            Huodong04OpenEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            Huodong04OpenEdit.Properties.Mask.UseMaskAsDisplayFormat = true;
            Huodong04OpenEdit.Size = new System.Drawing.Size(40, 20);
            Huodong04OpenEdit.TabIndex = 324;
            
            
            
            Huodong05OpenEdit.Location = new System.Drawing.Point(376, 299);
            Huodong05OpenEdit.MenuManager = ribbon;
            Huodong05OpenEdit.Name = "Huodong05OpenEdit";
            Huodong05OpenEdit.Properties.Appearance.Options.UseTextOptions = true;
            Huodong05OpenEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            Huodong05OpenEdit.Properties.Mask.EditMask = "n0";
            Huodong05OpenEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            Huodong05OpenEdit.Properties.Mask.UseMaskAsDisplayFormat = true;
            Huodong05OpenEdit.Size = new System.Drawing.Size(40, 20);
            Huodong05OpenEdit.TabIndex = 325;
            
            
            
            Huodong06OpenEdit.Location = new System.Drawing.Point(376, 327);
            Huodong06OpenEdit.MenuManager = ribbon;
            Huodong06OpenEdit.Name = "Huodong06OpenEdit";
            Huodong06OpenEdit.Properties.Appearance.Options.UseTextOptions = true;
            Huodong06OpenEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            Huodong06OpenEdit.Properties.Mask.EditMask = "n0";
            Huodong06OpenEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            Huodong06OpenEdit.Properties.Mask.UseMaskAsDisplayFormat = true;
            Huodong06OpenEdit.Size = new System.Drawing.Size(40, 20);
            Huodong06OpenEdit.TabIndex = 326;
            
            
            
            Huodong07OpenEdit.Location = new System.Drawing.Point(376, 355);
            Huodong07OpenEdit.MenuManager = ribbon;
            Huodong07OpenEdit.Name = "Huodong07OpenEdit";
            Huodong07OpenEdit.Properties.Appearance.Options.UseTextOptions = true;
            Huodong07OpenEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            Huodong07OpenEdit.Properties.Mask.EditMask = "n0";
            Huodong07OpenEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            Huodong07OpenEdit.Properties.Mask.UseMaskAsDisplayFormat = true;
            Huodong07OpenEdit.Size = new System.Drawing.Size(40, 20);
            Huodong07OpenEdit.TabIndex = 327;
            
            
            
            Huodong08OpenEdit.Location = new System.Drawing.Point(376, 383);
            Huodong08OpenEdit.MenuManager = ribbon;
            Huodong08OpenEdit.Name = "Huodong08OpenEdit";
            Huodong08OpenEdit.Properties.Appearance.Options.UseTextOptions = true;
            Huodong08OpenEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            Huodong08OpenEdit.Properties.Mask.EditMask = "n0";
            Huodong08OpenEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            Huodong08OpenEdit.Properties.Mask.UseMaskAsDisplayFormat = true;
            Huodong08OpenEdit.Size = new System.Drawing.Size(40, 20);
            Huodong08OpenEdit.TabIndex = 328;
            
            
            
            Huodong09OpenEdit.Location = new System.Drawing.Point(376, 411);
            Huodong09OpenEdit.MenuManager = ribbon;
            Huodong09OpenEdit.Name = "Huodong09OpenEdit";
            Huodong09OpenEdit.Properties.Appearance.Options.UseTextOptions = true;
            Huodong09OpenEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            Huodong09OpenEdit.Properties.Mask.EditMask = "n0";
            Huodong09OpenEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            Huodong09OpenEdit.Properties.Mask.UseMaskAsDisplayFormat = true;
            Huodong09OpenEdit.Size = new System.Drawing.Size(40, 20);
            Huodong09OpenEdit.TabIndex = 329;
            
            
            
            Huodong10OpenEdit.Location = new System.Drawing.Point(376, 439);
            Huodong10OpenEdit.MenuManager = ribbon;
            Huodong10OpenEdit.Name = "Huodong10OpenEdit";
            Huodong10OpenEdit.Properties.Appearance.Options.UseTextOptions = true;
            Huodong10OpenEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            Huodong10OpenEdit.Properties.Mask.EditMask = "n0";
            Huodong10OpenEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            Huodong10OpenEdit.Properties.Mask.UseMaskAsDisplayFormat = true;
            Huodong10OpenEdit.Size = new System.Drawing.Size(40, 20);
            Huodong10OpenEdit.TabIndex = 330;
            
            
            
            Huodong11OpenEdit.Location = new System.Drawing.Point(376, 467);
            Huodong11OpenEdit.MenuManager = ribbon;
            Huodong11OpenEdit.Name = "Huodong11OpenEdit";
            Huodong11OpenEdit.Properties.Appearance.Options.UseTextOptions = true;
            Huodong11OpenEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            Huodong11OpenEdit.Properties.Mask.EditMask = "n0";
            Huodong11OpenEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            Huodong11OpenEdit.Properties.Mask.UseMaskAsDisplayFormat = true;
            Huodong11OpenEdit.Size = new System.Drawing.Size(40, 20);
            Huodong11OpenEdit.TabIndex = 331;
            
            
            
            Huodong12OpenEdit.Location = new System.Drawing.Point(376, 495);
            Huodong12OpenEdit.MenuManager = ribbon;
            Huodong12OpenEdit.Name = "Huodong12OpenEdit";
            Huodong12OpenEdit.Properties.Appearance.Options.UseTextOptions = true;
            Huodong12OpenEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            Huodong12OpenEdit.Properties.Mask.EditMask = "n0";
            Huodong12OpenEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            Huodong12OpenEdit.Properties.Mask.UseMaskAsDisplayFormat = true;
            Huodong12OpenEdit.Size = new System.Drawing.Size(40, 20);
            Huodong12OpenEdit.TabIndex = 332;
            
            
            
            labelControl315.Location = new System.Drawing.Point(368, 58);
            labelControl315.Name = "labelControl315";
            labelControl315.Size = new System.Drawing.Size(52, 14);
            labelControl315.TabIndex = 317;
            labelControl315.Text = "开门时间";
            
            
            
            Wendangming.Location = new System.Drawing.Point(444, 58);
            Wendangming.Name = "Wendangming";
            Wendangming.Size = new System.Drawing.Size(42, 14);
            Wendangming.TabIndex = 147;
            Wendangming.Text = "记录文档名称";
            
            
            
            Chuanjiluming.Location = new System.Drawing.Point(444, 75);
            Chuanjiluming.MenuManager = ribbon;
            Chuanjiluming.Name = "Chuanjiluming";
            Chuanjiluming.Properties.Appearance.Options.UseTextOptions = true;
            Chuanjiluming.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            Chuanjiluming.Size = new System.Drawing.Size(60, 20);
            Chuanjiluming.TabIndex = 350;
            
            
            
            Rongyanjiluming.Location = new System.Drawing.Point(444, 103);
            Rongyanjiluming.MenuManager = ribbon;
            Rongyanjiluming.Name = "Rongyanjiluming";
            Rongyanjiluming.Properties.Appearance.Options.UseTextOptions = true;
            Rongyanjiluming.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            Rongyanjiluming.Size = new System.Drawing.Size(60, 20);
            Rongyanjiluming.TabIndex = 351;
            
            
            
            Yaotajiluming.Location = new System.Drawing.Point(444, 131);
            Yaotajiluming.MenuManager = ribbon;
            Yaotajiluming.Name = "Yaotajiluming";
            Yaotajiluming.Properties.Appearance.Options.UseTextOptions = true;
            Yaotajiluming.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            Yaotajiluming.Size = new System.Drawing.Size(60, 20);
            Yaotajiluming.TabIndex = 352;
            
            
            
            Motajiluming.Location = new System.Drawing.Point(444, 159);
            Motajiluming.MenuManager = ribbon;
            Motajiluming.Name = "Motajiluming";
            Motajiluming.Properties.Appearance.Options.UseTextOptions = true;
            Motajiluming.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            Motajiluming.Size = new System.Drawing.Size(60, 20);
            Motajiluming.TabIndex = 353;
            
            
            
            Hd01jiluming.Location = new System.Drawing.Point(444, 187);
            Hd01jiluming.MenuManager = ribbon;
            Hd01jiluming.Name = "Hd01jiluming";
            Hd01jiluming.Properties.Appearance.Options.UseTextOptions = true;
            Hd01jiluming.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            Hd01jiluming.Size = new System.Drawing.Size(60, 20);
            Hd01jiluming.TabIndex = 354;
            
            
            
            Hd02jiluming.Location = new System.Drawing.Point(444, 215);
            Hd02jiluming.MenuManager = ribbon;
            Hd02jiluming.Name = "Hd02jiluming";
            Hd02jiluming.Properties.Appearance.Options.UseTextOptions = true;
            Hd02jiluming.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            Hd02jiluming.Size = new System.Drawing.Size(60, 20);
            Hd02jiluming.TabIndex = 355;
            
            
            
            Hd03jiluming.Location = new System.Drawing.Point(444, 243);
            Hd03jiluming.MenuManager = ribbon;
            Hd03jiluming.Name = "Hd03jiluming";
            Hd03jiluming.Properties.Appearance.Options.UseTextOptions = true;
            Hd03jiluming.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            Hd03jiluming.Size = new System.Drawing.Size(60, 20);
            Hd03jiluming.TabIndex = 356;
            
            
            
            Hd04jiluming.Location = new System.Drawing.Point(444, 271);
            Hd04jiluming.MenuManager = ribbon;
            Hd04jiluming.Name = "Hd04jiluming";
            Hd04jiluming.Properties.Appearance.Options.UseTextOptions = true;
            Hd04jiluming.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            Hd04jiluming.Size = new System.Drawing.Size(60, 20);
            Hd04jiluming.TabIndex = 357;
            
            
            
            Hd05jiluming.Location = new System.Drawing.Point(444, 299);
            Hd05jiluming.MenuManager = ribbon;
            Hd05jiluming.Name = "Hd05jiluming";
            Hd05jiluming.Properties.Appearance.Options.UseTextOptions = true;
            Hd05jiluming.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            Hd05jiluming.Size = new System.Drawing.Size(60, 20);
            Hd05jiluming.TabIndex = 358;
            
            
            
            Hd06jiluming.Location = new System.Drawing.Point(444, 327);
            Hd06jiluming.MenuManager = ribbon;
            Hd06jiluming.Name = "Hd06jiluming";
            Hd06jiluming.Properties.Appearance.Options.UseTextOptions = true;
            Hd06jiluming.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            Hd06jiluming.Size = new System.Drawing.Size(60, 20);
            Hd06jiluming.TabIndex = 359;
            
            
            
            Hd07jiluming.Location = new System.Drawing.Point(444, 355);
            Hd07jiluming.MenuManager = ribbon;
            Hd07jiluming.Name = "Hd07jiluming";
            Hd07jiluming.Properties.Appearance.Options.UseTextOptions = true;
            Hd07jiluming.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            Hd07jiluming.Size = new System.Drawing.Size(60, 20);
            Hd07jiluming.TabIndex = 360;
            
            
            
            Hd08jiluming.Location = new System.Drawing.Point(444, 383);
            Hd08jiluming.MenuManager = ribbon;
            Hd08jiluming.Name = "Hd08jiluming";
            Hd08jiluming.Properties.Appearance.Options.UseTextOptions = true;
            Hd08jiluming.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            Hd08jiluming.Size = new System.Drawing.Size(60, 20);
            Hd08jiluming.TabIndex = 361;
            
            
            
            Hd09jiluming.Location = new System.Drawing.Point(444, 411);
            Hd09jiluming.MenuManager = ribbon;
            Hd09jiluming.Name = "Hd09jiluming";
            Hd09jiluming.Properties.Appearance.Options.UseTextOptions = true;
            Hd09jiluming.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            Hd09jiluming.Size = new System.Drawing.Size(60, 20);
            Hd09jiluming.TabIndex = 362;
            
            
            
            Hd10jiluming.Location = new System.Drawing.Point(444, 439);
            Hd10jiluming.MenuManager = ribbon;
            Hd10jiluming.Name = "Hd10jiluming";
            Hd10jiluming.Properties.Appearance.Options.UseTextOptions = true;
            Hd10jiluming.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            Hd10jiluming.Size = new System.Drawing.Size(60, 20);
            Hd10jiluming.TabIndex = 363;
            
            
            
            Hd11jiluming.Location = new System.Drawing.Point(444, 467);
            Hd11jiluming.MenuManager = ribbon;
            Hd11jiluming.Name = "Hd11jiluming";
            Hd11jiluming.Properties.Appearance.Options.UseTextOptions = true;
            Hd11jiluming.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            Hd11jiluming.Size = new System.Drawing.Size(60, 20);
            Hd11jiluming.TabIndex = 364;
            
            
            
            Hd12jiluming.Location = new System.Drawing.Point(444, 495);
            Hd12jiluming.MenuManager = ribbon;
            Hd12jiluming.Name = "Hd12jiluming";
            Hd12jiluming.Properties.Appearance.Options.UseTextOptions = true;
            Hd12jiluming.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            Hd12jiluming.Size = new System.Drawing.Size(60, 20);
            Hd12jiluming.TabIndex = 365;
            
            
            
            Shifoujilu.Location = new System.Drawing.Point(420, 58);
            Shifoujilu.Name = "Shifoujilu";
            Shifoujilu.Size = new System.Drawing.Size(24, 14);
            Shifoujilu.TabIndex = 333;
            Shifoujilu.Text = "是否";
            
            
            
            Chuanshifou.Location = new System.Drawing.Point(420, 75);
            Chuanshifou.MenuManager = ribbon;
            Chuanshifou.Name = "Chuanshifou";
            Chuanshifou.Properties.Caption = "";
            Chuanshifou.Size = new System.Drawing.Size(20, 19);
            Chuanshifou.TabIndex = 334;
            
            
            
            Rongyanshifou.Location = new System.Drawing.Point(420, 103);
            Rongyanshifou.MenuManager = ribbon;
            Rongyanshifou.Name = "Rongyanshifou";
            Rongyanshifou.Properties.Caption = "";
            Rongyanshifou.Size = new System.Drawing.Size(20, 19);
            Rongyanshifou.TabIndex = 335;
            
            
            
            Yaotashifou.Location = new System.Drawing.Point(420, 131);
            Yaotashifou.MenuManager = ribbon;
            Yaotashifou.Name = "Yaotashifou";
            Yaotashifou.Properties.Caption = "";
            Yaotashifou.Size = new System.Drawing.Size(20, 19);
            Yaotashifou.TabIndex = 336;
            
            
            
            Motashifou.Location = new System.Drawing.Point(420, 159);
            Motashifou.MenuManager = ribbon;
            Motashifou.Name = "Motashifou";
            Motashifou.Properties.Caption = "";
            Motashifou.Size = new System.Drawing.Size(20, 19);
            Motashifou.TabIndex = 337;
            
            
            
            Hd01shifou.Location = new System.Drawing.Point(420, 187);
            Hd01shifou.MenuManager = ribbon;
            Hd01shifou.Name = "Hd01shifou";
            Hd01shifou.Properties.Caption = "";
            Hd01shifou.Size = new System.Drawing.Size(20, 19);
            Hd01shifou.TabIndex = 338;
            
            
            
            Hd02shifou.Location = new System.Drawing.Point(420, 215);
            Hd02shifou.MenuManager = ribbon;
            Hd02shifou.Name = "Hd02shifou";
            Hd02shifou.Properties.Caption = "";
            Hd02shifou.Size = new System.Drawing.Size(20, 19);
            Hd02shifou.TabIndex = 339;
            
            
            
            Hd03shifou.Location = new System.Drawing.Point(420, 243);
            Hd03shifou.MenuManager = ribbon;
            Hd03shifou.Name = "Hd03shifou";
            Hd03shifou.Properties.Caption = "";
            Hd03shifou.Size = new System.Drawing.Size(20, 19);
            Hd03shifou.TabIndex = 340;
            
            
            
            Hd04shifou.Location = new System.Drawing.Point(420, 271);
            Hd04shifou.MenuManager = ribbon;
            Hd04shifou.Name = "Hd04shifou";
            Hd04shifou.Properties.Caption = "";
            Hd04shifou.Size = new System.Drawing.Size(20, 19);
            Hd04shifou.TabIndex = 341;
            
            
            
            Hd05shifou.Location = new System.Drawing.Point(420, 299);
            Hd05shifou.MenuManager = ribbon;
            Hd05shifou.Name = "Hd05shifou";
            Hd05shifou.Properties.Caption = "";
            Hd05shifou.Size = new System.Drawing.Size(20, 19);
            Hd05shifou.TabIndex = 342;
            
            
            
            Hd06shifou.Location = new System.Drawing.Point(420, 327);
            Hd06shifou.MenuManager = ribbon;
            Hd06shifou.Name = "Hd06shifou";
            Hd06shifou.Properties.Caption = "";
            Hd06shifou.Size = new System.Drawing.Size(20, 19);
            Hd06shifou.TabIndex = 343;
            
            
            
            Hd07shifou.Location = new System.Drawing.Point(420, 355);
            Hd07shifou.MenuManager = ribbon;
            Hd07shifou.Name = "Hd07shifou";
            Hd07shifou.Properties.Caption = "";
            Hd07shifou.Size = new System.Drawing.Size(20, 19);
            Hd07shifou.TabIndex = 344;
            
            
            
            Hd08shifou.Location = new System.Drawing.Point(420, 383);
            Hd08shifou.MenuManager = ribbon;
            Hd08shifou.Name = "Hd08shifou";
            Hd08shifou.Properties.Caption = "";
            Hd08shifou.Size = new System.Drawing.Size(20, 19);
            Hd08shifou.TabIndex = 345;
            
            
            
            Hd09shifou.Location = new System.Drawing.Point(420, 411);
            Hd09shifou.MenuManager = ribbon;
            Hd09shifou.Name = "Hd09shifou";
            Hd09shifou.Properties.Caption = "";
            Hd09shifou.Size = new System.Drawing.Size(20, 19);
            Hd09shifou.TabIndex = 346;
            
            
            
            Hd10shifou.Location = new System.Drawing.Point(420, 439);
            Hd10shifou.MenuManager = ribbon;
            Hd10shifou.Name = "Hd10shifou";
            Hd10shifou.Properties.Caption = "";
            Hd10shifou.Size = new System.Drawing.Size(20, 19);
            Hd10shifou.TabIndex = 347;
            
            
            
            Hd11shifou.Location = new System.Drawing.Point(420, 467);
            Hd11shifou.MenuManager = ribbon;
            Hd11shifou.Name = "Hd11shifou";
            Hd11shifou.Properties.Caption = "";
            Hd11shifou.Size = new System.Drawing.Size(20, 19);
            Hd11shifou.TabIndex = 348;
            
            
            
            Hd12shifou.Location = new System.Drawing.Point(420, 495);
            Hd12shifou.MenuManager = ribbon;
            Hd12shifou.Name = "Hd12shifou";
            Hd12shifou.Properties.Caption = "";
            Hd12shifou.Size = new System.Drawing.Size(20, 19);
            Hd12shifou.TabIndex = 349;
            
            
            
            labelControl74.Location = new System.Drawing.Point(78, 50);
            labelControl74.Name = "labelControl74";
            labelControl74.Size = new System.Drawing.Size(76, 14);
            labelControl74.TabIndex = 104;
            labelControl74.Text = "割肉持续时间:";
            
            
            
            HarvestDurationEdit.EditValue = System.TimeSpan.Parse("00:00:00");
            HarvestDurationEdit.Location = new System.Drawing.Point(166, 47);
            HarvestDurationEdit.MenuManager = ribbon;
            HarvestDurationEdit.Name = "HarvestDurationEdit";
            HarvestDurationEdit.Properties.AllowEditDays = false;
            HarvestDurationEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            HarvestDurationEdit.Properties.Mask.EditMask = "HH:mm:ss";
            HarvestDurationEdit.Size = new System.Drawing.Size(117, 20);
            HarvestDurationEdit.TabIndex = 103;
            
            
            
            labelControl47.Location = new System.Drawing.Point(78, 22);
            labelControl47.Name = "labelControl47";
            labelControl47.Size = new System.Drawing.Size(76, 14);
            labelControl47.TabIndex = 75;
            labelControl47.Text = "死亡持续时间:";
            
            
            
            DeadDurationEdit.EditValue = System.TimeSpan.Parse("00:00:00");
            DeadDurationEdit.Location = new System.Drawing.Point(166, 19);
            DeadDurationEdit.MenuManager = ribbon;
            DeadDurationEdit.Name = "DeadDurationEdit";
            DeadDurationEdit.Properties.AllowEditDays = false;
            DeadDurationEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            DeadDurationEdit.Properties.Mask.EditMask = "HH:mm:ss";
            DeadDurationEdit.Size = new System.Drawing.Size(117, 20);
            DeadDurationEdit.TabIndex = 74;
            
            
            
            xtraTabPage8.Controls.Add(StrengthLossRateEdit);
            xtraTabPage8.Controls.Add(labelControl64);
            xtraTabPage8.Controls.Add(StrengthAddRateEdit);
            xtraTabPage8.Controls.Add(labelControl65);
            xtraTabPage8.Controls.Add(MaxStrengthEdit);
            xtraTabPage8.Controls.Add(labelControl66);
            xtraTabPage8.Controls.Add(CurseRateEdit);
            xtraTabPage8.Controls.Add(labelControl63);
            xtraTabPage8.Controls.Add(labelControl88);
            xtraTabPage8.Controls.Add(XieJipindaxiaogailvy);
            xtraTabPage8.Controls.Add(XieJipindaxiaogailve);
            xtraTabPage8.Controls.Add(XieJipindaxiaogailvs);
            xtraTabPage8.Controls.Add(XieJipindaxiaogailvsi);
            xtraTabPage8.Controls.Add(XieJipindaxiaogailvw);
            xtraTabPage8.Controls.Add(XieJipindaxiaogailvl);
            xtraTabPage8.Controls.Add(XieJipindaxiaogailvzi);
            xtraTabPage8.Controls.Add(TouJipindaxiaogailvy);
            xtraTabPage8.Controls.Add(TouJipindaxiaogailve);
            xtraTabPage8.Controls.Add(TouJipindaxiaogailvs);
            xtraTabPage8.Controls.Add(TouJipindaxiaogailvsi);
            xtraTabPage8.Controls.Add(TouJipindaxiaogailvw);
            xtraTabPage8.Controls.Add(TouJipindaxiaogailvl);
            xtraTabPage8.Controls.Add(TouJipindaxiaogailvzi);
            xtraTabPage8.Controls.Add(YiJipindaxiaogailvy);
            xtraTabPage8.Controls.Add(YiJipindaxiaogailve);
            xtraTabPage8.Controls.Add(YiJipindaxiaogailvs);
            xtraTabPage8.Controls.Add(YiJipindaxiaogailvsi);
            xtraTabPage8.Controls.Add(YiJipindaxiaogailvw);
            xtraTabPage8.Controls.Add(YiJipindaxiaogailvl);
            xtraTabPage8.Controls.Add(YiJipindaxiaogailvzi);
            xtraTabPage8.Controls.Add(DunJipindaxiaogailvy);
            xtraTabPage8.Controls.Add(DunJipindaxiaogailve);
            xtraTabPage8.Controls.Add(DunJipindaxiaogailvs);
            xtraTabPage8.Controls.Add(DunJipindaxiaogailvsi);
            xtraTabPage8.Controls.Add(DunJipindaxiaogailvw);
            xtraTabPage8.Controls.Add(DunJipindaxiaogailvl);
            xtraTabPage8.Controls.Add(DunJipindaxiaogailvzi);
            xtraTabPage8.Controls.Add(GyJipindaxiaogailvy);
            xtraTabPage8.Controls.Add(GyJipindaxiaogailve);
            xtraTabPage8.Controls.Add(GyJipindaxiaogailvs);
            xtraTabPage8.Controls.Add(GyJipindaxiaogailvsi);
            xtraTabPage8.Controls.Add(GyJipindaxiaogailvw);
            xtraTabPage8.Controls.Add(GyJipindaxiaogailvl);
            xtraTabPage8.Controls.Add(GyJipindaxiaogailvzi);
            xtraTabPage8.Controls.Add(Jipindaxiaogailvy);
            xtraTabPage8.Controls.Add(Jipindaxiaogailve);
            xtraTabPage8.Controls.Add(Jipindaxiaogailvs);
            xtraTabPage8.Controls.Add(Jipindaxiaogailvsi);
            xtraTabPage8.Controls.Add(Jipindaxiaogailvw);
            xtraTabPage8.Controls.Add(Jipindaxiaogailvl);
            xtraTabPage8.Controls.Add(Jipindaxiaogailvzi);
            xtraTabPage8.Controls.Add(Jipindaxiaoy);
            xtraTabPage8.Controls.Add(Jipindaxiaoe);
            xtraTabPage8.Controls.Add(Jipindaxiaos);
            xtraTabPage8.Controls.Add(Jipindaxiaosi);
            xtraTabPage8.Controls.Add(Jipindaxiaow);
            xtraTabPage8.Controls.Add(Jipindaxiaol);
            xtraTabPage8.Controls.Add(Jipindaxiaozi);
            xtraTabPage8.Controls.Add(Jipindebaolv);
            xtraTabPage8.Controls.Add(Jipindebaolvzi);
            xtraTabPage8.Controls.Add(Mfguajishijian);
            xtraTabPage8.Controls.Add(Mfguajishijianzi);
            xtraTabPage8.Controls.Add(LabelControl88TaxSani);
            xtraTabPage8.Controls.Add(labelControl90);
            xtraTabPage8.Controls.Add(LabelControl90TaxSani);
            xtraTabPage8.Controls.Add(MaxCurseEdit);
            xtraTabPage8.Controls.Add(labelControl62);
            xtraTabPage8.Controls.Add(LuckRateEdit);
            xtraTabPage8.Controls.Add(labelControl61);
            xtraTabPage8.Controls.Add(MaxLuckEdit);
            xtraTabPage8.Controls.Add(labelControl60);
            xtraTabPage8.Controls.Add(labelControl59);
            xtraTabPage8.Controls.Add(SpecialRepairDelayEdit);
            xtraTabPage8.Controls.Add(TorchRateEdit);
            xtraTabPage8.Controls.Add(labelControl54);
            xtraTabPage8.Controls.Add(DropLayersEdit);
            xtraTabPage8.Controls.Add(labelControl50);
            xtraTabPage8.Controls.Add(DropDistanceEdit);
            xtraTabPage8.Controls.Add(labelControl49);
            xtraTabPage8.Controls.Add(labelControl48);
            xtraTabPage8.Controls.Add(DropDurationEdit);
            xtraTabPage8.Controls.Add(wakuangbangdingZi);
            xtraTabPage8.Controls.Add(wakuangbangding);
            xtraTabPage8.Name = "xtraTabPage8";
            xtraTabPage8.Size = new System.Drawing.Size(898, 435);
            xtraTabPage8.Text = "道具";
            
            
            
            StrengthLossRateEdit.Location = new System.Drawing.Point(399, 221);
            StrengthLossRateEdit.MenuManager = ribbon;
            StrengthLossRateEdit.Name = "StrengthLossRateEdit";
            StrengthLossRateEdit.Properties.Appearance.Options.UseTextOptions = true;
            StrengthLossRateEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            StrengthLossRateEdit.Properties.Mask.EditMask = "n0";
            StrengthLossRateEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            StrengthLossRateEdit.Properties.Mask.UseMaskAsDisplayFormat = true;
            StrengthLossRateEdit.Size = new System.Drawing.Size(117, 20);
            StrengthLossRateEdit.TabIndex = 100;
            
            
            
            labelControl64.Location = new System.Drawing.Point(325, 224);
            labelControl64.Name = "labelControl64";
            labelControl64.Size = new System.Drawing.Size(64, 14);
            labelControl64.TabIndex = 99;
            labelControl64.Text = "强度损耗率:";
            
            
            
            StrengthAddRateEdit.Location = new System.Drawing.Point(399, 193);
            StrengthAddRateEdit.MenuManager = ribbon;
            StrengthAddRateEdit.Name = "StrengthAddRateEdit";
            StrengthAddRateEdit.Properties.Appearance.Options.UseTextOptions = true;
            StrengthAddRateEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            StrengthAddRateEdit.Properties.Mask.EditMask = "n0";
            StrengthAddRateEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            StrengthAddRateEdit.Properties.Mask.UseMaskAsDisplayFormat = true;
            StrengthAddRateEdit.Size = new System.Drawing.Size(117, 20);
            StrengthAddRateEdit.TabIndex = 98;
            
            
            
            labelControl65.Location = new System.Drawing.Point(313, 196);
            labelControl65.Name = "labelControl65";
            labelControl65.Size = new System.Drawing.Size(76, 14);
            labelControl65.TabIndex = 97;
            labelControl65.Text = "强度增加几率:";
            
            
            
            MaxStrengthEdit.Location = new System.Drawing.Point(399, 165);
            MaxStrengthEdit.MenuManager = ribbon;
            MaxStrengthEdit.Name = "MaxStrengthEdit";
            MaxStrengthEdit.Properties.Appearance.Options.UseTextOptions = true;
            MaxStrengthEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            MaxStrengthEdit.Properties.Mask.EditMask = "n0";
            MaxStrengthEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            MaxStrengthEdit.Properties.Mask.UseMaskAsDisplayFormat = true;
            MaxStrengthEdit.Size = new System.Drawing.Size(117, 20);
            MaxStrengthEdit.TabIndex = 96;
            
            
            
            labelControl66.Location = new System.Drawing.Point(337, 168);
            labelControl66.Name = "labelControl66";
            labelControl66.Size = new System.Drawing.Size(52, 14);
            labelControl66.TabIndex = 95;
            labelControl66.Text = "最高强度:";
            
            
            
            CurseRateEdit.Location = new System.Drawing.Point(141, 249);
            CurseRateEdit.MenuManager = ribbon;
            CurseRateEdit.Name = "CurseRateEdit";
            CurseRateEdit.Properties.Appearance.Options.UseTextOptions = true;
            CurseRateEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            CurseRateEdit.Properties.Mask.EditMask = "n0";
            CurseRateEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            CurseRateEdit.Properties.Mask.UseMaskAsDisplayFormat = true;
            CurseRateEdit.Size = new System.Drawing.Size(117, 20);
            CurseRateEdit.TabIndex = 94;
            
            
            
            labelControl66.Location = new System.Drawing.Point(337, 168);
            labelControl66.Name = "labelControl66";
            labelControl66.Size = new System.Drawing.Size(52, 14);
            labelControl66.TabIndex = 95;
            labelControl66.Text = "最高强度:";
            
            
            
            CurseRateEdit.Location = new System.Drawing.Point(141, 249);
            CurseRateEdit.MenuManager = ribbon;
            CurseRateEdit.Name = "CurseRateEdit";
            CurseRateEdit.Properties.Appearance.Options.UseTextOptions = true;
            CurseRateEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            CurseRateEdit.Properties.Mask.EditMask = "n0";
            CurseRateEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            CurseRateEdit.Properties.Mask.UseMaskAsDisplayFormat = true;
            CurseRateEdit.Size = new System.Drawing.Size(117, 20);
            CurseRateEdit.TabIndex = 94;
            
            
            
            XieJipindaxiaogailvl.Location = new System.Drawing.Point(209, 728);
            XieJipindaxiaogailvl.MenuManager = ribbon;
            XieJipindaxiaogailvl.Name = "XieJipindaxiaogailvl";
            XieJipindaxiaogailvl.Properties.Appearance.Options.UseTextOptions = true;
            XieJipindaxiaogailvl.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            XieJipindaxiaogailvl.Properties.Mask.EditMask = "n0";
            XieJipindaxiaogailvl.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            XieJipindaxiaogailvl.Properties.Mask.UseMaskAsDisplayFormat = true;
            XieJipindaxiaogailvl.Size = new System.Drawing.Size(50, 20);
            XieJipindaxiaogailvl.TabIndex = 414;
            
            
            
            XieJipindaxiaogailvw.Location = new System.Drawing.Point(164, 728);
            XieJipindaxiaogailvw.MenuManager = ribbon;
            XieJipindaxiaogailvw.Name = "XieJipindaxiaogailvw";
            XieJipindaxiaogailvw.Properties.Appearance.Options.UseTextOptions = true;
            XieJipindaxiaogailvw.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            XieJipindaxiaogailvw.Properties.Mask.EditMask = "n0";
            XieJipindaxiaogailvw.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            XieJipindaxiaogailvw.Properties.Mask.UseMaskAsDisplayFormat = true;
            XieJipindaxiaogailvw.Size = new System.Drawing.Size(40, 20);
            XieJipindaxiaogailvw.TabIndex = 413;
            
            
            
            XieJipindaxiaogailvsi.Location = new System.Drawing.Point(124, 728);
            XieJipindaxiaogailvsi.MenuManager = ribbon;
            XieJipindaxiaogailvsi.Name = "XieJipindaxiaogailvsi";
            XieJipindaxiaogailvsi.Properties.Appearance.Options.UseTextOptions = true;
            XieJipindaxiaogailvsi.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            XieJipindaxiaogailvsi.Properties.Mask.EditMask = "n0";
            XieJipindaxiaogailvsi.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            XieJipindaxiaogailvsi.Properties.Mask.UseMaskAsDisplayFormat = true;
            XieJipindaxiaogailvsi.Size = new System.Drawing.Size(35, 20);
            XieJipindaxiaogailvsi.TabIndex = 412;
            
            
            
            XieJipindaxiaogailvs.Location = new System.Drawing.Point(84, 728);
            XieJipindaxiaogailvs.MenuManager = ribbon;
            XieJipindaxiaogailvs.Name = "XieJipindaxiaogailvs";
            XieJipindaxiaogailvs.Properties.Appearance.Options.UseTextOptions = true;
            XieJipindaxiaogailvs.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            XieJipindaxiaogailvs.Properties.Mask.EditMask = "n0";
            XieJipindaxiaogailvs.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            XieJipindaxiaogailvs.Properties.Mask.UseMaskAsDisplayFormat = true;
            XieJipindaxiaogailvs.Size = new System.Drawing.Size(35, 20);
            XieJipindaxiaogailvs.TabIndex = 411;
            
            
            
            XieJipindaxiaogailve.Location = new System.Drawing.Point(44, 728);
            XieJipindaxiaogailve.MenuManager = ribbon;
            XieJipindaxiaogailve.Name = "XieJipindaxiaogailve";
            XieJipindaxiaogailve.Properties.Appearance.Options.UseTextOptions = true;
            XieJipindaxiaogailve.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            XieJipindaxiaogailve.Properties.Mask.EditMask = "n0";
            XieJipindaxiaogailve.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            XieJipindaxiaogailve.Properties.Mask.UseMaskAsDisplayFormat = true;
            XieJipindaxiaogailve.Size = new System.Drawing.Size(35, 20);
            XieJipindaxiaogailve.TabIndex = 410;
            
            
            
            XieJipindaxiaogailvy.Location = new System.Drawing.Point(14, 728);
            XieJipindaxiaogailvy.MenuManager = ribbon;
            XieJipindaxiaogailvy.Name = "XieJipindaxiaogailvy";
            XieJipindaxiaogailvy.Properties.Appearance.Options.UseTextOptions = true;
            XieJipindaxiaogailvy.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            XieJipindaxiaogailvy.Properties.Mask.EditMask = "n0";
            XieJipindaxiaogailvy.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            XieJipindaxiaogailvy.Properties.Mask.UseMaskAsDisplayFormat = true;
            XieJipindaxiaogailvy.Size = new System.Drawing.Size(25, 20);
            XieJipindaxiaogailvy.TabIndex = 409;
            
            
            
            XieJipindaxiaogailvzi.Location = new System.Drawing.Point(14, 700);
            XieJipindaxiaogailvzi.Name = "XieJipindaxiaogailvzi";
            XieJipindaxiaogailvzi.Size = new System.Drawing.Size(76, 14);
            XieJipindaxiaogailvzi.TabIndex = 408;
            XieJipindaxiaogailvzi.Text = "鞋子手镯防御、魔御的大小生产概率:";
            
            
            
            TouJipindaxiaogailvl.Location = new System.Drawing.Point(209, 672);
            TouJipindaxiaogailvl.MenuManager = ribbon;
            TouJipindaxiaogailvl.Name = "TouJipindaxiaogailvl";
            TouJipindaxiaogailvl.Properties.Appearance.Options.UseTextOptions = true;
            TouJipindaxiaogailvl.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            TouJipindaxiaogailvl.Properties.Mask.EditMask = "n0";
            TouJipindaxiaogailvl.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            TouJipindaxiaogailvl.Properties.Mask.UseMaskAsDisplayFormat = true;
            TouJipindaxiaogailvl.Size = new System.Drawing.Size(50, 20);
            TouJipindaxiaogailvl.TabIndex = 407;
            
            
            
            TouJipindaxiaogailvw.Location = new System.Drawing.Point(164, 672);
            TouJipindaxiaogailvw.MenuManager = ribbon;
            TouJipindaxiaogailvw.Name = "TouJipindaxiaogailvw";
            TouJipindaxiaogailvw.Properties.Appearance.Options.UseTextOptions = true;
            TouJipindaxiaogailvw.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            TouJipindaxiaogailvw.Properties.Mask.EditMask = "n0";
            TouJipindaxiaogailvw.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            TouJipindaxiaogailvw.Properties.Mask.UseMaskAsDisplayFormat = true;
            TouJipindaxiaogailvw.Size = new System.Drawing.Size(40, 20);
            TouJipindaxiaogailvw.TabIndex = 406;
            
            
            
            TouJipindaxiaogailvsi.Location = new System.Drawing.Point(124, 672);
            TouJipindaxiaogailvsi.MenuManager = ribbon;
            TouJipindaxiaogailvsi.Name = "TouJipindaxiaogailvsi";
            TouJipindaxiaogailvsi.Properties.Appearance.Options.UseTextOptions = true;
            TouJipindaxiaogailvsi.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            TouJipindaxiaogailvsi.Properties.Mask.EditMask = "n0";
            TouJipindaxiaogailvsi.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            TouJipindaxiaogailvsi.Properties.Mask.UseMaskAsDisplayFormat = true;
            TouJipindaxiaogailvsi.Size = new System.Drawing.Size(35, 20);
            TouJipindaxiaogailvsi.TabIndex = 405;
            
            
            
            TouJipindaxiaogailvs.Location = new System.Drawing.Point(84, 672);
            TouJipindaxiaogailvs.MenuManager = ribbon;
            TouJipindaxiaogailvs.Name = "TouJipindaxiaogailvs";
            TouJipindaxiaogailvs.Properties.Appearance.Options.UseTextOptions = true;
            TouJipindaxiaogailvs.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            TouJipindaxiaogailvs.Properties.Mask.EditMask = "n0";
            TouJipindaxiaogailvs.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            TouJipindaxiaogailvs.Properties.Mask.UseMaskAsDisplayFormat = true;
            TouJipindaxiaogailvs.Size = new System.Drawing.Size(35, 20);
            TouJipindaxiaogailvs.TabIndex = 404;
            
            
            
            TouJipindaxiaogailve.Location = new System.Drawing.Point(44, 672);
            TouJipindaxiaogailve.MenuManager = ribbon;
            TouJipindaxiaogailve.Name = "TouJipindaxiaogailve";
            TouJipindaxiaogailve.Properties.Appearance.Options.UseTextOptions = true;
            TouJipindaxiaogailve.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            TouJipindaxiaogailve.Properties.Mask.EditMask = "n0";
            TouJipindaxiaogailve.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            TouJipindaxiaogailve.Properties.Mask.UseMaskAsDisplayFormat = true;
            TouJipindaxiaogailve.Size = new System.Drawing.Size(35, 20);
            TouJipindaxiaogailve.TabIndex = 403;
            
            
            
            TouJipindaxiaogailvy.Location = new System.Drawing.Point(14, 672);
            TouJipindaxiaogailvy.MenuManager = ribbon;
            TouJipindaxiaogailvy.Name = "TouJipindaxiaogailvy";
            TouJipindaxiaogailvy.Properties.Appearance.Options.UseTextOptions = true;
            TouJipindaxiaogailvy.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            TouJipindaxiaogailvy.Properties.Mask.EditMask = "n0";
            TouJipindaxiaogailvy.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            TouJipindaxiaogailvy.Properties.Mask.UseMaskAsDisplayFormat = true;
            TouJipindaxiaogailvy.Size = new System.Drawing.Size(25, 20);
            TouJipindaxiaogailvy.TabIndex = 402;
            
            
            
            TouJipindaxiaogailvzi.Location = new System.Drawing.Point(14, 644);
            TouJipindaxiaogailvzi.Name = "TouJipindaxiaogailvzi";
            TouJipindaxiaogailvzi.Size = new System.Drawing.Size(76, 14);
            TouJipindaxiaogailvzi.TabIndex = 401;
            TouJipindaxiaogailvzi.Text = "头防魔，饰攻自灵，链手准确、敏捷，鞋舒适:";
            
            
            
            YiJipindaxiaogailvl.Location = new System.Drawing.Point(209, 616);
            YiJipindaxiaogailvl.MenuManager = ribbon;
            YiJipindaxiaogailvl.Name = "YiJipindaxiaogailvl";
            YiJipindaxiaogailvl.Properties.Appearance.Options.UseTextOptions = true;
            YiJipindaxiaogailvl.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            YiJipindaxiaogailvl.Properties.Mask.EditMask = "n0";
            YiJipindaxiaogailvl.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            YiJipindaxiaogailvl.Properties.Mask.UseMaskAsDisplayFormat = true;
            YiJipindaxiaogailvl.Size = new System.Drawing.Size(50, 20);
            YiJipindaxiaogailvl.TabIndex = 400;
            
            
            
            YiJipindaxiaogailvw.Location = new System.Drawing.Point(164, 616);
            YiJipindaxiaogailvw.MenuManager = ribbon;
            YiJipindaxiaogailvw.Name = "YiJipindaxiaogailvw";
            YiJipindaxiaogailvw.Properties.Appearance.Options.UseTextOptions = true;
            YiJipindaxiaogailvw.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            YiJipindaxiaogailvw.Properties.Mask.EditMask = "n0";
            YiJipindaxiaogailvw.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            YiJipindaxiaogailvw.Properties.Mask.UseMaskAsDisplayFormat = true;
            YiJipindaxiaogailvw.Size = new System.Drawing.Size(40, 20);
            YiJipindaxiaogailvw.TabIndex = 399;
            
            
            
            YiJipindaxiaogailvsi.Location = new System.Drawing.Point(124, 616);
            YiJipindaxiaogailvsi.MenuManager = ribbon;
            YiJipindaxiaogailvsi.Name = "YiJipindaxiaogailvsi";
            YiJipindaxiaogailvsi.Properties.Appearance.Options.UseTextOptions = true;
            YiJipindaxiaogailvsi.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            YiJipindaxiaogailvsi.Properties.Mask.EditMask = "n0";
            YiJipindaxiaogailvsi.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            YiJipindaxiaogailvsi.Properties.Mask.UseMaskAsDisplayFormat = true;
            YiJipindaxiaogailvsi.Size = new System.Drawing.Size(35, 20);
            YiJipindaxiaogailvsi.TabIndex = 398;
            
            
            
            YiJipindaxiaogailvs.Location = new System.Drawing.Point(84, 616);
            YiJipindaxiaogailvs.MenuManager = ribbon;
            YiJipindaxiaogailvs.Name = "YiJipindaxiaogailvs";
            YiJipindaxiaogailvs.Properties.Appearance.Options.UseTextOptions = true;
            YiJipindaxiaogailvs.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            YiJipindaxiaogailvs.Properties.Mask.EditMask = "n0";
            YiJipindaxiaogailvs.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            YiJipindaxiaogailvs.Properties.Mask.UseMaskAsDisplayFormat = true;
            YiJipindaxiaogailvs.Size = new System.Drawing.Size(35, 20);
            YiJipindaxiaogailvs.TabIndex = 397;
            
            
            
            YiJipindaxiaogailve.Location = new System.Drawing.Point(44, 616);
            YiJipindaxiaogailve.MenuManager = ribbon;
            YiJipindaxiaogailve.Name = "YiJipindaxiaogailve";
            YiJipindaxiaogailve.Properties.Appearance.Options.UseTextOptions = true;
            YiJipindaxiaogailve.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            YiJipindaxiaogailve.Properties.Mask.EditMask = "n0";
            YiJipindaxiaogailve.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            YiJipindaxiaogailve.Properties.Mask.UseMaskAsDisplayFormat = true;
            YiJipindaxiaogailve.Size = new System.Drawing.Size(35, 20);
            YiJipindaxiaogailve.TabIndex = 396;
            
            
            
            YiJipindaxiaogailvy.Location = new System.Drawing.Point(14, 616);
            YiJipindaxiaogailvy.MenuManager = ribbon;
            YiJipindaxiaogailvy.Name = "YiJipindaxiaogailvy";
            YiJipindaxiaogailvy.Properties.Appearance.Options.UseTextOptions = true;
            YiJipindaxiaogailvy.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            YiJipindaxiaogailvy.Properties.Mask.EditMask = "n0";
            YiJipindaxiaogailvy.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            YiJipindaxiaogailvy.Properties.Mask.UseMaskAsDisplayFormat = true;
            YiJipindaxiaogailvy.Size = new System.Drawing.Size(25, 20);
            YiJipindaxiaogailvy.TabIndex = 395;
            
            
            
            YiJipindaxiaogailvzi.Location = new System.Drawing.Point(14, 588);
            YiJipindaxiaogailvzi.Name = "YiJipindaxiaogailvzi";
            YiJipindaxiaogailvzi.Size = new System.Drawing.Size(76, 14);
            YiJipindaxiaogailvzi.TabIndex = 394;
            YiJipindaxiaogailvzi.Text = "衣服,戒指防御魔御，戒指拾取Ra大小产生概率:";
            
            
            
            DunJipindaxiaogailvl.Location = new System.Drawing.Point(209, 560);
            DunJipindaxiaogailvl.MenuManager = ribbon;
            DunJipindaxiaogailvl.Name = "DunJipindaxiaogailvl";
            DunJipindaxiaogailvl.Properties.Appearance.Options.UseTextOptions = true;
            DunJipindaxiaogailvl.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            DunJipindaxiaogailvl.Properties.Mask.EditMask = "n0";
            DunJipindaxiaogailvl.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            DunJipindaxiaogailvl.Properties.Mask.UseMaskAsDisplayFormat = true;
            DunJipindaxiaogailvl.Size = new System.Drawing.Size(50, 20);
            DunJipindaxiaogailvl.TabIndex = 393;
            
            
            
            DunJipindaxiaogailvw.Location = new System.Drawing.Point(164, 560);
            DunJipindaxiaogailvw.MenuManager = ribbon;
            DunJipindaxiaogailvw.Name = "DunJipindaxiaogailvw";
            DunJipindaxiaogailvw.Properties.Appearance.Options.UseTextOptions = true;
            DunJipindaxiaogailvw.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            DunJipindaxiaogailvw.Properties.Mask.EditMask = "n0";
            DunJipindaxiaogailvw.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            DunJipindaxiaogailvw.Properties.Mask.UseMaskAsDisplayFormat = true;
            DunJipindaxiaogailvw.Size = new System.Drawing.Size(40, 20);
            DunJipindaxiaogailvw.TabIndex = 392;
            
            
            
            DunJipindaxiaogailvsi.Location = new System.Drawing.Point(124, 560);
            DunJipindaxiaogailvsi.MenuManager = ribbon;
            DunJipindaxiaogailvsi.Name = "DunJipindaxiaogailvsi";
            DunJipindaxiaogailvsi.Properties.Appearance.Options.UseTextOptions = true;
            DunJipindaxiaogailvsi.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            DunJipindaxiaogailvsi.Properties.Mask.EditMask = "n0";
            DunJipindaxiaogailvsi.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            DunJipindaxiaogailvsi.Properties.Mask.UseMaskAsDisplayFormat = true;
            DunJipindaxiaogailvsi.Size = new System.Drawing.Size(35, 20);
            DunJipindaxiaogailvsi.TabIndex = 391;
            
            
            
            DunJipindaxiaogailvs.Location = new System.Drawing.Point(84, 560);
            DunJipindaxiaogailvs.MenuManager = ribbon;
            DunJipindaxiaogailvs.Name = "DunJipindaxiaogailvs";
            DunJipindaxiaogailvs.Properties.Appearance.Options.UseTextOptions = true;
            DunJipindaxiaogailvs.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            DunJipindaxiaogailvs.Properties.Mask.EditMask = "n0";
            DunJipindaxiaogailvs.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            DunJipindaxiaogailvs.Properties.Mask.UseMaskAsDisplayFormat = true;
            DunJipindaxiaogailvs.Size = new System.Drawing.Size(35, 20);
            DunJipindaxiaogailvs.TabIndex = 390;
            
            
            
            DunJipindaxiaogailve.Location = new System.Drawing.Point(44, 560);
            DunJipindaxiaogailve.MenuManager = ribbon;
            DunJipindaxiaogailve.Name = "DunJipindaxiaogailve";
            DunJipindaxiaogailve.Properties.Appearance.Options.UseTextOptions = true;
            DunJipindaxiaogailve.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            DunJipindaxiaogailve.Properties.Mask.EditMask = "n0";
            DunJipindaxiaogailve.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            DunJipindaxiaogailve.Properties.Mask.UseMaskAsDisplayFormat = true;
            DunJipindaxiaogailve.Size = new System.Drawing.Size(35, 20);
            DunJipindaxiaogailve.TabIndex = 389;
            
            
            
            DunJipindaxiaogailvy.Location = new System.Drawing.Point(14, 560);
            DunJipindaxiaogailvy.MenuManager = ribbon;
            DunJipindaxiaogailvy.Name = "DunJipindaxiaogailvy";
            DunJipindaxiaogailvy.Properties.Appearance.Options.UseTextOptions = true;
            DunJipindaxiaogailvy.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            DunJipindaxiaogailvy.Properties.Mask.EditMask = "n0";
            DunJipindaxiaogailvy.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            DunJipindaxiaogailvy.Properties.Mask.UseMaskAsDisplayFormat = true;
            DunJipindaxiaogailvy.Size = new System.Drawing.Size(25, 20);
            DunJipindaxiaogailvy.TabIndex = 388;
            
            
            
            DunJipindaxiaogailvzi.Location = new System.Drawing.Point(14, 532);
            DunJipindaxiaogailvzi.Name = "DunJipindaxiaogailvzi";
            DunJipindaxiaogailvzi.Size = new System.Drawing.Size(76, 14);
            DunJipindaxiaogailvzi.TabIndex = 387;
            DunJipindaxiaogailvzi.Text = "盾牌攻自灵格挡闪避毒抗几率大小产生概率:";
            
            
            
            GyJipindaxiaogailvl.Location = new System.Drawing.Point(209, 504);
            GyJipindaxiaogailvl.MenuManager = ribbon;
            GyJipindaxiaogailvl.Name = "GyJipindaxiaogailvl";
            GyJipindaxiaogailvl.Properties.Appearance.Options.UseTextOptions = true;
            GyJipindaxiaogailvl.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            GyJipindaxiaogailvl.Properties.Mask.EditMask = "n0";
            GyJipindaxiaogailvl.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            GyJipindaxiaogailvl.Properties.Mask.UseMaskAsDisplayFormat = true;
            GyJipindaxiaogailvl.Size = new System.Drawing.Size(50, 20);
            GyJipindaxiaogailvl.TabIndex = 386;
            
            
            
            GyJipindaxiaogailvw.Location = new System.Drawing.Point(164, 504);
            GyJipindaxiaogailvw.MenuManager = ribbon;
            GyJipindaxiaogailvw.Name = "GyJipindaxiaogailvw";
            GyJipindaxiaogailvw.Properties.Appearance.Options.UseTextOptions = true;
            GyJipindaxiaogailvw.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            GyJipindaxiaogailvw.Properties.Mask.EditMask = "n0";
            GyJipindaxiaogailvw.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            GyJipindaxiaogailvw.Properties.Mask.UseMaskAsDisplayFormat = true;
            GyJipindaxiaogailvw.Size = new System.Drawing.Size(40, 20);
            GyJipindaxiaogailvw.TabIndex = 385;
            
            
            
            GyJipindaxiaogailvsi.Location = new System.Drawing.Point(124, 504);
            GyJipindaxiaogailvsi.MenuManager = ribbon;
            GyJipindaxiaogailvsi.Name = "GyJipindaxiaogailvsi";
            GyJipindaxiaogailvsi.Properties.Appearance.Options.UseTextOptions = true;
            GyJipindaxiaogailvsi.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            GyJipindaxiaogailvsi.Properties.Mask.EditMask = "n0";
            GyJipindaxiaogailvsi.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            GyJipindaxiaogailvsi.Properties.Mask.UseMaskAsDisplayFormat = true;
            GyJipindaxiaogailvsi.Size = new System.Drawing.Size(35, 20);
            GyJipindaxiaogailvsi.TabIndex = 384;
            
            
            
            GyJipindaxiaogailvs.Location = new System.Drawing.Point(84, 504);
            GyJipindaxiaogailvs.MenuManager = ribbon;
            GyJipindaxiaogailvs.Name = "GyJipindaxiaogailvs";
            GyJipindaxiaogailvs.Properties.Appearance.Options.UseTextOptions = true;
            GyJipindaxiaogailvs.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            GyJipindaxiaogailvs.Properties.Mask.EditMask = "n0";
            GyJipindaxiaogailvs.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            GyJipindaxiaogailvs.Properties.Mask.UseMaskAsDisplayFormat = true;
            GyJipindaxiaogailvs.Size = new System.Drawing.Size(35, 20);
            GyJipindaxiaogailvs.TabIndex = 383;
            
            
            
            GyJipindaxiaogailve.Location = new System.Drawing.Point(44, 504);
            GyJipindaxiaogailve.MenuManager = ribbon;
            GyJipindaxiaogailve.Name = "GyJipindaxiaogailve";
            GyJipindaxiaogailve.Properties.Appearance.Options.UseTextOptions = true;
            GyJipindaxiaogailve.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            GyJipindaxiaogailve.Properties.Mask.EditMask = "n0";
            GyJipindaxiaogailve.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            GyJipindaxiaogailve.Properties.Mask.UseMaskAsDisplayFormat = true;
            GyJipindaxiaogailve.Size = new System.Drawing.Size(35, 20);
            GyJipindaxiaogailve.TabIndex = 382;
            
            
            
            GyJipindaxiaogailvy.Location = new System.Drawing.Point(14, 504);
            GyJipindaxiaogailvy.MenuManager = ribbon;
            GyJipindaxiaogailvy.Name = "GyJipindaxiaogailvy";
            GyJipindaxiaogailvy.Properties.Appearance.Options.UseTextOptions = true;
            GyJipindaxiaogailvy.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            GyJipindaxiaogailvy.Properties.Mask.EditMask = "n0";
            GyJipindaxiaogailvy.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            GyJipindaxiaogailvy.Properties.Mask.UseMaskAsDisplayFormat = true;
            GyJipindaxiaogailvy.Size = new System.Drawing.Size(25, 20);
            GyJipindaxiaogailvy.TabIndex = 381;
            
            
            
            GyJipindaxiaogailvzi.Location = new System.Drawing.Point(14, 476);
            GyJipindaxiaogailvzi.Name = "GyJipindaxiaogailvzi";
            GyJipindaxiaogailvzi.Size = new System.Drawing.Size(76, 14);
            GyJipindaxiaogailvzi.TabIndex = 380;
            GyJipindaxiaogailvzi.Text = "所有攻击元素大小产生概率:";
            
            
            
            Jipindaxiaogailvl.Location = new System.Drawing.Point(209, 448);
            Jipindaxiaogailvl.MenuManager = ribbon;
            Jipindaxiaogailvl.Name = "Jipindaxiaogailvl";
            Jipindaxiaogailvl.Properties.Appearance.Options.UseTextOptions = true;
            Jipindaxiaogailvl.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            Jipindaxiaogailvl.Properties.Mask.EditMask = "n0";
            Jipindaxiaogailvl.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            Jipindaxiaogailvl.Properties.Mask.UseMaskAsDisplayFormat = true;
            Jipindaxiaogailvl.Size = new System.Drawing.Size(50, 20);
            Jipindaxiaogailvl.TabIndex = 379;
            
            
            
            Jipindaxiaogailvw.Location = new System.Drawing.Point(164, 448);
            Jipindaxiaogailvw.MenuManager = ribbon;
            Jipindaxiaogailvw.Name = "Jipindaxiaogailvw";
            Jipindaxiaogailvw.Properties.Appearance.Options.UseTextOptions = true;
            Jipindaxiaogailvw.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            Jipindaxiaogailvw.Properties.Mask.EditMask = "n0";
            Jipindaxiaogailvw.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            Jipindaxiaogailvw.Properties.Mask.UseMaskAsDisplayFormat = true;
            Jipindaxiaogailvw.Size = new System.Drawing.Size(40, 20);
            Jipindaxiaogailvw.TabIndex = 379;
            
            
            
            Jipindaxiaogailvsi.Location = new System.Drawing.Point(124, 448);
            Jipindaxiaogailvsi.MenuManager = ribbon;
            Jipindaxiaogailvsi.Name = "Jipindaxiaogailvsi";
            Jipindaxiaogailvsi.Properties.Appearance.Options.UseTextOptions = true;
            Jipindaxiaogailvsi.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            Jipindaxiaogailvsi.Properties.Mask.EditMask = "n0";
            Jipindaxiaogailvsi.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            Jipindaxiaogailvsi.Properties.Mask.UseMaskAsDisplayFormat = true;
            Jipindaxiaogailvsi.Size = new System.Drawing.Size(35, 20);
            Jipindaxiaogailvsi.TabIndex = 378;
            
            
            
            Jipindaxiaogailvs.Location = new System.Drawing.Point(84, 448);
            Jipindaxiaogailvs.MenuManager = ribbon;
            Jipindaxiaogailvs.Name = "Jipindaxiaogailvs";
            Jipindaxiaogailvs.Properties.Appearance.Options.UseTextOptions = true;
            Jipindaxiaogailvs.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            Jipindaxiaogailvs.Properties.Mask.EditMask = "n0";
            Jipindaxiaogailvs.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            Jipindaxiaogailvs.Properties.Mask.UseMaskAsDisplayFormat = true;
            Jipindaxiaogailvs.Size = new System.Drawing.Size(35, 20);
            Jipindaxiaogailvs.TabIndex = 377;
            
            
            
            Jipindaxiaogailve.Location = new System.Drawing.Point(44, 448);
            Jipindaxiaogailve.MenuManager = ribbon;
            Jipindaxiaogailve.Name = "Jipindaxiaogailve";
            Jipindaxiaogailve.Properties.Appearance.Options.UseTextOptions = true;
            Jipindaxiaogailve.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            Jipindaxiaogailve.Properties.Mask.EditMask = "n0";
            Jipindaxiaogailve.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            Jipindaxiaogailve.Properties.Mask.UseMaskAsDisplayFormat = true;
            Jipindaxiaogailve.Size = new System.Drawing.Size(35, 20);
            Jipindaxiaogailve.TabIndex = 376;
            
            
            
            Jipindaxiaogailvy.Location = new System.Drawing.Point(14, 448);
            Jipindaxiaogailvy.MenuManager = ribbon;
            Jipindaxiaogailvy.Name = "Jipindaxiaogailvy";
            Jipindaxiaogailvy.Properties.Appearance.Options.UseTextOptions = true;
            Jipindaxiaogailvy.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            Jipindaxiaogailvy.Properties.Mask.EditMask = "n0";
            Jipindaxiaogailvy.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            Jipindaxiaogailvy.Properties.Mask.UseMaskAsDisplayFormat = true;
            Jipindaxiaogailvy.Size = new System.Drawing.Size(25, 20);
            Jipindaxiaogailvy.TabIndex = 375;
            
            
            
            Jipindaxiaogailvzi.Location = new System.Drawing.Point(14, 420);
            Jipindaxiaogailvzi.Name = "Jipindaxiaogailvzi";
            Jipindaxiaogailvzi.Size = new System.Drawing.Size(76, 14);
            Jipindaxiaogailvzi.TabIndex = 374;
            Jipindaxiaogailvzi.Text = "武器攻击、自然、灵魂大小产生概率:";
            
            
            
            Jipindaxiaol.Location = new System.Drawing.Point(241, 389);
            Jipindaxiaol.MenuManager = ribbon;
            Jipindaxiaol.Name = "Jipindaxiaol";
            Jipindaxiaol.Properties.Appearance.Options.UseTextOptions = true;
            Jipindaxiaol.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            Jipindaxiaol.Properties.Mask.EditMask = "n0";
            Jipindaxiaol.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            Jipindaxiaol.Properties.Mask.UseMaskAsDisplayFormat = true;
            Jipindaxiaol.Size = new System.Drawing.Size(17, 20);
            Jipindaxiaol.TabIndex = 379;
            
            
            
            Jipindaxiaow.Location = new System.Drawing.Point(221, 389);
            Jipindaxiaow.MenuManager = ribbon;
            Jipindaxiaow.Name = "Jipindaxiaow";
            Jipindaxiaow.Properties.Appearance.Options.UseTextOptions = true;
            Jipindaxiaow.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            Jipindaxiaow.Properties.Mask.EditMask = "n0";
            Jipindaxiaow.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            Jipindaxiaow.Properties.Mask.UseMaskAsDisplayFormat = true;
            Jipindaxiaow.Size = new System.Drawing.Size(15, 20);
            Jipindaxiaow.TabIndex = 379;
            
            
            
            Jipindaxiaosi.Location = new System.Drawing.Point(201, 389);
            Jipindaxiaosi.MenuManager = ribbon;
            Jipindaxiaosi.Name = "Jipindaxiaosi";
            Jipindaxiaosi.Properties.Appearance.Options.UseTextOptions = true;
            Jipindaxiaosi.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            Jipindaxiaosi.Properties.Mask.EditMask = "n0";
            Jipindaxiaosi.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            Jipindaxiaosi.Properties.Mask.UseMaskAsDisplayFormat = true;
            Jipindaxiaosi.Size = new System.Drawing.Size(15, 20);
            Jipindaxiaosi.TabIndex = 378;
            
            
            
            Jipindaxiaos.Location = new System.Drawing.Point(181, 389);
            Jipindaxiaos.MenuManager = ribbon;
            Jipindaxiaos.Name = "Jipindaxiaos";
            Jipindaxiaos.Properties.Appearance.Options.UseTextOptions = true;
            Jipindaxiaos.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            Jipindaxiaos.Properties.Mask.EditMask = "n0";
            Jipindaxiaos.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            Jipindaxiaos.Properties.Mask.UseMaskAsDisplayFormat = true;
            Jipindaxiaos.Size = new System.Drawing.Size(15, 20);
            Jipindaxiaos.TabIndex = 377;
            
            
            
            Jipindaxiaoe.Location = new System.Drawing.Point(161, 389);
            Jipindaxiaoe.MenuManager = ribbon;
            Jipindaxiaoe.Name = "Jipindaxiaoe";
            Jipindaxiaoe.Properties.Appearance.Options.UseTextOptions = true;
            Jipindaxiaoe.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            Jipindaxiaoe.Properties.Mask.EditMask = "n0";
            Jipindaxiaoe.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            Jipindaxiaoe.Properties.Mask.UseMaskAsDisplayFormat = true;
            Jipindaxiaoe.Size = new System.Drawing.Size(15, 20);
            Jipindaxiaoe.TabIndex = 376;
            
            
            
            Jipindaxiaoy.Location = new System.Drawing.Point(141, 389);
            Jipindaxiaoy.MenuManager = ribbon;
            Jipindaxiaoy.Name = "Jipindaxiaoy";
            Jipindaxiaoy.Properties.Appearance.Options.UseTextOptions = true;
            Jipindaxiaoy.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            Jipindaxiaoy.Properties.Mask.EditMask = "n0";
            Jipindaxiaoy.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            Jipindaxiaoy.Properties.Mask.UseMaskAsDisplayFormat = true;
            Jipindaxiaoy.Size = new System.Drawing.Size(15, 20);
            Jipindaxiaoy.TabIndex = 375;
            
            
            
            Jipindaxiaozi.Location = new System.Drawing.Point(69, 392);
            Jipindaxiaozi.Name = "Jipindaxiaozi";
            Jipindaxiaozi.Size = new System.Drawing.Size(76, 14);
            Jipindaxiaozi.TabIndex = 374;
            Jipindaxiaozi.Text = "极品的大小:";
            
            
            
            Jipindebaolv.Location = new System.Drawing.Point(141, 361);
            Jipindebaolv.MenuManager = ribbon;
            Jipindebaolv.Name = "Jipindebaolv";
            Jipindebaolv.Properties.Appearance.Options.UseTextOptions = true;
            Jipindebaolv.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            Jipindebaolv.Properties.Mask.EditMask = "n0";
            Jipindebaolv.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            Jipindebaolv.Properties.Mask.UseMaskAsDisplayFormat = true;
            Jipindebaolv.Size = new System.Drawing.Size(117, 20);
            Jipindebaolv.TabIndex = 373;
            
            
            
            Jipindebaolvzi.Location = new System.Drawing.Point(69, 364);
            Jipindebaolvzi.Name = "Jipindebaolvzi";
            Jipindebaolvzi.Size = new System.Drawing.Size(76, 14);
            Jipindebaolvzi.TabIndex = 372;
            Jipindebaolvzi.Text = "极品的爆率:";
            
            
            
            Mfguajishijianzi.Location = new System.Drawing.Point(141, 333);
            Mfguajishijianzi.MenuManager = ribbon;
            Mfguajishijianzi.Name = "Mfguajishijianzi";
            Mfguajishijianzi.Properties.Appearance.Options.UseTextOptions = true;
            Mfguajishijianzi.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            Mfguajishijianzi.Properties.Mask.EditMask = "n0";
            Mfguajishijianzi.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            Mfguajishijianzi.Properties.Mask.UseMaskAsDisplayFormat = true;
            Mfguajishijianzi.Size = new System.Drawing.Size(117, 20);
            Mfguajishijianzi.TabIndex = 239;
            
            
            
            Mfguajishijian.Location = new System.Drawing.Point(57, 336);
            Mfguajishijian.Name = "Mfguajishijian";
            Mfguajishijian.Size = new System.Drawing.Size(76, 14);
            Mfguajishijian.TabIndex = 238;
            Mfguajishijian.Text = "免费挂机时间:";
            
            
            
            LabelControl90TaxSani.Location = new System.Drawing.Point(141, 305);
            LabelControl90TaxSani.MenuManager = ribbon;
            LabelControl90TaxSani.Name = "LabelControl90TaxSani";
            LabelControl90TaxSani.Properties.Appearance.Options.UseTextOptions = true;
            LabelControl90TaxSani.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            LabelControl90TaxSani.Properties.Mask.EditMask = "n0";
            LabelControl90TaxSani.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            LabelControl90TaxSani.Properties.Mask.UseMaskAsDisplayFormat = true;
            LabelControl90TaxSani.Size = new System.Drawing.Size(117, 20);
            LabelControl90TaxSani.TabIndex = 116;
            
            
            
            labelControl90.Location = new System.Drawing.Point(45, 308);
            labelControl90.Name = "labelControl90";
            labelControl90.Size = new System.Drawing.Size(76, 14);
            labelControl90.TabIndex = 114;
            labelControl90.Text = "宝箱重置[元宝]:";
            
            
            
            LabelControl88TaxSani.Location = new System.Drawing.Point(141, 277);
            LabelControl88TaxSani.MenuManager = ribbon;
            LabelControl88TaxSani.Name = "LabelControl88TaxSani";
            LabelControl88TaxSani.Properties.Appearance.Options.UseTextOptions = true;
            LabelControl88TaxSani.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            LabelControl88TaxSani.Properties.Mask.EditMask = "n0";
            LabelControl88TaxSani.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            LabelControl88TaxSani.Properties.Mask.UseMaskAsDisplayFormat = true;
            LabelControl88TaxSani.Size = new System.Drawing.Size(117, 20);
            LabelControl88TaxSani.TabIndex = 115;
            
            
            
            labelControl88.Location = new System.Drawing.Point(45, 280);
            labelControl88.Name = "labelControl88";
            labelControl88.Size = new System.Drawing.Size(76, 14);
            labelControl88.TabIndex = 113;
            labelControl88.Text = "宝箱抽奖[元宝]:";
            
            
            
            labelControl63.Location = new System.Drawing.Point(80, 252);
            labelControl63.Name = "labelControl63";
            labelControl63.Size = new System.Drawing.Size(52, 14);
            labelControl63.TabIndex = 93;
            labelControl63.Text = "诅咒几率:";
            
            
            
            MaxCurseEdit.Location = new System.Drawing.Point(141, 221);
            MaxCurseEdit.MenuManager = ribbon;
            MaxCurseEdit.Name = "MaxCurseEdit";
            MaxCurseEdit.Properties.Appearance.Options.UseTextOptions = true;
            MaxCurseEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            MaxCurseEdit.Properties.Mask.EditMask = "n0";
            MaxCurseEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            MaxCurseEdit.Properties.Mask.UseMaskAsDisplayFormat = true;
            MaxCurseEdit.Size = new System.Drawing.Size(117, 20);
            MaxCurseEdit.TabIndex = 92;
            
            
            
            labelControl62.Location = new System.Drawing.Point(80, 224);
            labelControl62.Name = "labelControl62";
            labelControl62.Size = new System.Drawing.Size(52, 14);
            labelControl62.TabIndex = 91;
            labelControl62.Text = "最高诅咒:";
            
            
            
            LuckRateEdit.Location = new System.Drawing.Point(141, 193);
            LuckRateEdit.MenuManager = ribbon;
            LuckRateEdit.Name = "LuckRateEdit";
            LuckRateEdit.Properties.Appearance.Options.UseTextOptions = true;
            LuckRateEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            LuckRateEdit.Properties.Mask.EditMask = "n0";
            LuckRateEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            LuckRateEdit.Properties.Mask.UseMaskAsDisplayFormat = true;
            LuckRateEdit.Size = new System.Drawing.Size(117, 20);
            LuckRateEdit.TabIndex = 90;
            
            
            
            labelControl61.Location = new System.Drawing.Point(80, 196);
            labelControl61.Name = "labelControl61";
            labelControl61.Size = new System.Drawing.Size(52, 14);
            labelControl61.TabIndex = 89;
            labelControl61.Text = "幸运几率:";
            
            
            
            MaxLuckEdit.Location = new System.Drawing.Point(141, 165);
            MaxLuckEdit.MenuManager = ribbon;
            MaxLuckEdit.Name = "MaxLuckEdit";
            MaxLuckEdit.Properties.Appearance.Options.UseTextOptions = true;
            MaxLuckEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            MaxLuckEdit.Properties.Mask.EditMask = "n0";
            MaxLuckEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            MaxLuckEdit.Properties.Mask.UseMaskAsDisplayFormat = true;
            MaxLuckEdit.Size = new System.Drawing.Size(117, 20);
            MaxLuckEdit.TabIndex = 88;
            
            
            
            labelControl60.Location = new System.Drawing.Point(80, 168);
            labelControl60.Name = "labelControl60";
            labelControl60.Size = new System.Drawing.Size(52, 14);
            labelControl60.TabIndex = 87;
            labelControl60.Text = "最高幸运:";
            
            
            
            labelControl59.Location = new System.Drawing.Point(56, 140);
            labelControl59.Name = "labelControl59";
            labelControl59.Size = new System.Drawing.Size(76, 14);
            labelControl59.TabIndex = 86;
            labelControl59.Text = "特殊修理延迟:";
            
            
            
            SpecialRepairDelayEdit.EditValue = System.TimeSpan.Parse("00:00:00");
            SpecialRepairDelayEdit.Location = new System.Drawing.Point(141, 137);
            SpecialRepairDelayEdit.MenuManager = ribbon;
            SpecialRepairDelayEdit.Name = "SpecialRepairDelayEdit";
            SpecialRepairDelayEdit.Properties.AllowEditDays = false;
            SpecialRepairDelayEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            SpecialRepairDelayEdit.Properties.Mask.EditMask = "HH:mm:ss";
            SpecialRepairDelayEdit.Size = new System.Drawing.Size(117, 20);
            SpecialRepairDelayEdit.TabIndex = 85;
            
            
            
            TorchRateEdit.Location = new System.Drawing.Point(141, 109);
            TorchRateEdit.MenuManager = ribbon;
            TorchRateEdit.Name = "TorchRateEdit";
            TorchRateEdit.Properties.Appearance.Options.UseTextOptions = true;
            TorchRateEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            TorchRateEdit.Properties.Mask.EditMask = "n0";
            TorchRateEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            TorchRateEdit.Properties.Mask.UseMaskAsDisplayFormat = true;
            TorchRateEdit.Size = new System.Drawing.Size(117, 20);
            TorchRateEdit.TabIndex = 84;
            
            
            
            labelControl54.Location = new System.Drawing.Point(68, 112);
            labelControl54.Name = "labelControl54";
            labelControl54.Size = new System.Drawing.Size(64, 14);
            labelControl54.TabIndex = 83;
            labelControl54.Text = "火炬使用率:";
            
            
            
            DropLayersEdit.Location = new System.Drawing.Point(141, 81);
            DropLayersEdit.MenuManager = ribbon;
            DropLayersEdit.Name = "DropLayersEdit";
            DropLayersEdit.Properties.Appearance.Options.UseTextOptions = true;
            DropLayersEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            DropLayersEdit.Properties.Mask.EditMask = "n0";
            DropLayersEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            DropLayersEdit.Properties.Mask.UseMaskAsDisplayFormat = true;
            DropLayersEdit.Size = new System.Drawing.Size(117, 20);
            DropLayersEdit.TabIndex = 81;
            
            
            
            labelControl50.Location = new System.Drawing.Point(92, 84);
            labelControl50.Name = "labelControl50";
            labelControl50.Size = new System.Drawing.Size(40, 14);
            labelControl50.TabIndex = 80;
            labelControl50.Text = "掉落层:";
            
            
            
            DropDistanceEdit.Location = new System.Drawing.Point(141, 53);
            DropDistanceEdit.MenuManager = ribbon;
            DropDistanceEdit.Name = "DropDistanceEdit";
            DropDistanceEdit.Properties.Appearance.Options.UseTextOptions = true;
            DropDistanceEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            DropDistanceEdit.Properties.Mask.EditMask = "n0";
            DropDistanceEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            DropDistanceEdit.Properties.Mask.UseMaskAsDisplayFormat = true;
            DropDistanceEdit.Size = new System.Drawing.Size(117, 20);
            DropDistanceEdit.TabIndex = 79;
            
            
            
            labelControl49.Location = new System.Drawing.Point(80, 56);
            labelControl49.Name = "labelControl49";
            labelControl49.Size = new System.Drawing.Size(52, 14);
            labelControl49.TabIndex = 78;
            labelControl49.Text = "掉落距离:";
            
            
            
            labelControl48.Location = new System.Drawing.Point(56, 28);
            labelControl48.Name = "labelControl48";
            labelControl48.Size = new System.Drawing.Size(76, 14);
            labelControl48.TabIndex = 77;
            labelControl48.Text = "掉落持续时间:";
            
            
            
            DropDurationEdit.EditValue = System.TimeSpan.Parse("00:00:00");
            DropDurationEdit.Location = new System.Drawing.Point(141, 25);
            DropDurationEdit.MenuManager = ribbon;
            DropDurationEdit.Name = "DropDurationEdit";
            DropDurationEdit.Properties.AllowEditDays = false;
            DropDurationEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            DropDurationEdit.Properties.Mask.EditMask = "HH:mm:ss";
            DropDurationEdit.Size = new System.Drawing.Size(117, 20);
            DropDurationEdit.TabIndex = 76;
            
            
            
            wakuangbangdingZi.Location = new System.Drawing.Point(313, 25);
            wakuangbangdingZi.Name = "wakuangbangdingZi";
            wakuangbangdingZi.Size = new System.Drawing.Size(64, 14);
            wakuangbangdingZi.TabIndex = 481;
            wakuangbangdingZi.Text = "是否挖矿绑定:";
            
            
            
            wakuangbangding.Location = new System.Drawing.Point(399, 22);
            wakuangbangding.MenuManager = ribbon;
            wakuangbangding.Name = "wakuangbangding";
            wakuangbangding.Properties.Caption = "";
            wakuangbangding.Size = new System.Drawing.Size(117, 19);
            wakuangbangding.TabIndex = 480;
            
            
            
            xtraTabPage9.Controls.Add(Lvduzi);
            xtraTabPage9.Controls.Add(Lvdushu);
            xtraTabPage9.Controls.Add(Qduobizi);
            xtraTabPage9.Controls.Add(Qduobishu);
            xtraTabPage9.Controls.Add(Qgedangzi);
            xtraTabPage9.Controls.Add(Qgedangshu);
            xtraTabPage9.Controls.Add(Qchenmozi);
            xtraTabPage9.Controls.Add(Qchenmoshu);
            xtraTabPage9.Controls.Add(Qyidongzi);
            xtraTabPage9.Controls.Add(Qyidongshu);
            xtraTabPage9.Controls.Add(Qmabizi);
            xtraTabPage9.Controls.Add(Qmabishu);
            xtraTabPage9.Controls.Add(Qbingdongzi);
            xtraTabPage9.Controls.Add(Qbingdongshu);
            xtraTabPage9.Controls.Add(Qmofadunzi);
            xtraTabPage9.Controls.Add(Qmofadunshu);
            xtraTabPage9.Controls.Add(Qhuanzi);
            xtraTabPage9.Controls.Add(Qhuanshu);
            xtraTabPage9.Controls.Add(Qanzi);
            xtraTabPage9.Controls.Add(Qanshu);

            xtraTabPage9.Controls.Add(ShaGuildzi);

            xtraTabPage9.Controls.Add(ShaGuildjy);
            xtraTabPage9.Controls.Add(ShaGuildjyshu);
            xtraTabPage9.Controls.Add(ShaGuildbl);
            xtraTabPage9.Controls.Add(ShaGuildblshu);
            xtraTabPage9.Controls.Add(ShaGuildjb);
            xtraTabPage9.Controls.Add(ShaGuildjbshu);

            xtraTabPage9.Controls.Add(QitaGuildzi);

            xtraTabPage9.Controls.Add(YiGuildrs);
            xtraTabPage9.Controls.Add(YiGuildrsshu);
            xtraTabPage9.Controls.Add(YiGuildjy);
            xtraTabPage9.Controls.Add(YiGuildjyshu);
            xtraTabPage9.Controls.Add(YiGuildbl);
            xtraTabPage9.Controls.Add(YiGuildblshu);
            xtraTabPage9.Controls.Add(YiGuildjb);
            xtraTabPage9.Controls.Add(YiGuildjbshu);

            xtraTabPage9.Controls.Add(ErGuildrs);
            xtraTabPage9.Controls.Add(ErGuildrsshu);
            xtraTabPage9.Controls.Add(ErGuildjy);
            xtraTabPage9.Controls.Add(ErGuildjyshu);
            xtraTabPage9.Controls.Add(ErGuildbl);
            xtraTabPage9.Controls.Add(ErGuildblshu);
            xtraTabPage9.Controls.Add(ErGuildjb);
            xtraTabPage9.Controls.Add(ErGuildjbshu);

            xtraTabPage9.Controls.Add(SanGuildrs);
            xtraTabPage9.Controls.Add(SanGuildrsshu);
            xtraTabPage9.Controls.Add(SanGuildjy);
            xtraTabPage9.Controls.Add(SanGuildjyshu);
            xtraTabPage9.Controls.Add(SanGuildbl);
            xtraTabPage9.Controls.Add(SanGuildblshu);
            xtraTabPage9.Controls.Add(SanGuildjb);
            xtraTabPage9.Controls.Add(SanGuildjbshu);

            xtraTabPage9.Controls.Add(SiGuildrs);
            xtraTabPage9.Controls.Add(SiGuildrsshu);
            xtraTabPage9.Controls.Add(SiGuildjy);
            xtraTabPage9.Controls.Add(SiGuildjyshu);
            xtraTabPage9.Controls.Add(SiGuildbl);
            xtraTabPage9.Controls.Add(SiGuildblshu);
            xtraTabPage9.Controls.Add(SiGuildjb);
            xtraTabPage9.Controls.Add(SiGuildjbshu);

            xtraTabPage9.Controls.Add(XinshouGuildzi);
            xtraTabPage9.Controls.Add(XGuilddj);
            xtraTabPage9.Controls.Add(XGuilddjshu);
            xtraTabPage9.Controls.Add(XGuildjy);
            xtraTabPage9.Controls.Add(XGuildjyshu);
            xtraTabPage9.Controls.Add(XGuildbl);
            xtraTabPage9.Controls.Add(XGuildblshu);
            xtraTabPage9.Controls.Add(XGuildjb);
            xtraTabPage9.Controls.Add(XGuildjbshu);
            xtraTabPage9.Controls.Add(Jieshaorendjwushi);
            xtraTabPage9.Controls.Add(Jieshaorendjwushishu);
            xtraTabPage9.Controls.Add(Jieshaorendjsishi);
            xtraTabPage9.Controls.Add(Jieshaorendjsishishu);
            xtraTabPage9.Controls.Add(Jieshaorendjsanshi);
            xtraTabPage9.Controls.Add(Jieshaorendjsanshishu);
            xtraTabPage9.Controls.Add(Jieshaorendjershi);
            xtraTabPage9.Controls.Add(Jieshaorendjershishu);
            xtraTabPage9.Controls.Add(Jieshaorendjshi);
            xtraTabPage9.Controls.Add(Jieshaorendjshishu);
            xtraTabPage9.Controls.Add(Jieshaorendjjieshao);
            xtraTabPage9.Controls.Add(Jieshaorenswsi);
            xtraTabPage9.Controls.Add(Jieshaorenswsishu);
            xtraTabPage9.Controls.Add(Jieshaorensjsi);
            xtraTabPage9.Controls.Add(Jieshaorensjsishu);
            xtraTabPage9.Controls.Add(Bjieshaorenswsi);
            xtraTabPage9.Controls.Add(Bjieshaorenswsishu);
            xtraTabPage9.Controls.Add(Bjieshaorensjsi);
            xtraTabPage9.Controls.Add(Bjieshaorensjsishu);
            xtraTabPage9.Controls.Add(Bjieshaorendjsi);
            xtraTabPage9.Controls.Add(Bjieshaorendjsishu);
            xtraTabPage9.Controls.Add(Jieshaorensws);
            xtraTabPage9.Controls.Add(Jieshaorenswsshu);
            xtraTabPage9.Controls.Add(Jieshaorensjs);
            xtraTabPage9.Controls.Add(Jieshaorensjsshu);
            xtraTabPage9.Controls.Add(Bjieshaorensws);
            xtraTabPage9.Controls.Add(Bjieshaorenswsshu);
            xtraTabPage9.Controls.Add(Bjieshaorensjs);
            xtraTabPage9.Controls.Add(Bjieshaorensjsshu);
            xtraTabPage9.Controls.Add(Bjieshaorendjs);
            xtraTabPage9.Controls.Add(Bjieshaorendjsshu);
            xtraTabPage9.Controls.Add(Jieshaorenswe);
            xtraTabPage9.Controls.Add(Jieshaorensweshu);
            xtraTabPage9.Controls.Add(Jieshaorensje);
            xtraTabPage9.Controls.Add(Jieshaorensjeshu);
            xtraTabPage9.Controls.Add(Bjieshaorenswe);
            xtraTabPage9.Controls.Add(Bjieshaorensweshu);
            xtraTabPage9.Controls.Add(Bjieshaorensje);
            xtraTabPage9.Controls.Add(Bjieshaorensjeshu);
            xtraTabPage9.Controls.Add(Bjieshaorendje);
            xtraTabPage9.Controls.Add(Bjieshaorendjeshu);
            xtraTabPage9.Controls.Add(Jieshaorensw);
            xtraTabPage9.Controls.Add(Jieshaorenswshu);
            xtraTabPage9.Controls.Add(Jieshaorensj);
            xtraTabPage9.Controls.Add(Jieshaorensjshu);
            xtraTabPage9.Controls.Add(Bjieshaorensw);
            xtraTabPage9.Controls.Add(Bjieshaorenswshu);
            xtraTabPage9.Controls.Add(Bjieshaorensj);
            xtraTabPage9.Controls.Add(Bjieshaorensjshu);
            xtraTabPage9.Controls.Add(Bjieshaorendj);
            xtraTabPage9.Controls.Add(Bjieshaorendjshu);
            xtraTabPage9.Controls.Add(Qshenzi);
            xtraTabPage9.Controls.Add(Qshenshu);
            xtraTabPage9.Controls.Add(Qfengzi);
            xtraTabPage9.Controls.Add(Qfengshu);
            xtraTabPage9.Controls.Add(Qleizi);
            xtraTabPage9.Controls.Add(Qleishu);
            xtraTabPage9.Controls.Add(Qbingzi);
            xtraTabPage9.Controls.Add(Qbingshu);
            xtraTabPage9.Controls.Add(Qhuozi);
            xtraTabPage9.Controls.Add(Qhuoshu);
            xtraTabPage9.Controls.Add(Ghuanzi);
            xtraTabPage9.Controls.Add(Ghuanshu);
            xtraTabPage9.Controls.Add(Ganzi);
            xtraTabPage9.Controls.Add(Ganshu);
            xtraTabPage9.Controls.Add(Gshengzi);
            xtraTabPage9.Controls.Add(Gshengshu);
            xtraTabPage9.Controls.Add(Gfengzi);
            xtraTabPage9.Controls.Add(Gfengshu);
            xtraTabPage9.Controls.Add(Gleizi);
            xtraTabPage9.Controls.Add(Gleishu);
            xtraTabPage9.Controls.Add(Gbingzi);
            xtraTabPage9.Controls.Add(Gbingshu);
            xtraTabPage9.Controls.Add(Ghuozi);
            xtraTabPage9.Controls.Add(Ghuoshu);
            xtraTabPage9.Controls.Add(Xxbsshu);
            xtraTabPage9.Controls.Add(Xxbszi);
            xtraTabPage9.Controls.Add(Jybsshu);
            xtraTabPage9.Controls.Add(Jybszi);
            xtraTabPage9.Controls.Add(Mybsshu);
            xtraTabPage9.Controls.Add(Mybszi);
            xtraTabPage9.Controls.Add(Fybsshu);
            xtraTabPage9.Controls.Add(Fybszi);
            xtraTabPage9.Controls.Add(Sdbsshu);
            xtraTabPage9.Controls.Add(Sdbszi);
            xtraTabPage9.Controls.Add(Mfbsshu);
            xtraTabPage9.Controls.Add(Mfbszi);
            xtraTabPage9.Controls.Add(Smjlbsshu);
            xtraTabPage9.Controls.Add(Smjlbszi);
            xtraTabPage9.Controls.Add(Lhjlbsshu);
            xtraTabPage9.Controls.Add(Lhjlbszi);
            xtraTabPage9.Controls.Add(Zrjlbsshu);
            xtraTabPage9.Controls.Add(Zrjlbszi);
            xtraTabPage9.Controls.Add(Gjjlbsshu);
            xtraTabPage9.Controls.Add(Gjjlbszi);
            xtraTabPage9.Controls.Add(Lhbsshu);
            xtraTabPage9.Controls.Add(Lhbszi);
            xtraTabPage9.Controls.Add(Zrbsshu);
            xtraTabPage9.Controls.Add(Zrbszi);
            xtraTabPage9.Controls.Add(Gjbsshu);
            xtraTabPage9.Controls.Add(Gjbszi);
            xtraTabPage9.Controls.Add(EwaijinbiOK);
            xtraTabPage9.Controls.Add(Ewaijinbi);
            xtraTabPage9.Controls.Add(EwaibaolvOK);
            xtraTabPage9.Controls.Add(Ewaibaolv);
            xtraTabPage9.Controls.Add(EwaijingyanOK);
            xtraTabPage9.Controls.Add(Ewaijingyan);
            xtraTabPage9.Controls.Add(Ghquanc2029);
            xtraTabPage9.Controls.Add(Ghquan2029);
            xtraTabPage9.Controls.Add(Ghquanc1019);
            xtraTabPage9.Controls.Add(Ghquan1019);
            xtraTabPage9.Controls.Add(Ghquanc0109);
            xtraTabPage9.Controls.Add(Ghquan0109);
            xtraTabPage9.Controls.Add(Ghquanc9099);
            xtraTabPage9.Controls.Add(Ghquan9099);
            xtraTabPage9.Controls.Add(Ghquanc8089);
            xtraTabPage9.Controls.Add(Ghquan8089);
            xtraTabPage9.Controls.Add(Ghquanc7079);
            xtraTabPage9.Controls.Add(Ghquan7079);
            xtraTabPage9.Controls.Add(Ghquanc6069);
            xtraTabPage9.Controls.Add(Ghquan6069);
            xtraTabPage9.Controls.Add(Ghquanc5059);
            xtraTabPage9.Controls.Add(Ghquan5059);
            xtraTabPage9.Controls.Add(Ghquanc4049);
            xtraTabPage9.Controls.Add(Ghquan4049);
            xtraTabPage9.Controls.Add(Ghquanc3039);
            xtraTabPage9.Controls.Add(Ghquan3039);
            xtraTabPage9.Controls.Add(Jingliancglvc);
            xtraTabPage9.Controls.Add(Jingliancglv);
            xtraTabPage9.Controls.Add(CompanionRateEdit);
            xtraTabPage9.Controls.Add(labelControl68);
            xtraTabPage9.Controls.Add(SkillRateEdit);
            xtraTabPage9.Controls.Add(labelControl58);
            xtraTabPage9.Controls.Add(GoldRateEdit);
            xtraTabPage9.Controls.Add(labelControl57);
            xtraTabPage9.Controls.Add(DropRateEdit);
            xtraTabPage9.Controls.Add(labelControl56);
            xtraTabPage9.Controls.Add(ExperienceRateEdit);
            xtraTabPage9.Controls.Add(labelControl55);
            xtraTabPage9.Name = "xtraTabPage9";
            xtraTabPage9.Size = new System.Drawing.Size(898, 435);
            xtraTabPage9.Text = "加成";
            
            
            
            Lvduzi.Location = new System.Drawing.Point(22, 726);
            Lvduzi.Name = "Lvduzi";
            Lvduzi.Size = new System.Drawing.Size(94, 14);
            Lvduzi.TabIndex = 367;
            Lvduzi.Text = "公会回收泉20-29:";
            
            
            
            Lvdushu.Location = new System.Drawing.Point(126, 723);
            Lvdushu.MenuManager = ribbon;
            Lvdushu.Name = "Lvdushu";
            Lvdushu.Properties.Appearance.Options.UseTextOptions = true;
            Lvdushu.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            Lvdushu.Properties.Mask.EditMask = "n0";
            Lvdushu.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            Lvdushu.Properties.Mask.UseMaskAsDisplayFormat = true;
            Lvdushu.Size = new System.Drawing.Size(50, 20);
            Lvdushu.TabIndex = 366;
            
            
            
            Qduobizi.Location = new System.Drawing.Point(22, 698);
            Qduobizi.Name = "Qduobizi";
            Qduobizi.Size = new System.Drawing.Size(94, 14);
            Qduobizi.TabIndex = 229;
            Qduobizi.Text = "公会回收泉10-19:";
            
            
            
            Qduobishu.Location = new System.Drawing.Point(126, 695);
            Qduobishu.MenuManager = ribbon;
            Qduobishu.Name = "Qduobishu";
            Qduobishu.Properties.Appearance.Options.UseTextOptions = true;
            Qduobishu.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            Qduobishu.Properties.Mask.EditMask = "n0";
            Qduobishu.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            Qduobishu.Properties.Mask.UseMaskAsDisplayFormat = true;
            Qduobishu.Size = new System.Drawing.Size(50, 20);
            Qduobishu.TabIndex = 228;
            
            
            
            Qgedangzi.Location = new System.Drawing.Point(22, 670);
            Qgedangzi.Name = "Qchenmozi";
            Qgedangzi.Size = new System.Drawing.Size(94, 14);
            Qgedangzi.TabIndex = 227;
            Qgedangzi.Text = "公会回收泉01-09:";
            
            
            
            Qgedangshu.Location = new System.Drawing.Point(126, 667);
            Qgedangshu.MenuManager = ribbon;
            Qgedangshu.Name = "Qgedangshu";
            Qgedangshu.Properties.Appearance.Options.UseTextOptions = true;
            Qgedangshu.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            Qgedangshu.Properties.Mask.EditMask = "n0";
            Qgedangshu.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            Qgedangshu.Properties.Mask.UseMaskAsDisplayFormat = true;
            Qgedangshu.Size = new System.Drawing.Size(50, 20);
            Qgedangshu.TabIndex = 226;
            
            
            
            Qchenmozi.Location = new System.Drawing.Point(22, 642);
            Qchenmozi.Name = "Qchenmozi";
            Qchenmozi.Size = new System.Drawing.Size(94, 14);
            Qchenmozi.TabIndex = 225;
            Qchenmozi.Text = "公会回收泉90以上:";
            
            
            
            Qchenmoshu.Location = new System.Drawing.Point(126, 639);
            Qchenmoshu.MenuManager = ribbon;
            Qchenmoshu.Name = "Qchenmoshu";
            Qchenmoshu.Properties.Appearance.Options.UseTextOptions = true;
            Qchenmoshu.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            Qchenmoshu.Properties.Mask.EditMask = "n0";
            Qchenmoshu.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            Qchenmoshu.Properties.Mask.UseMaskAsDisplayFormat = true;
            Qchenmoshu.Size = new System.Drawing.Size(50, 20);
            Qchenmoshu.TabIndex = 224;
            
            
            
            Qyidongzi.Location = new System.Drawing.Point(22, 614);
            Qyidongzi.Name = "Qyidongzi";
            Qyidongzi.Size = new System.Drawing.Size(94, 14);
            Qyidongzi.TabIndex = 223;
            Qyidongzi.Text = "公会回收泉80-89:";
            
            
            
            Qyidongshu.Location = new System.Drawing.Point(126, 611);
            Qyidongshu.MenuManager = ribbon;
            Qyidongshu.Name = "Qyidongshu";
            Qyidongshu.Properties.Appearance.Options.UseTextOptions = true;
            Qyidongshu.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            Qyidongshu.Properties.Mask.EditMask = "n0";
            Qyidongshu.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            Qyidongshu.Properties.Mask.UseMaskAsDisplayFormat = true;
            Qyidongshu.Size = new System.Drawing.Size(50, 20);
            Qyidongshu.TabIndex = 222;
            
            
            
            Qmabizi.Location = new System.Drawing.Point(22, 586);
            Qmabizi.Name = "Qmabizi";
            Qmabizi.Size = new System.Drawing.Size(94, 14);
            Qmabizi.TabIndex = 221;
            Qmabizi.Text = "公会回收泉70-79:";
            
            
            
            Qmabishu.Location = new System.Drawing.Point(126, 583);
            Qmabishu.MenuManager = ribbon;
            Qmabishu.Name = "Qmabishu";
            Qmabishu.Properties.Appearance.Options.UseTextOptions = true;
            Qmabishu.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            Qmabishu.Properties.Mask.EditMask = "n0";
            Qmabishu.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            Qmabishu.Properties.Mask.UseMaskAsDisplayFormat = true;
            Qmabishu.Size = new System.Drawing.Size(50, 20);
            Qmabishu.TabIndex = 220;
            
            
            
            Qbingdongzi.Location = new System.Drawing.Point(22, 558);
            Qbingdongzi.Name = "Qbingdongzi";
            Qbingdongzi.Size = new System.Drawing.Size(94, 14);
            Qbingdongzi.TabIndex = 219;
            Qbingdongzi.Text = "公会回收泉60-69:";
            
            
            
            Qbingdongshu.Location = new System.Drawing.Point(126, 555);
            Qbingdongshu.MenuManager = ribbon;
            Qbingdongshu.Name = "Qbingdongshu";
            Qbingdongshu.Properties.Appearance.Options.UseTextOptions = true;
            Qbingdongshu.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            Qbingdongshu.Properties.Mask.EditMask = "n0";
            Qbingdongshu.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            Qbingdongshu.Properties.Mask.UseMaskAsDisplayFormat = true;
            Qbingdongshu.Size = new System.Drawing.Size(50, 20);
            Qbingdongshu.TabIndex = 218;
            
            
            
            Qmofadunzi.Location = new System.Drawing.Point(22, 530);
            Qmofadunzi.Name = "Qmofadunzi";
            Qmofadunzi.Size = new System.Drawing.Size(94, 14);
            Qmofadunzi.TabIndex = 217;
            Qmofadunzi.Text = "公会回收泉50-59:";
            
            
            
            Qmofadunshu.Location = new System.Drawing.Point(126, 527);
            Qmofadunshu.MenuManager = ribbon;
            Qmofadunshu.Name = "Qmofadunshu";
            Qmofadunshu.Properties.Appearance.Options.UseTextOptions = true;
            Qmofadunshu.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            Qmofadunshu.Properties.Mask.EditMask = "n0";
            Qmofadunshu.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            Qmofadunshu.Properties.Mask.UseMaskAsDisplayFormat = true;
            Qmofadunshu.Size = new System.Drawing.Size(50, 20);
            Qmofadunshu.TabIndex = 216;
            
            
            
            Qhuanzi.Location = new System.Drawing.Point(22, 502);
            Qhuanzi.Name = "Qhuanzi";
            Qhuanzi.Size = new System.Drawing.Size(94, 14);
            Qhuanzi.TabIndex = 215;
            Qhuanzi.Text = "公会回收泉40-49:";
            
            
            
            Qhuanshu.Location = new System.Drawing.Point(126, 499);
            Qhuanshu.MenuManager = ribbon;
            Qhuanshu.Name = "Qhuanshu";
            Qhuanshu.Properties.Appearance.Options.UseTextOptions = true;
            Qhuanshu.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            Qhuanshu.Properties.Mask.EditMask = "n0";
            Qhuanshu.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            Qhuanshu.Properties.Mask.UseMaskAsDisplayFormat = true;
            Qhuanshu.Size = new System.Drawing.Size(50, 20);
            Qhuanshu.TabIndex = 214;
            
            
            
            Qanzi.Location = new System.Drawing.Point(22, 474);
            Qanzi.Name = "Qanzi";
            Qanzi.Size = new System.Drawing.Size(94, 14);
            Qanzi.TabIndex = 213;
            Qanzi.Text = "公会回收泉30-39:";
            
            
            
            Qanshu.Location = new System.Drawing.Point(126, 471);
            Qanshu.MenuManager = ribbon;
            Qanshu.Name = "Qanshu";
            Qanshu.Properties.Appearance.Options.UseTextOptions = true;
            Qanshu.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            Qanshu.Properties.Mask.EditMask = "n0";
            Qanshu.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            Qanshu.Properties.Mask.UseMaskAsDisplayFormat = true;
            Qanshu.Size = new System.Drawing.Size(50, 20);
            Qanshu.TabIndex = 212;
            
            
            
            
            
            XinshouGuildzi.Location = new System.Drawing.Point(668, 26);
            XinshouGuildzi.Name = "XinshouGuildzi";
            XinshouGuildzi.Size = new System.Drawing.Size(94, 275);
            XinshouGuildzi.TabIndex = 415;
            XinshouGuildzi.Text = "新手公会Buff加成:";
            
            
            
            
            
            XGuilddj.Location = new System.Drawing.Point(668, 54);
            XGuilddj.Name = "XGuilddj";
            XGuilddj.Size = new System.Drawing.Size(94, 275);
            XGuilddj.TabIndex = 416;
            XGuilddj.Text = "等级低于:";
            
            
            
            
            
            XGuilddjshu.Location = new System.Drawing.Point(726, 51);
            XGuilddjshu.MenuManager = ribbon;
            XGuilddjshu.Name = "XGuilddjshu";
            XGuilddjshu.Properties.Appearance.Options.UseTextOptions = true;
            XGuilddjshu.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            XGuilddjshu.Properties.Mask.EditMask = "n0";
            XGuilddjshu.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            XGuilddjshu.Properties.Mask.UseMaskAsDisplayFormat = true;
            XGuilddjshu.Size = new System.Drawing.Size(40, 20);
            XGuilddjshu.TabIndex = 417;
            
            
            
            
            
            XGuildjy.Location = new System.Drawing.Point(668, 82);
            XGuildjy.Name = "XGuildjy";
            XGuildjy.Size = new System.Drawing.Size(94, 275);
            XGuildjy.TabIndex = 418;
            XGuildjy.Text = "经验加成:";
            
            
            
            
            
            XGuildjyshu.Location = new System.Drawing.Point(726, 79);
            XGuildjyshu.MenuManager = ribbon;
            XGuildjyshu.Name = "XGuildjyshu";
            XGuildjyshu.Properties.Appearance.Options.UseTextOptions = true;
            XGuildjyshu.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            XGuildjyshu.Properties.Mask.EditMask = "n0";
            XGuildjyshu.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            XGuildjyshu.Properties.Mask.UseMaskAsDisplayFormat = true;
            XGuildjyshu.Size = new System.Drawing.Size(40, 20);
            XGuildjyshu.TabIndex = 419;
            
            
            
            
            
            XGuildbl.Location = new System.Drawing.Point(668, 110);
            XGuildbl.Name = "XGuildbl";
            XGuildbl.Size = new System.Drawing.Size(94, 275);
            XGuildbl.TabIndex = 420;
            XGuildbl.Text = "爆率加成:";
            
            
            
            
            
            XGuildblshu.Location = new System.Drawing.Point(726, 107);
            XGuildblshu.MenuManager = ribbon;
            XGuildblshu.Name = "XGuildblshu";
            XGuildblshu.Properties.Appearance.Options.UseTextOptions = true;
            XGuildblshu.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            XGuildblshu.Properties.Mask.EditMask = "n0";
            XGuildblshu.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            XGuildblshu.Properties.Mask.UseMaskAsDisplayFormat = true;
            XGuildblshu.Size = new System.Drawing.Size(40, 20);
            XGuildblshu.TabIndex = 421;
            
            
            
            
            
            XGuildjb.Location = new System.Drawing.Point(668, 138);
            XGuildjb.Name = "XGuildjb";
            XGuildjb.Size = new System.Drawing.Size(94, 275);
            XGuildjb.TabIndex = 422;
            XGuildjb.Text = "金币加成:";
            
            
            
            
            
            XGuildjbshu.Location = new System.Drawing.Point(726, 135);
            XGuildjbshu.MenuManager = ribbon;
            XGuildjbshu.Name = "XGuildjbshu";
            XGuildjbshu.Properties.Appearance.Options.UseTextOptions = true;
            XGuildjbshu.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            XGuildjbshu.Properties.Mask.EditMask = "n0";
            XGuildjbshu.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            XGuildjbshu.Properties.Mask.UseMaskAsDisplayFormat = true;
            XGuildjbshu.Size = new System.Drawing.Size(40, 20);
            XGuildjbshu.TabIndex = 423;
            
            
            
            
            
            QitaGuildzi.Location = new System.Drawing.Point(668, 164);
            QitaGuildzi.Name = "QitaGuildzi";
            QitaGuildzi.Size = new System.Drawing.Size(94, 275);
            QitaGuildzi.TabIndex = 424;
            QitaGuildzi.Text = "其他公会Buff加成:";
            
            
            
            
            
            YiGuildrs.Location = new System.Drawing.Point(668, 192);
            YiGuildrs.Name = "YiGuildrs";
            YiGuildrs.Size = new System.Drawing.Size(94, 275);
            YiGuildrs.TabIndex = 425;
            YiGuildrs.Text = "人数限制:";
            
            
            
            
            
            YiGuildrsshu.Location = new System.Drawing.Point(726, 189);
            YiGuildrsshu.MenuManager = ribbon;
            YiGuildrsshu.Name = "YiGuildrsshu";
            YiGuildrsshu.Properties.Appearance.Options.UseTextOptions = true;
            YiGuildrsshu.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            YiGuildrsshu.Properties.Mask.EditMask = "n0";
            YiGuildrsshu.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            YiGuildrsshu.Properties.Mask.UseMaskAsDisplayFormat = true;
            YiGuildrsshu.Size = new System.Drawing.Size(40, 20);
            YiGuildrsshu.TabIndex = 426;
            
            
            
            
            
            YiGuildjy.Location = new System.Drawing.Point(668, 220);
            YiGuildjy.Name = "YiGuildjy";
            YiGuildjy.Size = new System.Drawing.Size(94, 275);
            YiGuildjy.TabIndex = 427;
            YiGuildjy.Text = "经验加成:";
            
            
            
            
            
            YiGuildjyshu.Location = new System.Drawing.Point(726, 217);
            YiGuildjyshu.MenuManager = ribbon;
            YiGuildjyshu.Name = "YiGuildjyshu";
            YiGuildjyshu.Properties.Appearance.Options.UseTextOptions = true;
            YiGuildjyshu.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            YiGuildjyshu.Properties.Mask.EditMask = "n0";
            YiGuildjyshu.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            YiGuildjyshu.Properties.Mask.UseMaskAsDisplayFormat = true;
            YiGuildjyshu.Size = new System.Drawing.Size(40, 20);
            YiGuildjyshu.TabIndex = 428;
            
            
            
            
            
            YiGuildbl.Location = new System.Drawing.Point(668, 248);
            YiGuildbl.Name = "YiGuildbl";
            YiGuildbl.Size = new System.Drawing.Size(94, 275);
            YiGuildbl.TabIndex = 429;
            YiGuildbl.Text = "爆率加成:";
            
            
            
            
            
            YiGuildblshu.Location = new System.Drawing.Point(726, 245);
            YiGuildblshu.MenuManager = ribbon;
            YiGuildblshu.Name = "YiGuildblshu";
            YiGuildblshu.Properties.Appearance.Options.UseTextOptions = true;
            YiGuildblshu.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            YiGuildblshu.Properties.Mask.EditMask = "n0";
            YiGuildblshu.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            YiGuildblshu.Properties.Mask.UseMaskAsDisplayFormat = true;
            YiGuildblshu.Size = new System.Drawing.Size(40, 20);
            YiGuildblshu.TabIndex = 430;
            
            
            
            
            
            YiGuildjb.Location = new System.Drawing.Point(668, 274);
            YiGuildjb.Name = "YiGuildjb";
            YiGuildjb.Size = new System.Drawing.Size(94, 275);
            YiGuildjb.TabIndex = 431;
            YiGuildjb.Text = "金币加成:";
            
            
            
            
            
            YiGuildjbshu.Location = new System.Drawing.Point(726, 271);
            YiGuildjbshu.MenuManager = ribbon;
            YiGuildjbshu.Name = "YiGuildjbshu";
            YiGuildjbshu.Properties.Appearance.Options.UseTextOptions = true;
            YiGuildjbshu.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            YiGuildjbshu.Properties.Mask.EditMask = "n0";
            YiGuildjbshu.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            YiGuildjbshu.Properties.Mask.UseMaskAsDisplayFormat = true;
            YiGuildjbshu.Size = new System.Drawing.Size(40, 20);
            YiGuildjbshu.TabIndex = 432;
            
            
            
            
            
            ErGuildrs.Location = new System.Drawing.Point(668, 302);
            ErGuildrs.Name = "ErGuildrs";
            ErGuildrs.Size = new System.Drawing.Size(94, 275);
            ErGuildrs.TabIndex = 433;
            ErGuildrs.Text = "人数限制:";
            
            
            
            
            
            ErGuildrsshu.Location = new System.Drawing.Point(726, 299);
            ErGuildrsshu.MenuManager = ribbon;
            ErGuildrsshu.Name = "ErGuildrsshu";
            ErGuildrsshu.Properties.Appearance.Options.UseTextOptions = true;
            ErGuildrsshu.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            ErGuildrsshu.Properties.Mask.EditMask = "n0";
            ErGuildrsshu.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            ErGuildrsshu.Properties.Mask.UseMaskAsDisplayFormat = true;
            ErGuildrsshu.Size = new System.Drawing.Size(40, 20);
            ErGuildrsshu.TabIndex = 434;
            
            
            
            
            
            ErGuildjy.Location = new System.Drawing.Point(668, 330);
            ErGuildjy.Name = "ErGuildjy";
            ErGuildjy.Size = new System.Drawing.Size(94, 275);
            ErGuildjy.TabIndex = 435;
            ErGuildjy.Text = "经验加成:";
            
            
            
            
            
            ErGuildjyshu.Location = new System.Drawing.Point(726, 327);
            ErGuildjyshu.MenuManager = ribbon;
            ErGuildjyshu.Name = "ErGuildjyshu";
            ErGuildjyshu.Properties.Appearance.Options.UseTextOptions = true;
            ErGuildjyshu.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            ErGuildjyshu.Properties.Mask.EditMask = "n0";
            ErGuildjyshu.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            ErGuildjyshu.Properties.Mask.UseMaskAsDisplayFormat = true;
            ErGuildjyshu.Size = new System.Drawing.Size(40, 20);
            ErGuildjyshu.TabIndex = 436;
            
            
            
            
            
            ErGuildbl.Location = new System.Drawing.Point(668, 358);
            ErGuildbl.Name = "ErGuildbl";
            ErGuildbl.Size = new System.Drawing.Size(94, 275);
            ErGuildbl.TabIndex = 437;
            ErGuildbl.Text = "爆率加成:";
            
            
            
            
            
            ErGuildblshu.Location = new System.Drawing.Point(726, 355);
            ErGuildblshu.MenuManager = ribbon;
            ErGuildblshu.Name = "ErGuildblshu";
            ErGuildblshu.Properties.Appearance.Options.UseTextOptions = true;
            ErGuildblshu.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            ErGuildblshu.Properties.Mask.EditMask = "n0";
            ErGuildblshu.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            ErGuildblshu.Properties.Mask.UseMaskAsDisplayFormat = true;
            ErGuildblshu.Size = new System.Drawing.Size(40, 20);
            ErGuildblshu.TabIndex = 438;
            
            
            
            
            
            ErGuildjb.Location = new System.Drawing.Point(668, 386);
            ErGuildjb.Name = "ErGuildjb";
            ErGuildjb.Size = new System.Drawing.Size(94, 275);
            ErGuildjb.TabIndex = 439;
            ErGuildjb.Text = "金币加成:";
            
            
            
            
            
            ErGuildjbshu.Location = new System.Drawing.Point(726, 383);
            ErGuildjbshu.MenuManager = ribbon;
            ErGuildjbshu.Name = "ErGuildjbshu";
            ErGuildjbshu.Properties.Appearance.Options.UseTextOptions = true;
            ErGuildjbshu.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            ErGuildjbshu.Properties.Mask.EditMask = "n0";
            ErGuildjbshu.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            ErGuildjbshu.Properties.Mask.UseMaskAsDisplayFormat = true;
            ErGuildjbshu.Size = new System.Drawing.Size(40, 20);
            ErGuildjbshu.TabIndex = 440;
            
            
            
            
            
            SanGuildrs.Location = new System.Drawing.Point(668, 414);
            SanGuildrs.Name = "SanGuildrs";
            SanGuildrs.Size = new System.Drawing.Size(94, 275);
            SanGuildrs.TabIndex = 441;
            SanGuildrs.Text = "人数限制:";
            
            
            
            
            
            SanGuildrsshu.Location = new System.Drawing.Point(726, 411);
            SanGuildrsshu.MenuManager = ribbon;
            SanGuildrsshu.Name = "SanGuildrsshu";
            SanGuildrsshu.Properties.Appearance.Options.UseTextOptions = true;
            SanGuildrsshu.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            SanGuildrsshu.Properties.Mask.EditMask = "n0";
            SanGuildrsshu.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            SanGuildrsshu.Properties.Mask.UseMaskAsDisplayFormat = true;
            SanGuildrsshu.Size = new System.Drawing.Size(40, 20);
            SanGuildrsshu.TabIndex = 442;
            
            
            
            
            
            SanGuildjy.Location = new System.Drawing.Point(668, 442);
            SanGuildjy.Name = "SanGuildjy";
            SanGuildjy.Size = new System.Drawing.Size(94, 275);
            SanGuildjy.TabIndex = 443;
            SanGuildjy.Text = "经验加成:";
            
            
            
            
            
            SanGuildjyshu.Location = new System.Drawing.Point(726, 439);
            SanGuildjyshu.MenuManager = ribbon;
            SanGuildjyshu.Name = "SanGuildjyshu";
            SanGuildjyshu.Properties.Appearance.Options.UseTextOptions = true;
            SanGuildjyshu.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            SanGuildjyshu.Properties.Mask.EditMask = "n0";
            SanGuildjyshu.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            SanGuildjyshu.Properties.Mask.UseMaskAsDisplayFormat = true;
            SanGuildjyshu.Size = new System.Drawing.Size(40, 20);
            SanGuildjyshu.TabIndex = 444;
            
            
            
            
            
            SanGuildbl.Location = new System.Drawing.Point(668, 470);
            SanGuildbl.Name = "SanGuildbl";
            SanGuildbl.Size = new System.Drawing.Size(94, 275);
            SanGuildbl.TabIndex = 445;
            SanGuildbl.Text = "爆率加成:";
            
            
            
            
            
            SanGuildblshu.Location = new System.Drawing.Point(726, 467);
            SanGuildblshu.MenuManager = ribbon;
            SanGuildblshu.Name = "SanGuildblshu";
            SanGuildblshu.Properties.Appearance.Options.UseTextOptions = true;
            SanGuildblshu.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            SanGuildblshu.Properties.Mask.EditMask = "n0";
            SanGuildblshu.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            SanGuildblshu.Properties.Mask.UseMaskAsDisplayFormat = true;
            SanGuildblshu.Size = new System.Drawing.Size(40, 20);
            SanGuildblshu.TabIndex = 446;
            
            
            
            
            
            SanGuildjb.Location = new System.Drawing.Point(668, 498);
            SanGuildjb.Name = "SanGuildjb";
            SanGuildjb.Size = new System.Drawing.Size(94, 275);
            SanGuildjb.TabIndex = 447;
            SanGuildjb.Text = "金币加成:";
            
            
            
            
            
            SanGuildjbshu.Location = new System.Drawing.Point(726, 495);
            SanGuildjbshu.MenuManager = ribbon;
            SanGuildjbshu.Name = "SanGuildjbshu";
            SanGuildjbshu.Properties.Appearance.Options.UseTextOptions = true;
            SanGuildjbshu.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            SanGuildjbshu.Properties.Mask.EditMask = "n0";
            SanGuildjbshu.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            SanGuildjbshu.Properties.Mask.UseMaskAsDisplayFormat = true;
            SanGuildjbshu.Size = new System.Drawing.Size(40, 20);
            SanGuildjbshu.TabIndex = 448;
            
            
            
            
            
            SiGuildrs.Location = new System.Drawing.Point(668, 526);
            SiGuildrs.Name = "SiGuildrs";
            SiGuildrs.Size = new System.Drawing.Size(94, 275);
            SiGuildrs.TabIndex = 449;
            SiGuildrs.Text = "人数大于:";
            
            
            
            
            
            SiGuildrsshu.Location = new System.Drawing.Point(726, 523);
            SiGuildrsshu.MenuManager = ribbon;
            SiGuildrsshu.Name = "SiGuildrsshu";
            SiGuildrsshu.Properties.Appearance.Options.UseTextOptions = true;
            SiGuildrsshu.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            SiGuildrsshu.Properties.Mask.EditMask = "n0";
            SiGuildrsshu.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            SiGuildrsshu.Properties.Mask.UseMaskAsDisplayFormat = true;
            SiGuildrsshu.Size = new System.Drawing.Size(40, 20);
            SiGuildrsshu.TabIndex = 450;
            
            
            
            
            
            SiGuildjy.Location = new System.Drawing.Point(668, 554);
            SiGuildjy.Name = "SiGuildjy";
            SiGuildjy.Size = new System.Drawing.Size(94, 275);
            SiGuildjy.TabIndex = 451;
            SiGuildjy.Text = "经验加成:";
            
            
            
            
            
            SiGuildjyshu.Location = new System.Drawing.Point(726, 551);
            SiGuildjyshu.MenuManager = ribbon;
            SiGuildjyshu.Name = "SiGuildjyshu";
            SiGuildjyshu.Properties.Appearance.Options.UseTextOptions = true;
            SiGuildjyshu.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            SiGuildjyshu.Properties.Mask.EditMask = "n0";
            SiGuildjyshu.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            SiGuildjyshu.Properties.Mask.UseMaskAsDisplayFormat = true;
            SiGuildjyshu.Size = new System.Drawing.Size(40, 20);
            SiGuildjyshu.TabIndex = 452;
            
            
            
            
            
            SiGuildbl.Location = new System.Drawing.Point(668, 582);
            SiGuildbl.Name = "SiGuildbl";
            SiGuildbl.Size = new System.Drawing.Size(94, 275);
            SiGuildbl.TabIndex = 453;
            SiGuildbl.Text = "爆率加成:";
            
            
            
            
            
            SiGuildblshu.Location = new System.Drawing.Point(726, 579);
            SiGuildblshu.MenuManager = ribbon;
            SiGuildblshu.Name = "SiGuildblshu";
            SiGuildblshu.Properties.Appearance.Options.UseTextOptions = true;
            SiGuildblshu.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            SiGuildblshu.Properties.Mask.EditMask = "n0";
            SiGuildblshu.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            SiGuildblshu.Properties.Mask.UseMaskAsDisplayFormat = true;
            SiGuildblshu.Size = new System.Drawing.Size(40, 20);
            SiGuildblshu.TabIndex = 454;
            
            
            
            
            
            SiGuildjb.Location = new System.Drawing.Point(668, 610);
            SiGuildjb.Name = "SiGuildjb";
            SiGuildjb.Size = new System.Drawing.Size(94, 275);
            SiGuildjb.TabIndex = 455;
            SiGuildjb.Text = "金币加成:";
            
            
            
            
            
            SiGuildjbshu.Location = new System.Drawing.Point(726, 607);
            SiGuildjbshu.MenuManager = ribbon;
            SiGuildjbshu.Name = "SiGuildjbshu";
            SiGuildjbshu.Properties.Appearance.Options.UseTextOptions = true;
            SiGuildjbshu.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            SiGuildjbshu.Properties.Mask.EditMask = "n0";
            SiGuildjbshu.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            SiGuildjbshu.Properties.Mask.UseMaskAsDisplayFormat = true;
            SiGuildjbshu.Size = new System.Drawing.Size(40, 20);
            SiGuildjbshu.TabIndex = 456;
            
            
            
            
            
            ShaGuildzi.Location = new System.Drawing.Point(656, 638);
            ShaGuildzi.Name = "ShaGuildzi";
            ShaGuildzi.Size = new System.Drawing.Size(94, 275);
            ShaGuildzi.TabIndex = 457;
            ShaGuildzi.Text = "沙巴克公会Buff加成:";

            
            
            
            
            
            ShaGuildjy.Location = new System.Drawing.Point(668, 664);
            ShaGuildjy.Name = "ShaGuildjy";
            ShaGuildjy.Size = new System.Drawing.Size(94, 275);
            ShaGuildjy.TabIndex = 458;
            ShaGuildjy.Text = "经验加成:";
            
            
            
            
            
            ShaGuildjyshu.Location = new System.Drawing.Point(726, 661);
            ShaGuildjyshu.MenuManager = ribbon;
            ShaGuildjyshu.Name = "ShaGuildjyshu";
            ShaGuildjyshu.Properties.Appearance.Options.UseTextOptions = true;
            ShaGuildjyshu.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            ShaGuildjyshu.Properties.Mask.EditMask = "n0";
            ShaGuildjyshu.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            ShaGuildjyshu.Properties.Mask.UseMaskAsDisplayFormat = true;
            ShaGuildjyshu.Size = new System.Drawing.Size(40, 20);
            ShaGuildjyshu.TabIndex = 459;
            
            
            
            
            
            ShaGuildbl.Location = new System.Drawing.Point(668, 692);
            ShaGuildbl.Name = "ShaGuildbl";
            ShaGuildbl.Size = new System.Drawing.Size(94, 275);
            ShaGuildbl.TabIndex = 460;
            ShaGuildbl.Text = "爆率加成:";
            
            
            
            
            
            ShaGuildblshu.Location = new System.Drawing.Point(726, 689);
            ShaGuildblshu.MenuManager = ribbon;
            ShaGuildblshu.Name = "ShaGuildblshu";
            ShaGuildblshu.Properties.Appearance.Options.UseTextOptions = true;
            ShaGuildblshu.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            ShaGuildblshu.Properties.Mask.EditMask = "n0";
            ShaGuildblshu.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            ShaGuildblshu.Properties.Mask.UseMaskAsDisplayFormat = true;
            ShaGuildblshu.Size = new System.Drawing.Size(40, 20);
            ShaGuildblshu.TabIndex = 461;
            
            
            
            
            
            ShaGuildjb.Location = new System.Drawing.Point(668, 720);
            ShaGuildjb.Name = "ShaGuildjb";
            ShaGuildjb.Size = new System.Drawing.Size(94, 275);
            ShaGuildjb.TabIndex = 462;
            ShaGuildjb.Text = "金币加成:";
            
            
            
            
            
            ShaGuildjbshu.Location = new System.Drawing.Point(726, 717);
            ShaGuildjbshu.MenuManager = ribbon;
            ShaGuildjbshu.Name = "ShaGuildjbshu";
            ShaGuildjbshu.Properties.Appearance.Options.UseTextOptions = true;
            ShaGuildjbshu.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            ShaGuildjbshu.Properties.Mask.EditMask = "n0";
            ShaGuildjbshu.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            ShaGuildjbshu.Properties.Mask.UseMaskAsDisplayFormat = true;
            ShaGuildjbshu.Size = new System.Drawing.Size(40, 20);
            ShaGuildjbshu.TabIndex = 463;

            
            
            
            
            
            Jieshaorendjwushi.Location = new System.Drawing.Point(456, 723);
            Jieshaorendjwushi.Name = "Jieshaorendjwushi";
            Jieshaorendjwushi.Size = new System.Drawing.Size(94, 275);
            Jieshaorendjwushi.TabIndex = 294;
            Jieshaorendjwushi.Text = "介绍人等级50时:";
            
            
            
            
            
            Jieshaorendjwushishu.Location = new System.Drawing.Point(553, 720);
            Jieshaorendjwushishu.MenuManager = ribbon;
            Jieshaorendjwushishu.Name = "Jieshaorendjwushishu";
            Jieshaorendjwushishu.Properties.Appearance.Options.UseTextOptions = true;
            Jieshaorendjwushishu.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            Jieshaorendjwushishu.Properties.Mask.EditMask = "n0";
            Jieshaorendjwushishu.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            Jieshaorendjwushishu.Properties.Mask.UseMaskAsDisplayFormat = true;
            Jieshaorendjwushishu.Size = new System.Drawing.Size(40, 20);
            Jieshaorendjwushishu.TabIndex = 293;
            
            
            
            
            
            Jieshaorendjsishi.Location = new System.Drawing.Point(456, 695);
            Jieshaorendjsishi.Name = "Jieshaorendjsishi";
            Jieshaorendjsishi.Size = new System.Drawing.Size(94, 275);
            Jieshaorendjsishi.TabIndex = 292;
            Jieshaorendjsishi.Text = "介绍人等级40时:";
            
            
            
            
            
            Jieshaorendjsishishu.Location = new System.Drawing.Point(553, 692);
            Jieshaorendjsishishu.MenuManager = ribbon;
            Jieshaorendjsishishu.Name = "Jieshaorendjsishishu";
            Jieshaorendjsishishu.Properties.Appearance.Options.UseTextOptions = true;
            Jieshaorendjsishishu.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            Jieshaorendjsishishu.Properties.Mask.EditMask = "n0";
            Jieshaorendjsishishu.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            Jieshaorendjsishishu.Properties.Mask.UseMaskAsDisplayFormat = true;
            Jieshaorendjsishishu.Size = new System.Drawing.Size(40, 20);
            Jieshaorendjsishishu.TabIndex = 291;
            
            
            
            
            
            Jieshaorendjsanshi.Location = new System.Drawing.Point(456, 667);
            Jieshaorendjsanshi.Name = "Jieshaorendjsanshi";
            Jieshaorendjsanshi.Size = new System.Drawing.Size(94, 275);
            Jieshaorendjsanshi.TabIndex = 290;
            Jieshaorendjsanshi.Text = "介绍人等级30时:";
            
            
            
            
            
            Jieshaorendjsanshishu.Location = new System.Drawing.Point(553, 664);
            Jieshaorendjsanshishu.MenuManager = ribbon;
            Jieshaorendjsanshishu.Name = "Jieshaorendjsanshishu";
            Jieshaorendjsanshishu.Properties.Appearance.Options.UseTextOptions = true;
            Jieshaorendjsanshishu.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            Jieshaorendjsanshishu.Properties.Mask.EditMask = "n0";
            Jieshaorendjsanshishu.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            Jieshaorendjsanshishu.Properties.Mask.UseMaskAsDisplayFormat = true;
            Jieshaorendjsanshishu.Size = new System.Drawing.Size(40, 20);
            Jieshaorendjsanshishu.TabIndex = 289;
            
            
            
            
            
            Jieshaorendjershi.Location = new System.Drawing.Point(456, 639);
            Jieshaorendjershi.Name = "Jieshaorendjershi";
            Jieshaorendjershi.Size = new System.Drawing.Size(94, 275);
            Jieshaorendjershi.TabIndex = 288;
            Jieshaorendjershi.Text = "介绍人等级20时:";
            
            
            
            
            
            Jieshaorendjershishu.Location = new System.Drawing.Point(553, 636);
            Jieshaorendjershishu.MenuManager = ribbon;
            Jieshaorendjershishu.Name = "Jieshaorendjershishu";
            Jieshaorendjershishu.Properties.Appearance.Options.UseTextOptions = true;
            Jieshaorendjershishu.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            Jieshaorendjershishu.Properties.Mask.EditMask = "n0";
            Jieshaorendjershishu.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            Jieshaorendjershishu.Properties.Mask.UseMaskAsDisplayFormat = true;
            Jieshaorendjershishu.Size = new System.Drawing.Size(40, 20);
            Jieshaorendjershishu.TabIndex = 287;
            
            
            
            
            
            Jieshaorendjshi.Location = new System.Drawing.Point(456, 611);
            Jieshaorendjshi.Name = "Jieshaorendjshi";
            Jieshaorendjshi.Size = new System.Drawing.Size(94, 275);
            Jieshaorendjshi.TabIndex = 286;
            Jieshaorendjshi.Text = "介绍人等级10时:";
            
            
            
            
            
            Jieshaorendjshishu.Location = new System.Drawing.Point(553, 608);
            Jieshaorendjshishu.MenuManager = ribbon;
            Jieshaorendjshishu.Name = "Jieshaorendjshishu";
            Jieshaorendjshishu.Properties.Appearance.Options.UseTextOptions = true;
            Jieshaorendjshishu.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            Jieshaorendjshishu.Properties.Mask.EditMask = "n0";
            Jieshaorendjshishu.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            Jieshaorendjshishu.Properties.Mask.UseMaskAsDisplayFormat = true;
            Jieshaorendjshishu.Size = new System.Drawing.Size(40, 20);
            Jieshaorendjshishu.TabIndex = 285;
            
            
            
            
            
            Jieshaorendjjieshao.Location = new System.Drawing.Point(408, 583);
            Jieshaorendjjieshao.Name = "Jieshaorendjjieshao";
            Jieshaorendjjieshao.Size = new System.Drawing.Size(94, 275);
            Jieshaorendjjieshao.TabIndex = 284;
            Jieshaorendjjieshao.Text = "被介绍人注册账号时获得赏金设置:";
            
            
            
            
            
            Jieshaorenswsi.Location = new System.Drawing.Point(456, 555);
            Jieshaorenswsi.Name = "Jieshaorenswsi";
            Jieshaorenswsi.Size = new System.Drawing.Size(94, 275);
            Jieshaorenswsi.TabIndex = 283;
            Jieshaorenswsi.Text = "介绍人获得声望:";
            
            
            
            
            
            Jieshaorenswsishu.Location = new System.Drawing.Point(553, 552);
            Jieshaorenswsishu.MenuManager = ribbon;
            Jieshaorenswsishu.Name = "Jieshaorenswsishu";
            Jieshaorenswsishu.Properties.Appearance.Options.UseTextOptions = true;
            Jieshaorenswsishu.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            Jieshaorenswsishu.Properties.Mask.EditMask = "n0";
            Jieshaorenswsishu.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            Jieshaorenswsishu.Properties.Mask.UseMaskAsDisplayFormat = true;
            Jieshaorenswsishu.Size = new System.Drawing.Size(40, 20);
            Jieshaorenswsishu.TabIndex = 282;
            
            
            
            
            
            Jieshaorensjsi.Location = new System.Drawing.Point(456, 527);
            Jieshaorensjsi.Name = "Jieshaorensjsi";
            Jieshaorensjsi.Size = new System.Drawing.Size(94, 14);
            Jieshaorensjsi.TabIndex = 281;
            Jieshaorensjsi.Text = "介绍人获得赏金:";
            
            
            
            
            
            Jieshaorensjsishu.Location = new System.Drawing.Point(553, 524);
            Jieshaorensjsishu.MenuManager = ribbon;
            Jieshaorensjsishu.Name = "Jieshaorensjsishu";
            Jieshaorensjsishu.Properties.Appearance.Options.UseTextOptions = true;
            Jieshaorensjsishu.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            Jieshaorensjsishu.Properties.Mask.EditMask = "n0";
            Jieshaorensjsishu.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            Jieshaorensjsishu.Properties.Mask.UseMaskAsDisplayFormat = true;
            Jieshaorensjsishu.Size = new System.Drawing.Size(40, 20);
            Jieshaorensjsishu.TabIndex = 280;
            
            
            
            
            
            Bjieshaorenswsi.Location = new System.Drawing.Point(444, 499);
            Bjieshaorenswsi.Name = "Bjieshaorenswsi";
            Bjieshaorenswsi.Size = new System.Drawing.Size(94, 14);
            Bjieshaorenswsi.TabIndex = 279;
            Bjieshaorenswsi.Text = "被介绍人获得声望:";
            
            
            
            
            
            Bjieshaorenswsishu.Location = new System.Drawing.Point(553, 496);
            Bjieshaorenswsishu.MenuManager = ribbon;
            Bjieshaorenswsishu.Name = "Bjieshaorenswsishu";
            Bjieshaorenswsishu.Properties.Appearance.Options.UseTextOptions = true;
            Bjieshaorenswsishu.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            Bjieshaorenswsishu.Properties.Mask.EditMask = "n0";
            Bjieshaorenswsishu.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            Bjieshaorenswsishu.Properties.Mask.UseMaskAsDisplayFormat = true;
            Bjieshaorenswsishu.Size = new System.Drawing.Size(40, 20);
            Bjieshaorenswsishu.TabIndex = 278;
            
            
            
            
            
            Bjieshaorensjsi.Location = new System.Drawing.Point(444, 471);
            Bjieshaorensjsi.Name = "Bjieshaorensjsi";
            Bjieshaorensjsi.Size = new System.Drawing.Size(94, 14);
            Bjieshaorensjsi.TabIndex = 277;
            Bjieshaorensjsi.Text = "被介绍人获得赏金:";
            
            
            
            
            
            Bjieshaorensjsishu.Location = new System.Drawing.Point(553, 468);
            Bjieshaorensjsishu.MenuManager = ribbon;
            Bjieshaorensjsishu.Name = "Bjieshaorensjsishu";
            Bjieshaorensjsishu.Properties.Appearance.Options.UseTextOptions = true;
            Bjieshaorensjsishu.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            Bjieshaorensjsishu.Properties.Mask.EditMask = "n0";
            Bjieshaorensjsishu.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            Bjieshaorensjsishu.Properties.Mask.UseMaskAsDisplayFormat = true;
            Bjieshaorensjsishu.Size = new System.Drawing.Size(40, 20);
            Bjieshaorensjsishu.TabIndex = 276;
            
            
            
            
            
            Bjieshaorendjsi.Location = new System.Drawing.Point(468, 443);
            Bjieshaorendjsi.Name = "Bjieshaorendjsi";
            Bjieshaorendjsi.Size = new System.Drawing.Size(94, 14);
            Bjieshaorendjsi.TabIndex = 275;
            Bjieshaorendjsi.Text = "被介绍人等级:";
            
            
            
            
            
            Bjieshaorendjsishu.Location = new System.Drawing.Point(553, 440);
            Bjieshaorendjsishu.MenuManager = ribbon;
            Bjieshaorendjsishu.Name = "Bjieshaorendjsishu";
            Bjieshaorendjsishu.Properties.Appearance.Options.UseTextOptions = true;
            Bjieshaorendjsishu.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            Bjieshaorendjsishu.Properties.Mask.EditMask = "n0";
            Bjieshaorendjsishu.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            Bjieshaorendjsishu.Properties.Mask.UseMaskAsDisplayFormat = true;
            Bjieshaorendjsishu.Size = new System.Drawing.Size(40, 20);
            Bjieshaorendjsishu.TabIndex = 274;
            
            
            
            
            
            Jieshaorensws.Location = new System.Drawing.Point(456, 415);
            Jieshaorensws.Name = "Jieshaorensws";
            Jieshaorensws.Size = new System.Drawing.Size(94, 275);
            Jieshaorensws.TabIndex = 273;
            Jieshaorensws.Text = "介绍人获得声望:";
            
            
            
            
            
            Jieshaorenswsshu.Location = new System.Drawing.Point(553, 412);
            Jieshaorenswsshu.MenuManager = ribbon;
            Jieshaorenswsshu.Name = "Jieshaorenswsshu";
            Jieshaorenswsshu.Properties.Appearance.Options.UseTextOptions = true;
            Jieshaorenswsshu.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            Jieshaorenswsshu.Properties.Mask.EditMask = "n0";
            Jieshaorenswsshu.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            Jieshaorenswsshu.Properties.Mask.UseMaskAsDisplayFormat = true;
            Jieshaorenswsshu.Size = new System.Drawing.Size(40, 20);
            Jieshaorenswsshu.TabIndex = 272;
            
            
            
            
            
            Jieshaorensjs.Location = new System.Drawing.Point(456, 387);
            Jieshaorensjs.Name = "Jieshaorensjs";
            Jieshaorensjs.Size = new System.Drawing.Size(94, 14);
            Jieshaorensjs.TabIndex = 271;
            Jieshaorensjs.Text = "介绍人获得赏金:";
            
            
            
            
            
            Jieshaorensjsshu.Location = new System.Drawing.Point(553, 384);
            Jieshaorensjsshu.MenuManager = ribbon;
            Jieshaorensjsshu.Name = "Jieshaorensjsshu";
            Jieshaorensjsshu.Properties.Appearance.Options.UseTextOptions = true;
            Jieshaorensjsshu.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            Jieshaorensjsshu.Properties.Mask.EditMask = "n0";
            Jieshaorensjsshu.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            Jieshaorensjsshu.Properties.Mask.UseMaskAsDisplayFormat = true;
            Jieshaorensjsshu.Size = new System.Drawing.Size(40, 20);
            Jieshaorensjsshu.TabIndex = 270;
            
            
            
            
            
            Bjieshaorensws.Location = new System.Drawing.Point(444, 359);
            Bjieshaorensws.Name = "Bjieshaorensws";
            Bjieshaorensws.Size = new System.Drawing.Size(94, 14);
            Bjieshaorensws.TabIndex = 269;
            Bjieshaorensws.Text = "被介绍人获得声望:";
            
            
            
            
            
            Bjieshaorenswsshu.Location = new System.Drawing.Point(553, 356);
            Bjieshaorenswsshu.MenuManager = ribbon;
            Bjieshaorenswsshu.Name = "Bjieshaorenswsshu";
            Bjieshaorenswsshu.Properties.Appearance.Options.UseTextOptions = true;
            Bjieshaorenswsshu.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            Bjieshaorenswsshu.Properties.Mask.EditMask = "n0";
            Bjieshaorenswsshu.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            Bjieshaorenswsshu.Properties.Mask.UseMaskAsDisplayFormat = true;
            Bjieshaorenswsshu.Size = new System.Drawing.Size(40, 20);
            Bjieshaorenswsshu.TabIndex = 268;
            
            
            
            
            
            Bjieshaorensjs.Location = new System.Drawing.Point(444, 331);
            Bjieshaorensjs.Name = "Bjieshaorensjs";
            Bjieshaorensjs.Size = new System.Drawing.Size(94, 14);
            Bjieshaorensjs.TabIndex = 267;
            Bjieshaorensjs.Text = "被介绍人获得赏金:";
            
            
            
            
            
            Bjieshaorensjsshu.Location = new System.Drawing.Point(553, 328);
            Bjieshaorensjsshu.MenuManager = ribbon;
            Bjieshaorensjsshu.Name = "Bjieshaorensjsshu";
            Bjieshaorensjsshu.Properties.Appearance.Options.UseTextOptions = true;
            Bjieshaorensjsshu.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            Bjieshaorensjsshu.Properties.Mask.EditMask = "n0";
            Bjieshaorensjsshu.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            Bjieshaorensjsshu.Properties.Mask.UseMaskAsDisplayFormat = true;
            Bjieshaorensjsshu.Size = new System.Drawing.Size(40, 20);
            Bjieshaorensjsshu.TabIndex = 266;
            
            
            
            
            
            Bjieshaorendjs.Location = new System.Drawing.Point(468, 303);
            Bjieshaorendjs.Name = "Bjieshaorendjs";
            Bjieshaorendjs.Size = new System.Drawing.Size(94, 14);
            Bjieshaorendjs.TabIndex = 265;
            Bjieshaorendjs.Text = "被介绍人等级:";
            
            
            
            
            
            Bjieshaorendjsshu.Location = new System.Drawing.Point(553, 300);
            Bjieshaorendjsshu.MenuManager = ribbon;
            Bjieshaorendjsshu.Name = "Bjieshaorendjsshu";
            Bjieshaorendjsshu.Properties.Appearance.Options.UseTextOptions = true;
            Bjieshaorendjsshu.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            Bjieshaorendjsshu.Properties.Mask.EditMask = "n0";
            Bjieshaorendjsshu.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            Bjieshaorendjsshu.Properties.Mask.UseMaskAsDisplayFormat = true;
            Bjieshaorendjsshu.Size = new System.Drawing.Size(40, 20);
            Bjieshaorendjsshu.TabIndex = 264;
            
            
            
            
            
            Jieshaorenswe.Location = new System.Drawing.Point(456, 275);
            Jieshaorenswe.Name = "Jieshaorenswe";
            Jieshaorenswe.Size = new System.Drawing.Size(94, 275);
            Jieshaorenswe.TabIndex = 263;
            Jieshaorenswe.Text = "介绍人获得声望:";
            
            
            
            
            
            Jieshaorensweshu.Location = new System.Drawing.Point(553, 272);
            Jieshaorensweshu.MenuManager = ribbon;
            Jieshaorensweshu.Name = "Jieshaorensweshu";
            Jieshaorensweshu.Properties.Appearance.Options.UseTextOptions = true;
            Jieshaorensweshu.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            Jieshaorensweshu.Properties.Mask.EditMask = "n0";
            Jieshaorensweshu.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            Jieshaorensweshu.Properties.Mask.UseMaskAsDisplayFormat = true;
            Jieshaorensweshu.Size = new System.Drawing.Size(40, 20);
            Jieshaorensweshu.TabIndex = 262;
            
            
            
            
            
            Jieshaorensje.Location = new System.Drawing.Point(456, 247);
            Jieshaorensje.Name = "Jieshaorensje";
            Jieshaorensje.Size = new System.Drawing.Size(94, 14);
            Jieshaorensje.TabIndex = 261;
            Jieshaorensje.Text = "介绍人获得赏金:";
            
            
            
            
            
            Jieshaorensjeshu.Location = new System.Drawing.Point(553, 244);
            Jieshaorensjeshu.MenuManager = ribbon;
            Jieshaorensjeshu.Name = "Jieshaorensjeshu";
            Jieshaorensjeshu.Properties.Appearance.Options.UseTextOptions = true;
            Jieshaorensjeshu.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            Jieshaorensjeshu.Properties.Mask.EditMask = "n0";
            Jieshaorensjeshu.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            Jieshaorensjeshu.Properties.Mask.UseMaskAsDisplayFormat = true;
            Jieshaorensjeshu.Size = new System.Drawing.Size(40, 20);
            Jieshaorensjeshu.TabIndex = 260;
            
            
            
            
            
            Bjieshaorenswe.Location = new System.Drawing.Point(444, 219);
            Bjieshaorenswe.Name = "Bjieshaorensw";
            Bjieshaorenswe.Size = new System.Drawing.Size(94, 14);
            Bjieshaorenswe.TabIndex = 259;
            Bjieshaorenswe.Text = "被介绍人获得声望:";
            
            
            
            
            
            Bjieshaorensweshu.Location = new System.Drawing.Point(553, 216);
            Bjieshaorensweshu.MenuManager = ribbon;
            Bjieshaorensweshu.Name = "Bjieshaorensweshu";
            Bjieshaorensweshu.Properties.Appearance.Options.UseTextOptions = true;
            Bjieshaorensweshu.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            Bjieshaorensweshu.Properties.Mask.EditMask = "n0";
            Bjieshaorensweshu.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            Bjieshaorensweshu.Properties.Mask.UseMaskAsDisplayFormat = true;
            Bjieshaorensweshu.Size = new System.Drawing.Size(40, 20);
            Bjieshaorensweshu.TabIndex = 258;
            
            
            
            
            
            Bjieshaorensje.Location = new System.Drawing.Point(444, 194);
            Bjieshaorensje.Name = "Bjieshaorensje";
            Bjieshaorensje.Size = new System.Drawing.Size(94, 14);
            Bjieshaorensje.TabIndex = 257;
            Bjieshaorensje.Text = "被介绍人获得赏金:";
            
            
            
            
            
            Bjieshaorensjeshu.Location = new System.Drawing.Point(553, 191);
            Bjieshaorensjeshu.MenuManager = ribbon;
            Bjieshaorensjeshu.Name = "Bjieshaorensjeshu";
            Bjieshaorensjeshu.Properties.Appearance.Options.UseTextOptions = true;
            Bjieshaorensjeshu.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            Bjieshaorensjeshu.Properties.Mask.EditMask = "n0";
            Bjieshaorensjeshu.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            Bjieshaorensjeshu.Properties.Mask.UseMaskAsDisplayFormat = true;
            Bjieshaorensjeshu.Size = new System.Drawing.Size(40, 20);
            Bjieshaorensjeshu.TabIndex = 256;
            
            
            
            
            
            Bjieshaorendje.Location = new System.Drawing.Point(468, 166);
            Bjieshaorendje.Name = "Bjieshaorendje";
            Bjieshaorendje.Size = new System.Drawing.Size(94, 14);
            Bjieshaorendje.TabIndex = 255;
            Bjieshaorendje.Text = "被介绍人等级:";
            
            
            
            
            
            Bjieshaorendjeshu.Location = new System.Drawing.Point(553, 163);
            Bjieshaorendjeshu.MenuManager = ribbon;
            Bjieshaorendjeshu.Name = "Bjieshaorendjeshu";
            Bjieshaorendjeshu.Properties.Appearance.Options.UseTextOptions = true;
            Bjieshaorendjeshu.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            Bjieshaorendjeshu.Properties.Mask.EditMask = "n0";
            Bjieshaorendjeshu.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            Bjieshaorendjeshu.Properties.Mask.UseMaskAsDisplayFormat = true;
            Bjieshaorendjeshu.Size = new System.Drawing.Size(40, 20);
            Bjieshaorendjeshu.TabIndex = 254;
            
            
            
            
            
            Jieshaorensw.Location = new System.Drawing.Point(456, 138);
            Jieshaorensw.Name = "Jieshaorensw";
            Jieshaorensw.Size = new System.Drawing.Size(94, 14);
            Jieshaorensw.TabIndex = 253;
            Jieshaorensw.Text = "介绍人获得声望:";
            
            
            
            
            
            Jieshaorenswshu.Location = new System.Drawing.Point(553, 135);
            Jieshaorenswshu.MenuManager = ribbon;
            Jieshaorenswshu.Name = "Jieshaorenswshu";
            Jieshaorenswshu.Properties.Appearance.Options.UseTextOptions = true;
            Jieshaorenswshu.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            Jieshaorenswshu.Properties.Mask.EditMask = "n0";
            Jieshaorenswshu.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            Jieshaorenswshu.Properties.Mask.UseMaskAsDisplayFormat = true;
            Jieshaorenswshu.Size = new System.Drawing.Size(40, 20);
            Jieshaorenswshu.TabIndex = 252;
            
            
            
            
            
            Jieshaorensj.Location = new System.Drawing.Point(456, 110);
            Jieshaorensj.Name = "Jieshaorensj";
            Jieshaorensj.Size = new System.Drawing.Size(94, 14);
            Jieshaorensj.TabIndex = 251;
            Jieshaorensj.Text = "介绍人获得赏金:";
            
            
            
            
            
            Jieshaorensjshu.Location = new System.Drawing.Point(553, 107);
            Jieshaorensjshu.MenuManager = ribbon;
            Jieshaorensjshu.Name = "Jieshaorensjshu";
            Jieshaorensjshu.Properties.Appearance.Options.UseTextOptions = true;
            Jieshaorensjshu.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            Jieshaorensjshu.Properties.Mask.EditMask = "n0";
            Jieshaorensjshu.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            Jieshaorensjshu.Properties.Mask.UseMaskAsDisplayFormat = true;
            Jieshaorensjshu.Size = new System.Drawing.Size(40, 20);
            Jieshaorensjshu.TabIndex = 250;
            
            
            
            
            
            Bjieshaorensw.Location = new System.Drawing.Point(444, 82);
            Bjieshaorensw.Name = "Bjieshaorensw";
            Bjieshaorensw.Size = new System.Drawing.Size(94, 14);
            Bjieshaorensw.TabIndex = 249;
            Bjieshaorensw.Text = "被介绍人获得声望:";
            
            
            
            
            
            Bjieshaorenswshu.Location = new System.Drawing.Point(553, 79);
            Bjieshaorenswshu.MenuManager = ribbon;
            Bjieshaorenswshu.Name = "Bjieshaorenswshu";
            Bjieshaorenswshu.Properties.Appearance.Options.UseTextOptions = true;
            Bjieshaorenswshu.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            Bjieshaorenswshu.Properties.Mask.EditMask = "n0";
            Bjieshaorenswshu.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            Bjieshaorenswshu.Properties.Mask.UseMaskAsDisplayFormat = true;
            Bjieshaorenswshu.Size = new System.Drawing.Size(40, 20);
            Bjieshaorenswshu.TabIndex = 248;
            
            
            
            
            
            Bjieshaorensj.Location = new System.Drawing.Point(444, 54);
            Bjieshaorensj.Name = "Bjieshaorensj";
            Bjieshaorensj.Size = new System.Drawing.Size(94, 14);
            Bjieshaorensj.TabIndex = 247;
            Bjieshaorensj.Text = "被介绍人获得赏金:";
            
            
            
            
            
            Bjieshaorensjshu.Location = new System.Drawing.Point(553, 51);
            Bjieshaorensjshu.MenuManager = ribbon;
            Bjieshaorensjshu.Name = "Bjieshaorensjshu";
            Bjieshaorensjshu.Properties.Appearance.Options.UseTextOptions = true;
            Bjieshaorensjshu.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            Bjieshaorensjshu.Properties.Mask.EditMask = "n0";
            Bjieshaorensjshu.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            Bjieshaorensjshu.Properties.Mask.UseMaskAsDisplayFormat = true;
            Bjieshaorensjshu.Size = new System.Drawing.Size(40, 20);
            Bjieshaorensjshu.TabIndex = 246;
            
            
            
            
            
            Bjieshaorendj.Location = new System.Drawing.Point(468, 26);
            Bjieshaorendj.Name = "Bjieshaorendj";
            Bjieshaorendj.Size = new System.Drawing.Size(94, 14);
            Bjieshaorendj.TabIndex = 245;
            Bjieshaorendj.Text = "被介绍人等级:";
            
            
            
            
            
            Bjieshaorendjshu.Location = new System.Drawing.Point(553, 23);
            Bjieshaorendjshu.MenuManager = ribbon;
            Bjieshaorendjshu.Name = "Bjieshaorendjshu";
            Bjieshaorendjshu.Properties.Appearance.Options.UseTextOptions = true;
            Bjieshaorendjshu.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            Bjieshaorendjshu.Properties.Mask.EditMask = "n0";
            Bjieshaorendjshu.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            Bjieshaorendjshu.Properties.Mask.UseMaskAsDisplayFormat = true;
            Bjieshaorendjshu.Size = new System.Drawing.Size(40, 20);
            Bjieshaorendjshu.TabIndex = 244;
            
            
            
            Qshenzi.Location = new System.Drawing.Point(266, 698);
            Qshenzi.Name = "Qshenzi";
            Qshenzi.Size = new System.Drawing.Size(94, 14);
            Qshenzi.TabIndex = 211;
            Qshenzi.Text = "轴卷基础爆率:";
            
            
            
            Qshenshu.Location = new System.Drawing.Point(353, 695);
            Qshenshu.MenuManager = ribbon;
            Qshenshu.Name = "Qshenshu";
            Qshenshu.Properties.Appearance.Options.UseTextOptions = true;
            Qshenshu.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            Qshenshu.Properties.Mask.EditMask = "n0";
            Qshenshu.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            Qshenshu.Properties.Mask.UseMaskAsDisplayFormat = true;
            Qshenshu.Size = new System.Drawing.Size(40, 20);
            Qshenshu.TabIndex = 210;
            
            
            
            Qfengzi.Location = new System.Drawing.Point(266, 670);
            Qfengzi.Name = "Qfengzi";
            Qfengzi.Size = new System.Drawing.Size(94, 14);
            Qfengzi.TabIndex = 209;
            Qfengzi.Text = "宝石基础爆率:";
            
            
            
            Qfengshu.Location = new System.Drawing.Point(353, 667);
            Qfengshu.MenuManager = ribbon;
            Qfengshu.Name = "Qfengshu";
            Qfengshu.Properties.Appearance.Options.UseTextOptions = true;
            Qfengshu.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            Qfengshu.Properties.Mask.EditMask = "n0";
            Qfengshu.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            Qfengshu.Properties.Mask.UseMaskAsDisplayFormat = true;
            Qfengshu.Size = new System.Drawing.Size(40, 20);
            Qfengshu.TabIndex = 208;
            
            
            
            Qleizi.Location = new System.Drawing.Point(266, 642);
            Qleizi.Name = "Qleizi";
            Qleizi.Size = new System.Drawing.Size(94, 14);
            Qleizi.TabIndex = 207;
            Qleizi.Text = "徽章基础爆率:";
            
            
            
            Qleishu.Location = new System.Drawing.Point(353, 639);
            Qleishu.MenuManager = ribbon;
            Qleishu.Name = "Qleishu";
            Qleishu.Properties.Appearance.Options.UseTextOptions = true;
            Qleishu.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            Qleishu.Properties.Mask.EditMask = "n0";
            Qleishu.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            Qleishu.Properties.Mask.UseMaskAsDisplayFormat = true;
            Qleishu.Size = new System.Drawing.Size(40, 20);
            Qleishu.TabIndex = 206;
            
            
            
            Qbingzi.Location = new System.Drawing.Point(266, 614);
            Qbingzi.Name = "Qbingzi";
            Qbingzi.Size = new System.Drawing.Size(94, 14);
            Qbingzi.TabIndex = 205;
            Qbingzi.Text = "盾牌基础爆率:";
            
            
            
            Qbingshu.Location = new System.Drawing.Point(353, 611);
            Qbingshu.MenuManager = ribbon;
            Qbingshu.Name = "Qbingshu";
            Qbingshu.Properties.Appearance.Options.UseTextOptions = true;
            Qbingshu.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            Qbingshu.Properties.Mask.EditMask = "n0";
            Qbingshu.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            Qbingshu.Properties.Mask.UseMaskAsDisplayFormat = true;
            Qbingshu.Size = new System.Drawing.Size(40, 20);
            Qbingshu.TabIndex = 204;
            
            
            
            Qhuozi.Location = new System.Drawing.Point(266, 586);
            Qhuozi.Name = "Qhuozi";
            Qhuozi.Size = new System.Drawing.Size(94, 14);
            Qhuozi.TabIndex = 203;
            Qhuozi.Text = "书籍基础爆率:";
            
            
            
            Qhuoshu.Location = new System.Drawing.Point(353, 583);
            Qhuoshu.MenuManager = ribbon;
            Qhuoshu.Name = "Qhuoshu";
            Qhuoshu.Properties.Appearance.Options.UseTextOptions = true;
            Qhuoshu.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            Qhuoshu.Properties.Mask.EditMask = "n0";
            Qhuoshu.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            Qhuoshu.Properties.Mask.UseMaskAsDisplayFormat = true;
            Qhuoshu.Size = new System.Drawing.Size(40, 20);
            Qhuoshu.TabIndex = 202;
            
            
            
            Ghuanzi.Location = new System.Drawing.Point(266, 558);
            Ghuanzi.Name = "Ghuanzi";
            Ghuanzi.Size = new System.Drawing.Size(94, 14);
            Ghuanzi.TabIndex = 201;
            Ghuanzi.Text = "矿石基础爆率:";
            
            
            
            Ghuanshu.Location = new System.Drawing.Point(353, 555);
            Ghuanshu.MenuManager = ribbon;
            Ghuanshu.Name = "Ghuanshu";
            Ghuanshu.Properties.Appearance.Options.UseTextOptions = true;
            Ghuanshu.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            Ghuanshu.Properties.Mask.EditMask = "n0";
            Ghuanshu.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            Ghuanshu.Properties.Mask.UseMaskAsDisplayFormat = true;
            Ghuanshu.Size = new System.Drawing.Size(40, 20);
            Ghuanshu.TabIndex = 200;
            
            
            
            Ganzi.Location = new System.Drawing.Point(266, 530);
            Ganzi.Name = "Ganzi";
            Ganzi.Size = new System.Drawing.Size(94, 14);
            Ganzi.TabIndex = 199;
            Ganzi.Text = "靴子基础爆率:";
            
            
            
            Ganshu.Location = new System.Drawing.Point(353, 527);
            Ganshu.MenuManager = ribbon;
            Ganshu.Name = "Ganshu";
            Ganshu.Properties.Appearance.Options.UseTextOptions = true;
            Ganshu.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            Ganshu.Properties.Mask.EditMask = "n0";
            Ganshu.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            Ganshu.Properties.Mask.UseMaskAsDisplayFormat = true;
            Ganshu.Size = new System.Drawing.Size(40, 20);
            Ganshu.TabIndex = 198;
            
            
            
            Gshengzi.Location = new System.Drawing.Point(266, 502);
            Gshengzi.Name = "Gshengzi";
            Gshengzi.Size = new System.Drawing.Size(94, 14);
            Gshengzi.TabIndex = 197;
            Gshengzi.Text = "戒指基础爆率:";
            
            
            
            Gshengshu.Location = new System.Drawing.Point(353, 499);
            Gshengshu.MenuManager = ribbon;
            Gshengshu.Name = "Gshengshu";
            Gshengshu.Properties.Appearance.Options.UseTextOptions = true;
            Gshengshu.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            Gshengshu.Properties.Mask.EditMask = "n0";
            Gshengshu.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            Gshengshu.Properties.Mask.UseMaskAsDisplayFormat = true;
            Gshengshu.Size = new System.Drawing.Size(40, 20);
            Gshengshu.TabIndex = 196;
            
            
            
            Gfengzi.Location = new System.Drawing.Point(266, 474);
            Gfengzi.Name = "Gfengzi";
            Gfengzi.Size = new System.Drawing.Size(94, 14);
            Gfengzi.TabIndex = 196;
            Gfengzi.Text = "手镯基础爆率:";
            
            
            
            Gfengshu.Location = new System.Drawing.Point(353, 471);
            Gfengshu.MenuManager = ribbon;
            Gfengshu.Name = "Gfengshu";
            Gfengshu.Properties.Appearance.Options.UseTextOptions = true;
            Gfengshu.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            Gfengshu.Properties.Mask.EditMask = "n0";
            Gfengshu.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            Gfengshu.Properties.Mask.UseMaskAsDisplayFormat = true;
            Gfengshu.Size = new System.Drawing.Size(40, 20);
            Gfengshu.TabIndex = 195;
            
            
            
            Gleizi.Location = new System.Drawing.Point(266, 446);
            Gleizi.Name = "Gleizi";
            Gleizi.Size = new System.Drawing.Size(94, 14);
            Gleizi.TabIndex = 194;
            Gleizi.Text = "项链基础爆率:";
            
            
            
            Gleishu.Location = new System.Drawing.Point(353, 443);
            Gleishu.MenuManager = ribbon;
            Gleishu.Name = "Gleishu";
            Gleishu.Properties.Appearance.Options.UseTextOptions = true;
            Gleishu.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            Gleishu.Properties.Mask.EditMask = "n0";
            Gleishu.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            Gleishu.Properties.Mask.UseMaskAsDisplayFormat = true;
            Gleishu.Size = new System.Drawing.Size(40, 20);
            Gleishu.TabIndex = 193;
            
            
            
            Gbingzi.Location = new System.Drawing.Point(266, 418);
            Gbingzi.Name = "Gbingzi";
            Gbingzi.Size = new System.Drawing.Size(94, 14);
            Gbingzi.TabIndex = 192;
            Gbingzi.Text = "头盔基础爆率:";
            
            
            
            Gbingshu.Location = new System.Drawing.Point(353, 415);
            Gbingshu.MenuManager = ribbon;
            Gbingshu.Name = "Gbingshu";
            Gbingshu.Properties.Appearance.Options.UseTextOptions = true;
            Gbingshu.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            Gbingshu.Properties.Mask.EditMask = "n0";
            Gbingshu.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            Gbingshu.Properties.Mask.UseMaskAsDisplayFormat = true;
            Gbingshu.Size = new System.Drawing.Size(40, 20);
            Gbingshu.TabIndex = 191;
            
            
            
            Ghuozi.Location = new System.Drawing.Point(266, 390);
            Ghuozi.Name = "Ghuozi";
            Ghuozi.Size = new System.Drawing.Size(94, 14);
            Ghuozi.TabIndex = 190;
            Ghuozi.Text = "衣服基础爆率:";
            
            
            
            Ghuoshu.Location = new System.Drawing.Point(353, 387);
            Ghuoshu.MenuManager = ribbon;
            Ghuoshu.Name = "Ghuoshu";
            Ghuoshu.Properties.Appearance.Options.UseTextOptions = true;
            Ghuoshu.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            Ghuoshu.Properties.Mask.EditMask = "n0";
            Ghuoshu.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            Ghuoshu.Properties.Mask.UseMaskAsDisplayFormat = true;
            Ghuoshu.Size = new System.Drawing.Size(40, 20);
            Ghuoshu.TabIndex = 189;
            
            
            
            Xxbszi.Location = new System.Drawing.Point(266, 362);
            Xxbszi.Name = "Xxbszi";
            Xxbszi.Size = new System.Drawing.Size(94, 14);
            Xxbszi.TabIndex = 188;
            Xxbszi.Text = "武器基础爆率:";
            
            
            
            Xxbsshu.Location = new System.Drawing.Point(353, 359);
            Xxbsshu.MenuManager = ribbon;
            Xxbsshu.Name = "Xxbsshu";
            Xxbsshu.Properties.Appearance.Options.UseTextOptions = true;
            Xxbsshu.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            Xxbsshu.Properties.Mask.EditMask = "n0";
            Xxbsshu.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            Xxbsshu.Properties.Mask.UseMaskAsDisplayFormat = true;
            Xxbsshu.Size = new System.Drawing.Size(40, 20);
            Xxbsshu.TabIndex = 187;
            
            
            
            Jybszi.Location = new System.Drawing.Point(266, 334);
            Jybszi.Name = "Jybszi";
            Jybszi.Size = new System.Drawing.Size(94, 14);
            Jybszi.TabIndex = 186;
            Jybszi.Text = "黄金回收倍率:";
            
            
            
            Jybsshu.Location = new System.Drawing.Point(353, 331);
            Jybsshu.MenuManager = ribbon;
            Jybsshu.Name = "Jybsshu";
            Jybsshu.Properties.Appearance.Options.UseTextOptions = true;
            Jybsshu.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            Jybsshu.Properties.Mask.EditMask = "n0";
            Jybsshu.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            Jybsshu.Properties.Mask.UseMaskAsDisplayFormat = true;
            Jybsshu.Size = new System.Drawing.Size(40, 20);
            Jybsshu.TabIndex = 185;
            
            
            
            Mybszi.Location = new System.Drawing.Point(266, 306);
            Mybszi.Name = "Mybszi";
            Mybszi.Size = new System.Drawing.Size(94, 14);
            Mybszi.TabIndex = 184;
            Mybszi.Text = "白银回收倍率:";
            
            
            
            Mybsshu.Location = new System.Drawing.Point(353, 303);
            Mybsshu.MenuManager = ribbon;
            Mybsshu.Name = "Mybsshu";
            Mybsshu.Properties.Appearance.Options.UseTextOptions = true;
            Mybsshu.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            Mybsshu.Properties.Mask.EditMask = "n0";
            Mybsshu.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            Mybsshu.Properties.Mask.UseMaskAsDisplayFormat = true;
            Mybsshu.Size = new System.Drawing.Size(40, 20);
            Mybsshu.TabIndex = 183;
            
            
            
            Fybszi.Location = new System.Drawing.Point(266, 278);
            Fybszi.Name = "Fybszi";
            Fybszi.Size = new System.Drawing.Size(94, 14);
            Fybszi.TabIndex = 182;
            Fybszi.Text = "青铜回收倍率:";
            
            
            
            Fybsshu.Location = new System.Drawing.Point(353, 275);
            Fybsshu.MenuManager = ribbon;
            Fybsshu.Name = "Fybsshu";
            Fybsshu.Properties.Appearance.Options.UseTextOptions = true;
            Fybsshu.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            Fybsshu.Properties.Mask.EditMask = "n0";
            Fybsshu.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            Fybsshu.Properties.Mask.UseMaskAsDisplayFormat = true;
            Fybsshu.Size = new System.Drawing.Size(40, 20);
            Fybsshu.TabIndex = 181;
            
            
            
            Sdbszi.Location = new System.Drawing.Point(266, 250);
            Sdbszi.Name = "Sdbszi";
            Sdbszi.Size = new System.Drawing.Size(94, 14);
            Sdbszi.TabIndex = 180;
            Sdbszi.Text = "黄金会员金币:";
            
            
            
            Sdbsshu.Location = new System.Drawing.Point(353, 247);
            Sdbsshu.MenuManager = ribbon;
            Sdbsshu.Name = "Sdbsshu";
            Sdbsshu.Properties.Appearance.Options.UseTextOptions = true;
            Sdbsshu.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            Sdbsshu.Properties.Mask.EditMask = "n0";
            Sdbsshu.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            Sdbsshu.Properties.Mask.UseMaskAsDisplayFormat = true;
            Sdbsshu.Size = new System.Drawing.Size(40, 20);
            Sdbsshu.TabIndex = 179;
            
            
            
            Mfbszi.Location = new System.Drawing.Point(266, 222);
            Mfbszi.Name = "Mfbszi";
            Mfbszi.Size = new System.Drawing.Size(94, 14);
            Mfbszi.TabIndex = 178;
            Mfbszi.Text = "黄金会员爆率:";
            
            
            
            Mfbsshu.Location = new System.Drawing.Point(353, 219);
            Mfbsshu.MenuManager = ribbon;
            Mfbsshu.Name = "Mfbsshu";
            Mfbsshu.Properties.Appearance.Options.UseTextOptions = true;
            Mfbsshu.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            Mfbsshu.Properties.Mask.EditMask = "n0";
            Mfbsshu.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            Mfbsshu.Properties.Mask.UseMaskAsDisplayFormat = true;
            Mfbsshu.Size = new System.Drawing.Size(40, 20);
            Mfbsshu.TabIndex = 177;
            
            
            
            Smjlbszi.Location = new System.Drawing.Point(266, 194);
            Smjlbszi.Name = "Smjlbszi";
            Smjlbszi.Size = new System.Drawing.Size(94, 14);
            Smjlbszi.TabIndex = 176;
            Smjlbszi.Text = "黄金会员经验:";
            
            
            
            Smjlbsshu.Location = new System.Drawing.Point(353, 191);
            Smjlbsshu.MenuManager = ribbon;
            Smjlbsshu.Name = "Smjlbsshu";
            Smjlbsshu.Properties.Appearance.Options.UseTextOptions = true;
            Smjlbsshu.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            Smjlbsshu.Properties.Mask.EditMask = "n0";
            Smjlbsshu.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            Smjlbsshu.Properties.Mask.UseMaskAsDisplayFormat = true;
            Smjlbsshu.Size = new System.Drawing.Size(40, 20);
            Smjlbsshu.TabIndex = 175;
            
            
            
            Lhjlbszi.Location = new System.Drawing.Point(266, 166);
            Lhjlbszi.Name = "Lhjlbszi";
            Lhjlbszi.Size = new System.Drawing.Size(94, 14);
            Lhjlbszi.TabIndex = 174;
            Lhjlbszi.Text = "白银会员金币:";
            
            
            
            Lhjlbsshu.Location = new System.Drawing.Point(353, 163);
            Lhjlbsshu.MenuManager = ribbon;
            Lhjlbsshu.Name = "Lhjlbsshu";
            Lhjlbsshu.Properties.Appearance.Options.UseTextOptions = true;
            Lhjlbsshu.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            Lhjlbsshu.Properties.Mask.EditMask = "n0";
            Lhjlbsshu.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            Lhjlbsshu.Properties.Mask.UseMaskAsDisplayFormat = true;
            Lhjlbsshu.Size = new System.Drawing.Size(40, 20);
            Lhjlbsshu.TabIndex = 173;
            
            
            
            Zrjlbszi.Location = new System.Drawing.Point(266, 138);
            Zrjlbszi.Name = "Zrjlbszi";
            Zrjlbszi.Size = new System.Drawing.Size(94, 14);
            Zrjlbszi.TabIndex = 172;
            Zrjlbszi.Text = "白银会员爆率:";
            
            
            
            Zrjlbsshu.Location = new System.Drawing.Point(353, 135);
            Zrjlbsshu.MenuManager = ribbon;
            Zrjlbsshu.Name = "Zrjlbsshu";
            Zrjlbsshu.Properties.Appearance.Options.UseTextOptions = true;
            Zrjlbsshu.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            Zrjlbsshu.Properties.Mask.EditMask = "n0";
            Zrjlbsshu.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            Zrjlbsshu.Properties.Mask.UseMaskAsDisplayFormat = true;
            Zrjlbsshu.Size = new System.Drawing.Size(40, 20);
            Zrjlbsshu.TabIndex = 171;
            
            
            
            Gjjlbszi.Location = new System.Drawing.Point(266, 110);
            Gjjlbszi.Name = "Gjjlbszi";
            Gjjlbszi.Size = new System.Drawing.Size(94, 14);
            Gjjlbszi.TabIndex = 170;
            Gjjlbszi.Text = "白银会员经验:";
            
            
            
            Gjjlbsshu.Location = new System.Drawing.Point(353, 107);
            Gjjlbsshu.MenuManager = ribbon;
            Gjjlbsshu.Name = "Gjjlbsshu";
            Gjjlbsshu.Properties.Appearance.Options.UseTextOptions = true;
            Gjjlbsshu.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            Gjjlbsshu.Properties.Mask.EditMask = "n0";
            Gjjlbsshu.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            Gjjlbsshu.Properties.Mask.UseMaskAsDisplayFormat = true;
            Gjjlbsshu.Size = new System.Drawing.Size(40, 20);
            Gjjlbsshu.TabIndex = 169;
            
            
            
            Lhbszi.Location = new System.Drawing.Point(266, 82);
            Lhbszi.Name = "Lhbszi";
            Lhbszi.Size = new System.Drawing.Size(94, 14);
            Lhbszi.TabIndex = 168;
            Lhbszi.Text = "青铜会员金币:";
            
            
            
            Lhbsshu.Location = new System.Drawing.Point(353, 79);
            Lhbsshu.MenuManager = ribbon;
            Lhbsshu.Name = "Lhbsshu";
            Lhbsshu.Properties.Appearance.Options.UseTextOptions = true;
            Lhbsshu.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            Lhbsshu.Properties.Mask.EditMask = "n0";
            Lhbsshu.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            Lhbsshu.Properties.Mask.UseMaskAsDisplayFormat = true;
            Lhbsshu.Size = new System.Drawing.Size(40, 20);
            Lhbsshu.TabIndex = 167;
            
            
            
            Zrbszi.Location = new System.Drawing.Point(266, 54);
            Zrbszi.Name = "Zrbszi";
            Zrbszi.Size = new System.Drawing.Size(94, 14);
            Zrbszi.TabIndex = 166;
            Zrbszi.Text = "青铜会员爆率:";
            
            
            
            Zrbsshu.Location = new System.Drawing.Point(353, 51);
            Zrbsshu.MenuManager = ribbon;
            Zrbsshu.Name = "Zrbsshu";
            Zrbsshu.Properties.Appearance.Options.UseTextOptions = true;
            Zrbsshu.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            Zrbsshu.Properties.Mask.EditMask = "n0";
            Zrbsshu.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            Zrbsshu.Properties.Mask.UseMaskAsDisplayFormat = true;
            Zrbsshu.Size = new System.Drawing.Size(40, 20);
            Zrbsshu.TabIndex = 165;
            
            
            
            Gjbszi.Location = new System.Drawing.Point(266, 26);
            Gjbszi.Name = "Gjbszi";
            Gjbszi.Size = new System.Drawing.Size(94, 14);
            Gjbszi.TabIndex = 164;
            Gjbszi.Text = "青铜会员经验:";
            
            
            
            Gjbsshu.Location = new System.Drawing.Point(353, 23);
            Gjbsshu.MenuManager = ribbon;
            Gjbsshu.Name = "Gjbsshu";
            Gjbsshu.Properties.Appearance.Options.UseTextOptions = true;
            Gjbsshu.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            Gjbsshu.Properties.Mask.EditMask = "n0";
            Gjbsshu.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            Gjbsshu.Properties.Mask.UseMaskAsDisplayFormat = true;
            Gjbsshu.Size = new System.Drawing.Size(40, 20);
            Gjbsshu.TabIndex = 163;
            
            
            
            EwaijinbiOK.Location = new System.Drawing.Point(185, 80);
            EwaijinbiOK.MenuManager = ribbon;
            EwaijinbiOK.Name = "EwaijinbiOK";
            EwaijinbiOK.Properties.Caption = "";
            EwaijinbiOK.Size = new System.Drawing.Size(30, 19);
            EwaijinbiOK.TabIndex = 237;
            
            
            
            Ewaijinbi.Location = new System.Drawing.Point(215, 79);
            Ewaijinbi.MenuManager = ribbon;
            Ewaijinbi.Name = "Ewaijinbi";
            Ewaijinbi.Properties.Appearance.Options.UseTextOptions = true;
            Ewaijinbi.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            Ewaijinbi.Properties.Mask.EditMask = "n0";
            Ewaijinbi.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            Ewaijinbi.Properties.Mask.UseMaskAsDisplayFormat = true;
            Ewaijinbi.Size = new System.Drawing.Size(40, 20);
            Ewaijinbi.TabIndex = 236;
            
            
            
            EwaibaolvOK.Location = new System.Drawing.Point(185, 52);
            EwaibaolvOK.MenuManager = ribbon;
            EwaibaolvOK.Name = "EwaibaolvOK";
            EwaibaolvOK.Properties.Caption = "";
            EwaibaolvOK.Size = new System.Drawing.Size(30, 19);
            EwaibaolvOK.TabIndex = 235;
            
            
            
            Ewaibaolv.Location = new System.Drawing.Point(215, 51);
            Ewaibaolv.MenuManager = ribbon;
            Ewaibaolv.Name = "Ewaibaolv";
            Ewaibaolv.Properties.Appearance.Options.UseTextOptions = true;
            Ewaibaolv.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            Ewaibaolv.Properties.Mask.EditMask = "n0";
            Ewaibaolv.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            Ewaibaolv.Properties.Mask.UseMaskAsDisplayFormat = true;
            Ewaibaolv.Size = new System.Drawing.Size(40, 20);
            Ewaibaolv.TabIndex = 234;
            
            
            
            EwaijingyanOK.Location = new System.Drawing.Point(185, 24);
            EwaijingyanOK.MenuManager = ribbon;
            EwaijingyanOK.Name = "EwaijingyanOK";
            EwaijingyanOK.Properties.Caption = "";
            EwaijingyanOK.Size = new System.Drawing.Size(30, 19);
            EwaijingyanOK.TabIndex = 233;
            
            
            
            Ewaijingyan.Location = new System.Drawing.Point(215, 23);
            Ewaijingyan.MenuManager = ribbon;
            Ewaijingyan.Name = "Ewaijingyan";
            Ewaijingyan.Properties.Appearance.Options.UseTextOptions = true;
            Ewaijingyan.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            Ewaijingyan.Properties.Mask.EditMask = "n0";
            Ewaijingyan.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            Ewaijingyan.Properties.Mask.UseMaskAsDisplayFormat = true;
            Ewaijingyan.Size = new System.Drawing.Size(40, 20);
            Ewaijingyan.TabIndex = 232;
            
            
            
            Ghquan2029.Location = new System.Drawing.Point(22, 446);
            Ghquan2029.Name = "Ghquan2029";
            Ghquan2029.Size = new System.Drawing.Size(94, 14);
            Ghquan2029.TabIndex = 146;
            Ghquan2029.Text = "公会经验泉20-29:";
            
            
            
            Ghquanc2029.Location = new System.Drawing.Point(126, 443);
            Ghquanc2029.MenuManager = ribbon;
            Ghquanc2029.Name = "Ghquanc2029";
            Ghquanc2029.Properties.Appearance.Options.UseTextOptions = true;
            Ghquanc2029.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            Ghquanc2029.Properties.Mask.EditMask = "n0";
            Ghquanc2029.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            Ghquanc2029.Properties.Mask.UseMaskAsDisplayFormat = true;
            Ghquanc2029.Size = new System.Drawing.Size(50, 20);
            Ghquanc2029.TabIndex = 145;
            
            
            
            Ghquan1019.Location = new System.Drawing.Point(22, 418);
            Ghquan1019.Name = "Ghquan1019";
            Ghquan1019.Size = new System.Drawing.Size(94, 14);
            Ghquan1019.TabIndex = 144;
            Ghquan1019.Text = "公会经验泉10-19:";
            
            
            
            Ghquanc1019.Location = new System.Drawing.Point(126, 415);
            Ghquanc1019.MenuManager = ribbon;
            Ghquanc1019.Name = "Ghquanc1019";
            Ghquanc1019.Properties.Appearance.Options.UseTextOptions = true;
            Ghquanc1019.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            Ghquanc1019.Properties.Mask.EditMask = "n0";
            Ghquanc1019.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            Ghquanc1019.Properties.Mask.UseMaskAsDisplayFormat = true;
            Ghquanc1019.Size = new System.Drawing.Size(50, 20);
            Ghquanc1019.TabIndex = 143;
            
            
            
            Ghquan0109.Location = new System.Drawing.Point(22, 390);
            Ghquan0109.Name = "Ghquan0109";
            Ghquan0109.Size = new System.Drawing.Size(94, 14);
            Ghquan0109.TabIndex = 142;
            Ghquan0109.Text = "公会经验泉01-09:";
            
            
            
            Ghquanc0109.Location = new System.Drawing.Point(126, 387);
            Ghquanc0109.MenuManager = ribbon;
            Ghquanc0109.Name = "Ghquanc0109";
            Ghquanc0109.Properties.Appearance.Options.UseTextOptions = true;
            Ghquanc0109.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            Ghquanc0109.Properties.Mask.EditMask = "n0";
            Ghquanc0109.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            Ghquanc0109.Properties.Mask.UseMaskAsDisplayFormat = true;
            Ghquanc0109.Size = new System.Drawing.Size(50, 20);
            Ghquanc0109.TabIndex = 141;
            
            
            
            Ghquan9099.Location = new System.Drawing.Point(22, 362);
            Ghquan9099.Name = "Ghquan9099";
            Ghquan9099.Size = new System.Drawing.Size(94, 14);
            Ghquan9099.TabIndex = 140;
            Ghquan9099.Text = "公会经验泉90-99:";
            
            
            
            Ghquanc9099.Location = new System.Drawing.Point(126, 359);
            Ghquanc9099.MenuManager = ribbon;
            Ghquanc9099.Name = "Ghquanc9099";
            Ghquanc9099.Properties.Appearance.Options.UseTextOptions = true;
            Ghquanc9099.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            Ghquanc9099.Properties.Mask.EditMask = "n0";
            Ghquanc9099.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            Ghquanc9099.Properties.Mask.UseMaskAsDisplayFormat = true;
            Ghquanc9099.Size = new System.Drawing.Size(50, 20);
            Ghquanc9099.TabIndex = 139;
            
            
            
            Ghquan8089.Location = new System.Drawing.Point(22, 334);
            Ghquan8089.Name = "Ghquan8089";
            Ghquan8089.Size = new System.Drawing.Size(94, 14);
            Ghquan8089.TabIndex = 138;
            Ghquan8089.Text = "公会经验泉80-89:";
            
            
            
            Ghquanc8089.Location = new System.Drawing.Point(126, 331);
            Ghquanc8089.MenuManager = ribbon;
            Ghquanc8089.Name = "Ghquanc8089";
            Ghquanc8089.Properties.Appearance.Options.UseTextOptions = true;
            Ghquanc8089.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            Ghquanc8089.Properties.Mask.EditMask = "n0";
            Ghquanc8089.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            Ghquanc8089.Properties.Mask.UseMaskAsDisplayFormat = true;
            Ghquanc8089.Size = new System.Drawing.Size(50, 20);
            Ghquanc8089.TabIndex = 137;
            
            
            
            Ghquan7079.Location = new System.Drawing.Point(22, 306);
            Ghquan7079.Name = "Ghquan7079";
            Ghquan7079.Size = new System.Drawing.Size(94, 14);
            Ghquan7079.TabIndex = 136;
            Ghquan7079.Text = "公会经验泉70-79:";
            
            
            
            Ghquanc7079.Location = new System.Drawing.Point(126, 303);
            Ghquanc7079.MenuManager = ribbon;
            Ghquanc7079.Name = "Ghquanc7079";
            Ghquanc7079.Properties.Appearance.Options.UseTextOptions = true;
            Ghquanc7079.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            Ghquanc7079.Properties.Mask.EditMask = "n0";
            Ghquanc7079.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            Ghquanc7079.Properties.Mask.UseMaskAsDisplayFormat = true;
            Ghquanc7079.Size = new System.Drawing.Size(50, 20);
            Ghquanc7079.TabIndex = 135;
            
            
            
            Ghquan6069.Location = new System.Drawing.Point(22, 278);
            Ghquan6069.Name = "Ghquan6069";
            Ghquan6069.Size = new System.Drawing.Size(94, 14);
            Ghquan6069.TabIndex = 134;
            Ghquan6069.Text = "公会经验泉60-69:";
            
            
            
            Ghquanc6069.Location = new System.Drawing.Point(126, 275);
            Ghquanc6069.MenuManager = ribbon;
            Ghquanc6069.Name = "Ghquanc6069";
            Ghquanc6069.Properties.Appearance.Options.UseTextOptions = true;
            Ghquanc6069.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            Ghquanc6069.Properties.Mask.EditMask = "n0";
            Ghquanc6069.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            Ghquanc6069.Properties.Mask.UseMaskAsDisplayFormat = true;
            Ghquanc6069.Size = new System.Drawing.Size(50, 20);
            Ghquanc6069.TabIndex = 133;
            
            
            
            Ghquan5059.Location = new System.Drawing.Point(22, 250);
            Ghquan5059.Name = "Ghquan5059";
            Ghquan5059.Size = new System.Drawing.Size(94, 14);
            Ghquan5059.TabIndex = 132;
            Ghquan5059.Text = "公会经验泉50-59:";
            
            
            
            Ghquanc5059.Location = new System.Drawing.Point(126, 247);
            Ghquanc5059.MenuManager = ribbon;
            Ghquanc5059.Name = "Ghquanc5059";
            Ghquanc5059.Properties.Appearance.Options.UseTextOptions = true;
            Ghquanc5059.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            Ghquanc5059.Properties.Mask.EditMask = "n0";
            Ghquanc5059.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            Ghquanc5059.Properties.Mask.UseMaskAsDisplayFormat = true;
            Ghquanc5059.Size = new System.Drawing.Size(50, 20);
            Ghquanc5059.TabIndex = 131;
            
            
            
            Ghquan4049.Location = new System.Drawing.Point(22, 222);
            Ghquan4049.Name = "Ghquan4049";
            Ghquan4049.Size = new System.Drawing.Size(94, 14);
            Ghquan4049.TabIndex = 130;
            Ghquan4049.Text = "公会经验泉40-49:";
            
            
            
            Ghquanc4049.Location = new System.Drawing.Point(126, 219);
            Ghquanc4049.MenuManager = ribbon;
            Ghquanc4049.Name = "Ghquanc4049";
            Ghquanc4049.Properties.Appearance.Options.UseTextOptions = true;
            Ghquanc4049.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            Ghquanc4049.Properties.Mask.EditMask = "n0";
            Ghquanc4049.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            Ghquanc4049.Properties.Mask.UseMaskAsDisplayFormat = true;
            Ghquanc4049.Size = new System.Drawing.Size(50, 20);
            Ghquanc4049.TabIndex = 129;
            
            
            
            Ghquan3039.Location = new System.Drawing.Point(22, 194);
            Ghquan3039.Name = "Ghquan3039";
            Ghquan3039.Size = new System.Drawing.Size(94, 14);
            Ghquan3039.TabIndex = 128;
            Ghquan3039.Text = "公会经验泉30-39:";
            
            
            
            Ghquanc3039.Location = new System.Drawing.Point(126, 191);
            Ghquanc3039.MenuManager = ribbon;
            Ghquanc3039.Name = "Ghquanc3039";
            Ghquanc3039.Properties.Appearance.Options.UseTextOptions = true;
            Ghquanc3039.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            Ghquanc3039.Properties.Mask.EditMask = "n0";
            Ghquanc3039.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            Ghquanc3039.Properties.Mask.UseMaskAsDisplayFormat = true;
            Ghquanc3039.Size = new System.Drawing.Size(50, 20);
            Ghquanc3039.TabIndex = 127;
            
            
            
            Jingliancglv.Location = new System.Drawing.Point(28, 166);
            Jingliancglv.Name = "Jingliancglv";
            Jingliancglv.Size = new System.Drawing.Size(88, 14);
            Jingliancglv.TabIndex = 119;
            Jingliancglv.Text = "武器精炼成功率:";
            
            
            
            Jingliancglvc.Location = new System.Drawing.Point(126, 163);
            Jingliancglvc.MenuManager = ribbon;
            Jingliancglvc.Name = "Jingliancglvc";
            Jingliancglvc.Properties.Appearance.Options.UseTextOptions = true;
            Jingliancglvc.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            Jingliancglvc.Properties.Mask.EditMask = "n0";
            Jingliancglvc.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            Jingliancglvc.Properties.Mask.UseMaskAsDisplayFormat = true;
            Jingliancglvc.Size = new System.Drawing.Size(50, 20);
            Jingliancglvc.TabIndex = 118;
            
            
            
            CompanionRateEdit.Location = new System.Drawing.Point(126, 135);
            CompanionRateEdit.MenuManager = ribbon;
            CompanionRateEdit.Name = "CompanionRateEdit";
            CompanionRateEdit.Properties.Appearance.Options.UseTextOptions = true;
            CompanionRateEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            CompanionRateEdit.Properties.Mask.EditMask = "n0";
            CompanionRateEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            CompanionRateEdit.Properties.Mask.UseMaskAsDisplayFormat = true;
            CompanionRateEdit.Size = new System.Drawing.Size(50, 20);
            CompanionRateEdit.TabIndex = 89;
            
            
            
            labelControl68.Location = new System.Drawing.Point(40, 138);
            labelControl68.Name = "labelControl68";
            labelControl68.Size = new System.Drawing.Size(76, 14);
            labelControl68.TabIndex = 88;
            labelControl68.Text = "宠物经验加成:";
            
            
            
            SkillRateEdit.Location = new System.Drawing.Point(126, 107);
            SkillRateEdit.MenuManager = ribbon;
            SkillRateEdit.Name = "SkillRateEdit";
            SkillRateEdit.Properties.Appearance.Options.UseTextOptions = true;
            SkillRateEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            SkillRateEdit.Properties.Mask.EditMask = "n0";
            SkillRateEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            SkillRateEdit.Properties.Mask.UseMaskAsDisplayFormat = true;
            SkillRateEdit.Size = new System.Drawing.Size(50, 20);
            SkillRateEdit.TabIndex = 87;
            
            
            
            labelControl58.Location = new System.Drawing.Point(52, 110);
            labelControl58.Name = "labelControl58";
            labelControl58.Size = new System.Drawing.Size(64, 14);
            labelControl58.TabIndex = 86;
            labelControl58.Text = "技能值加成:";
            
            
            
            GoldRateEdit.Location = new System.Drawing.Point(126, 79);
            GoldRateEdit.MenuManager = ribbon;
            GoldRateEdit.Name = "GoldRateEdit";
            GoldRateEdit.Properties.Appearance.Options.UseTextOptions = true;
            GoldRateEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            GoldRateEdit.Properties.Mask.EditMask = "n0";
            GoldRateEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            GoldRateEdit.Properties.Mask.UseMaskAsDisplayFormat = true;
            GoldRateEdit.Size = new System.Drawing.Size(50, 20);
            GoldRateEdit.TabIndex = 85;
            
            
            
            labelControl57.Location = new System.Drawing.Point(64, 82);
            labelControl57.Name = "labelControl57";
            labelControl57.Size = new System.Drawing.Size(52, 14);
            labelControl57.TabIndex = 84;
            labelControl57.Text = "金币加成:";
            
            
            
            DropRateEdit.Location = new System.Drawing.Point(126, 51);
            DropRateEdit.MenuManager = ribbon;
            DropRateEdit.Name = "DropRateEdit";
            DropRateEdit.Properties.Appearance.Options.UseTextOptions = true;
            DropRateEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            DropRateEdit.Properties.Mask.EditMask = "n0";
            DropRateEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            DropRateEdit.Properties.Mask.UseMaskAsDisplayFormat = true;
            DropRateEdit.Size = new System.Drawing.Size(50, 20);
            DropRateEdit.TabIndex = 83;
            
            
            
            labelControl56.Location = new System.Drawing.Point(64, 54);
            labelControl56.Name = "labelControl56";
            labelControl56.Size = new System.Drawing.Size(52, 14);
            labelControl56.TabIndex = 82;
            labelControl56.Text = "爆率加成:";
            
            
            
            ExperienceRateEdit.Location = new System.Drawing.Point(126, 23);
            ExperienceRateEdit.MenuManager = ribbon;
            ExperienceRateEdit.Name = "ExperienceRateEdit";
            ExperienceRateEdit.Properties.Appearance.Options.UseTextOptions = true;
            ExperienceRateEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            ExperienceRateEdit.Properties.Mask.EditMask = "n0";
            ExperienceRateEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            ExperienceRateEdit.Properties.Mask.UseMaskAsDisplayFormat = true;
            ExperienceRateEdit.Size = new System.Drawing.Size(50, 20);
            ExperienceRateEdit.TabIndex = 81;
            
            
            
            labelControl55.Location = new System.Drawing.Point(64, 26);
            labelControl55.Name = "labelControl55";
            labelControl55.Size = new System.Drawing.Size(52, 14);
            labelControl55.TabIndex = 80;
            labelControl55.Text = "经验加成:";
            
            
            
            OpenDialog.FileName = "Zircon.exe";
            OpenDialog.Filter = "Zircon Client|Zircon.exe|All Files|*.*";
            
            
            
            FolderDialog.SelectedPath = ".\\";
            
            
            
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(904, 611);
            Controls.Add(xtraTabControl1);
            Controls.Add(ribbon);
            Name = "ConfigView";
            Ribbon = ribbon;
            Text = "Config View";
            ((System.ComponentModel.ISupportInitialize)(ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(xtraTabControl1)).EndInit();
            xtraTabControl1.ResumeLayout(false);
            xtraTabPage1.ResumeLayout(false);
            xtraTabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(PacketBanTimeEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(MaxPacketEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(UserCountPortEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(PingDelayEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(TimeOutEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(PortEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(IPAddressEdit.Properties)).EndInit();
            xtraTabPage2.ResumeLayout(false);
            xtraTabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(Dinghaoxiugaimimaok.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(AllowRequestActivationEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(AllowWebActivationEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(AllowManualActivationEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(AllowDeleteAccountEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(AllowManualResetPasswordEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(AllowWebResetPasswordEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(AllowRequestPasswordResetEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(AllowWizardEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(AllowTaoistEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(Shangxianxiaxiantishi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(Xinjuesetishi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(AllowAssassinEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(AllowWarriorEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(ShifouNeice.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(ShifouGongce.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(Guajixunzhaodiyi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(Guajixunzhaodier.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(RelogDelayEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(AllowStartGameEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(AllowDeleteCharacterEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(AllowNewCharacterEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(AllowLoginEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(AllowChangePasswordEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(AllowNewAccountEdit.Properties)).EndInit();
            xtraTabPage3.ResumeLayout(false);
            xtraTabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(ShenmiNpcTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(GuanggaoGaoduok.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(GuanggaoKuanduok.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(Biaomingok.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(Huodonglanok.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(Jueseshujukuhequ.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(XingyunNPCOK.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(Tishiok.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(Daojishiok.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(RabbitEventEndEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(ReleaseDateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(ClientPathEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(MasterPasswordEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(MapPathEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(DBSaveDelayEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(VersionPathEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(CheckVersionEdit.Properties)).EndInit();
            xtraTabPage4.ResumeLayout(false);
            xtraTabPage4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(MailDisplayNameEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(MailFromEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(MailPasswordEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(MailAccountEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(MailUseSSLEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(MailPortEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(MailServerEdit.Properties)).EndInit();
            xtraTabPage5.ResumeLayout(false);
            xtraTabPage5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(AllowBuyGammeGoldEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(RequireActivationEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(ProcessGameGoldEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(ReceiverEMailEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(IPNPrefixEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(BuyAddressEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(BuyPrefixEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(DeleteFailLinkEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(DeleteSuccessLinkEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(ResetFailLinkEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(ResetSuccessLinkEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(ActivationFailLinkEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(ActivationSuccessLinkEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(WebCommandLinkEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(WebPrefixEdit.Properties)).EndInit();
            xtraTabPage6.ResumeLayout(false);
            xtraTabPage6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(ChuanranBoss.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(ShidushuGuagou.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(BeiguaiSiwangbaolv.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(MingwenBangding.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(Sanmingwen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(Hongmingwupindiaobv.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(Putongwupindiaobv.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(Xishiwupindiaobv.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(Gaojiwupindiaobv.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(Baoguodiaobv.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(Siwangbaolv.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(KaiqiBaoshi5432.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(Huanhuabangding.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(ZhuangbeiHuanhua.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(Liujizhuansheng.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(ZaixianFenjie.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(GunghuiGerenPaihang.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(GunghuiPaihang.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(XinshouLiwu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(GuildLevel.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(JYhuishou.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(JihuowanjiaJYjiacheng.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(YaoqiuJSRjihuozhanghao.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(Jieshaorenzubeijsrgerenjingyan.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(Jieshaorenzubeijsrjingyan.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(Jieshaorenzuxinrenjingyan.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(Yunxujieshaoren.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(AutoReviveDelayEdit.Properties)).EndInit();
            daoshigroupBox1.ResumeLayout(false);
            daoshigroupBox1.PerformLayout();
            cikegroupBox1.ResumeLayout(false);
            cikegroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(ShidushuMax.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(Xiudikang.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(Yidaoyihua.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(DikangEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(SihuaEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(PvPCurseRateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(PvPCurseDurationEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(RedPointEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(PKPointTickRateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(PKPointRateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(BrownDurationEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(Shifoujilubaokaqingk.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(AllowObservationEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(SkillExpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(DayCycleCountEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(MaxLevelEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(GlobalDelayEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(ShoutDelayEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(MaxViewRangeEdit.Properties)).EndInit();
            xtraTabPage7.ResumeLayout(false);
            xtraTabPage7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(ShuaguaiBodong.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(Chuanshifou.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(Rongyanshifou.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(Yaotashifou.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(Motashifou.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(Hd01shifou.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(Hd02shifou.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(Hd03shifou.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(Hd04shifou.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(Hd05shifou.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(Hd06shifou.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(Hd07shifou.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(Hd08shifou.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(Hd09shifou.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(Hd10shifou.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(Hd11shifou.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(Hd12shifou.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(Chuanjiluming.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(Rongyanjiluming.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(Yaotajiluming.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(Motajiluming.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(Hd01jiluming.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(Hd02jiluming.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(Hd03jiluming.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(Hd04jiluming.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(Hd05jiluming.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(Hd06jiluming.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(Hd07jiluming.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(Hd08jiluming.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(Hd09jiluming.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(Hd10jiluming.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(Hd11jiluming.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(Hd12jiluming.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(Huodong12OpenEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(Huodong11OpenEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(Huodong10OpenEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(Huodong09OpenEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(Huodong08OpenEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(Huodong07OpenEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(Huodong06OpenEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(Huodong05OpenEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(Huodong04OpenEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(Huodong03OpenEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(Huodong02OpenEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(Huodong01OpenEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(MotaOpenEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(YaotaOpenEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(LairRegionOpenEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(MysteryShipOpenEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(Huodong12Edit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(Huodong11Edit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(Huodong10Edit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(Huodong09Edit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(Huodong08Edit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(Huodong07Edit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(Huodong06Edit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(Huodong05Edit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(Huodong04Edit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(Huodong03Edit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(Huodong02Edit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(Huodong01Edit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(MotaEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(yaotaEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(LairRegionIndexEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(MysteryShipRegionIndexEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(HarvestDurationEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(DeadDurationEdit.Properties)).EndInit();
            xtraTabPage8.ResumeLayout(false);
            xtraTabPage8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(StrengthLossRateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(StrengthAddRateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(MaxStrengthEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(CurseRateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(LabelControl88TaxSani.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(LabelControl90TaxSani.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(XieJipindaxiaogailvy.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(XieJipindaxiaogailve.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(XieJipindaxiaogailvs.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(XieJipindaxiaogailvsi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(XieJipindaxiaogailvw.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(XieJipindaxiaogailvl.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(TouJipindaxiaogailvy.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(TouJipindaxiaogailve.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(TouJipindaxiaogailvs.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(TouJipindaxiaogailvsi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(TouJipindaxiaogailvw.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(TouJipindaxiaogailvl.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(YiJipindaxiaogailvy.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(YiJipindaxiaogailve.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(YiJipindaxiaogailvs.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(YiJipindaxiaogailvsi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(YiJipindaxiaogailvw.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(YiJipindaxiaogailvl.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(DunJipindaxiaogailvy.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(DunJipindaxiaogailve.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(DunJipindaxiaogailvs.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(DunJipindaxiaogailvsi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(DunJipindaxiaogailvw.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(DunJipindaxiaogailvl.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(GyJipindaxiaogailvy.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(GyJipindaxiaogailve.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(GyJipindaxiaogailvs.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(GyJipindaxiaogailvsi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(GyJipindaxiaogailvw.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(GyJipindaxiaogailvl.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(Jipindaxiaogailvy.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(Jipindaxiaogailve.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(Jipindaxiaogailvs.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(Jipindaxiaogailvsi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(Jipindaxiaogailvw.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(Jipindaxiaogailvl.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(Jipindaxiaoy.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(Jipindaxiaoe.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(Jipindaxiaos.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(Jipindaxiaosi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(Jipindaxiaow.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(Jipindaxiaol.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(Jipindebaolv.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(Mfguajishijianzi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(MaxCurseEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(LuckRateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(MaxLuckEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(SpecialRepairDelayEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(TorchRateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(DropLayersEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(DropDistanceEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(DropDurationEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(wakuangbangding.Properties)).EndInit();
            xtraTabPage9.ResumeLayout(false);
            xtraTabPage9.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(Lvdushu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(Qduobishu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(Qgedangshu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(Qchenmoshu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(Qyidongshu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(Qmabishu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(Qbingdongshu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(Qmofadunshu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(Qhuanshu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(Qanshu.Properties)).EndInit();

            ((System.ComponentModel.ISupportInitialize)(ShaGuildjyshu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(ShaGuildblshu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(ShaGuildjbshu.Properties)).EndInit();

            ((System.ComponentModel.ISupportInitialize)(YiGuildrsshu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(YiGuildjyshu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(YiGuildblshu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(YiGuildjbshu.Properties)).EndInit();

            ((System.ComponentModel.ISupportInitialize)(ErGuildrsshu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(ErGuildjyshu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(ErGuildblshu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(ErGuildjbshu.Properties)).EndInit();

            ((System.ComponentModel.ISupportInitialize)(SanGuildrsshu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(SanGuildjyshu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(SanGuildblshu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(SanGuildjbshu.Properties)).EndInit();

            ((System.ComponentModel.ISupportInitialize)(SiGuildrsshu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(SiGuildjyshu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(SiGuildblshu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(SiGuildjbshu.Properties)).EndInit();

            ((System.ComponentModel.ISupportInitialize)(XGuilddjshu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(XGuildjyshu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(XGuildblshu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(XGuildjbshu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(Jieshaorendjwushishu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(Jieshaorendjsishishu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(Jieshaorendjsanshishu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(Jieshaorendjershishu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(Jieshaorendjshishu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(Jieshaorenswsishu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(Jieshaorensjsishu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(Bjieshaorenswsishu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(Bjieshaorensjsishu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(Bjieshaorendjsishu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(Jieshaorenswsshu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(Jieshaorensjsshu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(Bjieshaorenswsshu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(Bjieshaorensjsshu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(Bjieshaorendjsshu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(Jieshaorensweshu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(Jieshaorensjeshu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(Bjieshaorensweshu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(Bjieshaorensjeshu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(Bjieshaorendjeshu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(Jieshaorenswshu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(Jieshaorensjshu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(Bjieshaorenswshu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(Bjieshaorensjshu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(Bjieshaorendjshu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(Qshenshu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(Qfengshu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(Qleishu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(Qbingshu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(Qhuoshu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(Ghuanshu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(Ganshu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(Gshengshu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(Gfengshu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(Gleishu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(Gbingshu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(Ghuoshu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(Xxbsshu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(Jybsshu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(Mybsshu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(Fybsshu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(Sdbsshu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(Mfbsshu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(Smjlbsshu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(Lhjlbsshu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(Zrjlbsshu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(Gjjlbsshu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(Lhbsshu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(Zrbsshu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(Gjbsshu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(EwaijinbiOK.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(Ewaijinbi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(EwaibaolvOK.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(Ewaibaolv.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(EwaijingyanOK.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(Ewaijingyan.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(Ghquanc2029.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(Ghquanc1019.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(Ghquanc0109.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(Ghquanc9099.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(Ghquanc8089.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(Ghquanc7079.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(Ghquanc6069.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(Ghquanc5059.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(Ghquanc4049.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(Ghquanc3039.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(Jingliancglvc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(CompanionRateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(SkillRateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(GoldRateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(DropRateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(ExperienceRateEdit.Properties)).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.BarButtonItem SaveButton;
        private DevExpress.XtraBars.BarButtonItem ReloadButton;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraEditors.LabelControl labelControl51;
        private DevExpress.XtraEditors.TextEdit UserCountPortEdit;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.TimeSpanEdit PingDelayEdit;
        private DevExpress.XtraEditors.TimeSpanEdit TimeOutEdit;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit PortEdit;
        private DevExpress.XtraEditors.TextEdit IPAddressEdit;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
        private DevExpress.XtraEditors.LabelControl labelControl40;
        private DevExpress.XtraEditors.CheckEdit AllowWizardEdit;
        private DevExpress.XtraEditors.LabelControl labelControl39;
        private DevExpress.XtraEditors.CheckEdit AllowTaoistEdit;
        private DevExpress.XtraEditors.LabelControl Shangxianxiaxiantishizi;
        private DevExpress.XtraEditors.CheckEdit Shangxianxiaxiantishi;
        private DevExpress.XtraEditors.LabelControl Xinjuesetishizi;
        private DevExpress.XtraEditors.CheckEdit Xinjuesetishi;
        private DevExpress.XtraEditors.LabelControl labelControl38;
        private DevExpress.XtraEditors.CheckEdit AllowAssassinEdit;
        private DevExpress.XtraEditors.LabelControl labelControl36;
        private DevExpress.XtraEditors.CheckEdit AllowWarriorEdit;
        private DevExpress.XtraEditors.LabelControl ShifouNeicezi;
        private DevExpress.XtraEditors.CheckEdit ShifouNeice;
        private DevExpress.XtraEditors.LabelControl ShifouGongcezi;
        private DevExpress.XtraEditors.CheckEdit ShifouGongce;
        private DevExpress.XtraEditors.LabelControl GuajixunzhaodiyiZi;
        private DevExpress.XtraEditors.CheckEdit Guajixunzhaodiyi;
        private DevExpress.XtraEditors.LabelControl GuajixunzhaodierZi;
        private DevExpress.XtraEditors.CheckEdit Guajixunzhaodier;
        private DevExpress.XtraEditors.LabelControl labelControl15;
        private DevExpress.XtraEditors.TimeSpanEdit RelogDelayEdit;
        private DevExpress.XtraEditors.LabelControl labelControl14;
        private DevExpress.XtraEditors.CheckEdit AllowStartGameEdit;
        private DevExpress.XtraEditors.LabelControl labelControl12;
        private DevExpress.XtraEditors.CheckEdit AllowDeleteCharacterEdit;
        private DevExpress.XtraEditors.LabelControl labelControl11;
        private DevExpress.XtraEditors.CheckEdit AllowNewCharacterEdit;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.CheckEdit AllowLoginEdit;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.CheckEdit AllowChangePasswordEdit;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.CheckEdit AllowNewAccountEdit;
        private System.Windows.Forms.OpenFileDialog OpenDialog;
        private System.Windows.Forms.FolderBrowserDialog FolderDialog;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage4;
        private DevExpress.XtraEditors.LabelControl Dinghaoxiugaimima;
        private DevExpress.XtraEditors.CheckEdit Dinghaoxiugaimimaok;
        private DevExpress.XtraEditors.LabelControl labelControl16;
        private DevExpress.XtraEditors.CheckEdit AllowRequestActivationEdit;
        private DevExpress.XtraEditors.LabelControl labelControl22;
        private DevExpress.XtraEditors.CheckEdit AllowWebActivationEdit;
        private DevExpress.XtraEditors.LabelControl labelControl17;
        private DevExpress.XtraEditors.CheckEdit AllowManualActivationEdit;
        private DevExpress.XtraEditors.LabelControl labelControl18;
        private DevExpress.XtraEditors.CheckEdit AllowDeleteAccountEdit;
        private DevExpress.XtraEditors.LabelControl labelControl19;
        private DevExpress.XtraEditors.CheckEdit AllowManualResetPasswordEdit;
        private DevExpress.XtraEditors.LabelControl labelControl20;
        private DevExpress.XtraEditors.CheckEdit AllowWebResetPasswordEdit;
        private DevExpress.XtraEditors.LabelControl labelControl21;
        private DevExpress.XtraEditors.CheckEdit AllowRequestPasswordResetEdit;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage5;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage6;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage7;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage3;
        private DevExpress.XtraEditors.ButtonEdit MapPathEdit;
        private DevExpress.XtraEditors.LabelControl labelControl13;
        private DevExpress.XtraEditors.LabelControl labelControl10;
        private DevExpress.XtraEditors.TimeSpanEdit DBSaveDelayEdit;
        private DevExpress.XtraEditors.SimpleButton Yijianhequ;
        private DevExpress.XtraEditors.SimpleButton CheckVersionButton;
        private DevExpress.XtraEditors.ButtonEdit VersionPathEdit;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.CheckEdit CheckVersionEdit;
        private DevExpress.XtraEditors.TextEdit MailDisplayNameEdit;
        private DevExpress.XtraEditors.LabelControl labelControl31;
        private DevExpress.XtraEditors.TextEdit MailFromEdit;
        private DevExpress.XtraEditors.LabelControl labelControl30;
        private DevExpress.XtraEditors.TextEdit MailPasswordEdit;
        private DevExpress.XtraEditors.LabelControl labelControl29;
        private DevExpress.XtraEditors.TextEdit MailAccountEdit;
        private DevExpress.XtraEditors.LabelControl labelControl28;
        private DevExpress.XtraEditors.LabelControl labelControl27;
        private DevExpress.XtraEditors.CheckEdit MailUseSSLEdit;
        private DevExpress.XtraEditors.LabelControl labelControl25;
        private DevExpress.XtraEditors.TextEdit MailPortEdit;
        private DevExpress.XtraEditors.TextEdit MailServerEdit;
        private DevExpress.XtraEditors.LabelControl labelControl26;
        private DevExpress.XtraEditors.LabelControl labelControl23;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage8;
        private DevExpress.XtraEditors.TextEdit ActivationFailLinkEdit;
        private DevExpress.XtraEditors.LabelControl labelControl34;
        private DevExpress.XtraEditors.TextEdit ActivationSuccessLinkEdit;
        private DevExpress.XtraEditors.LabelControl labelControl35;
        private DevExpress.XtraEditors.LabelControl labelControl41;
        private DevExpress.XtraEditors.TextEdit WebCommandLinkEdit;
        private DevExpress.XtraEditors.TextEdit WebPrefixEdit;
        private DevExpress.XtraEditors.LabelControl labelControl42;
        private DevExpress.XtraEditors.TextEdit DeleteFailLinkEdit;
        private DevExpress.XtraEditors.LabelControl labelControl37;
        private DevExpress.XtraEditors.TextEdit DeleteSuccessLinkEdit;
        private DevExpress.XtraEditors.LabelControl labelControl43;
        private DevExpress.XtraEditors.TextEdit ResetFailLinkEdit;
        private DevExpress.XtraEditors.LabelControl labelControl32;
        private DevExpress.XtraEditors.TextEdit ResetSuccessLinkEdit;
        private DevExpress.XtraEditors.LabelControl labelControl33;
        private DevExpress.XtraEditors.TextEdit MaxLevelEdit;
        private DevExpress.XtraEditors.LabelControl labelControl46;
        private DevExpress.XtraEditors.LabelControl labelControl45;
        private DevExpress.XtraEditors.TimeSpanEdit GlobalDelayEdit;
        private DevExpress.XtraEditors.LabelControl labelControl44;
        private DevExpress.XtraEditors.TimeSpanEdit ShoutDelayEdit;
        private DevExpress.XtraEditors.TextEdit MaxViewRangeEdit;
        private DevExpress.XtraEditors.LabelControl labelControl47;
        private DevExpress.XtraEditors.TimeSpanEdit DeadDurationEdit;
        private DevExpress.XtraEditors.TextEdit DropDistanceEdit;
        private DevExpress.XtraEditors.LabelControl labelControl49;
        private DevExpress.XtraEditors.LabelControl labelControl48;
        private DevExpress.XtraEditors.TimeSpanEdit DropDurationEdit;
        private DevExpress.XtraEditors.LabelControl wakuangbangdingZi;
        private DevExpress.XtraEditors.CheckEdit wakuangbangding;
        private DevExpress.XtraEditors.TextEdit DropLayersEdit;
        private DevExpress.XtraEditors.LabelControl labelControl50;
        private DevExpress.XtraEditors.TextEdit DayCycleCountEdit;
        private DevExpress.XtraEditors.LabelControl labelControl52;
        private DevExpress.XtraEditors.TextEdit SkillExpEdit;
        private DevExpress.XtraEditors.LabelControl labelControl53;
        private DevExpress.XtraEditors.TextEdit TorchRateEdit;
        private DevExpress.XtraEditors.LabelControl labelControl54;
        private DevExpress.XtraEditors.LabelControl labelControl59;
        private DevExpress.XtraEditors.TimeSpanEdit SpecialRepairDelayEdit;
        private DevExpress.XtraEditors.TextEdit CurseRateEdit;
        private DevExpress.XtraEditors.LabelControl labelControl63;
        private DevExpress.XtraEditors.LabelControl labelControl88;
        private DevExpress.XtraEditors.TextEdit LabelControl88TaxSani;
        private DevExpress.XtraEditors.LabelControl labelControl90;
        private DevExpress.XtraEditors.TextEdit LabelControl90TaxSani;
        private DevExpress.XtraEditors.LabelControl XieJipindaxiaogailvzi;
        private DevExpress.XtraEditors.TextEdit XieJipindaxiaogailvy;
        private DevExpress.XtraEditors.TextEdit XieJipindaxiaogailve;
        private DevExpress.XtraEditors.TextEdit XieJipindaxiaogailvs;
        private DevExpress.XtraEditors.TextEdit XieJipindaxiaogailvsi;
        private DevExpress.XtraEditors.TextEdit XieJipindaxiaogailvw;
        private DevExpress.XtraEditors.TextEdit XieJipindaxiaogailvl;
        private DevExpress.XtraEditors.LabelControl TouJipindaxiaogailvzi;
        private DevExpress.XtraEditors.TextEdit TouJipindaxiaogailvy;
        private DevExpress.XtraEditors.TextEdit TouJipindaxiaogailve;
        private DevExpress.XtraEditors.TextEdit TouJipindaxiaogailvs;
        private DevExpress.XtraEditors.TextEdit TouJipindaxiaogailvsi;
        private DevExpress.XtraEditors.TextEdit TouJipindaxiaogailvw;
        private DevExpress.XtraEditors.TextEdit TouJipindaxiaogailvl;
        private DevExpress.XtraEditors.LabelControl YiJipindaxiaogailvzi;
        private DevExpress.XtraEditors.TextEdit YiJipindaxiaogailvy;
        private DevExpress.XtraEditors.TextEdit YiJipindaxiaogailve;
        private DevExpress.XtraEditors.TextEdit YiJipindaxiaogailvs;
        private DevExpress.XtraEditors.TextEdit YiJipindaxiaogailvsi;
        private DevExpress.XtraEditors.TextEdit YiJipindaxiaogailvw;
        private DevExpress.XtraEditors.TextEdit YiJipindaxiaogailvl;
        private DevExpress.XtraEditors.LabelControl DunJipindaxiaogailvzi;
        private DevExpress.XtraEditors.TextEdit DunJipindaxiaogailvy;
        private DevExpress.XtraEditors.TextEdit DunJipindaxiaogailve;
        private DevExpress.XtraEditors.TextEdit DunJipindaxiaogailvs;
        private DevExpress.XtraEditors.TextEdit DunJipindaxiaogailvsi;
        private DevExpress.XtraEditors.TextEdit DunJipindaxiaogailvw;
        private DevExpress.XtraEditors.TextEdit DunJipindaxiaogailvl;
        private DevExpress.XtraEditors.LabelControl GyJipindaxiaogailvzi;
        private DevExpress.XtraEditors.TextEdit GyJipindaxiaogailvy;
        private DevExpress.XtraEditors.TextEdit GyJipindaxiaogailve;
        private DevExpress.XtraEditors.TextEdit GyJipindaxiaogailvs;
        private DevExpress.XtraEditors.TextEdit GyJipindaxiaogailvsi;
        private DevExpress.XtraEditors.TextEdit GyJipindaxiaogailvw;
        private DevExpress.XtraEditors.TextEdit GyJipindaxiaogailvl;
        private DevExpress.XtraEditors.LabelControl Jipindaxiaogailvzi;
        private DevExpress.XtraEditors.TextEdit Jipindaxiaogailvy;
        private DevExpress.XtraEditors.TextEdit Jipindaxiaogailve;
        private DevExpress.XtraEditors.TextEdit Jipindaxiaogailvs;
        private DevExpress.XtraEditors.TextEdit Jipindaxiaogailvsi;
        private DevExpress.XtraEditors.TextEdit Jipindaxiaogailvw;
        private DevExpress.XtraEditors.TextEdit Jipindaxiaogailvl;
        private DevExpress.XtraEditors.LabelControl Jipindaxiaozi;
        private DevExpress.XtraEditors.TextEdit Jipindaxiaoy;
        private DevExpress.XtraEditors.TextEdit Jipindaxiaoe;
        private DevExpress.XtraEditors.TextEdit Jipindaxiaos;
        private DevExpress.XtraEditors.TextEdit Jipindaxiaosi;
        private DevExpress.XtraEditors.TextEdit Jipindaxiaow;
        private DevExpress.XtraEditors.TextEdit Jipindaxiaol;
        private DevExpress.XtraEditors.LabelControl Jipindebaolvzi;
        private DevExpress.XtraEditors.TextEdit Jipindebaolv;
        private DevExpress.XtraEditors.LabelControl Mfguajishijian;
        private DevExpress.XtraEditors.TextEdit Mfguajishijianzi;
        private DevExpress.XtraEditors.TextEdit MaxCurseEdit;
        private DevExpress.XtraEditors.LabelControl labelControl62;
        private DevExpress.XtraEditors.TextEdit LuckRateEdit;
        private DevExpress.XtraEditors.LabelControl labelControl61;
        private DevExpress.XtraEditors.TextEdit MaxLuckEdit;
        private DevExpress.XtraEditors.LabelControl labelControl60;
        private DevExpress.XtraEditors.TextEdit StrengthLossRateEdit;
        private DevExpress.XtraEditors.LabelControl labelControl64;
        private DevExpress.XtraEditors.TextEdit StrengthAddRateEdit;
        private DevExpress.XtraEditors.LabelControl labelControl65;
        private DevExpress.XtraEditors.TextEdit MaxStrengthEdit;
        private DevExpress.XtraEditors.LabelControl labelControl66;
        private DevExpress.XtraEditors.TextEdit MasterPasswordEdit;
        private DevExpress.XtraEditors.LabelControl labelControl67;
        private DevExpress.XtraEditors.LabelControl labelControl99;
        private DevExpress.XtraEditors.CheckEdit Shifoujilubaokaqingk;
        private DevExpress.XtraEditors.LabelControl labelControl24;
        private DevExpress.XtraEditors.CheckEdit AllowObservationEdit;
        private DevExpress.XtraEditors.LabelControl labelControl74;
        private DevExpress.XtraEditors.TimeSpanEdit HarvestDurationEdit;
        private DevExpress.XtraEditors.LabelControl labelControl75;
        private DevExpress.XtraEditors.TimeSpanEdit BrownDurationEdit;
        private DevExpress.XtraEditors.LabelControl Yidaoyihuazi;
        private DevExpress.XtraEditors.CheckEdit Yidaoyihua;
        private DevExpress.XtraEditors.LabelControl Xiudikangzi;
        private DevExpress.XtraEditors.CheckEdit Xiudikang;
        private DevExpress.XtraEditors.TextEdit DikangEdit;
        private DevExpress.XtraEditors.LabelControl DikangEditZi;
        private DevExpress.XtraEditors.TextEdit ShidushuMax;
        private DevExpress.XtraEditors.LabelControl ShidushuMaxzi;
        private GroupBox daoshigroupBox1;
        private GroupBox cikegroupBox1;
        private DevExpress.XtraEditors.TextEdit SihuaEdit;
        private DevExpress.XtraEditors.LabelControl SihuaEditZi;
        private DevExpress.XtraEditors.TextEdit PvPCurseRateEdit;
        private DevExpress.XtraEditors.LabelControl labelControl83;
        private DevExpress.XtraEditors.LabelControl labelControl84;
        private DevExpress.XtraEditors.TimeSpanEdit PvPCurseDurationEdit;
        private DevExpress.XtraEditors.TextEdit RedPointEdit;
        private DevExpress.XtraEditors.LabelControl labelControl77;
        private DevExpress.XtraEditors.LabelControl labelControl78;
        private DevExpress.XtraEditors.TimeSpanEdit PKPointTickRateEdit;
        private DevExpress.XtraEditors.TextEdit PKPointRateEdit;
        private DevExpress.XtraEditors.LabelControl labelControl76;
        private DevExpress.XtraEditors.LabelControl labelControl89;
        private DevExpress.XtraEditors.LabelControl ShuaguaiBodongzi;
        private DevExpress.XtraEditors.CheckEdit ShuaguaiBodong;
        private DevExpress.XtraEditors.LookUpEdit MysteryShipRegionIndexEdit;
        private DevExpress.XtraEditors.LabelControl labelControl289;
        private DevExpress.XtraEditors.LookUpEdit yaotaEdit;
        private DevExpress.XtraEditors.LabelControl labelControl290;
        private DevExpress.XtraEditors.LookUpEdit MotaEdit;
        private DevExpress.XtraEditors.LabelControl labelControl292;
        private DevExpress.XtraEditors.LookUpEdit Huodong01Edit;
        private DevExpress.XtraEditors.LabelControl labelControl294;
        private DevExpress.XtraEditors.LookUpEdit Huodong02Edit;
        private DevExpress.XtraEditors.LabelControl labelControl296;
        private DevExpress.XtraEditors.LookUpEdit Huodong03Edit;
        private DevExpress.XtraEditors.LabelControl labelControl298;
        private DevExpress.XtraEditors.LookUpEdit Huodong04Edit;
        private DevExpress.XtraEditors.LabelControl labelControl300;
        private DevExpress.XtraEditors.LookUpEdit Huodong05Edit;
        private DevExpress.XtraEditors.LabelControl labelControl302;
        private DevExpress.XtraEditors.LookUpEdit Huodong06Edit;
        private DevExpress.XtraEditors.LabelControl labelControl304;
        private DevExpress.XtraEditors.LookUpEdit Huodong07Edit;
        private DevExpress.XtraEditors.LabelControl labelControl306;
        private DevExpress.XtraEditors.LookUpEdit Huodong08Edit;
        private DevExpress.XtraEditors.LabelControl labelControl308;
        private DevExpress.XtraEditors.LookUpEdit Huodong09Edit;
        private DevExpress.XtraEditors.LabelControl labelControl310;
        private DevExpress.XtraEditors.LookUpEdit Huodong10Edit;
        private DevExpress.XtraEditors.LabelControl labelControl312;
        private DevExpress.XtraEditors.LookUpEdit Huodong11Edit;
        private DevExpress.XtraEditors.LabelControl labelControl314;
        private DevExpress.XtraEditors.LookUpEdit Huodong12Edit;
        private DevExpress.XtraEditors.LabelControl Wendangming;
        private DevExpress.XtraEditors.TextEdit Chuanjiluming;
        private DevExpress.XtraEditors.TextEdit Rongyanjiluming;
        private DevExpress.XtraEditors.TextEdit Yaotajiluming;
        private DevExpress.XtraEditors.TextEdit Motajiluming;
        private DevExpress.XtraEditors.TextEdit Hd01jiluming;
        private DevExpress.XtraEditors.TextEdit Hd02jiluming;
        private DevExpress.XtraEditors.TextEdit Hd03jiluming;
        private DevExpress.XtraEditors.TextEdit Hd04jiluming;
        private DevExpress.XtraEditors.TextEdit Hd05jiluming;
        private DevExpress.XtraEditors.TextEdit Hd06jiluming;
        private DevExpress.XtraEditors.TextEdit Hd07jiluming;
        private DevExpress.XtraEditors.TextEdit Hd08jiluming;
        private DevExpress.XtraEditors.TextEdit Hd09jiluming;
        private DevExpress.XtraEditors.TextEdit Hd10jiluming;
        private DevExpress.XtraEditors.TextEdit Hd11jiluming;
        private DevExpress.XtraEditors.TextEdit Hd12jiluming;
        private DevExpress.XtraEditors.LabelControl Shifoujilu;
        private DevExpress.XtraEditors.CheckEdit Chuanshifou;
        private DevExpress.XtraEditors.CheckEdit Rongyanshifou;
        private DevExpress.XtraEditors.CheckEdit Yaotashifou;
        private DevExpress.XtraEditors.CheckEdit Motashifou;
        private DevExpress.XtraEditors.CheckEdit Hd01shifou;
        private DevExpress.XtraEditors.CheckEdit Hd02shifou;
        private DevExpress.XtraEditors.CheckEdit Hd03shifou;
        private DevExpress.XtraEditors.CheckEdit Hd04shifou;
        private DevExpress.XtraEditors.CheckEdit Hd05shifou;
        private DevExpress.XtraEditors.CheckEdit Hd06shifou;
        private DevExpress.XtraEditors.CheckEdit Hd07shifou;
        private DevExpress.XtraEditors.CheckEdit Hd08shifou;
        private DevExpress.XtraEditors.CheckEdit Hd09shifou;
        private DevExpress.XtraEditors.CheckEdit Hd10shifou;
        private DevExpress.XtraEditors.CheckEdit Hd11shifou;
        private DevExpress.XtraEditors.CheckEdit Hd12shifou;
        private DevExpress.XtraEditors.TextEdit MysteryShipOpenEdit;
        private DevExpress.XtraEditors.TextEdit LairRegionOpenEdit;
        private DevExpress.XtraEditors.TextEdit YaotaOpenEdit;
        private DevExpress.XtraEditors.TextEdit MotaOpenEdit;
        private DevExpress.XtraEditors.TextEdit Huodong01OpenEdit;
        private DevExpress.XtraEditors.TextEdit Huodong02OpenEdit;
        private DevExpress.XtraEditors.TextEdit Huodong03OpenEdit;
        private DevExpress.XtraEditors.TextEdit Huodong04OpenEdit;
        private DevExpress.XtraEditors.TextEdit Huodong05OpenEdit;
        private DevExpress.XtraEditors.TextEdit Huodong06OpenEdit;
        private DevExpress.XtraEditors.TextEdit Huodong07OpenEdit;
        private DevExpress.XtraEditors.TextEdit Huodong08OpenEdit;
        private DevExpress.XtraEditors.TextEdit Huodong09OpenEdit;
        private DevExpress.XtraEditors.TextEdit Huodong10OpenEdit;
        private DevExpress.XtraEditors.TextEdit Huodong11OpenEdit;
        private DevExpress.XtraEditors.TextEdit Huodong12OpenEdit;
        private DevExpress.XtraEditors.LabelControl labelControl315;
        private DevExpress.XtraEditors.ButtonEdit Jueseshujukuhequ;
        private DevExpress.XtraEditors.LabelControl Jueseshujukuhequzi;
#pragma warning disable CS0649 
        private ButtonEdit ServerMergeEdit;
#pragma warning restore CS0649 
        private DevExpress.XtraEditors.ButtonEdit ClientPathEdit;
        private DevExpress.XtraEditors.LabelControl labelControl96;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage9;
        private DevExpress.XtraEditors.LabelControl Lvduzi;
        private DevExpress.XtraEditors.TextEdit Lvdushu;
        private DevExpress.XtraEditors.LabelControl Qduobizi;
        private DevExpress.XtraEditors.TextEdit Qduobishu;
        private DevExpress.XtraEditors.LabelControl Qgedangzi;
        private DevExpress.XtraEditors.TextEdit Qgedangshu;
        private DevExpress.XtraEditors.LabelControl Qchenmozi;
        private DevExpress.XtraEditors.TextEdit Qchenmoshu;
        private DevExpress.XtraEditors.LabelControl Qyidongzi;
        private DevExpress.XtraEditors.TextEdit Qyidongshu;
        private DevExpress.XtraEditors.LabelControl Qmabizi;
        private DevExpress.XtraEditors.TextEdit Qmabishu;
        private DevExpress.XtraEditors.LabelControl Qbingdongzi;
        private DevExpress.XtraEditors.TextEdit Qbingdongshu;
        private DevExpress.XtraEditors.LabelControl Qmofadunzi;
        private DevExpress.XtraEditors.TextEdit Qmofadunshu;
        private DevExpress.XtraEditors.LabelControl Qhuanzi;
        private DevExpress.XtraEditors.TextEdit Qhuanshu;
        private DevExpress.XtraEditors.LabelControl Qanzi;
        private DevExpress.XtraEditors.TextEdit Qanshu;

        private DevExpress.XtraEditors.LabelControl ShaGuildzi;

        private DevExpress.XtraEditors.LabelControl ShaGuildjy;
        private DevExpress.XtraEditors.TextEdit ShaGuildjyshu;
        private DevExpress.XtraEditors.LabelControl ShaGuildbl;
        private DevExpress.XtraEditors.TextEdit ShaGuildblshu;
        private DevExpress.XtraEditors.LabelControl ShaGuildjb;
        private DevExpress.XtraEditors.TextEdit ShaGuildjbshu;

        private DevExpress.XtraEditors.LabelControl QitaGuildzi;

        private DevExpress.XtraEditors.LabelControl YiGuildrs;
        private DevExpress.XtraEditors.TextEdit YiGuildrsshu;
        private DevExpress.XtraEditors.LabelControl YiGuildjy;
        private DevExpress.XtraEditors.TextEdit YiGuildjyshu;
        private DevExpress.XtraEditors.LabelControl YiGuildbl;
        private DevExpress.XtraEditors.TextEdit YiGuildblshu;
        private DevExpress.XtraEditors.LabelControl YiGuildjb;
        private DevExpress.XtraEditors.TextEdit YiGuildjbshu;

        private DevExpress.XtraEditors.LabelControl ErGuildrs;
        private DevExpress.XtraEditors.TextEdit ErGuildrsshu;
        private DevExpress.XtraEditors.LabelControl ErGuildjy;
        private DevExpress.XtraEditors.TextEdit ErGuildjyshu;
        private DevExpress.XtraEditors.LabelControl ErGuildbl;
        private DevExpress.XtraEditors.TextEdit ErGuildblshu;
        private DevExpress.XtraEditors.LabelControl ErGuildjb;
        private DevExpress.XtraEditors.TextEdit ErGuildjbshu;

        private DevExpress.XtraEditors.LabelControl SanGuildrs;
        private DevExpress.XtraEditors.TextEdit SanGuildrsshu;
        private DevExpress.XtraEditors.LabelControl SanGuildjy;
        private DevExpress.XtraEditors.TextEdit SanGuildjyshu;
        private DevExpress.XtraEditors.LabelControl SanGuildbl;
        private DevExpress.XtraEditors.TextEdit SanGuildblshu;
        private DevExpress.XtraEditors.LabelControl SanGuildjb;
        private DevExpress.XtraEditors.TextEdit SanGuildjbshu;

        private DevExpress.XtraEditors.LabelControl SiGuildrs;
        private DevExpress.XtraEditors.TextEdit SiGuildrsshu;
        private DevExpress.XtraEditors.LabelControl SiGuildjy;
        private DevExpress.XtraEditors.TextEdit SiGuildjyshu;
        private DevExpress.XtraEditors.LabelControl SiGuildbl;
        private DevExpress.XtraEditors.TextEdit SiGuildblshu;
        private DevExpress.XtraEditors.LabelControl SiGuildjb;
        private DevExpress.XtraEditors.TextEdit SiGuildjbshu;

        private DevExpress.XtraEditors.LabelControl XinshouGuildzi;
        private DevExpress.XtraEditors.LabelControl XGuilddj;
        private DevExpress.XtraEditors.TextEdit XGuilddjshu;
        private DevExpress.XtraEditors.LabelControl XGuildjy;
        private DevExpress.XtraEditors.TextEdit XGuildjyshu;
        private DevExpress.XtraEditors.LabelControl XGuildbl;
        private DevExpress.XtraEditors.TextEdit XGuildblshu;
        private DevExpress.XtraEditors.LabelControl XGuildjb;
        private DevExpress.XtraEditors.TextEdit XGuildjbshu;
        private DevExpress.XtraEditors.LabelControl Jieshaorendjwushi;
        private DevExpress.XtraEditors.TextEdit Jieshaorendjwushishu;
        private DevExpress.XtraEditors.LabelControl Jieshaorendjsishi;
        private DevExpress.XtraEditors.TextEdit Jieshaorendjsishishu;
        private DevExpress.XtraEditors.LabelControl Jieshaorendjsanshi;
        private DevExpress.XtraEditors.TextEdit Jieshaorendjsanshishu;
        private DevExpress.XtraEditors.LabelControl Jieshaorendjershi;
        private DevExpress.XtraEditors.TextEdit Jieshaorendjershishu;
        private DevExpress.XtraEditors.LabelControl Jieshaorendjshi;
        private DevExpress.XtraEditors.TextEdit Jieshaorendjshishu;
        private DevExpress.XtraEditors.LabelControl Jieshaorendjjieshao;
        private DevExpress.XtraEditors.LabelControl Jieshaorenswsi;
        private DevExpress.XtraEditors.TextEdit Jieshaorenswsishu;
        private DevExpress.XtraEditors.LabelControl Jieshaorensjsi;
        private DevExpress.XtraEditors.TextEdit Jieshaorensjsishu;
        private DevExpress.XtraEditors.LabelControl Bjieshaorenswsi;
        private DevExpress.XtraEditors.TextEdit Bjieshaorenswsishu;
        private DevExpress.XtraEditors.LabelControl Bjieshaorensjsi;
        private DevExpress.XtraEditors.TextEdit Bjieshaorensjsishu;
        private DevExpress.XtraEditors.LabelControl Bjieshaorendjsi;
        private DevExpress.XtraEditors.TextEdit Bjieshaorendjsishu;
        private DevExpress.XtraEditors.LabelControl Jieshaorensws;
        private DevExpress.XtraEditors.TextEdit Jieshaorenswsshu;
        private DevExpress.XtraEditors.LabelControl Jieshaorensjs;
        private DevExpress.XtraEditors.TextEdit Jieshaorensjsshu;
        private DevExpress.XtraEditors.LabelControl Bjieshaorensws;
        private DevExpress.XtraEditors.TextEdit Bjieshaorenswsshu;
        private DevExpress.XtraEditors.LabelControl Bjieshaorensjs;
        private DevExpress.XtraEditors.TextEdit Bjieshaorensjsshu;
        private DevExpress.XtraEditors.LabelControl Bjieshaorendjs;
        private DevExpress.XtraEditors.TextEdit Bjieshaorendjsshu;
        private DevExpress.XtraEditors.LabelControl Jieshaorenswe;
        private DevExpress.XtraEditors.TextEdit Jieshaorensweshu;
        private DevExpress.XtraEditors.LabelControl Jieshaorensje;
        private DevExpress.XtraEditors.TextEdit Jieshaorensjeshu;
        private DevExpress.XtraEditors.LabelControl Bjieshaorenswe;
        private DevExpress.XtraEditors.TextEdit Bjieshaorensweshu;
        private DevExpress.XtraEditors.LabelControl Bjieshaorensje;
        private DevExpress.XtraEditors.TextEdit Bjieshaorensjeshu;
        private DevExpress.XtraEditors.LabelControl Bjieshaorendje;
        private DevExpress.XtraEditors.TextEdit Bjieshaorendjeshu;
        private DevExpress.XtraEditors.LabelControl Jieshaorensw;
        private DevExpress.XtraEditors.TextEdit Jieshaorenswshu;
        private DevExpress.XtraEditors.LabelControl Jieshaorensj;
        private DevExpress.XtraEditors.TextEdit Jieshaorensjshu;
        private DevExpress.XtraEditors.LabelControl Bjieshaorensw;
        private DevExpress.XtraEditors.TextEdit Bjieshaorenswshu;
        private DevExpress.XtraEditors.LabelControl Bjieshaorensj;
        private DevExpress.XtraEditors.TextEdit Bjieshaorensjshu;
        private DevExpress.XtraEditors.LabelControl Bjieshaorendj;
        private DevExpress.XtraEditors.TextEdit Bjieshaorendjshu;
        private DevExpress.XtraEditors.LabelControl Qshenzi;
        private DevExpress.XtraEditors.TextEdit Qshenshu;
        private DevExpress.XtraEditors.LabelControl Qfengzi;
        private DevExpress.XtraEditors.TextEdit Qfengshu;
        private DevExpress.XtraEditors.LabelControl Qleizi;
        private DevExpress.XtraEditors.TextEdit Qleishu;
        private DevExpress.XtraEditors.LabelControl Qbingzi;
        private DevExpress.XtraEditors.TextEdit Qbingshu;
        private DevExpress.XtraEditors.LabelControl Qhuozi;
        private DevExpress.XtraEditors.TextEdit Qhuoshu;
        private DevExpress.XtraEditors.LabelControl Ghuanzi;
        private DevExpress.XtraEditors.TextEdit Ghuanshu;
        private DevExpress.XtraEditors.LabelControl Ganzi;
        private DevExpress.XtraEditors.TextEdit Ganshu;
        private DevExpress.XtraEditors.LabelControl Gshengzi;
        private DevExpress.XtraEditors.TextEdit Gshengshu;
        private DevExpress.XtraEditors.LabelControl Gfengzi;
        private DevExpress.XtraEditors.TextEdit Gfengshu;
        private DevExpress.XtraEditors.LabelControl Gleizi;
        private DevExpress.XtraEditors.TextEdit Gleishu;
        private DevExpress.XtraEditors.LabelControl Gbingzi;
        private DevExpress.XtraEditors.TextEdit Ghuoshu;
        private DevExpress.XtraEditors.LabelControl Ghuozi;
        private DevExpress.XtraEditors.TextEdit Gbingshu;
        private DevExpress.XtraEditors.TextEdit Xxbsshu;
        private DevExpress.XtraEditors.LabelControl Xxbszi;
        private DevExpress.XtraEditors.TextEdit Jybsshu;
        private DevExpress.XtraEditors.LabelControl Jybszi;
        private DevExpress.XtraEditors.TextEdit Mybsshu;
        private DevExpress.XtraEditors.LabelControl Mybszi;
        private DevExpress.XtraEditors.TextEdit Fybsshu;
        private DevExpress.XtraEditors.LabelControl Fybszi;
        private DevExpress.XtraEditors.TextEdit Sdbsshu;
        private DevExpress.XtraEditors.LabelControl Sdbszi;
        private DevExpress.XtraEditors.TextEdit Mfbsshu;
        private DevExpress.XtraEditors.LabelControl Mfbszi;
        private DevExpress.XtraEditors.TextEdit Smjlbsshu;
        private DevExpress.XtraEditors.LabelControl Smjlbszi;
        private DevExpress.XtraEditors.TextEdit Lhjlbsshu;
        private DevExpress.XtraEditors.LabelControl Lhjlbszi;
        private DevExpress.XtraEditors.TextEdit Zrjlbsshu;
        private DevExpress.XtraEditors.LabelControl Zrjlbszi;
        private DevExpress.XtraEditors.TextEdit Gjjlbsshu;
        private DevExpress.XtraEditors.LabelControl Gjjlbszi;
        private DevExpress.XtraEditors.TextEdit Lhbsshu;
        private DevExpress.XtraEditors.LabelControl Lhbszi;
        private DevExpress.XtraEditors.TextEdit Zrbsshu;
        private DevExpress.XtraEditors.LabelControl Zrbszi;
        private DevExpress.XtraEditors.TextEdit Gjbsshu;
        private DevExpress.XtraEditors.LabelControl Gjbszi;
        private DevExpress.XtraEditors.CheckEdit EwaijinbiOK;
        private DevExpress.XtraEditors.TextEdit Ewaijinbi;
        private DevExpress.XtraEditors.CheckEdit EwaibaolvOK;
        private DevExpress.XtraEditors.TextEdit Ewaibaolv;
        private DevExpress.XtraEditors.CheckEdit EwaijingyanOK;
        private DevExpress.XtraEditors.TextEdit Ewaijingyan;
        private DevExpress.XtraEditors.TextEdit Ghquanc2029;
        private DevExpress.XtraEditors.LabelControl Ghquan2029;
        private DevExpress.XtraEditors.TextEdit Ghquanc1019;
        private DevExpress.XtraEditors.LabelControl Ghquan1019;
        private DevExpress.XtraEditors.TextEdit Ghquanc0109;
        private DevExpress.XtraEditors.LabelControl Ghquan0109;
        private DevExpress.XtraEditors.TextEdit Ghquanc9099;
        private DevExpress.XtraEditors.LabelControl Ghquan9099;
        private DevExpress.XtraEditors.TextEdit Ghquanc8089;
        private DevExpress.XtraEditors.LabelControl Ghquan8089;
        private DevExpress.XtraEditors.TextEdit Ghquanc7079;
        private DevExpress.XtraEditors.LabelControl Ghquan7079;
        private DevExpress.XtraEditors.TextEdit Ghquanc6069;
        private DevExpress.XtraEditors.LabelControl Ghquan6069;
        private DevExpress.XtraEditors.TextEdit Ghquanc5059;
        private DevExpress.XtraEditors.LabelControl Ghquan5059;
        private DevExpress.XtraEditors.TextEdit Ghquanc4049;
        private DevExpress.XtraEditors.LabelControl Ghquan4049;
        private DevExpress.XtraEditors.TextEdit Ghquanc3039;
        private DevExpress.XtraEditors.LabelControl Ghquan3039;
        private DevExpress.XtraEditors.TextEdit Jingliancglvc;
        private DevExpress.XtraEditors.LabelControl Jingliancglv;
        private DevExpress.XtraEditors.TextEdit CompanionRateEdit;
        private DevExpress.XtraEditors.LabelControl labelControl68;
        private DevExpress.XtraEditors.TextEdit SkillRateEdit;
        private DevExpress.XtraEditors.LabelControl labelControl58;
        private DevExpress.XtraEditors.TextEdit GoldRateEdit;
        private DevExpress.XtraEditors.LabelControl labelControl57;
        private DevExpress.XtraEditors.TextEdit DropRateEdit;
        private DevExpress.XtraEditors.LabelControl labelControl56;
        private DevExpress.XtraEditors.LabelControl labelControl55;
        private DevExpress.XtraEditors.TextEdit ExperienceRateEdit;
        private DevExpress.XtraEditors.LabelControl labelControl91;
        private DevExpress.XtraEditors.TextEdit JihuowanjiaJYjiacheng;
        private DevExpress.XtraEditors.LabelControl ShidushuGuagouzi;
        private DevExpress.XtraEditors.CheckEdit ShidushuGuagou;
        private DevExpress.XtraEditors.LabelControl ChuanranBosszi;
        private DevExpress.XtraEditors.CheckEdit ChuanranBoss;
        private DevExpress.XtraEditors.LabelControl BeiguaiSiwangbaolvzi;
        private DevExpress.XtraEditors.CheckEdit BeiguaiSiwangbaolv;
        private DevExpress.XtraEditors.LabelControl MingwenBangdingzi;
        private DevExpress.XtraEditors.CheckEdit MingwenBangding;
        private DevExpress.XtraEditors.LabelControl Sanmingwenzi;
        private DevExpress.XtraEditors.CheckEdit Sanmingwen;
        private DevExpress.XtraEditors.TextEdit Hongmingwupindiaobv;
        private DevExpress.XtraEditors.LabelControl Hongmingwupindiaobvzi;
        private DevExpress.XtraEditors.TextEdit Putongwupindiaobv;
        private DevExpress.XtraEditors.LabelControl Putongwupindiaobvzi;
        private DevExpress.XtraEditors.TextEdit Xishiwupindiaobv;
        private DevExpress.XtraEditors.LabelControl Xishiwupindiaobvzi;
        private DevExpress.XtraEditors.TextEdit Gaojiwupindiaobv;
        private DevExpress.XtraEditors.LabelControl Gaojiwupindiaobvzi;
        private DevExpress.XtraEditors.TextEdit Baoguodiaobv;
        private DevExpress.XtraEditors.LabelControl Baoguodiaobvzi;
        private DevExpress.XtraEditors.LabelControl Siwangbaolvzi;
        private DevExpress.XtraEditors.CheckEdit Siwangbaolv;
        private DevExpress.XtraEditors.LabelControl KaiqiBaoshi5432zi;
        private DevExpress.XtraEditors.CheckEdit KaiqiBaoshi5432;
        private DevExpress.XtraEditors.LabelControl Huanhuabangdingzi;
        private DevExpress.XtraEditors.CheckEdit Huanhuabangding;
        private DevExpress.XtraEditors.LabelControl ZhuangbeiHuanhuazi;
        private DevExpress.XtraEditors.CheckEdit ZhuangbeiHuanhua;
        private DevExpress.XtraEditors.LabelControl Liujizhuanshengzi;
        private DevExpress.XtraEditors.CheckEdit Liujizhuansheng;
        private DevExpress.XtraEditors.LabelControl ZaixianFenjiezi;
        private DevExpress.XtraEditors.TextEdit ZaixianFenjie;
        private DevExpress.XtraEditors.LabelControl GunghuiGerenPaihangzi;
        private DevExpress.XtraEditors.CheckEdit GunghuiGerenPaihang;
        private DevExpress.XtraEditors.LabelControl GunghuiPaihangzi;
        private DevExpress.XtraEditors.CheckEdit GunghuiPaihang;
        private DevExpress.XtraEditors.LabelControl XinshouLiwuzi;
        private DevExpress.XtraEditors.CheckEdit XinshouLiwu;
        private DevExpress.XtraEditors.LabelControl GuildLevelzi;
        private DevExpress.XtraEditors.CheckEdit GuildLevel;
        private DevExpress.XtraEditors.LabelControl JYhuishouzi;
        private DevExpress.XtraEditors.TextEdit JYhuishou;
        private DevExpress.XtraEditors.LabelControl labelControl98;
        private DevExpress.XtraEditors.CheckEdit YaoqiuJSRjihuozhanghao;
        private DevExpress.XtraEditors.LabelControl labelControl95;
        private DevExpress.XtraEditors.TextEdit Jieshaorenzubeijsrgerenjingyan;
        private DevExpress.XtraEditors.LabelControl labelControl94;
        private DevExpress.XtraEditors.TextEdit Jieshaorenzubeijsrjingyan;
        private DevExpress.XtraEditors.LabelControl labelControl93;
        private DevExpress.XtraEditors.TextEdit Jieshaorenzuxinrenjingyan;
        private DevExpress.XtraEditors.LabelControl labelControl92;
        private DevExpress.XtraEditors.CheckEdit Yunxujieshaoren;
        private DevExpress.XtraEditors.LabelControl labelControl69;
        private DevExpress.XtraEditors.TimeSpanEdit AutoReviveDelayEdit;
        private DevExpress.XtraEditors.TextEdit ReleaseDateEdit;
        private DevExpress.XtraEditors.LabelControl labelControl70;
        private DevExpress.XtraEditors.TextEdit BuyPrefixEdit;
        private DevExpress.XtraEditors.LabelControl labelControl71;
        private DevExpress.XtraEditors.LabelControl labelControl81;
        private DevExpress.XtraEditors.CheckEdit AllowBuyGammeGoldEdit;
        private DevExpress.XtraEditors.LabelControl labelControl97;
        private DevExpress.XtraEditors.CheckEdit RequireActivationEdit;
        private DevExpress.XtraEditors.LabelControl labelControl80;
        private DevExpress.XtraEditors.CheckEdit ProcessGameGoldEdit;
        private DevExpress.XtraEditors.TextEdit ReceiverEMailEdit;
        private DevExpress.XtraEditors.LabelControl labelControl79;
        private DevExpress.XtraEditors.TextEdit IPNPrefixEdit;
        private DevExpress.XtraEditors.LabelControl labelControl73;
        private DevExpress.XtraEditors.TextEdit BuyAddressEdit;
        private DevExpress.XtraEditors.LabelControl labelControl72;
        private DevExpress.XtraEditors.LookUpEdit LairRegionIndexEdit;
        private DevExpress.XtraEditors.LabelControl labelControl82;
        private DevExpress.XtraEditors.TextEdit GuanggaoGaoduok;
        private DevExpress.XtraEditors.TextEdit GuanggaoKuanduok;
        private DevExpress.XtraEditors.TextEdit Biaomingok;
        private DevExpress.XtraEditors.LabelControl ShenmiNpcTimezi;
        private DevExpress.XtraEditors.TextEdit ShenmiNpcTime;
        private DevExpress.XtraEditors.LabelControl Huodonglan;
        private DevExpress.XtraEditors.CheckEdit Huodonglanok;
        private DevExpress.XtraEditors.LabelControl XingyunNPC;
        private DevExpress.XtraEditors.CheckEdit XingyunNPCOK;
        private DevExpress.XtraEditors.TextEdit Tishiok;
        private DevExpress.XtraEditors.LabelControl Tishi;
        private DevExpress.XtraEditors.LabelControl Daojishi;
        private DevExpress.XtraEditors.CheckEdit Daojishiok;
        private DevExpress.XtraEditors.TextEdit RabbitEventEndEdit;
        private DevExpress.XtraEditors.LabelControl labelControl85;
        private DevExpress.XtraEditors.TimeSpanEdit PacketBanTimeEdit;
        private DevExpress.XtraEditors.SimpleButton SyncronizeButton;
        private DevExpress.XtraEditors.LabelControl labelControl86;
        private DevExpress.XtraEditors.LabelControl labelControl87;
        private DevExpress.XtraEditors.TextEdit MaxPacketEdit;
    }
}