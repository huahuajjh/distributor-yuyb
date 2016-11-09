using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TravelAgent.Web.admin.car
{
    public partial class EditCarClass : System.Web.UI.Page
    {
        private static readonly TravelAgent.BLL.CarClass CityBll = new TravelAgent.BLL.CarClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (Request.QueryString["classid"] != null)
                {
                    TravelAgent.Model.CarClass model = CityBll.GetModel(Convert.ToInt32(Request.QueryString["classid"]));
                    if (model != null)
                    {
                        this.txtClassName.Text = model.ClassName;
                        this.txtSort.Text = model.Sort.ToString();
                        this.hidId.Value = model.Id.ToString();
                    }

                }
                else
                {
                    this.txtSort.Text = (CityBll.GetMaxID("Sort") + 1).ToString();
                }
            }
        }
    }
}
