using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;

namespace Inspriation.LibAPISKit
{
    public static class GlobalObjects
    {

        public static string LIBAPIS_ODMS_PATH = "ODMS";
        public static string LIBAPIS_CONFIG_FILE = "LIBAPISCONFIG.xml";

        public static Inspriation.Lib.Base_Config LIBAPIS_CONFIG_MAINCONFIGOBJ;
        public static Inspriation.Lib.Data_SqlConnectionHelper LIBAPIS_DBCONNECTION_HELPER;

        static GlobalObjects()
        {
            if (LIBAPIS_CONFIG_MAINCONFIGOBJ == null)
            {
                XmlDocument tmpConfigDoc = new XmlDocument();
                tmpConfigDoc.Load(LIBAPIS_ODMS_PATH + "\\" + LIBAPIS_CONFIG_FILE);
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
                LIBAPIS_CONFIG_MAINCONFIGOBJ = new Lib.Base_Config(LIBAPIS_ODMS_PATH + "\\" + LIBAPIS_CONFIG_FILE, true, RegKeyValue);
            }
            LIBAPIS_DBCONNECTION_HELPER = new Lib.Data_SqlConnectionHelper();
            
        }        

    }
}
