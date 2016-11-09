using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TravelAgent.Web.mTravel
{
    public partial class ThemeList : TravelAgent.Web.UI.mBasePage
    {
        public int thid;
        public string strNavName;
        private static readonly TravelAgent.BLL.Destination DestBll = new TravelAgent.BLL.Destination();
        private static readonly TravelAgent.BLL.Line LineBll = new TravelAgent.BLL.Line();
        private static readonly TravelAgent.BLL.Category CateBll = new TravelAgent.BLL.Category();
        private static readonly TravelAgent.BLL.DepartureCity CityBll = new TravelAgent.BLL.DepartureCity();
        protected void Page_Load(object sender, EventArgs e)
        {
            int.TryParse(Request.QueryString["thid"], out thid);
            if (Request.QueryString["thname"] != null)
            {
                strNavName = Request.QueryString["thname"];
            }
        }
        /// <summary>
        /// 绑定线路产品
        /// </summary>
        /// <param name="state"></param>
        /// <param name="top"></param>
        /// <returns></returns>
        public string BindLine(int top)
        {
            StringBuilder sbLine = new StringBuilder();
            if (thid > 0)
            {
                string strwhere = "isLock=0 and CHARINDEX('," + thid + ",',themeIds)>0";
                DataSet dsLine = LineBll.GetList(top, strwhere, "Sort asc,adddate desc");
                foreach (DataRow row in dsLine.Tables[0].Rows)
                {
                    sbLine.Append("<div class=\"show_line_box\">");
                    sbLine.Append("<a href=\"LineDetail.aspx?id=" + row["Id"] + "\" class=\"show_line_con\">");
                    sbLine.Append("<img src=\"" + row["linePic"] + "\" />");
                    if (row["priceCommon"].ToString().Equals("0") || row["priceCommon"].ToString().Equals(""))
                    {
                        sbLine.Append("<span class=\"show_line_jia\">电询</span>");
                    }
                    else
                    {
                        sbLine.Append("<span class=\"show_line_jia\">¥&nbsp;" + row["priceCommon"] + "</span>");
                    }

                    string name = "";
                    Model.DepartureCity city = CityBll.GetModel(Convert.ToInt32(row["cityId"]));
                    if (city != null) name = city.CityName;
                    sbLine.Append("</a>");
                    sbLine.Append("<a href=\"LineDetail.aspx?id=" + row["Id"] + "\" class=\"show_line_tit\">");
                    sbLine.Append("<strong>" + row["lineName"] + "</strong>");
                    sbLine.Append("<p>");
                    sbLine.Append("<span>" + name + "出发</span>|");
                    sbLine.Append("<span>" + row["dayNumber"] + "日游</span>|");
                    sbLine.Append("<span>关注：" + row["gzd"] + "</span>");
                    sbLine.Append("</p>");
                    sbLine.Append("</a>");
                    sbLine.Append("</div>");
                }
            }

            
            return sbLine.ToString();
        }
        /// <summary>
        /// 绑定底部导航
        /// </summary>
        /// <param name="top"></param>
        /// <returns></returns>
        public string BindBottonNav(int top, int parentid)
        {
            StringBuilder sbBottomNav = new StringBuilder();
            DataSet dsNav = CateBll.GetChannelListByParentId(parentid, top);
            for (int i = 0; i < dsNav.Tables[0].Rows.Count; i++)
            {
                sbBottomNav.Append("<a href=\"Article.aspx?id=" + dsNav.Tables[0].Rows[i]["Id"] + "\">" + dsNav.Tables[0].Rows[i]["Title"] + "</a>|");
            }
            return sbBottomNav.ToString().Remove(sbBottomNav.Length - 1);
        }
    }
}
