using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TravelAgent.Web
{
    public partial class Diy : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Title = "定制旅行-独立包团" + Master.webinfo.WebName + "-" + Master.webinfo.SEOTitle;
        }
        /// <summary>
        /// 绑定业务类型
        /// </summary>
        /// <returns></returns>
        public string BindBusinessType()
        {
            StringBuilder sb = new StringBuilder();
            Hashtable ht = TravelAgent.Tool.EnumHelper.GetMemberKeyValue<TravelAgent.Tool.EnumSummary.CustomBusinessType>();//数据源
            foreach (DictionaryEntry de in ht)
            {
                sb.Append("<option value=\""+de.Value.ToString()+"\">"+de.Key.ToString()+"</option>");
            }
            return sb.ToString();
        }
    }
}
