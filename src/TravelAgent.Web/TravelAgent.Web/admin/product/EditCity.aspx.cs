using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TravelAgent.Web.admin.product
{
    public partial class EditCity : TravelAgent.Web.UI.BasePage
    {
        private static readonly TravelAgent.BLL.DepartureCity CityBll = new TravelAgent.BLL.DepartureCity();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (Request.QueryString["cityid"] != null)
                {
                    TravelAgent.Model.DepartureCity model = CityBll.GetModel(Convert.ToInt32(Request.QueryString["cityid"]));
                    if (model != null)
                    {
                        this.txtCityName.Text = model.CityName;
                        this.txtSort.Text = model.Sort.ToString();
                        this.hidId.Value = model.id.ToString();
                        this.chkIsLock.Checked = model.isLock == 1;
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
