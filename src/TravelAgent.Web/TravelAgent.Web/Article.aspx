<%@ Page Title="" Language="C#" MasterPageFile="~/Common.Master" AutoEventWireup="true" CodeBehind="Article.aspx.cs" Inherits="TravelAgent.Web.Article" %>
<%@ MasterType VirtualPath="~/Common.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<link href="/css/style.css" rel="stylesheet" type="text/css" />
                <link href="/css/about.css" rel="stylesheet" type="text/css" />
                <script src="/js/jquery-1.7.2.min.js" type="text/javascript"></script>
                <script src="/js/about_pic.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<!--顶部-->
<div id="divheadmenu">
                                 
</div>
<!--主体部分-->
                <div class="allbg">
                        <!--面包屑导航-->
                        <div class="place">
                                <span>您当前位置：</span>
                                <a href="/">首页</a>&gt;
                                <em>关于我们</em>
                        </div>
 
                        <div class="aboutbox">
                                <ul class="aboutnav">
                                        <%=BindCategory(3)%>
                                </ul>
                                <div class="aboutcon">
                                        <h1><asp:Literal ID="ltTitle" runat="server"></asp:Literal></h1>
                                        <div class="about_txt" id="divContent" runat="server">
                                                
                                        </div>
                                </div>
                        </div>  
 
 
                        <div class="clear"></div>
                </div>
</asp:Content>
