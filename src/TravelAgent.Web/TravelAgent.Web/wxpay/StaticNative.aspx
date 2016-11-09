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
                                                                        <!--�������� START-->
                                                                        <div class="orderStep">
                                                                                <ul class="step4">
                                                                                        <li>��д����</li>
                                                                                        <li>��д�ο���Ϣ</li>
                                                                                        <li>�˶Զ���</li>
                                                                                        <li class="on">΢��ɨ��֧��</li>
                                                                                        <li>Ԥ���ɹ�</li>
                                                                                </ul>
                                                                        </div>
                                                                        <!--�������� END-->
                                                                        <div class="orderWrap" style="font-size:14px;">
                                                                                <div style="height:40px;"></div>
                                                                                <div style="text-align:center">�����ţ�<span style=" font-weight:bold; color:#ff6600;"><%=order_no%></span><br /><br />
                                                                                 �۸�<span style=" font-weight:bold; color:#ff6600;"><%=order_price%></span>Ԫ<br /><br /></div>
                                                                                <div align=center id="notpay" >
                                                                                 ΢��ɨ���ά�����֧��<br /><br />
                                                                                <img id="Img1" src="WxPay.ashx?action=nativestatic&product_id=<%=order_no%>" width="250" height="250"/>
                                                                                </div>
	                                                                            <div id="ispay"  style="margin-left:20px; font-size:16px ; font-weight:bold;text-align:center;display:none">
	                                                                                <table style="width:300px;">
	                                                                                    <tr>
	                                                                                        <td><img src="../images/pok.gif" /></td>
	                                                                                        <td> <span style="color:#ff6600;">֧���ɹ� !�������⣬����ѯ <%=Master.webinfo.WebTel %></span></td>
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
