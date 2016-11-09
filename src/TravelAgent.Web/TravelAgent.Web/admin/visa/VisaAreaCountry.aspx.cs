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
    public partial class VisaAreaCountry : TravelAgent.Web.UI.BasePage
    {
        TravelAgent.BLL.VisaCountry bll = new TravelAgent.BLL.VisaCountry();
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
            if (Admin.Role.roleAuth.IndexOf(",area_add,") > -1)
            {
                sbButton.Append("<ul class=\"toolbar\">");
                sbButton.Append("<li class=\"click\"><a href=\"EditAreaCountry.aspx\" class=\"country_art\" title=\"添加国家区域\" width=\"700px\" height=\"520px\"><span><img src=\"../images/t01.png\" /></span>添加国家区域</a></li>");
                sbButton.Append("</ul>");
            }
            return sbButton.ToString();
        }
        /// <summary>
        /// 列表数据绑定
        /// </summary>
        private void BindData()
        {
            dt = bll.GetList(0,"");
            this.rptCountry.DataSource = dt;
            this.rptCountry.DataBind();
            divNoRecord.Style["display"] = dt.Rows.Count == 0 ? "" : "none";
        }
        /// <summary>
        /// 绑定项tr
        /// </summary>
        /// <param name="item"></param>
        public string BindDataTR(DataRowView row)
        {
            StringBuilder stringbuilder = new StringBuilder();
            string display = Convert.ToInt32(row["ParentId"]) > 0 ? "none" : "";
            string strTag = "<span style=\"width:{0}px;text-align:right;display:inline-block;padding-right:3px;padding-bottom:5px;\">{1}</span>";
            string strImg = "<img src=\"../images/t.png\" align=\"absmiddle\" />";
            string strLayer = "0";

            if (!row["ClassLayer"].ToString().Equals("1"))
            {
                strLayer = row["ParentId"].ToString();
                strTag = string.Format(strTag, 15 * Convert.ToInt32(row["ClassLayer"]), strImg);
            }
            else
            {
                strTag = string.Format(strTag, 0, "");
            }

            if (TravelAgent.Tool.BusinessOprate.isContainSub(dt, row))
            {
                stringbuilder.Append("<tr id=\"" + row["Id"] + "\" class=\"layer_" + strLayer + "\"  style=\"display:" + display + "\" onclick=\"ShowLayer(this," + row["Id"] + ");\">");
                stringbuilder.Append("<td style=\"text-align:center;\">" + row["Id"] + "</td>");
                stringbuilder.Append("<td>" + strTag + "<span class=\"fuhao nolast\">&nbsp;&nbsp;&nbsp;&nbsp;</span>" + row["Name"] + "</td>");
            }
            else
            {
                stringbuilder.Append("<tr id=\"" + row["Id"] + "\" class=\"layer_" + strLayer + "\" style=\"display:" + display + "\">");
                stringbuilder.Append("<td style=\"text-align:center;\">" + row["Id"] + "</td>");
                stringbuilder.Append("<td>" + strTag + "<span class=\"fuhao last\">&nbsp;&nbsp;&nbsp;&nbsp;</span>" + row["Name"] + "</td>");
            }

            stringbuilder.Append("<td>" + row["EnglishName"] + "</td>");
            stringbuilder.Append("<td>" + row["FirstWord"] + "</td>");
            if (row["isLock"].ToString().Equals("1"))
            {
                stringbuilder.Append("<td style=\"text-align:center;\">隐藏</td>");
            }
            else
            {
                stringbuilder.Append("<td style=\"text-align:center;\">显示</td>");
            }
            stringbuilder.Append("<td style=\"text-align:center;\">" + row["Sort"] + "</td><td style=\"text-align:center;\">");
            if (Admin.Role.roleAuth.IndexOf(",area_update,") > -1)
            {
                stringbuilder.Append("<a href=\"EditAreaCountry.aspx?id=" + row["Id"] + "\" class=\"tablelink country_art\" title=\"修改网站导航\" width=\"700px\" height=\"500px\">修改</a> ");
            }
            if (Admin.Role.roleAuth.IndexOf(",area_delete,") > -1)
            {
                stringbuilder.Append("<a href=\"#\" id=\"" + row["Id"] + "\" name=\"" + row["Name"] + "\" class=\"tablelink country_delete\">删除</a>");
            }
            stringbuilder.Append("</td></tr>");

            return stringbuilder.ToString();
        }
    }
}
