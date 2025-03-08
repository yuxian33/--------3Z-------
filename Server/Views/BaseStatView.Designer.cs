namespace Server.Views
{
    partial class BaseStatView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseStatView));
            ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            SaveButton = new DevExpress.XtraBars.BarButtonItem();
            ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            BaseStatGridControl = new DevExpress.XtraGrid.GridControl();
            BaseStatGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
            gridColumn15 = new DevExpress.XtraGrid.Columns.GridColumn();
            gridColumn16 = new DevExpress.XtraGrid.Columns.GridColumn();
            gridColumn17 = new DevExpress.XtraGrid.Columns.GridColumn();
            gridColumn18 = new DevExpress.XtraGrid.Columns.GridColumn();
            gridColumn19 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(BaseStatGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(BaseStatGridView)).BeginInit();
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
            ribbon.Size = new System.Drawing.Size(631, 144);
            // 
            // SaveButton
            // 
            SaveButton.Caption = "Save Databasse";
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
            // BaseStatGridControl
            // 
            BaseStatGridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            BaseStatGridControl.Location = new System.Drawing.Point(0, 144);
            BaseStatGridControl.MainView = BaseStatGridView;
            BaseStatGridControl.MenuManager = ribbon;
            BaseStatGridControl.Name = "BaseStatGridControl";
            BaseStatGridControl.Size = new System.Drawing.Size(631, 290);
            BaseStatGridControl.TabIndex = 2;
            BaseStatGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            BaseStatGridView});
            // 
            // BaseStatGridView
            // 
            BaseStatGridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            gridColumn1,
            gridColumn2,
            gridColumn3,
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
            gridColumn14,
            gridColumn15,
            gridColumn16,
            gridColumn17,
            gridColumn18,
            gridColumn19});
            BaseStatGridView.GridControl = BaseStatGridControl;
            BaseStatGridView.GroupCount = 1;
            BaseStatGridView.Name = "BaseStatGridView";
            BaseStatGridView.OptionsView.EnableAppearanceEvenRow = true;
            BaseStatGridView.OptionsView.EnableAppearanceOddRow = true;
            BaseStatGridView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            BaseStatGridView.OptionsView.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            BaseStatGridView.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(gridColumn1, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // gridColumn1
            // 
            gridColumn1.FieldName = "Class";
            gridColumn1.Name = "gridColumn1";
            gridColumn1.Visible = true;
            gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn2
            // 
            gridColumn2.FieldName = "Level";
            gridColumn2.Name = "gridColumn2";
            gridColumn2.Visible = true;
            gridColumn2.VisibleIndex = 0;
            // 
            // gridColumn3
            // 
            gridColumn3.FieldName = "Health";
            gridColumn3.Name = "gridColumn3";
            gridColumn3.Visible = true;
            gridColumn3.VisibleIndex = 1;
            // 
            // gridColumn4
            // 
            gridColumn4.FieldName = "Mana";
            gridColumn4.Name = "gridColumn4";
            gridColumn4.Visible = true;
            gridColumn4.VisibleIndex = 2;
            // 
            // gridColumn5
            // 
            gridColumn5.FieldName = "BagWeight";
            gridColumn5.Name = "gridColumn5";
            gridColumn5.Visible = true;
            gridColumn5.VisibleIndex = 3;
            // 
            // gridColumn6
            // 
            gridColumn6.FieldName = "WearWeight";
            gridColumn6.Name = "gridColumn6";
            gridColumn6.Visible = true;
            gridColumn6.VisibleIndex = 4;
            // 
            // gridColumn7
            // 
            gridColumn7.FieldName = "HandWeight";
            gridColumn7.Name = "gridColumn7";
            gridColumn7.Visible = true;
            gridColumn7.VisibleIndex = 5;
            // 
            // gridColumn8
            // 
            gridColumn8.FieldName = "Accuracy";
            gridColumn8.Name = "gridColumn8";
            gridColumn8.Visible = true;
            gridColumn8.VisibleIndex = 6;
            // 
            // gridColumn9
            // 
            gridColumn9.FieldName = "Agility";
            gridColumn9.Name = "gridColumn9";
            gridColumn9.Visible = true;
            gridColumn9.VisibleIndex = 7;
            // 
            // gridColumn10
            // 
            gridColumn10.FieldName = "MinAC";
            gridColumn10.Name = "gridColumn10";
            gridColumn10.Visible = true;
            gridColumn10.VisibleIndex = 8;
            // 
            // gridColumn11
            // 
            gridColumn11.FieldName = "MaxAC";
            gridColumn11.Name = "gridColumn11";
            gridColumn11.Visible = true;
            gridColumn11.VisibleIndex = 9;
            // 
            // gridColumn12
            // 
            gridColumn12.FieldName = "MinMR";
            gridColumn12.Name = "gridColumn12";
            gridColumn12.Visible = true;
            gridColumn12.VisibleIndex = 10;
            // 
            // gridColumn13
            // 
            gridColumn13.FieldName = "MaxMR";
            gridColumn13.Name = "gridColumn13";
            gridColumn13.Visible = true;
            gridColumn13.VisibleIndex = 11;
            // 
            // gridColumn14
            // 
            gridColumn14.FieldName = "MinDC";
            gridColumn14.Name = "gridColumn14";
            gridColumn14.Visible = true;
            gridColumn14.VisibleIndex = 12;
            // 
            // gridColumn15
            // 
            gridColumn15.FieldName = "MaxDC";
            gridColumn15.Name = "gridColumn15";
            gridColumn15.Visible = true;
            gridColumn15.VisibleIndex = 13;
            // 
            // gridColumn16
            // 
            gridColumn16.FieldName = "MinMC";
            gridColumn16.Name = "gridColumn16";
            gridColumn16.Visible = true;
            gridColumn16.VisibleIndex = 14;
            // 
            // gridColumn17
            // 
            gridColumn17.FieldName = "MaxMC";
            gridColumn17.Name = "gridColumn17";
            gridColumn17.Visible = true;
            gridColumn17.VisibleIndex = 15;
            // 
            // gridColumn18
            // 
            gridColumn18.FieldName = "MinSC";
            gridColumn18.Name = "gridColumn18";
            gridColumn18.Visible = true;
            gridColumn18.VisibleIndex = 16;
            // 
            // gridColumn19
            // 
            gridColumn19.FieldName = "MaxSC";
            gridColumn19.Name = "gridColumn19";
            gridColumn19.Visible = true;
            gridColumn19.VisibleIndex = 17;
            // 
            // BaseStatView
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(631, 434);
            Controls.Add(BaseStatGridControl);
            Controls.Add(ribbon);
            Name = "BaseStatView";
            Ribbon = ribbon;
            Text = "BaseStatView";
            ((System.ComponentModel.ISupportInitialize)(ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(BaseStatGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(BaseStatGridView)).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.BarButtonItem SaveButton;
        private DevExpress.XtraGrid.GridControl BaseStatGridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView BaseStatGridView;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn15;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn16;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn17;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn18;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn19;
    }
}