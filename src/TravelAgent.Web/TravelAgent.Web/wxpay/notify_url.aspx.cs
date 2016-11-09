using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Web.Configuration;
using TravelAgent.WxPay;

namespace TravelAgent.Web.wxpay
{
    public partial class notify_url : TravelAgent.Web.UI.mBasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string key = webinfo.Key;

            if (Request.RequestType == "POST")
            {
                try
                {
                    StreamReader reader = new StreamReader(Request.InputStream);
                    String xmlData = reader.ReadToEnd();

                    NotifyEntites notifyentites = new NotifyEntites(xmlData);
                    TravelAgent.WxPay.Utils.WriteTxt("通知数据:" + xmlData);
                    if (notifyentites.ValidSign(notifyentites, key))
                    {
                        if (notifyentites.result_code == "SUCCESS" && notifyentites.return_code == "SUCCESS")
                        {
                            //商户自行增加处理流程,
                            //例如：更新订单状态
                            //例如：数据库操作
                            //例如：推送支付完成信息
                            //object r = TravelAgent.WxPay.AccessDbHelper.ExecuteCommand("UPDATE [wx_order] set [openid]='" + notifyentites.openid + "',[order_status]='支付成功',[transaction_id]='" + notifyentites.transaction_id + "' where [order_no]='" + notifyentites.out_trade_no + "'");
                            //TravelAgent.WxPay.AccessDbHelper.Connection.Close();
                            TravelAgent.Tool.DbHelperSQL.ExecuteSql("update [order] set orderState=" + Convert.ToInt32(TravelAgent.Tool.EnumSummary.OrderState.已付款) + " where ordercode='" + notifyentites.out_trade_no + "'");
                            TravelAgent.WxPay.Utils.WriteTxt("支付成功");
                            Response.Write("SUCCESS");


                        }
                        else
                        {
                            Response.Write("FAIL");
                        }
                    }
                    else
                    {
                        //验证签名出错
                        Response.Write("FAIL");
                    }


                }
                catch (Exception ex)
                {
                    TravelAgent.WxPay.Utils.WriteTxt("notify_异常了:" + ex);
                }
            }
        }
    }
}