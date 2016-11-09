using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace TravelAgent.WxPay
{
    public class UnifyReceive
    {
   
        /// <summary>
        /// SUCCESS/FAIL此字段是通信标识，非交易标识，交易是否成功需要查看result_code来判断
        /// </summary>
        public string return_code { get; set; }
        /// <summary>
        /// 返回信息，如非空，为错误原因
        /// </summary>
        public string return_msg { get; set; }
        /// <summary>
        /// 微信分配的公众账号ID
        /// </summary>
        public string appid { get; set; }
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
        /// 业务结果
        /// </summary>
        public string result_code { get; set; }
        /// <summary>
        /// 预支付ID
        /// </summary>
        public string prepay_id { get; set; }
        /// <summary>
        /// 交易类型
        /// </summary>
        public string trade_type { get; set; }
        /// <summary>
        /// 二维码链接
        /// </summary>
        public string code_url { get; set; }
        public UnifyReceive(string xml)
        {
            Utils.WriteTxt("UnifyReceive:"+xml);
            XElement doc = XElement.Parse(xml);
            return_code = doc.Element("return_code").Value;
            return_msg = doc.Element("return_msg").Value;
            if (return_code == "SUCCESS")
            {
                appid = doc.Element("appid").Value;
                mch_id = doc.Element("mch_id").Value;
                nonce_str = doc.Element("nonce_str").Value;
                sign = doc.Element("sign").Value;
                result_code = doc.Element("result_code").Value;
                if (result_code == "SUCCESS")
                {
                    trade_type = doc.Element("trade_type").Value;
                    prepay_id = doc.Element("prepay_id").Value;
                    if (trade_type == "NATIVE")
                    {
                        code_url = doc.Element("code_url").Value;
                    }
                    trade_type = doc.Element("trade_type").Value;
                }
            }
        }
    }
}
