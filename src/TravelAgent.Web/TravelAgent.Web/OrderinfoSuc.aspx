<%@ Page Title="" Language="C#" MasterPageFile="~/Other.Master" AutoEventWireup="true" CodeBehind="OrderinfoSuc.aspx.cs" Inherits="TravelAgent.Web.OrderinfoSuc" %>
<%@ MasterType VirtualPath="~/Other.master" %>
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
                                                                <li>填写订单</li>
                                                                <li>填写游客信息</li>
                                                                <li class="on">核对订单</li>
                                                                <li>付款</li>
                                                                <li>预订成功</li>
                                                        </ul>
                                                </div>
                                <div class="orderWrap">
                                                        <div class="orderSuccess">
                                                                <%--<p class="p1">
                                                                        <em><%=strTip %></em>
                                                                        <%=strSubTip %>
                                                                </p>--%>
			<div class="order_ok">
			<i class="ok"></i>
			<h3>订单提交成功！</h3>
			<p>订单编号：<%=order.ordercode %></p>
			<p><b><a target="_blank" href="/"><%=Master.webinfo.WebCompanyName%></a> 客服人员会尽快处理，并与您联系确认。</b></p>
			<p>如需其它咨询可直接致电：<em><%=Master.webinfo.WebTel%></em></p>
                        <p style="padding-top:10px;"><a style="text-decoration:none;" target="_blank" href="/line/<%=Line.Id %>.html"><%=Line.LineName %></a></p>
			 <p><span class="f60"><%=Line.DealType == Convert.ToInt32(TravelAgent.Tool.EnumSummary.DealType.人工处理) ? "该产品需运营商确认审核，审核通过后进入会员中心付款即可预订成功。" : "该产品无需确认铁定出游，直接付款即可预订成功。"%></span></p>
				<div class="tip_box">
						<div>	<p>
								订单总额：<em><%=order.orderPrice+order.attachPrice%></em>元( <%=order.attachPrice==0?"不含保险":"含保险" %> )&nbsp;&nbsp;&nbsp;&nbsp;预订人数：<em style="font-size:14px;font-family:'Microsoft Yahei',华文黑体,Arail,Verdana,Helvetica,sans-serif;"><%=order.adultNumber %>成人/<%=order.childNumber %>儿童</em></p></div>
 <div style="width:600px; overflow:hidden;border-top: 1px dotted #e6e6e6;">
<div style="width:190px; float:left" >
							<p class="pay">应付金额：<b><%=order.orderPrice+order.attachPrice%></b>元 </p></div>
<div style=" float:left; padding-top:10px;" class="divpay" id="divPay" runat="server"><a href="/lineorder/4/<%=oid %>.html"><input  type="button" onclick="gotoPay()" /></a>
<script type="text/javascript">
    function gotoPay() {
        location.href = "/lineorder/4/"+<%=oid %>+".html";
    }
</script>
</div>


</div>


							 
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
