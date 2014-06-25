using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Inspriation.SecurityToken
{
    public class TokenDeserialize
    {
        public static ConnectToken DeserializeTokenObj(string SerializationString)
        {
            if (SerializationString == "")
                return null;
            else
            {
                try
                {
                    byte[] tmpBuffer = Convert.FromBase64String(SerializationString);
                    MemoryStream tmpMS = new MemoryStream(tmpBuffer, 0, tmpBuffer.Length);
                    BinaryFormatter activeBF = new BinaryFormatter();
                    ConnectToken activeToken = activeBF.Deserialize(tmpMS) as ConnectToken;
                    return activeToken;

                }
                catch
                {
                    return null;
                }
            }
        }
    }
}
