﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TravelAgent.Web.member
{
    public partial class GetPassword : TravelAgent.Web.UI.mBasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Title = "找回密码-" + Master.webinfo.WebName;
        }
    }
}
