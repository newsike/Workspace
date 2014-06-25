var userControl = new Global_UIControls_TextBox();
var pwdControl = new Global_UIControls_Password();
var checkControl = new Global_UIControls_Button();
var mainForm = new Global_UIContainer();
//var activeForm;
var mainformNode;

function init() {
    initAction();
    /*mainformNode = mainForm.CreateMainPanelWithPosition('_mainform', '', 1000, 1000, 0, 0, '');
    mainForm.ActionMoveToContainerCenter($(document.body), mainformNode);
    activeForm = mainForm.CreateChildPanel('_loginForm', mainformNode, '', 'url(Images/Form/Mainform.fw.png)', 1024, 1200, 0, 0);
    mainForm.ActionMoveToContainerCenter(mainformNode, activeForm);
    userControl.CreateControl(activeForm, 'txtUser', 'NonbackControl', '310', '18', '0', '', 197, 105, '');
    pwdControl.CreateControl(activeForm, 'txtUser', 'NonbackControl', '310', '18', '0', '', 197, 154, '');
    checkControl.CreateControl(activeForm, 'buttonCheck', '', 100, 20, 1, 'Black', 400, 200, 'Check');
    checkControl.ActionSetClick(summitAction);*/    
    //messageBox.CreateControl(activeForm, '', '', '');
};

$(document).ready(init);

function initAction() {
    var obj = new Commons_NetService();
    obj.AsyGetRemoteGetStringWithGETByCallBack('Actions/Actions_LoginInitChecking.aspx', '', initCheck);
};

function summitAction() {
    if (check()) {
        var usernamevalue = userControl.GetText();
        var passwordvalue = pwdControl.GetText();
        var obj = new Commons_NetService();
        obj.AsyGetRemoteStringWithPOSTByCallBack('Actions/Actions_SecurityChecking.aspx', { username: usernamevalue, password: passwordvalue }, 'json', loginCheck);
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
    if (userControl.GetText() == '') {
        messageBox.ActionDisplay('Login Error', 'Please enter username first,Code:100000');
        return false;
    }
    if (pwdControl.GetText() == '') {
        messageBox.ActionDisplay('Login Error', 'Please enter password first,Code:100001');
        return false;
    }
    return true;
};