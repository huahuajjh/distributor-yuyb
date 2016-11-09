<%@ Page Title="" Language="C#" MasterPageFile="~/Common.Master" AutoEventWireup="true" CodeBehind="Theme.aspx.cs" Inherits="TravelAgent.Web.Theme" %>
<%@ MasterType VirtualPath="~/Common.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<link href="/css/style.css" rel="stylesheet" type="text/css" />
                <link href="/css/theme.css" rel="stylesheet" type="text/css" />
                <script src="/js/jquery-1.7.2.min.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div id="divheadmenu">
                                 
</div>
<!--主体部分-->
                <div class="photobox">
                        <div class="place">
                                <span>您当前位置：</span>
                                <a href="/">首页</a>&gt;
                                <em>主题旅游</em>
                        </div>
                        <ul class="photo">
                                <%=BindThemeNav()%>                      
                       </ul>
                </div>
                <div class="main">
                        <!--left-->
                        <div class="themelist">
                                <%=BindLine()%>                
                         </div>
                        <!--right-->
                        <div class="sidebar">
                                <h3>特价线路</h3>
                                <ul class="th_line">
                                        <%=BindTejiaLine(Convert.ToInt32(TravelAgent.Tool.EnumSummary.State.特价), 10)%>
                                </ul>
                                <h3>最新游记攻略</h3>
                                <ul class="hot_search">
                                     <%=BindNews(49,10)%>                                
                                </ul>
                        </div>
                </div>
</asp:Content>
