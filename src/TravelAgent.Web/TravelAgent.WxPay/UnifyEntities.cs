using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TravelAgent.WxPay
{
    public class UnifyEntities
    {
        /// <summary>
        /// 公众账号ID
        /// </summary>
        public string appid { get; set; }
        /// <summary>
        /// 微信支付分配的商户号
        /// </summary>
        public string mch_id { get; set; }
        /// <summary>
        /// 微信支付分配的终端设备号
        /// </summary>
        public string device_info { get; set; }
        /// <summary>
        /// 随机字符串，不长于32位
        /// </summary>
        public string nonce_str { get; set; }
        /// <summary>
        /// 签名
        /// </summary>
        public string sign { get; set; }
        /// <summary>
        /// 商品描述最大长度127
        /// </summary>
        public string body { get; set; }
        /// <summary>
        /// 附加数据，原样返回
        /// </summary>
        public string attach { get; set; }
        /// <summary>
        /// 商户系统内部的订单号,32 个字符内、可包含字母,确保在商户系统唯一,详细说明
        /// </summary>
        public string out_trade_no { get; set; }
        /// <summary>
        /// 订单总金额，单位为分，不能带小数点
        /// </summary>
        public string total_fee { get; set; }
        /// <summary>
        /// 终端IP
        /// </summary>
        public string spbill_create_ip { get; set; }
        /// <summary>
        /// 交易起始时间
        /// </summary>
        public string time_start { get; set; }
        /// <summary>
        /// 交易结束时间
        /// </summary>
        public string time_expire { get; set; }
        /// <summary>
        /// 接收微信支付成功通知
        /// </summary>
        public string notify_url { get; set; }
        /// <summary>
        /// JSAPI、NATIVE、APP
        /// </summary>
        public string trade_type { get; set; }
        /// <summary>
        /// 用户在商户appid下的唯一标识，trade_type为JSAPI 时，此参数必传
        /// </summary>
        public string openid { get; set; }
        /// <summary>
        /// 只在 trade_type 为 NATIVE 时需要填写。此id为二维码中包含的商品ID，商户自行维护。
        /// </summary>
        public string product_id { get; set; }
    }
}
