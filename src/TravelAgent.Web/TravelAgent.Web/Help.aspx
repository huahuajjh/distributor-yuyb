<%@ Page Title="" Language="C#" MasterPageFile="~/Other.Master" AutoEventWireup="true" CodeBehind="Help.aspx.cs" Inherits="TravelAgent.Web.Help" %>
<%@ MasterType VirtualPath="~/Other.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<link type="text/css" rel="stylesheet" href="/css/style.css"/>
<link type="text/css" rel="stylesheet" href="/css/help.css"/>
<script type="text/javascript" src="/js/jquery-1.7.2.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="place1">
                        <span>您当前位置：</span>
                        <a href="/">首页</a>&gt;
                        <em>帮助中心</em>
                </div>
<div class="main">
                        <div class="title">
                                <h1>帮助中心</h1>
                                <span>Help Center</span>
                        </div>
                        <!--边栏-->
                        <div class="sidebar">
                                <ul>
                                        <%=BindCategory(4)%>
                                </ul>
                        </div>


                        <!--主体内容部分-->
                        <div class="content">
                                <div id="tab_help_1">
                                        <h3>
    <asp:Literal ID="ltTitle" runat="server"></asp:Literal></h3>
                                        <div class="con" id="divContent" runat="server">                                       
                                                
                                        </div>
                                </div>
                        </div>
                </div> 
</asp:Content>
