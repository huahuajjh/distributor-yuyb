using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Xml.Linq;

namespace TravelAgent.WxPay
{
    public class NativeReceive
    {
        /// <summary>
        /// 公众账号ID
        /// </summary>
        public string appid { get; set; }
        /// <summary>
        /// 公用户在商户appid下的唯一标识
        /// </summary>
        public string openid { get; set; }
        /// <summary>
        /// 商户号
        /// </summary>
        public string mch_id { get; set; }
        /// <summary>
        /// 是否关注公众号
        /// </summary>
        public string is_subscribe { get; set; }
        /// <summary>
        /// 随机字符串
        /// </summary>
        public string nonce_str { get; set; }
       /// <summary>
        ///  商品ID
       /// </summary>
        public string product_id { get; set; }
        /// <summary>
        ///  签名
        /// </summary>
        public string sign { get; set; }

        public NativeReceive()
        {
            string postStr = "";
            Stream s = HttpContext.Current.Request.InputStream;
            byte[] b = new byte[s.Length];
            s.Read(b, 0, (int)s.Length);
            postStr = Encoding.UTF8.GetString(b);
            Utils.WriteTxt(postStr);
            XElement doc = XElement.Parse(postStr);
            appid = doc.Element("appid").Value;
            mch_id = doc.Element("mch_id").Value;
            openid = doc.Element("openid").Value;
            is_subscribe = doc.Element("is_subscribe").Value;
            nonce_str = doc.Element("nonce_str").Value;
            product_id = doc.Element("product_id").Value;
            sign = doc.Element("sign").Value;
        }
        /// <summary>
        /// 验证签名
        /// </summary>
        /// <param name="nativeReceive"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool ValidSign(NativeReceive nativeReceive,string key)
        {
            string _sign = nativeReceive.sign;
            string url, sign;
            nativeReceive.sign = null;
            Utils.GetUnifyUrlXml<NativeReceive>(nativeReceive,key,out url,out sign);

            return sign == _sign;
        }
    }
}
