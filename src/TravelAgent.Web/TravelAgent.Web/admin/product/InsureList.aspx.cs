using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TravelAgent.Web.admin.product
{
    public partial class InsureList : TravelAgent.Web.UI.BasePage
    {
        private static readonly TravelAgent.BLL.Insure InsureBll = new TravelAgent.BLL.Insure();

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
            if (Admin.Role.roleAuth.IndexOf(",lineinsure_add,") > -1)
            {
                sbButton.Append("<ul class=\"toolbar\">");
                sbButton.Append("<li class=\"click\"><a href=\"EidtInsure.aspx\" class=\"theme_art\" title=\"添加保险\" width=\"700px\" height=\"450px\"><span><img src=\"../images/t01.png\" /></span>添加保险</a></li>");
                sbButton.Append("</ul>");
            }
            return sbButton.ToString();
        }
        /// <summary>
        /// 绑定参团性质
        /// </summary>
        private void DataBindRpt()
        {
            DataSet ds = InsureBll.GetList();
            this.rptList.DataSource = ds.Tables[0].DefaultView;
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
            if (Admin.Role.roleAuth.IndexOf(",lineinsure_update,") > -1)
            {
                sbEdit.Append("<a href=\"EidtInsure.aspx?insureid="+id+"\" class=\"tablelink theme_art\" width=\"700px\" height=\"450px\" title=\"修改保险\">修改</a>  ");
            }
            if (Admin.Role.roleAuth.IndexOf(",lineinsure_delete,") > -1)
            {
                sbEdit.Append("<a id=\""+id+"\" name=\""+title+"\" href=\"#\" class=\"tablelink insure_delete\">删除</a>");
            }
            return sbEdit.ToString();
        }
    }
}
