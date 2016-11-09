using System;
using System.Data;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TravelAgent.Web.admin.data
{
    public partial class SysInfo : TravelAgent.Web.UI.BasePage
    {
        public int kindId; 
        private static readonly TravelAgent.BLL.WebInfo WebInfoBll = new TravelAgent.BLL.WebInfo();
        private static readonly TravelAgent.BLL.WebNav WebNavBll = new TravelAgent.BLL.WebNav();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (Request["tag"] != null)
                {
                    string strTag = Request["tag"];
                    
                    if (strTag == "qqservice")//QQ客服设置
                    {
                        webinfo.QQServiceState = Convert.ToInt32(Request["rbtnQQServices"]);
                        int intQQServicesCount = Convert.ToInt32(Request["hidQQServiceCount"]);
                        string strQQServices = "",strTempQQservice="";
                        for (int i = 1; i <= intQQServicesCount; i++)
                        {
                            if (!Request["txtQQServiceName_" + i].Equals(""))
                            {
                                strTempQQservice = Request["txtQQServiceName_" + i] + ":" + Request["txtQQServiceList_" + i];
                                strQQServices = strQQServices + strTempQQservice + "|";
                            } 
                        }
                        if (!strQQServices.Equals(""))
                        {
                            strQQServices = strQQServices.Substring(0, strQQServices.Length - 1);
                        }
                        webinfo.QQServices = strQQServices;

                        try
                        {
                            WebInfoBll.saveConifg(webinfo, Server.MapPath(ConfigurationManager.AppSettings["WebInfoConfig"].ToString()));
                            Response.Write("true");
                        }
                        catch
                        {
                            Response.Write("false");
                        }
                    }
                    else if (strTag == "nav")//网站导航设置
                    {
                        int nav_editid = Convert.ToInt32(Request["hidNavId"]);
                        int navId;
                        int parentId = Convert.ToInt32(Request["ddlNav"]);       //上一级目录
                        int navLayer = 1;                                         //栏目深度
                        string navList = "";
                        TravelAgent.Model.WebNav webNav = new TravelAgent.Model.WebNav();
                        webNav.navName = Request["txtNavName"];
                        webNav.navParentId = parentId;
                        webNav.navURL = Request["txtNavURL"];
                        webNav.navList = "";
                        webNav.navSort = Convert.ToInt32(Request["txtSort"]);
                        webNav.kindId = this.kindId;
                        webNav.State = Request["hidState"];
                        if (nav_editid == 0)
                        {
                            //添加导航
                            navId = WebNavBll.Add(webNav);
                        }
                        else
                        {
                            navId = nav_editid;
                        }
                        //修改导航的下属导航ID列表
                        if (parentId > 0)
                        {
                            DataSet ds = WebNavBll.GetNavListByClassId(parentId);

                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                DataRow dr = ds.Tables[0].Rows[0];
                                navList = dr["navList"].ToString().Trim() + navId + ",";
                                navLayer = Convert.ToInt32(dr["navLayer"]) + 1;
                            }
                        }
                        else
                        {
                            navList = "," + navId + ",";
                            navLayer = 1;
                        }
                        webNav.Id = navId;
                        webNav.navList = navList;
                        webNav.navLayer = navLayer;

                        try
                        {
                            WebNavBll.Update(webNav);
                            Response.Write("true");
                        }
                        catch
                        {
                            Response.Write("false");
                        }
                    }
                    else if (strTag == "nav_delete")//删除导航
                    {
                        int navid = Convert.ToInt32(Request["navid"]);
                        try
                        {
                            WebNavBll.Delete(navid);
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
    }
}
