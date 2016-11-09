using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TravelAgent.Web.admin.product
{
    public partial class EidtInsure : TravelAgent.Web.UI.BasePage
    {
        private static readonly TravelAgent.BLL.Insure InsureBll = new TravelAgent.BLL.Insure();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (Request.QueryString["insureid"] != null)
                {
                    TravelAgent.Model.Insure model = InsureBll.GetModel(Convert.ToInt32(Request.QueryString["insureid"]));
                    if (model != null)
                    {
                        this.txtInsureName.Text = model.InsureName;
                        this.txtPrice.Text = model.InsurePrice.ToString();
                        this.txtContent.Value = model.InsureContent;
                        this.hidId.Value = model.Id.ToString();
                        this.chkIsLock.Checked = model.IsLock == 1;
                    }

                }
            }
        }
    }
}
