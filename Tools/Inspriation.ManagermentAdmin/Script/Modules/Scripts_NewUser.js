var userControl = new Global_UIControls_TextBox();
var pwdControl = new Global_UIControls_Password();
var keyControl = new Global_UIControls_Password();
var checkControl = new Global_UIControls_Button();
var mainForm = new Global_UIContainer();
var activeForm;
var mainformNode;

function init() {
    mainformNode = mainForm.CreateMainPanelWithPosition('_mainform', '', 1000, 1000, 0, 0, '');
    mainForm.ActionMoveToContainerCenter($(document.body), mainformNode);
    activeForm = mainForm.CreateChildPanel('_loginForm', mainformNode, '', 'url(Images/Form/Form_NewAdmin.png)', 600, 300, 0, 200);
    mainForm.ActionMoveToContainerCenter(mainformNode, activeForm);
    userControl.CreateControl(activeForm, 'txtUser', 'NonbackControl', '310', '18', '0', '', 197, 105, '');
    keyControl.CreateControl(activeForm, 'txtKey', 'NonbackControl', '310', '18', '0', '', 197, 147, '');
    pwdControl.CreateControl(activeForm, 'txtUser', 'NonbackControl', '310', '18', '0', '', 197, 189, '');
    checkControl.CreateControl(activeForm, 'buttonCheck', '', 150, 20, 1, 'Black', 350, 250, 'Create New User');
    checkControl.ActionSetClick(summitAction);
    messageBox.CreateControl(activeForm, '', '', '');
};

$(document).ready(init);

function summitAction() {
    if (check()) {
        var obj = new Commons_NetService();
        var usernamevalue = userControl.GetText();
        var passwordvalue = pwdControl.GetText();
        var keycodevalue = keyControl.GetText();
        obj.AsyGetRemoteStringWithPOSTByCallBack('Actions/Actions_LoginNewUser.aspx', { username: usernamevalue, password: passwordvalue, checkcode: keycodevalue }, 'json', resultCheck);
    }
};

function resultCheck(data, status) {
    if (data == "Ok") {
        messageBox.ActionDisplay('Create new admin user sucessfully.', 'Thanks.Please redirect to : Start.html to start the system.');
    }
    else if (data == "Existed") {
        messageBox.ActionDisplay('Create new admin user faild.', 'This admin user has been existed,can not create again.');
    }
    else {
        messageBox.ActionDisplay('Create new admin user faild.', 'Please contact at administrator to check this issue.');
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
    if (keyControl.GetText() == '') {
        messageBox.ActionDisplay('Login Error', 'Please enter check code first,Code:100002');
        return false;
    }
    return true;
};