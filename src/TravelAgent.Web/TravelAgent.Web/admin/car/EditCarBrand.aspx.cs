using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TravelAgent.Web.admin.car
{
    public partial class EditCarBrand : TravelAgent.Web.UI.BasePage
    {
        private static readonly TravelAgent.BLL.CarBrand BrandBll = new TravelAgent.BLL.CarBrand();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (Request.QueryString["themeid"] != null)
                {
                    TravelAgent.Model.CarBrand model = BrandBll.GetModel(Convert.ToInt32(Request.QueryString["themeid"]));
                    if (model != null)
                    {
                        this.txtBrandName.Text = model.BrandName;
                        this.txtImgUrl.Text = model.BrandPic;
                        this.txtSort.Text = model.Sort.ToString();
                        this.hidId.Value = model.Id.ToString();
                    }

                }
                else
                {
                    this.txtSort.Text = (BrandBll.GetMaxID("Sort") + 1).ToString();
                }
            }
        }
    }
}