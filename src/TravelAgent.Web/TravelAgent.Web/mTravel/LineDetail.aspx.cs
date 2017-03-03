using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace TravelAgent.Web.mTravel
{
    public partial class LineDetail : TravelAgent.Web.UI.mBasePage
    {
        public TravelAgent.Model.Line Line;
        private static readonly TravelAgent.BLL.Line LineBll = new TravelAgent.BLL.Line();
        private static readonly TravelAgent.BLL.JoinProperty ProBll = new TravelAgent.BLL.JoinProperty();
        private static readonly TravelAgent.BLL.DepartureCity CityBll = new TravelAgent.BLL.DepartureCity();
        private static readonly TravelAgent.BLL.LineContent LineContentBll = new TravelAgent.BLL.LineContent();
        private static readonly TravelAgent.BLL.Category CateBll = new TravelAgent.BLL.Category();
        private static readonly TravelAgent.BLL.LineSpePrice SpePriceBll = new TravelAgent.BLL.LineSpePrice();
        protected void Page_Load(object sender, EventArgs e)
        {
            int id = 0;
            if (Request.QueryString["id"] != null && int.TryParse(Request.QueryString["id"], out id))
            {
                Line = LineBll.GetModel(id);
            }
            if(Line == null)
            {
                Response.Redirect("/Opr.aspx?t=error&msg=opr");
            }
            else
            {
                int normalPrice = String.IsNullOrEmpty(Line.PriceContent) ? 0 : Convert.ToInt32(Line.PriceContent.Split(',')[2]);
                Line.PurchasePrice = GetLineSpePrice(id, normalPrice);
            }
        }
        /// <summary>
        /// 显示参团性质
        /// </summary>
        /// <returns></returns>
        public string ShowJoinName(string proids)
        {
            string strvalue = "";
            int proidsId;
            if (int.TryParse(proids, out proidsId))
            {
                TravelAgent.Model.JoinProperty proModel = ProBll.GetModel(proidsId);
                if (proModel != null)
                {
                    strvalue = proModel.joinName;
                }
            }
            return strvalue;
        }
        /// <summary>
        /// 显示价格
        /// </summary>
        /// <param name="price"></param>
        /// <returns></returns>
        public string ShowPrice(string price)
        {
            string strvalue = "";
            if (price.ToString().Equals("0") || price.Equals(""))
            {
                strvalue = "电询";
            }
            else
            {
                strvalue = "¥&nbsp;" + price + "起";
            }
            return strvalue;
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
        /// 显示出发城市
        /// </summary>
        /// <param name="cityid"></param>
        /// <returns></returns>
        public string ShowCityName()
        {
            Model.DepartureCity city = CityBll.GetModel(Line.CityId);
            if (city == null) return "";
            return city.CityName;
        }
        /// <summary>
        /// 显示行程详细内容
        /// </summary>
        /// <param name="lineId"></param>
        /// <returns></returns>
        public string ShowLine(int lineId)
        {
            StringBuilder sb = new StringBuilder();
            List<TravelAgent.Model.LineContent> lstLineContent = LineContentBll.GetlstLineContentByLineId(lineId);
            TravelAgent.Model.LineContent content = null;
            for (int i = 0; i < lstLineContent.Count; i++)
            {
                content = lstLineContent[i];
                sb.Append("<p><em>第" + content.DaySort + "天</em>" + TravelAgent.Tool.CommonOprate.ShowLineTitle(content.Title) + "</p>");
            }

            return sb.ToString();
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
        /// 显示行程日期
        /// </summary>
        /// <returns></returns>
        public string ShowDate()
        {
            StringBuilder sbDate = new StringBuilder();
            List<TravelAgent.Model.LineSpePrice> listSpePrice = SpePriceBll.GetlstSpePriceByLineId(Line.Id);
            string[] Day = new string[] { "星期日", "星期一", "星期二", "星期三", "星期四", "星期五", "星期六" };
            if (!string.IsNullOrEmpty(Line.PriceSDate) && !string.IsNullOrEmpty(Line.PriceEDate))
            {
                DateTime dtstart = Convert.ToDateTime(Line.PriceSDate);
                DateTime dtend = Convert.ToDateTime(Line.PriceEDate);
                if (dtend >= dtstart)
                {
                    TimeSpan ts = dtend.Subtract(dtstart);
                    int days = ts.Days;
                    string strSpePrice = "";
                    for (int i = 0; i <= days; i++)
                    {
                        DateTime dttemp = dtstart.AddDays(i);
                        if (dttemp >= DateTime.Now)
                        {
                            int dayValue = Convert.ToInt32(dttemp.DayOfWeek);
                            string strCurPrice = Line.PriceContent.Split(',')[2] + "," + Line.PriceContent.Split(',')[3];
                            if (Line.PriceEditModel == 0)//天天发团
                            {
                                strSpePrice = getSpePrice(Line.Id, dttemp.ToString("yyyy-MM-dd"), strCurPrice, listSpePrice);
                            }
                            else if (Line.PriceEditModel == 1)//按周
                            {
                                if (TravelAgent.Tool.CommonOprate.IsContainValue(dayValue.ToString(), Line.PriceSetting))
                                {
                                    strSpePrice = getSpePrice(Line.Id, dttemp.ToString("yyyy-MM-dd"), strCurPrice, listSpePrice);
                                }
                                else
                                {
                                    strSpePrice = getSpePrice(Line.Id, dttemp.ToString("yyyy-MM-dd"), "", listSpePrice);
                                }
                            }
                            else if (Line.PriceEditModel == 2)//按号
                            {
                                if (TravelAgent.Tool.CommonOprate.IsContainValue(dttemp.Day.ToString(), Line.PriceSetting))
                                {
                                    strSpePrice = getSpePrice(Line.Id, dttemp.ToString("yyyy-MM-dd"), strCurPrice, listSpePrice);
                                }
                                else
                                {
                                    strSpePrice = getSpePrice(Line.Id, dttemp.ToString("yyyy-MM-dd"), "", listSpePrice);
                                }
                            }
                            if (!strSpePrice.Equals(""))
                            {
                                string[] arrySpePrice = strSpePrice.Split(',');
                                sbDate.Append("<p style=\"line-height: 28px; color: #f80;\">" + dttemp.ToString("yyyy-MM-dd") + "  " + arrySpePrice[0] + "元/成人," + arrySpePrice[1] + "元/儿童</p>");
                            }
                        }
                    }
                }
            }
            return sbDate.ToString();
        }
        /// <summary>
        /// 获得特殊日期价格
        /// </summary>
        /// <param name="lineid"></param>
        /// <param name="pricecontent"></param>
        /// <returns></returns>
        public string getSpePrice(int lineid, string date, string curprice, List<TravelAgent.Model.LineSpePrice> lstSpePrice)
        {
            string strValue = curprice;
            //List<TravelAgent.Model.LineSpePrice> listSpePrice = SpePriceBll.GetlstSpePriceByLineId(lineid);
            foreach (TravelAgent.Model.LineSpePrice price in lstSpePrice)
            {
                if (price.lineDate.Equals(date))
                {
                    if (price.tag == 1)//新增的价格
                    {
                        strValue = price.linePrice.Split(',')[2] + "," + price.linePrice.Split(',')[3];
                    }
                    else if (price.tag == 0)//删除的价格
                    {
                        strValue = "";
                    }
                    break;
                }
            }
            return strValue;
        }
    }
}
