using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TravelAgent.Web.admin.product
{
    public partial class LineList : TravelAgent.Web.UI.BasePage
    {
        private static readonly TravelAgent.BLL.DepartureCity CityBll = new TravelAgent.BLL.DepartureCity();
        private static readonly TravelAgent.BLL.JoinProperty ProBll = new TravelAgent.BLL.JoinProperty();
        private static readonly TravelAgent.BLL.LineTheme ThemeBll = new TravelAgent.BLL.LineTheme();
        private static readonly TravelAgent.BLL.Destination DestBll = new TravelAgent.BLL.Destination();
        private static readonly TravelAgent.BLL.Supply SupplyBll = new TravelAgent.BLL.Supply();
        private static readonly TravelAgent.BLL.Line LineBll = new TravelAgent.BLL.Line();
        public int pcount;                                   //总条数
        public int page;                                     //当前页
        public readonly int pagesize = 10;                    //设置每页显示的大小

        public int proid;
        public int cityId;
        public int destid;
        public int stateid;
        public string keywords = "";
        public string code = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!int.TryParse(Request.Params["proid"] as string, out this.proid))
            {
                this.proid = 0;
            }
            if (!int.TryParse(Request.Params["cityId"] as string, out this.cityId))
            {
                this.cityId = 0;
            }
            if (!int.TryParse(Request.Params["destid"] as string, out this.destid))
            {
                this.destid = 0;
            }
            if (!int.TryParse(Request.Params["stateid"] as string, out this.stateid))
            {
                this.stateid = -1;
            }
            if (!string.IsNullOrEmpty(Request.Params["keywords"]))
            {
                this.keywords = Request.Params["keywords"].Trim();
            }
            if (!string.IsNullOrEmpty(Request.Params["code"]))
            {
                this.code = Request.Params["code"].Trim();
            }
            if (this.hfSearchType.Value == "1")
            {
                this.divGGSearch.Style["display"] = "";
            }
            else
            {
                this.divGGSearch.Style["display"] = "none";
            }
            if (!this.IsPostBack)
            {
                DataBindProperty();
                DataBindCity();
                DataBindDestType();
                DataBindState();
                RptBind("Id>0" + this.CombSqlTxt(this.proid,this.cityId,this.destid,this.stateid, this.keywords,this.code), "adddate desc");

                if (Admin.Role.roleAuth.IndexOf(",linelist_delete,") <=-1)
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
            if (Admin.Role.roleAuth.IndexOf(",linelist_add,") > -1)
            {
                sbButton.Append("<li><a href=\"LineOne.aspx?id=0&tag=add\"><span><img src=\"../images/t01.png\" /></span>添加线路</a></li>");
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
            if (Admin.Role.roleAuth.IndexOf(",linelist_update,") > -1)
            {
                sbEdit.Append("<a href=\"LineOne.aspx?id="+id+"&tag=edit\" class=\"tablelink\">修改</a> ");
            }
            if (Admin.Role.roleAuth.IndexOf(",linelist_delete,") > -1)
            {
                sbEdit.Append("<a id=\""+id+"\" href=\"#\" class=\"tablelink linelist_delete\">删除</a> ");
            }
            if (Admin.Role.roleAuth.IndexOf(",linelist_add,") > -1)
            {
                sbEdit.Append("<a id=\""+id+"\" href=\"#\" class=\"tablelink linelist_copy\">复制</a>");
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
            this.pcount = LineBll.GetCount(strWhere);
            if (this.pcount > 0)
            {
                this.lbtnDel.Enabled = true;
            }
            else
            {
                this.lbtnDel.Enabled = false;
            }
            if (this.proid > 0)
            {
                this.ddlType.SelectedValue = this.proid.ToString();
            }
            if (this.cityId > 0)
            {
                this.ddlCountry.SelectedValue = this.cityId.ToString();
            }
            if (this.destid > 0)
            {
                this.ddlDest.SelectedValue = this.destid.ToString();
            }
            if (this.stateid >=0)
            {
                this.ddlState.SelectedValue = this.stateid.ToString();
            }
            this.txtKeywords.Text = this.keywords;
            this.txtCode.Text = this.code;
            DataSet ds = LineBll.GetPageList(this.pagesize, this.page, strWhere, orderby);
            this.rptLine.DataSource = ds;
            this.rptLine.DataBind();
            this.trNoRecord.Style["display"] = ds.Tables[0].Rows.Count == 0 ? "" : "none";
            this.trPagination.Style["display"] = ds.Tables[0].Rows.Count == 0 ? "none" : "";
        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnQuery_Click(object sender, EventArgs e)
        {
            
            int pro_id = this.ddlType.SelectedValue.Equals("") ? 0 : Convert.ToInt32(this.ddlType.SelectedValue);
            int city_id = this.ddlCountry.SelectedValue.Equals("") ? 0 : Convert.ToInt32(this.ddlCountry.SelectedValue);
            int dest_id = this.ddlDest.SelectedValue.Equals("") ? 0 : Convert.ToInt32(this.ddlDest.SelectedValue);
            int state_id = this.ddlState.SelectedValue.Equals("") ? -1 : Convert.ToInt32(this.ddlState.SelectedValue);
            Response.Redirect("LineList.aspx?" + this.CombUrlTxt(pro_id, city_id, dest_id, state_id, txtKeywords.Text.Trim(), this.txtCode.Text.Trim()) + "page=0");
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
                    LineBll.Delete(id);
                }
            }
            JscriptPrint("批量删除成功！", "LineList.aspx?" + CombUrlTxt(this.proid,this.cityId,this.destid,this.stateid, this.keywords,this.code) + "page=0", "Success");
        }
        /// <summary>
        /// 组合SQL语句
        /// </summary>
        /// <param name="_classId"></param>
        /// <param name="_keywords"></param>
        /// <returns></returns>
        protected string CombSqlTxt(int _proId, int _cityid, int _destid,int _stateid,string _keywords,string _code)
        {
            StringBuilder strTemp = new StringBuilder();
            _keywords = _keywords.Replace("'", "");
            if (_proId > 0)
            {
                strTemp.Append(" and proIds like '%," + _proId + ",%'");
            }
            if (_cityid > 0)
            {
                strTemp.Append(" and cityId = " + _cityid + "");
            }
            if (_destid > 0)
            {
                strTemp.Append(" and destId = " + _destid + "");
            }
            if (_stateid >= 0)
            {
                strTemp.Append(" and State like '%," + _stateid + ",%'");
            }
            if (!string.IsNullOrEmpty(_keywords))
            {
                strTemp.Append(" and lineName like '%" + _keywords + "%'");
            }
            if (!string.IsNullOrEmpty(_code))
            {
                //Access
                //strTemp.Append(" and InStr('"+_code+"',Id)>0");
                strTemp.Append(" and CHARINDEX('Id','" + _code.TrimStart('0') + "')>0");
            }
            return strTemp.ToString();
        }
        /// <summary>
        /// 组合URL语句
        /// </summary>
        /// <param name="_classId"></param>
        /// <param name="_keywords"></param>
        /// <returns></returns>
        protected string CombUrlTxt(int _proId, int _cityid, int _destid, int _stateid, string _keywords, string _code)
        {
            StringBuilder strTemp = new StringBuilder();
            if (_proId > 0)
            {
                strTemp.Append("proid=" + _proId.ToString() + "&");
            }
            if (_cityid > 0)
            {
                strTemp.Append("cityid=" + _cityid.ToString() + "&");
            }
            if (_destid > 0)
            {
                strTemp.Append("destid=" + _destid.ToString() + "&");
            }
            if (_stateid >= 0)
            {
                strTemp.Append("stateid=" + _stateid.ToString() + "&");
            }
            if (!string.IsNullOrEmpty(_keywords))
            {
                strTemp.Append("keywords=" + Server.UrlEncode(_keywords) + "&");
            }
            if (!string.IsNullOrEmpty(_code))
            {
                strTemp.Append("code=" + Server.UrlEncode(_code) + "&");
            }
            return strTemp.ToString();
        }
        /// <summary>
        /// 绑定参团性质
        /// </summary>
        private void DataBindProperty()
        {
            this.ddlType.DataSource = getCacheData("pro");
            this.ddlType.DataTextField = "joinName";
            this.ddlType.DataValueField = "Id";
            this.ddlType.DataBind();
            this.ddlType.Items.Insert(0, new ListItem("参团性质", ""));
        }
        /// <summary>
        /// 绑定出发城市
        /// </summary>
        private void DataBindCity()
        {
            this.ddlCountry.DataSource = getCacheData("city");
            this.ddlCountry.DataTextField = "CityName";
            this.ddlCountry.DataValueField = "Id";
            this.ddlCountry.DataBind();
            this.ddlCountry.Items.Insert(0, new ListItem("出发城市", ""));
        }
         /// <summary>
        /// 绑定目的地
        /// </summary>
        private void DataBindDestType()
        {
            //this.ddlDest.DataSource = getCacheData("dest");
            this.ddlDest.DataSource = DestBll.GetDestListByLayer(1).Tables[0];
            this.ddlDest.DataTextField = "navName";
            this.ddlDest.DataValueField = "Id";
            this.ddlDest.DataBind();
            this.ddlDest.Items.Insert(0, new ListItem("目的地类型", ""));
        }
        /// <summary>
        /// 绑定状态属性
        /// </summary>
        private void DataBindState()
        {
            Hashtable ht = TravelAgent.Tool.EnumHelper.GetMemberKeyValue<TravelAgent.Tool.EnumSummary.State>();//数据源
            //foreach (DictionaryEntry de in ht)
            //{
            //    ListItem item = new ListItem(de.Key.ToString(), de.Value.ToString());
            //    item.Attributes.Add("alt", item.Value);
            //    chkState.Items.Add(item);
            //}
            this.ddlState.DataSource = ht;
            this.ddlState.DataTextField = "Key";
            this.ddlState.DataValueField = "Value";
            this.ddlState.DataBind();
            this.ddlState.Items.Insert(0, new ListItem("状态属性", ""));
        }
        /// <summary>
        /// 获得名称
        /// </summary>
        /// <param name="classid"></param>
        /// <returns></returns>
        public string getName(string strDataName, string strId,string rowName)
        {
            string strName = "";
            DataTable dt = getCacheData(strDataName);
            foreach (DataRow row in dt.Rows)
            {
                if (row["Id"].ToString().Equals(strId))
                {
                    strName = row[rowName].ToString();
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
                if (strDataName.Equals("pro"))
                {
                    dtData = ProBll.GetList("isLock=0").Tables[0];
                }
                else if (strDataName.Equals("city"))
                {
                    dtData = CityBll.GetList("isLock=0").Tables[0];
                }
                else if (strDataName.Equals("dest"))
                {
                    dtData = DestBll.GetDestListByLayer(1).Tables[0];
                }
                else if (strDataName.Equals("supply"))
                {
                    dtData = SupplyBll.GetList("isLock=0").Tables[0];
                }
                TravelAgent.Tool.CacheHelper.Add<DataTable>(strDataName, dtData);
            }

            return dtData;
        }
        /// <summary>
        /// 显示价格
        /// </summary>
        /// <param name="priceContent"></param>
        /// <returns></returns>
        public string ShowPrice(string priceContent)
        {
            string strvalue = "";
            if (!string.IsNullOrEmpty(priceContent))
            {
                strvalue = "成人：<span style=\"color:red\">￥" + priceContent.Split(',')[2] + "</span></br>儿童：<span style=\"color:red\">￥" + priceContent.Split(',')[3]+"</span>";
            }
            return strvalue;
        }
    }
}
