namespace Server.Views
{
    partial class UserItemView
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
            UserDropGridView.GridControl = UserDropGridControl;
            UserDropGridView.Name = "UserDropGridView";
            UserDropGridView.OptionsView.EnableAppearanceEvenRow = true;
            UserDropGridView.OptionsView.EnableAppearanceOddRow = true;
            UserDropGridView.OptionsView.ShowGroupPanel = false;
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
            // UserItemView
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(693, 408);
            Controls.Add(UserDropGridControl);
            Name = "UserItemView";
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
    }
}