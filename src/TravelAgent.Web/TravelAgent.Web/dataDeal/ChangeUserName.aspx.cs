using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TravelAgent.Web.dataDeal
{
    public partial class ChangeUserName : System.Web.UI.Page
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
                if (Request["username"] != null)
                {
                    string strsql = "update Club set clubName='" + Request["username"] + "' where Id=" + strUid;
                    //Access
                    //if (TravelAgent.Tool.DbHelperOleDb.ExecuteSql(strsql) > 0)
                    //SQL
                    if (TravelAgent.Tool.DbHelperSQL.ExecuteSql(strsql) > 0)
                    {
                        TravelAgent.Tool.CookieHelper.SetCookie("username", Request["username"]);
                        Response.Redirect("/member/UpdateSucMemberName.aspx?username="+Request["username"],false);
                    }
                    else
                    {
                        Response.Redirect("/Opr.aspx?t=error&msg=opr",false);
                    }
                }
                
             }
        }
    }
}
