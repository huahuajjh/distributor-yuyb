using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TravelAgent.Web
{
    public partial class Opr : System.Web.UI.Page
    {
        public string strcss;
        protected void Page_Load(object sender, EventArgs e)
        {
            string strmsg = "";

            if (!this.IsPostBack)
            {
                if (Request.QueryString["t"] != null)
                {
                    string strtag = Request.QueryString["t"];
                    if (strtag.Equals("error"))
                    {
                        strcss = "error_ico";
                        this.ltTag.Text = "操作失败！";
                        this.Title = "操作失败";
                    }
                    else if (strtag.Equals("success"))
                    {
                        strcss = "success_ico";
                        this.ltTag.Text = "操作成功！";
                        this.Title = "操作成功";
                    }
                }
                if (Request.QueryString["msg"] != null)
                {
                    string strTag = Server.UrlDecode(Request.QueryString["msg"]);
                    if (strTag.Equals("opr"))
                    {
                        strmsg = "很抱歉，操作失败，原因是 \"网站发生错误，请联系网站工作人员！\"";
                    }
                    else if (strTag.Equals("login"))
                    {
                        strmsg = "很抱歉，操作失败，原因是 \"用户名或者密码错误！\"";
                    }
                    else if (strTag.Equals("no"))
                    {
                        strmsg = "很抱歉，你访问的产品已不存在，请联系网站客服人员！\"";
                    }
                    else
                    {
                        strmsg = strTag;
                    }
                }
                ltMsg.Text = strmsg;
            }
        }
    }
}
