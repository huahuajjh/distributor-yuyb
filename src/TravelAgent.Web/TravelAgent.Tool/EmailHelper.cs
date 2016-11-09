using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;

namespace TravelAgent.Tool
{
    public static class EmailHelper
    {
        /// <summary>
        /// 功能：发送邮件,返回字符串：“发送成功”否则返回错误代码。
        /// </summary>
        /// <param name="MailTo">MailTo为收信人地址</param>
        /// <param name="Subject">Subject为标题</param>
        /// <param name="Body">Body为信件内容</param>
        /// <param name="BodyFormat">BodyFormat为信件内容格式:0为Text,1为Html</param>
        /// <param name="Attachments">Attachment为附件,为null则不发送</param>
        public static bool SendMail(System.Collections.ArrayList MailTo, string Subject, string Body, int BodyFormat, string Attachments,
            string str_FromUserName, string str_FromPassword, string str_FromEmail, SmtpClient mail)
        {
            
            ////发件人的用户名
            //string str_FromUserName = ConfigurationManager.AppSettings["email_user"];
            ////发件人的密码
            //string str_FromPassword = ConfigurationManager.AppSettings["email_pwd"];
            ////发件人的邮箱
            //string str_FromEmail = ConfigurationManager.AppSettings["email"];

            //SmtpClient mail = new SmtpClient();
            //发送方式
            mail.DeliveryMethod = SmtpDeliveryMethod.Network;
            //smtp服务器
            //mail.Host = ConfigurationManager.AppSettings["host"];

            //mail.Port = Convert.ToInt32(ConfigurationManager.AppSettings["port"]);

            mail.Timeout = 10000;

            mail.UseDefaultCredentials = true;
            //用户名凭证               
            mail.Credentials = new System.Net.NetworkCredential(str_FromUserName, str_FromPassword);
            //邮件信息
            MailMessage message = new MailMessage();
            //发件人
            message.From = new MailAddress(str_FromEmail);
            //收件人
            foreach (object item in MailTo)
            {
                message.To.Add(item.ToString());
            }
            //主题
            message.Subject = Subject;
            //内容
            message.Body = Body;
            //正文编码
            message.BodyEncoding = System.Text.Encoding.UTF8;
            //设置为HTML格式
            message.IsBodyHtml = (BodyFormat == 1) ? true : false;
            //优先级
            message.Priority = MailPriority.High;

            try
            {
                mail.Send(message);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
