using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TravelAgent.Tool;
namespace TravelAgent.Web
{
    public partial class LineModel : System.Web.UI.Page
    {
        public int nav = 0;
        public int od = 0;//第一级
        public int td = 0;//第二级
        public int thd = 0;//第三级

        public int cityId = 0;//城市
        public int proId = 0;//线路类型-参团性质
        public int day = 0;//行程天数
        public int isTuijian = 0;//推荐
        public int isTejia = 0;//特价
        public int isRemai = 0;//热卖
        public string price_up = "0";//搜索价格上限
        public string price_down = "0";//搜索价格下限
        public int renqi = 0;
        public int price = 0;

        public int pcount;                                   //总条数
        public int page = 0;                                     //当前页
        public readonly int pagesize = 20;                    //设置每页显示的大小

        public string strPlace = "";
        public DataSet dsthd = null;
        private static readonly TravelAgent.BLL.Line LineBll = new TravelAgent.BLL.Line();
        private static readonly TravelAgent.BLL.DepartureCity CityBll = new TravelAgent.BLL.DepartureCity();
        private static readonly TravelAgent.BLL.JoinProperty ProBll = new TravelAgent.BLL.JoinProperty();
        private static readonly TravelAgent.BLL.Destination DestBll = new TravelAgent.BLL.Destination();
        private static readonly TravelAgent.BLL.LineTheme ThemeBll = new TravelAgent.BLL.LineTheme();
        protected void Page_Load(object sender, EventArgs e)
        {
            string strTitle = "";
            string strTempName = "";
            int.TryParse(Request["nav"], out nav);
            if (Request["od"] != null && int.TryParse(Request["od"], out od))
            {
                if (od > 0)
                {
                    Model.Destination model = DestBll.GetModel(od);
                    if(model != null)
                    {
                        strTempName = model.navName;
                        //strPlace += "<a href=\"?nav=" + nav + "&od=" + od + "\">" +strTempName+ "</a>&gt;";
                        //urlrewrite
                        strPlace += "<a href=\"/linemodel/" + nav + "/" + od + ".html\">" + strTempName + "</a>&gt;";
                        strTitle = strTempName;
                    }
                }
            }
            if (Request["td"] != null && int.TryParse(Request["td"], out td))
            {
                if (td > 0)
                {
                    Model.Destination model = DestBll.GetModel(td);
                    if(model != null)
                    {
                        strTempName = model.navName;
                        //strPlace += "<a href=\"?nav=" + nav + "&od=" + od + "&td=" + td + "\">" + strTempName + "旅游</a>&gt;";
                        //urlrewrite
                        strPlace += "<a href=\"/linesub/" + nav + "/" + od + "/" + td + ".html\">" + strTempName + "旅游</a>&gt;";
                        if (!strTitle.Equals(""))
                        {
                            strTitle = strTempName + "旅游-" + strTitle;
                        }
                    }
                }
            }
            if (Request["thd"] != null && int.TryParse(Request["thd"], out thd))
            {
                if (thd > 0)
                {
                    Model.Destination model = DestBll.GetModel(thd);
                    if(model != null)
                    {
                        strTempName = model.navName;
                        strPlace += "<em>" + strTempName + "</em>";
                        if (!strTitle.Equals(""))
                        {
                            strTitle = strTempName + "旅游-" + strTitle;
                        }
                    }
                }
            }
            int.TryParse(Request["c"], out cityId);
            int.TryParse(Request["p"], out proId);
            int.TryParse(Request["d"], out day);
            int.TryParse(Request["Tu"], out isTuijian);
            int.TryParse(Request["Te"], out isTejia);
            int.TryParse(Request["Re"], out isRemai);
            int.TryParse(Request["rq"], out renqi);
            int.TryParse(Request["pr"], out price);
            int.TryParse(Request["page"], out page);
            if (Request["pu"] != null)
            {
                price_up = Request["pu"];
            }
            if (Request["pd"] != null)
            {
                price_down = Request["pd"];
            }
            this.Title = strTitle + "-" + Master.webinfo.WebName;
        }
        /// <summary>
        /// 绑定目的地
        /// </summary>
        /// <returns></returns>
        public string BindLeftDest()
        {
            StringBuilder sbDest = new StringBuilder();
            DataTable dtDest = DestBll.GetList(od, 0);
            DataRow[] FristRows = dtDest.Select("navLayer=2", "navSort asc");
            DataRow row=null;
            for (int i = 0; i < FristRows.Length; i++)
            {
                row = FristRows[i];
                sbDest.Append("<li>");
                if (td == 0)
                {
                    if (i == 0)
                    {
                        //sbDest.Append("<em class=\"open\"><a href=\"?nav=" + nav + "&od=" + od + "&td=" + row["Id"] + "\">" + row["navName"] + "</a></em>");
                        //urlrewrite
                        sbDest.Append("<em class=\"open\"><a href=\"/linesub/" + nav + "/" + od + "/" + row["Id"] + ".html\">" + row["navName"] + "</a></em>");
                        sbDest.Append("<dl class=\"rocon\" style=\"display: block;\">");
                    }
                    else
                    {
                        //sbDest.Append("<em><a href=\"?nav=" + nav + "&od=" + od + "&td=" + row["Id"] + "\">" + row["navName"] + "</a></em>");
                        //urlrewrite
                        sbDest.Append("<em><a href=\"/linesub/" + nav + "/" + od + "/" + row["Id"] + ".html\">" + row["navName"] + "</a></em>");
                        sbDest.Append("<dl class=\"rocon\">");
                    }
                }
                else
                {
                    if (td == Convert.ToInt32(row["Id"]))
                    {
                        //sbDest.Append("<em class=\"open\"><a href=\"?nav=" + nav + "&od=" + od + "&td=" + row["Id"] + "\">" + row["navName"] + "</a></em>");
                        //urlrewrite
                        sbDest.Append("<em class=\"open\"><a href=\"/linesub/" + nav + "/" + od + "/" + row["Id"] + ".html\">" + row["navName"] + "</a></em>");
                        sbDest.Append("<dl class=\"rocon\" style=\"display: block;\">");
                    }
                    else
                    {
                        //sbDest.Append("<em><a href=\"?nav=" + nav + "&od=" + od + "&td=" + row["Id"] + "\">" + row["navName"] + "</a></em>");
                        //urlrewrite
                        sbDest.Append("<em><a href=\"/linesub/" + nav + "/" + od + "/" + row["Id"] + ".html\">" + row["navName"] + "</a></em>");
                        sbDest.Append("<dl class=\"rocon\">");
                    }
                }
                DataRow[] destRows = dtDest.Select("isLock=0 and navParentId="+row["Id"], "navSort asc");
                foreach (DataRow r in destRows)
                {
                    if (r["State"].ToString().Contains("," + Convert.ToInt32(EnumSummary.State.推荐) + ","))
                    {
                        //sbDest.Append("<dt><a target=\"_blank\" href=\"?nav=" + nav + "&od=" + od + "&td=" + row["Id"] + "&thd=" + r["Id"] + "\">" + r["navName"] + "</a></dt>");
                        //urlrewrite
                        sbDest.Append("<dt><a target=\"_blank\" href=\"/line/" + nav + "/" + od + "/" + row["Id"] + "/" + r["Id"] + ".html\">" + r["navName"] + "</a></dt>");
                    }
                    else
                    {
                        //sbDest.Append("<dd><a target=\"_blank\" href=\"?nav=" + nav + "&od=" + od + "&td=" + row["Id"] + "&thd=" + r["Id"] + "\">" + r["navName"] + "</a></dd>");
                        //urlrewrite
                        sbDest.Append("<dd><a target=\"_blank\" href=\"/line/" + nav + "/" + od + "/" + row["Id"] + "/" + r["Id"] + ".html\">" + r["navName"] + "</a></dd>");
                    }
                }
                sbDest.Append("</dl>");
                sbDest.Append("</li>");
            }
            return sbDest.ToString();
        }
        /// <summary>
        /// 绑定推荐线路
        /// </summary>
        /// <returns></returns>
        public string BindTuijian()
        {
            StringBuilder sbLine = new StringBuilder();
            //Access
            //DataSet dsLine = LineBll.GetList(3, "InStr(State,'," + Convert.ToInt32(EnumSummary.State.推荐) + ",')>0 and isLock=0 and destId="+od, "Sort asc,adddate desc");
            //SQL
            DataSet dsLine = LineBll.GetList(3, "CHARINDEX('," + Convert.ToInt32(EnumSummary.State.推荐) + ",',State)>0 and isLock=0 and destId=" + od, "Sort asc,adddate desc");
            DataRow row = null;
            for (int i = 0; i < dsLine.Tables[0].Rows.Count; i++)
            {
                row = dsLine.Tables[0].Rows[i];
                if (i == 0)
                {
                    sbLine.Append("<dl class=\"tj_box\">");
                }
                else
                {
                    sbLine.Append("<dl class=\"tj_box tjmgl\">");
                }
                sbLine.Append("<dt class=\"tj_pic\">");
                //sbLine.Append("<a target=\"_blank\" href=\"/Line.aspx?id=" + row["Id"] + "\"><img alt=\"" + row["lineName"] + "\" src=\"" + row["linePic"] + "\"></a>");
                //sbLine.Append("<a class=\"tj_tit\" target=\"_blank\" href=\"/Line.aspx?id=" + row["Id"] + "\">" + row["lineName"] + "</a>");
                //urlrewrite
                sbLine.Append("<a target=\"_blank\" href=\"/line/" + row["Id"] + ".html\"><img alt=\"" + row["lineName"] + "\" src=\"" + row["linePic"] + "\"></a>");
                sbLine.Append("<a class=\"tj_tit\" target=\"_blank\" href=\"/line/" + row["Id"] + ".html\">"+row["lineName"]+"</a>");
                sbLine.Append("<span class=\"tj_sale\"><img alt=\"推荐产品\" src=\"/images/sale.png\"></span>");
                sbLine.Append("</dt>");
                //sbLine.Append("<dd class=\"tj_txt txtbj" + (i + 1) + "\"><a href=\"/Line.aspx?id=" + row["Id"] + "\" target=\"_blank\">"+Master.webinfo.WebName+"-推荐旅游线路</a></dd>");
                //urlrewrite
                //sbLine.Append("<dd class=\"tj_txt txtbj" + (i + 1) + "\"><a href=\"/line/" + row["Id"] + ".html\" target=\"_blank\">" + Master.webinfo.WebName + "-推荐旅游线路</a></dd>");
                if (row["priceContent"].ToString().Equals(""))
                {
                    sbLine.Append("<dd class=\"tj_jia\"><font class=\"ho22\">电询</font></dd>");
                }
                else
                {
                    sbLine.Append("<dd class=\"tj_jia\">¥<font class=\"ho22\">" + row["priceContent"].ToString().Split(',')[2]+ "</font></dd>");
                }
                
                sbLine.Append("<dd class=\"tj_sheng\">");
                //sbLine.Append("<span>" + row["dayNumber"] + "日游</span>|<span>" + row["gzd"] + "人关注</span>|<a target=\"_blank\" href=\"/Line.aspx?id=" + row["Id"] + "\">查看详情</a>");
                //urlrewrite
                sbLine.Append("<span>" + row["dayNumber"] + "日游</span>|<span>" + row["gzd"] + "人关注</span>|<a target=\"_blank\" href=\"/line/" + row["Id"] + ".html\">查看详情</a>");
                sbLine.Append("</dd>");
                sbLine.Append("</dl>");
            }
            return sbLine.ToString();
        }
        /// <summary>
        /// 绑定特价
        /// </summary>
        /// <returns></returns>
        public string BindTejia()
        { 
            StringBuilder sbLine = new StringBuilder();
            //Access
            //DataSet dsLine = LineBll.GetList(10, "InStr(State,'," + Convert.ToInt32(EnumSummary.State.特价) + ",')>0 and isLock=0 and destId="+od, "Sort asc,adddate desc");
            //SQL
            DataSet dsLine = LineBll.GetList(10, "CHARINDEX('," + Convert.ToInt32(EnumSummary.State.特价) + ",',State)>0 and isLock=0 and destId=" + od, "Sort asc,adddate desc");
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
                    sbLine.Append("<li>");
                }
                //sbLine.Append("<a target=\"_blank\" href=\"/Line.aspx?id=" + row["Id"] + "\" rel=\"nofollow\"><img alt=\""+row["lineName"]+"\" src=\""+row["linePic"]+"\">"+row["lineName"]+"</a>");
                //urlrewrite
                sbLine.Append("<a target=\"_blank\" href=\"/line/" + row["Id"] + ".html\" rel=\"nofollow\"><img alt=\"" + row["lineName"] + "\" src=\"" + row["linePic"] + "\">" + row["lineName"] + "</a>");
                if (row["priceContent"].ToString().Equals(""))
                {
                    sbLine.Append(" <p><span><font class=\"ho16\">电询</font></span></p>");
                }
                else
                {
                    sbLine.Append(" <p><span>¥<font class=\"ho16\">" + row["priceContent"].ToString().Split(',')[2] + "</font></span></p>");
                }
                sbLine.Append("</li>");
            }
            return sbLine.ToString();
        }
        /// <summary>
        /// 显示出发城市
        /// </summary>
        /// <returns></returns>
        public string ShowCity()
        {
            StringBuilder sbCity = new StringBuilder();
            DataSet dsCity = CityBll.GetList("isLock=0");
            if (cityId == 0)
            {
                //sbCity.Append("<a href=\"?nav=" + nav + "&od=" + od + "&td=" + td + "&thd=" + thd + "&c=0&p=" + proId + "&d=" + day + "&Tu=" + isTuijian + "&Te=" + isTejia + "&Re=" + isRemai + "&pu=" + price_up + "&pd=" + price_down + "&rq=" + renqi + "&pr=" + price + "\" class=\"current\">全部</a>");
                //urlrewrite
                sbCity.Append("<a href=\"/line/" + nav + "/" + od + "/" + td + "/" + thd + "/0/" + proId + "/" + day + "/" + isTuijian + "/" + isTejia + "/" + isRemai + "/" + price_up + "/" + price_down + "/" + renqi + "/" + price + ".html\" class=\"current\">全部</a>");
            }
            else
            {
                //sbCity.Append("<a href=\"?nav=" + nav + "&od=" + od + "&td=" + td + "&thd=" + thd + "&c=0&p=" + proId + "&d=" + day + "&Tu=" + isTuijian + "&Te=" + isTejia + "&Re=" + isRemai + "&pu=" + price_up + "&pd=" + price_down + "&rq=" + renqi + "&pr=" + price + "\">全部</a>");
                //urlrewrite
                sbCity.Append("<a href=\"/line/" + nav + "/" + od + "/" + td + "/" + thd + "/0/" + proId + "/" + day + "/" + isTuijian + "/" + isTejia + "/" + isRemai + "/" + price_up + "/" + price_down + "/" + renqi + "/" + price + ".html\">全部</a>");
            }
            foreach (DataRow row in dsCity.Tables[0].Rows)
            {
                if (Convert.ToInt32(row["id"]) == cityId)
                {
                    //sbCity.Append("<a href=\"?nav=" + nav + "&od=" + od + "&td=" + td + "&thd=" + thd + "&c=" + row["id"] + "&p=" + proId + "&d=" + day + "&Tu=" + isTuijian + "&Te=" + isTejia + "&Re=" + isRemai + "&pu=" + price_up + "&pd=" + price_down + "&rq=" + renqi + "&pr=" + price + "\" class=\"current\">" + row["CityName"] + "</a>");
                    //urlrewrite
                    sbCity.Append("<a href=\"/line/" + nav + "/" + od + "/" + td + "/" + thd + "/" + row["id"] + "/" + proId + "/" + day + "/" + isTuijian + "/" + isTejia + "/" + isRemai + "/" + price_up + "/" + price_down + "/" + renqi + "/" + price + ".html\" class=\"current\">" + row["CityName"] + "</a>");
                }
                else
                {
                    //sbCity.Append("<a href=\"?nav=" + nav + "&od=" + od + "&td=" + td + "&thd=" + thd + "&c=" + row["id"] + "&p=" + proId + "&d=" + day + "&Tu=" + isTuijian + "&Te=" + isTejia + "&Re=" + isRemai + "&pu=" + price_up + "&pd=" + price_down + "&rq=" + renqi + "&pr=" + price + "\">" + row["CityName"] + "</a>");
                    //urlrewrite
                    sbCity.Append("<a href=\"/line/" + nav + "/" + od + "/" + td + "/" + thd + "/" + row["id"] + "/" + proId + "/" + day + "/" + isTuijian + "/" + isTejia + "/" + isRemai + "/" + price_up + "/" + price_down + "/" + renqi + "/" + price + ".html\">" + row["CityName"] + "</a>");
                }
            }
            return sbCity.ToString();
        }
        /// <summary>
        /// 显示参团性质
        /// </summary>
        /// <returns></returns>
        public string ShowJoinPro()
        {
            StringBuilder sbPro = new StringBuilder();
            DataSet dsPro = ProBll.GetList("isLock=0");
            if (proId == 0)
            {
                sbPro.Append("<a href=\"/line/" + nav + "/" + od + "/" + td + "/" + thd + "/" + cityId + "/0/" + day + "/" + isTuijian + "/" + isTejia + "/" + isRemai + "/" + price_up + "/" + price_down + "/" + renqi + "/" + price + ".html\" class=\"current\">全部</a>");
            }
            else
            {
                sbPro.Append("<a href=\"/line/" + nav + "/" + od + "/" + td + "/" + thd + "/" + cityId + "/0/" + day + "/" + isTuijian + "/" + isTejia + "/" + isRemai + "/" + price_up + "/" + price_down + "/" + renqi + "/" + price + ".html\">全部</a>");
            }
            foreach (DataRow row in dsPro.Tables[0].Rows)
            {
                if (Convert.ToInt32(row["Id"]) == proId)
                {
                    sbPro.Append("<a href=\"/line/" + nav + "/" + od + "/" + td + "/" + thd + "/" + cityId + "/" + row["Id"] + "/" + day + "/" + isTuijian + "/" + isTejia + "/" + isRemai + "/" + price_up + "/" + price_down + "/" + renqi + "/" + price + ".html\" class=\"current\">" + row["joinName"] + "</a>");
                }
                else
                {
                    sbPro.Append("<a href=\"/line/" + nav + "/" + od + "/" + td + "/" + thd + "/" + cityId + "/" + row["Id"] + "/" + day + "/" + isTuijian + "/" + isTejia + "/" + isRemai + "/" + price_up + "/" + price_down + "/" + renqi + "/" + price + ".html\">" + row["joinName"] + "</a>");
                }
            }
            return sbPro.ToString();
        }
        /// <summary>
        /// 绑定天数
        /// </summary>
        /// <returns></returns>
        public string ShowDay(int tday)
        {
            StringBuilder sbDay = new StringBuilder();
            if (day == 0)
            {
                sbDay.Append("<a href=\"/line/" + nav + "/" + od + "/" + td + "/" + thd + "/" + cityId + "/" + proId + "/0/" + isTuijian + "/" + isTejia + "/" + isRemai + "/" + price_up + "/" + price_down + "/" + renqi + "/" + price + ".html\" class=\"current\">全部</a>");
            }
            else
            {
                sbDay.Append("<a href=\"/line/" + nav + "/" + od + "/" + td + "/" + thd + "/" + cityId + "/" + proId + "/0/" + isTuijian + "/" + isTejia + "/" + isRemai + "/" + price_up + "/" + price_down + "/" + renqi + "/" + price + ".html\">全部</a>");
            }
            for (int i = 1; i <= tday; i++)
            {
                if (i == day)
                {
                    sbDay.Append("<a href=\"/line/" + nav + "/" + od + "/" + td + "/" + thd + "/" + cityId + "/" + proId + "/" + i + "/" + isTuijian + "/" + isTejia + "/" + isRemai + "/" + price_up + "/" + price_down + "/" + renqi + "/" + price + ".html\" class=\"current\">" + i + "天</a>");
                }
                else
                {
                    sbDay.Append("<a href=\"/line/" + nav + "/" + od + "/" + td + "/" + thd + "/" + cityId + "/" + proId + "/" + i + "/" + isTuijian + "/" + isTejia + "/" + isRemai + "/" + price_up + "/" + price_down + "/" + renqi + "/" + price + ".html\">" + i + "天</a>");
                }
            }
            return sbDay.ToString();
        }
        /// <summary>
        /// 绑定排序搜索条件
        /// </summary>
        /// <returns></returns>
        public string ShowOther()
        {
            StringBuilder sbOther = new StringBuilder();
            if (renqi == 0 && price == 0)
            {
                sbOther.Append("<li class=\"curr\"><a href=\"/line/" + nav + "/" + od + "/" + td + "/" + thd + "/" + cityId + "/" + proId + "/0/" + isTuijian + "/=" + isTejia + "/" + isRemai + "/" + price_up + "/" + price_down + "/0/0.html\">全部</a></li>");
                sbOther.Append("<li><a rel=\"nofollow\" href=\"/line/" + nav + "/" + od + "/" + td + "/" + thd + "/" + cityId + "/" + proId + "/0/" + isTuijian + "/" + isTejia + "/" + isRemai + "/" + price_up + "/" + price_down + "/1/0.html\"><span>人气</span><i class=\"s1\"></i></a></li>");
                sbOther.Append("<li><a rel=\"nofollow\" href=\"/line/" + nav + "/" + od + "/" + td + "/" + thd + "/" + cityId + "/" + proId + "/0/" + isTuijian + "/" + isTejia + "/" + isRemai + "/" + price_up + "/" + price_down + "/0/1.html\"><span>价格</span><i class=\"s1\"></i></a></li>");
            }
            else
            {
                sbOther.Append("<li><a href=\"/line/" + nav + "/" + od + "/" + td + "/" + thd + "/" + cityId + "/" + proId + "/0/" + isTuijian + "/" + isTejia + "/" + isRemai + "/" + price_up + "/" + price_down + "/0/0.html\">全部</a></li>");
                if (renqi == 0 & price > 0)
                {
                    sbOther.Append("<li><a rel=\"nofollow\" href=\"/line/" + nav + "/" + od + "/" + td + "/" + thd + "/" + cityId + "/" + proId + "/" + day + "/" + isTuijian + "/" + isTejia + "/" + isRemai + "/" + price_up + "/" + price_down + "/1/0.html\"><span>人气</span><i class=\"s1\"></i></a></li>");
                    sbOther.Append("<li class=\"curr\"><a rel=\"nofollow\" href=\"/line/" + nav + "/" + od + "/" + td + "/" + thd + "/" + cityId + "/" + proId + "/" + day + "/" + isTuijian + "/" + isTejia + "/" + isRemai + "/" + price_up + "/" + price_down + "/0/1.html\"><span>价格</span><i class=\"s0\"></i></a></li>");
                }
                else
                {
                    sbOther.Append("<li class=\"curr\"><a rel=\"nofollow\" href=\"/line/" + nav + "/" + od + "/" + td + "/" + thd + "/" + cityId + "/" + proId + "/" + day + "/" + isTuijian + "/" + isTejia + "/" + isRemai + "/" + price_up + "/" + price_down + "/1/0.html\"><span>人气</span><i class=\"s0\"></i></a></li>");
                    sbOther.Append("<li><a rel=\"nofollow\" href=\"/line/" + nav + "/" + od + "/" + td + "/" + thd + "/" + cityId + "/" + proId + "/" + day + "/" + isTuijian + "/" + isTejia + "/" + isRemai + "/" + price_up + "/" + price_down + "/0/1.html\"><span>价格</span><i class=\"s1\"></i></a></li>");
                }
            }

            return sbOther.ToString();
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
            string strWhere=getWhere();
            this.pcount = LineBll.GetCount(strWhere);
            DataSet ds = LineBll.GetPageList(this.pagesize, this.page, strWhere, getOrder());
            DataRow row = null;
            //List<TravelAgent.Model.LineContent> lstLineContent = null;
            //TravelAgent.Model.LineContent content = null;
            int selectCount=ds.Tables[0].Rows.Count;
            for (int i = 0; i < selectCount; i++)
            {
                row = ds.Tables[0].Rows[i];
                sbList.Append("<li class=\"linelist\">");
                sbList.Append("<div class=\"linetop\">");
                //sbList.Append("<div class=\"linepic\"><a target=\"_blank\" href=\"/Line.aspx?id=" + row["Id"] + "\"><img alt=\"" + row["lineName"] + "\" src=\"" + row["linePic"] + "\"></a></div>");
                //urlrewrite
                sbList.Append("<div class=\"linepic\"><a target=\"_blank\" href=\"/line/"+row["Id"]+".html\"><img alt=\""+row["lineName"]+"\" src=\""+row["linePic"]+"\"></a></div>");
                sbList.Append("<div class=\"linecon\">");
                sbList.Append("<p class=\"tit\">");
                //sbList.Append("<a target=\"_blank\" href=\"/Line.aspx?id=" + row["Id"] + "\">" + row["lineName"] + "</a>");
                //urlrewrite
                sbList.Append("<a target=\"_blank\" href=\"/line/" + row["Id"] + ".html\">"+row["lineName"]+"</a>");
                sbList.Append("</p>");
                sbList.Append("<p class=\"sight\">线路特色："+row["lineSubName"]+"</p>");
                string strLineTheme="";
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
                if (row["priceCommon"].Equals("") || row["priceCommon"].Equals("0"))
                {
                    sbList.Append("<p class=\"jia\">电询</p>");
                }
                else
                {
                    sbList.Append("<p class=\"jia\"><font class=\"h014\">¥</font><font class=\"ho18\">" + row["priceCommon"] + "</font> 起</p>");
                }
                
                sbList.Append("<p class=\"gzu\">"+row["gzd"]+"人关注</p>");
                //sbList.Append("<a class=\"xq\" target=\"_blank\" href=\"/Line.aspx?id=" + row["Id"] + "\"></a>");
                //urlrewrite
                sbList.Append("<a class=\"xq\" target=\"_blank\" href=\"/line/"+row["Id"]+".html\"></a>");
                sbList.Append("</div>");
                sbList.Append("</div>");
                sbList.Append("<div class=\"linebot\">");
                sbList.Append("<div class=\"botbox\"><p class=\"s1\">线路编号</p><p>L-"+row["Id"].ToString().PadLeft(6,'0')+"</p></div>");
                sbList.Append("<div class=\"botbox\"><p class=\"s1\">线路类型</p><p>" + getJoinPropery(Convert.ToInt32(row["proIds"])) + "</p></div>");
                sbList.Append("<div class=\"botbox\"><p class=\"s1\">行程天数</p><p>" + row["dayNumber"] + "天</p></div>");
                //sbList.Append("<div class=\"botbox\"><p class=\"s1\">发团日期</p><p class=\"tuanqi\"><a href=\"javascript:;\" data-url=\"/Line.aspx?id=" + row["Id"] + "\" data-id=\"" + row["Id"] + "\" class=\"zk\" rel=\"nofollow\">查看</a></p></div>");
                //urlrewrite
                sbList.Append("<div class=\"botbox\"><p class=\"s1\">发团日期</p><p class=\"tuanqi\"><a href=\"javascript:;\" data-url=\"/line/"+row["Id"]+".html\" data-id=\""+row["Id"]+"\" class=\"zk\" rel=\"nofollow\">查看</a></p></div>");
                sbList.Append("<div style=\"border:0\" class=\"botbox\"><p class=\"s1\">往返交通</p><p>" + row["trafficIds"].ToString().Trim(',') + "</p></div>");
                sbList.Append("</div>");
                sbList.Append("<dd class=\"case_calendar\" id=\"case_calendar_"+row["Id"]+"\">");
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
                    //urlrewrite
                    sbList.Append("<a href='/line/" + nav + "/" + od + "/" + td + "/" + thd + "/" + cityId + "/" + proId + "/" + day + "/" + isTuijian + "/" + isTejia + "/" + isRemai + "/" + price_up + "/" + price_down + "/" + renqi + "/" + price + "/" + (page - 1) + ".html'>上一页</a>");
                }
                for (int i = 0; i < totalPagecount; i++)
                {
                    if (i == this.page)
                    {
                        sbList.Append("&nbsp;<span class='current'>" + (i + 1) + "</span>");
                    }
                    else
                    {
                        sbList.Append("&nbsp;<a href='/line/" + nav + "/" + od + "/" + td + "/" + thd + "/" + cityId + "/" + proId + "/" + day + "/" + isTuijian + "/" + isTejia + "/" + isRemai + "/" + price_up + "/" + price_down + "/" + renqi + "/" + price + "/" + i + ".html'>" + (i + 1) + "</a>");
                    }

                }
                if (this.page < totalPagecount - 1)
                {
                    sbList.Append("<a href='/line/" + nav + "/" + od + "/" + td + "/" + thd + "/" + cityId + "/" + proId + "/" + day + "/" + isTuijian + "/" + isTejia + "/" + isRemai + "/" + price_up + "/" + price_down + "/" + renqi + "/" + price + "/" + (page + 1) + ".html'>下一页</a>");
                }

                sbList.Append("</div>");
            }
            return sbList.ToString();
        }
        /// <summary>
        /// 组合SQL语句
        /// </summary>
        /// <param name="_classId"></param>
        /// <param name="_keywords"></param>
        /// <returns></returns>
        protected string getWhere()
        {
            StringBuilder strTemp = new StringBuilder();
            strTemp.Append("isLock=0");
            if (this.od > 0)
            {
                strTemp.Append(" and destId=" + this.od);
            }
            if (this.td > 0)
            {
                if (thd == 0)
                {
                    dsthd = DestBll.GetDestListByParentId(td, null);
                    foreach (DataRow row in dsthd.Tables[0].Rows)
                    {
                        strTemp.Append(" and dest like '%" + row["Id"] + "%'");
                    }
                }
            }
            if (this.thd > 0)
            {
                strTemp.Append(" and dest like '%"+this.thd+"%'");
            }
            if (this.cityId > 0)
            {
                strTemp.Append(" and cityId=" + this.cityId + "");
            }
            if (this.proId > 0)
            {
                strTemp.Append(" and proIds ='" + this.proId + "'");
            }
            if (this.day > 0)
            {
                strTemp.Append(" and dayNumber = " + this.day + "");
            }
            if (this.isTuijian > 0)
            {
                strTemp.Append(" and State like '%," + Convert.ToInt32(EnumSummary.State.推荐) + ",%'");
            }
            if (this.isTejia > 0)
            {
                strTemp.Append(" and State like '%," + Convert.ToInt32(EnumSummary.State.特价) + ",%'");
            }
            if (this.isRemai > 0)
            {
                strTemp.Append(" and State like '%," + Convert.ToInt32(EnumSummary.State.热卖) + ",%'");
            }
           
            if (!string.IsNullOrEmpty(this.price_up))
            {
                if(!this.price_up.Equals("0"))
                {
                    int tempPrice_up;
                    int.TryParse(this.price_up, out tempPrice_up);
                    strTemp.Append(" and priceCommon<=" + tempPrice_up.ToString());
                }
            }
            if (!string.IsNullOrEmpty(this.price_down))
            {
                if(!this.price_down.Equals("0"))
                {
                    int tempPrice_down;
                    int.TryParse(this.price_down, out tempPrice_down);
                    strTemp.Append(" and priceCommon>=" + tempPrice_down);
                }
            }
            return strTemp.ToString();
        }
        /// <summary>
        /// 获得排序
        /// </summary>
        /// <returns></returns>
        protected string getOrder()
        {
            StringBuilder strTemp = new StringBuilder();
            if (this.renqi > 0)
            {
                strTemp.Append("gzd desc,");
            }
            if (this.price > 0)
            {
                strTemp.Append("priceCommon desc,");
            }
            strTemp.Append("Sort asc,adddate desc");
            return strTemp.ToString();
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
    }
}
