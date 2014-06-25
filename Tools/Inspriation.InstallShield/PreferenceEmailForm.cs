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
    public partial class PreferenceEmailForm : InstallShield.TemplateForm
    {
        public PreferenceEmailForm()
        {
            InitializeComponent();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (txt_mailserver.Text == "")
            {
                MessageBox.Show("Remote mail server can't be empty,please check.");
                return;
            }
            else
            {
                XmlNode activeSession = GlobalObjects.appConfig.Get_SessionNode("emailserver");
                if (activeSession != null)
                    activeSession = GlobalObjects.appConfig.Create_NewSession("emailserver", "", false);
                XmlNode serverNode = GlobalObjects.appConfig.Get_ItemNode(activeSession, "server");
                if (serverNode == null)
                    serverNode = GlobalObjects.appConfig.Create_Item(activeSession, "server", "", false);
                GlobalObjects.appConfig.Set_ItemAttr(serverNode, "server", txt_mailserver.Text, false);
                XmlNode accountNode = GlobalObjects.appConfig.Get_ItemNode(activeSession, "account");
                if (accountNode == null)
                    accountNode = GlobalObjects.appConfig.Create_Item(activeSession, "account", "", false);
                GlobalObjects.appConfig.Set_ItemAttr(accountNode, "account", txt_acount.Text, false);
                XmlNode passwordNode = GlobalObjects.appConfig.Get_ItemNode(activeSession, "password");
                if (passwordNode == null)
                    passwordNode = GlobalObjects.appConfig.Create_Item(activeSession, "password", "", false);
                GlobalObjects.appConfig.Set_ItemAttr(passwordNode, "password", txt_password.Text, false);
                GlobalObjects.emailServicesObj = new Inspriation.Lib.Base_EmailServices(txt_mailserver.Text, txt_acount.Text, txt_password.Text);
                MessageBox.Show("You have updated the config to config file.");
            }
        }

        private void PreferenceEmailForm_Load(object sender, EventArgs e)
        {
            XmlNode activeSession = GlobalObjects.appConfig.Get_SessionNode("emailserver");
            if (activeSession != null)
            {
                XmlNode serverNode = GlobalObjects.appConfig.Get_ItemNode(activeSession, "server");
                string strServer = GlobalObjects.appConfig.Get_AttrValue(serverNode, "value", false);
                txt_mailserver.Text = strServer;
                XmlNode accountNode = GlobalObjects.appConfig.Get_ItemNode(activeSession, "account");
                string strAccount = GlobalObjects.appConfig.Get_AttrValue(accountNode, "account", false);
                txt_acount.Text = strAccount;
                XmlNode passwordNode = GlobalObjects.appConfig.Get_ItemNode(activeSession, "password");
                string strPassword = GlobalObjects.appConfig.Get_AttrValue(activeSession, "password", false);
                txt_password.Text = strPassword;
            }
        }
    }
}
