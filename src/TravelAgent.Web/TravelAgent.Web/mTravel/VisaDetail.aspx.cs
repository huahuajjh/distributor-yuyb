using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TravelAgent.Web.mTravel
{
    public partial class VisaDetail : TravelAgent.Web.UI.mBasePage
    {
        public TravelAgent.Model.VisaList Visa;
        private static readonly TravelAgent.BLL.VisaList VisaBll = new TravelAgent.BLL.VisaList();
        private static readonly TravelAgent.BLL.VisaType TypeBll = new TravelAgent.BLL.VisaType();
        private static readonly TravelAgent.BLL.Category CateBll = new TravelAgent.BLL.Category();
        protected void Page_Load(object sender, EventArgs e)
        {
            int id;
            if (Request.QueryString["id"] != null && int.TryParse(Request.QueryString["id"], out id))
            {
                Visa = VisaBll.GetModel(id);
            }
            if(Visa == null) Response.Redirect("/Opr.aspx?t=error&msg=opr");
        }
        /// <summary>
        /// 显示签证类型
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public string ShowTypeName(int type)
        {
            string strvalue = "";

            TravelAgent.Model.VisaType vt = TypeBll.GetModel(type);

            if (vt != null)
            {
                strvalue = vt.Name;
            }

            return strvalue;
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
