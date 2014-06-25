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

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                txt_selectedConfigFile.Text = openFileDialog.FileName;                
                MessageBox.Show("You have selected the active config fiel.");
            }
        }
    }
}
