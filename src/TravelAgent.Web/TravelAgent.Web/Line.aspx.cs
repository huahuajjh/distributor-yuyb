using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TravelAgent.Web
{
    public partial class Line : System.Web.UI.Page
    {
        public TravelAgent.Model.Line LineModel;
        private static readonly TravelAgent.BLL.Line LineBll = new TravelAgent.BLL.Line();
        private static readonly TravelAgent.BLL.Destination DestBll = new TravelAgent.BLL.Destination();
        private static readonly TravelAgent.BLL.JoinProperty ProBll = new TravelAgent.BLL.JoinProperty();
        private static readonly TravelAgent.BLL.DepartureCity CityBll = new TravelAgent.BLL.DepartureCity();
        private static readonly TravelAgent.BLL.LineSpePrice SpePriceBll = new TravelAgent.BLL.LineSpePrice();
        private static readonly TravelAgent.BLL.LineContent LineContentBll = new TravelAgent.BLL.LineContent();
        private static readonly TravelAgent.BLL.LineConsult ConsultBll = new TravelAgent.BLL.LineConsult();

        protected void Page_Load(object sender, EventArgs e)
        {
            int id;
            if (!this.IsPostBack && Request.QueryString["id"] != null && int.TryParse(Request.QueryString["id"], out id))
            {
                LineModel = LineBll.GetModel(id);
                if (LineModel != null)
                {
                    //增加关注度
                    string strsql = "update Line set gzd=gzd+1 where Id=" + LineModel.Id;
                    //Access
                    //TravelAgent.Tool.DbHelperOleDb.ExecuteSql(strsql);
                    //SQL
                    TravelAgent.Tool.DbHelperSQL.ExecuteSql(strsql);

                    if (LineModel.SeoTitle.Trim().Equals(""))
                    {
                        this.Title = LineModel.LineName + "-" + Master.webinfo.WebName + "-" + Master.webinfo.SEOTitle;
                    }
                    else
                    {
                        this.Title = LineModel.SeoTitle;
                    }
                    if (LineModel.SeoKey.Trim().Equals(""))
                    {
                        Common.AddMeta(Page.Master.Page, "keywords", Master.webinfo.SEOKeywords);
                    }
                    else
                    {
                        Common.AddMeta(Page.Master.Page, "keywords", LineModel.SeoKey);
                    }
                    if (LineModel.SeoDisc.Trim().Equals(""))
                    {
                        Common.AddMeta(Page.Master.Page, "description", Master.webinfo.SEODescription);
                    }
                    else
                    {
                        Common.AddMeta(Page.Master.Page, "description", LineModel.SeoDisc);
                    }

                    this.divPlace.InnerHtml = ShowPlace(LineModel);

                    TravelAgent.Model.JoinProperty proModel = ProBll.GetModel(Convert.ToInt32(LineModel.ProIds));
                    if (proModel != null)
                    {
                        this.lblLineType.Text = proModel.joinName;
                    }

                    TravelAgent.Model.DepartureCity cityModel = CityBll.GetModel(LineModel.CityId);
                    if (cityModel != null)
                    {
                        this.lblCity.Text = cityModel.CityName;
                    }

                    int intNormalPrice = String.IsNullOrEmpty(LineModel.PriceContent) ? 0 : Convert.ToInt32(LineModel.PriceContent.Split(',')[2]);
                    int intMinPrice = GetLineSpePrice(LineModel.Id, intNormalPrice);
                    if (intMinPrice == 0)
                    {
                        this.ltPrice.Text = "电询";
                    }
                    else
                    {
                        this.ltPrice.Text = "¥ " + intMinPrice;
                    }
                }
            }
            if (LineModel == null) Response.Redirect("/Opr.aspx?t=error&msg=opr");
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
        /// 显示位置
        /// </summary>
        /// <param name="strPro"></param>
        /// <returns></returns>
        public string ShowPlace(TravelAgent.Model.Line Line)
        {
            StringBuilder sbPlace = new StringBuilder();
            sbPlace.Append("<span>您当前位置：</span>");
            sbPlace.Append(" <a href=\"" + Master.webinfo.WebDomain + "\">首页</a>&gt;");
            int proId = 0;
            if (!string.IsNullOrEmpty(Line.Dest))
            {
                if (Line.Dest.Contains(","))
                {
                    proId = Convert.ToInt32(Line.Dest.Split(',')[1]);
                }
                else
                {
                    proId = Convert.ToInt32(Line.Dest);
                }
                TravelAgent.Model.Destination dest = DestBll.GetModel(proId);
                string[] arryplace = dest.navList.Split(',');
                for (int i = 0; i < arryplace.Length; i++)
                {
                    if (!string.IsNullOrEmpty(arryplace[i]))
                    {
                        TravelAgent.Model.Destination model = DestBll.GetModel(Convert.ToInt32(arryplace[i]));
                        if (model != null)
                        {
                            sbPlace.Append("<a>" + model.navName + "报价</a>&gt;");
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                sbPlace.Append("<em>" + Line.LineName + "</em>");
            }
            else
            {
                TravelAgent.Model.Destination dest = DestBll.GetModel(Line.DestId);
                if (dest != null)
                {
                    sbPlace.Append("<a>" + dest.navName + "报价</a>&gt;");
                }

                sbPlace.Append("<em>" + Line.LineName + "</em>");
            }

            return sbPlace.ToString();
        }
        /// <summary>
        /// 显示行程详细内容
        /// </summary>
        /// <param name="lineId"></param>
        /// <returns></returns>
        public string ShowLine(TravelAgent.Model.Line line)
        {
            StringBuilder sb = new StringBuilder();
            if (line.EditModel == 0)
            {
                List<TravelAgent.Model.LineContent> lstLineContent = LineContentBll.GetlstLineContentByLineId(line.Id);
                TravelAgent.Model.LineContent content = null;
                for (int i = 0; i < lstLineContent.Count; i++)
                {
                    content = lstLineContent[i];
                    sb.Append("<div class=\"titcon\">");
                    sb.Append("<div class=\"titkey\">第<em>" + content.DaySort + "</em>天</div>");
                    sb.Append("<div class=\"titpic\">" + TravelAgent.Tool.CommonOprate.ShowLineTitle(content.Title) + "</div>");
                    sb.Append("</div>");
                    sb.Append("<div class=\"chizhu\">");
                    sb.Append("<p><span class=\"chi\" title=\"用餐\"></span><em><font class=\"hco\">早餐</font>-" + TravelAgent.Tool.CommonOprate.ShowCatering(content.Morn) + " ， <font class=\"hco\">中餐</font>-" + TravelAgent.Tool.CommonOprate.ShowCatering(content.Noon) + " ， <font class=\"hco\">晚餐</font>-" + TravelAgent.Tool.CommonOprate.ShowCatering(content.Night) + "</em></p>");
                    sb.Append("<p><span class=\"zhu\" title=\"住宿\"></span><em><font class=\"hco\">住宿：</font>" + content.Accom + "</em></p>");
                    sb.Append("</div>");
                    sb.Append("<div class=\"text\">");
                    sb.Append("<div class=\"text_tp\">");
                    sb.Append(content.Content);
                    sb.Append("</div>");
                    sb.Append("</div>");
                }
            }
            else
            {
                sb.Append(line.LineContent);
            }

            return sb.ToString();
        }
        /// <summary>
        /// 显示相关产品
        /// </summary>
        /// <param name="dest"></param>
        /// <returns></returns>
        public string ShowAboutLine(string dest, int destId, int top)
        {
            StringBuilder sbLine = new StringBuilder();
            string strWhere = "";
            if (!string.IsNullOrEmpty(dest))
            {
                string[] arryDest = dest.Split(',');
                foreach (string s in arryDest)
                {
                    strWhere += "dest like '%," + s + ",%' and ";
                }
                strWhere = strWhere + "isLock=0";
            }
            DataSet dsAboutLine = LineBll.GetList(top, strWhere, "Sort asc,adddate desc");
            if (dsAboutLine.Tables[0].Rows.Count == 0)
            {
                dsAboutLine = LineBll.GetList(top, "destId=" + destId + " and isLock=0", "Sort asc,adddate desc");
            }
            foreach (DataRow row in dsAboutLine.Tables[0].Rows)
            {
                sbLine.Append("<li>");
                //sbLine.Append("<a href=\"?id=" + row["Id"] + "\" target=\"_blank\"><img src=\"" + row["linePic"] + "\" alt=\"" + row["lineName"] + "\" />"+TravelAgent.Tool.StringPlus.LeftTrueLen(row["lineName"].ToString(),24,"")+"</a>");
                //urlrewrite
                sbLine.Append("<a href=\"/line/" + row["Id"] + ".html\" target=\"_blank\"><img src=\"" + row["linePic"] + "\" alt=\"" + row["lineName"] + "\" />" + TravelAgent.Tool.StringPlus.LeftTrueLen(row["lineName"].ToString(), 24, "") + "</a>");
                if (string.IsNullOrEmpty(row["priceContent"].ToString()))
                {
                    sbLine.Append("<span>电询</span>");
                }
                else
                {
                    sbLine.Append("<span>¥ " + row["priceContent"].ToString().Split(',')[2] + "</span>");
                }

                sbLine.Append("</li>");
            }
            return sbLine.ToString();
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
                                sbDate.Append("<option value=\"" + dttemp.ToString("yyyy-MM-dd") + "\" tag=\"" + strSpePrice + "\">" + dttemp.ToString("yyyy-MM-dd") + " （" + Day[dayValue] + "） " + arrySpePrice[0] + "元/成人," + arrySpePrice[1] + "元/儿童</option>");
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
        /// <summary>
        /// 返回咨询列表
        /// </summary>
        /// <returns></returns>
        public string ShowConsult()
        {
            StringBuilder sb = new StringBuilder();
            DataSet dscon = ConsultBll.GetList("LineId=" + LineModel.Id);
            foreach (DataRow row in dscon.Tables[0].Rows)
            {
                if (row["IsReply"].ToString().Equals("1"))
                {
                    sb.Append("<dl class=\"tw_zxbox\">");
                    sb.Append("<dt class=\"tw_zxwen\">");
                    sb.Append("<em>提问：</em>" + row["ConsultContent"] + "<span>2014-12-10</span>");
                    sb.Append("</dt>");
                    sb.Append("<dd class=\"tw_zxda\"><em>回复：</em>" + row["ReplyContent"] + "</dd>");
                    sb.Append("</dl>");
                }
            }
            return sb.ToString();
        }
    }
}
