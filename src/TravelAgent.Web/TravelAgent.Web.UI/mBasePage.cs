using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace TravelAgent.Web.UI
{
    public class mBasePage : System.Web.UI.Page
    {
        protected internal TravelAgent.Model.WebInfo webinfo;
        public mBasePage()
        {
            webinfo = new TravelAgent.BLL.WebInfo().loadConfig(Server.MapPath(ConfigurationManager.AppSettings["WebInfoConfig"].ToString()));
        }
    }
}
