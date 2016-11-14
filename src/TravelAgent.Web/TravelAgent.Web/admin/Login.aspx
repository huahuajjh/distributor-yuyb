<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TravelAgent.Web.admin.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<%--<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />--%>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>约游约呗供应商管理后台-后台登录</title>
<link href="/admin/css/style.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="/admin/js/jquery.js"></script>
<%--<script type="text/javascript" src="/js/cloud.js" ></script>--%>
<script type="text/javascript" src="/js/jquery.cookie.js"></script>
    
<script type="text/javascript">
    $(function () {
        //let the account input obtain focus, written by jjh
        letAccInputGetFocus();

        //cookie settings, comment was written by jjh, not function's implement
        var username = $.cookie('loginname') == null ? "" : $.cookie('loginname');
        var password = $.cookie('loginpwd') == null ? "" : $.cookie('loginpwd');
        var checkv = $.cookie('isremember') == "1";
        $("#user").val(username);
        $("#pwd").val(password);
        $("#isRemember").attr("checked", checkv);

        $('.loginbox').css({ 'position': 'absolute', 'left': ($(window).width() - 692) / 2+'px' });
        $(window).resize(function() {
            $('.loginbox').css({ 'position': 'absolute', 'left': ($(window).width() - 692) / 2+'px' });
        });

        //login, written by jjh
        $("#btnLogin").click(function() {
            login();
        })

        //enter key event for login, written by jjh
        document.onkeydown = function (e) {
            if(e.keyCode == 13){
                login();
            }
        }

    });

    //login function, written by jjh
    function login() {
        var user = $.trim($("#user").val());
        var pwd = $.trim($("#pwd").val());
        var remember = $("#isRemember").attr("checked") ? 1 : 0;

        //input check
        if (user == "") {
            alert("请输入用户名！");
            $("#user").focus();
            return false; //why return a boolean value? this comment was written by jjh
        }

        if (pwd == "") {
            alert("请输入密码！");
            $("#pwd").focus();
            return false; //why return a boolean value? this comment was written by jjh
        }

        //request login asyn
        $.ajax({
            type: "POST",
            url: "/admin/data/Admin.ashx",
            cache: false,
            dataType: "json",
            data: { user_name: user, user_pwd: pwd, check: remember },
            success: function (state) {
                //提示删除成功消息
                if (state.msg == "true") {
                    location.href = state.location;
                    return false;
                }
                else if (state.msg == "islock") {
                    alert("您的账号已被锁定，请联系运营商！");
                    $("#user").val("");
                    $("#pwd").val("");
                    return false;
                }
                else {
                    alert("用户名或者密码错误，请重新输入！");
                    $("#pwd").val("");
                    return false;
                }
            }
        })
        return false;
    }

    //make the account form element gets focus, written by jjh
    function letAccInputGetFocus() {
        document.getElementById("user").focus();
    }

</script>

</head>

<body style="background-color:#1c77ac; background-image:url(images/light.png); background-repeat:no-repeat; background-position:center top; overflow:hidden;" defaultButton="btnLogin">



    <div id="mainBody">
      <div id="cloud1" class="cloud"></div>
      <div id="cloud2" class="cloud"></div>
    </div>  


<div class="logintop">    
    <span>欢迎登录TravelCMS旅行社网站管理系统</span>    
    <ul>
    <li><a href="/Default.aspx">网站首页</a></li>
    <li><a href="#">关于TravelCMS</a></li>
    </ul>    
    </div>
    
    <div class="loginbody">
    
    <div  style="height:71px; text-align:center; width:100%; margin-top:40px;"><img src="images/logo.png" /></div> 
       
    <div class="loginbox">
   <form id="formLogin" runat="server">
    <ul>
    <li><input id="user" name="user" type="text" class="loginuser" value="" onclick="JavaScript:this.value=''" runat="server"/></li>
    <li><input id="pwd" name="pwd" type="password" class="loginpwd" value=""  runat="server"/></li>
    <li><input id="btnLogin" name="btnLogin" type="button" class="loginbtn" value="登录"  /><label><input id="isRemember" name="isRemember" type="checkbox" runat="server" />记住用户名和密码</label></li>
    </ul>
    </form>
    
    
    </div>
    
    </div>
    
    
    
    <div class="loginbm">版权所有  2015-<%=DateTime.Now.Year %>  Designed by 开心闯天下</div>
	
    
</body>

</html>
