using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using TravelAgent.Tool;

namespace TravelAgent.Web.admin.club
{
    public partial class GroupSMS : TravelAgent.Web.UI.BasePage
    {
        public int pHandle=0;
        public string strtels;
        private static TravelAgent.BLL.Club ClubBll = new TravelAgent.BLL.Club();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                //int loginResult = CSMS.Login(webinfo.SmsHostname, 80, webinfo.SmsUsername, webinfo.SmsPassword, ref pHandle);
                //if (loginResult < 0)
                //{
                    //TravelAgent.Tool.Javascript.JsAlert("短信平台连接短信网关失败，请与短信提供商联系！");
               // }
              
                BindClubClass();
                if (Request.QueryString["va"] != null)
                {
                    strtels = Request.QueryString["va"];
                    this.txtMobiles.Text = Request.QueryString["va"];
                }

                if (Admin.Role.roleAuth.IndexOf(",sms_opr,") <= -1)
                {
                    this.btnSave.Visible = false;
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            strtels="";
            if (this.ddlRule.SelectedValue == "1")//指定会员
            {
                strtels = this.txtMobiles.Text;
            }
            else if (this.ddlRule.SelectedValue == "2")//注册日期
            {
                DataSet dsClub = ClubBll.GetList(0, "regDate>='" + Convert.ToDateTime(this.txtStartDate.Text) + "' and regDate<='"+Convert.ToDateTime(this.txtEndDate.Text)+"'", "regDate desc");
                foreach (DataRow r in dsClub.Tables[0].Rows)
                {
                    if (!string.IsNullOrEmpty(r["clubMobile"].ToString()))
                    {
                        strtels = strtels + r["clubMobile"] + ",";
                    }
                }
                if (!string.IsNullOrEmpty(strtels))
                {
                    strtels = strtels.Substring(0, strtels.Length - 1);
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
                DataSet dsclub = ClubBll.GetList(0, "classId in ("+strclass+")", "regDate desc");
                foreach (DataRow r in dsclub.Tables[0].Rows)
                {
                    if (!string.IsNullOrEmpty(r["clubMobile"].ToString()))
                    {
                        strtels = strtels + r["clubMobile"] + ",";
                    }
                }
                if (!string.IsNullOrEmpty(strtels))
                {
                    strtels = strtels.Substring(0, strtels.Length - 1);
                }
            }

            if (strtels.Equals(""))
            {
                TravelAgent.Tool.Javascript.JsAlert("经检测，没有合适的会员！");
            }
            else
            {
                //int tellength = strtels.Split(',').Length;
                //int sendtextReuslt = CSMS.SendText(Convert.ToInt32(ViewState["pHandle"]), this.txtSMSContent.Value, "", tellength);
                bool r = SMSUtil.Send(strtels, this.txtSMSContent.Value);   //write by jjh

                if (/*sendtextReuslt > 0*/r)
                {
                    //int result = CSMS.SendPhones(pHandle, sendtextReuslt, strNumTemp);
                    //if (result == 0)
                    //{
                    //    Club.Common.Javascript.JsAlert("发送成功");
                    //}
                    //else
                    //{
                    //    Club.Common.Javascript.JsAlert("发送号码错误：" + result.ToString());
                    //}
                    //循环发送
                    //SendTelphone(strtels.Split(','), sendtextReuslt);
                    //TravelAgent.Tool.Javascript.JsAlert("发送成功");
                    TravelAgent.Tool.Javascript.JsAlert("发送成功");    //modify by jjh
                }
                else
                {
                    TravelAgent.Tool.Javascript.JsAlert("发送失败");   //modify by jjh
                }
            }


        }
        /// <summary>
        /// 循环发送
        /// </summary>
        private void SendTelphone(string[] arryTel, int sendtextReuslt)
        {
            //if (arryTel.Length > 100)
            //{
            //    CSMS.SendPhones(pHandle, sendtextReuslt, GetTelephone(arryTel.Take(100).ToArray()));
            //
            //    SendTelphone(arryTel.Skip(100).ToArray(), sendtextReuslt);
            //}
            //else
            //{
            //    CSMS.SendPhones(pHandle, sendtextReuslt, GetTelephone(arryTel));
            //}
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="strtel"></param>
        /// <returns></returns>
        private string GetTelephone(string[] strtel)
        {
            string strvalue = "";

            for (int i = 0; i <= strtel.Length - 1; i++)
            {
                strvalue = strvalue + strtel[i].Replace("\r\n", "") + ",";
            }

            return strvalue != "" ? strvalue.Substring(0, strvalue.Length - 1) : "";
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
