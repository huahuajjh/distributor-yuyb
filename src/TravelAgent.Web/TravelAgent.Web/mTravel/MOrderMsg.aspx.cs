﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TravelAgent.Web.mTravel
{
    public partial class MOrderMsg : TravelAgent.Web.UI.mBasePage
    {
        public string strClass = "success";
        public string strMsg = "";
        public string strNo = "";
        public string strPrice = "";
        private static readonly TravelAgent.BLL.Category CateBll = new TravelAgent.BLL.Category();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["msg"] != "")
            {
                strMsg = Request.QueryString["msg"];
            }
            if (Request.QueryString["class"] != null)
            {
                strClass = Request.QueryString["class"];
            }
            if (Request.QueryString["no"] != null)
            {
                strNo = Request.QueryString["no"];
            }
            if (Request.QueryString["pr"] != null)
            {
                strPrice = Request.QueryString["pr"];
            }
        }
        /// <summary>
        /// 绑定底部导航
        /// </summary>
        /// <param name="top"></param>
        /// <returns></returns>
        public string BindBottonNav(int top, int parentid)
        {
            StringBuilder sbBottomNav = new StringBuilder();
            DataSet dsNav = CateBll.GetChannelListByParentId(parentid, top);
            for (int i = 0; i < dsNav.Tables[0].Rows.Count; i++)
            {
                sbBottomNav.Append("<a href=\"Article.aspx?id=" + dsNav.Tables[0].Rows[i]["Id"] + "\">" + dsNav.Tables[0].Rows[i]["Title"] + "</a>|");
            }
            return sbBottomNav.ToString().Remove(sbBottomNav.Length - 1);
        }
    }
}
