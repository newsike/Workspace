$(document).ready(ScriptStart);
var isAddMethodToButton = false;

function ScriptStart() {
    setTimeout(AddMethodToButton, 100);
    //$(obj.inputNode).click(summitAction);
};

function AddMethodToButton() {
    if (activeControls.GetLength() > 0 && isAddMethodToButton == false) {
        var obj = activeControls.Get("loginbutton");
        obj.ActionSetClick(summitAction);
        isAddMethodToButton = true;
    }
};

function summitAction() {    
    if (check()) {        
    }
};

function check() {
    var obj = activeControls.Get("uer");
    var unamevalue = obj.GetText();
    if (obj.GetText() == '') {
        messageBox.ActionDisplay('身份验证信息', '无法登录系统，请先输入您的账户名称，账户名称不可为空.');
        return false;
    }
    obj = activeControls.Get("pwd");
    var pwdvalue = obj.GetText();
    if (obj.GetText() == '') {
        messageBox.ActionDisplay('身份验证信息', '无法登录系统，请先输入您的账户密码，账户密码不可为空.');
        return false;
    }
    obj = activeControls.Get("key");
    var keyvalue = obj.GetText();
    if (obj.GetText() == '') {
        messageBox.ActionDisplay('身份验证信息', '无法登录系统，请先输入您的账户密钥，账户密钥不可为空.');
        return false;
    }
    var netobj = new Commons_NetService();
    netobj.NonAsyGetRemoteStringWithPost('Actions/Action_SuLogin.aspx', { uname: unamevalue, pwd: pwdvalue, key: keyvalue }, 'xml', Callback_Response);
    return true;
};