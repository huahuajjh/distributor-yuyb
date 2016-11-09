using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TravelAgent.Web.admin.data
{
    public partial class Role : System.Web.UI.Page
    {
        private static readonly TravelAgent.BLL.AdminRole RoleBll = new TravelAgent.BLL.AdminRole();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (Request["rolename"] != null)
                {
                    TravelAgent.Model.AdminRole role = new TravelAgent.Model.AdminRole();
                    role.roleName = Request["rolename"];
                    role.roleInfo = Request["roleinfo"];
                    role.roleAuth = Request["roleauth"];
                    int roleid = Request["roleid"] == "" ? 0 : Convert.ToInt32(Request["roleid"]);
                    if (roleid == 0)
                    {
                        if (RoleBll.Add(role) > 0)
                        {
                            Response.Write("true");
                        }
                        else
                        {
                            Response.Write("false");
                        }
                    }
                    else
                    {
                        role.Id=roleid;
                        if (RoleBll.Update(role) > 0)
                        {
                            Response.Write("true");
                        }
                        else
                        {
                            Response.Write("false");
                        }
                    }
                }
                if (Request["role_id"] != null)
                {
                    if (RoleBll.Delete(Convert.ToInt32(Request["role_id"])) > 0)
                    {
                        Response.Write("true");
                    }
                    else
                    {
                        Response.Write("false");
                    }
                }
            }
        }
    }
}
