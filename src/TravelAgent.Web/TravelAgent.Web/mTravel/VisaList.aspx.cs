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
    public partial class VisaList : TravelAgent.Web.UI.mBasePage
    {
        public int typeid;
        public int countryId;
        public string strTypeName;
        public string strKeyName;
        public int pcount;
        private static readonly TravelAgent.BLL.Category CateBll = new TravelAgent.BLL.Category();
        private static readonly TravelAgent.BLL.VisaType TypeBll = new TravelAgent.BLL.VisaType();
        private static readonly TravelAgent.BLL.VisaList VisaBll = new TravelAgent.BLL.VisaList();
        private static readonly TravelAgent.BLL.VisaCountry CountryBll = new TravelAgent.BLL.VisaCountry();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["typeid"] != null && int.TryParse(Request.QueryString["typeid"], out typeid))
            {
                TravelAgent.Model.VisaType VisaType = TypeBll.GetModel(typeid);
                strTypeName = VisaType!=null?VisaType.Name:"";
            }
            if (Request.QueryString["keyword"] != null)
            {
                strKeyName = Request.QueryString["keyword"];
            }
            int.TryParse(Request.QueryString["countryId"], out countryId);
        }
        /// <summary>
        /// 绑定签证列表
        /// </summary>
        /// <returns></returns>
        public string BindVisaList()
        {
            StringBuilder sbVisaList = new StringBuilder();
            string strWhere="isLock=0";
            if (typeid > 0)
            {
                strWhere += " and typeId=" + typeid;
            }
            if (strKeyName != "")
            {
                strWhere += " and visaName like '%"+strKeyName+"%'";
            }
            if (countryId > 0)
            {
                strWhere += " and countryId=" + countryId;
            }
            DataSet dsVisa = VisaBll.GetList(0, strWhere, "Sort asc,adddate desc");
            //pcount = dsVisa.Tables[0].Rows.Count;
            //this.ltcount.Text = dsVisa.Tables[0].Rows.Count.ToString();
            foreach (DataRow row in dsVisa.Tables[0].Rows)
            {
                sbVisaList.Append("<li>");
                sbVisaList.Append("<a href=\"VisaDetail.aspx?id="+row["Id"]+"\" >");
                sbVisaList.Append("<div class=\"m-img\"><img src=\"" + row["PicUrl"] + "\" width=\"90px\" height=\"60px\" class=\"tag_icon gw\" /></div>");
                sbVisaList.Append("<div class=\"m-c\">");
                sbVisaList.Append("<div class=\"m-c-bg\">");
                sbVisaList.Append("<p><code>" + row["visaName"] + "</code></p>");
                sbVisaList.Append("<p class=\"m-c-txt\">");
                sbVisaList.Append("<span> <em class=\"c-0\">" + row["stayTime"] + "</em></span>");
                if (!row["price"].ToString().Equals("") || !row["price"].ToString().Equals("0"))
                {
                    sbVisaList.Append("<strong> <i>￥</i>" + row["price"] + "<em class=\"co-1\">元/人</em> </strong>");
                }
                else
                {
                    sbVisaList.Append("<strong><em class=\"co-1\">电询</em> </strong>");
                }
                sbVisaList.Append("</p>");
                sbVisaList.Append(" </div>");
                sbVisaList.Append("</div>");
                sbVisaList.Append("</a>");
                sbVisaList.Append("</li>");
            }
            return sbVisaList.ToString();
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
