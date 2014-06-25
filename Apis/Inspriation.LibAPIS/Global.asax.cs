using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Xml;
using System.IO;

namespace Inspriation.LibAPIS
{
    public class Global : System.Web.HttpApplication
    {

        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup

        }

        void Application_End(object sender, EventArgs e)
        {
            //  Code that runs on application shutdown

        }

        void Application_Error(object sender, EventArgs e)
        {
            // Code that runs when an unhandled error occurs

        }

        void Session_Start(object sender, EventArgs e)
        {
            // Code that runs when a new session is started
            if (Inspriation.LibAPIS.CLASS_Cobehind.GlobalStaticObjects.LIBAPIS_CONFIG_MAINCONFIGOBJ == null)
            {
                XmlDocument tmpConfigDoc=new XmlDocument();
                tmpConfigDoc.Load(Server.MapPath("~/")+"\\" + Inspriation.LibAPIS.CLASS_Cobehind.GlobalStaticObjects.LIBAPIS_ODMS_PATH + "\\" + Inspriation.LibAPIS.CLASS_Cobehind.GlobalStaticObjects.LIBAPIS_CONFIG_FILE);
                string RegkeyPath = "";
                XmlNode rootNode = tmpConfigDoc.SelectSingleNode("/root");
                string mode = Inspriation.Lib.AwsXmlHelper.GetNodeValue("@mode", rootNode);             
                RegkeyPath = Inspriation.Lib.AwsXmlHelper.GetNodeValue("@content", rootNode);
                string RegKeyValue = "";
                if (mode == "2")                
                    Inspriation.Lib.Base_Registry.GetKeyValueFromLocalMachineNode(RegkeyPath, "", out RegKeyValue);
                else if (mode == "0")
                {
                    FileStream fs = new FileStream(RegkeyPath, FileMode.Open);
                    StreamReader sr = new StreamReader(fs);
                    RegKeyValue = sr.ReadLine();
                }
                Inspriation.LibAPIS.CLASS_Cobehind.GlobalStaticObjects.LIBAPIS_CONFIG_MAINCONFIGOBJ = new Lib.Base_Config(Server.MapPath("~/") + "\\" + Inspriation.LibAPIS.CLASS_Cobehind.GlobalStaticObjects.LIBAPIS_ODMS_PATH + "\\" + Inspriation.LibAPIS.CLASS_Cobehind.GlobalStaticObjects.LIBAPIS_CONFIG_FILE, true, RegKeyValue);
                Inspriation.LibAPIS.CLASS_Cobehind.GlobalStaticObjects.APICLASS_RESPONSE_CODE_OBJ = new CLASS_Cobehind.APICLASS_RESPONSE(Server.MapPath("~/") + "\\" + Inspriation.LibAPIS.CLASS_Cobehind.GlobalStaticObjects.LIBAPIS_ODMS_PATH + "\\");
            }
            if (Session["COUNT_OF_CONNECT"] == null)            
                Session["COUNT_OF_CONNECT"] = (0).ToString();            

        }

        void Session_End(object sender, EventArgs e)
        {
            // Code that runs when a session ends. 
            // Note: The Session_End event is raised only when the sessionstate mode
            // is set to InProc in the Web.config file. If session mode is set to StateServer 
            // or SQLServer, the event is not raised.

        }

    }
}
