using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TravelAgent.Web.admin.car
{
    public partial class EditCarNumber : System.Web.UI.Page
    {
        private static readonly TravelAgent.BLL.CarNumber NumBll = new TravelAgent.BLL.CarNumber();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (Request.QueryString["numid"] != null)
                {
                    TravelAgent.Model.CarNumber model = NumBll.GetModel(Convert.ToInt32(Request.QueryString["numid"]));
                    if (model != null)
                    {
                        this.txtNumName.Text = model.NumName;
                        this.txtSort.Text = model.Sort.ToString();
                        this.hidId.Value = model.Id.ToString();
                    }

                }
                else
                {
                    this.txtSort.Text = (NumBll.GetMaxID("Sort") + 1).ToString();
                }
            }
        }
    }
}
