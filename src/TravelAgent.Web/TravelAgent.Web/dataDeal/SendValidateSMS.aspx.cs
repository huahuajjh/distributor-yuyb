using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TravelAgent.Web.dataDeal
{
    public partial class SendValidateSMS : TravelAgent.Web.UI.mBasePage
    {
        private static readonly TravelAgent.BLL.Club ClubBll = new TravelAgent.BLL.Club();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["mobile"] != null)
            {
                string strtel = Request["mobile"];
                string strcode = Request["verify"];
                int clubid = Convert.ToInt32(Request["clubid"]);
                int count = ClubBll.GetCount("clubMobile='" + strtel + "' and id<>" + clubid);
                if (count > 0)
                {
                    Response.Write("-2");
                    Response.End();
                }
                if (!strcode.Equals(TravelAgent.Tool.CookieHelper.GetCookieValue("yzm")))
                {
                    Response.Write("-4");
                    Response.End();
                }
                int sendCount = 0;
                if (!string.IsNullOrEmpty(TravelAgent.Tool.CookieHelper.GetCookieValue("sendsms_" + clubid)))
                {
                    sendCount = Convert.ToInt32(TravelAgent.Tool.CookieHelper.GetCookieValue("sendsms_" + clubid));
                }
                if (sendCount < 3)
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
                        string strSMSYZM=TravelAgent.Tool.StringPlus.GetRandString(6);
                        TravelAgent.Tool.CookieHelper.ClearCookie("smsyzm");
                        TravelAgent.Tool.CookieHelper.SetCookie("smsyzm",strSMSYZM);
                        string strSMS = "【" + webinfo.WebName + "】验证码：" + strSMSYZM;
                        int sendtextReuslt = CSMS.SendText(pHandle, strSMS, "", 1);
                        if (sendtextReuslt > 0)
                        {
                            int sendtelResult=CSMS.SendPhones(pHandle, sendtextReuslt, strtel);
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
                    Response.Write("-1");
                    Response.End();
                }


            }
        }
    }
}
