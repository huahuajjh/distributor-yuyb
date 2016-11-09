using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TravelAgent.Web.admin.data
{
    public partial class CarPriceData : System.Web.UI.Page
    {
        private static readonly TravelAgent.BLL.CarPrice PriceBll = new TravelAgent.BLL.CarPrice();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["tag"] != null)
            { 
                string strtag = Request["tag"];
                int priceid = Convert.ToInt32(Request["priceid"]);
                if (strtag.Equals("price_delete"))
                {
                    try
                    {
                        PriceBll.Delete(priceid);
                        Response.Write("true");
                    }
                    catch
                    {
                        Response.Write("false");
                    }
                }
            }
        }
    }
}
