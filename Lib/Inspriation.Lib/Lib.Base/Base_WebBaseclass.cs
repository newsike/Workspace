using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Xml;

namespace Inspriation.Lib
{
    public class Codebehind_WebBase:System.Web.UI.Page
    {

        protected XmlDocument RESPONSEDOCUMENT = new XmlDocument();

        public Codebehind_WebBase()
        {
            RESPONSEDOCUMENT.LoadXml("<root></root>");
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

        protected virtual void InitServices()
        {
        }

        protected virtual void StartServices()
        {            
        }

        protected virtual void FinishedLoad()
        {
           
        }

        protected void AddErrMessageToResponseDOC(string header, string message,string link)
        {
            XmlNode errNode = AwsXmlHelper.CreateNode(RESPONSEDOCUMENT, "err", "");
            AwsXmlHelper.SetAttribute(errNode, "header", header);
            AwsXmlHelper.SetAttribute(errNode, "msg", message);
            AwsXmlHelper.SetAttribute(errNode, "link", link);
            RESPONSEDOCUMENT.SelectSingleNode("/root").AppendChild(errNode);
        }

        protected void AddResponseMessageToResponseDOC(string header, string code, string message,string link)
        {
            XmlNode newNode = AwsXmlHelper.CreateNode(RESPONSEDOCUMENT, "msg", "");
            AwsXmlHelper.SetAttribute(newNode, "header", header);
            AwsXmlHelper.SetAttribute(newNode, "code", code);
            AwsXmlHelper.SetAttribute(newNode, "msg", message);
            AwsXmlHelper.SetAttribute(newNode, "link", link);
            RESPONSEDOCUMENT.SelectSingleNode("/root").AppendChild(newNode);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            InitServices();
            StartServices();
            FinishedLoad();
        }       
    }
}
