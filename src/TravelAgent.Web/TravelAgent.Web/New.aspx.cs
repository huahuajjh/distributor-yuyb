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
    public partial class New : System.Web.UI.Page
    {
        public string CateName="";
        public int nav;
        public int id;
        public string strNav = "";
        public string dest = "";
        private static readonly TravelAgent.BLL.Article ArticleBll = new TravelAgent.BLL.Article();
        private static readonly TravelAgent.BLL.Category CateBll = new TravelAgent.BLL.Category();
        private static readonly TravelAgent.BLL.Line LineBll = new TravelAgent.BLL.Line();
        protected void Page_Load(object sender, EventArgs e)
        {
            int.TryParse(Request.QueryString["nav"], out nav);
            int.TryParse(Request.QueryString["id"], out id);
            if (!this.IsPostBack)
            {
                StringBuilder sbPlace = new StringBuilder();
                if (nav > 0)
                {
                    TravelAgent.Model.Category Cate = CateBll.GetModel(nav);
                    if (Cate != null)
                    {
                        //sbPlace.Append("<a href=\"/NewsList.aspx?nav=" + nav + "\">" + Cate.Title + "</a>&gt;");
                        //urlrewrite
                        CateName=Cate.Title;
                        sbPlace.Append("<a href=\"/newlist/" + nav + ".html\">" + CateName + "</a>&gt;");
                        if (id > 0)
                        {
                            TravelAgent.Model.Article Article = ArticleBll.GetModel(id);
                            if (Article != null)
                            {
                                dest = Article.Dest;
                                sbPlace.Append("<em>" + Article.Title + "</em>");
                                this.ltTitle.Text = Article.Title;
                                this.ltSource.Text = Article.Form;
                                this.ltDate.Text = Article.AddTime.ToString("yyyy-MM-dd");
                                this.divContent.InnerHtml = Article.Content;

                                if (Article.Zhaiyao.Trim().Equals(""))
                                {
                                    this.Title = Article.Title + "-" + Master.webinfo.WebName;
                                }
                                else
                                {
                                    this.Title = Article.Zhaiyao + "-" + Master.webinfo.WebName;
                                }
                                if (!Article.Keyword.Trim().Equals(""))
                                {
                                    Common.AddMeta(Page.Master.Page, "keywords", Article.Keyword);
                                }
                                if (!Article.Daodu.Trim().Equals(""))
                                {
                                    Common.AddMeta(Page.Master.Page, "description", Article.Daodu);
                                }
                            }
                        }
                    }
                }
                
                strNav = sbPlace.ToString();
            }
        }
        /// <summary>
        /// 绑定前一条，下一条
        /// </summary>
        /// <returns></returns>
        public string BindPrevNext()
        {
            StringBuilder sbtext = new StringBuilder();
            DataSet dsPrev = ArticleBll.GetList(1, "ClassId=" + nav + " and IsLock=0 and Id<"+id, "Click asc,AddTime desc");
            sbtext.Append("<li class=\"text_up\">上一篇：");
            if (dsPrev.Tables[0].Rows.Count > 0)
            {
                sbtext.Append("<a href=\"/new/" + nav + "/" + dsPrev.Tables[0].Rows[0]["Id"] + ".html\" >" + dsPrev.Tables[0].Rows[0]["Title"] + "</a>");
            }
            else
            {
                sbtext.Append("没有了");
            }
            sbtext.Append("</li>");
            DataSet dsNext = ArticleBll.GetList(1, "ClassId=" + nav + " and IsLock=0 and Id>" + id, "Click asc,AddTime desc");
            sbtext.Append("<li class=\"text_down\">下一篇：");
            if(dsNext.Tables[0].Rows.Count>0)
            {
                sbtext.Append("<a href=\"/new/" + nav + "/" + dsNext.Tables[0].Rows[0]["Id"] + ".html\" >" + dsNext.Tables[0].Rows[0]["Title"] + "</a>");
            }
            else
            {
                sbtext.Append("没有了");
            }
            sbtext.Append("</li>");
            return sbtext.ToString();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string BindTJLine(int top)
        {
            StringBuilder sbLine = new StringBuilder();
            //Access
            //DataSet dsLine = LineBll.GetList(top, "InStr(State,'," + Convert.ToInt32(TravelAgent.Tool.EnumSummary.State.推荐) + ",')>0 and isLock=0", "Sort asc,adddate desc");
            //SQL
            DataSet dsLine = LineBll.GetList(top, "CHARINDEX('," + Convert.ToInt32(TravelAgent.Tool.EnumSummary.State.推荐) + ",',State)>0 and isLock=0", "Sort asc,adddate desc");
            foreach (DataRow row in dsLine.Tables[0].Rows)
            {
                sbLine.Append("<li>");
                //sbLine.Append(" <a target=\"_blank\" href=\"/Line.aspx?id=" + row["Id"] + "\"><img alt=\"" + row["lineName"] + "\" src=\"" + row["linePic"] + "\"></a>");
                //urlrewrite
                sbLine.Append(" <a target=\"_blank\" href=\"/line/" + row["Id"] + ".html\"><img alt=\"" + row["lineName"] + "\" src=\"" + row["linePic"] + "\"></a>");
                sbLine.Append("<p>");
                //sbLine.Append("<em><a target=\"_blank\" href=\"/Line.aspx?id=" + row["Id"] + "\">" + row["lineName"] + "</a></em>");
                //urlrewrite
                sbLine.Append("<em><a target=\"_blank\" href=\"/line/" + row["Id"] + ".html\">" + row["lineName"] + "</a></em>");
                if (row["priceCommon"].ToString().Equals(""))
                {
                    sbLine.Append("<span>电询</span>");
                }
                else
                {
                    sbLine.Append("<span>¥ " + row["priceCommon"] + "</span>");
                }
                
                sbLine.Append("</p>");
                sbLine.Append("</li>");
            }
            return sbLine.ToString();
        }
        /// <summary>
        /// 绑定新闻
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public string BindNews(int top)
        {
            StringBuilder sbNews = new StringBuilder();
            DataSet dsNews = ArticleBll.GetList(top, "ClassId=" + nav, "Click asc,AddTime desc");
            DataRow row = null;
            for(int i=0;i<dsNews.Tables[0].Rows.Count;i++)
            {
                row = dsNews.Tables[0].Rows[i];
                if (i < dsNews.Tables[0].Rows.Count - 1)
                {
                    //sbNews.Append("<li><a href=\"/New.aspx?nav=" + type + "&id=" + row["Id"] + "\" target=\"_blank\">" + TravelAgent.Tool.StringPlus.LeftTrueLen(row["Title"].ToString(), 34, "") + "</a></li>");
                    //urlrewrite
                    sbNews.Append("<li><a href=\"/new/" + nav + "/" + row["Id"] + ".html\" target=\"_blank\">" + TravelAgent.Tool.StringPlus.LeftTrueLen(row["Title"].ToString(), 34, "") + "</a></li>");
                }
                else
                {
                    //sbNews.Append("<li style=\"border:none;\"><a href=\"/New.aspx?nav=" + type + "&id=" + row["Id"] + "\" target=\"_blank\">" + TravelAgent.Tool.StringPlus.LeftTrueLen(row["Title"].ToString(), 34, "") + "</a></li>");
                    //urlrewrite
                    sbNews.Append("<li style=\"border:none;\"><a href=\"/new/" + nav + "/" + row["Id"] + ".html\" target=\"_blank\">" + TravelAgent.Tool.StringPlus.LeftTrueLen(row["Title"].ToString(), 34, "") + "</a></li>");
                }
            }
            return sbNews.ToString();
        }
        /// <summary>
        /// 绑定推荐产品
        /// </summary>
        /// <returns></returns>
        public string BindTuijiancp(int top)
        {
            StringBuilder sbtuijian = new StringBuilder();
            if (!dest.Equals(""))
            {
                dest = dest.Trim(',');
                string[] arrydest = dest.Split(',');
                string strwhere_dest = "";
                foreach (string s in arrydest)
                {
                    strwhere_dest += "dest like '%," + s + ",%' and";
                }
                strwhere_dest += " isLock=0";
                DataSet dsAboutLine = LineBll.GetList(top, strwhere_dest, "Sort asc,adddate desc");
                if (dsAboutLine.Tables[0].Rows.Count > 0)
                {
                    sbtuijian.Append("<div class=\"jqhd\">");
                    foreach (DataRow row in dsAboutLine.Tables[0].Rows)
                    {
                        sbtuijian.Append("<dl class=\"jqhd_box\">");
                        sbtuijian.Append("<dt class=\"jqhd_pic\"><a href=\"/line/" + row["Id"] + ".html\" target=\"_blank\"><img alt=\"" + row["lineName"] + "\" src=\"" + row["linePic"] + "\"></a></dt>");
                        sbtuijian.Append(" <dd class=\"jqhd_con\"><p><a href=\"/line/" + row["Id"] + ".html\" target=\"_blank\">" + row["lineName"] + "</a></p>");
                        sbtuijian.Append("<span>¥ 1998</span>");
                        sbtuijian.Append("</dd></dl>");
                    }
                    sbtuijian.Append("</div>");
                }
            }
            return sbtuijian.ToString();
        }
        /// <summary>
        /// 绑定相关文章
        /// </summary>
        /// <returns></returns>
        public string BindAboutArticle()
        { 
            StringBuilder sbabout = new StringBuilder();
            if (!dest.Equals(""))
            {
                dest = dest.Trim(',');
                string[] arrydest = dest.Split(',');
                string strwhere_dest = "";
                foreach (string s in arrydest)
                {
                    strwhere_dest += "Dest like '%," + s + ",%' and";
                }
                strwhere_dest += " isLock=0 and ClassId=" + nav + " and Id<>"+id;
                DataSet dsAboutArticle = ArticleBll.GetList(0, strwhere_dest, "Click desc,AddTime desc");
                if (dsAboutArticle.Tables[0].Rows.Count > 0)
                {
                    sbabout.Append("<div class=\"xgbox\"><h3>相关"+CateName+"</h3><ul class=\"xg_txt_list\">");
                    foreach(DataRow row in dsAboutArticle.Tables[0].Rows)
                    {
                        string strimg = row["ImgUrl"].ToString();
                        if (string.IsNullOrEmpty(strimg))
                        {
                            strimg = "/images/no_image.gif";
                        }
                        sbabout.Append("<li>");
                        sbabout.Append("<a href=\"/new/" + nav + "/" + row["Id"] + ".html\" target=\"_blank\"><img src=\"" + strimg + "\" alt=\"" + row["Title"] + "\" /></a>");
                        sbabout.Append("<em><a href=\"/new/" + nav + "/" + row["Id"] + ".html\" target=\"_blank\" >"+row["Title"]+"</a></em>");
                        sbabout.Append("<p>" + TravelAgent.Tool.StringPlus.DropHTML(row["Content"].ToString(), 72) + "...</p>");
                        sbabout.Append("</li>");
                    }
                    sbabout.Append("</ul></div>");
                }
            }
            return sbabout.ToString();
        }
    }
}
