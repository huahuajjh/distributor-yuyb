using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TravelAgent.Web.mTravel.data
{
    public partial class addorder : System.Web.UI.Page
    {
        public string ordercode = "";
        private static readonly TravelAgent.BLL.Category CateBll = new TravelAgent.BLL.Category();
        private static readonly TravelAgent.BLL.Order OrderBll = new TravelAgent.BLL.Order();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (Request["lineid"] != null)
                {
                    TravelAgent.Model.Order order = new TravelAgent.Model.Order();
                    order.lineId = Convert.ToInt32(Request["lineid"]);
                    ordercode = "O" + DateTime.Now.ToString("yyyyMMddHHmmssfff");
                    order.ordercode = ordercode;
                    order.peopleNumber = Convert.ToInt32(Request["renshu1"]) + Convert.ToInt32(Request["renshu2"]);
                    order.adultNumber = Convert.ToInt32(Request["renshu1"]);
                    order.childNumber = Convert.ToInt32(Request["renshu2"]);
                    order.orderDate = DateTime.Now;
                    order.TravelDate = Request["shijian1"];
                    order.orderPrice = Convert.ToInt32(Request["adult_price"]) * Convert.ToInt32(Request["renshu1"]) + Convert.ToInt32(Request["child_price"]) * Convert.ToInt32(Request["renshu2"]);
                    order.attachPrice = Convert.ToInt32(Request["bx_price"]) * Convert.ToInt32(Request["renshu3"]);
                    order.usePoints = 0;
                    order.donatePoints = 0;
                    order.contactName = Request["xingming"];
                    order.contactMobile = Request["dianhua"];
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
                    order.IDcard = Request["IDcard"];
                    order.tuijianren = Request["tuijianren"];
                    order.orderType = Convert.ToInt32(Request["order_type"]);
                    order.contactSex = "";
                    order.sourceType = Convert.ToInt32(TravelAgent.Tool.EnumSummary.SourceType.移动WAP);
                    try
                    {
                        int orderid = OrderBll.Add(order);

                        if (orderid > 0)
                        {
                            Response.Redirect("../weipay/ordertip.aspx?o=" + ordercode,false);
                        }
                        else
                        {
                            Response.Redirect("../MOrderMsg.aspx?msg=订单提交失败&class=error", false);
                        }

                    }
                    catch (Exception ex)
                    {
                        Response.Redirect("../MOrderMsg.aspx?msg=订单提交失败&class=error", false);
                    }
                }
            }
        }
    }
}
