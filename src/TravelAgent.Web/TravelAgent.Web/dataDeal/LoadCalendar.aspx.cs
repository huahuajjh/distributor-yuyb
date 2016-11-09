using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TravelAgent.Web.dataDeal
{
    public partial class LoadCalendar : System.Web.UI.Page
    {
        private static readonly TravelAgent.BLL.Line LineBll = new TravelAgent.BLL.Line();
        private static readonly TravelAgent.BLL.LineSpePrice SpePriceBll = new TravelAgent.BLL.LineSpePrice();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null)
            {
                int id = Convert.ToInt32(Request.QueryString["id"]);
                StringBuilder sb = new StringBuilder();
                string[] Day = new string[] { "星期日", "星期一", "星期二", "星期三", "星期四", "星期五", "星期六" };
                TravelAgent.Model.Line Line = LineBll.GetModel(id);
                if (Line != null)
                {
                    if (!Line.PriceSDate.Equals("") && !Line.PriceEDate.Equals(""))
                    {
                        DateTime dtstart = Convert.ToDateTime(Line.PriceSDate);
                        DateTime dtend = Convert.ToDateTime(Line.PriceEDate);
                        if (dtend >= dtstart)
                        {
                            sb.Append("[");
                            TimeSpan ts = dtend.Subtract(dtstart);
                            int days = ts.Days;
                            string strSpePrice = "";
                            for (int i = 0; i <= days; i++)
                            {
                                DateTime dttemp = dtstart.AddDays(i);
                                int dayValue=Convert.ToInt32(dttemp.DayOfWeek);
                                string strCurprice = Line.PriceContent.Split(',')[2] + "," + Line.PriceContent.Split(',')[3];
                                if (dttemp >= DateTime.Now)
                                {
                                    if (Line.PriceEditModel == 0)//天天发团
                                    {
                                        strSpePrice = getSpePrice(Line.Id, dttemp.ToString("yyyy-MM-dd"),strCurprice);
                                    }
                                    else if (Line.PriceEditModel == 1)//按周
                                    {
                                        if (TravelAgent.Tool.CommonOprate.IsContainValue(dayValue.ToString(), Line.PriceSetting))
                                        {
                                            strSpePrice = getSpePrice(Line.Id, dttemp.ToString("yyyy-MM-dd"), strCurprice);
                                        }
                                        else
                                        {
                                            strSpePrice = getSpePrice(Line.Id, dttemp.ToString("yyyy-MM-dd"), "");
                                        }
                                    }
                                    else if (Line.PriceEditModel == 2)//按月
                                    {
                                        if (TravelAgent.Tool.CommonOprate.IsContainValue(dttemp.Day.ToString(), Line.PriceSetting))
                                        {
                                            strSpePrice = getSpePrice(Line.Id, dttemp.ToString("yyyy-MM-dd"), strCurprice);
                                        }
                                        else
                                        {
                                            strSpePrice = getSpePrice(Line.Id, dttemp.ToString("yyyy-MM-dd"), "");
                                        }
                                    }
                                    if (!strSpePrice.Equals(""))
                                    {
                                        sb.Append("{\"id\":\"" + dttemp.ToString("yyyyMMdd") + "\",");
                                        sb.Append("\"title\":\"" + strSpePrice.Split(',')[0] + "元\",");
                                        sb.Append("\"start\":\"" + dttemp.ToString("yyyy-MM-dd") + "\",");
                                        sb.Append("\"end\":\"" + dttemp.ToString("yyyy-MM-dd") + "\",");
                                        sb.Append("\"allDay\":true,");
                                        sb.Append("\"price\":\"" + Line.PriceContent + "\",");
                                        sb.Append("\"info\":\"" + dttemp.ToString("yyyy-MM-dd")+"("+Day[dayValue]+")  "+ strSpePrice.Split(',')[0] + "元/成人," + strSpePrice.Split(',')[1] + "元/儿童\",");
                                        sb.Append("\"textColor\":\"#eb7f0b\"},");
                                    }
                                }
                            }
                            sb.Remove(sb.Length - 1, 1);
                            sb.Append("]");
                        }
                    }
                    else
                    {
                        List<TravelAgent.Model.LineSpePrice> listSpePrice = SpePriceBll.GetlstSpePriceByLineId(id);
                        sb.Append("[");
                        foreach (TravelAgent.Model.LineSpePrice price in listSpePrice)
                        {
                            if (price.tag == 1)
                            {
                                DateTime dtspeTemp=Convert.ToDateTime(price.lineDate);
                                sb.Append("{\"id\":\"" + dtspeTemp.ToString("yyyyMMdd") + "\",");
                                sb.Append("\"title\":\"" + price.linePrice.Split(',')[2] + "元\",");
                                sb.Append("\"start\":\"" + price.lineDate + "\",");
                                sb.Append("\"end\":\"" + price.lineDate + "\",");
                                sb.Append("\"allDay\":true,");
                                sb.Append("\"price\":\"" + Line.PriceContent + "\",");
                                sb.Append("\"info\":\"" + dtspeTemp.ToString("yyyyMMdd") + "(" + Day[Convert.ToInt32(dtspeTemp.DayOfWeek)] + ")" + price.linePrice.Split(',')[2] + "元/成人," + price.linePrice.Split(',')[3] + "元/儿童\",");
                                sb.Append("\"textColor\":\"#eb7f0b\"},");
                            }
                        }
                        sb.Remove(sb.Length - 1, 1);
                        sb.Append("]");
                    }
                }
                Response.Write(sb.ToString());
            }
        }
        /// <summary>
        /// 获得特殊日期价格
        /// </summary>
        /// <param name="lineid"></param>
        /// <param name="pricecontent"></param>
        /// <returns></returns>
        public string getSpePrice(int lineid, string date, string curprice)
        {
            string strprice = curprice;

            List<TravelAgent.Model.LineSpePrice> listSpePrice = getCacheData(lineid);
            foreach (TravelAgent.Model.LineSpePrice price in listSpePrice)
            {
                if (price.lineDate.Equals(date))
                {
                    if (price.tag == 1)//新增的价格
                    {
                        strprice = price.linePrice.Split(',')[2] + "," + price.linePrice.Split(',')[3];
                    }
                    else if (price.tag == 0)//删除的价格
                    {
                        strprice = "";
                    }
                    break;
                }
            }
            return strprice;
        }
        /// <summary>
        /// 获得集合
        /// </summary>
        /// <returns></returns>
        private List<TravelAgent.Model.LineSpePrice> getCacheData(int lineid)
        {
            List<TravelAgent.Model.LineSpePrice> lstSpePrice = null;
            bool bolExist = false;//TravelAgent.Tool.CacheHelper.Exists("speprice");

            if (bolExist)
            {
                //lstSpePrice = TravelAgent.Tool.CacheHelper.Get<List<TravelAgent.Model.LineSpePrice>>("speprice");
            }
            else
            {
                lstSpePrice = SpePriceBll.GetlstSpePriceByLineId(lineid);
                TravelAgent.Tool.CacheHelper.Add<List<TravelAgent.Model.LineSpePrice>>("speprice", lstSpePrice);
            }

            return lstSpePrice;
        }
    }
}
