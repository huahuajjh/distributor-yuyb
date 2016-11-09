using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TravelAgent.Web.admin.data
{
    public partial class Holiday : TravelAgent.Web.UI.mBasePage
    {
        private static readonly TravelAgent.BLL.WebInfo WebInfoBll = new TravelAgent.BLL.WebInfo();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["ddlHoliday"] != null)
            {
                webinfo.Holiday = Convert.ToInt32(Request["ddlHoliday"]);
                try
                {
                    ////修改配置信息
                    WebInfoBll.saveConifg(webinfo, Server.MapPath(ConfigurationManager.AppSettings["WebInfoConfig"].ToString()));
                    Response.Write("true");
                }
                catch
                {
                    Response.Write("false");
                }
                
            }
        }
    }
}
