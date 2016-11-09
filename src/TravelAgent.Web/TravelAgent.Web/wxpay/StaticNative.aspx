<%@ Page Title="" Language="C#" MasterPageFile="~/Other.Master" AutoEventWireup="true" CodeBehind="StaticNative.aspx.cs" Inherits="TravelAgent.Web.wxpay.StaticNative" %>
<%@ MasterType VirtualPath="~/Other.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 <link type="text/css" rel="stylesheet" href="/css/style.css"/>
<link href="/css/order.css" rel="stylesheet" type="text/css" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<script src="js/jquery-1.9.0.js" type="text/javascript"></script>
<script type="text/javascript">
    function Get_Pay_Status() {
        var order_no = $('#order_no').val();
        $.ajax({
            type: 'GET',
            url: 'WxPay.ashx',
            dataType: "json",
            data: {
                action: "GetOrderStatus",
                order_no: order_no
            },
            async: false,
            cache: false,
            success: function(res) {
                if (res.flag == 'true') {
                    $("#notpay").css('display', 'none')
                    $("#ispay").css('display', 'block')
                }
            },
            error: function() {
            }
        });
    }
    $(document).ready(function() {
        setInterval(Get_Pay_Status, 1000);
    });
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="order">
                                <div id="page">
                                                        <form id="formpay" method="post" action="/PayApi/Submit.aspx" target="_blank">
                                                                <div class="order">
                                                                        <!--订单步骤 START-->
                                                                        <div class="orderStep">
                                                                                <ul class="step4">
                                                                                        <li>填写订单</li>
                                                                                        <li>填写游客信息</li>
                                                                                        <li>核对订单</li>
                                                                                        <li class="on">微信扫码支付</li>
                                                                                        <li>预订成功</li>
                                                                                </ul>
                                                                        </div>
                                                                        <!--订单步骤 END-->
                                                                        <div class="orderWrap" style="font-size:14px;">
                                                                                <div style="height:40px;"></div>
                                                                                <div style="text-align:center">订单号：<span style=" font-weight:bold; color:#ff6600;"><%=order_no%></span><br /><br />
                                                                                 价格：<span style=" font-weight:bold; color:#ff6600;"><%=order_price%></span>元<br /><br /></div>
                                                                                <div align=center id="notpay" >
                                                                                 微信扫描二维码进行支付<br /><br />
                                                                                <img id="Img1" src="WxPay.ashx?action=nativestatic&product_id=<%=order_no%>" width="250" height="250"/>
                                                                                </div>
	                                                                            <div id="ispay"  style="margin-left:20px; font-size:16px ; font-weight:bold;text-align:center;display:none">
	                                                                                <table style="width:300px;">
	                                                                                    <tr>
	                                                                                        <td><img src="../images/pok.gif" /></td>
	                                                                                        <td> <span style="color:#ff6600;">支付成功 !如有问题，请咨询 <%=Master.webinfo.WebTel %></span></td>
	                                                                                    </tr>
	                                                                                </table>
		                                                                           
	                                                                            </div>
                                                                                <input name="order_no" id="order_no" type="hidden" value="<%=order_no%>" >
                                                                                <div style="height:40px"></div>
                                                                        </div>
                                                                </div>
                                                                
                                                        </form>
                                                      
                                                </div>                        </div>
</asp:Content>
