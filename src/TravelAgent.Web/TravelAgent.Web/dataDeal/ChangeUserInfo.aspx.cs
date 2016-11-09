using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TravelAgent.Web.dataDeal
{
    public partial class ChangeUserInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
             string strUid = TravelAgent.Tool.CookieHelper.GetCookieValue("uid");
             if (string.IsNullOrEmpty(strUid))
             {
                 Response.Redirect("/member/Login.aspx");
             }
             else
             {
                 if (Request["realname"] != null)
                 {
                     string strsql = "update Club set trueName='" + Request["realname"] + "',clubSex='" + Request["sex"] + "',clubBirthday='" + Request["birthday"] + "' where Id="+strUid;
                     //Access
                     //if (TravelAgent.Tool.DbHelperOleDb.ExecuteSql(strsql) > 0)
                     //SQL
                     if (TravelAgent.Tool.DbHelperSQL.ExecuteSql(strsql) > 0)
                     {
                         Response.Redirect("/Opr.aspx?t=success&msg="+Server.UrlEncode("修改成功！"),false);
                     }
                     else
                     {
                         Response.Redirect("/Opr.aspx?t=error&msg=opr", false);
                     }
                 }
             }
        }
    }
}
