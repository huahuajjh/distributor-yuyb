using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TravelAgent.Web.dataDeal
{
    public partial class CheckUserName : System.Web.UI.Page
    {
        private static readonly TravelAgent.BLL.Club ClubBll = new TravelAgent.BLL.Club();
        protected void Page_Load(object sender, EventArgs e)
        {
             string strUid = TravelAgent.Tool.CookieHelper.GetCookieValue("uid");
             if (string.IsNullOrEmpty(strUid))
             {
                 Response.Redirect("/member/Login.aspx");
             }
             else
             {
                 if (Request["name"] != null)
                 {
                     int count = ClubBll.GetCount("clubName='" + Request["name"] + "'");
                     if (count > 0)
                     {
                         Response.Write("has");
                     }
                     else
                     {
                         Response.Write("");
                     }
                 }
             }
        }
    }
}
