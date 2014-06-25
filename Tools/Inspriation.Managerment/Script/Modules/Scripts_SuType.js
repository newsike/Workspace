$(document).ready(ScriptStart);
var isAddMethodToButton = false;
var typeDoc;

function ScriptStart() {
    setTimeout(AddMethodToButton, 200);    
};

function AddMethodToButton() {
    if (activeControls.GetLength() > 0 && isAddMethodToButton == false) {
        var obj = activeControls.Get("savetype_button");
        obj.ActionSetClick(CreateNewCorpInfo);
        obj = activeControls.Get("newtype_button");
        obj.ActionSetClick(newimgAction);
        obj = activeControls.Get("deltype_button");
        obj.ActionSetClick(DeleteItem);
        LoadImages();
        isAddMethodToButton = true;
    }
};

function CreateNewCorpInfo() {
    var obj = activeControls.Get("name");
    var namevalue = obj.GetText();
    obj = activeControls.Get("key");
    var keyvalue = obj.GetText();    
    if (namevalue == "" || keyvalue == "") {
        messageBox.ActionDisplay('系统警告', '无法保存新数据，请检查*号字段是否为空.');
        return false;
    }
    var rootNode = $(typeDoc).xpath("/root");
    var activeNode = $(rootNode).xpath("item[@type_name='" + namevalue + "']");
    if (activeNode.length != 0) {
        messageBox.ActionDisplay('系统警告', '无法继续保存新数据，您输入的名称已经存在.');
        return false;
    }
    var netobj = new Commons_NetService();
    obj = activeControls.Get("activetype_list");
    obj.ActionInsetItem(namevalue);
    netobj.NonAsyGetRemoteStringWithPost('Actions/Action_SuCreateNewType.aspx', { name: namevalue, key: keyvalue }, 'xml', Callback_Response);
    LoadImages();
};

function LoadImages() {    
    var netobj = new Commons_NetService();
    netobj.NonAsyGetRemoteStringWithPost('Actions/Action_SuGetAllTypeList.aspx', { key: 'post' }, 'xml', Callback_LoadTypes);
};

function Callback_LoadTypes(data) {
    var obj = activeControls.Get("activetype_list");
    obj.ActionClearAllItems();
    typeDoc = data;
    var rootNode = $(data).xpath("/root");  
    var items = $(rootNode).xpath("item");
    $(items).each(function () {
        var activeID = $(this).attr("type_name");
        obj.ActionInsetItem(activeID);
    });
};

function DeleteItem() {    
    var obj = activeControls.Get("activetype_list");
    var activeText = obj.ActionGetActiveItem();
    var item = $(typeDoc).xpath("/root/item[@type_name='" + activeText + "']");
    if (item.length != 0) {
        var id = $(item).attr("id");
        delImgAction(id);
    }
    else {
        messageBox.ActionDisplay('系统警告', '无法继续删除数据，您输入的名称不存在.');
        return false;
    }
};

function delImgAction(data) {
    var netobj = new Commons_NetService();
    netobj.NonAsyGetRemoteStringWithPost('Actions/Action_SuDeleteType.aspx?id=' + data, { key: 'post' }, 'xml', Callback_Response);
    LoadImages();
};

function newimgAction() {
    var obj = activeControls.Get("name");
    obj.SetText("");
    obj = activeControls.Get("key");
    obj.SetText("");
};