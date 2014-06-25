using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Xml;

namespace Inspriation.LibAPIS.API_Account
{
    public partial class IA_IS_ACCOUNTEXISTED : Inspriation.LibAPIS.CLASS_Cobehind.APICLASS_BASECLASS_CA
    {
        protected override void API_StartServices()
        {
            string inputXML = GetQuerystringParam("input");
            if (inputXML != "")
            {
                XmlDocument doc=new XmlDocument();
                try
                {                    
                    doc.LoadXml(inputXML);
                }
                catch
                {
                    AddResponseMessageToResponseDOC(Inspriation.LibAPIS.CLASS_Cobehind.GlobalStaticObjects.APICLASS_RESPONSE_CODE_OBJ.GET_RESPONSEITEM("COMMONRESPONSE","004").RES_HEADER,Inspriation.LibAPIS.CLASS_Cobehind.GlobalStaticObjects.APICLASS_RESPONSE_CODE_OBJ.GET_RESPONSEITEM("COMMONRESPONSE","004").RES_CODE,Inspriation.LibAPIS.CLASS_Cobehind.GlobalStaticObjects.APICLASS_RESPONSE_CODE_OBJ.GET_RESPONSEITEM("COMMONRESPONSE","004").RES_MESSAGE,Inspriation.LibAPIS.CLASS_Cobehind.GlobalStaticObjects.APICLASS_RESPONSE_CODE_OBJ.GET_RESPONSEITEM("COMMONRESPONSE","004").RES_LINK);
                    Response.ContentType = "Text/XML";
                    Response.Write(RESPONSEDOCUMENT.OuterXml);
                    return;
                }
                Inspriation.Lib.Data_SqlSPEntry activeSPEntry = Inspriation.LibAPIS.CLASS_Cobehind.GlobalStaticObjects.APISPS_COREDB["SPA_Operation_BasicDB_BasicAccount"];
                DataTable activeUserDT = Inspriation.LibAPIS.CLASS_Cobehind.GlobalStaticObjects.LIBAPIS_DB_DBHELPER.ExecuteGetSPS(activeSPEntry, Inspriation.LibAPIS.CLASS_Cobehind.GlobalStaticObjects.LIBAPIS_DB_CONNECTIONHELPER, Inspriation.LibAPIS.CLASS_Cobehind.GlobalStaticObjects.LIBAPIS_CONFIG_COREDBKEYNAME);
                if(activeUserDT!=null && activeUserDT.Rows.Count>0)
                {
                    AddResponseMessageToResponseDOC(Inspriation.LibAPIS.CLASS_Cobehind.GlobalStaticObjects.APICLASS_RESPONSE_CODE_OBJ.GET_RESPONSEITEM("COMMONRESPONSE","006").RES_HEADER,Inspriation.LibAPIS.CLASS_Cobehind.GlobalStaticObjects.APICLASS_RESPONSE_CODE_OBJ.GET_RESPONSEITEM("COMMONRESPONSE","006").RES_CODE,Inspriation.LibAPIS.CLASS_Cobehind.GlobalStaticObjects.APICLASS_RESPONSE_CODE_OBJ.GET_RESPONSEITEM("COMMONRESPONSE","006").RES_MESSAGE,Inspriation.LibAPIS.CLASS_Cobehind.GlobalStaticObjects.APICLASS_RESPONSE_CODE_OBJ.GET_RESPONSEITEM("COMMONRESPONSE","006").RES_LINK);
                    Response.ContentType = "Text/XML";
                    Response.Write(RESPONSEDOCUMENT.OuterXml);
                    return;
                }
                XmlNode itemNode = doc.SelectSingleNode("/root/item");
                string userName = Inspriation.Lib.AwsXmlHelper.GetNodeValue("@val", itemNode);
                DataRow[] selectedRows = activeUserDT.Select("u_name='" + userName + "'");
                if (selectedRows.Length > 0)                
                    AddResponseMessageToResponseDOC(Inspriation.LibAPIS.CLASS_Cobehind.GlobalStaticObjects.APICLASS_RESPONSE_CODE_OBJ.GET_RESPONSEITEM("ACCOUNTRESPONSE", "1002").RES_HEADER, Inspriation.LibAPIS.CLASS_Cobehind.GlobalStaticObjects.APICLASS_RESPONSE_CODE_OBJ.GET_RESPONSEITEM("ACCOUNTRESPONSE", "1002").RES_CODE, Inspriation.LibAPIS.CLASS_Cobehind.GlobalStaticObjects.APICLASS_RESPONSE_CODE_OBJ.GET_RESPONSEITEM("ACCOUNTRESPONSE", "1002").RES_MESSAGE, Inspriation.LibAPIS.CLASS_Cobehind.GlobalStaticObjects.APICLASS_RESPONSE_CODE_OBJ.GET_RESPONSEITEM("ACCOUNTRESPONSE", "1002").RES_LINK);                
                else
                    AddResponseMessageToResponseDOC(Inspriation.LibAPIS.CLASS_Cobehind.GlobalStaticObjects.APICLASS_RESPONSE_CODE_OBJ.GET_RESPONSEITEM("ACCOUNTRESPONSE", "1003").RES_HEADER, Inspriation.LibAPIS.CLASS_Cobehind.GlobalStaticObjects.APICLASS_RESPONSE_CODE_OBJ.GET_RESPONSEITEM("ACCOUNTRESPONSE", "1003").RES_CODE, Inspriation.LibAPIS.CLASS_Cobehind.GlobalStaticObjects.APICLASS_RESPONSE_CODE_OBJ.GET_RESPONSEITEM("ACCOUNTRESPONSE", "1003").RES_MESSAGE, Inspriation.LibAPIS.CLASS_Cobehind.GlobalStaticObjects.APICLASS_RESPONSE_CODE_OBJ.GET_RESPONSEITEM("ACCOUNTRESPONSE", "1003").RES_LINK);
                Response.ContentType = "Text/XML";
                Response.Write(RESPONSEDOCUMENT.OuterXml);                
            }
            else
            {
                AddResponseMessageToResponseDOC(Inspriation.LibAPIS.CLASS_Cobehind.GlobalStaticObjects.APICLASS_RESPONSE_CODE_OBJ.GET_RESPONSEITEM("TOKENRESPONSE", "1001").RES_HEADER, Inspriation.LibAPIS.CLASS_Cobehind.GlobalStaticObjects.APICLASS_RESPONSE_CODE_OBJ.GET_RESPONSEITEM("TOKENRESPONSE", "1001").RES_CODE, Inspriation.LibAPIS.CLASS_Cobehind.GlobalStaticObjects.APICLASS_RESPONSE_CODE_OBJ.GET_RESPONSEITEM("TOKENRESPONSE", "1001").RES_MESSAGE, Inspriation.LibAPIS.CLASS_Cobehind.GlobalStaticObjects.APICLASS_RESPONSE_CODE_OBJ.GET_RESPONSEITEM("TOKENRESPONSE", "1001").RES_LINK);
            }
        }
    }
}