namespace Server.Views
{
    partial class EventInfoView
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
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            DevExpress.XtraGrid.GridLevelNode gridLevelNode2 = new DevExpress.XtraGrid.GridLevelNode();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EventInfoView));
            TargetsGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            MonsterLookUpEdit = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            Shijiannpc = new DevExpress.XtraGrid.Columns.GridColumn();
            NPCLookUpEdit = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            EventInfoGridControl = new DevExpress.XtraGrid.GridControl();
            ActionsGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            RespawnLookUpEdit = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            RegionLookUpEdit = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            MapLookUpEdit = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            SpawnNpc = new DevExpress.XtraGrid.Columns.GridColumn();
            zuobiaox = new DevExpress.XtraGrid.Columns.GridColumn();
            zuobiaoy = new DevExpress.XtraGrid.Columns.GridColumn();
            EventInfoGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            SaveButton = new DevExpress.XtraBars.BarButtonItem();
            ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(TargetsGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(NPCLookUpEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(MonsterLookUpEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(EventInfoGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(ActionsGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(RespawnLookUpEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(RegionLookUpEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(MapLookUpEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(EventInfoGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(ribbon)).BeginInit();
            SuspendLayout();
            // 
            // TargetsGridView
            // 
            TargetsGridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            gridColumn5,
            gridColumn12,
            gridColumn3,
            Shijiannpc});
            TargetsGridView.GridControl = EventInfoGridControl;
            TargetsGridView.Name = "TargetsGridView";
            TargetsGridView.OptionsView.EnableAppearanceEvenRow = true;
            TargetsGridView.OptionsView.EnableAppearanceOddRow = true;
            TargetsGridView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            TargetsGridView.OptionsView.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            TargetsGridView.OptionsView.ShowGroupPanel = false;
            // 
            // 事件NPC
            // 
            Shijiannpc.ColumnEdit = NPCLookUpEdit;
            Shijiannpc.FieldName = "NPC";
            Shijiannpc.Name = "Shijiannpc";
            Shijiannpc.Visible = true;
            Shijiannpc.VisibleIndex = 1;
            // 
            // NPCLookUpEdit
            // 
            NPCLookUpEdit.AutoHeight = false;
            NPCLookUpEdit.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            NPCLookUpEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            NPCLookUpEdit.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Index", "Index"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("NPCName", "NPC Name"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("RegionName", "Region Name")});
            NPCLookUpEdit.DisplayMember = "RegionName";
            NPCLookUpEdit.Name = "NPCLookUpEdit";
            NPCLookUpEdit.NullText = "[NPC is null]";
            // 
            // gridColumn5
            // 
            gridColumn5.ColumnEdit = MonsterLookUpEdit;
            gridColumn5.FieldName = "Monster";
            gridColumn5.Name = "gridColumn5";
            gridColumn5.Visible = true;
            gridColumn5.VisibleIndex = 0;
            // 
            // MonsterLookUpEdit
            // 
            MonsterLookUpEdit.AutoHeight = false;
            MonsterLookUpEdit.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            MonsterLookUpEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            MonsterLookUpEdit.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Index", "Index"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("MonsterName", "Monster Name"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("AI", "AI"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Level", "Level"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Experience", "Experience"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("IsBoss", "Is Boss")});
            MonsterLookUpEdit.DisplayMember = "MonsterName";
            MonsterLookUpEdit.Name = "MonsterLookUpEdit";
            MonsterLookUpEdit.NullText = "[Monster is null]";
            // 
            // gridColumn3
            // 
            gridColumn3.FieldName = "Value";
            gridColumn3.Name = "gridColumn3";
            gridColumn3.Visible = true;
            gridColumn3.VisibleIndex = 3;
            // 
            // EventInfoGridControl
            // 
            EventInfoGridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            gridLevelNode1.LevelTemplate = TargetsGridView;
            gridLevelNode1.RelationName = "Targets";
            gridLevelNode2.LevelTemplate = ActionsGridView;
            gridLevelNode2.RelationName = "Actions";
            EventInfoGridControl.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1,
            gridLevelNode2});
            EventInfoGridControl.Location = new System.Drawing.Point(0, 143);
            EventInfoGridControl.MainView = EventInfoGridView;
            EventInfoGridControl.MenuManager = ribbon;
            EventInfoGridControl.Name = "EventInfoGridControl";
            EventInfoGridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            NPCLookUpEdit,
            MonsterLookUpEdit,
            RespawnLookUpEdit,
            RegionLookUpEdit,
            MapLookUpEdit});
            EventInfoGridControl.ShowOnlyPredefinedDetails = true;
            EventInfoGridControl.Size = new System.Drawing.Size(742, 381);
            EventInfoGridControl.TabIndex = 2;
            EventInfoGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            ActionsGridView,
            EventInfoGridView,
            TargetsGridView});
            // 
            // ActionsGridView
            // 
            ActionsGridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            gridColumn4,
            gridColumn6,
            gridColumn7,
            gridColumn8,
            gridColumn9,
            gridColumn10,
            gridColumn11,
            SpawnNpc,
            zuobiaox,
            zuobiaoy});
            ActionsGridView.GridControl = EventInfoGridControl;
            ActionsGridView.Name = "ActionsGridView";
            ActionsGridView.OptionsView.EnableAppearanceEvenRow = true;
            ActionsGridView.OptionsView.EnableAppearanceOddRow = true;
            ActionsGridView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            ActionsGridView.OptionsView.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            ActionsGridView.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn4
            // 
            gridColumn4.FieldName = "TriggerValue";
            gridColumn4.Name = "gridColumn4";
            gridColumn4.Visible = true;
            gridColumn4.VisibleIndex = 0;
            gridColumn4.Width = 103;
            // 
            // gridColumn6
            // 
            gridColumn6.FieldName = "Type";
            gridColumn6.Name = "gridColumn6";
            gridColumn6.Visible = true;
            gridColumn6.VisibleIndex = 1;
            gridColumn6.Width = 103;
            // 
            // gridColumn7
            // 
            gridColumn7.FieldName = "StringParameter1";
            gridColumn7.Name = "gridColumn7";
            gridColumn7.Visible = true;
            gridColumn7.VisibleIndex = 2;
            gridColumn7.Width = 103;
            // 
            // gridColumn8
            // 
            gridColumn8.ColumnEdit = MonsterLookUpEdit;
            gridColumn8.FieldName = "MonsterParameter1";
            gridColumn8.Name = "gridColumn8";
            gridColumn8.Visible = true;
            gridColumn8.VisibleIndex = 3;
            gridColumn8.Width = 103;
            // 
            // gridColumn9
            // 
            gridColumn9.ColumnEdit = RespawnLookUpEdit;
            gridColumn9.FieldName = "RespawnParameter1";
            gridColumn9.Name = "gridColumn9";
            gridColumn9.Visible = true;
            gridColumn9.VisibleIndex = 4;
            gridColumn9.Width = 87;
            // 
            // RespawnLookUpEdit
            // 
            RespawnLookUpEdit.AutoHeight = false;
            RespawnLookUpEdit.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            RespawnLookUpEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            RespawnLookUpEdit.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Index", "Index"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("RegionName", "Region"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("MonsterName", "Monster")});
            RespawnLookUpEdit.DisplayMember = "RegionName";
            RespawnLookUpEdit.Name = "RespawnLookUpEdit";
            RespawnLookUpEdit.NullText = "[Respawn is null]";
            // 
            // gridColumn10
            // 
            gridColumn10.ColumnEdit = RegionLookUpEdit;
            gridColumn10.FieldName = "RegionParameter1";
            gridColumn10.Name = "gridColumn10";
            gridColumn10.Visible = true;
            gridColumn10.VisibleIndex = 5;
            gridColumn10.Width = 110;
            // 
            // RegionLookUpEdit
            // 
            RegionLookUpEdit.AutoHeight = false;
            RegionLookUpEdit.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            RegionLookUpEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            RegionLookUpEdit.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ServerDescription", "Description")});
            RegionLookUpEdit.DisplayMember = "ServerDescription";
            RegionLookUpEdit.Name = "RegionLookUpEdit";
            RegionLookUpEdit.NullText = "[Region is null]";
            // 
            // gridColumn11
            // 
            gridColumn11.ColumnEdit = MapLookUpEdit;
            gridColumn11.FieldName = "MapParameter1";
            gridColumn11.Name = "gridColumn11";
            gridColumn11.Visible = true;
            gridColumn11.VisibleIndex = 6;
            gridColumn11.Width = 115;
            // 
            // MapLookUpEdit
            // 
            MapLookUpEdit.AutoHeight = false;
            MapLookUpEdit.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            MapLookUpEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            MapLookUpEdit.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Index", "Index"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("FileName", "File Name"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Description", "Description")});
            MapLookUpEdit.DisplayMember = "Description";
            MapLookUpEdit.Name = "MapLookUpEdit";
            MapLookUpEdit.NullText = "[Map is null]";
            // 
            // 刷出来NPC
            // 
            SpawnNpc.FieldName = "SpawnNpc";
            SpawnNpc.Name = "SpawnNpc";
            SpawnNpc.Visible = true;
            SpawnNpc.VisibleIndex = 7;
            SpawnNpc.Width = 53;
            // 
            // 坐标X
            // 
            zuobiaox.FieldName = "IntParameter1";
            zuobiaox.Name = "IntParameter1";
            zuobiaox.Visible = true;
            zuobiaox.VisibleIndex = 8;
            zuobiaox.Width = 53;
            // 
            // 坐标Y 
            // 
            zuobiaoy.FieldName = "IntParameter2";
            zuobiaoy.Name = "IntParameter2";
            zuobiaoy.Visible = true;
            zuobiaoy.VisibleIndex = 9;
            zuobiaoy.Width = 53;
            // 
            // EventInfoGridView
            // 
            EventInfoGridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            gridColumn1,
            gridColumn2});
            EventInfoGridView.GridControl = EventInfoGridControl;
            EventInfoGridView.Name = "EventInfoGridView";
            EventInfoGridView.OptionsDetail.AllowExpandEmptyDetails = true;
            EventInfoGridView.OptionsView.EnableAppearanceEvenRow = true;
            EventInfoGridView.OptionsView.EnableAppearanceOddRow = true;
            EventInfoGridView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            EventInfoGridView.OptionsView.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            EventInfoGridView.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            gridColumn1.FieldName = "Description";
            gridColumn1.Name = "gridColumn1";
            gridColumn1.Visible = true;
            gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn2
            // 
            gridColumn2.FieldName = "MaxValue";
            gridColumn2.Name = "gridColumn2";
            gridColumn2.Visible = true;
            gridColumn2.VisibleIndex = 1;
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
            ribbon.Size = new System.Drawing.Size(742, 143);
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
            // gridColumn12
            // 
            gridColumn12.FieldName = "DropSet";
            gridColumn12.Name = "gridColumn12";
            gridColumn12.Visible = true;
            gridColumn12.VisibleIndex = 2;
            // 
            // EventInfoView
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(742, 524);
            Controls.Add(EventInfoGridControl);
            Controls.Add(ribbon);
            Name = "EventInfoView";
            Ribbon = ribbon;
            Text = "EventInfoView";
            ((System.ComponentModel.ISupportInitialize)(TargetsGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(NPCLookUpEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(MonsterLookUpEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(EventInfoGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(ActionsGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(RespawnLookUpEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(RegionLookUpEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(MapLookUpEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(EventInfoGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(ribbon)).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.BarButtonItem SaveButton;
        private DevExpress.XtraGrid.GridControl EventInfoGridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView TargetsGridView;
        private DevExpress.XtraGrid.Views.Grid.GridView ActionsGridView;
        private DevExpress.XtraGrid.Views.Grid.GridView EventInfoGridView;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn Shijiannpc;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit NPCLookUpEdit;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit MonsterLookUpEdit;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit RespawnLookUpEdit;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit RegionLookUpEdit;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit MapLookUpEdit;
        private DevExpress.XtraGrid.Columns.GridColumn SpawnNpc;
        private DevExpress.XtraGrid.Columns.GridColumn zuobiaox;
        private DevExpress.XtraGrid.Columns.GridColumn zuobiaoy;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
    }
}