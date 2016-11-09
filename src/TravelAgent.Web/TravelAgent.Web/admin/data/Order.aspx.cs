using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TravelAgent.Web.admin.data
{
    public partial class Order : System.Web.UI.Page
    {
        private static readonly TravelAgent.BLL.Order LineOrderBll = new TravelAgent.BLL.Order();
        //private static readonly TravelAgent.BLL.VisaOrder VisaOrderBll = new TravelAgent.BLL.VisaOrder();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                //删除线路订单
                if (Request["lineorderid"]!=null)
                {
                    if (LineOrderBll.Delete(Convert.ToInt32(Request["lineorderid"])) > 0)
                    {
                        Response.Write("true");
                    }
                    else
                    {
                        Response.Write("false");
                    }
                }
                ////删除签证订单
                //if (Request["visaorderid"] != null)
                //{
                //    if (VisaOrderBll.Delete(Convert.ToInt32(Request["visaorderid"])) > 0)
                //    {
                //        Response.Write("true");
                //    }
                //    else
                //    {
                //        Response.Write("false");
                //    }
                //}
                //线路订单操作
                if (Request["orderid"] != null)
                {
                    string strsubprice = Request["subprice"] == "" ? "0" : Request["subprice"];
                    int usepoints = Request["usepoints"].Equals("") ? 0 : Convert.ToInt32(Request["usepoints"]);
                    int donatepoints = string.IsNullOrEmpty(Request["donatepoints"])? 0 : Convert.ToInt32(Request["donatepoints"]);
                    int orderstate = Convert.ToInt32(Request["orderstate"]);
                    string oprremark = Request["oprremark"];
                    string paytype = Request["paytype"];
                    int clubid = Convert.ToInt32(Request["clubid"]);
                    string strsql = "update [Order] set subPrice=" + strsubprice + ",usePoints=" + usepoints + ",donatePoints="+donatepoints+",orderState=" + orderstate + ",operRemark='" + oprremark + "',payType=" + paytype + " where Id=" + Request["orderid"] + ";";

                    if (usepoints > 0)
                    {
                        strsql += "insert into ClubPoints(clubid,Content,points,remark,pType,adddate) values ('" + clubid + "'产品预订使用积分,'订单号:" + Request.Form["ordercode"] + "','" + usepoints + "','','" + TravelAgent.Tool.EnumSummary.PointsType.产品预订 + "','" + DateTime.Now + "');";
                    }

                    if (orderstate == Convert.ToInt32(TravelAgent.Tool.EnumSummary.OrderState.预订成功))
                    {
                        strsql += "insert into ClubPoints(clubid,Content,points,remark,pType,adddate) values ('" + clubid + "','产品支付赠送积分，订单号:" + Request.Form["ordercode"] + "','" + Request.Form["donatep"] + "','','" + TravelAgent.Tool.EnumSummary.PointsType.赠送积分 + "','" + DateTime.Now + "');";
                    }
                    strsql += "update Club set currentPoints=currentPoints+" + (donatepoints - usepoints) + " where Id=" + clubid;

                    //Access
                    // if (TravelAgent.Tool.DbHelperOleDb.ExecuteSql(strsql) > 0)
                    //SQL
                    if (TravelAgent.Tool.DbHelperSQL.ExecuteSql(strsql) > 0)
                    {
                        Response.Write("true");
                    }
                    else
                    {
                        Response.Write("false");
                    }
                }

                ////签证订单操作
                //if (Request["vsorderid"] != null)
                //{
                //    string strsubprice = Request["subprice"] == "" ? "0" : Request["subprice"];
                //    string strusepoints = Request["usepoints"];
                //    string orderstate = Request["orderstate"];
                //    string oprremark = Request["oprremark"];
                //    string paytype = Request["paytype"];
                //    string strsql = "update VisaOrder set subPrice=" + strsubprice + ",usePoints=" + strusepoints + ",orderState=" + orderstate + ",operateRemark='" + oprremark + "',payType=" + paytype + " where Id=" + Request["vsorderid"];
                //    if (TravelAgent.Tool.DbHelperOleDb.ExecuteSql(strsql) > 0)
                //    {
                //        Response.Write("true");
                //    }
                //    else
                //    {
                //        Response.Write("false");
                //    }
                //}
            }
        }
    }
}
