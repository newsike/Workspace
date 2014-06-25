namespace InstallShield
{
    partial class PreferenceEmailForm
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
            this.txt_mailserver = new System.Windows.Forms.TextBox();
            this.txt_acount = new System.Windows.Forms.TextBox();
            this.txt_password = new System.Windows.Forms.TextBox();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // txt_mailserver
            // 
            this.txt_mailserver.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_mailserver.Location = new System.Drawing.Point(351, 208);
            this.txt_mailserver.Name = "txt_mailserver";
            this.txt_mailserver.Size = new System.Drawing.Size(593, 14);
            this.txt_mailserver.TabIndex = 6;
            // 
            // txt_acount
            // 
            this.txt_acount.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_acount.Location = new System.Drawing.Point(351, 257);
            this.txt_acount.Name = "txt_acount";
            this.txt_acount.Size = new System.Drawing.Size(593, 14);
            this.txt_acount.TabIndex = 7;
            // 
            // txt_password
            // 
            this.txt_password.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_password.Location = new System.Drawing.Point(351, 304);
            this.txt_password.Name = "txt_password";
            this.txt_password.PasswordChar = '*';
            this.txt_password.Size = new System.Drawing.Size(593, 14);
            this.txt_password.TabIndex = 8;
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.BackColor = System.Drawing.Color.Transparent;
            this.linkLabel2.Location = new System.Drawing.Point(793, 400);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(167, 12);
            this.linkLabel2.TabIndex = 9;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "Update the config to system";
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // PreferenceEmailForm
            // 
            this.BackgroundImage = global::InstallShield.Properties.Resources.Preference_MailForm_fw;
            this.ClientSize = new System.Drawing.Size(1000, 700);
            this.Controls.Add(this.linkLabel2);
            this.Controls.Add(this.txt_password);
            this.Controls.Add(this.txt_acount);
            this.Controls.Add(this.txt_mailserver);
            this.Name = "PreferenceEmailForm";
            this.Load += new System.EventHandler(this.PreferenceEmailForm_Load);
            this.Controls.SetChildIndex(this.txt_mailserver, 0);
            this.Controls.SetChildIndex(this.txt_acount, 0);
            this.Controls.SetChildIndex(this.txt_password, 0);
            this.Controls.SetChildIndex(this.linkLabel2, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_mailserver;
        private System.Windows.Forms.TextBox txt_acount;
        private System.Windows.Forms.TextBox txt_password;
        private System.Windows.Forms.LinkLabel linkLabel2;
    }
}
