using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace TravelAgent.Web.admin.product
{
    public partial class EditProperty : TravelAgent.Web.UI.BasePage
    {
        private static readonly TravelAgent.BLL.JoinProperty PropertyBll = new TravelAgent.BLL.JoinProperty();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (Request.QueryString["propertyid"] != null)
                {
                    TravelAgent.Model.JoinProperty model = PropertyBll.GetModel(Convert.ToInt32(Request.QueryString["propertyid"]));
                    if (model != null)
                    {
                        this.txtPropertyName.Text = model.joinName;
                        this.txtSort.Text = model.joinSort.ToString();
                        this.hidId.Value = model.id.ToString();
                        this.chkIsLock.Checked = model.isLock == 1;
                    }

                }
                else
                {
                    this.txtSort.Text = (PropertyBll.GetMaxID("joinSort") + 1).ToString();
                }
            }
        }

    
    }
}
