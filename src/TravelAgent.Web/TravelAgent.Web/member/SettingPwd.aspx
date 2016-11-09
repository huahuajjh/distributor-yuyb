<%@ Page Title="" Language="C#" MasterPageFile="~/Other.Master" AutoEventWireup="true" CodeBehind="SettingPwd.aspx.cs" Inherits="TravelAgent.Web.member.SettingPwd" %>
<%@ MasterType VirtualPath="~/Other.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 <link rel="stylesheet" type="text/css" href="/css/style.css" />
<link rel="stylesheet" type="text/css" href="/member/css/user.css" />
<script type="text/javascript" src="/js/jquery-1.7.2.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div id="content">
<div class="password_title"><b>找回密码</b></div>
	<ul class="password_steps password_steps_3">
      <li>选择找回密码方式</li>
      <li>输入注册邮箱</li>
      <li class="cur">重新设置密码</li>
    </ul>
    <ul class="change_password">
            <form id="form1" method="post" action="/dataDeal/PassWord2.aspx" >
            <div class="password_tel_strong"><i class="on1">弱</i><i class="on2">中</i><i class="on3">强</i></div>
            <li><span>您用于登录的用户名为：</span><b class="f00"><%=struser %></b><input type="hidden" name="txtEmail" value="<%=struser %>" /></li>
            <li><span><em>*</em>请输入新密码：</span><input id="txtPwd"  type="password" name="txtPwd" onblur="checkPwdLevel()" onkeyup="checkPwdLevel()" /><p id="txtPwdTip" class="prompt_write"></p></li>
            <li><span><em>*</em>请再次输入新密码：</span><input  type="password" id="txtRePwd" name="txtRePwd"  /> <p id="txtRePwdTip" class="prompt_write"></p></li>
            <li><span>&nbsp;</span><div class="sure"><button type="submit" name="button" >提交</button></div></li>
             </form>
    </ul>
</div>
<script src="/member/js/password.js" type="text/javascript"></script>
<script src="/member/js/formValidator-4.1.1.js" type="text/javascript"></script>
<script src="/member/js/theme.js" type="text/javascript"></script>
<script src="/member/js/formValidatorRegex.js" type="text/javascript"></script> 
<script src="/member/js/findPwd.js" type="text/javascript"></script>
</asp:Content>
