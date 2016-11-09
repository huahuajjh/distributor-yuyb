using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TravelAgent.Web.admin.product
{
    public partial class LineTwo : TravelAgent.Web.UI.BasePage
    {
        public int lineid;
        public string tag;
        private static readonly TravelAgent.BLL.Line LineBll = new TravelAgent.BLL.Line();
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
                if (lineid > 0)
                {
                    TravelAgent.Model.Line line = LineBll.GetModel(lineid);
                    if (line != null)
                    {
                        this.txtStartDate.Value = line.PriceSDate;
                        this.txtEndDate.Value = line.PriceEDate;
                        this.rbtnPlanType.SelectedValue = line.PriceEditModel.ToString();
                        if (rbtnPlanType.SelectedValue == "1")//按周
                        {
                            foreach (ListItem item in chkWeekList.Items)
                            {
                                if (TravelAgent.Tool.CommonOprate.IsContainValue(item.Value, line.PriceSetting))
                                {
                                    item.Selected = true;
                                }
                            }
                            this.hidweek.Value = line.PriceSetting;
                            this.trWeek.Style["display"] = "";
                        }
                        else if (rbtnPlanType.SelectedValue == "2")//按号
                        {
                            foreach (ListItem item in chkDayList.Items)
                            {
                                if (TravelAgent.Tool.CommonOprate.IsContainValue(item.Value, line.PriceSetting))
                                {
                                    item.Selected = true;
                                }
                            }
                            this.hidday.Value = line.PriceSetting;
                            this.trDay.Style["display"] = "";
                        }
                        if (!line.PriceContent.Equals(""))
                        {
                            string[] strArryPrice = line.PriceContent.Split(',');
                            this.txtMenshi_adult.Value = strArryPrice[0];
                            this.txtMenshi_child.Value = strArryPrice[1];
                            this.txtPrice_adult.Value = strArryPrice[2];
                            this.txtPrice_child.Value = strArryPrice[3];
                            this.txtUsePoints_adult.Value = strArryPrice[4];
                            this.txtUsePoints_child.Value = strArryPrice[5];
                            this.txtDoPoints_adult.Value = strArryPrice[6];
                            this.txtDoPoints_child.Value = strArryPrice[7];
                            this.txtCheng_adult.Value = strArryPrice[8];
                            this.txtCheng_child.Value = strArryPrice[9];
                            this.txtDFC.Value = strArryPrice[10];
                            this.txtNumber.Value = strArryPrice[11];
                        }
                       

                        this.rbtnDealType.SelectedValue = line.DealType.ToString();
                    }
                }
            }
        }
    }
}
