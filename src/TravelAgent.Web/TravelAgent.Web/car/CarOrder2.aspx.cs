using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TravelAgent.Web.car
{
    public partial class CarOrder2 : TravelAgent.Web.UI.mBasePage
    {
        private static readonly TravelAgent.BLL.CarList CarBll = new TravelAgent.BLL.CarList();
        private static readonly TravelAgent.BLL.CarPrice CarPriceBll = new TravelAgent.BLL.CarPrice();
        private static readonly TravelAgent.BLL.Order OrderBll = new TravelAgent.BLL.Order();
        public TravelAgent.Model.CarList CarModel;
        public TravelAgent.Model.CarPrice CarPriceModel;
        public TravelAgent.Model.Order order;
        public int cid;
        public int pid;
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
                }
                if (Request.QueryString["oid"] != null)
                {
                    order = OrderBll.GetModel(Convert.ToInt32(Request.QueryString["oid"]));
                }
                if (CarModel == null || CarPriceModel == null || order==null)
                {
                    Response.Redirect("/Opr.aspx?msg=no");
                }
            }
        }
    }
}
