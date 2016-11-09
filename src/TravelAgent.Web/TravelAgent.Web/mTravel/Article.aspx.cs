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
    public partial class Article : TravelAgent.Web.UI.mBasePage
    {
        public string strtitle;
        public string strcontent;
        private static readonly TravelAgent.BLL.Category CateBll = new TravelAgent.BLL.Category();
        private static readonly TravelAgent.BLL.Article ArticleBll = new TravelAgent.BLL.Article();
        protected void Page_Load(object sender, EventArgs e)
        {
            int id;
            if (int.TryParse(Request.QueryString["id"], out id))
            {
                //article = ArticleBll.GetModel(Convert.ToInt32(Request.QueryString["id"]));
                DataSet dsArticle = ArticleBll.GetList(1, "IsLock=0 and ClassId=" + id.ToString(), "Click asc,AddTime desc");
                if (dsArticle.Tables[0].Rows.Count > 0)
                {
                    strtitle = dsArticle.Tables[0].Rows[0]["Title"].ToString();
                    strcontent= dsArticle.Tables[0].Rows[0]["Content"].ToString();
                }
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
    }
}
