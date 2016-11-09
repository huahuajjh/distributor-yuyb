using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TravelAgent.Web.admin.product
{
    public partial class EditSupply : TravelAgent.Web.UI.BasePage
    {
        private static readonly TravelAgent.BLL.Supply SupplyBll = new TravelAgent.BLL.Supply();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (Request.QueryString["supplyid"] != null)
                {
                    TravelAgent.Model.Supplier model = SupplyBll.GetModel(Convert.ToInt32(Request.QueryString["supplyid"]));
                    if (model != null)
                    {
                        this.txtSupplyName.Text = model.supplyName;
                        this.txtContactName.Text = model.contactName;
                        this.txtTelephone.Text = model.telephone;
                        this.txtMobilephone.Text = model.mobilephone;
                        this.txtEmail.Text = model.email;
                        this.txtRemark.Text = model.remark;
                        this.chkIsLock.Checked = model.isLock == 1;
                    }
                }
            }
        }
      
        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            TravelAgent.Model.Supplier model = new TravelAgent.Model.Supplier();
            model.supplyName = this.txtSupplyName.Text.Trim();
            model.contactName = this.txtContactName.Text.Trim();
            model.telephone = this.txtTelephone.Text.Trim();
            model.mobilephone = this.txtMobilephone.Text.Trim();
            model.email = this.txtEmail.Text.Trim();
            model.remark = this.txtRemark.Text.Trim();
            model.isLock = this.chkIsLock.Checked?1:0;
            var stringUrl = Request.Url.ToString();
            try
            {
                if (Request.QueryString["supplyid"] != null)
                {
                    model.Id = Convert.ToInt32(Request.QueryString["supplyid"]);
                    SupplyBll.Update(model);
                    JscriptPrint("保存成功！", "SupplyList.aspx", "Success");
                }
                else
                {
                    SupplyBll.Add(model);
                    JscriptPrint("添加成功！", "SupplyList.aspx", "Success");
                }
            }
            catch
            {
                JscriptPrint("保存失败！", stringUrl, "Error");
            }
        }
    }
}
