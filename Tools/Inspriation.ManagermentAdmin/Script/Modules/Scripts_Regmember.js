$(document).ready(ScriptStart);
var isAddMethodToButton = false;

function ScriptStart() {
    setTimeout(AddMethodToButton, 200);   
};

function AddMethodToButton() {
    if (activeControls.GetLength() > 0 && isAddMethodToButton == false) {
        var obj = activeControls.Get("reg_btn_create");
        obj.ActionSetClick(summitAction);
        isAddMethodToButton = true;        
    }    
};

function summitAction() {    
    if (check()) {
        var obj = activeControls.Get("reg_txt_regcode");
        var u_regcode = obj.GetText();
        obj = activeControls.Get("reg_txt_username");
        var u_name = obj.GetText();
        obj = activeControls.Get("reg_pwd_userpwd");
        var u_pwd = obj.GetText();
        obj = activeControls.Get("reg_txt_optionalkey");
        var u_key = obj.GetText();
        var inputXML = "<root><item u_level='0' u_name='" + u_name + "' u_regcode='" + u_regcode + "' u_pwd='" + u_pwd + "' u_key='" + u_key + "'></item></root>";
        var netobj = new Commons_NetService();
        netobj.NonAsyGetRemoteStringWithPost('Actions/Action_SuCreateNewMember.aspx', { input: inputXML }, 'xml', Callback_SummitResponse);
    }
};

function Callback_SummitResponse(data) {
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
    var obj = activeControls.Get("reg_txt_regcode");
    if (obj.GetText() == '') {
        messageBox.ActionDisplay('Account Message', 'Please enter the security code first.');
        return false;
    }
    obj = activeControls.Get("reg_txt_username");
    if (obj.GetText() == '') {
        messageBox.ActionDisplay('Account Message', 'Please enter the username first.');
        return false;
    }
    obj = activeControls.Get("reg_pwd_userpwd");
    if (obj.GetText() == '') {
        messageBox.ActionDisplay('Account Message', 'Please enter the password first.');
        return false;
    }
    return true;
};