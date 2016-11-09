using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TravelAgent.Web.admin.basicset
{
    public partial class RoleList : TravelAgent.Web.UI.BasePage
    {
        private static readonly TravelAgent.BLL.AdminRole RoleBll = new TravelAgent.BLL.AdminRole();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                BindRoleList();
            }
        }
        /// <summary>
        /// 显示添加
        /// </summary>
        /// <returns></returns>
        public string ShowAdd()
        {
            StringBuilder sbButton = new StringBuilder();
            if (Admin.Role.roleAuth.IndexOf(",sysrole_add,") > -1)
            {
                sbButton.Append("<ul class=\"toolbar\">");
                sbButton.Append("<li class=\"click\"><a href=\"EditRole.aspx\"><span><img src=\"../images/t01.png\" /></span>添加角色</a></li>");
                sbButton.Append("</ul>");
            }
            return sbButton.ToString();
        }
        /// <summary>
        /// 绑定角色列表
        /// </summary>
        private void BindRoleList()
        {
            DataSet dsRole = RoleBll.GetList();
            this.rptList.DataSource = dsRole;
            this.rptList.DataBind();
            divNoRecord.Style["display"] = dsRole.Tables[0].Rows.Count > 0 ? "none" : "";
        }

        /// <summary>
        /// 显示编辑按钮
        /// </summary>
        /// <param name="id"></param>
        /// <param name="title"></param>
        /// <returns></returns>
        public string ShowEdit(string id, string title)
        {
            StringBuilder sbEdit = new StringBuilder();
            if (Admin.Role.roleAuth.IndexOf(",sysrole_update,") > -1)
            {
                sbEdit.Append("<a href=\"EditRole.aspx?roleid="+id+"\" class=\"tablelink\">修改</a>  ");
            }
            if (Admin.Role.roleAuth.IndexOf(",sysrole_delete,") > -1)
            {
                sbEdit.Append("<a id=\""+id+"\" name=\""+title+"\" href=\"#\" class=\"tablelink data_delete\">删除</a>");
            }
            return sbEdit.ToString();
        }
    }
}
