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
    public partial class VisaModel : TravelAgent.Web.UI.mBasePage
    {
        private static readonly TravelAgent.BLL.Category CateBll = new TravelAgent.BLL.Category();
        private static readonly TravelAgent.BLL.VisaList VisaBll = new TravelAgent.BLL.VisaList();
        private static readonly TravelAgent.BLL.VisaType TypeBll = new TravelAgent.BLL.VisaType();
        private static readonly TravelAgent.BLL.VisaCountry CountryBll = new TravelAgent.BLL.VisaCountry();
        protected void Page_Load(object sender, EventArgs e)
        {

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
        /// 绑定热卖签证
        /// </summary>
        /// <returns></returns>
        public string BindTuijian(int top)
        {
            StringBuilder sbTuijian = new StringBuilder();
            string strWhere = "CHARINDEX('," + Convert.ToInt32(TravelAgent.Tool.EnumSummary.State.热卖) + ",',State)>0 and isLock=0";
            DataSet dsVisa = VisaBll.GetList(top, strWhere, "Sort asc,adddate desc");
            foreach(DataRow row in dsVisa.Tables[0].Rows)
            {
                sbTuijian.Append("<li>");
                sbTuijian.Append("<a href=\"VisaDetail.aspx?id="+row["Id"]+"\">");
                sbTuijian.Append("<div class=\"visa-box\">");
                sbTuijian.Append("<div class=\"img-box\">");
                sbTuijian.Append("<img src=\"" + row["PicUrl"] + "\" />");
                sbTuijian.Append("</div>");
                sbTuijian.Append("<h2 class=\"country\">"+CountryBll.GetModel(Convert.ToInt32(row["countryId"])).Name+"</h2>");
                sbTuijian.Append("<h2 class=\"country\" style=\"margin-top: 0\">" + TypeBll.GetModel(Convert.ToInt32(row["typeId"])).Name+ "</h2>");
                sbTuijian.Append("<h4>￥<span class=\"big-price\">" + row["price"] + "</span></h4>");
                sbTuijian.Append("</div>");
                sbTuijian.Append("</a>");
                sbTuijian.Append("</li>");
            }
            return sbTuijian.ToString();
        }
        /// <summary>
        /// 绑定更多签证
        /// </summary>
        /// <returns></returns>
        public string BindMoreVisa()
        {
            StringBuilder sbVisa = new StringBuilder();
            DataSet dsVisaType = TypeBll.GetList("isLock=0");
            DataSet dsVisa = null;
            foreach (DataRow row in dsVisaType.Tables[0].Rows)
            {
                //sbVisa.Append("<div class=\"gy_tit\">");
                //sbVisa.Append("<em>" + row["Name"] + "</em>");
                //sbVisa.Append("</div>");
                sbVisa.Append("<div style=\" height:10px; background-color:#ffffff; width:100%\"></div>");
                sbVisa.Append("<h1 class=\"line-tit\"><em class=\"c-0\"></em>" + row["Name"] + "<a href=\"VisaList.aspx?typeid="+row["Id"]+"\">更多></a></h1>");
                dsVisa = VisaBll.GetList(6, "CHARINDEX('," + Convert.ToInt32(TravelAgent.Tool.EnumSummary.State.推荐) + ",',State)>0 and isLock=0 and typeId=" + row["Id"], "Sort asc,adddate desc");
                if (dsVisa.Tables[0].Rows.Count > 0)
                {
                    sbVisa.Append("<ul class=\"visa-list\">");
                    for (int i = 1; i <= dsVisa.Tables[0].Rows.Count; i++)
                    {
                        sbVisa.Append("<li class=\"left-li\">");
                        sbVisa.Append("<a href=\"VisaDetail.aspx?id=" + dsVisa.Tables[0].Rows[i-1]["Id"] + "\">");
                        sbVisa.Append("<div class=\"visa-box\">");
                        sbVisa.Append("<div class=\"img-box\">");
                        sbVisa.Append("<img src=\"" + dsVisa.Tables[0].Rows[i-1]["PicUrl"] + "\" />");
                        sbVisa.Append("</div>");
                        sbVisa.Append("<h2 class=\"country\">" + CountryBll.GetModel(Convert.ToInt32(dsVisa.Tables[0].Rows[i-1]["countryId"])).Name + "</h2>");
                        //sbVisa.Append("<h2 class=\"country\" style=\"margin-top: 0\">" + TypeBll.GetModel(Convert.ToInt32(row["typeId"])).Name + "</h2>");
                        sbVisa.Append("<h4>￥<span class=\"big-price\">" + dsVisa.Tables[0].Rows[i-1]["price"] + "</span></h4>");
                        sbVisa.Append("</div>");
                        sbVisa.Append("</a>");
                        sbVisa.Append("</li>");
                        if (i % 3 == 0)
                        {
                            sbVisa.Append("<div style=\"clear: both\"></div>");
                        }
                    }
                    sbVisa.Append("</ul>");
                }
            }
            return sbVisa.ToString();
        }
        
        /// <summary>
        /// 绑定导航
        /// </summary>
        /// <returns></returns>
        public string BindNav()
        {
            StringBuilder sbDest = new StringBuilder();
            DataTable dtDest = CountryBll.GetList(0, "isLock=0");
            DataRow[] FristRows = dtDest.Select("ClassLayer=1", "Sort asc");
            DataRow row = null;
            for (int i = 0; i < FristRows.Length; i++)
            {
                row = FristRows[i];
                sbDest.Append("<li>");
                sbDest.Append("<em>");
                sbDest.Append("<a href=\"#\">" + row["Name"] + "</a>");
                sbDest.Append("<span class=\"robtn\"></span>");
                sbDest.Append("</em>");
                sbDest.Append("<div class=\"rocon\">");
                DataRow[] destRows = dtDest.Select("isLock=0 and ParentId=" + row["Id"], "Sort asc");
                foreach (DataRow r in destRows)
                {
                    sbDest.Append("<a href=\"VisaList.aspx?countryId=" + r["Id"] + "\">" + r["Name"] + "</a>");
                }
                sbDest.Append("</div>");
                sbDest.Append("</li>");
            }
            return sbDest.ToString();
        }
    }
}
