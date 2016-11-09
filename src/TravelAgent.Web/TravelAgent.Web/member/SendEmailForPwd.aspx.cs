using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Text;
using System.Web.UI.WebControls;

namespace TravelAgent.Web.member
{
    public partial class SendEmailForPwd : TravelAgent.Web.UI.mBasePage
    {
        public string strEmail;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.Title = "发送邮件-" + webinfo.WebName;
            if (Request.Form["email"] != null)
            {
                strEmail = Request.Form["email"];

                try
                {
                    ArrayList al = new ArrayList();
                    al.Add(strEmail);
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
                    sbEmail.Append("尊敬的用户（<a href=\"mailto:" + strEmail + "\" target=\"_blank\">" + strEmail + "</a>）：<br>");
                    sbEmail.Append("您好！<br>");
                    sbEmail.Append("这是一封重置密码的确认邮件。如果您并未尝试找回密码，请忽略本邮件。<br>");
                    sbEmail.Append("您可以通过点击以下链接重置账户密码（基于安全考虑，本链接24小时内有效）。");
                    sbEmail.Append("<a target=\"_blank\" style=\"color: #09f; text-decoration: underline;word-wrap:break-word;\" class=\"b under\" href=\"" + webinfo.WebDomain + "/member/SettingPwd.aspx?user=" + Server.UrlEncode(strEmail) + "\">" + webinfo.WebDomain + "/member/SettingPwd.aspx?user=" + Server.UrlEncode(strEmail) + "</a><br>");
                    sbEmail.Append("（如果链接无法点击，请将上面的地址拷贝至浏览器的地址栏。）<br>");
                    sbEmail.Append("温馨提示：如果您在使用中遇到问题，请拨打咨询电话：<b style=\"color: #09f; font-weight: bold;\">" + webinfo.WebTel + "</b> 联系客服，将为您提供一站式的旅游服务，让您的旅游不再操心。<br>");
                    sbEmail.Append("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;此致<br>");
                    sbEmail.Append("" + webinfo.WebName + "(<a href=\"" + webinfo.WebDomain + "\" target=\"_blank\">" + webinfo.WebDomain + "</a>)");
                    sbEmail.Append("<span style=\"\"><br><br>-------------------------------------------------------------------------------</span><br><br>");
                    sbEmail.Append("<span style=\"color: #999;\">此为系统邮件，请勿回复</span><br>");
                    sbEmail.Append(" </p>");
                    sbEmail.Append("</div>");
                    sbEmail.Append("</div>");

                    System.Net.Mail.SmtpClient Client = new System.Net.Mail.SmtpClient();
                    Client.Host = webinfo.EmailSmtp;
                    Client.Port = Convert.ToInt32(webinfo.EmailPort);

                    bool send = TravelAgent.Tool.EmailHelper.SendMail(al, "重置密码-" + webinfo.WebName, sbEmail.ToString(), 1, null, webinfo.EmailUsername, webinfo.EmailPassword, webinfo.EmailAccount, Client);

                    if (!send)
                    {
                        Response.Redirect("/Opr.aspx?t=error&msg=opr");
                    }
                }
                catch
                {
                    Response.Redirect("/Opr.aspx?t=error&msg=opr");
                }
            }
        }
    }
}
