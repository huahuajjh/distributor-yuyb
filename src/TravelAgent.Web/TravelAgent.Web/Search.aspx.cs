using System;
using System.Text;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TravelAgent.Tool;
namespace TravelAgent.Web
{
    public partial class Search : System.Web.UI.Page
    {
        
        public string keyword = "no";//搜索关键字
        public int cityId = 0;//城市
        public int proId = 0;//线路类型-参团性质
        public int day = 0;//行程天数
        public int isTuijian = 0;//推荐
        public int isTejia = 0;//特价
        public int isRemai=0;//热卖
        public string price_up = "0";//搜索价格上限
        public string price_down = "0";//搜索价格下限
        public int renqi = 0;
        public int price = 0;

        public int pcount;                                   //总条数
        public int page=0;                                     //当前页
        public readonly int pagesize = 10;                    //设置每页显示的大小
        private static readonly TravelAgent.BLL.DepartureCity CityBll = new TravelAgent.BLL.DepartureCity();
        private static readonly TravelAgent.BLL.JoinProperty ProBll = new TravelAgent.BLL.JoinProperty();
        private static readonly TravelAgent.BLL.Line LineBll = new TravelAgent.BLL.Line();
        private static readonly TravelAgent.BLL.LineContent LineContentBll = new TravelAgent.BLL.LineContent();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["k"] != null)
            {
                if (!Request["k"].Equals("请输入目的地"))
                {
                    keyword = Server.UrlDecode(Request["k"]); 
                }
            }
            int.TryParse(Request["c"], out cityId);
            int.TryParse(Request["p"], out proId);
            int.TryParse(Request["d"], out day);
            int.TryParse(Request["Tu"], out isTuijian);
            int.TryParse(Request["Te"], out isTejia);
            int.TryParse(Request["Re"], out isRemai);
            if (Request["pu"] != null)
            {
                price_up = Request["pu"];
            }
            if (Request["pd"] != null)
            {
                price_down = Request["pd"];
            }
            int.TryParse(Request["rq"], out renqi);
            int.TryParse(Request["pr"], out price);
            int.TryParse(Request["page"], out page);
            if (keyword != "no")
            {
                this.Title = keyword + "旅游搜索结果-" + Master.webinfo.WebName;
            }
            else
            {
                this.Title = "搜索结果-"+Master.webinfo.WebName;
            }
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
                //sbCity.Append("<a href=\"?k=" + keyword + "&c=0&p=" + proId + "&d=" + day + "&Tu=" + isTuijian + "&Te=" + isTejia + "&Re=" + isRemai + "&pu=" + price_up + "&pd=" + price_down + "&rq=" + renqi + "&pr=" + price + "\" class=\"current\">全部</a>");
                //urlrewrite
                sbCity.Append("<a href=\"/search/" + keyword + "/0/" + proId + "/" + day + "/" + isTuijian + "/" + isTejia + "/" + isRemai + "/" + price_up + "/" + price_down + "/" + renqi + "/" + price + ".html\" class=\"current\">全部</a>");
            }
            else
            {
                sbCity.Append("<a href=\"/search/" + keyword + "/0/" + proId + "/" + day + "/" + isTuijian + "/" + isTejia + "/" + isRemai + "/" + price_up + "/" + price_down + "/" + renqi + "/" + price + ".html\">全部</a>");
            }
            foreach (DataRow row in dsCity.Tables[0].Rows)
            {
                if (Convert.ToInt32(row["id"]) == cityId)
                {
                    sbCity.Append("<a href=\"/search/" + keyword + "/" + row["id"] + "/" + proId + "/" + day + "/" + isTuijian + "/" + isTejia + "/" + isRemai + "/" + price_up + "/" + price_down + "/" + renqi + "/" + price + ".html\" class=\"current\">" + row["CityName"] + "</a>");
                }
                else
                {
                    sbCity.Append("<a href=\"/search/" + keyword + "/" + row["id"] + "/" + proId + "/" + day + "/" + isTuijian + "/" + isTejia + "/" + isRemai + "/" + price_up + "/" + price_down + "/" + renqi + "/" + price + ".html\">" + row["CityName"] + "</a>");
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
                sbPro.Append("<a href=\"/search/" + keyword + "/" + cityId + "/0/" + day + "/" + isTuijian + "/" + isTejia + "/" + isRemai + "/" + price_up + "/" + price_down + "/" + renqi + "/" + price + ".html\" class=\"current\">全部</a>");
            }
            else
            {
                sbPro.Append("<a href=\"/search/" + keyword + "/" + cityId + "/0/" + day + "/" + isTuijian + "/" + isTejia + "/" + isRemai + "/" + price_up + "/" + price_down + "/" + renqi + "/" + price + ".html\">全部</a>");
            }
            foreach (DataRow row in dsPro.Tables[0].Rows)
            {
                if (Convert.ToInt32(row["Id"]) == proId)
                {
                    sbPro.Append("<a href=\"/search/" + keyword + "/" + cityId + "/" + row["Id"] + "/" + day + "/" + isTuijian + "/" + isTejia + "/" + isRemai + "/" + price_up + "/" + price_down + "/" + renqi + "/" + price + ".html\" class=\"current\">" + row["joinName"] + "</a>");
                }
                else
                {
                    sbPro.Append("<a href=\"/search/" + keyword + "/" + cityId + "/" + row["Id"] + "/" + day + "/" + isTuijian + "/" + isTejia + "/" + isRemai + "/" + price_up + "/" + price_down + "/" + renqi + "/" + price + ".html\">" + row["joinName"] + "</a>");
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
                sbDay.Append("<a href=\"/search/" + keyword + "/" + cityId + "/" + proId + "/0/" + isTuijian + "/" + isTejia + "/" + isRemai + "/" + price_up + "/" + price_down + "/" + renqi + "/" + price + ".html\" class=\"current\">全部</a>");
            }
            else
            {
                sbDay.Append("<a href=\"/search/" + keyword + "/" + cityId + "/" + proId + "/0/" + isTuijian + "/" + isTejia + "/" + isRemai + "/" + price_up + "/" + price_down + "/" + renqi + "/" + price + ".html\">全部</a>");
            }
            for (int i = 1; i <= tday; i++)
            {
                if (i== day)
                {
                    sbDay.Append("<a href=\"/search/" + keyword + "/" + cityId + "/" + proId + "/" + i + "/" + isTuijian + "/" + isTejia + "/" + isRemai + "/" + price_up + "/" + price_down + "/" + renqi + "/" + price + ".html\" class=\"current\">" + i + "天</a>");
                }
                else
                {
                    sbDay.Append("<a href=\"/search/" + keyword + "/" + cityId + "/" + proId + "/" + i + "/" + isTuijian + "/" + isTejia + "/" + isRemai + "/" + price_up + "/" + price_down + "/" + renqi + "/" + price + ".html\">" + i + "天</a>");
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
                sbOther.Append("<li class=\"curr\"><a href=\"/search/" + keyword + "/" + cityId + "/" + proId + "/0/" + isTuijian + "/" + isTejia + "/" + isRemai + "/" + price_up + "/" + price_down + "/0/0.html\">全部</a></li>");
                sbOther.Append("<li><a rel=\"nofollow\" href=\"/search/" + keyword + "/" + cityId + "/" + proId + "/0/" + isTuijian + "/" + isTejia + "/" + isRemai + "/" + price_up + "/" + price_down + "/1/0.html\"><span>人气</span><i class=\"s1\"></i></a></li>");
                sbOther.Append("<li><a rel=\"nofollow\" href=\"/search/" + keyword + "/" + cityId + "/" + proId + "/0/" + isTuijian + "/" + isTejia + "/" + isRemai + "/" + price_up + "/" + price_down + "/0/1.html\"><span>价格</span><i class=\"s1\"></i></a></li>");
            }
            else
            {
                sbOther.Append("<li><a href=\"/search/" + keyword + "/" + cityId + "/" + proId + "/0/" + isTuijian + "/" + isTejia + "/" + isRemai + "/" + price_up + "/" + price_down + "/0/0.html\">全部</a></li>");
                if (renqi == 0 & price > 0)
                {
                    sbOther.Append("<li><a rel=\"nofollow\" href=\"/search/" + keyword + "/" + cityId + "/" + proId + "/" + day + "/" + isTuijian + "/" + isTejia + "/" + isRemai + "/" + price_up + "/" + price_down + "/1/0.html\"><span>人气</span><i class=\"s1\"></i></a></li>");
                    sbOther.Append("<li class=\"curr\"><a rel=\"nofollow\" href=\"/search/" + keyword + "/" + cityId + "/" + proId + "/" + day + "/" + isTuijian + "/" + isTejia + "/" + isRemai + "/" + price_up + "/" + price_down + "/0/1.html\"><span>价格</span><i class=\"s0\"></i></a></li>");
                }
                else
                {
                    sbOther.Append("<li class=\"curr\"><a rel=\"nofollow\" href=\"/search/" + keyword + "/" + cityId + "/" + proId + "/" + day + "/" + isTuijian + "/" + isTejia + "/" + isRemai + "/" + price_up + "/" + price_down + "/1/0.html\"><span>人气</span><i class=\"s0\"></i></a></li>");
                    sbOther.Append("<li><a rel=\"nofollow\" href=\"/search/" + keyword + "/" + cityId + "/" + proId + "/" + day + "/" + isTuijian + "/" + isTejia + "/" + isRemai + "/" + price_up + "/" + price_down + "/0/1.html\"><span>价格</span><i class=\"s1\"></i></a></li>");
                }
            }

            return sbOther.ToString();
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
            if (!this.keyword.Equals("no"))
            {
                this.keyword = this.keyword.Replace("'", "");
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
            if (!string.IsNullOrEmpty(this.keyword))
            {
                if (!this.keyword.Equals("no"))
                {
                    strTemp.Append(" and (lineName like '%" + this.keyword + "%' or lineSubName like '%" + this.keyword + "%')");
                }
            }
            if (!this.price_up.Equals("") && !this.price_up.Equals("0"))
            {
                int tempPrice_up;
                int.TryParse(this.price_up, out tempPrice_up);
                strTemp.Append(" and priceCommon<=" + tempPrice_up);
            }
            if (!this.price_down.Equals("")&&!this.price_down.Equals("0"))
            {
                int tempPrice_down;
                int.TryParse(this.price_down, out tempPrice_down);
                strTemp.Append(" and priceCommon>=" + tempPrice_down);
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
        /// <summary>
        /// 绑定线路路列表
        /// </summary>
        /// <param name="dsLine"></param>
        /// <returns></returns>
        public string BindlistLine()
        {
            StringBuilder sbLine = new StringBuilder();
            //获得总条数
            string strWhere=getWhere();
            this.pcount = LineBll.GetCount(strWhere);
            if (this.pcount > 0)
            {
                DataSet ds = LineBll.GetPageList(this.pagesize, this.page, strWhere, getOrder());
                DataRow row = null;
                List<TravelAgent.Model.LineContent> lstLineContent = null;
                TravelAgent.Model.LineContent content = null;
                int selectCount = ds.Tables[0].Rows.Count;
                for (int i = 0; i < selectCount; i++)
                {
                    row = ds.Tables[0].Rows[i];
                    sbLine.Append("<div class=\"linebox\">");
                    //sbLine.Append("<div class=\"linepic\"><a href=\"/Line.aspx?id=" + row["Id"] + "\" target=\"_blank\"><img src=\"" + row["linePic"] + "\" alt=\"" + row["lineName"] + "\" /></a></div>");
                    //urlrewrite
                    sbLine.Append("<div class=\"linepic\"><a href=\"/line/" + row["Id"] + ".html\" target=\"_blank\"><img src=\"" + row["linePic"] + "\" alt=\"" + row["lineName"] + "\" /></a></div>");
                    sbLine.Append("<div class=\"linecon\">");
                    //sbLine.Append("<div class=\"line_tit\"><a href=\"/Line.aspx?id=" + row["Id"] + "\" target=\"_blank\">" + row["lineName"] + "</a></div>");
                    //urlrewrite
                    sbLine.Append("<div class=\"line_tit\"><a href=\"/line/" + row["Id"] + ".html\" target=\"_blank\">" + row["lineName"] + "</a>"+TravelAgent.Tool.CommonOprate.ShowLineState(row["State"].ToString())+"</div>");
                    sbLine.Append("<div class=\"line_txt\"><span>行程天数：" + row["dayNumber"] + "天</span><span>线路类型：" + getJoinPropery(Convert.ToInt32(row["proIds"])) + "</span><span>往返交通：" + row["trafficIds"].ToString().Trim(',') + "</span><span>人 气：" + row["gzd"] + "人关注</span></div>");
                    sbLine.Append("<div class=\"lc-day-detail\"><div class=\"doc-line-list2\">");

                    lstLineContent = LineContentBll.GetlstLineContentByLineId(Convert.ToInt32(row["Id"]));

                    for (int j = 0; j < lstLineContent.Count; j++)
                    {
                        content = lstLineContent[j];
                        sbLine.Append("<dl>");
                        sbLine.Append("<dt class=\"doc-day-num\">D" + content.DaySort + "</dt>");
                        sbLine.Append("<dd class=\"doc-mdd-list\">" + content.Title + "</dd>");
                        sbLine.Append("</dl>");
                    }

                    sbLine.Append("</div>");
                    sbLine.Append("<div class=\"doc-more\"><a href=\"javascript:void(0)\"><em>行程</em><span class=\"icon-hide\"></span></a></div>");
                    //sbLine.Append("<div class=\"doc-price\"><a class=\"zk\" data-id=\"" + row["Id"] + "\" data-url=\"/Line.aspx?id=" + row["Id"] + "\" href=\"javascript:;\"><em>团期</em><span></span></a></div>");
                    //sbLine.Append("<div class=\"doc-deital\"><a href=\"/Line.aspx?id=" + row["Id"] + "\"><em>详情</em><span></span></a></div>");
                    //urlrewrite
                    sbLine.Append("<div class=\"doc-price\"><a class=\"zk\" data-id=\"" + row["Id"] + "\" data-url=\"/line/" + row["Id"] + ".html\" href=\"javascript:;\"><em>团期</em><span></span></a></div>");
                    sbLine.Append("<div class=\"doc-deital\"><a href=\"/line/" + row["Id"] + ".html\"><em>详情</em><span></span></a></div>");
                    sbLine.Append("</div></div>");
                    if (row["priceCommon"].ToString().Equals("") || row["priceCommon"].ToString().Equals("0"))
                    {
                        sbLine.Append("<div class=\"pre prebg" + (i + 1) + "\">电询</div>");
                    }
                    else
                    {
                        sbLine.Append("<div class=\"pre prebg" + (i + 1) + "\">¥ " + row["priceCommon"] + "</div>");
                    }
                    sbLine.Append("<div id=\"case_calendar_" + row["Id"] + "\" class=\"case_calendar\">");
                    sbLine.Append("<div class=\"case_calendar_left\"></div>");
                    sbLine.Append("<div class=\"case_calendar_right\"></div>");
                    sbLine.Append("</div>");
                    sbLine.Append("<div class=\"clear\"></div>");
                    sbLine.Append("</div>");

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

                    sbLine.Append("<div class=\"pages\">");

                    if (this.page > 0)
                    {
                        sbLine.Append("<a href='/search/" + keyword + "/" + cityId + "/" + proId + "/" + day + "/" + isTuijian + "/" + isTejia + "/" + isRemai + "/" + price_up + "/" + price_down + "/" + renqi + "/" + price + "/" + (page - 1) + ".html'>上一页</a>");
                    }
                    for (int i = 0; i < totalPagecount; i++)
                    {
                        if (i == this.page)
                        {
                            sbLine.Append("&nbsp;<span class='current'>" + (i + 1) + "</span>");
                        }
                        else
                        {
                            sbLine.Append("&nbsp;<a href='/search/" + keyword + "/" + cityId + "/" + proId + "/" + day + "/" + isTuijian + "/" + isTejia + "/" + isRemai + "/" + price_up + "/" + price_down + "/" + renqi + "/" + price + "/" + i + ".html'>" + (i + 1) + "</a>");
                        }

                    }
                    if (this.page < totalPagecount - 1)
                    {
                        sbLine.Append("<a href='/search/" + keyword + "/" + cityId + "/" + proId + "/" + day + "/" + isTuijian + "/" + isTejia + "/" + isRemai + "/" + price_up + "/" + price_down + "/" + renqi + "/" + price + "/" + (page + 1) + ".html'>下一页</a>");
                    }

                    sbLine.Append("</div>");
                }
            }
            else
            {
                string strv=this.keyword.Equals("no")?"":this.keyword;
                sbLine.Append("<div class=\"noContent\">");
                sbLine.Append("<div class=\"content\">");
                sbLine.Append("很抱歉，无法匹配“<span style=\"color:red\">" + strv + "</span>”相关的旅游产品，请重新输入关键词或点击右边特价产品。");
                sbLine.Append("<p>您可以更换搜索条件或改订其他线路 <a href=\"/Search.aspx\">清除筛选条件</a></p>");
                sbLine.Append("</div>");
                sbLine.Append("</div>");
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
            //DataSet dsLine = LineBll.GetList(top, "InStr(State,',"+ state+ ",')>0 and isLock=0", "Sort asc,adddate desc");
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
