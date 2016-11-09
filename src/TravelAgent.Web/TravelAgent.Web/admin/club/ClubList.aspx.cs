using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TravelAgent.Web.admin.club
{
    public partial class ClubList : TravelAgent.Web.UI.BasePage
    {
        private static readonly TravelAgent.BLL.Club ClubBll = new TravelAgent.BLL.Club();
        public int pcount;                                   //总条数
        public int page;                                     //当前页
        public readonly int pagesize = 15;                    //设置每页显示的大小

        public string classid="";
        public string isLock="";
        public string keywords = "用户名/手机/邮箱";
        protected void Page_Load(object sender, EventArgs e)
        {
            this.classid = Request.Params["classid"] == null ? "" : Request.Params["classid"];
            this.isLock = Request.Params["isLock"] == null ? "" : Request.Params["isLock"];
            if (!string.IsNullOrEmpty(Request.Params["keywords"]))
            {
                this.keywords = Server.UrlDecode(Request.Params["keywords"].Trim());
            }
            if (!this.IsPostBack)
            {
                DataBindClass();
                RptBind("Id>0" + this.CombSqlTxt(this.classid, this.isLock, this.keywords), "regDate desc");
                if (Admin.Role.roleAuth.IndexOf(",clublist_delete,") <= -1)
                {
                    this.lbtnDel.Enabled = false;
                }
                if (Admin.Role.roleAuth.IndexOf(",clublist_export,") <= -1)
                {
                    this.lbtnExport.Enabled = false;
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
            if (Admin.Role.roleAuth.IndexOf(",sms,") > -1)
            {
                sbButton.Append("<li><a href=\"#\" onclick=\"gotoUrl('GroupSMS.aspx','mobile')\"><span><img src=\"../images/t01.png\" /></span>短信群发</a></li>");
            }
            if (Admin.Role.roleAuth.IndexOf(",email,") > -1)
            {
                sbButton.Append("<li><a href=\"#\" onclick=\"gotoUrl('GroupEmail.aspx','email')\"><span><img src=\"../images/email.png\" style=\"width:24px; height:24px\" /></span>邮件群发</a></li>");
            }
            return sbButton.ToString();
        }
        /// <summary>
        /// 显示邮件
        /// </summary>
        /// <returns></returns>
        public string ShowEmail(string stremail,string strvalidate)
        {
            string strvalue = "";
            if (stremail != "")
            {
                if (strvalidate.Equals("0"))
                {
                    strvalue = stremail + "[<span style='color:red'>未验证</span>]";
                }
                else
                {
                    strvalue = stremail;
                }
            }
            return strvalue;
        }
        /// <summary>
        /// 显示邮件
        /// </summary>
        /// <returns></returns>
        public string ShowTelephone(string strtel, string strvalidate)
        {
            string strvalue = "";
            if (strtel != "")
            {
                if (strvalidate.Equals("0"))
                {
                    strvalue = strtel + "[<span style='color:red'>未验证</span>]";
                }
                else
                {
                    strvalue = strtel;
                }
            }
            return strvalue;
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
            this.pcount = ClubBll.GetCount(strWhere);
            if (this.pcount > 0)
            {
                this.lbtnDel.Enabled = true;
                this.lbtnExport.Enabled = true;
            }
            else
            {
                this.lbtnDel.Enabled = false;
                this.lbtnExport.Enabled = false;
            }
            
            this.ddlClass.SelectedValue = this.classid.ToString();
            this.ddlState.SelectedValue = this.isLock.ToString();
            this.txtKeywords.Text = this.keywords;

            DataSet ds = ClubBll.GetPageList(this.pagesize, this.page, strWhere, orderby);
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
        protected string CombSqlTxt(string _classId, string _islock, string _keywords)
        {
            StringBuilder strTemp = new StringBuilder();
            _keywords = _keywords.Replace("'", "");
            if (!_classId.Equals(""))
            {
                strTemp.Append(" and classId = " + _classId + "");
            }
            if (!_islock.Equals(""))
            {
                strTemp.Append(" and isLock = " + _islock + "");
            }
            if (!string.IsNullOrEmpty(_keywords))
            {
                if (!_keywords.Equals("用户名/手机/邮箱"))
                {
                    strTemp.Append(" and (clubName like '%" + _keywords + "%' or clubMobile like '%" + _keywords + "%' or clubEmail like '%" + _keywords + "%')");
                }
            }

            return strTemp.ToString();
        }
        /// <summary>
        /// 组合URL语句
        /// </summary>
        /// <param name="_classId"></param>
        /// <param name="_keywords"></param>
        /// <returns></returns>
        protected string CombUrlTxt(string _classId, string _islock, string _keywords)
        {
            StringBuilder strTemp = new StringBuilder();
            if (!_classId.Equals(""))
            {
                strTemp.Append("classid=" + _classId+ "&");
            }
            if (!_islock.Equals(""))
            {
                strTemp.Append("isLock=" + _islock.ToString() + "&");
            }
            if (!string.IsNullOrEmpty(_keywords))
            {
                strTemp.Append("keywords=" + Server.UrlEncode(_keywords) + "&");
            }
            return strTemp.ToString();
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
                    ClubBll.Delete(id);
                }
            }
            JscriptPrint("批量删除成功！", "ClubList.aspx?" + CombUrlTxt(this.classid, this.isLock, this.keywords) + "page=0", "Success");
        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnQuery_Click(object sender, EventArgs e)
        {
            string strKeyWord = txtKeywords.Text.Trim();
            if (strKeyWord.Equals("用户名/手机/邮箱"))
            {
                strKeyWord = "";
            }
            Response.Redirect("ClubList.aspx?" + this.CombUrlTxt(this.ddlClass.SelectedValue, this.ddlState.SelectedValue, strKeyWord) + "page=0");
        }
        /// <summary>
        /// 绑定状态属性
        /// </summary>
        private void DataBindClass()
        {
            Hashtable ht = TravelAgent.Tool.EnumHelper.GetMemberKeyValue<TravelAgent.Tool.EnumSummary.ClubClass>();//数据源
            this.ddlClass.DataSource = ht;
            this.ddlClass.DataTextField = "Key";
            this.ddlClass.DataValueField = "Value";
            this.ddlClass.DataBind();
            this.ddlClass.Items.Insert(0, new ListItem("选择会员级别", ""));
        }
        /// <summary>
        /// 导出Excel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbtnExport_Click(object sender, EventArgs e)
        {
            string strSheetName = DateTime.Now.ToString("yyyyMMddHHmmssfff");
            DataSet dsclub = ClubBll.GetList(0, this.CombSqlTxt(this.classid, this.isLock, this.keywords), "regDate desc");
            DataTable dt = GetJHDataTable(dsclub);
            TravelAgent.Tool.ExcelHelper.ExportExcel(Response, dt, strSheetName, strSheetName);
        }
        /// <summary>
        /// 返回计划DataTable
        /// </summary>
        /// <param name="lstPlan"></param>
        /// <returns></returns>
        public DataTable GetJHDataTable(DataSet dsQueryClub)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("会员名", typeof(string)));
            dt.Columns.Add(new DataColumn("手机", typeof(string)));
            dt.Columns.Add(new DataColumn("邮件", typeof(string)));
            dt.Columns.Add(new DataColumn("真实姓名", typeof(string)));
            dt.Columns.Add(new DataColumn("性别", typeof(string)));
            dt.Columns.Add(new DataColumn("出生日期", typeof(string)));
            dt.Columns.Add(new DataColumn("积分余额", typeof(string)));
            dt.Columns.Add(new DataColumn("是否锁定", typeof(string)));
            dt.Columns.Add(new DataColumn("注册日期", typeof(string)));
            dt.Columns.Add(new DataColumn("手机验证", typeof(string)));
            dt.Columns.Add(new DataColumn("邮箱验证", typeof(string)));
            dt.Columns.Add(new DataColumn("会员类型", typeof(string)));
            DataRow row = null,qrow=null;
            Hashtable ht = new Hashtable();
            for (int i = 0; i <= dsQueryClub.Tables[0].Rows.Count - 1; i++)
            {
                qrow = dsQueryClub.Tables[0].Rows[i];
                row = dt.NewRow();
                row["会员名"] = qrow["clubName"];
                row["手机"] = qrow["clubMobile"];
                row["邮件"] = qrow["clubEmail"];
                row["真实姓名"] = qrow["trueName"];
                row["性别"] = !qrow["clubSex"].ToString().Equals("")?TravelAgent.Tool.EnumHelper.GetMemberName<TravelAgent.Tool.EnumSummary.TouristSex>(qrow["clubSex"]):"";
                row["出生日期"] = qrow["clubBirthday"];
                row["积分余额"] = qrow["currentPoints"];
                row["是否锁定"] = qrow["isLock"].ToString().Equals("0") ? "正常" : "锁定";
                row["注册日期"] = qrow["regDate"];
                row["手机验证"] = qrow["mobileIsValid"].ToString().Equals("0")?"未验证":"已验证";
                row["邮箱验证"] = qrow["emailIsValid"].ToString().Equals("0") ? "未验证" : "已验证";
                row["会员类型"] = TravelAgent.Tool.EnumHelper.GetMemberName<TravelAgent.Tool.EnumSummary.ClubClass>(qrow["classId"]);
                dt.Rows.Add(row);
            }

            return dt;
        }
    }
}
