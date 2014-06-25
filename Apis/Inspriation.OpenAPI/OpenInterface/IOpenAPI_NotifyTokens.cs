using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Inspriation.OpenAPI
{
    public interface IOpenAPI_NotifyTokens
    {
        void NotifyClient_Tokens(ref SecurityToken.ConnectToken activeToken);
    }
}