function Dirc_Node() {

    this.key;
    this.value;    

    this.setKey = function(Key) {
        this.key = Key;
    };

    this.setValue = function(Value) {
        this.value = Value;
    };

    this.getKey = function() {
        return this.key;
    };

    this.getValue = function() {
        return this.value;
    };

};

function Dirc() {

    this.listBuffer = new Array();   

    this.Add = function(key, value) {        
        if (!this.IsContainkey(key)) {
            var tmpObj = new Dirc_Node();
            tmpObj.setKey(key);
            tmpObj.setValue(value);
            this.listBuffer[this.listBuffer.length] = tmpObj;
        };
    };

    this.GetLength = function () {
        return this.listBuffer.length;
    };

    this.IsContainkey = function(key) {
        for (var i = 0; i < this.listBuffer.length; i++) {
            var tmpkey = this.listBuffer[i].getKey();
            if (tmpkey == key) {
                return true;
            }
        }
        return false;
    };

    this.Get = function(key) {       
        if (this.IsContainkey(key)) {
            for (var i = 0; i < this.listBuffer.length; i++) {
                if (this.listBuffer[i].getKey() == key) {
                    return this.listBuffer[i].getValue();
                }
                else
                    continue;
            };
        }
        else
            return null;
    };

};