namespace InstallShield
{
    partial class Mainform
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.securityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newConfigFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.productToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.productBaseInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clientConfigToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tokenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txt_selectedConfigFile = new System.Windows.Forms.TextBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.txt_key = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Transparent;
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.securityToolStripMenuItem,
            this.productToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(24, 119);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(217, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // securityToolStripMenuItem
            // 
            this.securityToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newConfigFileToolStripMenuItem,
            this.toolStripMenuItem1,
            this.exitToolStripMenuItem});
            this.securityToolStripMenuItem.Name = "securityToolStripMenuItem";
            this.securityToolStripMenuItem.Size = new System.Drawing.Size(39, 21);
            this.securityToolStripMenuItem.Text = "File";
            // 
            // newConfigFileToolStripMenuItem
            // 
            this.newConfigFileToolStripMenuItem.Name = "newConfigFileToolStripMenuItem";
            this.newConfigFileToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.newConfigFileToolStripMenuItem.Text = "New Config File";
            this.newConfigFileToolStripMenuItem.Click += new System.EventHandler(this.newConfigFileToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(164, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // productToolStripMenuItem
            // 
            this.productToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.productBaseInfoToolStripMenuItem,
            this.clientConfigToolStripMenuItem,
            this.tokenToolStripMenuItem});
            this.productToolStripMenuItem.Name = "productToolStripMenuItem";
            this.productToolStripMenuItem.Size = new System.Drawing.Size(170, 21);
            this.productToolStripMenuItem.Text = "Security And Performance";
            // 
            // productBaseInfoToolStripMenuItem
            // 
            this.productBaseInfoToolStripMenuItem.Name = "productBaseInfoToolStripMenuItem";
            this.productBaseInfoToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.productBaseInfoToolStripMenuItem.Text = "Product Basic Info";
            this.productBaseInfoToolStripMenuItem.Click += new System.EventHandler(this.productBaseInfoToolStripMenuItem_Click);
            // 
            // clientConfigToolStripMenuItem
            // 
            this.clientConfigToolStripMenuItem.Name = "clientConfigToolStripMenuItem";
            this.clientConfigToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.clientConfigToolStripMenuItem.Text = "Client Config";
            // 
            // tokenToolStripMenuItem
            // 
            this.tokenToolStripMenuItem.Name = "tokenToolStripMenuItem";
            this.tokenToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.tokenToolStripMenuItem.Text = "Token";
            // 
            // txt_selectedConfigFile
            // 
            this.txt_selectedConfigFile.Location = new System.Drawing.Point(191, 214);
            this.txt_selectedConfigFile.Name = "txt_selectedConfigFile";
            this.txt_selectedConfigFile.Size = new System.Drawing.Size(567, 21);
            this.txt_selectedConfigFile.TabIndex = 1;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.BackColor = System.Drawing.Color.Transparent;
            this.linkLabel1.LinkColor = System.Drawing.Color.White;
            this.linkLabel1.Location = new System.Drawing.Point(804, 219);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(59, 12);
            this.linkLabel1.TabIndex = 4;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Open File";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            this.openFileDialog.Filter = "Config File|*.xml";
            // 
            // txt_key
            // 
            this.txt_key.Location = new System.Drawing.Point(130, 166);
            this.txt_key.Name = "txt_key";
            this.txt_key.Size = new System.Drawing.Size(749, 21);
            this.txt_key.TabIndex = 5;
            // 
            // Mainform
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = global::InstallShield.Properties.Resources.mainform_fw;
            this.ClientSize = new System.Drawing.Size(900, 700);
            this.Controls.Add(this.txt_key);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.txt_selectedConfigFile);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Mainform";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inspration Online Management";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem securityToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newConfigFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem productToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem productBaseInfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clientConfigToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tokenToolStripMenuItem;
        private System.Windows.Forms.TextBox txt_selectedConfigFile;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.TextBox txt_key;
    }
}