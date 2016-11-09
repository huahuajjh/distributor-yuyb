using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TravelAgent.Web.admin.product
{
    public partial class LineZixunList : TravelAgent.Web.UI.BasePage
    {
        public int pcount;                                   //总条数
        public int page;                                     //当前页
        public readonly int pagesize = 10;                    //设置每页显示的大小

        public string linename = "";
        public string linecontent = "";
        private static readonly TravelAgent.BLL.LineConsult ConsultBll = new TravelAgent.BLL.LineConsult();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.Params["name"]))
            {
                this.linename = Request.Params["name"].Trim();
            }
            if (!string.IsNullOrEmpty(Request.Params["content"]))
            {
                this.linecontent = Request.Params["content"].Trim();
            }
            if (!this.IsPostBack)
            {
                RptBind("a.Id>0" + this.CombSqlTxt(this.linename, this.linecontent), "a.ConsultDate desc");

                if (Admin.Role.roleAuth.IndexOf(",linezixun_delete,") <= -1)
                {
                    this.lbtnDel.Enabled = false;
                }
            }
        }
        /// <summary>
        /// 显示编辑按钮
        /// </summary>
        /// <param name="id"></param>
        /// <param name="title"></param>
        /// <returns></returns>
        public string ShowEdit(string id,int isreply)
        {
            StringBuilder sbEdit = new StringBuilder();
            if (Admin.Role.roleAuth.IndexOf(",linezixun_update,") > -1)
            {
                sbEdit.Append("<a href=\"EditZixun.aspx?id="+id+"\" class=\"tablelink zixun_art\" title=\"回复\" width=\"700px\" height=\"300px\">回复</a> ");
            }
            if (Admin.Role.roleAuth.IndexOf(",linezixun_delete,") > -1)
            {
                sbEdit.Append("<a id=\"" + id + "\" href=\"#\" class=\"tablelink linelist_delete\">删除</a> ");
            }
        
            return sbEdit.ToString();
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
            this.pcount = ConsultBll.GetCount(strWhere);
            if (this.pcount > 0)
            {
                this.lbtnDel.Enabled = true;
            }
            else
            {
                this.lbtnDel.Enabled = false;
            }
            
            this.txtLineName.Text = this.linename;
            this.txtLineZixun.Text = this.linecontent;
            DataSet ds = ConsultBll.GetPageList(this.pagesize, this.page, strWhere, orderby);
            this.rptList.DataSource = ds;
            this.rptList.DataBind();
            this.trNoRecord.Style["display"] = ds.Tables[0].Rows.Count == 0 ? "" : "none";
            this.trPagination.Style["display"] = ds.Tables[0].Rows.Count == 0 ? "none" : "";
        }
        /// <summary>
        /// 组合SQL语句
        /// </summary>
        /// <param name="_classId"></param>
        /// <param name="_keywords"></param>
        /// <returns></returns>
        protected string CombSqlTxt(string _keywords, string _code)
        {
            StringBuilder strTemp = new StringBuilder();
            _keywords = _keywords.Replace("'", "");
           
            if (!string.IsNullOrEmpty(_keywords))
            {
                strTemp.Append(" and b.lineName like '%" + _keywords + "%'");
            }
            if (!string.IsNullOrEmpty(_code))
            {
                strTemp.Append(" and a.ConsultContent like '%" + _code + "%'");
            }
            return strTemp.ToString();
        }
        /// <summary>
        /// 组合URL语句
        /// </summary>
        /// <param name="_classId"></param>
        /// <param name="_keywords"></param>
        /// <returns></returns>
        protected string CombUrlTxt(string _keywords, string _code)
        {
            StringBuilder strTemp = new StringBuilder();
            
            if (!string.IsNullOrEmpty(_keywords))
            {
                strTemp.Append("name=" + Server.UrlEncode(_keywords) + "&");
            }
            if (!string.IsNullOrEmpty(_code))
            {
                strTemp.Append("content=" + Server.UrlEncode(_code) + "&");
            }
            return strTemp.ToString();
        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnQuery_Click(object sender, EventArgs e)
        {
            Response.Redirect("LineZixunList.aspx?" + this.CombUrlTxt(this.txtLineName.Text.Trim(), this.txtLineZixun.Text.Trim()) + "page=0");
        }
        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbtnDel_Click(object sender, EventArgs e)
        {
            //批量删除
            for (int i = 0; i < rptList.Items.Count; i++)
            {
                int id = Convert.ToInt32(((Label)rptList.Items[i].FindControl("lb_id")).Text);
                CheckBox cb = (CheckBox)rptList.Items[i].FindControl("cb_id");
                if (cb.Checked)
                {
                    ConsultBll.Delete(id);
                }
            }
            JscriptPrint("批量删除成功！", "LineZixunList.aspx?" + CombUrlTxt(this.linename, this.linecontent) + "page=0", "Success");
        }
    }
}
