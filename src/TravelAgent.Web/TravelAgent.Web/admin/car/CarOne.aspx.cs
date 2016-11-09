using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TravelAgent.Web.admin.car
{
    public partial class CarOne : TravelAgent.Web.UI.BasePage
    {
        private static readonly TravelAgent.BLL.CarBrand BrandBll = new TravelAgent.BLL.CarBrand();
        private static readonly TravelAgent.BLL.CarClass ClassBll = new TravelAgent.BLL.CarClass();
        private static readonly TravelAgent.BLL.CarList CarBll = new TravelAgent.BLL.CarList();
        public int carid;
        public string tag;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["carid"] != null)
            {
                carid = Convert.ToInt32(Request.QueryString["carid"]);
            }
            if (Request.QueryString["tag"] != null)
            {
                tag = Request.QueryString["tag"];
            }
            if (!this.IsPostBack)
            {
                BindBrand();
                BindClass();
                DataBindState();

                if (carid > 0)
                {
                    TravelAgent.Model.CarList model = CarBll.GetModel(carid);
                    if (model != null)
                    {
                        this.txtCarName.Text = model.CarName;
                        this.txtImgUrl.Text = model.CarPic;
                        this.ddlBrand.SelectedValue = model.BrandId.ToString();
                        this.ddlClass.SelectedValue = model.ClassId.ToString();
                        this.txtSeat.Text = model.Seat.ToString();
                        this.txtCarContent.Value = model.CarDesc;
                        this.txtOrderTip.Value = model.CarOrderTip;
                        //状态属性
                        foreach (ListItem item in chkState.Items)
                        {
                            if (model.State.Contains("," + item.Value + ","))
                            {
                                item.Selected = true;
                            }
                        }
                        this.txtSort.Text = model.Sort.ToString();
                        this.chkIsLock.Checked = model.IsLock == 1;
                    }
                }
            }
        }
        /// <summary>
        /// 保存进入到下一步
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            TravelAgent.Model.CarList model = new TravelAgent.Model.CarList();
            model.CarName = this.txtCarName.Text.Trim();
            model.CarPic = this.txtImgUrl.Text;
            model.BrandId = Convert.ToInt32(this.ddlBrand.SelectedValue);
            model.ClassId = Convert.ToInt32(this.ddlClass.SelectedValue);
            model.Seat = Convert.ToInt32(this.txtSeat.Text);
            model.CarDesc = this.txtCarContent.Value;
            model.CarOrderTip = this.txtOrderTip.Value;
             string strState = "";
            foreach (ListItem item in chkState.Items)
            {
                if (item.Selected)
                {
                    strState = strState + item.Value + ",";
                }
            }
            model.State = !strState.Equals("") ? "," + strState : "";
            model.Sort = Convert.ToInt32(this.txtSort.Text);
            model.IsLock = this.chkIsLock.Checked ? 1 : 0;
            try
            {
                if (carid > 0)
                {
                    string strsql = "update CarList set CarName='"+model.CarName+"',CarPic='"+model.CarPic+"',BrandId='"+model.BrandId+"',ClassId='"+model.ClassId+"',";
                    strsql += "Seat='"+model.Seat+"',CarDesc='"+model.CarDesc+"',CarOrderTip='"+model.CarOrderTip+"',State='"+model.State+"',IsLock='"+model.IsLock+"',Sort='"+model.Sort+"' where Id="+carid;
                    if (CarBll.Update(strsql) > 0)
                    {
                        JscriptPrint("保存成功！", "CarTwo.aspx?carid=" + carid + "&tag=edit", "Success");
                    }
                    else
                    {
                        JscriptPrint("保存失败！", Request.Url.ToString(), "Error");
                    }
                }
                else
                {
                    carid = CarBll.Add(model);
                    if (carid > 0)
                    {
                        JscriptPrint("新增成功！", "CarTwo.aspx?carid=" + carid + "&tag=add", "Success");
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
            TravelAgent.Model.CarList model = new TravelAgent.Model.CarList();
            model.CarName = this.txtCarName.Text.Trim();
            model.CarPic = this.txtImgUrl.Text;
            model.BrandId = Convert.ToInt32(this.ddlBrand.SelectedValue);
            model.ClassId = Convert.ToInt32(this.ddlClass.SelectedValue);
            model.Seat = Convert.ToInt32(this.txtSeat.Text);
            model.CarDesc = this.txtCarContent.Value;
            model.CarOrderTip = this.txtOrderTip.Value;
            string strState = "";
            foreach (ListItem item in chkState.Items)
            {
                if (item.Selected)
                {
                    strState = strState + item.Value + ",";
                }
            }
            model.State = !strState.Equals("") ? "," + strState : "";
            model.Sort = Convert.ToInt32(this.txtSort.Text);
            model.IsLock = this.chkIsLock.Checked ? 1 : 0;
            try
            {
                if (carid > 0)
                {
                    string strsql = "update CarList set CarName='',CarPic='',BrandId='',ClassId='',";
                    strsql += "Seat='',CarDesc='',CarOrderTip='',State='',IsLock='',Sort='' where Id=" + carid;
                    if (CarBll.Update(strsql) > 0)
                    {
                        JscriptPrint("保存成功！", "CarList.aspx", "Success");
                    }
                    else
                    {
                        JscriptPrint("保存失败！", Request.Url.ToString(), "Error");
                    }
                }
                else
                {
                    carid = CarBll.Add(model);
                    if (carid > 0)
                    {
                        JscriptPrint("新增成功！", "CarList.aspx", "Success");
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
    }
}
