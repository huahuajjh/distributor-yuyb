using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TravelAgent.Web.dataDeal
{
    public partial class AddDiy : System.Web.UI.Page
    {
        private static readonly TravelAgent.BLL.CustomOrder bll = new TravelAgent.BLL.CustomOrder();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["jingdian"] != null)
            {
                TravelAgent.Model.CustomOrder order = new TravelAgent.Model.CustomOrder();
                order.Jindians = Request["jingdian"];
                order.CustomType = Convert.ToInt32(Request["type"]);
                order.LineDay = Convert.ToInt32(Request["days"]);
                order.LinePeopleNumber = Convert.ToInt32(Request["renshu"]);
                order.PeoplePrice = Convert.ToInt32(Request["price"]);
                order.TravelDate = Request["shijian"];
                order.LinkName = Request["xingming"];
                order.LinkTelephone = Request["dianhua"];
                order.OtherMsg = Request["remark"];
                try
                {
                    if (bll.Add(order) > 0)
                    {
                        Response.Write("true");
                    }
                    else
                    {
                        Response.Write("false");
                    }
                }
                catch
                {
                    Response.Write("false");
                }
            }
        }
    }
}
