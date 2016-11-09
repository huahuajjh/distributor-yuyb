using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TravelAgent.Web.car
{
    public partial class CarOrder1 : TravelAgent.Web.UI.mBasePage
    {
        private static readonly TravelAgent.BLL.CarList CarBll = new TravelAgent.BLL.CarList();
        private static readonly TravelAgent.BLL.CarPrice CarPriceBll = new TravelAgent.BLL.CarPrice();
        private static readonly TravelAgent.BLL.Club ClubBll = new TravelAgent.BLL.Club();
        public TravelAgent.Model.CarList CarModel;
        public TravelAgent.Model.CarPrice CarPriceModel;
        public TravelAgent.Model.Club CurClub;
        public int cid;
        public int pid;
        public string strYCDate;
        public string strHCDate;
        private static readonly TravelAgent.BLL.Order LineOrderBll = new TravelAgent.BLL.Order();
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Title ="租车预订_" + Master.webinfo.WebName;
            if (!this.IsPostBack)
            {
                if (Request.QueryString["cid"] != null)
                {
                    cid = Convert.ToInt32(Request.QueryString["cid"]);
                    CarModel = CarBll.GetModel(cid);
                }
                if (Request.QueryString["pcid"] != null)
                {
                    pid = Convert.ToInt32(Request.QueryString["pcid"]);
                    CarPriceModel = CarPriceBll.GetModel(pid);
                   
                    if (CarPriceModel.CarTypeID == 1)//旅游租车
                    {
                        this.trHuan.Style["display"] = "none";
                    }
                }
                if (CarModel == null || CarPriceModel == null)
                {
                    Response.Redirect("/Opr.aspx?msg=no");
                }
                if (!string.IsNullOrEmpty(TravelAgent.Tool.CookieHelper.GetCookieValue("uid")))
                {
                    CurClub = ClubBll.GetModel(Convert.ToInt32(TravelAgent.Tool.CookieHelper.GetCookieValue("uid")));
                }
                else
                {
                    CurClub = new TravelAgent.Model.Club();
                }
                strYCDate = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd");
                strHCDate = Convert.ToDateTime(strYCDate).AddDays(1).ToString("yyyy-MM-dd");

                if (Request["txtHiddenCId"] != null)
                {
                    TravelAgent.Model.Order order = new TravelAgent.Model.Order();
                    order.lineId = Convert.ToInt32(Request["txtHiddenCId"]);
                    order.ordercode = "O" + DateTime.Now.ToString("yyyyMMddHHmmssfff");
                    order.peopleNumber = Convert.ToInt32(Request["txtHiddenPId"]);
                    order.adultNumber = 0;
                    order.childNumber = 0;
                    order.orderDate = DateTime.Now;
                    order.TravelDate = "";
                    order.orderPrice = Convert.ToInt32(Request["txtHiddenOrderPrice"]);
                    order.attachPrice = 0;
                    order.usePoints = 0;
                    order.donatePoints = 0;
                    order.contactName = Request["txt_name"];
                    order.contactMobile = Request["txt_mobile"];
                    order.contactEmail = Request["txt_email"];
                    order.contactTelephone = Request["txt_start_phone"] + "-" + Request["txt_end_phone"];
                    order.orderRemark = Request["txt_des"];
                    order.operRemark = "";
                    order.orderState = Convert.ToInt32(TravelAgent.Tool.EnumSummary.OrderState.处理中);
                    if (string.IsNullOrEmpty(TravelAgent.Tool.CookieHelper.GetCookieValue("uid")))
                    {
                        order.clubid = 0;
                    }
                    else
                    {
                        order.clubid = Convert.ToInt32(TravelAgent.Tool.CookieHelper.GetCookieValue("uid"));
                    }
                    order.adultPrice = 0;
                    order.childPrice = 0;
                    order.payType = 0;
                    order.subPrice = 0;
                    order.orderType = Convert.ToInt32(TravelAgent.Tool.EnumSummary.OrderType.租车);
                    order.contactSex = "";
                    order.sourceType = Convert.ToInt32(TravelAgent.Tool.EnumSummary.SourceType.PC网页);
                    order.usedate = Request["txtHiddenYongcheDate"];
                    order.timedot = Convert.ToInt32(Request["timedot"]);
                    order.huandate = Request["txtHiddenHuancheDate"];
                    order.account = Convert.ToInt32(Request["selYongchecount"]);
                    try
                    {
                        int orderid = LineOrderBll.Add(order);

                        if (orderid > 0 & order.clubid > 0)
                        {
                            //urlrewrite
                            Response.Redirect("/car/CarOrder2.aspx?cid="+cid+"&pcid="+pid+"&oid="+orderid+"", false);
                        }
                        else
                        {
                            Response.Redirect("/Opr.aspx?t=error&msg=opr");
                        }
                    }
                    catch (Exception ex)
                    {
                        Response.Redirect("/Opr.aspx?t=error&msg=opr");
                    }
                }
            }
        }
    }
}
