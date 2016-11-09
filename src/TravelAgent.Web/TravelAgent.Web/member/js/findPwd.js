$(function() {
        uReg();
        $("#mobile").focus();
        $("#verify1").unFormValidator(false);
        $("#txtValidatorTip,#verifyTip").css("display", "inline");
});

function uReg() {

        /***phone***/
    $.formValidator.initConfig({ validatorGroup: "1", ajaxObjects: "form1", submitOnce: false, formID: "form1", errorFocus: false, ajaxPrompt: "",
        onError: function(msg) {
            //alert(msg);
            return false;
        },
        onSuccess: function() {
            document.forms[0].submit();

        }
    });

        $("#mobile").formValidator({validatorGroup: "1", onShow: "", onFocus: "请您填写注册时用的手机号码", onCorrect: "&nbsp;"}).inputValidator({min: 1, onError: "请输入手机号"}).regexValidator({regExp: "mobile", dataType: "enum", onError: "手机格式不正确"})
                .ajaxValidator({
                dataType: "text",
                type: "post",
                async: true,
                url: "/member/data/FindPassword.ashx?tag=mobile",
                success: function(data) {
                        if (data == 'true') {
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
                onError: "您输入的手机号码不存在",
                onWait: "&nbsp;"
        });
//        $("#verify").formValidator({validatorGroup: "1", onShow: "", onFocus: "请输入图片中的数字", onCorrect: "&nbsp;"}).inputValidator({min: 4, max: 4, onError: "图片中的数字为4位"}).regexValidator({regExp: "intege3", dataType: "enum", onError: "图片中的数字为4位"})
//                .ajaxValidator({
//                type: "post",
//                dataType: "html",
//                async: true,
//                url: "/public/validation",
//                success: function(data) {
//                        if (data == 'true') {
//                                return true;
//                        } else {
//                                return false;
//                        }
//                },
//                complete: function() {
//                },
//                error: function(jqXHR, textStatus, errorThrown) {
//                        alert("请重试" + errorThrown);
//                },
//                onError: "您输入的数字和图片中的不符，请重新输入",
//                onWait: "&nbsp;"
//        });
        $("#txtValidator").formValidator({validatorGroup: "1", onShow: "", onFocus: "请输入验证码", onCorrect: "&nbsp;"}).inputValidator({min: 4, max: 4, onError: "验证码为4位数字"}).regexValidator({regExp: "intege3", dataType: "enum", onError: "验证码为4位数字"})
                .ajaxValidator({
                type: "post",
                dataType: "html",
                async: true,
                url: "/member/data/FindPassword.ashx?tag=code",
                success: function(data) {
                        if (data == 'true') {
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
                onError: "您输入的短信验证码不正确，请重新输入",
                onWait: "&nbsp;"
        });

        /***pwd***/
        $.formValidator.initConfig({validatorGroup: "3", ajaxObjects: "form1", submitOnce: false, formID: "form1", errorFocus: false,
                onError: function(msg) {
                        //alert(msg);
                },
                onSuccess: function() {
                        document.forms[1].submit();

                }
        });
        $("#txtPwd").formValidator({validatorGroup: "1", onShow: "", onFocus: "6-16位字符，可由英文字母、数字及符号组成。", onCorrect: "&nbsp;"}).inputValidator({min: 6, max: 16, empty: {leftEmpty: false, rightEmpty: false, emptyError: "密码两边不能有空符号"}, onError: "密码长度至少6位，不超过16位"});
        $("#txtRePwd").formValidator({validatorGroup: "1", onShow: "", onFocus: "请再次输入密码", onCorrect: "&nbsp;"}).inputValidator({min: 5, max: 16, empty: {leftEmpty: false, rightEmpty: false, emptyError: "前后密码不一致。"}, onError: "前后密码不一致。"}).compareValidator({desID: "txtPwd", operateor: "=", onError: "前后密码不一致。"});

        /***Email***/
        $.formValidator.initConfig({validatorGroup: "2", ajaxObjects: "form2", submitOnce: false, formID: "form2", errorFocus: false,
                onError: function(msg) {
                        //alert(msg);
                },
                onSuccess: function() {
                        document.forms[1].submit();

                }
        });

        $("#email").formValidator({validatorGroup: "2", onShow: "", onFocus: "请您填写注册时用的邮箱", onCorrect: "&nbsp;"}).inputValidator({min: 1, onError: "邮箱不能为空"}).regexValidator({regExp: "email", dataType: "enum", onError: "邮箱格式不正确"})
                .ajaxValidator({
                dataType: "text",
                type: "post",
                async: true,
                url: "/member/data/FindPassword.ashx?tag=email",
                success: function(data) {
                        if (data == 'true') {
                                return true;
                        }else {
                                return false;
                        }
                },
                complete: function() {
                },
                error: function(jqXHR, textStatus, errorThrown) {
                        alert("请重试" + errorThrown);
                },
                onError: "您输入的邮箱地址不存在",
                onWait: "&nbsp;"
        });
        $("#verify").formValidator({ validatorGroup: "2", onShow: "", onFocus: "请输入验证码", onCorrect: "&nbsp;" }).inputValidator({ min: 4, max: 4, onError: "验证码为4位数字" }).regexValidator({ regExp: "intege3", dataType: "enum", onError: "验证码为4位数字" })
                .ajaxValidator({
                dataType: "html",
                type: "post",
                async: true,
                url: "/member/data/RegisterVerify.ashx?tag=code",
                success: function(data) {
                        if (data == 'true') {
                                return true;
                        }else {
                                return false;
                        }
                },
                complete: function() {
                },
                error: function(jqXHR, textStatus, errorThrown) {
                        alert("请重试" + errorThrown);
                },
                onError: "验证码不正确，请重新输入",
                onWait: "&nbsp;"
        });
}

//检查密码强度
function checkPwdLevel() {
        var o = $('#txtPwd');
        var oV = $.trim(o.val())
        var os = $('.password_tel_strong');
        var level = checkStrong(oV); //检查密码强度等级
        switch (level) {
                case 0:
                        os.attr('class', 'password_tel_strong');
                        break;
                case 1:
                        os.attr('class', 'password_tel_strong sPwdLevel1');
                        break;
                case 2:
                        os.attr('class', 'password_tel_strong sPwdLevel2');
                        break;
                default:
                        os.attr('class', 'password_tel_strong sPwdLevel3');
        }
}

function regTimeMinus(btn, t) {
        if (t > 1) {
                $('#' + btn).attr("disabled", true); //变灰
                t = t - 1;
                $("#showTime").text("，请" + (t < 10 ? "0" + t : "" + t) + "秒后");
                //执行完后，再次执行
                timeCode = window.setTimeout("regTimeMinus('" + btn + "', " + t + ")", 1000);
        }
        else if (t <= 1) {
                $('#' + btn).attr("disabled", false); //变灰 //变黄
                $("#showTime").text("，现在可以");
        }
}


$(function() {
    $("#codeSend,#reSend").click(function() {
        $("#verify").unFormValidator(false);
        var phone = $("#mobile").val();
        if (phone == "") {
            $("#phoneError").css("display", "inline").text("请您填写注册时用的手机号码")
            return false;
        }
        var mobileReg = new RegExp(regexEnum.mobile);
        if (!mobileReg.test(phone)) {
            $("#phoneError").css("display", "inline").text("手机格式不正确")
            return false;
        }
        $("#mobileTip,#verifyTip").children("span").each(function(i, item) {
            if ($(item).attr("class") == "" || $(item).css("display") == "none") {
                $(item).parent().siblings(":text").focus();
            }
        });
        if ($("#checkCodeForSend").css("display") != "none") {
            if ($("#mobileTip,#verifyTip").children("span[class='onCorrect']").length != 2)
                return false;
        }
        var verify = $("#verify").val();
        if ($("#checkCodeForSend").css("display") == "none")
            verify = "none";
        $.ajax({
            type: "POST",
            cache: false,
            async: false,
            data: { "mobile": $('#mobile').val(), "type": "findPassword", "verify": verify },
            url: "/member/data/SendMobileCode.aspx",
            success: function(data) {
                $("#checkCodeForSend").hide();
                $("#verify1").val("none");
                if (data != "-4") {
                    $("#imgCheckCode").click(); //更新验证码 
                    $("#verifyTip span").removeClass();
                    $("#verify").val("");
                }
                if (data == 'true') {
                    regTimeMinus("reSend", 61);
                    $("#codeError").text("");
                    $("#sended").css("display", "inline");
                    $("#codeSend").css("display", "none");
                }
                //                                else if (data == "-1") {
                //                                        $("#codeSend").css("display", "none");
                //                                        $("#sendedThree").css("display", "inline");
                //                                        $("#sended").css("display", "none");
                //                                    } 
                else if (data == "-3") {
                    $("#phoneError").css("display", "inline").text("您输入的手机号码不存在");
                }
                else if (data == "-4") {
                    $("#verifyError").css("display", "inline").text("您输入数字和图片中的不相符");
                    $("#checkCodeForSend").show();
                    $("#verify").val("");
                }
                else if (data == "sendfail") {
                    alert("您的短信服务器连接错误，请联系管理员！");
                    return false;
                }
            },
            error: function() {

            }
        });
    });

    $(".submitPwd").click(function() {
        $("#verify1").unFormValidator(true);
    });
});