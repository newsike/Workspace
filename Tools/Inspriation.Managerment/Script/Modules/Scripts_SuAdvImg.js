$(document).ready(ScriptStart);
var isAddMethodToButton = false;
var advModuleMaping = new Dirc();
var module_imgidlist = new Dirc();

function ScriptStart() {
    setTimeout(AddMethodToButton, 200);    
};

function AddMethodToButton() {
    if (activeControls.GetLength() > 0 && isAddMethodToButton == false) {
        var obj = activeControls.Get("addimg_button");
        obj.ActionSetClick(AddImgToList);
        obj = activeControls.Get("delimg_button");
        obj.ActionSetClick(RemoveImgFromList);
        obj = activeControls.Get("loadimg_button");
        obj.ActionSetClick(ActionLoadModuleSetting);
        obj = activeControls.Get("addsetting_button");
        obj.ActionSetClick(CreateNewAdvInfo);
        obj = activeControls.Get("removesetting_button");
        obj.ActionSetClick(delImgAction);
        LoadImages();
        LoadModule();
        LoadActiveModules();
        isAddMethodToButton = true;
    }
};

function AddImgToList() {
    var obj_imglist = activeControls.Get("image_list");
    var obj_activeimglist = activeControls.Get("activeimage_list");
    var text = obj_imglist.ActionGetActiveItem();
    obj_activeimglist.ActionInsetItem(text);
};

function RemoveImgFromList() {
    var obj_activeimglist = activeControls.Get("activeimage_list");
    var text = obj_activeimglist.ActionGetActiveItem();
    obj_activeimglist.ActionRemoveItem(text);
};

function LoadActiveModules() {
    var netObj = new Commons_NetService();
    netObj.AsyGetRemoteXML('Actions/Action_SuGetAllAdvImgList.aspx', callback_loadactivemodules);  

};

function callback_loadactivemodules(data) {
    var obj = activeControls.Get("alladvsetting_list");
    obj.ActionClearAllItems();
    var activeList_Obj = activeControls.Get("activeimage_list");
    activeList_Obj.ActionClearAllItems();
    var items = $(data).xpath("/root/item");
    $(items).each(function () {
        var module_name = $(this).attr("module_name");
        var module_id = $(this).attr("id");
        var module_imgid = $(this).attr("module_imgid");
        var module_action = $(this).attr("module_actionURL");
        var module_page = $(this).attr("module_page");
        module_imgidlist.Add(module_name, module_imgid);
        obj.ActionInsetItem(module_name);
    });
};

function LoadModule() {
    var netObj = new Commons_NetService();
    netObj.AsyGetRemoteXML('Actions/InspriationWebUIConfig.xml', callback_UIXML);  

};

function callback_UIXML(data) {
    var forms = $(data).xpath("/root/session[@type='form']");
    var activeForms = $(forms).xpath("item[@type='childform']");
    var obj_activeimglist = activeControls.Get("alladv_list");
    $(activeForms).each(function () {
        var avtivesControls = $(this).xpath("item");
        $(avtivesControls).each(function () {
            var control_name = $(this).attr("name");
            var control_type = $(this).attr("control");
            var control_page = $(this).attr("isTemplater");
            if (control_type == "ADV") {               
                obj_activeimglist.ActionInsetItem(control_name);
                advModuleMaping.Add(control_name, control_page);               
            }
        });
    });
};

function ActionLoadModuleSetting() {
    var netObj = new Commons_NetService();
    netObj.AsyGetRemoteXML('Actions/Action_SuGetAllAdvImgList.aspx', callback_loadactivemodulesetting);  

   
};

function callback_loadactivemodulesetting(data) {

    var obj_activeimglist = activeControls.Get("alladv_list");
    var result = obj_activeimglist.ActionGetActiveItem();

    var activeitem = $(data).xpath("/root/item[@module_name='" + result + "']");
    var module_name = $(activeitem).attr("module_name");
    var module_id = $(activeitem).attr("id");
    var module_imgid = $(activeitem).attr("module_imgid");
    var module_action = $(activeitem).attr("module_actionURL");
    var module_page = $(activeitem).attr("module_page");
    var obj_page = activeControls.Get("page_list");
    obj_page.SetText(module_page);
    var obj_activeImgList = activeControls.Get("activeimage_list");
    var module_imgids = module_imgid.split('|');
    obj_activeImgList.ActionClearAllItems();
    for (var i = 0; i < module_imgids.length; i++) {
        if (module_imgids[i] != "") {
            obj_activeImgList.ActionInsetItem("Active Image ID:" + module_imgids[i]);
        }
    }
    var obj_action = activeControls.Get("action");
    obj_action.SetText(module_action);

};

function CreateNewAdvInfo() {
    var obj = activeControls.Get("alladv_list");
    var module_name_value = obj.ActionGetActiveItem();
    obj = activeControls.Get("activeimage_list");
    var module_imgid_value = obj.GetValue();
    obj = activeControls.Get("action");
    var module_action_value = obj.GetText();
    obj = activeControls.Get("page_list");
    var module_page_value = obj.GetText();
    if (module_page_value == "") {
        messageBox.ActionDisplay('提示', '无法获取模块配置页信息，请先加载模块配置。');
        return false;
    }  
    var netobj = new Commons_NetService();
    netobj.NonAsyGetRemoteStringWithPost('Actions/Action_SuCreateNewADVImg.aspx', { module_name: module_name_value, module_imglist: module_imgid_value, module_actionurl: module_action_value, module_page: module_page_value }, 'xml', Callback_Response);
};

function LoadImages() {    
    var netobj = new Commons_NetService();
    netobj.NonAsyGetRemoteStringWithPost('Actions/Action_SysGetAllImagesIDList.aspx', { key: 'post' }, 'xml', Callback_LoadImages);
};

function Callback_LoadImages(data) {
    var rootNode = $(data).xpath("/root");
    var count = parseInt($(rootNode).attr("count"));
    var pageLabel = new Global_UIControls_Label();
    var pageLabelNode;
    var obj = activeControls.Get("image_list");
    if (count == 0) {
        obj.ActionInsetItem("图片库为空");
    }
    else {
        var items = $(rootNode).xpath("item");
        $(items).each(function () {
            var activeID = $(this).attr("id");
            obj.ActionInsetItem("Active Image ID:" + activeID);
        });       
    }
};

function delImgAction() {
    var obj = activeControls.Get("alladvsetting_list");
    var module_name_value = obj.ActionGetActiveItem();
    var netobj = new Commons_NetService();
    netobj.NonAsyGetRemoteStringWithPost('Actions/Action_SuDeleteAdvImg.aspx?name=' + module_name_value, { key: 'post' }, 'xml', Callback_Response);

};
