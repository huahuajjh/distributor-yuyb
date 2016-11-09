using System;
using System.Text;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TravelAgent.Web
{
    public partial class Help : System.Web.UI.Page
    {
        public int navId;
        private static readonly TravelAgent.BLL.Category CateBll = new TravelAgent.BLL.Category();
        private static readonly TravelAgent.BLL.Article ArticleBll = new TravelAgent.BLL.Article();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Request.QueryString["navid"]!=null)
            {
                navId = Convert.ToInt32(Request.QueryString["navid"]);
            }
            if (!this.IsPostBack)
            {
                if (navId > 0)
                {
                    TravelAgent.Model.Category cate = CateBll.GetModel(navId);
                    if (cate != null)
                    {
                        StringBuilder sbContent = new StringBuilder();
                        this.ltTitle.Text = cate.Title;
                        this.Title = cate.Title + "-" + Master.webinfo.WebName;
                        DataSet dsCate = CateBll.GetChannelListByParentId(cate.Id, null);
                        DataRow row = null;
                        DataSet dsContent = null;
                        for (int i = 0; i < dsCate.Tables[0].Rows.Count; i++)
                        {
                            row = dsCate.Tables[0].Rows[i];
                            sbContent.Append("<em id=\"help_"+row["Id"]+"\">"+(i+1)+"."+row["Title"]+"</em>");
                            dsContent=ArticleBll.GetList(1, "IsLock=0 and ClassId=" + row["Id"], "Click asc,AddTime desc");
                            if (dsContent.Tables[0].Rows.Count>0)
                            {
                                sbContent.Append("<p>"+ dsContent.Tables[0].Rows[0]["Content"].ToString()+"</p>");
                            }
                        }
                        this.divContent.InnerHtml = sbContent.ToString();
                    }
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
            DataSet dsCate = CateBll.GetChannelListByParentId(type, null);
            //DataRow[] drFrist = dsCate.Select("ParentId=3 and State=0", "ClassOrder asc");
            string strurl = "";
            foreach (DataRow row in dsCate.Tables[0].Rows)
            {
                strurl = row["PageUrl"].ToString();
                if (strurl.Equals(""))
                {
                    strurl = "?navid=" + row["Id"];
                }
                if (Convert.ToInt32(row["Id"]).Equals(navId))
                {
                    sbCategory.Append("<li class=\"hover\"><em><a href=\""+strurl+"\">"+row["Title"]+"</a></em><span>›</span></li>");
                }
                else
                {
                    sbCategory.Append("<li><em><a href=\"" + strurl + "\">" + row["Title"] + "</a></em><span>›</span></li>");
                }
            }
            return sbCategory.ToString();
        }
    }
}
