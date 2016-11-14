using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Threading;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TravelAgent.Web
{
    public partial class Order : System.Web.UI.Page
    {
        public string ordertime = "";
        public int adult = 0;
        public int child = 0;
        public int id = 0;
        public int adultprice = 0;
        public int childprice = 0;
        public int totalprice = 0;
        public TravelAgent.Model.Line LineModel;
        public string strAttach = "";
        private static readonly TravelAgent.BLL.Line LineBll = new TravelAgent.BLL.Line();
        private static readonly TravelAgent.BLL.DepartureCity CityBll = new TravelAgent.BLL.DepartureCity();
        private static readonly TravelAgent.BLL.LineSpePrice SpePriceBll = new TravelAgent.BLL.LineSpePrice();
        private static readonly TravelAgent.BLL.Insure InsureBll = new TravelAgent.BLL.Insure();
        private static readonly TravelAgent.BLL.Order LineOrderBll = new TravelAgent.BLL.Order();
        private static readonly TravelAgent.BLL.Club ClubBll = new TravelAgent.BLL.Club();
        public TravelAgent.Model.Club CurClub;
        protected void Page_Load(object sender, EventArgs e)
        {
            //check if the user login - write by jjh
            CheckLogin();

            this.Title = "填写订单-" + Master.webinfo.WebName;
            int.TryParse(Request.QueryString["adult"], out adult);
            int.TryParse(Request.QueryString["child"], out child);
            int.TryParse(Request.QueryString["id"], out id);
            if (Request.QueryString["ordertime"] != null)
            {
                ordertime = Request.QueryString["ordertime"];
            }
            if (!this.IsPostBack)
            {
                if (id > 0)
                {
                    DateTime orderdate;
                    LineModel = LineBll.GetModel(id);
                    if (LineModel != null && DateTime.TryParseExact(ordertime, "yyyyMMdd", Thread.CurrentThread.CurrentCulture, System.Globalization.DateTimeStyles.None, out orderdate))
                    {
                        ordertime = orderdate.ToString("yyyy-MM-dd");
                        string strspeprice = getSpePrice(id, ordertime);
                        if (strspeprice.Equals(""))
                        {
                            adultprice = Convert.ToInt32(LineModel.PriceContent.Split(',')[2]);
                            childprice = Convert.ToInt32(LineModel.PriceContent.Split(',')[3]);
                        }
                        else
                        {
                            adultprice = Convert.ToInt32(strspeprice.Split(',')[0]);
                            childprice = Convert.ToInt32(strspeprice.Split(',')[1]);
                        }
                        totalprice = adult * adultprice + child * childprice;
                        if (LineModel.InsureId == 0)
                        {
                            strAttach = "-<span style=\"color:#ff6600\">赠送保险</span>";
                            this.divattach.Style["display"] = "none";
                        }
                    }
                }
                int uid = 0;
                if (!string.IsNullOrEmpty(TravelAgent.Tool.CookieHelper.GetCookieValue("uid")) && int.TryParse(TravelAgent.Tool.CookieHelper.GetCookieValue("uid"), out uid))
                {
                    CurClub = ClubBll.GetModel(uid);
                }
                if (CurClub == null)
                {
                    CurClub = new TravelAgent.Model.Club();
                }
                //预订第一步
                if (Request["txtHiddenPId"] != null)
                {
                    TravelAgent.Model.Order order = new TravelAgent.Model.Order();
                    order.lineId = id;
                    order.ordercode = "O" + DateTime.Now.ToString("yyyyMMddHHmmssfff");
                    int txtHiddenPersonNum;
                    int txtHiddenChildNum;
                    int.TryParse(Request["txtHiddenPersonNum"], out txtHiddenPersonNum);
                    int.TryParse(Request["txtHiddenChildNum"], out txtHiddenChildNum);
                    order.peopleNumber = txtHiddenPersonNum + txtHiddenChildNum;
                    order.adultNumber = txtHiddenPersonNum;
                    order.childNumber = txtHiddenChildNum;
                    order.orderDate = DateTime.Now;
                    order.TravelDate = ordertime;
                    order.orderPrice = totalprice;
                    int txtHiddenAttachPrice;
                    int.TryParse(Request["txtHiddenAttachPrice"], out txtHiddenAttachPrice);
                    order.attachPrice = txtHiddenAttachPrice;
                    order.usePoints = 0;
                    order.donatePoints = 0;
                    order.contactName = Request["txt_name"];
                    order.contactMobile = Request["txt_mobile"];
                    order.contactEmail = Request["txt_email"];
                    order.contactTelephone = Request["txt_start_phone"] + "-" + Request["txt_end_phone"];
                    order.orderRemark = Request["txt_des"];
                    order.operRemark = "";
                    order.orderState = Convert.ToInt32(TravelAgent.Tool.EnumSummary.OrderState.填写信息);
                    order.clubid = uid;
                    order.adultPrice = adultprice;
                    order.childPrice = childprice;
                    order.payType = 0;
                    order.subPrice = 0;
                    order.orderType = Convert.ToInt32(TravelAgent.Tool.EnumSummary.OrderType.线路);
                    order.contactSex = "";
                    order.sourceType = Convert.ToInt32(TravelAgent.Tool.EnumSummary.SourceType.PC网页);
                    order.tuijianren = Request["txtHiddentuijianren"];
                    try
                    {
                        int orderid = LineOrderBll.Add(order);

                        if (orderid > 0 & order.clubid > 0)
                        {
                            //urlrewrite
                            Response.Redirect("/lineorder/2/" + orderid + ".html", false);
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
            if (LineModel == null) Response.Redirect("/Opr.aspx?t=error&msg=opr");
        }
        /// <summary>
        /// 显示城市名称
        /// </summary>
        /// <param name="cityId"></param>
        /// <returns></returns>
        public string ShowCityName(int cityId)
        {
            TravelAgent.Model.DepartureCity city = CityBll.GetModel(cityId);
            return city != null ? city.CityName : "";
        }
        /// <summary>
        /// 获得特殊日期价格
        /// </summary>
        /// <param name="lineid"></param>
        /// <param name="pricecontent"></param>
        /// <returns></returns>
        public string getSpePrice(int lineid, string date)
        {
            string strValue = "";
            List<TravelAgent.Model.LineSpePrice> listSpePrice = SpePriceBll.GetlstSpePriceByLineId(lineid);
            foreach (TravelAgent.Model.LineSpePrice price in listSpePrice)
            {
                if (price.lineDate.Equals(date))
                {
                    if (price.tag == 1)//新增的价格
                    {
                        strValue = price.linePrice.Split(',')[2] + "," + price.linePrice.Split(',')[3];
                    }
                    else if (price.tag == 0)//删除的价格
                    {
                        strValue = "";
                    }
                    break;
                }
            }
            return strValue;
        }
        /// <summary>
        /// 绑定附加产品
        /// </summary>
        /// <returns></returns>
        public string BindAttach()
        {
            StringBuilder sbAttach = new StringBuilder();
            if (id > 0)
            {
                TravelAgent.Model.Insure model = InsureBll.GetModel(LineModel.InsureId);
                if (model != null)
                {
                    sbAttach.Append("<tr id=\"tr_0\">");
                    sbAttach.Append("<td class=\"lt\">");
                    sbAttach.Append("<a href=\"javascript:void(0);\" style=\"line-height: 17px;\" id=\"atoggle_0\">");
                    sbAttach.Append("<span class=\"arrowFlag\">▼</span><span id=\"a_0\">" + model.InsureName + "</span>");
                    sbAttach.Append("</a>");
                    sbAttach.Append("</td>");
                    sbAttach.Append("<td><b>¥</b><b id=\"td_price_0\">" + model.InsurePrice + "</b></td>");
                    sbAttach.Append("<td><input type=\"hidden\" id=\"hdunits_0\" value=\"元/人\" />元/人</td>");
                    sbAttach.Append("<td>");
                    sbAttach.Append("<input id=\"txtHiddenDefaultNums_0\" type=\"hidden\" />");
                    sbAttach.Append("<input id=\"txtHiddenAddProductTypeId_0\" type=\"hidden\" value=\"3\" />");
                    sbAttach.Append("<select id=\"ddl_nums_0\" name=\"insure\" style=\"min-width: 34px;\"></select>");
                    sbAttach.Append("</td>");
                    sbAttach.Append("<td><b>¥</b><b id=\"td_total_0\">0</b></td>");
                    sbAttach.Append("</tr>");
                    sbAttach.Append("<tr class=\"trhide\">");
                    sbAttach.Append("<td colspan=\"6\" style=\"text-align: left; color: #666; line-height: 22px;\">");
                    sbAttach.Append("" + model.InsureContent + "");
                    sbAttach.Append("</td>");
                    sbAttach.Append("</tr>");
                }
            }
            return sbAttach.ToString();
        }

        private void CheckLogin()
        {
            string user_id = TravelAgent.Tool.CookieHelper.GetCookieValue("uid");

            if(string.IsNullOrWhiteSpace(user_id))
            {
                Response.Redirect("/Opr.aspx?t=o&msg=locked");
            }
        }
    }
}
