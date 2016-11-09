using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TravelAgent.Web.admin.data
{
    public partial class SettingProperty : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["hidlineids"] != null)
            {
                string strsql = "update Line set ";
                if (Request["chkisTheme"] != null)
                {
                    strsql += "themeIds='" + Request["hidtheme"]+"',";
                }
                if (Request["chkisState"] != null)
                {
                    strsql += "State='" + Request["hidstate"] + "',";
                }
                if (Request["chkisHoliday"] != null)
                {
                    strsql += "holiday='" + Request["hidholiday"] + "',";
                }
                if (Request["chkishidden"] != null)
                {
                    int islock = Request["chkIsLock"] != null ? 1 : 0;
                    strsql += "isLock=" + islock + ",";
                }
                if (strsql.IndexOf(',') > -1)
                {
                    strsql = strsql.Substring(0, strsql.Length - 1);
                    strsql += " where Id in (" + Request["hidlineids"] + ")";
                }
                else
                {
                    strsql = "";
                }
                try
                {
                    if (!strsql.Equals(""))
                    {
                        if (TravelAgent.Tool.DbHelperSQL.ExecuteSql(strsql) > 0)
                        {
                            Response.Write("true");
                        }
                        else
                        {
                            Response.Write("false");
                        }
                    }
                    else
                    {
                        Response.Write("empty");
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
