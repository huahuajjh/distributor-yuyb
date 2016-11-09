using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using System.Configuration;
using System.Web.Configuration;
using Newtonsoft.Json.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using TravelAgent.WxPay;
namespace TravelAgent.Web.wxpay
{
    /// <summary>
    /// WxPay 的摘要说明
    /// </summary>
    public class WxPay : IHttpHandler
    {
        /// <summary>
        /// 公众账号ID
        /// </summary>
        private string appid;
        /// <summary>
        /// 商户号
        /// </summary>
        private string mch_id;
        /// <summary>
        /// 通知url
        /// </summary>
        private string notify_url ;
        /// <summary>
        /// 密钥
        /// </summary>
        private string key;
        /// <summary>
        /// appsecret
        /// </summary>
        private string appsecret;

        public void ProcessRequest(HttpContext context)
        {
            TravelAgent.Model.WebInfo webinfo = new TravelAgent.BLL.WebInfo().loadConfig(context.Server.MapPath(ConfigurationManager.AppSettings["WebInfoConfig"].ToString()));
            if (webinfo != null)
            {
                appid = webinfo.AppID;
                mch_id = webinfo.Mchid;
                key = webinfo.Key;
                appsecret = webinfo.AppSecret;
                notify_url = webinfo.WebDomain + "/wxpay/notify_url.aspx";
            }
            string action = JKRequest.GetQueryString("action");
            switch (action)
            {
                case "unifysign":
                GetUnifySign(context); break;
                case "nativestatic": GetStaticPayQr(context); break;
                case "GetOpenId": GetOpenId(context); break;
                case "GetOrderStatus": GetOrderStatus(context); break;
                case "ver": GetVersion(context); break;

            }
        }
        #region 获取版本

        void GetVersion(HttpContext context)
        {
            context.Response.Write("Ver 1.0");
            TravelAgent.WxPay.Utils.WriteTxt("Ver 1.0");
        }
        #endregion
        #region 获取js支付参数

        void GetJsPayParam(HttpContext context)
        {
            JsEntities jsEntities = new JsEntities()
            {
                appId = appid,
                nonceStr = TravelAgent.WxPay.Utils.GetRandom(),
                package = string.Format("prepay_id={0}", GetPrepayId(context)),
                signType = "MD5",
                timeStamp = Utils.ConvertDateTimeInt(DateTime.Now).ToString()
            };
            string url, sign;
            TravelAgent.WxPay.Utils.GetUnifyUrlXml<JsEntities>(jsEntities, key, out url, out sign);
            jsEntities.paySign = sign;
            context.Response.Write(JsonConvert.SerializeObject(jsEntities));
        }
        #endregion

        #region 获取OpenId

        void GetOpenId(HttpContext context)
        {
            string code = JKRequest.GetQueryString("code");
            string retdata = Utils.HttpGet(string.Format("https://api.weixin.qq.com/sns/oauth2/access_token?appid={0}&secret={1}&code={2}&grant_type=authorization_code", appid, appsecret, code));

            //context.Response.Write(retdata);
            JObject jobj = (JObject)JsonConvert.DeserializeObject(retdata);
            string openid = jobj.Value<string>("openid");
            //return openid;
            context.Response.Write(openid);


        }
        #endregion
        #region 获取预支付ID

        string GetPrepayId(HttpContext context)
        {
            string xml;
            GetUnifySign(context, out xml);
            TravelAgent.WxPay.Utils.WriteTxt(xml);
            UnifyReceive unifyReceive = new UnifyReceive(Utils.HttpPost("https://api.mch.weixin.qq.com/pay/unifiedorder", xml));
            TravelAgent.WxPay.Utils.WriteTxt("prepay_id:" + unifyReceive.prepay_id);
            return unifyReceive.prepay_id;
        }
        #endregion
        #region 获取统一签名
        void GetUnifySign(HttpContext context)
        {
            string xml;
            context.Response.Write(GetUnifySign(context, out xml));
        }
        #endregion
        #region 获取统一签名

        string GetUnifySign(HttpContext context, out string xml)
        {
            string url, sign;
            xml = TravelAgent.WxPay.Utils.GetUnifyUrlXml<UnifyEntities>(GetUnifyEntities(context), key, out  url, out sign);
            return sign;
        }
        #endregion


        #region 获取二维码

        void GetStaticPayQr(HttpContext context)
        {
            //string url = GetPayUrl(context);
            //HttpContext.Current.Response.Write(url);

            NativeStatic ns = new NativeStatic()
            {
                appid = appid,
                mch_id = mch_id,
                nonce_str = TravelAgent.WxPay.Utils.GetRandom(),
                product_id = JKRequest.GetQueryString("product_id"),
                time_stamp = Utils.ConvertDateTimeInt(DateTime.Now).ToString()
            };
            string url, sign;
            TravelAgent.WxPay.Utils.GetUnifyUrlXml<NativeStatic>(ns, key, out url, out sign);

            TravelAgent.WxPay.Utils.GetQrCode("weixin://wxpay/bizpayurl?" + url);

        }
        #endregion
        #region 获取预支付ID

        string GetPayUrl(HttpContext context)
        {
            string xml;
            GetUnifySign(context, out xml);
            TravelAgent.WxPay.Utils.WriteTxt(xml);
            UnifyReceive unifyReceive = new UnifyReceive(Utils.HttpPost("https://api.mch.weixin.qq.com/pay/unifiedorder", xml));
            return unifyReceive.code_url;
        }
        #endregion
        #region 获取统一支付接口参数对象

        UnifyEntities GetUnifyEntities(HttpContext context)
        {
            string msgid = JKRequest.GetQueryString("msgid");
            UnifyEntities unify = new UnifyEntities
            {
                appid = appid,
                body = JKRequest.GetQueryString("body"),
                mch_id = mch_id,
                nonce_str = TravelAgent.WxPay.Utils.GetRandom(),
                out_trade_no = JKRequest.GetQueryString("out_trade_no"),
                notify_url = notify_url,
                spbill_create_ip = JKRequest.GetIP(),
                trade_type = JKRequest.GetQueryString("trade_type"),
                total_fee = JKRequest.GetQueryString("total_fee")
            };
            if (unify.trade_type == "NATIVE")
            {
                unify.product_id = msgid;
            }
            else
            {
                unify.openid = msgid;
            }
            return unify;
        }

        #endregion

        #region 检测订单状态
        //从订单查询接口里查询订单支付状态

        void GetOrderStatus(HttpContext context)
        {
            string order_no = JKRequest.GetQueryString("order_no");

            QueryOrderEntities qo = new QueryOrderEntities()
            {
                appid = appid,
                mch_id = mch_id,
                out_trade_no = order_no,
                nonce_str = TravelAgent.WxPay.Utils.GetRandom()
            };

            string url, sign;
            string xml = TravelAgent.WxPay.Utils.GetUnifyUrlXml<QueryOrderEntities>(qo, key, out url, out sign);
            string data = Utils.HttpPost("https://api.mch.weixin.qq.com/pay/orderquery", xml);
            XElement doc = XElement.Parse(data);
            string result_code = doc.Element("result_code").Value;
            string return_code = doc.Element("return_code").Value;
            if (result_code == "SUCCESS" && return_code == "SUCCESS")
            {
                string trade_state = doc.Element("trade_state").Value;
                if (trade_state == "SUCCESS" )
                {
                    context.Response.Write("{\"flag\":\"true\",\"msg\":\"已支付\"}");
                }
                else
                {
                    context.Response.Write("{\"flag\":\"false\",\"msg\":\"未支付\"}");
                }
            }
            else
            {
                context.Response.Write("{\"flag\":\"false\",\"msg\":\"未支付\"}");
            }
           
        }
        #endregion
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}