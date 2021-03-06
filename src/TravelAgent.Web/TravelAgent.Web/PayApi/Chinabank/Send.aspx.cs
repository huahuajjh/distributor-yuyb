﻿using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TravelAgent.Web.PayApi.Chinabank
{
    public partial class Send : TravelAgent.Web.UI.mBasePage
    {
        //必要的交易信息
        protected string v_amount;       // 订单金额
        protected string v_moneytype;    // 币种
        protected string v_md5info;      // 对拼凑串MD5私钥加密后的值
        protected string v_mid;		 // 商户号
        protected string v_url;		 // 返回页地址
        protected string v_oid;		 // 推荐订单号构成格式为 年月日-商户号-小时分钟秒

        //收货信息
        protected string v_rcvname;      // 收货人
        protected string v_rcvaddr;      // 收货地址
        protected string v_rcvtel;       // 收货人电话
        protected string v_rcvpost;      // 收货人邮编
        protected string v_rcvemail;     // 收货人邮件
        protected string v_rcvmobile;    // 收货人手机号

        //订货人信息
        protected string v_ordername;    // 订货人姓名
        protected string v_orderaddr;    // 订货人地址
        protected string v_ordertel;     // 订货人电话
        protected string v_orderpost;    // 订货人邮编
        protected string v_orderemail;   // 订货人邮件
        protected string v_ordermobile;  // 订货人手机号
        protected string pmode_id;
        //两个备注
        protected string remark1;
        protected string remark2;

        protected void Page_Load(object sender, EventArgs e)
        {
            v_mid = webinfo.ChinabankAccount;										//1001是网银在线的测试商户号，商户要替换为自己的商户号。
            v_url = webinfo.WebDomain + "/PayApi/Chinabank/Receive.aspx";  //商户自定义返回接收支付结果的页面。对应Receive.aspx.cs示例。
            //参照"网银在线支付B2C系统商户接口文档v4.1.doc"中2.3.3.1

            string key = webinfo.ChinabankKey;								// 参照"网银在线支付B2C系统商户接口文档v4.1.doc"中2.4.1进行设置。

            remark2 = "[url:=" + webinfo.WebDomain + "/PayApi//Chinabank/AutoReceive.aspx]";//服务器异步通知的接收地址。对应AutoReceive.aspx.cs示例。必须要有[url:=]格式。
            //参照"网银在线支付B2C系统商户接口文档v4.1.doc"中2.3.3.2。

            //v_oid = Request["v_oid"];
            v_oid = Request["out_trade_no"];
            if (v_oid == null || v_oid.Equals(""))
            {
                DateTime dt = DateTime.Now;
                string v_ymd = dt.ToString("yyyyMMdd"); // yyyyMMdd
                string timeStr = dt.ToString("HHmmss"); // HHmmss
                v_oid = v_ymd + v_mid + timeStr;
            }

            v_amount = Request["total_fee"];

            v_moneytype = "CNY";

            string text = v_amount + v_moneytype + v_oid + v_mid + v_url + key; // 拼凑加密串

            v_md5info = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(text, "md5").ToUpper();

            //收货信息
            //v_rcvname = Request["v_rcvname"];
            //v_rcvaddr = Request["v_rcvaddr"];
            //v_rcvtel = Request["v_rcvtel"];
            //v_rcvpost = Request["v_rcvpost"];
            //v_rcvemail = Request["v_rcvemail"];
            //v_rcvmobile = Request["v_rcvmobile"];

            v_rcvname = Request["body"];
            v_rcvaddr = Request["orderid"];
            v_rcvtel = Request["ordertype"];
            v_rcvpost = Request["subject"];
            v_rcvemail = Request["v_rcvemail"];
            v_rcvmobile = Request["v_rcvmobile"];

            //订货人信息
            v_ordername = Request["points"];//使用积分
            v_orderaddr = Request["donatep"];//赠送积分

            v_ordertel = Request["v_ordertel"];
            v_orderpost = Request["v_orderpost"];
            v_orderemail = Request["v_orderemail"];
            v_ordermobile = Request["v_ordermobile"];

            remark1 = Request["body"];

        }
    }
}
