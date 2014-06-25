namespace InstallShield
{
    partial class ConfigFileForm
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
            this.cmb_keytype = new System.Windows.Forms.ComboBox();
            this.txt_filename = new System.Windows.Forms.TextBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.txt_planname = new System.Windows.Forms.TextBox();
            this.txt_keyfile = new System.Windows.Forms.TextBox();
            this.txt_keycontent = new System.Windows.Forms.TextBox();
            this.linkLabel3 = new System.Windows.Forms.LinkLabel();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.linkLabel5 = new System.Windows.Forms.LinkLabel();
            this.linkLabel4 = new System.Windows.Forms.LinkLabel();
            this.chk_using64 = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // cmb_keytype
            // 
            this.cmb_keytype.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmb_keytype.FormattingEnabled = true;
            this.cmb_keytype.Items.AddRange(new object[] {
            "Keyfile",
            "WebConfig",
            "Regkey"});
            this.cmb_keytype.Location = new System.Drawing.Point(106, 270);
            this.cmb_keytype.Name = "cmb_keytype";
            this.cmb_keytype.Size = new System.Drawing.Size(162, 20);
            this.cmb_keytype.TabIndex = 0;
            this.cmb_keytype.SelectedIndexChanged += new System.EventHandler(this.cmb_keytype_SelectedIndexChanged);
            // 
            // txt_filename
            // 
            this.txt_filename.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_filename.Location = new System.Drawing.Point(182, 157);
            this.txt_filename.Name = "txt_filename";
            this.txt_filename.Size = new System.Drawing.Size(615, 14);
            this.txt_filename.TabIndex = 1;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.BackColor = System.Drawing.Color.Transparent;
            this.linkLabel1.Location = new System.Drawing.Point(842, 157);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(65, 12);
            this.linkLabel1.TabIndex = 2;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Create New";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // txt_planname
            // 
            this.txt_planname.BackColor = System.Drawing.Color.White;
            this.txt_planname.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_planname.Location = new System.Drawing.Point(123, 190);
            this.txt_planname.Name = "txt_planname";
            this.txt_planname.Size = new System.Drawing.Size(852, 14);
            this.txt_planname.TabIndex = 4;
            // 
            // txt_keyfile
            // 
            this.txt_keyfile.BackColor = System.Drawing.Color.White;
            this.txt_keyfile.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_keyfile.Location = new System.Drawing.Point(92, 305);
            this.txt_keyfile.Name = "txt_keyfile";
            this.txt_keyfile.Size = new System.Drawing.Size(883, 14);
            this.txt_keyfile.TabIndex = 5;
            // 
            // txt_keycontent
            // 
            this.txt_keycontent.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_keycontent.Location = new System.Drawing.Point(135, 336);
            this.txt_keycontent.Name = "txt_keycontent";
            this.txt_keycontent.Size = new System.Drawing.Size(718, 14);
            this.txt_keycontent.TabIndex = 6;
            // 
            // linkLabel3
            // 
            this.linkLabel3.AutoSize = true;
            this.linkLabel3.BackColor = System.Drawing.Color.Transparent;
            this.linkLabel3.Location = new System.Drawing.Point(734, 451);
            this.linkLabel3.Name = "linkLabel3";
            this.linkLabel3.Size = new System.Drawing.Size(119, 12);
            this.linkLabel3.TabIndex = 7;
            this.linkLabel3.TabStop = true;
            this.linkLabel3.Text = "Save To Config File";
            this.linkLabel3.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel3_LinkClicked);
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.Filter = "Security Config File|*.xml";
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.BackColor = System.Drawing.Color.Transparent;
            this.linkLabel2.Location = new System.Drawing.Point(912, 157);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(29, 12);
            this.linkLabel2.TabIndex = 8;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "Open";
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "Inspriation Config File|*.xml";
            // 
            // linkLabel5
            // 
            this.linkLabel5.AutoSize = true;
            this.linkLabel5.BackColor = System.Drawing.Color.Transparent;
            this.linkLabel5.Location = new System.Drawing.Point(880, 451);
            this.linkLabel5.Name = "linkLabel5";
            this.linkLabel5.Size = new System.Drawing.Size(95, 12);
            this.linkLabel5.TabIndex = 10;
            this.linkLabel5.TabStop = true;
            this.linkLabel5.Text = "Close This Form";
            this.linkLabel5.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel5_LinkClicked);
            // 
            // linkLabel4
            // 
            this.linkLabel4.AutoSize = true;
            this.linkLabel4.BackColor = System.Drawing.Color.Transparent;
            this.linkLabel4.Location = new System.Drawing.Point(910, 22);
            this.linkLabel4.Name = "linkLabel4";
            this.linkLabel4.Size = new System.Drawing.Size(65, 12);
            this.linkLabel4.TabIndex = 11;
            this.linkLabel4.TabStop = true;
            this.linkLabel4.Text = "Close Form";
            this.linkLabel4.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel4_LinkClicked_1);
            // 
            // chk_using64
            // 
            this.chk_using64.AutoSize = true;
            this.chk_using64.BackColor = System.Drawing.Color.Transparent;
            this.chk_using64.Location = new System.Drawing.Point(301, 273);
            this.chk_using64.Name = "chk_using64";
            this.chk_using64.Size = new System.Drawing.Size(168, 16);
            this.chk_using64.TabIndex = 12;
            this.chk_using64.Text = "Use 64 bits Registry Key";
            this.chk_using64.UseVisualStyleBackColor = false;
            this.chk_using64.Visible = false;
            // 
            // ConfigFileForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = global::InstallShield.Properties.Resources.ConfigFileForm_fw;
            this.ClientSize = new System.Drawing.Size(1000, 700);
            this.Controls.Add(this.chk_using64);
            this.Controls.Add(this.linkLabel4);
            this.Controls.Add(this.linkLabel5);
            this.Controls.Add(this.linkLabel2);
            this.Controls.Add(this.linkLabel3);
            this.Controls.Add(this.txt_keycontent);
            this.Controls.Add(this.txt_keyfile);
            this.Controls.Add(this.txt_planname);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.txt_filename);
            this.Controls.Add(this.cmb_keytype);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ConfigFileForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ConfigFileForm";
            this.Load += new System.EventHandler(this.ConfigFileForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmb_keytype;
        private System.Windows.Forms.TextBox txt_filename;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.TextBox txt_planname;
        private System.Windows.Forms.TextBox txt_keyfile;
        private System.Windows.Forms.TextBox txt_keycontent;
        private System.Windows.Forms.LinkLabel linkLabel3;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.LinkLabel linkLabel5;
        private System.Windows.Forms.LinkLabel linkLabel4;
        private System.Windows.Forms.CheckBox chk_using64;
    }
}