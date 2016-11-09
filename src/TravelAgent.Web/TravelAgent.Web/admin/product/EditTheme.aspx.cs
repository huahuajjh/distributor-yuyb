using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TravelAgent.Web.admin.product
{
    public partial class EditTheme : TravelAgent.Web.UI.BasePage
    {
        private static readonly TravelAgent.BLL.LineTheme ThemeBll = new TravelAgent.BLL.LineTheme();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (Request.QueryString["themeid"] != null)
                {
                    TravelAgent.Model.LineTheme model = ThemeBll.GetModel(Convert.ToInt32(Request.QueryString["themeid"]));
                    if (model != null)
                    {
                        this.txtThemeName.Text = model.themeName;
                        this.txtImgUrl.Text = model.themeTopPic;
                        this.txtSort.Text = model.Sort.ToString();
                        this.hidId.Value = model.Id.ToString();
                        this.chkIsLock.Checked = model.isLock == 1;
                    }

                }
                else
                {
                    this.txtSort.Text = (ThemeBll.GetMaxID("Sort") + 1).ToString();
                }
            }
        }
    }
}
