namespace Server.Views
{
    partial class FubenInfoView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MagicInfoView));
            ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            SaveButton = new DevExpress.XtraBars.BarButtonItem();
            ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            SchoolImageComboBox = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            ClassImageComboBox = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            FubenInfoGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            gridColumn15 = new DevExpress.XtraGrid.Columns.GridColumn();
            gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            //gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            MonsterLookUpEdit = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            gridColumn16 = new DevExpress.XtraGrid.Columns.GridColumn();
            gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            MapLookUpEdit = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
            gridColumn17 = new DevExpress.XtraGrid.Columns.GridColumn();
            gridColumn18 = new DevExpress.XtraGrid.Columns.GridColumn();
            gridColumn20 = new DevExpress.XtraGrid.Columns.GridColumn();
            FubenInfoGridControl = new DevExpress.XtraGrid.GridControl();
            ((System.ComponentModel.ISupportInitialize)(ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(SchoolImageComboBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(ClassImageComboBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(MonsterLookUpEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(FubenInfoGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(FubenInfoGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(MapLookUpEdit)).BeginInit();
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
            ribbon.Size = new System.Drawing.Size(896, 144);
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
            // SchoolImageComboBox
            // 
            SchoolImageComboBox.AutoHeight = false;
            SchoolImageComboBox.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            SchoolImageComboBox.Name = "SchoolImageComboBox";
            // 
            // ClassImageComboBox
            // 
            ClassImageComboBox.AutoHeight = false;
            ClassImageComboBox.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            ClassImageComboBox.Name = "ClassImageComboBox";
            // 
            // FubenInfoGridView
            // 
            FubenInfoGridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            gridColumn15,
            gridColumn1,
            gridColumn3,
            //gridColumn4,
            gridColumn11,
            gridColumn16,
            gridColumn5,
            gridColumn6,
            gridColumn12,
            gridColumn13,
            gridColumn14,
            gridColumn17,
            gridColumn18,
            gridColumn20});
            FubenInfoGridView.GridControl = FubenInfoGridControl;
            FubenInfoGridView.Name = "FubenInfoGridView";
            FubenInfoGridView.OptionsDetail.AllowExpandEmptyDetails = true;
            FubenInfoGridView.OptionsView.EnableAppearanceEvenRow = true;
            FubenInfoGridView.OptionsView.EnableAppearanceOddRow = true;
            FubenInfoGridView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            FubenInfoGridView.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn15
            // 
            gridColumn15.FieldName = "Index";
            gridColumn15.Name = "gridColumn15";
            gridColumn15.OptionsColumn.AllowEdit = false;
            gridColumn15.OptionsColumn.ReadOnly = true;
            gridColumn15.Visible = true;
            gridColumn15.VisibleIndex = 0;
            // 
            // gridColumn1
            // 
            gridColumn1.FieldName = "Name";
            gridColumn1.Name = "gridColumn1";
            gridColumn1.Visible = true;
            gridColumn1.VisibleIndex = 1;
            // 
            // gridColumn3
            // 
            gridColumn3.ColumnEdit = SchoolImageComboBox;
            gridColumn3.FieldName = "School";
            gridColumn3.Name = "gridColumn3";
            gridColumn3.Visible = true;
            gridColumn3.VisibleIndex = 2;
            // 
            // gridColumn4
            //
            /*
            gridColumn4.ColumnEdit = ClassImageComboBox;
            gridColumn4.FieldName = "Class";
            gridColumn4.Name = "gridColumn4";
            gridColumn4.Visible = true;
            gridColumn4.VisibleIndex = 4;
            */
            // 
            // gridColumn11
            // 
            gridColumn11.ColumnEdit = MonsterLookUpEdit;
            gridColumn11.FieldName = "Monster";
            gridColumn11.Name = "gridColumn11";
            gridColumn11.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            gridColumn11.SortMode = DevExpress.XtraGrid.ColumnSortMode.DisplayText;
            gridColumn11.Visible = true;
            gridColumn11.VisibleIndex = 3;
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
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("IsBoss", "IsBoss")});
            MonsterLookUpEdit.DisplayMember = "MonsterName";
            MonsterLookUpEdit.Name = "MonsterLookUpEdit";
            MonsterLookUpEdit.NullText = "[Monster is null]";
            //
            // gridColumn16
            // 
            gridColumn16.FieldName = "Icon";
            gridColumn16.Name = "gridColumn16";
            gridColumn16.Visible = true;
            gridColumn16.VisibleIndex = 4;
            // 
            // gridColumn5
            // 
            gridColumn5.FieldName = "FubenDian";
            gridColumn5.Name = "gridColumn5";
            gridColumn5.Visible = true;
            gridColumn5.VisibleIndex = 5;
            // 
            // gridColumn6
            // 
            gridColumn6.FieldName = "Level";
            gridColumn6.Name = "gridColumn6";
            gridColumn6.Visible = true;
            gridColumn6.VisibleIndex = 6;

            // 
            // gridColumn12
            // 
            gridColumn12.Caption = "JiangliDian";
            gridColumn12.FieldName = "JiangliDian";
            gridColumn12.Name = "gridColumn12";
            gridColumn12.Visible = true;
            gridColumn12.VisibleIndex = 7;
            // 
            // gridColumn13
            // 
            gridColumn13.ColumnEdit = MapLookUpEdit;
            gridColumn13.FieldName = "MapParameter1";
            gridColumn13.Name = "gridColumn13";
            gridColumn13.Visible = true;
            gridColumn13.VisibleIndex = 8;
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
            MapLookUpEdit.NullText = "";
            // 
            // gridColumn14
            // 
            gridColumn14.Caption = "Y坐标";
            gridColumn14.FieldName = "Xdian";
            gridColumn14.Name = "gridColumn14";
            gridColumn14.Visible = true;
            gridColumn14.VisibleIndex = 9;
            // 
            // gridColumn17
            // 
            gridColumn17.Caption = "Y坐标";
            gridColumn17.FieldName = "Ydian";
            gridColumn17.Name = "gridColumn17";
            gridColumn17.Visible = true;
            gridColumn17.VisibleIndex = 10;
            // 
            // gridColumn18
            // 
            gridColumn18.Caption = "需要的金币";
            gridColumn18.FieldName = "MoveGold";
            gridColumn18.Name = "gridColumn18";
            gridColumn18.Visible = true;
            gridColumn18.VisibleIndex = 11;
            // 
            // gridColumn20
            // 
            gridColumn20.FieldName = "Description";
            gridColumn20.Name = "gridColumn20";
            gridColumn20.Visible = true;
            gridColumn20.VisibleIndex = 12;
            // 
            // FubenInfoGridControl
            // 
            FubenInfoGridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            FubenInfoGridControl.Location = new System.Drawing.Point(0, 144);
            FubenInfoGridControl.MainView = FubenInfoGridView;
            FubenInfoGridControl.MenuManager = ribbon;
            FubenInfoGridControl.Name = "FubenInfoGridControl";
            FubenInfoGridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            SchoolImageComboBox,
            ClassImageComboBox,
            MonsterLookUpEdit,
            MapLookUpEdit});
            FubenInfoGridControl.Size = new System.Drawing.Size(896, 395);
            FubenInfoGridControl.TabIndex = 2;
            FubenInfoGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            FubenInfoGridView});
            // 
            // FubenInfoView
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(896, 539);
            Controls.Add(FubenInfoGridControl);
            Controls.Add(ribbon);
            Name = "FubenInfoView";
            Ribbon = ribbon;
            Text = "副本设置";
            Load += new System.EventHandler(FubenInfoView_Load);
            ((System.ComponentModel.ISupportInitialize)(ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(SchoolImageComboBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(ClassImageComboBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(MonsterLookUpEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(FubenInfoGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(FubenInfoGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(MapLookUpEdit)).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.BarButtonItem SaveButton;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox SchoolImageComboBox;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox ClassImageComboBox;
        private DevExpress.XtraGrid.Views.Grid.GridView FubenInfoGridView;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn15;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        //private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit MonsterLookUpEdit;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn16;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.GridControl FubenInfoGridControl;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit MapLookUpEdit;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn17;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn18;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn20;
    }
}