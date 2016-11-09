$(function() {
        validate();
        checkPwdLevel();
});

function validate() {
        $.formValidator.initConfig({validatorGroup: "1", ajaxObjects: "form1", submitOnce: false, formID: "form1", errorFocus: false, ajaxPrompt: "尊敬的用户，部分填写项正在验证中，请稍后再注册",
                onError: function(msg) {
                },
                onSuccess: function() {

                        if ($(".changeKeyword .onError").length > 0)
                                return false;
                        else
                                document.forms[window.document.forms.length - 1].submit();
                }
        });
        $("#txtOldPassword").formValidator({validatorGroup: "1", onShow: "", onFocus: "6-16位字符，可由英文字母、数字及符号组成", onCorrect: "&nbsp;"}).inputValidator({min: 6, max: 16, empty: {leftEmpty: false, rightEmpty: false, emptyError: "密码两边不能有空符号"}, onError: "密码长度至少6位，不超过16位"});
        $("#txtPassword").formValidator({validatorGroup: "1", onShow: "", onFocus: "6-16位字符，可由英文字母、数字及符号组成", onCorrect: "&nbsp;"}).inputValidator({min: 6, max: 16, empty: {leftEmpty: false, rightEmpty: false, emptyError: "密码两边不能有空符号"}, onError: "密码长度至少6位，不超过16位"}).compareValidator({desID: "txtOldPassword", operateor: "!=", onError: "新密码不能和原密码一样"});
        $("#txtRePassword").formValidator({validatorGroup: "1", onShow: "", onFocus: "请再次输入密码", onCorrect: "&nbsp;"}).inputValidator({min: 6, max: 16, empty: {leftEmpty: false, rightEmpty: false, emptyError: "前后密码不一致"}, onError: "前后密码不一致"}).compareValidator({desID: "txtPassword", operateor: "=", onError: "前后密码不一致"});

}

//检查密码强度
function checkPwdLevel() {
        var o = $('#txtPassword');
        var oV = $.trim(o.val())
        var os = $('.power_strong');
        var level = checkStrong(oV); //检查密码强度等级
        switch (level) {
                case 0:
                        os.attr('class', 'power_strong');
                        break;
                case 1:
                        os.attr('class', 'power_strong sPwdLevel1');
                        break;
                case 2:
                        os.attr('class', 'power_strong sPwdLevel2');
                        break;
                default:
                        os.attr('class', 'power_strong sPwdLevel3');
        }
}

function checkStrong(sPW) {
        if (sPW.length <= 5)
                return 0;
        Modes = 0;
        for (i = 0; i < sPW.length; i++) {
                Modes |= charMode(sPW.charCodeAt(i));
        }
        return bitTotal(Modes);
}

function charMode(iN) {
        if (iN >= 48 && iN <= 57)
                return 1;
        if (iN >= 65 && iN <= 90)
                return 2;
        if (iN >= 97 && iN <= 122)
                return 4;
        else
                return 8;
}

function checkStrong(sPW) {
        if (sPW.length <= 5)
                return 0;
        Modes = 0;
        for (i = 0; i < sPW.length; i++) {
                Modes |= charMode(sPW.charCodeAt(i));
        }
        return bitTotal(Modes);
}
function bitTotal(num) {
        modes = 0;
        for (i = 0; i < 4; i++) {
                if (num & 1)
                        modes++;
                num >>>= 1;
        }
        return modes;
}