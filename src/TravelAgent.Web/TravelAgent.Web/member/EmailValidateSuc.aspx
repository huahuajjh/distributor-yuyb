<%@ Page Title="" Language="C#" MasterPageFile="~/member/Member.Master" AutoEventWireup="true" CodeBehind="EmailValidateSuc.aspx.cs" Inherits="TravelAgent.Web.member.EmailValidateSuc" %>
<%@ MasterType VirtualPath="~/member/Member.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="user_title"><b>邮箱验证</b></div>
                                <div class="steps_img"><img src="/member/images/mail_steps_2.gif" /></div>
                                                <ul class="validation_tel">
                                                        <li style="height: 150px;"><p style="margin: auto;margin-left: 30%;"> <img src="/member/images/suess.gif"></p></li>
                                                        <li ><p>  
                                                                        <div class="success_text fl" style="color: red;">
                                                                                <p class="success_text_tg">您的邮箱<b><asp:Literal ID="ltEmail" runat="server"></asp:Literal></b>验证成功！</p>
                                                                                <p>邮箱验证成功赠送<span class="success_ub"><%=webinfo.EmailValidate %>积分</span>，您可以去<a href="/member/MyPoints.aspx" title="我的积分">我的积分&gt;&gt;</a>中查收</p>
                                                                        </div> 
                                                                </p></li>
                                                </ul>                       

</asp:Content>
