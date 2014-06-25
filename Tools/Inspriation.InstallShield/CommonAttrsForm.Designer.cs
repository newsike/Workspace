namespace InstallShield
{
    partial class CommonAttrsForm
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
            this.cmb_node = new System.Windows.Forms.ComboBox();
            this.txt_nodevalue = new System.Windows.Forms.TextBox();
            this.cmb_secondnode = new System.Windows.Forms.ComboBox();
            this.txt_childvalue = new System.Windows.Forms.TextBox();
            this.cmb_attrs = new System.Windows.Forms.ComboBox();
            this.txt_attrValue = new System.Windows.Forms.TextBox();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.linkLabel3 = new System.Windows.Forms.LinkLabel();
            this.linkLabel5 = new System.Windows.Forms.LinkLabel();
            this.linkLabel6 = new System.Windows.Forms.LinkLabel();
            this.linkLabel9 = new System.Windows.Forms.LinkLabel();
            this.linkLabel10 = new System.Windows.Forms.LinkLabel();
            this.linkLabel11 = new System.Windows.Forms.LinkLabel();
            this.lab_selectednode = new System.Windows.Forms.Label();
            this.lab_isfirstlevelselected = new System.Windows.Forms.Label();
            this.lab_attrnodeselected = new System.Windows.Forms.Label();
            this.linkLabel4 = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // cmb_node
            // 
            this.cmb_node.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmb_node.FormattingEnabled = true;
            this.cmb_node.Location = new System.Drawing.Point(240, 153);
            this.cmb_node.Name = "cmb_node";
            this.cmb_node.Size = new System.Drawing.Size(554, 20);
            this.cmb_node.TabIndex = 4;
            this.cmb_node.SelectedIndexChanged += new System.EventHandler(this.cmb_node_SelectedIndexChanged);
            // 
            // txt_nodevalue
            // 
            this.txt_nodevalue.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_nodevalue.Location = new System.Drawing.Point(240, 199);
            this.txt_nodevalue.Name = "txt_nodevalue";
            this.txt_nodevalue.Size = new System.Drawing.Size(554, 14);
            this.txt_nodevalue.TabIndex = 6;
            // 
            // cmb_secondnode
            // 
            this.cmb_secondnode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmb_secondnode.FormattingEnabled = true;
            this.cmb_secondnode.Location = new System.Drawing.Point(240, 271);
            this.cmb_secondnode.Name = "cmb_secondnode";
            this.cmb_secondnode.Size = new System.Drawing.Size(554, 20);
            this.cmb_secondnode.TabIndex = 7;
            this.cmb_secondnode.SelectedIndexChanged += new System.EventHandler(this.cmb_secondnode_SelectedIndexChanged);
            // 
            // txt_childvalue
            // 
            this.txt_childvalue.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_childvalue.Location = new System.Drawing.Point(240, 318);
            this.txt_childvalue.Name = "txt_childvalue";
            this.txt_childvalue.Size = new System.Drawing.Size(554, 14);
            this.txt_childvalue.TabIndex = 8;
            // 
            // cmb_attrs
            // 
            this.cmb_attrs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmb_attrs.FormattingEnabled = true;
            this.cmb_attrs.Location = new System.Drawing.Point(268, 430);
            this.cmb_attrs.Name = "cmb_attrs";
            this.cmb_attrs.Size = new System.Drawing.Size(526, 20);
            this.cmb_attrs.TabIndex = 9;
            this.cmb_attrs.SelectedIndexChanged += new System.EventHandler(this.cmb_attrs_SelectedIndexChanged);
            // 
            // txt_attrValue
            // 
            this.txt_attrValue.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_attrValue.Location = new System.Drawing.Point(252, 473);
            this.txt_attrValue.Name = "txt_attrValue";
            this.txt_attrValue.Size = new System.Drawing.Size(542, 14);
            this.txt_attrValue.TabIndex = 10;
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.BackColor = System.Drawing.Color.Transparent;
            this.linkLabel2.Location = new System.Drawing.Point(840, 178);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(65, 12);
            this.linkLabel2.TabIndex = 11;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "Create New";
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // linkLabel3
            // 
            this.linkLabel3.AutoSize = true;
            this.linkLabel3.BackColor = System.Drawing.Color.Transparent;
            this.linkLabel3.Location = new System.Drawing.Point(931, 178);
            this.linkLabel3.Name = "linkLabel3";
            this.linkLabel3.Size = new System.Drawing.Size(41, 12);
            this.linkLabel3.TabIndex = 12;
            this.linkLabel3.TabStop = true;
            this.linkLabel3.Text = "Remove";
            this.linkLabel3.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel3_LinkClicked);
            // 
            // linkLabel5
            // 
            this.linkLabel5.AutoSize = true;
            this.linkLabel5.BackColor = System.Drawing.Color.Transparent;
            this.linkLabel5.Location = new System.Drawing.Point(840, 295);
            this.linkLabel5.Name = "linkLabel5";
            this.linkLabel5.Size = new System.Drawing.Size(65, 12);
            this.linkLabel5.TabIndex = 14;
            this.linkLabel5.TabStop = true;
            this.linkLabel5.Text = "Create New";
            this.linkLabel5.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel5_LinkClicked);
            // 
            // linkLabel6
            // 
            this.linkLabel6.AutoSize = true;
            this.linkLabel6.BackColor = System.Drawing.Color.Transparent;
            this.linkLabel6.Location = new System.Drawing.Point(931, 295);
            this.linkLabel6.Name = "linkLabel6";
            this.linkLabel6.Size = new System.Drawing.Size(41, 12);
            this.linkLabel6.TabIndex = 15;
            this.linkLabel6.TabStop = true;
            this.linkLabel6.Text = "Remove";
            this.linkLabel6.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel6_LinkClicked);
            // 
            // linkLabel9
            // 
            this.linkLabel9.AutoSize = true;
            this.linkLabel9.BackColor = System.Drawing.Color.Transparent;
            this.linkLabel9.Location = new System.Drawing.Point(931, 438);
            this.linkLabel9.Name = "linkLabel9";
            this.linkLabel9.Size = new System.Drawing.Size(41, 12);
            this.linkLabel9.TabIndex = 19;
            this.linkLabel9.TabStop = true;
            this.linkLabel9.Text = "Remove";
            this.linkLabel9.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel9_LinkClicked);
            // 
            // linkLabel10
            // 
            this.linkLabel10.AutoSize = true;
            this.linkLabel10.BackColor = System.Drawing.Color.Transparent;
            this.linkLabel10.Location = new System.Drawing.Point(840, 438);
            this.linkLabel10.Name = "linkLabel10";
            this.linkLabel10.Size = new System.Drawing.Size(65, 12);
            this.linkLabel10.TabIndex = 18;
            this.linkLabel10.TabStop = true;
            this.linkLabel10.Text = "Create New";
            this.linkLabel10.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel10_LinkClicked);
            // 
            // linkLabel11
            // 
            this.linkLabel11.AutoSize = true;
            this.linkLabel11.BackColor = System.Drawing.Color.Transparent;
            this.linkLabel11.Location = new System.Drawing.Point(840, 475);
            this.linkLabel11.Name = "linkLabel11";
            this.linkLabel11.Size = new System.Drawing.Size(41, 12);
            this.linkLabel11.TabIndex = 20;
            this.linkLabel11.TabStop = true;
            this.linkLabel11.Text = "Update";
            this.linkLabel11.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel11_LinkClicked);
            // 
            // lab_selectednode
            // 
            this.lab_selectednode.AutoSize = true;
            this.lab_selectednode.BackColor = System.Drawing.Color.Transparent;
            this.lab_selectednode.Location = new System.Drawing.Point(383, 239);
            this.lab_selectednode.Name = "lab_selectednode";
            this.lab_selectednode.Size = new System.Drawing.Size(101, 12);
            this.lab_selectednode.TabIndex = 21;
            this.lab_selectednode.Text = "No Node Selected";
            // 
            // lab_isfirstlevelselected
            // 
            this.lab_isfirstlevelselected.AutoSize = true;
            this.lab_isfirstlevelselected.BackColor = System.Drawing.Color.Transparent;
            this.lab_isfirstlevelselected.Location = new System.Drawing.Point(820, 373);
            this.lab_isfirstlevelselected.Name = "lab_isfirstlevelselected";
            this.lab_isfirstlevelselected.Size = new System.Drawing.Size(29, 12);
            this.lab_isfirstlevelselected.TabIndex = 22;
            this.lab_isfirstlevelselected.Text = "None";
            // 
            // lab_attrnodeselected
            // 
            this.lab_attrnodeselected.AutoSize = true;
            this.lab_attrnodeselected.BackColor = System.Drawing.Color.Transparent;
            this.lab_attrnodeselected.Location = new System.Drawing.Point(204, 373);
            this.lab_attrnodeselected.Name = "lab_attrnodeselected";
            this.lab_attrnodeselected.Size = new System.Drawing.Size(101, 12);
            this.lab_attrnodeselected.TabIndex = 23;
            this.lab_attrnodeselected.Text = "No Node Selected";
            // 
            // linkLabel4
            // 
            this.linkLabel4.AutoSize = true;
            this.linkLabel4.BackColor = System.Drawing.Color.Transparent;
            this.linkLabel4.Location = new System.Drawing.Point(774, 550);
            this.linkLabel4.Name = "linkLabel4";
            this.linkLabel4.Size = new System.Drawing.Size(161, 12);
            this.linkLabel4.TabIndex = 24;
            this.linkLabel4.TabStop = true;
            this.linkLabel4.Text = "Action To Save All Changes";
            this.linkLabel4.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel4_LinkClicked_1);
            // 
            // CommonAttrsForm
            // 
            this.BackgroundImage = global::InstallShield.Properties.Resources.CommonAttrsForm_fw;
            this.ClientSize = new System.Drawing.Size(1000, 700);
            this.Controls.Add(this.linkLabel4);
            this.Controls.Add(this.lab_attrnodeselected);
            this.Controls.Add(this.lab_isfirstlevelselected);
            this.Controls.Add(this.lab_selectednode);
            this.Controls.Add(this.linkLabel11);
            this.Controls.Add(this.linkLabel9);
            this.Controls.Add(this.linkLabel10);
            this.Controls.Add(this.linkLabel6);
            this.Controls.Add(this.linkLabel5);
            this.Controls.Add(this.linkLabel3);
            this.Controls.Add(this.linkLabel2);
            this.Controls.Add(this.txt_attrValue);
            this.Controls.Add(this.cmb_attrs);
            this.Controls.Add(this.txt_childvalue);
            this.Controls.Add(this.cmb_secondnode);
            this.Controls.Add(this.txt_nodevalue);
            this.Controls.Add(this.cmb_node);
            this.Name = "CommonAttrsForm";
            this.Load += new System.EventHandler(this.CommonAttrsForm_Load);
            this.Controls.SetChildIndex(this.cmb_node, 0);
            this.Controls.SetChildIndex(this.txt_nodevalue, 0);
            this.Controls.SetChildIndex(this.cmb_secondnode, 0);
            this.Controls.SetChildIndex(this.txt_childvalue, 0);
            this.Controls.SetChildIndex(this.cmb_attrs, 0);
            this.Controls.SetChildIndex(this.txt_attrValue, 0);
            this.Controls.SetChildIndex(this.linkLabel2, 0);
            this.Controls.SetChildIndex(this.linkLabel3, 0);
            this.Controls.SetChildIndex(this.linkLabel5, 0);
            this.Controls.SetChildIndex(this.linkLabel6, 0);
            this.Controls.SetChildIndex(this.linkLabel10, 0);
            this.Controls.SetChildIndex(this.linkLabel9, 0);
            this.Controls.SetChildIndex(this.linkLabel11, 0);
            this.Controls.SetChildIndex(this.lab_selectednode, 0);
            this.Controls.SetChildIndex(this.lab_isfirstlevelselected, 0);
            this.Controls.SetChildIndex(this.lab_attrnodeselected, 0);
            this.Controls.SetChildIndex(this.linkLabel4, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmb_node;
        private System.Windows.Forms.TextBox txt_nodevalue;
        private System.Windows.Forms.ComboBox cmb_secondnode;
        private System.Windows.Forms.TextBox txt_childvalue;
        private System.Windows.Forms.ComboBox cmb_attrs;
        private System.Windows.Forms.TextBox txt_attrValue;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.LinkLabel linkLabel3;
        private System.Windows.Forms.LinkLabel linkLabel5;
        private System.Windows.Forms.LinkLabel linkLabel6;
        private System.Windows.Forms.LinkLabel linkLabel9;
        private System.Windows.Forms.LinkLabel linkLabel10;
        private System.Windows.Forms.LinkLabel linkLabel11;
        private System.Windows.Forms.Label lab_selectednode;
        private System.Windows.Forms.Label lab_isfirstlevelselected;
        private System.Windows.Forms.Label lab_attrnodeselected;
        private System.Windows.Forms.LinkLabel linkLabel4;
    }
}
