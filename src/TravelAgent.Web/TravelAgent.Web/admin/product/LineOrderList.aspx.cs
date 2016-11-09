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
    public partial class LineOrderList : TravelAgent.Web.UI.BasePage
    {
        public int pcount;                                   //总条数
        public int page;                                     //当前页
        public readonly int pagesize = 10;                    //设置每页显示的大小

        public string strordercode = "";
        public string strordername = "";
        public string strorderstartdate = "";
        public string strorderenddate = "";
        public string strstartdate = "";
        public string strenddate = "";
        public string orderstate = "";
        public int clubid = 0;
        private static readonly TravelAgent.BLL.Order LineOrderBll = new TravelAgent.BLL.Order();
        protected void Page_Load(object sender, EventArgs e)
        {
            this.strordercode = string.IsNullOrEmpty(Request.Params["oc"]) ? "" : Request.Params["oc"];
            this.strordername = string.IsNullOrEmpty(Request.Params["on"])? "" : Server.UrlDecode(Request.Params["on"]);
            this.strorderstartdate = string.IsNullOrEmpty(Request.Params["osd"])? "" : Request.Params["osd"];
            this.strorderenddate = string.IsNullOrEmpty(Request.Params["oed"])? "" : Request.Params["oed"];
            this.strstartdate = string.IsNullOrEmpty(Request.Params["sd"])? "" : Request.Params["sd"];
            this.strenddate = string.IsNullOrEmpty(Request.Params["ed"])? "" : Request.Params["ed"];
            this.orderstate = string.IsNullOrEmpty(Request.Params["state"]) ? "" : Request.Params["state"];
            this.clubid = string.IsNullOrEmpty(Request.Params["clubid"]) ? 0 : Convert.ToInt32(Request.Params["clubid"]);
            if (!this.IsPostBack)
            {
                DataBindState();
                RptBind("a.orderType="+Convert.ToInt32(TravelAgent.Tool.EnumSummary.OrderType.线路)+ this.CombSqlTxt(this.strordercode, this.strordername, this.strorderstartdate, this.strorderenddate, this.strstartdate, this.strenddate, this.orderstate, this.clubid), "a.orderDate desc");

                DateTime dtStartDate;
                DateTime dtEndDate;
                this.hljrorder.NavigateUrl = "/admin/product/LineOrderList.aspx?osd=" + DateTime.Now.ToString("yyyy-MM-dd") + "&oed=" + DateTime.Now.ToString("yyyy-MM-dd");
                TravelAgent.Tool.DateHelper.GetDateOfWeek(DateTime.Now, out dtStartDate, out dtEndDate);
                this.hlbzorder.NavigateUrl = "/admin/product/LineOrderList.aspx?osd=" + dtStartDate.ToString("yyyy-MM-dd") + "&oed=" + dtEndDate.ToString("yyyy-MM-dd");
                this.hlbzstart.NavigateUrl = "/admin/product/LineOrderList.aspx?sd=" + dtStartDate.ToString("yyyy-MM-dd") + "&ed=" + dtEndDate.ToString("yyyy-MM-dd");

                this.hljrstart.NavigateUrl = "/admin/product/LineOrderList.aspx?sd=" + DateTime.Now.ToString("yyyy-MM-dd") + "&ed=" + DateTime.Now.ToString("yyyy-MM-dd");
                dtStartDate = DateTime.Now.AddDays(1 - (DateTime.Now.Day));
                int year = DateTime.Now.Date.Year;
                int month = DateTime.Now.Date.Month;
                int dayCount = DateTime.DaysInMonth(year, month);
                dtEndDate = dtStartDate.AddDays(dayCount - 1);
                this.hlbyorder.NavigateUrl = "/admin/product/LineOrderList.aspx?osd=" + dtStartDate.ToString("yyyy-MM-dd") + "&oed=" + dtEndDate.ToString("yyyy-MM-dd");
                this.hlbystart.NavigateUrl = "/admin/product/LineOrderList.aspx?sd=" + dtStartDate.ToString("yyyy-MM-dd") + "&ed=" + dtEndDate.ToString("yyyy-MM-dd");

                if (Admin.Role.roleAuth.IndexOf(",lineorder_delete,") <= -1)
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
        public string ShowEdit(string id)
        {
            StringBuilder sbEdit = new StringBuilder();
            if (Admin.Role.roleAuth.IndexOf(",lineorder_opr,") > -1)
            {
                sbEdit.Append("<a href=\"EditLineOrder.aspx?id=" + id + "\" class=\"tablelink club_art\" title=\"操作订单\" width=\"730px\" height=\"550px\">操作</a>  ");
            }
            if (Admin.Role.roleAuth.IndexOf(",lineorder_delete,") > -1)
            {
                sbEdit.Append("<a id=\"" + id + "\" href=\"#\" class=\"tablelink club_delete\">删除</a>");
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
            this.pcount = LineOrderBll.GetLineOrderCount(strWhere);
            if (this.pcount > 0)
            {
                this.lbtnDel.Enabled = true;
            }
            else
            {
                this.lbtnDel.Enabled = false;
            }
            this.txtOrderCode.Text = this.strordercode;
            this.txtOrderName.Text = this.strordername;
            this.txtOrderStartDate.Text = this.strorderstartdate;
            this.txtOrderEndDate.Text = this.strorderenddate;
            this.ddlState.SelectedValue = this.orderstate.ToString();

            DataSet ds = LineOrderBll.GetPageList2(this.pagesize, this.page, strWhere, orderby);
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
        protected string CombSqlTxt(string _ordercode, string _ordername, string _orderstartdate,string _orderenddate,string _startdate,string _enddate,string _orderstate,int _clubid)
        {
            StringBuilder strTemp = new StringBuilder();
            if (!_ordercode.Equals(""))
            {
                strTemp.Append(" and a.ordercode like '%" + _ordercode + "%'");
            }
            if (!_ordername.Equals(""))
            {
                strTemp.Append(" and b.lineName like '%" + _ordername + "%'");
            }
            if (!_orderstartdate.Equals(""))
            {
                strTemp.Append(" and a.orderDate >='" + Convert.ToDateTime(_orderstartdate) + "'");
            }
            if (!_orderenddate.Equals(""))
            {
                strTemp.Append(" and a.orderDate<='" + Convert.ToDateTime(_orderenddate) + "'");
            }
            if (!_startdate.Equals(""))
            {
                strTemp.Append(" and a.TravelDate>='" + Convert.ToDateTime(_startdate) + "'");
            }
            if (!_enddate.Equals(""))
            {
                strTemp.Append(" and a.TravelDate<='" + Convert.ToDateTime(_enddate) + "'");
            }
            if (!_orderstate.Equals(""))
            {
                strTemp.Append(" and a.orderState=" + _orderstate);
            }
            if (_clubid > 0)
            {
                strTemp.Append(" and a.clubid=" + _clubid);
            }
            
            return strTemp.ToString();
        }
        /// <summary>
        /// 组合URL语句
        /// </summary>
        /// <param name="_classId"></param>
        /// <param name="_keywords"></param>
        /// <returns></returns>
        protected string CombUrlTxt(string _ordercode, string _ordername, string _orderstartdate, string _orderenddate, string _startdate, string _enddate, string _orderstate, int _clubid)
        {
            StringBuilder strTemp = new StringBuilder();
            if (!_ordercode.Equals(""))
            {
                strTemp.Append("oc=" + _ordercode + "&");
            }
            if (!_ordername.Equals(""))
            {
                strTemp.Append("on=" + Server.UrlEncode(_ordername) + "&");
            }
            if (!_orderstartdate.Equals(""))
            {
                strTemp.Append("osd=" + _orderstartdate + "&");
            }
            if (!_orderenddate.Equals(""))
            {
                strTemp.Append("oed=" + _orderenddate + "&");
            }
            if (!_startdate.Equals(""))
            {
                strTemp.Append("sd=" + _startdate + "&");
            }
            if (!_enddate.Equals(""))
            {
                strTemp.Append("ed=" + _enddate + "&");
            }
            if (!_orderstate.Equals(""))
            {
                strTemp.Append("state=" + _orderstate + "&");
            }
            if (_clubid > 0)
            {
                strTemp.Append("clubid=" + _clubid + "&");
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
            Response.Redirect("LineOrderList.aspx?" + this.CombUrlTxt(this.txtOrderCode.Text.Trim(),this.txtOrderName.Text.Trim(),this.txtOrderStartDate.Text,this.txtOrderEndDate.Text,this.strstartdate,this.strenddate,this.ddlState.SelectedValue,this.clubid) + "page=0");
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
                    LineOrderBll.Delete(id);
                }
            }
            JscriptPrint("批量删除成功！", "LineOrderList.aspx?" + CombUrlTxt(this.strordercode, this.strordername, this.strorderstartdate, this.strorderenddate, this.strstartdate, this.strenddate, this.orderstate, this.clubid) + "page=0", "Success");
        }
        /// <summary>
        /// 绑定状态属性
        /// </summary>
        private void DataBindState()
        {
            Dictionary<string, int> dc = TravelAgent.Tool.EnumHelper.GetDictionaryMemberKeyValue<TravelAgent.Tool.EnumSummary.OrderState>();//数据源
            //Hashtable ht = TravelAgent.Tool.EnumHelper.GetMemberKeyValue<TravelAgent.Tool.EnumSummary.OrderState>();//数据源
            this.ddlState.DataSource = dc;
            this.ddlState.DataTextField = "key";
            this.ddlState.DataValueField = "value";
            this.ddlState.DataBind();
            this.ddlState.Items.Insert(0, new ListItem("订单状态", ""));
        }
      
        /// <summary>
        /// 返回总金额
        /// </summary>
        /// <param name="orderprice"></param>
        /// <param name="attachprice"></param>
        /// <returns></returns>
        public int ShowTotal(int orderprice, int attachprice,int subprice)
        {
            return orderprice + attachprice+subprice;
        }
        /// <summary>
        /// 导出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbtnExport_Click(object sender, EventArgs e)
        {
            string strSheetName = DateTime.Now.ToString("yyyyMMddHHmmssfff");
            DataSet dsclub = LineOrderBll.GetList(0, "orderType=" + Convert.ToInt32(TravelAgent.Tool.EnumSummary.OrderType.线路) + this.CombSqlTxt(this.strordercode, this.strordername, this.strorderstartdate, this.strorderenddate, this.strstartdate, this.strenddate, this.orderstate, this.clubid), "orderDate desc");
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
            dt.Columns.Add(new DataColumn("编号", typeof(int)));
            dt.Columns.Add(new DataColumn("订单号", typeof(string)));
            dt.Columns.Add(new DataColumn("下单时间", typeof(string)));
            dt.Columns.Add(new DataColumn("线路名称", typeof(string)));
            dt.Columns.Add(new DataColumn("出发日期", typeof(string)));
            dt.Columns.Add(new DataColumn("成人", typeof(int)));
            dt.Columns.Add(new DataColumn("儿童", typeof(int)));
            dt.Columns.Add(new DataColumn("应支付", typeof(int)));
            dt.Columns.Add(new DataColumn("状态", typeof(string)));
            dt.Columns.Add(new DataColumn("联系人", typeof(string)));
            dt.Columns.Add(new DataColumn("联系电话", typeof(string)));
            dt.Columns.Add(new DataColumn("推荐人", typeof(string)));
            dt.Columns.Add(new DataColumn("身份证", typeof(string)));
            dt.Columns.Add(new DataColumn("邮箱", typeof(string)));
            dt.Columns.Add(new DataColumn("手机", typeof(string)));
            DataRow row = null, qrow = null;
            Hashtable ht = new Hashtable();
            for (int i = 0; i <= dsQueryClub.Tables[0].Rows.Count - 1; i++)
            {
                qrow = dsQueryClub.Tables[0].Rows[i];
                row = dt.NewRow();
                row["编号"] = qrow[0];
                row["订单号"] = qrow[2];
                row["下单时间"] = qrow[6];
                row["线路名称"] = qrow[33];
                row["出发日期"] = qrow[7];
                row["成人"] = qrow[4];
                row["儿童"] = qrow[5];
                row["应支付"] = ShowTotal(Convert.ToInt32(qrow[5]), Convert.ToInt32(qrow[9]),Convert.ToInt32(qrow[23]));
                row["状态"] = TravelAgent.Tool.EnumHelper.GetMemberName<TravelAgent.Tool.EnumSummary.OrderState>(qrow[18]);
                row["联系人"] = qrow[12];
                row["联系电话"] = qrow[13].ToString().Length < 11 ? "NA" : qrow[13];
                row["邮箱"] = qrow[14];
                row["手机"] = qrow[15].ToString().Length < 11 ? "NA" : qrow[15];
                row["身份证"] = qrow[32];
                row["推荐人"] = qrow[31];
                dt.Rows.Add(row);
            }

            return dt;
        }
    }
}
