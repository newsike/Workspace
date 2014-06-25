$(document).ready(ScriptStart);
var isAddMethodToButton = false;
var imageDoc;
var imagesPage;
var imagesCount;
var imageItemNode;

function ScriptStart() {
    setTimeout(AddMethodToButton, 200);    
};

function AddMethodToButton() {
    if (activeControls.GetLength() > 0 && isAddMethodToButton == false) {
        var obj = activeControls.Get("addimg_button");
        obj.ActionSetClick(AddImgToList);
        obj = activeControls.Get("removeimg_button");
        obj.ActionSetClick(RemoveImgFromList);
        obj = activeControls.Get("upcorpinfo_button");
        obj.ActionSetClick(UpdateCorpInfo);
        obj = activeControls.Get("savecorpinfo_button");
        obj.ActionSetClick(CreateNewCorpInfo);
        obj = activeControls.Get("neworpinfo_button");
        obj.ActionSetClick(newimgAction);
        LoadImages();
        LoadCorpImfo();
        drawImageItems(1); 
        isAddMethodToButton = true;
    }
};

function AddImgToList() {
    var obj_imglist = activeControls.Get("img_list");
    var obj_activeimglist = activeControls.Get("activeimg_list");
    var text = obj_imglist.ActionGetActiveItem();    
    obj_activeimglist.ActionInsetItem(text);
};

function RemoveImgFromList() {
    var obj_activeimglist = activeControls.Get("activeimg_list");
    var text = obj_activeimglist.ActionGetActiveItem();
    obj_activeimglist.ActionRemoveItem(text);
};

function UpdateCorpInfo() {
    var obj = activeControls.Get("name");
    var namevalue = obj.GetText();
    obj = activeControls.Get("tel");
    var telvalue = obj.GetText();
    obj = activeControls.Get("address");
    var adressvalue = obj.GetText();
    obj = activeControls.Get("id");
    var idvalue = obj.GetText();
    if (idvalue == "") {
        messageBox.ActionDisplay('系统警告', '请先选择需要更新的数据后进行更新.');
        return false;
    }
    if (namevalue == "" || telvalue == "" || adressvalue == "") {
        messageBox.ActionDisplay('系统警告', '无法保存新数据，请检查*号字段是否为空.');
        return false;
    }
    obj = activeControls.Get("activeimg_list");
    var imgValue = obj.GetValue();
    obj = activeControls.Get("des");
    var desValue = obj.GetText();
    var netobj = new Commons_NetService();
    netobj.NonAsyGetRemoteStringWithPost('Actions/Action_SuUpdateCorp.aspx', { id: idvalue, name: namevalue, tel: telvalue, address: adressvalue, img: imgValue, des: desValue }, 'xml', Callback_Response);

};

function CreateNewCorpInfo() {
    var obj = activeControls.Get("name");
    var namevalue = obj.GetText();
    obj = activeControls.Get("tel");
    var telvalue = obj.GetText();
    obj = activeControls.Get("address");
    var adressvalue = obj.GetText();
    if (namevalue == "" || telvalue == "" || adressvalue == "") {
        messageBox.ActionDisplay('系统警告', '无法保存新数据，请检查*号字段是否为空.');
        return false;
    }
    obj = activeControls.Get("activeimg_list");
    var imgValue = obj.GetValue();
    obj = activeControls.Get("des");
    var desValue = obj.GetText();
    var netobj = new Commons_NetService();
    netobj.NonAsyGetRemoteStringWithPost('Actions/Action_SuCreateNewCorp.aspx', { name: namevalue, tel: telvalue, address: adressvalue, img: imgValue, des: desValue }, 'xml', Callback_Response);
};

function LoadImages() {    
    var netobj = new Commons_NetService();
    netobj.NonAsyGetRemoteStringWithPost('Actions/Action_SysGetAllImagesIDList.aspx', { key: 'post' }, 'xml', Callback_LoadImages);
};

function LoadCorpImfo() {
    var netobj = new Commons_NetService();
    netobj.NonAsyGetRemoteStringWithPost('Actions/Action_SuGetAllCorpList.aspx', { key: 'post' }, 'xml', Callback_LoadCorp);
};

function Callback_LoadCorp(data) {
    imageDoc = data;
    var rootNode = $(data).xpath("/root");
    var count = parseInt($(rootNode).attr("count"));
    imagesCount = count;
    var pageLabel = new Global_UIControls_Label();
    var pageLabelNode;
    if (count == 0) {
        pageLabel.CreateControl(mainFormNode, 'labelpage0', '344', '534', '0', 'FontCss_ImgPage');
    }
    else {
        imagesPage = parseInt(count / 24) + 1;
        var overCount = parseInt(count % 24);
        for (var i = 1; i <= imagesPage; i++) {
            var pageNode = pageLabel.CreateControl(mainFormNode, 'labelpage' + i, ((i - 1) * 20) + 344, '581', i, 'FontCss_ImgPage');
            $(pageNode).click(i, callDrawImageItems);
        }
    }
};

function Callback_LoadImages(data) {
    var rootNode = $(data).xpath("/root");
    var count = parseInt($(rootNode).attr("count"));
    var pageLabel = new Global_UIControls_Label();
    var pageLabelNode;
    var obj = activeControls.Get("img_list");
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

function callDrawImageItems(data) {
    drawImageItems(data.data);
};

function drawImageItems(page) {
    if (page == 0)
        return;
    else {
        var min = page == 1 ? 1 : (page - 1) * 24 + 1;
        var max = page * 24;
        if (max > imagesCount)
            max = imagesCount;
        var activeIndex = 0;
        $("div").remove(".imgitems");
        for (var i = min; i <= max; i++) {
            var imageInfoNode = $(imageDoc).xpath("/root/item[@index=" + i + "]");
            var id = $(imageInfoNode).attr("id");
            var width = $(imageInfoNode).attr("corp_tel");            
            var filename = $(imageInfoNode).attr("corp_name");
            imageItemNode = $("<div class='imgitems'></div>");
            imageItemNode.css("position", "absolute");
            imageItemNode.css("left", "300px");
            imageItemNode.css("top", ((activeIndex * 30) + 657) + "px");
            imageItemNode.css("z-index", 10000);
            imageItemNode.css("width", "900");
            mainFormNode.append(imageItemNode);
            var itemTableNode = $("<table border='0' cellpadding='0' cellspacing='0' width='900'></table>");            
            imageItemNode.append(itemTableNode);
            var trNode = $("<tr width='900'></tr>");
            itemTableNode.append(trNode);
            var idTDNpde = $("<td width='87' align='center' class='FontCss_ImgInfo'>" + id + "</td>");
            trNode.append(idTDNpde);
            var filenameTDNode = $("<td width='404' align='center' class='FontCss_ImgInfo'>" + filename + "</td>");
            trNode.append(filenameTDNode);
            var widthTDNode = $("<td width='177' align='left' class='FontCss_ImgInfo'>" + width + "</td>");
            trNode.append(widthTDNode);                                  
            var imgLinkTDNode = $("<td width='80' align='left' class='FontCss_ImgInfo'>选择</td>");
            trNode.append(imgLinkTDNode);
            imgLinkTDNode.click(id, choseItem);
            var imgDelTDNode = $("<td width='80' align='left' class='FontCss_ImgInfo'>删除</td>");
            $(imgDelTDNode).click(id, delImgAction);
            trNode.append(imgDelTDNode);
            activeIndex++;
        }
        
    }
};

function choseItem(data) {

    var item = $(imageDoc).xpath("/root/item[@id='" + data.data + "']");
    if (item != null) {
        var obj = activeControls.Get("name");
        obj.SetText($(item).attr("corp_name"));
        obj = activeControls.Get("id");
        obj.SetText($(item).attr("id"));
        obj = activeControls.Get("tel");
        obj.SetText($(item).attr("corp_tel"));
        obj = activeControls.Get("address");
        obj.SetText($(item).attr("corp_address"));
        obj = activeControls.Get("activeimg_list");
        obj.ActionClearAllItems();
        var corp_imglist = $(item).attr("corp_imglist");
        var corp_imglists = corp_imglist.split('|');
        for (var i = 0; i < corp_imglists.length; i++) {
            obj.ActionInsetItem(corp_imglists[i]);
        }    
    }   

};

function delImgAction(data) {
    var netobj = new Commons_NetService();
    netobj.NonAsyGetRemoteStringWithPost('Actions/Action_SuDeleteCorpInfo.aspx?ImageID=' + data.data, { key: 'post' }, 'xml', Callback_Response);
};

function newimgAction() {
    var obj = activeControls.Get("name");
    obj.SetText("");
    obj = activeControls.Get("id");
    obj.SetText("");
    obj = activeControls.Get("tel");
    obj.SetText("");
    obj = activeControls.Get("address");
    obj.SetText("");
    obj = activeControls.Get("activeimg_list");
    obj.ActionClearAllItems();
};