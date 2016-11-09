using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TravelAgent.Web.admin.visa
{
    public partial class VistTypeList : TravelAgent.Web.UI.BasePage
    {
        private static readonly TravelAgent.BLL.VisaType TypeBll = new TravelAgent.BLL.VisaType();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                DataBindRpt();
            }
        }
        /// <summary>
        /// 绑定出发城市
        /// </summary>
        private void DataBindRpt()
        {
            DataSet ds = TypeBll.GetList();
            this.rptVisaType.DataSource = ds.Tables[0].DefaultView;
            this.DataBind();
            trNoRecord.Style["display"] = ds.Tables[0].Rows.Count == 0 ? "" : "none";
        }
        /// <summary>
        /// 显示添加
        /// </summary>
        /// <returns></returns>
        public string ShowAdd()
        {
            StringBuilder sbButton = new StringBuilder();
            if (Admin.Role.roleAuth.IndexOf(",visatype_add,") > -1)
            {
                sbButton.Append("<ul class=\"toolbar\">");
                sbButton.Append("<li class=\"click\"><a href=\"EditVisaType.aspx\" class=\"type_art\" title=\"添加签证类型\" width=\"600px\" height=\"250px\"><span><img src=\"../images/t01.png\" /></span>添加签证类型</a></li>");
                sbButton.Append("</ul>");
            }
            return sbButton.ToString();
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
            if (Admin.Role.roleAuth.IndexOf(",visatype_update,") > -1)
            {
                sbEdit.Append("<a href=\"EditVisaType.aspx?id="+id+"\" class=\"tablelink type_art\" width=\"600px\" height=\"250px\">修改</a>  ");
            }
            if (Admin.Role.roleAuth.IndexOf(",visatype_delete,") > -1)
            {
                sbEdit.Append("<a id=\""+id+"\" name=\""+title+"\" href=\"#\" class=\"tablelink type_delete\">删除</a>");
            }
            return sbEdit.ToString();
        }
    }
}
