<%@ Page Title="" Language="C#" MasterPageFile="~/Other.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TravelAgent.Web.visa.Default" %>
<%@ MasterType VirtualPath="~/Other.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script src="/js/jquery-1.7.2.min.js" type="text/javascript"></script>
    <link href="/css/style.css" rel="stylesheet" type="text/css" />
    <link href="/css/visa.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="place1">

                        <div class="placeL">   
                                <span>您当前位置：</span>
                                <a href="/">首页</a>&gt;
                                <i>签证办理</i>
                        </div>

                </div>
                <div class="visa">
                        <!--右-->
                        <div class="visa_R">
                                <div class="liucheng"><img src="/images/visa_process.jpg"></div>
                                <div class="visa_titile">
                                        <h2>热门签证国家</h2>
                                </div>
                                <div class="visa_box">
                                                <%=BindVisaList()%>              
                                </div>
                                <div class="visa_titile">
                                        <h2>签证推荐</h2>
                                </div>
                                <div class="qianzheng">
                                        <%=BindVisaDetail() %>                 
                              </div>

                                <div class="visa_titile">
                                        <h2>签证办理注意事项</h2>
                                </div>
                                <div class="zhuyi" id="divZYSX" runat="server">
                                        
                                </div>
                        </div>
                        <!--左边--> 
                        <div class="visa_L">
                                <div class="visa_L_box_title">
                                        <h3>康辉代办优势</h3>
                                </div>
                                <ul class="visa_L_box">
                                        <%=BindBrand(1,3) %>
                                </ul>
                         </div>
                         <div class="visa_L">
                                <div class="visa_L_box_title">
                                        <h3>签证资讯及公告</h3>
                                        <span><a target="_blank" href="/newlist/50.html" rel="nofollow">更多>></a></span>
                                </div>
                                <ul class="visa_L_box3">
                                       <%=BindNews(50, 5)%>            
                                </ul>
                           </div>
                           <div class="visa_L">
                                <div class="visa_L_box_title">
                                        <h3>签证知识</h3>
                                        <span><a target="_blank" href="/Help.aspx?navid=18" rel="nofollow">更多>></a></span>
                                </div>
                                <ul class="visa_L_box3">
                                        <%=BindVisaHelp(18)%>
                                </ul>
                        </div>
                </div>
</asp:Content>
