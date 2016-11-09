using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TravelAgent.BLL;
using TravelAgent.Model;
using TravelAgent.Tool;
namespace TravelAgent.Web.PayApi.Chinabank
{
    public partial class AutoReceive : TravelAgent.Web.UI.mBasePage
    {
        protected string v_oid; //订单号
        protected string v_pstatus; //支付状态码
        //20（支付成功，对使用实时银行卡进行扣款的订单）；
        //30（支付失败，对使用实时银行卡进行扣款的订单）；

        protected string v_pstring; //支付状态描述
        protected string v_pmode; //支付银行
        protected string v_md5str; //MD5校验码
        protected string v_amount; //支付金额
        protected string v_moneytype; //币种		
        protected string remark1;//备注1
        protected string remark2;//备注1
        protected string status_msg;//备注1
        private static readonly TravelAgent.BLL.Order LineOrderBll = new TravelAgent.BLL.Order();
        //private static readonly TravelAgent.BLL.VisaOrder VisaOrderBll = new TravelAgent.BLL.VisaOrder();
        protected void Page_Load(object sender, EventArgs e)
        {
            // MD5密钥要跟订单提交页相同，如Send.asp里的 key = "test" ,修改""号内 test 为您的密钥
            string key = webinfo.ChinabankKey ;	// 如果您还没有设置MD5密钥请登陆我们为您提供商户后台，地址：https://merchant3.chinabank.com.cn/
            // 登陆后在上面的导航栏里可能找到“B2C”，在二级导航栏里有“MD5密钥设置”
            // 建议您设置一个16位以上的密钥或更高，密钥最多64位，但设置16位已经足够了			

            v_oid = Request["v_oid"];
            v_pstatus = Request["v_pstatus"];
            v_pstring = Request["v_pstring"];
            v_pmode = Request["v_pmode"];
            v_md5str = Request["v_md5str"];
            v_amount = Request["v_amount"];
            v_moneytype = Request["v_moneytype"];
            remark1 = Request["remark1"];
            remark2 = Request["remark2"];
            string userid = remark1;
            string total_fee = v_amount;

            string str = v_oid + v_pstatus + v_amount + v_moneytype + key;
            str = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(str, "md5").ToUpper();
            //使用积分
            int points = Request["v_rcvname"].ToString().Equals("") ? 0 : Convert.ToInt32(Request["v_rcvname"]);
            //赠送积分
            int donatepoints = Request["v_rcvaddr"].ToString().Equals("") ? 0 : Convert.ToInt32(Request["v_rcvaddr"]);

            if (str == v_md5str)
            {
                status_msg = "ok";

                if (v_pstatus.Equals("20"))
                {
                    //支付成功
                    string strsql = string.Empty;
                    string strOrderType = Request.Form["v_rcvtel"];
                    //if (strOrderType.Equals("line"))
                    //{
                    strsql = "update [Order] set usePoints=" + points + ",donatePoints=" + donatepoints + ",orderState=" + Convert.ToInt32(TravelAgent.Tool.EnumSummary.OrderState.已付款) + ",payType=" + Convert.ToInt32(TravelAgent.Tool.EnumSummary.PayType.支付宝) + " where Id=" + Request.Form["v_rcvaddr"];
                        if (points > 0)
                        {
                            strsql += "insert into ClubPoints(clubid,Content,points,remark,pType,adddate) values ('" + (TravelAgent.Tool.CookieHelper.GetCookieValue("uid")) + "','产品预订使用积分，订单号:" + v_oid + "','" + points + "','','" + TravelAgent.Tool.EnumSummary.PointsType.产品预订 + "','" + DateTime.Now + "');";
                        }
                        strsql += "insert into ClubPoints(clubid,Content,points,remark,pType,adddate) values ('" + (TravelAgent.Tool.CookieHelper.GetCookieValue("uid")) + "','产品支付赠送积分，订单号:" + v_oid + "','" + donatepoints + "','','" + TravelAgent.Tool.EnumSummary.PointsType.赠送积分 + "','" + DateTime.Now + "');";
                        strsql += "update Club set currentPoints=currentPoints+" + (donatepoints - points) + " where Id=" + TravelAgent.Tool.CookieHelper.GetCookieValue("uid");
                    //}
                    //else if (strOrderType.Equals("visa"))
                    //{
                    //    strsql = "update VisaOrder set orderState=" + Convert.ToInt32(TravelAgent.Tool.EnumSummary.OrderState.已付款) + ",payType=" + Convert.ToInt32(TravelAgent.Tool.EnumSummary.PayType.网银在线) + " where Id=" + Request.Form["v_rcvaddr"];
                    //}
                    if (!string.IsNullOrEmpty(strsql))
                    {
                        //Access
                        //TravelAgent.Tool.DbHelperOleDb.ExecuteSql(strsql);
                        //SQL
                        TravelAgent.Tool.DbHelperSQL.ExecuteSql(strsql);
                    }
                }
            }
            else
            {
                status_msg = "error";
            }
        }
    }
}
