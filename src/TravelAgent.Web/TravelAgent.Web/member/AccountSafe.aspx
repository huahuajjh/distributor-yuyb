<%@ Page Title="" Language="C#" MasterPageFile="~/member/Member.Master" AutoEventWireup="true" CodeBehind="AccountSafe.aspx.cs" Inherits="TravelAgent.Web.member.AccountSafe" %>
<%@ MasterType VirtualPath="~/member/Member.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

                                <div class="security_box"><b>安全级别：</b><strong class="font_weak">弱</strong>建议您通过以下方式提高安全级别，验证手机和邮箱可分别获得<em>100积分</em></div>
                                <ul class="validation">
                                        <li class="ico_login_select"><span></span><p><b>登录密码</b>为了保护您账户和资产的安全，请定期修改您的密码</p><a href="/member/UpdatePassword.aspx">修改密码</a></li>
                                      <li class="<%=ShowMobileValidate() %>"><span></span><p><b>手机验证</b>完成手机验证轻松获得<em><%=Master.webinfo.MobileValidate%>积分</em>验证后可接收订单状态、出团通知等变动提醒，保障您的账户安全。</p><strong><a href="/member/MobileValidate.aspx">立即验证</a></strong></li>
                                        <li class="<%=ShowEmailValidate() %>"><span></span><p><b>邮箱验证</b>完成邮箱验证轻松获得<em><%=Master.webinfo.EmailValidate%>积分</em>验证后可接收订单状态、出团通知等变动提醒，保障您的账户安全。</p><strong><a href="/member/EmailValidate.aspx">立即验证</a></strong></li>
                                </ul>
                        
</asp:Content>
