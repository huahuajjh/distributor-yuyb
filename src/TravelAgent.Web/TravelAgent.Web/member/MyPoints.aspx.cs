using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TravelAgent.Web.member
{
    public partial class MyPoints : System.Web.UI.Page
    {
        public int pcount;                                   //总条数
        public int page = 0;                                     //当前页
        public readonly int pagesize = 10;                    //设置每页显示的大小

        public int totalgetPoints;
        public int totalusePoints;
        public TravelAgent.Model.Club club;
        private static readonly TravelAgent.BLL.Club clubBll = new TravelAgent.BLL.Club();
        private static readonly TravelAgent.BLL.ClubPoints pointsBll = new TravelAgent.BLL.ClubPoints();
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Title = "积分交易-" + Master.webinfo.WebName;
            string strUid = TravelAgent.Tool.CookieHelper.GetCookieValue("uid");
            if (string.IsNullOrEmpty(strUid))
            {
                Response.Redirect("/member/Login.aspx");
            }
            else
            {
                club = clubBll.GetModel(Convert.ToInt32(strUid));
                //Access
                //object getp=TravelAgent.Tool.DbHelperOleDb.GetSingle("select sum(points) from ClubPoints where clubid=" + club.id + " and points>=0");
                //SQL
                object getp = TravelAgent.Tool.DbHelperSQL.GetSingle("select sum(points) from ClubPoints where clubid=" + club.id + " and points>=0");
                totalgetPoints = getp != null ? Convert.ToInt32(getp) : 0;
                //Access
                //object usep = TravelAgent.Tool.DbHelperOleDb.GetSingle("select sum(points) from ClubPoints where clubid=" + club.id + " and points<0");
                //SQL
                object usep = TravelAgent.Tool.DbHelperSQL.GetSingle("select sum(points) from ClubPoints where clubid=" + club.id + " and points<0");
                totalusePoints = usep != null ? Convert.ToInt32(usep) : 0;
            }
        }

        /// <summary>
        /// 绑定收藏线路
        /// </summary>
        /// <returns></returns>
        public string BindPointsList()
        {
            StringBuilder sbCollect = new StringBuilder();
            string strWhere = "clubid=" + club.id;
            this.pcount = pointsBll.GetCount(strWhere);
            if (this.pcount > 0)
            {
                DataSet ds = pointsBll.GetPageList(this.pagesize, this.page, strWhere, "adddate desc");
                DataRow row = null;
                int selectCount = ds.Tables[0].Rows.Count;
                for (int i = 0; i < selectCount; i++)
                {
                    row = ds.Tables[0].Rows[i];
                   
                    sbCollect.Append("<tr>");
                    sbCollect.Append("<td>"+row["adddate"]+"</td>");
                    sbCollect.Append("<td>" + row["points"] + "</td>");
                    sbCollect.Append("<td>" + TravelAgent.Tool.EnumHelper.GetMemberName<TravelAgent.Tool.EnumSummary.PointsType>(row["pType"]) + "</td>");
                    sbCollect.Append("<td>" + row["Content"] + "</td>");
                    sbCollect.Append("</tr>");

                    if (Convert.ToInt32(row["points"]) >= 0)
                    {
                        totalgetPoints += Convert.ToInt32(row["points"]);
                    }
                    else
                    {
                        totalusePoints += Convert.ToInt32(row["points"]);
                    }
                }
            }
            else
            {
                sbCollect.Append("<tr><td colspan=\"4\" style=\"line-height:30px;text-align:center;background-color:#f9f0a8;\">没有记录！</td></tr>");
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
    }
}
