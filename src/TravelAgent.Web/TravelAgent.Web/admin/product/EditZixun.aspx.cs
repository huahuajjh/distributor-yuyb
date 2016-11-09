using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TravelAgent.Web.admin.product
{
    public partial class EditZixun : TravelAgent.Web.UI.BasePage
    {
        private static readonly TravelAgent.BLL.LineConsult Bll = new TravelAgent.BLL.LineConsult();
        public int id;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    id = Convert.ToInt32(Request.QueryString["id"]);
                    TravelAgent.Model.LineConsult model = Bll.GetModel(id);
                    if (model != null)
                    {
                        this.lbldate.Text = model.ConsultDate.ToString();
                        this.lblZixun.Text = model.ConsultContent;
                        this.txtContent.Value = model.ReplyContent;
                        this.chkIsEmail.Enabled = !model.LinkEmail.Equals("");
                        this.chkIsEmail.Checked = !model.LinkEmail.Equals("");
                        this.hfemail.Value = model.LinkEmail;
                        this.hfquestion.Value = model.ConsultContent;
                    }
                }
            }
        }
    }
}
