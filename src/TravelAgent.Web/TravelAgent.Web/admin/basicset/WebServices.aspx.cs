using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TravelAgent.Web.admin.basicset
{
    public partial class WebServices : TravelAgent.Web.UI.BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                DataBindServices();
                if (Admin.Role.roleAuth.IndexOf(",sysbase_update,") <= -1)
                {
                    this.btnSave.Visible = false;
                }
            }
        }
        /// <summary>
        /// 绑定客服列表
        /// </summary>
        private void DataBindServices()
        {
            this.rbtnQQServices.SelectedValue = webinfo.QQServiceState.ToString();
            DataBindServicesList();
        }
        /// <summary>
        /// 绑定客服详细信息
        /// </summary>
        private void DataBindServicesList()
        {
            StringBuilder stringbuilder = new StringBuilder();
            stringbuilder.Append("<table style=\"text-align:right; color:#056dae;width:99%;\" id=\"tblQQServices\">");
            stringbuilder.Append("<tr style=\"background: #F5F5F5; \">");
            stringbuilder.Append("<td style=\"text-align:center; width:20%\">组名</td>");
            stringbuilder.Append("<td style=\"text-align:center; width:70%\">客服QQ[多个QQ用,号分开]</td>");
            stringbuilder.Append("<td style=\"text-align:center\"><a href=\"javascript:void(0);\" onclick=\"AddQQService()\">[增加]</a></td>");
            stringbuilder.Append("</tr>");
            if (webinfo.QQServices.Equals(""))
            {
                stringbuilder.Append("<tr class=\"trChild\">");
                stringbuilder.Append("<td style=\" text-align:left;\"><input id=\"txtQQServiceName_1\" name=\"txtQQServiceName_1\" type=\"text\" class=\"dfinput\" style=\" width:96%\" maxlength=\"4\" /></td>");
                stringbuilder.Append("<td style=\" text-align:left;\"><input id=\"txtQQServiceList_1\" name=\"txtQQServiceList_1\" type=\"text\" class=\"dfinput\" style=\" width:98%\" /></td>");
                stringbuilder.Append("<td style=\"text-align:center\"><a href=\"javascript:void(0);\" onclick=\"DeleteQQService(this);\">[删除]</a></td>");
                stringbuilder.Append("</tr>");
                this.hidQQServiceCount.Value = "1";
            }
            else
            {
                string[] strArryQQService = webinfo.QQServices.Split(new char[] { '|' });
                this.hidQQServiceCount.Value = strArryQQService.Length.ToString();
                for (int i = 0; i < strArryQQService.Length; i++)
                {
                    if (!strArryQQService[i].Equals(""))
                    {
                        string[] strArryServiceDetail = strArryQQService[i].Split(new char[] { ':' });
                        stringbuilder.Append("<tr class=\"trChild\">");
                        stringbuilder.Append("<td style=\" text-align:left;\"><input id=\"txtQQServiceName_" + (i + 1) + "\" name=\"txtQQServiceName_" + (i + 1) + "\" type=\"text\" class=\"dfinput\" style=\" width:96%\" maxlength=\"4\" value=\"" + strArryServiceDetail[0] + "\" /></td>");
                        stringbuilder.Append("<td style=\" text-align:left;\"><input id=\"txtQQServiceList_" + (i + 1) + "\" name=\"txtQQServiceList_" + (i + 1) + "\" type=\"text\" class=\"dfinput\" style=\" width:98%\" value=\"" + strArryServiceDetail[1] + "\" /></td>");
                        stringbuilder.Append("<td style=\"text-align:center\"><a href=\"javascript:void(0);\" onclick=\"DeleteQQService(this);\">[删除]</a></td>");
                        stringbuilder.Append("</tr>");
                    }
                  
                }
            }
            stringbuilder.Append("</table>");
            this.divQQServices.InnerHtml = stringbuilder.ToString();
        }
    }
}
