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
    public partial class LineTheme : TravelAgent.Web.UI.mBasePage
    {
        private static readonly TravelAgent.BLL.LineTheme ThemeBll = new TravelAgent.BLL.LineTheme();
        private static readonly TravelAgent.BLL.Category CateBll = new TravelAgent.BLL.Category();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 绑定
        /// </summary>
        /// <returns></returns>
        public string BindTheme()
        {
            StringBuilder sbTheme = new StringBuilder();
            DataSet dsTheme = ThemeBll.GetList("isLock=0");
            DataRow row=null;
            for (int i = 1; i <= dsTheme.Tables[0].Rows.Count; i++)
            {
                row=dsTheme.Tables[0].Rows[i-1];
                if (i % 2 == 0)
                {
                    sbTheme.Append("<a href=\"ThemeList.aspx?thid=" + row["Id"] + "&thname=" + row["themeName"] + "\" class=\"home_link_a\">");
                    sbTheme.Append("<div class=\"home_link_box mgrt b"+i+"\">");
                    sbTheme.Append("<es></es>");
                    sbTheme.Append("<label>" + row["themeName"] + "</label>");
                    sbTheme.Append("</div>");
                    sbTheme.Append("</a>");
                    if (dsTheme.Tables[0].Rows.Count % 2 == 1)
                    {
                        sbTheme.Append("</div>");
                    }
                }
                else
                {
                    sbTheme.Append("<div class=\"home_link_li\">");
                    sbTheme.Append("<a href=\"ThemeList.aspx?thid=" + row["Id"] + "&thname=" + row["themeName"] + "\" class=\"home_link_a\">");
                    sbTheme.Append("<div class=\"home_link_box mgrt b"+i+"\">");
                    sbTheme.Append("<es></es>");
                    sbTheme.Append("<label>" + row["themeName"] + "</label>");
                    sbTheme.Append("</div>");
                    sbTheme.Append("</a>");
                    if (dsTheme.Tables[0].Rows.Count== 1)
                    {
                        sbTheme.Append("</div>");
                    }
                }

                
                
            }
            return sbTheme.ToString();
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
