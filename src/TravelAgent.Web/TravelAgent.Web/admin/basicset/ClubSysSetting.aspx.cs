using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TravelAgent.Web.admin.basicset
{
    public partial class ClubSysSetting : TravelAgent.Web.UI.BasePage
    {
        private static readonly TravelAgent.BLL.InfoSetting bll = new TravelAgent.BLL.InfoSetting();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                TravelAgent.Model.InfoSetting info = new TravelAgent.Model.InfoSetting();
                info.ds = bll.GetList();
                this.txtRegContent.Value = info.getValue("RegFWTK");
                this.rbtnWebLock.SelectedValue = info.getValue("ClubIsReg");

                if (Admin.Role.roleAuth.IndexOf(",sysclub_update,") <= -1)
                {
                    this.btnSave.Visible = false;
                }
            }
        }
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            string stringUrl = Request.Url.ToString();
            Hashtable ht = new Hashtable();
            ht.Add("ClubIsReg", this.rbtnWebLock.SelectedValue);
            ht.Add("RegFWTK", this.txtRegContent.Value);
            try
            {
                bll.UpdateValue(ht);
                JscriptPrint("保存成功！", stringUrl, "Success");
            }
            catch
            {
                JscriptPrint("保存失败！", stringUrl, "Error");
            }
        }
    }
}
