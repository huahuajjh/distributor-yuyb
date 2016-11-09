using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TravelAgent.Web.admin.common
{
    public partial class BarList : System.Web.UI.Page
    {
        public int aid;
        private static readonly TravelAgent.BLL.Advertising advBll = new TravelAgent.BLL.Advertising();
        private static readonly TravelAgent.BLL.Adbanner banBll = new TravelAgent.BLL.Adbanner();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (Request.QueryString["aid"] != null)
                {
                    aid = Convert.ToInt32(Request.QueryString["aid"]);
                    TravelAgent.Model.Advertising adv = advBll.GetModel(aid);
                    if (adv != null)
                    {
                        this.lblAdvName.Text = adv.Title;
                    }
                    DataBindBan(aid);
                }
            }
        }
        /// <summary>
        /// 绑定
        /// </summary>
        /// <param name="aid"></param>
        protected void DataBindBan(int aid)
        {
            DataSet ds = banBll.GetList("Aid="+aid);
            this.rptList.DataSource = ds.Tables[0].DefaultView;
            this.rptList.DataBind();
            this.trNoRecord.Style["display"] = ds.Tables[0].Rows.Count == 0 ? "block" : "none";
        }
        /// <summary>
        /// 显示广告的状态
        /// </summary>
        /// <param name="strLock"></param>
        /// <param name="strTime"></param>
        /// <returns></returns>
        protected string GetAdState(string strLock, string strTime)
        {
            if (int.Parse(strLock) == 1)
            {
                return "<font color=\"#999999\">暂停</font>";
            }
            else if (DateTime.Compare(DateTime.Parse(strTime), DateTime.Today) == -1)
            {
                return "<font color=\"#FF0000\">已过期</font>";
            }
            else
            {
                return "<font color=\"#009900\">正常</font>";
            }
        }
    }
}
