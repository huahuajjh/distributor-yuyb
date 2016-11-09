using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TravelAgent.Web.admin.car
{
    public partial class EditCarCity : System.Web.UI.Page
    {
        private static readonly TravelAgent.BLL.CarCity CityBll = new TravelAgent.BLL.CarCity();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (Request.QueryString["cityid"] != null)
                {
                    TravelAgent.Model.CarCity model = CityBll.GetModel(Convert.ToInt32(Request.QueryString["cityid"]));
                    if (model != null)
                    {
                        this.txtCityName.Text = model.CityName;
                        this.txtSort.Text = model.Sort.ToString();
                        this.hidId.Value = model.id.ToString();
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
