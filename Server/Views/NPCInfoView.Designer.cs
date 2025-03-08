namespace Server.Views
{
    partial class NPCInfoView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NPCInfoView));
            ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            SaveButton = new DevExpress.XtraBars.BarButtonItem();
            ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            NPCInfoGridControl = new DevExpress.XtraGrid.GridControl();
            NPCInfoGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            colNPCName = new DevExpress.XtraGrid.Columns.GridColumn();
            colImage = new DevExpress.XtraGrid.Columns.GridColumn();
            colIndex = new DevExpress.XtraGrid.Columns.GridColumn();
            colEntryPage = new DevExpress.XtraGrid.Columns.GridColumn();
            PageLookUpEdit = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            RegionLookUpEdit = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(NPCInfoGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(NPCInfoGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(PageLookUpEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(RegionLookUpEdit)).BeginInit();
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
            ribbon.Size = new System.Drawing.Size(736, 144);
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
            // NPCInfoGridControl
            // 
            NPCInfoGridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            NPCInfoGridControl.Location = new System.Drawing.Point(0, 144);
            NPCInfoGridControl.MainView = NPCInfoGridView;
            NPCInfoGridControl.MenuManager = ribbon;
            NPCInfoGridControl.Name = "NPCInfoGridControl";
            NPCInfoGridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            RegionLookUpEdit,
            PageLookUpEdit});
            NPCInfoGridControl.ShowOnlyPredefinedDetails = true;
            NPCInfoGridControl.Size = new System.Drawing.Size(736, 427);
            NPCInfoGridControl.TabIndex = 2;
            NPCInfoGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            NPCInfoGridView});
            // 
            // NPCInfoGridView
            // 
            NPCInfoGridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            colNPCName,
            colImage,
            colEntryPage,
            gridColumn1,
            colIndex,});
            NPCInfoGridView.GridControl = NPCInfoGridControl;
            NPCInfoGridView.Name = "NPCInfoGridView";
            NPCInfoGridView.OptionsDetail.AllowExpandEmptyDetails = true;
            NPCInfoGridView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            NPCInfoGridView.OptionsView.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            NPCInfoGridView.OptionsView.ShowGroupPanel = false;
            // 
            // colNPCName
            // 
            colNPCName.FieldName = "NPCName";
            colNPCName.Name = "colNPCName";
            colNPCName.Visible = true;
            colNPCName.VisibleIndex = 2;
            // 
            // colImage
            // 
            colImage.FieldName = "Image";
            colImage.Name = "colImage";
            colImage.Visible = true;
            colImage.VisibleIndex = 3;
            // 
            // colEntryPage
            // 
            colEntryPage.ColumnEdit = PageLookUpEdit;
            colEntryPage.FieldName = "EntryPage";
            colEntryPage.Name = "colEntryPage";
            colEntryPage.Visible = true;
            colEntryPage.VisibleIndex = 4;
            // 
            // colIndex
            // 
            colIndex.FieldName = "Index";
            colIndex.Name = "colIndex";
            colIndex.Visible = true;
            colIndex.Width = 48;
            colIndex.VisibleIndex = 0;
            // 
            // PageLookUpEdit
            // 
            PageLookUpEdit.AutoHeight = false;
            PageLookUpEdit.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            PageLookUpEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            PageLookUpEdit.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Index", "Index"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Description", "Description"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DialogType", "DialogType"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Say", "Say")});
            PageLookUpEdit.DisplayMember = "Description";
            PageLookUpEdit.Name = "PageLookUpEdit";
            PageLookUpEdit.NullText = "[Page is null]";
            // 
            // gridColumn1
            // 
            gridColumn1.ColumnEdit = RegionLookUpEdit;
            gridColumn1.FieldName = "Region";
            gridColumn1.Name = "gridColumn1";
            gridColumn1.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            gridColumn1.SortMode = DevExpress.XtraGrid.ColumnSortMode.DisplayText;
            gridColumn1.Visible = true;
            gridColumn1.VisibleIndex = 1;
            // 
            // RegionLookUpEdit
            // 
            RegionLookUpEdit.AutoHeight = false;
            RegionLookUpEdit.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            RegionLookUpEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            RegionLookUpEdit.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Index", "Index"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ServerDescription", "Server Description"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Size", "Size")});
            RegionLookUpEdit.DisplayMember = "ServerDescription";
            RegionLookUpEdit.Name = "RegionLookUpEdit";
            RegionLookUpEdit.NullText = "[Region is null]";
            // 
            // NPCInfoView
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(736, 571);
            Controls.Add(NPCInfoGridControl);
            Controls.Add(ribbon);
            Name = "NPCInfoView";
            Ribbon = ribbon;
            Text = "NPC Info";
            ((System.ComponentModel.ISupportInitialize)(ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(NPCInfoGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(NPCInfoGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(PageLookUpEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(RegionLookUpEdit)).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.BarButtonItem SaveButton;
        private DevExpress.XtraGrid.GridControl NPCInfoGridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView NPCInfoGridView;
        private DevExpress.XtraGrid.Columns.GridColumn colNPCName;
        private DevExpress.XtraGrid.Columns.GridColumn colImage;
        private DevExpress.XtraGrid.Columns.GridColumn colIndex;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit RegionLookUpEdit;
        private DevExpress.XtraGrid.Columns.GridColumn colEntryPage;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit PageLookUpEdit;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
    }
}