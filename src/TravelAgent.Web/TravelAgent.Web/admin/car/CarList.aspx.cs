using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TravelAgent.Web.admin.car
{
    public partial class CarList : TravelAgent.Web.UI.BasePage
    {
        public int pcount;                                   //总条数
        public int page;                                     //当前页
        public readonly int pagesize = 15;                    //设置每页显示的大小

        public string keyword = "";
        public string brand = "";
        public string classs = "";

        private static readonly TravelAgent.BLL.CarBrand BrandBll = new TravelAgent.BLL.CarBrand();
        private static readonly TravelAgent.BLL.CarClass ClassBll = new TravelAgent.BLL.CarClass();
        private static readonly TravelAgent.BLL.CarList CarBll = new TravelAgent.BLL.CarList();
        protected void Page_Load(object sender, EventArgs e)
        {
            this.brand = Request.Params["brand"] == null ? "" : Request.Params["brand"];
            this.classs = Request.Params["classs"] == null ? "" : Request.Params["classs"];
            if (!string.IsNullOrEmpty(Request.Params["keywords"]))
            {
                this.keyword = Server.UrlDecode(Request.Params["keywords"].Trim());
            }
            if (!this.IsPostBack)
            {
                BindBrand();
                BindClass();
                RptBind("Id>0" + this.CombSqlTxt(this.brand, this.classs, this.keyword), "AddDate desc");
            }
        }
        /// <summary>
        /// 绑定品牌列表
        /// </summary>
        /// <returns></returns>
        private void BindBrand()
        {
            DataSet dsbrand = BrandBll.GetList();
            foreach (DataRow row in dsbrand.Tables[0].Rows)
            {
                this.ddlBrand.Items.Add(new ListItem(row["BrandName"].ToString(), row["Id"].ToString()));
            }
            this.ddlBrand.Items.Insert(0, new ListItem("租车品牌", ""));
        }
        /// <summary>
        /// 绑定级别
        /// </summary>
        private void BindClass()
        {
            DataSet dsClass = ClassBll.GetList();
            foreach (DataRow row in dsClass.Tables[0].Rows)
            {
                this.ddlClass.Items.Add(new ListItem(row["ClassName"].ToString(), row["Id"].ToString()));
            }
            this.ddlClass.Items.Insert(0, new ListItem("租车级别", ""));
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
            this.pcount = CarBll.GetCount(strWhere);
            if (this.pcount > 0)
            {
                this.lbtnDel.Enabled = true;
            }
            else
            {
                this.lbtnDel.Enabled = false;
            }

            this.ddlClass.SelectedValue = this.classs.ToString();
            this.ddlBrand.SelectedValue = this.brand.ToString();
            this.txtKeywords.Text = this.keyword;

            DataSet ds = CarBll.GetPageList(this.pagesize, this.page, strWhere, orderby);
            this.rptClub.DataSource = ds;
            this.rptClub.DataBind();
            this.trNoRecord.Style["display"] = ds.Tables[0].Rows.Count == 0 ? "" : "none";
            this.trPagination.Style["display"] = ds.Tables[0].Rows.Count == 0 ? "none" : "";
        }
        /// <summary>
        /// 组合SQL语句
        /// </summary>
        /// <param name="_classId"></param>
        /// <param name="_keywords"></param>
        /// <returns></returns>
        protected string CombSqlTxt(string _brand, string _classs, string _keywords)
        {
            StringBuilder strTemp = new StringBuilder();
            _keywords = _keywords.Replace("'", "");
            if (!_brand.Equals(""))
            {
                strTemp.Append(" and BrandId = " + _brand + "");
            }
            if (!_classs.Equals(""))
            {
                strTemp.Append(" and ClassId = " + _classs + "");
            }
            if (!string.IsNullOrEmpty(_keywords))
            {
                strTemp.Append(" and CarName like '%" + _keywords + "%'");
            }

            return strTemp.ToString();
        }
        /// <summary>
        /// 组合URL语句
        /// </summary>
        /// <param name="_classId"></param>
        /// <param name="_keywords"></param>
        /// <returns></returns>
        protected string CombUrlTxt(string _brand, string _classs, string _keywords)
        {
            StringBuilder strTemp = new StringBuilder();
            if (!_brand.Equals(""))
            {
                strTemp.Append("brand=" + _brand + "&");
            }
            if (!_classs.Equals(""))
            {
                strTemp.Append("classs=" + _classs.ToString() + "&");
            }
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
            Response.Redirect("CarList.aspx?" + this.CombUrlTxt(this.ddlBrand.SelectedValue, this.ddlClass.SelectedValue, this.txtKeywords.Text.Trim()) + "page=0");
        }
        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbtnDel_Click(object sender, EventArgs e)
        {
            //批量删除
            for (int i = 0; i < rptClub.Items.Count; i++)
            {
                int id = Convert.ToInt32(((Label)rptClub.Items[i].FindControl("lb_id")).Text);
                CheckBox cb = (CheckBox)rptClub.Items[i].FindControl("cb_id");
                if (cb.Checked)
                {
                    CarBll.Delete(id);
                }
            }
            JscriptPrint("批量删除成功！", "CarList.aspx?" + CombUrlTxt(this.brand, this.classs, this.keyword) + "page=0", "Success");
        }
    }
}
