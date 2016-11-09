using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TravelAgent.WxPay
{
    public class NativeSend
    {
        /// <summary>
        /// SUCCESS/FAIL
        /// </summary>
        public string return_code { get; set; }
        /// <summary>
        /// 返回信息，如非空，为错误原因签名失败参数格式校验错误
        /// </summary>
        public string return_msg { get; set; }
        /// <summary>
        /// 微信分配的公众账号 ID
        /// </summary>
        public string appid { get; set; }
        /// <summary>
        /// 微信支付分配的商户号
        /// </summary>
        public string mch_id { get; set; }
        /// <summary>
        /// 随机字符串
        /// </summary>
        public string nonce_str { get; set; }
        /// <summary>
        /// 调用统一支付接口生成的预支付 ID

        /// </summary>
        public string prepay_id { get; set; }
        /// <summary>
        /// 业务结果SUCCESS/FAIL
        /// </summary>
        public string result_code { get; set; }
        /// <summary>
        /// 当 result_code 为 FAIL 时，返回错误信息，微信直接展示给用户，例如：订单过期，无效订单等
        /// </summary>
        public string err_code_des { get; set; }
        /// <summary>
        /// 签名
        /// </summary>
        public string sign { get; set; }
    }
}
