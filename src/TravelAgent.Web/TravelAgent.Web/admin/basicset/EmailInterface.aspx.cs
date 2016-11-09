using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TravelAgent.Web.admin.basicset
{
    public partial class EmailInterface : TravelAgent.Web.UI.BasePage
    {
        private static readonly TravelAgent.BLL.WebInfo WebInfoBll = new TravelAgent.BLL.WebInfo();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.txtUserName.Text = webinfo.EmailUsername;
                this.txtUserPassword.Attributes.Add("value", webinfo.EmailPassword);
                this.txtEmail.Text = webinfo.EmailAccount;
                this.txtSMTP.Text = webinfo.EmailSmtp;
                this.txtPort.Text = webinfo.EmailPort;
                this.rbtnLock.SelectedValue = webinfo.EmailIslock.ToString();

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
                webinfo.EmailUsername = this.txtUserName.Text.Trim();
                webinfo.EmailPassword = this.txtUserPassword.Text.Trim();
                webinfo.EmailAccount = this.txtEmail.Text;
                webinfo.EmailSmtp = this.txtSMTP.Text.Trim();
                webinfo.EmailPort = this.txtPort.Text;
                webinfo.EmailIslock = Convert.ToInt32(this.rbtnLock.SelectedValue);

                ////修改配置信息
                WebInfoBll.saveConifg(webinfo, Server.MapPath(ConfigurationManager.AppSettings["WebInfoConfig"].ToString()));
                JscriptPrint("保存成功！", "EmailInterface.aspx", "Success");
            }
            catch
            {
                JscriptPrint("保存失败！", "EmailInterface.aspx", "Error");
            }
        }
    }
}
