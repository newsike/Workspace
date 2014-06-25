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
        var obj = activeControls.Get("upimg_button");
        obj.ActionSetClick(summitAction);
        obj = activeControls.Get("newimg_button");
        obj.ActionSetClick(newimgAction);
        LoadImages();   
        isAddMethodToButton = true;
    }
};

function LoadImages() {    
    var netobj = new Commons_NetService();
    netobj.NonAsyGetRemoteStringWithPost('Actions/Action_SysGetAllImagesIDList.aspx', { key: 'post' }, 'xml', Callback_LoadImages);
};

function Callback_LoadImages(data) {
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
        imagesPage = parseInt(count / 32) + 1;
        var overCount = parseInt(count % 32);
        for (var i = 1; i <= imagesPage; i++) {
            var pageNode = pageLabel.CreateControl(mainFormNode, 'labelpage' + i, ((i - 1) * 20) + 344, '539', i, 'FontCss_ImgPage');
            $(pageNode).click(i,callDrawImageItems);
        }
        drawImageItems(1);
    }
};

function callDrawImageItems(data) {
    drawImageItems(data.data);
};

function drawImageItems(page) {
    if (page == 0)
        return;
    else {
        var min = page == 1 ? 1 : (page - 1) * 32 + 1;
        var max = page * 32;
        if (max > imagesCount)
            max = imagesCount;
        var activeIndex = 0;
        $("div").remove(".imgitems");
        for (var i = min; i <= max; i++) {
            var imageInfoNode = $(imageDoc).xpath("/root/item[@index=" + i + "]");
            var id = $(imageInfoNode).attr("id");
            var width = $(imageInfoNode).attr("width");
            var height = $(imageInfoNode).attr("height");
            var filename = $(imageInfoNode).attr("filename");
            imageItemNode = $("<div class='imgitems'></div>");
            imageItemNode.css("position", "absolute");
            imageItemNode.css("left", "300px");
            imageItemNode.css("top", ((activeIndex * 27) + 598) + "px");
            imageItemNode.css("z-index", 10000);
            imageItemNode.css("width", "900");
            mainFormNode.append(imageItemNode);
            var itemTableNode = $("<table border='0' cellpadding='0' cellspacing='4' width='900'></table>");            
            imageItemNode.append(itemTableNode);
            var trNode = $("<tr width='900'></tr>");
            itemTableNode.append(trNode);
            var idTDNpde = $("<td width='87' align='center' class='FontCss_ImgInfo'>" + id + "</td>");
            trNode.append(idTDNpde);
            var filenameTDNode = $("<td width='484' align='center' class='FontCss_ImgInfo'>" + filename + "</td>");
            trNode.append(filenameTDNode);
            var widthTDNode = $("<td width='90' align='center' class='FontCss_ImgInfo'>" + width + "</td>");
            trNode.append(widthTDNode);
            var heightTDNode = $("<td width='90' align='center' class='FontCss_ImgInfo'>" + height + "</td>");
            trNode.append(heightTDNode);
            var spaceTDNode = $("<td width='100' align='center' class='FontCss_ImgInfo'>　</td>");
            trNode.append(spaceTDNode);
            var url = "Actions/Action_SysGetImage.aspx?ImageID=" + id;
            var imgLinkTDNode = $("<td width='80' align='left' class='FontCss_ImgInfo'><a href='" + url + "'>查看图片</a></td>");
            trNode.append(imgLinkTDNode);
            var imgDelTDNode = $("<td width='80' align='left' class='FontCss_ImgInfo'>删除图片</td>");
            $(imgDelTDNode).click(id, delImgAction);
            trNode.append(imgDelTDNode);
            activeIndex++;
        }
        
    }
};

function delImgAction(data) {
    var netobj = new Commons_NetService();
    netobj.NonAsyGetRemoteStringWithPost('Actions/Action_SysDeleteImage.aspx?ImageID=' + data.data, { key: 'post' }, 'xml', callback_delImg);    
};

function callback_delImg(data) {
    LoadImages();
};

function newimgAction() {
    var obj = activeControls.Get("height_tb");
    obj.SetText('');
    obj = activeControls.Get("width_tb");
    obj.SetText('');
    obj = activeControls.Get("id_tb");
    obj.SetText('');
    obj = activeControls.Get("data_tb");
    obj.SetText('');
};

function summitAction() {
    var obj = activeControls.Get("height_tb");
    var heightvalue = obj.GetText();
    obj = activeControls.Get("width_tb");
    var widthvalue = obj.GetText();
    if (heightvalue == "" || widthvalue == "") {
        messageBox.ActionDisplay('提示', '请先输入图片的高度以及宽度。');
        return;
    }
    $.ajaxFileUpload({
        url: 'Actions/Action_SuImageUpload.aspx?width=' + widthvalue + '&height=' + heightvalue,
        secureuri: false,
        fileElementId: 'upload',
        dataType: 'xml',
        success: function (data, status) {
            messageBox.ActionDisplay('提示', '数据以及上载到远程服务器，如果浏览器没有刷新，请按F5.');
            obj = activeControls.Get("data_tb");
            obj.SetText('Data is ready.');
            window.location.reload();
        },
        error: function () {
            messageBox.ActionDisplay('提示', '上传数据失败，请检查网络或者文件.');
        }
    });
};