using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TravelAgent.Web
{
    public partial class Order4 : System.Web.UI.Page
    {
        public string strOrdercode;
        public string strOrderName;
        public int intPeopleNumber;
        public int intTotalPrice;
        public int donatePoints;
        public string strTag="line";
        public int oid;
        public DateTime? orderdate;
        public TravelAgent.Model.Club club;
        public TravelAgent.Model.Line Line;
        private static readonly TravelAgent.BLL.Order OrderBll = new TravelAgent.BLL.Order();
        private static readonly TravelAgent.BLL.Line LineBll = new TravelAgent.BLL.Line();
        //private static readonly TravelAgent.BLL.VisaOrder VisaOrderBll = new TravelAgent.BLL.VisaOrder();
        private static readonly TravelAgent.BLL.VisaList VisaBll = new TravelAgent.BLL.VisaList();
        private static readonly TravelAgent.BLL.CarList CarBll = new TravelAgent.BLL.CarList();
        private static readonly TravelAgent.BLL.Club clubBll = new TravelAgent.BLL.Club();
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Title = "付款-" + Master.webinfo.WebName;
            int.TryParse(Request.QueryString["oid"], out oid);
            int strUid;
            if (!int.TryParse(TravelAgent.Tool.CookieHelper.GetCookieValue("uid"), out strUid))
            {
                Response.Redirect("/member/Login.aspx");
            }
            else
            {
                club = clubBll.GetModel(strUid);
            }
            if (Request.QueryString["t"] != null)
            {
                strTag = Request.QueryString["t"];
            }
            if (!this.IsPostBack)
            {
                if (!string.IsNullOrEmpty(strTag))
                {
                    if (oid > 0)
                    {
                        TravelAgent.Model.Order order = OrderBll.GetModel(oid);
                        if (order != null)
                        {
                            strOrdercode = order.ordercode;
                            intPeopleNumber = order.peopleNumber;
                            intTotalPrice = order.orderPrice + order.attachPrice+order.subPrice;
                            orderdate = order.orderDate;
                            if (strTag.Equals("line"))//线路
                            {
                                Line = LineBll.GetModel(order.lineId);
                                if (Line != null)
                                {
                                    strOrderName = Line.LineName;
                                    donatePoints = Line.DonatePoints;
                                }
                                else
                                {
                                    Response.Redirect("/Opr.aspx?t=error&msg=opr", false);
                                }
                            }
                            else if (strTag.Equals("visa"))
                            {
                                TravelAgent.Model.VisaList visa = VisaBll.GetModel(order.lineId);
                                if (visa != null)
                                {
                                    strOrderName = visa.visaName;
                                    donatePoints = visa.donatePoints;
                                }
                                else
                                {
                                    Response.Redirect("/Opr.aspx?t=error&msg=opr", false);
                                }
                            }
                            else if (strTag.Equals("car"))
                            {
                                TravelAgent.Model.CarList car = CarBll.GetModel(order.lineId);
                                if (car != null)
                                {
                                    strOrderName = car.CarName;
                                    donatePoints = 0;
                                }
                                else
                                {
                                    Response.Redirect("/Opr.aspx?t=error&msg=opr", false);
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
                }
                else
                {
                    Response.Redirect("/Opr.aspx?t=error&msg=opr", false);
                }

            }
            if (club == null) { Response.Redirect("/Opr.aspx?t=error&msg=opr", false); club = new Model.Club(); }
            if (Line == null) { Response.Redirect("/Opr.aspx?t=error&msg=opr", false); Line = new Model.Line(); }
        }
        /// <summary>
        /// 显示支付方式
        /// </summary>
        /// <returns></returns>
        public string ShowPay()
        {
            StringBuilder sbPay = new StringBuilder();
            if (Master.webinfo.AlipayIslock == 1)
            { 
                 sbPay.Append("<td class=\"padleft5_sll\" width=\"21\"><input type=\"radio\"  value=\"4\" name=\"pay_bank\" id=\"third_party_radio_alipay\" onclick=\"checkPayType(this);\" /></td>");
                 sbPay.Append("<td width=\"149\"><img width=\"147\" height=\"37\" style=\"border: solid 1px #CDCDCD;\" alt=\"支付宝\" src=\"/images/alipay.jpg\" class=\"on\" /></td>");
            }
            if (Master.webinfo.WxpayIsLock == 1)
            { 
                sbPay.Append("<td class=\"padleft5_sll\" width=\"21\"><input type=\"radio\"  value=\"8\" name=\"pay_bank\" id=\"third_party_radio_wxpay\" onclick=\"checkPayType(this);\" /></td>");
                sbPay.Append("<td width=\"149\"><img width=\"147\" height=\"37\" style=\"border: solid 1px #CDCDCD;\" alt=\"微信支付\" src=\"/images/wxpay.jpg\" class=\"on\" /></td>");
            }
            if (Master.webinfo.ChinabankIslock == 1)
            {
                sbPay.Append("<td class=\"padleft5_sll\" width=\"21\"><input type=\"radio\"  value=\"5\" name=\"pay_bank\" id=\"third_party_radio_chinabank\" onclick=\"checkPayType(this);\"  /> </td>");
                sbPay.Append("<td width=\"149\"><img width=\"147\" height=\"37\" style=\"border: solid 1px #CDCDCD;\" alt=\"网银在线\" src=\"/images/chinabank.gif\" class=\"on\" /></td>");
            }
           
            return sbPay.ToString();
        }
        /// <summary>
        /// 显示支付按钮
        /// </summary>
        /// <returns></returns>
        public string ShowPayButton()
        {
            string strbutton=" <input id=\"btnSubmit\" type=\"submit\" value=\"\" style=\"background:url('/images/order6.gif') no-repeat; width:121px; height:38px;border:none;\" />";
            if (Master.webinfo.AlipayIslock == 0 && Master.webinfo.WxpayIsLock == 0 && Master.webinfo.ChinabankIslock == 0)
            {
                strbutton = "<input id=\"btnSubmit\" type=\"submit\" value=\"\" style=\"background:url('/images/order6.gif') no-repeat; width:121px; height:38px;border:none;\" disabled=\"disabled\" />";
            }
            return strbutton;
        }
    }
}
