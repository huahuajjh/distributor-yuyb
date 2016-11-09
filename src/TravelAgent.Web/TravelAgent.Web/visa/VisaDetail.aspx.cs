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
    public partial class VisaDetail : System.Web.UI.Page
    {
        public TravelAgent.Model.VisaList visa;
        private static readonly TravelAgent.BLL.VisaBrand BrandBll = new TravelAgent.BLL.VisaBrand();
        private static readonly TravelAgent.BLL.Category CateBll = new TravelAgent.BLL.Category();
        private static readonly TravelAgent.BLL.VisaList VisaListBll = new TravelAgent.BLL.VisaList();

        protected void Page_Load(object sender, EventArgs e)
        {
            int id;
            if (!this.IsPostBack && int.TryParse(Request.QueryString["id"], out id))
            {
                visa = VisaListBll.GetModel(id);
                if (visa != null) this.Title = visa.visaName + "-" + Master.webinfo.WebName;
            }
            if (visa == null) { Response.Redirect("/Opr.aspx?t=error&msg=opr", false); visa = new Model.VisaList(); }
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
    }
}
