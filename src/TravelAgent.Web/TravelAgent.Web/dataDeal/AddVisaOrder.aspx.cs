using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TravelAgent.Web.dataDeal
{
    public partial class AddVisaOrder : System.Web.UI.Page
    {
        private static readonly TravelAgent.BLL.Order OrderBll = new TravelAgent.BLL.Order();
        protected void Page_Load(object sender, EventArgs e)
        {
            string strUid = TravelAgent.Tool.CookieHelper.GetCookieValue("uid");
            if (string.IsNullOrEmpty(strUid))
            {
                Response.Redirect("/member/Login.aspx");
            }
            else
            {
                if (Request["realname"] != null)
                {
                    TravelAgent.Model.Order order = new TravelAgent.Model.Order();
                    order.lineId = Convert.ToInt32(Request["visa_id"]);
                    order.TravelDate = Request["godate"];
                    order.peopleNumber = Convert.ToInt32(Request["personcount"]);
                    order.adultNumber = 0;
                    order.childNumber = 0;
                    order.orderRemark = Request["remark"];
                    order.contactName = Request["realname"];
                    order.contactSex = Request["sex"];
                    order.contactMobile = Request["mobile"];
                    order.contactEmail = Request["email"];
                    order.contactTelephone = "";
                    order.orderPrice = Convert.ToInt32(Request["personcount"]) * Convert.ToInt32(Request["visa_price"]);
                    order.attachPrice = 0;
                    order.usePoints = 0;
                    order.donatePoints = 0;
                    order.adultPrice = 0;
                    order.childPrice = 0;
                    order.payType = 0;
                    order.operRemark = "";
                    order.orderState = Convert.ToInt32(TravelAgent.Tool.EnumSummary.OrderState.处理中);
                    order.clubid = Convert.ToInt32(strUid);
                    order.orderDate = DateTime.Now;
                    order.ordercode = "O" + DateTime.Now.ToString("yyyyMMddHHmmssfff");
                    order.subPrice = 0;
                    order.orderType = Convert.ToInt32(TravelAgent.Tool.EnumSummary.OrderType.签证);
                    order.sourceType = Convert.ToInt32(TravelAgent.Tool.EnumSummary.SourceType.PC网页);
                    //order.vid = Convert.ToInt32(Request["visa_id"]);
                    //order.travelDate = Request["godate"];
                    //order.travelPeopleNum = Convert.ToInt32(Request["personcount"]);
                    //order.travelRemark = Request["remark"];
                    //order.guestName = Request["realname"];
                    //order.guestSex = Request["sex"];
                    //order.guestMobile = Request["mobile"];
                    //order.guestEmail = Request["email"];
                    //order.orderPrice = Convert.ToInt32(Request["personcount"]) * Convert.ToInt32(Request["visa_price"]);
                    //order.usePoints = 0;
                    //order.operateRemark = "";
                    //order.orderState = Convert.ToInt32(TravelAgent.Tool.EnumSummary.LineOrderState.处理中);
                    //order.clubid = Convert.ToInt32(strUid);
                    //order.adddate = DateTime.Now;
                    //order.ordercode = "V" + DateTime.Now.ToString("yyyyMMddHHmmssfff");
                    if (OrderBll.Add(order) > 0)
                    {
                        Response.Write("success");
                    }
                    else
                    {
                        Response.Write("error");
                    }
                }
            }
        }
    }
}
