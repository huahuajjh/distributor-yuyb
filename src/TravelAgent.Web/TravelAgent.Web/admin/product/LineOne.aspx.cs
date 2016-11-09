using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TravelAgent.Web.admin.product
{
    public partial class LineOne : TravelAgent.Web.UI.BasePage
    {
        private static readonly TravelAgent.BLL.DepartureCity CityBll = new TravelAgent.BLL.DepartureCity();
        private static readonly TravelAgent.BLL.JoinProperty ProBll = new TravelAgent.BLL.JoinProperty();
        private static readonly TravelAgent.BLL.LineTheme ThemeBll = new TravelAgent.BLL.LineTheme();
        private static readonly TravelAgent.BLL.Destination DestBll = new TravelAgent.BLL.Destination();
        private static readonly TravelAgent.BLL.Supply SupplyBll = new TravelAgent.BLL.Supply();
        private static readonly TravelAgent.BLL.Line LineBll = new TravelAgent.BLL.Line();
        private static readonly TravelAgent.BLL.Insure InsureBll = new TravelAgent.BLL.Insure();
        private static readonly TravelAgent.BLL.LineHoliday HolidayBll = new TravelAgent.BLL.LineHoliday();
        public int lineid;
        public string tag;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["tag"] != null)
            {
                tag = Request.QueryString["tag"];
            }
            if (Request.QueryString["id"] != null)
            {
                lineid = Convert.ToInt32(Request.QueryString["id"]);
            }
            if (!this.IsPostBack)
            {
                DataBindSupply();
                DataBindCity();
                
                DataBindProperty();
                DataBindTheme();
                DataBindState();
                DataBindInsure();
                DataBindHoliday();
                    if (lineid > 0)
                    {
                        TravelAgent.Model.Line line = LineBll.GetModel(lineid);
                        if (line != null)
                        {
                            this.ddlSupply.SelectedValue = line.SupplyId.ToString();
                            this.txtTitle.Text = line.LineName;
                            this.txtSubTitle.Text = line.LineSubName;
                            this.txtImgUrl.Text = line.LinePic;
                            this.SEOTitle.Value = line.SeoTitle;
                            this.SEOKeywords.Value = line.SeoKey;
                            this.SEODescription.Value = line.SeoDisc;
                            this.ddlCity.SelectedValue = line.CityId.ToString();
                            this.ddlDayNumber.SelectedValue = line.DayNumber.ToString();
                            this.hidDest.Value = line.Dest;
                            DataBindDestType(line.DestId,line.Dest);
                            this.ddlDestType.SelectedValue = line.DestId.ToString();
                            //参团性质
                            this.ddlJoinPropery.SelectedValue = line.ProIds;
                            this.txtGZD.Text = line.GZD.ToString();
                            this.ddlInsurance.SelectedValue = line.InsureId.ToString();
                            this.chkIsLock.Checked = line.IsLock == 1;
                            //主题
                            foreach (ListItem item in chkTheme.Items)
                            {
                                if (line.ThemeIds.Contains(","+item.Value+","))
                                {
                                    item.Selected = true;
                                }
                            }
                            //往返交通
                            foreach (ListItem item in chkTraffic.Items)
                            {
                                if (line.TrafficIds.Contains(","+item.Value+","))
                                {
                                    item.Selected = true;
                                }
                            }
                            //状态属性
                            foreach (ListItem item in chkState.Items)
                            {
                                if (line.State.Contains(","+item.Value+","))
                                {
                                    item.Selected = true;
                                }
                            }
                            this.txtFeature.Value = line.LineFeature;
                            this.txtAheadNumber.Text = line.AheadNumber.ToString();
                            this.txtSort.Text = line.Sort.ToString();
                            //节日
                            foreach (ListItem item in this.chkHoliday.Items)
                            {
                                if (line.Holiday.Contains("," + item.Value + ","))
                                {
                                    item.Selected = true;
                                }
                            }
                        }
                    }
                    else
                    {
                        DataBindDestType(null,null);
                    }
            }
        }
        /// <summary>
        /// 保存进入下一步
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            TravelAgent.Model.Line model = new TravelAgent.Model.Line();
            model.SupplyId = Convert.ToInt32(ddlSupply.SelectedValue);
            model.LineName = this.txtTitle.Text.Trim();
            model.LineSubName = this.txtSubTitle.Text.Trim();
            model.LinePic = this.txtImgUrl.Text;
            model.SeoTitle = this.SEOTitle.Value.Trim();
            model.SeoKey = this.SEOKeywords.Value.Trim();
            model.SeoDisc = this.SEODescription.Value.Trim();
            model.CityId = Convert.ToInt32(this.ddlCity.SelectedValue);
            model.DayNumber = Convert.ToInt32(this.ddlDayNumber.SelectedValue);
            model.DestId = Convert.ToInt32(this.ddlDestType.SelectedValue);
            model.Dest = this.hidDest.Value;
            model.IsLock = this.chkIsLock.Checked ? 1 : 0;
            model.ProIds = this.ddlJoinPropery.SelectedValue;
            model.GZD = this.txtGZD.Text.Trim().Equals("")?0:Convert.ToInt32(this.txtGZD.Text);
            model.InsureId = Convert.ToInt32(this.ddlInsurance.SelectedValue);
            string strTheme = "";
            foreach (ListItem item in chkTheme.Items)
            {
                if (item.Selected)
                {
                    strTheme = strTheme + item.Value + ",";
                }
            }
            model.ThemeIds = !strTheme.Equals("") ? "," + strTheme : "";
            model.LineFeature = this.txtFeature.Value;
            string strTraffic = "";
            foreach (ListItem item in chkTraffic.Items)
            {
                if (item.Selected)
                {
                    strTraffic = strTraffic + item.Value + ",";
                }
            }
            model.TrafficIds = !strTraffic.Equals("") ? "," + strTraffic : "";
            string strState = "";
            foreach (ListItem item in chkState.Items)
            {
                if (item.Selected)
                {
                    strState = strState + item.Value + ",";
                }
            }
            model.State = !strState.Equals("") ? "," + strState : "";
            model.AheadNumber = Convert.ToInt32(this.txtAheadNumber.Text);
            model.Sort = Convert.ToInt32(this.txtSort.Text);
            string strHoliday = "";
            foreach (ListItem item in this.chkHoliday.Items)
            {
                if (item.Selected)
                {
                    strHoliday = strHoliday + item.Value + ",";
                }
            }
            model.Holiday = !strHoliday.Equals("") ? "," + strHoliday : "";
            try
            {
                if (lineid > 0)
                {
                    string strsql = "update Line set lineName='" + model.LineName + "',lineSubName='" + model.LineSubName + "',linePic='" + model.LinePic + "',seoTitle='" + model.SeoTitle + "',seoKey='" + model.SeoKey + "',seoDisc='"+model.SeoDisc+"',";
                    strsql += "cityId='" + model.CityId + "',dayNumber='" + model.DayNumber + "',aheadNumber='" + model.AheadNumber + "',supplyId='" + model.SupplyId + "',destId='" + model.DestId + "',dest='" + model.Dest + "',proIds='" + model.ProIds + "',";
                    strsql += "themeIds='" + model.ThemeIds + "',trafficIds='" + model.TrafficIds + "',Sort='" + model.Sort + "',lineFeature='" + model.LineFeature + "',State='"+model.State+"',gzd='"+model.GZD+"',holiday='"+model.Holiday+"' where id="+lineid;
                    if (LineBll.Update(strsql) > 0)
                    {
                        JscriptPrint("保存成功！", "LineTwo.aspx?id=" + lineid + "&tag=edit", "Success");
                    }
                    else
                    {
                        JscriptPrint("保存失败！", Request.Url.ToString(), "Error");
                    }
                }
                else
                {
                    lineid=LineBll.Add(model);
                    if (lineid > 0)
                    {
                        JscriptPrint("新增成功！", "LineTwo.aspx?id="+lineid+"&tag=add", "Success");
                    }
                    else
                    {
                        JscriptPrint("新增失败！", Request.Url.ToString(), "Error");
                    }
                }
            }
            catch
            {
                JscriptPrint("保存失败！", Request.Url.ToString(), "Error");
            }
        }
        /// <summary>
        /// 保存返回列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave1_Click(object sender, EventArgs e)
        {
            TravelAgent.Model.Line model = new TravelAgent.Model.Line();
            model.SupplyId = Convert.ToInt32(ddlSupply.SelectedValue);
            model.LineName = this.txtTitle.Text.Trim();
            model.LineSubName = this.txtSubTitle.Text.Trim();
            model.LinePic = this.txtImgUrl.Text;
            model.SeoTitle = this.SEOTitle.Value.Trim();
            model.SeoKey = this.SEOKeywords.Value.Trim();
            model.SeoDisc = this.SEODescription.Value.Trim();
            model.CityId = Convert.ToInt32(this.ddlCity.SelectedValue);
            model.DayNumber = Convert.ToInt32(this.ddlDayNumber.SelectedValue);
            model.DestId = Convert.ToInt32(this.ddlDestType.SelectedValue);
            model.Dest = this.hidDest.Value;
            model.IsLock = this.chkIsLock.Checked ? 1 : 0;
            //string strJoinProperty = "";
            //foreach (ListItem item in chkJoinProperty.Items)
            //{
            //    if (item.Selected)
            //    {
            //        strJoinProperty = strJoinProperty + item.Value + ",";
            //    }
            //}
            model.ProIds = this.ddlJoinPropery.SelectedValue;
            model.GZD = this.txtGZD.Text.Trim().Equals("") ? 0 : Convert.ToInt32(this.txtGZD.Text);
            model.InsureId = Convert.ToInt32(this.ddlInsurance.SelectedValue);
            string strTheme = "";
            foreach (ListItem item in chkTheme.Items)
            {
                if (item.Selected)
                {
                    strTheme = strTheme + item.Value + ",";
                }
            }
            model.ThemeIds = !strTheme.Equals("") ? "," + strTheme : "";
            model.LineFeature = this.txtFeature.Value;
            string strTraffic = "";
            foreach (ListItem item in chkTraffic.Items)
            {
                if (item.Selected)
                {
                    strTraffic = strTraffic + item.Value + ",";
                }
            }
            model.TrafficIds = !strTraffic.Equals("") ? "," + strTraffic : "";
            string strState = "";
            foreach (ListItem item in chkState.Items)
            {
                if (item.Selected)
                {
                    strState = strState + item.Value + ",";
                }
            }
            model.State = !strState.Equals("") ? "," + strState : "";
            model.AheadNumber = Convert.ToInt32(this.txtAheadNumber.Text);
            model.Sort = Convert.ToInt32(this.txtSort.Text);
            string strHoliday = "";
            foreach (ListItem item in this.chkHoliday.Items)
            {
                if (item.Selected)
                {
                    strHoliday = strHoliday + item.Value + ",";
                }
            }
            model.Holiday = !strHoliday.Equals("") ? "," + strHoliday : "";
            try
            {
                if (lineid > 0)
                {
                    string strsql = "update Line set lineName='" + model.LineName + "',lineSubName='" + model.LineSubName + "',linePic='" + model.LinePic + "',seoTitle='" + model.SeoTitle + "',seoKey='" + model.SeoKey + "',seoDisc='" + model.SeoDisc + "',";
                    strsql += "cityId='" + model.CityId + "',dayNumber='" + model.DayNumber + "',aheadNumber='" + model.AheadNumber + "',supplyId='" + model.SupplyId + "',destId='" + model.DestId + "',dest='" + model.Dest + "',proIds='" + model.ProIds + "',";
                    strsql += "themeIds='" + model.ThemeIds + "',trafficIds='" + model.TrafficIds + "',Sort='" + model.Sort + "',lineFeature='" + model.LineFeature + "',State='" + model.State + "',isLock="+model.IsLock+",gzd='"+model.GZD+"',holiday='"+model.Holiday+"' where id=" + lineid;
                    if (LineBll.Update(strsql) > 0)
                    {
                        JscriptPrint("保存成功！", "LineList.aspx", "Success");
                    }
                    else
                    {
                        JscriptPrint("保存失败！", Request.Url.ToString(), "Error");
                    }
                }
                else
                {
                    lineid = LineBll.Add(model);
                    if (lineid > 0)
                    {
                        JscriptPrint("新增成功！", "LineList.aspx", "Success");
                    }
                    else
                    {
                        JscriptPrint("新增失败！", Request.Url.ToString(), "Error");
                    }
                }
            }
            catch
            {
                JscriptPrint("保存失败！", Request.Url.ToString(), "Error");
            }
        }
        /// <summary>
        /// 绑定出发城市
        /// </summary>
        private void DataBindCity()
        {
            this.ddlCity.DataSource = CityBll.GetList("isLock=0");
            this.ddlCity.DataTextField = "CityName";
            this.ddlCity.DataValueField = "Id";
            this.ddlCity.DataBind();
            this.ddlCity.Items.Insert(0, new ListItem("出发城市", ""));
        }
        /// <summary>
        /// 绑定目的地
        /// </summary>
        private void DataBindDestType(int? id,string dest)
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
                    if (i == 0)
                    {
                        item.Selected = true;
                        sb.Append("<div class=\"lineDest\" id=\"DestContainer_" + drs[i]["Id"].ToString() + "\" style=\"display:\">");
                    }
                    else
                    {
                        sb.Append("<div class=\"lineDest\" id=\"DestContainer_" + drs[i]["Id"].ToString() + "\" style=\"display:none\">");
                    }
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
                sb.Append(DataBindSubDest(Convert.ToInt32(drs[i]["Id"]),dest,dt));
                sb.Append("</div>");
                this.ddlDestType.Items.Add(item);
            }
            
            this.divDest.InnerHtml = sb.ToString();
        }
        /// <summary>
        /// 绑定子集
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private string DataBindSubDest(int id,string dest,DataTable dt)
        {
            StringBuilder sb = new StringBuilder();
            //DataRow[] drs = dt.Select("navList like '%," + id + ",%'");
            foreach (DataRow row in dt.Rows)
            {
                if (row["navList"].ToString().IndexOf(","+id+",")>=0)
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
                            if (dest.Contains(","+row["Id"].ToString()+","))
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
        /// <summary>
        /// 绑定参团性质
        /// </summary>
        private void DataBindProperty()
        {
            this.ddlJoinPropery.DataSource = ProBll.GetList("isLock=0");
            this.ddlJoinPropery.DataTextField = "joinName";
            this.ddlJoinPropery.DataValueField = "Id";
            this.ddlJoinPropery.DataBind();
            this.ddlJoinPropery.Items.Insert(0, new ListItem("选择参团性质", ""));
        }
        /// <summary>
        /// 绑定线路主题
        /// </summary>
        private void DataBindTheme()
        {
            this.chkTheme.DataSource = ThemeBll.GetList("isLock=0");
            this.chkTheme.DataTextField = "themeName";
            this.chkTheme.DataValueField = "Id";
            this.chkTheme.DataBind();
        }
        /// <summary>
        /// 绑定状态属性
        /// </summary>
        private void DataBindState()
        {
            Hashtable ht = TravelAgent.Tool.EnumHelper.GetMemberKeyValue<TravelAgent.Tool.EnumSummary.State>();//数据源
            foreach (DictionaryEntry de in ht)
            {
                ListItem item = new ListItem(de.Key.ToString(), de.Value.ToString());
                item.Attributes.Add("alt", item.Value);
                chkState.Items.Add(item);
            }
        }
        /// <summary>
        /// 绑定节日
        /// </summary>
        private void DataBindHoliday()
        {
            this.chkHoliday.DataSource = HolidayBll.GetList();
            this.chkHoliday.DataTextField = "holidayName";
            this.chkHoliday.DataValueField = "Id";
            this.chkHoliday.DataBind();
        }
        /// <summary>
        /// 绑定供应商
        /// </summary>
        private void DataBindSupply()
        {
            this.ddlSupply.DataSource = SupplyBll.GetList("isLock=0");
            this.ddlSupply.DataTextField = "supplyName";
            this.ddlSupply.DataValueField = "Id";
            this.ddlSupply.DataBind();
            this.ddlSupply.Items.Insert(0, new ListItem("选择供应商", ""));
        }
        /// <summary>
        /// 绑定保险列表
        /// </summary>
        private void DataBindInsure()
        {
            this.ddlInsurance.DataSource = InsureBll.GetList("IsLock=0");
            this.ddlInsurance.DataTextField = "InsureName";
            this.ddlInsurance.DataValueField = "Id";
            this.ddlInsurance.DataBind();
            this.ddlInsurance.Items.Insert(0, new ListItem("选择保险", ""));
            this.ddlInsurance.Items.Insert(1, new ListItem("赠送保险", "0"));
        }
    
        //protected void Page_Error(object sender,EventArgs e)
        //{
        //    Exception ex = Server.GetLastError();
        //    if(ex is HttpRequestValidationException)
        //    {
        //        Server.ClearError();
        //    }
        //}
    }
}
