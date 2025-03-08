namespace Server.Views
{
    partial class StoreInfoView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StoreInfoView));
            ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            SaveButton = new DevExpress.XtraBars.BarButtonItem();
            ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            StoreInfoGridControl = new DevExpress.XtraGrid.GridControl();
            StoreInfoGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            ItemLookUpEdit = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(StoreInfoGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(StoreInfoGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(ItemLookUpEdit)).BeginInit();
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
            ribbon.Size = new System.Drawing.Size(718, 143);
            // 
            // SaveButton
            // 
            SaveButton.Caption = "Save Database";
            SaveButton.Id = 1;
            SaveButton.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("SaveButton.ImageOptions.Image")));
            SaveButton.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("SaveButton.ImageOptions.LargeImage")));
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
            // StoreInfoGridControl
            // 
            StoreInfoGridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            StoreInfoGridControl.Location = new System.Drawing.Point(0, 143);
            StoreInfoGridControl.MainView = StoreInfoGridView;
            StoreInfoGridControl.MenuManager = ribbon;
            StoreInfoGridControl.Name = "StoreInfoGridControl";
            StoreInfoGridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            ItemLookUpEdit});
            StoreInfoGridControl.ShowOnlyPredefinedDetails = true;
            StoreInfoGridControl.Size = new System.Drawing.Size(718, 355);
            StoreInfoGridControl.TabIndex = 2;
            StoreInfoGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            StoreInfoGridView});
            // 
            // StoreInfoGridView
            // 
            StoreInfoGridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            gridColumn1,
            gridColumn2,
            gridColumn6,
            gridColumn3,
            gridColumn4,
            gridColumn5});
            StoreInfoGridView.GridControl = StoreInfoGridControl;
            StoreInfoGridView.Name = "StoreInfoGridView";
            StoreInfoGridView.OptionsView.EnableAppearanceEvenRow = true;
            StoreInfoGridView.OptionsView.EnableAppearanceOddRow = true;
            StoreInfoGridView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            StoreInfoGridView.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            gridColumn1.ColumnEdit = ItemLookUpEdit;
            gridColumn1.FieldName = "Item";
            gridColumn1.Name = "gridColumn1";
            gridColumn1.Visible = true;
            gridColumn1.VisibleIndex = 0;
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
            // gridColumn2
            // 
            gridColumn2.FieldName = "Price";
            gridColumn2.Name = "gridColumn2";
            gridColumn2.Visible = true;
            gridColumn2.VisibleIndex = 1;
            // 
            // gridColumn6
            // 
            gridColumn6.FieldName = "HuntGoldPrice";
            gridColumn6.Name = "gridColumn6";
            gridColumn6.Visible = true;
            gridColumn6.VisibleIndex = 2;
            // 
            // gridColumn3
            // 
            gridColumn3.FieldName = "Filter";
            gridColumn3.Name = "gridColumn3";
            gridColumn3.Visible = true;
            gridColumn3.VisibleIndex = 3;
            // 
            // gridColumn4
            // 
            gridColumn4.FieldName = "Available";
            gridColumn4.Name = "gridColumn4";
            gridColumn4.Visible = true;
            gridColumn4.VisibleIndex = 4;
            // 
            // gridColumn5
            // 
            gridColumn5.FieldName = "Duration";
            gridColumn5.Name = "gridColumn5";
            gridColumn5.Visible = true;
            gridColumn5.VisibleIndex = 5;
            // 
            // StoreInfoView
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(718, 498);
            Controls.Add(StoreInfoGridControl);
            Controls.Add(ribbon);
            Name = "StoreInfoView";
            Ribbon = ribbon;
            Text = "StoreInfoView";
            ((System.ComponentModel.ISupportInitialize)(ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(StoreInfoGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(StoreInfoGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(ItemLookUpEdit)).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.BarButtonItem SaveButton;
        private DevExpress.XtraGrid.GridControl StoreInfoGridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView StoreInfoGridView;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEdit;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
    }
}