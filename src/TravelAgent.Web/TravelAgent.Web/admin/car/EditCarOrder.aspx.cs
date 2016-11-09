using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TravelAgent.Web.admin.car
{
    public partial class EditCarOrder : System.Web.UI.Page
    {
        public int orderid;
        private static readonly TravelAgent.BLL.Club ClubBll = new TravelAgent.BLL.Club();
        private static readonly TravelAgent.BLL.Order OrderBll = new TravelAgent.BLL.Order();
        private static readonly TravelAgent.BLL.CarList CarBll = new TravelAgent.BLL.CarList();
        private static readonly TravelAgent.BLL.CarPrice PriceBll = new TravelAgent.BLL.CarPrice();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["id"]))
            {
                orderid = Convert.ToInt32(Request.QueryString["id"]);
            }
            if (!this.IsPostBack)
            {
                DataBindState();
                DataBindPay();
                if (orderid > 0)
                {
                    TravelAgent.Model.Order order = OrderBll.GetModel(orderid);
                    if (order != null)
                    {
                        TravelAgent.Model.CarList car = CarBll.GetModel(order.lineId);
                        if (car != null)
                        {
                            this.hdordercode.Value = order.ordercode;
                            this.lblCarName.Text = car.CarName;
                            this.lblOrderCode.Text = order.ordercode;
                            this.lblUseCount.Text = order.account.ToString();
                            this.lblOrderDate.Text = order.orderDate.ToString();
                            TravelAgent.Model.CarPrice price = PriceBll.GetModel(order.peopleNumber);
                            if (price != null)
                            {
                                this.lblCarType.Text = price.CarTypeID == 0 ? "旅游租车" : "自驾租车";
                            }
                            this.lblUseDate.Text = order.usedate + " " + order.timedot+"点";
                            this.lblHuanDate.Text = order.huandate;
                        }
                        
                        TravelAgent.Model.Club club = ClubBll.GetModel(order.clubid);
                        if (club != null)
                        {
                            this.lblClubInfo.Text = club.clubName + " / " + club.clubMobile + " / " + club.clubEmail;
                        }
                        this.lblLinkName.Text = order.contactName;
                        this.lblEmail.Text = order.contactEmail;
                        this.lblTel.Text = order.contactMobile;
                        this.lblSex.Text = !order.contactSex.Equals("") ? TravelAgent.Tool.EnumHelper.GetMemberName<TravelAgent.Tool.EnumSummary.TouristSex>(order.contactSex) : "";
                        this.lblOrderTotalPrice.Text = order.orderPrice.ToString();
                        this.txtJiaJian.Value = order.subPrice.ToString();
                        this.txtuserPoints.Value = order.usePoints.ToString();
                        this.lblPayCost.Text = (order.orderPrice - order.usePoints + order.subPrice).ToString();
                        this.ddlPayType.SelectedValue = order.payType.ToString();
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
                    }
                }
            }
        }
        /// <summary>
        /// 绑定状态属性
        /// </summary>
        private void DataBindState()
        {
            //Hashtable ht = TravelAgent.Tool.EnumHelper.GetMemberKeyValue<TravelAgent.Tool.EnumSummary.OrderState>();//数据源
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
