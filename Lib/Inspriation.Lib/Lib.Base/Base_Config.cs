﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.IO;

namespace Inspriation.Lib
{
    public class Base_Config
    {
        XmlDocument _configDoc = new XmlDocument();
        public Security_DES refActiveDesObj;
        string _fileName = "";

        public Base_Config(string xmlData,string configKey)
        {
            _configDoc = new XmlDocument();
            _configDoc.LoadXml(xmlData);
            refActiveDesObj = new Security_DES(configKey);
        }

        public Base_Config(string configKey)
        {
            refActiveDesObj = new Security_DES(configKey);
        }
        public Base_Config()
        {
        }
        
        public Base_Config(string fileName,bool isEncry, string configKey)
        {
            try
            {
                _fileName = fileName;
                _configDoc.Load(fileName);
                if(isEncry)
                    refActiveDesObj = new Security_DES(configKey);
            }
            catch(Exception err)
            {
                _configDoc.LoadXml("<root></root>");
                throw err;
            }
        }

        public bool Create_NewConfigDocument()
        {
            try
            {
                _configDoc.LoadXml("<root></root>");
                _configDoc.Save(_fileName);
                return true;
            }
            catch
            {
                return false;
            }

        }

        public bool Create_NewConfigDocument(string newFilePath)
        {
            try
            {
                _configDoc.LoadXml("<root></root>");
                _configDoc.Save(newFilePath);                
                _fileName = newFilePath;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool doSave()
        {
            try
            {
                lock (_configDoc)
                {
                    _configDoc.Save(_fileName);
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public bool doOpen(string fileNamePath)
        {
            try
            {
                _configDoc = new XmlDocument();
                _configDoc.Load(fileNamePath);
                _fileName = fileNamePath;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Is_DocumentExisted(string activeFolderPath, string fileName)
        {
            if (fileName == "")
                return false;
            else
            {
                DirectoryInfo activeDIObj = new DirectoryInfo(activeFolderPath == "" ? Environment.CurrentDirectory : activeFolderPath);
                FileInfo[] activeFiles = activeDIObj.GetFiles("*.xml");
                foreach (FileInfo fi in activeFiles)
                {
                    if (fi.FullName.Contains(fileName))
                        return true;
                }
                return false;
            }
        }

        public void Set_OptionalEncryKey(string key)
        {
            refActiveDesObj = new Security_DES(key);
        }
        

        public XmlNode Create_NewSession(string SessionName, string SessionValue,bool IsEncry)
        {
            if (SessionName == "")
                return null;
            else
            {
                string result = SessionValue;
                if (IsEncry)
                    refActiveDesObj.DESCoding(SessionValue, out result);
                XmlNode newSessionNode = AwsXmlHelper.CreateNode(_configDoc, "session", result);
                AwsXmlHelper.SetAttribute(newSessionNode, "name", SessionName);
                _configDoc.SelectSingleNode("/root").AppendChild(newSessionNode);
                return newSessionNode;
            }
        }        

        public XmlNode Create_Item(XmlNode activeParentNode, string ItemName, string ItemValue, bool IsEncry)
        {
            if (activeParentNode == null)
                return null;
            string result = ItemValue;
            if (IsEncry)
                refActiveDesObj.DESCoding(ItemValue, out result);
            try
            {
                XmlNode newItemNode = AwsXmlHelper.CreateNode(_configDoc, "item", result);
                AwsXmlHelper.SetAttribute(newItemNode, "name", ItemName);
                activeParentNode.AppendChild(newItemNode);
                return newItemNode;
            }
            catch
            {
                return null;
            }
        }

        public XmlNode Get_ItemNode(string SessionName, string ItemName)
        {
            XmlNode activeSession = Get_SessionNode(SessionName);
            if (activeSession != null)
            {
                XmlNode itemNode = activeSession.SelectSingleNode("item[@name='" + ItemName + "']");
                return itemNode;
            }
            else
                return null;
        }

        public XmlNode Get_ItemNode(XmlNode parentNode, string ItemName)
        {
            if (parentNode != null)
            {                
                XmlNode itemNode = parentNode.SelectSingleNode("item[@name='" + ItemName + "']");
                return itemNode;            
            }
            else
                return null;
        }

        public XmlNodeList Get_ItemNodes(string SessionName, string ItemName)
        {
            XmlNode activeSession = Get_SessionNode(SessionName);
            if (activeSession != null)
            {
                XmlNodeList itemNodes = activeSession.SelectNodes("item[@name='" + ItemName + "']");
                return itemNodes;
            }
            else
                return null;
        }

        public XmlNodeList Get_ItemNodes(string SessionName)
        {
            XmlNode activeSession = Get_SessionNode(SessionName);
            if (activeSession != null)
            {
                XmlNodeList itemNodes = activeSession.SelectNodes("item");
                return itemNodes;
            }
            else
                return null;
        }

        public string Get_NodeValue(XmlNode activeNode, bool isEncry)
        {
            if (activeNode != null)
            {

                string sourceData = AwsXmlHelper.GetNodeValue("", activeNode);
                string resultData="";
                if (isEncry)
                {
                    refActiveDesObj.DESDecoding(sourceData, out resultData);
                }
                else
                {
                    resultData = sourceData;
                }
                return resultData;
            }
            else
                return "";
        }        

        public XmlNode Get_SessionNode(string SessionName)
        {
            if (SessionName == "")
                return null;
            else
            {
                XmlNode activeSessionNode = _configDoc.SelectSingleNode("/root/session[@name='" + SessionName + "']");
                if (activeSessionNode != null)
                    return activeSessionNode;
                else
                    return null;
            }
        }

        public XmlNodeList Get_SessionNodes()
        {
            if (_configDoc != null)
            {
                return _configDoc.SelectNodes("/root/session");
            }
            else
                return null;
        }

        public List<XmlAttribute> Get_SessionAttrs(string SessionName)
        {
            List<XmlAttribute> resultList=new List<XmlAttribute>();
            if (Is_SessionExisted(SessionName))
            {
                XmlNode activeSessionNode = Get_SessionNode(SessionName);
                if (activeSessionNode != null)
                {
                    foreach (XmlAttribute activeAttr in activeSessionNode.Attributes)
                        resultList.Add(activeAttr);
                }
                return resultList;
            }
            else
                return resultList;
        }

        public bool Set_SessionAttr(string SessionName, string AttrName, string AttrValue, bool IsEncry)
        {
            if(SessionName=="" || AttrName=="")
                return false;
            string activeAttrValue = AttrValue;
            string result = AttrValue;
            if (IsEncry)
                refActiveDesObj.DESCoding(AttrValue, out result);
            XmlNode activeSessionNode = Get_SessionNode(SessionName);
            if (activeSessionNode != null)
            {
                AwsXmlHelper.SetAttribute(activeSessionNode, AttrName, result);
                return true;
            }
            else
                return false;
        }

        public bool Set_SessionValue(string SessionName, string SessionValue, bool IsEncry)
        {
            if (SessionName == "")
                return false;
            else
            {
                XmlNode activeSessionNode = Get_SessionNode(SessionName);
                if (activeSessionNode != null)
                {
                    string SessionValueResult = "";
                    if (IsEncry)
                        refActiveDesObj.DESCoding(SessionValue, out SessionValueResult);
                    else
                        SessionValueResult = SessionValue;
                    activeSessionNode.InnerText = SessionValueResult;
                    return true;
                }
                else
                    return false;

            }
        }

        public bool Set_ItemAttr(XmlNode Item, string AttrName, string AttrValue, bool IsEncry)
        {
            if (Item == null)
                return false;
            else
            {
                string result = AttrValue;
                if (IsEncry)
                    refActiveDesObj.DESCoding(AttrValue, out result);
                AwsXmlHelper.SetAttribute(Item, AttrName, result);
                return true;
            }
        }

        public bool Set_InitDocument(string tagName, string tagValue, bool isEncry)
        {
            if (_configDoc == null)
                return false;
            else
            {
                XmlNode rootNode = _configDoc.SelectSingleNode("/root");
                if (rootNode == null)
                    return false;
                else
                {
                    string result = "";
                    refActiveDesObj.DESCoding(tagValue, out result);
                    AwsXmlHelper.SetAttribute(rootNode, tagName, isEncry ? result : tagValue);
                    return true;
                }
            }
        }

        public bool Is_InitDocument(string tagName, string tagValue, bool IsEncry)
        {
            if (_configDoc == null)
                return false;
            else
            {
                XmlNode rootNode = _configDoc.SelectSingleNode("/root");
                if (rootNode == null)
                    return false;
                else
                {
                    if (!IsEncry)
                        return AwsXmlHelper.GetNodeValue(tagName, rootNode) == tagValue ? true : false;
                    else
                    {
                        string result = "";
                        refActiveDesObj.DESCoding(tagValue, out result);
                        return AwsXmlHelper.GetNodeValue(tagName, rootNode) == result ? true : false;
                    }
                }
                    
            }
        }

        public bool Is_SessionExisted(string SessionName)
        {
            XmlNode activeSessionNode = Get_SessionNode(SessionName);
            if (activeSessionNode != null)
                return true;
            else
                return false;
        }

        public string Get_SessionValue(string SessionName,bool IsEncry)
        {
            if (SessionName == "")
                return "";
            else
            {
                XmlNode activeSessionNode = Get_SessionNode(SessionName);
                string value = AwsXmlHelper.GetNodeValue("", activeSessionNode);
                string result = value;
                if (IsEncry)
                    refActiveDesObj.DESDecoding(value, out result);
                return result;                
            }
        }

        public string Get_AttrValue(XmlNode ActiveNode, string AttrName,bool IsEncry)
        {
            if (ActiveNode == null)
                return "";
            else
            {
                string result = AwsXmlHelper.GetAttrValue(ActiveNode, AttrName);
                string encryResult = result;
                if (IsEncry)
                {
                    refActiveDesObj.DESDecoding(result, out encryResult);
                    result = encryResult;
                }
                return result;
            }
        }

        public string Get_ItemValue(string SessionName,string ItemName, bool IsEncry)
        {
            if (SessionName == "" || ItemName=="")
                return "";
            else
            {
                XmlNode activeItemNode = Get_ItemNode(SessionName, ItemName);
                string result = AwsXmlHelper.GetNodeValue("", activeItemNode);
                string encryResult=result;
                if (IsEncry)
                    refActiveDesObj.DESDecoding(result, out encryResult);
                return encryResult;
            }
        }

        public string Get_ItemValue(XmlNode parentNode, bool IsEncry)
        {
            if (parentNode == null)
                return "";
            else
            {
                string result = AwsXmlHelper.GetNodeValue("", parentNode);
                string encryResult = result;
                if (IsEncry)
                    refActiveDesObj.DESDecoding(result, out encryResult);
                return encryResult;
            }
        }

        

        public bool Remove_Session(string SessionName)
        {
            if (Is_SessionExisted(SessionName))
            {
                XmlNode activeSessionNode = Get_SessionNode(SessionName);
                if (activeSessionNode != null)
                {
                    activeSessionNode.ParentNode.RemoveChild(activeSessionNode);
                    return true;
                }
                else
                    return false;
            }
            else
                return false;
        }

        public bool Remove_SessionItem(string SessionName, string SessionItemName)
        {
            if (SessionName != "" && SessionItemName != "")
            {
                XmlNode activeSessionNode = Get_SessionNode(SessionName);
                if (activeSessionNode != null)
                {
                    XmlNode itemNode = Get_ItemNode(SessionName, SessionItemName);
                    if (itemNode != null)
                    {
                        activeSessionNode.RemoveChild(itemNode);
                        return true;
                    }
                    else
                        return false;

                }
                else
                    return false;
            }
            else
                return false;
        }

        public bool Remove_ActiveItem(XmlNode ParentNode, string ActiveItemName)
        {
            if (ParentNode == null)
                return false;
            else
            {
                XmlNode activeItemNode = ParentNode.SelectSingleNode("item[@name='" + ActiveItemName + "']");
                if (activeItemNode != null)
                {
                    ParentNode.RemoveChild(activeItemNode);
                    return true;
                }
                else
                    return false;
            }
        }

        public bool Remove_SessionAttr(string SessionName, string SessionAttrName)
        {
            if (Is_SessionExisted(SessionName))
            {
                XmlNode activeSessionNode = Get_SessionNode(SessionName);
                XmlAttribute activeAttr = activeSessionNode.Attributes[SessionAttrName];
                if (activeAttr != null)
                {
                    activeSessionNode.Attributes.Remove(activeAttr);
                    return true;
                }
                else
                    return false;
            }
            else
                return false;
        }

    }
}
