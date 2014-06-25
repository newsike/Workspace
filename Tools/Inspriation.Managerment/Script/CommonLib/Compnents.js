function Global_UIContainer() {
    this.CreateMainPanelWithPosition = function (PanelName, OptionalCssName, Width, Height, PositionX, PositionY, OptionalBackImage) {
        if (PanelName == "")
            return null;
        else {
            var newPanel = $("<div></div>");
            newPanel.attr("id", PanelName);
            if (OptionalCssName != "")
                newPanel.addClass(OptionalCssName);
            else {
                newPanel.css("width", Width.toString() + "px");
                newPanel.css("height", Height.toString() + "px");
                newPanel.css("position", "absolute");
                newPanel.css("left", PositionX.toString() + "px");
                newPanel.css("top", PositionY.toString() + "px");
                if (OptionalBackImage != "")
                    newPanel.css("backgroundImage", OptionalBackImage);
                $(document.body).append(newPanel);
                return newPanel;
            }
        }
    };

    this.CreateMainPanelWithFullDocument = function (PanelName, OptionalBackImage) {
        if (PanelName == "")
            return null;
        else {
            var documentWidth = $(document.body).width();
            var documentHeight = $(document).scrollTop();
            var newPanel = $("<div></div>");
            newPanel.attr("id", PanelName);
            newPanel.css("width", documentWidth + "px");
            newPanel.css("height", documentHeight + "px");
            newPanel.css("position", "absolute");
            newPanel.css("left", "0px");
            newPanel.css("top", "0px");
            if (OptionalBackImage != "")
                newPanel.css("backgroundImage", OptionalBackImage);
            $(document.body).append(newPanel);
            return newPanel;
        }
    };

    this.CreateChildPanel = function (PanelName, ParentPanel, OptionalCssName, OptionalBackImage, Width, Height, PositionX, PositionY) {
        if (PanelName == "")
            return null;
        else {
            var newPanel = $("<div></div>");
            newPanel.attr("id", PanelName);
            newPanel.css("width", Width + "px");
            newPanel.css("height", Height + "px");
            newPanel.css("position", "absolute");
            newPanel.css("left", PositionX.toString() + "px");
            newPanel.css("top", PositionY.toString() + "px");
            if (OptionalCssName != "")
                newPanel.addClass(OptionalCssName);
            if (OptionalBackImage != "")
                newPanel.css("backgroundImage", OptionalBackImage);
            ParentPanel.append(newPanel);
            return newPanel;
        }
    };

    this.GetParentContainer = function (ControlName, ContainerName) {
        if (ControlName == "")
            return null;
        else {
            return $("." + ControlName).parent().parent("." + ContainerName);
        }
    };

    this.ActionMoveToContainerCenter = function (Container, Control) {
        if (Container == null)
            return false;
        var ContainerWidth = Container.width();
        var ControlWidth = Control.width();
        if (ControlWidth > ContainerWidth) {
            Control.css("left", "0px");
            return true;
        }
        else {
            var HalfControlWidth = ControlWidth / 2;
            var HalfContainerWidth = ContainerWidth / 2;
            var PositionFlag = HalfContainerWidth - HalfControlWidth;
            Control.css("left", PositionFlag.toString() + "px");
        }
    };

    this.ActionMoveToContainerMiddle = function (Container, Control) {
        if (Container == null)
            return false;
        var ContainerHeight = Container.height();
        var ControlHeight = Control.height();
        if (ControlHeight > ContainerHeight) {
            Control.css("top", "0px");
            return true;
        }
        else {
            var HalfControlHeight = ControlHeight / 2;
            var HalfContainerHeight = ContainerHeight / 2;
            var PositionFlag = HalfContainerHeight - HalfControlHeight;
            Control.css("top", PositionFlag.toString() + "px");
        }
    };

    this.ActionSetBackImage = function (Container, BackImage) {
        if (Container == null || BackImage == "")
            return false;
        else {
            Container.css("background-image", BackImage);
            return true;
        }
    };
};

function Global_UIControls_AlertBox() {
    var divNode;
    var herderText = new Global_UIControls_Label();
    var contentsNode = new Global_UIControls_Label();
    var uiContainer = new Global_UIContainer();


    this.CreateControl = function (Container, HeaderCssName, ContentCssName, BorderColor) {
        divNode = $("<div></div>");
        divNode.css("width", "600px");
        divNode.css("height", "120px");
        divNode.css("border-color", BorderColor);
        divNode.css("position", "absolute");
        divNode.css("backgroundImage", "url(Script/CommonLib/Images/Alert/Alert.png)");
        divNode.css("visibility", "hidden");
        divNode.css("z-index", "50000");
        var contentDomNode;
        Container.append(divNode);
        var headerNode = $("<div></div>");
        headerNode.css("width", "600px");
        headerNode.css("height", "20px");
        headerNode.css("font-size", "12px");
        divNode.append(headerNode);
        var contentNode = $("<div></div>");
        contentNode.css("width", "600px");
        contentNode.css("height", "100px");
        contentNode.css("position", "absolute");
        contentNode.css("top", "20px");
        contentNode.css("text-align", "center");
        divNode.append(contentNode);
        contentsNode.CreateControl(contentNode, "contentsText", 20, 20, "Content");        
        var OKButton = new Global_UIControls_Button();
        OKButton.CreateControl(contentNode, "OKButton", "", "80", "20", "1", "black", "250", "60", "OK");
        var thisObj = new Global_UIControls_AlertBox();
        OKButton.ActionSetClick(this.ActionDisplay);
        herderText.CreateControl(headerNode, "messageBoxHeader", 10, 8, "Alert Message");
        var tmpObj = new Global_UIContainer();
        tmpObj.ActionMoveToContainerCenter(Container, divNode);
        tmpObj.ActionMoveToContainerMiddle(Container, divNode);

    };

    this.ActionDisplay = function (Header, ActiveMessage) {
        if (divNode != null) {
            if (divNode.css("visibility") == "hidden")
                divNode.css("visibility", "visible");
            else
                divNode.css("visibility", "hidden");
        }
        if (Header != "")
            herderText.ActionSetText(Header);
        contentsNode.ActionSetText(ActiveMessage);
    };

};


function Global_UIControls_TextBox() {

    var inputNode;

    this.CreateControl = function (Container, Name, OptionalCss, Width, Height, BorderWidth, BorderColor, DefaultPositionX, DefaultPositionY, DefaultValue) {
        var divNode = $("<div></div>");
        divNode.css("position", "absolute");
        divNode.css("border-style", "none");
        divNode.css("z-index", "10000");
        inputNode = $("<input></input>");
        inputNode.attr("id", Name);
        inputNode.attr("type", "text");
        divNode.append(inputNode);
        if (DefaultValue != "") {
            inputNode.attr("value", DefaultValue);
        }
        if (OptionalCss != "") {
            inputNode.addClass(OptionalCss);
        }
        inputNode.css("width", Width);
        inputNode.css("height", Height);
        if (BorderWidth == 0)
            inputNode.css("border-style", "none");
        else
            inputNode.css("border-width", BorderWidth.toString() + "px");
        if (BorderColor != "")
            inputNode.css("border-color", BorderColor);
        divNode.css("left", DefaultPositionX + "px");
        divNode.css("top", DefaultPositionY + "px");
        if (Container != null)
            Container.append(divNode);
        else
            return divNode;
    };

    this.GetText = function () {
        if (inputNode != null)
            return inputNode.attr("value");
        else
            return "";
    };

    this.SetText = function (Text) {
        if (inputNode != null)
            inputNode.attr("value", Text);
    };

    this.ActionChangeBackColor = function (Color) {
        if (inputNode != null)
            inputNode.css("background-color", Color);
    };

    this.ActionDisplay = function () {
        if (inputNode != null) {
            if (inputNode.css("visibility") == "hidden")
                inputNode.css("visibility", "visible");
            else
                inputNode.css("visibility", "hidden");
        }
    };

    this.ActionEnabel = function () {
        if (inputNode != null) {
            if (inputNode.attr("disabled") == "true")
                inputNode.attr("disabled", "false");
            else
                inputNode.attr("disabled", "true");
        }
    };

    this.ActionChangeForeColor = function (Color) {
        if (inputNode != null) {
            inputNode.css("color", Color);
        }
    };

    this.ActionSetNewCss = function (CssName) {
        if (inputNode != null) {
            inputNode.addClass(CssName);
        }
    };

    this.ActionChangeWidth = function (NewWidth) {
        if (inputNode != null) {
            inputNode.css("width", NewWidth);
        }
    };

    this.ActionChangeHeight = function (NewHeight) {
        if (inputNode != null) {
            inputNode.css("height", NewHeight);
        }
    };

};

function Global_UIControls_File() {

    var inputNode;

    this.CreateControl = function (Container, Name, OptionalCss, Width, Height, BorderWidth, BorderColor, DefaultPositionX, DefaultPositionY, DefaultValue) {
        var divNode = $("<div></div>");
        divNode.css("position", "absolute");
        divNode.css("border-style", "none");
        divNode.css("z-index", "10000");
        inputNode = $("<input></input>");
        inputNode.attr("id", Name);
        inputNode.attr("name", Name);
        inputNode.attr("type", "file");
        divNode.append(inputNode);
        if (DefaultValue != "") {
            inputNode.attr("value", DefaultValue);
        }
        if (OptionalCss != "") {
            inputNode.addClass(OptionalCss);
        }
        inputNode.css("width", Width);
        inputNode.css("height", Height);
        if (BorderWidth == 0)
            inputNode.css("border-style", "none");
        else
            inputNode.css("border-width", BorderWidth.toString() + "px");
        if (BorderColor != "")
            inputNode.css("border-color", BorderColor);
        divNode.css("left", DefaultPositionX + "px");
        divNode.css("top", DefaultPositionY + "px");
        if (Container != null)
            Container.append(divNode);
        else
            return divNode;
    };

    this.GetText = function () {
        if (inputNode != null)
            return inputNode.attr("value");
        else
            return "";
    };

    this.SetText = function (Text) {
        if (inputNode != null)
            inputNode.attr("value", Text);
    };

    this.ActionChangeBackColor = function (Color) {
        if (inputNode != null)
            inputNode.css("background-color", Color);
    };

    this.ActionDisplay = function () {
        if (inputNode != null) {
            if (inputNode.css("visibility") == "hidden")
                inputNode.css("visibility", "visible");
            else
                inputNode.css("visibility", "hidden");
        }
    };

    this.ActionEnabel = function () {
        if (inputNode != null) {
            if (inputNode.attr("disabled") == "true")
                inputNode.attr("disabled", "false");
            else
                inputNode.attr("disabled", "true");
        }
    };

    this.ActionChangeForeColor = function (Color) {
        if (inputNode != null) {
            inputNode.css("color", Color);
        }
    };

    this.ActionSetNewCss = function (CssName) {
        if (inputNode != null) {
            inputNode.addClass(CssName);
        }
    };

    this.ActionChangeWidth = function (NewWidth) {
        if (inputNode != null) {
            inputNode.css("width", NewWidth);
        }
    };

    this.ActionChangeHeight = function (NewHeight) {
        if (inputNode != null) {
            inputNode.css("height", NewHeight);
        }
    };

};

function Global_UIControls_Button() {

    this.inputNode;

    this.CreateControl = function (Container, Name, OptionalCss, Width, Height, BorderWidth, BorderColor, DefaultPositionX, DefaultPositionY, DefaultValue) {
        var divNode = $("<div></div>");
        divNode.css("position", "absolute");
        divNode.css("border-style", "none");
        divNode.css("z-index", "10000");
        this.inputNode = $("<input></input>");
        this.inputNode.attr("id", Name);
        this.inputNode.attr("type", "button");
        divNode.append(this.inputNode);
        if (DefaultValue != "") {
            this.inputNode.attr("value", DefaultValue);
        }
        if (OptionalCss != "") {
            this.inputNode.addClass(OptionalCss);
        }
        this.inputNode.css("width", Width);
        this.inputNode.css("height", Height);
        if (BorderWidth == 0)
            this.inputNode.css("border-style", "none");
        else
            this.inputNode.css("border-width", BorderWidth.toString() + "px");
        if (BorderColor != "")
            this.inputNode.css("border-color", BorderColor);
        divNode.css("left", DefaultPositionX + "px");
        divNode.css("top", DefaultPositionY + "px");
        if (Container != null)
            Container.append(divNode);
        else
            return divNode;
    };

    this.GetText = function () {
        if (this.inputNode != null)
            return this.inputNode.attr("value");
        else
            return "";
    };

    this.SetText = function (Text) {
        if (this.inputNode != null)
            this.inputNode.attr("value", Text);
    };

    this.ActionChangeBackColor = function (Color) {
        if (this.inputNode != null)
            this.inputNode.css("background-color", Color);
    };

    this.ActionDisplay = function () {
        if (this.inputNode != null) {
            if (this.inputNode.css("visibility") == "hidden")
                this.inputNode.css("visibility", "visible");
            else
                this.inputNode.css("visibility", "hidden");
        }
    };

    this.ActionEnabel = function () {
        if (this.inputNode != null) {
            if (this.inputNode.attr("disabled") == "true")
                this.inputNode.attr("disabled", "false");
            else
                this.inputNode.attr("disabled", "true");
        }
    };

    this.ActionChangeForeColor = function (Color) {
        if (this.inputNode != null) {
            this.inputNode.css("color", Color);
        }
    };

    this.ActionSetNewCss = function (CssName) {
        if (this.inputNode != null) {
            this.inputNode.addClass(CssName);
        }
    };

    this.ActionChangeWidth = function (NewWidth) {
        if (this.inputNode != null) {
            this.inputNode.css("width", NewWidth);
        }
    };

    this.ActionChangeHeight = function (NewHeight) {
        if (this.inputNode != null) {
            this.inputNode.css("height", NewHeight);
        }
    };

    this.ActionSetClick = function (FunctionRef) {
        if (this.inputNode != null) {
            $(this.inputNode).click(FunctionRef);
        }
    };

};

function Global_UIControls_Password() {

    var inputNode;

    this.CreateControl = function (Container, Name, OptionalCss, Width, Height, BorderWidth, BorderColor, DefaultPositionX, DefaultPositionY, DefaultValue, MaxLength) {
        var divNode = $("<div></div>");
        divNode.css("position", "absolute");
        divNode.css("border-style", "none");
        divNode.css("z-index", "10000");
        inputNode = $("<input></input>");
        inputNode.attr("id", Name);
        inputNode.attr("type", "password");
        if (MaxLength != "")
            inputNode.attr("maxlength", MaxLength);
        divNode.append(inputNode);
        if (DefaultValue != "") {
            inputNode.attr("value", DefaultValue);
        }
        if (OptionalCss != "") {
            inputNode.addClass(OptionalCss);
        }
        inputNode.css("width", Width);
        inputNode.css("height", Height);
        if (BorderWidth == 0)
            inputNode.css("border-style", "none");
        else
            inputNode.css("border-width", BorderWidth.toString() + "px");
        if (BorderColor != "")
            inputNode.css("border-color", BorderColor);
        divNode.css("left", DefaultPositionX + "px");
        divNode.css("top", DefaultPositionY + "px");
        if (Container != null)
            Container.append(divNode);
        else
            return divNode;
    };

    this.GetText = function () {
        if (inputNode != null)
            return inputNode.attr("value");
        else
            return "";
    };

    this.SetText = function (Text) {
        if (inputNode != null)
            inputNode.attr("value", Text);
    };

    this.ActionChangeBackColor = function (Color) {
        if (inputNode != null)
            inputNode.css("background-color", Color);
    };

    this.ActionDisplay = function () {
        if (inputNode != null) {
            if (inputNode.css("visibility") == "hidden")
                inputNode.css("visibility", "visible");
            else
                inputNode.css("visibility", "hidden");
        }
    };

    this.ActionEnabel = function () {
        if (inputNode != null) {
            if (inputNode.attr("disabled") == "true")
                inputNode.attr("disabled", "false");
            else
                inputNode.attr("disabled", "true");
        }
    };

    this.ActionChangeForeColor = function (Color) {
        if (inputNode != null) {
            inputNode.css("color", Color);
        }
    };

    this.ActionSetNewCss = function (CssName) {
        if (inputNode != null) {
            inputNode.addClass(CssName);
        }
    };

    this.ActionChangeWidth = function (NewWidth) {
        if (inputNode != null) {
            inputNode.css("width", NewWidth);
        }
    };

    this.ActionChangeHeight = function (NewHeight) {
        if (inputNode != null) {
            inputNode.css("height", NewHeight);
        }
    };

};

function Global_UIControls_CheckBox() {

    var inputNode;

    this.CreateControl = function (Container, Name, OptionalCss, Width, Height, BorderWidth, BorderColor, DefaultPositionX, DefaultPositionY, DefaultValue) {
        var divNode = $("<div></div>");
        divNode.css("position", "absolute");
        divNode.css("border-style", "none");
        divNode.css("z-index", "10000");
        inputNode = $("<input></input>");
        inputNode.attr("id", Name);
        inputNode.attr("type", "checkbox");
        divNode.append(inputNode);
        if (DefaultValue != "") {
            inputNode.attr("value", DefaultValue);
        }
        if (OptionalCss != "") {
            inputNode.addClass(OptionalCss);
        }
        inputNode.css("width", Width);
        inputNode.css("height", Height);
        if (BorderWidth == 0)
            inputNode.css("border-style", "none");
        else
            inputNode.css("border-width", BorderWidth.toString() + "px");
        if (BorderColor != "")
            inputNode.css("border-color", BorderColor);
        divNode.css("left", DefaultPositionX + "px");
        divNode.css("top", DefaultPositionY + "px");
        if (Container != null)
            Container.append(divNode);
        else
            return divNode;
    };

    this.GetText = function () {
        if (inputNode != null)
            return inputNode.attr("value");
        else
            return "";
    };

    this.SetText = function (Text) {
        if (inputNode != null)
            inputNode.attr("value", Text);
    };

    this.ActionChangeBackColor = function (Color) {
        if (inputNode != null)
            inputNode.css("background-color", Color);
    };

    this.ActionDisplay = function () {
        if (inputNode != null) {
            if (inputNode.css("visibility") == "hidden")
                inputNode.css("visibility", "visible");
            else
                inputNode.css("visibility", "hidden");
        }
    };

    this.ActionEnabel = function () {
        if (inputNode != null) {
            if (inputNode.attr("disabled") == "true")
                inputNode.attr("disabled", "false");
            else
                inputNode.attr("disabled", "true");
        }
    };

    this.ActionChangeForeColor = function (Color) {
        if (inputNode != null) {
            inputNode.css("color", Color);
        }
    };

    this.ActionSetNewCss = function (CssName) {
        if (inputNode != null) {
            inputNode.addClass(CssName);
        }
    };

    this.ActionChangeWidth = function (NewWidth) {
        if (inputNode != null) {
            inputNode.css("width", NewWidth);
        }
    };

    this.ActionChangeHeight = function (NewHeight) {
        if (inputNode != null) {
            inputNode.css("height", NewHeight);
        }
    };

    this.ActionChecked = function () {
        if (inputNode != null) {
            return inputNode.attr("checked") == "1" ? true : false;            
        }
    };

};

function Global_UIControls_Label() {
    
    var spanNode;

    this.CreateControl = function (Container, Name, DefaultPositionX, DefaultPositionY, Text,Css) {
        spanNode = $("<span>" + Text + "</span>");
        spanNode.attr("id", Name);
        spanNode.css("position", "absolute");
        spanNode.css("left", DefaultPositionX + "px");
        spanNode.css("top", DefaultPositionY + "px");
        spanNode.addClass(Css);
        Container.append(spanNode);
        return spanNode;
    };

    this.ActionSetText = function (Text) {
        spanNode.html("<span>" + Text + "</span>");
    };

    this.ActionGetText = function () {
        return spanNode.text();
    };

    this.ActionChangeCss = function (CssName) {
        spanNode.addClass(CssName);
    };

};

function Global_UIControls_LinkLabel() {

    this.spanNode;

    this.CreateControl = function (Container, Name, DefaultPositionX, DefaultPositionY, Text, ActionURL, Css) {
        this.spanNode = $("<span><a href='" + ActionURL + "'>" + Text + "</a></span>");
        this.spanNode.attr("id", Name);
        this.spanNode.css("position", "absolute");
        this.spanNode.css("left", DefaultPositionX + "px");
        this.spanNode.css("top", DefaultPositionY + "px");
        this.spanNode.addClass(Css);
        Container.append(this.spanNode);
    };
};

function Global_UIControls_Image() {

    this.divNode;

    this.CreateControl = function (Container, Name, Width, Height, DefaultPositionX, DefaultPositionY, ImageURL, ActionURL, Css, ActionMethod) {
        this.divNode = $("<div></div>");
        this.divNode.attr("id", Name);
        this.divNode.css("position", "absolute");
        this.divNode.css("left", DefaultPositionX + "px");
        this.divNode.css("top", DefaultPositionY + "px");
        this.divNode.css("width", Width);
        this.divNode.css("height", Height);
        this.divNode.addClass(Css);
        var imgNode;
        if (ActionURL != "") {
            imgNode = $("<a href=" + ActionURL + "><img src=" + ImageURL + "></img></a>");
        }
        else {
            imgNode = $("<img src=" + ImageURL + "></img>");
        }
        if (ActionMethod != null) {
            $(imgNode).click(function () {
                ActionMethod();
            });
        }
        this.divNode.append(imgNode);
        Container.append(this.divNode);
        return this.divNode;
    };
};

function Global_UIControls_TipImage() {

    this.divNode;
    this.tipNode;

    this.CreateControl = function (Container, Name, Width, Height, DefaultPositionX, DefaultPositionY, ImageURL, ActionURL, Css, ActionMethod, TipWidth, TipHeight, FormNode) {
        this.divNode = $("<div></div>");
        var containerControl = new Global_UIContainer();
        this.tipNode = $("<div></div>");
        this.tipNode.css("visibility", "hide");
        this.tipNode.attr("id", "tip" + Name);
        this.tipNode.css("position", "absolute");
        this.tipNode.css("left", DefaultPositionX + "px");
        this.tipNode.css("top", DefaultPositionY + "px");
        this.tipNode.css("width", TipWidth);
        this.tipNode.css("height", TipHeight);
        this.tipNode.css("z-index", "20000");
        this.tipNode.css("backgroundImage", "url(" + ImageURL + ")");
        containerControl.ActionMoveToContainerCenter(FormNode, this.tipNode);
        containerControl.ActionMoveToContainerMiddle(FormNode, this.tipNode);
        this.divNode.attr("id", Name);
        this.divNode.css("position", "absolute");
        this.divNode.css("left", DefaultPositionX + "px");
        this.divNode.css("top", DefaultPositionY + "px");
        this.divNode.css("width", Width);
        this.divNode.css("height", Height);
        this.divNode.addClass(Css);
        var imgNode;
        if (ActionURL != "") {
            imgNode = $("<a href=" + ActionURL + "><img src=" + ImageURL + "></img></a>");
        }
        else {
            imgNode = $("<img src=" + ImageURL + "></img>");
        }
        if (ActionMethod != null) {
            $(imgNode).click(function () {
                ActionMethod();
            });
        }
        this.divNode.append(imgNode);
        Container.append(this.divNode);
        return this.divNode;
    };
};


function Private_Struct_UIControls_ADV() {

    this.ADV_Name;
    this.ADV_IMG;
    this.ADV_Url;

    this.Set_ADV_Name = function (name) {
        this.ADV_Name = name;
    };

    this.Get_ADV_Name = function () {
        return this.ADV_Name;
    };

    this.Set_ADV_IMG = function (img) {
        this.ADV_IMG = img;
    };

    this.Get_ADV_IMG = function () {
        return this.ADV_IMG;
    };

    this.Set_ADV_Url = function (url) {
        this.ADV_Url = url;
    };

    this.Get_ADV_Url = function () {
        return this.ADV_Url;
    };

};

function Global_UIControls_ADV() {

     var divNode;
     var advCount = 0;
     var advActiveIndex = 0;
     var advDircItems = new Dirc();
     var imgDivNode;
     var imgNode;

     this.Global_UIControls_ADV = function () {
         advDircItems = new Dirc();
     };

     this.InsertAdv = function (Name, Img, ActionUrl) {
         var newAdvItem = new Private_Struct_UIControls_ADV();
         newAdvItem.Set_ADV_Name(Name);
         newAdvItem.Set_ADV_IMG(Img);
         newAdvItem.Set_ADV_Url(ActionUrl);
         advCount = advCount + 1;
         advDircItems.Add(advCount, newAdvItem);
     };

     this.ActionFlush = function () {
         if (advCount > 1) {
             if (advActiveIndex < advCount) {
                 advActiveIndex = advActiveIndex + 1;
             }
             else {
                 advActiveIndex = 1;
             }
             var advItem = advDircItems.Get(advActiveIndex);
             $(imgDivNode).fadeOut(300);
             $(imgNode).attr("src", advItem.Get_ADV_IMG());
             $(imgDivNode).fadeIn(300);     
         }
     };

     this.CreateControl = function (Container, Name, OptionalCss, Width, Height, BorderWidth, BorderColor, DefaultPositionX, DefaultPositionY) {
         divNode = $("<div></div>");
         divNode.attr("id", Name);
         divNode.css("position", "absolute");
         divNode.css("border-style", "solid");
         divNode.css("border-width", BorderWidth.toString() + "px");
         divNode.css("border-color", BorderColor);
         divNode.css("width", Width);
         divNode.css("height", Height);
         divNode.css("left", DefaultPositionX + "px");
         divNode.css("top", DefaultPositionY + "px");
         divNode.css("visibility", "visible");         
         if (advCount > 0) {
             imgDivNode = $("<div></div>");
             if (advActiveIndex == 0) {
                 advActiveIndex = 1;
                 var advItem = advDircItems.Get(advActiveIndex);
                 imgDivNode.attr("id", "activeAdvItem");
                 imgDivNode.css("position", "absolute");
                 imgDivNode.css("width", (Width - 2) + "px");
                 imgDivNode.css("height", (Height - 2) + "px");
                 imgDivNode.css("top", "1px");
                 imgDivNode.css("left", "1px");                 
                 imgNode = $("<img src='" + advItem.Get_ADV_IMG() + "' width='" + (Width - 2) + "' height='" + (Height - 2) + "'></img>");
                 imgDivNode.append(imgNode);
                 $(imgDivNode).click(function () {
                     window.location.href = advItem.Get_ADV_Url();
                 });
                 divNode.append(imgDivNode);
             }
         }

         var arrangButtonLeft = $("<div></div>");
         arrangButtonLeft.css("position", "absolute");
         arrangButtonLeft.css("border-style", "solid");
         arrangButtonLeft.css("border-width", "1px");
         arrangButtonLeft.css("border-color", "white");
         arrangButtonLeft.css("width", "22px");
         arrangButtonLeft.css("height", (Height - 2) + "px");
         arrangButtonLeft.css("left", "0px");
         arrangButtonLeft.css("top", "0px");
         arrangButtonLeft.css("background-color", "#CACAD9");
         $(arrangButtonLeft).mouseover(function () {
             $(arrangButtonLeft).css("background-color", "#A8A8B7");
             $(arrangButtonLeft).css("cursor", "hand");
         });
         $(arrangButtonLeft).mouseout(function () {
             $(arrangButtonLeft).css("background-color", "#CACAD9");
         });
         $(arrangButtonLeft).click(function () {
             if (advCount > 0 && advActiveIndex > 1) {
                 advActiveIndex = advActiveIndex - 1;
                 var advItem = advDircItems.Get(advActiveIndex);
                 $(imgDivNode).fadeIn(300);
                 $(imgNode).attr("src", advItem.Get_ADV_IMG());
                 $(imgDivNode).fadeIn(300);
             }
         });
         var arrangeImageLeft = $("<img src='BaseScripts/CommonLib/Images/Adv/arrangeLeft.fw.png' />");
         arrangeImageLeft.css("position", "absolute");
         arrangeImageLeft.css("top", (Height / 2 - 10) + "px");
         arrangeImageLeft.css("left", "1px");
         arrangButtonLeft.append(arrangeImageLeft);
         divNode.append(arrangButtonLeft);
         var arrangButtonRight = $("<div></div>");
         arrangButtonRight.css("position", "absolute");
         arrangButtonRight.css("border-style", "solid");
         arrangButtonRight.css("border-width", "1px");
         arrangButtonRight.css("border-color", "white");
         arrangButtonRight.css("width", "22px");
         arrangButtonRight.css("height", (Height - 2) + "px");
         arrangButtonRight.css("left", (Width - 22 - 2) + "px");
         arrangButtonRight.css("top", "0px");
         arrangButtonRight.css("background-color", "#CACAD9");
         $(arrangButtonRight).mouseover(function () {
             $(arrangButtonRight).css("background-color", "#A8A8B7");
             $(arrangButtonRight).css("cursor", "hand");
         });
         $(arrangButtonRight).mouseout(function () {
             $(arrangButtonRight).css("background-color", "#CACAD9");
         });
         $(arrangButtonRight).click(function () {
             if (advActiveIndex < advCount) {
                 advActiveIndex = advActiveIndex + 1;
                 var advItem = advDircItems.Get(advActiveIndex);
                 $(imgDivNode).fadeOut(300);
                 $(imgNode).attr("src", advItem.Get_ADV_IMG());
                 $(imgDivNode).fadeIn(300);
             }
         });
         var arrangeImageRight = $("<img src='BaseScripts/CommonLib/Images/Adv/arrangeRight.fw.png' />");
         arrangeImageRight.css("position", "absolute");
         arrangeImageRight.css("top", (Height / 2 - 10) + "px");
         arrangeImageRight.css("left", "1px");
         arrangButtonRight.append(arrangeImageRight);
         divNode.append(arrangButtonRight);
         setInterval(this.ActionFlush, 5000);
         if (Container != null)
             Container.append(divNode);
         else
             return divNode;

     };

 };

 function Private_Struct_UIControls_MenuItem() {
     this.Name;
     this.Style;
     this.Img;
     this.Lable;
     this.LableDesc;
     this.LabelActionUrl;
     this.ChildMenuList = new Dirc();
     this.Index;
     this.BackColor;
     this.BackImg;
     this.MainLable_Css;
     this.ChildLable_Css;
     this.ItemWidth;
     this.ItemHeight;
     this.ActiveLeft;
     this.ActiveTop;
     this.OverIMG;
     this.NodeRefFromDOC;
     this.NodeRefFromChild;
 };

 
function Private_Struct_UIControls_MenuADV() {

    this.Name;
    this.Width=160;
    this.Height;
    this.DefaultPositionX=428;
    this.DefaultPositionY=28;
    this.ImageURL;
    this.ActionURL;
        
};

 function Global_UIControls_Menu() {
     this.menuDivNode;
     this.menuItemCount = 0;
     var menuMainItems = new Dirc();
     this.childMenuADV = new Dirc();

     this.Global_UIControls_Menu = function () {
         menuMainItems = new Dirc();
         this.menuItemCount = 0;
     };

     this.Create_MenuItems = function (Name, Style, Icon, Lable, LabelActionUrl, BackColor, BackImg, OverImg, MainLabel_Css, ItemWidth, ItemHeight, LableDesc) {
         var newMenuItem = new Private_Struct_UIControls_MenuItem();
         newMenuItem.Name = Name;
         newMenuItem.Style = Style;
         newMenuItem.Icon = Icon;
         newMenuItem.Lable = Lable;
         newMenuItem.LabelActionUrl = LabelActionUrl;
         newMenuItem.BackColor = BackColor;
         newMenuItem.BackImg = BackImg;
         newMenuItem.MainLable_Css = MainLabel_Css;
         newMenuItem.ItemWidth = parseInt(ItemWidth);
         newMenuItem.ItemHeight = parseInt(ItemHeight);
         newMenuItem.Index = 0;
         newMenuItem.ActiveLeft = 0;
         newMenuItem.ActiveTop = 0;
         newMenuItem.OverIMG = OverImg;
         newMenuItem.LableDesc = LableDesc;
         return newMenuItem;
     };

     this.Insert_MainMenu = function (newMenuItem) {
         newMenuItem.Index = this.menuItemCount + 1;
         this.menuItemCount = this.menuItemCount + 1;
         newMenuItem.ActiveLeft = 0;
         newMenuItem.ActiveTop = ((newMenuItem.Index - 1) * newMenuItem.ItemHeight);
         menuMainItems.Add(newMenuItem.Index, newMenuItem);
     };

     this.Insert_ChildMenu = function (parentMenuItem, newMenuItem) {
         if (parentMenuItem != null)         
             parentMenuItem.ChildMenuList.Add(parentMenuItem.ChildMenuList.GetLength()+1, newMenuItem);

     };


     this.Insert_ChildADV = function (Name, Height, ImageURL, ActionURL) {
         var newADVItem = Private_Struct_UIControls_MenuADV();
         newADVItem.Name = Name;
         newADVItem.Height = Height;
         newADVItem.ImageURL = ImageURL;
         newADVItem.ActionURL = ActionURL;
         childMenuADV.add(childMenuADV.GetLength() + 1, newADVItem);
     };

     this.CreateControl = function (Container, Name, BorderWidth, BorderColor, DefaultPositionX, DefaultPositionY) {
         this.menuDivNode = $("<div></div>");
         this.menuDivNode.attr("id", Name);
         this.menuDivNode.css("position", "absolute");
         this.menuDivNode.css("border-style", "none");
         this.menuDivNode.css("left", DefaultPositionX + "px");
         this.menuDivNode.css("top", DefaultPositionY + "px");
         this.menuDivNode.css("visibility", "visible");
         this.menuDivNode.css("z-index", "20000");
         if (this.menuItemCount > 0) {
             for (var i = 1; i <= this.menuItemCount; i++) {
                 newMenuItem = menuMainItems.Get(i);
                 mainMenuDivNode = $("<div></div>");
                 mainMenuDivNode.attr("id", newMenuItem.Index);
                 mainMenuDivNode.css("position", "absolute");
                 if (newMenuItem.MainLable_Css == "") {
                     if (newMenuItem.Style == "1") {
                         if (i != "1") {
                             mainMenuDivNode.css("border-top-style", "solid");
                         }
                         mainMenuDivNode.css("border-right-style", "solid");
                         mainMenuDivNode.css("border-bottom-style", "solid");
                         mainMenuDivNode.css("border-left-style", "solid");
                     }
                     else if (newMenuItem.Style == "2") {
                         if (i != "1") {
                             mainMenuDivNode.css("border-top-style", "dashed");
                         }
                         mainMenuDivNode.css("border-right-style", "dashed");
                         mainMenuDivNode.css("border-bottom-style", "dashed");
                         mainMenuDivNode.css("border-left-style", "dashed");
                     }
                     else {
                         mainMenuDivNode.css("border-style", "none");
                     }
                 }
                 else
                     mainMenuDivNode.addClass(newMenuItem.MainLable_Css);
                 mainMenuDivNode.css("width", newMenuItem.ItemWidth + "px");
                 mainMenuDivNode.css("height", newMenuItem.ItemHeight + "px");
                 mainMenuDivNode.css("border-width", BorderWidth);
                 mainMenuDivNode.css("border-color", BorderColor);
                 mainMenuDivNode.css("left", "0px");
                 mainMenuDivNode.css("top", ((i - 1) * newMenuItem.ItemHeight) + "px");
                 newMenuItem.ActiveTop = (i - 1) * newMenuItem.ItemHeight;
                 mainMenuDivNode.css("backgroundImage", "url(" + newMenuItem.BackImg + ")");
                 mainMenuDivNode.css("background-color", newMenuItem.BackColor);
                 var mainMenuLevelLabelObj = new Global_UIControls_Label();
                 mainMenuLevelLabelObj.CreateControl(mainMenuDivNode, '', 20, 14, newMenuItem.Lable, 'FontCss_MainLabel');
                 newMenuItem.NodeRefFromDOC = mainMenuDivNode;
                 if (newMenuItem.ChildMenuList.GetLength() > 0) {
                     var childMenuNode = $("<div></div>");
                     childMenuNode.css("position", "absolute");
                     childMenuNode.css("border-style", "none");
                     childMenuNode.css("width", "600px");
                     childMenuNode.css("left", (newMenuItem.ItemWidth + 2) + "px");
                     childMenuNode.css("top", "0px");
                     childMenuNode.css("z-index", "10000");
                     if (newMenuItem.ChildMenuList.GetLength() <= 20)
                         childMenuNode.css("height", "150px");
                     else if (newMenuItem.ChildMenuList.GetLength() <= 30 && newMenuItem.ChildMenuList.GetLength() > 20)
                         childMenuNode.css("height", "250px");
                     else if (newMenuItem.ChildMenuList.GetLength() > 30)
                         childMenuNode.css("height", "400px");
                     if (newMenuItem.ChildMenuList.GetLength() <= 20)
                         childMenuNode.css("backgroundImage", "url(Images/MenuItems/MainForm/Menu_ChildMenuItem_Back_Small.fw.png)");
                     else if (newMenuItem.ChildMenuList.GetLength() <= 30 && newMenuItem.ChildMenuList.GetLength() > 20)
                         childMenuNode.css("backgroundImage", "url(Images/MenuItems/MainForm/Menu_ChildMenuItem_Back_Normal.fw.png)");
                     else if (newMenuItem.ChildMenuList.GetLength() > 30)
                         childMenuNode.css("backgroundImage", "url(Images/MenuItems/MainForm/Menu_ChildMenuItem_Back_Large.fw.png)");
                     mainMenuDivNode.append(childMenuNode);
                     $(childMenuNode).hide();
                     newMenuItem.NodeRefFromChild = childMenuNode;
                     if (newMenuItem.ChildMenuList.GetLength() > 0) {
                         var tableNode = $("<table border='0' width='400'></table>");
                         tableNode.css("position", "absolute");
                         tableNode.css("left", "5px");
                         tableNode.css("top", "22px");
                         childMenuNode.append(tableNode);
                         var rowCount = (newMenuItem.ChildMenuList.GetLength() / 5) < 1 ? 1 : parseInt((newMenuItem.ChildMenuList.GetLength() / 5) + 1);
                         for (var childRow = 1; childRow <= rowCount; childRow++) {
                             var rowNode = $("<TR></TR>");
                             tableNode.append(rowNode);
                             for (var childIndex = (childRow - 1) * 5 + 1; childIndex <= (childRow - 1) * 5 + 5; childIndex++) {
                                 if (newMenuItem.ChildMenuList.GetLength() < childIndex)
                                     break;
                                 var childMenuItem = newMenuItem.ChildMenuList.Get(childIndex);
                                 var linkLable = $("<span><a href=" + childMenuItem.LabelActionUrl + ">" + childMenuItem.Lable + "</a></span>");
                                 linkLable.addClass(childMenuItem.MainLable_Css);
                                 var columnNode = $("<TD align='center'></TD>");
                                 columnNode.append(linkLable);
                                 rowNode.append(columnNode);
                             }
                         }
                     }
                 }
                 $(mainMenuDivNode).mouseover(function (e) {
                     var activeDiv = menuMainItems.Get(e.currentTarget.id);
                     $(activeDiv.NodeRefFromDOC).css("backgroundImage", "url(" + activeDiv.OverIMG + ")");
                     $(activeDiv.NodeRefFromChild).show();
                 });
                 $(mainMenuDivNode).mouseout(function (e) {
                     var activeDiv = menuMainItems.Get(e.currentTarget.id);
                     $(activeDiv.NodeRefFromDOC).css("backgroundImage", "url(" + activeDiv.BackImg + ")");
                     $(activeDiv.NodeRefFromChild).hide();
                 });
                 this.menuDivNode.append(mainMenuDivNode);

             }
         }
         if (Container != null) {
             Container.append(this.menuDivNode);
         }
         else
             return this.menuDivNode;
     };

 };


 function Private_Struct_UIControls_PIItemAttr() {
     this.attrname;
     this.attrvalue;
     this.attrcss;
     this.attrurl;    
 };

 function Private_Struct_UIControls_PIItem() {
     this.img;
     this.imgwidth;
     this.imgheight;
     this.attrs = new Dirc();
     this.labelrow = 2;
     this.width;
     this.height;

     this.Insert_AttrItem = function (attrname, attrvalue, attrcss, attrurl) {
         var NewPIItemAttr = new Private_Struct_UIControls_PIItemAttr();
         NewPIItemAttr.attrname = attrname;
         NewPIItemAttr.attrvalue = attrvalue;
         NewPIItemAttr.attrcss = attrcss;
         NewPIItemAttr.attrurl = attrurl;
         this.attrs.Add(this.attrs.GetLength() + 1, NewPIItemAttr);
     };
 };

 function Global_UIControls_PI() {
     this.Items = new Dirc();
     this.Insert_PIItem = function (NewPIItem) {
         if (NewPIItem != null) {
             this.Items.Add(this.Items.GetLength() + 1, NewPIItem);
         }
     };
     this.CreateControl = function (container, controlName, style, positionX, positionY) {
         var ItemFrameNode = $("<div></div>");
         ItemFrameNode.css("position", "absolute");
         ItemFrameNode.css("border-style", "none");
         ItemFrameNode.css("left", positionX + "px");
         ItemFrameNode.css("top", positionY + "px");
         var tableNode = $("<table border='0' cellspacing='0' cellpadding='0'></table>");
         var rowNode = $("<tr></tr>");
         tableNode.append(rowNode);
         for (var index = 1; index <= this.Items.GetLength(); index++) {
             var tmpPIItem = this.Items.Get(index);
             var cellNode = $("<td width='" + tmpPIItem.width + "' height='" + tmpPIItem.height + "'></td>");
             var contentNode;
             if (style == "1") {
                 contentNode = $("<div></div>");
                 contentNode.css("position", "absolute");
                 contentNode.css("border-style", "none");
                 contentNode.css("left", positionX + "px");
                 contentNode.css("top", positionY + "px");
             } else if (style == "2") {

             }
         }
     };
 };

/* function Global_UIControls_Combox() {
     this.divComboxNode;
     this.divComboxItemNode;
     this.textInputNode;
     this.items = new Dirc();
     this.CreateControl = function (container, controlName, bordercolor, positionX, positionY, width) {
         this.divComboxNode = $("<div></div>");
         this.divComboxNode.attr("id", controlName);
         this.divComboxNode.css("position", "absolute");
         this.divComboxNode.css("border-style", "none");
         this.divComboxNode.css("width", width + "px");
         this.divComboxNode.css("height", "25px");
         this.divComboxNode.css("left", positionX + "px");
         this.divComboxNode.css("top", positionY + "px");
         this.divComboxItemNode = $("<div></div>");
         $(this.divComboxItemNode).hide();
         var tableNode = $("<table border='0' cellpadding='0' cellspacing='0' width='" + width + "'></table>");
         var trNode = $("<tr></tr>");
         tableNode.append(trNode);
         var tdTextNode = $("<td></td>");
         this.textInputNode = $("<input type='textbox' id='comboboxtext'></input>");
         trNode.append(tdTextNode);
         var tdArrNode = $("<td width='25' height='25'><img src='BaseScripts/CommonLib/Images/Combox/array.fw.png'></img></td>");
         trNode.append(tdArrNode);
         $(tdArrNode).click(function () {

         });
         this.divComboxNode.append(tableNode);
     };

 };*/

 
 function Global_UIControls_Select() {
     this.DivNode;
     this.SelectNode;
     this.Items = new Dirc();

     this.InsertItem = function (ItemContent) {
         this.Items.Add(this.Items.GetLength() + 1, ItemContent);
     };

     this.CreateControl = function (container, controlName, positionX, positionY) {
         this.DivNode = $("<div></div>");
         this.DivNode.css("position", "absolute");
         this.DivNode.css("border-style", "none");
         this.DivNode.css("left", positionX + "px");
         this.DivNode.css("top", positionY + "px");
         this.SelectNode = $("<select></select>");
         $(this.SelectNode).attr("name", controlName);
         this.DivNode.append(this.SelectNode);
         for (var i = 1; i <= this.Items.GetLength(); i++) {
             var activeItem = this.Items.Get(i);
             if (activeItem != "") {
                 var actionOption = $("<option>" + activeItem + "</option>");
                 this.SelectNode.append(actionOption);
             }
         }
         container.append(this.DivNode);
         return this.SelectNode;

     };

     this.ActionChange = function (RefMethod) {
         $(this.SelectNode).change(RefMethod);
     };

     this.ActionInsetItem = function (ItemContent) {
         var itemNode = $("<option>" + ItemContent + "</option>");
         this.Items.Add(this.Items.GetLength() + 1, ItemContent);
         this.SelectNode.append(itemNode);
     };

     this.ActionRemoveItem = function (ItemContent) {
         for (var i = 0; i < $(this.SelectNode).get(0).length; i++) {
             if ($(this.SelectNode).get(0).options[i].value == ItemContent) {
                 $(this.SelectNode).get(0).remove(i);
                 return true;
             }
         }
     };

     this.ActionGetActiveItem = function () {
         var Text = $(this.SelectNode).find("option:selected").text();
         return Text;
     };

     this.GetValue = function () {
         var result = "";
         for (var i = 0; i < $(this.SelectNode).get(0).length; i++) {
             result = result + (this.SelectNode).get(0).options[i].value + "|";
         }
         return result;
     };

     this.ActionClearAllItems = function () {
         for (var i = 0; i < $(this.SelectNode).get(0).length; i++) {
             $(this.SelectNode).get(0).remove(i);
         }
     };

 };


 function Global_UIControls_Editor() {
     this.CreateControl = function (container, controlName, positionX, positionY) {
        
     };
 };
