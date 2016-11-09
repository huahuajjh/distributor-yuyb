using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TravelAgent.Web.admin
{
    public partial class Admin_Center : System.Web.UI.Page
    {
        private static readonly TravelAgent.BLL.Order OrderBll = new TravelAgent.BLL.Order();
        private static readonly TravelAgent.BLL.VisaList VisaListBll = new TravelAgent.BLL.VisaList();
        private static readonly TravelAgent.BLL.Line LineBll = new TravelAgent.BLL.Line();
        private static readonly TravelAgent.BLL.Club ClubBll = new TravelAgent.BLL.Club();
        private static readonly TravelAgent.BLL.Article ArticleBll = new TravelAgent.BLL.Article();
        private static readonly TravelAgent.BLL.CarList CarBll = new TravelAgent.BLL.CarList();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                DataBindOrder();
                DataBindClub();

                this.ltClubNumber.Text = ClubBll.GetCount("").ToString();
                this.ltLineNumber.Text = LineBll.GetCount("").ToString();
                this.ltVisaNumber.Text = VisaListBll.GetCount("").ToString();
                this.ltLineOrderNumber.Text = OrderBll.GetCount("orderType=" + Convert.ToInt32(TravelAgent.Tool.EnumSummary.OrderType.线路)).ToString();
                this.ltVisaOrderNumber.Text = OrderBll.GetCount("orderType=" + Convert.ToInt32(TravelAgent.Tool.EnumSummary.OrderType.签证)).ToString();
                this.ltArtilceNumber.Text = ArticleBll.GetCount("").ToString();
            }
        }
        /// <summary>
        /// 绑定订单
        /// </summary>
        private void DataBindOrder()
        {
            DataSet dsOrder = OrderBll.GetList0(10, "", "orderDate desc");
            this.rptList.DataSource = dsOrder;
            this.rptList.DataBind();
            this.trNoRecord.Style["display"] = dsOrder.Tables[0].Rows.Count > 0 ? "none" : "";
        }
        /// <summary>
        /// 绑定会员
        /// </summary>
        private void DataBindClub()
        {
            DataSet dsClub = ClubBll.GetList(9, "", "regDate desc");
            this.rptClubList.DataSource = dsClub;
            this.rptClubList.DataBind();
        }
        /// <summary>
        /// 返回线路名称
        /// </summary>
        /// <param name="id"></param>
        /// <param name="orderType"></param>
        public string getOrderName(int id,int orderType)
        {
            string strvalue = "";
            if (orderType == Convert.ToInt32(TravelAgent.Tool.EnumSummary.OrderType.线路))
            {
                TravelAgent.Model.Line l = LineBll.GetModel(id);
                if (l != null)
                {
                    strvalue = "<a href=\"/Line.aspx?id=" + id + "\" target=\"_blank\" class=\"tablelink\">" + l.LineName + "</a>";
                }
            }
            else if (orderType == Convert.ToInt32(TravelAgent.Tool.EnumSummary.OrderType.签证))
            {
                TravelAgent.Model.VisaList v = VisaListBll.GetModel(id);
                if (v != null)
                {
                    strvalue = "<a href=\"/visa/VisaDetail.aspx?id=" + id + "\" target=\"_blank\" class=\"tablelink\">" + v.visaName + "</a>";
                }
            }
            else if (orderType == Convert.ToInt32(TravelAgent.Tool.EnumSummary.OrderType.租车))
            {
                TravelAgent.Model.CarList c = CarBll.GetModel(id);
                if (c!= null)
                {
                    strvalue = "<a href=\"/car/CarDetail.aspx?id=" + id + "\" target=\"_blank\" class=\"tablelink\">" + c.CarName + "</a>";
                }
            }

            return strvalue;
        }
        /// <summary>
        /// 显示跳转地址
        /// </summary>
        /// <param name="id"></param>
        /// <param name="orderType"></param>
        /// <returns></returns>
        public string showEditUrl(int id, int orderType)
        {
            string strvalue = "";
            if (orderType == Convert.ToInt32(TravelAgent.Tool.EnumSummary.OrderType.线路))
            {
                strvalue = "/admin/product/EditLineOrder.aspx?id="+id;
            }
            else if (orderType == Convert.ToInt32(TravelAgent.Tool.EnumSummary.OrderType.签证))
            {
                strvalue = "/admin/visa/EditVisaOrder.aspx?id="+id;
            }
            else if (orderType == Convert.ToInt32(TravelAgent.Tool.EnumSummary.OrderType.租车))
            {
                strvalue = "/admin/car/EditCarOrder.aspx?id=" + id;
            }
            return strvalue;
        }
    }
}
