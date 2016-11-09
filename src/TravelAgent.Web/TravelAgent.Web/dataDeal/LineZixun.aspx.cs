using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TravelAgent.Web.dataDeal
{
    public partial class LineZixun : System.Web.UI.Page
    {
        TravelAgent.BLL.LineConsult ConsultBll = new TravelAgent.BLL.LineConsult();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["line_id"] != null)
            {
                TravelAgent.Model.LineConsult consult = new TravelAgent.Model.LineConsult();
                consult.LineId=Convert.ToInt32(Request["line_id"]);
                consult.LinkEmail = Request["email"] == null ? "" : Request["email"];
                consult.LinkTel=Request["phone"];
                consult.ConsultContent=Request["content"];
                consult.ConsultDate=DateTime.Now;
                try
                {
                    if(ConsultBll.Add(consult)>0)
                    {
                        Response.Write("true");
                    }
                    else
                    {
                        Response.Write("false");
                    }
                }
                catch
                {
                    Response.Write("false");
                }
            }
        }
    }
}
