using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TravelAgent.Web.admin.product
{
    public partial class LineThree : TravelAgent.Web.UI.BasePage
    {
        public int lineid;
        public string tag;
        public int dayNumber;
        private static readonly TravelAgent.BLL.Line LineBll = new TravelAgent.BLL.Line();
        private static readonly TravelAgent.BLL.LineContent LineContentBll = new TravelAgent.BLL.LineContent();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (Request.QueryString["tag"] != null)
                {
                    tag = Request.QueryString["tag"];
                }
                if (Request.QueryString["id"] != null)
                {
                    lineid = Convert.ToInt32(Request.QueryString["id"]);
                    this.hidlineid.Value = lineid.ToString();
                    if (lineid > 0)
                    {
                        TravelAgent.Model.Line line = LineBll.GetModel(lineid);
                        if (line != null)
                        {
                            dayNumber = line.DayNumber;
                            this.rbtnEditModel.SelectedValue = line.EditModel.ToString();
                            this.trDayEdit.Style["display"] = line.EditModel == 0?"":"none";
                            this.trVisableEdit.Style["display"] = line.EditModel == 1 ? "" : "none";
                            List<TravelAgent.Model.LineContent> lineContent = LineContentBll.GetlstLineContentByLineId(lineid);
                            LoadLineContent(dayNumber,lineContent);
                            this.txtContent.Value = line.LineContent;
                        }
                    }
                   
                }
            }
        }
        /// <summary>
        /// 加载行程内容
        /// </summary>
        /// <param name="dayNumber"></param>
        /// <returns></returns>
        private void LoadLineContent(int dayNumber,List<TravelAgent.Model.LineContent> linecontent)
        {
            StringBuilder sb = new StringBuilder();
            TravelAgent.Model.LineContent content = null;
            sb.Append("<table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" style=\"width:100%\" class=\"formtable\">");
            for (int i = 1; i <= dayNumber; i++)
            {
                content=GetLineContent(i,linecontent);
                sb.Append("<tr>");
                sb.Append("<td style=\"width:6%; text-align:center\">第 <span style=\"font-weight:bold;font-size:16px\">"+i+"</span> 天</td>");
                sb.Append("<td>");
                sb.Append("<table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" style=\"width:100%;\">");
                sb.Append("<tr>");
                sb.Append("<td style=\" width:55px; text-align:right\">标题：</td>");
                sb.Append("<td>");
                sb.Append("<table border=\"0\" cellpadding=\"0\" cellspacing=\"0\">");
                sb.Append("<tr>");
                string strtitle = content == null ? "" : content.Title;
                sb.Append("<td style=\"border:0\"><input id=\"txt_BT_D" + i + "\" name=\"txt_BT_D" + i + "\" type=\"text\" class=\"dfinput w200\" value=\"" + strtitle + "\" /></td>");
                sb.Append("<td style=\"border:0\">");
                sb.Append("<a href=\"javascript:;\" onclick=\"addtraffic('"+i+"','[飞机]');\"><img src=\"/images/air.gif\" alt=\"飞机\" title=\"飞机\"></a> ");
                sb.Append("<a href=\"javascript:;\" onclick=\"addtraffic('"+i+"','[船]');\"><img src=\"/images/ship.gif\" alt=\"船\" title=\"船\"></a>");
                sb.Append("<a href=\"javascript:;\" onclick=\"addtraffic('"+i+"','[火车]');\"><img src=\"/images/train.gif\" alt=\"火车\" title=\"火车\"></a>");
                sb.Append("<a href=\"javascript:;\" onclick=\"addtraffic('"+i+"','[汽车]');\"><img src=\"/images/vehicle.gif\" alt=\"汽车\" title=\"汽车\"></a>");
                sb.Append("</td>");
                sb.Append("</tr>");
                sb.Append("</table>");
                sb.Append("</td>");
                sb.Append("</tr>");
                sb.Append("<tr>");
                sb.Append("<td style=\"text-align:right\">用餐：</td>");
                sb.Append("<td>");
                sb.Append("<table border=\"0\" cellpadding=\"0\" cellspacing=\"0\">");
                sb.Append("<tr>");
                sb.Append("<td style=\"border:0\">早</td>");
                sb.Append("<td style=\"border:0\">");
                sb.Append("<input id=\"chk_morn_D" + i + "\" name=\"chk_morn_D" + i + "\" type=\"checkbox\" " + GetCheckedCatering("morn",content)+ " />");
                sb.Append("</td>");
                sb.Append("<td style=\"border:0\">中</td>");
                sb.Append("<td style=\"border:0\">");
                sb.Append("<input id=\"chk_noon_D" + i + "\" name=\"chk_noon_D" + i + "\" type=\"checkbox\" " + GetCheckedCatering("noon", content) + " />");
                sb.Append("</td>");
                sb.Append("<td style=\"border:0\">晚</td>");
                sb.Append("<td style=\"border:0\">");
                sb.Append("<input id=\"chk_night_D" + i + "\" name=\"chk_night_D" + i + "\" type=\"checkbox\" " + GetCheckedCatering("night", content) + " />");
                sb.Append("</td>");
                sb.Append("</tr>");
                sb.Append("</table>");
                sb.Append("</td>");
                sb.Append("</tr>");
                sb.Append("<tr>");
                sb.Append("<td style=\"text-align:right\">住宿：</td>");
                string straccom = content == null ? "" : content.Accom;
                sb.Append("<td style=\"padding-left:10px;\"><input id=\"txt_ZS_D" + i + "\" name=\"txt_ZS_D" + i + "\" type=\"text\" class=\"dfinput w150\" value=\"" + straccom + "\" /></td>");
                sb.Append("</tr>");
                sb.Append("<tr>");
                sb.Append("<td style=\"text-align:right\">内容：</td>");
                string strcontent = content == null ? "" : content.Content;
                sb.Append("<td style=\"padding-right:5px;\"><textarea id=\"txt_Content_D" + i + "\" name=\"txt_Content_D" + i + "\" cols=\"100\" rows=\"4\" style=\"width:100%; height:180px;\">" + strcontent + "</textarea></td>");
                sb.Append(" </tr>");
                sb.Append("</table>");
                sb.Append("</td>");
                sb.Append("</tr>");
            }
            sb.Append("</table>");
            divContent.InnerHtml = sb.ToString();
        }
        /// <summary>
        /// 获得第几天的内容
        /// </summary>
        /// <param name="daySort"></param>
        /// <param name="linecontent"></param>
        /// <returns></returns>
        private TravelAgent.Model.LineContent GetLineContent(int daySort, List<TravelAgent.Model.LineContent> linecontent)
        {
            TravelAgent.Model.LineContent content = null;
            foreach (TravelAgent.Model.LineContent con in linecontent)
            {
                if (daySort == con.DaySort)
                {
                    content = con;
                    break;
                }
            }

            return content;
        }
        /// <summary>
        /// 获得餐饮的选中状态
        /// </summary>
        /// <returns></returns>
        public string GetCheckedCatering(string tag,TravelAgent.Model.LineContent content)
        {
            string check = "";
            if (content != null)
            {
                if (tag == "morn")
                {
                    if (content.Morn == 1)
                    {
                        check = "checked=\"checked\"";
                    }
                }
                else if (tag == "noon")
                {
                    if (content.Noon == 1)
                    {
                        check = "checked=\"checked\"";
                    }
                }
                else if (tag == "night")
                {
                    if (content.Night == 1)
                    {
                        check = "checked=\"checked\"";
                    }
                }
            }
            return check;
        }
    }
}
