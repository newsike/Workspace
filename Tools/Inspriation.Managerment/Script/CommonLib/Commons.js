function Global_LoadingBox() {
    var divNode;

    this.CreateControl = function () {
        divNode = $("<div></div>");
        divNode.css("width", "400px");
        divNode.css("height", "100px");
        divNode.css("border-color", BorderColor);
        divNode.css("position", "absolute");
        divNode.css("backgroundImage", "url(BaseScripts/CommonLib/Images/Alert/Loading.fw.png)");
        divNode.css("visibility", "hidden");
        divNode.css("z-index", "20000");
        var contentDomNode;
        window.document.body.append(divNode);
        this.ActionMoveToContainerCenter(window.document.body, divNode);
        this.ActionMoveToContainerMiddle(window.document.body, divNode);
    };

    this.ActionMoveToContainerCenter = function (Container, Control) {
        if (Container == null)
            return false;
        var ContainerWidth = Container.width();
        var ControlWidth = Control.width();
        if (ControlWidth > ContainerWidth) {
            Control.css("left", "0px");
            return true;
        }
        else {
            var HalfControlWidth = ControlWidth / 2;
            var HalfContainerWidth = ContainerWidth / 2;
            var PositionFlag = HalfContainerWidth - HalfControlWidth;
            Control.css("left", PositionFlag.toString() + "px");
        }
    };

    this.ActionMoveToContainerMiddle = function (Container, Control) {
        if (Container == null)
            return false;
        var ContainerHeight = Container.height();
        var ControlHeight = Control.height();
        if (ControlHeight > ContainerHeight) {
            Control.css("top", "0px");
            return true;
        }
        else {
            var HalfControlHeight = ControlHeight / 2;
            var HalfContainerHeight = ContainerHeight / 2;
            var PositionFlag = HalfContainerHeight - HalfControlHeight;
            Control.css("top", PositionFlag.toString() + "px");
        }
    };

    this.ActionDisplay = function () {
        if (divNode != null) {
            if (divNode.css("visibility") == "hidden")
                divNode.css("visibility", "visible");
            else
                divNode.css("visibility", "hidden");
        }        
    };

};


function Commons_NetService() {

    var remoteXmlDoc;

    this.HtmlEncode = function (text) {
        var temp = document.createElement("div");
        (temp.textContent != null) ? (temp.textContent = text) : (temp.innerText = text);
        var output = temp.innerHTML;
        temp = null;
        return output;        
    };
         

    this.GetRemoteXmlResult = function () {
        return this.remoteXmlDoc;
    };

    this.SetRemoteXmlResult = function (xmldata) {
        this.remoteXmlDoc = xmldata;
    };

    this.NonAsyGetRemoteStringWithGet = function (url, postdata) {
        $.ajaxSetup({ async: false });
        if (url == "")
            return "";
        else {
            $.get(url, getdata, function (data) {
                return data;
            });
        }
    };

    this.NonAsyGetRemoteStringWithPost = function (url, postdata, type, callbackref) {
        $.ajaxSetup({ async: false });
        if (url == "")
            return "";
        else {
            $.post(url, postdata, callbackref, type);   
        }
    };

    this.AsyGetRemoteStringWithPOSTByCallBack = function (url, postdata, type, callbackref) {        
        if (url == "")
            return "";
        else {
            $.post(url, postdata, callbackref, type);
        }
    };
    this.AsyGetRemoteGetStringWithGETByCallBack = function (url, getdata, callbackref) {        
        if (url == "")
            return "";
        else {
            $.get(url, getdata, callbackref);
        }
    };
    this.AsyGetRemoteXML = function (url, callbackref) {
        if (url == "")
            return null;
        else {
            $.ajax({ type: 'GET', url: url, dataType: 'xml', success: callbackref });
        }
    };
};

function Commons_HTTP() {

    this.Get_ActiveURL = function () {
        var activeFullURL = window.location.href.split("/");
        var realFullURL = activeFullURL[activeFullURL.length - 1].split("#");
        return realFullURL[0];
    };

    this.Get_ActiveParams = function (spliter) {
        var activeFullParams = window.location.href.split("#");
        if (activeFullParams.length > 1) {
            if (spliter != "") {
                var activeParams = activeFullParams[activeFullParams.length - 1].split(spliter);
                return activeParams;
            }
            else {
                return activeFullParams[activeFullParams.length - 1];
            }
        }
        else
            return "";
    };

};

function Common_Dynamics() {

    var activeNode;
    var itemAttrName = "item";

    this.SetIemAttrName = function (activeItemAttrName) {
        itemAttrName = activeItemAttrName;
    };

    this.CreateDynamicUpdate = function (url, rootNode) {
        if (url != "") {
            if (rootNode != null || rootNode != undefined) {
                activeNode = rootNode;
                var tmpNetObj = new Commons_NetService();
                tmpNetObj.NonAsyGetRemoteStringWithPost(url, { key: 'post' }, 'xml', this.Callback_Result);
            }
        }
        else {
            return false;
        }
    };

    this.Callback_Result = function (data) {
        $(activeNode).empty();
        var rootNodes = $(data).xpath("/root");
        var itemsNodes = $(rootNodes).xpath(itemAttrName);
        for (var i = 0; i < itemsNodes.length; i++) {
            $(activeNode).append(itemsNodes[i]);
        }       
    };

};

