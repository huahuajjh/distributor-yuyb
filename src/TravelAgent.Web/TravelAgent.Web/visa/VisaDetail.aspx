<%@ Page Title="" Language="C#" MasterPageFile="~/Other.Master" AutoEventWireup="true" CodeBehind="VisaDetail.aspx.cs" Inherits="TravelAgent.Web.visa.VisaDetail" %>
<%@ MasterType VirtualPath="~/Other.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script src="/js/jquery-1.7.2.min.js" type="text/javascript"></script>
    <link href="/css/style.css" rel="stylesheet" type="text/css" />
    <link href="/css/visa.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<!--位置导航-->
                <div class="place1">
                        <div class="placeL">   
                                <span>您当前位置：</span>
                                <a href="/">首页</a>>
                                <a href="/visa/Default.aspx">签证办理</a>>
                                <a href="/visa_<%=visa.countryId %>.html"><%=visa.countryName %>签证办理</a>>
                                <i><%=visa.visaName %></i>
                        </div>

                </div>
                <div class="visa">
                        
                         <!--右-->
                        <div class="visa_R">
                                <div class="liucheng"><img src="/images/visa_process.jpg" /></div>
                                <div class="visa_txt">
                                        <div class="visa_txt_pic"> <img alt="<%=visa.visaName %>" src="<%=visa.picurl %>" /></div>
                                        <div class="visa_txt_con">
                                                <h1><%=visa.visaName %></h1>
                                                <p>办理费用：<i>￥</i><b><%=visa.price==0?"电询":visa.price.ToString() %></b></p>
                                                <p>最长停留时间：<%=visa.stayTime %></p>
                                                <p>有效期：<%=visa.expiryDate %></p>
                                                <p>办理时长：<%=visa.dealTime %></p>                                                
                                        </div>
                                        <div class="visa_txt_yuding"><a rel="nofollow" href="/visa/VisaOrder.aspx?id=<%=visa.id %>" title="立即预订"></a></div>                                        
                                </div>
                                
                                <div class="tishi">
                                        <h2>友情提示</h2>
                                         <%=visa.tips %>                               
                                </div>
                                
                                
                                <div class="visa_titile">
                                        <h2>签证办理所需材料</h2>
                                </div>
                                <div class="cailiao">
                                    <div class="visabox">
                                        <%=visa.needMaterial %>
                                    </div>
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
                                <ul class="visa_L_box3">
                                        <%=BindVisaHelp(18)%>
                                </ul>
                        </div>
                        
                </div>
</asp:Content>
