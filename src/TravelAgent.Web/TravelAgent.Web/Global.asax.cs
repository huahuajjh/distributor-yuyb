using NLog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace TravelAgent.Web
{
    public class Global : System.Web.HttpApplication
    {
        private ILogger logger = LogManager.GetCurrentClassLogger();
        protected void Application_Error(object sender, EventArgs e)
        {
            Exception ex = HttpContext.Current.Server.GetLastError();
            if(ex != null)
            {
                logger.Error("error={0}\n\n  url={1}\n\n  user_ip={2}\n\n  stacktrace={3}\n\n  inner_exception={4}\n\n Referer={5}\n\n", ex.Message, HttpContext.Current.Request.RawUrl, HttpContext.Current.Request.UserHostAddress, ex.StackTrace, ex.InnerException.Message, HttpContext.Current.Request.Headers["Referer"]);
            }
        }

        //protected void Application_Start(object sender,EventArgs e)
        //{ 
        //    string url = Request.Url.AbsolutePath;
        //}
    }
}