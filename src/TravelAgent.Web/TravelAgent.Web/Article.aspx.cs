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
    public partial class Article : System.Web.UI.Page
    {
        public int navId;
        private static readonly TravelAgent.BLL.Article ArticleBll = new TravelAgent.BLL.Article();
        private static readonly TravelAgent.BLL.Category CateBll = new TravelAgent.BLL.Category();
        protected void Page_Load(object sender, EventArgs e)
        {
            int.TryParse(Request.QueryString["navid"], out navId);
            if (!this.IsPostBack)
            {
                if (navId > 0)
                {
                    TravelAgent.Model.Category cate = CateBll.GetModel(navId);
                    if (cate != null)
                    {
                        this.ltTitle.Text = cate.Title;
                        this.Title = cate.Title + "-" + Master.webinfo.WebName;
                        DataSet dsArticle = ArticleBll.GetList(1, "IsLock=0 and ClassId=" + cate.Id, "Click asc,AddTime desc");
                        if (dsArticle.Tables[0].Rows.Count > 0)
                        { 
                            this.divContent.InnerHtml = dsArticle.Tables[0].Rows[0]["Content"].ToString();
                        }
                    }
                }
                else
                {
                    this.Title = Master.webinfo.WebName;
                }
            }
        }
        /// <summary>
        /// 绑定目录
        /// </summary>
        /// <returns></returns>
        public string BindCategory(int type)
        {
            StringBuilder sbCategory = new StringBuilder();
            DataSet dsCate = CateBll.GetChannelListByParentId(type,null);
            //DataRow[] drFrist = dsCate.Select("ParentId=3 and State=0", "ClassOrder asc");
            string strurl = "";
            foreach (DataRow row in dsCate.Tables[0].Rows)
            {
                strurl = row["PageUrl"].ToString();
                if (strurl.Equals(""))
                {
                    strurl = "/article/" + row["Id"]+".html";
                }
                if (Convert.ToInt32(row["Id"]).Equals(navId))
                {
                    sbCategory.Append("<li class=\"current\"><a href=\"" + strurl + "\">" + row["Title"] + "</a></li>");
                }
                else
                {
                    sbCategory.Append("<li><a href=\"" + strurl + "\">" + row["Title"] + "</a></li>");
                }
            }
            return sbCategory.ToString();
        }
    }
}
