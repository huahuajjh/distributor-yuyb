<%@ Page Title="" Language="C#" MasterPageFile="~/member/Member.Master" AutoEventWireup="true" CodeBehind="MyAsk.aspx.cs" Inherits="TravelAgent.Web.member.MyAsk" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <div class="user_title"><b>我的提问</b></div>
        <div class="order">
            <table cellpadding="0" cellspacing="0" border="0" width="770">
              <tbody><tr><th width="60">分类</th><th class="thleft" width="550">标题</th><th width="60">审核状态</th><th width="120">发布时间</th></tr>
                                    <tr><td colspan="4">您还没有提问，点击<a href="http://www.kanghui.cn/ask/add" target="_blank">这里</a>提交你的提问</td></tr>             
             
            </tbody></table>
           <div class="pages"></div>
		</div>
    
</asp:Content>
