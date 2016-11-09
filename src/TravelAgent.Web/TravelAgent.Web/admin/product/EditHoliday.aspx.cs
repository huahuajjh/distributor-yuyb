using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TravelAgent.Web.admin.product
{
    public partial class EditHoliday : TravelAgent.Web.UI.BasePage
    {
        private static readonly TravelAgent.BLL.LineHoliday Bll = new TravelAgent.BLL.LineHoliday();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    TravelAgent.Model.LineHoliday model = Bll.GetModel(Convert.ToInt32(Request.QueryString["id"]));
                    if (model != null)
                    {
                        this.txtThemeName.Text = model.holidayName;
                        this.txtImgUrl.Text = model.holidaybgurl;
                        this.hidId.Value = model.Id.ToString();
                    }

                }
            }
        }
    }
}
