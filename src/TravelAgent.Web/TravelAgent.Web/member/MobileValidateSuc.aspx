<%@ Page Title="" Language="C#" MasterPageFile="~/member/Member.Master" AutoEventWireup="true" CodeBehind="MobileValidateSuc.aspx.cs" Inherits="TravelAgent.Web.member.MobileValidateSuc" %>
<%@ MasterType VirtualPath="~/member/Member.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="user_title"><b>手机验证</b></div>
                                <div class="steps_img"><img src="/member/images/tel_steps_2.gif" /></div>
                                                <ul class="validation_tel">
                                                        <li style="height: 200px;"><p style="margin: auto;margin-left: 30%;"> <img src="/member/images/suess.gif"></p></li>
                                                        <li ><p>  
                                                                        <div class="success_text fl" style="color: red;">
                                                                                <p class="success_text_tg">您的手机<b><asp:Label ID="lblTel" runat="server" Text=""></asp:Label></b>验证成功！</p>
                                                                                <p>手机验证成功赠送<span class="success_ub"><%=webinfo.MobileValidate %>积分</span>，您可以去<a href="/member/MyPoints.aspx" title="我的积分">我的积分&gt;&gt;</a>中查收</p>
                                                                        </div> 
                                                                </p></li>
                                                </ul>                       
</asp:Content>
