using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TravelAgent.Web.admin.basicset
{
    public partial class WebContactInfo : TravelAgent.Web.UI.BasePage
    {
        private static readonly TravelAgent.BLL.WebInfo WebInfoBll = new TravelAgent.BLL.WebInfo();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                DataBindContactInfo();

                if (Admin.Role.roleAuth.IndexOf(",sysbase_update,") <= -1)
                {
                    this.btnSave.Visible = false;
                }
            }
        }
        /// <summary>
        /// 绑定网站联系信息
        /// </summary>
        private void DataBindContactInfo()
        {
            this.txtCompanyName.Text = webinfo.WebCompanyName;
            this.txtWebLicence.Text = webinfo.WebLicence;
            this.txtWebEmail.Text = webinfo.WebEmail;
            this.txtWebTel.Text = webinfo.WebTel;
            this.txtWebQQ.Text = webinfo.WebQQ;
            this.txtWebAddress.Text = webinfo.WebAddress;
            this.txtWorkTime.Text = webinfo.WorkTime;

        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                webinfo.WebCompanyName = this.txtCompanyName.Text.Trim();
                webinfo.WebLicence = this.txtWebLicence.Text.Trim();
                webinfo.WebEmail = this.txtWebEmail.Text;
                webinfo.WebTel = this.txtWebTel.Text.Trim();
                webinfo.WebQQ = this.txtWebQQ.Text.Trim();
                webinfo.WebAddress = this.txtWebAddress.Text.Trim();
                webinfo.WorkTime = this.txtWorkTime.Text.Trim();
                ////修改配置信息
                WebInfoBll.saveConifg(webinfo, Server.MapPath(ConfigurationManager.AppSettings["WebInfoConfig"].ToString()));
                JscriptPrint("保存成功！", "WebContactInfo.aspx", "Success");
            }
            catch
            {
                JscriptPrint("保存失败！", "WebContactInfo.aspx", "Error");
            }
        }
    }
}
