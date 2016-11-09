using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TravelAgent.Web.member
{
    public partial class AccountSafe : System.Web.UI.Page
    {
        public TravelAgent.Model.Club club;
        private static readonly TravelAgent.BLL.Club clubBll = new TravelAgent.BLL.Club();
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Title = "账户安全-" + Master.webinfo.WebName;
            string strUid = TravelAgent.Tool.CookieHelper.GetCookieValue("uid");
            if (string.IsNullOrEmpty(strUid))
            {
                Response.Redirect("/member/Login.aspx");
            }
            else
            {
                club = clubBll.GetModel(Convert.ToInt32(strUid));
            }
        }
        /// <summary>
        /// 显示手机验证
        /// </summary>
        /// <returns></returns>
        public string ShowMobileValidate()
        {
            string strvalue = "ico_tel";
            if (club.mobileIsValid == 1)
            {
                strvalue = "ico_tel_select";
            }
            return strvalue;
        }
        /// <summary>
        /// 显示邮箱验证
        /// </summary>
        /// <returns></returns>
        public string ShowEmailValidate()
        {
            string strvalue = "ico_mail";
            if (club.emailIsValid == 1)
            {
                strvalue = "ico_mail_select";
            }
            return strvalue;
        }
    }
}
