using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Inspriation.LibAPIS.CLASS_Cobehind
{
    public class APICLASS_SECURITY_TOKENS : Page
    {

        public bool ACTION_TOKEN_ISCHECKED(Inspriation.SecurityToken.ConnectToken activeToken)
        {
            if (activeToken == null)
                return false;
            else
            {
                if (Session[activeToken.TokenID] != null)
                {
                    if (Request.Cookies[activeToken.TokenID] != null)
                    {
                        if (Session[activeToken.TokenID] == Request.Cookies[activeToken.TokenID])
                            return true;
                        else
                            return false;
                    }
                    else
                        return false;
                }
                else
                    return false;
            }
        }

        public bool ACTION_TOKEN_ASYSESSIONANDPOOL(Inspriation.SecurityToken.ConnectToken activeToken)
        {
            return true;
        }

        public bool ACTION_TOKEN_CHECK(Inspriation.SecurityToken.ConnectToken activeToken)
        {
            if (activeToken == null)
                return false;
            else
            {
                if (activeToken.RequestProductID == "")
                    return false;
                XmlNode activeTokenNode = GlobalStaticObjects.LIBAPIS_CONFIG_MAINCONFIGOBJ.Get_ItemNode("token", activeToken.TokenName);
                if (activeTokenNode != null)
                {
                    string strProductIDfromToken = GlobalStaticObjects.LIBAPIS_CONFIG_MAINCONFIGOBJ.Get_AttrValue(activeTokenNode, "product", true);
                    string strClientIDfromToken = GlobalStaticObjects.LIBAPIS_CONFIG_MAINCONFIGOBJ.Get_AttrValue(activeTokenNode, "client", true);
                    if (strClientIDfromToken == "" || strProductIDfromToken == "")
                        return false;
                    XmlNode activeClientNode = GlobalStaticObjects.LIBAPIS_CONFIG_MAINCONFIGOBJ.Get_ItemNode("client", strClientIDfromToken);
                    Inspriation.Lib.Security_DES CLIENTDESOBJ = new Lib.Security_DES(activeToken.ClientKey);
                    string strPassword = "";
                    CLIENTDESOBJ.DESDecoding(GlobalStaticObjects.LIBAPIS_CONFIG_MAINCONFIGOBJ.Get_AttrValue(activeClientNode, "password", false), out strPassword);
                    if (activeToken.ClientPassword == strPassword)
                    {
                        activeToken.AcceptRequest();
                        XmlNode activeProductNode = GlobalStaticObjects.LIBAPIS_CONFIG_MAINCONFIGOBJ.Get_ItemNode("product", strProductIDfromToken);
                        string strEnteranceURL = GlobalStaticObjects.LIBAPIS_CONFIG_MAINCONFIGOBJ.Get_AttrValue(activeProductNode, "enterance", true);
                        string strTimeOut = GlobalStaticObjects.LIBAPIS_CONFIG_MAINCONFIGOBJ.Get_AttrValue(activeTokenNode, "timeout", true);
                        activeToken.RequestRemoteURL = strEnteranceURL;
                        string newGuid = Guid.NewGuid().ToString();
                        while (APICLASS_POOLS.POOLS_ACTIVETOKEN.ContainsKey(newGuid))
                            newGuid = Guid.NewGuid().ToString();
                        activeToken.TokenID = newGuid;
                        Session[activeToken.TokenID] = SecurityToken.TokenSerialization.SerializationTokenObj(activeToken);
                        APICLASS_POOLS.POOLS_ACTIVETOKEN.Add(activeToken.TokenID, activeToken);
                        Session.Timeout = int.Parse(strTimeOut);
                        HttpCookie newClientCookie = new HttpCookie(activeToken.TokenID);
                        foreach (string activeKey in Response.Cookies.AllKeys)
                        {
                            if (activeKey == activeToken.TokenID)
                                Response.Cookies.Remove(activeKey);
                        }
                        newClientCookie.Name = activeToken.TokenID;
                        newClientCookie.Value = SecurityToken.TokenSerialization.SerializationTokenObj(activeToken);
                        Response.Cookies.Add(newClientCookie);
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