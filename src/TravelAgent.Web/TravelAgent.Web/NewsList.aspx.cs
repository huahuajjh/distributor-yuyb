using System;
using System.Text;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TravelAgent.Web
{
    public partial class NewsList : System.Web.UI.Page
    {
        public int nav;
        public int id;
        public string strNav = "";

        public int pcount;                                   //总条数
        public int page = 0;                                     //当前页
        public readonly int pagesize = 20;                    //设置每页显示的大小

        private static readonly TravelAgent.BLL.Article ArticleBll = new TravelAgent.BLL.Article();
        private static readonly TravelAgent.BLL.Category CateBll = new TravelAgent.BLL.Category();
        private static readonly TravelAgent.BLL.Line LineBll = new TravelAgent.BLL.Line();
        protected void Page_Load(object sender, EventArgs e)
        {
            int.TryParse(Request.QueryString["nav"], out nav);
            int.TryParse(Request.QueryString["page"], out page);
            if (!this.IsPostBack)
            {
                StringBuilder sbPlace = new StringBuilder();
                if (nav > 0)
                {
                    TravelAgent.Model.Category Cate = CateBll.GetModel(nav);
                    if (Cate != null)
                    {
                        sbPlace.Append("<em>" + Cate.Title + "</em>");
                        this.ltTitle.Text = Cate.Title;
                        this.Title = Cate.Title + "-" + Master.webinfo.WebName;
                    }
                }

                strNav = sbPlace.ToString();
            }
        }
       
        /// <summary>
        /// 绑定新闻列表
        /// </summary>
        /// <returns></returns>
        public string BindNewsList()
        {
            StringBuilder sbList = new StringBuilder();
            string strWhere = "ClassId=" + nav + " and IsLock=0";
            this.pcount = ArticleBll.GetCount(strWhere);
            DataSet ds = ArticleBll.GetPageList(this.pagesize, this.page, strWhere, "Click asc,AddTime desc");
            DataRow row = null;
            //List<TravelAgent.Model.LineContent> lstLineContent = null;
            //TravelAgent.Model.LineContent content = null;
            int selectCount=ds.Tables[0].Rows.Count;
            for (int i = 0; i < selectCount; i++)
            {
                row = ds.Tables[0].Rows[i];
                string strimg = row["ImgUrl"].ToString();
                if (string.IsNullOrEmpty(strimg))
                {
                    strimg = "/images/no_image.gif";
                }
                sbList.Append("<dl class=\"news_box1\">");
                //sbList.Append("<dt class=\"news_pic1\"><a href=\"/New.aspx?nav=" + nav + "&id=" + row["Id"] + "\"  target=\"_blank\"><img src=\"" + strimg + "\" alt=\"" + row["Title"] + "\" /></a></dt>");
                //urlrewrite
                sbList.Append("<dt class=\"news_pic1\"><a href=\"/new/" + nav + "/" + row["Id"] + ".html\"  target=\"_blank\"><img src=\"" + strimg + "\" alt=\"" + row["Title"] + "\" /></a></dt>");
                sbList.Append("<dd class=\"news_con1\">");
                //sbList.Append("<h4><a href=\"/New.aspx?nav=" + nav + "&id=" + row["Id"] + "\"  target=\"_blank\">" + row["Title"] + "</a></h4>");
                sbList.Append("<h4><a href=\"/new/" + nav + "/" + row["Id"] + ".html\"  target=\"_blank\">"+row["Title"]+"</a></h4>");
                sbList.Append("<span><i class=\"a1\">"+Convert.ToDateTime(row["AddTime"]).ToString("yyyy-MM-dd")+"</i></span>");
                sbList.Append("<p>" + TravelAgent.Tool.StringPlus.DropHTML(row["Content"].ToString(), 160) + "...</p>");
                sbList.Append("</dd>");
                sbList.Append("</dl>");
            }
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
                    sbList.Append("<a href='/newlist/" + nav + "/0.html'>首页</a>");
                    sbList.Append("<a href='/newlist/" + nav + "/" + (page - 1) + ".html'>上一页</a>");
                }


                if (totalPagecount <= 10)
                {
                    for (int i = 0; i < totalPagecount; i++)
                    {
                        if (i == this.page)
                        {
                            sbList.Append("&nbsp;<span class='current'>" + (i + 1) + "</span>");
                        }
                        else
                        {
                            sbList.Append("&nbsp;<a href='/newlist/" + nav + "/" + i + ".html'>" + (i + 1) + "</a>");
                        }

                    }
                }
                else
                {
                    int tempStartpage = 0;
                    int tempEndpage = totalPagecount - 1;
                    if (totalPagecount > 10)
                    {
                        tempEndpage = 9;
                    }

                    if (this.page > 5)
                    {
                        tempStartpage = this.page - 5;

                        if (this.page + 4 > totalPagecount - 1)
                        {
                            tempEndpage = totalPagecount - 1;
                        }
                        else
                        {
                            tempEndpage = this.page + 4;
                        }
                    }
                    for (int k = tempStartpage; k <= tempEndpage; k++)
                    {
                        if (k == this.page)
                        {
                            sbList.Append("&nbsp;<span class='current'>" + (k + 1) + "</span>");
                        }
                        else
                        {
                            sbList.Append("&nbsp;<a href='/newlist/" + nav + "/" + k + ".html'>" + (k + 1) + "</a>");
                        }
                    }
                }
                if (this.page < totalPagecount - 1)
                {
                    sbList.Append("<a href='/newlist/" + nav + "/" + (page + 1) + ".html'>下一页</a>");
                    sbList.Append("<a href='/newlist/" + nav + "/" + (totalPagecount - 1) + ".html'>尾页</a>");
                }

                sbList.Append("</div>");
            }
            return sbList.ToString();
        }
        /// <summary>
        /// 绑定推荐线路
        /// </summary>
        /// <returns></returns>
        public string BindTJLine(int top)
        {
            StringBuilder sbLine = new StringBuilder();
            //Access
            //DataSet dsLine = LineBll.GetList(top, "InStr(State,'," + Convert.ToInt32(TravelAgent.Tool.EnumSummary.State.推荐) + ",')>0 and isLock=0", "Sort asc,adddate desc");
            //SQL
            DataSet dsLine = LineBll.GetList(top, "CHARINDEX('," + Convert.ToInt32(TravelAgent.Tool.EnumSummary.State.推荐) + ",',State)>0 and isLock=0", "Sort asc,adddate desc");
            DataRow row = null;
            for (int i = 0; i < dsLine.Tables[0].Rows.Count; i++)
            {
                row = dsLine.Tables[0].Rows[i];
                if (i == 0)
                {
                    sbLine.Append("<dl onmouseover=\"show_king_list(this, "+(i+1)+");\" id=\"a"+(i+1)+"\">");  
                }
                else
                {
                    sbLine.Append("<dl class=\"bg\" onmouseover=\"show_king_list(this, " + (i + 1) + ");\" id=\"a" + (i + 1) + "\">");  
                }
                sbLine.Append("<dt class=\"sl01\">0" + (i + 1) + "</dt>");
                //sbLine.Append("<dt class=\"sl02\"><a target=\"_blank\" href=\"/Line.aspx?id=" + row["Id"] + "\"><img alt=\"" + row["lineName"] + "\" src=\"" + row["linePic"] + "\"></a></dt>");
                //sbLine.Append("<dd class=\"sl03\"><a target=\"_blank\" href=\"/Line.aspx?id=" + row["Id"] + "\">" + TravelAgent.Tool.StringPlus.LeftTrueLen(row["lineName"].ToString(), 28, "...") + "</a></dd>");
                //urlrewrite
                sbLine.Append("<dt class=\"sl02\"><a target=\"_blank\" href=\"/line/" + row["Id"] + ".html\"><img alt=\"" + row["lineName"] + "\" src=\"" + row["linePic"] + "\"></a></dt>");
                sbLine.Append("<dd class=\"sl03\"><a target=\"_blank\" href=\"/line/" + row["Id"] + ".html\">" + TravelAgent.Tool.StringPlus.LeftTrueLen(row["lineName"].ToString(), 28, "...") + "</a></dd>");
                if (row["priceCommon"].ToString().Equals(""))
                {
                    sbLine.Append("<dd class=\"sl04\">电询</dd>");
                }
                else
                {
                    sbLine.Append("<dd class=\"sl04\"><i>¥</i><span>" + row["priceCommon"] + "</span>起</dd>");
                }
                sbLine.Append("</dl>");
            }
                
            return sbLine.ToString();
        }
        /// <summary>
        /// 绑定人气线路
        /// </summary>
        /// <returns></returns>
        public string BindGZLine(int top)
        {
            StringBuilder sbLine = new StringBuilder();
            DataSet dsLine = LineBll.GetList(top, "isLock=0", "gzd desc");
            DataRow row = null;
            for (int i = 0; i < dsLine.Tables[0].Rows.Count; i++)
            {
                row = dsLine.Tables[0].Rows[i];
                sbLine.Append("<dl>");
                sbLine.Append("<dt class=\"sl01\">0" + (i + 1) + "</dt>");
                //sbLine.Append("<dt class=\"sl02\"><a target=\"_blank\" href=\"/Line.aspx?id=" + row["Id"] + "\"><img alt=\"" + row["lineName"] + "\" src=\"" + row["linePic"] + "\"></a></dt>");
                //sbLine.Append("<dd class=\"sl03\"><a target=\"_blank\" href=\"/Line.aspx?id=" + row["Id"] + "\">" + TravelAgent.Tool.StringPlus.LeftTrueLen(row["lineName"].ToString(), 28, "...") + "</a></dd>");
                //urlrewrite
                sbLine.Append("<dt class=\"sl02\"><a target=\"_blank\" href=\"/line/" + row["Id"] + ".html\"><img alt=\"" + row["lineName"] + "\" src=\"" + row["linePic"] + "\"></a></dt>");
                sbLine.Append("<dd class=\"sl03\"><a target=\"_blank\" href=\"/line/" + row["Id"] + ".html\">" + TravelAgent.Tool.StringPlus.LeftTrueLen(row["lineName"].ToString(), 28, "...") + "</a></dd>");
                if (row["priceCommon"].ToString().Equals(""))
                {
                    sbLine.Append("<dd class=\"sl04\">电询</dd>");
                }
                else
                {
                    sbLine.Append("<dd class=\"sl04\"><i>¥</i><span>" + row["priceCommon"] + "</span>起</dd>");
                }
                sbLine.Append("</dl>");
            }

            return sbLine.ToString();
        }
    }
}
