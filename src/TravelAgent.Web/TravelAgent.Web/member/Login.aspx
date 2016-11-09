<%@ Page Title="" Language="C#" MasterPageFile="~/Other.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TravelAgent.Web.member.Login" %>
<%@ MasterType VirtualPath="~/Other.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<link rel="stylesheet" type="text/css" href="/css/style.css" />
<link rel="stylesheet" type="text/css" href="/member/css/user.css" />
<script type="text/javascript" src="/js/jquery-1.7.2.min.js"></script>
<script src="/js/Validform.js" type="text/javascript"></script> 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <div class="content">
                        <div id="login_box">
                                <img src="/member/images/login_img.jpg" class="login_img" />
                                <span id="sp_tishi"></span>
                                <div class="login">
                                        <span>还不是会员？<a href="/member/Register.aspx" class="f00">免费注册</a> (注册即送<%=webinfo.FristReg %>分)</span>
 
                                        <form id="reguser" action="" onsubmit="return mySubmit();" method="post">
                                                <ul class="user_id">
                                                        <li>用户名：<input name="username" type="text" id="username" value="用户名/手机/邮箱" /><span ></span></li>
                                                        <li>密　码：<input name="password" type="password" id="password" /></li>
                                                </ul>
                                                <span><input name="cooktime" type="checkbox" value="0" />7天内自动登录 <a href="/member/GetPassword.aspx" class="green">忘记密码？</a></span>
                                                <div class="login_button"><input  type="submit" value="" /></div>
                                        </form>
<!--                                        <span>使用合作网站帐号登录</span>
                                        <ul class="login_partner">
                                                <li><img src="/Public/Tours/images/user/ico_sina.gif" /><a href="#">新浪微博</a></li>
                                                <li><img src="/Public/Tours/images/user/ico_pay.gif" /><a href="#">支付宝</a></li>
                                                <li><img src="/Public/Tours/images/user/ico_qq.gif" /><a href="#">QQ账号</a></li>
                                        </ul>-->
                                </div>
                        </div>
                </div>
<script type="text/javascript">
    function mySubmit() {
        var username = $("#username").attr("value");
        var password = $("#password").attr("value");
        if ($.trim(username) == "" || $.trim(username) == "会员名/手机号/邮箱") {
            $("#username").focus(function() {
                $(this).css({ "color": "#999" });
            });
            return false;
        }
        if ($.trim(password) == "") {
            $("#password").focus();
            return false;
        }
        return true;
    }
    $(function() {
        $("#username").click(function() {
            var name = $(this).val();
            if (name == "用户名/手机/邮箱") {
                $(this).val("");
                $(this).css("color", "#000");
            }
        });
        $("#username").blur(function() {
            $("#sp_tishi").text("");
            var username = $.trim($(this).val());
            if (!username || username == "") {
                $(this).val("用户名/手机/邮箱").css("color", "#999");
            }
        });
        $("#password").blur(function() {
            $("#sp_tishi").text("");
            var password = $.trim($(this).val());
            if (!password || password == "") {
            }
        });
    });
    $(function() {
        $("#cooktime").click(function() {
            if ($(this).attr("checked")) {
                $(this).val("1");
            } else {
                $(this).val("0");
            }
        });
        var username = "";
        if (username != "" && username != null) {
            $("#username").val(username);
            $("#username").css("color", "#000000");
        } else {
            $("#username").css("color", "#999");
        }

    });
                </script>

</asp:Content>
