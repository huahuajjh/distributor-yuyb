using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TravelAgent.Web
{
    public partial class Order3 : System.Web.UI.Page
    {
        public string strAgreeMent;
        public int oid;
        public TravelAgent.Model.Line Line;
        public TravelAgent.Model.Order order;
        private static readonly TravelAgent.BLL.Order LineOrderBll = new TravelAgent.BLL.Order();
        private static readonly TravelAgent.BLL.Line LineBll = new TravelAgent.BLL.Line();
        private static readonly TravelAgent.BLL.Insure InsureBll = new TravelAgent.BLL.Insure();
        private static readonly TravelAgent.BLL.LineOrderTourist OTBll = new TravelAgent.BLL.LineOrderTourist();
        private static readonly TravelAgent.BLL.DepartureCity CityBll = new TravelAgent.BLL.DepartureCity();
        private static readonly TravelAgent.BLL.InfoSetting bll = new TravelAgent.BLL.InfoSetting();
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Title = "核对订单-" + Master.webinfo.WebName;
            int.TryParse(Request.QueryString["oid"], out oid);
            if (!this.IsPostBack)
            {
                TravelAgent.Model.InfoSetting info = new TravelAgent.Model.InfoSetting();
                info.ds = bll.GetList();

                if (oid > 0)
                {
                    order = LineOrderBll.GetModel(oid);
                    if (order != null)
                    {
                        Line = LineBll.GetModel(order.lineId);
                        if (Line != null)
                        {
                            if (Line.DestId==1)//出境
                            {
                                strAgreeMent = info.getValue("CJAgreeMent");
                            }
                            else//国内、周边
                            {
                                strAgreeMent = info.getValue("GNAgreeMent");
                            }
                        }
                    }
                    else
                    {
                        Response.Redirect("/Opr.aspx?t=error&msg=opr", false);
                    }
                }
                else
                {
                    Response.Redirect("/Opr.aspx?t=error&msg=opr", false);
                }

                if (Request["txtHiddenOrderId"] != null)
                {
                    string strsql="";
                    if (Line.DealType == Convert.ToInt32(TravelAgent.Tool.EnumSummary.DealType.自动处理))
                    {
                        strsql = "update [Order] set orderState=" + Convert.ToInt32(TravelAgent.Tool.EnumSummary.OrderState.待付款) + " where Id=" + oid;
                    }
                    else
                    {
                        strsql = "update [Order] set orderState=" + Convert.ToInt32(TravelAgent.Tool.EnumSummary.OrderState.处理中) + " where Id=" + oid;
                    }
                    if (TravelAgent.Tool.DbHelperSQL.ExecuteSql(strsql) > 0)
                    {
                        //urlrewrite
                        Response.Redirect("/lineorder/5/" + oid+".html", false);
                    }
                    else
                    {
                        Response.Redirect("/Opr.aspx?t=error&msg=opr", false);
                    }
                }
            }
            if (order == null) { Response.Redirect("/Opr.aspx?t=error&msg=opr", false); order = new Model.Order(); }
            if (Line == null) { Response.Redirect("/Opr.aspx?t=error&msg=opr", false); Line = new Model.Line(); }
        }
        /// <summary>
        /// 显示城市名称
        /// </summary>
        /// <param name="cityId"></param>
        /// <returns></returns>
        public string ShowCityName(int cityId)
        {
            string strCityName = "";
            TravelAgent.Model.DepartureCity cityModel = CityBll.GetModel(cityId);
            if (cityModel != null)
            {
                strCityName = cityModel.CityName;
            }

            return strCityName;
        }
        /// <summary>
        /// 绑定游客信息
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public string BindTourist(int orderId)
        {
            StringBuilder sbTourist = new StringBuilder();
            DataSet dsTourist = OTBll.GetList("orderId="+orderId);
            foreach (DataRow r in dsTourist.Tables[0].Rows)
            {
                sbTourist.Append("<tr>");
                sbTourist.Append("<td class=\"lt\">" + TravelAgent.Tool.EnumHelper.GetMemberName<TravelAgent.Tool.EnumSummary.TouristType>(r["touristType"]) + "</td>");
                sbTourist.Append("<td>" + r["touristName"] + "</td>");
                sbTourist.Append("<td>" + TravelAgent.Tool.EnumHelper.GetMemberName<TravelAgent.Tool.EnumSummary.PapersType>(r["papersType"]) + "</td>");
                sbTourist.Append("<td>" + r["papersNo"] + "</td>");
                sbTourist.Append("<td>" + TravelAgent.Tool.EnumHelper.GetMemberName<TravelAgent.Tool.EnumSummary.TouristSex>(r["touristSex"]) + "</td>");
                sbTourist.Append("<td>" + r["birthDate"] + "</td>");
                sbTourist.Append("<td>" + r["mobile"] + "</td>");
                sbTourist.Append(" </tr>");
            }

            return sbTourist.ToString();
        }
    }
}
