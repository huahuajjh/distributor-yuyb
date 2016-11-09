using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TravelAgent.Web.admin.data
{
    public partial class User : System.Web.UI.Page
    {
        private static TravelAgent.BLL.AdminList AdminBll = new TravelAgent.BLL.AdminList();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (Request["txtUsername"] != null)
                {
                    TravelAgent.Model.AdminList admin = new TravelAgent.Model.AdminList();
                    admin.UserName = Request["txtUsername"];
                    admin.UserPwd = Request["txtPassword"];
                    admin.ReadName = Request["txtTrueName"];
                    admin.RoleId = Convert.ToInt32(Request["ddlRole"]);
                    admin.IsLock = Request["chkIsLock"] == null ? 0 : 1;
                    int adminid = Convert.ToInt32(Request["hidId"]);
                    if (adminid == 0)
                    {
                        if (AdminBll.Add(admin) > 0)
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
                        admin.Id = adminid;
                        if (AdminBll.Update(admin) > 0)
                        {
                            Response.Write("true");
                        }
                        else
                        {
                            Response.Write("false");
                        }
                    }
                }
                if (Request["admin_id"] != null)
                {
                    if (AdminBll.Delete(Convert.ToInt32(Request["admin_id"])) > 0)
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
