namespace Server.Views
{
    partial class MapRegionView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MapRegionView));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            SaveButton = new DevExpress.XtraBars.BarButtonItem();
            ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            MapRegionGridControl = new DevExpress.XtraGrid.GridControl();
            MapRegionGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            colIndex = new DevExpress.XtraGrid.Columns.GridColumn();
            gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            MapLookUpEdit = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            EditButtonEdit = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            ((System.ComponentModel.ISupportInitialize)(ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(MapRegionGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(MapRegionGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(MapLookUpEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(EditButtonEdit)).BeginInit();
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
            ribbon.Size = new System.Drawing.Size(728, 144);
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
            // MapRegionGridControl
            // 
            MapRegionGridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            MapRegionGridControl.Location = new System.Drawing.Point(0, 144);
            MapRegionGridControl.MainView = MapRegionGridView;
            MapRegionGridControl.MenuManager = ribbon;
            MapRegionGridControl.Name = "MapRegionGridControl";
            MapRegionGridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            MapLookUpEdit,
            EditButtonEdit});
            MapRegionGridControl.Size = new System.Drawing.Size(728, 404);
            MapRegionGridControl.TabIndex = 2;
            MapRegionGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            MapRegionGridView});
            // 
            // MapRegionGridView
            // 
            MapRegionGridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            colIndex,
            gridColumn1,
            gridColumn2,
            gridColumn3,
            gridColumn4});
            MapRegionGridView.GridControl = MapRegionGridControl;
            MapRegionGridView.Name = "MapRegionGridView";
            MapRegionGridView.OptionsView.EnableAppearanceEvenRow = true;
            MapRegionGridView.OptionsView.EnableAppearanceOddRow = true;
            MapRegionGridView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            MapRegionGridView.OptionsView.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            MapRegionGridView.OptionsView.ShowGroupPanel = false;
            // 
            // colIndex
            // 
            colIndex.FieldName = "Index";
            colIndex.Name = "colIndex";
            colIndex.Visible = true;
            colIndex.Width = 48;
            colIndex.VisibleIndex = 0;
            // 
            // gridColumn1
            // 
            gridColumn1.ColumnEdit = MapLookUpEdit;
            gridColumn1.FieldName = "Map";
            gridColumn1.Name = "gridColumn1";
            gridColumn1.Visible = true;
            gridColumn1.VisibleIndex = 1;
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
            // gridColumn2
            // 
            gridColumn2.FieldName = "Description";
            gridColumn2.Name = "gridColumn2";
            gridColumn2.Visible = true;
            gridColumn2.VisibleIndex = 2;
            // 
            // gridColumn3
            // 
            gridColumn3.Caption = "Size";
            gridColumn3.FieldName = "Size";
            gridColumn3.Name = "gridColumn3";
            gridColumn3.OptionsColumn.AllowEdit = false;
            gridColumn3.OptionsColumn.ReadOnly = true;
            gridColumn3.Visible = true;
            gridColumn3.VisibleIndex = 3;
            // 
            // gridColumn4
            // 
            gridColumn4.Caption = "Edit";
            gridColumn4.ColumnEdit = EditButtonEdit;
            gridColumn4.Name = "gridColumn4";
            gridColumn4.Visible = true;
            gridColumn4.VisibleIndex = 4;
            // 
            // EditButtonEdit
            // 
            EditButtonEdit.AutoHeight = false;
            EditButtonEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, ((System.Drawing.Image)(resources.GetObject("EditButtonEdit.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, serializableAppearanceObject2, serializableAppearanceObject3, serializableAppearanceObject4, "", null, null, true)});
            EditButtonEdit.Name = "EditButtonEdit";
            EditButtonEdit.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            EditButtonEdit.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(EditButtonEdit_ButtonClick);
            // 
            // MapRegionView
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(728, 548);
            Controls.Add(MapRegionGridControl);
            Controls.Add(ribbon);
            Name = "MapRegionView";
            Ribbon = ribbon;
            Text = "Map Region View";
            ((System.ComponentModel.ISupportInitialize)(ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(MapRegionGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(MapRegionGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(MapLookUpEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(EditButtonEdit)).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.BarButtonItem SaveButton;
        private DevExpress.XtraGrid.GridControl MapRegionGridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView MapRegionGridView;
        private DevExpress.XtraGrid.Columns.GridColumn colIndex;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit MapLookUpEdit;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit EditButtonEdit;
    }
}