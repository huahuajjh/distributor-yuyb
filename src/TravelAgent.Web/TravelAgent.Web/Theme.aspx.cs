using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TravelAgent.Tool;
namespace TravelAgent.Web
{
    public partial class Theme : System.Web.UI.Page
    {
        private static readonly TravelAgent.BLL.Article ArticleBll = new TravelAgent.BLL.Article();
        private static readonly TravelAgent.BLL.LineTheme ThemeBll = new TravelAgent.BLL.LineTheme();
        private static readonly TravelAgent.BLL.Line LineBll = new TravelAgent.BLL.Line();
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Title = "主题旅游-特色旅游-" + Master.webinfo.WebName;
        }
        /// <summary>
        /// 绑定导航
        /// </summary>
        /// <returns></returns>
        public string BindThemeNav()
        {
            StringBuilder sbTheme = new StringBuilder();
            DataSet dsTheme = ThemeBll.GetList("isLock=0");
            DataRow row = null;
            for (int i = 0; i < dsTheme.Tables[0].Rows.Count; i++)
            {
                row = dsTheme.Tables[0].Rows[i];
                //sbTheme.Append("<li class=\"ph" + (i + 1) + "\"><a href=\"/ThemeModel.aspx?id=" + row["Id"] + "\" target=\"_blank\">" + row["themeName"] + "</a></li>");
                //urlrewrite
                sbTheme.Append("<li class=\"ph"+(i+1)+"\"><a href=\"/theme/"+row["Id"]+".html\" target=\"_blank\">" + row["themeName"] + "</a></li>");
            }
            return sbTheme.ToString();    
        }
        /// <summary>
        /// 绑定线路
        /// </summary>
        /// <returns></returns>
        public string BindLine()
        { 
            StringBuilder sbLine = new StringBuilder();
            DataSet dsTheme = ThemeBll.GetList("isLock=0");
            DataRow row = null;
            for (int i = 0; i < dsTheme.Tables[0].Rows.Count; i++)
            {
                row = dsTheme.Tables[0].Rows[i];
                //sbLine.Append("<h3 class=\"bord" + (i + 1) + "\"><a href=\"/ThemeModel.aspx?id=" + row["Id"] + "\" target=\"_blank\">" + row["themeName"] + "</a></h3>");
                //urlrewrite
                sbLine.Append("<h3 class=\"bord" + (i + 1) + "\"><a href=\"/theme/"+row["Id"]+".html\" target=\"_blank\">" + row["themeName"] + "</a></h3>");
                sbLine.Append("<ul class=\"themebox\">");
                //Access
                //DataSet dsLine = LineBll.GetList(4, "InStr(themeIds,'," + row["Id"] + ",')>0", "Sort asc,adddate desc");
                //SQL
                DataSet dsLine = LineBll.GetList(4, "CHARINDEX('," + row["Id"] + ",',themeIds)>0", "Sort asc,adddate desc");
                foreach (DataRow r in dsLine.Tables[0].Rows)
                {
                    sbLine.Append("<li>");
                    //sbLine.Append("<a href=\"/Line.aspx?id=" + r["Id"] + "\" target=\"_blank\"><img src=\"" + r["linePic"] + "\" alt=\"" + r["lineName"] + "\" /></a>");
                    //sbLine.Append("<p class=\"theme_txt\"><a href=\"Line.aspx?id=" + r["Id"] + "\" target=\"_blank\">" + r["lineName"] + "</a></p>");
                    //urlrewrite
                    sbLine.Append("<a href=\"/line/"+r["Id"]+".html\" target=\"_blank\"><img src=\""+r["linePic"]+"\" alt=\""+r["lineName"]+"\" /></a>");
                    sbLine.Append("<p class=\"theme_txt\"><a href=\"/line/"+r["Id"]+".html\" target=\"_blank\">"+r["lineName"]+"</a></p>");
                    if (!r["priceCommon"].Equals("") && !r["priceCommon"].Equals("0"))
                    {
                        sbLine.Append("<p class=\"theme_pre\">¥<font class=\"ho18\">" + r["priceCommon"] + "</font></p>");
                    }
                    else
                    {
                        sbLine.Append("<p class=\"theme_pre\">电询</p>");
                    }
                    sbLine.Append("</li>");
                }
                sbLine.Append("</ul>");
            }
            return sbLine.ToString();
        }
        /// <summary>
        /// 绑定特价线路
        /// </summary>
        /// <returns></returns>
        public string BindTejiaLine(int state, int top)
        {
            StringBuilder sbLine = new StringBuilder();
            //Access
            //DataSet dsLine = LineBll.GetList(top, "InStr(State,'," + state + ",')>0 and isLock=0", "Sort asc,adddate desc");
            //SQL
            DataSet dsLine = LineBll.GetList(top, "CHARINDEX('," + state + ",',State)>0 and isLock=0", "Sort asc,adddate desc");
            DataRow row = null;
            for (int i = 0; i < dsLine.Tables[0].Rows.Count; i++)
            {
                row = dsLine.Tables[0].Rows[i];
                if (i == dsLine.Tables[0].Rows.Count - 1)
                {
                    sbLine.Append("<li style=\"border:none\">");
                }
                else
                {
                    sbLine.Append("<li >");
                }
                //sbLine.Append("<a href=\"/Line.aspx?id=" + row["Id"] + "\" target=\"_blank\"><img src=\"" + row["linePic"] + "\" alt=\"" + row["lineName"] + "\" />" + row["lineName"] + "</a>");
                //urlrewrite
                sbLine.Append("<a href=\"/line/" + row["Id"] + ".html\" target=\"_blank\"><img src=\"" + row["linePic"] + "\" alt=\"" + row["lineName"] + "\" />" + row["lineName"] + "</a>");
                if (row["priceContent"].ToString() != "")
                {
                    sbLine.Append("<p><span>¥<font class=\"ho18\">" + row["priceContent"].ToString().Split(',')[2] + "</font></span><s>¥ " + row["priceContent"].ToString().Split(',')[0] + "</s></p>");
                }
                else
                {
                    sbLine.Append("<p><span><font class=\"ho18\">电询</font></span></p>");
                }

                sbLine.Append("</li>");
            }
            return sbLine.ToString();
        }
        /// <summary>
        /// 绑定文章
        /// </summary>
        /// <param name="type"></param>
        /// <param name="top"></param>
        /// <returns></returns>
        public string BindNews(int type, int top)
        {
            StringBuilder sbNews = new StringBuilder();
            DataSet dsNews = ArticleBll.GetList(top, "ClassId=" + type, "Click asc,AddTime desc");
            foreach (DataRow row in dsNews.Tables[0].Rows)
            {
                if (type == 1)
                {
                    //sbNews.Append("<li><a href=\"/NewsList.aspx?nav=" + type + "\" target=\"_blank\" class=\"the1\">[公告]</a><a href=\"/New.aspx?nav=" + type + "&id=" + row["Id"] + "\" target=\"_blank\" title=\"" + row["Title"] + "\" class=\"the2\">" + StringPlus.LeftTrueLen(row["Title"].ToString(), 22, "") + "</a></li>");
                    //urlrewrite
                    sbNews.Append("<li><a href=\"/newlist/" + type + ".html\" target=\"_blank\" class=\"the1\">[公告]</a><a href=\"/New.aspx?nav=" + type + "&id=" + row["Id"] + "\" target=\"_blank\" title=\"" + row["Title"] + "\" class=\"the2\">" + StringPlus.LeftTrueLen(row["Title"].ToString(), 22, "") + "</a></li>");
                }
                else if (type == 2)
                {
                    sbNews.Append("<li><a href=\"/newlist/" + type + ".html\" target=\"_blank\" class=\"the1\">[资讯]</a><a href=\"/New.aspx?nav=" + type + "&id=" + row["Id"] + "\" target=\"_blank\" title=\"" + row["Title"] + "\" class=\"the2\">" + StringPlus.LeftTrueLen(row["Title"].ToString(), 22, "") + "</a></li>");
                }
                else if (type == 49)
                {
                    //sbNews.Append("<li><a href=\"/New.aspx?nav=" + type + "&id=" + row["Id"] + "\" target=\"_blank\">" + row["Title"] + "</a></li>");
                    //urlrewrite
                    sbNews.Append("<li><a href=\"/new/" + type + "/" + row["Id"] + ".html\" target=\"_blank\">" + row["Title"] + "</a></li>");
                }
            }
            return sbNews.ToString();
        }
    }
}
