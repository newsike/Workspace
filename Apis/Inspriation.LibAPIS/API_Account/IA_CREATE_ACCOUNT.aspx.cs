using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Data;

namespace Inspriation.LibAPIS.API_Account
{
    public partial class IA_CREATE_ACCOUNT : Inspriation.LibAPIS.CLASS_Cobehind.APICLASS_BASECLASS_CA
    {
        /// <summary>
        /// <root>
        /// <item u_name='test' regcode='1234' u_pwd='12345' u_key='12345' u_level="1"></item>
        /// </root>
        /// </summary>
        protected override void API_StartServices()
        {
            string inputXML = GetQuerystringParam("input");
            if (inputXML != "")
            {
                XmlDocument doc = new XmlDocument();
                try
                {
                    doc.LoadXml(inputXML);
                }
                catch
                {
                    AddResponseMessageToResponseDOC(Inspriation.LibAPIS.CLASS_Cobehind.GlobalStaticObjects.APICLASS_RESPONSE_CODE_OBJ.GET_RESPONSEITEM("COMMONRESPONSE", "004").RES_HEADER, Inspriation.LibAPIS.CLASS_Cobehind.GlobalStaticObjects.APICLASS_RESPONSE_CODE_OBJ.GET_RESPONSEITEM("COMMONRESPONSE", "004").RES_CODE, Inspriation.LibAPIS.CLASS_Cobehind.GlobalStaticObjects.APICLASS_RESPONSE_CODE_OBJ.GET_RESPONSEITEM("COMMONRESPONSE", "004").RES_MESSAGE, Inspriation.LibAPIS.CLASS_Cobehind.GlobalStaticObjects.APICLASS_RESPONSE_CODE_OBJ.GET_RESPONSEITEM("COMMONRESPONSE", "004").RES_LINK);
                    Response.ContentType = "Text/XML";
                    Response.Write(RESPONSEDOCUMENT.OuterXml);
                    return;
                }
                Inspriation.Lib.Data_SqlSPEntry activeSPEntry = Inspriation.LibAPIS.CLASS_Cobehind.GlobalStaticObjects.APISPS_COREDB["SPA_Operation_BasicDB_BasicAccount"];
                XmlNode itemNode = doc.SelectSingleNode("/root/item");
                string u_name = Inspriation.Lib.AwsXmlHelper.GetNodeValue("@u_name", itemNode);
                string u_pwd = Inspriation.Lib.AwsXmlHelper.GetNodeValue("@u_pwd", itemNode);
                string u_key = Inspriation.Lib.AwsXmlHelper.GetNodeValue("@u_key", itemNode);
                string u_level = Inspriation.Lib.AwsXmlHelper.GetNodeValue("@u_level", itemNode);
                string u_regcode = Inspriation.Lib.AwsXmlHelper.GetNodeValue("@regcode", itemNode);
                if (u_level == "0")
                {
                    XmlNode regcodeNode = Inspriation.LibAPIS.CLASS_Cobehind.GlobalStaticObjects.LIBAPIS_CONFIG_MAINCONFIGOBJ.Get_SessionNode("securitycode");
                    if (regcodeNode != null)
                    {
                        XmlNodeList items = Inspriation.LibAPIS.CLASS_Cobehind.GlobalStaticObjects.LIBAPIS_CONFIG_MAINCONFIGOBJ.Get_ItemNodes("securitycode");
                        bool isRegCodeChecked = false;
                        foreach (XmlNode item in items)
                        {
                            string securityCode = Inspriation.LibAPIS.CLASS_Cobehind.GlobalStaticObjects.LIBAPIS_CONFIG_MAINCONFIGOBJ.Get_AttrValue(itemNode, "val", true);
                            if (securityCode == u_regcode)
                                isRegCodeChecked = true;
                        }
                        if (!isRegCodeChecked)
                        {
                            AddResponseMessageToResponseDOC(Inspriation.LibAPIS.CLASS_Cobehind.GlobalStaticObjects.APICLASS_RESPONSE_CODE_OBJ.GET_RESPONSEITEM("ACCOUNTRESPONSE", "1010").RES_HEADER, Inspriation.LibAPIS.CLASS_Cobehind.GlobalStaticObjects.APICLASS_RESPONSE_CODE_OBJ.GET_RESPONSEITEM("ACCOUNTRESPONSE", "1010").RES_CODE, Inspriation.LibAPIS.CLASS_Cobehind.GlobalStaticObjects.APICLASS_RESPONSE_CODE_OBJ.GET_RESPONSEITEM("ACCOUNTRESPONSE", "1010").RES_MESSAGE, Inspriation.LibAPIS.CLASS_Cobehind.GlobalStaticObjects.APICLASS_RESPONSE_CODE_OBJ.GET_RESPONSEITEM("ACCOUNTRESPONSE", "1010").RES_LINK);
                            Response.ContentType = "Text/XML";
                            Response.Write(RESPONSEDOCUMENT.OuterXml);
                            return;
                        }
                    }
                    else
                    {
                        AddResponseMessageToResponseDOC(Inspriation.LibAPIS.CLASS_Cobehind.GlobalStaticObjects.APICLASS_RESPONSE_CODE_OBJ.GET_RESPONSEITEM("ACCOUNTRESPONSE", "1009").RES_HEADER, Inspriation.LibAPIS.CLASS_Cobehind.GlobalStaticObjects.APICLASS_RESPONSE_CODE_OBJ.GET_RESPONSEITEM("ACCOUNTRESPONSE", "1009").RES_CODE, Inspriation.LibAPIS.CLASS_Cobehind.GlobalStaticObjects.APICLASS_RESPONSE_CODE_OBJ.GET_RESPONSEITEM("ACCOUNTRESPONSE", "1009").RES_MESSAGE, Inspriation.LibAPIS.CLASS_Cobehind.GlobalStaticObjects.APICLASS_RESPONSE_CODE_OBJ.GET_RESPONSEITEM("ACCOUNTRESPONSE", "1009").RES_LINK);
                        Response.ContentType = "Text/XML";
                        Response.Write(RESPONSEDOCUMENT.OuterXml);
                        return;

                    }
                }
                else
                {
                    /*
                     * 
                     */
                }

                DataTable activeUserDT = Inspriation.LibAPIS.CLASS_Cobehind.GlobalStaticObjects.LIBAPIS_DB_DBHELPER.ExecuteGetSPS(activeSPEntry, Inspriation.LibAPIS.CLASS_Cobehind.GlobalStaticObjects.LIBAPIS_DB_CONNECTIONHELPER, Inspriation.LibAPIS.CLASS_Cobehind.GlobalStaticObjects.LIBAPIS_CONFIG_COREDBKEYNAME);
                if (activeUserDT != null && activeUserDT.Rows.Count > 0)
                {
                    AddResponseMessageToResponseDOC(Inspriation.LibAPIS.CLASS_Cobehind.GlobalStaticObjects.APICLASS_RESPONSE_CODE_OBJ.GET_RESPONSEITEM("COMMONRESPONSE", "006").RES_HEADER, Inspriation.LibAPIS.CLASS_Cobehind.GlobalStaticObjects.APICLASS_RESPONSE_CODE_OBJ.GET_RESPONSEITEM("COMMONRESPONSE", "006").RES_CODE, Inspriation.LibAPIS.CLASS_Cobehind.GlobalStaticObjects.APICLASS_RESPONSE_CODE_OBJ.GET_RESPONSEITEM("COMMONRESPONSE", "006").RES_MESSAGE, Inspriation.LibAPIS.CLASS_Cobehind.GlobalStaticObjects.APICLASS_RESPONSE_CODE_OBJ.GET_RESPONSEITEM("COMMONRESPONSE", "006").RES_LINK);
                    Response.ContentType = "Text/XML";
                    Response.Write(RESPONSEDOCUMENT.OuterXml);
                    return;
                }
                DataRow[] selectedRows = activeUserDT.Select("u_name='" + u_name + "'");
                if (selectedRows.Length == 0)
                {
                    Dictionary<string, object> valueMaping = new Dictionary<string, object>();
                    Dictionary<string ,int> sizeMaping=new Dictionary<string,int>();
                    valueMaping.Add("@u_name", u_name);
                    valueMaping.Add("@u_password", u_pwd);
                    valueMaping.Add("@u_key", u_key);
                    valueMaping.Add("@u_level", u_level);
                    Inspriation.LibAPIS.CLASS_Cobehind.GlobalStaticObjects.LIBAPIS_DB_DBHELPER.ExecuteInsertSPS(activeSPEntry, Inspriation.LibAPIS.CLASS_Cobehind.GlobalStaticObjects.LIBAPIS_DB_CONNECTIONHELPER, Inspriation.LibAPIS.CLASS_Cobehind.GlobalStaticObjects.LIBAPIS_CONFIG_COREDBKEYNAME, valueMaping, sizeMaping);
                    AddResponseMessageToResponseDOC(Inspriation.LibAPIS.CLASS_Cobehind.GlobalStaticObjects.APICLASS_RESPONSE_CODE_OBJ.GET_RESPONSEITEM("ACCOUNTRESPONSE", "1008").RES_HEADER, Inspriation.LibAPIS.CLASS_Cobehind.GlobalStaticObjects.APICLASS_RESPONSE_CODE_OBJ.GET_RESPONSEITEM("ACCOUNTRESPONSE", "1008").RES_CODE, Inspriation.LibAPIS.CLASS_Cobehind.GlobalStaticObjects.APICLASS_RESPONSE_CODE_OBJ.GET_RESPONSEITEM("ACCOUNTRESPONSE", "1008").RES_MESSAGE, Inspriation.LibAPIS.CLASS_Cobehind.GlobalStaticObjects.APICLASS_RESPONSE_CODE_OBJ.GET_RESPONSEITEM("ACCOUNTRESPONSE", "1008").RES_LINK);
                }
                else
                {
                    AddResponseMessageToResponseDOC(Inspriation.LibAPIS.CLASS_Cobehind.GlobalStaticObjects.APICLASS_RESPONSE_CODE_OBJ.GET_RESPONSEITEM("ACCOUNTRESPONSE", "1002").RES_HEADER, Inspriation.LibAPIS.CLASS_Cobehind.GlobalStaticObjects.APICLASS_RESPONSE_CODE_OBJ.GET_RESPONSEITEM("ACCOUNTRESPONSE", "1002").RES_CODE, Inspriation.LibAPIS.CLASS_Cobehind.GlobalStaticObjects.APICLASS_RESPONSE_CODE_OBJ.GET_RESPONSEITEM("ACCOUNTRESPONSE", "1002").RES_MESSAGE, Inspriation.LibAPIS.CLASS_Cobehind.GlobalStaticObjects.APICLASS_RESPONSE_CODE_OBJ.GET_RESPONSEITEM("ACCOUNTRESPONSE", "1002").RES_LINK);                
                }
                Response.ContentType = "Text/XML";
                Response.Write(RESPONSEDOCUMENT.OuterXml);         
            }
        }
    }
}