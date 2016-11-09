using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TravelAgent.Web.admin.visa
{
    public partial class EditVisaType : TravelAgent.Web.UI.BasePage
    {
        private static readonly TravelAgent.BLL.VisaType TypeBll = new TravelAgent.BLL.VisaType();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    TravelAgent.Model.VisaType model = TypeBll.GetModel(Convert.ToInt32(Request.QueryString["id"]));
                    if (model != null)
                    {
                        this.txtName.Text = model.Name;
                        this.txtSort.Text = model.Sort.ToString();
                        this.hidId.Value = model.Id.ToString();
                        this.chkState.Checked = model.isLock == 1;
                    }

                }
                else
                {
                    this.txtSort.Text = (TypeBll.GetMaxID("Sort") + 1).ToString();
                }
            }
        }
    }
}
