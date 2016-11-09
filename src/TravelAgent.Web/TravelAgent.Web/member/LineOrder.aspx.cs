using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TravelAgent.Web.member
{
    public partial class LineOrder : System.Web.UI.Page
    {
        public int clubid;
        private static readonly TravelAgent.BLL.Order LineOrderBll = new TravelAgent.BLL.Order();

        protected void Page_Load(object sender, EventArgs e)
        {
            this.Title = "线路订单-" + Master.webinfo.WebName;
            string strUid = TravelAgent.Tool.CookieHelper.GetCookieValue("uid");
            if (string.IsNullOrEmpty(strUid))
            {
                Response.Redirect("/member/Login.aspx");
            }
            else
            {
                clubid = Convert.ToInt32(strUid);
            }
        }
        /// <summary>
        /// 显示线路订单
        /// </summary>
        public string ShowLineOrder()
        {
            StringBuilder sbLineOrder = new StringBuilder();
            DataSet dsLineOrder = LineOrderBll.GetList(0, "orderType="+Convert.ToInt32(TravelAgent.Tool.EnumSummary.OrderType.线路)+" and clubid=" + clubid, "orderDate desc");
            foreach (DataRow r in dsLineOrder.Tables[0].Rows)
            {
                sbLineOrder.Append("<tr>");
                sbLineOrder.Append("<td class=\"arial\">"+r["ordercode"]+"</td>");
                sbLineOrder.Append("<td class=\"order_pic\"><a href=\"/Line.aspx?id=" + r["lineId"] + "\"><img src=\"" + r["LinePic"] + "\" />" + r["ProName"] + "</a></td>");
                sbLineOrder.Append("<td class=\"arial order_price\">¥" + (Convert.ToInt32(r["orderPrice"]) + Convert.ToInt32(r["attachPrice"]) + Convert.ToInt32(r["subPrice"])) + "</td>");
                sbLineOrder.Append("<td>" + TravelAgent.Tool.EnumHelper.GetMemberName<TravelAgent.Tool.EnumSummary.OrderState>(r["orderState"]) + "</td>");
                sbLineOrder.Append("<td class=\"arial\">" + r["orderDate"] + "</td>");
                sbLineOrder.Append("<td class=\"order_operate\">");
                if (Convert.ToInt32(r["orderState"]) == Convert.ToInt32(TravelAgent.Tool.EnumSummary.OrderState.填写信息))
                {
                    sbLineOrder.Append("<a target=\"_blank\" href=\"/Order2.aspx?oid="+r["Id"]+"\">补充游客信息</a>");
                }
                else if (Convert.ToInt32(r["orderState"]) == Convert.ToInt32(TravelAgent.Tool.EnumSummary.OrderState.核对订单))
                {
                    sbLineOrder.Append("<a target=\"_blank\" href=\"/Order3.aspx?oid=" + r["Id"] + "\">核对订单</a>");
                }
                else if (Convert.ToInt32(r["orderState"]) == Convert.ToInt32(TravelAgent.Tool.EnumSummary.OrderState.待付款))
                {
                    sbLineOrder.Append("<a target=\"_blank\" href=\"/Order4.aspx?t=line&oid=" + r["Id"] + "\">付款</a>");
                }
                else
                {
                    sbLineOrder.Append("");
                }

                sbLineOrder.Append("</td>");
                sbLineOrder.Append("</tr>");
            }
            return sbLineOrder.ToString();
        }
    }
}
