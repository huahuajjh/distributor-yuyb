using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TravelAgent.Web.dataDeal
{
    public partial class DelLineCollect : System.Web.UI.Page
    {
        private static readonly TravelAgent.BLL.ClubLineCollect LineCollectBll = new TravelAgent.BLL.ClubLineCollect();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["collectid"] != null)
            {
                int id = Convert.ToInt32(Request["collectid"]);
                if (LineCollectBll.Delete(id) > 0)
                {
                    Response.Write("success");
                }
                else
                {
                    Response.Write("error");
                }
            }
            if (Request["hidIds"] != null)
            {
                string strIds = Request["hidIds"].ToString().TrimEnd(',');
                string strsql = "delete from ClubLineCollect where Id in (" + strIds + ")";
                //Access
                //if (TravelAgent.Tool.DbHelperOleDb.ExecuteSql(strsql) > 0)
                //SQL
                if (TravelAgent.Tool.DbHelperSQL.ExecuteSql(strsql) > 0)
                {
                    Response.Write("success");
                }
                else
                {
                    Response.Write("error");
                }
            }
        }
    }
}
