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
    public class UpdatePassword : IHttpHandler, IRequiresSessionState
    {
        private static readonly TravelAgent.BLL.AdminList AdminBll = new TravelAgent.BLL.AdminList();
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            if (context.Request["pwd"] != null)
            {
                TravelAgent.Model.AdminList curAcc = (TravelAgent.Model.AdminList)context.Session["LoginUser"];
                curAcc.UserPwd = context.Request["pwd"];
                if (AdminBll.Update(curAcc) > 0)
                {
                    context.Session["LoginUser"] = curAcc;
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
