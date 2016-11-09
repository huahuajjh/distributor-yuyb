using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TravelAgent.Web.admin.visa
{
    public partial class VisaSetting : TravelAgent.Web.UI.BasePage
    {
        private static readonly TravelAgent.BLL.InfoSetting bll = new TravelAgent.BLL.InfoSetting();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                TravelAgent.Model.InfoSetting info = new TravelAgent.Model.InfoSetting();
                info.ds = bll.GetList();
                this.txtVisa01.Value = info.getValue("VisaZYSX");
                this.txtVisa02.Value = info.getValue("VisaMZSM");

                if (Admin.Role.roleAuth.IndexOf(",visaset_update,") <= -1)
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
            ht.Add("VisaZYSX",this.txtVisa01.Value);
            ht.Add("VisaMZSM", this.txtVisa02.Value);
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
