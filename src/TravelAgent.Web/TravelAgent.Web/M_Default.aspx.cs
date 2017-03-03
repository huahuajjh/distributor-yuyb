using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TravelAgent.Web
{
    public partial class M_Default : TravelAgent.Web.UI.mBasePage
    {
        public string bannerstring;
        private static readonly TravelAgent.BLL.Adbanner bannerBll = new TravelAgent.BLL.Adbanner();
        //public TravelAgent.Model.WebInfo webinfo;
        private static readonly TravelAgent.BLL.Line LineBll = new TravelAgent.BLL.Line();
        private static readonly TravelAgent.BLL.Category CateBll = new TravelAgent.BLL.Category();
        private static readonly TravelAgent.BLL.LineSpePrice SpePriceBll = new TravelAgent.BLL.LineSpePrice();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 绑定
        /// </summary>
        /// <returns></returns>
        public string BindBanner(int aid)
        {
            StringBuilder sbBanner = new StringBuilder();
            DataSet dsBanner = bannerBll.GetList(0, "IsLock=0 and Aid=" + aid, "AddTime desc");
            DataRow row = null;
            for (int i = 0; i < dsBanner.Tables[0].Rows.Count; i++)
            {
                row = dsBanner.Tables[0].Rows[i];
                //bannerstring += "<a href=\"javascript:;\">" + (i + 1) + "</a>";
                bannerstring += "<a href=\"javascript:;\"></a>";
                sbBanner.Append("<li><a href=\"javascript:void(0);" + Server.UrlEncode(row["Title"].ToString()) + "\"><img id=\"main_img_" + (i + 1) + "\" src=\"" + row["AdUrl"] + "\" alt=\"" + row["Title"] + "\" /></a></li>");
            }
            return sbBanner.ToString();
        }
        /// <summary>
        /// 绑定推荐产品
        /// </summary>
        /// <returns></returns>
        public string BindLine(int top, int state)
        {
            StringBuilder sbLine = new StringBuilder();
            //Access
            //DataSet dsLine = LineBll.GetList(top, "InStr(State,'," + state + ",')>0 and isLock=0", "Sort asc,adddate desc");
            //SQL
            DataSet dsLine = LineBll.GetList(top, "CHARINDEX('," + state + ",',State)>0 and isLock=0", "Sort asc,adddate desc");
            foreach (DataRow row in dsLine.Tables[0].Rows)
            {
                sbLine.Append("<li>");
                sbLine.Append("<a href=\"mTravel/LineDetail.aspx?id=" + row["Id"] + "\">");
                sbLine.Append("<div class=\"m-img\"><img src=\"" + row["linePic"] + "\"></div>");
                sbLine.Append("<div class=\"m-c\">");
                sbLine.Append("<p class=\"m-c-tit\"><code>" + row["lineName"] + "</code></p>");
                sbLine.Append("<p class=\"m-c-txt\">");
                sbLine.Append("<span>" + row["dayNumber"] + "日游</span>");

                int intNormalPrice = String.IsNullOrEmpty(row["priceContent"].ToString()) ? 0 : Convert.ToInt32(row["priceContent"].ToString().Split(',')[2]);
                //获得市场价
                int marketPrice = LineBll.GetModel(Convert.ToInt32(row["Id"])).GetShopPrice();
                //获得同行价
                int intMinPrice = GetLineSpePrice(Convert.ToInt32(row["Id"]), intNormalPrice);

                if (row["priceCommon"].ToString().Equals("0") || row["priceCommon"].ToString().Equals(""))
                {
                    sbLine.Append("<em>电询</em>");
                }
                else
                {
                    sbLine.Append("<em>同行价¥ " + intMinPrice + "</em>");
                    sbLine.Append("<em>市场价¥ " + marketPrice + "</em>");
                }
                sbLine.Append("</p>");
                sbLine.Append("</div>");
                sbLine.Append("</a>");
                sbLine.Append("</li>");
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
                sbBottomNav.Append("<a href=\"mTravel/Article.aspx?id=" + dsNav.Tables[0].Rows[i]["Id"] + "\">" + dsNav.Tables[0].Rows[i]["Title"] + "</a>|");
            }
            return sbBottomNav.ToString().Remove(sbBottomNav.Length - 1);
        }
    }
}
