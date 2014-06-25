using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace Inspriation.LibAPISKit
{

    public enum LakResponseCode
    {
        CODE_VALIDATED_TOKEN = 2001,
        CODE_INVALIDATED_TOKEN = 2002,
        CODE_OBJECT_TOKEN = 2003,
        CODE_EXCEPTION_COMMON = 1001
    }

    public class LakResponse
    {
        private XmlDocument _responseDoc = new XmlDocument();

        public Dictionary<LakResponseCode, string> RESPONSE_CODE_MAPING = new Dictionary<LakResponseCode, string>();

        public LakResponse()
        {
            _responseDoc = new XmlDocument();
            _responseDoc.LoadXml("<root></root>");
            RESPONSE_CODE_MAPING.Add(LakResponseCode.CODE_VALIDATED_TOKEN, "Validated Token");
            RESPONSE_CODE_MAPING.Add(LakResponseCode.CODE_EXCEPTION_COMMON,"Common Exception");
        }

        public XmlDocument ResponseDocument
        {
            set
            {
                _responseDoc = value;
            }
            get
            {
                return _responseDoc;
            }
        }

        public void AddMsgToResponse(LakResponseCode Code, string optionalMessage)
        {
            XmlNode itemNode = Inspriation.Lib.AwsXmlHelper.CreateNode(_responseDoc, "item", "");
            Inspriation.Lib.AwsXmlHelper.SetAttribute(itemNode, "code", Code.ToString());
            Inspriation.Lib.AwsXmlHelper.SetAttribute(itemNode, "codedes", RESPONSE_CODE_MAPING[Code]);
            Inspriation.Lib.AwsXmlHelper.SetAttribute(itemNode, "msg", optionalMessage);
            _responseDoc.SelectSingleNode("/root").AppendChild(itemNode);
        }

        public string GetStrResponseDocument()
        {
            return _responseDoc.OuterXml;
        }

    }
}
