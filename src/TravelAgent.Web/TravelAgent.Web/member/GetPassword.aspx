<%@ Page Title="" Language="C#" MasterPageFile="~/Other.Master" AutoEventWireup="true" CodeBehind="GetPassword.aspx.cs" Inherits="TravelAgent.Web.member.GetPassword" %>
<%@ MasterType VirtualPath="~/Other.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 <link rel="stylesheet" type="text/css" href="/css/style.css" />
<link rel="stylesheet" type="text/css" href="/member/css/user.css" />
<script type="text/javascript" src="/js/jquery-1.7.2.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div id="content">
<div class="password_title"><b>找回密码</b></div>
	<ul class="password_steps password_steps_1">
      <li class="cur">选择找回密码方式</li>
      <li>输入注册手机/邮箱</li>
      <li>重新设置密码</li>
    </ul>
    <div class="findpassword_way">
    	<h4>请通过以下方式找回您的密码：</h4>
    	<ul class="findpassword_way">
            <li><em class="tel_way"></em><span>手机发送短信找回密码</span><a href="/member/GetPasswordByPhone.aspx">手机找回密码</a></li>
            <li><em class="mail_way"></em><span>邮箱发送邮件找回密码</span><a href="/member/GetPasswordByEmail.aspx">邮箱找回密码</a></li>
   		 </ul>
    </div>
    
</div>
</asp:Content>
