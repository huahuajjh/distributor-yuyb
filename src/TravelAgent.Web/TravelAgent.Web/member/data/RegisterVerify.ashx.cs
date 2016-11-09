using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TravelAgent.Web.member.data
{
    /// <summary>
    /// $codebehindclassname$ 的摘要说明
    /// </summary>
    public class RegisterVerify : IHttpHandler
    {
        private static readonly TravelAgent.BLL.Club ClubBll = new TravelAgent.BLL.Club();
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string strTag = context.Request["tag"];
            if (strTag.Equals("code"))
            {
                //验证码
                if (context.Request["verify"] != null)
                {
                    if (context.Request["verify"] == TravelAgent.Tool.CookieHelper.GetCookieValue("yzm"))
                    {
                        context.Response.Write("true");
                    }
                    else
                    {
                        context.Response.Write("false");
                    }
                }
            }
            else if (strTag.Equals("email"))
            {
                //检测邮箱
                if (context.Request["email"] != null)
                {
                    if (ClubBll.GetCount("clubEmail='" + context.Request["email"] + "'") > 0)
                    {
                        context.Response.Write("true");
                    }
                    else
                    {
                        context.Response.Write("false");
                    }
                }
            }
            else if (strTag.Equals("mobile"))
            {
                //手机号码
                if (context.Request["mobile"] != null)
                {
                    if (ClubBll.GetCount("clubMobile='" + context.Request["mobile"] + "'") > 0)
                    {
                        context.Response.Write("true");
                    }
                    else
                    {
                        context.Response.Write("false");
                    }
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
