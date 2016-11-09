using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TravelAgent.Web.admin.data
{
    public partial class Product_Line_Calendar : System.Web.UI.Page
    {
        private static readonly TravelAgent.BLL.Line LineBll = new TravelAgent.BLL.Line();
        private static readonly TravelAgent.BLL.LineSpePrice SpePriceBll = new TravelAgent.BLL.LineSpePrice();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null)
            {
                StringBuilder sb = new StringBuilder();
                TravelAgent.Model.Line Line = LineBll.GetModel(Convert.ToInt32(Request.QueryString["id"]));
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
                            for (int i = 0; i <= days; i++)
                            {
                                DateTime dttemp = dtstart.AddDays(i);
                                if (dttemp >= DateTime.Now)
                                {
                                    if (Line.PriceEditModel == 0)//天天发团
                                    {
                                            sb.Append("{\"id\":\"" + dttemp.ToString("yyyyMMdd") + "\",");
                                            sb.Append("\"title\":\"" + getSpePrice(Line.Id, dttemp.ToString("yyyy-MM-dd"), Line.PriceContent) + "\",");
                                            sb.Append("\"start\":\"" + dttemp.ToString("yyyy-MM-dd") + "\",");
                                            sb.Append("\"end\":\"" + dttemp.ToString("yyyy-MM-dd") + "\",");
                                            sb.Append("\"price\":\"" + Line.PriceContent + "\",");
                                            sb.Append("\"color\":\"#fee08f\"},");
                                    }
                                    else if (Line.PriceEditModel == 1)//按周
                                    {
                                        if (TravelAgent.Tool.CommonOprate.IsContainValue(Convert.ToInt32(dttemp.DayOfWeek).ToString(), Line.PriceSetting))
                                        {
                                            sb.Append("{\"id\":\"" + dttemp.ToString("yyyyMMdd") + "\",");
                                            sb.Append("\"title\":\"" + getSpePrice(Line.Id, dttemp.ToString("yyyy-MM-dd"), Line.PriceContent) + "\",");
                                            sb.Append("\"start\":\"" + dttemp.ToString("yyyy-MM-dd") + "\",");
                                            sb.Append("\"end\":\"" + dttemp.ToString("yyyy-MM-dd") + "\",");
                                            sb.Append("\"price\":\"" + Line.PriceContent + "\",");
                                            sb.Append("\"color\":\"#fee08f\"},");
                                        }
                                        else
                                        {
                                            string strspeprice = getSpePrice2(Line.Id, dttemp.ToString("yyyy-MM-dd"), Line.PriceContent);
                                            if (!strspeprice.Equals(""))
                                            {
                                                sb.Append("{\"id\":\"" + dttemp.ToString("yyyyMMdd") + "\",");
                                                sb.Append("\"title\":\"" + strspeprice + "\",");
                                                sb.Append("\"start\":\"" + dttemp.ToString("yyyy-MM-dd") + "\",");
                                                sb.Append("\"end\":\"" + dttemp.ToString("yyyy-MM-dd") + "\",");
                                                sb.Append("\"price\":\"" + Line.PriceContent + "\",");
                                                sb.Append("\"color\":\"#fee08f\"},");
                                            }
                                        }
                                    }
                                    else if (Line.PriceEditModel == 2)//按月
                                    {
                                        if (TravelAgent.Tool.CommonOprate.IsContainValue(dttemp.Day.ToString(), Line.PriceSetting))
                                        {
                                            sb.Append("{\"id\":\"" + dttemp.ToString("yyyyMMdd") + "\",");
                                            sb.Append("\"title\":\"" + getSpePrice(Line.Id, dttemp.ToString("yyyy-MM-dd"), Line.PriceContent) + "\",");
                                            sb.Append("\"start\":\"" + dttemp.ToString("yyyy-MM-dd") + "\",");
                                            sb.Append("\"end\":\"" + dttemp.ToString("yyyy-MM-dd") + "\",");
                                            sb.Append("\"price\":\"" + Line.PriceContent + "\",");
                                            sb.Append("\"color\":\"#fee08f\"},");
                                        }
                                        else
                                        {
                                            string strspeprice = getSpePrice2(Line.Id, dttemp.ToString("yyyy-MM-dd"), Line.PriceContent);
                                            if (!strspeprice.Equals(""))
                                            {
                                                sb.Append("{\"id\":\"" + dttemp.ToString("yyyyMMdd") + "\",");
                                                sb.Append("\"title\":\"" + strspeprice + "\",");
                                                sb.Append("\"start\":\"" + dttemp.ToString("yyyy-MM-dd") + "\",");
                                                sb.Append("\"end\":\"" + dttemp.ToString("yyyy-MM-dd") + "\",");
                                                sb.Append("\"price\":\"" + Line.PriceContent + "\",");
                                                sb.Append("\"color\":\"#fee08f\"},");
                                            }
                                        }
                                    }
                                }
                            }
                            sb.Remove(sb.Length - 1, 1);
                            sb.Append("]");
                        }
                    }
                    else
                    {
                        List<TravelAgent.Model.LineSpePrice> listSpePrice = getCacheData(Convert.ToInt32(Request.QueryString["id"]));
                        sb.Append("[");
                        foreach (TravelAgent.Model.LineSpePrice price in listSpePrice)
                        {
                            if (price.tag == 1)
                            {
                                sb.Append("{\"id\":\"" + Convert.ToDateTime(price.lineDate).ToString("yyyyMMdd") + "\",");
                                sb.Append("\"title\":\"销：" + price.linePrice.Split(',')[2] + "     余：" + price.linePrice.Split(',')[11] + "\",");
                                sb.Append("\"start\":\"" + price.lineDate + "\",");
                                sb.Append("\"end\":\"" + price.lineDate + "\",");
                                sb.Append("\"price\":\"" + Line.PriceContent + "\",");
                                sb.Append("\"color\":\"#fee08f\"},");
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
        public string getSpePrice(int lineid, string date,string curprice)
        {
            string strprice = "销：" + curprice.Split(',')[2] + "     余：" + curprice.Split(',')[11];
           
            List<TravelAgent.Model.LineSpePrice> listSpePrice = getCacheData(lineid);
            foreach (TravelAgent.Model.LineSpePrice price in listSpePrice)
            {
                if (price.lineDate.Equals(date))
                {
                    if (price.tag == 1)//新增的价格
                    {
                        strprice = "销：" + price.linePrice.Split(',')[2] + "     余：" + price.linePrice.Split(',')[11];
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
        /// 获得特殊日期价格
        /// </summary>
        /// <param name="lineid"></param>
        /// <param name="pricecontent"></param>
        /// <returns></returns>
        public string getSpePrice2(int lineid, string date, string curprice)
        {
            string strprice = "";

            List<TravelAgent.Model.LineSpePrice> listSpePrice = getCacheData(lineid);
            foreach (TravelAgent.Model.LineSpePrice price in listSpePrice)
            {
                if (price.lineDate.Equals(date))
                {
                    if (price.tag == 1)//新增的价格
                    {
                        strprice = "销：" + price.linePrice.Split(',')[2] + "     余：" + price.linePrice.Split(',')[11];

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
