namespace InstallShield
{
    partial class ClientInfoForm
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
            this.cmb_clientname = new System.Windows.Forms.ComboBox();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.linkLabel3 = new System.Windows.Forms.LinkLabel();
            this.cmb_iplist = new System.Windows.Forms.ComboBox();
            this.linkLabel4 = new System.Windows.Forms.LinkLabel();
            this.linkLabel5 = new System.Windows.Forms.LinkLabel();
            this.txt_password = new System.Windows.Forms.TextBox();
            this.txt_key = new System.Windows.Forms.TextBox();
            this.linkLabel6 = new System.Windows.Forms.LinkLabel();
            this.txt_clientemail = new System.Windows.Forms.TextBox();
            this.linkLabel7 = new System.Windows.Forms.LinkLabel();
            this.linkLabel8 = new System.Windows.Forms.LinkLabel();
            this.linkLabel9 = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // cmb_clientname
            // 
            this.cmb_clientname.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmb_clientname.FormattingEnabled = true;
            this.cmb_clientname.Location = new System.Drawing.Point(119, 213);
            this.cmb_clientname.Name = "cmb_clientname";
            this.cmb_clientname.Size = new System.Drawing.Size(207, 20);
            this.cmb_clientname.TabIndex = 4;
            this.cmb_clientname.SelectedIndexChanged += new System.EventHandler(this.cmb_clientname_SelectedIndexChanged);
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.BackColor = System.Drawing.Color.Transparent;
            this.linkLabel2.Location = new System.Drawing.Point(127, 255);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(65, 12);
            this.linkLabel2.TabIndex = 5;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "Create New";
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // linkLabel3
            // 
            this.linkLabel3.AutoSize = true;
            this.linkLabel3.BackColor = System.Drawing.Color.Transparent;
            this.linkLabel3.Location = new System.Drawing.Point(218, 255);
            this.linkLabel3.Name = "linkLabel3";
            this.linkLabel3.Size = new System.Drawing.Size(95, 12);
            this.linkLabel3.TabIndex = 6;
            this.linkLabel3.TabStop = true;
            this.linkLabel3.Text = "Remove Selected";
            this.linkLabel3.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel3_LinkClicked);
            // 
            // cmb_iplist
            // 
            this.cmb_iplist.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmb_iplist.FormattingEnabled = true;
            this.cmb_iplist.Location = new System.Drawing.Point(496, 213);
            this.cmb_iplist.Name = "cmb_iplist";
            this.cmb_iplist.Size = new System.Drawing.Size(311, 20);
            this.cmb_iplist.TabIndex = 7;
            // 
            // linkLabel4
            // 
            this.linkLabel4.AutoSize = true;
            this.linkLabel4.BackColor = System.Drawing.Color.Transparent;
            this.linkLabel4.Location = new System.Drawing.Point(840, 221);
            this.linkLabel4.Name = "linkLabel4";
            this.linkLabel4.Size = new System.Drawing.Size(71, 12);
            this.linkLabel4.TabIndex = 8;
            this.linkLabel4.TabStop = true;
            this.linkLabel4.Text = "Add to list";
            this.linkLabel4.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel4_LinkClicked);
            // 
            // linkLabel5
            // 
            this.linkLabel5.AutoSize = true;
            this.linkLabel5.BackColor = System.Drawing.Color.Transparent;
            this.linkLabel5.Location = new System.Drawing.Point(913, 221);
            this.linkLabel5.Name = "linkLabel5";
            this.linkLabel5.Size = new System.Drawing.Size(41, 12);
            this.linkLabel5.TabIndex = 9;
            this.linkLabel5.TabStop = true;
            this.linkLabel5.Text = "Remove";
            this.linkLabel5.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel5_LinkClicked);
            // 
            // txt_password
            // 
            this.txt_password.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_password.Location = new System.Drawing.Point(502, 261);
            this.txt_password.Name = "txt_password";
            this.txt_password.Size = new System.Drawing.Size(305, 14);
            this.txt_password.TabIndex = 10;
            // 
            // txt_key
            // 
            this.txt_key.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_key.Location = new System.Drawing.Point(502, 308);
            this.txt_key.Name = "txt_key";
            this.txt_key.Size = new System.Drawing.Size(305, 14);
            this.txt_key.TabIndex = 11;
            // 
            // linkLabel6
            // 
            this.linkLabel6.AutoSize = true;
            this.linkLabel6.BackColor = System.Drawing.Color.Transparent;
            this.linkLabel6.Location = new System.Drawing.Point(840, 311);
            this.linkLabel6.Name = "linkLabel6";
            this.linkLabel6.Size = new System.Drawing.Size(41, 12);
            this.linkLabel6.TabIndex = 12;
            this.linkLabel6.TabStop = true;
            this.linkLabel6.Text = "Random";
            this.linkLabel6.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel6_LinkClicked);
            // 
            // txt_clientemail
            // 
            this.txt_clientemail.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_clientemail.Location = new System.Drawing.Point(114, 426);
            this.txt_clientemail.Name = "txt_clientemail";
            this.txt_clientemail.Size = new System.Drawing.Size(585, 14);
            this.txt_clientemail.TabIndex = 13;
            // 
            // linkLabel7
            // 
            this.linkLabel7.AutoSize = true;
            this.linkLabel7.BackColor = System.Drawing.Color.Transparent;
            this.linkLabel7.Location = new System.Drawing.Point(797, 522);
            this.linkLabel7.Name = "linkLabel7";
            this.linkLabel7.Size = new System.Drawing.Size(167, 12);
            this.linkLabel7.TabIndex = 14;
            this.linkLabel7.TabStop = true;
            this.linkLabel7.Text = "Action To Save All Configs ";
            this.linkLabel7.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel7_LinkClicked);
            // 
            // linkLabel8
            // 
            this.linkLabel8.AutoSize = true;
            this.linkLabel8.BackColor = System.Drawing.Color.Transparent;
            this.linkLabel8.Location = new System.Drawing.Point(623, 380);
            this.linkLabel8.Name = "linkLabel8";
            this.linkLabel8.Size = new System.Drawing.Size(155, 12);
            this.linkLabel8.TabIndex = 15;
            this.linkLabel8.TabStop = true;
            this.linkLabel8.Text = "Update the data to buffer";
            this.linkLabel8.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel8_LinkClicked);
            // 
            // linkLabel9
            // 
            this.linkLabel9.AutoSize = true;
            this.linkLabel9.BackColor = System.Drawing.Color.Transparent;
            this.linkLabel9.Location = new System.Drawing.Point(729, 426);
            this.linkLabel9.Name = "linkLabel9";
            this.linkLabel9.Size = new System.Drawing.Size(215, 12);
            this.linkLabel9.TabIndex = 16;
            this.linkLabel9.TabStop = true;
            this.linkLabel9.Text = "Send the key and password to client";
            this.linkLabel9.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel9_LinkClicked);
            // 
            // ClientInfoForm
            // 
            this.BackgroundImage = global::InstallShield.Properties.Resources.ClientInfoForm_fw;
            this.ClientSize = new System.Drawing.Size(1000, 700);
            this.Controls.Add(this.linkLabel9);
            this.Controls.Add(this.linkLabel8);
            this.Controls.Add(this.linkLabel7);
            this.Controls.Add(this.txt_clientemail);
            this.Controls.Add(this.linkLabel6);
            this.Controls.Add(this.txt_key);
            this.Controls.Add(this.txt_password);
            this.Controls.Add(this.linkLabel5);
            this.Controls.Add(this.linkLabel4);
            this.Controls.Add(this.cmb_iplist);
            this.Controls.Add(this.linkLabel3);
            this.Controls.Add(this.linkLabel2);
            this.Controls.Add(this.cmb_clientname);
            this.Name = "ClientInfoForm";
            this.Load += new System.EventHandler(this.ClientInfoForm_Load);
            this.Controls.SetChildIndex(this.cmb_clientname, 0);
            this.Controls.SetChildIndex(this.linkLabel2, 0);
            this.Controls.SetChildIndex(this.linkLabel3, 0);
            this.Controls.SetChildIndex(this.cmb_iplist, 0);
            this.Controls.SetChildIndex(this.linkLabel4, 0);
            this.Controls.SetChildIndex(this.linkLabel5, 0);
            this.Controls.SetChildIndex(this.txt_password, 0);
            this.Controls.SetChildIndex(this.txt_key, 0);
            this.Controls.SetChildIndex(this.linkLabel6, 0);
            this.Controls.SetChildIndex(this.txt_clientemail, 0);
            this.Controls.SetChildIndex(this.linkLabel7, 0);
            this.Controls.SetChildIndex(this.linkLabel8, 0);
            this.Controls.SetChildIndex(this.linkLabel9, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmb_clientname;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.LinkLabel linkLabel3;
        private System.Windows.Forms.ComboBox cmb_iplist;
        private System.Windows.Forms.LinkLabel linkLabel4;
        private System.Windows.Forms.LinkLabel linkLabel5;
        private System.Windows.Forms.TextBox txt_password;
        private System.Windows.Forms.TextBox txt_key;
        private System.Windows.Forms.LinkLabel linkLabel6;
        private System.Windows.Forms.TextBox txt_clientemail;
        private System.Windows.Forms.LinkLabel linkLabel7;
        private System.Windows.Forms.LinkLabel linkLabel8;
        private System.Windows.Forms.LinkLabel linkLabel9;
    }
}
