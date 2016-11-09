using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TravelAgent.Web.admin.club
{
    public partial class GroupEmail : TravelAgent.Web.UI.BasePage
    {
        public string stremails;
        private static TravelAgent.BLL.Club ClubBll = new TravelAgent.BLL.Club();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                BindClubClass();
                if (Request.QueryString["va"] != null)
                {
                    stremails = Request.QueryString["va"];
                    this.txtEmail.Text = Request.QueryString["va"];
                }

                if (Admin.Role.roleAuth.IndexOf(",email_opr,") <= -1)
                {
                    this.btnSave.Visible = false;
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            stremails = "";
            if (this.ddlRule.SelectedValue == "1")//指定会员
            {
                stremails = this.txtEmail.Text;
            }
            else if (this.ddlRule.SelectedValue == "2")//注册日期
            {
                DataSet dsClub = ClubBll.GetList(0, "regDate>='" + Convert.ToDateTime(this.txtStartDate.Text) + "' and regDate<='" + Convert.ToDateTime(this.txtEndDate.Text) + "'", "regDate desc");
                foreach (DataRow r in dsClub.Tables[0].Rows)
                {
                    if (!string.IsNullOrEmpty(r["clubEmail"].ToString()))
                    {
                        stremails = stremails + r["clubEmail"] + ";";
                    }
                }
                if (!string.IsNullOrEmpty(stremails))
                {
                    stremails = stremails.Substring(0, stremails.Length - 1);
                }
            }
            else if (this.ddlRule.SelectedValue == "3")//所有会员
            {
                string strclass = "";
                foreach (ListItem item in this.chkClubClass.Items)
                {
                    if (item.Selected)
                    {
                        strclass = strclass + item.Value + ",";
                    }
                }
                if (!string.IsNullOrEmpty(strclass))
                {
                    strclass = strclass.Substring(0, strclass.Length - 1);
                }
                DataSet dsclub = ClubBll.GetList(0, "classId in (" + strclass + ")", "regDate desc");
                foreach (DataRow r in dsclub.Tables[0].Rows)
                {
                    if (!string.IsNullOrEmpty(r["clubEmail"].ToString()))
                    {
                        stremails = stremails + r["clubEmail"] + ";";
                    }
                }
                if (!string.IsNullOrEmpty(stremails))
                {
                    stremails = stremails.Substring(0, stremails.Length - 1);
                }
            }

            if (stremails.Equals(""))
            {
                TravelAgent.Tool.Javascript.JsAlert("经检测，没有合适的会员！");
            }
            else
            {
                ArrayList al = new ArrayList();
                string[] arryEmail = stremails.Split(';');
                foreach (string s in arryEmail)
                {
                    al.Add(s);
                }
                System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient();
                smtp.Host = webinfo.EmailSmtp;
                smtp.Port = Convert.ToInt32(webinfo.EmailPort);
                bool send = TravelAgent.Tool.EmailHelper.SendMail(al, this.txtTitle.Text+"-"+webinfo.WebName, this.txtEmailContent.Value, 1, null,webinfo.EmailUsername,webinfo.EmailPassword,webinfo.EmailAccount,smtp);
                if (send)
                {
                    TravelAgent.Tool.Javascript.JsAlert("发送成功");
                }
                else
                {
                    TravelAgent.Tool.Javascript.JsAlert("发送失败，请联系网站管理员！");
                }
            }
        }
        /// <summary>
        /// 绑定会员级别
        /// </summary>
        private void BindClubClass()
        {
            Hashtable ht = TravelAgent.Tool.EnumHelper.GetMemberKeyValue<TravelAgent.Tool.EnumSummary.ClubClass>();//数据源
            foreach (DictionaryEntry de in ht)
            {
                ListItem item = new ListItem(de.Key.ToString(), de.Value.ToString());
                item.Attributes.Add("alt", item.Value);
                this.chkClubClass.Items.Add(item);
            }
        }
    }
}
