using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TravelAgent.Tool;
using TravelAgent.Model;
using TravelAgent.BLL;
namespace TravelAgent.Web.PayApi
{
    public partial class Submit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int payType = Convert.ToInt32(Request["hdPayType"]);
            if (payType == Convert.ToInt32(EnumSummary.PayType.支付宝))
            {
                Response.Write("<script>top.location.href='Alipay/alipay_default.aspx"
                + "?out_trade_no=" + Request.Form["ordercode"]
                + "&total_fee=" + Convert.ToDouble(Request.Form["channel_amount"])
                + "&body="+""
                + "&orderid=" + Convert.ToInt32(Request["order_id"])
                + "&ordertype=" +Request.Form["hdTag"]
                + "&points=" + Request.Form["txt_points"]
                + "&donatep=" + Request.Form["hddonatePoints"]
                + "&subject=" + System.Web.HttpUtility.UrlEncode(Request.Form["ordername"])
                + "';</script>");
            }
            else if (payType == Convert.ToInt32(EnumSummary.PayType.网银在线))
            {
                Response.Write("<script>top.location.href='Chinabank/Send.aspx"
                + "?out_trade_no=" + Request.Form["ordercode"]
                + "&total_fee=" + Convert.ToDouble(Request.Form["channel_amount"])
                + "&body=" + ""
                + "&orderid=" + Convert.ToInt32(Request["order_id"])
                + "&ordertype=" + Request.Form["hdTag"]
                + "&points=" + Request.Form["txt_points"]
                + "&donatep=" + Request.Form["hddonatePoints"]
                + "&subject=" + System.Web.HttpUtility.UrlEncode(Request.Form["ordername"])
                + "';</script>");
            }
        }
    }
}
