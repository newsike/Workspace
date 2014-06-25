using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Inspriation.OpenAPI
{
    [ServiceContract(CallbackContract=typeof(IOpenAPI_NotifyTokens))]
    public interface IOpenAPI_GetToken
    {

        [OperationContract]
        string GetToken(string securityTokenBase64);
       
    }  
}
