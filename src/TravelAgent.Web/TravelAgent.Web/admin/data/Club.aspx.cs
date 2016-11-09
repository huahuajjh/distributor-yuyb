using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TravelAgent.Web.admin.data
{
    public partial class Club : System.Web.UI.Page
    {
        private static readonly TravelAgent.BLL.Club ClubBll = new TravelAgent.BLL.Club();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["id"] != null)
            {
                //TravelAgent.Model.Club model = ClubBll.GetModel(Convert.ToInt32(Request["id"]));

                //if (model != null)
                //{
                    //model.clubMobile = Request["txtMobile"];
                    //model.clubEmail = Request["txtEmail"];
                    //model.classId = Convert.ToInt32(Request["ddlClass"]);
                    //model.trueName = Request["txtName"];
                    //model.clubSex = Request["ddlSex"];
                    //model.clubBirthday = Request["txtBirthday"];
                    //model.isLock = Convert.ToInt32(Request["ddlLock"]);
                    string strsql = "update club set clubMobile='" + Request["txtMobile"] + "',clubEmail='" + Request["txtEmail"] + "',classId='" + Convert.ToInt32(Request["ddlClass"]) +
                                          "',trueName='" + Request["txtName"] + "',clubSex='" + Request["ddlSex"] + "',clubBirthday='" + Request["txtBirthday"] + "',isLock='" + Convert.ToInt32(Request["ddlLock"]) + "' where Id="+Request.QueryString["id"];
                    try
                    {
                        //Access
                        // if (TravelAgent.Tool.DbHelperOleDb.ExecuteSql(strsql) > 0)
                        //SQL
                        if (TravelAgent.Tool.DbHelperSQL.ExecuteSql(strsql) > 0)
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
                //}
                //else
                //{
                //    Response.Write("false");
                //}
            }
            if (Request["clubid"] != null)
            {
                try
                {
                    if (ClubBll.Delete(Convert.ToInt32(Request["clubid"])) > 0)
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
