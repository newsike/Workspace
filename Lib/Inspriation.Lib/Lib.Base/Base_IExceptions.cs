using System;
using System.Collections.Generic;

namespace Inspriation.Lib
{
    public class Exception_IAppExceptions : ApplicationException
    {
        public Exception_IAppExceptions()
        {
            LogServices_AppRuuningLogServices Log = new LogServices_AppRuuningLogServices(Environment.CurrentDirectory + @"\AppExceptionLog.xml");           
            Dictionary<string, string> attrList = new Dictionary<string, string>();
            attrList.Add("Catch_Time", DateTime.Now.ToString());
            attrList.Add("Message_Sys", base.Message);
            attrList.Add("Stack_Sys", base.StackTrace);
            Log.AddLogItem("Exception", attrList);
        }

        public void Write_Specil_Message(string Message)
        {
            LogServices_AppRuuningLogServices Log = new LogServices_AppRuuningLogServices(Environment.CurrentDirectory + @"\AppExceptionLog.xml");
            Dictionary<string, string> attrList = new Dictionary<string, string>();
            attrList.Add("Catch_Time", DateTime.Now.ToString());
            attrList.Add("Message_Sys", Message);
            attrList.Add("Stack_Sys", "None");
            Log.AddLogItem("Exception", attrList);
        }
    }
}

