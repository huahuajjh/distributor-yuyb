using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace TravelAgent.Web.admin.common
{
    public partial class EditCategory : TravelAgent.Web.UI.BasePage
    {
        public readonly int kindId = 0; //类别种类
        private static readonly TravelAgent.BLL.Category CategoryBll = new TravelAgent.BLL.Category();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                DataBindCategory();

                if (Request.QueryString["categoryid"] != null)
                {
                    int categoryid = Convert.ToInt32(Request.QueryString["categoryid"]);
                    TravelAgent.Model.Category category = CategoryBll.GetModel(categoryid);

                    if (category != null)
                    {
                        this.hidId.Value = category.Id.ToString();
                        this.ddlCategory.SelectedValue = category.ParentId.ToString();
                        this.txtName.Text = category.Title;
                        this.txtURL.Text = category.PageUrl;
                        this.txtSort.Text = category.ClassOrder.ToString();

                        this.chkState.Checked = category.State.Equals("1");
                    }
                }
                else
                {
                    this.txtSort.Text = (CategoryBll.GetMaxID("ClassOrder") + 1).ToString();
                }
            }
        }
        /// <summary>
        /// 绑定新闻分类
        /// </summary>
        private void DataBindCategory()
        {
            DataTable dt = CategoryBll.GetList(0, this.kindId);

            this.ddlCategory.Items.Clear();
            this.ddlCategory.Items.Add(new ListItem("新闻分类根目录", "0"));
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
    }
}
