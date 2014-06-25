using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace InstallShield
{
    public partial class TokenForm : InstallShield.TemplateForm
    {
        private XmlNode activeTokenNode;

        public TokenForm()
        {
            InitializeComponent();
        }

        private void TokenForm_Load(object sender, EventArgs e)
        {
            if (!GlobalObjects.isLoaded)
            {
                MessageBox.Show("Please load the active config file first.");
                this.Close();
            }
            else
            {
                activeTokenNode = GlobalObjects.activeConfigObj.Get_SessionNode("token");
                if (activeTokenNode == null)
                    activeTokenNode = GlobalObjects.activeConfigObj.Create_NewSession("token", "", true);
                XmlNodeList productNodes = GlobalObjects.activeConfigObj.Get_ItemNodes("product");
                XmlNodeList clientNodes = GlobalObjects.activeConfigObj.Get_ItemNodes("client");
                XmlNodeList tokenNodes = GlobalObjects.activeConfigObj.Get_ItemNodes("token");
                int totalRequest = 0;
                foreach (XmlNode activeProductNode in productNodes)                
                    cmb_bindingpro.Items.Add(GlobalObjects.activeConfigObj.Get_AttrValue(activeProductNode, "name", false));
                foreach(XmlNode activeClientNode in clientNodes)
                    cmb_bindingclient.Items.Add(GlobalObjects.activeConfigObj.Get_AttrValue(activeClientNode, "name", false));
                foreach (XmlNode activeToken in tokenNodes)
                {
                    cmb_tokens.Items.Add(GlobalObjects.activeConfigObj.Get_AttrValue(activeToken, "name", false));
                    totalRequest = totalRequest + Int32.Parse(GlobalObjects.activeConfigObj.Get_AttrValue(activeToken, "MRS", true));
                }
                lb_count_tokens.Text = tokenNodes.Count.ToString();
                lb_count_products.Text = productNodes.Count.ToString();
                lb_count_clients.Text = clientNodes.Count.ToString();
                lb_count_request.Text = totalRequest.ToString();
            }
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (txt_token.Text == "")
            {
                MessageBox.Show("Please enter the token name first.");
                return;
            }
            else
            {
                XmlNode newTokenNode = GlobalObjects.activeConfigObj.Get_ItemNode("token", txt_token.Text);
                if (newTokenNode != null)
                {
                    MessageBox.Show("The token name has been existed,please change the token name.");
                    return;
                }
                else
                {
                    newTokenNode = GlobalObjects.activeConfigObj.Create_Item(activeTokenNode, txt_token.Text, "", true);
                    GlobalObjects.activeConfigObj.Set_ItemAttr(newTokenNode, "product", cmb_bindingpro.Text, true);
                    GlobalObjects.activeConfigObj.Set_ItemAttr(newTokenNode, "client", cmb_bindingclient.Text, true);
                    GlobalObjects.activeConfigObj.Set_ItemAttr(newTokenNode, "MRS", txt_maxrequest.Text, true);
                    GlobalObjects.activeConfigObj.Set_ItemAttr(newTokenNode, "MRS-ULM", chk_unlimited.Checked ? "1" : "0", true);
                    GlobalObjects.activeConfigObj.Set_ItemAttr(newTokenNode, "priority", cmb_priority.Text, true);
                    GlobalObjects.activeConfigObj.Set_ItemAttr(newTokenNode, "DWRMO", chk_deniedWMRO.Checked ? "1" : "0", true);
                    GlobalObjects.activeConfigObj.Set_ItemAttr(newTokenNode, "timeout", txt_timeout.Text != "" ? txt_timeout.Text : "60", true);
                    GlobalObjects.activeConfigObj.doSave();
                    MessageBox.Show("You have create new token : " + txt_token.Text + " .");
                }
            }
            
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (txt_token.Text == "")
            {
                MessageBox.Show("Please chek the name of the token.");
                return;
            }
            else
            {
                XmlNode activeItem = GlobalObjects.activeConfigObj.Get_ItemNode("product", txt_token.Text);
                if (activeItem != null)
                {
                    GlobalObjects.activeConfigObj.Remove_SessionItem("product", txt_token.Text);
                    MessageBox.Show("You have removed the active item.");
                }
                else
                {
                    MessageBox.Show("The token is not existed,please check the token name again.");
                    return;
                }
            }
        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (cmb_tokens.Text != "")
            {
                XmlNode activeItemNode = GlobalObjects.activeConfigObj.Get_ItemNode("token", cmb_tokens.Text);
                if (activeItemNode != null)
                {
                    string str_product = GlobalObjects.activeConfigObj.Get_AttrValue(activeItemNode, "product", true);
                    if (!cmb_bindingpro.Items.Contains(str_product))
                    {
                        MessageBox.Show("The data from the token is invalidate,please reset the token.");
                        cmb_tokens.Text = "";
                        return;
                    }
                    cmb_bindingpro.Text = str_product;                   
                    string str_client = GlobalObjects.activeConfigObj.Get_AttrValue(activeItemNode, "client", true);
                    if (!cmb_bindingclient.Items.Contains(str_client))
                    {
                        MessageBox.Show("The data from the token is invalidate,please reset the token.");
                        cmb_tokens.Text = "";
                        return;
                    }
                    cmb_bindingclient.Text = str_client;
                    string str_MRS = GlobalObjects.activeConfigObj.Get_AttrValue(activeItemNode, "MRS", true);
                    txt_maxrequest.Text = str_MRS;
                    string str_MRSULM = GlobalObjects.activeConfigObj.Get_AttrValue(activeItemNode, "MRS-ULM", true);
                    chk_unlimited.Checked = str_MRSULM == "1" ? true : false;
                    string str_priority = GlobalObjects.activeConfigObj.Get_AttrValue(activeItemNode, "priority", true);
                    cmb_priority.Text = str_priority;
                    string str_timeout = GlobalObjects.activeConfigObj.Get_AttrValue(activeItemNode, "timeout", true);
                    txt_timeout.Text = str_timeout;
                    string str_DWRMO = GlobalObjects.activeConfigObj.Get_AttrValue(activeItemNode, "DWRMO", true);
                    chk_deniedWMRO.Checked = str_DWRMO == "1" ? true : false;
                }
            }
        }
    }
}
