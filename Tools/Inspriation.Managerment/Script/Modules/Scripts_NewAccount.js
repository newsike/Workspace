$(document).ready(ScriptStart);
var isAddMethodToButton = false;

function ScriptStart() {
    setTimeout(AddMethodToButton, 200);    
};

function AddMethodToButton() {
    if (activeControls.GetLength() > 0 && isAddMethodToButton == false) {
        var obj = activeControls.Get("reg_btn_create");
        obj.ActionSetClick(SummitToServer);
        isAddMethodToButton = true;
    }
};

function SummitToServer() {
    
};