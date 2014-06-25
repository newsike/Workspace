using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Inspriation.LibAPIS.API_Security
{
    public partial class IA_GET_NEWTOKEN : Inspriation.LibAPIS.CLASS_Cobehind.APICLASS_BASECLASS
    {
        protected override void API_StartServices()
        {
            string U_CLIENTKEY = GetQuerystringParam("clientkey");
            string U_CLIENTNAME = GetQuerystringParam("clientname");
            string U_CLIENTPASSWORD = GetQuerystringParam("clientpassword");
            string U_TOKENNAME = GetQuerystringParam("tokenname");
            Inspriation.SecurityToken.ConnectToken tokenObj = new Inspriation.SecurityToken.ConnectToken();
            tokenObj.ClientKey = U_CLIENTKEY;
            tokenObj.ClientPassword = U_CLIENTNAME;
            tokenObj.ClientName = U_CLIENTPASSWORD;
            tokenObj.TokenName = U_TOKENNAME;
            string str_activetoken = Inspriation.SecurityToken.TokenSerialization.SerializationTokenObj(tokenObj);

        }
    }
}