using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TravelAgent.Web.admin.product
{
    public partial class SetHoliday :TravelAgent.Web.UI.mBasePage
    {
        private static readonly TravelAgent.BLL.LineHoliday bll = new TravelAgent.BLL.LineHoliday();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                DataBindHoliday();
                this.ddlHoliday.SelectedValue = webinfo.Holiday.ToString();
            }
        }
        /// <summary>
        /// 绑定节日
        /// </summary>
        private void DataBindHoliday()
        {
            this.ddlHoliday.DataSource = bll.GetList();
            this.ddlHoliday.DataTextField = "holidayName";
            this.ddlHoliday.DataValueField = "Id";
            this.ddlHoliday.DataBind();
            this.ddlHoliday.Items.Insert(0, new ListItem("不设置", "0"));
        }
        
    }
}
