using System;
using System.Data;
using System.Text;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using TravelAgent.Tool;
namespace TravelAgent.Web
{
    public partial class Master : System.Web.UI.MasterPage
    {
        public TravelAgent.Model.WebInfo webinfo;
        private TravelAgent.BLL.WebNav NavBll = new TravelAgent.BLL.WebNav();
        private static readonly TravelAgent.BLL.Destination DestBll = new TravelAgent.BLL.Destination();
        private static readonly TravelAgent.BLL.LineTheme ThemeBll = new TravelAgent.BLL.LineTheme();
        private static readonly TravelAgent.BLL.VisaCountry CountryBll = new TravelAgent.BLL.VisaCountry();
        private static readonly TravelAgent.BLL.Category CateBll = new TravelAgent.BLL.Category();
        private static readonly TravelAgent.BLL.Adbanner BannerBll = new TravelAgent.BLL.Adbanner();
        private static readonly TravelAgent.BLL.Links LinkBll = new TravelAgent.BLL.Links();
        protected void Page_Init(object sender, EventArgs e)
        {
            if (webinfo == null)
            {
                webinfo = new TravelAgent.BLL.WebInfo().loadConfig(Server.MapPath(ConfigurationManager.AppSettings["WebInfoConfig"].ToString()));
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        /// <summary>
        /// 绑定搜索关键字
        /// </summary>
        /// <returns></returns>
        public string BindSearchKey()
        {
            StringBuilder sb = new StringBuilder();
            if (!webinfo.SearchKey.Equals(""))
            {
                string[] arryKey = webinfo.SearchKey.Split(',');
                foreach (string key in arryKey)
                {
                    sb.Append("<a href=\"/Search.aspx?k="+Server.UrlEncode(key)+"\" target=\"_blank\">" + key + "</a> ");
                }
            }

            return sb.ToString();
        }
        /// <summary>
        /// 绑定导航
        /// </summary>
        /// <returns></returns>
        public string BindNav()
        {
            StringBuilder strNav = new StringBuilder();
            DataSet dsNav = NavBll.GetNavListByParentId(0, null);
            foreach (DataRow row in dsNav.Tables[0].Rows)
            {
                if (row["State"].ToString().Contains("," + Convert.ToInt32(EnumSummary.State.热卖) + ","))
                {
                    strNav.Append("<li id=\"nav_li" + row["Id"] + "\"><a class=\"hot\" href=\"" + row["navURL"] + "\">" + row["navName"] + "<i></i></a></li>");
                }
                else
                {
                    strNav.Append("<li id=\"nav_li" + row["Id"] + "\"><a href=\"" + row["navURL"] + "\">" + row["navName"] + "</a></li>");
                }
                
            }
            return strNav.ToString();
        }
        /// <summary>
        /// 绑定目的地
        /// </summary>
        /// <returns></returns>
        public string BindDest()
        {
            string strValue = "";
            if (CacheHelper.Exists("dest"))
            {
                strValue = CacheHelper.Get<string>("dest");
            }
            else
            {
                StringBuilder strDest = new StringBuilder();
                DataTable dtDest = DestBll.GetList(0, 0);
                DataRow[] FristRows = dtDest.Select("navLayer=1 and isLock=0", "navSort asc");
                int fristLength = FristRows.Length > 3 ? 3 : FristRows.Length;
                for (int i = 1; i <= fristLength; i++)
                {
                    strDest.Append("<dt>");
                    strDest.Append("<div class=\"cpTit\">");
                    strDest.Append("<h3 class=\"cpTit_H\">");
                    //strDest.Append("<a href=\"/LineModel.aspx?od=" + FristRows[i - 1]["Id"] + "\" target=\"_blank\" class=\"ico" + i + "\">" + FristRows[i - 1]["navName"] + "</a><i class=\"arrow\"></i>");
                    //urlrewrite
                    strDest.Append("<a href=\"/linemodel/" + FristRows[i - 1]["Id"] + ".html\" target=\"_blank\" class=\"ico" + i + "\">" + FristRows[i - 1]["navName"] + "</a><i class=\"arrow\"></i>");
                    strDest.Append("</h3>");
                    strDest.Append("<p class=\"cpTit_P\">");
                    DataRow[] FristRows_Three = dtDest.Select("navLayer=3  and isLock=0 and navList like '" + FristRows[i - 1]["navList"] + "%' and State like '%," + Convert.ToInt32(EnumSummary.State.推荐) + ",%'", "navSort asc");
                    int FristRows_Length = FristRows_Three.Length > 3 ? 3 : FristRows_Three.Length;
                    for (int k = 0; k <= FristRows_Length - 1; k++)
                    {
                        //strDest.Append("<a href=\"/LineModel.aspx?od=" + FristRows[i - 1]["Id"] + "&td=" + FristRows_Three[k]["navParentId"] + "&thd=" + FristRows_Three[k]["Id"] + "\" target=\"_blank\">" + FristRows_Three[k]["navName"] + "</a>");
                        //urlrewrite
                        strDest.Append("<a href=\"/linemodel/" + FristRows[i - 1]["Id"] + "/" + FristRows_Three[k]["navParentId"] + "/" + FristRows_Three[k]["Id"] + ".html\" target=\"_blank\">" + FristRows_Three[k]["navName"] + "</a>");
                    }
                    strDest.Append("</p>");
                    strDest.Append("</div>");
                    strDest.Append("<div class=\"mddBox A" + i + "\">");

                    DataRow[] TwoRows = dtDest.Select("navLayer=2  and isLock=0 and navList like '" + FristRows[i - 1]["navList"] + "%'", "navSort asc");
                    int TwoRows_Length = TwoRows.Length;
                    double dblMiddle = TwoRows_Length > 5 ? (Convert.ToDouble(TwoRows_Length) / 2) : Convert.ToDouble(TwoRows_Length);
                    int middle = Convert.ToInt32(Math.Ceiling(dblMiddle));
                    strDest.Append("<ul class=\"subItem-box1\">");
                    for (int h = 0; h <= middle - 1; h++)
                    {
                        strDest.Append("<li class=\"subItem-box2\">");
                        //strDest.Append("<h4 class=\"subItem-hd\"><a href=\"/LineModel.aspx?od=" + FristRows[i - 1]["Id"] + "&td=" + TwoRows[h]["Id"] + "\" target=\"_blank\">" + TwoRows[h]["navName"] + "</a></h4>");
                        //urlrewrite
                        strDest.Append("<h4 class=\"subItem-hd\"><a href=\"/linemodel/" + FristRows[i - 1]["Id"] + "/" + TwoRows[h]["Id"] + ".html\" target=\"_blank\">" + TwoRows[h]["navName"] + "</a></h4>");
                        strDest.Append("<div class=\"subItem-cat\">");
                        DataRow[] ThreeRows = dtDest.Select("navLayer=3  and isLock=0 and navList like '" + TwoRows[h]["navList"] + "%'", "navSort asc");
                        foreach (DataRow trow in ThreeRows)
                        {
                            if (trow["State"].ToString().Contains("," + Convert.ToInt32(EnumSummary.State.热卖) + ","))
                            {
                                strDest.Append("<a href=\"/linemodel/" + FristRows[i - 1]["Id"] + "/" + TwoRows[h]["navParentId"] + "/" + trow["Id"] + ".html\" target=\"_blank\" class=\"hot\">" + trow["navName"] + "</a>");
                                //urlrewrite
                                //strDest.Append("<a href=\"/LineModel.aspx?od=" + FristRows[i - 1]["Id"] + "&td=" + TwoRows[h]["navParentId"] + "&thd=" + trow["Id"] + "\" target=\"_blank\" class=\"hot\">" + trow["navName"] + "</a>");
                            }
                            else
                            {
                                //strDest.Append("<a href=\"/LineModel.aspx?od=" + FristRows[i - 1]["Id"] + "&td=" + TwoRows[h]["navParentId"] + "&thd=" + trow["Id"] + "\" target=\"_blank\">" + trow["navName"] + "</a>");
                                //urlrewrite
                                strDest.Append("<a href=\"/linemodel/" + FristRows[i - 1]["Id"] + "/" + TwoRows[h]["navParentId"] + "/" + trow["Id"] + ".html\" target=\"_blank\">" + trow["navName"] + "</a>");
                            }
                        }
                        strDest.Append("</div>");
                        strDest.Append("</li>");
                    }
                    strDest.Append("</ul>");
                    strDest.Append("<ul class=\"subItem-box1\">");
                    for (int j = middle; j < TwoRows_Length; j++)
                    {
                        strDest.Append("<li class=\"subItem-box2\">");
                        //strDest.Append("<h4 class=\"subItem-hd\"><a href=\"/LineModel.aspx?od=" + FristRows[i - 1]["Id"] + "&td=" + TwoRows[j]["Id"] + "\" target=\"_blank\">" + TwoRows[j]["navName"] + "</a></h4>");
                        //urlrewrite
                        strDest.Append("<h4 class=\"subItem-hd\"><a href=\"/linem/" + FristRows[i - 1]["Id"] + "/" + TwoRows[j]["Id"] + ".html\" target=\"_blank\">" + TwoRows[j]["navName"] + "</a></h4>");
                        strDest.Append("<div class=\"subItem-cat\">");
                        DataRow[] ThreeRows = dtDest.Select("navLayer=3  and isLock=0 and navList like '" + TwoRows[j]["navList"] + "%'", "navSort asc");
                        foreach (DataRow trow in ThreeRows)
                        {
                            if (trow["State"].ToString().Contains("," + Convert.ToInt32(TravelAgent.Tool.EnumSummary.State.热卖) + ","))
                            {
                                //strDest.Append("<a href=\"/LineModel.aspx?od=" + FristRows[i - 1]["Id"] + "&td=" + TwoRows[j]["navParentId"] + "&thd=" + trow["Id"] + "\" target=\"_blank\" class=\"hot\">" + trow["navName"] + "</a>");
                                //urlrewrite
                                strDest.Append("<a href=\"/linemodel/" + FristRows[i - 1]["Id"] + "/" + TwoRows[j]["navParentId"] + "/" + trow["Id"] + ".html\" target=\"_blank\" class=\"hot\">" + trow["navName"] + "</a>");
                            }
                            else
                            {
                                //strDest.Append("<a href=\"/LineModel.aspx?od=" + FristRows[i - 1]["Id"] + "&td=" + TwoRows[j]["navParentId"] + "&thd=" + trow["Id"] + "\" target=\"_blank\">" + trow["navName"] + "</a>");
                                //urlrewrite
                                strDest.Append("<a href=\"/linemodel/" + FristRows[i - 1]["Id"] + "/" + TwoRows[j]["navParentId"] + "/" + trow["Id"] + ".html\" target=\"_blank\">" + trow["navName"] + "</a>");
                            }
                        }
                        strDest.Append("</div>");
                        strDest.Append("</li>");
                    }
                    strDest.Append("</ul>");

                    strDest.Append("</div>");
                    strDest.Append("</dt>");
                }

                strValue = strDest.ToString();
                CacheHelper.Add<string>("dest", strValue);
            }

            return strValue;
        }
        /// <summary>
        /// 绑定帮助中心
        /// </summary>
        /// <returns></returns>
        public string BindHelp(int co)
        {
            DataTable dtHelp = CateBll.GetList(4, null);
            StringBuilder sbHelp = new StringBuilder();
            DataRow[] drFrist = dtHelp.Select("ParentId=4 and State=0", "ClassOrder asc");
            int count = drFrist.Length;
            if (count >= co)
            {
                count = co;
            }
         
            for (int i = 1; i <=count;i++ )
            {
                //sbHelp.Append("<li>");
                //sbHelp.Append("<i class=\"helpico"+i+"\"></i>");
                //sbHelp.Append("<dl class=\"helpCon\">");
                //sbHelp.Append("<dt class=\"helpTit\">"+drFrist[i-1]["Title"]+"</dt>");
                //DataRow[] drTwo = dtHelp.Select("ClassList like '" + drFrist[i - 1]["ClassList"] + "%' and State=0 and ClassLayer=3", "ClassOrder asc");
                //foreach (DataRow row in drTwo)
                //{
                //    sbHelp.Append("<dd class=\"helpTxt\"><a rel=\"nofollow\" href=\"/Help.aspx?navid=" + drFrist[i - 1]["Id"] + "#help_"+row["Id"]+"\">" + row["Title"] + "</a></dd>");
                //}
                //sbHelp.Append("</dl>");
                //sbHelp.Append("</li>");

                //sbHelp.Append("<ul>");
                //sbHelp.Append("<b><a rel=\"nofollow\" href=\"#\">" + drFrist[i - 1]["Title"] + "</a></b>");
                //DataRow[] drTwo = dtHelp.Select("ClassList like '" + drFrist[i - 1]["ClassList"] + "%' and State=0 and ClassLayer=3", "ClassOrder asc");
                //foreach (DataRow row in drTwo)
                //{
                //    sbHelp.Append("<li><a href=\"/Help.aspx?navid=" + drFrist[i - 1]["Id"] + "#help_" + row["Id"] + "\">" + row["Title"] + "</a></li>");
                //}
                //sbHelp.Append("</ul>");
                sbHelp.Append("<dl>");
                sbHelp.Append("<dt><a rel=\"nofollow\" href=\"#\">" + drFrist[i - 1]["Title"] + "</a></dt>");
                sbHelp.Append("<dd>");
                sbHelp.Append("<ul>");
                DataRow[] drTwo = dtHelp.Select("ClassList like '" + drFrist[i - 1]["ClassList"] + "%' and State=0 and ClassLayer=3", "ClassOrder asc");
                foreach (DataRow row in drTwo)
                {
                    sbHelp.Append("<li><a title=\"" + row["Title"] + "\" target=\"_blank\" href=\"/Help.aspx?navid=" + drFrist[i - 1]["Id"] + "#help_" + row["Id"] + "\">" + row["Title"] + "</a></li>");
                }
                sbHelp.Append("</ul>");
                sbHelp.Append("</dd>");
                sbHelp.Append("</dl>");
            }
            return sbHelp.ToString();
        }
        /// <summary>
        /// 绑定关于
        /// </summary>
        /// <returns></returns>
        public string BindAbout()
        {
            DataSet dsCate = CateBll.GetChannelListByParentId(3,null);
            StringBuilder sbAbout = new StringBuilder();
            DataRow row=null;
            string strurl = "";
            for (int i = 0; i < dsCate.Tables[0].Rows.Count; i++)
            {
                row=dsCate.Tables[0].Rows[i];
                strurl = row["PageUrl"].ToString();
                if (strurl.Equals(""))
                {
                    strurl = "/article/" + row["Id"]+".html";
                }
                if (i < dsCate.Tables[0].Rows.Count - 1)
                {
                    sbAbout.Append("<a rel=\"nofollow\" href=\"" + strurl + "\">" + row["Title"] + "</a>|");
                }
                else
                {
                    sbAbout.Append("<a rel=\"nofollow\" href=\"" + strurl + "\">" + row["Title"] + "</a>");
                }
                
            }
            return sbAbout.ToString();
        }
        /// <summary>
        /// 绑定荣誉
        /// </summary>
        /// <returns></returns>
        public string BindRongyu()
        {
            DataSet dsRongyu = BannerBll.GetList("Aid=23 and StartTime<'" + DateTime.Now + "' and EndTime>'" + DateTime.Now + "'");
            StringBuilder sbRongyu = new StringBuilder();
            foreach (DataRow row in dsRongyu.Tables[0].Rows)
            {
                //sbRongyu.Append("<img src=\"" + row["AdUrl"] + "\" alt=\""+row["Title"]+"\" />");
                sbRongyu.Append("<a href=\"" + row["LinkUrl"] + "\" target=\"_blank\"><img src=\"" + row["AdUrl"] + "\" alt=\"" + row["Title"] + "\"></a>");
            }
            return sbRongyu.ToString();
        }
        /// <summary>
        /// 绑定友情链接
        /// </summary>
        /// <returns></returns>
        public string BindLinks()
        {
            DataSet dsLink = LinkBll.GetList(0, "IsLock=0", "SortId asc,AddTime desc");
            StringBuilder sbLink = new StringBuilder();
            foreach (DataRow row in dsLink.Tables[0].Rows)
            {
                sbLink.Append("<a href=\"" + row["WebUrl"] + "\" target=\"_blank\">" + row["Title"] + "</a>");
            }
            return sbLink.ToString();
        }
        /// <summary>
        /// 添加页面属性
        /// </summary>
        /// <param name="page"></param>
        /// <param name="metaName"></param>
        /// <param name="metaContent"></param>
        public static void AddMeta(Page page, string metaName, string metaContent)
        {
            HtmlMeta meta = new HtmlMeta();
            meta.Name = metaName;
            meta.Content = metaContent;
            page.Header.Controls.Add(meta);
        }
    }
}
