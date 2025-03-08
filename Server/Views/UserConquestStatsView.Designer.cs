namespace Server.Views
{
    partial class UserConquestStatsView
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
            UserDropGridControl = new DevExpress.XtraGrid.GridControl();
            UserDropGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
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
            AccountLookUpEdit = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            ItemLookUpEdit = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(UserDropGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(UserDropGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(AccountLookUpEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(ItemLookUpEdit)).BeginInit();
            SuspendLayout();
            // 
            // UserDropGridControl
            // 
            UserDropGridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            UserDropGridControl.Location = new System.Drawing.Point(0, 0);
            UserDropGridControl.MainView = UserDropGridView;
            UserDropGridControl.Name = "UserDropGridControl";
            UserDropGridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            AccountLookUpEdit,
            ItemLookUpEdit});
            UserDropGridControl.Size = new System.Drawing.Size(693, 408);
            UserDropGridControl.TabIndex = 0;
            UserDropGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            UserDropGridView});
            // 
            // UserDropGridView
            // 
            UserDropGridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
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
            gridColumn14});
            UserDropGridView.GridControl = UserDropGridControl;
            UserDropGridView.Name = "UserDropGridView";
            UserDropGridView.OptionsView.EnableAppearanceEvenRow = true;
            UserDropGridView.OptionsView.EnableAppearanceOddRow = true;
            UserDropGridView.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            gridColumn1.DisplayFormat.FormatString = "f";
            gridColumn1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            gridColumn1.FieldName = "WarStartDate";
            gridColumn1.Name = "gridColumn1";
            gridColumn1.Visible = true;
            gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn2
            // 
            gridColumn2.FieldName = "CastleName";
            gridColumn2.Name = "gridColumn2";
            gridColumn2.Visible = true;
            gridColumn2.VisibleIndex = 1;
            // 
            // gridColumn3
            // 
            gridColumn3.FieldName = "CharacterName";
            gridColumn3.Name = "gridColumn3";
            gridColumn3.Visible = true;
            gridColumn3.VisibleIndex = 2;
            // 
            // gridColumn4
            // 
            gridColumn4.FieldName = "GuildName";
            gridColumn4.Name = "gridColumn4";
            gridColumn4.Visible = true;
            gridColumn4.VisibleIndex = 3;
            // 
            // gridColumn5
            // 
            gridColumn5.FieldName = "Level";
            gridColumn5.Name = "gridColumn5";
            gridColumn5.Visible = true;
            gridColumn5.VisibleIndex = 4;
            // 
            // gridColumn6
            // 
            gridColumn6.FieldName = "Class";
            gridColumn6.Name = "gridColumn6";
            gridColumn6.Visible = true;
            gridColumn6.VisibleIndex = 5;
            // 
            // gridColumn7
            // 
            gridColumn7.DisplayFormat.FormatString = "#,##0";
            gridColumn7.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gridColumn7.FieldName = "BossDamageTaken";
            gridColumn7.Name = "gridColumn7";
            gridColumn7.Visible = true;
            gridColumn7.VisibleIndex = 6;
            // 
            // gridColumn8
            // 
            gridColumn8.DisplayFormat.FormatString = "#,##0";
            gridColumn8.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gridColumn8.FieldName = "BossDamageDealt";
            gridColumn8.Name = "gridColumn8";
            gridColumn8.Visible = true;
            gridColumn8.VisibleIndex = 7;
            // 
            // gridColumn9
            // 
            gridColumn9.DisplayFormat.FormatString = "#,##0";
            gridColumn9.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gridColumn9.FieldName = "BossDeathCount";
            gridColumn9.Name = "gridColumn9";
            gridColumn9.Visible = true;
            gridColumn9.VisibleIndex = 8;
            // 
            // gridColumn10
            // 
            gridColumn10.DisplayFormat.FormatString = "#,##0";
            gridColumn10.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gridColumn10.FieldName = "BossKillCount";
            gridColumn10.Name = "gridColumn10";
            gridColumn10.Visible = true;
            gridColumn10.VisibleIndex = 9;
            // 
            // gridColumn11
            // 
            gridColumn11.Caption = "PvP Damage Taken";
            gridColumn11.DisplayFormat.FormatString = "#,##0";
            gridColumn11.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gridColumn11.FieldName = "PvPDamageTaken";
            gridColumn11.Name = "gridColumn11";
            gridColumn11.Visible = true;
            gridColumn11.VisibleIndex = 10;
            // 
            // gridColumn12
            // 
            gridColumn12.Caption = "PvP Damage Dealt";
            gridColumn12.DisplayFormat.FormatString = "#,##0";
            gridColumn12.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gridColumn12.FieldName = "PvPDamageDealt";
            gridColumn12.Name = "gridColumn12";
            gridColumn12.Visible = true;
            gridColumn12.VisibleIndex = 11;
            // 
            // gridColumn13
            // 
            gridColumn13.Caption = "PvP Death Count";
            gridColumn13.DisplayFormat.FormatString = "#,##0";
            gridColumn13.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gridColumn13.FieldName = "PvPDeathCount";
            gridColumn13.Name = "gridColumn13";
            gridColumn13.Visible = true;
            gridColumn13.VisibleIndex = 12;
            // 
            // gridColumn14
            // 
            gridColumn14.Caption = "PvP Kill Count";
            gridColumn14.DisplayFormat.FormatString = "#,##0";
            gridColumn14.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gridColumn14.FieldName = "PvPKillCount";
            gridColumn14.Name = "gridColumn14";
            gridColumn14.Visible = true;
            gridColumn14.VisibleIndex = 13;
            // 
            // AccountLookUpEdit
            // 
            AccountLookUpEdit.AutoHeight = false;
            AccountLookUpEdit.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            AccountLookUpEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            AccountLookUpEdit.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("EMailAddress", "EMail")});
            AccountLookUpEdit.DisplayMember = "EMailAddress";
            AccountLookUpEdit.Name = "AccountLookUpEdit";
            AccountLookUpEdit.NullText = "[Account is null]";
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
            // 
            // UserConquestStatsView
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(693, 408);
            Controls.Add(UserDropGridControl);
            Name = "UserConquestStatsView";
            Text = "UserDropView";
            ((System.ComponentModel.ISupportInitialize)(UserDropGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(UserDropGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(AccountLookUpEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(ItemLookUpEdit)).EndInit();
            ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl UserDropGridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView UserDropGridView;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit AccountLookUpEdit;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUpEdit;
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
    }
}