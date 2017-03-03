using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TravelAgent.Web.mTravel
{
    public partial class LineList : TravelAgent.Web.UI.mBasePage
    {
        public int d=0;
        public string strNavName;
        private static readonly TravelAgent.BLL.Destination DestBll = new TravelAgent.BLL.Destination();
        private static readonly TravelAgent.BLL.Line LineBll = new TravelAgent.BLL.Line();
        private static readonly TravelAgent.BLL.Category CateBll = new TravelAgent.BLL.Category();
        private static readonly TravelAgent.BLL.DepartureCity CityBll = new TravelAgent.BLL.DepartureCity();
        private static readonly TravelAgent.BLL.LineSpePrice SpePriceBll = new TravelAgent.BLL.LineSpePrice();
        protected void Page_Load(object sender, EventArgs e)
        {
            strNavName = "特价线路";
            if (Request["d"] != null && int.TryParse(Request["d"], out d))
            {
                Model.Destination des = DestBll.GetModel(d);
                if (des != null) strNavName = des.navName;
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
            string strwhere = "isLock=0";
            int state = Convert.ToInt32(TravelAgent.Tool.EnumSummary.State.推荐);
            if (d == 0)
            {
                state = Convert.ToInt32(TravelAgent.Tool.EnumSummary.State.特价);
                strwhere += " and CHARINDEX('," + state + ",',State)>0";
            }
            else
            {
                strwhere += " and CHARINDEX('," + state + ",',State)>0 and destId=" + d;
            }
            
            DataSet dsLine = LineBll.GetList(top, strwhere, "Sort asc,adddate desc");
            foreach (DataRow row in dsLine.Tables[0].Rows)
            {
                sbLine.Append("<div class=\"show_line_box\">");
                sbLine.Append("<a href=\"LineDetail.aspx?id="+row["Id"]+"\" class=\"show_line_con\">");
                sbLine.Append("<img src=\"" + row["linePic"] + "\" />");

                int intNormalPrice = String.IsNullOrEmpty(row["priceContent"].ToString()) ? 0 : Convert.ToInt32(row["priceContent"].ToString().Split(',')[2]);
                //获得市场价
                int marketPrice = LineBll.GetModel(Convert.ToInt32(row["Id"])).GetShopPrice();
                //获得同行价
                int intMinPrice = GetLineSpePrice(Convert.ToInt32(row["Id"]), intNormalPrice);

                if (row["priceCommon"].ToString().Equals("0") || row["priceCommon"].ToString().Equals(""))
                {
                    sbLine.Append("<span class=\"show_line_jia\">电询</span>");
                }
                else
                {
                    sbLine.Append("<span class=\"show_line_jia\">¥市场价&nbsp;" + intMinPrice + "&nbsp&nbsp" + "¥同行价&nbsp;" + marketPrice + "</span>");
                    //sbLine.Append("<span class=\"show_line_jia\">¥同行价&nbsp;" + marketPrice + "</span>");
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
                sbLine.Append("<span>关注："+row["gzd"]+"</span>");
                sbLine.Append("</p>");
                sbLine.Append("</a>");
                sbLine.Append("</div>");
            }
            return sbLine.ToString();
        }

        /// <summary>
        /// 获取线路中成人特殊日期价格的最低价格
        /// </summary>
        /// <param name="lineId"></param>
        /// <returns></returns>
        public int GetLineSpePrice(int lineId, int intNormalPrice)
        {
            int intMinPrice = 0;
            List<TravelAgent.Model.LineSpePrice> lstLineSpePrice = SpePriceBll.GetlstSpePriceByLineId(lineId).Where(t => t.tag == 1 && t.linePrice != "").ToList();
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
        /// <summary>
        /// 绑定分类导航
        /// </summary>
        /// <returns></returns>
        public string BindNav()
        { 
            StringBuilder sbDest = new StringBuilder();
            DataTable dtDest = DestBll.GetList(d, 0);
            DataRow[] FristRows = dtDest.Select("navLayer=2 and isLock=0", "navSort asc");
            DataRow row=null;
            for (int i = 0; i < FristRows.Length; i++)
            {
                row = FristRows[i];
                sbDest.Append("<li>");
                sbDest.Append("<em>");
                sbDest.Append("<a href=\"LineDest.aspx?d=" + d + "&fd=" + row["Id"] + "&name=" + row["navName"] + "\">" + row["navName"] + "</a>");
                sbDest.Append("<span class=\"robtn\"></span>");
                sbDest.Append("</em>");
                sbDest.Append("<div class=\"rocon\">");
                DataRow[] destRows = dtDest.Select("isLock=0 and navParentId="+row["Id"], "navSort asc");
                foreach (DataRow r in destRows)
                {
                    sbDest.Append("<a href=\"LineDest.aspx?td=" + r["Id"] + "&name=" + r["navName"] + "\">" + r["navName"] + "</a>");
                }
                sbDest.Append("</div>");
                sbDest.Append("</li>");
            }
            return sbDest.ToString();
        }
        /// <summary>
        /// 绑定推荐目的地导航
        /// </summary>
        /// <returns></returns>
        public string BindPageNav()
        { 
            StringBuilder sbDest = new StringBuilder();
            DataTable dtDest = DestBll.GetList(d, 0);
            DataRow[] FristRows = dtDest.Select("navLayer=3 and isLock=0", "navSort asc");
            DataRow row=null;
            for (int i = 0; i < FristRows.Length; i++)
            {
                row = FristRows[i];
                if (row["State"].ToString().Contains("," + Convert.ToInt32(TravelAgent.Tool.EnumSummary.State.推荐) + ","))
                {
                    sbDest.Append("<li><a href=\"LineDest.aspx?td=" + row["Id"] + "&name=" + row["navName"] + "\">" + row["navName"] + "</a></li>");
                }
            }
            return sbDest.ToString();
        }
    }
}
