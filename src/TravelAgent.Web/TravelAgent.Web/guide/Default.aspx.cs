using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TravelAgent.Model;

namespace TravelAgent.Web.guide
{
    public partial class Default : TravelAgent.Web.UI.mBasePage
    {
        TravelAgent.BLL.TourGuide guide = new BLL.TourGuide();
        TravelAgent.BLL.TourGuideTemp tgt = new BLL.TourGuideTemp();
        TravelAgent.BLL.TourGuideRoute tre = new BLL.TourGuideRoute();
        TravelAgent.BLL.TourGuideSpot spot = new BLL.TourGuideSpot();
        TravelAgent.BLL.TourGuideGallery tgy = new BLL.TourGuideGallery();
        TravelAgent.BLL.AdminList admin = new BLL.AdminList();
        TravelAgent.BLL.Club club = new BLL.Club();
        TravelAgent.BLL.TourComment comment = new BLL.TourComment();
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Title = "游记" + Master.webinfo.WebName;
            Initpages();
        }
        private void Initpages() {

            List<TourGuide> list = guide.GetListPublis();
            string mstr = "";
            for (int i = 0; i < list.Count; i++) {
                mstr += list[i].Id + "|";
            }
            datalists.Value = mstr;
        }
    }
}