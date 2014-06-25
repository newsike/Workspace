using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace InstallShield
{
    public partial class Mainform : Form
    {
        public Mainform()
        {
            InitializeComponent();
        }

        private void newConfigFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfigFileForm obj = new ConfigFileForm();
            obj.ShowDialog();
        }

        private void productBaseInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProductForm obj = new ProductForm();
            obj.ShowDialog();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (txt_key.Text == "")
            {
                if (MessageBox.Show("The config file key is empty,do you want to continue?", "Caution", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    return;
                }
            }
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    txt_selectedConfigFile.Text = openFileDialog.FileName;
                    MessageBox.Show("You have selected the active config file.");
                    GlobalObjects.activeConfigObj = new Inspriation.Lib.Base_Config(txt_selectedConfigFile.Text, txt_key.Text != "" ? true : false, txt_key.Text);
                    lab_filestatus.Text = "The system has loaded the file : " + txt_selectedConfigFile.Text.Split('\\')[txt_selectedConfigFile.Text.Split('\\').Length - 1];
                    GlobalObjects.isLoaded = true;
                }
                catch
                {
                    MessageBox.Show("Fail to loading config file,please check the file or key value.");
                    GlobalObjects.isLoaded = false;
                    return;
                }
            }
        }

        private void emailServicesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PreferenceEmailForm obj = new PreferenceEmailForm();
            obj.ShowDialog();
        }

        private void clientConfigToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClientInfoForm obj = new ClientInfoForm();
            obj.ShowDialog();
        }

        private void Mainform_Load(object sender, EventArgs e)
        {

        }

        private void tokenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TokenForm obj = new TokenForm();
            obj.ShowDialog();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Application.Exit();
        }

        private void commonAttrsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CommonAttrsForm obj = new CommonAttrsForm();
            obj.ShowDialog();
        }

        private void databaseOperationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DatabaseOperationForm obj = new DatabaseOperationForm();
            obj.ShowDialog();
        }

        private void securityCodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SecurityCodeForm obj = new SecurityCodeForm();
            obj.ShowDialog();
        }
    }
}
