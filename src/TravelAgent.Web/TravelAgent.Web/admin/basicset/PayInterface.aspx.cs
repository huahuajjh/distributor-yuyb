using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TravelAgent.Web.admin.basicset
{
    public partial class PayInterface : TravelAgent.Web.UI.BasePage
    {
        private static readonly TravelAgent.BLL.WebInfo WebInfoBll = new TravelAgent.BLL.WebInfo();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.txtAlipayAccount.Text = webinfo.AlipayAccount;
                this.txtAlipayID.Text = webinfo.AlipayPid;
                this.txtAlipayKEY.Text = webinfo.AlipayKey;
                this.txtSiYue.Text = webinfo.AlipaySiyue;
                this.txtGongyue.Text = webinfo.AlipayGongyue;
                this.rbtnAlipayLock.SelectedValue = webinfo.AlipayIslock.ToString();

                this.txtAppId.Text = webinfo.AppID;
                this.txtappSecret.Text = webinfo.AppSecret;
                this.txtmchid.Text = webinfo.Mchid;
                this.txtapiKey.Text = webinfo.Key;
                this.rbtnwxPayLock.SelectedValue = webinfo.WxpayIsLock.ToString();

                this.txtChinabankAccount.Text = webinfo.ChinabankAccount;
                this.txtChinabankKey.Text = webinfo.ChinabankKey;
                this.rbtnChinabankLock.SelectedValue = webinfo.ChinabankIslock.ToString();

                if (Admin.Role.roleAuth.IndexOf(",sysinterface,") <= -1)
                {
                    this.btnSave.Visible = false;
                }
            }
        }
        /// <summary>
        /// 修改网银在线
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                webinfo.ChinabankAccount = this.txtChinabankAccount.Text;
                webinfo.ChinabankKey = this.txtChinabankKey.Text;
                webinfo.EmailIslock = Convert.ToInt32(this.rbtnChinabankLock.SelectedValue);

                ////修改配置信息
                WebInfoBll.saveConifg(webinfo, Server.MapPath(ConfigurationManager.AppSettings["WebInfoConfig"].ToString()));
                JscriptPrint("保存成功！", "PayInterface.aspx", "Success");
            }
            catch
            {
                JscriptPrint("保存失败！", "PayInterface.aspx", "Error");
            }
        }
        /// <summary>
        /// 修改支付宝
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave1_Click(object sender, EventArgs e)
        {
            try
            {
                webinfo.AlipayAccount = this.txtAlipayAccount.Text.Trim();
                webinfo.AlipayPid = this.txtAlipayID.Text.Trim();
                webinfo.AlipayKey = this.txtAlipayKEY.Text;
                webinfo.AlipaySiyue = this.txtSiYue.Text.Trim();
                webinfo.AlipayGongyue = this.txtGongyue.Text;
                webinfo.AlipayIslock = Convert.ToInt32(this.rbtnAlipayLock.SelectedValue);
                ////修改配置信息
                WebInfoBll.saveConifg(webinfo, Server.MapPath(ConfigurationManager.AppSettings["WebInfoConfig"].ToString()));
                JscriptPrint("保存成功！", "PayInterface.aspx", "Success");
            }
            catch
            {
                JscriptPrint("保存失败！", "PayInterface.aspx", "Error");
            }
        }
        /// <summary>
        /// 修改微信支付
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave2_Click(object sender, EventArgs e)
        {
            try
            {
                webinfo.AppID = this.txtAppId.Text.Trim();
                webinfo.AppSecret = this.txtappSecret.Text.Trim();
                webinfo.Mchid = this.txtmchid.Text;
                webinfo.Key = this.txtapiKey.Text.Trim();
                webinfo.WxpayIsLock = Convert.ToInt32(this.rbtnwxPayLock.SelectedValue);
                ////修改配置信息
                WebInfoBll.saveConifg(webinfo, Server.MapPath(ConfigurationManager.AppSettings["WebInfoConfig"].ToString()));
                JscriptPrint("保存成功！", "PayInterface.aspx", "Success");
            }
            catch
            {
                JscriptPrint("保存失败！", "PayInterface.aspx", "Error");
            }
        }
    }
}
