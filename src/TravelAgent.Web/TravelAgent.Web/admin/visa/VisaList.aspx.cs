using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TravelAgent.Web.admin.visa
{
    public partial class VisaList : TravelAgent.Web.UI.BasePage
    {
        private static readonly TravelAgent.BLL.VisaType TypeBll = new TravelAgent.BLL.VisaType();
        private static readonly TravelAgent.BLL.VisaCountry CountryBll = new TravelAgent.BLL.VisaCountry();
        private static readonly TravelAgent.BLL.VisaList VisaBll = new TravelAgent.BLL.VisaList();
        public int pcount;                                   //总条数
        public int page;                                     //当前页
        public readonly int pagesize = 15;                    //设置每页显示的大小

        public int typeid;
        public int countryid;
        public string keywords = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!int.TryParse(Request.Params["typeid"] as string, out this.typeid))
            {
                this.typeid = 0;
            }
            if (!int.TryParse(Request.Params["countryid"] as string, out this.countryid))
            {
                this.countryid = 0;
            }
            if (!string.IsNullOrEmpty(Request.Params["keywords"]))
            {
                this.keywords = Request.Params["keywords"].Trim();
            }
            if (!this.IsPostBack)
            {
                DataBindType();
                DataBindCountry();
                RptBind("Id>0" + this.CombSqlTxt(this.typeid, this.countryid, this.keywords), "adddate desc");

                if (Admin.Role.roleAuth.IndexOf(",visalist_delete,") <= -1)
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
            if (Admin.Role.roleAuth.IndexOf(",visalist_add,") > -1)
            {
                sbButton.Append("<li><a href=\"EditVisa.aspx\"><span><img src=\"../images/t01.png\" /></span>添加签证</a></li>");
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
            if (Admin.Role.roleAuth.IndexOf(",visalist_update,") > -1)
            {
                sbEdit.Append("<a href=\"EditVisa.aspx?id="+id+"\" class=\"tablelink\">修改</a> ");
            }
            if (Admin.Role.roleAuth.IndexOf(",visalist_delete,") > -1)
            {
                sbEdit.Append("<a id=\""+id+"\" href=\"#\" class=\"tablelink visa_delete\">删除</a> ");
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
            this.pcount = VisaBll.GetCount(strWhere);
            if (this.pcount > 0)
            {
                this.lbtnDel.Enabled = true;
            }
            else
            {
                this.lbtnDel.Enabled = false;
            }
            if (this.typeid > 0)
            {
                this.ddlType.SelectedValue = this.typeid.ToString();
            }
            if (this.countryid > 0)
            {
                this.ddlCountry.SelectedValue = this.countryid.ToString();
            }
            this.txtKeywords.Text = this.keywords;
            DataSet ds = VisaBll.GetPageList(this.pagesize, this.page, strWhere, orderby);
            this.rptVisa.DataSource = ds;
            this.rptVisa.DataBind();
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
            for (int i = 0; i < rptVisa.Items.Count; i++)
            {
                int id = Convert.ToInt32(((Label)rptVisa.Items[i].FindControl("lb_id")).Text);
                CheckBox cb = (CheckBox)rptVisa.Items[i].FindControl("cb_id");
                if (cb.Checked)
                {
                    VisaBll.Delete(id);
                }
            }
            JscriptPrint("批量删除成功！", "VisaList.aspx?" + CombUrlTxt(this.typeid, this.countryid, this.keywords) + "page=0", "Success");
        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnQuery_Click(object sender, EventArgs e)
        {
            int tid = this.ddlType.SelectedValue.Equals("") ? 0 : Convert.ToInt32(this.ddlType.SelectedValue);
            int cid = this.ddlCountry.SelectedValue.Equals("") ? 0 : Convert.ToInt32(this.ddlCountry.SelectedValue);
            Response.Redirect("VisaList.aspx?" + this.CombUrlTxt(tid,cid, txtKeywords.Text.Trim()) + "page=0");
        }
        /// <summary>
        /// 绑定签证类型
        /// </summary>
        private void DataBindType()
        {
            this.ddlType.DataSource = getCacheData("type");
            this.ddlType.DataTextField = "Name";
            this.ddlType.DataValueField = "Id";
            this.ddlType.DataBind();
            this.ddlType.Items.Insert(0, new ListItem("选择签证类型",""));
        }
        /// <summary>
        /// 绑定区域国家
        /// </summary>
        private void DataBindCountry()
        {
            DataTable dt = getCacheData("country");

            this.ddlCountry.Items.Clear();
            this.ddlCountry.Items.Add(new ListItem("选择签证国家", ""));
            foreach (DataRow dr in dt.Rows)
            {
                int ClassLayer = Convert.ToInt32(dr["ClassLayer"]);
                string Id = dr["Id"].ToString().Trim();
                string Name = dr["Name"].ToString().Trim();

                if (ClassLayer > 1 & dr["isLock"].ToString().Equals("0"))
                //{
                //    Name = "├ " + Name;
                //    this.ddlCountry.Items.Add(new ListItem(Name, Id));

                //}
                //else
                {
                    Name = dr["FirstWord"].ToString() + "--" + Name + "(" + dr["EnglishName"].ToString() + ")";
                    Name = TravelAgent.Tool.StringPlus.StringOfChar(ClassLayer - 1, "　") + Name;

                    this.ddlCountry.Items.Add(new ListItem(Name, Id));
                }
            }
        }
        /// <summary>
        /// 组合SQL语句
        /// </summary>
        /// <param name="_classId"></param>
        /// <param name="_keywords"></param>
        /// <returns></returns>
        protected string CombSqlTxt(int _typeId,int _countryid, string _keywords)
        {
            StringBuilder strTemp = new StringBuilder();
            _keywords = _keywords.Replace("'", "");
            if (_typeId > 0)
            {
                strTemp.Append(" and typeId = " + _typeId + "");
            }
            if (_countryid > 0)
            {
                strTemp.Append(" and countryId = " + _countryid + "");
            }
            if (!string.IsNullOrEmpty(_keywords))
            {
                strTemp.Append(" and visaName like '%" + _keywords + "%'");
            }

            return strTemp.ToString();
        }
        /// <summary>
        /// 组合URL语句
        /// </summary>
        /// <param name="_classId"></param>
        /// <param name="_keywords"></param>
        /// <returns></returns>
        protected string CombUrlTxt(int _typeId, int _countryid, string _keywords)
        {
            StringBuilder strTemp = new StringBuilder();
            if (_typeId > 0)
            {
                strTemp.Append("typeid=" + _typeId.ToString() + "&");
            }
            if (_countryid > 0)
            {
                strTemp.Append("countryid=" + _countryid.ToString() + "&");
            }
            if (!string.IsNullOrEmpty(_keywords))
            {
                strTemp.Append("keywords=" + Server.UrlEncode(_keywords) + "&");
            }
            return strTemp.ToString();
        }
        /// <summary>
        /// 获得名称
        /// </summary>
        /// <param name="classid"></param>
        /// <returns></returns>
        public string getName(string strDataName,string strId)
        {
            string strName = "";
            DataTable dt = getCacheData(strDataName);
            foreach (DataRow row in dt.Rows)
            {
                if (row["Id"].ToString().Equals(strId))
                {
                    strName = row["Name"].ToString();
                    break;
                }
            }
            return strName;
        }
        /// <summary>
        /// 获得集合
        /// </summary>
        /// <returns></returns>
        private DataTable getCacheData(string strDataName)
        {
            DataTable dtData = null;
            bool bolExist = TravelAgent.Tool.CacheHelper.Exists(strDataName);

            if (bolExist)
            {
                dtData = TravelAgent.Tool.CacheHelper.Get<DataTable>(strDataName);
            }
            else
            {
                if (strDataName.Equals("type"))
                {
                    dtData = TypeBll.GetList("isLock=0").Tables[0];
                }
                else if (strDataName.Equals("country"))
                {
                    dtData = CountryBll.GetList(0,"");
                }
               
                TravelAgent.Tool.CacheHelper.Add<DataTable>(strDataName, dtData);
            }

            return dtData;
        }
    }
}
