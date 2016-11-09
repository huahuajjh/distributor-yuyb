using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TravelAgent.Web.member
{
    public partial class MyCollect : System.Web.UI.Page
    {
        public int pcount;                                   //总条数
        public int page = 0;                                     //当前页
        public readonly int pagesize = 10;                    //设置每页显示的大小

        public TravelAgent.Model.Club club;
        private static readonly TravelAgent.BLL.Club clubBll = new TravelAgent.BLL.Club();
        private static readonly TravelAgent.BLL.ClubLineCollect LineCollectBll = new TravelAgent.BLL.ClubLineCollect();
        private static readonly TravelAgent.BLL.Line LineBll = new TravelAgent.BLL.Line();
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Title = "收藏线路-" + Master.webinfo.WebName;
            string strUid = TravelAgent.Tool.CookieHelper.GetCookieValue("uid");
            if (string.IsNullOrEmpty(strUid))
            {
                Response.Redirect("/member/Login.aspx");
            }
            else
            {
                club = clubBll.GetModel(Convert.ToInt32(strUid));
            }
        }
        /// <summary>
        /// 绑定收藏线路
        /// </summary>
        /// <returns></returns>
        public string BindCollectList()
        {
            StringBuilder sbCollect = new StringBuilder();
            string strWhere = "ClubId=" + club.id;
            this.pcount = LineCollectBll.GetCount(strWhere);
            if (this.pcount > 0)
            {
                DataSet ds = LineCollectBll.GetPageList(this.pagesize, this.page, strWhere, "CollectDate desc");
                DataRow row = null;
                TravelAgent.Model.Line line = null;
                int selectCount = ds.Tables[0].Rows.Count;
                for (int i = 0; i < selectCount; i++)
                {
                    row = ds.Tables[0].Rows[i];
                    line = LineBll.GetModel(Convert.ToInt32(row["LineId"]));
                    if (line != null)
                    {
                        sbCollect.Append("<tr>");
                        sbCollect.Append("<td><input name=\"collection_id[]\" type=\"checkbox\" value=\"" + row["Id"] + "\" /></td>");
                        sbCollect.Append("<td class=\"order_pic\"><a href=\"/Line.aspx?id=" + row["LineId"] + "\" target=\"_blank\"><img src=\"" + line.LinePic + "\" />" + line.LineName + "</a><span style=\"text-align: left;\">L" + line.Id.ToString().PadLeft(6, '0') + "</span></td>");
                        sbCollect.Append("<td class=\"arial order_price\">¥" + line.PriceCommon + "</td><td class=\"arial\">" + row["CollectDate"] + "</td>");
                        sbCollect.Append("<td class=\"order_operate\"><a href=\"/Line.aspx?id=" + row["LineId"] + "\" target=\"_blank\">去预订</a><a class=\"delcollect\" href=\"javascript:void(0)\" id=\""+row["Id"]+"\">删除</a></td>");
                        sbCollect.Append("</tr>");
                    }
                }
            }
            else
            {
                sbCollect.Append("<tr><td colspan=\"5\" style=\"line-height:30px;text-align:center;background-color:#f9f0a8;\">您目前还没有收藏线路哦！</td></tr>");
            }
            return sbCollect.ToString();
        }
        /// <summary>
        /// 绑定分页
        /// </summary>
        /// <returns></returns>
        public string BindPage()
        {
            StringBuilder sbPage = new StringBuilder();
            if (this.pcount > this.pagesize)
            {
                int totalPagecount;
                if (this.pcount % this.pagesize != 0)
                {
                    totalPagecount = this.pcount / this.pagesize + 1;
                }
                else
                {
                    totalPagecount = this.pcount / this.pagesize;
                }

                sbPage.Append("<div class=\"pages\">");

                if (this.page > 0)
                {
                    sbPage.Append("<a href='?page=" + (page - 1) + "'>上一页</a>");
                }
                for (int i = 0; i < totalPagecount; i++)
                {
                    if (i == this.page)
                    {
                        sbPage.Append("&nbsp;<span class='current'>" + (i + 1) + "</span>");
                    }
                    else
                    {
                        sbPage.Append("&nbsp;<a href='?page=" + i + "'>" + (i + 1) + "</a>");
                    }

                }
                if (this.page < totalPagecount - 1)
                {
                    sbPage.Append("<a href='?page=" + (page + 1) + "'>下一页</a>");
                }

                sbPage.Append("</div>");
            }
            return sbPage.ToString();
        }
        /// <summary>
        /// 绑定特价线路
        /// </summary>
        /// <returns></returns>
        public string BindTejiaLine()
        { 
            StringBuilder sbLine = new StringBuilder();
            //Access
            //DataSet dsLine = LineBll.GetList(10, "InStr(State,'," + Convert.ToInt32(TravelAgent.Tool.EnumSummary.State.特价) + ",')>0 and isLock=0", "Sort asc,adddate desc");
            //SQL
            DataSet dsLine = LineBll.GetList(10, "CHARINDEX('," + Convert.ToInt32(TravelAgent.Tool.EnumSummary.State.特价) + ",',State)>0 and isLock=0", "Sort asc,adddate desc");
            DataRow row = null;
            for (int i = 0; i < dsLine.Tables[0].Rows.Count; i++)
            {
                row = dsLine.Tables[0].Rows[i];
                sbLine.Append("<li><img src=\"" + row["linePic"] + "\"><a href=\"/Line.aspx?id=" + row["Id"] + "\">" + TravelAgent.Tool.StringPlus.LeftTrueLen(row["lineName"].ToString(), 26, "") + "</a><span><b>¥" + row["priceCommon"] + "</b>起</span></li>");
            }
            return sbLine.ToString();
        }
    }
}
