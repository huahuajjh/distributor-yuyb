using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TravelAgent.Web.member
{
    public partial class QuickLogin : System.Web.UI.Page
    {
        public string strTel;
        public string strPwd;
        public string strError;
        public string strBtnContent="<button type='button' class=\"quicklogin_nextbtn\" id=\"btn_QuitLogin_next\" onclick=\"parent.document.getElementById('btn_Next_2').click();\">已记住密码，下一步</button>";
        private static readonly TravelAgent.BLL.Club ClubBll = new TravelAgent.BLL.Club();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["tel"] != null)
            {
                strTel = Request.QueryString["tel"];
            }
            if (!this.IsPostBack)
            {
                //if (Request["actionName"] != null)
                //{
                       string strTag = Request["actionName"];
                    //if (strTag.Equals("buySubmit"))
                    //{
                        //快速预订
                        if (Request["mobile"] != null)
                        {
                            string strtelephone = Request["mobile"];
                            if (ClubBll.GetCount("clubMobile='" + strtelephone + "'") > 0)//存在该手机号码
                            {
                                strError = "exits_" + strtelephone;
                            }
                            else
                            {
                                //签证订单提交
                                if (strTag.Equals("visaOrderSubmit"))
                                {
                                    strBtnContent = "<button type='button' class=\"quicklogin_nextbtn\" id=\"btn_QuitLogin_next\" onclick=\"parent.submit();parent.closeEditor();\">已记住密码，开始预订</button>";
                                }
                                TravelAgent.Model.Club model = new TravelAgent.Model.Club();
                                model.clubName = "club" + strtelephone;
                                model.clubMobile = strtelephone;
                                strPwd=TravelAgent.Tool.GetRandom.GenerateRandom(6, TravelAgent.Tool.GetRandom.RandomType.Number);
                                model.clubPwd = strPwd;
                                int clubid=ClubBll.Add(model);
                                if (clubid > 0)
                                {
                                    TravelAgent.Tool.CookieHelper.SetCookie("uid", clubid.ToString());
                                    TravelAgent.Tool.CookieHelper.SetCookie("username", model.clubName);
                                    
                                    this.quicklogin_block.Style["display"] = "none";
                                    this.quicklogin_next.Style["display"] = "";
                                }
                                else
                                {
                                    strError = "regerror_" + strtelephone;
                                }
                            }
                        }
                        if (Request["txtName"] != null)
                        {
                            string strName = TravelAgent.Tool.StringPlus.FilterStr(Request["txtName"]);
                            string strPwd = TravelAgent.Tool.StringPlus.FilterStr(Request["txtPwd"]);
                            TravelAgent.Model.Club club = ClubBll.GetModel(strName, strPwd);
                            if (club != null)
                            {
                                if (club.isLock == 0)//正常
                                { 
                                    TravelAgent.Tool.CookieHelper.SetCookie("uid", club.id.ToString());
                                    TravelAgent.Tool.CookieHelper.SetCookie("username", club.clubName);
                                    //线路订单
                                    if (strTag.Equals("buySubmit"))
                                    {
                                        Response.Write("<script>parent.document.getElementById('btn_Next_2').click();</script>");
                                    }
                                    else if (strTag.Equals("visaOrderSubmit"))//签证订单
                                    {
                                        Response.Write("<script>parent.submit();parent.closeEditor();</script>");
                                    }
                                }
                            }
                            else
                            {
                                strError = "loginerror_" + strName;
                            }
                        }
                    //}
            //    }
            }
        }
        
    }
}
