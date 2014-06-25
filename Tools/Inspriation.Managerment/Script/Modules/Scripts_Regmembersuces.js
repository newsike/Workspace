$(document).ready(ScriptStart);
var isAddMethodToButton = false;

function ScriptStart() {
    setTimeout(AddMethodToButton, 500);
};

function AddMethodToButton() {
    if (activeControls.GetLength() > 0 && isAddMethodToButton == false) {
        var obj = activeControls.Get("getkey");
        obj.ActionSetClick(summitAction);
        isAddMethodToButton = true;    
    }
};

function summitAction() {
    var msg = commonHTTP.Get_ActiveParams('');
    if (msg != "") {
        var obj = activeControls.Get("ukey");
        obj.SetText(msg);
    }
};