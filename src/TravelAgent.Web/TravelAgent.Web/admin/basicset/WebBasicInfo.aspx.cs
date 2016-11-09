using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TravelAgent.Web.admin.basicset
{
    public partial class WebBasicInfo : TravelAgent.Web.UI.BasePage
    {
        private static readonly TravelAgent.BLL.WebInfo WebInfoBll = new TravelAgent.BLL.WebInfo();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                DataBindBaseInfo();

                if (Admin.Role.roleAuth.IndexOf(",sysbase_update,") <= -1)
                {
                    this.btnSave.Visible = false;
                }
            }
        }
        /// <summary>
        /// 绑定网站基本信息
        /// </summary>
        private void DataBindBaseInfo()
        {
            this.txtWebName.Text = webinfo.WebName;
            this.txtWebDomain.Text = webinfo.WebDomain;
            this.txtImgUrl.Text = webinfo.WebLogo;
            this.txtWebICP.Text = webinfo.WebICP;
            this.rbtnWebLock.SelectedValue = webinfo.WebLock.ToString();
            this.txtMYD.Text = webinfo.MYD.ToString();
            this.txtSearchKey.Text = webinfo.SearchKey;
        }
        /// <summary>
        /// 保存信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                webinfo.WebName = this.txtWebName.Text.Trim();
                webinfo.WebDomain = this.txtWebDomain.Text.Trim();
                webinfo.WebLogo = this.txtImgUrl.Text;
                webinfo.WebICP = this.txtWebICP.Text.Trim();
                webinfo.WebLock = Convert.ToInt32(this.rbtnWebLock.SelectedValue);
                webinfo.MYD = Convert.ToInt32(this.txtMYD.Text);
                webinfo.SearchKey = this.txtSearchKey.Text.Trim();
                ////修改配置信息
                WebInfoBll.saveConifg(webinfo, Server.MapPath(ConfigurationManager.AppSettings["WebInfoConfig"].ToString()));
                JscriptPrint("保存成功！", "WebBasicInfo.aspx", "Success");
            }
            catch
            {
                JscriptPrint("保存失败！", "WebBasicInfo.aspx", "Error");
            }
        }
    }
}
