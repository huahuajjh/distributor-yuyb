<%@ Page Title="" Language="C#" MasterPageFile="~/member/Member.Master" AutoEventWireup="true" CodeBehind="UpdateSucMemberName.aspx.cs" Inherits="TravelAgent.Web.member.UpdateSucMemberName" %>
<%@ MasterType VirtualPath="~/member/Member.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

      	<div class="user_title"><b>更改用户名</b></div>
        <div class="steps_img"><img src="/member/images/user_steps_2.gif"></div>
        <div class="verification_success">
        	<span><img src="/member/images/suess.gif"></span>
            <p><strong>您的用户名<b><asp:Literal ID="ltMemberName" runat="server"></asp:Literal></b>，修改成功！</strong>您还可以继续修改<a href="/member/MyInfo.aspx">个人资料</a>，轻松获得<em>100积分</em></p>
        </div>
    
</asp:Content>
