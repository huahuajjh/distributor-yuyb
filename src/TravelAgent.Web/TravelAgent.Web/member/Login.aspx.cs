using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TravelAgent.Tool;
namespace TravelAgent.Web.member
{
    public partial class Login : TravelAgent.Web.UI.mBasePage
    {
        private static readonly TravelAgent.BLL.Club ClubBll = new TravelAgent.BLL.Club();
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Title = "会员登录-"+Master.webinfo.WebName;
            if (!this.IsPostBack)
            {
                if (Request["username"] != null && Request["password"] != null)
                {
                    string strUserName = StringPlus.FilterStr(Request["username"]);
                    string strPassWord = StringPlus.FilterStr(Request["password"]);

                    TravelAgent.Model.Club model = ClubBll.GetModel(strUserName, strPassWord);
                    if (model != null)
                    {
                        double day = 1.0;
                        if (Request["cooktime"] != null)
                        {
                            if (Request["cooktime"] == "1")
                            {
                                day = 7.0;
                            }
                        }
                        TravelAgent.Tool.CookieHelper.SetCookie("uid", model.id.ToString(), DateTime.Now.AddDays(day));
                        TravelAgent.Tool.CookieHelper.SetCookie("username", model.clubName, DateTime.Now.AddDays(day));
                        Response.Redirect("/member/Index.aspx");
                    }
                    else
                    {
                        Response.Redirect("/Opr.aspx?t=error&msg=login");
                    }
                }
               
            }
        }
    }
}
