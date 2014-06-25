using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using Inspriation.Lib;

namespace InstallShield
{
    public class GlobalObjects
    {
        public static bool isLoaded = false;
        public static bool isEmailServices = false;
        public static string filePath = "";
        public static XmlDocument activeDoc = new XmlDocument();
        public static Security_DES activeDes;
        public static Base_Config activeConfigObj;
        public static Base_Config appConfig;
        public static string appConfigFile = "installshieldconf.xml";
        public static Inspriation.Lib.Base_EmailServices emailServicesObj;
    }
}
