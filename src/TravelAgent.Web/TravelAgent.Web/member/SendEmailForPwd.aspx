<%@ Page Title="" Language="C#" MasterPageFile="~/Other.Master" AutoEventWireup="true" CodeBehind="SendEmailForPwd.aspx.cs" Inherits="TravelAgent.Web.member.SendEmailForPwd" %>
<%@ MasterType VirtualPath="~/Other.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<link rel="stylesheet" type="text/css" href="/css/style.css" />
<link rel="stylesheet" type="text/css" href="/member/css/user.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div id="content">
    <div class="password_title"><b>找回密码</b></div>
        <div class="send_email_success">
        <span><img src="/member/images/suess.gif" alt="" /></span>
            <p>我们已经把重置密码的邮件发送至您的邮箱<b class="f00"><%=strEmail %></b>，</p>
                        <p>请登录邮箱并在24小时内通过邮件内的链接继续设置新的密码。</p>
            <p>没有收到？烦请到邮箱的垃圾邮件里找找看，或者<a href="GetPasswordByEmail.aspx">重新发送</a>。</p>
        </div>
</div>
</asp:Content>
