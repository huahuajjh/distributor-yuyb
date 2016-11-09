using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;

namespace TravelAgent.Web.admin.common
{
    public partial class LinkList : TravelAgent.Web.UI.BasePage
    {
        private static readonly TravelAgent.BLL.Links linkBll = new TravelAgent.BLL.Links();
        public int pcount;                                   //总条数
        public int page;                                     //当前页
        public readonly int pagesize = 15;                    //设置每页显示的大小
        public string keywords = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.Params["keywords"]))
            {
                this.keywords = Request.Params["keywords"].Trim();
            }
            if (!this.IsPostBack)
            {
                RptBind("Id>0" + this.CombSqlTxt(this.keywords), "AddTime desc");
                if (Admin.Role.roleAuth.IndexOf(",linkk_delete,") <= -1)
                {
                    this.lbtnDel.Enabled = false;
                }
            }
        }
        /// <summary>
        /// 显示按钮
        /// </summary>
        /// <returns></returns>
        public string ShowButton()
        {
            StringBuilder sbButton = new StringBuilder();
            if (Admin.Role.roleAuth.IndexOf(",linkk_add,") > -1)
            {
                sbButton.Append("<li><a href=\"EditLink.aspx\" class=\"link_art\" title=\"添加链接\" width=\"700px\" height=\"400px\"><span><img src=\"../images/t01.png\" /></span>添加链接</a></li>");
            }
            return sbButton.ToString();
        }
        /// <summary>
        /// 显示编辑按钮
        /// </summary>
        /// <param name="id"></param>
        /// <param name="title"></param>
        /// <returns></returns>
        public string ShowEdit(string id,string title)
        {
            StringBuilder sbEdit = new StringBuilder();
            if (Admin.Role.roleAuth.IndexOf(",linkk_update,") > -1)
            {
                sbEdit.Append("<a href=\"EditLink.aspx?id="+id+"\" class=\"tablelink link_art\" width=\"700px\" height=\"400px\">修改</a> ");
            }
            if (Admin.Role.roleAuth.IndexOf(",linkk_delete,") > -1)
            {
                sbEdit.Append("<a id=\""+id+"\" name=\""+title+"\" href=\"#\" class=\"tablelink link_delete\">删除</a> ");
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
            this.pcount = linkBll.GetCount(strWhere);
            if (this.pcount > 0)
            {
                this.lbtnDel.Enabled = true;
            }
            else
            {
                this.lbtnDel.Enabled = false;
            }
        
            this.txtKeywords.Text = this.keywords;
            DataSet ds = linkBll.GetPageList(this.pagesize, this.page, strWhere, orderby);
            this.rptLinks.DataSource = ds;
            this.rptLinks.DataBind();
            this.trNoRecord.Style["display"] = ds.Tables[0].Rows.Count == 0 ? "" : "none";
            this.trPagination.Style["display"] = ds.Tables[0].Rows.Count == 0 ? "none" : "";
        }
        /// <summary>
        /// 组合SQL语句
        /// </summary>
        /// <param name="_classId"></param>
        /// <param name="_keywords"></param>
        /// <returns></returns>
        protected string CombSqlTxt(string _keywords)
        {
            StringBuilder strTemp = new StringBuilder();
            _keywords = _keywords.Replace("'", "");
            if (!string.IsNullOrEmpty(_keywords))
            {
                strTemp.Append(" and Title like '%" + _keywords + "%'");
            }

            return strTemp.ToString();
        }
        /// <summary>
        /// 组合URL语句
        /// </summary>
        /// <param name="_classId"></param>
        /// <param name="_keywords"></param>
        /// <returns></returns>
        protected string CombUrlTxt(string _keywords)
        {
            StringBuilder strTemp = new StringBuilder();
            if (!string.IsNullOrEmpty(_keywords))
            {
                strTemp.Append("keywords=" + Server.UrlEncode(_keywords) + "&");
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
            Response.Redirect("LinkList.aspx?" + this.CombUrlTxt(txtKeywords.Text.Trim()) + "page=0");
        }
        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbtnDel_Click(object sender, EventArgs e)
        {
            //批量删除
            for (int i = 0; i < rptLinks.Items.Count; i++)
            {
                int id = Convert.ToInt32(((Label)rptLinks.Items[i].FindControl("lb_id")).Text);
                CheckBox cb = (CheckBox)rptLinks.Items[i].FindControl("cb_id");
                if (cb.Checked)
                {
                    linkBll.Delete(id);
                }
            }
            JscriptPrint("批量删除成功！", "LinkList.aspx?" + CombUrlTxt(this.keywords) + "page=0", "Success");
        }
    }
}
