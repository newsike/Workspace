using System;
using System.Xml;

namespace Inspriation.Lib
{   
    public class CodeBehind_StartApplicationInitServices
    {
        public XmlDocument appDoc = new XmlDocument();
        public string activeApplicationConfigFilePath = "";

        public string GetAppConfigItem(string type)
        {
            if (type != "")
            {
                if (this.appDoc != null)
                {
                    XmlNode node = this.appDoc.SelectSingleNode("/root/item[@type='" + type + "']");
                    if (node != null)
                    {
                        return AwsXmlHelper.GetNodeValue("@value", node);
                    }
                    return "";
                }
                return "";
            }
            return "";
        }

        public bool LoadApplicationConfig(string appConfigFile)
        {
            try
            {
                this.appDoc.Load(appConfigFile);
                activeApplicationConfigFilePath = appConfigFile;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool updateConfigItem(string type, string value)
        {
            XmlNode newChild = this.appDoc.SelectSingleNode("/root/item[@type='" + type + "']");
            if (newChild == null)
            {
                newChild = AwsXmlHelper.CreateNode(this.appDoc, "item", "");
                this.appDoc.SelectSingleNode("/root").AppendChild(newChild);
                AwsXmlHelper.SetAttribute(newChild, "type", type);
                AwsXmlHelper.SetAttribute(newChild, "value", value);
            }
            else
            {
                AwsXmlHelper.SetAttribute(newChild, "type", type);
                AwsXmlHelper.SetAttribute(newChild, "value", value);
            }
            this.appDoc.Save(activeApplicationConfigFilePath);
            return true;
        }
    }
}

