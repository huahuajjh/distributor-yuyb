using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TravelAgent.Web.admin.product
{
    public partial class JoinProperty : TravelAgent.Web.UI.BasePage
    {
        private static readonly TravelAgent.BLL.JoinProperty PropertyBll = new TravelAgent.BLL.JoinProperty();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                DataBindRpt();
            }
        }
        /// <summary>
        /// 显示添加
        /// </summary>
        /// <returns></returns>
        public string ShowAdd()
        {
            StringBuilder sbButton = new StringBuilder();
            if (Admin.Role.roleAuth.IndexOf(",linejoin_add,") > -1)
            {
                sbButton.Append("<ul class=\"toolbar\">");
                sbButton.Append("<li class=\"click\"><a href=\"EditProperty.aspx\" class=\"city_art\" title=\"添加参团性质\" width=\"600px\" height=\"250px\"><span><img src=\"../images/t01.png\" /></span>添加参团性质</a></li>");
                sbButton.Append("</ul>");
            }
            return sbButton.ToString();
        }
        /// <summary>
        /// 绑定参团性质
        /// </summary>
        private void DataBindRpt()
        {
            DataSet ds = PropertyBll.GetList();
            this.rptProperty.DataSource = ds.Tables[0].DefaultView;
            this.DataBind();
            divNoRecord.Style["display"] = ds.Tables[0].Rows.Count == 0 ? "" : "none";
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
            if (Admin.Role.roleAuth.IndexOf(",linejoin_update,") > -1)
            {
                sbEdit.Append("<a href=\"EditProperty.aspx?propertyid="+id+"\" class=\"tablelink pro_art\" width=\"600px\" height=\"250px\">修改</a>  ");
            }
            if (Admin.Role.roleAuth.IndexOf(",linejoin_delete,") > -1)
            {
                sbEdit.Append("<a id=\"" + id + "\" name=\"" + title + "\" href=\"#\" class=\"tablelink pro_delete\">删除</a>");
            }
            return sbEdit.ToString();
        }
    }
}
