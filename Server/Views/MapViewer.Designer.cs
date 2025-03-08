namespace Server.Views
{
    partial class MapViewer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MapViewer));
            ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            ZoomResetButton = new DevExpress.XtraBars.BarButtonItem();
            ZoomInButton = new DevExpress.XtraBars.BarButtonItem();
            ZoomOutButton = new DevExpress.XtraBars.BarButtonItem();
            AttributesButton = new DevExpress.XtraBars.BarButtonItem();
            SelectionButton = new DevExpress.XtraBars.BarButtonItem();
            DaochuButton = new DevExpress.XtraBars.BarButtonItem();
            DaoruButton = new DevExpress.XtraBars.BarButtonItem();
            QingkongButton = new DevExpress.XtraBars.BarButtonItem();
            SaveButton = new DevExpress.XtraBars.BarButtonItem();
            CancelButton = new DevExpress.XtraBars.BarButtonItem();
            ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            DXPanel = new DevExpress.XtraEditors.PanelControl();
            MapVScroll = new DevExpress.XtraEditors.VScrollBar();
            MapHScroll = new DevExpress.XtraEditors.HScrollBar();
            ((System.ComponentModel.ISupportInitialize)(ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(DXPanel)).BeginInit();
            SuspendLayout();
            // 
            // ribbon
            // 
            ribbon.ExpandCollapseItem.Id = 0;
            ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            ribbon.ExpandCollapseItem,
            ZoomResetButton,
            ZoomInButton,
            ZoomOutButton,
            AttributesButton,
            SelectionButton,
            DaochuButton,
            DaoruButton,
            QingkongButton,
            SaveButton,
            CancelButton});
            ribbon.Location = new System.Drawing.Point(0, 0);
            ribbon.MaxItemId = 12;
            ribbon.MdiMergeStyle = DevExpress.XtraBars.Ribbon.RibbonMdiMergeStyle.Always;
            ribbon.Name = "ribbon";
            ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            ribbonPage1});
            ribbon.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            ribbon.ShowCategoryInCaption = false;
            ribbon.ShowExpandCollapseButton = DevExpress.Utils.DefaultBoolean.False;
            ribbon.ShowQatLocationSelector = false;
            ribbon.ShowToolbarCustomizeItem = false;
            ribbon.Size = new System.Drawing.Size(1098, 144);
            ribbon.Toolbar.ShowCustomizeItem = false;
            // 
            // ZoomResetButton
            // 
            ZoomResetButton.Caption = "Reset";
            ZoomResetButton.Glyph = ((System.Drawing.Image)(resources.GetObject("ZoomResetButton.Glyph")));
            ZoomResetButton.Id = 2;
            ZoomResetButton.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("ZoomResetButton.LargeGlyph")));
            ZoomResetButton.Name = "ZoomResetButton";
            ZoomResetButton.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(ZoomResetButton_ItemClick);
            // 
            // ZoomInButton
            // 
            ZoomInButton.Caption = "Zoom In";
            ZoomInButton.Glyph = ((System.Drawing.Image)(resources.GetObject("ZoomInButton.Glyph")));
            ZoomInButton.Id = 3;
            ZoomInButton.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("ZoomInButton.LargeGlyph")));
            ZoomInButton.Name = "ZoomInButton";
            ZoomInButton.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(ZoomInButton_ItemClick);
            // 
            // ZoomOutButton
            // 
            ZoomOutButton.Caption = "Zoom Out";
            ZoomOutButton.Glyph = ((System.Drawing.Image)(resources.GetObject("ZoomOutButton.Glyph")));
            ZoomOutButton.Id = 4;
            ZoomOutButton.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("ZoomOutButton.LargeGlyph")));
            ZoomOutButton.Name = "ZoomOutButton";
            ZoomOutButton.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(ZoomOutButton_ItemClick);
            // 
            // AttributesButton
            // 
            AttributesButton.Caption = "Attributes";
            AttributesButton.Glyph = ((System.Drawing.Image)(resources.GetObject("AttributesButton.Glyph")));
            AttributesButton.Id = 5;
            AttributesButton.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("AttributesButton.LargeGlyph")));
            AttributesButton.Name = "AttributesButton";
            AttributesButton.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(AttributesButton_ItemClick);
            // 
            // SelectionButton
            // 
            SelectionButton.Caption = "Selection";
            SelectionButton.Glyph = ((System.Drawing.Image)(resources.GetObject("SelectionButton.Glyph")));
            SelectionButton.Id = 6;
            SelectionButton.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("SelectionButton.LargeGlyph")));
            SelectionButton.Name = "SelectionButton";
            SelectionButton.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(SelectionButton_ItemClick);
            // 
            // 导出坐标记录
            // 
            DaochuButton.Caption = "导出坐标记录";
            DaochuButton.Glyph = ((System.Drawing.Image)(resources.GetObject("ZoomResetButton.Glyph")));
            DaochuButton.Id = 7;
            DaochuButton.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("ZoomResetButton.LargeGlyph")));
            DaochuButton.Name = "DaochuButton";
            DaochuButton.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(DaochuButton_ItemClick);
            // 
            // 导入坐标记录
            // 
            DaoruButton.Caption = "导入坐标记录";
            DaoruButton.Glyph = ((System.Drawing.Image)(resources.GetObject("SelectionButton.Glyph")));
            DaoruButton.Id = 8;
            DaoruButton.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("SelectionButton.LargeGlyph")));
            DaoruButton.Name = "DaoruButton";
            DaoruButton.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(DaoruButton_ItemClick);
            // 
            // 清理对应文档坐标记录
            // 
            QingkongButton.Caption = "清空坐标记录";
            QingkongButton.Glyph = ((System.Drawing.Image)(resources.GetObject("AttributesButton.Glyph")));
            QingkongButton.Id = 9;
            QingkongButton.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("AttributesButton.LargeGlyph")));
            QingkongButton.Name = "QingkongButton";
            QingkongButton.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(QingkongButton_ItemClick);


            // 
            // SaveButton
            // 
            SaveButton.Caption = "Save";
            SaveButton.Glyph = ((System.Drawing.Image)(resources.GetObject("SaveButton.Glyph")));
            SaveButton.Id = 10;
            SaveButton.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("SaveButton.LargeGlyph")));
            SaveButton.Name = "SaveButton";
            SaveButton.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(SaveButton_ItemClick);
            // 
            // CancelButton
            // 
            CancelButton.Caption = "Cancel";
            CancelButton.Glyph = ((System.Drawing.Image)(resources.GetObject("CancelButton.Glyph")));
            CancelButton.Id = 11;
            CancelButton.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("CancelButton.LargeGlyph")));
            CancelButton.Name = "CancelButton";
            CancelButton.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(CancelButton_ItemClick);
            // 
            // ribbonPage1
            // 
            ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            ribbonPageGroup2,
            ribbonPageGroup1});
            ribbonPage1.Name = "ribbonPage1";
            ribbonPage1.Text = "Home";
            // 
            // ribbonPageGroup2
            // 
            ribbonPageGroup2.AllowTextClipping = false;
            ribbonPageGroup2.ItemLinks.Add(SaveButton);
            ribbonPageGroup2.ItemLinks.Add(CancelButton);
            ribbonPageGroup2.Name = "ribbonPageGroup2";
            ribbonPageGroup2.ShowCaptionButton = false;
            ribbonPageGroup2.Text = "Selection";
            // 
            // ribbonPageGroup1
            // 
            ribbonPageGroup1.AllowTextClipping = false;
            ribbonPageGroup1.ItemLinks.Add(ZoomResetButton);
            ribbonPageGroup1.ItemLinks.Add(ZoomInButton);
            ribbonPageGroup1.ItemLinks.Add(ZoomOutButton);
            ribbonPageGroup1.ItemLinks.Add(AttributesButton);
            ribbonPageGroup1.ItemLinks.Add(SelectionButton);
            ribbonPageGroup1.ItemLinks.Add(DaochuButton);
            ribbonPageGroup1.ItemLinks.Add(DaoruButton);
            ribbonPageGroup1.ItemLinks.Add(QingkongButton);
            ribbonPageGroup1.Name = "ribbonPageGroup1";
            ribbonPageGroup1.ShowCaptionButton = false;
            ribbonPageGroup1.Text = "View";
            // 
            // DXPanel
            // 
            DXPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            DXPanel.Location = new System.Drawing.Point(0, 150);
            DXPanel.Name = "DXPanel";
            DXPanel.Size = new System.Drawing.Size(1081, 452);
            DXPanel.TabIndex = 2;
            DXPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(DXPanel_MouseDown);
            DXPanel.MouseEnter += new System.EventHandler(DXPanel_MouseEnter);
            DXPanel.MouseLeave += new System.EventHandler(DXPanel_MouseLeave);
            DXPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(DXPanel_MouseMove);
            DXPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(DXPanel_MouseUp);
            // 
            // MapVScroll
            // 
            MapVScroll.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            MapVScroll.Location = new System.Drawing.Point(1081, 150);
            MapVScroll.Name = "MapVScroll";
            MapVScroll.Size = new System.Drawing.Size(17, 452);
            MapVScroll.TabIndex = 4;
            MapVScroll.ValueChanged += new System.EventHandler(MapVScroll_ValueChanged);
            // 
            // MapHScroll
            // 
            MapHScroll.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            MapHScroll.Location = new System.Drawing.Point(0, 602);
            MapHScroll.Name = "MapHScroll";
            MapHScroll.Size = new System.Drawing.Size(1081, 17);
            MapHScroll.TabIndex = 5;
            MapHScroll.ValueChanged += new System.EventHandler(MapHScroll_ValueChanged);
            // 
            // MapViewer
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1098, 619);
            Controls.Add(MapHScroll);
            Controls.Add(MapVScroll);
            Controls.Add(DXPanel);
            Controls.Add(ribbon);
            Name = "MapViewer";
            Ribbon = ribbon;
            Text = "Map Viewer";
            ((System.ComponentModel.ISupportInitialize)(ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(DXPanel)).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraEditors.PanelControl DXPanel;
        private DevExpress.XtraEditors.VScrollBar MapVScroll;
        private DevExpress.XtraEditors.HScrollBar MapHScroll;
        private DevExpress.XtraBars.BarButtonItem ZoomResetButton;
        private DevExpress.XtraBars.BarButtonItem ZoomInButton;
        private DevExpress.XtraBars.BarButtonItem ZoomOutButton;
        private DevExpress.XtraBars.BarButtonItem AttributesButton;
        private DevExpress.XtraBars.BarButtonItem SelectionButton;
        private DevExpress.XtraBars.BarButtonItem DaochuButton;
        private DevExpress.XtraBars.BarButtonItem DaoruButton;
        private DevExpress.XtraBars.BarButtonItem QingkongButton;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.BarButtonItem SaveButton;
#pragma warning disable CS0108 // “MapViewer.CancelButton”隐藏继承的成员“Form.CancelButton”。如果是有意隐藏，请使用关键字 new。
        private DevExpress.XtraBars.BarButtonItem CancelButton;
#pragma warning restore CS0108 // “MapViewer.CancelButton”隐藏继承的成员“Form.CancelButton”。如果是有意隐藏，请使用关键字 new。
    }
}