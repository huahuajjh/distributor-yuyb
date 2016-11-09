using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TravelAgent.Tool;

namespace TravelAgent.Web.member.data
{
    public partial class SendMobileCode1 : TravelAgent.Web.UI.mBasePage
    {
        private static readonly TravelAgent.BLL.Club ClubBll = new TravelAgent.BLL.Club();

        protected void Page_Load(object sender, EventArgs e)
        {
            string strmobile = Request["mobile"];
            string stryzm = Request["verify"];
            if (!stryzm.Equals(TravelAgent.Tool.CookieHelper.GetCookieValue("yzm")))
            {
                Response.Write("-4");
                Response.End();
            }
            int count = ClubBll.GetCount("clubMobile='" + strmobile + "'");

            if (count > 0)
            {
                int pHandle = 0;
                int loginResult = CSMS.Login(webinfo.SmsHostname, 80, webinfo.SmsUsername, webinfo.SmsPassword, ref pHandle);                
                if (loginResult < 0)
                {
                    Response.Write("sendfail");
                    Response.End();
                }
                else
                {
                    string strSMSYZM = TravelAgent.Tool.StringPlus.GetRandString(6);
                    TravelAgent.Tool.CookieHelper.ClearCookie("smsyzm");
                    TravelAgent.Tool.CookieHelper.SetCookie("smsyzm", strSMSYZM);
                    string strSMS = "【" + webinfo.WebName + "】验证码：" + strSMSYZM;
                    int sendtextReuslt = CSMS.SendText(pHandle, strSMS, "", 1);

                    if (sendtextReuslt > 0)
                    {
                        int sendtelResult = CSMS.SendPhones(pHandle, sendtextReuslt, strmobile);
                        if (sendtelResult == 0)
                        {
                            Response.Write("true");
                            Response.End();
                        }
                        else
                        {
                            Response.Write("sendfail");
                            Response.End();
                        }
                    }
                    else
                    {
                        Response.Write("sendfail");
                        Response.End();
                    }
                }
            }
            else
            {
                Response.Write("-3");
                Response.End();
            }
        }
    }
}
