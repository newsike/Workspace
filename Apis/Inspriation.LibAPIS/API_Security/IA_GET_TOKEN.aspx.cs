using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Inspriation.LibAPIS.API_Security
{
    public partial class IA_GET_TOKEN : Inspriation.LibAPIS.CLASS_Cobehind.APICLASS_BASECLASS
    {
        protected override void  API_InitServices()
        {
            string strToken = "";
            strToken = Request["token"];            
            Inspriation.SecurityToken.ConnectToken activeToken=new SecurityToken.ConnectToken();
            if (strToken != "")
            {
                activeToken = Inspriation.SecurityToken.TokenDeserialize.DeserializeTokenObj(strToken);
                if (activeToken != null)
                {
                    bool passed = false;
                    if (!CLASS_Cobehind.GlobalStaticObjects.APICLASS_SECURITY_TOKEN_OBJ.ACTION_TOKEN_ISCHECKED(activeToken))
                    {
                        if (CLASS_Cobehind.GlobalStaticObjects.APICLASS_SECURITY_TOKEN_OBJ.ACTION_TOKEN_CHECK(activeToken))
                        {
                            passed = true;
                        }                        
                    }
                    if (!passed)
                    {
                        AddErrMessageToResponseDOC(Inspriation.LibAPIS.CLASS_Cobehind.GlobalStaticObjects.APICLASS_RESPONSE_CODE_OBJ.GET_RESPONSEITEM("TOKENRESPONSE", "2001").RES_CODE, Inspriation.LibAPIS.CLASS_Cobehind.GlobalStaticObjects.APICLASS_RESPONSE_CODE_OBJ.GET_RESPONSEITEM("TOKENRESPONSE", "2001").RES_MESSAGE, Inspriation.LibAPIS.CLASS_Cobehind.GlobalStaticObjects.APICLASS_RESPONSE_CODE_OBJ.GET_RESPONSEITEM("TOKENRESPONSE", "2001").RES_LINK);
                    }
                    else
                    {
                        AddResponseMessageToResponseDOC(Inspriation.LibAPIS.CLASS_Cobehind.GlobalStaticObjects.APICLASS_RESPONSE_CODE_OBJ.GET_RESPONSEITEM("TOKENRESPONSE", "2002").RES_HEADER, Inspriation.LibAPIS.CLASS_Cobehind.GlobalStaticObjects.APICLASS_RESPONSE_CODE_OBJ.GET_RESPONSEITEM("TOKENRESPONSE", "2002").RES_CODE, Inspriation.LibAPIS.CLASS_Cobehind.GlobalStaticObjects.APICLASS_RESPONSE_CODE_OBJ.GET_RESPONSEITEM("TOKENRESPONSE", "2001").RES_MESSAGE, Inspriation.LibAPIS.CLASS_Cobehind.GlobalStaticObjects.APICLASS_RESPONSE_CODE_OBJ.GET_RESPONSEITEM("TOKENRESPONSE", "2001").RES_LINK);
                    }   
                }
                else
                {
                    AddErrMessageToResponseDOC(Inspriation.LibAPIS.CLASS_Cobehind.GlobalStaticObjects.APICLASS_RESPONSE_CODE_OBJ.GET_RESPONSEITEM("TOKENRESPONSE", "2003").RES_CODE, Inspriation.LibAPIS.CLASS_Cobehind.GlobalStaticObjects.APICLASS_RESPONSE_CODE_OBJ.GET_RESPONSEITEM("TOKENRESPONSE", "2003").RES_MESSAGE, Inspriation.LibAPIS.CLASS_Cobehind.GlobalStaticObjects.APICLASS_RESPONSE_CODE_OBJ.GET_RESPONSEITEM("TOKENRESPONSE", "2003").RES_LINK);
                }
            }
        }
    }
}