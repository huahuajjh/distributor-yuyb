using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TravelAgent.Model;

namespace TravelAgent.Web.admin.guide
{
    /// <summary>
    /// guideback 的摘要说明
    /// </summary>
    public class guideback : IHttpHandler
    {
        TravelAgent.BLL.TourGuide guide = new BLL.TourGuide();
        TravelAgent.BLL.TourGuideTemp tgt = new BLL.TourGuideTemp();
        TravelAgent.BLL.TourGuideRoute tre = new BLL.TourGuideRoute();
        TravelAgent.BLL.TourGuideSpot spot = new BLL.TourGuideSpot();
        TravelAgent.BLL.TourGuideGallery tgy = new BLL.TourGuideGallery();
        TravelAgent.BLL.TourComment comments = new BLL.TourComment();
        TravelAgent.BLL.Club club = new BLL.Club();
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string cmd=context.Request["cmd"];
            switch (cmd)
            {
                case "check":
                    Check(context);
                    break;
                case "DeleteGuide":
                    DeleteGuide(context);
                    break;
            }

        }
        public void Check(HttpContext context)
        { 
            int id=Convert.ToInt32( context.Request["id"]);
            TourGuide gd = guide.GetModel(id);
            gd.ispublish = 1;
            guide.Update(gd);

        }
        public void DeleteGuide(HttpContext context)
        {
            int id = Convert.ToInt32(context.Request["id"]);
            guide.Delete(id);
        
        }
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}