using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TravelAgent.Web.admin.visa
{
    public partial class EditVisaCity : TravelAgent.Web.UI.BasePage
    {
        private static readonly TravelAgent.BLL.VisaCity CityBll = new TravelAgent.BLL.VisaCity();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (Request.QueryString["cityid"] != null)
                {
                    TravelAgent.Model.VisaCity model = CityBll.GetModel(Convert.ToInt32(Request.QueryString["cityid"]));
                    if (model != null)
                    {
                        this.txtCityName.Text = model.CityName;
                        this.txtTips.Value = model.Tips;
                        this.txtSort.Text = model.Sort.ToString();
                        this.hidId.Value = model.Id.ToString();
                        this.chkState.Checked = model.isLock == 1;
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
