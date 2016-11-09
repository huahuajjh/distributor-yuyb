using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TravelAgent.Web.mTravel
{
    public partial class MOrder : TravelAgent.Web.UI.mBasePage
    {
        public int pid;
        public TravelAgent.Model.Line LineModel;
        private static readonly TravelAgent.BLL.Category CateBll = new TravelAgent.BLL.Category();
        private static readonly TravelAgent.BLL.Line LineBll = new TravelAgent.BLL.Line();
        private static readonly TravelAgent.BLL.LineSpePrice SpePriceBll = new TravelAgent.BLL.LineSpePrice();
        private static readonly TravelAgent.BLL.Insure InsureBll = new TravelAgent.BLL.Insure();
        protected void Page_Load(object sender, EventArgs e)
        {
            int.TryParse(Request.QueryString["id"], out pid);
            if (!this.IsPostBack)
            {
                if (pid > 0)
                {
                    LineModel = LineBll.GetModel(pid);
                    if (LineModel != null)
                    {
                        LineModel.Insure = InsureBll.GetModel(LineModel.InsureId);
                    }
                }
            }
            if(LineModel == null)
            {
                Response.Redirect("/Opr.aspx?t=error&msg=opr");
            }
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
            List<TravelAgent.Model.LineSpePrice> listSpePrice = SpePriceBll.GetlstSpePriceByLineId(LineModel.Id);
            string[] Day = new string[] { "星期日", "星期一", "星期二", "星期三", "星期四", "星期五", "星期六" };
            if (!string.IsNullOrEmpty(LineModel.PriceSDate) && !string.IsNullOrEmpty(LineModel.PriceEDate))
            {
                DateTime dtstart = Convert.ToDateTime(LineModel.PriceSDate);
                DateTime dtend = Convert.ToDateTime(LineModel.PriceEDate);
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
                            string strCurPrice = LineModel.PriceContent.Split(',')[2] + "," + LineModel.PriceContent.Split(',')[3];
                            if (LineModel.PriceEditModel == 0)//天天发团
                            {
                                strSpePrice = getSpePrice(LineModel.Id, dttemp.ToString("yyyy-MM-dd"), strCurPrice, listSpePrice);
                            }
                            else if (LineModel.PriceEditModel == 1)//按周
                            {
                                if (TravelAgent.Tool.CommonOprate.IsContainValue(dayValue.ToString(), LineModel.PriceSetting))
                                {
                                    strSpePrice = getSpePrice(LineModel.Id, dttemp.ToString("yyyy-MM-dd"), strCurPrice, listSpePrice);
                                }
                                else
                                {
                                    strSpePrice = getSpePrice(LineModel.Id, dttemp.ToString("yyyy-MM-dd"), "", listSpePrice);
                                }
                            }
                            else if (LineModel.PriceEditModel == 2)//按号
                            {
                                if (TravelAgent.Tool.CommonOprate.IsContainValue(dttemp.Day.ToString(), LineModel.PriceSetting))
                                {
                                    strSpePrice = getSpePrice(LineModel.Id, dttemp.ToString("yyyy-MM-dd"), strCurPrice, listSpePrice);
                                }
                                else
                                {
                                    strSpePrice = getSpePrice(LineModel.Id, dttemp.ToString("yyyy-MM-dd"), "", listSpePrice);
                                }
                            }
                            if (!strSpePrice.Equals(""))
                            {
                                string[] arrySpePrice = strSpePrice.Split(',');
                                sbDate.Append("<option value=\"" + dttemp.ToString("yyyy-MM-dd") + "\" tag=\"" + strSpePrice + "\">" + dttemp.ToString("yyyy-MM-dd") + " （" + Day[dayValue] + "） </option>");
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
