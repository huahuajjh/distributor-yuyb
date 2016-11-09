<%@ Page Title="" Language="C#" MasterPageFile="~/member/Member.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="TravelAgent.Web.member.Index" %>
<%@ MasterType VirtualPath="~/member/Member.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
                            <div class="heads">
                                    <div class="heads_pic"><a href="/user/info#avator"><img src="/member/images/clubpic.gif"></a></div>
                                    <div class="heads_txt">
                                            <p><b> <%=club.clubName %></b>,您好！<a href="/member/MyInfo.aspx">完善个人资料&gt;&gt;</a></p>
                                            <div>安全级别：<span class="<%=strPasswordStrengthcss %>"><em>弱</em><em>中</em><em>强</em></span><a href="/member/MobileValidate.aspx"><%=ShowMobileValidate()%></a>
                                                    <a href="/member/EmailValidate.aspx"><%=ShowEmailValidate()%></a>                                                        绑定邮箱可在忘记密码时顺利找回   
                                                    <a href="/member/AccountSafe.aspx">安全设置</a></div>
                                            <p>积分数量：<b><%=club.currentPoints %> </b><a href="/member/MyPoints.aspx">查看</a></p>
                                    </div>
                            </div>
                            <div class="user_title"><b>近期订单</b></div>
                            <div class="order">
                                    <table width="770" border="0" cellspacing="0" cellpadding="0">
                                            <tbody>
                                            <tr>
                                            <th width="150">订单编号</th>
                                            <th width="200" class="thleft">产品信息</th>
                                            <th width="80">订单类型</th>
                                            <th width="80">订单金额</th>
                                            <th width="60">订单状态</th>
                                            <th width="100">下单时间</th>
                                            <th width="100">操作</th>
                                            </tr>
                                            <%=ShowLineOrder() %>
                                    </tbody>
                                    </table>
                            </div>
</asp:Content>
