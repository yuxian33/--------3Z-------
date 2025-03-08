namespace Server.Views
{
    partial class SyncForm
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
            label1 = new System.Windows.Forms.Label();
            txtRemoteIP = new System.Windows.Forms.TextBox();
            btnSync = new System.Windows.Forms.Button();
            label2 = new System.Windows.Forms.Label();
            txtKey = new System.Windows.Forms.TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(12, 18);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(57, 13);
            label1.TabIndex = 0;
            label1.Text = "远程服务器IP";
            // 
            // txtRemoteIP
            // 
            txtRemoteIP.Location = new System.Drawing.Point(90, 15);
            txtRemoteIP.Name = "txtRemoteIP";
            txtRemoteIP.Size = new System.Drawing.Size(180, 20);
            txtRemoteIP.TabIndex = 1;
            // 
            // btnSync
            // 
            btnSync.Location = new System.Drawing.Point(15, 76);
            btnSync.Name = "btnSync";
            btnSync.Size = new System.Drawing.Size(282, 23);
            btnSync.TabIndex = 2;
            btnSync.Text = "Sync";
            btnSync.UseVisualStyleBackColor = true;
            btnSync.Click += new System.EventHandler(btnSync_Click);
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(12, 48);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(25, 13);
            label2.TabIndex = 3;
            label2.Text = "密码";
            // 
            // txtKey
            // 
            txtKey.Location = new System.Drawing.Point(75, 45);
            txtKey.Name = "txtKey";
            txtKey.PasswordChar = '*';
            txtKey.Size = new System.Drawing.Size(222, 20);
            txtKey.TabIndex = 4;
            // 
            // SyncForm
            // 
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            ClientSize = new System.Drawing.Size(311, 114);
            Controls.Add(txtKey);
            Controls.Add(label2);
            Controls.Add(btnSync);
            Controls.Add(txtRemoteIP);
            Controls.Add(label1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            Name = "SyncForm";
            Text = "Syncronization Remote DB";
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtRemoteIP;
        private System.Windows.Forms.Button btnSync;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtKey;
    }
}