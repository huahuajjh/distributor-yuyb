<%@ Page Title="" Language="C#" MasterPageFile="~/Other.Master" AutoEventWireup="true" CodeBehind="GetPasswordByEmail.aspx.cs" Inherits="TravelAgent.Web.member.GetPasswordByEmail" %>
<%@ MasterType VirtualPath="~/Other.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<link rel="stylesheet" type="text/css" href="/css/style.css" />
<link rel="stylesheet" type="text/css" href="/member/css/user.css" />
<script type="text/javascript" src="/js/jquery-1.7.2.min.js"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div id="content">
<div class="password_title"><b>找回密码</b></div>
	<ul class="password_steps password_steps_2">
      <li>选择找回密码方式</li>
      <li class="cur">输入注册邮箱</li>
      <li>重新设置密码</li>
    </ul>
    <ul class="change_password">
            <form name="form2" method="post" action="/member/SendEmailForPwd.aspx" class="fm" id="form2">
            <li><span><em>*</em>您注册时用的邮箱地址：</span>  <input type="text" value="" name="email" id="email"><p id="emailTip" class="prompt_write" style="margin: 0px; padding: 0px; background: none repeat scroll 0% 0% transparent; display: none;"></p></li>
            <li class="password_code"><span>验证码：</span> <input type="text" class="input02" maxlength="4" name="verify" id="verify">
                    <img src="/RandomImage.aspx" style="cursor: pointer; margin-right:5px;" title="看不清，换一张?" alt="看不清，换一张" width="80px" height="25" id="img1" border="0" onclick='javascript:this.src = "/RandomImage.aspx?t=" + new Date().toUTCString();' />
                    <p id="verifyTip" class="prompt_write" style="margin: 0px; padding: 0px; background: none repeat scroll 0% 0% transparent; display: inline;"></p></li>
            <li><span>&nbsp;</span><div class="sure"><button type="submit">提交</button></div></li>
             </form>
            <p>温馨提示：·如果您忘记注册时填写邮箱地址，请联系客服 <span style="color:Red"><%= Master.webinfo.WebTel%></span> 帮助找回。</p>            
    </ul>
</div>
<script src="/member/js/formValidator-4.1.1.js" type="text/javascript"></script>
<script src="/member/js/theme.js" type="text/javascript"></script>
<script src="/member/js/formValidatorRegex.js" type="text/javascript"></script> 
<script src="/member/js/findPwd.js" type="text/javascript"></script>
</asp:Content>
