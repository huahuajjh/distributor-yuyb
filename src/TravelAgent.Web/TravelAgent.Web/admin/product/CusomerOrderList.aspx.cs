using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TravelAgent.Web.admin.product
{
    public partial class CusomerOrderList : TravelAgent.Web.UI.BasePage
    {
        private static readonly TravelAgent.BLL.CustomOrder Bll = new TravelAgent.BLL.CustomOrder();
        public int pcount;                                   //总条数
        public int page;                                     //当前页
        public readonly int pagesize = 10;                    //设置每页显示的大小
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                RptBind("Id>0", "AddDate desc");

                if (Admin.Role.roleAuth.IndexOf(",customerorder_delete,") <= -1)
                {
                    this.lbtnDel.Enabled = false;
                }
            }
        }
        /// <summary>
        /// 绑定
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="orderby"></param>
        private void RptBind(string strWhere, string orderby)
        {
            if (!int.TryParse(Request.Params["page"] as string, out this.page))
            {
                this.page = 0;
            }
            //获得总条数
            this.pcount = Bll.GetCount(strWhere);
            if (this.pcount > 0)
            {
                this.lbtnDel.Enabled = true;
            }
            else
            {
                this.lbtnDel.Enabled = false;
            }

            DataSet ds = Bll.GetPageList(this.pagesize, this.page, strWhere, orderby);
            this.rptLine.DataSource = ds;
            this.rptLine.DataBind();
            this.trNoRecord.Style["display"] = ds.Tables[0].Rows.Count == 0 ? "" : "none";
            this.trPagination.Style["display"] = ds.Tables[0].Rows.Count == 0 ? "none" : "";
        }
        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbtnDel_Click(object sender, EventArgs e)
        {
            //批量删除
            for (int i = 0; i < rptLine.Items.Count; i++)
            {
                int id = Convert.ToInt32(((Label)rptLine.Items[i].FindControl("lb_id")).Text);
                CheckBox cb = (CheckBox)rptLine.Items[i].FindControl("cb_id");
                if (cb.Checked)
                {
                    Bll.Delete(id);
                }
            }
            JscriptPrint("批量删除成功！", "CusomerOrderList.aspx?page=0", "Success");
        }
    }
}
