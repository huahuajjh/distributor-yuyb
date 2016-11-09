<%@ Page Title="" Language="C#" MasterPageFile="~/Other.Master" AutoEventWireup="true" CodeBehind="CarOrder2.aspx.cs" Inherits="TravelAgent.Web.car.CarOrder2" %>
<%@ MasterType VirtualPath="~/Other.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<link type="text/css" rel="stylesheet" href="/css/style.css"/>
<link href="/css/order.css" rel="stylesheet" type="text/css" />
<script src="/js/jquery-1.7.2.min.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<!--预订部分开始-->
                <div id="page">
                        <div id="xs2" class="xs" style="text-align: center; display: none;">
                                <img src="/images/loading.gif" />
                                <br />
                                正在提交，请稍后。。。
                        </div>
                        <div class="order">
                                <div class="orderStep">
                                                        <ul class="step3">
                                                              <li>选择产品</li>
                                                                <li>确认订单</li>
                                                                <li class="on">提交审核</li>
                                                                <li>在线付款</li>
                                                                <li>预订成功</li>
                                                        </ul>
                                                </div>
                                <div class="orderWrap">
                                                        <div class="orderSuccess">
			<div class="order_ok">
			<i class="ok"></i>
			<h3>订单提交成功！</h3>
			<p>订单编号：</p>
			<p><b><a target="_blank" href="/"><%=Master.webinfo.WebCompanyName%></a> 客服人员会尽快处理，并与您联系确认。</b></p>
			<p>如需其它咨询可直接致电：<em><%=Master.webinfo.WebTel%></em></p>
			 <p><span class="f60"><%=CarPriceModel.DealType == Convert.ToInt32(TravelAgent.Tool.EnumSummary.DealType.人工处理) ? "该产品需运营商确认审核，审核通过后进入会员中心付款即可预订成功。" : "该产品无需确认，直接付款即可预订成功。"%></span></p>
			<div>
			    <table class="tborderinfo">
			        <tr class="ttr">
			            <td>租车名称</td>
			            <td>用车日期</td>
			            <%=CarPriceModel.CarTypeID==2?"<td>还车日期</td>":""%>
			            <td>数量</td>
			            <td>联系人</td>
			            <td>联系电话</td>
			            <td>应付金额</td>
			        </tr>
			        <tr>
			            <td><a href="/car/CarDetail.aspx?id=<%=cid %>" target="_blank">
                            <%=CarModel.CarName%></a> </td>
			            <td><%=order.usedate %></td>
			            <%=CarPriceModel.CarTypeID==2?"<td>"+order.huandate+"</td>":""%>
			            <td><%=order.account %></td>
			            <td><%=order.contactName %></td>
			            <td><%=order.contactMobile %></td>
			            <td><span style="color:#f60; font-weight:bold; font-size:16px;"><%=order.orderPrice %></span> 元</td>
			        </tr>
			    </table>
			</div>
			<div class="wx_tips">
				<b>温馨提示：</b>
				<p>因近期电信、移动等运营商整治垃圾短信，可能造成短信通道发送延迟，或无法正常接收订单消息。为了不影响您的正常出行，建议您下订单后，直接电话联系旅行社进行确认，给您带来的不便敬请理解！ </p>
			</div>
			</div>
                                                                <div class="orderSuccessDetail">
                                                                        <div class="d1">
                                                                                <p class="pT">温馨提示</p>
                                                                                <p class="p2">
                                                                                        订单提交后如需修改订单（变更线路、日期、人数等），请致电网站客服电话：<%=Master.webinfo.WebTel %>。<br />
                                                                                </p>
                                                                        </div>
                                                                        <div class="d2">
                                                                                <p class="pT">您可以：</p>
                                                                                <p class="p3">
                                                                                        <a href="/member/LineOrder.aspx">去我的订单>></a>，查看订单信息<br />
                                                                                        <a href="/">去网站首页>></a>，浏览更多优惠旅游线路
                                                                                </p>
                                                                        </div>
                                                                        <div class="clearfix"></div>
                                                                </div>
                                                        </div>
                                                </div>                        </div>
                </div>

</asp:Content>
