using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Specialized;
using System.Collections.Generic;
using TravelAgent.Pay;
using TravelAgent.Tool;
using TravelAgent.Model;
using TravelAgent.BLL;
namespace TravelAgent.Web.PayApi.Alipay
{

    /// <summary>
    /// 功能：服务器异步通知页面
    /// 版本：3.3
    /// 日期：2012-07-10
    /// 说明：
    /// 以下代码只是为了方便商户测试而提供的样例代码，商户可以根据自己网站的需要，按照技术文档编写,并非一定要使用该代码。
    /// 该代码仅供学习和研究支付宝接口使用，只是提供一个参考。
    /// 
    /// ///////////////////页面功能说明///////////////////
    /// 创建该页面文件时，请留心该页面文件中无任何HTML代码及空格。
    /// 该页面不能在本机电脑测试，请到服务器上做测试。请确保外部可以访问该页面。
    /// 该页面调试工具请使用写文本函数logResult。
    /// 如果没有收到该页面返回的 success 信息，支付宝会在24小时内按一定的时间策略重发通知
    /// </summary>
    public partial class notify_url : System.Web.UI.Page
    {
        private static readonly TravelAgent.BLL.Order orderbll = new TravelAgent.BLL.Order();
        private static readonly TravelAgent.BLL.Line linebll = new TravelAgent.BLL.Line();
        private static readonly TravelAgent.BLL.VisaList visabll = new TravelAgent.BLL.VisaList();
        private static readonly TravelAgent.BLL.CarList carbll = new TravelAgent.BLL.CarList();
        protected void Page_Load(object sender, EventArgs e)
        {
            SortedDictionary<string, string> sPara = GetRequestPost();

            if (sPara.Count > 0)//判断是否有带返回参数
            {
                Notify aliNotify = new Notify();
                bool verifyResult = aliNotify.Verify(sPara, Request.Form["notify_id"], Request.Form["sign"]);

                if (verifyResult)//验证成功
                {
                    /////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    //请在这里加上商户的业务逻辑程序代码


                    //——请根据您的业务逻辑来编写程序（以下代码仅作参考）——
                    //获取支付宝的通知返回参数，可参考技术文档中服务器异步通知参数列表

                    //商户订单号
                    string out_trade_no = Request.Form["out_trade_no"];
                    //支付宝交易号
                    string trade_no = Request.Form["trade_no"];
                    //交易状态
                    string trade_status = Request.Form["trade_status"];
                    //额外参数
                    string struse_points = Request.Form["extra_common_param"];

                    if (Request.Form["trade_status"] == "TRADE_FINISHED")
                    {
                        //判断该笔订单是否在商户网站中已经做过处理
                        //如果没有做过处理，根据订单号（out_trade_no）在商户网站的订单系统中查到该笔订单的详细，并执行商户的业务程序
                        //如果有做过处理，不执行商户的业务程序
                     
                        //注意：
                        //该种交易状态只在两种情况下出现
                        //1、开通了普通即时到账，买家付款成功后。
                        //2、开通了高级即时到账，从该笔交易成功时间算起，过了签约时的可退款时限（如：三个月以内可退款、一年以内可退款等）后。
                    }
                    else if (Request.Form["trade_status"] == "TRADE_SUCCESS")
                    {
                        //判断该笔订单是否在商户网站中已经做过处理
                        //如果没有做过处理，根据订单号（out_trade_no）在商户网站的订单系统中查到该笔订单的详细，并执行商户的业务程序
                        //如果有做过处理，不执行商户的业务程序
                        int intusepoints = string.IsNullOrEmpty(struse_points) ? 0 : Convert.ToInt32(struse_points);//使用积分
                        int intdonatep = 0;//赠送积分
                        //TravelAgent.WxPay.Utils.WriteTxt("支付宝支付,使用积分：" + intusepoints + "-赠送积分：" + intdonatep + "-" + DateTime.Now);

                        TravelAgent.Model.Order order = orderbll.GetModelByCode1(out_trade_no);
                        if (order != null)
                        {
                            //TravelAgent.WxPay.Utils.WriteTxt("支付宝支付：" + order.ordercode + "--" + DateTime.Now);
                            if (order.orderType == Convert.ToInt32(TravelAgent.Tool.EnumSummary.OrderType.线路))
                            {
                                TravelAgent.Model.Line line = linebll.GetModel(order.lineId);
                                if (line != null)
                                {
                                    intdonatep = line.DonatePoints;
                                }
                            }
                            else if (order.orderType == Convert.ToInt32(TravelAgent.Tool.EnumSummary.OrderType.签证))
                            {
                                TravelAgent.Model.VisaList visa = visabll.GetModel(order.lineId);
                                if (visa != null)
                                {
                                    intdonatep = visa.donatePoints;
                                }
                            }
                            else if (order.orderType == Convert.ToInt32(TravelAgent.Tool.EnumSummary.OrderType.租车))
                            {
                                TravelAgent.Model.CarList car = carbll.GetModel(order.lineId);
                                if (car != null)
                                {
                                    intdonatep = 20;//默认赠送
                                }
                            }
                        }
                        string strsql = "update [Order] set usePoints=" + intusepoints + ",donatePoints=" + intdonatep + ",orderState=" + Convert.ToInt32(TravelAgent.Tool.EnumSummary.OrderState.已付款) + ",payType=" + Convert.ToInt32(TravelAgent.Tool.EnumSummary.PayType.支付宝) + " where ordercode='" + out_trade_no + "';";
                        if (intusepoints > 0)
                        {
                            strsql += "insert into ClubPoints(clubid,Content,points,remark,pType,adddate) values ('" + (TravelAgent.Tool.CookieHelper.GetCookieValue("uid")) + "','产品预订使用积分,订单号:" + out_trade_no + "','" + intusepoints + "','','" + Convert.ToInt32(TravelAgent.Tool.EnumSummary.PointsType.产品预订) + "','" + DateTime.Now + "');";
                        }
                        if (intdonatep > 0)
                        {
                            strsql += "insert into ClubPoints(clubid,Content,points,remark,pType,adddate) values ('" + (TravelAgent.Tool.CookieHelper.GetCookieValue("uid")) + "','产品支付赠送积分，订单号:" + out_trade_no + "','" + intdonatep + "','','" + Convert.ToInt32(TravelAgent.Tool.EnumSummary.PointsType.赠送积分) + "','" + DateTime.Now + "');";
                        }

                        strsql += "update Club set currentPoints=currentPoints+" + (intdonatep - intusepoints) + " where Id=" + order.clubid;

                        if (!string.IsNullOrEmpty(strsql))
                        {
                            //Access
                            //TravelAgent.Tool.DbHelperOleDb.ExecuteSql(strsql);
                            //SQL
                            TravelAgent.Tool.DbHelperSQL.ExecuteSql(strsql);
                        }
                        //注意：
                        //该种交易状态只在一种情况下出现——开通了高级即时到账，买家付款成功后。
                    }
                    else
                    {
                    }

                    //——请根据您的业务逻辑来编写程序（以上代码仅作参考）——

                    Response.Write("success");  //请不要修改或删除

                    /////////////////////////////////////////////////////////////////////////////////////////////////////////////
                }
                else//验证失败
                {
                    Response.Write("fail");
                }
            }
            else
            {
                Response.Write("无通知参数");
            }
        }

        /// <summary>
        /// 获取支付宝POST过来通知消息，并以“参数名=参数值”的形式组成数组
        /// </summary>
        /// <returns>request回来的信息组成的数组</returns>
        public SortedDictionary<string, string> GetRequestPost()
        {
            int i = 0;
            SortedDictionary<string, string> sArray = new SortedDictionary<string, string>();
            NameValueCollection coll;
            //Load Form variables into NameValueCollection variable.
            coll = Request.Form;

            // Get names of all forms into a string array.
            String[] requestItem = coll.AllKeys;

            for (i = 0; i < requestItem.Length; i++)
            {
                sArray.Add(requestItem[i], Request.Form[requestItem[i]]);
            }

            return sArray;
        }
    }

}
