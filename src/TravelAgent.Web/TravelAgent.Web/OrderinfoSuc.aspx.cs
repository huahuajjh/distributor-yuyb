using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TravelAgent.Web
{
    public partial class OrderinfoSuc : System.Web.UI.Page
    {
        public int oid;
        public string strTip = "您的预订信息已经提交成功";
        public string strSubTip = "我们的客服人员会及时审核您的订单信息会尽快与您联系，请耐心等待！";
        public TravelAgent.Model.Line Line;
        public TravelAgent.Model.Order order;
        private static readonly TravelAgent.BLL.Order LineOrderBll = new TravelAgent.BLL.Order();
        private static readonly TravelAgent.BLL.Line LineBll = new TravelAgent.BLL.Line();
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Title = "订单结果" + Master.webinfo.WebName;
            int.TryParse(Request.QueryString["oid"], out oid);
            if (Request.QueryString["pay"] != null)
            {
                strTip = "付款成功";
                strSubTip = "如果付款成功，订单的状态仍是‘待付款’，请联系客服工作人员核实修改！";
            }
            if (!this.IsPostBack)
            {
                if (oid > 0)
                {
                    order = LineOrderBll.GetModel(oid);
                    if (order != null)
                    {
                        Line = LineBll.GetModel(order.lineId);
                        if (Line.DealType == Convert.ToInt32(TravelAgent.Tool.EnumSummary.DealType.人工处理))
                        {
                            this.divPay.Style["display"] = "none";
                        }
                        else
                        {
                            this.divPay.Style["display"] = "";
                        }
                    }
                }
            }
            if (order == null) { Response.Redirect("/Opr.aspx?t=error&msg=opr", false); order = new Model.Order(); }
            if (Line == null) { Response.Redirect("/Opr.aspx?t=error&msg=opr", false); Line = new Model.Line(); }
        }
    }
}
