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
                                <span>����ǰλ�ã�</span>
                                <a href="/">��ҳ</a>&gt;
                                <i>ǩ֤����</i>
                        </div>

                </div>
                <div class="visa">
                        <!--��-->
                        <div class="visa_R">
                                <div class="liucheng"><img src="/images/visa_process.jpg"></div>
                                <div class="visa_titile">
                                        <h2>����ǩ֤����</h2>
                                </div>
                                <div class="visa_box">
                                                <%=BindVisaList()%>              
                                </div>
                                <div class="visa_titile">
                                        <h2>ǩ֤�Ƽ�</h2>
                                </div>
                                <div class="qianzheng">
                                        <%=BindVisaDetail() %>                 
                              </div>

                                <div class="visa_titile">
                                        <h2>ǩ֤����ע������</h2>
                                </div>
                                <div class="zhuyi" id="divZYSX" runat="server">
                                        
                                </div>
                        </div>
                        <!--���--> 
                        <div class="visa_L">
                                <div class="visa_L_box_title">
                                        <h3>���Դ�������</h3>
                                </div>
                                <ul class="visa_L_box">
                                        <%=BindBrand(1,3) %>
                                </ul>
                         </div>
                         <div class="visa_L">
                                <div class="visa_L_box_title">
                                        <h3>ǩ֤��Ѷ������</h3>
                                        <span><a target="_blank" href="/newlist/50.html" rel="nofollow">����>></a></span>
                                </div>
                                <ul class="visa_L_box3">
                                       <%=BindNews(50, 5)%>            
                                </ul>
                           </div>
                           <div class="visa_L">
                                <div class="visa_L_box_title">
                                        <h3>ǩ֤֪ʶ</h3>
                                        <span><a target="_blank" href="/Help.aspx?navid=18" rel="nofollow">����>></a></span>
                                </div>
                                <ul class="visa_L_box3">
                                        <%=BindVisaHelp(18)%>
                                </ul>
                        </div>
                </div>
</asp:Content>
