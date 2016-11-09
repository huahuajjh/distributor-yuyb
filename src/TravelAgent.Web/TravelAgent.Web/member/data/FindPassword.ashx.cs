using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TravelAgent.Web.member.data
{
    /// <summary>
    /// $codebehindclassname$ 的摘要说明
    /// </summary>
    public class FindPassword : IHttpHandler
    {
        private static readonly TravelAgent.BLL.Club clubBll = new TravelAgent.BLL.Club();
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string strTag = context.Request["tag"];
            if (strTag.Equals("email"))
            {
                int count = clubBll.GetCount("clubEmail='" + context.Request["email"] + "' and isLock=0");
                //验证码
                if (count > 0)
                {
                    context.Response.Write("true");
                }
                else
                {
                    context.Response.Write("false");
                }
            }
            else if (strTag.Equals("mobile"))
            {
                int count = clubBll.GetCount("clubMobile='" + context.Request["mobile"] + "' and isLock=0");
                //验证码
                if (count > 0)
                {
                    context.Response.Write("true");
                }
                else
                {
                    context.Response.Write("false");
                }
            }
            else if (strTag.Equals("code"))//短信验证码
            {
                string strcode = context.Request["txtValidator"];
                var sms = TravelAgent.Tool.CookieHelper.GetCookieValue("smsyzm");
                if (string.IsNullOrEmpty(sms))
                {
                    context.Response.Write("false");
                }
                else
                {
                    if (strcode.Equals(sms))
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
