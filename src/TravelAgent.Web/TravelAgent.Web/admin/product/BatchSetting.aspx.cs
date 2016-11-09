using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TravelAgent.Web.admin.product
{
    public partial class BatchSetting : System.Web.UI.Page
    {
        private static readonly TravelAgent.BLL.LineHoliday HolidayBll = new TravelAgent.BLL.LineHoliday();
        private static readonly TravelAgent.BLL.LineTheme ThemeBll = new TravelAgent.BLL.LineTheme();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["ids"] != null)
            {
                this.hidlineids.Value = Request.QueryString["ids"];
            }
            if (!this.IsPostBack)
            {
                DataBindTheme();
                DataBindState();
                DataBindHoliday();
            }
        }
        /// <summary>
        /// 绑定线路主题
        /// </summary>
        private void DataBindTheme()
        {
            DataSet ds = ThemeBll.GetList("isLock=0");
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                ListItem item = new ListItem(row["themeName"].ToString(), row["Id"].ToString());
                item.Attributes.Add("alt", item.Value);
                chkTheme.Items.Add(item);
            }
        }
        /// <summary>
        /// 绑定状态属性
        /// </summary>
        private void DataBindState()
        {
            Hashtable ht = TravelAgent.Tool.EnumHelper.GetMemberKeyValue<TravelAgent.Tool.EnumSummary.State>();//数据源
            foreach (DictionaryEntry de in ht)
            {
                ListItem item = new ListItem(de.Key.ToString(), de.Value.ToString());
                item.Attributes.Add("alt", item.Value);
                chkState.Items.Add(item);
            }
        }
        /// <summary>
        /// 绑定节日
        /// </summary>
        private void DataBindHoliday()
        {
            DataSet ds = HolidayBll.GetList();
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                ListItem item = new ListItem(row["holidayName"].ToString(), row["Id"].ToString());
                item.Attributes.Add("alt", item.Value);
                chkHoliday.Items.Add(item);
            }
        }
    }
}
