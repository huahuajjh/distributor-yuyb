var editorDataLocalStorageInterval = webconfig("editordatalocalstorageinterval");
function WbLocalStorage(saveInterval, recoverEditorContentSwitchClassName) {
    recoverSwitchClassName = "recoverEditorContentSwitch"
    if (typeof (recoverEditorContentSwitchClassName) != "undefined") {
        recoverSwitchClassName = recoverEditorContentSwitchClassName;
    }
    saveInterval = (typeof (saveInterval) == "undefined" || saveInterval < editorDataLocalStorageInterval) ? editorDataLocalStorageInterval : saveInterval;
    this.saveTimer = null;
    if (window.localStorage) {
        var tip = $('#EditorAutoSaveTip');
        this.saveTimer = setInterval(function () {
            if (typeof (editor) != "undefined") {
                var hasEditor = false;
                for (key in editor) {
                    var content = editor[key].getContent();
                    if ($.trim(content) != "") {
                        hasEditor = true;
                        localStorage.setItem(key, content);
                    }
                }
                if (hasEditor && tip.length > 0) {
                    var d = new Date();
                    var YMDHMS = d.getFullYear() + "-" + (d.getMonth() + 1) + "-" + d.getDate() + " " + d.getHours() + ":" + d.getMinutes() + ":" + d.getSeconds();
                    tip.html('（数据保存于: ' + YMDHMS + '）');
                    setTimeout(function () { tip.html(''); }, 5000);
                }
            }
        }, saveInterval);   //每隔N秒保存一次
        //WbLocalStorage.fill();
        WbLocalStorage.showSwich();
    } else {
        alert('您的浏览器不支持 localStorage 技术。');
    }
}

WbLocalStorage.prototype.stop = function () {
    clearInterval(this.saveTimer); //停止保存
};

WbLocalStorage.get = function (key) {
    return localStorage.getItem(key);
};

WbLocalStorage.set = function (key, value) {
    localStorage.setItem(key, value);
};

WbLocalStorage.remove = function (key) {
    return localStorage.removeItem(key);
};

WbLocalStorage.showSwich = function () {
    $("." + recoverSwitchClassName).each(function () {
        var content = WbLocalStorage.get($(this).attr("tag"));
        if (typeof (content) != "undefined" || $.trim(content) != "") {
            $(this).show();
        } else {
            $(this).hide();
        }
    });
};

WbLocalStorage.fill = function () {
    for (key in editor) {
        var content = WbLocalStorage.get(key);
        if (typeof (content) != "undefined" && content != null && $.trim(content) != "") {
            //editor[key].setContent(content);
            editor[key].addListener("ready", function () {
                this.setContent(WbLocalStorage.get(this.key));
            });
        }
    }
};
WbLocalStorage.fillone = function (key) {
    var content = WbLocalStorage.get(key);
    if (typeof (content) != "undefined" && content != null && $.trim(content) != "") {
        editor[key].setContent(WbLocalStorage.get(key));
    }
};

//type{0:"清除所有",1:"清除当前页面所有编辑的数据"}
WbLocalStorage.clear = function (type) {
    if (type == 1) {
        for (key in editor) {
            WbLocalStorage.remove(key);
        }
    } else {
        localStorage.clear();
    }
};
