using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace TravelAgent.Web.admin.common
{
    public partial class EditNew : TravelAgent.Web.UI.BasePage
    {
        public readonly int kindId = 0; //类别种类
        private static readonly TravelAgent.BLL.Article ArticleBll = new TravelAgent.BLL.Article();
        private static readonly TravelAgent.BLL.Category CategoryBll = new TravelAgent.BLL.Category();
        private static readonly TravelAgent.BLL.Destination DestBll = new TravelAgent.BLL.Destination();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                DataBindCategory();
                if (Request.QueryString["id"] != null)
                {
                    TravelAgent.Model.Article model = ArticleBll.GetModel(Convert.ToInt32(Request.QueryString["id"]));
                    if (model != null)
                    {
                        this.ltTag1.Text = "修改内容";
                        this.txtTitle.Text = model.Title;
                        this.txtForm.Text = model.Form;
                        this.SEOKeywords.Value = model.Keyword;
                        this.SEOTitle.Value = model.Zhaiyao;
                        this.SEODescription.Value = model.Daodu;
                        this.ddlCategory.SelectedValue = model.ClassId.ToString();
                        this.txtImgUrl.Text = model.ImgUrl;
                        this.txtContent.Value = model.Content;
                        this.txtClick.Text = model.Click.ToString();
                        this.txtUrl.Text = model.LinkUrl;
                        this.checkHidden.Checked = model.IsLock == 1;
                        if (!model.DestId.Equals(""))
                        {
                            DataBindDestType(Convert.ToInt32(model.DestId), model.Dest);
                        }
                        else
                        {
                            DataBindDestType(null, null);
                        }
                        this.ddlDestType.SelectedValue = model.DestId;
                        this.hidDest.Value = model.Dest;
                    }
                }
                else
                {
                    DataBindDestType(null, null);
                }
            }
        }
        /// <summary>
        /// 绑定内容分类
        /// </summary>
        private void DataBindCategory()
        {
            DataTable dt = getCategory();

            this.ddlCategory.Items.Clear();
            this.ddlCategory.Items.Add(new ListItem("选择分类", ""));
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
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            TravelAgent.Model.Article model = new TravelAgent.Model.Article();
            model.Title = this.txtTitle.Text.Trim();
            model.Author="";//发布者
            model.Form = this.txtForm.Text.Trim();
            model.Keyword = this.SEOKeywords.Value.Trim();
            model.Zhaiyao = this.SEOTitle.Value.Trim();
            model.Daodu = this.SEODescription.Value.Trim();
            model.ClassId = Convert.ToInt32(this.ddlCategory.SelectedValue);
            model.ImgUrl = this.txtImgUrl.Text;
            model.Content = this.txtContent.Value.Trim();
            model.Click = Convert.ToInt32(this.txtClick.Text);//序号
            model.IsLock = this.checkHidden.Checked?1:0;
            model.LinkUrl = this.txtUrl.Text.Trim();
            model.AddTime = DateTime.Now;
            model.DestId = this.ddlDestType.SelectedValue;
            model.Dest = this.hidDest.Value;
            string stringUrl = Request.Url.ToString();
            try
            {
                if (Request.QueryString["id"] != null)
                {
                    model.Id = Convert.ToInt32(Request.QueryString["id"]);
                    ArticleBll.Update(model);
                    JscriptPrint("保存成功！", "NewList.aspx", "Success");
                }
                else
                {
                    ArticleBll.Add(model);
                    JscriptPrint("添加成功！", "NewList.aspx", "Success");
                }
            }
            catch
            {
                JscriptPrint("保存失败！", stringUrl, "Error");
            }
        }
        /// <summary>
        /// 获得分类
        /// </summary>
        /// <returns></returns>
        private DataTable getCategory()
        {
            DataTable dtCategory = null;
            bool bolExist = TravelAgent.Tool.CacheHelper.Exists("Category");

            if (bolExist)
            {
                dtCategory = TravelAgent.Tool.CacheHelper.Get<DataTable>("Category");
            }
            else
            {
                dtCategory = CategoryBll.GetList(0, this.kindId);
                TravelAgent.Tool.CacheHelper.Add<DataTable>("Category", dtCategory);
            }

            return dtCategory;
        }
        /// <summary>
        /// 绑定目的地
        /// </summary>
        private void DataBindDestType(int? id, string dest)
        {
            StringBuilder sb = new StringBuilder();
            ListItem item = null;
            DataTable dt = DestBll.GetList(0, 0);
            DataRow[] drs = dt.Select("navLayer=1 and isLock=0", "navSort asc");
            for (int i = 0; i < drs.Length; i++)
            {
                item = new ListItem(drs[i].ItemArray[1].ToString(), drs[i].ItemArray[0].ToString());
                if (id == null)
                {
                    //if (i == 0)
                    //{
                    //    item.Selected = true;
                    //    sb.Append("<div class=\"lineDest\" id=\"DestContainer_" + drs[i]["Id"].ToString() + "\" style=\"display:\">");
                    //}
                    //else
                    //{
                        sb.Append("<div class=\"lineDest\" id=\"DestContainer_" + drs[i]["Id"].ToString() + "\" style=\"display:none\">");
                    //}
                }
                else
                {
                    if (item.Value == id.ToString())
                    {
                        item.Selected = true;
                        sb.Append("<div class=\"lineDest\" id=\"DestContainer_" + drs[i]["Id"].ToString() + "\" style=\"display:\">");
                    }
                    else
                    {
                        sb.Append("<div class=\"lineDest\" id=\"DestContainer_" + drs[i]["Id"].ToString() + "\" style=\"display:none\">");
                    }
                }
                sb.Append(DataBindSubDest(Convert.ToInt32(drs[i]["Id"]), dest, dt));
                sb.Append("</div>");
                this.ddlDestType.Items.Add(item);
            }
            this.ddlDestType.Items.Insert(0, new ListItem("--请选择--", ""));
            this.divDest.InnerHtml = sb.ToString();
        }
        /// <summary>
        /// 绑定子集
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private string DataBindSubDest(int id, string dest, DataTable dt)
        {
            StringBuilder sb = new StringBuilder();
            //DataRow[] drs = dt.Select("navList like '%," + id + ",%'");
            foreach (DataRow row in dt.Rows)
            {
                if (row["navList"].ToString().IndexOf("," + id + ",") >= 0)
                {
                    if (row["navLayer"].ToString().Equals("2"))
                    {
                        sb.Append("<div class=\"lineSubDest\"><label>" + row["navName"] + "</label> </div>");
                    }
                    else if (row["navLayer"].ToString().Equals("3"))
                    {
                        if (string.IsNullOrEmpty(dest))
                        {
                            sb.Append("<label><input type=\"checkbox\"   value=\"" + row["Id"] + "\"  name=\"dest\">" + row["navName"] + "</label>");
                        }
                        else
                        {
                            if (dest.Contains("," + row["Id"].ToString() + ","))
                            {
                                sb.Append("<label><input type=\"checkbox\"   value=\"" + row["Id"] + "\"  name=\"dest\" checked=\"checked\">" + row["navName"] + "</label>");
                            }
                            else
                            {
                                sb.Append("<label><input type=\"checkbox\"   value=\"" + row["Id"] + "\"  name=\"dest\">" + row["navName"] + "</label>");
                            }
                        }
                    }
                }
            }
            return sb.ToString();
        }
    }
}
