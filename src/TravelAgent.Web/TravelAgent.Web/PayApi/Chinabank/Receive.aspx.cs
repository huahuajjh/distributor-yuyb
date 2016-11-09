using System;
using System.Configuration;
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
    public partial class Receive : TravelAgent.Web.UI.mBasePage
    {
        protected string v_oid;		// 订单号
        protected string v_pstatus;	// 支付状态码
        //20（支付成功，对使用实时银行卡进行扣款的订单）；
        //30（支付失败，对使用实时银行卡进行扣款的订单）；

        protected string v_pstring;	//支付状态描述
        protected string v_pmode;	//支付银行
        protected string v_amount;	//支付金额
        protected string v_moneytype;	//币种		
        protected string remark1;	// 备注1
        protected string remark2;	// 备注1
        protected string v_md5str;
        protected string status_msg;
        protected string str;	// 备注1

        //private static readonly bProOrderPay PayBll = new bProOrderPay();
        protected void Page_Load(object sender, EventArgs e)
        {
            // MD5密钥要跟订单提交页相同，如Send.asp里的 key = "test" ,修改""号内 test 为您的密钥
            string key =webinfo.ChinabankKey;	// 如果您还没有设置MD5密钥请登陆我们为您提供商户后台，地址：https://merchant3.chinabank.com.cn/
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
            //remark2 = Request["remark2"];

            string str = v_oid + v_pstatus + v_amount + v_moneytype + key;

            str = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(str, "md5").ToUpper();
            //使用积分
            int points = Request["v_rcvname"].ToString().Equals("") ? 0 : Convert.ToInt32(Request["v_rcvname"]);
            //赠送积分
            int donatepoints = Request["v_rcvaddr"].ToString().Equals("") ? 0 : Convert.ToInt32(Request["v_rcvaddr"]);

            if (str == v_md5str)
            {

                if (v_pstatus.Equals("20"))
                {
                    //支付成功
                    string strsql = string.Empty;
                    string strOrderType = Request.Form["v_rcvtel"];
                    strsql = "update [Order] set usePoints=" + points + ",donatePoints=" + donatepoints + ",orderState=" + Convert.ToInt32(TravelAgent.Tool.EnumSummary.OrderState.已付款) + ",payType=" + Convert.ToInt32(TravelAgent.Tool.EnumSummary.PayType.支付宝) + " where Id=" + Request.Form["v_rcvaddr"];
                    if (points > 0)
                    {
                        strsql += "insert into ClubPoints(clubid,Content,points,remark,pType,adddate) values ('" + (TravelAgent.Tool.CookieHelper.GetCookieValue("uid")) + "','产品预订使用积分，订单号:" + v_oid + "','" + points + "','','" + TravelAgent.Tool.EnumSummary.PointsType.产品预订 + "','" + DateTime.Now + "');";
                    }
                    strsql += "insert into ClubPoints(clubid,Content,points,remark,pType,adddate) values ('" + (TravelAgent.Tool.CookieHelper.GetCookieValue("uid")) + "','产品支付赠送积分，订单号:" + v_oid + "','" + donatepoints + "','','" + TravelAgent.Tool.EnumSummary.PointsType.赠送积分 + "','" + DateTime.Now + "');";
                    strsql += "update Club set currentPoints=currentPoints+" + (donatepoints - points) + " where Id=" + TravelAgent.Tool.CookieHelper.GetCookieValue("uid");
                    if (!string.IsNullOrEmpty(strsql))
                    {
                        //Access
                        //if (TravelAgent.Tool.DbHelperOleDb.ExecuteSql(strsql) > 0)
                        //SQL
                        if (TravelAgent.Tool.DbHelperSQL.ExecuteSql(strsql) > 0)
                        {
                            Response.Redirect("/OrderinfoSuc.aspx?pay=",false);
                        }
                        else
                        {
                            Response.Redirect("/Opr.aspx?t=error&msg=opr",false);
                        }
                    }
                    
                    //支付成功
                    //在这里商户可以写上自己的业务逻辑
                }
            }
            else
            {

                status_msg = "校验失败，数据可疑";
            }
        }
    }
}
