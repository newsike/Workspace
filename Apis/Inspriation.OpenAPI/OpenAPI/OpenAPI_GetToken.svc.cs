using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Inspriation.Lib;

namespace Inspriation.OpenAPI
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    public class OpenAPI_GetToken : IOpenAPI_GetToken
    {
        public string GetToken(string securityTokenBase64)
        {            
            string strToken = "";
            strToken = securityTokenBase64;
            Inspriation.SecurityToken.ConnectToken activeToken = new SecurityToken.ConnectToken();
            Inspriation.LibAPISKit.LakResponse ResponseDoc = new LibAPISKit.LakResponse();
            if (strToken != "")
            {
                activeToken = Inspriation.SecurityToken.TokenDeserialize.DeserializeTokenObj(strToken);
                if (activeToken != null)
                {
                    bool passed = false;
                    if (Inspriation.OpenAPI.OpenAPI_GlobalObjects.GlobalObj_TokenActions.ACTION_TOKEN_CHECK(ref activeToken))
                    {
                        passed = true;
                    }                    
                    if (!passed)
                    {
                        ResponseDoc.AddMsgToResponse(LibAPISKit.LakResponseCode.CODE_INVALIDATED_TOKEN, "Invalidate Taken");                        
                    }
                    else
                    {
                        SecurityToken.TokenDeserialize objTokenDeserialize=new SecurityToken.TokenDeserialize();                        
                        ResponseDoc.AddMsgToResponse(LibAPISKit.LakResponseCode.CODE_OBJECT_TOKEN,SecurityToken.TokenSerialization.SerializationTokenObj(activeToken));
                    }
                }
                else
                {
                    ResponseDoc.AddMsgToResponse(LibAPISKit.LakResponseCode.CODE_EXCEPTION_COMMON,"Empty Token");                    
                }
            }
            return ResponseDoc.GetStrResponseDocument();
        }
    }
}
