using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Xml;

namespace InstallShield
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            GlobalObjects.appConfig = new Inspriation.Lib.Base_Config();
            if (!GlobalObjects.appConfig.Is_DocumentExisted(Environment.CurrentDirectory, GlobalObjects.appConfigFile))            
                GlobalObjects.appConfig.Create_NewConfigDocument(Environment.CurrentDirectory + "\\" + GlobalObjects.appConfigFile);
            if (!GlobalObjects.appConfig.doOpen(Environment.CurrentDirectory + "\\" + GlobalObjects.appConfigFile))
            {
                MessageBox.Show("Init application config faild.please check the file : " + Environment.CurrentDirectory + "\\" + GlobalObjects.appConfigFile);
                Application.Exit();              
            }
            XmlNode activeSession = GlobalObjects.appConfig.Get_SessionNode("emailserver");
            if (activeSession != null)
            {
                XmlNode serverNode = GlobalObjects.appConfig.Get_ItemNode(activeSession, "server");
                string strServer = GlobalObjects.appConfig.Get_AttrValue(serverNode, "value", false);
                XmlNode accountNode = GlobalObjects.appConfig.Get_ItemNode(activeSession, "account");
                string strAccount = GlobalObjects.appConfig.Get_AttrValue(accountNode, "account", false);
                XmlNode passwordNode = GlobalObjects.appConfig.Get_ItemNode(activeSession, "password");
                string strPassword = GlobalObjects.appConfig.Get_AttrValue(activeSession, "password", false);
                GlobalObjects.emailServicesObj = new Inspriation.Lib.Base_EmailServices(strServer, strAccount, strPassword);
                if (GlobalObjects.emailServicesObj.Start_Services())                
                    MessageBox.Show("Fail to start email services,please check.", "Caution");                
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Splash());
        }
    }
}
