var mainForm = new Global_UIContainer();
var mainFormNode;
var activeForms = new Dirc();
var activeControls = new Dirc();
var messageBox;
var responseDoc;
var uiDoc;

$(document).ready(BLL_AutoStart);

function BLL_AutoStart() {
    var obj = new BLL_Start();
    obj.InitCommonUI();
};

function Callback_Response(data) {
    responseDoc = data;
    var rootNode = $(responseDoc).xpath('/root');
    if (rootNode != null) {
        var result = $(rootNode).attr("return");
        if (result == "false") {
            var msg = $(rootNode).attr("msg");
            if (msg != null && msg != undefined && msg != "")
                messageBox.ActionDisplay('系统信息', msg);
        }
        else if (result == "true") {
            var action = $(rootNode).attr("action");
            window.location = action;
        }
    }
};

function Callback_ErrorResponse() {
    window.location = 'sysdown.html';
};

function BLL_Start() {
    this.InitCommonUI = function () {
        var netObj = new Commons_NetService();
        netObj.AsyGetRemoteXML('Actions/InspriationWebUIConfig.xml', this.callback_UIXML);
    };

    this.callback_UIXML = function (xmldata) {
        uiDoc = xmldata;
        var formNodes = $(xmldata).xpath("/root/session[@type='form']");
        var activePage = commonHTTP.Get_ActiveURL();
        $(formNodes).each(function () {
            var mainformpanelname = $(this).attr("name");
            mainFormNode = mainForm.CreateMainPanelWithPosition(mainformpanelname, '', 1240, 1, 0, 0, '');
            mainForm.ActionMoveToContainerCenter($(document.body), mainFormNode);
            var childFormNodes = $(this).xpath("item[@type='childform']");
            var pagesnode = $(this).xpath("item[@type='templatepageconfig']");
            var TemplateGroupName = "";
            $(pagesnode).each(function () {
                var activePageNode = $(this).xpath("item[@page='" + activePage + "']");
                if (activePageNode.length > 0) {
                    TemplateGroupName = $(this).attr("name");
                }
            });
            var activeFormConfigs = $(this).xpath("item[@type='childform']");
            if (activeFormConfigs != null) {
                var activeFormConfigs_activePages = $(this).xpath("item[@isTemplater='" + activePage + "']");
                var activeFormConfigs_templateGroup = $(this).xpath("item[@isTemplater='" + TemplateGroupName + "']");
                if (activeFormConfigs != null) {
                    childFormNodes = activeFormConfigs_activePages;
                }
                else if (activeFormConfigs_templateGroup != null) {
                    childFormNodes = activeFormConfigs_templateGroup;
                }
                else {
                    alert('Can not load system,please reset the system.');
                    return;
                }
            }
            var activeForm;
            var formname = $(childFormNodes[0]).attr("name");
            var formimage = $(childFormNodes[0]).attr("formimage");
            var width = $(childFormNodes[0]).attr("width");
            var height = $(childFormNodes[0]).attr("height");
            var css = $(childFormNodes[0]).attr("css");
            var positionX = $(childFormNodes[0]).attr("positionX");
            var positionY = $(childFormNodes[0]).attr("positionY");
            var isCenter = $(childFormNodes[0]).attr("isCenter");
            var isMiddle = $(childFormNodes[0]).attr("isMiddle");
            var isTemplater = $(childFormNodes[0]).attr("isTemplater");
            var isCheckedlogin = $(childFormNodes[0]).attr("isCheckLogined");
            var CheckURL = $(childFormNodes[0]).attr("CheckURL");
            if (isTemplater == TemplateGroupName || isTemplater == activePage) {
                if (isCheckedlogin == "1") {
                    $.ajax({
                        url: CheckURL,
                        data: { key: 'test' },
                        cache: false,
                        async: false,
                        type: 'POST',
                        dataType: 'xml',
                        success: Callback_Response,
                        error: Callback_ErrorResponse
                    });

                }
            }
            activeForm = mainForm.CreateChildPanel(formname, mainFormNode, css, formimage, width, height, positionX, positionY);
            activeControls.Add(formname, activeForm);
            messageBox = new Global_UIControls_AlertBox();
            messageBox.CreateControl(activeForm, '', 'FontCss_AlertLabel', '');
            if (isCenter == "1") {
                mainForm.ActionMoveToContainerCenter(mainFormNode, activeForm);
            }
            if (isMiddle == "1") {
                mainForm.ActionMoveToContainerMiddle(mainFormNode, activeForm);
            }
            var controls = $(xmldata).xpath("/root/session[@type='form']/item/item");
            $(controls).each(function () {
                var control_name = $(this).attr("name");
                var control_type = $(this).attr("control");
                var control_width = $(this).attr("width");
                var control_height = $(this).attr("height");
                var control_positionX = $(this).attr("positionX");
                var control_positionY = $(this).attr("positionY");
                var control_css = $(this).attr("css");
                var control_label = $(this).attr("label");
                var control_imgsrc = $(this).attr("imgsrc");
                var control_isTemplater = $(this).attr("isTemplater");
                var control_borderwidth = $(this).attr("bordrtwidth");
                var control_bordercolor = $(this).attr("bordercolor");
                var control_tipwidth = $(this).attr("tipwidth");
                var control_tipheight = $(this).attr("tipheight");
                var control_url = $(this).attr("url");
                var control_dynamic = $(this).attr("dynamic");
                var control_dynamicAttrs = $(this).attr("dynamicAttrs");
                if (control_isTemplater == TemplateGroupName || control_isTemplater == activePage) {
                    if (control_dynamic != undefined && control_dynamic != null) {
                        if (control_dynamic != "") {
                            var Dynamic_Obj = new Common_Dynamics();
                            Dynamic_Obj.SetIemAttrName(control_dynamicAttrs);
                            Dynamic_Obj.CreateDynamicUpdate(control_dynamic, $(this));
                        }
                    }
                    if (control_type == "button" || control_type == "Button") {
                        var dynamicControl_Button = new Global_UIControls_Button();
                        dynamicControl_Button.CreateControl(activeForm, control_name, control_css, control_width, control_height, control_borderwidth, control_bordercolor, control_positionX, control_positionY, control_label);
                        activeControls.Add(control_name, dynamicControl_Button);
                    }
                    else if (control_type == "label" || control_type == "Label") {
                        var dynamicControl_Label = new Global_UIControls_Label();
                        dynamicControl_Label.CreateControl(activeForm, control_name, control_positionX, control_positionY, control_label, control_css);
                        activeControls.Add(control_name, dynamicControl_Label);
                    }
                    else if (control_type == "textbox" || control_type == "Textbox") {
                        var dynamicControl_Textbox = new Global_UIControls_TextBox();
                        dynamicControl_Textbox.CreateControl(activeForm, control_name, control_css, control_width, control_height, control_borderwidth, control_bordercolor, control_positionX, control_positionY, control_label);
                        activeControls.Add(control_name, dynamicControl_Textbox);
                    }
                    else if (control_type == "password" || control_type == "Password") {
                        var dynamicControl_Password = new Global_UIControls_Password();
                        dynamicControl_Password.CreateControl(activeForm, control_name, control_css, control_width, control_height, control_borderwidth, control_bordercolor, control_positionX, control_positionY, control_label);
                        activeControls.Add(control_name, dynamicControl_Password);
                    }
                    else if (control_type == "tipimage" || control_type == "TipImage") {
                        //var dynamicControl_tipimage = new Global_UIControls_TipImage();
                        //dynamicControl_tipimage.CreateControl(activeForm, control_name, control_css, control_width, control_height, control_borderwidth, control_bordercolor, control_positionX, control_positionY, control_label,);
                        //activeControls.Add(control_name, dynamicControl_tipimage);
                    }
                    else if (control_type == "linklabel" || control_type == "LinkLabel") {
                        var dynamicControl_linklabel = new Global_UIControls_LinkLabel();
                        dynamicControl_linklabel.CreateControl(activeForm, control_name, control_positionX, control_positionY, control_label, control_url, control_css);
                        activeControls.Add(control_name, dynamicControl_linklabel);
                    }
                    else if (control_type == "image" || control_type == "Image") {
                        var dynamicControl_image = new Global_UIControls_Image();
                        dynamicControl_image.CreateControl(activeForm, control_name, control_width, control_height, control_positionX, control_positionY, control_imgsrc, control_url, control_css, null);
                        activeControls.Add(control_name, dynamicControl_image);
                    }
                    else if (control_type == "combox" || control_type == "Combox") {
                        var dynamicControl_combox = new Global_UIControls_Select();
                        var items = $(this).xpath("item");
                        $(items).each(function () {
                            var value = $(this).attr("value");
                            dynamicControl_combox.InsertItem(value);
                        });
                        dynamicControl_combox.CreateControl(activeForm, control_name, control_positionX, control_positionY);
                        activeControls.Add(control_name, dynamicControl_combox);
                    }
                    else if (control_type == "ADV") {
                        var dynamicControl_ADV = new Global_UIControls_ADV();
                        var ADVITEMS = $(this).xpath("adv");
                        $(ADVITEMS).each(function () {
                            var advitem_name = $(this).attr("name");
                            var advitem_img = $(this).attr("img");
                            var advitem_action = $(this).attr("action");
                            dynamicControl_ADV.InsertAdv(advitem_name, advitem_img, advitem_name);
                        });
                        dynamicControl_ADV.CreateControl(activeForm, control_name, control_css, control_width, control_height, control_borderwidth, control_bordercolor, control_positionX, control_positionY);
                    }
                    else if (control_type == "MainMenu") {
                        var mainMenu = new Global_UIControls_Menu();
                        var mainmenuNodes = $(this).xpath("mainmenu");
                        $(mainmenuNodes).each(function () {
                            var mainmenu_name = $(this).attr("name");
                            var mainmenu_backimg = $(this).attr("backimg");
                            var mainmenu_overimg = $(this).attr("overimg");
                            var mainmenu_label = $(this).attr("label");
                            var mainmenu_actionurl = $(this).attr("actionurl");
                            var mainmenu_style = $(this).attr("style");
                            var mainmenu_width = $(this).attr("width");
                            var mainmenu_height = $(this).attr("height");
                            var mainmenu_css = $(this).attr("css");
                            var mainmenu_item = mainMenu.Create_MenuItems(mainmenu_name, mainmenu_style, '', mainmenu_label, mainmenu_actionurl, '', mainmenu_backimg, mainmenu_overimg, mainmenu_css, mainmenu_width, mainmenu_height, '');
                            mainMenu.Insert_MainMenu(mainmenu_item);
                            var childMenuNodes = $(this).xpath("childmenu");
                            $(childMenuNodes).each(function () {
                                var childmenu_name = $(this).attr("name");
                                var childmenu_label = $(this).attr("label");
                                var childmenu_url = $(this).attr("actionurl");
                                var childmenu_css = $(this).attr("css");
                                var childmenu_item = mainMenu.Create_MenuItems(childmenu_name, '3', '', childmenu_label, childmenu_url, '', '', '', childmenu_css, 0, 0, '');
                                mainMenu.Insert_ChildMenu(mainmenu_item, childmenu_item);
                            });
                            var childMenuADVNodes = $(this).xpath("adv");
                            $(childMenuADVNodes).each(function () {
                                var childMenuADV_Name = $(this).attr("name");
                                var childMenuADV_Height = $(this).attr("height");
                                var childMenuADV_Img = $(this).attr("img");
                                var childMenuADV_Url = $(this).attr("url");
                                mainMenu.Insert_ChildADV(childMenuADV_Name, childMenuADV_Height, childMenuADV_Img, childMenuADV_Url);
                            });
                        });
                        mainMenu.CreateControl(activeForm, control_name, '0', control_bordercolor, control_positionX, control_positionY);
                    }
                }
            });

        });
    };
};

