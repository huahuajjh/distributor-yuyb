using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TravelAgent.Web.admin.car
{
    public partial class CarTwo : TravelAgent.Web.UI.BasePage
    {
        private static readonly TravelAgent.BLL.CarCity CityBll = new TravelAgent.BLL.CarCity();
        private static readonly TravelAgent.BLL.CarNumber NumberBll = new TravelAgent.BLL.CarNumber();
        private static readonly TravelAgent.BLL.CarPrice PriceBll = new TravelAgent.BLL.CarPrice();
        public int carid;
        public int priceid;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(Request.QueryString["carid"]))
            {
                carid = Convert.ToInt32(Request.QueryString["carid"]);
            }
            if (!string.IsNullOrEmpty(Request.QueryString["priceid"]))
            {
                priceid = Convert.ToInt32(Request.QueryString["priceid"]);
            }
            if (!this.IsPostBack)
            {
                BindCarCity();
                BindCarNumber();
                BindPrice();
                if (priceid > 0)
                {
                    TravelAgent.Model.CarPrice model = PriceBll.GetModel(priceid);
                    if (model != null)
                    {
                        this.lblPriceName.Text = model.PriceName;
                        this.txtPriceName.Text = model.PriceName;
                        this.txtUnit.Text = model.Unit;
                        this.rbtnCarType.SelectedValue = model.CarTypeID.ToString();
                        this.ddlCarCity.SelectedValue = model.CarCityId.ToString();
                        this.ddlCarNumber.SelectedValue = model.NumberId.ToString();
                        this.ddlBSQ.SelectedValue = model.BSQ.ToString();
                        this.txtStartDate.Text = model.StartDate;
                        this.txtEndDate.Text = model.EndDate;
                        this.txtMenshi.Text = model.MemshiPrice.ToString();
                        this.txtXiaoshou.Text = model.XiaoshuPrice.ToString();
                        this.txtJiesuan.Text = model.JiesuanPrice.ToString();
                        this.txtUsePoint.Text = model.UsePoints.ToString();
                        this.txtDonatePoint.Text = model.DonatePoints.ToString();
                        this.rbtnDealType0.SelectedValue = model.DealType.ToString();
                        this.chkIsLock.Checked = model.IsLock == 1;
                    }
                }
                else
                {
                    this.lblPriceName.Text = "";
                }
            }
        }
        /// <summary>
        /// 绑定价格列表
        /// </summary>
        public void BindPrice()
        {
            DataSet dsPrice = PriceBll.GetList(0, "CarId=" + carid, "Id desc");
            this.rptPrice.DataSource = dsPrice.Tables[0].DefaultView;
            this.rptPrice.DataBind();
            this.trNoRecord.Style["display"] = dsPrice.Tables[0].Rows.Count == 0 ? "" : "none";
        }
        /// <summary>
        /// 绑定租车城市
        /// </summary>
        public void BindCarCity()
        {
            DataSet dsClass = CityBll.GetList();
            foreach (DataRow row in dsClass.Tables[0].Rows)
            {
                this.ddlCarCity.Items.Add(new ListItem(row["CityName"].ToString(), row["Id"].ToString()));
            }
            this.ddlCarCity.Items.Insert(0, new ListItem("选择城市", ""));
        }
        /// <summary>
        /// 绑定租车厢数
        /// </summary>
        public void BindCarNumber()
        {
            DataSet dsNumber = NumberBll.GetList();
            foreach (DataRow row in dsNumber.Tables[0].Rows)
            {
                this.ddlCarNumber.Items.Add(new ListItem(row["NumName"].ToString(), row["Id"].ToString()));
            }
            this.ddlCarNumber.Items.Insert(0, new ListItem("选择厢数", ""));
        }
        /// <summary>
        /// 添加价格体系
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            TravelAgent.Model.CarPrice model = new TravelAgent.Model.CarPrice();
            model.CarId = carid;
            model.PriceName = this.txtPriceName.Text.Trim();
            model.Unit = this.txtUnit.Text.Trim();
            model.CarTypeID = Convert.ToInt32(this.rbtnCarType.SelectedValue);
            model.CarCityId = Convert.ToInt32(this.ddlCarCity.SelectedValue);
            model.TranDisc = "";
            model.NumberId = Convert.ToInt32(this.ddlCarNumber.SelectedValue);
            model.MemshiPrice = Convert.ToInt32(this.txtMenshi.Text);
            model.XiaoshuPrice = Convert.ToInt32(this.txtXiaoshou.Text);
            model.JiesuanPrice = Convert.ToInt32(this.txtJiesuan.Text);
            model.UsePoints = Convert.ToInt32(this.txtUsePoint.Text);
            model.DonatePoints = Convert.ToInt32(this.txtDonatePoint.Text);
            model.StartDate = this.txtStartDate.Text;
            model.EndDate = this.txtEndDate.Text;
            model.DealType = Convert.ToInt32(this.rbtnDealType0.SelectedValue);
            model.IsLock = this.chkIsLock.Checked ? 1 : 0;
            model.BSQ = Convert.ToInt32(this.ddlBSQ.SelectedValue);
            model.SpeXiaoshuPrice = "";
            string stringUrl = Request.Url.ToString();
            try
            {
                if (priceid>0)
                {
                    model.Id = priceid;
                    PriceBll.Update(model);
                    JscriptPrint("保存成功！", stringUrl, "Success");
                }
                else
                {
                    PriceBll.Add(model);
                    JscriptPrint("添加成功！", stringUrl, "Success");
                }
            }
            catch
            {
                JscriptPrint("保存失败！", stringUrl, "Error");
            }
        }
    }
}
