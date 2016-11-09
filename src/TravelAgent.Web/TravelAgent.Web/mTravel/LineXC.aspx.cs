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
    public partial class LineXC : TravelAgent.Web.UI.mBasePage
    {
        private static readonly TravelAgent.BLL.Line LineBll = new TravelAgent.BLL.Line();
        private static readonly TravelAgent.BLL.Category CateBll = new TravelAgent.BLL.Category();
        private static readonly TravelAgent.BLL.LineContent LineContentBll = new TravelAgent.BLL.LineContent();
        public TravelAgent.Model.Line Line;
        protected void Page_Load(object sender, EventArgs e)
        {
            int id;
            if (Request.QueryString["id"] != null && int.TryParse(Request.QueryString["id"], out id))
            {
                Line = LineBll.GetModel(id);
            }
            if(Line == null)
            {
                Response.Redirect("/Opr.aspx?t=error&msg=opr");
            }
        }

        /// <summary>
        /// 绑定行程
        /// </summary>
        /// <returns></returns>
        public string BindLineXC()
        {
            StringBuilder sb = new StringBuilder();
            List<TravelAgent.Model.LineContent> lstLineContent = LineContentBll.GetlstLineContentByLineId(Line.Id);
            TravelAgent.Model.LineContent content = null;
            for (int i = 0; i < lstLineContent.Count; i++)
            {
                content = lstLineContent[i];
                sb.Append("<div class=\"threeBox_trip\">");
                sb.Append("<div class='days'>");
                sb.Append("<strong>第 " + content.DaySort + " 天</strong>");
                sb.Append("<span>" + TravelAgent.Tool.CommonOprate.ShowLineTitle(content.Title) + "</span>");
                sb.Append("</div>");
                sb.Append("<div class=\"chis\">");
                sb.Append("<span>用餐：</span>");
                sb.Append("早-" + TravelAgent.Tool.CommonOprate.ShowCatering(content.Morn) + "； 中-" + TravelAgent.Tool.CommonOprate.ShowCatering(content.Noon) + "； 晚-" + TravelAgent.Tool.CommonOprate.ShowCatering(content.Night) + "");
                sb.Append("</div>");
                sb.Append("<div class=\"zhus\">");
                sb.Append("<span>住宿：</span>");
                sb.Append(content.Accom);
                sb.Append("</div>");
                sb.Append("<div class='cons'>");
                sb.Append(content.Content);
                sb.Append("</div>");
                sb.Append("</div>");
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
    }
}
