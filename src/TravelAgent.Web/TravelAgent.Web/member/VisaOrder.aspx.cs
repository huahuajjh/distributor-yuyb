using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TravelAgent.Web.member
{
    public partial class VisaOrder : System.Web.UI.Page
    {
        public int clubid;
        private static readonly TravelAgent.BLL.VisaList VisaListBll = new TravelAgent.BLL.VisaList();
        private static readonly TravelAgent.BLL.Order OrderBll = new TravelAgent.BLL.Order();
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Title = "签证订单-" + Master.webinfo.WebName;
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
        public string ShowVisaOrder()
        {
            StringBuilder sbVisaOrder = new StringBuilder();
            DataSet dsVisaOrder = OrderBll.GetList(0, "orderType="+Convert.ToInt32(TravelAgent.Tool.EnumSummary.OrderType.签证) +" and clubid=" + clubid, "orderDate desc");
            TravelAgent.Model.VisaList model = null;
            string strpicurl = "";
            foreach (DataRow r in dsVisaOrder.Tables[0].Rows)
            {
                model = VisaListBll.GetModel(Convert.ToInt32(r["lineId"]));
                if (model != null)
                {
                    sbVisaOrder.Append("<tr>");
                    sbVisaOrder.Append("<td class=\"arial\">" + r["ordercode"] + "</td>");
                    strpicurl = model.picurl.Equals("") ? "/images/no_image.gif" : model.picurl;
                    sbVisaOrder.Append("<td class=\"order_pic\"><a href=\"/visa/VisaDetail.aspx?id=" + r["lineId"] + "\" target=\"_blank\"><img src=\"" + strpicurl + "\" />" + model.visaName + "</a></td>");
                    sbVisaOrder.Append("<td class=\"arial order_price\">¥" + (Convert.ToInt32(r["orderPrice"]) + Convert.ToInt32(r["attachPrice"]) + Convert.ToInt32(r["subPrice"])) + "</td>");
                    sbVisaOrder.Append("<td>" + TravelAgent.Tool.EnumHelper.GetMemberName<TravelAgent.Tool.EnumSummary.OrderState>(r["orderState"]) + "</td>");
                    sbVisaOrder.Append("<td class=\"arial\">" + r["orderDate"] + "</td>");
                    sbVisaOrder.Append("<td class=\"order_operate\">");
                    if (Convert.ToInt32(r["orderState"]) == Convert.ToInt32(TravelAgent.Tool.EnumSummary.OrderState.填写信息))
                    {
                        sbVisaOrder.Append("<a target=\"_blank\" href=\"/Order2.aspx?oid=" + r["Id"] + "\">补充游客信息</a>");
                    }
                    else if (Convert.ToInt32(r["orderState"]) == Convert.ToInt32(TravelAgent.Tool.EnumSummary.OrderState.核对订单))
                    {
                        sbVisaOrder.Append("<a target=\"_blank\" href=\"/Order3.aspx?oid=" + r["Id"] + "\">核对订单</a>");
                    }
                    else if (Convert.ToInt32(r["orderState"]) == Convert.ToInt32(TravelAgent.Tool.EnumSummary.OrderState.待付款))
                    {
                        sbVisaOrder.Append("<a target=\"_blank\" href=\"/Order4.aspx?t=visa&oid=" + r["Id"] + "\">付款</a>");
                    }
                    sbVisaOrder.Append("</td>");
                    sbVisaOrder.Append("</tr>");
                }
               
            }
            return sbVisaOrder.ToString();
        }
    }
}
