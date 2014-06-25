using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Inspriation.SecurityToken;

namespace Inspriation.LibAPISKit
{
    public class Pool_Item
    {
        public Dictionary<string, ConnectToken> ACTIVE_TOKENPOOLS = new Dictionary<string, ConnectToken>();

    }

    public class Common_Pools
    {
        public static Dictionary<string, Pool_Item> POOLS_TOKEN = new Dictionary<string, Pool_Item>();

    }
}
