using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TravelAgent.Web.admin.basicset
{
    public partial class EditRole : TravelAgent.Web.UI.BasePage
    {
        private static readonly TravelAgent.BLL.AdminRole RoleBll = new TravelAgent.BLL.AdminRole();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (Request.QueryString["roleid"] != null)
                {
                    int roleid=Convert.ToInt32(Request.QueryString["roleid"]);
                    TravelAgent.Model.AdminRole role = RoleBll.GetModel(roleid);
                    if (role != null)
                    {
                        this.txtRole.Text = role.roleName;
                        this.txtRoleInfo.Value = role.roleInfo;
                        this.hidroleid.Value = roleid.ToString();
                        this.hidauth.Value = role.roleAuth;
                    }
                }
               
            }
        }
    }
}
