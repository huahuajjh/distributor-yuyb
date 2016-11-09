using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
namespace TravelAgent.WxPay
{

    public class NotifyEntites
    {
        /// <summary>
        /// 公众账号ID
        /// </summary>
        public string appid { get; set; }
        /// <summary>
        /// 付款银行
        /// </summary>
        public string bank_type { get; set; }
        /// <summary>
        /// 现金支付金额
        /// </summary>
        public string cash_fee { get; set; }
        /// <summary>
        /// 货币类型
        /// </summary>
        public string fee_type { get; set; }

        /// <summary>
        /// 是否关注公众账号
        /// </summary>
        public string is_subscribe { get; set; }

        /// <summary>
        /// 用户的openid
        /// </summary>
        public string openid { get; set; }


        /// <summary>
        /// 微信支付分配的商户号
        /// </summary>
        public string mch_id { get; set; }

        /// <summary>
        /// 随机字符串，不长于32位
        /// </summary>
        public string nonce_str { get; set; }
        /// <summary>
        /// 签名
        /// </summary>
        public string sign { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string result_code { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string return_code { get; set; }

        /// <summary>
        /// 商户系统内部的订单号,32 个字符内、可包含字母,确保在商户系统唯一,详细说明
        /// </summary>
        public string out_trade_no { get; set; }

        /// <summary>
        /// 订单总金额，单位为分，不能带小数点
        /// </summary>
        public string total_fee { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string time_end { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string trade_type { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string transaction_id { get; set; }

        public NotifyEntites(string xml)
        {

            XElement doc = XElement.Parse(xml);

            appid = doc.Element("appid").Value;
            bank_type = doc.Element("bank_type").Value;
            cash_fee = doc.Element("cash_fee").Value;
            fee_type = doc.Element("fee_type").Value;
            is_subscribe = doc.Element("is_subscribe").Value;

            openid = doc.Element("openid").Value;
            mch_id = doc.Element("mch_id").Value;
            nonce_str = doc.Element("nonce_str").Value;

            sign = doc.Element("sign").Value;
            result_code = doc.Element("result_code").Value;
            return_code = doc.Element("return_code").Value;

            out_trade_no = doc.Element("out_trade_no").Value;
            total_fee = doc.Element("total_fee").Value;

            time_end = doc.Element("time_end").Value;
            trade_type = doc.Element("trade_type").Value;
            transaction_id = doc.Element("transaction_id").Value;




        }
        /// <summary>
        /// 验证签名
        /// </summary>
        /// <param name="nativeReceive"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool ValidSign(NotifyEntites notifyEntites, string key)
        {
            string _sign = notifyEntites.sign;
            string url, sign;
            notifyEntites.sign = null;
            Utils.GetUnifyUrlXml<NotifyEntites>(notifyEntites, key, out url, out sign);

            return sign == _sign;
        }


    }

}
