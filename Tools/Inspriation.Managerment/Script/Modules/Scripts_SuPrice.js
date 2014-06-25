$(document).ready(ScriptStart);
var isAddMethodToButton = false;
var searchDoc;
var searchOutDoc;
var selectItemID;
var pagesList = new Dirc();

function ScriptStart() {
    setTimeout(AddMethodToButton, 200);    
};

function AddMethodToButton() {
    if (activeControls.GetLength() > 0 && isAddMethodToButton == false) {
        var obj = activeControls.Get("getinfo_button");
        obj.ActionSetClick(LoadProPrice);
        obj = activeControls.Get("rmimg_button");
        obj.ActionSetClick(RemoveImgFromList);
        obj = activeControls.Get("newinfo_button");
        obj.ActionSetClick(NewProduct);
        obj = activeControls.Get("addoper_button");
        obj.ActionSetClick(AddCondition);
        obj = activeControls.Get("saveinfo_button");
        obj.ActionSetClick(ActionNewProduct);   
        obj = activeControls.Get("rmoper_button");
        obj.ActionSetClick(RemoveSearchFromList);
        obj = activeControls.Get("search_button");
        obj.ActionSetClick(StartSearch);
        obj = activeControls.Get("updateinfo_button");
        obj.ActionSetClick(ActionUpdateProduct);          
        LoadCorpImfo();
        LoadImages();
        LoadTypes();
        LoadOpers();
        LoadStatus();
        GetSearchDoc('all');
        if (searchDoc != null) {
            GetSearch(searchDoc);                        
        }
        isAddMethodToButton = true;
    }
};

function LoadProPrice() {
    var obj = activeControls.Get("id");
    var key = obj.GetText();
    if (key == "") {
        messageBox.ActionDisplay('提示', '产品编号不可为空，请先访问产品信息获取产品编号。');
        return false;
    }
    else {
        GetKeyDoc(key);
    }
};

function GetKeyDoc(keyid) {
    var netobj = new Commons_NetService();    
    netobj.NonAsyGetRemoteStringWithPost('Actions/Action_SysGetPrice.aspx', { keyid: keyid }, 'xml', Callback_SearchPrice);
};

function Callback_SearchPrice(data) {
    var itemNode = $(data).xpath("/root/item[@index=1]");
    var name = $(imageInfoNode).attr("item_name");
    var obj = activeControls.Get("productname");
    obj.SetText(name);
};

function RemoveSearchFromList() {
    var obj_activeimglist = activeControls.Get("sear_list");
    var text = obj_activeimglist.ActionGetActiveItem();
    obj_activeimglist.ActionRemoveItem(text);
};

function StartSearch() {
    var obj = activeControls.Get("searchkey");
    var key = obj.GetText();
    if (key == "")
        GetSearchDoc('all');
    else {
        var activeKey = "attrs:" + key;
        GetSearchDoc(activeKey);
    }
    if (searchDoc != null) {
        GetSearch(searchDoc);
    }
};

function GetSearchDoc(condition) {
    var netobj = new Commons_NetService();    
    netobj.NonAsyGetRemoteStringWithPost('Actions/Action_SysGetSearchDoc.aspx', { conditional: condition }, 'text', Search);
};

function Search(data) {   
    searchDoc = data;    
};

function GetSearch(doc) {
    var netobj = new Commons_NetService();
    var postValue = netobj.HtmlEncode(doc);
    netobj.NonAsyGetRemoteStringWithPost('Actions/Action_SysGetSearchOut.aspx', { condition: postValue }, 'xml', Callback_SearchOut);
};

function Callback_SearchOut(data) {
    searchOutDoc = data;
    var rootNode = $(data).xpath("/root");
    var count = parseInt($(rootNode).attr("count"));
    var pageLabel = new Global_UIControls_Label();
    var pageLabelNode;
    if (pagesList.GetLength() > 0) {
        for (var activeIndex = 1; activeIndex <= pagesList.GetLength(); activeIndex++) {
            var ActivePageControl = pagesList.Get(activeIndex);
            ActivePageControl.ActionSetText("");
            ActivePageControl = null;
        }
        pagesList = new Dirc();
    }
    if (count == 0) {        
        pageLabel.CreateControl(mainFormNode, 'labelpage0', '83', '740', '0', 'FontCss_ImgPage');
        pagesList.Add(1, pageLabel);
        drawProductItems(0);
    }
    else {
        imagesPage = parseInt(count / 28) + 1;
        var overCount = parseInt(count % 28);
        for (var i = 1; i <= imagesPage; i++) {
            var pageLabel = new Global_UIControls_Label();
            var pageNode = pageLabel.CreateControl(mainFormNode, 'labelpage' + i, ((i - 1) * 20) + 83, '740', i, 'FontCss_ImgPage');
            pagesList.Add(i, pageLabel);
            $(pageNode).click(i, callDrawProductItems);
        }
        drawProductItems(1);
    }
};

function callDrawProductItems(data) {
    drawProductItems(data.data);
};

function drawProductItems(page) {
    $("div").remove(".imgitems");
    if (page == 0)
        return;
    else {
        var rootNode = $(searchOutDoc).xpath("/root");
        var imagesCount = parseInt($(rootNode).attr("count"));
        var min = page == 1 ? 1 : (page - 1) * 28 + 1;
        var max = page * 28;
        if (max > imagesCount)
            max = imagesCount;
        var activeIndex = 0;        
        if (imagesCount > 0) {
            for (var i = min; i <= max; i++) {
                var imageInfoNode = $(searchOutDoc).xpath("/root/item[@index=" + i + "]");
                var id = $(imageInfoNode).attr("id");
                var isbn = $(imageInfoNode).attr("item_isbn");
                var name = $(imageInfoNode).attr("item_name");
                var count = $(imageInfoNode).attr("item_count");
                var status = $(imageInfoNode).attr("item_status");
                imageItemNode = $("<div class='imgitems'></div>");
                imageItemNode.css("position", "absolute");
                imageItemNode.css("left", "30px");
                imageItemNode.css("top", ((activeIndex * 27) + 800) + "px");
                imageItemNode.css("z-index", 10000);
                imageItemNode.css("width", "900");
                mainFormNode.append(imageItemNode);
                var itemTableNode = $("<table border='0' cellpadding='4' cellspacing='0' width='1191'></table>");
                imageItemNode.append(itemTableNode);
                var trNode = $("<tr width='1191'></tr>");
                itemTableNode.append(trNode);
                var idTDNpde = $("<td width='185' align='center' class='FontCss_ImgInfo'>" + isbn + "</td>");
                trNode.append(idTDNpde);
                var filenameTDNode = $("<td width='530' align='center' class='FontCss_ImgInfo'>" + name + "</td>");
                trNode.append(filenameTDNode);
                var filenameTDNode = $("<td width='90' align='center' class='FontCss_ImgInfo'>保密</td>");
                trNode.append(filenameTDNode);
                var widthTDNode = $("<td width='90' align='center' class='FontCss_ImgInfo'>" + count + "</td>");
                trNode.append(widthTDNode);
                var statusTDNode = $("<td width='90' align='center' class='FontCss_ImgInfo'>" + status + "</td>");
                trNode.append(statusTDNode);
                var imgLinkTDNode = $("<td width='110' align='center' class='FontCss_ImgInfo'>选择</td>");
                trNode.append(imgLinkTDNode);
                imgLinkTDNode.click(id, choseActiveItem);
                var imgDelTDNode = $("<td width='110' align='center' class='FontCss_ImgInfo'>删除</td>");
                //$(imgDelTDNode).click(id, delImgAction);
                trNode.append(imgDelTDNode);
                activeIndex++;
            }
        }
    }
};



function NewProduct() {
    var obj_activeimglist = activeControls.Get("activeimg_list");
    obj_activeimglist.ActionClearAllItems();
    var obj = activeControls.Get("name");
    obj.SetText("");
    obj = activeControls.Get("price");
    obj.SetText("");
    obj = activeControls.Get("count");
    obj.SetText("");
    obj = activeControls.Get("id");
    obj.SetText("");
    obj = activeControls.Get("weight");
    obj.SetText("");
    obj = activeControls.Get("sear_list");
    obj.ActionClearAllItems();
};

function AddCondition() {
    var obj_TypeA = activeControls.Get("typeA_list");
    var valueA = obj_TypeA.ActionGetActiveItem();
    var obj_TypeB = activeControls.Get("typeB_list");
    var valueB = obj_TypeB.ActionGetActiveItem();
    var obj_Oper = activeControls.Get("oper_list");
    var valueOper = obj_Oper.ActionGetActiveItem();
    var obj_Condition = activeControls.Get("sear_list");
    obj_Condition.ActionInsetItem(valueA + ":" + valueOper + ":" + valueB);
};

function ActionNewProduct() {
    var obj_activeimglist = activeControls.Get("activeimg_list");
    var value_imgList = obj_activeimglist.GetValue();
    var obj = activeControls.Get("name");
    var value_name = obj.GetText();
    obj = activeControls.Get("price");
    var value_price = obj.GetText();
    obj = activeControls.Get("count");
    var value_count = obj.GetText();
    obj = activeControls.Get("id");
    var value_id = obj.GetText();
    obj = activeControls.Get("weight");
    var value_weight = obj.GetText();
    obj = activeControls.Get("sear_list");
    var value_searList = obj.GetValue();
    obj = activeControls.Get("corp_list");
    var value_corp = obj.ActionGetActiveItem();
    obj = activeControls.Get("status");
    var value_status = obj.ActionGetActiveItem();
    if (value_name == "") {
        messageBox.ActionDisplay('提示', '无法获取新添加产品的名称，请先填写名称。');
        return false;
    }
    var netobj = new Commons_NetService();
    netobj.NonAsyGetRemoteStringWithPost('Actions/Action_SuCreateNewProduct.aspx', { name: value_name, price: value_price, count: value_count, id: value_id, weight: value_weight, corp: value_corp, img: value_imgList, typecondition: value_searList, status: value_status }, 'xml', Callback_Response);
};

function ActionUpdateProduct() {
    if (selectItemID != "") {
        var obj_activeimglist = activeControls.Get("activeimg_list");
        var value_imgList = obj_activeimglist.GetValue();
        var obj = activeControls.Get("name");
        var value_name = obj.GetText();
        obj = activeControls.Get("price");
        var value_price = obj.GetText();
        obj = activeControls.Get("count");
        var value_count = obj.GetText();
        obj = activeControls.Get("id");
        var value_id = obj.GetText();
        obj = activeControls.Get("weight");
        var value_weight = obj.GetText();
        obj = activeControls.Get("sear_list");
        var value_searList = obj.GetValue();
        obj = activeControls.Get("corp_list");
        var value_corp = obj.ActionGetActiveItem();
        obj = activeControls.Get("status");
        var value_status = obj.ActionGetActiveItem();
        if (value_name == "") {
            messageBox.ActionDisplay('提示', '无法获取新添加产品的名称，请先填写名称。');
            return false;
        }
        var netobj = new Commons_NetService();
        netobj.NonAsyGetRemoteStringWithPost('Actions/Action_SuUpdateProduct.aspx', { name: value_name, price: value_price, count: value_count, id: value_id, weight: value_weight, corp: value_corp, img: value_imgList, typecondition: value_searList, status: value_status }, 'xml', Callback_Response);
    }
    else {
        messageBox.ActionDisplay('提示', '无法更新产品的信息，请先选择需要更新的产品。');
        return false;
    }
};

function RemoveImgFromList() {
    var obj_activeimglist = activeControls.Get("activeimg_list");
    var text = obj_activeimglist.ActionGetActiveItem();
    obj_activeimglist.ActionRemoveItem(text);
};

function AddImg() {
    var obj_imglist = activeControls.Get("img_list");
    var obj_activeimglist = activeControls.Get("activeimg_list");
    var text = obj_imglist.ActionGetActiveItem();
    obj_activeimglist.ActionInsetItem(text);
};

function LoadStatus() {
    var obj = activeControls.Get("status");
    obj.ActionClearAllItems();
    obj.ActionInsetItem("正常销售");
    obj.ActionInsetItem("已经下架");
    obj.ActionInsetItem("暂不销售");
    obj.ActionInsetItem("需要预定");
};

function LoadCorpImfo() {
    var netobj = new Commons_NetService();
    netobj.NonAsyGetRemoteStringWithPost('Actions/Action_SuGetAllCorpList.aspx', { key: 'post' }, 'xml', Callback_LoadCorp);
};

function Callback_LoadCorp(data) {
    imageDoc = data;
    var rootNode = $(data).xpath("/root");
    var items = $(rootNode).xpath("item");
    var obj = activeControls.Get("corp_list");
    obj.ActionClearAllItems();
    $(items).each(function () {
        var id_value = $(this).attr("id");
        var name_value = $(this).attr("corp_name");
        obj.ActionInsetItem(id_value + "|" + name_value);
    });
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

function LoadTypes() {
    var netobj = new Commons_NetService();
    netobj.NonAsyGetRemoteStringWithPost('Actions/Action_SuGetAllTypeList.aspx', { key: 'post' }, 'xml', Callback_LoadTypes);
};

function Callback_LoadTypes(data) {
    var obj = activeControls.Get("typeA_list");
    obj.ActionClearAllItems();
    var obj2 = activeControls.Get("typeB_list");
    obj2.ActionClearAllItems();
    typeDoc = data;
    var rootNode = $(data).xpath("/root");
    var items = $(rootNode).xpath("item");
    $(items).each(function () {
        var activeID = $(this).attr("type_name");
        obj.ActionInsetItem(activeID);
        obj2.ActionInsetItem(activeID);
    });
};

function LoadOpers() {
    var obj = activeControls.Get("oper_list");
    obj.ActionClearAllItems();
    obj.ActionInsetItem("and");
    obj.ActionInsetItem("or");
};


function delImgAction() {
    var obj = activeControls.Get("alladvsetting_list");
    var module_name_value = obj.ActionGetActiveItem();
    var netobj = new Commons_NetService();
    netobj.NonAsyGetRemoteStringWithPost('Actions/Action_SuDeleteAdvImg.aspx?name=' + module_name_value, { key: 'post' }, 'xml', Callback_Response);

};

function choseActiveItem(i) {    
    var itemInfoNode = $(searchOutDoc).xpath("/root/item[@id=" + i.data + "]");
    var id = $(itemInfoNode).attr("id");
    var isbn = $(itemInfoNode).attr("item_isbn");
    var name = $(itemInfoNode).attr("item_name");
    var count = $(itemInfoNode).attr("item_count");
    var status = $(itemInfoNode).attr("item_status");
    var weight = $(itemInfoNode).attr("item_weight");
    var corplist = $(itemInfoNode).attr("item_corplist");    

    var obj_activeimglist = activeControls.Get("activeimg_list");
    obj_activeimglist.ActionClearAllItems();
    var obj = activeControls.Get("name");
    obj.SetText(name);
    obj = activeControls.Get("price");
    obj.SetText("请使用价格系统查验");
    obj = activeControls.Get("count");
    obj.SetText(count);
    obj = activeControls.Get("id");
    obj.SetText(isbn);
    obj = activeControls.Get("weight");
    obj.SetText(weight);
    obj = activeControls.Get("sear_list");
    obj.ActionClearAllItems();
};
