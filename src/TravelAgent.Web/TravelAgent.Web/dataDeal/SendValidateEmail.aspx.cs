using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TravelAgent.Web.dataDeal
{
    public partial class SendValidateEmail : TravelAgent.Web.UI.mBasePage
    {
        private static readonly TravelAgent.BLL.Club ClubBll = new TravelAgent.BLL.Club();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["email"] != null)
            {
                string stremail=Request["email"];
                int clubid = Convert.ToInt32(Request["clubid"]);
                int count = ClubBll.GetCount("clubEmail='"+stremail+"' and id<>"+clubid);
                if (count > 0)
                {
                    Response.Write("exists");
                    Response.End();
                }
                int sendCount = 0;
                if (!string.IsNullOrEmpty(TravelAgent.Tool.CookieHelper.GetCookieValue("sendemail_" + clubid)))
                {
                    sendCount = Convert.ToInt32(TravelAgent.Tool.CookieHelper.GetCookieValue("sendemail_" + clubid));
                }
                if (sendCount < 3)
                {
                    StringBuilder sbEmail = new StringBuilder();
                    sbEmail.Append("<div style=\"border: 1px solid #cdcaca; line-height: 23px; color: #333; margin-bottom: 15px;width: 700px; margin: 0 auto 15px;\">");
                    sbEmail.Append("<p style=\"height: 20px; background: rgb(47, 189, 35);\"></p>");
                    sbEmail.Append("<div class=\"sHead\">");
                    sbEmail.Append("<div class=\"sHeadInner\">");
                    sbEmail.Append("<div class=\"d1\">");
                    sbEmail.Append("<a title=\"" + webinfo.WebName + "\" href=\"" + webinfo.WebDomain + "\" target=\"_blank\" style=\"margin-left: 10px;\">");
                    sbEmail.Append("<img src=\"" + webinfo.WebDomain + webinfo.WebLogo + "\" style=\"border:0\"></a>");
                    sbEmail.Append("</div>");
                    sbEmail.Append("</div>");
                    sbEmail.Append("</div>");
                    sbEmail.Append("<div style=\"padding: 35px;\" class=\"forUserEnamlInner\">");
                    sbEmail.Append("<p style=\"line-height: 28px;\">");
                    sbEmail.Append("尊敬的用户（<a href=\"mailto:" + stremail + "\" target=\"_blank\">" + stremail + "</a>）：<br>");
                    sbEmail.Append("您好！<br>");
                    sbEmail.Append("请点击下面的链接来完成邮箱验证，享受我们的优质服务。（本链接24小时内有效）<br>");
                    sbEmail.Append("<a target=\"_blank\" style=\"color: #09f; text-decoration: underline;word-wrap:break-word;\" class=\"b under\" href=\"" + webinfo.WebDomain + "/member/EmailValidateSuc.aspx?email=" + Server.UrlEncode(stremail) + "\">" + webinfo.WebDomain + "/member/EmailValidateSuc.aspx?email=" + Server.UrlEncode(stremail) + "</a><br>");
                    sbEmail.Append("（如果链接无法点击，请将上面的地址拷贝至浏览器的地址栏。）<br>");
                    sbEmail.Append("温馨提示：如果您在使用中遇到问题，请拨打免费咨询电话：<b style=\"color: #09f; font-weight: bold;\">" + webinfo.WebTel + "</b> 联系客服，将为您提供一站式的旅游服务，让您的旅游不再操心。<br>");
                    sbEmail.Append("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;此致<br>");
                    sbEmail.Append("" + webinfo.WebName + "(<a href=\"" + webinfo.WebDomain + "\" target=\"_blank\">" + webinfo.WebDomain + "</a>)");
                    sbEmail.Append("<span style=\"\"><br><br>-------------------------------------------------------------------------------</span><br><br>");
                    sbEmail.Append("<span style=\"color: #999;\">此为系统邮件，请勿回复</span><br>");
                    sbEmail.Append(" </p>");
                    sbEmail.Append("</div>");
                    sbEmail.Append("</div>");
                    ArrayList al = new ArrayList();
                    al.Add(stremail);
                    System.Net.Mail.SmtpClient mail = new System.Net.Mail.SmtpClient();
                    mail.Host = webinfo.EmailSmtp;
                    mail.Port = Convert.ToInt32(webinfo.EmailPort);
                    bool send = TravelAgent.Tool.EmailHelper.SendMail(al, webinfo.WebName + "会员邮箱验证", sbEmail.ToString(), 1, null,webinfo.EmailUsername,webinfo.EmailPassword,webinfo.EmailAccount,mail);
                    if (send)
                    {
                        TravelAgent.Tool.CookieHelper.SetCookie("sendemail_" + clubid, (sendCount + 1).ToString());
                        Response.Write("success");
                        Response.End();
                    }
                }
                else
                {
                    Response.Write("threeError");
                    Response.End();
                }
                
            }
        }
    }
}
