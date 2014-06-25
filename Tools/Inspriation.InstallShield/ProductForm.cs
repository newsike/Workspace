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
    public partial class ProductForm : TemplateForm
    {

        private string imgBase64 = "";

        public ProductForm()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (cmb_proname.Text != "")
            {
                if (!cmb_proname.Items.Contains(cmb_proname.Text))
                {

                    cmb_proname.Items.Add(cmb_proname.Text);
                }
                else
                {
                    MessageBox.Show("Please change the product name,the porduct has been existed.");
                    return;
                }
            }
        }

        private void ProductForm_Load(object sender, EventArgs e)
        {
            if (!GlobalObjects.isLoaded)
            {
                MessageBox.Show("Please load the active config file first.");
                this.Close();
            }
            else
            {
                XmlNodeList items = GlobalObjects.activeConfigObj.Get_ItemNodes("product");
                foreach (XmlNode activeItem in items)
                {
                    string productName = GlobalObjects.activeConfigObj.Get_AttrValue(activeItem, "name", false);
                    cmb_proname.Items.Add(productName);
                    
                }
            }
        }

        private void cmb_proname_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                XmlNode activeItem = GlobalObjects.activeConfigObj.Get_ItemNode("product", cmb_proname.Text);
                string productType = GlobalObjects.activeConfigObj.Get_AttrValue(activeItem, "ptype", true);
                string productEnterance = GlobalObjects.activeConfigObj.Get_AttrValue(activeItem, "enterance", true);
                string productStartMode = GlobalObjects.activeConfigObj.Get_AttrValue(activeItem, "startmode", true);
                cmb_protype.Text = productType;
                txt_entrance.Text = productEnterance;
                cmb_startmode.Text = productStartMode;
            }
            catch
            {
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (cmb_proname.Text!="")
            {
                if (cmb_proname.Items.Contains(cmb_proname.Text))
                {
                    cmb_proname.Items.Remove(cmb_proname.Text);
                    GlobalObjects.activeConfigObj.Remove_SessionItem("product", cmb_proname.Text);
                    MessageBox.Show("You have removed the product : " + cmb_proname.Text);
                    cmb_proname.Text = "";
                }
            }
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            XmlNode activeSessionNode=null;
            if (!GlobalObjects.activeConfigObj.Is_SessionExisted("product"))
                activeSessionNode= GlobalObjects.activeConfigObj.Create_NewSession("product", "", false);
            else
                activeSessionNode=GlobalObjects.activeConfigObj.Get_SessionNode("product");
            foreach (string activeItemName in cmb_proname.Items)
            {
                XmlNode activeItemNode = GlobalObjects.activeConfigObj.Get_ItemNode("product", activeItemName);
                if (activeItemNode == null)
                    activeItemNode = GlobalObjects.activeConfigObj.Create_Item(activeSessionNode, activeItemName, "", true);
                GlobalObjects.activeConfigObj.Set_ItemAttr(activeItemNode, "ptype", cmb_protype.Text, true);
                GlobalObjects.activeConfigObj.Set_ItemAttr(activeItemNode, "enterance", txt_entrance.Text, true);
                GlobalObjects.activeConfigObj.Set_ItemAttr(activeItemNode, "startmode", cmb_startmode.Text, true);
                if (imgBase64 != null && imgBase64.Length > 0)
                    GlobalObjects.activeConfigObj.Create_Item(activeItemNode, "eimg", imgBase64, true);
                MessageBox.Show("You have updated the data to buffer.");
            }
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (GlobalObjects.activeConfigObj.doSave())
                MessageBox.Show("You have saved the config file.");
            else
                MessageBox.Show("Error occured when you save the config file,please contact at administrator.");            
        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                FileStream activeStream = new FileStream(openFileDialog.FileName, FileMode.Open);
                BinaryReader br=new BinaryReader(activeStream);                
                byte[] imageBuffer=new byte[activeStream.Length];
                br.Read(imageBuffer, 0, Convert.ToInt32(activeStream.Length));
                imgBase64 = Convert.ToBase64String(imageBuffer);
                lb_uploadedimage.Text = "You have uploaded the image from disk.";                
            }
        }
    }
}
