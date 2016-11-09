using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TravelAgent.Web.dataDeal
{
    public partial class LineCollect : System.Web.UI.Page
    {
        private static readonly TravelAgent.BLL.ClubLineCollect LineCollectBll = new TravelAgent.BLL.ClubLineCollect();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["uid"] != null)
            {
                int uid = Convert.ToInt32(Request["uid"]);
                int lineid = Convert.ToInt32(Request["line_id"]);
                int count = LineCollectBll.GetCount("LineId=" + lineid + " and ClubId="+uid);
                if (count > 0)
                {
                    Response.Write("has");
                }
                else
                {
                    TravelAgent.Model.ClubLineCollect model = new TravelAgent.Model.ClubLineCollect();
                    model.LineId = lineid;
                    model.ClubId = uid;
                    model.CollectDate = DateTime.Now;
                    if (LineCollectBll.Add(model) > 0)
                    {
                        Response.Write("success");
                    }
                    else
                    {
                        Response.Redirect("/Opr.aspx?t=error&msg=opr",false);
                    }
                }
                
            }
        }
    }
}
