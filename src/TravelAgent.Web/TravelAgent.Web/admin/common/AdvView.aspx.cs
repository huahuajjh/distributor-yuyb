using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TravelAgent.Web.admin.common
{
    public partial class AdvView : System.Web.UI.Page
    {
        public TravelAgent.Model.Advertising model = new TravelAgent.Model.Advertising();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    TravelAgent.BLL.Advertising advBll = new TravelAgent.BLL.Advertising();
                    model = advBll.GetModel(Convert.ToInt32(Request.QueryString["id"]));
                }
            }
        }
    }
}
