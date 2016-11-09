<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WeiPay.aspx.cs" Inherits="TravelAgent.Web.mTravel.weipay.WeiPay" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
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
           $(function() {
               SavePay();
           })
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
    </form>
</body>
</html>
