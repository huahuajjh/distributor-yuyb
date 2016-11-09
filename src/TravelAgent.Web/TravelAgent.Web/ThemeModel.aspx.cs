using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TravelAgent.Web
{
    public partial class ThemeModel : System.Web.UI.Page
    {
        public int pcount;                                   //总条数
        public int page = 0;                                     //当前页
        public readonly int pagesize = 20;                    //设置每页显示的大小

        public int id;
        public string strBackgroudUrl = "";
        private static readonly TravelAgent.BLL.LineTheme ThemeBll = new TravelAgent.BLL.LineTheme();
        private static readonly TravelAgent.BLL.Line LineBll = new TravelAgent.BLL.Line();
        private static readonly TravelAgent.BLL.JoinProperty ProBll = new TravelAgent.BLL.JoinProperty();
        protected void Page_Load(object sender, EventArgs e)
        {
            int.TryParse(Request.QueryString["id"], out id);
            int.TryParse(Request.QueryString["page"], out page);
            if (!this.IsPostBack)
            {
                if (id > 0)
                {
                    TravelAgent.Model.LineTheme theme = ThemeBll.GetModel(id);
                    if (theme != null)
                    {
                        strBackgroudUrl = theme.themeTopPic;
                        this.ltTitle.Text = theme.themeName;
                        this.Title = theme.themeName + "-主题旅游-" + Master.webinfo.WebName;
                    }
                }
                else
                {
                    this.Title = "主题旅游-"+Master.webinfo.WebName;
                }
            }

        }
        /// <summary>
        /// 绑定线路
        /// </summary>
        /// <returns></returns>
        public string BindlistLine()
        {
            StringBuilder sbList = new StringBuilder();
            sbList.Append("<ul class=\"linebox\">");
            //获得总条数
            string strWhere = "CHARINDEX('," + id + ",',themeIds)>0 and isLock=0";
            this.pcount = LineBll.GetCount(strWhere);
            //Access
            //DataSet ds = LineBll.GetPageList(this.pagesize, this.page, "InStr(themeIds,'," + id + ",')>0 and isLock=0", "Sort asc,adddate desc");
            //SQL
            DataSet ds = LineBll.GetPageList(this.pagesize, this.page, strWhere, "Sort asc,adddate desc");
            DataRow row = null;
            //List<TravelAgent.Model.LineContent> lstLineContent = null;
            //TravelAgent.Model.LineContent content = null;
            int selectCount = ds.Tables[0].Rows.Count;
            for (int i = 0; i < selectCount; i++)
            {
                row = ds.Tables[0].Rows[i];
                sbList.Append("<li class=\"linelist\">");
                sbList.Append("<div class=\"linetop\">");
                //sbList.Append("<div class=\"linepic\"><a target=\"_blank\" href=\"/Line.aspx?id=" + row["Id"] + "\"><img alt=\"" + row["lineName"] + "\" src=\"" + row["linePic"] + "\"></a></div>");
                //urlrewrite
                sbList.Append("<div class=\"linepic\"><a target=\"_blank\" href=\"/line/" + row["Id"] + ".html\"><img alt=\"" + row["lineName"] + "\" src=\"" + row["linePic"] + "\"></a></div>");
                sbList.Append("<div class=\"linecon\">");
                sbList.Append("<p class=\"tit\">");
                //sbList.Append("<a target=\"_blank\" href=\"/Line.aspx?id=" + row["Id"] + "\">" + row["lineName"] + "</a>");
                //urlrewrite
                sbList.Append("<a target=\"_blank\" href=\"/line/" + row["Id"] + ".html\">" + row["lineName"] + "</a>");
                sbList.Append("</p>");
                sbList.Append("<p class=\"sight\">线路特色：" + row["lineSubName"] + "</p>");
                string strLineTheme = "";
                //if(!row["lineFeature"].ToString().Equals(""))
                //{
                //    strLineFeature=row["lineFeature"].ToString().Substring(0,74);
                //}
                if (!row["themeIds"].ToString().Equals(""))
                {
                    string strtheme = row["themeIds"].ToString().Trim(',');
                    DataSet dstheme = ThemeBll.GetList("Id in (" + strtheme + ")");
                    foreach (DataRow r in dstheme.Tables[0].Rows)
                    {
                        strLineTheme = strLineTheme + r["themeName"] + ",";
                    }
                }
                sbList.Append("<p class=\"sight\">线路主题：" + strLineTheme.Trim(',') + "</p>");
                sbList.Append("</div>");
                sbList.Append("<div class=\"lineico\">");
                sbList.Append("<p>");
                sbList.Append(TravelAgent.Tool.CommonOprate.ShowLineState(row["State"].ToString()));
                //sbList.Append("<i title=\"跟团游\" class=\"gty\"></i>");
                sbList.Append("</p>");
                sbList.Append("</div>");
                sbList.Append("<div class=\"linepre\">");
                if (row["priceCommon"].Equals(""))
                {
                    sbList.Append("<p class=\"jia\">电询</p>");
                }
                else
                {
                    sbList.Append("<p class=\"jia\"><font class=\"h014\">¥</font><font class=\"ho18\">" + row["priceCommon"] + "</font> 起</p>");
                }

                sbList.Append("<p class=\"gzu\">" + row["gzd"] + "人关注</p>");
                //sbList.Append("<a class=\"xq\" target=\"_blank\" href=\"/Line.aspx?id=" + row["Id"] + "\"></a>");
                //urlrewrite
                sbList.Append("<a class=\"xq\" target=\"_blank\" href=\"/line/" + row["Id"] + ".html\"></a>");
                sbList.Append("</div>");
                sbList.Append("</div>");
                sbList.Append("<div class=\"linebot\">");
                sbList.Append("<div class=\"botbox\"><p class=\"s1\">线路编号</p><p>L-" + row["Id"].ToString().PadLeft(6, '0') + "</p></div>");
                sbList.Append("<div class=\"botbox\"><p class=\"s1\">线路类型</p><p>" + getJoinPropery(Convert.ToInt32(row["proIds"])) + "</p></div>");
                sbList.Append("<div class=\"botbox\"><p class=\"s1\">行程天数</p><p>" + row["dayNumber"] + "天</p></div>");
                //sbList.Append("<div class=\"botbox\"><p class=\"s1\">发团日期</p><p class=\"tuanqi\"><a href=\"javascript:;\" data-url=\"/Line.aspx?id=" + row["Id"] + "\" data-id=\"" + row["Id"] + "\" class=\"zk\" rel=\"nofollow\">查看</a></p></div>");
                //urlrewrite
                sbList.Append("<div class=\"botbox\"><p class=\"s1\">发团日期</p><p class=\"tuanqi\"><a href=\"javascript:;\" data-url=\"/line/" + row["Id"] + ".html\" data-id=\"" + row["Id"] + "\" class=\"zk\" rel=\"nofollow\">查看</a></p></div>");
                sbList.Append("<div style=\"border:0\" class=\"botbox\"><p class=\"s1\">往返交通</p><p>" + row["trafficIds"].ToString().Trim(',') + "</p></div>");
                sbList.Append("</div>");
                sbList.Append("<dd class=\"case_calendar\" id=\"case_calendar_" + row["Id"] + "\">");
                sbList.Append("<div class=\"case_calendar_left\"></div>");
                sbList.Append("<div class=\"case_calendar_right\"></div>");
                sbList.Append(" </dd>");
                sbList.Append("</li>");
            }

            sbList.Append("</ul>");

            //分页
            if (this.pcount > this.pagesize)
            {
                int totalPagecount;
                if (this.pcount % this.pagesize != 0)
                {
                    totalPagecount = this.pcount / this.pagesize + 1;
                }
                else
                {
                    totalPagecount = this.pcount / this.pagesize;
                }

                sbList.Append("<div class=\"pages\">");

                if (this.page > 0)
                {
                    //sbList.Append("<a href='?id=" + id + "&page=" + (page - 1) + "'>上一页</a>");
                    //urlrewrite
                    sbList.Append("<a href='/theme/"+id+"/" + (page - 1) + ".html'>上一页</a>");
                }
                for (int i = 0; i < totalPagecount; i++)
                {
                    if (i == this.page)
                    {
                        sbList.Append("&nbsp;<span class='current'>" + (i + 1) + "</span>");
                    }
                    else
                    {
                        //sbList.Append("&nbsp;<a href='?id=" + id + "&page=" + i + "'>" + (i + 1) + "</a>");
                        //urlrewrite
                        sbList.Append("&nbsp;<a href='/theme/" + id + "/" + i + ".html'>" + (i + 1) + "</a>");
                    }

                }
                if (this.page < totalPagecount - 1)
                {
                    //sbList.Append("<a href='?id=" + id + "&page=" + (page + 1) + "'>下一页</a>");
                    //urlrewrite
                    sbList.Append("<a href='/theme/" + id + "/" + (page + 1) + ".html'>下一页</a>");
                }

                sbList.Append("</div>");
            }
            return sbList.ToString();
        }
        /// <summary>
        /// 获得参团性质
        /// </summary>
        /// <returns></returns>
        protected string getJoinPropery(int value)
        {
            TravelAgent.Model.JoinProperty proModel = ProBll.GetModel(value);
            return proModel != null ? proModel.joinName : "";
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
    }
}
