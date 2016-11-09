using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TravelAgent.Web.admin.product
{
    public partial class EditLineOrder : System.Web.UI.Page
    {
        public int orderid;
        private static readonly TravelAgent.BLL.Club ClubBll = new TravelAgent.BLL.Club();
        private static readonly TravelAgent.BLL.Order LineOrderBll = new TravelAgent.BLL.Order();
        private static readonly TravelAgent.BLL.LineOrderTourist TouristBll = new TravelAgent.BLL.LineOrderTourist();
        private static readonly TravelAgent.BLL.Line LineBll = new TravelAgent.BLL.Line();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null)
            {
                orderid = Convert.ToInt32(Request.QueryString["id"]);
            }
            if (!this.IsPostBack)
            {
                DataBindState();
                DataBindPay();
                if (orderid > 0)
                {
                    TravelAgent.Model.Order order = LineOrderBll.GetModel(orderid);
                    if (order != null)
                    {
                        TravelAgent.Model.Line line = LineBll.GetModel(order.lineId);
                        if (line != null)
                        {
                            this.hddonate.Value = line.DonatePoints.ToString();
                        }
                        this.hdordercode.Value = order.ordercode;
                        this.lblLineName.Text = order.proName;
                        this.lblOrderCode.Text = order.ordercode;
                        this.lblPeopleNum.Text = order.peopleNumber + "("+order.adultNumber+"/"+order.childNumber+")";
                        this.lblOrderDate.Text = order.orderDate.ToString();
                        this.lblTravelDate.Text = order.TravelDate;
                        this.lblOrderRemark.Text = order.orderRemark;
                        this.IDcard.Text = order.IDcard;
                        this.lbltuijianren.Text = order.tuijianren;
                        this.lblLinkName.Text = order.contactName;
                        this.lblTel.Text = order.contactMobile;
                        this.lblEmail.Text = order.contactEmail;
                        this.hdclubid.Value = order.clubid.ToString();
                        TravelAgent.Model.Club club = ClubBll.GetModel(order.clubid);
                        if (club != null)
                        {
                            this.lblClubInfo.Text = club.clubName + " / " + club.clubMobile + " / " + club.clubEmail;
                        }

                        this.lblOrderTotalPrice.Text = order.orderPrice.ToString();
                        this.lblIsBaoxian.Text = order.attachPrice == 0 ? "否" : "是";
                        this.lblBaoxianCost.Text = order.attachPrice.ToString();
                        this.txtuserPoints.Value = order.usePoints.ToString();
                        this.lblPayCost.Text = (order.orderPrice + order.attachPrice - order.usePoints+order.subPrice).ToString();
                        this.ddlState.SelectedValue = order.orderState.ToString();
                        this.txtRemark.Value = order.operRemark;

                        if (order.orderState == Convert.ToInt32(TravelAgent.Tool.EnumSummary.OrderState.已付款))
                        {
                            this.lblPayState.Text = "已付款";
                        }
                        else
                        {
                            this.lblPayState.Text = "未付款";
                        }
                        this.ddlPayType.SelectedValue = order.payType.ToString();
                    }
                }
            }
        }
        /// <summary>
        /// 显示游客信息
        /// </summary>
        /// <returns></returns>
        public string ShowTourist()
        {
            StringBuilder sbTourist = new StringBuilder();
            DataSet dsTourList = TouristBll.GetList("orderId=" + orderid);
            foreach (DataRow r in dsTourList.Tables[0].Rows)
            {
                sbTourist.Append("<tr>");
                sbTourist.Append("<td><span style='color:#000'>" + r["touristName"] + "</span></td>");
                if (r["touristSex"].ToString().Equals(""))
                {
                    sbTourist.Append("<td><span style='color:#000'></span></td>");
                }
                else
                {
                    sbTourist.Append("<td><span style='color:#000'>" + TravelAgent.Tool.EnumHelper.GetMemberName<TravelAgent.Tool.EnumSummary.TouristSex>(r["touristSex"]) + "</span></td>");
                }
                
                sbTourist.Append("<td><span style='color:#000'>" + TravelAgent.Tool.EnumHelper.GetMemberName<TravelAgent.Tool.EnumSummary.PapersType>(r["papersType"]) + "</span></td>");
                sbTourist.Append("<td><span style='color:#000'>" + r["papersNo"] + "</span></td>");
                sbTourist.Append("<td><span style='color:#000'>" + r["mobile"] + "</span></td>");
                sbTourist.Append("</tr>");
            }
            return sbTourist.ToString();
        }
        /// <summary>
        /// 绑定状态属性
        /// </summary>
        private void DataBindState()
        {
            Dictionary<string, int> dcPay = TravelAgent.Tool.EnumHelper.GetDictionaryMemberKeyValue<TravelAgent.Tool.EnumSummary.OrderState>();//数据源
            this.ddlState.DataSource = dcPay.OrderBy(d => d.Value); ;
            this.ddlState.DataTextField = "Key";
            this.ddlState.DataValueField = "Value";
            this.ddlState.DataBind();
            this.ddlState.Items.Insert(0, new ListItem("订单状态", "0"));
        }
        /// <summary>
        /// 绑定状态属性
        /// </summary>
        private void DataBindPay()
        {
            Hashtable ht = TravelAgent.Tool.EnumHelper.GetMemberKeyValue<TravelAgent.Tool.EnumSummary.PayType>();//数据源
            this.ddlPayType.DataSource = ht;
            this.ddlPayType.DataTextField = "Key";
            this.ddlPayType.DataValueField = "Value";
            this.ddlPayType.DataBind();
            this.ddlPayType.Items.Insert(0, new ListItem("支付方式", "0"));
        }
    }
}
