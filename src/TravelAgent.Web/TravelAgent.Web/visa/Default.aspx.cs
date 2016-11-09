using System;
using System.Text;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TravelAgent.Web.visa
{
    public partial class Default : System.Web.UI.Page
    {
        private static readonly TravelAgent.BLL.VisaBrand BrandBll = new TravelAgent.BLL.VisaBrand();
        private static readonly TravelAgent.BLL.Category CateBll = new TravelAgent.BLL.Category();
        private static readonly TravelAgent.BLL.Article ArticleBll = new TravelAgent.BLL.Article();
        private static readonly TravelAgent.BLL.VisaCountry CountryBll = new TravelAgent.BLL.VisaCountry();
        private static readonly TravelAgent.BLL.VisaType VisaTypeBll = new TravelAgent.BLL.VisaType();
        private static readonly TravelAgent.BLL.VisaList VisaListBll = new TravelAgent.BLL.VisaList();
        private static readonly TravelAgent.BLL.InfoSetting bll = new TravelAgent.BLL.InfoSetting();

        protected void Page_Load(object sender, EventArgs e)
        {
            this.Title = "签证办理_签证代办_出国签证查询及办理流程-" + Master.webinfo.WebName;
            Other.AddMeta(Page.Master.Page, "keywords", "签证代办，签证查询，签证办理");
            Other.AddMeta(Page.Master.Page, "description", "权威签证申请中心，拥有多年网上签证办理经验，方便的签证办理查询，详细说明办理费用及流程，拥有专业签证团队，为您解读2013出国签证各种问题。");
            if (!this.IsPostBack)
            {
                TravelAgent.Model.InfoSetting info = new TravelAgent.Model.InfoSetting();
                info.ds = bll.GetList();
                divZYSX.InnerHtml = info.getValue("VisaZYSX");
            }
        }
        /// <summary>
        /// 绑定基本信息设置
        /// </summary>
        /// <param name="type"></param>
        /// <param name="top"></param>
        /// <returns></returns>
        public string BindBrand(int type, int top)
        {
            StringBuilder sbBrand = new StringBuilder();
            DataSet dsBrand = BrandBll.GetList(top, "isLock=0 and Type=" + type, "Sort asc");
            DataRow row = null;
            for (int i = 0; i < dsBrand.Tables[0].Rows.Count; i++)
            {
                row = dsBrand.Tables[0].Rows[i];
                sbBrand.Append("<li class=\"visa_L_box_" + i + "\"><b>" + row["Title"] + "</b>" + row["SubTitle"] + "</li>");
                //sbBrand.Append("<li><i class=\"icon" + (i + 1) + "\"></i><strong>" + row["Title"] + "</strong><br>" + row["SubTitle"] + "</li>");
            }
            return sbBrand.ToString();
        }
        /// <summary>
        /// 绑定新闻
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public string BindNews(int type, int top)
        {
            StringBuilder sbNews = new StringBuilder();
            DataSet dsNews = ArticleBll.GetList(top, "ClassId=" + type, "Click asc,AddTime desc");
            foreach (DataRow row in dsNews.Tables[0].Rows)
            {
                //sbNews.Append("<li>·<a href=\"/New.aspx?nav=" + type + "&id=" + row["Id"] + "\" target=\"_blank\">" + row["Title"] + "</a></li>");
                //urlrewrite
                sbNews.Append("<li>·<a href=\"/new/" + type + "/" + row["Id"] + ".html\" target=\"_blank\">" + row["Title"] + "</a></li>");
            }
            return sbNews.ToString();
        }
        /// <summary>
        /// 签证帮助
        /// </summary>
        /// <returns></returns>
        public string BindVisaHelp(int type)
        {
            StringBuilder sbHelp = new StringBuilder();
            DataSet dsCate = CateBll.GetChannelListByParentId(type, null);
            foreach (DataRow row in dsCate.Tables[0].Rows)
            {
                sbHelp.Append("<li>·<a href=\"/Help.aspx?navid=" + type + "#help_" + row["Id"] + "\" rel=\"nofollow\">" + row["Title"] + "</a></li>");
            }
            return sbHelp.ToString();
        }
        /// <summary>
        /// 绑定签证列表
        /// </summary>
        /// <returns></returns>
        public string BindVisaList()
        {
            StringBuilder sbVisa = new StringBuilder();
            DataTable dtVisa = CountryBll.GetList(0, "isLock=0");
            DataRow[] dtFristRow = dtVisa.Select("ParentId=0");
            DataRow[] drTwoRow = null;
            foreach (DataRow row in dtFristRow)
            {
                sbVisa.Append("<dl class=\"visa_con\">");
                sbVisa.Append("<dt>" + row["Name"] + "</dt>");
                sbVisa.Append("<dd>");
                drTwoRow = dtVisa.Select("ParentId="+row["Id"]);
                foreach (DataRow r in drTwoRow)
                {
                    //sbVisa.Append("<a target=\"_blank\" href=\"/visa/VisaMore.aspx?countryid=" + r["Id"] + "\">" + r["Name"] + "</a>");
                    //urlrewrite
                    sbVisa.Append("<a target=\"_blank\" href=\"/visa_" + r["Id"] + ".html\">" + r["Name"] + "</a>");
                }
                sbVisa.Append("</dd>");
                sbVisa.Append("</dl>");
            }

            return sbVisa.ToString();
        }
        public string BindVisaDetail()
        {
            StringBuilder sbVisaDetail = new StringBuilder();
            DataSet dsType = VisaTypeBll.GetList("isLock=0");
            DataSet dsVisaList;
            string strPicUrl = "/images/no_image.gif";
            foreach (DataRow row in dsType.Tables[0].Rows)
            {
                sbVisaDetail.Append("<div class=\"qianzheng_box\">");
                sbVisaDetail.Append("<h3>"+row["Name"]+"</h3>");
                sbVisaDetail.Append("</div>");
                dsVisaList = VisaListBll.GetList(6, "isLock=0 and typeId="+row["Id"], "Sort asc,adddate desc");
                
                foreach (DataRow r in dsVisaList.Tables[0].Rows)
                {
                    sbVisaDetail.Append("<dl>");
                    if (!r["PicUrl"].Equals(""))
                    {
                        strPicUrl = r["PicUrl"].ToString();
                    }
                    //sbVisaDetail.Append("<dt><a target=\"_blank\" href=\"/visa/VisaDetail.aspx?id=" + r["Id"] + "\"><img alt=\"" + r["visaName"] + "\" src=\"" + strPicUrl + "\"></a></dt>");
                    //sbVisaDetail.Append("<dd><h4><a target=\"_blank\" href=\"/visa/VisaDetail.aspx?id=" + r["Id"] + "\">" + r["visaName"] + "</a></h4>");
                    //urlrewrite
                    sbVisaDetail.Append("<dt><a target=\"_blank\" href=\"/visa/" + r["Id"] + ".html\"><img alt=\"" + r["visaName"] + "\" src=\"" + strPicUrl + "\"></a></dt>");
                    sbVisaDetail.Append("<dd><h4><a target=\"_blank\" href=\"/visa/" + r["Id"] + ".html\">" + r["visaName"] + "</a></h4>");
                    if (r["price"].ToString().Equals("0") || r["price"].ToString().Equals(""))
                    {
                        sbVisaDetail.Append("<span>¥<b>电询</b></span>");
                    }
                    else
                    {
                        sbVisaDetail.Append("<span>¥<b>" + r["price"] + "</b></span>");
                    }
                    sbVisaDetail.Append("</dd>");
                    sbVisaDetail.Append("</dl>");
                }
            }
            return sbVisaDetail.ToString();
        }
    }
}
