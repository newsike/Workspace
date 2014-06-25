using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;


namespace Inspriation.SecurityToken
{
    [DataContract]
    public class ConnectToken
    {
        private string _TokenID = "";
        private string _RequestProductID;
        private int _RequestTimesOnSession = 0;
        private bool _IsTimeOut = true;
        private int _Timeout = 0;
        private string _RequestClientIP = "";
        private string _RequestClientName = "";
        private string _RequestClientPassword = "";
        private string _RequestClientKey = "";
        private DateTime _ConnectedTime;
        private string _ResponseMessage = "";
        private bool _IsAccepedFromServer = true;
        private string _RequestRemoteServer = "";
        private string _RequestRemoteURL = "";
        private string _RequestAction = "";
        private string _RequestTokenName = "";
        private string _ResponseDocument = "";
        
        [DataMember]
        public string RequestRemoteServer
        {
            get
            {
                return _RequestRemoteServer;
            }
            set
            {
                _RequestRemoteServer = value;
            }
        }

        [DataMember]
        public int TimeOut
        {
            get
            {
                return _Timeout;
            }
            set
            {
                _Timeout = value;
            }
        }

        [DataMember]
        public string RequestRemoteURL
        {
            get
            {
                return _RequestRemoteURL;
            }
            set
            {
                _RequestRemoteURL = value;
            }
        }

        [DataMember]
        public string RequestAction
        {
            get
            {
                return _RequestAction;
            }
            set
            {
                _RequestAction = value;
            }
        }

        [DataMember]
        public string TokenID
        {
            get
            {
                return _TokenID;
            }
            set
            {
                _TokenID = value;
            }
        }

        [DataMember]
        public string RequestProductID
        {
            get
            {
                return _RequestProductID;
            }
            set
            {
                _RequestProductID = value;
            }
        }

        [DataMember]
        public string RequestClientIP
        {
            get
            {
                return _RequestClientIP;
            }
            set
            {
                _RequestClientIP = value;
            }
        }

        [DataMember]
        public int RequestTimesOnSession
        {
            get
            {
                return _RequestTimesOnSession;
            }
        }

        [DataMember]
        public bool IsAcceptFromRemoteServer
        {
            get
            {
                return _IsAccepedFromServer;
            }
        }

        [DataMember]
        public string ClientName
        {
            set
            {
                _RequestClientName = value;
            }
            get
            {
                return _RequestClientName;
            }
        }

        [DataMember]
        public string ClientKey
        {
            set
            {
                _RequestClientKey = value;
            }
            get
            {
                return _RequestClientKey;
            }
        }

        [DataMember]
        public string ClientPassword
        {
            set
            {
                _RequestClientPassword = value;
            }
            get
            {
                return _RequestClientPassword;
            }
        }

        [DataMember]
        public string TokenName
        {
            set
            {
                _RequestTokenName = value;
            }
            get
            {
                return _RequestTokenName;
            }
        }

        [DataMember]
        public string ResponseXMLDocument
        {
            set
            {
                _ResponseDocument = value;
            }
            get
            {
                return _ResponseDocument;
            }
        }

        
        public void ConnectToServer()
        {
            if (_RequestTimesOnSession == 0)
                _ConnectedTime = DateTime.Now;
            _RequestTimesOnSession++;
        }

        public void AcceptRequest()
        {
            _IsAccepedFromServer = true;
        }

        public void RefuseReuest()
        {
            _IsAccepedFromServer = false;
        }

    }
}
