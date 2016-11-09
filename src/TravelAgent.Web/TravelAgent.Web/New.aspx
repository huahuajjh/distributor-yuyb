<%@ Page Title="" Language="C#" MasterPageFile="~/Common.Master" AutoEventWireup="true" CodeBehind="New.aspx.cs" Inherits="TravelAgent.Web.New" %>
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
                        <div class="newstxt">
                                <h1>
                    <asp:Literal ID="ltTitle" runat="server"></asp:Literal></h1>
                                <div class="txt_info">来源：<asp:Literal ID="ltSource" runat="server"></asp:Literal> | 时间：<asp:Literal ID="ltDate" runat="server"></asp:Literal></div>
                                <div class="txt_content" id="divContent" runat="server">
                                               
                                </div>
                                 <ul class="prenext">
                                     <%=BindPrevNext() %>
                                  </ul>
                                  <%=BindTuijiancp(2) %>
                                  <%=BindAboutArticle() %>
                        </div>
                        
                        <!--右-->
                        <div class="sidebar1">
                                <div class="goods">
                                <script type="text/javascript" src="/Tools/Advert_js.ashx?id=32"></script>
                                </div>
                                <h3>特价线路</h3>
                                        <ul class="xg_line">
                                             <%=BindTJLine(10)%>            
                                        </ul>                                
                                <h3>最新<%=CateName%></h3>
                                <ul class="new_news">
                                        <%=BindNews(10)%>           
                                </ul>
                        </div>
                </div>
</asp:Content>
