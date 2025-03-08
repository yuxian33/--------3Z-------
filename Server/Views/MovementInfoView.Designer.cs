namespace Server.Views
{
    partial class MovementInfoView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MovementInfoView));
            ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            SaveButton = new DevExpress.XtraBars.BarButtonItem();
            ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            MovementGridControl = new DevExpress.XtraGrid.GridControl();
            MovementGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            MapLookUpEdit = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            ShifouFuben = new DevExpress.XtraGrid.Columns.GridColumn();
            Zuduiguotu = new DevExpress.XtraGrid.Columns.GridColumn();
            Gerenguotu = new DevExpress.XtraGrid.Columns.GridColumn();
            Daysofyear = new DevExpress.XtraGrid.Columns.GridColumn();
            gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            ItemLookUpEdit = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            SpawnLookUpEdit = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            MapIconImageComboBox = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            MonsterSpawnLookUpEdit = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            Jilu = new DevExpress.XtraGrid.Columns.GridColumn();
            String = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(MovementGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(MovementGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(MapLookUpEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(ItemLookUpEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(SpawnLookUpEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(MapIconImageComboBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(MonsterSpawnLookUpEdit)).BeginInit();
            SuspendLayout();
            // 
            // ribbon
            // 
            ribbon.ExpandCollapseItem.Id = 0;
            ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            ribbon.ExpandCollapseItem,
            SaveButton});
            ribbon.Location = new System.Drawing.Point(0, 0);
            ribbon.MaxItemId = 2;
            ribbon.Name = "ribbon";
            ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            ribbonPage1});
            ribbon.Size = new System.Drawing.Size(733, 144);
            // 
            // SaveButton
            // 
            SaveButton.Caption = "Save Database";
            SaveButton.Glyph = ((System.Drawing.Image)(resources.GetObject("SaveButton.Glyph")));
            SaveButton.Id = 1;
            SaveButton.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("SaveButton.LargeGlyph")));
            SaveButton.LargeWidth = 60;
            SaveButton.Name = "SaveButton";
            SaveButton.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(SaveButton_ItemClick);
            // 
            // ribbonPage1
            // 
            ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            ribbonPageGroup1});
            ribbonPage1.Name = "ribbonPage1";
            ribbonPage1.Text = "Home";
            // 
            // ribbonPageGroup1
            // 
            ribbonPageGroup1.AllowTextClipping = false;
            ribbonPageGroup1.ItemLinks.Add(SaveButton);
            ribbonPageGroup1.Name = "ribbonPageGroup1";
            ribbonPageGroup1.ShowCaptionButton = false;
            ribbonPageGroup1.Text = "Saving";
            // 
            // MovementGridControl
            // 
            MovementGridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            MovementGridControl.Location = new System.Drawing.Point(0, 144);
            MovementGridControl.MainView = MovementGridView;
            MovementGridControl.MenuManager = ribbon;
            MovementGridControl.Name = "MovementGridControl";
            MovementGridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            MapLookUpEdit,
            MapIconImageComboBox,
            ItemLookUpEdit,
            SpawnLookUpEdit,
            MonsterSpawnLookUpEdit});
            MovementGridControl.ShowOnlyPredefinedDetails = true;
            MovementGridControl.Size = new System.Drawing.Size(733, 391);
            MovementGridControl.TabIndex = 2;
            MovementGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            MovementGridView});
            // 
            // MovementGridView
            // 
            MovementGridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            gridColumn1,
            gridColumn2,
            gridColumn3,
            ShifouFuben,
            Zuduiguotu,
            Gerenguotu,
            Daysofyear,
            gridColumn4,
            gridColumn5,
            gridColumn6,
            gridColumn7,
            gridColumn8,
            gridColumn9,
            gridColumn10,
            gridColumn11,
            gridColumn12,
            gridColumn13,
            Jilu,
            String});
            MovementGridView.GridControl = MovementGridControl;
            MovementGridView.Name = "MovementGridView";
            MovementGridView.OptionsView.EnableAppearanceEvenRow = true;
            MovementGridView.OptionsView.EnableAppearanceOddRow = true;
            MovementGridView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            MovementGridView.OptionsView.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            MovementGridView.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            gridColumn1.ColumnEdit = MapLookUpEdit;
            gridColumn1.FieldName = "SourceRegion";
            gridColumn1.Name = "gridColumn1";
            gridColumn1.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            gridColumn1.SortMode = DevExpress.XtraGrid.ColumnSortMode.DisplayText;
            gridColumn1.Visible = true;
            gridColumn1.VisibleIndex = 0;
            // 
            // MapLookUpEdit
            // 
            MapLookUpEdit.AutoHeight = false;
            MapLookUpEdit.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            MapLookUpEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            MapLookUpEdit.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ServerDescription", "Description"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Size", "Size")});
            MapLookUpEdit.DisplayMember = "ServerDescription";
            MapLookUpEdit.Name = "MapLookUpEdit";
            MapLookUpEdit.NullText = "[Region is null]";
            // 
            // gridColumn2
            // 
            gridColumn2.ColumnEdit = MapLookUpEdit;
            gridColumn2.FieldName = "DestinationRegion";
            gridColumn2.Name = "gridColumn2";
            gridColumn2.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            gridColumn2.SortMode = DevExpress.XtraGrid.ColumnSortMode.DisplayText;
            gridColumn2.Visible = true;
            gridColumn2.VisibleIndex = 1;
            // 
            // gridColumn3
            // 
            gridColumn3.FieldName = "Icon";
            gridColumn3.Name = "gridColumn3";
            gridColumn3.Visible = true;
            gridColumn3.VisibleIndex = 2;
            // 
            // 是否副本
            // 
            ShifouFuben.FieldName = "Fuben";
            ShifouFuben.Name = "ShifouFuben";
            ShifouFuben.ToolTip = "是否副本地图";
            ShifouFuben.Visible = true;
            ShifouFuben.VisibleIndex = 3;
            // 
            // 副本地图组队可过图
            // 
            Zuduiguotu.FieldName = "Group";
            Zuduiguotu.Name = "Zuduiguotu";
            Zuduiguotu.ToolTip = "是否组队才能可以过副本地图";
            Zuduiguotu.Visible = true;
            Zuduiguotu.VisibleIndex = 4;
            // 
            // 副本地图可组队可个人过图
            // 
            Gerenguotu.FieldName = "Geren";
            Gerenguotu.Name = "Gerenguotu";
            Gerenguotu.ToolTip = "是否可组队可个人过副本地图";
            Gerenguotu.Visible = true;
            Gerenguotu.VisibleIndex = 5;
            // 
            // 地图开启日期
            // 
            Daysofyear.FieldName = "Days";
            Daysofyear.Name = "Daysofyear";
            Daysofyear.ToolTip = "开启时间";
            Daysofyear.Visible = true;
            Daysofyear.VisibleIndex = 6;
            // 
            // gridColumn4
            // 
            gridColumn4.ColumnEdit = ItemLookUpEdit;
            gridColumn4.FieldName = "NeedItem";
            gridColumn4.Name = "gridColumn4";
            gridColumn4.Visible = true;
            gridColumn4.VisibleIndex = 7;
            // 
            // ItemLookUpEdit
            // 
            ItemLookUpEdit.AutoHeight = false;
            ItemLookUpEdit.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            ItemLookUpEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            ItemLookUpEdit.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Index", "Index"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ItemName", "Item Name"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ItemType", "Item Type"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Price", "Price"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("StackSize", "Stack Size")});
            ItemLookUpEdit.DisplayMember = "ItemName";
            ItemLookUpEdit.Name = "ItemLookUpEdit";
            ItemLookUpEdit.NullText = "[Item is null]";
            // 
            // gridColumn11
            // 
            gridColumn11.FieldName = "NeedItemCount";
            gridColumn11.Name = "gridColumn11";
            gridColumn11.ToolTip = "收取的物品数量";
            gridColumn11.Visible = true;
            gridColumn11.VisibleIndex = 8;
            // 
            // gridColumn5
            // 
            gridColumn5.ColumnEdit = SpawnLookUpEdit;
            gridColumn5.FieldName = "NeedSpawn";
            gridColumn5.Name = "gridColumn5";
            gridColumn5.Visible = true;
            gridColumn5.VisibleIndex = 9;
            // 
            // SpawnLookUpEdit
            // 
            SpawnLookUpEdit.AutoHeight = false;
            SpawnLookUpEdit.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            SpawnLookUpEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            SpawnLookUpEdit.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Index", "Index"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("RegionName", "Region"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("MonsterName", "Monster")});
            SpawnLookUpEdit.DisplayMember = "MonsterName";
            SpawnLookUpEdit.Name = "SpawnLookUpEdit";
            SpawnLookUpEdit.NullText = "[Spawn is null]";
            // 
            // gridColumn9
            // 
            gridColumn9.ColumnEdit = ItemLookUpEdit;
            gridColumn9.FieldName = "GiveItem";
            gridColumn9.Name = "gridColumn9";
            gridColumn9.Visible = true;
            gridColumn9.VisibleIndex = 10;
            // 
            // gridColumn10
            // 
            gridColumn10.FieldName = "GiveItemCount";
            gridColumn10.Name = "gridColumn10";
            gridColumn10.ToolTip = "给的物品数量";
            gridColumn10.Visible = true;
            gridColumn10.VisibleIndex = 11;
            // 
            // gridColumn8
            // 
            gridColumn8.ColumnEdit = MonsterSpawnLookUpEdit;
            gridColumn8.FieldName = "MonsterSpawn";
            gridColumn8.Name = "gridColumn8";
            gridColumn8.Visible = true;
            gridColumn8.VisibleIndex = 12;
            // 
            // MonsterSpawnLookUpEdit
            // 
            MonsterSpawnLookUpEdit.AutoHeight = false;
            MonsterSpawnLookUpEdit.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            MonsterSpawnLookUpEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            MonsterSpawnLookUpEdit.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Index", "Index"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("RegionName", "Region"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("MonsterName", "Monster")});
            MonsterSpawnLookUpEdit.DisplayMember = "MonsterName";
            MonsterSpawnLookUpEdit.Name = "MonsterSpawnLookUpEdit";
            MonsterSpawnLookUpEdit.NullText = "[Spawn is null]";
            // 
            // gridColumn6
            // 
            gridColumn6.FieldName = "Effect";
            gridColumn6.Name = "gridColumn6";
            gridColumn6.Visible = true;
            gridColumn6.VisibleIndex = 13;
            // 
            // MapIconImageComboBox
            // 
            MapIconImageComboBox.AutoHeight = false;
            MapIconImageComboBox.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            MapIconImageComboBox.Name = "MapIconImageComboBox";
            // 
            // gridColumn12
            // 
            gridColumn12.FieldName = "CurrentMapBoos";
            gridColumn12.Name = "gridColumn12";
            gridColumn12.ToolTip = "是否地图内有Boss能过地图";
            gridColumn12.Visible = true;
            gridColumn12.VisibleIndex = 14;
            // 
            // gridColumn13
            // 
            gridColumn13.FieldName = "CurrentMapMon";
            gridColumn13.Name = "gridColumn13";
            gridColumn13.ToolTip = "是否地图内有怪物能过地图";
            gridColumn13.Visible = true;
            gridColumn13.VisibleIndex = 15;
            // 
            // gridColumn7
            // 
            gridColumn7.FieldName = "RequiredClass";
            gridColumn7.Name = "gridColumn7";
            gridColumn7.Visible = true;
            gridColumn7.VisibleIndex = 16;


            // 
            // 是否进地图记录玩家名字？
            // 
            Jilu.FieldName = "Jilu";
            Jilu.Name = "Jilu";
            Jilu.ToolTip = "是否记录玩家名";
            Jilu.Visible = true;
            Jilu.VisibleIndex = 17;
            // 
            // 记录文件名称
            // 
            String.FieldName = "JiluName";
            String.Name = "String";
            String.ToolTip = "记录玩家文档名";
            String.Visible = true;
            String.VisibleIndex = 18;
            // 
            // MovementInfoView
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(733, 535);
            Controls.Add(MovementGridControl);
            Controls.Add(ribbon);
            Name = "MovementInfoView";
            Ribbon = ribbon;
            Text = "Movement Info";
            ((System.ComponentModel.ISupportInitialize)(ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(MovementGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(MovementGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(MapLookUpEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(ItemLookUpEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(SpawnLookUpEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(MapIconImageComboBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(MonsterSpawnLookUpEdit)).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.BarButtonItem SaveButton;
        private DevExpress.XtraGrid.GridControl MovementGridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView MovementGridView;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit MapLookUpEdit;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox MapIconImageComboBox;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn ShifouFuben;
        private DevExpress.XtraGrid.Columns.GridColumn Zuduiguotu;
        private DevExpress.XtraGrid.Columns.GridColumn Gerenguotu;
        private DevExpress.XtraGrid.Columns.GridColumn Daysofyear;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEdit;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit SpawnLookUpEdit;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit MonsterSpawnLookUpEdit;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
        private DevExpress.XtraGrid.Columns.GridColumn Jilu;
        private DevExpress.XtraGrid.Columns.GridColumn String;


    }
}