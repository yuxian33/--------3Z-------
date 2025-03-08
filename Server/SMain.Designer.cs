using DevExpress.XtraNavBar;
using System.Drawing;

namespace Server
{
    partial class SMain
    {
        /// <summary>
        /// 必需的设计器变量
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除所有正在使用的资源
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// 设计器支持所需的方法-不要修改
        /// 此方法的内容和代码编辑器
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SMain));
            DLookAndFeel = new DevExpress.LookAndFeel.DefaultLookAndFeel(components);
            ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            skinRibbonGalleryBarItem1 = new DevExpress.XtraBars.SkinRibbonGalleryBarItem();
            StartServerButton = new DevExpress.XtraBars.BarButtonItem();
            StopServerButton = new DevExpress.XtraBars.BarButtonItem();
            barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ribbonPage2 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ribbonPage3 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            navBarControl1 = new DevExpress.XtraNavBar.NavBarControl();
            navBarGroup1 = new DevExpress.XtraNavBar.NavBarGroup();
            LogNavButton = new DevExpress.XtraNavBar.NavBarItem();
            navBarItem1 = new DevExpress.XtraNavBar.NavBarItem();
            navBarGroup2 = new DevExpress.XtraNavBar.NavBarGroup();
            MapInfoButton = new DevExpress.XtraNavBar.NavBarItem();
            ItemInfoButton = new DevExpress.XtraNavBar.NavBarItem();
            MonsterInfoButton = new DevExpress.XtraNavBar.NavBarItem();
            MonsterCustomInfoButton = new DevExpress.XtraNavBar.NavBarItem();
            MonsterInfoStatButton = new DevExpress.XtraNavBar.NavBarItem();
            MagicInfoButton = new DevExpress.XtraNavBar.NavBarItem();
            MingwenInfoButton = new DevExpress.XtraNavBar.NavBarItem();
            MapRegionButton = new DevExpress.XtraNavBar.NavBarItem();
            MovementInfoButton = new DevExpress.XtraNavBar.NavBarItem();
            SafeZoneInfoButton = new DevExpress.XtraNavBar.NavBarItem();
            RespawnInfoButton = new DevExpress.XtraNavBar.NavBarItem();
            DropInfoButton = new DevExpress.XtraNavBar.NavBarItem();
            BaseStatButton = new DevExpress.XtraNavBar.NavBarItem();
            ItemInfoStatButton = new DevExpress.XtraNavBar.NavBarItem();
            SetInfoButton = new DevExpress.XtraNavBar.NavBarItem();
            navBarItem5 = new DevExpress.XtraNavBar.NavBarItem();
            CraftInfo = new DevExpress.XtraNavBar.NavBarItem();
            NPCInfoButton = new DevExpress.XtraNavBar.NavBarItem();
            NPCPageButton = new DevExpress.XtraNavBar.NavBarItem();
            QuestInfoButton = new DevExpress.XtraNavBar.NavBarItem();
            MeiriQuestInfoButton = new DevExpress.XtraNavBar.NavBarItem();
            StoreInfoButton = new DevExpress.XtraNavBar.NavBarItem();
            EventInfoButton = new DevExpress.XtraNavBar.NavBarItem();
            CastleInfoButton = new DevExpress.XtraNavBar.NavBarItem();
            CompanionInfoButton = new DevExpress.XtraNavBar.NavBarItem();
            horseInfoButton = new DevExpress.XtraNavBar.NavBarItem();
            miniGamesButton = new DevExpress.XtraNavBar.NavBarItem();
            FubenInfoButton = new DevExpress.XtraNavBar.NavBarItem();
            ConfigButton = new DevExpress.XtraNavBar.NavBarItem();
            navBarGroup3 = new DevExpress.XtraNavBar.NavBarGroup();
            AccountInfoButton = new DevExpress.XtraNavBar.NavBarItem();
            CharacterInfoButton = new DevExpress.XtraNavBar.NavBarItem();
            UserDropButton = new DevExpress.XtraNavBar.NavBarItem();
            PaymentButton = new DevExpress.XtraNavBar.NavBarItem();
            StoreSalesButton = new DevExpress.XtraNavBar.NavBarItem();
            DiagnosticButton = new DevExpress.XtraNavBar.NavBarItem();
            navBarItem2 = new DevExpress.XtraNavBar.NavBarItem();
            navBarItem3 = new DevExpress.XtraNavBar.NavBarItem();
            navBarItem4 = new DevExpress.XtraNavBar.NavBarItem();
            DManager = new DevExpress.XtraBars.Docking2010.DocumentManager(components);
            tabbedView1 = new DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView(components);
            BManager = new DevExpress.XtraBars.BarManager(components);
            bar3 = new DevExpress.XtraBars.Bar();
            ConnectionLabel = new DevExpress.XtraBars.BarStaticItem();
            ObjectLabel = new DevExpress.XtraBars.BarStaticItem();
            ProcessLabel = new DevExpress.XtraBars.BarStaticItem();
            LoopLabel = new DevExpress.XtraBars.BarStaticItem();
            ConDelay = new DevExpress.XtraBars.BarStaticItem();
            TotalDownloadLabel = new DevExpress.XtraBars.BarStaticItem();
            TotalUploadLabel = new DevExpress.XtraBars.BarStaticItem();
            DownloadSpeedLabel = new DevExpress.XtraBars.BarStaticItem();
            UploadSpeedLabel = new DevExpress.XtraBars.BarStaticItem();
            EMailsSentLabel = new DevExpress.XtraBars.BarStaticItem();
            SaveDelay = new DevExpress.XtraBars.BarStaticItem();
            barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            InterfaceTimer = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)(ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(navBarControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(DManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(tabbedView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(BManager)).BeginInit();
            SuspendLayout();

            DLookAndFeel.LookAndFeel.SkinName = "Office 2010 Blue";

            ribbonControl1.ExpandCollapseItem.Id = 0;
            ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            ribbonControl1.ExpandCollapseItem,
            skinRibbonGalleryBarItem1,
            StartServerButton,
            StopServerButton,
            barButtonItem1});
            ribbonControl1.Location = new System.Drawing.Point(0, 0);
            ribbonControl1.MaxItemId = 9;
            ribbonControl1.MdiMergeStyle = DevExpress.XtraBars.Ribbon.RibbonMdiMergeStyle.Always;
            ribbonControl1.Name = "ribbonControl1";
            ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            ribbonPage1,
            ribbonPage2,
            ribbonPage3});
            ribbonControl1.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            ribbonControl1.ShowCategoryInCaption = false;
            ribbonControl1.ShowExpandCollapseButton = DevExpress.Utils.DefaultBoolean.True;
            ribbonControl1.ShowQatLocationSelector = false;
            ribbonControl1.ShowToolbarCustomizeItem = false;
            ribbonControl1.Size = new System.Drawing.Size(1284, 148);
            ribbonControl1.Toolbar.ShowCustomizeItem = false;

            skinRibbonGalleryBarItem1.Caption = "skinRibbonGalleryBarItem1";
            skinRibbonGalleryBarItem1.Id = 1;
            skinRibbonGalleryBarItem1.Name = "skinRibbonGalleryBarItem1";

            StartServerButton.Caption = "启动";
            StartServerButton.Id = 2;
            StartServerButton.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("StartServerButton.ImageOptions.Image")));
            StartServerButton.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("StartServerButton.ImageOptions.LargeImage")));
            StartServerButton.LargeWidth = 50;
            StartServerButton.Name = "StartServerButton";
            StartServerButton.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(StartServerButton_ItemClick);

            StopServerButton.Caption = "停止";
            StopServerButton.Id = 3;
            StopServerButton.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("StopServerButton.ImageOptions.Image")));
            StopServerButton.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("StopServerButton.ImageOptions.LargeImage")));
            StopServerButton.LargeWidth = 50;
            StopServerButton.Name = "StopServerButton";
            StopServerButton.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(StopServerButton_ItemClick);

            barButtonItem1.Caption = "地图查看";
            barButtonItem1.Id = 6;
            barButtonItem1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.ImageOptions.Image")));
            barButtonItem1.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.ImageOptions.LargeImage")));
            barButtonItem1.Name = "barButtonItem1";
            barButtonItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(barButtonItem1_ItemClick_1);
     
            ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            ribbonPageGroup1});
            ribbonPage1.Name = "ribbonPage1";
            ribbonPage1.Text = "Home";
  
            ribbonPageGroup1.ItemLinks.Add(StartServerButton);
            ribbonPageGroup1.ItemLinks.Add(StopServerButton);
            ribbonPageGroup1.Name = "ribbonPageGroup1";
            ribbonPageGroup1.ShowCaptionButton = false;
            ribbonPageGroup1.Text = "管理";
     
            ribbonPage2.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            ribbonPageGroup2});
            ribbonPage2.Name = "ribbonPage2";
            ribbonPage2.Text = "视图";
 
            ribbonPageGroup2.ItemLinks.Add(skinRibbonGalleryBarItem1);
            ribbonPageGroup2.Name = "ribbonPageGroup2";
            ribbonPageGroup2.Text = "皮肤";
  
            ribbonPage3.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            ribbonPageGroup3});
            ribbonPage3.Name = "ribbonPage3";
            ribbonPage3.Text = "命令";
  
            ribbonPageGroup3.AllowTextClipping = false;
            ribbonPageGroup3.ItemLinks.Add(barButtonItem1);
            ribbonPageGroup3.Name = "ribbonPageGroup3";
            ribbonPageGroup3.ShowCaptionButton = false;
            ribbonPageGroup3.Text = "测试";
  
            navBarControl1.ActiveGroup = navBarGroup1;
            navBarControl1.Dock = System.Windows.Forms.DockStyle.Left;
            navBarControl1.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] {
            navBarGroup1,
            navBarGroup2,
            navBarGroup3});
            navBarControl1.Items.AddRange(new DevExpress.XtraNavBar.NavBarItem[] {
            LogNavButton,
            navBarItem1,
            ConfigButton,
            MapInfoButton,
            MonsterInfoButton,
            MonsterCustomInfoButton,
            ItemInfoButton,
            NPCInfoButton,
            NPCPageButton,
            MagicInfoButton,
            MingwenInfoButton,
            AccountInfoButton,
            CharacterInfoButton,
            MovementInfoButton,
            ItemInfoStatButton,
            SetInfoButton,
            StoreInfoButton,
            BaseStatButton,
            SafeZoneInfoButton,
            RespawnInfoButton,
            MapRegionButton,
            DropInfoButton,
            UserDropButton,
            QuestInfoButton,
            MeiriQuestInfoButton,
            CompanionInfoButton,
            horseInfoButton,
            miniGamesButton,
            FubenInfoButton,
            EventInfoButton,
            MonsterInfoStatButton,
            CastleInfoButton,
            PaymentButton,
            StoreSalesButton,
            DiagnosticButton,
            navBarItem2,
            navBarItem3,
            navBarItem4,
            navBarItem5,
            CraftInfo});
            navBarControl1.Location = new System.Drawing.Point(0, 148);
            navBarControl1.Name = "navBarControl1";
            navBarControl1.OptionsNavPane.ExpandedWidth = 168;
            navBarControl1.Size = new System.Drawing.Size(168, 471);
            navBarControl1.TabIndex = 1;
            navBarControl1.Text = "navBarControl1";
            // 
            // navBarGroup1
            // 
            navBarGroup1.Caption = "操作";
            navBarGroup1.Expanded = true;
            navBarGroup1.ImageOptions.SmallImage = ((System.Drawing.Image)(resources.GetObject("navBarGroup1.ImageOptions.SmallImage")));
            navBarGroup1.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(LogNavButton),
            new DevExpress.XtraNavBar.NavBarItemLink(navBarItem1)});
            navBarGroup1.Name = "navBarGroup1";

            LogNavButton.Caption = "系统日志";
            LogNavButton.ImageOptions.SmallImage = ((System.Drawing.Image)(resources.GetObject("LogNavButton.ImageOptions.SmallImage")));
            LogNavButton.Name = "LogNavButton";
            LogNavButton.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(LogNavButton_LinkClicked);
  
            navBarItem1.Caption = "聊天日志";
            navBarItem1.ImageOptions.SmallImage = ((System.Drawing.Image)(resources.GetObject("navBarItem1.ImageOptions.SmallImage")));
            navBarItem1.Name = "navBarItem1";
     
            navBarGroup2.Caption = "设置";
            navBarGroup2.Expanded = true;
            navBarGroup2.ImageOptions.SmallImage = ((System.Drawing.Image)(resources.GetObject("navBarGroup2.ImageOptions.SmallImage")));
            navBarGroup2.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(MapInfoButton),
            new DevExpress.XtraNavBar.NavBarItemLink(ItemInfoButton),
            new DevExpress.XtraNavBar.NavBarItemLink(MonsterInfoButton),
            new DevExpress.XtraNavBar.NavBarItemLink(MonsterCustomInfoButton),
            new DevExpress.XtraNavBar.NavBarItemLink(MonsterInfoStatButton),
            new DevExpress.XtraNavBar.NavBarItemLink(MagicInfoButton),
            new DevExpress.XtraNavBar.NavBarItemLink(MingwenInfoButton),
            new DevExpress.XtraNavBar.NavBarItemLink(MapRegionButton),
            new DevExpress.XtraNavBar.NavBarItemLink(MovementInfoButton),
            new DevExpress.XtraNavBar.NavBarItemLink(SafeZoneInfoButton),
            new DevExpress.XtraNavBar.NavBarItemLink(RespawnInfoButton),
            new DevExpress.XtraNavBar.NavBarItemLink(DropInfoButton),
            new DevExpress.XtraNavBar.NavBarItemLink(BaseStatButton),
            new DevExpress.XtraNavBar.NavBarItemLink(ItemInfoStatButton),
            new DevExpress.XtraNavBar.NavBarItemLink(SetInfoButton),
            new DevExpress.XtraNavBar.NavBarItemLink(navBarItem5),
            new DevExpress.XtraNavBar.NavBarItemLink(CraftInfo),
            new DevExpress.XtraNavBar.NavBarItemLink(NPCInfoButton),
            new DevExpress.XtraNavBar.NavBarItemLink(NPCPageButton),
            new DevExpress.XtraNavBar.NavBarItemLink(QuestInfoButton),
            new DevExpress.XtraNavBar.NavBarItemLink(MeiriQuestInfoButton),
            new DevExpress.XtraNavBar.NavBarItemLink(StoreInfoButton),
            new DevExpress.XtraNavBar.NavBarItemLink(EventInfoButton),
            new DevExpress.XtraNavBar.NavBarItemLink(CastleInfoButton),
            new DevExpress.XtraNavBar.NavBarItemLink(CompanionInfoButton),
            new DevExpress.XtraNavBar.NavBarItemLink(horseInfoButton),
            new DevExpress.XtraNavBar.NavBarItemLink(miniGamesButton),
            new DevExpress.XtraNavBar.NavBarItemLink(FubenInfoButton),
            new DevExpress.XtraNavBar.NavBarItemLink(ConfigButton)});
            navBarGroup2.Name = "navBarGroup2";
  
            MapInfoButton.Caption = "地图设置";
            MapInfoButton.ImageOptions.SmallImage = ((System.Drawing.Image)(resources.GetObject("MapInfoButton.ImageOptions.SmallImage")));
            MapInfoButton.Name = "MapInfoButton";
            MapInfoButton.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(MapInfoButton_LinkClicked);
   
            ItemInfoButton.Caption = "道具设置";
            ItemInfoButton.ImageOptions.SmallImage = ((System.Drawing.Image)(resources.GetObject("ItemInfoButton.ImageOptions.SmallImage")));
            ItemInfoButton.Name = "ItemInfoButton";
            ItemInfoButton.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(ItemInfoButton_LinkClicked);
     
            MonsterInfoButton.Caption = "怪物设置 ";
            MonsterInfoButton.ImageOptions.SmallImage = ((System.Drawing.Image)(resources.GetObject("MonsterInfoButton.ImageOptions.SmallImage")));
            MonsterInfoButton.Name = "MonsterInfoButton";
            MonsterInfoButton.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(MonsterInfoButton_LinkClicked);
     
            MonsterCustomInfoButton.Caption = "自定义怪物设置";
            MonsterCustomInfoButton.ImageOptions.SmallImage = ((System.Drawing.Image)(resources.GetObject("MonsterInfoButton.ImageOptions.SmallImage")));
            MonsterCustomInfoButton.Name = "MonsterCustomInfoButton";
            MonsterCustomInfoButton.LinkClicked += new NavBarLinkEventHandler(MonsterCustomInfoButton_LinkClicked);
      
            MonsterInfoStatButton.Caption = "怪物参数设置";
            MonsterInfoStatButton.ImageOptions.SmallImage = ((System.Drawing.Image)(resources.GetObject("MonsterInfoStatButton.ImageOptions.SmallImage")));
            MonsterInfoStatButton.Name = "MonsterInfoStatButton";
            MonsterInfoStatButton.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(MonsterInfoStatButton_LinkClicked);
     
            MagicInfoButton.Caption = "魔法技能";
            MagicInfoButton.ImageOptions.SmallImage = ((System.Drawing.Image)(resources.GetObject("MagicInfoButton.ImageOptions.SmallImage")));
            MagicInfoButton.Name = "MagicInfoButton";
            MagicInfoButton.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(MagicInfoButton_LinkClicked);
      
            MingwenInfoButton.Caption = "铭文设置";
            MingwenInfoButton.ImageOptions.SmallImage = ((System.Drawing.Image)(resources.GetObject("MagicInfoButton.ImageOptions.SmallImage")));
            MingwenInfoButton.Name = "MingwenInfoButton";
            MingwenInfoButton.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(MingwenInfoButton_LinkClicked);
     
            MapRegionButton.Caption = "地图设置";
            MapRegionButton.ImageOptions.SmallImage = ((System.Drawing.Image)(resources.GetObject("MapRegionButton.ImageOptions.SmallImage")));
            MapRegionButton.Name = "MapRegionButton";
            MapRegionButton.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(MapRegionButton_LinkClicked);
    
     
            MovementInfoButton.Caption = "地图链接";
            MovementInfoButton.ImageOptions.SmallImage = ((System.Drawing.Image)(resources.GetObject("MovementInfoButton.ImageOptions.SmallImage")));
            MovementInfoButton.Name = "MovementInfoButton";
            MovementInfoButton.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(MovementInfoButton_LinkClicked);

            SafeZoneInfoButton.Caption = "安全区设置";
            SafeZoneInfoButton.ImageOptions.SmallImage = ((System.Drawing.Image)(resources.GetObject("SafeZoneInfoButton.ImageOptions.SmallImage")));
            SafeZoneInfoButton.Name = "SafeZoneInfoButton";
            SafeZoneInfoButton.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(SafeZoneInfoButton_LinkClicked);
     
            RespawnInfoButton.Caption = "地图刷怪设置";
            RespawnInfoButton.ImageOptions.SmallImage = ((System.Drawing.Image)(resources.GetObject("RespawnInfoButton.ImageOptions.SmallImage")));
            RespawnInfoButton.Name = "RespawnInfoButton";
            RespawnInfoButton.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(RespawnInfoButton_LinkClicked);
      
            DropInfoButton.Caption = "怪物爆率设置";
            DropInfoButton.ImageOptions.SmallImage = ((System.Drawing.Image)(resources.GetObject("DropInfoButton.ImageOptions.SmallImage")));
            DropInfoButton.Name = "DropInfoButton";
            DropInfoButton.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(DropInfoButton_LinkClicked);
 
            BaseStatButton.Caption = "职业初始设定";
            BaseStatButton.ImageOptions.SmallImage = ((System.Drawing.Image)(resources.GetObject("BaseStatButton.ImageOptions.SmallImage")));
            BaseStatButton.Name = "BaseStatButton";
            BaseStatButton.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(BaseStatButton_LinkClicked);
    
            ItemInfoStatButton.Caption = "道具参数设置";
            ItemInfoStatButton.ImageOptions.SmallImage = ((System.Drawing.Image)(resources.GetObject("ItemInfoStatButton.ImageOptions.SmallImage")));
            ItemInfoStatButton.Name = "ItemInfoStatButton";
            ItemInfoStatButton.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(ItemInfoStatButton_LinkClicked);
    
            SetInfoButton.Caption = "套装设置";
            SetInfoButton.ImageOptions.SmallImage = ((System.Drawing.Image)(resources.GetObject("SetInfoButton.ImageOptions.SmallImage")));
            SetInfoButton.Name = "SetInfoButton";
            SetInfoButton.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(SetInfoButton_LinkClicked);
   
            navBarItem5.Caption = "武器工艺信息";
            navBarItem5.ImageOptions.SmallImage = ((System.Drawing.Image)(resources.GetObject("navBarItem5.ImageOptions.SmallImage")));
            navBarItem5.Name = "navBarItem5";
            navBarItem5.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(navBarItem5_LinkClicked);
   
            CraftInfo.Caption = "物品制作";
            CraftInfo.ImageOptions.SmallImage = ((System.Drawing.Image)(resources.GetObject("navBarItem5.ImageOptions.SmallImage")));
            CraftInfo.Name = "CraftItemInfo";
            CraftInfo.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(navBarItem6_LinkClicked);
   
            NPCInfoButton.Caption = "NPC设置";
            NPCInfoButton.ImageOptions.SmallImage = ((System.Drawing.Image)(resources.GetObject("NPCInfoButton.ImageOptions.SmallImage")));
            NPCInfoButton.Name = "NPCInfoButton";
            NPCInfoButton.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(NPCInfoButton_LinkClicked);
    
            NPCPageButton.Caption = "NPC对话";
            NPCPageButton.ImageOptions.SmallImage = ((System.Drawing.Image)(resources.GetObject("NPCPageButton.ImageOptions.SmallImage")));
            NPCPageButton.Name = "NPCPageButton";
            NPCPageButton.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(NPCPageButton_LinkClicked);
   
            QuestInfoButton.Caption = "支线任务";
            QuestInfoButton.ImageOptions.SmallImage = ((System.Drawing.Image)(resources.GetObject("QuestInfoButton.ImageOptions.SmallImage")));
            QuestInfoButton.Name = "QuestInfoButton";
            QuestInfoButton.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(QuestInfoButton_LinkClicked);
    
            MeiriQuestInfoButton.Caption = "每日任务";
            MeiriQuestInfoButton.ImageOptions.SmallImage = ((System.Drawing.Image)(resources.GetObject("QuestInfoButton.ImageOptions.SmallImage")));
            MeiriQuestInfoButton.Name = "MeiriQuestInfoButton";
            MeiriQuestInfoButton.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(MeiriQuestInfoButton_LinkClicked);
     
            StoreInfoButton.Caption = "商城信息";
            StoreInfoButton.ImageOptions.SmallImage = ((System.Drawing.Image)(resources.GetObject("StoreInfoButton.ImageOptions.SmallImage")));
            StoreInfoButton.Name = "StoreInfoButton";
            StoreInfoButton.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(StoreInfoButton_LinkClicked);
  
            EventInfoButton.Caption = "事件信息";
            EventInfoButton.ImageOptions.SmallImage = ((System.Drawing.Image)(resources.GetObject("EventInfoButton.ImageOptions.SmallImage")));
            EventInfoButton.Name = "EventInfoButton";
            EventInfoButton.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(EventInfoButton_LinkClicked);
    
            CastleInfoButton.Caption = "城堡信息";
            CastleInfoButton.ImageOptions.SmallImage = ((System.Drawing.Image)(resources.GetObject("CastleInfoButton.ImageOptions.SmallImage")));
            CastleInfoButton.Name = "CastleInfoButton";
            CastleInfoButton.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(CastleInfoButton_LinkClicked);
     
            CompanionInfoButton.Caption = "宠物信息";
            CompanionInfoButton.ImageOptions.SmallImage = ((System.Drawing.Image)(resources.GetObject("CompanionInfoButton.ImageOptions.SmallImage")));
            CompanionInfoButton.Name = "CompanionInfoButton";
            CompanionInfoButton.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(CompanionInfoButton_LinkClicked);
         
            horseInfoButton.Caption = "匹马商城";
            horseInfoButton.ImageOptions.SmallImage = ((System.Drawing.Image)(resources.GetObject("MapRegionButton.ImageOptions.SmallImage")));
            horseInfoButton.Name = "horseInfoButton";
            horseInfoButton.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(horseInfoButton_LinkClicked);
    
            miniGamesButton.Caption = "迷你游戏";
            miniGamesButton.ImageOptions.SmallImage = ((System.Drawing.Image)(resources.GetObject("CompanionInfoButton.ImageOptions.SmallImage")));
            miniGamesButton.Name = "miniGamesButton";
            miniGamesButton.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(miniGamesButton_LinkClicked);
    
            FubenInfoButton.Caption = "副本设置";
            FubenInfoButton.ImageOptions.SmallImage = ((System.Drawing.Image)(resources.GetObject("MagicInfoButton.ImageOptions.SmallImage")));
            FubenInfoButton.Name = "FubenInfoButton";
            FubenInfoButton.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(FubenInfoButton_LinkClicked);
    
            ConfigButton.Caption = "配置";
            ConfigButton.ImageOptions.SmallImage = ((System.Drawing.Image)(resources.GetObject("ConfigButton.ImageOptions.SmallImage")));
            ConfigButton.Name = "ConfigButton";
            ConfigButton.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(ConfigButton_LinkClicked);
     
            navBarGroup3.Caption = "管理";
            navBarGroup3.Expanded = true;
            navBarGroup3.ImageOptions.SmallImage = ((System.Drawing.Image)(resources.GetObject("navBarGroup3.ImageOptions.SmallImage")));
            navBarGroup3.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(AccountInfoButton),
            new DevExpress.XtraNavBar.NavBarItemLink(CharacterInfoButton),
            new DevExpress.XtraNavBar.NavBarItemLink(UserDropButton),
            new DevExpress.XtraNavBar.NavBarItemLink(PaymentButton),
            new DevExpress.XtraNavBar.NavBarItemLink(StoreSalesButton),
            new DevExpress.XtraNavBar.NavBarItemLink(DiagnosticButton),
            new DevExpress.XtraNavBar.NavBarItemLink(navBarItem2),
            new DevExpress.XtraNavBar.NavBarItemLink(navBarItem3),
            new DevExpress.XtraNavBar.NavBarItemLink(navBarItem4)});
            navBarGroup3.Name = "navBarGroup3";
      
            AccountInfoButton.Caption = "账户信息";
            AccountInfoButton.ImageOptions.SmallImage = ((System.Drawing.Image)(resources.GetObject("AccountInfoButton.ImageOptions.SmallImage")));
            AccountInfoButton.Name = "AccountInfoButton";
            AccountInfoButton.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(AccountInfoButton_LinkClicked);
     
            CharacterInfoButton.Caption = "角色信息";
            CharacterInfoButton.ImageOptions.SmallImage = ((System.Drawing.Image)(resources.GetObject("CharacterInfoButton.ImageOptions.SmallImage")));
            CharacterInfoButton.Name = "CharacterInfoButton";
            CharacterInfoButton.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(CharacterInfoButton_LinkClicked);
      
            UserDropButton.Caption = "人物爆率";
            UserDropButton.ImageOptions.SmallImage = ((System.Drawing.Image)(resources.GetObject("UserDropButton.ImageOptions.SmallImage")));
            UserDropButton.Name = "UserDropButton";
            UserDropButton.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(UserDropButton_LinkClicked);
       
            PaymentButton.Caption = "充值记录";
            PaymentButton.ImageOptions.SmallImage = ((System.Drawing.Image)(resources.GetObject("PaymentButton.ImageOptions.SmallImage")));
            PaymentButton.Name = "PaymentButton";
            PaymentButton.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(PaymentButton_LinkClicked);
       
            StoreSalesButton.Caption = "商城购买记录";
            StoreSalesButton.ImageOptions.SmallImage = ((System.Drawing.Image)(resources.GetObject("StoreSalesButton.ImageOptions.SmallImage")));
            StoreSalesButton.Name = "StoreSalesButton";
            StoreSalesButton.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(StoreSalesButton_LinkClicked);
     
            DiagnosticButton.Caption = "判断工具";
            DiagnosticButton.ImageOptions.SmallImage = ((System.Drawing.Image)(resources.GetObject("DiagnosticButton.ImageOptions.SmallImage")));
            DiagnosticButton.Name = "DiagnosticButton";
            DiagnosticButton.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(DiagnosticButton_LinkClicked);
       
            navBarItem2.Caption = "所有角色道具";
            navBarItem2.Name = "navBarItem2";
            navBarItem2.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(navBarItem2_LinkClicked);
      
            navBarItem3.Caption = "所有攻城战统计";
            navBarItem3.Name = "navBarItem3";
            navBarItem3.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(navBarItem3_LinkClicked);
    
            navBarItem4.Caption = "所有角色邮件";
            navBarItem4.Name = "navBarItem4";
            navBarItem4.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(navBarItem4_LinkClicked);
    
            DManager.MdiParent = this;
            DManager.MenuManager = ribbonControl1;
            DManager.View = tabbedView1;
            DManager.ViewCollection.AddRange(new DevExpress.XtraBars.Docking2010.Views.BaseView[] {
            tabbedView1});
     
            BManager.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            bar3});
            BManager.DockControls.Add(barDockControlTop);
            BManager.DockControls.Add(barDockControlBottom);
            BManager.DockControls.Add(barDockControlLeft);
            BManager.DockControls.Add(barDockControlRight);
            BManager.Form = this;
            BManager.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            ConnectionLabel,
            ObjectLabel,
            ProcessLabel,
            LoopLabel,
            TotalDownloadLabel,
            TotalUploadLabel,
            DownloadSpeedLabel,
            UploadSpeedLabel,
            EMailsSentLabel,
            ConDelay,
            SaveDelay});
            BManager.MaxItemId = 12;
            BManager.StatusBar = bar3;
   
            bar3.BarName = "Status bar";
            bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            bar3.DockCol = 0;
            bar3.DockRow = 0;
            bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            bar3.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(ConnectionLabel),
            new DevExpress.XtraBars.LinkPersistInfo(ObjectLabel),
            new DevExpress.XtraBars.LinkPersistInfo(ProcessLabel),
            new DevExpress.XtraBars.LinkPersistInfo(LoopLabel),
            new DevExpress.XtraBars.LinkPersistInfo(ConDelay),
            new DevExpress.XtraBars.LinkPersistInfo(TotalDownloadLabel),
            new DevExpress.XtraBars.LinkPersistInfo(TotalUploadLabel),
            new DevExpress.XtraBars.LinkPersistInfo(DownloadSpeedLabel),
            new DevExpress.XtraBars.LinkPersistInfo(UploadSpeedLabel),
            new DevExpress.XtraBars.LinkPersistInfo(EMailsSentLabel),
            new DevExpress.XtraBars.LinkPersistInfo(SaveDelay)});
            bar3.OptionsBar.AllowQuickCustomization = false;
            bar3.OptionsBar.DrawDragBorder = false;
            bar3.OptionsBar.UseWholeRow = true;
            bar3.Text = "Status bar";
  
            ConnectionLabel.Caption = "连接: 0";
            ConnectionLabel.Id = 1;
            ConnectionLabel.Name = "ConnectionLabel";

            ObjectLabel.Caption = "对象: 0";
            ObjectLabel.Id = 2;
            ObjectLabel.Name = "ObjectLabel";
  
            ProcessLabel.Caption = "过程计数: 0";
            ProcessLabel.Id = 3;
            ProcessLabel.Name = "ProcessLabel";
 
            LoopLabel.Caption = "循环计数: 0";
            LoopLabel.Id = 4;
            LoopLabel.Name = "LoopLabel";
    
            ConDelay.Caption = "控制延迟: 0";
            ConDelay.Id = 10;
            ConDelay.Name = "ConDelay";
 
            TotalDownloadLabel.Caption = "下载: 0B";
            TotalDownloadLabel.Id = 5;
            TotalDownloadLabel.Name = "TotalDownloadLabel";
    
            TotalUploadLabel.Caption = "上传: 0B";
            TotalUploadLabel.Id = 6;
            TotalUploadLabel.Name = "TotalUploadLabel";
   
            DownloadSpeedLabel.Caption = "D/L 速度: 0Bps";
            DownloadSpeedLabel.Id = 7;
            DownloadSpeedLabel.Name = "DownloadSpeedLabel";
    
            UploadSpeedLabel.Caption = "U/L 速度: 0Bps";
            UploadSpeedLabel.Id = 8;
            UploadSpeedLabel.Name = "UploadSpeedLabel";
    
            EMailsSentLabel.Caption = "邮件发送: 0";
            EMailsSentLabel.Id = 9;
            EMailsSentLabel.Name = "EMailsSentLabel";
    
            SaveDelay.Caption = "保存延迟: 0";
            SaveDelay.Id = 11;
            SaveDelay.Name = "SaveDelay";
    
            barDockControlTop.CausesValidation = false;
            barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            barDockControlTop.Location = new System.Drawing.Point(0, 0);
            barDockControlTop.Manager = BManager;
            barDockControlTop.Size = new System.Drawing.Size(1284, 0);
     
            barDockControlBottom.CausesValidation = false;
            barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            barDockControlBottom.Location = new System.Drawing.Point(0, 619);
            barDockControlBottom.Manager = BManager;
            barDockControlBottom.Size = new System.Drawing.Size(1284, 29);
     
            barDockControlLeft.CausesValidation = false;
            barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            barDockControlLeft.Manager = BManager;
            barDockControlLeft.Size = new System.Drawing.Size(0, 619);
   
            barDockControlRight.CausesValidation = false;
            barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            barDockControlRight.Location = new System.Drawing.Point(1284, 0);
            barDockControlRight.Manager = BManager;
            barDockControlRight.Size = new System.Drawing.Size(0, 619);
    
            InterfaceTimer.Interval = 1000;
            InterfaceTimer.Tick += new System.EventHandler(InterfaceTimer_Tick);

            AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            AutoScroll = true;
            ClientSize = new System.Drawing.Size(1284, 648);
            Controls.Add(navBarControl1);
            Controls.Add(ribbonControl1);
            Controls.Add(barDockControlLeft);
            Controls.Add(barDockControlRight);
            Controls.Add(barDockControlBottom);
            Controls.Add(barDockControlTop);
            Name = "SMain";
            Ribbon = ribbonControl1;
            Text = "欢乐世界Mir3服务器（技术QQ：15114424，玩家群：124385013）";
            WindowState = System.Windows.Forms.FormWindowState.Maximized;
            Load += new System.EventHandler(SMain_Load);
            ((System.ComponentModel.ISupportInitialize)(ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(navBarControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(DManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(tabbedView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(BManager)).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private DevExpress.LookAndFeel.DefaultLookAndFeel DLookAndFeel;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.SkinRibbonGalleryBarItem skinRibbonGalleryBarItem1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage2;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraNavBar.NavBarControl navBarControl1;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroup1;
        private DevExpress.XtraBars.Docking2010.DocumentManager DManager;
        private DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView tabbedView1;
        private DevExpress.XtraBars.BarButtonItem StartServerButton;
        private DevExpress.XtraBars.BarButtonItem StopServerButton;
        private DevExpress.XtraNavBar.NavBarItem LogNavButton;
        private DevExpress.XtraNavBar.NavBarItem navBarItem1;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarManager BManager;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarStaticItem ConnectionLabel;
        private System.Windows.Forms.Timer InterfaceTimer;
        private DevExpress.XtraBars.BarStaticItem ObjectLabel;
        private DevExpress.XtraBars.BarStaticItem ProcessLabel;
        private DevExpress.XtraBars.BarStaticItem LoopLabel;
        private DevExpress.XtraBars.BarStaticItem TotalDownloadLabel;
        private DevExpress.XtraBars.BarStaticItem TotalUploadLabel;
        private DevExpress.XtraBars.BarStaticItem DownloadSpeedLabel;
        private DevExpress.XtraBars.BarStaticItem UploadSpeedLabel;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroup2;
        private DevExpress.XtraNavBar.NavBarItem ConfigButton;
        private DevExpress.XtraBars.BarStaticItem EMailsSentLabel;
        private DevExpress.XtraNavBar.NavBarItem MapInfoButton;
        private DevExpress.XtraNavBar.NavBarItem MonsterInfoButton;
        private DevExpress.XtraNavBar.NavBarItem MonsterCustomInfoButton;
        private DevExpress.XtraNavBar.NavBarItem ItemInfoButton;
        private DevExpress.XtraNavBar.NavBarItem NPCInfoButton;
        private DevExpress.XtraNavBar.NavBarItem NPCPageButton;
        private DevExpress.XtraNavBar.NavBarItem MagicInfoButton;
        private DevExpress.XtraNavBar.NavBarItem MingwenInfoButton;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroup3;
        private DevExpress.XtraNavBar.NavBarItem AccountInfoButton;
        private DevExpress.XtraNavBar.NavBarItem CharacterInfoButton;
        private DevExpress.XtraNavBar.NavBarItem MovementInfoButton;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage3;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private DevExpress.XtraNavBar.NavBarItem ItemInfoStatButton;
        private DevExpress.XtraNavBar.NavBarItem SetInfoButton;
        private DevExpress.XtraNavBar.NavBarItem StoreInfoButton;
        private DevExpress.XtraNavBar.NavBarItem BaseStatButton;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraNavBar.NavBarItem SafeZoneInfoButton;
        private DevExpress.XtraNavBar.NavBarItem RespawnInfoButton;
        private DevExpress.XtraNavBar.NavBarItem MapRegionButton;
        private DevExpress.XtraNavBar.NavBarItem DropInfoButton;
        private DevExpress.XtraNavBar.NavBarItem UserDropButton;
        private DevExpress.XtraNavBar.NavBarItem QuestInfoButton;
        private DevExpress.XtraNavBar.NavBarItem MeiriQuestInfoButton;
        private DevExpress.XtraNavBar.NavBarItem CompanionInfoButton;
        private DevExpress.XtraNavBar.NavBarItem horseInfoButton;
        private DevExpress.XtraNavBar.NavBarItem miniGamesButton;
        private DevExpress.XtraNavBar.NavBarItem FubenInfoButton;
        private DevExpress.XtraNavBar.NavBarItem EventInfoButton;
        private DevExpress.XtraNavBar.NavBarItem MonsterInfoStatButton;
        private DevExpress.XtraNavBar.NavBarItem CastleInfoButton;
        private DevExpress.XtraNavBar.NavBarItem PaymentButton;
        private DevExpress.XtraNavBar.NavBarItem StoreSalesButton;
        private DevExpress.XtraBars.BarStaticItem ConDelay;
        private DevExpress.XtraNavBar.NavBarItem DiagnosticButton;
        private DevExpress.XtraBars.BarStaticItem SaveDelay;
        private DevExpress.XtraNavBar.NavBarItem navBarItem2;
        private DevExpress.XtraNavBar.NavBarItem navBarItem3;
        private DevExpress.XtraNavBar.NavBarItem navBarItem4;
        private DevExpress.XtraNavBar.NavBarItem navBarItem5;
        private DevExpress.XtraNavBar.NavBarItem CraftInfo;
    }
}

