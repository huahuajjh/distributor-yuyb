using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TravelAgent.Web.dataDeal
{
    public partial class PassWord : System.Web.UI.Page
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
                 TravelAgent.Model.Club club = ClubBll.GetModel(Convert.ToInt32(strUid));
                 if (Request["txtOldPassword"] != null)
                 {
                     if (!club.clubPwd.Equals(Request["txtOldPassword"]))
                     {
                         Response.Redirect("/Opr.aspx?t=error&msg="+Server.UrlEncode("原密码错误！"));
                     }
                     string strnewPassword = Request["txtPassword"];
                     string strsql = "update Club set clubPwd='"+strnewPassword+"' where Id="+club.id;
                     //Access
                     //if (TravelAgent.Tool.DbHelperOleDb.ExecuteSql(strsql) > 0)
                     //SQL
                     if (TravelAgent.Tool.DbHelperSQL.ExecuteSql(strsql) > 0)
                     {
                         Response.Redirect("/Opr.aspx?t=success&msg=" + Server.UrlEncode("密码修改成功！"));
                     }
                     else
                     {
                         Response.Redirect("/Opr.aspx?t=error&msg=opr");
                     }
                 }
             }
            
        }
    }
}
