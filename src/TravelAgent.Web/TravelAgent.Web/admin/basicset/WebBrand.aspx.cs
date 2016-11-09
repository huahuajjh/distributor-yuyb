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
    public partial class WebBrand : TravelAgent.Web.UI.BasePage
    {
        private static readonly TravelAgent.BLL.VisaBrand BrandBll = new TravelAgent.BLL.VisaBrand();
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
            if (Admin.Role.roleAuth.IndexOf(",sysbrand_add,") > -1)
            {
                sbButton.Append("<ul class=\"toolbar\">");
                sbButton.Append("<li class=\"click\"><a href=\"EditBrand.aspx\" class=\"brand_art\" title=\"添加品牌\" width=\"720px\" height=\"400px\"><span><img src=\"../images/t01.png\" /></span>添加品牌</a></li>");
                sbButton.Append("</ul>");
            }
            return sbButton.ToString();
        }
        /// <summary>
        /// 绑定出发城市
        /// </summary>
        private void DataBindRpt()
        {
            DataSet ds = BrandBll.GetList(0,"","Sort asc");
            this.rptCity.DataSource = ds.Tables[0].DefaultView;
            this.DataBind();
            trNoRecord.Style["display"] = ds.Tables[0].Rows.Count == 0 ? "" : "none";
        }
        /// <summary>
        /// 显示编辑按钮
        /// </summary>
        /// <param name="id"></param>
        /// <param name="title"></param>
        /// <returns></returns>
        public string ShowEdit(string id,string title)
        {
            StringBuilder sbEdit = new StringBuilder();
            if (Admin.Role.roleAuth.IndexOf(",sysbrand_update,") > -1)
            {
                sbEdit.Append("<a href=\"EditBrand.aspx?id="+id+"\" class=\"tablelink brand_art\" width=\"720px\" height=\"400px\">修改</a> ");
            }
            if (Admin.Role.roleAuth.IndexOf(",sysbrand_delete,") > -1)
            {
                sbEdit.Append("<a id="+id+" name="+title+" href=\"#\" class=\"tablelink brand_delete\">删除</a>");
            }
            return sbEdit.ToString();
        }
    }
}
