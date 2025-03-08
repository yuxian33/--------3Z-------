namespace Server.Views
{
    partial class DropInfoView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DropInfoView));
            ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            SavingButton = new DevExpress.XtraBars.BarButtonItem();
            ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            DropInfoGridControl = new DevExpress.XtraGrid.GridControl();
            DropInfoGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            MonsterLookUpEdit = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            ItemLookUpEdit = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            DuliChance = new DevExpress.XtraGrid.Columns.GridColumn();
            Duli = new DevExpress.XtraGrid.Columns.GridColumn();
            gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(DropInfoGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(DropInfoGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(MonsterLookUpEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(ItemLookUpEdit)).BeginInit();
            SuspendLayout();
            // 
            // ribbon
            // 
            ribbon.ExpandCollapseItem.Id = 0;
            ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            ribbon.ExpandCollapseItem,
            SavingButton});
            ribbon.Location = new System.Drawing.Point(0, 0);
            ribbon.MaxItemId = 2;
            ribbon.Name = "ribbon";
            ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            ribbonPage1});
            ribbon.Size = new System.Drawing.Size(706, 143);
            // 
            // SavingButton
            // 
            SavingButton.Caption = "Save Database";
            SavingButton.Glyph = ((System.Drawing.Image)(resources.GetObject("SavingButton.Glyph")));
            SavingButton.Id = 1;
            SavingButton.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("SavingButton.LargeGlyph")));
            SavingButton.LargeWidth = 60;
            SavingButton.Name = "SavingButton";
            SavingButton.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(SavingButton_ItemClick);
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
            ribbonPageGroup1.ItemLinks.Add(SavingButton);
            ribbonPageGroup1.Name = "ribbonPageGroup1";
            ribbonPageGroup1.ShowCaptionButton = false;
            ribbonPageGroup1.Text = "Saving";
            // 
            // DropInfoGridControl
            // 
            DropInfoGridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            DropInfoGridControl.Location = new System.Drawing.Point(0, 143);
            DropInfoGridControl.MainView = DropInfoGridView;
            DropInfoGridControl.MenuManager = ribbon;
            DropInfoGridControl.Name = "DropInfoGridControl";
            DropInfoGridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            MonsterLookUpEdit,
            ItemLookUpEdit});
            DropInfoGridControl.Size = new System.Drawing.Size(706, 439);
            DropInfoGridControl.TabIndex = 1;
            DropInfoGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            DropInfoGridView});
            // 
            // DropInfoGridView
            // 
            DropInfoGridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            gridColumn1,
            gridColumn2,
            gridColumn3,
            DuliChance,
            Duli,
            gridColumn4,
            gridColumn5,
            gridColumn6,
            gridColumn7,
            gridColumn8});
            DropInfoGridView.GridControl = DropInfoGridControl;
            DropInfoGridView.Name = "DropInfoGridView";
            DropInfoGridView.OptionsView.EnableAppearanceEvenRow = true;
            DropInfoGridView.OptionsView.EnableAppearanceOddRow = true;
            DropInfoGridView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            DropInfoGridView.OptionsView.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            DropInfoGridView.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            gridColumn1.ColumnEdit = MonsterLookUpEdit;
            gridColumn1.FieldName = "Monster";
            gridColumn1.Name = "gridColumn1";
            gridColumn1.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            gridColumn1.SortMode = DevExpress.XtraGrid.ColumnSortMode.DisplayText;
            gridColumn1.Visible = true;
            gridColumn1.VisibleIndex = 0;
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
            // gridColumn2
            // 
            gridColumn2.ColumnEdit = ItemLookUpEdit;
            gridColumn2.FieldName = "Item";
            gridColumn2.Name = "gridColumn2";
            gridColumn2.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            gridColumn2.SortMode = DevExpress.XtraGrid.ColumnSortMode.DisplayText;
            gridColumn2.Visible = true;
            gridColumn2.VisibleIndex = 1;
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
            // gridColumn3
            // 
            gridColumn3.FieldName = "Chance";
            gridColumn3.Name = "gridColumn3";
            gridColumn3.Visible = true;
            gridColumn3.VisibleIndex = 2;
            // 
            // 独立爆率（不影响爆率加成）
            // 
            DuliChance.FieldName = "DuliChance";
            DuliChance.Name = "DuliChance";
            DuliChance.ToolTip = "独立Chance（不影响爆率加成）";
            DuliChance.Visible = true;
            DuliChance.VisibleIndex = 3;
            // 
            // 是否执行独立爆率
            // 
            Duli.FieldName = "Duli";
            Duli.Name = "Duli";
            Duli.ToolTip = "是否独立爆率（不影响爆率加成）";
            Duli.Visible = true;
            Duli.VisibleIndex = 4;
            // 
            // gridColumn4
            // 
            gridColumn4.FieldName = "Amount";
            gridColumn4.Name = "gridColumn4";
            gridColumn4.Visible = true;
            gridColumn4.VisibleIndex = 5;
            // 
            // gridColumn5
            // 
            gridColumn5.FieldName = "DropSet";
            gridColumn5.Name = "gridColumn5";
            gridColumn5.Visible = true;
            gridColumn5.VisibleIndex = 6;
            // 
            // gridColumn6
            // 
            gridColumn6.FieldName = "PartOnly";
            gridColumn6.Name = "gridColumn6";
            gridColumn6.Visible = true;
            gridColumn6.VisibleIndex = 7;
            // 
            // gridColumn7
            // 
            gridColumn7.FieldName = "EasterEvent";
            gridColumn7.Name = "gridColumn7";
            gridColumn7.Visible = true;
            gridColumn7.VisibleIndex = 8;
            // 
            // 圣诞节活动爆率
            // 
            gridColumn8.FieldName = "圣诞节活动";
            gridColumn8.Name = "gridColumn8";
            gridColumn8.Visible = true;
            gridColumn8.VisibleIndex = 9;
            // 
            // DropInfoView
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(706, 582);
            Controls.Add(DropInfoGridControl);
            Controls.Add(ribbon);
            Name = "DropInfoView";
            Ribbon = ribbon;
            Text = "Drop Info View";
            ((System.ComponentModel.ISupportInitialize)(ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(DropInfoGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(DropInfoGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(MonsterLookUpEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(ItemLookUpEdit)).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.BarButtonItem SavingButton;
        private DevExpress.XtraGrid.GridControl DropInfoGridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView DropInfoGridView;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit MonsterLookUpEdit;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEdit;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn DuliChance;
        private DevExpress.XtraGrid.Columns.GridColumn Duli;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
    }
}