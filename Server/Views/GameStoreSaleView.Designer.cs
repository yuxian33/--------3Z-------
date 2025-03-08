namespace Server.Views
{
    partial class GameStoreSaleView
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
            GameStoreSaleGridControl = new DevExpress.XtraGrid.GridControl();
            GameStoreSaleGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            AccountLookUpEdit = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            ItemLookUpEdit = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(GameStoreSaleGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(GameStoreSaleGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(AccountLookUpEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(ItemLookUpEdit)).BeginInit();
            SuspendLayout();
            // 
            // GameStoreSaleGridControl
            // 
            GameStoreSaleGridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            GameStoreSaleGridControl.Location = new System.Drawing.Point(0, 0);
            GameStoreSaleGridControl.MainView = GameStoreSaleGridView;
            GameStoreSaleGridControl.Name = "GameStoreSaleGridControl";
            GameStoreSaleGridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            AccountLookUpEdit,
            ItemLookUpEdit});
            GameStoreSaleGridControl.Size = new System.Drawing.Size(937, 373);
            GameStoreSaleGridControl.TabIndex = 0;
            GameStoreSaleGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            GameStoreSaleGridView});
            // 
            // GameStoreSaleGridView
            // 
            GameStoreSaleGridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            gridColumn1,
            gridColumn5,
            gridColumn2,
            gridColumn3,
            gridColumn4,
            gridColumn6,
            gridColumn7});
            GameStoreSaleGridView.GridControl = GameStoreSaleGridControl;
            GameStoreSaleGridView.Name = "GameStoreSaleGridView";
            GameStoreSaleGridView.OptionsView.EnableAppearanceEvenRow = true;
            GameStoreSaleGridView.OptionsView.EnableAppearanceOddRow = true;
            GameStoreSaleGridView.OptionsView.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            GameStoreSaleGridView.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            gridColumn1.FieldName = "Index";
            gridColumn1.Name = "gridColumn1";
            gridColumn1.Visible = true;
            gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn5
            // 
            gridColumn5.ColumnEdit = AccountLookUpEdit;
            gridColumn5.FieldName = "Account";
            gridColumn5.Name = "gridColumn5";
            gridColumn5.Visible = true;
            gridColumn5.VisibleIndex = 1;
            // 
            // AccountLookUpEdit
            // 
            AccountLookUpEdit.AutoHeight = false;
            AccountLookUpEdit.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            AccountLookUpEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            AccountLookUpEdit.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Index", "Index"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("EMailAddress", "EMailAddress"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Referral", "Referral"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Banned", "Banned")});
            AccountLookUpEdit.DisplayMember = "EMailAddress";
            AccountLookUpEdit.Name = "AccountLookUpEdit";
            AccountLookUpEdit.NullText = "";
            // 
            // gridColumn2
            // 
            gridColumn2.ColumnEdit = ItemLookUpEdit;
            gridColumn2.FieldName = "Item";
            gridColumn2.Name = "gridColumn2";
            gridColumn2.Visible = true;
            gridColumn2.VisibleIndex = 2;
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
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("StackSize", "Stack Szie")});
            ItemLookUpEdit.DisplayMember = "ItemName";
            ItemLookUpEdit.Name = "ItemLookUpEdit";
            ItemLookUpEdit.NullText = "[Item is null]";
            // 
            // gridColumn3
            // 
            gridColumn3.DisplayFormat.FormatString = "F";
            gridColumn3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            gridColumn3.FieldName = "Date";
            gridColumn3.Name = "gridColumn3";
            gridColumn3.Visible = true;
            gridColumn3.VisibleIndex = 3;
            // 
            // gridColumn4
            // 
            gridColumn4.FieldName = "Price";
            gridColumn4.Name = "gridColumn4";
            gridColumn4.Visible = true;
            gridColumn4.VisibleIndex = 4;
            // 
            // gridColumn6
            // 
            gridColumn6.FieldName = "Count";
            gridColumn6.Name = "gridColumn6";
            gridColumn6.Visible = true;
            gridColumn6.VisibleIndex = 5;
            // 
            // gridColumn7
            // 
            gridColumn7.FieldName = "HuntGold";
            gridColumn7.Name = "gridColumn7";
            gridColumn7.Visible = true;
            gridColumn7.VisibleIndex = 6;
            // 
            // GameStoreSaleView
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(937, 373);
            Controls.Add(GameStoreSaleGridControl);
            Name = "GameStoreSaleView";
            Text = "Game Store Sale View";
            ((System.ComponentModel.ISupportInitialize)(GameStoreSaleGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(GameStoreSaleGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(AccountLookUpEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(ItemLookUpEdit)).EndInit();
            ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl GameStoreSaleGridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView GameStoreSaleGridView;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit AccountLookUpEdit;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEdit;
    }
}