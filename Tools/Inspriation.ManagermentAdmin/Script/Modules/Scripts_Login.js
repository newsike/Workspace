$(document).ready(ScriptStart);
var isAddMethodToButton = false;

function ScriptStart() {
    setTimeout(AddMethodToButton, 100);
    //$(obj.inputNode).click(summitAction);
};

function AddMethodToButton() {
    if (activeControls.GetLength() > 0 && isAddMethodToButton == false) {
        var obj = activeControls.Get("logic_btn_login");
        obj.ActionSetClick(summitAction);
        isAddMethodToButton = true;
    }
};

function summitAction() {    
    if (check()) {        
    }
};

function check() {
    var obj = activeControls.Get("login_txt_username");
    var unamevalue = obj.GetText();
    if (obj.GetText() == '') {
        messageBox.ActionDisplay('Login Alert', 'You can not login the system,the username can not be empty.');
        return false;
    }
    obj = activeControls.Get("login_pwd_userpwd");
    var pwdvalue = obj.GetText();
    if (obj.GetText() == '') {
        messageBox.ActionDisplay('Login Alert', 'You should enter the password first.');
        return false;
    }
    obj = activeControls.Get("login_txt_keycode");
    var keyvalue = obj.GetText();
    if (obj.GetText() == '') {
        messageBox.ActionDisplay('Login Alert', 'The key code can not be empty,please enter first.');
        return false;
    }
    //var netobj = new Commons_NetService();
    //netobj.NonAsyGetRemoteStringWithPost('Actions/Action_SuLogin.aspx', { uname: unamevalue, pwd: pwdvalue, key: keyvalue }, 'xml', Callback_Response);
    return true;
};