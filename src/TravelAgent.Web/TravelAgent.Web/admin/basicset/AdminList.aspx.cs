using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace TravelAgent.Web.admin.basicset
{
    public partial class AdminList : TravelAgent.Web.UI.BasePage
    {
        private static readonly TravelAgent.BLL.AdminList AdminBll = new TravelAgent.BLL.AdminList();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                BindAdmin();
            }
        
        }
        /// <summary>
        /// 显示添加
        /// </summary>
        /// <returns></returns>
        public string ShowAdd()
        {
            StringBuilder sbButton = new StringBuilder();
            if (Admin.Role.roleAuth.IndexOf(",sysuser_add,") > -1)
            {
                sbButton.Append("<ul class=\"toolbar\">");
                sbButton.Append("<li class=\"click\"><a href=\"EditAdmin.aspx\" class=\"data_art\" title=\"添加用户\" width=\"500px\" height=\"350px\"><span><img src=\"../images/t01.png\" /></span>添加用户</a></li>");
                sbButton.Append("</ul>");
            }
            return sbButton.ToString();
        }
        /// <summary>
        /// 绑定用户列表
        /// </summary>
        private void BindAdmin()
        {
            DataSet dsAdmin = AdminBll.GetList();
            this.rptList.DataSource = dsAdmin;
            this.rptList.DataBind();
            divNoRecord.Style["display"] = dsAdmin.Tables[0].Rows.Count > 0 ? "none" : "";
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
            if (Admin.Role.roleAuth.IndexOf(",sysuser_update,") > -1)
            {
                sbEdit.Append("<a href=\"EditAdmin.aspx?id="+id+"\" class=\"tablelink data_art\" width=\"500px\" height=\"350px\">修改</a>  ");
            }
            if (Admin.Role.roleAuth.IndexOf(",sysuser_delete,") > -1)
            {
                sbEdit.Append("<a id=\""+id+"\" name=\""+title+"\" href=\"#\" class=\"tablelink data_delete\">删除</a>");
            }
            return sbEdit.ToString();
        }
    }
}
