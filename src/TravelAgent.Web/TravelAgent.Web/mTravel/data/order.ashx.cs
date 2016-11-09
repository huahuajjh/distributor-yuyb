using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TravelAgent.Web.mTravel.data
{
    /// <summary>
    /// $codebehindclassname$ 的摘要说明
    /// </summary>
    public class order : IHttpHandler
    {
        private static readonly TravelAgent.BLL.Order LineOrderBll = new TravelAgent.BLL.Order();
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            if (context.Request["line_id"] != null)
            {
                TravelAgent.Model.Order order = new TravelAgent.Model.Order();
                order.lineId = Convert.ToInt32(context.Request["line_id"]);
                order.ordercode = "O" + DateTime.Now.ToString("yyyyMMddHHmmssfff");
                order.peopleNumber = Convert.ToInt32(context.Request["line_ren"]);
                order.adultNumber = 0;
                order.childNumber = 0;
                order.orderDate = DateTime.Now;
                order.TravelDate = "";
                order.orderPrice = 0;
                order.attachPrice = 0;
                order.usePoints = 0;
                order.donatePoints = 0;
                order.contactName = context.Request["line_name"];
                order.contactMobile = context.Request["line_phone"];
                order.contactEmail = "";
                order.contactTelephone = "";
                order.orderRemark = "";
                order.operRemark = "";
                order.orderState = Convert.ToInt32(TravelAgent.Tool.EnumSummary.OrderState.处理中);
                order.clubid = 0;
                order.adultPrice = 0;
                order.childPrice = 0;
                order.payType = 0;
                order.subPrice = 0;

                order.orderType = Convert.ToInt32(context.Request["order_type"]);
                order.contactSex = "";
                order.sourceType = Convert.ToInt32(TravelAgent.Tool.EnumSummary.SourceType.移动WAP);
                try
                {
                    int orderid = LineOrderBll.Add(order);

                    if (orderid>0)
                    {
                        context.Response.Write("true");
                    }
                    else
                    {
                        context.Response.Write("false");
                    }
                }
                catch (Exception ex)
                {
                    context.Response.Write("false");
                }
            }
           
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}
