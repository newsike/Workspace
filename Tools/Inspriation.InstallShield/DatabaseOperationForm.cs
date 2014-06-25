using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace InstallShield
{
    public partial class DatabaseOperationForm : InstallShield.TemplateForm
    {       

        public DatabaseOperationForm()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (txt_server.Text != "")
            {
                Inspriation.Lib.Data_SqlConnectionHelper obj = new Inspriation.Lib.Data_SqlConnectionHelper();
                if (obj.Set_NewConnectionItem("TestConnection", txt_server.Text, txt_uid.Text, txt_pwd.Text, txt_database.Text))
                    MessageBox.Show("The connection for database : " + txt_database.Text + " can be connected.");
                else
                    MessageBox.Show("Fail to connect to database : " + txt_database.Text);
            }
            else
            {
                MessageBox.Show("Invalidate server,please check it again.");
                return;
            }
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (txt_server.Text != "")
            {
                Inspriation.Lib.Data_SqlConnectionHelper obj = new Inspriation.Lib.Data_SqlConnectionHelper();
                if (obj.Set_NewConnectionItem("TestConnection", txt_server.Text, txt_uid.Text, txt_pwd.Text, txt_database.Text))
                {
                    Inspriation.Lib.Data_SqlHelper sqlHelper = new Inspriation.Lib.Data_SqlHelper();
                    sqlHelper.Action_AutoCreateSPS(obj.Get_ActiveConnection("TestConnection"));
                    MessageBox.Show("All default SPS have been updated in database :" + txt_database.Text);
                }
                else
                    MessageBox.Show("Fail to connect to database : " + txt_database.Text);
            }
            else
            {
                MessageBox.Show("Invalidate server,please check it again.");
                return;
            }
        }
    }
}
