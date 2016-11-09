using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TravelAgent.Web.admin.basicset
{
    public partial class WebPoints : TravelAgent.Web.UI.BasePage
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
            this.txtRegPoints.Text = webinfo.FristReg.ToString();
            this.txtMobilePoints.Text = webinfo.MobileValidate.ToString();
            this.txtEmailPoints.Text = webinfo.EmailValidate.ToString();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                webinfo.FristReg = Convert.ToInt32(this.txtRegPoints.Text);
                webinfo.MobileValidate = Convert.ToInt32(this.txtMobilePoints.Text);
                webinfo.EmailValidate = Convert.ToInt32(this.txtEmailPoints.Text);
             
                ////修改配置信息
                WebInfoBll.saveConifg(webinfo, Server.MapPath(ConfigurationManager.AppSettings["WebInfoConfig"].ToString()));
                JscriptPrint("保存成功！", "WebPoints.aspx", "Success");
            }
            catch
            {
                JscriptPrint("保存失败！", "WebPoints.aspx", "Error");
            }
        }
    }
}
