using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TravelAgent.Web.admin.common
{
    public partial class EditLink : TravelAgent.Web.UI.BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    int linkid = Convert.ToInt32(Request.QueryString["id"]);
                    TravelAgent.BLL.Links LinkBll = new TravelAgent.BLL.Links();
                    TravelAgent.Model.Links model = LinkBll.GetModel(linkid);
                    if (model != null)
                    {
                        this.hidId.Value = model.Id.ToString();
                        this.txtName.Text = model.Title;
                        this.txtURL.Text = model.WebUrl;
                        this.txtContactName.Text = model.UserName;
                        this.txtLinkContent.Text = model.UserTel;
                        this.txtEmail.Text = model.UserMail;
                        this.txtSort.Text = model.SortId.ToString();
                        this.chkState.Checked = model.IsLock == 1;
                    }
                }
            }
        }
    }
}
