using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TravelAgent.Web.admin.common
{
    public partial class BarEdit : TravelAgent.Web.UI.BasePage
    {
        private static readonly TravelAgent.BLL.Advertising advBll = new TravelAgent.BLL.Advertising();
        private static readonly TravelAgent.BLL.Adbanner banBll = new TravelAgent.BLL.Adbanner();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (Request.QueryString["aid"] != null)
                {
                    int aid = Convert.ToInt32(Request.QueryString["aid"]);
                    TravelAgent.Model.Advertising adv = advBll.GetModel(aid);
                    if (adv != null)
                    {
                        this.lblAdTitle.Text = adv.Title;
                        this.hidaId.Value = adv.Id.ToString(); ;
                    }
                }
                if (Request.QueryString["id"] != null)
                {
                    int barid = Convert.ToInt32(Request.QueryString["id"]);
                    TravelAgent.Model.Adbanner bar = banBll.GetModel(barid);
                    if (bar != null)
                    {
                        this.hidId.Value = bar.Id.ToString();
                        //this.lblAdTitle.Text = bar.Aid.ToString();
                        this.txtTitle.Text = bar.Title;
                        this.txtStartTime.Text = bar.StartTime.ToString("yyyy-MM-dd");
                        this.txtEndTime.Text = bar.EndTime.ToString("yyyy-MM-dd");
                        this.txtImgUrl.Text = bar.AdUrl;
                        this.txtLinkUrl.Text = bar.LinkUrl;
                        this.txtAdRemark.Text = TravelAgent.Tool.StringPlus.ToTxt(bar.AdRemark);
                        this.rblIsLock.SelectedValue = bar.IsLock.ToString();
                    }
                }
            }
        }
        
    }
}
