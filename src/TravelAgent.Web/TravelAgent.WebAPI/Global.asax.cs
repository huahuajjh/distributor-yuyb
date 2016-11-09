using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace TravelAgent.WebAPI
{
    // 注意: 有关启用 IIS6 或 IIS7 经典模式的说明，
    // 请访问 http://go.microsoft.com/?LinkId=9394801

    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //return json data configuration
            //GlobalConfiguration.Configuration.Formatters.XmlFormatter.SupportedMediaTypes.Clear();
        }

        private ILogger logger = LogManager.GetCurrentClassLogger();
        //protected void Application_Error(object sender, EventArgs e)
        //{
        //    Exception ex = HttpContext.Current.Server.GetLastError();
        //    if (ex != null)
        //    {
        //        logger.Error("error={0}\n\n  url={1}\n\n  user_ip={2}\n\n  stacktrace={3}\n\n  inner_exception={4}\n\n", ex.Message, HttpContext.Current.Request.RawUrl, HttpContext.Current.Request.UserHostAddress, ex.StackTrace, ex.InnerException.Message);
        //    }
        //}

    }
}