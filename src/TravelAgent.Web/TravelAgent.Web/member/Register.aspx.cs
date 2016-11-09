using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TravelAgent.Web.member
{
    public partial class Register : System.Web.UI.Page
    {
        public string strMemberAgreement;
        private static readonly TravelAgent.BLL.Club ClubBll = new TravelAgent.BLL.Club();
        private static readonly TravelAgent.BLL.InfoSetting bll = new TravelAgent.BLL.InfoSetting();
        private static readonly TravelAgent.BLL.ClubPoints PointsBll = new TravelAgent.BLL.ClubPoints();
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Title = "会员注册-" + Master.webinfo.WebName;
            if (!this.IsPostBack)
            {
                TravelAgent.Model.InfoSetting info = new TravelAgent.Model.InfoSetting();
                info.ds = bll.GetList();
                strMemberAgreement = info.getValue("RegFWTK");
                if (Request["type"] != null)
                {
                    string strTag = Request["type"];
                    TravelAgent.Model.Club model = new TravelAgent.Model.Club();
                    if (strTag.Equals("mobile"))
                    {
                        model.clubMobile = Request["mobile"];
                        model.clubName = "club" + model.clubMobile;
                    }
                    else
                    {
                        model.clubEmail = Request["email"];
                        model.clubName = "club" + model.clubEmail;
                    }
                    model.clubPwd = Request["password"];
                    
                    int userid = ClubBll.Add(model);
                    if (userid > 0)
                    {
                        //积分开始
                        TravelAgent.Model.ClubPoints points = new TravelAgent.Model.ClubPoints();
                        points.clubid = userid;
                        points.Content = "首次注册";
                        points.points = Master.webinfo.FristReg;
                        points.remark = "";
                        points.pType = Convert.ToInt32(TravelAgent.Tool.EnumSummary.PointsType.注册);
                        points.adddate = DateTime.Now;
                        PointsBll.Add(points);

                        string strsql = "update Club set currentPoints=currentPoints+" + Master.webinfo.FristReg + " where Id=" + userid;
                        //Access
                        //TravelAgent.Tool.DbHelperOleDb.ExecuteSql(strsql);
                        //SQL
                        TravelAgent.Tool.DbHelperSQL.ExecuteSql(strsql);
                        //积分结束

                        TravelAgent.Tool.CookieHelper.SetCookie("uid", userid.ToString());
                        TravelAgent.Tool.CookieHelper.SetCookie("username", model.clubName);
                        Response.Redirect("/member/Index.aspx");
                    }
                    else
                    {
                        Response.Redirect("/Opr.aspx?t=error&msg=opr", false);
                    }
                }
            }
        }
    }
}
