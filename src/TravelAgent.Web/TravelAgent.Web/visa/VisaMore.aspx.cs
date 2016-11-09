using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TravelAgent.Web.visa
{
    public partial class VisaMore : System.Web.UI.Page
    {
        public int countryid;
        public string strPicUrl;
        public string strVisaName;
        private static readonly TravelAgent.BLL.VisaBrand BrandBll = new TravelAgent.BLL.VisaBrand();
        private static readonly TravelAgent.BLL.InfoSetting bll = new TravelAgent.BLL.InfoSetting();
        private static readonly TravelAgent.BLL.Category CateBll = new TravelAgent.BLL.Category();
        private static readonly TravelAgent.BLL.VisaList VisaListBll = new TravelAgent.BLL.VisaList();
        private static readonly TravelAgent.BLL.VisaCountry CountryBll = new TravelAgent.BLL.VisaCountry();

        protected void Page_Load(object sender, EventArgs e)
        {
            int.TryParse(Request.QueryString["countryid"], out countryid);
            if (!this.IsPostBack)
            {
                TravelAgent.Model.InfoSetting info = new TravelAgent.Model.InfoSetting();
                info.ds = bll.GetList();
                divZYSX.InnerHtml = info.getValue("VisaZYSX");
                if (countryid > 0)
                {
                    TravelAgent.Model.VisaCountry country = CountryBll.GetModel(countryid);
                    if (country != null)
                    {
                        strPicUrl = country.PicUrl;
                        strVisaName = country.Name;
                        this.Title = country.Name + "签证-" + Master.webinfo.WebName;
                    }
                    
                }
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
            StringBuilder sbVisaList = new StringBuilder();
            DataSet dsVisa = VisaListBll.GetList(0, "isLock=0 and countryId=" + countryid, "Sort asc,adddate desc");
            foreach (DataRow row in dsVisa.Tables[0].Rows)
            {
                sbVisaList.Append("<dl class=\"visa_content\">");
                //sbVisaList.Append("<dt class=\"visa_content_pic\"><a target=\"_blank\" href=\"/visa/VisaDetail.aspx?id=" + row["Id"] + "\"><img src=\"" + row["PicUrl"] + "\"></a></dt>");
                //urlrewrite
                sbVisaList.Append("<dt class=\"visa_content_pic\"><a target=\"_blank\" href=\"/visa/" + row["Id"] + ".html\"><img src=\"" + row["PicUrl"] + "\"></a></dt>");
                sbVisaList.Append("<dd class=\"visa_content_txt\">");
                //sbVisaList.Append("<p><a target=\"_blank\" href=\"/visa/VisaDetail.aspx?id=" + row["Id"] + "\">" + row["visaName"] + "</a></p>");
                //urlrewrite
                sbVisaList.Append("<p><a target=\"_blank\" href=\"/visa/" + row["Id"] + ".html\">" + row["visaName"] + "</a></p>");
                sbVisaList.Append("<p>签证有效期：" + row["expiryDate"] + "</p>");
                sbVisaList.Append("<p>最长停留时间：" + row["stayTime"] + "</p>");
                sbVisaList.Append("</dd>");
                sbVisaList.Append("<dd class=\"visa_content_shichang\">办理时长：" + row["dealTime"] + "</dd>");
                sbVisaList.Append("<dd class=\"visa_jiage\">");
                if (row["price"].ToString().Equals("0"))
                {
                    sbVisaList.Append("<p><b>电询</b></p>");
                }
                else
                {
                    sbVisaList.Append("<p><i>¥</i><b>"+row["price"]+"</b></p>");
                }
                //sbVisaList.Append("<p><a title=\"立刻预订\" href=\"/visa/VisaDetail.aspx?id=" + row["Id"] + "\" rel=\"nofollow\"></a></p>");
                //urlrewrite
                sbVisaList.Append("<p><a title=\"立刻预订\" href=\"/visa/" + row["Id"] + ".html\" rel=\"nofollow\"></a></p>");
                sbVisaList.Append("</dd>");
                sbVisaList.Append("</dl>");
            }

            return sbVisaList.ToString();
        }
    }
}
