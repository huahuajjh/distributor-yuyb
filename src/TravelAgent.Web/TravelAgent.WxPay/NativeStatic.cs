using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TravelAgent.WxPay
{
    public class NativeStatic
    {
        /// <summary>
        /// 公众账号ID
        /// </summary>
        public string appid { get; set; }
        /// <summary>
        /// 商户号
        /// </summary>
        public string mch_id { get; set; }
        /// <summary>
        /// 时间戳
        /// </summary>
        public string time_stamp { get; set; }
        /// <summary>
        /// 随机字符串
        /// </summary>
        public string nonce_str { get; set; }
       /// <summary>
        ///  商品ID
       /// </summary>
        public string product_id { get; set; }
    }
}
