using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
namespace TravelAgent.Web.admin.basicset
{
    public partial class EditAdmin : System.Web.UI.Page
    {
        private static readonly TravelAgent.BLL.AdminRole RoleBll = new TravelAgent.BLL.AdminRole();
        private static readonly TravelAgent.BLL.AdminList AdminBll = new TravelAgent.BLL.AdminList();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                BindRole();
                if (Request.QueryString["id"] != null)
                { 
                    int adminid=Convert.ToInt32(Request.QueryString["id"]);
                    TravelAgent.Model.AdminList admin = AdminBll.GetModel(adminid);
                    if (admin != null)
                    {
                        this.hidId.Value = adminid.ToString();
                        this.ddlRole.SelectedValue = admin.RoleId.ToString();
                        this.txtUsername.Text = admin.UserName;
                        this.txtPassword.Attributes.Add("value", admin.UserPwd);
                        this.txtTrueName.Text = admin.ReadName;
                        this.chkIsLock.Checked = admin.IsLock == 1;
                    }
                }
            }
        }
        /// <summary>
        /// 绑定角色
        /// </summary>
        private void BindRole()
        {
            DataSet dsRole = RoleBll.GetList();
            this.ddlRole.DataSource = dsRole;
            this.ddlRole.DataTextField = "roleName";
            this.ddlRole.DataValueField = "Id";
            this.ddlRole.DataBind();
            this.ddlRole.Items.Insert(0, new ListItem("选择角色", ""));
        }
    }
}
