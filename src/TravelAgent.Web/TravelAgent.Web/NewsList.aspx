<%@ Page Title="" Language="C#" MasterPageFile="~/Common.Master" AutoEventWireup="true" CodeBehind="NewsList.aspx.cs" Inherits="TravelAgent.Web.NewsList" %>
<%@ MasterType VirtualPath="~/Common.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<link rel="stylesheet" type="text/css" href="/css/style.css" />
                <link rel="stylesheet" type="text/css" href="/css/news.css" />
                <script src="/js/jquery-1.7.2.min.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="place">
                        <span>您当前位置：</span>
                        <a href="/Default.aspx">首页</a>&gt;
                        <%=strNav%>
                </div>
                <div class="main">
                        <div class="news">
                                <h2><asp:Literal ID="ltTitle" runat="server"></asp:Literal></h2>
                                 <%=BindNewsList() %>
                        </div>
                        <!--右-->
                        <div class="sidebar1">
                                <div class="goods">
                                <script type="text/javascript" src="/Tools/Advert_js.ashx?id=32"></script>
                                </div>

                                <h3>热卖线路</h3>
                                <div class="star">
                                               <%=BindTJLine(5)%>           
                             </div>
                             <h3>人气线路</h3>
                                <div class="star">
                                               <%=BindGZLine(5)%>       
                                </div>
                                <!--<div class="goods2">广告位</div>-->
                        </div>

                </div>
                <script src="js/listmdd.js" type="text/javascript"></script>
</asp:Content>
