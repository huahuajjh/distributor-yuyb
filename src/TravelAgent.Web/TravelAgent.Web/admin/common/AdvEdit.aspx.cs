using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TravelAgent.Web.admin.common
{
    public partial class AdvEdit : TravelAgent.Web.UI.BasePage
    {
        private static readonly TravelAgent.BLL.Advertising bll = new TravelAgent.BLL.Advertising();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                DataBindCategory();
                if (Request.QueryString["id"]!=null)
                {
                    TravelAgent.Model.Advertising model = bll.GetModel(Convert.ToInt32(Request.QueryString["id"]));

                    if (model != null)
                    {
                        this.hidId.Value = model.Id.ToString();
                        this.txtTitle.Text = model.Title;
                        this.rblAdType.SelectedValue = model.AdType.ToString();
                        this.txtAdRemark.Text = model.AdRemark;
                        this.txtAdNum.Text = model.AdNum.ToString();
                        this.txtAdWidth.Text = model.AdWidth.ToString();
                        this.txtAdHeight.Text = model.AdHeight.ToString();
                        this.rblAdTarget.SelectedValue = model.AdTarget;
                        this.ddlAdv.SelectedValue = model.ParentID.ToString();
                        if (model.ParentID == 0)
                        {
                            this.ddlAdv.Enabled = false;
                        }
                    }
                }
               
            }
        }
        /// <summary>
        /// 绑定新闻分类
        /// </summary>
        private void DataBindCategory()
        {
            DataTable dt = bll.GetTableList(0);

            this.ddlAdv.Items.Clear();
            this.ddlAdv.Items.Add(new ListItem("广告位根目录", "0"));
            foreach (DataRow dr in dt.Rows)
            {
                int ClassLayer = Convert.ToInt32(dr["ClassLayer"]);
                string Id = dr["Id"].ToString().Trim();
                string Name = dr["Title"].ToString().Trim();

                if (ClassLayer == 1)
                {
                    Name = "├ " + Name;
                    this.ddlAdv.Items.Add(new ListItem(Name, Id));

                }
                else
                {
                    Name = "├ " + Name;
                    Name = TravelAgent.Tool.StringPlus.StringOfChar(ClassLayer - 1, "　") + Name;

                    this.ddlAdv.Items.Add(new ListItem(Name, Id));
                }
            }
        }
    }
}
