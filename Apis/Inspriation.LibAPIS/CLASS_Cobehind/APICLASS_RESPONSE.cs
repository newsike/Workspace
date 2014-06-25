using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;

namespace Inspriation.LibAPIS.CLASS_Cobehind
{

    public class APICLASS_RESPONSE_ITEM
    {
        public string RES_HEADER = "";
        public string RES_CODE = "";
        public string RES_MESSAGE = "";
        public string RES_LINK="";
    }

    public class APICLASS_RESPONSE
    {

        public Dictionary<string, Dictionary<string, APICLASS_RESPONSE_ITEM>> RESPONSE_CODE_MAPING = new Dictionary<string, Dictionary<string, APICLASS_RESPONSE_ITEM>>();
        public XmlDocument RESPONSE_CODE_DOC = new XmlDocument();

        public APICLASS_RESPONSE(string rootPath)
        {
            RESPONSE_CODE_DOC.Load(rootPath + "\\" + LibAPIS.CLASS_Cobehind.GlobalStaticObjects.LIBAPIS_RESPONSECODE_FILE);                
        }

        private void INIT_RESPONSEITEMS()
        {
            XmlNodeList headerNodes = RESPONSE_CODE_DOC.SelectNodes("/root/header");
            foreach (XmlNode headerNode in headerNodes)
            {
                string header = Inspriation.Lib.AwsXmlHelper.GetNodeValue("@header", headerNode);
                Dictionary<string,APICLASS_RESPONSE_ITEM> RESPONSE_ITEMS_DIC=new Dictionary<string,APICLASS_RESPONSE_ITEM>();
                RESPONSE_CODE_MAPING.Add(header, RESPONSE_ITEMS_DIC);
                XmlNodeList items = headerNode.SelectNodes("item");
                foreach (XmlNode activeItem in items)
                {
                    string itemHeader = Inspriation.Lib.AwsXmlHelper.GetNodeValue("@header", activeItem);
                    string code = Inspriation.Lib.AwsXmlHelper.GetNodeValue("@code", activeItem);
                    string message = Inspriation.Lib.AwsXmlHelper.GetNodeValue("@message", activeItem);
                    string link = Inspriation.Lib.AwsXmlHelper.GetNodeValue("@link", activeItem);
                    APICLASS_RESPONSE_ITEM newitem = new APICLASS_RESPONSE_ITEM();
                    newitem.RES_HEADER = itemHeader;
                    newitem.RES_CODE = code;
                    newitem.RES_LINK = link;
                    newitem.RES_MESSAGE = message;
                    RESPONSE_ITEMS_DIC.Add(code, newitem);
                }                
            }
        }

        public APICLASS_RESPONSE_ITEM GET_RESPONSEITEM(string normalHeader, string itemCode)
        {
            if (normalHeader != "" && itemCode != "")
            {
                Dictionary<string, APICLASS_RESPONSE_ITEM> itemsdic = new Dictionary<string, APICLASS_RESPONSE_ITEM>();
                itemsdic = RESPONSE_CODE_MAPING[normalHeader];
                return itemsdic[itemCode];
            }
            else
                return null;
        }


        
    }
}