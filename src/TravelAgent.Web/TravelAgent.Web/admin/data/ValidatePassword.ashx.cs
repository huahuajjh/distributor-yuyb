using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using TravelAgent.BLL;
using TravelAgent.Model;

namespace TravelAgent.Web.admin.data
{
    /// <summary>
    /// $codebehindclassname$ 的摘要说明
    /// </summary>
    public class ValidatePassword : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            if (context.Request["password"] != null)
            {
                if (context.Request["password"].ToString().Equals(((TravelAgent.Model.AdminList)context.Session["LoginUser"]).UserPwd))
                {
                    context.Response.Write("true");
                }
                else
                {
                    context.Response.Write("false");
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
