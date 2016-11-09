$(function() {
        regXieYi();
        uReg();
        doTab('.register_title');
        initClick();
        $("#txtValidatorTip,#txtValidator2Tip,#txtPhone,#txtEmail").css("display", "inline");
        $("#")
});

function uReg() {

        /***phone***/
    $.formValidator.initConfig({ validatorGroup: "1", ajaxObjects: "register", submitOnce: false, formID: "register", errorFocus: false, ajaxPrompt: "尊敬的用户，部分填写项正在验证中，请稍后再注册",
        onError: function(msg) {
            //alert(msg);
        },
        onSuccess: function() {
            //$("#btnSubmit").css("display", "none");
            //$("#btnSubmitWait").css("display", "inline");
            //$("#register").submit();
            return true;
        }
    });

        $("#mobile").formValidator({validatorGroup: "1", onShow: "", onFocus: "手机号码作为您的登录名，可通过手机号码找回密码", onCorrect: "&nbsp;"}).inputValidator({min: 1, onError: "请输入手机号"}).regexValidator({regExp: "mobile", dataType: "enum", onError: "手机格式不正确"})
                .ajaxValidator({
                dataType: "html",
                async: true,
                url: "/member/data/RegisterVerify.ashx?tag=mobile",
                success: function(data) {
                        if (data == 'false') {
                                return true;
                        } else {
                                return false;
                        }
                },
                complete: function() {
                },
                error: function(jqXHR, textStatus, errorThrown) {
                        alert("请重试" + errorThrown);
                },
                onError: "手机号码已注册",
                onWait: "&nbsp;"
        }).focus();
        $("#txtPwd").formValidator({validatorGroup: "1", onShow: "", onFocus: "6-16位字符，可由英文字母、数字及符号组成", onCorrect: "&nbsp;"}).inputValidator({min: 6, max: 16, empty: {leftEmpty: false, rightEmpty: false, emptyError: "密码两边不能有空符号"}, onError: "密码长度至少6位，不超过16位"});
        $("#txtRePwd").formValidator({validatorGroup: "1", onShow: "", onFocus: "请再次输入密码", onCorrect: "&nbsp;"}).inputValidator({min: 6, max: 16, empty: {leftEmpty: false, rightEmpty: false, emptyError: "前后密码不一致"}, onError: "前后密码不一致"}).compareValidator({desID: "txtPwd", operateor: "=", onError: "前后密码不一致"});
        $("#verify").formValidator({ validatorGroup: "1", onShow: "", onFocus: "请输入验证码", onCorrect: "&nbsp;" }).inputValidator({ min: 4, max: 4, onError: "验证码为4位数字" }).regexValidator({ regExp: "intege3", dataType: "enum", onError: "验证码为4位数字" })
                .ajaxValidator({
                    dataType: "html",
                    async: true,
                    url: "/member/data/RegisterVerify.ashx?tag=code",
                    success: function(data) {
                        if (data == 'true') {
                            return true;
                        }
                        else {
                            return false;
                        }
                    },
                    complete: function() {
                    },
                    error: function(jqXHR, textStatus, errorThrown) {
                        alert("请重试" + errorThrown);
                    },
                    onError: "您输入的验证码不正确，请重新输入",
                    onWait: "&nbsp;"
                });

        $("#email").formValidator({validatorGroup: "1", onShow: "", onFocus: "邮箱可以作为您的登录名，可用邮箱找回密码", onCorrect: "&nbsp;"}).inputValidator({min: 1, onError: "邮箱不能为空"}).regexValidator({regExp: "email", dataType: "enum", onError: "邮箱格式不正确"})
                .ajaxValidator({
                dataType: "html",
                async: true,
                url: "/member/data/RegisterVerify.ashx?tag=email",
                success: function(data) {
                        if (data == 'false') {
                                return true;
                        } else {
                                return false;
                        }
                },
                complete: function() {
                },
                error: function(jqXHR, textStatus, errorThrown) {
                        alert("请重试" + errorThrown);
                },
                onError: "邮箱已注册",
                onWait: "&nbsp;"
        }).focus();


}


function doTab(obj) {

        $.formValidator.resetTipState();
        $(obj).find('a').click(function() {
                var o = $(this);
                var id = o.attr('id');

                if (id == 'email_register') {
                        $('#current_id').html('邮箱注册');
                        $('#email_register').hide();
                        $('#phone_input').hide();
                        $('#email_input').show();
                        $('#phone_register').show();
                        $("#type").val("email");
                        $("#email").focus();
                } else {
                        $('#current_id').html('手机注册');
                        $('#phone_input').show();
                        $('#email_input').hide();
                        $('#email_register').show();
                        $('#phone_register').hide();
                        $("#type").val("email");
                        $("#email").focus();
                }
                return false;
        });

}

//检查密码强度
function checkPwdLevel() {
        var o = $('#txtPwd');
        var oV = $.trim(o.val())
        var os = $('#pwdLevel');
        var level = checkStrong(oV); //检查密码强度等级
        switch (level) {
                case 0:
                        os.attr('class', 'pwdLevel');
                        break;
                case 1:
                        os.attr('class', 'pwdLevel sPwdLevel1');
                        break;
                case 2:
                        os.attr('class', 'pwdLevel sPwdLevel2');
                        break;
                default:
                        os.attr('class', 'pwdLevel sPwdLevel3');
        }
}


//检查密码强度
function checkPwdLevel2() {
        var o = $('#txtPwd2');
        var oV = $.trim(o.val())
        var os = $('#pwdLevel2');
        var level = checkStrong(oV); //检查密码强度等级
        switch (level) {
                case 0:
                        os.attr('class', 'pwdLevel');
                        break;
                case 1:
                        os.attr('class', 'pwdLevel sPwdLevel1');
                        break;
                case 2:
                        os.attr('class', 'pwdLevel sPwdLevel2');
                        break;
                default:
                        os.attr('class', 'pwdLevel sPwdLevel3');
        }
}

function regXieYi() {
        $('a.aYieYi').toggle(function() {
                $('#xieyi').show();
                $(this).addClass('on');
                return false;
        }, function() {
                $('#xieyi').hide();
                $(this).removeClass('on');
                return false;
        });

        $("#checkXieYi").click(function() {
                if ($(this).is(':checked') === true) {
                        $("#btnSubmit").css("background-position", "").attr("disabled", false);
                } else
                        $("#btnSubmit").css("background-position", "0 -60px").attr("disabled", true);
        });

        $("#checkXieYi2").click(function() {
                if ($(this).is(':checked') === true)
                        $("#btnSubmit2").css("background-position", "").attr("disabled", false);
                else
                        $("#btnSubmit2").css("background-position", "0 -60px").attr("disabled", false);
        });
}

function initClick() {
        $("#mReg>.hd>ul>li.on").click();
}