<%@ Page Title="" Language="C#" MasterPageFile="~/member/Member.Master" AutoEventWireup="true" CodeBehind="EmailValidate.aspx.cs" Inherits="TravelAgent.Web.member.EmailValidate" %>
<%@ MasterType VirtualPath="~/member/Member.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script src="/js/formValidatorRegex.js" type="text/javascript"></script>
<script type="text/javascript">
                        var waitHtml = "<img style='margin-right:8px;margin-top:-5px' src=\"/member/images/onLoad.gif\">#";
                        $(function() {
                                $("#sendMail").click(function() {
                                        var result = validateEmail();
                                        if (result == false) {
                                                return false;
                                        }
                                        $("#sendEmailSuccess").hide();
                                        $("#txtEmailTip").removeClass().html(waitHtml.replace("#", "数据提交中，请稍候..."))
                                        $.ajax({
                                                url: "/dataDeal/SendValidateEmail.aspx",
                                                data: { "email": $.trim($("#txtEmail").val()), "clubid": $.cookie('uid') },
                                                type: "post",
                                                success: function(msg) {
                                                        if (msg == "success") {
                                                                $("#txtEmailTip").removeClass().html(waitHtml.replace("#", "邮件发送中，请稍候..."))
                                                                regTimeMinus(5);
                                                        } else if (msg.indexOf("exists") > 0) {
                                                                $("#txtEmailTip").removeClass().addClass("submitError").html("您的邮箱地址已经被使用");
                                                        } else if (msg.indexOf("threeError") > 0) {
                                                                $("#txtEmailTip").removeClass().addClass("submitError").html("三次邮件验证发送机会已用完");
                                                        } else if (msg != "") {
                                                                $("#txtEmailTip").removeClass().addClass("submitError").html(msg);
                                                        }
                                                },
                                                error: function() {
                                                        $("#txtEmailTip").removeClass().html("");
                                                        $("#sendEmailSuccess").hide();
                                                        alert("系统繁忙，请稍候再试...", "");
                                                }
                                        });
                                });

                                if ($("#txtEmail").val() === "") {
                                        $("#txtEmail").focus(function() {
                                                $("#txtEmailTip").removeClass().addClass("submitFocus").html("请填写您的邮箱地址");
                                        });
                                }
                                $("#txtEmail").blur(function() {
                                        validateEmail();
                                });
                        });

                        function validateEmail() {
                                var email = $.trim($("#txtEmail").val());
                                if (email == "") {
                                        $("#txtEmailTip").removeClass().addClass("submitError").html("请填写您的邮箱地址");
                                        return false;
                                }
                                var emailReg = new RegExp(regexEnum.email);
                                if (!emailReg.test(email)) {
                                        $("#txtEmailTip").removeClass().addClass("submitError").html("您的邮箱地址格式不正确");
                                        return false;
                                }
                                $("#txtEmailTip").removeClass().html("");
                                return true;
                        }

                        function regTimeMinus(t) {
                                if (t > 1) {
                                        isSendEmail = true;
                                        t = t - 1; //执行完后，再次执行
                                        timeCode = window.setTimeout("regTimeMinus(" + t + ")", 1000);
                                }
                                else if (t <= 1) {
                                        //$('#' + btn).css("display", "inline").attr('disabled', false);
                                        $("#txtEmailTip").removeClass().html("");
                                        $("#sendMail").text("重新发送验证邮件");
                                        $("#sendEmailSuccess").show();
                                }
                        }
                </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

                                <div class="user_title"><b>邮箱验证</b></div>
                                <div class="steps_img"><img src="/member/images/mail_steps_1.gif"></div>
                                                <ul class="validation_tel">
                                                        <li><span><em>*</em>邮箱地址：</span><input name="txtEmail" id="txtEmail" value="<%=club.clubEmail %>" type="text"><a href="javascript:" class="distortion" id="sendMail">发送验证邮件</a><p class="prompt_error" id="txtEmailTip"></p></li>
                                                        <li id="sendEmailSuccess" style="display: none;"><span>&nbsp;</span><em>验证邮件已发出，请注意查收。</em>如果没收到，点击“重新发送验证邮件”按钮。</li>
                                                        <li><span>&nbsp;</span>温馨提示：每个用户每日可以发送三次验证邮件</li>            
                                                </ul>                        
</asp:Content>
