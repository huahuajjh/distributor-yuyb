using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TravelAgent.Web.admin.product
{
    public partial class LineFour : TravelAgent.Web.UI.BasePage
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
                         this.txtCost.Value = line.LineCost;
                         this.txtOrder.Value = line.OrderTips;
                         this.txtTravel.Value = line.TravelNotice;
                     }
                }
            }
        }
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            string strsql = "update Line set lineCost='" + this.txtCost.Value + "',orderTips='" + this.txtOrder.Value + "',travelNotice='"+this.txtTravel.Value+"' where Id="+lineid;

            try
            {
                if (LineBll.Update(strsql) > 0)
                {
                    JscriptPrint("保存成功！", Request.Url.ToString(), "Success");
                }
                else
                {
                    JscriptPrint("保存失败！", Request.Url.ToString(), "Error");
                }
            }
            catch
            {
                JscriptPrint("保存失败！", Request.Url.ToString(), "Error");
            }
        }
    }
}
