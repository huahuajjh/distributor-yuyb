using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TravelAgent.Web.dataDeal
{
    public partial class ValidateOrModifyMobile : TravelAgent.Web.UI.mBasePage
    {
        private static readonly TravelAgent.BLL.Club ClubBll = new TravelAgent.BLL.Club();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["mobile"] != null)
            {
                string strmobile = Request["mobile"];
                string strcode = Request["validateCode"];
                int clubid = Convert.ToInt32(Request["clubid"]);
                int count = ClubBll.GetCount("clubMobile='" + strmobile + "' and id<>" + clubid);
                if (count > 0)
                {
                    Response.Write("已经被注册");
                    Response.End();
                }
                if (strcode.Equals(TravelAgent.Tool.CookieHelper.GetCookieValue("smsyzm")))
                {
                    string strsql = "update Club set clubMobile='" + strmobile + "',mobileIsValid=1 where Id="+clubid;
                    //Access
                    //if (TravelAgent.Tool.DbHelperOleDb.ExecuteSql(strsql) > 0)
                    //SQL
                    if (TravelAgent.Tool.DbHelperSQL.ExecuteSql(strsql) > 0)
                    {
                        Response.Write("success");
                        Response.End();
                    }
                    else
                    {
                        Response.Redirect("/Opr.aspx?t=error&msg=opr");
                    }
                }
                else
                {
                    Response.Write("验证码");
                    Response.End();
                }
            }
        }
    }
}
