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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Mainform));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.securityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newConfigFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.productToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.productBaseInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clientConfigToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tokenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.commonAttrsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deployInspriationTokenRSWCFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.databaseOperationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.prefenenceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.commonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.emailServicesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txt_selectedConfigFile = new System.Windows.Forms.TextBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.txt_key = new System.Windows.Forms.TextBox();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.lab_filestatus = new System.Windows.Forms.Label();
            this.securityCodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Transparent;
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.securityToolStripMenuItem,
            this.productToolStripMenuItem,
            this.toolStripMenuItem2,
            this.prefenenceToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(24, 119);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(445, 25);
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
            this.tokenToolStripMenuItem,
            this.securityCodeToolStripMenuItem});
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
            this.clientConfigToolStripMenuItem.Click += new System.EventHandler(this.clientConfigToolStripMenuItem_Click);
            // 
            // tokenToolStripMenuItem
            // 
            this.tokenToolStripMenuItem.Name = "tokenToolStripMenuItem";
            this.tokenToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.tokenToolStripMenuItem.Text = "Token";
            this.tokenToolStripMenuItem.Click += new System.EventHandler(this.tokenToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem3,
            this.commonAttrsToolStripMenuItem,
            this.deployInspriationTokenRSWCFToolStripMenuItem,
            this.databaseOperationToolStripMenuItem});
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(52, 21);
            this.toolStripMenuItem2.Text = "Tools";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(267, 22);
            this.toolStripMenuItem3.Text = "Family Testor";
            // 
            // commonAttrsToolStripMenuItem
            // 
            this.commonAttrsToolStripMenuItem.Name = "commonAttrsToolStripMenuItem";
            this.commonAttrsToolStripMenuItem.Size = new System.Drawing.Size(267, 22);
            this.commonAttrsToolStripMenuItem.Text = "Common Attrs";
            this.commonAttrsToolStripMenuItem.Click += new System.EventHandler(this.commonAttrsToolStripMenuItem_Click);
            // 
            // deployInspriationTokenRSWCFToolStripMenuItem
            // 
            this.deployInspriationTokenRSWCFToolStripMenuItem.Name = "deployInspriationTokenRSWCFToolStripMenuItem";
            this.deployInspriationTokenRSWCFToolStripMenuItem.Size = new System.Drawing.Size(267, 22);
            this.deployInspriationTokenRSWCFToolStripMenuItem.Text = "Deploy Inspriation.TokenRS WCF";
            // 
            // databaseOperationToolStripMenuItem
            // 
            this.databaseOperationToolStripMenuItem.Name = "databaseOperationToolStripMenuItem";
            this.databaseOperationToolStripMenuItem.Size = new System.Drawing.Size(267, 22);
            this.databaseOperationToolStripMenuItem.Text = "Database Operation";
            this.databaseOperationToolStripMenuItem.Click += new System.EventHandler(this.databaseOperationToolStripMenuItem_Click);
            // 
            // prefenenceToolStripMenuItem
            // 
            this.prefenenceToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.commonToolStripMenuItem,
            this.emailServicesToolStripMenuItem});
            this.prefenenceToolStripMenuItem.Name = "prefenenceToolStripMenuItem";
            this.prefenenceToolStripMenuItem.Size = new System.Drawing.Size(84, 21);
            this.prefenenceToolStripMenuItem.Text = "Prefenence";
            // 
            // commonToolStripMenuItem
            // 
            this.commonToolStripMenuItem.Name = "commonToolStripMenuItem";
            this.commonToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.commonToolStripMenuItem.Text = "Common";
            // 
            // emailServicesToolStripMenuItem
            // 
            this.emailServicesToolStripMenuItem.Name = "emailServicesToolStripMenuItem";
            this.emailServicesToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.emailServicesToolStripMenuItem.Text = "Email Services";
            this.emailServicesToolStripMenuItem.Click += new System.EventHandler(this.emailServicesToolStripMenuItem_Click);
            // 
            // txt_selectedConfigFile
            // 
            this.txt_selectedConfigFile.Location = new System.Drawing.Point(193, 214);
            this.txt_selectedConfigFile.Name = "txt_selectedConfigFile";
            this.txt_selectedConfigFile.Size = new System.Drawing.Size(567, 21);
            this.txt_selectedConfigFile.TabIndex = 1;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.BackColor = System.Drawing.Color.Transparent;
            this.linkLabel1.LinkColor = System.Drawing.Color.White;
            this.linkLabel1.Location = new System.Drawing.Point(798, 217);
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
            this.txt_key.Location = new System.Drawing.Point(123, 166);
            this.txt_key.Name = "txt_key";
            this.txt_key.Size = new System.Drawing.Size(754, 21);
            this.txt_key.TabIndex = 5;
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.BackColor = System.Drawing.Color.Transparent;
            this.linkLabel2.Location = new System.Drawing.Point(765, 77);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(101, 12);
            this.linkLabel2.TabIndex = 6;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "Exit Inspriation";
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // lab_filestatus
            // 
            this.lab_filestatus.AutoSize = true;
            this.lab_filestatus.BackColor = System.Drawing.Color.Transparent;
            this.lab_filestatus.Location = new System.Drawing.Point(298, 245);
            this.lab_filestatus.Name = "lab_filestatus";
            this.lab_filestatus.Size = new System.Drawing.Size(233, 12);
            this.lab_filestatus.TabIndex = 7;
            this.lab_filestatus.Text = "No active config file selected by user";
            // 
            // securityCodeToolStripMenuItem
            // 
            this.securityCodeToolStripMenuItem.Name = "securityCodeToolStripMenuItem";
            this.securityCodeToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.securityCodeToolStripMenuItem.Text = "Security Code";
            this.securityCodeToolStripMenuItem.Click += new System.EventHandler(this.securityCodeToolStripMenuItem_Click);
            // 
            // Mainform
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = global::InstallShield.Properties.Resources.mainform_fw;
            this.ClientSize = new System.Drawing.Size(900, 700);
            this.Controls.Add(this.lab_filestatus);
            this.Controls.Add(this.linkLabel2);
            this.Controls.Add(this.txt_key);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.txt_selectedConfigFile);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Mainform";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inspration Online Management";
            this.Load += new System.EventHandler(this.Mainform_Load);
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
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.Label lab_filestatus;
        private System.Windows.Forms.ToolStripMenuItem prefenenceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem commonToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem emailServicesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem commonAttrsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deployInspriationTokenRSWCFToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem databaseOperationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem securityCodeToolStripMenuItem;
    }
}