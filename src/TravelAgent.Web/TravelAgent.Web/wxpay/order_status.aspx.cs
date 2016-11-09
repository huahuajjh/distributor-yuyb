using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TravelAgent.Web.wxpay
{
    public partial class order_status : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
 
        }
        protected void button_Click(object sender, EventArgs e)
        {


            object r = TravelAgent.WxPay.AccessDbHelper.GetOScalar("select [order_status] from   [wx_order]   where [order_no]='" + order_no.Text + "'");

            if (r == null)
            {
                Response.Write("订单不存在");
                Response.End();
               
            }
            Response.Write(r.ToString());

        }
    }
}