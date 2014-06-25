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
    public partial class ClientInfoForm : InstallShield.TemplateForm
    {
        public ClientInfoForm()
        {
            InitializeComponent();
        }

        private void ClientInfoForm_Load(object sender, EventArgs e)
        {
            if (!GlobalObjects.isLoaded)
            {
                MessageBox.Show("Please load the active config file first.");
                this.Close();
            }
            else
            {
                XmlNodeList items = GlobalObjects.activeConfigObj.Get_ItemNodes("client");
                cmb_clientname.Items.Clear();
                foreach (XmlNode activeItem in items)
                {
                    cmb_clientname.Items.Add(GlobalObjects.activeConfigObj.Get_AttrValue(activeItem, "name", false));
                }
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (cmb_clientname.Text != "" && !cmb_clientname.Items.Contains(cmb_clientname.Text))
            {
                cmb_clientname.Items.Add(cmb_clientname.Text);
                XmlNode activeSessionNode;
                if (!GlobalObjects.activeConfigObj.Is_SessionExisted("client"))
                    activeSessionNode = GlobalObjects.activeConfigObj.Create_NewSession("client", "", false);
                else
                    activeSessionNode = GlobalObjects.activeConfigObj.Get_SessionNode("client");
                GlobalObjects.activeConfigObj.Create_Item(activeSessionNode, cmb_clientname.Text, "", true);
                MessageBox.Show("You have create new client.");
            }
            else
            {
                MessageBox.Show("Client name can't be empty or it is existed,please check again.");
            }
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (cmb_clientname.Text != "")
            {
                if (cmb_clientname.Items.Contains(cmb_clientname.Text))
                {
                    cmb_clientname.Items.Remove(cmb_clientname.Text);
                    GlobalObjects.activeConfigObj.Remove_SessionItem("client", cmb_clientname.Text);
                    MessageBox.Show("You have removed the client : [ " + cmb_clientname.Text + " ] ");
                    cmb_clientname.Text = "";
                }
            }
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (cmb_clientname.Text != "")
            {
                if (cmb_iplist.Text != "" && !cmb_iplist.Items.Contains(cmb_iplist.Text))
                {
                    cmb_iplist.Items.Add(cmb_iplist.Text);
                    MessageBox.Show("You have add the IP : [ " + cmb_iplist.Text + " ] to the list.");
                }
                else
                {
                    MessageBox.Show("The IP Can't be empty or this IP has been existed in the list.");
                }
            }
            else
                MessageBox.Show("Please select the active client first.");
        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (cmb_iplist.Text != "" && cmb_iplist.Items.Contains(cmb_iplist.Text))
            {
                cmb_iplist.Items.Remove(cmb_iplist.Text);
                MessageBox.Show("You have remove the IP : [ " + cmb_iplist.Text + " ] from the list.");
            }
        }

        private void linkLabel6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            bool ranflag = true;
            if (txt_key.Text != "")
            {
                if (!(MessageBox.Show("This action will romove all text on key field , are you sure ?", "Caution", MessageBoxButtons.YesNo) == DialogResult.Yes))
                    ranflag = false;                
            }
            if (ranflag)
            {
                Random rnd = new Random();
                string strRnd="";
                for (int i = 1; i <= 8; i++)
                {
                    int result = rnd.Next(65, 90);
                    strRnd = strRnd + (char)result;
                }
                txt_key.Text = strRnd;
            }
        }

        private void linkLabel8_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (cmb_clientname.Text != "")
            {
                if (txt_key.Text == "")
                {
                    MessageBox.Show("Please enter the key first.");
                    return;
                }
                if (txt_password.Text == "" || txt_password.Text.Length < 8)
                {
                    MessageBox.Show("Invalidate password for client,please check.");
                    return;
                }
                XmlNode iplistNode = null;
                XmlNode clientNode = null;
                clientNode = GlobalObjects.activeConfigObj.Get_SessionNode("client");
                if (clientNode == null)
                {
                    MessageBox.Show("No client,please add client first,and select the active client.");
                    return;
                }
                XmlNode activeClientNode = GlobalObjects.activeConfigObj.Get_ItemNode(clientNode, cmb_clientname.Text);
                if (activeClientNode == null)
                {
                    MessageBox.Show("The client is not existed , please check again.");
                    return;
                }
                if (GlobalObjects.activeConfigObj.Get_ItemNode(activeClientNode, "iplist") == null)
                    iplistNode = GlobalObjects.activeConfigObj.Create_Item(activeClientNode, "iplist", "", false);
                else
                {

                    iplistNode = GlobalObjects.activeConfigObj.Get_ItemNode(activeClientNode, "iplist");
                    iplistNode.ParentNode.RemoveChild(iplistNode);
                    iplistNode = iplistNode = GlobalObjects.activeConfigObj.Create_Item(activeClientNode, "iplist", "", false);
                }
                Inspriation.Lib.Security_DES clientDES;
                clientDES = new Inspriation.Lib.Security_DES(txt_key.Text);
                foreach (string activeIP in cmb_iplist.Items)
                {
                    string desActiveIP = "";
                    clientDES.DESCoding(activeIP, out desActiveIP);
                    GlobalObjects.activeConfigObj.Create_Item(iplistNode, "IP", desActiveIP, false);
                }
                GlobalObjects.activeConfigObj.Set_ItemAttr(activeClientNode, "key", txt_key.Text, true);
                string desPassword;
                clientDES.DESCoding(txt_password.Text, out desPassword);
                GlobalObjects.activeConfigObj.Set_ItemAttr(activeClientNode, "password", desPassword, false);
                MessageBox.Show("You have updated the data to the buffer.");
            }
            else
            {
                MessageBox.Show("Please select the active client first.");
                return;
            }
        }

        private void linkLabel9_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!GlobalObjects.isEmailServices)
            {
                MessageBox.Show("Email services has not been started , please check your config.");
                return;
            }
            else
            {
                StringBuilder emailContent = new StringBuilder();
                emailContent.AppendLine("Dear : " + cmb_clientname.Text );
                emailContent.AppendLine("Congratuation ! You have get the inspriation client id !");
                emailContent.AppendLine("Your Client ID ( Client UserName ) : " + cmb_clientname.Text);
                emailContent.AppendLine("Your Password : " + txt_password.Text);
                emailContent.AppendLine("Your Key : " + txt_key.Text);
                GlobalObjects.emailServicesObj.SetMailTask(txt_clientemail.Text, "Inspriation Feedback", emailContent.ToString());
                MessageBox.Show("You have sent the email to the client.");
            }
        }

        private void linkLabel7_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            GlobalObjects.activeConfigObj.doSave();
            MessageBox.Show("You have save all date to config file.");
        }

        private void cmb_clientname_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_clientname.Text != "")
            {
                cmb_iplist.Items.Clear();
                XmlNode activeClientNode = GlobalObjects.activeConfigObj.Get_ItemNode("client", cmb_clientname.Text);
                if (activeClientNode != null)
                {
                    string key = "";
                    key = GlobalObjects.activeConfigObj.Get_AttrValue(activeClientNode, "key", true);
                    txt_key.Text = key;
                    Inspriation.Lib.Security_DES clientDES = new Inspriation.Lib.Security_DES(key);
                    XmlNode ipListNode = GlobalObjects.activeConfigObj.Get_ItemNode(activeClientNode, "iplist");
                    if (ipListNode != null)
                    {
                        foreach (XmlNode activeIpNode in ipListNode.SelectNodes("item"))
                        {
                            string ip = "";
                            clientDES.DESDecoding(GlobalObjects.activeConfigObj.Get_ItemValue(ipListNode, false), out ip);
                            cmb_iplist.Items.Add(ip);
                        }
                    }
                    string password = "";
                    clientDES.DESDecoding(GlobalObjects.activeConfigObj.Get_AttrValue(activeClientNode, "password", false), out password);
                    txt_password.Text = password;
                }
            }
        }
    }
}
