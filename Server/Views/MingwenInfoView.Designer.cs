namespace Server.Views
{
    partial class MingwenInfoView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MingwenInfoView));
            ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            SaveButton = new DevExpress.XtraBars.BarButtonItem();
            ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            MagicImageComboBox = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            SchoolImageComboBox = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            ClassImageComboBox = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            MingwenInfoGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            gridColumn15 = new DevExpress.XtraGrid.Columns.GridColumn();
            gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            gridColumn16 = new DevExpress.XtraGrid.Columns.GridColumn();
            gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            gridColumn25 = new DevExpress.XtraGrid.Columns.GridColumn();
            gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            gridColumn17 = new DevExpress.XtraGrid.Columns.GridColumn();
            gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            gridColumn18 = new DevExpress.XtraGrid.Columns.GridColumn();
            gridColumn19 = new DevExpress.XtraGrid.Columns.GridColumn();
            gridColumn26 = new DevExpress.XtraGrid.Columns.GridColumn();
            gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
            gridColumn20 = new DevExpress.XtraGrid.Columns.GridColumn();
            MingwenInfoGridControl = new DevExpress.XtraGrid.GridControl();
            ((System.ComponentModel.ISupportInitialize)(ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(MagicImageComboBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(SchoolImageComboBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(ClassImageComboBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(MingwenInfoGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(MingwenInfoGridControl)).BeginInit();
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
            // MagicImageComboBox
            // 
            MagicImageComboBox.AutoHeight = false;
            MagicImageComboBox.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            MagicImageComboBox.Name = "MagicImageComboBox";
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
            // MingwenInfoGridView
            // 
            MingwenInfoGridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            gridColumn15,
            gridColumn1,
            gridColumn2,
            gridColumn3,
            gridColumn4,
            gridColumn16,
            gridColumn5,
            gridColumn6,
            gridColumn25,
            gridColumn13,
            gridColumn8,
            gridColumn7,
            gridColumn17,
            gridColumn9,
            gridColumn10,
            gridColumn11,
            gridColumn12,
            gridColumn18,
            gridColumn19,
            gridColumn26,
            gridColumn14,
            gridColumn20});
            MingwenInfoGridView.GridControl = MingwenInfoGridControl;
            MingwenInfoGridView.Name = "MingwenInfoGridView";
            MingwenInfoGridView.OptionsDetail.AllowExpandEmptyDetails = true;
            MingwenInfoGridView.OptionsView.EnableAppearanceEvenRow = true;
            MingwenInfoGridView.OptionsView.EnableAppearanceOddRow = true;
            MingwenInfoGridView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            MingwenInfoGridView.OptionsView.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            MingwenInfoGridView.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn15
            // 
            gridColumn15.Caption = "序号";
            gridColumn15.FieldName = "Index";
            gridColumn15.Name = "gridColumn15";
            gridColumn15.ToolTip = "序号";
            gridColumn15.OptionsColumn.AllowEdit = false;
            gridColumn15.OptionsColumn.ReadOnly = true;
            gridColumn15.Visible = true;
            gridColumn15.VisibleIndex = 0;
            // 
            // gridColumn1
            // 
            gridColumn1.Caption = "铭文";
            gridColumn1.FieldName = "Name";
            gridColumn1.Name = "gridColumn1";
            gridColumn1.ToolTip = "铭文名";
            gridColumn1.Visible = true;
            gridColumn1.VisibleIndex = 1;
            // 
            // gridColumn2
            // 
            gridColumn2.Caption = "技能";
            gridColumn2.ColumnEdit = MagicImageComboBox;
            gridColumn2.FieldName = "Magic";
            gridColumn2.Name = "gridColumn2";
            gridColumn2.ToolTip = "对应技能";
            gridColumn2.Visible = true;
            gridColumn2.VisibleIndex = 2;
            // 
            // gridColumn3
            // 
            gridColumn3.Caption = "元素";
            gridColumn3.ColumnEdit = SchoolImageComboBox;
            gridColumn3.FieldName = "School";
            gridColumn3.Name = "gridColumn3";
            gridColumn3.ToolTip = "对应元素";
            gridColumn3.Visible = true;
            gridColumn3.VisibleIndex = 3;
            // 
            // gridColumn4
            // 
            gridColumn4.Caption = "职业";
            gridColumn4.ColumnEdit = ClassImageComboBox;
            gridColumn4.FieldName = "Class";
            gridColumn4.Name = "gridColumn4";
            gridColumn4.ToolTip = "对应职业";
            gridColumn4.Visible = true;
            gridColumn4.VisibleIndex = 4;
            // 
            // gridColumn5
            // 
            gridColumn5.Caption = "概率";
            gridColumn5.FieldName = "XiGailv";
            gridColumn5.Name = "gridColumn5";
            gridColumn5.ToolTip = "铭文洗出概率";
            gridColumn5.Visible = true;
            gridColumn5.VisibleIndex = 5;
            // 
            // gridColumn16
            // 
            gridColumn16.Caption = "参数0";
            gridColumn16.FieldName = "Canshu0";
            gridColumn16.Name = "gridColumn16";
            gridColumn16.ToolTip = "铭文属性参数0";
            gridColumn16.Visible = true;
            gridColumn16.VisibleIndex = 6;
            // 
            // gridColumn6
            // 
            gridColumn6.Caption = "参数1";
            gridColumn6.FieldName = "Canshu1";
            gridColumn6.Name = "gridColumn6";
            gridColumn6.ToolTip = "铭文属性参数1";
            gridColumn6.Visible = true;
            gridColumn6.VisibleIndex = 7;
            // 
            // gridColumn7
            // 
            gridColumn7.Caption = "参数2";
            gridColumn7.FieldName = "Canshu2";
            gridColumn7.Name = "gridColumn7";
            gridColumn7.ToolTip = "铭文属性参数2";
            gridColumn7.Visible = true;
            gridColumn7.VisibleIndex = 8;
            // 
            // gridColumn13
            // 
            gridColumn13.Caption = "参数3";
            gridColumn13.FieldName = "Canshu3";
            gridColumn13.Name = "gridColumn13";
            gridColumn13.ToolTip = "铭文属性参数3";
            gridColumn13.Visible = true;
            gridColumn13.VisibleIndex = 9;
            // 
            // gridColumn8
            // 
            gridColumn8.Caption = "参数4";
            gridColumn8.FieldName = "Canshu4";
            gridColumn8.Name = "gridColumn8";
            gridColumn8.ToolTip = "铭文属性参数4";
            gridColumn8.Visible = true;
            gridColumn8.VisibleIndex = 10;
            // 
            // gridColumn17
            // 
            gridColumn17.Caption = "参数5";
            gridColumn17.FieldName = "Canshu5";
            gridColumn17.Name = "gridColumn17";
            gridColumn17.ToolTip = "铭文属性参数5";
            gridColumn17.Visible = true;
            gridColumn17.VisibleIndex = 11;
            // 
            // gridColumn9
            // 
            gridColumn9.Caption = "参数6";
            gridColumn9.FieldName = "Canshu6";
            gridColumn9.Name = "gridColumn9";
            gridColumn9.ToolTip = "铭文属性参数6(decimal)";
            gridColumn9.Visible = true;
            gridColumn9.VisibleIndex = 12;
            // 
            // gridColumn10
            // 
            gridColumn10.Caption = "参数7";
            gridColumn10.FieldName = "Canshu7";
            gridColumn10.Name = "gridColumn10";
            gridColumn10.ToolTip = "铭文属性参数7";
            gridColumn10.Visible = true;
            gridColumn10.VisibleIndex = 13;
            // 
            // gridColumn11
            // 
            gridColumn11.Caption = "参数8";
            gridColumn11.FieldName = "Canshu8";
            gridColumn11.Name = "gridColumn11";
            gridColumn11.ToolTip = "铭文属性参数8";
            gridColumn11.Visible = true;
            gridColumn11.VisibleIndex = 14;
            // 
            // gridColumn12
            // 
            gridColumn12.Caption = "参数9";
            gridColumn12.FieldName = "Canshu9";
            gridColumn12.Name = "gridColumn12";
            gridColumn12.ToolTip = "铭文属性参数9";
            gridColumn12.Visible = true;
            gridColumn12.VisibleIndex = 15;
            // 
            // gridColumn18
            // 
            gridColumn18.Caption = "参数10";
            gridColumn18.FieldName = "Canshu10";
            gridColumn18.Name = "gridColumn18";
            gridColumn18.ToolTip = "铭文属性参数10";
            gridColumn18.Visible = true;
            gridColumn18.VisibleIndex = 16;
            // 
            // gridColumn19
            // 
            gridColumn19.Caption = "参数11";
            gridColumn19.FieldName = "Canshu11";
            gridColumn19.Name = "gridColumn19";
            gridColumn19.ToolTip = "铭文属性参数11";
            gridColumn19.Visible = true;
            gridColumn19.VisibleIndex = 17;
            // 
            // gridColumn26
            // 
            gridColumn26.Caption = "参数12";
            gridColumn26.FieldName = "Canshu12";
            gridColumn26.Name = "gridColumn26";
            gridColumn26.ToolTip = "铭文属性参数12";
            gridColumn26.Visible = true;
            gridColumn26.VisibleIndex = 18;
            // 
            // gridColumn14
            // 
            gridColumn14.FieldName = "MingWenID";
            gridColumn14.Name = "gridColumn14";
            gridColumn14.Visible = true;
            gridColumn14.VisibleIndex = 20;
            // 
            // gridColumn20
            // 
            gridColumn20.Caption = "铭文解释";
            gridColumn20.FieldName = "MwJieshi";
            gridColumn20.Name = "gridColumn20";
            gridColumn20.ToolTip = "铭文解释";
            gridColumn20.Visible = true;
            gridColumn20.VisibleIndex = 21;
            // 
            // gridColumn25
            // 
            gridColumn25.Caption = "参数说明";
            gridColumn25.FieldName = "CsShuoming";
            gridColumn25.Name = "gridColumn25";
            gridColumn25.ToolTip = "铭文对应的各参数说明";
            gridColumn25.Visible = true;
            gridColumn25.VisibleIndex = 22;
            gridColumn25.Width = 110;
            // 
            // MingwenInfoGridControl
            // 
            MingwenInfoGridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            MingwenInfoGridControl.Location = new System.Drawing.Point(0, 144);
            MingwenInfoGridControl.MainView = MingwenInfoGridView;
            MingwenInfoGridControl.MenuManager = ribbon;
            MingwenInfoGridControl.Name = "MingwenInfoGridControl";
            MingwenInfoGridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            MagicImageComboBox,
            SchoolImageComboBox,
            ClassImageComboBox});
            MingwenInfoGridControl.Size = new System.Drawing.Size(896, 395);
            MingwenInfoGridControl.TabIndex = 2;
            MingwenInfoGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            MingwenInfoGridView});
            // 
            // MingwenInfoView
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(896, 539);
            Controls.Add(MingwenInfoGridControl);
            Controls.Add(ribbon);
            Name = "MingwenInfoView";
            Ribbon = ribbon;
            Text = "Ming wen Info";
            Load += new System.EventHandler(MingwenInfoView_Load);
            ((System.ComponentModel.ISupportInitialize)(ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(MagicImageComboBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(SchoolImageComboBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(ClassImageComboBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(MingwenInfoGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(MingwenInfoGridControl)).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.BarButtonItem SaveButton;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox MagicImageComboBox;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox SchoolImageComboBox;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox ClassImageComboBox;
        private DevExpress.XtraGrid.Views.Grid.GridView MingwenInfoGridView;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn15;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn16;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn25;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
        private DevExpress.XtraGrid.GridControl MingwenInfoGridControl;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn17;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn18;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn19;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn26;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn20;
    }
}