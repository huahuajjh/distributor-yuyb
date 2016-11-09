using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using TravelAgent.BLL;
using TravelAgent.Model;
using TravelAgent.Tool;
namespace TravelAgent.Web.admin.data
{
    /// <summary>
    /// $codebehindclassname$ 的摘要说明
    /// </summary>
    public class Admin : IHttpHandler, IRequiresSessionState
    {
        int login_error_num = 0;
        private static readonly TravelAgent.BLL.AdminList adminbll = new TravelAgent.BLL.AdminList();
        public void ProcessRequest(HttpContext context)
        {
            if (context.Request["user_name"] != null)
            {
                string strUserName = StringPlus.Filter(context.Request["user_name"]);
                string strUserPwd = StringPlus.Filter(context.Request["user_pwd"]);
                int remember = Convert.ToInt32(context.Request["check"]);
                TravelAgent.Model.AdminList Account = adminbll.GetAccountByUser(strUserName, strUserPwd);
                if (Account != null)
                {
                    if (Account.IsLock == 0)
                    {
                        string strUrl = "Admin_Default.aspx";
                      
                        context.Response.Write("{\"msg\":\"true\",\"location\":\"" + strUrl + "\"}");
                        context.Session["LoginUser"] = Account;
                        TravelAgent.Tool.CookieHelper.ClearCookie("login_num");
                        //记住用户名和密码并自动登录
                        if (remember == 1)
                        {
                            TravelAgent.Tool.CookieHelper.SetCookie("loginname", strUserName);
                            TravelAgent.Tool.CookieHelper.SetCookie("loginpwd", strUserPwd);
                            TravelAgent.Tool.CookieHelper.SetCookie("isremember", remember.ToString());
                        }
                        else
                        {
                            TravelAgent.Tool.CookieHelper.ClearCookie("loginname");
                            TravelAgent.Tool.CookieHelper.ClearCookie("loginpwd");
                            TravelAgent.Tool.CookieHelper.ClearCookie("isremember");
                        }
                    }
                    else
                    {
                        context.Response.Write("{\"msg\":\"islock\",\"location\":\"\"}");
                    }
                }
                else
                {
                    context.Response.Write("{\"msg\":\"false\",\"location\":\"\"}");
                    login_error_num = string.IsNullOrEmpty(TravelAgent.Tool.CookieHelper.GetCookieValue("login_num"))? 0 : Convert.ToInt32(TravelAgent.Tool.CookieHelper.GetCookieValue("login_num"));
                    TravelAgent.Tool.CookieHelper.ClearCookie("login_num");
                    TravelAgent.Tool.CookieHelper.SetCookie("login_num", (login_error_num + 1).ToString());
                }
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}
