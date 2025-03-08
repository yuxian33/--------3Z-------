namespace Server.Views
{
    partial class SetInfoView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SetInfoView));
            SetStatsGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            StatImageComboBox = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            RequiredClassImageComboBox = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            SetInfoGridControl = new DevExpress.XtraGrid.GridControl();
            SetInfoGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            SaveDatabaseButton = new DevExpress.XtraBars.BarButtonItem();
            ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ((System.ComponentModel.ISupportInitialize)(SetStatsGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(StatImageComboBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(RequiredClassImageComboBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(SetInfoGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(SetInfoGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(ribbon)).BeginInit();
            SuspendLayout();
            // 
            // SetStatsGridView
            // 
            SetStatsGridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            gridColumn2,
            gridColumn3,
            gridColumn4,
            gridColumn5});
            SetStatsGridView.GridControl = SetInfoGridControl;
            SetStatsGridView.Name = "SetStatsGridView";
            SetStatsGridView.OptionsView.EnableAppearanceEvenRow = true;
            SetStatsGridView.OptionsView.EnableAppearanceOddRow = true;
            SetStatsGridView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            SetStatsGridView.OptionsView.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            SetStatsGridView.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn2
            // 
            gridColumn2.ColumnEdit = StatImageComboBox;
            gridColumn2.FieldName = "Stat";
            gridColumn2.Name = "gridColumn2";
            gridColumn2.Visible = true;
            gridColumn2.VisibleIndex = 0;
            // 
            // StatImageComboBox
            // 
            StatImageComboBox.AutoHeight = false;
            StatImageComboBox.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            StatImageComboBox.Name = "StatImageComboBox";
            // 
            // gridColumn3
            // 
            gridColumn3.FieldName = "Amount";
            gridColumn3.Name = "gridColumn3";
            gridColumn3.Visible = true;
            gridColumn3.VisibleIndex = 1;
            // 
            // gridColumn4
            // 
            gridColumn4.ColumnEdit = RequiredClassImageComboBox;
            gridColumn4.FieldName = "Class";
            gridColumn4.Name = "gridColumn4";
            gridColumn4.Visible = true;
            gridColumn4.VisibleIndex = 2;
            // 
            // RequiredClassImageComboBox
            // 
            RequiredClassImageComboBox.AutoHeight = false;
            RequiredClassImageComboBox.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            RequiredClassImageComboBox.Name = "RequiredClassImageComboBox";
            // 
            // gridColumn5
            // 
            gridColumn5.FieldName = "Level";
            gridColumn5.Name = "gridColumn5";
            gridColumn5.Visible = true;
            gridColumn5.VisibleIndex = 3;
            // 
            // SetInfoGridControl
            // 
            SetInfoGridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            gridLevelNode1.LevelTemplate = SetStatsGridView;
            gridLevelNode1.RelationName = "SetStats";
            SetInfoGridControl.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            SetInfoGridControl.Location = new System.Drawing.Point(0, 144);
            SetInfoGridControl.MainView = SetInfoGridView;
            SetInfoGridControl.MenuManager = ribbon;
            SetInfoGridControl.Name = "SetInfoGridControl";
            SetInfoGridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            StatImageComboBox,
            RequiredClassImageComboBox});
            SetInfoGridControl.ShowOnlyPredefinedDetails = true;
            SetInfoGridControl.Size = new System.Drawing.Size(727, 342);
            SetInfoGridControl.TabIndex = 2;
            SetInfoGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            SetInfoGridView,
            SetStatsGridView});
            // 
            // SetInfoGridView
            // 
            SetInfoGridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            gridColumn1});
            SetInfoGridView.GridControl = SetInfoGridControl;
            SetInfoGridView.Name = "SetInfoGridView";
            SetInfoGridView.OptionsDetail.AllowExpandEmptyDetails = true;
            SetInfoGridView.OptionsView.EnableAppearanceEvenRow = true;
            SetInfoGridView.OptionsView.EnableAppearanceOddRow = true;
            SetInfoGridView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            SetInfoGridView.OptionsView.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            SetInfoGridView.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            gridColumn1.FieldName = "SetName";
            gridColumn1.Name = "gridColumn1";
            gridColumn1.Visible = true;
            gridColumn1.VisibleIndex = 0;
            // 
            // ribbon
            // 
            ribbon.ExpandCollapseItem.Id = 0;
            ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            ribbon.ExpandCollapseItem,
            SaveDatabaseButton});
            ribbon.Location = new System.Drawing.Point(0, 0);
            ribbon.MaxItemId = 2;
            ribbon.Name = "ribbon";
            ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            ribbonPage1});
            ribbon.Size = new System.Drawing.Size(727, 144);
            // 
            // SaveDatabaseButton
            // 
            SaveDatabaseButton.Caption = "Save Database";
            SaveDatabaseButton.Glyph = ((System.Drawing.Image)(resources.GetObject("SaveDatabaseButton.Glyph")));
            SaveDatabaseButton.Id = 1;
            SaveDatabaseButton.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("SaveDatabaseButton.LargeGlyph")));
            SaveDatabaseButton.LargeWidth = 60;
            SaveDatabaseButton.Name = "SaveDatabaseButton";
            SaveDatabaseButton.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(SaveDatabaseButton_ItemClick);
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
            ribbonPageGroup1.ItemLinks.Add(SaveDatabaseButton);
            ribbonPageGroup1.Name = "ribbonPageGroup1";
            ribbonPageGroup1.ShowCaptionButton = false;
            ribbonPageGroup1.Text = "Saving";
            // 
            // SetInfoView
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(727, 486);
            Controls.Add(SetInfoGridControl);
            Controls.Add(ribbon);
            Name = "SetInfoView";
            Ribbon = ribbon;
            Text = "Set Info";
            ((System.ComponentModel.ISupportInitialize)(SetStatsGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(StatImageComboBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(RequiredClassImageComboBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(SetInfoGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(SetInfoGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(ribbon)).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.BarButtonItem SaveDatabaseButton;
        private DevExpress.XtraGrid.GridControl SetInfoGridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView SetStatsGridView;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Views.Grid.GridView SetInfoGridView;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox StatImageComboBox;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox RequiredClassImageComboBox;
    }
}