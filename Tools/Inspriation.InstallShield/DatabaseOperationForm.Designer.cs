namespace InstallShield
{
    partial class DatabaseOperationForm
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
            this.txt_server = new System.Windows.Forms.TextBox();
            this.txt_uid = new System.Windows.Forms.TextBox();
            this.txt_pwd = new System.Windows.Forms.TextBox();
            this.txt_database = new System.Windows.Forms.TextBox();
            this.linkLabel4 = new System.Windows.Forms.LinkLabel();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // txt_server
            // 
            this.txt_server.BackColor = System.Drawing.Color.LightGray;
            this.txt_server.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_server.Location = new System.Drawing.Point(137, 353);
            this.txt_server.Name = "txt_server";
            this.txt_server.Size = new System.Drawing.Size(330, 14);
            this.txt_server.TabIndex = 4;
            this.txt_server.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // txt_uid
            // 
            this.txt_uid.BackColor = System.Drawing.Color.LightGray;
            this.txt_uid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_uid.Location = new System.Drawing.Point(137, 390);
            this.txt_uid.Name = "txt_uid";
            this.txt_uid.Size = new System.Drawing.Size(330, 14);
            this.txt_uid.TabIndex = 5;
            // 
            // txt_pwd
            // 
            this.txt_pwd.BackColor = System.Drawing.Color.LightGray;
            this.txt_pwd.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_pwd.Location = new System.Drawing.Point(137, 427);
            this.txt_pwd.Name = "txt_pwd";
            this.txt_pwd.PasswordChar = '*';
            this.txt_pwd.Size = new System.Drawing.Size(330, 14);
            this.txt_pwd.TabIndex = 6;
            // 
            // txt_database
            // 
            this.txt_database.BackColor = System.Drawing.Color.LightGray;
            this.txt_database.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_database.Location = new System.Drawing.Point(137, 464);
            this.txt_database.Name = "txt_database";
            this.txt_database.Size = new System.Drawing.Size(330, 14);
            this.txt_database.TabIndex = 7;
            // 
            // linkLabel4
            // 
            this.linkLabel4.AutoSize = true;
            this.linkLabel4.BackColor = System.Drawing.Color.Transparent;
            this.linkLabel4.Location = new System.Drawing.Point(663, 439);
            this.linkLabel4.Name = "linkLabel4";
            this.linkLabel4.Size = new System.Drawing.Size(179, 12);
            this.linkLabel4.TabIndex = 15;
            this.linkLabel4.TabStop = true;
            this.linkLabel4.Text = "Action to create default SPS.";
            this.linkLabel4.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel4_LinkClicked);
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.BackColor = System.Drawing.Color.Transparent;
            this.linkLabel2.Location = new System.Drawing.Point(626, 406);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(245, 12);
            this.linkLabel2.TabIndex = 16;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "Try to connect to remote database server";
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // DatabaseOperationForm
            // 
            this.BackgroundImage = global::InstallShield.Properties.Resources.DatabaseOperationForm_fw;
            this.ClientSize = new System.Drawing.Size(1000, 700);
            this.Controls.Add(this.linkLabel2);
            this.Controls.Add(this.linkLabel4);
            this.Controls.Add(this.txt_database);
            this.Controls.Add(this.txt_pwd);
            this.Controls.Add(this.txt_uid);
            this.Controls.Add(this.txt_server);
            this.Name = "DatabaseOperationForm";
            this.Controls.SetChildIndex(this.txt_server, 0);
            this.Controls.SetChildIndex(this.txt_uid, 0);
            this.Controls.SetChildIndex(this.txt_pwd, 0);
            this.Controls.SetChildIndex(this.txt_database, 0);
            this.Controls.SetChildIndex(this.linkLabel4, 0);
            this.Controls.SetChildIndex(this.linkLabel2, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_server;
        private System.Windows.Forms.TextBox txt_uid;
        private System.Windows.Forms.TextBox txt_pwd;
        private System.Windows.Forms.TextBox txt_database;
        private System.Windows.Forms.LinkLabel linkLabel4;
        private System.Windows.Forms.LinkLabel linkLabel2;
    }
}
