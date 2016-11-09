<%@ Page Title="" Language="C#" MasterPageFile="~/Common.Master" AutoEventWireup="true" CodeBehind="ThemeModel.aspx.cs" Inherits="TravelAgent.Web.ThemeModel" %>
<%@ MasterType VirtualPath="~/Common.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="/css/style.css" rel="stylesheet" type="text/css" />
                <link href="/css/theme.css" rel="stylesheet" type="text/css" />
                <script src="/js/jquery-1.7.2.min.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="divheadmenu">
                                 
     </div>
                <div class="themepic" style="background: url(<%=strBackgroudUrl%>) no-repeat;">
                        <div class="place">
                                <span>您当前位置：</span>
                                <a href="/">首页</a>&gt;
                                <a href="/Theme.aspx">主题旅游</a>&gt;
                                <em><asp:Literal ID="ltTitle" runat="server"></asp:Literal></em>
                        </div>
                </div>
                <!--主体部分-->
                <div class="main">
                        <div class="theme_lt">
                                <%=BindlistLine() %>
                        </div>
 
                        <!--right-->
                        <div class="sidebar2">
                                <h4>特价线路</h4>
                                <ul class="th_line">
                                        <%=BindTejiaLine(Convert.ToInt32(TravelAgent.Tool.EnumSummary.State.特价), 10)%>    
                            </ul>
                        </div>
                </div>
                <div class="clear"></div>
</asp:Content>
