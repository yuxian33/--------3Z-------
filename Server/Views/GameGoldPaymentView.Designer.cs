namespace Server.Views
{
    partial class GameGoldPaymentView
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
            GameGoldPaymentGridControl = new DevExpress.XtraGrid.GridControl();
            GameGoldPaymentGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
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
            ((System.ComponentModel.ISupportInitialize)(GameGoldPaymentGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(GameGoldPaymentGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(AccountLookUpEdit)).BeginInit();
            SuspendLayout();
            // 
            // GameGoldPaymentGridControl
            // 
            GameGoldPaymentGridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            GameGoldPaymentGridControl.Location = new System.Drawing.Point(0, 0);
            GameGoldPaymentGridControl.MainView = GameGoldPaymentGridView;
            GameGoldPaymentGridControl.Name = "GameGoldPaymentGridControl";
            GameGoldPaymentGridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            AccountLookUpEdit});
            GameGoldPaymentGridControl.Size = new System.Drawing.Size(937, 373);
            GameGoldPaymentGridControl.TabIndex = 0;
            GameGoldPaymentGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            GameGoldPaymentGridView});
            // 
            // GameGoldPaymentGridView
            // 
            GameGoldPaymentGridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
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
            gridColumn15});
            GameGoldPaymentGridView.GridControl = GameGoldPaymentGridControl;
            GameGoldPaymentGridView.Name = "GameGoldPaymentGridView";
            GameGoldPaymentGridView.OptionsView.EnableAppearanceEvenRow = true;
            GameGoldPaymentGridView.OptionsView.EnableAppearanceOddRow = true;
            GameGoldPaymentGridView.OptionsView.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            GameGoldPaymentGridView.OptionsView.ShowGroupPanel = false;
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
            gridColumn2.FieldName = "CharacterName";
            gridColumn2.Name = "gridColumn2";
            gridColumn2.Visible = true;
            gridColumn2.VisibleIndex = 1;
            // 
            // gridColumn3
            // 
            gridColumn3.FieldName = "Name";
            gridColumn3.Name = "gridColumn3";
            gridColumn3.Visible = true;
            gridColumn3.VisibleIndex = 2;
            // 
            // gridColumn4
            // 
            gridColumn4.FieldName = "PaymentDate";
            gridColumn4.Name = "gridColumn4";
            gridColumn4.Visible = true;
            gridColumn4.VisibleIndex = 3;
            // 
            // gridColumn5
            // 
            gridColumn5.ColumnEdit = AccountLookUpEdit;
            gridColumn5.FieldName = "Account";
            gridColumn5.Name = "gridColumn5";
            gridColumn5.Visible = true;
            gridColumn5.VisibleIndex = 4;
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
            gridColumn6.FieldName = "TransactionID";
            gridColumn6.Name = "gridColumn6";
            gridColumn6.Visible = true;
            gridColumn6.VisibleIndex = 5;
            // 
            // gridColumn7
            // 
            gridColumn7.FieldName = "TransactionType";
            gridColumn7.Name = "gridColumn7";
            gridColumn7.Visible = true;
            gridColumn7.VisibleIndex = 6;
            // 
            // gridColumn8
            // 
            gridColumn8.FieldName = "Status";
            gridColumn8.Name = "gridColumn8";
            gridColumn8.Visible = true;
            gridColumn8.VisibleIndex = 7;
            // 
            // gridColumn9
            // 
            gridColumn9.FieldName = "GameGoldAmount";
            gridColumn9.Name = "gridColumn9";
            gridColumn9.Visible = true;
            gridColumn9.VisibleIndex = 8;
            // 
            // gridColumn10
            // 
            gridColumn10.FieldName = "Payer_EMail";
            gridColumn10.Name = "gridColumn10";
            gridColumn10.Visible = true;
            gridColumn10.VisibleIndex = 9;
            // 
            // gridColumn11
            // 
            gridColumn11.FieldName = "Payer_ID";
            gridColumn11.Name = "gridColumn11";
            gridColumn11.Visible = true;
            gridColumn11.VisibleIndex = 10;
            // 
            // gridColumn12
            // 
            gridColumn12.FieldName = "Price";
            gridColumn12.Name = "gridColumn12";
            gridColumn12.Visible = true;
            gridColumn12.VisibleIndex = 11;
            // 
            // gridColumn13
            // 
            gridColumn13.FieldName = "Currency";
            gridColumn13.Name = "gridColumn13";
            gridColumn13.Visible = true;
            gridColumn13.VisibleIndex = 12;
            // 
            // gridColumn14
            // 
            gridColumn14.FieldName = "Fee";
            gridColumn14.Name = "gridColumn14";
            gridColumn14.Visible = true;
            gridColumn14.VisibleIndex = 13;
            // 
            // gridColumn15
            // 
            gridColumn15.FieldName = "Error";
            gridColumn15.Name = "gridColumn15";
            gridColumn15.Visible = true;
            gridColumn15.VisibleIndex = 14;
            // 
            // GameGoldPaymentView
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(937, 373);
            Controls.Add(GameGoldPaymentGridControl);
            Name = "GameGoldPaymentView";
            Text = "Game Gold Payment View";
            ((System.ComponentModel.ISupportInitialize)(GameGoldPaymentGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(GameGoldPaymentGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(AccountLookUpEdit)).EndInit();
            ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl GameGoldPaymentGridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView GameGoldPaymentGridView;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit AccountLookUpEdit;
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
    }
}