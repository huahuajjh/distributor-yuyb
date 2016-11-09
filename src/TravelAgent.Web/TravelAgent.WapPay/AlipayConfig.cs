using System.Web;
using System.Text;
using System.IO;
using System.Net;
using System.Configuration;
using System;
using System.Collections.Generic;

namespace TravelAgent.WapPay
{
    /// <summary>
    /// 类名：Config
    /// 功能：基础配置类
    /// 详细：设置帐户有关信息及返回路径
    /// 版本：3.3
    /// 日期：2012-07-05
    /// 说明：
    /// 以下代码只是为了方便商户测试而提供的样例代码，商户可以根据自己网站的需要，按照技术文档编写,并非一定要使用该代码。
    /// 该代码仅供学习和研究支付宝接口使用，只是提供一个参考。
    /// 
    /// 如何获取安全校验码和合作身份者ID
    /// 1.用您的签约支付宝账号登录支付宝网站(www.alipay.com)
    /// 2.点击“商家服务”(https://b.alipay.com/order/myOrder.htm)
    /// 3.点击“查询合作者身份(PID)”、“查询安全校验码(Key)”
    /// </summary>
    public class Config
    {
        #region 字段
        private static string partner = "";
        private static string seller_id = "";
        private static string private_key = "";
        private static string public_key = "";
        private static string input_charset = "";
        private static string sign_type = "";
        #endregion

        static Config()
        {
            //↓↓↓↓↓↓↓↓↓↓请在这里配置您的基本信息↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓

            //合作身份者ID，以2088开头由16位纯数字组成的字符串
            partner = "";
			
            //收款支付宝账号，以2088开头由16位纯数字组成的字符串
            seller_id = partner;

            //商户的私钥
            private_key = "";
            //private_key = @"MIICdQIBADANBgkqhkiG9w0BAQEFAASCAl8wggJbAgEAAoGBAPPB+Ipu+XLQTCO29ux5eEpIqXAvKaCkbOw5OGVp3tplgJd40hjgMuGM5Zblvb5qiQlJFQ63dwbjDBR17eDThU1GwZmd2aJlbwOdkZcCwc0ZY1rk+UDGvDQ/pq84m/hRebc79+u9OKXrUWCZ+Cd/QOEtafP6LpRhu/YZUEQQtJZtAgMBAAECgYAenjbB7L6YlWF6+vh5K6jYa9gcp0/rRbwI0ActdebwN9+3Jw384eyCOFh+Y805pdggunVSq+jfjJVv3IBMxUTw+Tf8WgL/5lq9IPLwHquw0S/uXxtv12coeGUrP0YeeQKufo4YZsIrsLiv+S0aEruy+m6q3zZU6z6fuH5I1+lFAQJBAPxJP8x/RZnj7lkiy9LSXUxE7u+zCCvmGNcLIQagFvjSZI63BrDmnAR+OrFq3WUKCIAJyhC4pmO1JJXByY+Cw8UCQQD3WJT3b/KFjXZtevNwv+9GwGUFo0yrCdu7xntl8AI2iLzennhtREeCrU+leIoLmu3h0XHgd4rtP3MAwe99ZaqJAkBs5i1s108y40liHnv+z6FIJ8U/oHcZg+QbBwnFc1sXIrIXTHfN6m1UHyy0op1YXOFYa2FWoG3qQim9nv2jPd3FAkBYIkAySrlnzRg9ummz6zAfTb6xW5ad+01Ig1jE4dhoBiEGUgEnLgUtEwQmOeU2bWYF6NNi4DWog8s+odvsGqXBAkBoGhvIwK/nnwMU8McaSH1cN76EJIdHZMjl4XKNGqRe6A30FvmLcjQehU5VFVIiPmguQVM3FW5EDOq3xQnONX4F";

            //支付宝的公钥，无需修改该值
            public_key = "";
            //public_key = @"MIGfMA0GCSqGSIb3DQEBAQUAA4GNADCBiQKBgQCnxj/9qwVfgoUh/y2W89L6BkRAFljhNhgPdyPuBV64bfQNN1PjbCzkIM6qRdKBoLPXmKKMiFYnkd6rAoprih3/PrQEB/VsW8OoM8fxn67UDYuyBTqA23MML9q1+ilIZwBC2AQ2UBVOrFXfFl75p6/B5KsiNG9zpgmLCUYuLkxpLQIDAQAB";

            //↑↑↑↑↑↑↑↑↑↑请在这里配置您的基本信息↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑



            //字符编码格式 目前支持 gbk 或 utf-8
            input_charset = "utf-8";

            //签名方式，选择项：RSA、DSA、MD5
            sign_type = "RSA";
        }

        #region 属性
        /// <summary>
        /// 获取或设置合作者身份ID
        /// </summary>
        public static string Partner
        {
            get { return partner; }
            set { partner = value; }
        }

        /// <summary>
        /// 获取或设置合作者身份ID
        /// </summary>
        public static string Seller_id
        {
            get { return seller_id; }
            set { seller_id = value; }
        }

        /// <summary>
        /// 获取或设置商户的私钥
        /// </summary>
        public static string Private_key
        {
            get { return private_key; }
            set { private_key = value; }
        }

        /// <summary>
        /// 获取或设置支付宝的公钥
        /// </summary>
        public static string Public_key
        {
            get { return public_key; }
            set { public_key = value; }
        }

        /// <summary>
        /// 获取字符编码格式
        /// </summary>
        public static string Input_charset
        {
            get { return input_charset; }
        }

        /// <summary>
        /// 获取签名方式
        /// </summary>
        public static string Sign_type
        {
            get { return sign_type; }
        }
        #endregion
    }
}