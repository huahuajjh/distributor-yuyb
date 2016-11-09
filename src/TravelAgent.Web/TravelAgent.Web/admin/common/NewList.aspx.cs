using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;

namespace TravelAgent.Web.admin.common
{
    public partial class NewList : TravelAgent.Web.UI.BasePage
    {
        public readonly int kindId = 0; //类别种类
        private static readonly TravelAgent.BLL.Article ArticleBll = new TravelAgent.BLL.Article();
        private static readonly TravelAgent.BLL.Category CategoryBll = new TravelAgent.BLL.Category();
        public int pcount;                                   //总条数
        public int page;                                     //当前页
        public readonly int pagesize = 15;                    //设置每页显示的大小

        public int classId;
        public string keywords = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!int.TryParse(Request.Params["classId"] as string, out this.classId))
            {
                this.classId = 0;
            }
            if (!string.IsNullOrEmpty(Request.Params["keywords"]))
            {
                this.keywords = Request.Params["keywords"].Trim();
            }
            if (!this.IsPostBack)
            {
                DataBindCategory();
                RptBind("Id>0" + this.CombSqlTxt(this.classId, this.keywords), "AddTime desc");
                if (Admin.Role.roleAuth.IndexOf(",articlelst_delete,") <= -1)
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
            if (Admin.Role.roleAuth.IndexOf(",articlelst_add,") > -1)
            {
                sbButton.Append("<li><a href=\"EditNew.aspx\"><span><img src=\"../images/t01.png\" /></span>添加内容</a></li>");
            }
            return sbButton.ToString();
        }
        /// <summary>
        /// 显示编辑按钮
        /// </summary>
        /// <param name="id"></param>
        /// <param name="title"></param>
        /// <returns></returns>
        public string ShowEdit(string id)
        {
            StringBuilder sbEdit = new StringBuilder();
            if (Admin.Role.roleAuth.IndexOf(",articlelst_update,") > -1)
            {
                sbEdit.Append("<a href=\"EditNew.aspx?id=" + id + "\" class=\"tablelink\">修改</a> ");
            }
            if (Admin.Role.roleAuth.IndexOf(",articlelst_delete,") > -1)
            {
                sbEdit.Append("<a id=\"" + id + "\" href=\"#\" class=\"tablelink new_delete\">删除</a> ");
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
            this.pcount = ArticleBll.GetCount(strWhere);
            if (this.pcount > 0)
            {
                this.lbtnDel.Enabled = true;
            }
            else
            {
                this.lbtnDel.Enabled = false;
            }
            if (this.classId > 0)
            {
                this.ddlCategory.SelectedValue = this.classId.ToString();
            }
            this.txtKeywords.Text = this.keywords;
            DataSet ds = ArticleBll.GetPageList(this.pagesize, this.page, strWhere, orderby);
            this.rptNews.DataSource = ds;
            this.rptNews.DataBind();
            this.trNoRecord.Style["display"] = ds.Tables[0].Rows.Count == 0 ? "" : "none";
            this.trPagination.Style["display"] = ds.Tables[0].Rows.Count == 0 ? "none" : "";
        }
        /// <summary>
        /// 组合SQL语句
        /// </summary>
        /// <param name="_classId"></param>
        /// <param name="_keywords"></param>
        /// <returns></returns>
        protected string CombSqlTxt(int _classId, string _keywords)
        {
            StringBuilder strTemp = new StringBuilder();
            _keywords = _keywords.Replace("'", "");
            if (_classId > 0)
            {
                strTemp.Append(" and ClassId = " + _classId + "");
            }
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
        protected string CombUrlTxt(int _classId, string _keywords)
        {
            StringBuilder strTemp = new StringBuilder();
            if (_classId > 0)
            {
                strTemp.Append("classId=" + _classId.ToString() + "&");
            }
            if (!string.IsNullOrEmpty(_keywords))
            {
                strTemp.Append("keywords=" + Server.UrlEncode(_keywords) + "&");
            }
            return strTemp.ToString();
        }
        /// <summary>
        /// 绑定内容分类
        /// </summary>
        private void DataBindCategory()
        {
            DataTable dt = getCategory();

            this.ddlCategory.Items.Clear();
            this.ddlCategory.Items.Add(new ListItem("选择分类", "0"));
            foreach (DataRow dr in dt.Rows)
            {
                int ClassLayer = Convert.ToInt32(dr["ClassLayer"]);
                string Id = dr["Id"].ToString().Trim();
                string Name = dr["Title"].ToString().Trim();

                if (ClassLayer == 1)
                {
                    Name = "├ " + Name;
                    this.ddlCategory.Items.Add(new ListItem(Name, Id));

                }
                else
                {
                    Name = "├ " + Name;
                    Name = TravelAgent.Tool.StringPlus.StringOfChar(ClassLayer - 1, "　") + Name;

                    this.ddlCategory.Items.Add(new ListItem(Name, Id));
                }
            }
        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnQuery_Click(object sender, EventArgs e)
        {
            Response.Redirect("NewList.aspx?" + this.CombUrlTxt(Convert.ToInt32(this.ddlCategory.SelectedValue), txtKeywords.Text.Trim()) + "page=0");
        }
        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbtnDel_Click(object sender, EventArgs e)
        {
            //批量删除
            for (int i = 0; i < rptNews.Items.Count; i++)
            {
                int id = Convert.ToInt32(((Label)rptNews.Items[i].FindControl("lb_id")).Text);
                CheckBox cb = (CheckBox)rptNews.Items[i].FindControl("cb_id");
                if (cb.Checked)
                {
                    ArticleBll.Delete(id);
                }
            }
            JscriptPrint("批量删除成功！", "NewList.aspx?" + CombUrlTxt(this.classId, this.keywords) + "page=0", "Success");
        }
        /// <summary>
        /// 获得分类名称
        /// </summary>
        /// <param name="classid"></param>
        /// <returns></returns>
        public string getCategoryName(string classid)
        {
            string strCategoryName = "";
            DataTable dt = getCategory();
            foreach (DataRow row in dt.Rows)
            {
                if (row["Id"].ToString().Equals(classid))
                {
                    strCategoryName = row["Title"].ToString();
                    break;
                }
            }
            return strCategoryName;
        }
        /// <summary>
        /// 获得分类
        /// </summary>
        /// <returns></returns>
        private DataTable getCategory()
        {
            DataTable dtCategory = null;
            bool bolExist= TravelAgent.Tool.CacheHelper.Exists("Category");

            if (bolExist)
            {
                dtCategory = TravelAgent.Tool.CacheHelper.Get<DataTable>("Category");
            }
            else
            {
                dtCategory=CategoryBll.GetList(0, this.kindId);
                TravelAgent.Tool.CacheHelper.Add<DataTable>("Category", dtCategory);
            }

            return dtCategory;
        }
    }
}
