using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Net;
using System.Text;

public class ManagementAdminBaseClass : System.Web.UI.Page
{

    public string str_activetoken;
    public string str_tokenKey = "ASDFGHJK";
    public string str_tokenPassword = "12345678";
    public string str_tokenClientName = "AWSE_INSPRIATION_FAMILY";
    public string str_tokenName = "TOKEN_API_CORE";
    public string str_APIServer = "http://127.0.0.1/Inspriation.LibAPIS/";

    protected void Page_Load(object sender, EventArgs e)
    {
        Inspriation.SecurityToken.ConnectToken tokenObj = new Inspriation.SecurityToken.ConnectToken();
        tokenObj.ClientKey = str_tokenKey;
        tokenObj.ClientPassword = str_tokenPassword;
        tokenObj.ClientName = str_tokenClientName;
        tokenObj.TokenName = str_tokenName;
        str_activetoken = Inspriation.SecurityToken.TokenSerialization.SerializationTokenObj(tokenObj);
        ActionStart();
    }

    protected virtual void ActionStart()
    {

    }

    protected string GetQuerystringParam(string paramName)
    {
        if (paramName != "")
        {
            try
            {
                return Request.QueryString[paramName].ToString();
            }
            catch
            {
                return "";
            }
        }
        else
            return "";
    }

    public string getRemoteRequestToString(string input, string remoteurl, int requestTimeOut, List<Cookie> activeCookies)
    {
        try
        {
            byte[] bytes = Encoding.Default.GetBytes(input);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(remoteurl);
            request.CookieContainer = new CookieContainer();
            if (activeCookies != null && activeCookies.Count > 0)
                foreach (Cookie activeCookie in activeCookies)
                    request.CookieContainer.Add(activeCookie);
            request.Timeout = 0x1b7740;
            request.Method = "post";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = bytes.Length;
            Stream requestStream = request.GetRequestStream();
            requestStream.Write(bytes, 0, bytes.Length);
            requestStream.Flush();
            requestStream.Close();
            Stream responseStream = ((HttpWebResponse)request.GetResponse()).GetResponseStream();
            StreamReader reader = new StreamReader(responseStream);
            string str = reader.ReadToEnd();
            reader.Close();
            responseStream.Close();
            return str;
        }
        catch
        {
            return "";
        }
    }

}