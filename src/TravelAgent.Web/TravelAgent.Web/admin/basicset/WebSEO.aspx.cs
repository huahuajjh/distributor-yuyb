using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TravelAgent.Web.admin.basicset
{
    public partial class WebSEO : TravelAgent.Web.UI.BasePage
    {
        private static readonly TravelAgent.BLL.WebInfo WebInfoBll = new TravelAgent.BLL.WebInfo();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                DataBindSEO();
                if (Admin.Role.roleAuth.IndexOf(",sysbase_update,") <= -1)
                {
                    this.btnSave.Visible = false;
                }
            }
        }

        /// <summary>
        /// 绑定网站SEO信息
        /// </summary>
        private void DataBindSEO()
        {
            this.SEOTitle.Value = webinfo.SEOTitle;
            this.SEOKeywords.Value = webinfo.SEOKeywords;
            this.SEODescription.Value = webinfo.SEODescription;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                webinfo.SEOTitle = this.SEOTitle.Value;
                webinfo.SEOKeywords = this.SEOKeywords.Value;
                webinfo.SEODescription = this.SEODescription.Value;
                ////修改配置信息
                WebInfoBll.saveConifg(webinfo, Server.MapPath(ConfigurationManager.AppSettings["WebInfoConfig"].ToString()));
                JscriptPrint("保存成功！", "WebSEO.aspx", "Success");
            }
            catch
            {
                JscriptPrint("保存失败！", "WebSEO.aspx", "Error");
            }
        }
    }
}
