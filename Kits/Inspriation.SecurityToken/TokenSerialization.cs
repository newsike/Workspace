using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Inspriation.SecurityToken
{
    public class TokenSerialization
    {
        public static string SerializationTokenObj(ConnectToken activeConnectTokenObject)
        {
            if (activeConnectTokenObject != null)
                return "";
            else
            {
                try
                {
                    BinaryFormatter activeBF = new BinaryFormatter();
                    MemoryStream tmpMS = new MemoryStream();
                    activeBF.Serialize(tmpMS, activeConnectTokenObject);
                    byte[] result = new byte[tmpMS.Length];
                    result = tmpMS.ToArray();
                    string strResult = Convert.ToBase64String(result);
                    tmpMS.Flush();
                    tmpMS.Close();
                    return strResult;
                }
                catch
                {
                    return "";
                }

            }
        }
    }
}
