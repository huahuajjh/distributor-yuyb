using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TravelAgent.Web.member
{
    public partial class EmailValidateSuc : TravelAgent.Web.UI.mBasePage
    {
        public TravelAgent.Model.Club club;
        private static readonly TravelAgent.BLL.Club clubBll = new TravelAgent.BLL.Club();
        private static readonly TravelAgent.BLL.ClubPoints PointsBll = new TravelAgent.BLL.ClubPoints();
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Title = "验证成功-" + Master.webinfo.WebName;
            string strUid = TravelAgent.Tool.CookieHelper.GetCookieValue("uid");
            if (string.IsNullOrEmpty(strUid))
            {
                Response.Redirect("/member/Login.aspx");
            }
            else
            {
                club = clubBll.GetModel(Convert.ToInt32(strUid));
            }
            if (!this.IsPostBack)
            {
                if (Request["email"] != null)
                {
                    string strEmail = Server.UrlDecode(Request["email"]);
                    this.ltEmail.Text = strEmail;
                    string strsql = "update Club set clubEmail='" + strEmail + "',emailIsValid=1 where Id=" + club.id+";";
                    try
                    {
                        //第一次验证赠送
                        if (club.emailIsValid == 0)
                        {
                            //积分开始
                            TravelAgent.Model.ClubPoints points = new TravelAgent.Model.ClubPoints();
                            points.clubid = club.id;
                            points.Content = "验证邮箱";
                            points.points = webinfo.EmailValidate;
                            points.remark = "";
                            points.pType = Convert.ToInt32(TravelAgent.Tool.EnumSummary.PointsType.邮箱验证);
                            points.adddate = DateTime.Now;
                            PointsBll.Add(points);

                            strsql += "update Club set currentPoints=currentPoints+" + webinfo.EmailValidate + " where Id=" + club.id;
                            //TravelAgent.Tool.DbHelperOleDb.ExecuteSql(strsql);
                            //积分结束
                        }
                        //Access
                        //TravelAgent.Tool.DbHelperOleDb.ExecuteSql(strsql);
                        //SQL
                        TravelAgent.Tool.DbHelperSQL.ExecuteSql(strsql);
                    }
                    catch
                    {
                        Response.Redirect("/Opr.aspx?t=error&msg=opr");
                    }
                }
                else
                {
                    Response.Redirect("/Opr.aspx?t=error&msg=opr");
                }
            }
        }
    }
}
