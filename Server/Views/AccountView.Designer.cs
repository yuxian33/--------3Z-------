namespace Server.Views
{
    partial class AccountView
    {
        /// <summary>
        /// 必需的设计器变量
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除所有正在使用的资源
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
        /// 设计器支持所需的方法-不要修改
        /// 此方法的内容和代码编辑器
        /// </summary>
        private void InitializeComponent()
        {
            AccountGridControl = new DevExpress.XtraGrid.GridControl();
            AccountGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            AccountLookUpEdit = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
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
            gridColumn22 = new DevExpress.XtraGrid.Columns.GridColumn();
            gridColumn23 = new DevExpress.XtraGrid.Columns.GridColumn();
            gridColumn16 = new DevExpress.XtraGrid.Columns.GridColumn();
            gridColumn17 = new DevExpress.XtraGrid.Columns.GridColumn();
            gridColumn21 = new DevExpress.XtraGrid.Columns.GridColumn();
            gridColumn18 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(AccountGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(AccountGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(AccountLookUpEdit)).BeginInit();
            SuspendLayout();
            // 
            // AccountGridControl
            // 
            AccountGridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            AccountGridControl.Location = new System.Drawing.Point(0, 0);
            AccountGridControl.MainView = AccountGridView;
            AccountGridControl.Name = "AccountGridControl";
            AccountGridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            AccountLookUpEdit});
            AccountGridControl.Size = new System.Drawing.Size(937, 373);
            AccountGridControl.TabIndex = 0;
            AccountGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            AccountGridView});
            // 
            // AccountGridView
            // 
            AccountGridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
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
            gridColumn22,
            gridColumn23,
            gridColumn16,
            gridColumn17,
            gridColumn21,
            gridColumn18});
            AccountGridView.GridControl = AccountGridControl;
            AccountGridView.Name = "AccountGridView";
            AccountGridView.OptionsView.EnableAppearanceEvenRow = true;
            AccountGridView.OptionsView.EnableAppearanceOddRow = true;
            AccountGridView.OptionsView.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            AccountGridView.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            gridColumn1.FieldName = "Index";
            gridColumn1.Name = "gridColumn1";
            gridColumn1.Visible = true;
            gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn2
            // 
            gridColumn2.FieldName = "EMailAddress";
            gridColumn2.Name = "gridColumn2";
            gridColumn2.Visible = true;
            gridColumn2.VisibleIndex = 1;
            // 
            // gridColumn3
            // 
            gridColumn3.FieldName = "RealName";
            gridColumn3.Name = "gridColumn3";
            gridColumn3.Visible = true;
            gridColumn3.VisibleIndex = 3;
            // 
            // gridColumn4
            // 
            gridColumn4.FieldName = "BirthDate";
            gridColumn4.Name = "gridColumn4";
            gridColumn4.Visible = true;
            gridColumn4.VisibleIndex = 4;
            // 
            // gridColumn5
            // 
            gridColumn5.ColumnEdit = AccountLookUpEdit;
            gridColumn5.FieldName = "Referral";
            gridColumn5.Name = "gridColumn5";
            gridColumn5.Visible = true;
            gridColumn5.VisibleIndex = 5;
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
            // gridColumn6
            // 
            gridColumn6.FieldName = "CreationIP";
            gridColumn6.Name = "gridColumn6";
            gridColumn6.Visible = true;
            gridColumn6.VisibleIndex = 6;
            // 
            // gridColumn7
            // 
            gridColumn7.FieldName = "CreationDate";
            gridColumn7.Name = "gridColumn7";
            gridColumn7.Visible = true;
            gridColumn7.VisibleIndex = 7;
            // 
            // gridColumn8
            // 
            gridColumn8.FieldName = "LastIP";
            gridColumn8.Name = "gridColumn8";
            gridColumn8.Visible = true;
            gridColumn8.VisibleIndex = 8;
            // 
            // gridColumn9
            // 
            gridColumn9.FieldName = "LastLogin";
            gridColumn9.Name = "gridColumn9";
            gridColumn9.Visible = true;
            gridColumn9.VisibleIndex = 9;
            // 
            // gridColumn10
            // 
            gridColumn10.FieldName = "Activated";
            gridColumn10.Name = "gridColumn10";
            gridColumn10.Visible = true;
            gridColumn10.VisibleIndex = 10;
            // 
            // gridColumn11
            // 
            gridColumn11.FieldName = "Banned";
            gridColumn11.Name = "gridColumn11";
            gridColumn11.Visible = true;
            gridColumn11.VisibleIndex = 11;
            // 
            // gridColumn12
            // 
            gridColumn12.FieldName = "ExpiryDate";
            gridColumn12.Name = "gridColumn12";
            gridColumn12.Visible = true;
            gridColumn12.VisibleIndex = 12;
            // 
            // gridColumn13
            // 
            gridColumn13.FieldName = "BanReason";
            gridColumn13.Name = "gridColumn13";
            gridColumn13.Visible = true;
            gridColumn13.VisibleIndex = 13;
            // 
            // gridColumn14
            // 
            gridColumn14.FieldName = "Gold";
            gridColumn14.Name = "gridColumn14";
            gridColumn14.Visible = true;
            gridColumn14.VisibleIndex = 14;
            // 
            // gridColumn15
            // 
            gridColumn15.FieldName = "GameGold";
            gridColumn15.Name = "gridColumn15";
            gridColumn15.Visible = true;
            gridColumn15.VisibleIndex = 15;
            // 
            // gridColumn22
            // 
            gridColumn22.FieldName = "GameGoldPrice";
            gridColumn22.Name = "gridColumn22";
            gridColumn22.Visible = true;
            gridColumn22.VisibleIndex = 16;
            // 
            // gridColumn23
            // 
            gridColumn23.FieldName = "Zanzhujilu";
            gridColumn23.Name = "gridColumn23";
            gridColumn23.Visible = true;
            gridColumn23.VisibleIndex = 17;
            // 
            // gridColumn16
            // 
            gridColumn16.FieldName = "HuntGold";
            gridColumn16.Name = "gridColumn16";
            gridColumn16.Visible = true;
            gridColumn16.VisibleIndex = 18;
            // 
            // gridColumn17
            // 
            gridColumn17.FieldName = "Admin";
            gridColumn17.Name = "gridColumn17";
            gridColumn17.Visible = true;
            gridColumn17.VisibleIndex = 19;
            // 
            // gridColumn21
            // 
            gridColumn21.FieldName = "Horse";
            gridColumn21.Name = "gridColumn21";
            gridColumn21.Visible = true;
            gridColumn21.VisibleIndex = 20;
            // 
            // gridColumn18
            // 
            gridColumn18.FieldName = "Observer";
            gridColumn18.Name = "gridColumn18";
            gridColumn18.Visible = true;
            gridColumn18.VisibleIndex = 21;
            // 
            // AccountView
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(937, 373);
            Controls.Add(AccountGridControl);
            Name = "AccountView";
            Text = "Account View";
            ((System.ComponentModel.ISupportInitialize)(AccountGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(AccountGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(AccountLookUpEdit)).EndInit();
            ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl AccountGridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView AccountGridView;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit AccountLookUpEdit;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn15;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn22;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn23;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn16;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn17;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn21;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn18;
    }
}