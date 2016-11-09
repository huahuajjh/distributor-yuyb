<%@ Page Title="" Language="C#" MasterPageFile="~/member/Member.Master" AutoEventWireup="true" CodeBehind="MobileValidate.aspx.cs" Inherits="TravelAgent.Web.member.MobileValidate" %>
<%@ MasterType VirtualPath="~/member/Member.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script src="/js/formValidatorRegex.js" type="text/javascript"></script>
 <script type="text/javascript">
                        var waitHtml = "<img style='margin-right:8px;margin-top:-5px' src=\"/member/images/onLoad.gif\">#";
                        $(function() {
                                $("#sendPhone").click(function() {

                                        var result = validateMobile();
                                        if (result == false) {
                                                return false;
                                        }
                                        result = validateCheckCode();
                                        if (result == false) {
                                                return false;
                                        }
                                        $("#mobileSendSuccess").hide();
                                        $("#txtPhoneTip").removeClass().html(waitHtml.replace("#", "数据提交中，请稍候..."));
                                        var txtCheckCode = $("#txtCheckCode").val();
                                        if ($("#checkCodeForSend").css("display") === "none")
                                        txtCheckCode = "none";
                                        $.ajax({
                                        url: "/dataDeal/SendValidateSMS.aspx",
                                        data: { "mobile": $.trim($("#txtPhone").val()), "verify": txtCheckCode, "clubid": $.cookie('uid') },
                                                type: "post",
                                                success: function(msg) {
                                                        $("#checkCodeForSend").hide(); //隐藏图片验证码输入
                                                        if (msg != "-4") {
                                                                $("#imgCheckCode").click(); //更新验证码 
                                                                $("#txtCheckCode").val("");
                                                        }
                                                        if (msg == "error") {
                                                                alert("您的手机号码已经被屏蔽或未登录");
                                                        } else if (msg == "true" || parseInt(msg, 10) >= 0) {
                                                                $("#txtPhoneTip").removeClass().html("");
                                                                $("#sendPhone").attr("disabled", true);
                                                                $("#mobileSendSuccess").show();
                                                                regTimeMinus(60);
                                                        } else if (msg == "-2") {
                                                                $("#txtPhoneTip").removeClass().addClass("submitError").html("您的手机号码已经被使用");
                                                        } else if (msg == "-1") {
                                                                $("#txtPhoneTip").removeClass().addClass("submitError").html("三次验证短信发送机会已用完");
                                                        } else if (msg == "-4") {
                                                                $("#txtPhoneTip").removeClass().html("");
                                                                $("#txtCheckCodeTip").removeClass().addClass("submitError").html("您填写的数字和图片中的不符");
                                                                $("#checkCodeForSend").show(); //显示图片验证码输入
                                                        } else if (msg != "") {
                                                                $("#txtPhoneTip").removeClass().addClass("submitError").html("验证短信发送失败");
                                                        }
                                                        },
                                                error: function() {
                                                $("#txtPhoneTip").removeClass().html("");
                                                $("#mobileSendSuccess").hide();
                                                alert("系统繁忙，请稍候再试...", "");
                                                }
                                        });
                        });

                        $("#mySubmit").click(function() {
                                var result = validateMobile();
                                if (result == false) {
                                        return false;
                                }
                                result = validatePhoneCode();
                                if (result == false) {
                                        return false;
                                }
                                $("#txtPhoneTip").removeClass().html(waitHtml.replace("#", "数据提交中，请稍候..."));
                                $.ajax({
                                url: "/member/ValidateOrModifyMobile.aspx",
                                data: { "mobile": $.trim($("#txtPhone").val()), "validateCode": $.trim($("#txtPhoneCode").val()), "clubid": $.cookie('uid') },
                                type: "post",
                                success: function(msg) {
                                    $("#txtPhoneTip").removeClass().html("");
                                    if (msg == "success") {
                                        location.href = "/member/MobileValidateSuc.aspx";
                                    }else if (msg.indexOf("已经被注册") >= 0) {
                                        $("#txtPhoneTip").removeClass().addClass("submitError").html("您的手机号码已经被使用");
                                    } else if (msg.indexOf("验证码") >= 0) {
                                        $("#txtPhoneCodeTip").removeClass().addClass("submitError").html("您的短信验证码不正确");
                                    }
                                    else if (msg != "") {
                                        alert(msg);
                                    }
                                },
                                error: function() {
                                    $("#txtPhoneTip,#txtPhoneCodeTip").removeClass().html("");
                                    $("#mobileSendSuccess").hide();
                                    alertDaliag.alertMsg("系统繁忙，请稍候再试...", "");
                                }
                                });
                                });


                        if ($("#txtPhone").val() === "") {
                        $("#txtPhone").focus(function() {
                        $("#txtPhoneTip").removeClass().addClass("submitFocus").html("请填写您的手机号码");
                        });
                        }
                        $("#txtPhone").blur(function() {
                        validateMobile();
                        });
                        $("#txtPhoneCode").blur(function() {
                        validatePhoneCode();
                        });
                        $("#txtCheckCode").blur(function() {
                        validateCheckCode();
                        });
                        });

                        function validateCheckCode() {
                            if ($("#checkCodeForSend").css("display") != "none") {
                            var code = $.trim($("#txtCheckCode").val());
                            if (code == "") {
                            $("#txtCheckCodeTip").removeClass().addClass("submitError").html("请填写图片中的数字");
                            return false;
                            }
                            var codeReg = new RegExp(regexEnum.intege3);
                            if (!codeReg.test(code) || code.length != 4) {
                            $("#txtCheckCodeTip").removeClass().addClass("submitError").html("您填写的格式不正确");
                            return false;
                            }
                        }
                        $("#txtCheckCodeTip").removeClass().html("");
                        return true;
                        }

                        function validatePhoneCode() {
                            var code = $.trim($("#txtPhoneCode").val());
                            if (code == "") {
                            $("#txtPhoneCodeTip").removeClass().addClass("submitError").html("请填写您收到的短信验证码");
                            return false;
                            }
                            var codeReg = new RegExp(regexEnum.intege3);
                            if (!codeReg.test(code) || code.length < 4) {
                            $("#txtPhoneCodeTip").removeClass().addClass("submitError").html("您的短信验证码格式不正确");
                            return false;
                            }
                            $("#txtPhoneCodeTip").removeClass().html("");
                            return true;
                        }

                        function validateMobile() {
                            var mobile = $.trim($("#txtPhone").val());
                            if (mobile == "") {
                            $("#txtPhoneTip").removeClass().addClass("submitError").html("请填写您的手机号码");
                            return false;
                        }
                        var mobileReg = new RegExp(regexEnum.mobile);
                            if (!mobileReg.test(mobile)) {
                            $("#txtPhoneTip").removeClass().addClass("submitError").html("您的手机号码格式不正确");
                            return false;
                        }
                        $("#txtPhoneTip").removeClass().html("");
                        return true;
                        }

                        function regTimeMinus(t) {
                            if (t > 1) {
                            isSendEmail = true;
                            t = t - 1; //执行完后，再次执行
                            timeCode = window.setTimeout("regTimeMinus(" + t + ")", 1000);
                            $("#time").html("请<span class=\"c_f60\">" + (t < 10 ? "0" + t : t) + "</span>秒后")
                        }
                        else if (t <= 1) {
                            //$('#' + btn).css("display", "inline").attr('disabled', false); 
                            $("#sendPhone").attr("disabled", false).val("重新发送短信验证码");
                            $("#time").html("现在可以");
                        }
                        }
                </script>
                <style type="text/css">
                        .success_text {
                                color: #666666;
                                padding-left: 15px;
                        }
                        .success_text a {
                                color: #3366CC;
                                margin: 0 5px;
                        }
                        .success_text a:hover {
                                color: #FF9900;
                        }
                        .success_text_tg {
                                color: #F08200;
                                font-size: 14px;
                                font-weight: bold;
                                padding: 18px 0;
                        }
                        .success_text_tg b {
                                color: #666666;
                                margin: 0 6px 0 8px;
                        } 

                </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="user_title"><b>手机验证</b></div>
                                                <div class="steps_img"><img src="/member/images/tel_steps_1.gif" /></div>
                                                <ul class="validation_tel">
                                                        <li><span><em>*</em>手机号码：</span><input name="txtPhone" type="text" id='txtPhone' maxlength="11" class="yz_input" /><a href="#" class="distortion" id='sendPhone'>发送手机验证码</a> <p id="txtPhoneTip" ></p></li>

                                                        <li class="validation_code" id='checkCodeForSend'><span>&nbsp;</span><input name="txtCheckCode" type="text" class="yz_input" id='txtCheckCode'/><img width="60px" height="22" border="0" src="/RandomImage.aspx" style="cursor: pointer;" title="看不清，换一张?" alt="看不清，换一张" id="imgCheckCode" onclick='javascript:this.src = "/RandomImage.aspx?t=" + new Date().toUTCString();'>
                                                                        <p class="prompt_write" id='txtCheckCodeTip'></p>
                                                        </li>
                                                        <li ><span>手机验证码：</span><input name="txtPhoneCode" type="text" id='txtPhoneCode'/><p class="prompt_write" id='txtPhoneCodeTip'></p></li>
                                                        <li><span>&nbsp;</span><div class="sure"><button type="submit" class="fn-btn" id="mySubmit" >验证</button></div></li>
                                                        <p>温馨提示：每个用户每日可以发送三次验证短信</p>            
                                                </ul>
</asp:Content>
