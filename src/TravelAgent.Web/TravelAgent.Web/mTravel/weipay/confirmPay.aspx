<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="confirmPay.aspx.cs" Inherits="TravelAgent.Web.mTravel.weipay.confirmPay" %>

<!doctype html>
<html>
<head>
<meta charset="utf-8" />
<title>确认支付</title>
<meta name="viewport" content="width=device-width, initial-scale=1.0, user-scalable=0, minimum-scale=1.0, maximum-scale=1.0">
<link type="text/css" rel="stylesheet" href="../css/style.css" />
<link type="text/css" rel="stylesheet" href="../css/yuding.css" />
<script src="../scripts/jquery.js" type="text/javascript"></script>
 <script src="../scripts/lazyloadv3.js" type="text/javascript"></script>
 <script type="text/javascript">
     function SavePay() {
         WeixinJSBridge.invoke('getBrandWCPayRequest', {
             "appId": "<%= webinfo.AppID %>", //公众号名称，由商户传入
             "timeStamp": "<%= TimeStamp %>", //时间戳
             "nonceStr": "<%= NonceStr %>", //随机串
             "package": "<%= Package %>", //扩展包
             "signType": "MD5", //微信签名方式:1.sha1
             "paySign": "<%= PaySign %>" //微信签名
         },
               function(res) {
                   if (res.err_msg == "get_brand_wcpay_request:ok") {
                       // alert("微信支付成功!");
                       //location.href = "weipayok.aspx?dingdanhao=<%= OrderSN %> ";
                       location.href = "../MOrderMsg.aspx?no=<%= OrderSN %>&pr=<%= TotalFee %>&msg=支付成功&class=success";
                   } else if (res.err_msg == "get_brand_wcpay_request:cancel") {
                       alert("用户取消支付!");
                   } else {
                       alert(res.err_msg);
                       alert("支付失败!");
                   }
                   // 使用以上方式判断前端返回,微信团队郑重提示：res.err_msg将在用户支付成功后返回ok，但并不保证它绝对可靠。
                   //因此微信团队建议，当收到ok返回时，向商户后台询问是否收到交易成功的通知，若收到通知，前端展示交易成功的界面；若此时未收到通知，商户后台主动调用查询订单接口，查询订单的当前状态，并反馈给前端展示相应的界面。
               });
     }
    </script>
</head>
<body> 
<form id="form1" runat="server">
<div class = "page_first">
<header class="header"> <a href="javascript:window.history.go(-1);" class="ic_back"></a>
  <h2>确认支付</h2>
  <a href="javascript:;" class="navbtn"><span></span><span></span><span></span></a> </header>
<div id="page_1">
  <div class="m-main">
      <section class="main" id="order-next-m">
        <div class="plr10">
          <div class="order-m">
            <ul>
              <li> 
              
                <label  style="line-height:36px;">订单编号</label>
                <span class="long_name"><%= OrderSN%></span></li>
							<li> 
							        <label>订单名称</label>
							        <span class="t1" id="start_date"><%= Body%></span>
                                    
							</li>
              <li> 
                <label>订单总额</label>
                <span class="price t1" style="width:auto;right:16px;top:5px;color:#f60;">￥ <span  style="font-weight:bold;font-size:22px;color:#f60;"><%= TotalFee%></span> </span></li>
            </ul>
          </div>
        </div>
      </section>
        <div class="plr10">
<div class="form_btn">
    <%--<input type="button" value="确认支付" id="getBrandWCPayRequest" onclick="SavePay()" class="cancel" />     --%>
    <a class="cancel" id="getBrandWCPayRequest" onclick="SavePay()" >微信支付</a>                     
 </div>
        </div>
  </div>
</div>

<!--foot-->
<footer class="copyright">
	<p>
		<%=BindBottonNav(3,3)%>
	</p>
	<p>Copyright &copy; 2015-<%=DateTime.Now.Year %></p>
	<p>技术支持：约游约呗</p>
</footer>
<script type="text/javascript" src="../scripts/script1.js"></script>
<div class="zhedang"></div>
<div class="roboxs">
<div class="roboxs_tit"> 
<a href="../../M_Default.aspx" class="homebtn"></a>
<a href="javascript:;" class="closebtn">×</a>
  <h3>产品分类</h3>
</div>
<div class="theme-popbod-one">
  <div class="m_more_des">				
				<span><a href="../LineList.aspx">特价产品</a></span>
				<span><a href="../LineList.aspx?d=1">出境旅游</a></span>
				<span><a href="../LineList.aspx?d=2">国内旅游</a></span>
				<span><a href="../LineList.aspx?d=3">周边旅游</a></span>
			</div>
</div>
</div>
    <asp:HiddenField ID="hdopenid" runat="server" />
</form>
</body>
</html>