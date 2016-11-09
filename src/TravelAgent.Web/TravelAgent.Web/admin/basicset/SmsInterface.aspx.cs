using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TravelAgent.Web.admin.basicset
{
    public partial class SmsInterface : TravelAgent.Web.UI.BasePage
    {
        private static readonly TravelAgent.BLL.WebInfo WebInfoBll = new TravelAgent.BLL.WebInfo();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.txtHostName.Text = webinfo.SmsHostname;
                this.txtPassword.Attributes.Add("value", webinfo.SmsPassword);
                //this.txtPassword.Text = webinfo.SmsPassword;
                this.txtUsername.Text = webinfo.SmsUsername;
                this.rbtnLock.SelectedValue = webinfo.SmsIslock.ToString();

                if (Admin.Role.roleAuth.IndexOf(",sysinterface,") <= -1)
                {
                    this.btnSave.Visible = false;
                }
            }
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                webinfo.SmsHostname = this.txtHostName.Text.Trim();
                webinfo.SmsPassword = this.txtPassword.Text.Trim();
                webinfo.SmsUsername = this.txtUsername.Text;
                webinfo.SmsIslock = Convert.ToInt32(this.rbtnLock.SelectedValue);

                ////修改配置信息
                WebInfoBll.saveConifg(webinfo, Server.MapPath(ConfigurationManager.AppSettings["WebInfoConfig"].ToString()));
                JscriptPrint("保存成功！", "SmsInterface.aspx", "Success");
            }
            catch
            {
                JscriptPrint("保存失败！", "SmsInterface.aspx", "Error");
            }
        }
    }
}
