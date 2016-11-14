using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TravelAgent.Tool;
using TravelAgent.IDAL;
using NLog;
namespace TravelAgent.Web
{
    public partial class Default : System.Web.UI.Page
    {
        public TravelAgent.Model.LineHoliday holiday;
        public string holidaybg = "";
        private static readonly TravelAgent.BLL.Destination DestBll = new TravelAgent.BLL.Destination();
        private static readonly TravelAgent.BLL.LineTheme ThemeBll = new TravelAgent.BLL.LineTheme();
        private static readonly TravelAgent.BLL.VisaCountry CountryBll = new TravelAgent.BLL.VisaCountry();
        private static readonly TravelAgent.BLL.Article ArticleBll = new TravelAgent.BLL.Article();
        private static readonly TravelAgent.BLL.Line LineBll = new TravelAgent.BLL.Line();
        private static readonly TravelAgent.BLL.LineSpePrice SpePriceBll = new TravelAgent.BLL.LineSpePrice();
        private static readonly TravelAgent.BLL.VisaList VisaBll = new TravelAgent.BLL.VisaList();
        private static readonly TravelAgent.BLL.VisaBrand BrandBll = new TravelAgent.BLL.VisaBrand();
        private static readonly TravelAgent.BLL.LineHoliday HolidayBll = new TravelAgent.BLL.LineHoliday();

        protected void Page_Load(object sender, EventArgs e)
        {
            this.Title = Master.webinfo.WebName+"-"+Master.webinfo.SEOTitle;
            Master.AddMeta(Page.Master.Page, "keywords", Master.webinfo.SEOKeywords);
            Master.AddMeta(Page.Master.Page, "description", Master.webinfo.SEODescription);
            if (!this.IsPostBack)
            { 
                holiday=HolidayBll.GetModel(Master.webinfo.Holiday);
                holidaybg = holiday != null ? holiday.holidaybgurl : "";
            }
        }
        /// <summary>
        /// 绑定特价线路
        /// </summary>
        /// <param name="top"></param>
        /// <returns></returns>
        public string BindTejiaLine(int top)
        { 
            StringBuilder sbLine = new StringBuilder();
            DataSet dsLine = LineBll.GetList(top, "CHARINDEX('," + Convert.ToInt32(TravelAgent.Tool.EnumSummary.State.特价) + ",',State)>0 and isLock=0", "Sort asc,adddate desc");
            DataRow row = null;
            for (int i = 0; i < top; i++)
            {
                row = dsLine.Tables[0].Rows[i];
                sbLine.Append("<div class=\"tip\"><span class=\"time\">限时特价</span></div>");
                sbLine.Append("<div style=\" z-index:1px; position:absolute;\">");
                sbLine.Append("<a href=\"/line/" + row["Id"] + ".html\" target=\"_blank\"><img src=\"" + row["linePic"] + "\" alt=\"" + row["lineName"] + "\" /></a>");
                sbLine.Append("</div>");
                sbLine.Append("<div class=\"tejiatitle\">");
                sbLine.Append("<a href=\"/line/" + row["Id"] + ".html\" target=\"_blank\">" + TravelAgent.Tool.StringPlus.CutString(row["lineName"].ToString(),26) + "</a>");
                sbLine.Append("</div>");
            }
            return sbLine.ToString();
        }
        /// <summary>
        /// 绑定目的地
        /// </summary>
        /// <returns></returns>
        public string BindDest()
        {
            StringBuilder strDest = new StringBuilder(Master.BindDest());
            strDest.Append("<dt>");
            strDest.Append("<div class=\"cpTit\">");
            strDest.Append("<h3 class=\"cpTit_H\">");
            strDest.Append("<a href=\"/theme.html\" target=\"_blank\" class=\"ico4\">主题旅游</a><i class=\"arrow\"></i>");
            strDest.Append("</h3>");
            strDest.Append("<p class=\"cpTit_P\">");
            DataSet dsTheme = ThemeBll.GetList("isLock=0");
            int dsTheme_Length = dsTheme.Tables[0].Rows.Count > 3 ? 3 : dsTheme.Tables[0].Rows.Count;
            for (int i = 0; i < dsTheme_Length;i++)
            {
                //strDest.Append("<a href=\"/ThemeModel.aspx?id=" + dsTheme.Tables[0].Rows[i]["Id"] + "\" target=\"_blank\">" + dsTheme.Tables[0].Rows[i]["themeName"] + "</a>");
                //urlrewrite
                strDest.Append("<a href=\"/theme/" + dsTheme.Tables[0].Rows[i]["Id"] + ".html\" target=\"_blank\">" + dsTheme.Tables[0].Rows[i]["themeName"] + "</a>");
            }
            strDest.Append("</p>");
            strDest.Append("</div>");
            strDest.Append("<div class=\"mddBox A4\">");
            strDest.Append("<ul class=\"subItem-box1\">");
            foreach (DataRow row in dsTheme.Tables[0].Rows)
            { 
                strDest.Append("<li class=\"subItem-box2\">");
                strDest.Append("<h4 class=\"subItem-hd\"><a href=\"/theme/" + row["Id"] + ".html\" target=\"_blank\">" + row["themeName"] + "</a></h4>");
                strDest.Append("</li>");
            }
            strDest.Append("</ul>");
            strDest.Append("</div>");
            strDest.Append("</dt>");

            strDest.Append("<dt style=\"background:none\">");
            strDest.Append("<div class=\"cpTit\">");
            strDest.Append("<h3 class=\"cpTit_H\">");

            //strDest.Append("<a href=\"/visa/Default.aspx?nav=15\" target=\"_blank\" class=\"ico1\">全球签证</a><i class=\"arrow\"></i>");
            //urlrewrite
            strDest.Append("<a href=\"/visa/15_.html\" target=\"_blank\" class=\"ico1\">全球签证</a><i class=\"arrow\"></i>");
            strDest.Append("</h3>");
            strDest.Append("<p class=\"cpTit_P\">");
            DataTable dtVisa = CountryBll.GetList(0,"isLock=0");
            DataRow[] drThree = dtVisa.Select("ClassLayer=2 and isLock=0", "Sort asc");
            int drThree_Length = drThree.Length > 3 ? 3 : drThree.Length;
            for (int i = 0; i < drThree_Length; i++)
            {
                //strDest.Append("<a href=\"/visa/VisaMore.aspx?countryid=" + drThree[i]["Id"] + "\" target=\"_blank\">" + drThree[i]["Name"] + "</a>");
                //urlrewrite
                strDest.Append("<a href=\"/visa_" + drThree[i]["Id"] + ".html\" target=\"_blank\">" + drThree[i]["Name"] + "</a>");
            }
            strDest.Append("</p>");
            strDest.Append("</div>");
            strDest.Append("<div class=\"mddBox A8\">");
            DataRow[] drTwo = dtVisa.Select("ClassLayer=1 and isLock=0", "Sort asc");
            int intVisaTwo_Length = drTwo.Length;
            double dblVisaMiddle = intVisaTwo_Length > 5 ? (Convert.ToDouble(intVisaTwo_Length) / 2) : (Convert.ToDouble(intVisaTwo_Length));
            int VisaMiddle = Convert.ToInt32(Math.Ceiling(dblVisaMiddle));
            strDest.Append("<ul class=\"subItem-box1\">");
            for (int h = 0; h <= VisaMiddle - 1; h++)
            {
                strDest.Append("<li class=\"subItem-box2\">");
                //strDest.Append("<h4 class=\"subItem-hd\"><a href=\"/visa/VisaMore.aspx?countryid=" + drTwo[h]["Id"] + "\" target=\"_blank\">" + drTwo[h]["Name"] + "</a></h4>");
                //urlrewrite
                strDest.Append("<h4 class=\"subItem-hd\"><a href=\"/visa_" + drTwo[h]["Id"] + ".html\" target=\"_blank\">" + drTwo[h]["Name"] + "</a></h4>");
                strDest.Append("<div class=\"subItem-cat\">");
                DataRow[] ThreeRows = dtVisa.Select("ClassLayer=2 and isLock=0 and ClassList like '" + drTwo[h]["ClassList"] + "%'", "Sort asc");
                foreach (DataRow trow in ThreeRows)
                {
                    //strDest.Append("<a href=\"/visa/VisaMore.aspx?countryid=" + trow["Id"] + "\" target=\"_blank\">" + trow["Name"] + "</a>");
                    //urlrewrite
                    strDest.Append("<a href=\"/visa_" + trow["Id"] + ".html\" target=\"_blank\">" + trow["Name"] + "</a>");
                }
                strDest.Append("</div>");
                strDest.Append("</li>");
            }
            strDest.Append("</ul>");
            strDest.Append("<ul class=\"subItem-box1\">");
            for (int j = VisaMiddle; j < intVisaTwo_Length; j++)
            {
                strDest.Append("<li class=\"subItem-box2\">");
                //strDest.Append("<h4 class=\"subItem-hd\"><a href=\"/visa/VisaMore.aspx?countryid=" + drTwo[j]["Id"] + "\" target=\"_blank\">" + drTwo[j]["Name"] + "</a></h4>");
                //urlrewrite
                strDest.Append("<h4 class=\"subItem-hd\"><a href=\"/visa_" + drTwo[j]["Id"] + ".html\" target=\"_blank\">" + drTwo[j]["Name"] + "</a></h4>");
                strDest.Append("<div class=\"subItem-cat\">");
                DataRow[] ThreeRows = dtVisa.Select("ClassLayer=2 and isLock=0 and ClassList like '" + drTwo[j]["ClassList"] + "%'", "Sort asc");
                foreach (DataRow trow in ThreeRows)
                {
                    //strDest.Append("<a href=\"/visa/VisaMore.aspx?countryid=" + trow["Id"] + "\" target=\"_blank\">" + trow["Name"] + "</a>");
                    //urlrewrite
                    strDest.Append("<a href=\"/visa_" + trow["Id"] + ".html\" target=\"_blank\">" + trow["Name"] + "</a>");
                }
                strDest.Append("</div>");
                strDest.Append("</li>");
            }
            strDest.Append("</ul>");
            strDest.Append("</div>");
            strDest.Append("</dt>");
            return strDest.ToString();
        }
        /// <summary>
        /// 绑定新闻
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public string BindNews(int type,int top)
        {
            StringBuilder sbNews = new StringBuilder();
            DataSet dsNews = ArticleBll.GetList(top, "ClassId="+type, "Click asc,AddTime desc");
            foreach (DataRow row in dsNews.Tables[0].Rows)
            {
                if(type==1)
                {
                    //sbNews.Append("<li><a href=\"/NewsList.aspx?nav=1\" target=\"_blank\" class=\"the1\">[公告]</a><a href=\"/New.aspx?nav=1&id=" + row["Id"] + "\" target=\"_blank\" title=\"" + row["Title"] + "\" class=\"the2\">" + StringPlus.LeftTrueLen(row["Title"].ToString(), 22, "") + "</a></li>");
                    //urlrewrite
                    sbNews.Append("<li><a href=\"/newlist/1.html\" target=\"_blank\" class=\"the1\">[公告]</a><a href=\"/new/1/" + row["Id"] + ".html\" target=\"_blank\" title=\"" + row["Title"] + "\" class=\"the2\">" + StringPlus.LeftTrueLen(row["Title"].ToString(), 22, "") + "</a></li>");
                }
                else if(type==2)
                {
                    //sbNews.Append("<li><a href=\"/NewsList.aspx?nav=2\" target=\"_blank\" class=\"the1\">[资讯]</a><a href=\"/New.aspx?nav=2&id=" + row["Id"] + "\" target=\"_blank\" title=\"" + row["Title"] + "\" class=\"the2\">" + StringPlus.LeftTrueLen(row["Title"].ToString(), 22, "") + "</a></li>");
                    //urlrewrite
                    sbNews.Append("<li><a href=\"/newlist/2.html\" target=\"_blank\" class=\"the1\">[资讯]</a><a href=\"/new/2/" + row["Id"] + ".html\" target=\"_blank\" title=\"" + row["Title"] + "\" class=\"the2\">" + StringPlus.LeftTrueLen(row["Title"].ToString(), 22, "") + "</a></li>");
                }
                else if (type == 49)
                {
                    //sbNews.Append("<li><a href=\"/New.aspx?nav=49&id=" + row["Id"] + "\" target=\"_blank\">" + row["Title"] + "</a></li>");
                    //urlrewrite
                    sbNews.Append("<li><a href=\"/new/49/" + row["Id"] + ".html\" target=\"_blank\">" + row["Title"] + "</a></li>");
                }
            }
            return sbNews.ToString();
        }
        /// <summary>
        /// 绑定线路
        /// </summary>
        /// <param name="state"></param>
        /// <param name="top"></param>
        /// <returns></returns>
        public string BindTJLine(int state,int top)
        {
            StringBuilder sbLine = new StringBuilder();
            //Access
            //DataSet dsLine = LineBll.GetList(top, "InStr(State,',"+ state+ ",')>0 and isLock=0", "Sort asc,adddate desc");

            //SQL
            DataSet dsLine = LineBll.GetList(top, "CHARINDEX('," + state + ",',State)>0 and isLock=0", "Sort asc,adddate desc");
            DataRow row = null;
            for (int i = 0; i < dsLine.Tables[0].Rows.Count; i++)
            {
                row=dsLine.Tables[0].Rows[i];
                if (i == 0)
                {
                    sbLine.Append("<dl class='tj_con '>");
                }
                else
                {
                    sbLine.Append("<dl class='tj_con tjmgl'>");
                }
                sbLine.Append("<dt class=\"tj_pic\">");
                //sbLine.Append("<a rel=\"nofollow\" href=\"/Line.aspx?id=" + row["Id"] + "\" target=\"_blank\"><img src=\"" + row["linePic"] + "\" alt=\"" + row["lineName"] + "\" /></a>");
                //urlrewrite
                sbLine.Append("<a rel=\"nofollow\" href=\"/line/"+row["Id"]+".html\" target=\"_blank\"><img src=\"" + row["linePic"] + "\" alt=\"" + row["lineName"] + "\" /></a>");
                sbLine.Append("<span class=\"tj_tit tjbg" + (i + 1) + "\">" + StringPlus.LeftTrueLen(row["lineName"].ToString(),30,"") + "</span>");
                sbLine.Append("</dt> ");
                sbLine.Append("<dd class=\"tj_jia\">");
                
                int intNormalPrice = String.IsNullOrEmpty(row["priceContent"].ToString()) ? 0 : Convert.ToInt32(row["priceContent"].ToString().Split(',')[2]);
                int intMinPrice = GetLineSpePrice(Convert.ToInt32(row["Id"]), intNormalPrice);
                if (intMinPrice == 0)
                {
                    sbLine.Append("<span>电询</span>");
                }
                else
                {
                    sbLine.Append("<span>¥ " + intMinPrice + "<font class=\"preqi\">起</font></span>");
                }
                sbLine.Append("</dd>");
                sbLine.Append("</dl>");
            }
            return sbLine.ToString();
        }
        /// <summary>
        /// 获取线路中成人特殊日期价格的最低价格
        /// </summary>
        /// <param name="lineId"></param>
        /// <returns></returns>
        public int GetLineSpePrice(int lineId,int intNormalPrice)
        {
            int intMinPrice = 0;
            List<TravelAgent.Model.LineSpePrice> lstLineSpePrice = SpePriceBll.GetlstSpePriceByLineId(lineId).Where(t=>t.tag==1&&t.linePrice!="").ToList();
            if (intNormalPrice == 0)
            {
                if (lstLineSpePrice.Count > 0)
                { 
                    intMinPrice = Convert.ToInt32(lstLineSpePrice[0].linePrice.Split(',')[2]);
                }
            }
            else
            {
                intMinPrice = intNormalPrice;
            }
            
            foreach (TravelAgent.Model.LineSpePrice p in lstLineSpePrice)
            {
                if (intMinPrice > Convert.ToInt32(p.linePrice.Split(',')[2]))
                {
                    intMinPrice = Convert.ToInt32(p.linePrice.Split(',')[2]);
                }
            }

            return intMinPrice;
        }
        /// <summary>
        /// 绑定线路
        /// </summary>
        /// <param name="state"></param>
        /// <param name="top"></param>
        /// <param name="destId"></param>
        /// <returns></returns>
        public string BindLine(int top, int destId)
        {
            StringBuilder sbLine = new StringBuilder();
            string strWhere = "isLock=0 and destId=" + destId;
            //if (state != null)
            //{
                //Access
                //strWhere = "InStr(State,'," + state + ",')>0 and "+strWhere;

                //SQL
                //strWhere = "CHARINDEX('," + state + ",',State)>0 and "+strWhere;
            //}
          
            DataSet dsLine = LineBll.GetList(top, strWhere, "Sort asc,adddate desc");
            DataRow row = null;
            for (int i = 0; i < dsLine.Tables[0].Rows.Count; i++)
            {
                 row = dsLine.Tables[0].Rows[i];
                 sbLine.Append("<dl class=\"xl_box\">");
                 //sbLine.Append("<dt class=\"xl_pic\"><a rel=\"nofollow\" href=\"/Line.aspx?id=" + row["Id"] + "\" target=\"_blank\"><img src=\"" + row["linePic"] + "\" alt=\"" + row["lineName"] + "\" /></a></dt>");
                 //sbLine.Append("<dd class=\"xl_tit\"><a rel=\"nofollow\" href=\"/Line.aspx?id=" + row["Id"] + "\" target=\"_blank\"><i>" + row["dayNumber"] + "日游</i>" + row["lineName"] + "</a></dd>");
                 //urlrewrite
                 sbLine.Append("<dt class=\"xl_pic\"><a rel=\"nofollow\" href=\"/line/"+row["Id"]+".html\" target=\"_blank\"><img src=\""+row["linePic"]+"\" alt=\""+row["lineName"]+"\" /></a></dt>");
                sbLine.Append("<dd class=\"xl_tit\"><a rel=\"nofollow\" href=\"/line/"+row["Id"]+".html\" target=\"_blank\"><i>"+row["dayNumber"]+"日游</i>"+row["lineName"]+"</a></dd>");

                int intNormalPrice = String.IsNullOrEmpty(row["priceContent"].ToString()) ? 0 : Convert.ToInt32(row["priceContent"].ToString().Split(',')[2]);
                int intMinPrice = GetLineSpePrice(Convert.ToInt32(row["Id"]), intNormalPrice);
                if (intMinPrice == 0)
                {
                    sbLine.Append("<dd class=\"xl_jia\">电询<font class=\"gzd\">关注度：" + row["gzd"] + "</font></dd>");
                }
                else
                {
                    sbLine.Append("<dd class=\"xl_jia\">¥<font class=\"h18\"></font><font class=\"preqi\">同行价</font>" + intMinPrice + "&nbsp</font><font class=\"preqi\">市场价</font>"+ LineBll.GetModel(Convert.ToInt32(row["Id"])).GetShopPrice() +"</dd>");
                    sbLine.Append("<dd><font class=\"gzd\">关注度:+"+row["gzd"]+"</font></dd>");
                }
               
                sbLine.Append("</dl>");
            }
            return sbLine.ToString();
        }
        /// <summary>
        /// 绑定自由行
        /// </summary>
        /// <param name="?"></param>
        /// <param name="top"></param>
        /// <returns></returns>
        public string BindZYXLine(int? state, int top)
        {
            StringBuilder sbLine = new StringBuilder();
            string strWhere = "isLock=0 and proIds='4'";
            if (state != null)
            {
                //Access
                //strWhere = "InStr(State,'," + state + ",')>0 and " + strWhere;

                //SQL
                strWhere = "CHARINDEX('," + state + ",',State)>0 and " + strWhere;
            }
            DataSet dsLine = LineBll.GetList(top, strWhere, "Sort asc,adddate desc");
            DataRow row = null;
            for (int i = 0; i < dsLine.Tables[0].Rows.Count; i++)
            {
                row = dsLine.Tables[0].Rows[i];
                sbLine.Append("<dl class=\"zyx_box\">");
                //sbLine.Append("<dt class=\"zyx_pic\"><a rel=\"nofollow\" href=\"/Line.aspx?id=" + row["Id"] + "\" target=\"_blank\"><img src=\"" + row["linePic"] + "\" alt=\"" + row["lineName"] + "\" /></a></dt>");
                //sbLine.Append("<dd class=\"zyx_tit\"><a rel=\"nofollow\" href=\"/Line.aspx?id=" + row["Id"] + "\" target=\"_blank\">" + row["lineName"] + "<" + row["lineSubName"] + "></a></dd>");
                //urlrewrite
                sbLine.Append("<dt class=\"zyx_pic\"><a rel=\"nofollow\" href=\"/line/"+row["Id"]+".html\" target=\"_blank\"><img src=\""+row["linePic"]+"\" alt=\""+row["lineName"]+"\" /></a></dt>");
                sbLine.Append("<dd class=\"zyx_tit\"><a rel=\"nofollow\" href=\"/line/"+row["Id"]+".html\" target=\"_blank\">"+row["lineName"]+"<"+row["lineSubName"]+"></a></dd>");
                int intNormalPrice = String.IsNullOrEmpty(row["priceContent"].ToString()) ? 0 : Convert.ToInt32(row["priceContent"].ToString().Split(',')[2]);
                int intMinPrice = GetLineSpePrice(Convert.ToInt32(row["Id"]), intNormalPrice);
                if (intMinPrice == 0)
                {
                    sbLine.Append("<dd class=\"zyx_jia\">电询</dd>");
                }
                else
                {
                    sbLine.Append("<dd class=\"zyx_jia\">¥<font class=\"h18\">" + "</font><font class=\"preqi\">同行价</font></dd>" + intMinPrice);
                    sbLine.Append("<dd class=\"zyx_jia\">¥<font class=\"h18\">" + "</font><font class=\"preqi\">市场价</font></dd>" + LineBll.GetModel(Convert.ToInt32(row["Id"])).GetShopPrice());
                }
                sbLine.Append("</dl>");
            }

            return sbLine.ToString();
        }
        /// <summary>
        /// 绑定签证
        /// </summary>
        /// <param name="state"></param>
        /// <param name="top"></param>
        /// <returns></returns>
        public string BindVisaList(int? state, int top)
        {
            StringBuilder sbVisa = new StringBuilder();
            string strWhere = "isLock=0";
            if (state != null)
            {
                //Access
                //strWhere = "InStr(State,'," + state + ",')>0 and " + strWhere;
                //SQL
                strWhere = "CHARINDEX('," + state + ",',State)>0 and " + strWhere;
            }
            DataSet dsVisa = VisaBll.GetList(top, strWhere, "Sort asc,adddate desc");
            DataRow row = null;
            for (int i = 0; i < dsVisa.Tables[0].Rows.Count; i++)
            {
                row = dsVisa.Tables[0].Rows[i];
                sbVisa.Append("<dl class=\"zyx_visa_box\">");
                //sbVisa.Append("<dt class=\"zyx_visa_pic\"><a href=\"/visa/VisaDetail.aspx?id=" + row["Id"] + "\" target=\"_blank\"><img src=\"" + row["PicUrl"] + "\" alt=" + row["visaName"] + " /></a></dt>");
                //urlrewrite
                sbVisa.Append("<dt class=\"zyx_visa_pic\"><a href=\"/visa/"+row["Id"]+".html\" target=\"_blank\"><img src=\"" + row["PicUrl"] + "\" alt=" + row["visaName"] + " /></a></dt>");
                sbVisa.Append("<dd class=\"zyx_visa_con\">");
                //sbVisa.Append("<a href=\"/visa/VisaDetail.aspx?id=" + row["Id"] + "\" target=\"_blank\">" + StringPlus.LeftTrueLen(row["visaName"].ToString(), 14, "") + "</a>");
                //urlrewrite
                sbVisa.Append("<a href=\"/visa/" + row["Id"] + ".html\" target=\"_blank\">" + StringPlus.LeftTrueLen(row["visaName"].ToString(), 14, "") + "</a>");
                if (Convert.ToInt32(row["price"]) == 0)
                {
                    sbVisa.Append("<p>面议</p>");
                }
                else
                {
                    sbVisa.Append("<p>￥ " + row["price"] + "</p>");
                }
                
                sbVisa.Append("</dd></dl>");
            }

            return sbVisa.ToString();
        }
        /// <summary>
        /// 绑定节日特惠目的地
        /// </summary>
        /// <param name="state"></param>
        /// <param name="top"></param>
        /// <param name="nav"></param>
        /// <returns></returns>
        public string BindHolidayDest(int? state, int top, int nav,int dest)
        {
            StringBuilder sbDest = new StringBuilder();
            string strWhere = "isLock=0 and navList like '," + dest + ",%'";
            if (state != null)
            {
                //Access
                //strWhere = strWhere + " and InStr(State,'," + state + ",')>0";

                //SQL
                strWhere = strWhere + " and CHARINDEX('," + state + ",',State)>0";
            }
            DataSet dsDest = DestBll.GetDestListByLayer(3, strWhere);
            DataRow row = null;
            for (int i = 0; i < dsDest.Tables[0].Rows.Count; i++)
            {
                row = dsDest.Tables[0].Rows[i];
                
                //sbDest.Append("<a href=\"/LineModel.aspx?nav=" + nav + "&od=" + type + "&td=" + row["navParentId"] + "\" target=\"_blank\">" + row["navName"] + "</a>");
                //urlrewrite
                sbDest.Append("<li><a href=\"/linesub/" + nav + "/" + dest + "/" + row["navParentId"] + ".html\" target=\"_blank\">" + row["navName"] + "</a></li>");
            }
            return sbDest.ToString();
        }
        /// <summary>
        /// 绑定节日线路
        /// </summary>
        /// <param name="state"></param>
        /// <param name="top"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public string BindHolidayLine(int top, int type)
        {
            StringBuilder sbLine = new StringBuilder();
            string strWhere = "isLock=0 and destId=" + type;
            if (Master.webinfo.Holiday == 0)
            {
                strWhere = "CHARINDEX('," + Convert.ToInt32(TravelAgent.Tool.EnumSummary.State.推荐) + ",',State)>0 and " + strWhere;
            }
            else
            {
                strWhere = "CHARINDEX('," + Master.webinfo.Holiday + ",',holiday)>0 and " + strWhere;
            }
            DataSet dsLine = LineBll.GetList(top, strWhere, "Sort asc,adddate desc");
            DataRow row = null;
            for (int i = 0; i < dsLine.Tables[0].Rows.Count; i++)
            {
                row = dsLine.Tables[0].Rows[i];
                sbLine.Append("<dl class=\"sqlinebox\">");
                sbLine.Append("<dt class=\"sqpic\"><a target=\"_blank\" href=\"/line/" + row["Id"] + ".html\" rel=\"nofollow\"><img alt=\"" + row["lineName"] + "\" src=\"" + row["linePic"] + "\"></a></dt>");
                sbLine.Append("<dd class=\"sqtxt\">");
                sbLine.Append("<em><a target=\"_blank\" href=\"/line/" + row["Id"] + ".html\" rel=\"nofollow\">"+row["lineName"]+"</a></em>");
                int intNormalPrice = String.IsNullOrEmpty(row["priceContent"].ToString()) ? 0 : Convert.ToInt32(row["priceContent"].ToString().Split(',')[2]);
                int intMinPrice = GetLineSpePrice(Convert.ToInt32(row["Id"]), intNormalPrice);
                int marketPrice = LineBll.GetModel(Convert.ToInt32(row["Id"])).GetShopPrice();
                if (intMinPrice == 0)
                {
                    sbLine.Append("<span>电询</span>");
                }
                else
                {
                    sbLine.Append("<font style=\"font:10px\" class=\"preqi\">同行价</font></span>" + "<span>¥ " + intMinPrice);
                    sbLine.Append("<font class=\"preqi\">市场价</font></span>" + "<span>¥ " + marketPrice); //add a shop price, written by jjh
                }
                sbLine.Append("</dd>");
                sbLine.Append("</dl>");
            }
           
           
            return sbLine.ToString();
        }
        /// <summary>
        /// 绑定目的地
        /// </summary>
        /// <param name="state"></param>
        /// <param name="top"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public string BindDest(int? state, int top, int type,int nav)
        {
            StringBuilder sbDest = new StringBuilder();
            string strWhere = "isLock=0 and navList like ',"+type+",%'";
            if (state != null)
            {
                //Access
                //strWhere = strWhere + " and InStr(State,'," + state + ",')>0";

                //SQL
                strWhere = strWhere + " and CHARINDEX('," + state + ",',State)>0";
            }
            DataSet dsDest = DestBll.GetDestListByLayer(3,strWhere);
            DataRow row = null;
            for (int i = 0; i < dsDest.Tables[0].Rows.Count; i++)
            {
                row = dsDest.Tables[0].Rows[i];
                //sbDest.Append("<a href=\"/LineModel.aspx?nav=" + nav + "&od=" + type + "&td=" + row["navParentId"] + "\" target=\"_blank\">" + row["navName"] + "</a>");
                //urlrewrite
                //sbDest.Append("<a href=\"/linesub/" + nav + "/" + type + "/" + row["navParentId"] + ".html\" target=\"_blank\">" + row["navName"] + "</a>");
                sbDest.Append("<li><a href=\"/linesub/" + nav + "/" + type + "/" + row["navParentId"] + ".html\" target=\"_blank\">" + row["navName"] + "</a></li>");
            }
            return sbDest.ToString();
        }
        /// <summary>
        /// 绑定目的地
        /// </summary>
        /// <param name="state"></param>
        /// <param name="top"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public string BindNavDest(int? state, int top, int type, int nav)
        {
            StringBuilder sbDest = new StringBuilder();
            string strWhere = "isLock=0 and navList like '," + type + ",%'";
            if (state != null)
            {
                //Access
                //strWhere = strWhere + " and InStr(State,'," + state + ",')>0";

                //SQL
                strWhere = strWhere + " and CHARINDEX('," + state + ",',State)>0";
            }
            DataSet dsDest = DestBll.GetDestListByLayer(3, strWhere);
            DataRow row = null;
            sbDest.Append("<li id=\"li_" + type + "_1\" onmouseover=\"setContentTab('li_" + type + "_', 1, " + (1 + dsDest.Tables[0].Rows.Count) + ")\" class=\"current\"><a rel=\"nofollow\" href=\"javascript:void(0)\">精选</a></li>");

            int count = dsDest.Tables[0].Rows.Count;
            if (dsDest.Tables[0].Rows.Count > top)
            {
                count = top;
            }
            for (int i = 0; i < count; i++)
            {
                row = dsDest.Tables[0].Rows[i];
                //sbDest.Append("<a href=\"/LineModel.aspx?nav=" + nav + "&od=" + type + "&td=" + row["Id"] + "\" target=\"_blank\">" + row["navName"] + "</a>");
                //sbDest.Append("<li id=\"li_" + type + "_" + (i + 2) + "\" onmouseover=\"setContentTab('li_" + type + "_', " + (i + 2) + ", " + (1 + dsDest.Tables[0].Rows.Count) + ")\"><a href=\"/LineModel.aspx?nav=" + nav + "&od=" + type + "&td=" + row["navParentId"] + "&thd=" + row["Id"] + "\" target=\"_blank\">" + row["navName"] + "</a></li>");
                //urlrewrite
                sbDest.Append("<li id=\"li_" + type + "_" + (i + 2) + "\" onmouseover=\"setContentTab('li_" + type + "_', " + (i + 2) + ", " + (1 + dsDest.Tables[0].Rows.Count) + ")\"><a href=\"/line/" + nav + "/" + type + "/" + row["navParentId"] + "/" + row["Id"] + ".html\" target=\"_blank\">" + row["navName"] + "</a></li>");
            }
            return sbDest.ToString();
        }
        /// <summary>
        /// 绑定热卖产品
        /// </summary>
        /// <param name="state"></param>
        /// <param name="top"></param>
        /// <returns></returns>
        public string BindHotLine(int? state, int top)
        { 
             StringBuilder sbLine = new StringBuilder();
            string strWhere = "isLock=0";
            if (state != null)
            {
                //Access
                //strWhere = "InStr(State,'," + state + ",')>0 and "+strWhere;
                //SQL
                strWhere = "CHARINDEX('," + state + ",',State)>0 and " + strWhere;
            }
          
            DataSet dsLine = LineBll.GetList(top, strWhere, "Sort asc,adddate desc");
            DataRow row = null;
            for (int i = 0; i < dsLine.Tables[0].Rows.Count; i++)
            {
                row = dsLine.Tables[0].Rows[i];
                //sbLine.Append("<a href=\"/Line.aspx?id="+row["Id"]+"\" target=\"_blank\" >");
                //urlrewrite
                sbLine.Append("<a href=\"/line/" + row["Id"] + ".html\" target=\"_blank\" >");
                string intNormalPrice = String.IsNullOrEmpty(row["priceContent"].ToString()) ? "电询" : "¥" + row["priceContent"].ToString().Split(',')[2];
                sbLine.Append("<span class=\"inbox_zhiding_pre\">&nbsp;<i style=\"font-size:20px;font-family:Verdana,SimSun,Arial;\">" + intNormalPrice + "</i>元/人</span>");
                sbLine.Append("<span class=\"inbox_zhiding_tit\">" + row["lineName"] + "</span>");
                sbLine.Append("<span class=\"inbox_zhiding_con\">" + row["lineSubName"] + "</span>");
                sbLine.Append("<em></em></a>");
            }
            return sbLine.ToString();
        }
        /// <summary>
        /// 绑定基本信息设置
        /// </summary>
        /// <param name="type"></param>
        /// <param name="top"></param>
        /// <returns></returns>
        public string BindBrand(int type, int top)
        {
            StringBuilder sbBrand = new StringBuilder();
            DataSet dsBrand = BrandBll.GetList(top, "isLock=0 and Type="+type, "Sort asc");
            DataRow row = null;
            for (int i = 0; i < dsBrand.Tables[0].Rows.Count; i++)
            {
                row = dsBrand.Tables[0].Rows[i];
                sbBrand.Append("<li><i class=\"icon" + (i + 1) + "\"></i><strong>" + row["Title"] + "</strong><br>" + row["SubTitle"] + "</li>");
            }
            return sbBrand.ToString();
        }
       
    }
}
