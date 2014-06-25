using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Xml;
using System.IO;

namespace Inspriation.LibAPIS.CLASS_Cobehind
{
    public class GlobalStaticObjects
    {
        public const string LIBAPIS_ODMS_PATH = "API_ODMS";
        public const string LIBAPIS_CONFIG_FILE = "InspriationAPI_Core.xml";
        public const string LIBAPIS_RESPONSECODE_FILE = "ResponseCode.xml";
        public const string LIBAPIS_CONFIG_COREDBKEYNAME = "DB_CORE_BASIC";

        public static Inspriation.Lib.Base_Config LIBAPIS_CONFIG_MAINCONFIGOBJ;
        public static Inspriation.Lib.Data_SqlConnectionHelper LIBAPIS_DB_CONNECTIONHELPER;
        public static Inspriation.Lib.Data_SqlHelper LIBAPIS_DB_DBHELPER;
        public static CLASS_Cobehind.APICLASS_SECURITY_TOKENS APICLASS_SECURITY_TOKEN_OBJ = new APICLASS_SECURITY_TOKENS();
        public static CLASS_Cobehind.APICLASS_RESPONSE APICLASS_RESPONSE_CODE_OBJ;
        public static Dictionary<string, Inspriation.Lib.Data_SqlSPEntry> APISPS_COREDB = new Dictionary<string, Lib.Data_SqlSPEntry>();
        

        public static bool InitMethod(string rootPath)
        {
            if (Inspriation.LibAPIS.CLASS_Cobehind.GlobalStaticObjects.LIBAPIS_CONFIG_MAINCONFIGOBJ == null)
            {
                XmlDocument tmpConfigDoc = new XmlDocument();
                tmpConfigDoc.Load(rootPath + "\\" + Inspriation.LibAPIS.CLASS_Cobehind.GlobalStaticObjects.LIBAPIS_ODMS_PATH + "\\" + Inspriation.LibAPIS.CLASS_Cobehind.GlobalStaticObjects.LIBAPIS_CONFIG_FILE);
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
                try
                {
                    APICLASS_RESPONSE_CODE_OBJ = new APICLASS_RESPONSE(rootPath);
                    Inspriation.LibAPIS.CLASS_Cobehind.GlobalStaticObjects.LIBAPIS_CONFIG_MAINCONFIGOBJ = new Lib.Base_Config(rootPath + "\\" + Inspriation.LibAPIS.CLASS_Cobehind.GlobalStaticObjects.LIBAPIS_ODMS_PATH + "\\" + Inspriation.LibAPIS.CLASS_Cobehind.GlobalStaticObjects.LIBAPIS_CONFIG_FILE, true, RegKeyValue);
                    XmlNode activeItemNode = LIBAPIS_CONFIG_MAINCONFIGOBJ.Get_ItemNode("commonattr", LIBAPIS_CONFIG_COREDBKEYNAME);
                    if (activeItemNode != null)
                    {
                        LIBAPIS_DB_CONNECTIONHELPER = new Lib.Data_SqlConnectionHelper();
                        string DB_Server = LIBAPIS_CONFIG_MAINCONFIGOBJ.Get_AttrValue(activeItemNode, "Server", true);
                        string DB_Uid = LIBAPIS_CONFIG_MAINCONFIGOBJ.Get_AttrValue(activeItemNode, "Uid", true);
                        string DB_Pwd = LIBAPIS_CONFIG_MAINCONFIGOBJ.Get_AttrValue(activeItemNode, "Pwd", true);
                        string DB_ActiveDB = LIBAPIS_CONFIG_MAINCONFIGOBJ.Get_AttrValue(activeItemNode, "ActiveDB", true);
                        if (!LIBAPIS_DB_CONNECTIONHELPER.Set_NewConnectionItem(LIBAPIS_CONFIG_COREDBKEYNAME, DB_Server, DB_Uid, DB_Pwd, DB_ActiveDB))
                            return false;
                        else
                        {
                            LIBAPIS_DB_DBHELPER = new Lib.Data_SqlHelper();
                            APISPS_COREDB = new Dictionary<string, Lib.Data_SqlSPEntry>();
                            APISPS_COREDB = LibAPIS.CLASS_Cobehind.GlobalStaticObjects.LIBAPIS_DB_DBHELPER.Action_AutoLoadingAllSPS(LIBAPIS_DB_CONNECTIONHELPER.Get_ActiveConnection(LIBAPIS_CONFIG_COREDBKEYNAME), "");                                                        
                            return true;
                        }
                    }
                    else
                        return false;
                }
                catch
                {
                    return false;
                }
            }
            else
                return false;
        }


    }
}