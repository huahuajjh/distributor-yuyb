using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TravelAgent.Web.admin.product
{
    public partial class ProductDest : TravelAgent.Web.UI.BasePage
    {
        public int kindId; //目的地种类
        TravelAgent.BLL.Destination bll = new TravelAgent.BLL.Destination();
        public DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                BindData();
            }
        }
        /// <summary>
        /// 显示添加
        /// </summary>
        /// <returns></returns>
        public string ShowAdd()
        {
            StringBuilder sbButton = new StringBuilder();
            if (Admin.Role.roleAuth.IndexOf(",linedest_add,") > -1)
            {
                sbButton.Append("<ul class=\"toolbar\">");
                sbButton.Append("<li class=\"click\"><a href=\"EditDest.aspx\" class=\"dest_art\" title=\"添加旅游目的地\" width=\"700px\" height=\"380px\"><span><img src=\"../images/t01.png\" /></span>添加目的地</a></li>");
                sbButton.Append("</ul>");
            }
            return sbButton.ToString();
        }
        /// <summary>
        /// 目的地列表数据绑定
        /// </summary>
        private void BindData()
        {
            dt = bll.GetList(0, kindId);
            this.rptDestination.DataSource = dt;
            this.rptDestination.DataBind();
            divNoRecord.Style["display"] = dt.Rows.Count == 0 ? "" : "none";
        }
        /// <summary>
        /// 绑定项tr
        /// </summary>
        /// <param name="item"></param>
        public string BindDataTR(DataRowView row)
        {
            StringBuilder stringbuilder = new StringBuilder();
            string display = Convert.ToInt32(row["navParentId"]) > 0 ? "none" : "";
            string strTag = "<span style=\"width:{0}px;text-align:right;display:inline-block;padding-right:3px;padding-bottom:5px;\">{1}</span>";
            string strImg = "<img src=\"../images/t.png\" align=\"absmiddle\" />";
            string strLayer = "0";

            if (!row["navLayer"].ToString().Equals("1"))
            {
                strLayer = row["navParentId"].ToString();
                strTag = string.Format(strTag, 15 * Convert.ToInt32(row["navLayer"]), strImg);
            }
            else
            {
                strTag = string.Format(strTag, 0, "");
            }

            if (TravelAgent.Tool.BusinessOprate.isContainSubNav(dt, row))
            {
                stringbuilder.Append("<tr id=\"" + row["Id"] + "\" class=\"layer_" + strLayer + "\"  style=\"display:" + display + "; width:100%\" onclick=\"ShowLayer(this," + row["Id"] + ");\">");
                stringbuilder.Append("<td style=\"text-align:center;\">" + row["Id"] + "</td>");
                stringbuilder.Append("<td>" + strTag + "<span class=\"fuhao nolast\">&nbsp;&nbsp;&nbsp;&nbsp;</span>" + row["navName"] + "</td>");
            }
            else
            {
                stringbuilder.Append("<tr id=\"" + row["Id"] + "\" class=\"layer_" + strLayer + "\" style=\"display:" + display + "; width:100%\">");
                stringbuilder.Append("<td style=\"text-align:center;\">" + row["Id"] + "</td>");
                stringbuilder.Append("<td>" + strTag + "<span class=\"fuhao\">&nbsp;&nbsp;&nbsp;&nbsp;</span>" + row["navName"] + "</td>");
            }

            stringbuilder.Append("<td>" + row["navURL"] + "</td>");
            stringbuilder.Append("<td>" + TravelAgent.Tool.CommonOprate.GetStatesByValue(row["State"].ToString()) + "</td>");
            if (row["isLock"].ToString().Equals("1"))
            {
                stringbuilder.Append("<td style=\"text-align:center;\">隐藏</td>");
            }
            else
            {
                stringbuilder.Append("<td style=\"text-align:center;\">显示</td>");
            }
            stringbuilder.Append("<td style=\"text-align:center;\">" + row["navSort"] + "</td><td style=\"text-align:center;\">");

            if (Admin.Role.roleAuth.IndexOf(",linedest_update,") > -1)
            {
                stringbuilder.Append("<a href=\"EditDest.aspx?destid=" + row["Id"] + "\" class=\"tablelink dest_art\" title=\"修改网站导航\" width=\"700px\" height=\"350px\">修改</a> ");
            }

            if (Admin.Role.roleAuth.IndexOf(",linedest_delete,") > -1 && !row["navLayer"].ToString().Equals("1"))
            {
                stringbuilder.Append("<a href=\"#\" id=\"" + row["Id"] + "\" name=\"" + row["navName"] + "\" class=\"tablelink dest_delete\">删除</a>");
            }

            stringbuilder.Append("</td></tr>");

            return stringbuilder.ToString();
        }
    }
}
