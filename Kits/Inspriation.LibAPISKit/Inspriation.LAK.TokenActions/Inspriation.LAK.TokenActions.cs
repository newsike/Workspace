using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Xml;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Inspriation.LibAPISKit
{
    public class TokenActions
    {       
        public bool ACTION_TOKEN_CHECK(ref Inspriation.SecurityToken.ConnectToken activeToken)
        {
            if (activeToken == null)
                return false;
            else
            {
                if (activeToken.RequestProductID == "")
                    return false;
                XmlNode activeTokenNode = GlobalObjects.LIBAPIS_CONFIG_MAINCONFIGOBJ.Get_ItemNode("token", activeToken.TokenName);
                if (activeTokenNode != null)
                {
                    string strProductIDfromToken = GlobalObjects.LIBAPIS_CONFIG_MAINCONFIGOBJ.Get_AttrValue(activeTokenNode, "product", true);
                    string strClientIDfromToken = GlobalObjects.LIBAPIS_CONFIG_MAINCONFIGOBJ.Get_AttrValue(activeTokenNode, "client", true);
                    if (strClientIDfromToken == "" || strProductIDfromToken == "")
                        return false;
                    XmlNode activeClientNode = GlobalObjects.LIBAPIS_CONFIG_MAINCONFIGOBJ.Get_ItemNode("client", strClientIDfromToken);
                    Inspriation.Lib.Security_DES CLIENTDESOBJ = new Lib.Security_DES(activeToken.ClientKey);
                    string strPassword = "";
                    CLIENTDESOBJ.DESDecoding(GlobalObjects.LIBAPIS_CONFIG_MAINCONFIGOBJ.Get_AttrValue(activeClientNode, "password", false), out strPassword);
                    if (activeToken.ClientPassword == strPassword)
                    {                        
                        XmlNode activeProductNode = GlobalObjects.LIBAPIS_CONFIG_MAINCONFIGOBJ.Get_ItemNode("product", strProductIDfromToken);
                        string strEnteranceURL = GlobalObjects.LIBAPIS_CONFIG_MAINCONFIGOBJ.Get_AttrValue(activeProductNode, "enterance", true);
                        string strTimeOut = GlobalObjects.LIBAPIS_CONFIG_MAINCONFIGOBJ.Get_AttrValue(activeTokenNode, "timeout", true);
                        activeToken.RequestRemoteURL = strEnteranceURL;
                        string newGuid = Guid.NewGuid().ToString();
                        activeToken.TokenID = newGuid;
                        activeToken.TimeOut = int.Parse(strTimeOut);
                        activeToken.AcceptRequest();
                        return true;
                    }
                    else
                    {
                        activeToken.RefuseReuest();
                        return false;
                    }
                }
                else
                    return false;
            }
        }
    }
}
