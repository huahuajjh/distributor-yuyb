using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TravelAgent.Web.admin.visa
{
    public partial class EditVisa : TravelAgent.Web.UI.BasePage
    {
        private static readonly TravelAgent.BLL.VisaType TypeBll = new TravelAgent.BLL.VisaType();
        private static readonly TravelAgent.BLL.VisaCountry CountryBll = new TravelAgent.BLL.VisaCountry();
        private static readonly TravelAgent.BLL.VisaCity CityBll = new TravelAgent.BLL.VisaCity();
        private static readonly TravelAgent.BLL.VisaList VisaBll = new TravelAgent.BLL.VisaList();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                DataBindType();
                DataBindCountry();
                DataBindCity();
                DataBindCheckBoxList();
                if (Request.QueryString["id"] != null)
                {
                    TravelAgent.Model.VisaList model = VisaBll.GetModel(Convert.ToInt32(Request.QueryString["id"]));

                    if (model != null)
                    {
                        this.ltTag1.Text = "修改签证";
                        this.txtTitle.Text = model.visaName;
                        this.ddlType.SelectedValue = model.typeId.ToString();
                        this.ddlSign.SelectedValue = model.signId.ToString();
                        this.ddlCountry.SelectedValue = model.countryId.ToString();
                        this.txtPrice.Text = model.price.ToString();
                        this.txtUsePoints.Text = model.usePoints.ToString();
                        this.txtDonatePoints.Text = model.donatePoints.ToString();
                        this.txtDealTime.Text = model.dealTime;
                        this.txtStayTime.Text = model.stayTime;
                        this.txtEnterNumber.Text = model.enterNumber;
                        this.txtInterview.Text = model.interview;
                        this.txtExpiryDate.Text = model.expiryDate;
                        this.rbtnDealType.SelectedValue = model.dealType.ToString();
                        foreach (ListItem item in chkState.Items)
                        {
                            if (TravelAgent.Tool.CommonOprate.IsContainValue(item.Value, model.State))
                            {
                                item.Selected = true;
                            }
                        }
                        this.txtTips.Value = model.tips;
                        this.txtMaterial.Value = model.needMaterial;
                        this.txtSort.Text = model.Sort.ToString();
                        this.chkIsLock.Checked = model.isLock == 1;
                    }
                }
                else
                {
                    this.txtSort.Text = (VisaBll.GetMaxID("Sort") + 1).ToString();
                }
            }
        }
        /// <summary>
        /// 绑定签证类型
        /// </summary>
        private void DataBindType()
        {
            this.ddlType.DataSource = TypeBll.GetList("isLock=0");
            this.ddlType.DataTextField = "Name";
            this.ddlType.DataValueField = "Id";
            this.ddlType.DataBind();
            this.ddlType.Items.Insert(0, new ListItem("选择签证类型", ""));
        }
        /// <summary>
        /// 绑定区域国家
        /// </summary>
        private void DataBindCountry()
        {
            DataTable dt = CountryBll.GetList(0,"");

            this.ddlCountry.Items.Clear();
            this.ddlCountry.Items.Add(new ListItem("选择签证国家", ""));
            foreach (DataRow dr in dt.Rows)
            {
                int ClassLayer = Convert.ToInt32(dr["ClassLayer"]);
                string Id = dr["Id"].ToString().Trim();
                string Name = dr["Name"].ToString().Trim();

                if (ClassLayer > 1 && dr["isLock"].ToString().Equals("0"))
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
        /// 绑定签发城市
        /// </summary>
        private void DataBindCity()
        {
            this.ddlSign.DataSource = CityBll.GetList("isLock=0");
            this.ddlSign.DataTextField = "CityName";
            this.ddlSign.DataValueField = "Id";
            this.ddlSign.DataBind();
            this.ddlSign.Items.Insert(0, new ListItem("选择签发城市", ""));
        }
        /// <summary>
        /// 绑定状态列表
        /// </summary>
        private void DataBindCheckBoxList()
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
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            TravelAgent.Model.VisaList model = new TravelAgent.Model.VisaList();
            model.visaName = this.txtTitle.Text.Trim();
            model.typeId = Convert.ToInt32(this.ddlType.SelectedValue);
            model.signId = Convert.ToInt32(this.ddlSign.SelectedValue);
            model.countryId = Convert.ToInt32(this.ddlCountry.SelectedValue);
            model.price = Convert.ToInt32(this.txtPrice.Text);
            model.usePoints = Convert.ToInt32(this.txtUsePoints.Text);
            model.donatePoints = Convert.ToInt32(this.txtDonatePoints.Text);
            model.dealTime = this.txtDealTime.Text.Trim();
            model.stayTime = this.txtStayTime.Text.Trim();
            model.enterNumber = this.txtEnterNumber.Text.Trim();
            model.interview = this.txtInterview.Text.Trim();
            model.expiryDate = this.txtExpiryDate.Text.Trim();
            model.dealType = Convert.ToInt32(this.rbtnDealType.SelectedValue);
            model.State = this.hidState.Value;
            model.tips = this.txtTips.Value;
            model.needMaterial = this.txtMaterial.Value;
            model.adddate = DateTime.Now;
            model.Sort = Convert.ToInt32(this.txtSort.Text);
            model.isLock = this.chkIsLock.Checked ? 1 : 0;
            string stringUrl = Request.Url.ToString();
            try
            {
                if (Request.QueryString["id"] != null)
                {
                    model.id = Convert.ToInt32(Request.QueryString["id"]);
                    VisaBll.Update(model);
                    JscriptPrint("保存成功！", "VisaList.aspx", "Success");
                }
                else
                {
                    VisaBll.Add(model);
                    JscriptPrint("添加成功！", "VisaList.aspx", "Success");
                }
            }
            catch
            {
                JscriptPrint("保存失败！", stringUrl, "Error");
            }
        }
    }
}
