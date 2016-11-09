using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TravelAgent.Web.member
{
    public partial class SettingPwd : TravelAgent.Web.UI.mBasePage
    {
        public string struser;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.Title = "重置密码-" + webinfo.WebName;

            if (Request.QueryString["user"] != null)
            {
                struser = Server.UrlDecode(Request.QueryString["user"]);
            }
            if (Request["mobile"] != null)
            {
                struser = Request["mobile"];
            }
        }
    }
}
