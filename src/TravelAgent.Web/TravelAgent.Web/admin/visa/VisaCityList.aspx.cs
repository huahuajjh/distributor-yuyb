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
    public partial class VisaCityList : TravelAgent.Web.UI.BasePage
    {
        private static readonly TravelAgent.BLL.VisaCity CityBll = new TravelAgent.BLL.VisaCity();
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
            if (Admin.Role.roleAuth.IndexOf(",lingqu_add,") > -1)
            {
                sbButton.Append("<ul class=\"toolbar\">");
                sbButton.Append("<li class=\"click\"><a href=\"EditVisaCity.aspx\" class=\"city_art\" title=\"添加领区\" width=\"600px\" height=\"350px\"><span><img src=\"../images/t01.png\" /></span>添加领区</a></li>");
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
            if (Admin.Role.roleAuth.IndexOf(",lingqu_update,") > -1)
            {
                sbEdit.Append("<a href=\"EditVisaCity.aspx?cityid="+id+"\" class=\"tablelink city_art\" width=\"600px\" height=\"350px\">修改</a>  ");
            }
            if (Admin.Role.roleAuth.IndexOf(",lingqu_delete,") > -1)
            {
                sbEdit.Append("<a id=\""+id+"\" name=\""+title+"\" href=\"#\" class=\"tablelink city_delete\">删除</a>");
            }
            return sbEdit.ToString();
        }
        /// <summary>
        /// 绑定出发城市
        /// </summary>
        private void DataBindRpt()
        {
            DataSet ds = CityBll.GetList();
            this.rptCity.DataSource = ds.Tables[0].DefaultView;
            this.DataBind();
            divNoRecord.Style["display"] = ds.Tables[0].Rows.Count == 0 ? "" : "none";
        }
        /// <summary>
        /// 显示状态
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        public string ShowState(string state)
        {
            return TravelAgent.Tool.CommonOprate.IsContainValue("0", state) ? "不显示" : "显示";
        }
    }
}
