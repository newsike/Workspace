using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Inspriation.LibAPIS.API_Security
{
    public partial class IA_CHECK_TOKENEXISTED : Inspriation.Lib.Codebehind_WebBase
    {
        protected override void InitServices()
        {
            Response.ContentType = "text/html";
            string returnStrXML="";
            string tokenid = GetQuerystringParam("tokenid");
            if (tokenid != "")
                tokenid = Request["tokenid"];
            if (Session["tokenid"] != null)
            {
                if (Session["tokenid"].ToString() == tokenid)
                    returnStrXML = "<root result='true'></root>";
                else
                    returnStrXML = "<root result='false'></root>";
            }
            else
                returnStrXML = "<root result='false'></root>";
            Response.Write(returnStrXML);           
        }
    }
}