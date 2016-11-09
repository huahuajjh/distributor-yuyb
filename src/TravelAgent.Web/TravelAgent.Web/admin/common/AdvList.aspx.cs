using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TravelAgent.Web.admin.common
{
    public partial class AdvList : TravelAgent.Web.UI.BasePage
    {
        public DataTable dt;
        private static readonly TravelAgent.BLL.Advertising AdvBll = new TravelAgent.BLL.Advertising();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                DataBindAdv();
            }
        }
        /// <summary>
        /// 显示添加
        /// </summary>
        /// <returns></returns>
        public string ShowAdd()
        {
            StringBuilder sbButton = new StringBuilder();
            if (Admin.Role.roleAuth.IndexOf(",adv_add,") > -1)
            {
                sbButton.Append("<ul class=\"toolbar\">");
                sbButton.Append("<li class=\"click\"><a class=\"adv_art\" href=\"AdvEdit.aspx\"  title=\"添加广告位\" width=\"700px\" height=\"460px\"><span><img src=\"../images/t01.png\" /></span>添加广告位</a></li>");
                sbButton.Append("</ul>");
            }
            return sbButton.ToString();
        }
        /// <summary>
        /// 绑定广告位
        /// </summary>
        private void DataBindAdv()
        {
            dt = AdvBll.GetTableList(0);
            this.rptList.DataSource = dt;
            this.rptList.DataBind();
            this.trNoRecord.Style["display"] = dt.Rows.Count == 0 ? "" : "none";
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
                stringbuilder.Append("<td>" + strTag + "<span class=\"fuhao nolast\">&nbsp;&nbsp;&nbsp;&nbsp;</span>" + row["Title"] + "</td>");
            }
            else
            {
                stringbuilder.Append("<tr id=\"" + row["Id"] + "\" class=\"layer_" + strLayer + "\" style=\"display:" + display + "\">");
                stringbuilder.Append("<td style=\"text-align:center;\">" + row["Id"] + "</td>");
                stringbuilder.Append("<td>" + strTag + "<span class=\"fuhao last\">&nbsp;&nbsp;&nbsp;&nbsp;</span>" + row["Title"] + "</td>");
            }

            stringbuilder.Append("<td>" + row["AdRemark"] + "</td>");
            stringbuilder.Append("<td align=\"center\">" + GetTypeName(row["AdType"].ToString()) + "</td>");
            stringbuilder.Append("<td align=\"center\">" + row["AdNum"] + "</td>");
            stringbuilder.Append("<td align=\"center\">" + row["AdWidth"] + "px*" + row["AdHeight"] + "px</td>");
            stringbuilder.Append("<td align=\"center\">" + row["AdTarget"] + "</td>");
            stringbuilder.Append("<td style=\"text-align:center;\"><span>");
            if (Admin.Role.roleAuth.IndexOf(",adv_add,") > -1)
            {
                stringbuilder.Append("<a class=\"tablelink\" href=\"BarList.aspx?aid=" + row["Id"].ToString() + "\">内容管理</a> ");
            }
            stringbuilder.Append("<a class=\"tablelink adv_art\" href=\"AdvView.aspx?id=" + row["Id"].ToString() + "\" width=\"720px\" height=\"200px\">调用</a> ");
            if (Admin.Role.roleAuth.IndexOf(",adv_update,") > -1)
            { 
                stringbuilder.Append("<a class=\"tablelink adv_art\" href=\"AdvEdit.aspx?id=" + row["Id"].ToString() + "\" width=\"700px\" height=\"460px\">编辑</a> ");
            }
            if (Admin.Role.roleAuth.IndexOf(",adv_delete,") > -1)
            {
                stringbuilder.Append("<a href=\"#\" id=\"" + row["Id"] + "\" name=\"" + row["Title"] + "\" class=\"tablelink adv_delete\">删除</a>");
            }
            stringbuilder.Append("</span></td></tr>");

            return stringbuilder.ToString();
        }
        /// <summary>
        /// 显示广告类型
        /// </summary>
        /// <param name="strId"></param>
        /// <returns></returns>
        protected string GetTypeName(string strId)
        {
            switch (strId)
            {
                case "1":
                    return "文字";
                case "2":
                    return "图片";
                case "3":
                    return "幻灯片";
                case "4":
                    return "动画";
                case "5":
                    return "视频";
                case "6":
                    return "代码";
                default:
                    return "其它";
            }
        }
    }
}
