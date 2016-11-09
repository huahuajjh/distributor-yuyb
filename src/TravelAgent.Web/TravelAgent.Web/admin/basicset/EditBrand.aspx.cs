using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TravelAgent.Web.admin.basicset
{
    public partial class EditBrand : TravelAgent.Web.UI.BasePage
    {
        private static readonly TravelAgent.BLL.VisaBrand Bll = new TravelAgent.BLL.VisaBrand();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    TravelAgent.Model.VisaBrand model = Bll.GetModel(Convert.ToInt32(Request.QueryString["id"]));
                    if (model != null)
                    {
                        this.hidId.Value = model.Id.ToString();
                        this.ddlType.SelectedValue = model.Type.ToString();
                        this.txtTitle.Text = model.Title;
                        this.txtSubTitle.Text = model.SubTitle;
                        //this.txtImgUrl.Text = model.PicUrl;
                        this.txtSort.Text = model.Sort.ToString();
                        this.chkState.Checked = model.isLock == 1;
                    }

                }
                else
                {
                    this.txtSort.Text = (Bll.GetMaxID("Sort") + 1).ToString();
                }
            }
        }
    }
}
