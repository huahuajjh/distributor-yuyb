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
    public partial class Index : System.Web.UI.Page
    {
        public string strPasswordStrengthcss = "weak";
        public TravelAgent.Model.Club club;
        private static readonly TravelAgent.BLL.Club clubBll = new TravelAgent.BLL.Club();
        private static readonly TravelAgent.BLL.Order LineOrderBll = new TravelAgent.BLL.Order();

        private static readonly TravelAgent.BLL.Line LineBll = new TravelAgent.BLL.Line();
        private static readonly TravelAgent.BLL.VisaList VisaListBll = new TravelAgent.BLL.VisaList();
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Title = "会员中心-" + Master.webinfo.WebName;
            string strUid = TravelAgent.Tool.CookieHelper.GetCookieValue("uid");
            if (string.IsNullOrEmpty(strUid))
            {
                Response.Redirect("/member/Login.aspx");
            }
            else
            {
                club = clubBll.GetModel(Convert.ToInt32(strUid));
                if (TravelAgent.Tool.StringPlus.PasswordStrength(club.clubPwd) == TravelAgent.Tool.EnumSummary.Strength.Normal)
                {
                    strPasswordStrengthcss = "middle";
                }
                else if (TravelAgent.Tool.StringPlus.PasswordStrength(club.clubPwd) == TravelAgent.Tool.EnumSummary.Strength.Strong)
                {
                    strPasswordStrengthcss = "strong";
                }
            }
        }
        /// <summary>
        /// 显示手机验证
        /// </summary>
        /// <returns></returns>
        public string ShowMobileValidate()
        {
            string strvalue = "<img src=\"/member/images/ico_tel_gray.gif\" alt=\"手机验证图标\" title=\"手机未验证\" class=\"sjTb\"/>";
            if (club.mobileIsValid == 1)
            {
                strvalue = "<img src=\"/member/images/ico_tel.gif\" alt=\"手机验证图标\" title=\"手机已验证\" class=\"sjTb\"/>";
            }
            return strvalue;
        }
        /// <summary>
        /// 显示邮箱验证
        /// </summary>
        /// <returns></returns>
        public string ShowEmailValidate()
        {
            string strvalue = "<img class=\"sjTb\" title=\"邮箱未验证\" alt=\"邮箱验证图标\" src=\"/member/images/ico_email_gray.gif\">";
            if (club.emailIsValid == 1)
            {
                strvalue = "<img class=\"sjTb\" title=\"邮箱已验证\" alt=\"邮箱验证图标\" src=\"/member/images/ico_email.gif\">";
            }
            return strvalue;
        }
        /// <summary>
        /// 显示线路订单
        /// </summary>
        public string ShowLineOrder()
        {
            StringBuilder sbLineOrder = new StringBuilder();
            DataSet dsLineOrder = LineOrderBll.GetList(5, "clubid=" + club.id, "orderDate desc");
            string proname = "";
            string propic = "";
            TravelAgent.Model.Line linem = null;
            TravelAgent.Model.VisaList visa = null;
            foreach (DataRow r in dsLineOrder.Tables[0].Rows)
            {
                sbLineOrder.Append("<tr>");
                sbLineOrder.Append("<td class=\"arial\">" + r["ordercode"] + "</td>");
                if (Convert.ToInt32(r["orderType"]) == Convert.ToInt32(TravelAgent.Tool.EnumSummary.OrderType.线路))
                {
                    linem = LineBll.GetModel(Convert.ToInt32(r["lineId"]));
                    if (linem != null)
                    {
                        proname = linem.LineName;
                        propic = linem.LinePic;
                    }
                    sbLineOrder.Append("<td class=\"order_pic\"><a href=\"/Line.aspx?id=" + r["lineId"] + "\"><img src=\"" + propic + "\" />" + proname + "</a></td>");
                }
                else if (Convert.ToInt32(r["orderType"]) == Convert.ToInt32(TravelAgent.Tool.EnumSummary.OrderType.签证))
                {
                    visa = VisaListBll.GetModel(Convert.ToInt32(r["lineId"]));
                    if (visa != null)
                    {
                        proname = visa.visaName;
                        propic = visa.picurl;
                    }
                    sbLineOrder.Append("<td class=\"order_pic\"><a href=\"/visa/VisaDetail.aspx?id=" + r["lineId"] + "\" target=\"_blank\"><img src=\"" + propic + "\" />" + proname + "</a></td>");
                }
                //sbLineOrder.Append("<td class=\"order_pic\"><a href=\"/Line.aspx?id=" + r["lineId"] + "\"><img src=\"" + r["LinePic"] + "\" />" + r["ProName"] + "</a></td>");
                sbLineOrder.Append("<td class=\"arial\">" + TravelAgent.Tool.EnumHelper.GetMemberName<TravelAgent.Tool.EnumSummary.OrderType>(r["orderType"]) + "</td>");
                sbLineOrder.Append("<td class=\"arial order_price\">¥" + (Convert.ToInt32(r["orderPrice"]) + Convert.ToInt32(r["attachPrice"])).ToString() + "</td>");
                sbLineOrder.Append("<td>" + TravelAgent.Tool.EnumHelper.GetMemberName<TravelAgent.Tool.EnumSummary.OrderState>(r["orderState"]) + "</td>");
                sbLineOrder.Append("<td class=\"arial\">" + r["orderDate"] + "</td>");
                if (Convert.ToInt32(r["orderState"]) == Convert.ToInt32(TravelAgent.Tool.EnumSummary.OrderState.填写信息))
                {
                    sbLineOrder.Append("<td class=\"order_operate\"><a target=\"_blank\" href=\"/Order2.aspx?oid=" + r["Id"] + "\">补充游客信息</a>");
                }
                else if (Convert.ToInt32(r["orderState"]) == Convert.ToInt32(TravelAgent.Tool.EnumSummary.OrderState.核对订单))
                {
                    sbLineOrder.Append("<td class=\"order_operate\"><a target=\"_blank\" href=\"/Order3.aspx?oid=" + r["Id"] + "\">核对订单</a>");
                }
                else if (Convert.ToInt32(r["orderState"]) == Convert.ToInt32(TravelAgent.Tool.EnumSummary.OrderState.待付款))
                {
                    sbLineOrder.Append("<td class=\"order_operate\"><a target=\"_blank\" href=\"/Order4.aspx?t=line&oid=" + r["Id"] + "\">付款</a>");
                }
                else
                {
                    sbLineOrder.Append("<td class=\"order_operate\">");
                }

                sbLineOrder.Append("</td>");
                sbLineOrder.Append("</tr>");
            }
            return sbLineOrder.ToString();
        }
    }
}
