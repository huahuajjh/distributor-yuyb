using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TravelAgent.Web.member
{
    public partial class MobileValidate : System.Web.UI.Page
    {
        public TravelAgent.Model.Club club;
        private static readonly TravelAgent.BLL.Club clubBll = new TravelAgent.BLL.Club();
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Title = "手机验证-" + Master.webinfo.WebName;
            string strUid = TravelAgent.Tool.CookieHelper.GetCookieValue("uid");
            if (string.IsNullOrEmpty(strUid))
            {
                Response.Redirect("/member/Login.aspx");
            }
            else
            {
                club = clubBll.GetModel(Convert.ToInt32(strUid));
            }
        }
    }
}
