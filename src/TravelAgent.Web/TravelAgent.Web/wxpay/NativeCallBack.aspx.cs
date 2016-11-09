using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Web.Configuration;
using TravelAgent.WxPay;

namespace TravelAgent.Web.wxpay
{
    public partial class NativeCallback : System.Web.UI.Page
    {
        private string appid;
        private string mch_id;
        private string notify_url;
        private string key;
        private static readonly TravelAgent.BLL.Order orderBll = new TravelAgent.BLL.Order();
        private static readonly TravelAgent.BLL.VisaList VisaListBll = new TravelAgent.BLL.VisaList();
        private static readonly TravelAgent.BLL.Line LineBll = new TravelAgent.BLL.Line();
        private static readonly TravelAgent.BLL.CarList CarBll = new TravelAgent.BLL.CarList();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                TravelAgent.Model.WebInfo webinfo = new TravelAgent.BLL.WebInfo().loadConfig(Server.MapPath(ConfigurationManager.AppSettings["WebInfoConfig"].ToString()));
                if (webinfo != null)
                {
                    appid = webinfo.AppID;
                    mch_id = webinfo.Mchid;
                    key = webinfo.Key;
                    notify_url = webinfo.WebDomain + "/wxpay/notify_url.aspx";
                }
                //Utils.WriteTxt(appid+"-"+mch_id+"-"+key+"-"+notify_url);
                var nr = new NativeReceive();
                var ns = new NativeSend();
                bool valid=nr.ValidSign(nr, key);
                //Utils.WriteTxt("验证"+valid.ToString());
                if (valid)
                {
                    TravelAgent.Model.Order order = orderBll.GetModelByCode(nr.product_id);
                    if (order == null)
                    {
                        return;
                    }
                    
                    //object r = TravelAgent.WxPay.AccessDbHelper.GetOScalar("select [order_price] from   [wx_order]   where [order_no]='" + nr.product_id + "'");

                    //if (r == null)
                    //{
                    //   // Response.Write("用户名或密码错误");
                    //  //  Response.End();
                    //    return;
                    //}
                    float  order_price ;
                    order_price = wxpay.Utils.StrToFloat(((order.orderPrice+order.attachPrice+order.subPrice-order.usePoints)).ToString(), 0) * 100;//积分1分兑换1元

                    UnifyEntities ue = new UnifyEntities
                    {
                        appid = appid,
                        body = getOrderName(order.lineId,order.orderType),
                        mch_id = mch_id,
                        nonce_str = TravelAgent.WxPay.Utils.GetRandom(),
                        notify_url = notify_url,
                        out_trade_no = nr.product_id,
                        product_id = nr.product_id,
                        spbill_create_ip = JKRequest.GetIP(),
                        trade_type = "NATIVE",
                        total_fee = order_price.ToString()

                    };
                    string url, sign;
                    string xml = TravelAgent.WxPay.Utils.GetUnifyUrlXml<UnifyEntities>(ue, key, out url, out sign);

                    //Utils.WriteTxt(xml);

                    string data = Utils.HttpPost("https://api.mch.weixin.qq.com/pay/unifiedorder", xml);
                    UnifyReceive unifyReceive = new UnifyReceive(data);

                    
                    NativeSend nc = new NativeSend()
                    {
                        appid = appid,
                        mch_id = mch_id,
                        nonce_str = TravelAgent.WxPay.Utils.GetRandom(),
                        prepay_id = unifyReceive.prepay_id,
                        result_code = "SUCCESS",
                        return_code = "SUCCESS",
                    };
                    string url1, sign1;
                    string xml1 = TravelAgent.WxPay.Utils.GetUnifyUrlXml<NativeSend>(nc, key, out url1, out sign1);
                    Utils.WriteTxt(xml1);
                    Response.Write(xml1);
                }
                else
                {
                    Utils.WriteTxt("签名验证失败");
                    NativeSend nc = new NativeSend()
                    {
                        return_code = "FAIL",
                        return_msg = "签名验证失败"
                    };
                }
            }
            catch (Exception ee)
            {
                Utils.WriteTxt(ee.ToString());
            }
        }
        /// <summary>
        /// 返回线路名称
        /// </summary>
        /// <param name="id"></param>
        /// <param name="orderType"></param>
        public string getOrderName(int id, int orderType)
        {
            string strvalue = "";
            if (orderType == Convert.ToInt32(TravelAgent.Tool.EnumSummary.OrderType.线路))
            {
                TravelAgent.Model.Line l = LineBll.GetModel(id);
                if (l != null)
                {
                    strvalue = l.LineName;
                }
            }
            else if (orderType == Convert.ToInt32(TravelAgent.Tool.EnumSummary.OrderType.签证))
            {
                TravelAgent.Model.VisaList v = VisaListBll.GetModel(id);
                if (v != null)
                {
                    strvalue = v.visaName;
                }
            }
            else if (orderType == Convert.ToInt32(TravelAgent.Tool.EnumSummary.OrderType.租车))
            {
                TravelAgent.Model.CarList c = CarBll.GetModel(id);
                if (c != null)
                {
                    strvalue =c.CarName;
                }
            }

            return strvalue;
        }
    }
}