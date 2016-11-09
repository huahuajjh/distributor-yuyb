using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TravelAgent.Web.admin.basicset
{
    public partial class WebOther : TravelAgent.Web.UI.BasePage
    {
        private static readonly TravelAgent.BLL.WebInfo WebInfoBll = new TravelAgent.BLL.WebInfo();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                DataBindBaseInfo();

                if (Admin.Role.roleAuth.IndexOf(",sysother_update,") <= -1)
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
            this.txtWXName.Text = webinfo.WXName;
            this.txtImgUrl.Text = webinfo.WXM;
            //this.txtXLWBName.Text = webinfo.XLWBName;
            //this.txtImgUrl1.Text = webinfo.XLWBM;
            this.txtXLWBUrl.Text = webinfo.XLWBUrl;
            this.txtTXWBUrl.Text = webinfo.TXWBUrl;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                webinfo.WXName = this.txtWXName.Text.Trim();
                webinfo.WXM = this.txtImgUrl.Text;
                //webinfo.XLWBName = this.txtXLWBName.Text;
                //webinfo.XLWBM = this.txtImgUrl1.Text;
                webinfo.XLWBUrl = this.txtXLWBUrl.Text;
                webinfo.TXWBUrl = this.txtTXWBUrl.Text;
                ////修改配置信息
                WebInfoBll.saveConifg(webinfo, Server.MapPath(ConfigurationManager.AppSettings["WebInfoConfig"].ToString()));
                JscriptPrint("保存成功！", "WebOther.aspx", "Success");
            }
            catch
            {
                JscriptPrint("保存失败！", "WebOther.aspx", "Error");
            }
        }
    }
}
