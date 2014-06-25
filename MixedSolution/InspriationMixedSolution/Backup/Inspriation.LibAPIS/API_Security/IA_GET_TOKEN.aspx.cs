using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Inspriation.LibAPIS.API_Security
{
    public partial class IA_GET_TOKEN : Inspriation.Lib.Codebehind_WebBase
    {
        protected override void InitServices()
        {
            string strToken = "";
            strToken = Request["token"];            
            Inspriation.SecurityToken.ConnectToken activeToken=new SecurityToken.ConnectToken();
            if (strToken != "")
            {
                activeToken = Inspriation.SecurityToken.TokenDeserialize.DeserializeTokenObj(strToken);
                if (activeToken != null)
                {
                }
                else
                {
                }
            }
        }
    }
}