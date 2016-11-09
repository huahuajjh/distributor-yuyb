using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TravelAgent.Web.visa
{
    public partial class VisaOrder : System.Web.UI.Page
    {
        public TravelAgent.Model.VisaList visa;
        public TravelAgent.Model.Club club;
        private static readonly TravelAgent.BLL.VisaList VisaListBll = new TravelAgent.BLL.VisaList();
        //private static readonly TravelAgent.BLL.VisaOrder VisaOrderBll = new TravelAgent.BLL.VisaOrder();
        private static readonly TravelAgent.BLL.Club ClubBll = new TravelAgent.BLL.Club();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                int id;
                int uid;
                if (int.TryParse(Request.QueryString["id"], out id))
                {
                    visa = VisaListBll.GetModel(id);
                    if (visa != null) this.Title = visa.visaName + "-" + Master.webinfo.WebName;
                }
                if (int.TryParse(TravelAgent.Tool.CookieHelper.GetCookieValue("uid"), out uid))
                {
                    club = ClubBll.GetModel(uid);
                }
            }
            if (visa == null) { Response.Redirect("/Opr.aspx?t=error&msg=opr", false); visa = new Model.VisaList(); }
            if (club == null) { Response.Redirect("/Opr.aspx?t=error&msg=opr", false); club = new Model.Club() ; }
        }
        /// <summary>
        /// 显示性别
        /// </summary>
        /// <returns></returns>
        public string ShowOptionSex()
        {
            string stroption = "<option selected=\"selected\" value=\"1\">男</option><option value=\"0\">女</option>";
            if (club != null)
            {
                if (club.clubSex.Equals(""))
                {
                    if (club.clubSex.Equals("0"))
                    {
                        stroption = "<option value=\"1\">男</option><option selected=\"selected\" value=\"0\">女</option>";
                    }
                }
            }
            return stroption;
        }
    }
}
