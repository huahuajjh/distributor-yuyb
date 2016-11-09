using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TravelAgent.Web.member
{
    public partial class MyInfo : System.Web.UI.Page
    {
        public TravelAgent.Model.Club club;
        private static readonly TravelAgent.BLL.Club clubBll = new TravelAgent.BLL.Club();
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Title = "个人资料-" + Master.webinfo.WebName;
            string strUid = TravelAgent.Tool.CookieHelper.GetCookieValue("uid");
            if (string.IsNullOrEmpty(strUid))
            {
                Response.Redirect("/member/Login.aspx");
            }
            else
            {
                club = clubBll.GetModel(Convert.ToInt32(strUid));
                this.ltMemberName.Text = club.clubName;
            }
        }
        /// <summary>
        /// 显示性别选中
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public string ShowSexChecked()
        {
            string strValue = "";
            if (club.clubSex.Equals("1"))
            {
                strValue = "<input class=\"input_radio\" id=\"sex1\" name=\"sex\" value=\"1\" type=\"radio\" checked=\"checked\">男 <input class=\"input_radio\" id=\"sex2\" name=\"sex\" value=\"0\" type=\"radio\"> 女";
            }
            else
            {
                strValue = "<input class=\"input_radio\" id=\"sex1\" name=\"sex\" value=\"1\" type=\"radio\">男 <input class=\"input_radio\" id=\"sex2\" name=\"sex\" value=\"0\" type=\"radio\"  checked=\"checked\"> 女";
            }
            return strValue;
        }
    }
}
