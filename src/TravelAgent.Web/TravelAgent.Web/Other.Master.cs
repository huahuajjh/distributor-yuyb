﻿using System;
using System.Data;
using System.Text;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using TravelAgent.Tool;

namespace TravelAgent.Web
{
    public partial class Other : System.Web.UI.MasterPage
    {
        public TravelAgent.Model.WebInfo webinfo;
        private TravelAgent.BLL.WebNav NavBll = new TravelAgent.BLL.WebNav();
        //private static readonly TravelAgent.BLL.Destination DestBll = new TravelAgent.BLL.Destination();
        private static readonly TravelAgent.BLL.LineTheme ThemeBll = new TravelAgent.BLL.LineTheme();
        private static readonly TravelAgent.BLL.VisaCountry CountryBll = new TravelAgent.BLL.VisaCountry();
        private static readonly TravelAgent.BLL.Category CateBll = new TravelAgent.BLL.Category();
        private static readonly TravelAgent.BLL.Adbanner BannerBll = new TravelAgent.BLL.Adbanner();
        //private static readonly TravelAgent.BLL.Links LinkBll = new TravelAgent.BLL.Links();
        protected void Page_Init(object sender, EventArgs e)
        {
            if (webinfo == null)
            {
                webinfo = new TravelAgent.BLL.WebInfo().loadConfig(Server.MapPath(ConfigurationManager.AppSettings["WebInfoConfig"].ToString()));
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 绑定搜索关键字
        /// </summary>
        /// <returns></returns>
        public string BindSearchKey()
        {
            StringBuilder sb = new StringBuilder();
            if (!webinfo.SearchKey.Equals(""))
            {
                string[] arryKey = webinfo.SearchKey.Split(',');
                foreach (string key in arryKey)
                {
                    sb.Append("<a href=\"/Search.aspx?keyword=" + Server.UrlEncode(key) + "\" target=\"_blank\">" + key + "</a> ");
                }
            }

            return sb.ToString();
        }
        /// <summary>
        /// 绑定导航
        /// </summary>
        /// <returns></returns>
        public string BindNav()
        {
            StringBuilder strNav = new StringBuilder();
            DataSet dsNav = NavBll.GetNavListByParentId(0, null);
            foreach (DataRow row in dsNav.Tables[0].Rows)
            {
                if (row["State"].ToString().Contains("," + Convert.ToInt32(EnumSummary.State.热卖) + ","))
                {
                    strNav.Append("<li id=\"nav_li" + row["Id"] + "\"><a class=\"hot\" href=\"" + row["navURL"] + "\">" + row["navName"] + "<i></i></a></li>");
                }
                else
                {
                    strNav.Append("<li id=\"nav_li" + row["Id"] + "\"><a href=\"" + row["navURL"] + "\">" + row["navName"] + "</a></li>");
                }
            }
            return strNav.ToString();
        }
        /// <summary>
        /// 绑定关于
        /// </summary>
        /// <returns></returns>
        public string BindAbout()
        {
            DataSet dsCate = CateBll.GetChannelListByParentId(3, null);
            StringBuilder sbAbout = new StringBuilder();
            DataRow row = null;
            string strurl = "";
            for (int i = 0; i < dsCate.Tables[0].Rows.Count; i++)
            {
                row = dsCate.Tables[0].Rows[i];
                strurl = row["PageUrl"].ToString();
                if (strurl.Equals(""))
                {
                    strurl = "/article/" + row["Id"]+".html";
                }
                if (i < dsCate.Tables[0].Rows.Count - 1)
                {
                    sbAbout.Append("<a rel=\"nofollow\" href=\"" + strurl + "\">" + row["Title"] + "</a>|");
                }
                else
                {
                    sbAbout.Append("<a rel=\"nofollow\" href=\"" + strurl + "\">" + row["Title"] + "</a>");
                }

            }
            return sbAbout.ToString();
        }
        /// <summary>
        /// 绑定荣誉
        /// </summary>
        /// <returns></returns>
        public string BindRongyu()
        {
            DataSet dsRongyu = BannerBll.GetList("Aid=23 and StartTime<'" + DateTime.Now + "' and EndTime>'" + DateTime.Now + "'");
            StringBuilder sbRongyu = new StringBuilder();
            foreach (DataRow row in dsRongyu.Tables[0].Rows)
            {
                sbRongyu.Append("<img src=\"" + row["AdUrl"] + "\" alt=\"" + row["Title"] + "\" />");
            }
            return sbRongyu.ToString();
        }
        /// <summary>
        /// 添加页面属性
        /// </summary>
        /// <param name="page"></param>
        /// <param name="metaName"></param>
        /// <param name="metaContent"></param>
        public static void AddMeta(Page page, string metaName, string metaContent)
        {
            HtmlMeta meta = new HtmlMeta();
            meta.Name = metaName;
            meta.Content = metaContent;
            page.Header.Controls.Add(meta);
        }
    }
}
