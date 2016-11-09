<%@ Page Title="" Language="C#" MasterPageFile="~/Other.Master" AutoEventWireup="true" CodeBehind="VisaMore.aspx.cs" Inherits="TravelAgent.Web.visa.VisaMore" %>
<%@ MasterType VirtualPath="~/Other.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script src="/js/jquery-1.7.2.min.js" type="text/javascript"></script>
    <link href="/css/style.css" rel="stylesheet" type="text/css" />
    <link href="/css/visa.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="place1">
                        <div class="placeL">   
                                <span>您当前位置：</span>
                                <a href="/">首页</a>&gt;
                                <a href="/visa/Default.aspx">签证办理</a>&gt;
                                <i><%=strVisaName %>签证办理</i>
                        </div>
                </div>
                <div class="visa">

                        <!--右-->
                        <div class="visa_R">
                                <div class="visa_list">
                                        <img src="<%=strPicUrl %>">
                                        <h1><%=strVisaName %>签证办理</h1>
                                </div>

                                <div class="visa_list_con">
                                                <%=BindVisaList() %>                    
                                </div>
                                
                                <div class="visa_titile">
                                        <h2>签证办理温馨提示</h2>
                                </div>
                                <div class="zhuyi" id="divZYSX" runat="server">
                                      
                                </div>

                        </div>


                        <!--左--> 
                        <div class="visa_L">
                                <div class="visa_L_box_title">
                                        <h3>康辉代办优势</h3>
                                </div>
                                <ul class="visa_L_box">
                                        <%=BindBrand(1,3) %>
                                </ul>

                                <div class="visa_L_box_title">
                                        <h3>签证知识</h3>
                                        <span><a target="_blank" href="/Help.aspx?navid=18" rel="nofollow">更多>></a></span>
                                </div>
                                <ul class="visa_L_box2">
                                        <%=BindVisaHelp(18)%>
                                </ul>
                        </div>

                </div>
</asp:Content>
