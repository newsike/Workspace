namespace InstallShield
{
    partial class ProductForm
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
            this.cmb_proname = new System.Windows.Forms.ComboBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.cmb_protype = new System.Windows.Forms.ComboBox();
            this.txt_entrance = new System.Windows.Forms.TextBox();
            this.cmb_startmode = new System.Windows.Forms.ComboBox();
            this.linkLabel3 = new System.Windows.Forms.LinkLabel();
            this.linkLabel4 = new System.Windows.Forms.LinkLabel();
            this.linkLabel5 = new System.Windows.Forms.LinkLabel();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.lb_uploadedimage = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmb_proname
            // 
            this.cmb_proname.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmb_proname.FormattingEnabled = true;
            this.cmb_proname.Location = new System.Drawing.Point(150, 154);
            this.cmb_proname.Name = "cmb_proname";
            this.cmb_proname.Size = new System.Drawing.Size(656, 20);
            this.cmb_proname.TabIndex = 0;
            this.cmb_proname.SelectedIndexChanged += new System.EventHandler(this.cmb_proname_SelectedIndexChanged);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.BackColor = System.Drawing.Color.Transparent;
            this.linkLabel1.Location = new System.Drawing.Point(833, 157);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(65, 12);
            this.linkLabel1.TabIndex = 3;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Create New";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.BackColor = System.Drawing.Color.Transparent;
            this.linkLabel2.Location = new System.Drawing.Point(919, 157);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(41, 12);
            this.linkLabel2.TabIndex = 4;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "Remove";
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // cmb_protype
            // 
            this.cmb_protype.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmb_protype.FormattingEnabled = true;
            this.cmb_protype.Items.AddRange(new object[] {
            "Web Application",
            "Windows Form"});
            this.cmb_protype.Location = new System.Drawing.Point(150, 191);
            this.cmb_protype.Name = "cmb_protype";
            this.cmb_protype.Size = new System.Drawing.Size(656, 20);
            this.cmb_protype.TabIndex = 5;
            // 
            // txt_entrance
            // 
            this.txt_entrance.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_entrance.Location = new System.Drawing.Point(177, 233);
            this.txt_entrance.Name = "txt_entrance";
            this.txt_entrance.Size = new System.Drawing.Size(800, 14);
            this.txt_entrance.TabIndex = 6;
            // 
            // cmb_startmode
            // 
            this.cmb_startmode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmb_startmode.FormattingEnabled = true;
            this.cmb_startmode.Items.AddRange(new object[] {
            "X01-Start Application OnLine ( For windows form or web )",
            "X02-Download Application ( Just for windows form )"});
            this.cmb_startmode.Location = new System.Drawing.Point(231, 270);
            this.cmb_startmode.Name = "cmb_startmode";
            this.cmb_startmode.Size = new System.Drawing.Size(575, 20);
            this.cmb_startmode.TabIndex = 7;
            // 
            // linkLabel3
            // 
            this.linkLabel3.AutoSize = true;
            this.linkLabel3.BackColor = System.Drawing.Color.Transparent;
            this.linkLabel3.LinkColor = System.Drawing.Color.White;
            this.linkLabel3.Location = new System.Drawing.Point(811, 463);
            this.linkLabel3.Name = "linkLabel3";
            this.linkLabel3.Size = new System.Drawing.Size(101, 12);
            this.linkLabel3.TabIndex = 8;
            this.linkLabel3.TabStop = true;
            this.linkLabel3.Text = "Action To Update";
            this.linkLabel3.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel3_LinkClicked);
            // 
            // linkLabel4
            // 
            this.linkLabel4.AutoSize = true;
            this.linkLabel4.BackColor = System.Drawing.Color.Transparent;
            this.linkLabel4.Location = new System.Drawing.Point(771, 541);
            this.linkLabel4.Name = "linkLabel4";
            this.linkLabel4.Size = new System.Drawing.Size(185, 12);
            this.linkLabel4.TabIndex = 9;
            this.linkLabel4.TabStop = true;
            this.linkLabel4.Text = "Action To Save Configs To File";
            this.linkLabel4.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel4_LinkClicked);
            // 
            // linkLabel5
            // 
            this.linkLabel5.AutoSize = true;
            this.linkLabel5.BackColor = System.Drawing.Color.Transparent;
            this.linkLabel5.Location = new System.Drawing.Point(188, 314);
            this.linkLabel5.Name = "linkLabel5";
            this.linkLabel5.Size = new System.Drawing.Size(167, 12);
            this.linkLabel5.TabIndex = 10;
            this.linkLabel5.TabStop = true;
            this.linkLabel5.Text = "Action To Upload The Images";
            this.linkLabel5.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel5_LinkClicked);
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "GIF|*.GIF|PNG|*.PNG|JPG|*.JPG|JPEG|*.JPEG";
            // 
            // lb_uploadedimage
            // 
            this.lb_uploadedimage.AutoSize = true;
            this.lb_uploadedimage.BackColor = System.Drawing.Color.Transparent;
            this.lb_uploadedimage.Location = new System.Drawing.Point(738, 314);
            this.lb_uploadedimage.Name = "lb_uploadedimage";
            this.lb_uploadedimage.Size = new System.Drawing.Size(107, 12);
            this.lb_uploadedimage.TabIndex = 11;
            this.lb_uploadedimage.Text = "No Image Uploaded";
            // 
            // ProductForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::InstallShield.Properties.Resources.ProductForm_fw;
            this.ClientSize = new System.Drawing.Size(1000, 700);
            this.Controls.Add(this.lb_uploadedimage);
            this.Controls.Add(this.linkLabel5);
            this.Controls.Add(this.linkLabel4);
            this.Controls.Add(this.linkLabel3);
            this.Controls.Add(this.cmb_startmode);
            this.Controls.Add(this.txt_entrance);
            this.Controls.Add(this.cmb_protype);
            this.Controls.Add(this.linkLabel2);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.cmb_proname);
            this.Name = "ProductForm";
            this.Text = "ProductForm";
            this.Load += new System.EventHandler(this.ProductForm_Load);
            this.Controls.SetChildIndex(this.cmb_proname, 0);
            this.Controls.SetChildIndex(this.linkLabel1, 0);
            this.Controls.SetChildIndex(this.linkLabel2, 0);
            this.Controls.SetChildIndex(this.cmb_protype, 0);
            this.Controls.SetChildIndex(this.txt_entrance, 0);
            this.Controls.SetChildIndex(this.cmb_startmode, 0);
            this.Controls.SetChildIndex(this.linkLabel3, 0);
            this.Controls.SetChildIndex(this.linkLabel4, 0);
            this.Controls.SetChildIndex(this.linkLabel5, 0);
            this.Controls.SetChildIndex(this.lb_uploadedimage, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmb_proname;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.ComboBox cmb_protype;
        private System.Windows.Forms.TextBox txt_entrance;
        private System.Windows.Forms.ComboBox cmb_startmode;
        private System.Windows.Forms.LinkLabel linkLabel3;
        private System.Windows.Forms.LinkLabel linkLabel4;
        private System.Windows.Forms.LinkLabel linkLabel5;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Label lb_uploadedimage;
    }
}