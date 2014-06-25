using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.IO;

namespace InstallShield
{
    public partial class ConfigFileForm : Form
    {

        XmlDocument activeDoc = new XmlDocument();

        public ConfigFileForm()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                txt_filename.Text = saveFileDialog.FileName;
            }
        }

        private void cmb_keytype_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_keytype.Text != "")
            {
                if (cmb_keytype.Text == "Regkey")
                {
                    txt_keyfile.Text = txt_filename.Text.Replace(".xml", ".reg");
                    chk_using64.Visible = true;
                }
                else
                {
                    txt_keyfile.Text = txt_filename.Text.Replace(".xml", ".oskey");
                    chk_using64.Visible = false;
                }                
            }
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (txt_filename.Text == "")
            {
                MessageBox.Show("Please create the new file first.");
                return;
            }
            if (txt_keyfile.Text == "")
            {
                MessageBox.Show("Please select the des file type first.");
                return;
            }
            if (txt_keycontent.Text == "" || (txt_keycontent.Text.Length < 8 || txt_keycontent.Text.Length>128))
            {
                MessageBox.Show("Invalidate key content,please check and modify.");
                return;
            }            
            activeDoc.LoadXml("<root></root>");            
            string desMode="";
            switch(cmb_keytype.Text)
            {
                case "Keyfile":
                    desMode="0";
                    break;
                case "WebConfig":
                    desMode="1";
                    break;
                case "Regkey":
                    desMode="2";
                    break;
                default:
                    desMode="0";
                    break;
            }
            
            Inspriation.Lib.AwsXmlHelper.SetAttribute(activeDoc.SelectSingleNode("/root"), "mode", desMode);
            string modeContent="";
            switch (desMode)
            {
                default:
                case "0":
                    modeContent = txt_keyfile.Text.Split('\\')[txt_keyfile.Text.Split('\\').Length - 1];
                    break;
                case "1":
                    modeContent= "";
                    break;
                case "2":
                    if(!chk_using64.Checked)
                        modeContent = "SOFTWARE\\INSPRIATION\\" + txt_planname.Text.ToUpper();
                    else
                        modeContent = "SOFTWARE\\Wow6432Node\\INSPRIATION\\" + txt_planname.Text.ToUpper();
                    break;
            }
            Inspriation.Lib.AwsXmlHelper.SetAttribute(activeDoc.SelectSingleNode("/root"), "content", modeContent);
            Inspriation.Lib.AwsXmlHelper.SetAttribute(activeDoc.SelectSingleNode("/root"), "plan", txt_planname.Text);
            activeDoc.Save(txt_filename.Text);
            FileStream fs = new FileStream(txt_keyfile.Text, FileMode.Create);
            StreamWriter sw = new StreamWriter(fs);
            if (desMode == "2")
            {
                sw.WriteLine("REGEDIT4");
                sw.WriteLine("");
                sw.WriteLine("[HKEY_LOCAL_MACHINE\\SOFTWARE\\INSPRIATION\\" + txt_planname.Text.ToUpper() + "]");
                sw.WriteLine("\"REGKEY\"=\"" + txt_keycontent.Text + "\"");
                sw.WriteLine("[HKEY_LOCAL_MACHINE\\SOFTWARE\\WOW6432Node\\INSPRIATION\\" + txt_planname.Text.ToUpper() + "]");
                sw.WriteLine("\"REGKEY\"=\"" + txt_keycontent.Text + "\"");
            }
            else
            {
                sw.WriteLine(txt_keycontent.Text);
            }
            sw.Flush();
            sw.Close();
            fs.Close();
            MessageBox.Show("You have created the new config file.");
              
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                txt_filename.Text = openFileDialog.FileName;
                activeDoc = new XmlDocument();
                activeDoc.Load(txt_filename.Text);
                string mode = "";
                string modeContent = "";
                string plan = "";
                XmlNode rootNode = activeDoc.SelectSingleNode("/root");
                if (rootNode != null)
                {
                    mode = Inspriation.Lib.AwsXmlHelper.GetNodeValue("@mode", rootNode);
                    switch (mode)
                    {
                        case "0":
                            cmb_keytype.Text = "Keyfile";
                            break;
                        case "1":
                            cmb_keytype.Text = "WebConfig";
                            break;
                        case "2":
                            cmb_keytype.Text = "Regkey";
                            break;
                    }
                    modeContent = Inspriation.Lib.AwsXmlHelper.GetNodeValue("@content", rootNode);
                    plan = Inspriation.Lib.AwsXmlHelper.GetNodeValue("@plan", rootNode);
                    txt_keycontent.Text = modeContent;
                    txt_planname.Text = plan;
                }
            }
        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        private void ConfigFileForm_Load(object sender, EventArgs e)
        {

        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void linkLabel4_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }
    }
}
