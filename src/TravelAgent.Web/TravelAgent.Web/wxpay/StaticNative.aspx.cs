using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TravelAgent.Web.wxpay
{
    public partial class StaticNative : TravelAgent.Web.UI.mBasePage
    {
        public string order_no;
        public string order_price;
        public int order_usepoints;
        public int order_donetpoints;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.Title = "微信扫码支付-"+Master.webinfo.WebName;
            order_no = Request.Form["ordercode"];
            //order_price = Request.Form["order_price"];
            order_price = Request.Form["channel_amount"];
            order_usepoints = Request.Form["txt_points"].ToString().Equals("")?0:Convert.ToInt32(Request.Form["txt_points"]);
            order_donetpoints = Request.Form["hddonatePoints"].ToString().Equals("")?0:Convert.ToInt32(Request.Form["hddonatePoints"]);
            string strsql = "update [Order] set usePoints=" + order_usepoints + ",donatePoints=" + order_donetpoints + ",payType=" + Convert.ToInt32(TravelAgent.Tool.EnumSummary.PayType.微信支付) + " where ordercode='" + order_no + "';";
            if (order_usepoints > 0)
            {
                strsql += "insert into ClubPoints(clubid,Content,points,remark,pType,adddate) values ('" + (TravelAgent.Tool.CookieHelper.GetCookieValue("uid")) + "'产品预订使用积分,'订单号:" + order_no + "','" + order_usepoints + "','','" + TravelAgent.Tool.EnumSummary.PointsType.产品预订 + "','" + DateTime.Now + "');";
            }
            if (order_donetpoints > 0)
            {
                strsql += "insert into ClubPoints(clubid,Content,points,remark,pType,adddate) values ('" + (TravelAgent.Tool.CookieHelper.GetCookieValue("uid")) + "','产品支付赠送积分，订单号:" + order_no + "','" + Request.Form["donatep"] + "','','" + TravelAgent.Tool.EnumSummary.PointsType.赠送积分 + "','" + DateTime.Now + "');";
            }

            strsql += "update Club set currentPoints=currentPoints+" + (order_donetpoints - order_usepoints) + " where Id=" + TravelAgent.Tool.CookieHelper.GetCookieValue("uid");
            
            int rowffect=TravelAgent.Tool.DbHelperSQL.ExecuteSql(strsql);
            if(rowffect==0)
            {
                Response.Redirect("/Opr.aspx?t=error&msg=opr", false);
            }
        }
    }
}
