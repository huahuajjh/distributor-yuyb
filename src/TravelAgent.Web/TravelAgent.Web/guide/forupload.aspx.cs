using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TravelAgent.Web.guide
{

    public partial class forupload : System.Web.UI.Page
    {
        protected string para="";
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetNoStore();
            if(!IsPostBack){
                string rid=Request["rid"];
                string sid=Request["sid"];
                para="?rid="+rid+"&sid="+sid;
            }
        }
    }
}