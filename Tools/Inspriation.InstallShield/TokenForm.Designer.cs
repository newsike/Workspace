namespace InstallShield
{
    partial class TokenForm
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
            this.txt_token = new System.Windows.Forms.TextBox();
            this.cmb_bindingpro = new System.Windows.Forms.ComboBox();
            this.cmb_bindingclient = new System.Windows.Forms.ComboBox();
            this.txt_maxrequest = new System.Windows.Forms.TextBox();
            this.chk_unlimited = new System.Windows.Forms.CheckBox();
            this.cmb_priority = new System.Windows.Forms.ComboBox();
            this.chk_deniedWMRO = new System.Windows.Forms.CheckBox();
            this.linkLabel4 = new System.Windows.Forms.LinkLabel();
            this.txt_timeout = new System.Windows.Forms.TextBox();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.linkLabel3 = new System.Windows.Forms.LinkLabel();
            this.lb_count_tokens = new System.Windows.Forms.Label();
            this.lb_count_request = new System.Windows.Forms.Label();
            this.lb_count_products = new System.Windows.Forms.Label();
            this.lb_count_clients = new System.Windows.Forms.Label();
            this.cmb_tokens = new System.Windows.Forms.ComboBox();
            this.linkLabel5 = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // txt_token
            // 
            this.txt_token.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_token.Location = new System.Drawing.Point(137, 155);
            this.txt_token.Name = "txt_token";
            this.txt_token.Size = new System.Drawing.Size(318, 14);
            this.txt_token.TabIndex = 7;
            // 
            // cmb_bindingpro
            // 
            this.cmb_bindingpro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmb_bindingpro.FormattingEnabled = true;
            this.cmb_bindingpro.Location = new System.Drawing.Point(164, 188);
            this.cmb_bindingpro.Name = "cmb_bindingpro";
            this.cmb_bindingpro.Size = new System.Drawing.Size(311, 20);
            this.cmb_bindingpro.TabIndex = 8;
            // 
            // cmb_bindingclient
            // 
            this.cmb_bindingclient.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmb_bindingclient.FormattingEnabled = true;
            this.cmb_bindingclient.Location = new System.Drawing.Point(634, 188);
            this.cmb_bindingclient.Name = "cmb_bindingclient";
            this.cmb_bindingclient.Size = new System.Drawing.Size(347, 20);
            this.cmb_bindingclient.TabIndex = 9;
            // 
            // txt_maxrequest
            // 
            this.txt_maxrequest.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_maxrequest.Location = new System.Drawing.Point(195, 229);
            this.txt_maxrequest.Name = "txt_maxrequest";
            this.txt_maxrequest.Size = new System.Drawing.Size(293, 14);
            this.txt_maxrequest.TabIndex = 10;
            this.txt_maxrequest.Text = "2";
            // 
            // chk_unlimited
            // 
            this.chk_unlimited.AutoSize = true;
            this.chk_unlimited.BackColor = System.Drawing.Color.Transparent;
            this.chk_unlimited.Location = new System.Drawing.Point(584, 229);
            this.chk_unlimited.Name = "chk_unlimited";
            this.chk_unlimited.Size = new System.Drawing.Size(15, 14);
            this.chk_unlimited.TabIndex = 11;
            this.chk_unlimited.UseVisualStyleBackColor = false;
            // 
            // cmb_priority
            // 
            this.cmb_priority.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmb_priority.FormattingEnabled = true;
            this.cmb_priority.Items.AddRange(new object[] {
            "Below Normal",
            "Normal",
            "Above Normal",
            "Speceial",
            "Super"});
            this.cmb_priority.Location = new System.Drawing.Point(137, 261);
            this.cmb_priority.Name = "cmb_priority";
            this.cmb_priority.Size = new System.Drawing.Size(338, 20);
            this.cmb_priority.TabIndex = 12;
            // 
            // chk_deniedWMRO
            // 
            this.chk_deniedWMRO.AutoSize = true;
            this.chk_deniedWMRO.BackColor = System.Drawing.Color.Transparent;
            this.chk_deniedWMRO.Location = new System.Drawing.Point(830, 329);
            this.chk_deniedWMRO.Name = "chk_deniedWMRO";
            this.chk_deniedWMRO.Size = new System.Drawing.Size(15, 14);
            this.chk_deniedWMRO.TabIndex = 13;
            this.chk_deniedWMRO.UseVisualStyleBackColor = false;
            // 
            // linkLabel4
            // 
            this.linkLabel4.AutoSize = true;
            this.linkLabel4.BackColor = System.Drawing.Color.Transparent;
            this.linkLabel4.Location = new System.Drawing.Point(221, 595);
            this.linkLabel4.Name = "linkLabel4";
            this.linkLabel4.Size = new System.Drawing.Size(185, 12);
            this.linkLabel4.TabIndex = 14;
            this.linkLabel4.TabStop = true;
            this.linkLabel4.Text = "Action To Save Configs To File";
            this.linkLabel4.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel4_LinkClicked);
            // 
            // txt_timeout
            // 
            this.txt_timeout.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_timeout.Location = new System.Drawing.Point(266, 329);
            this.txt_timeout.Name = "txt_timeout";
            this.txt_timeout.Size = new System.Drawing.Size(152, 14);
            this.txt_timeout.TabIndex = 15;
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.BackColor = System.Drawing.Color.Transparent;
            this.linkLabel2.Location = new System.Drawing.Point(546, 595);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(251, 12);
            this.linkLabel2.TabIndex = 16;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "Action To Remove Selected Token From File";
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // linkLabel3
            // 
            this.linkLabel3.AutoSize = true;
            this.linkLabel3.BackColor = System.Drawing.Color.Transparent;
            this.linkLabel3.Location = new System.Drawing.Point(801, 449);
            this.linkLabel3.Name = "linkLabel3";
            this.linkLabel3.Size = new System.Drawing.Size(65, 12);
            this.linkLabel3.TabIndex = 17;
            this.linkLabel3.TabStop = true;
            this.linkLabel3.Text = "Click Here";
            // 
            // lb_count_tokens
            // 
            this.lb_count_tokens.AutoSize = true;
            this.lb_count_tokens.BackColor = System.Drawing.Color.Transparent;
            this.lb_count_tokens.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_count_tokens.ForeColor = System.Drawing.Color.White;
            this.lb_count_tokens.Location = new System.Drawing.Point(341, 428);
            this.lb_count_tokens.Name = "lb_count_tokens";
            this.lb_count_tokens.Size = new System.Drawing.Size(12, 12);
            this.lb_count_tokens.TabIndex = 18;
            this.lb_count_tokens.Text = "0";
            // 
            // lb_count_request
            // 
            this.lb_count_request.AutoSize = true;
            this.lb_count_request.Location = new System.Drawing.Point(570, 428);
            this.lb_count_request.Name = "lb_count_request";
            this.lb_count_request.Size = new System.Drawing.Size(11, 12);
            this.lb_count_request.TabIndex = 19;
            this.lb_count_request.Text = "0";
            // 
            // lb_count_products
            // 
            this.lb_count_products.AutoSize = true;
            this.lb_count_products.Location = new System.Drawing.Point(341, 474);
            this.lb_count_products.Name = "lb_count_products";
            this.lb_count_products.Size = new System.Drawing.Size(11, 12);
            this.lb_count_products.TabIndex = 20;
            this.lb_count_products.Text = "0";
            // 
            // lb_count_clients
            // 
            this.lb_count_clients.AutoSize = true;
            this.lb_count_clients.Location = new System.Drawing.Point(570, 474);
            this.lb_count_clients.Name = "lb_count_clients";
            this.lb_count_clients.Size = new System.Drawing.Size(11, 12);
            this.lb_count_clients.TabIndex = 21;
            this.lb_count_clients.Text = "0";
            // 
            // cmb_tokens
            // 
            this.cmb_tokens.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmb_tokens.FormattingEnabled = true;
            this.cmb_tokens.Location = new System.Drawing.Point(581, 154);
            this.cmb_tokens.Name = "cmb_tokens";
            this.cmb_tokens.Size = new System.Drawing.Size(285, 20);
            this.cmb_tokens.TabIndex = 22;
            // 
            // linkLabel5
            // 
            this.linkLabel5.AutoSize = true;
            this.linkLabel5.BackColor = System.Drawing.Color.Transparent;
            this.linkLabel5.Location = new System.Drawing.Point(900, 157);
            this.linkLabel5.Name = "linkLabel5";
            this.linkLabel5.Size = new System.Drawing.Size(65, 12);
            this.linkLabel5.TabIndex = 23;
            this.linkLabel5.TabStop = true;
            this.linkLabel5.Text = "Load Token";
            this.linkLabel5.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel5_LinkClicked);
            // 
            // TokenForm
            // 
            this.BackgroundImage = global::InstallShield.Properties.Resources.TokenForm_fw;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1000, 700);
            this.Controls.Add(this.linkLabel5);
            this.Controls.Add(this.cmb_tokens);
            this.Controls.Add(this.lb_count_clients);
            this.Controls.Add(this.lb_count_products);
            this.Controls.Add(this.lb_count_request);
            this.Controls.Add(this.lb_count_tokens);
            this.Controls.Add(this.linkLabel3);
            this.Controls.Add(this.linkLabel2);
            this.Controls.Add(this.txt_timeout);
            this.Controls.Add(this.linkLabel4);
            this.Controls.Add(this.chk_deniedWMRO);
            this.Controls.Add(this.cmb_priority);
            this.Controls.Add(this.chk_unlimited);
            this.Controls.Add(this.txt_maxrequest);
            this.Controls.Add(this.cmb_bindingclient);
            this.Controls.Add(this.cmb_bindingpro);
            this.Controls.Add(this.txt_token);
            this.Name = "TokenForm";
            this.Load += new System.EventHandler(this.TokenForm_Load);
            this.Controls.SetChildIndex(this.txt_token, 0);
            this.Controls.SetChildIndex(this.cmb_bindingpro, 0);
            this.Controls.SetChildIndex(this.cmb_bindingclient, 0);
            this.Controls.SetChildIndex(this.txt_maxrequest, 0);
            this.Controls.SetChildIndex(this.chk_unlimited, 0);
            this.Controls.SetChildIndex(this.cmb_priority, 0);
            this.Controls.SetChildIndex(this.chk_deniedWMRO, 0);
            this.Controls.SetChildIndex(this.linkLabel4, 0);
            this.Controls.SetChildIndex(this.txt_timeout, 0);
            this.Controls.SetChildIndex(this.linkLabel2, 0);
            this.Controls.SetChildIndex(this.linkLabel3, 0);
            this.Controls.SetChildIndex(this.lb_count_tokens, 0);
            this.Controls.SetChildIndex(this.lb_count_request, 0);
            this.Controls.SetChildIndex(this.lb_count_products, 0);
            this.Controls.SetChildIndex(this.lb_count_clients, 0);
            this.Controls.SetChildIndex(this.cmb_tokens, 0);
            this.Controls.SetChildIndex(this.linkLabel5, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_token;
        private System.Windows.Forms.ComboBox cmb_bindingpro;
        private System.Windows.Forms.ComboBox cmb_bindingclient;
        private System.Windows.Forms.TextBox txt_maxrequest;
        private System.Windows.Forms.CheckBox chk_unlimited;
        private System.Windows.Forms.ComboBox cmb_priority;
        private System.Windows.Forms.CheckBox chk_deniedWMRO;
        private System.Windows.Forms.LinkLabel linkLabel4;
        private System.Windows.Forms.TextBox txt_timeout;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.LinkLabel linkLabel3;
        private System.Windows.Forms.Label lb_count_tokens;
        private System.Windows.Forms.Label lb_count_request;
        private System.Windows.Forms.Label lb_count_products;
        private System.Windows.Forms.Label lb_count_clients;
        private System.Windows.Forms.ComboBox cmb_tokens;
        private System.Windows.Forms.LinkLabel linkLabel5;
    }
}
