using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TravelAgent.Web.admin.product
{
    public partial class LineHoliday : TravelAgent.Web.UI.BasePage
    {
        private static readonly TravelAgent.BLL.LineHoliday Bll = new TravelAgent.BLL.LineHoliday();
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
            if (Admin.Role.roleAuth.IndexOf(",lineholiday_add,") > -1)
            {
                sbButton.Append("<ul class=\"toolbar\">");
                sbButton.Append("<li class=\"click\"><a href=\"EditHoliday.aspx\" class=\"theme_art\" title=\"添加节日\" width=\"700px\" height=\"250px\"><span><img src=\"../images/t01.png\" /></span>添加节日</a></li>");
                sbButton.Append("<li class=\"click\"><a href=\"SetHoliday.aspx\" class=\"theme_art\" title=\"设置推广节日\" width=\"400px\" height=\"220px\"><span><img src=\"../images/t01.png\" /></span>设置推广节日</a></li>");
                sbButton.Append("</ul>");
            }
            return sbButton.ToString();
        }
        /// <summary>
        /// 绑定参团性质
        /// </summary>
        private void DataBindRpt()
        {
            DataSet ds = Bll.GetList();
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
            if (Admin.Role.roleAuth.IndexOf(",lineholiday_update,") > -1)
            {
                sbEdit.Append("<a href=\"EditHoliday.aspx?id=" + id + "\" class=\"tablelink theme_art\" width=\"700px\" height=\"250px\">修改</a>  ");
            }
            if (Admin.Role.roleAuth.IndexOf(",lineholiday_delete,") > -1)
            {
                sbEdit.Append("<a id=\"" + id + "\" name=\"" + title + "\" href=\"#\" class=\"tablelink theme_delete\">删除</a>");
            }
            return sbEdit.ToString();
        }
    }
}
