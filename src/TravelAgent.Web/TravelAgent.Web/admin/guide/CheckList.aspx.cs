using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TravelAgent.Model;
using System.Data;

namespace TravelAgent.Web.admin.guide
{
    public partial class CheckList : TravelAgent.Web.UI.BasePage
    {
        TravelAgent.BLL.TourGuide guides = new BLL.TourGuide();
        TravelAgent.BLL.TourGuideRoute route = new BLL.TourGuideRoute();
        TravelAgent.BLL.TourGuideSpot spot = new BLL.TourGuideSpot();
        TravelAgent.BLL.TourGuideGallery gallery = new BLL.TourGuideGallery();
        TravelAgent.BLL.TourGuideTemp temp = new BLL.TourGuideTemp();
        public int pcount;                                   //总条数
        public int page;                                     //当前页
        public readonly int pagesize = 15;                    //设置每页显示的大小
        protected void Page_Load(object sender, EventArgs e)
        {
            

            Response.Cache.SetNoStore();
            if (!IsPostBack) {
                RptBind(""," id desc");
            }
        }
        private void Bind() {
            List<TourGuide> guidelist = guides.GetList();

        }
        private void RptBind(string strWhere, string orderby)
        {
            if (!int.TryParse(Request.Params["page"] as string, out this.page))
            {
                this.page = 0;
            }
            //获得总条数
            this.pcount = guides.GetList().Count;
            if (this.pcount > 0)
            {
                //this.lbtnDel.Enabled = true;
                //this.lbtnExport.Enabled = true;
            }
            else
            {
                //this.lbtnDel.Enabled = false;
                //this.lbtnExport.Enabled = false;
            }



            DataSet ds = guides.GetPageList(this.pagesize, this.page, strWhere, orderby);
            this.rptClub.DataSource = ds;
            this.rptClub.DataBind();
            this.trNoRecord.Style["display"] = ds.Tables[0].Rows.Count == 0 ? "" : "none";
            this.trPagination.Style["display"] = ds.Tables[0].Rows.Count == 0 ? "none" : "";
        }

    }
}