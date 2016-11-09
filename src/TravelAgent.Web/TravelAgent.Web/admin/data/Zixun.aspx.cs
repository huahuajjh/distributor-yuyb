using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TravelAgent.Web.admin.data
{
    public partial class Zixun : TravelAgent.Web.UI.BasePage
    {
        private static readonly TravelAgent.BLL.LineConsult ConsultBll = new TravelAgent.BLL.LineConsult();
        protected void Page_Load(object sender, EventArgs e)
        {
            //删除
            if (Request["zixunid"] != null)
            {

                if (ConsultBll.Delete(Convert.ToInt32(Request["zixunid"])) > 0)
                {
                    Response.Write("true");
                }
                else
                {
                    Response.Write("false");
                }
            }
            //回复
            if (Request["zixun_id"] != null)
            {
                string strsql = "update LineConsult set IsReply=1,ReplyUserId=" + Admin.Id + ",ReplyContent='"+Request["content"]+"',ReplyDate='" + DateTime.Now + "' where Id=" + Request["zixun_id"];
                //Access
                // if (TravelAgent.Tool.DbHelperOleDb.ExecuteSql(strsql) > 0)
                //SQL
                if (TravelAgent.Tool.DbHelperSQL.ExecuteSql(strsql) > 0)
                {
                    if (Convert.ToBoolean(Request["isemail"]))
                    { 
                        ArrayList al = new ArrayList();
                        al.Add(Request["email"].ToString());
                        System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient();
                        smtp.Host = webinfo.EmailSmtp;
                        smtp.Port = Convert.ToInt32(webinfo.EmailPort);
                        TravelAgent.Tool.EmailHelper.SendMail(al, "回复'" + Request["question"] + "'-" + webinfo.WebName, Request["content"], 1, null, webinfo.EmailUsername, webinfo.EmailPassword, webinfo.EmailAccount, smtp);
                    }
                    
                    Response.Write("true");
                }
                else
                {
                    Response.Write("false");
                }
            }
        }
    }
}
