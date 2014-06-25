$(document).ready(ScriptStart);
var isAddMethodToButton = false;

function ScriptStart() {
    setTimeout(AddMethodToButton, 200);   
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
        var obj = activeControls.Get("key");
        var keyvalue = obj.GetText();
        obj = activeControls.Get("name");
        var namevalue = obj.GetText();
        obj = activeControls.Get("pwd");
        var pwdvalue = obj.GetText();
        obj = activeControls.Get("uname");
        var unamevalue = obj.GetText();
        obj = activeControls.Get("email");
        var emailvalue = obj.GetText();
        obj = activeControls.Get("im");
        var imvalue = obj.GetText();
        var netobj = new Commons_NetService();
        netobj.NonAsyGetRemoteStringWithPost('Actions/Action_SuCreateNewMember.aspx', { key: keyvalue, name: namevalue, pwd: pwdvalue, uname: unamevalue, email: emailvalue, im: imvalue }, 'xml', Callback_Response);   
    }
};

function initCheck(data) {
    if (data != '') {
        window.location.href = data;
    }
};

function loginCheck(data) {
    if (data.Result == 'Error') {
        messageBox.ActionDisplay('User Authorization Faild', 'Please check you username or password!');
    } else if (data.Result.indexOf(".html") >= 0) {
        window.location.href = data.Result;
    }
};


function check() {
    var obj = activeControls.Get("key");
    if (obj.GetText() == '') {
        messageBox.ActionDisplay('身份验证信息', '无法进行账户开通申请，请先输入您的授权码.');
        return false;
    }
    obj = activeControls.Get("name");
    if (obj.GetText() == '') {
        messageBox.ActionDisplay('身份验证信息', '无法进行账户开通申请，请先输入您的真实姓名以便系统进行安全验证.');
        return false;
    }
    obj = activeControls.Get("pwd");
    if (obj.GetText() == '') {
        messageBox.ActionDisplay('身份验证信息', '无法登录系统，请先输入您的账户密码，账户密码不可为空.');
        return false;
    }
    return true;
};