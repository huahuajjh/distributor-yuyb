using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TravelAgent.Model;
using System.Text;

namespace TravelAgent.Web.guide
{
    public partial class show : System.Web.UI.Page
    {
        TravelAgent.BLL.TourGuide guide = new BLL.TourGuide();
        TravelAgent.BLL.TourGuideTemp tgt = new BLL.TourGuideTemp();
        TravelAgent.BLL.TourGuideRoute tre = new BLL.TourGuideRoute();
        TravelAgent.BLL.TourGuideSpot spot = new BLL.TourGuideSpot();
        TravelAgent.BLL.TourGuideGallery tgy = new BLL.TourGuideGallery();
        TravelAgent.BLL.AdminList admin = new BLL.AdminList();
        TravelAgent.BLL.Club club = new BLL.Club();
        TravelAgent.BLL.TourComment comment = new BLL.TourComment();
        public Club user = null;
        public TourGuide gd = null;
        public TourGuideTemp tt = null;
        public List<TourGuideRoute> routelist = new List<TourGuideRoute>();
        public AdminList ad = new AdminList();
        public string begindate="";
        public List<TourComment> comlist = new List<TourComment>();
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetNoStore();
            if (!IsPostBack) {
                int id;
                int.TryParse(Request["id"], out id);
                gd = guide.GetModel(id);
                if (gd != null)
                {
                    gd.browsecount = gd.browsecount + 1;
                    guide.Update(gd);
                    gd = guide.GetModel(id);
                    string userid = gd.userid;
                    user = club.GetModel(Convert.ToInt32(userid));
                    tt = tgt.GetModel(gd.temp_id);
                    routelist = tre.GetList(tt.Id);
                    if (routelist.Count > 0)
                    {
                        begindate = routelist[0].routetime.ToString("yyyy-MM-dd");
                        //Response.Write(routelist[0].routetime);
                    }
                    StringBuilder sb = new StringBuilder();

                    for (int i = 0; i < routelist.Count; i++)
                    {

                        sb.Append("<div class=\"day_box\">");
                        sb.Append("<div class=\"day_item\">");
                        sb.Append("<div class=\"room-title\">");
                        sb.Append("<p>第<em>" + (i + 1) + "</em>天</p>");
                        sb.Append("<p class=\"date\">" + routelist[i].routetime.ToString("yyyy-MM-dd") + "</p>");
                        sb.Append("<p class=\"cities\">");
                        sb.Append("<span></span>&nbsp;&nbsp;<a href=\"javascript:;\" rel=\"nofollow\">" + routelist[i].title + "</a>");
                        //sb.Append("<span></span>&nbsp;&nbsp;<a href=\"javascript:;\" rel=\"nofollow\">上海</a>");
                        sb.Append("&nbsp;&nbsp;&gt;");
                        sb.Append("</p>");
                        sb.Append("</div>");

                        sb.Append("<div class=\"day_content\">");
                        sb.Append("<div class=\"route_title\">" + routelist[i].title + "</div>");
                        int routeid = routelist[i].id;
                        List<TourGuideSpot> spotlist = spot.GetList(routeid);
                        for (int j = 0; j < spotlist.Count; j++)
                        {
                            sb.Append("<div class=\"day_spot\">");
                            sb.Append(" <div class=\"room-city\">");
                            sb.Append("<p class=\"city-name\" data-destination=\"" + spotlist[j].areaname + "\"><span></span>&nbsp;<a href=\"javascript:;\" rel=\"nofollow\">" + spotlist[j].areaname + "</a></p>");
                            sb.Append("</div>");
                            sb.Append("<div class=\"spot_gallery_list\">");
                            sb.Append("<ul>");
                            int spotid = spotlist[j].id;
                            List<TourGuideGallery> gallerylist = tgy.GetList(spotid);
                            for (int p = 0; p < gallerylist.Count; p++)
                            {
                                sb.Append("<li class=\"pic_item\">");
                                sb.Append("<a href=\"\"><img src=\"../" + gallerylist[p].image + "\"/></a>");
                                sb.Append("</li>");
                            }


                            sb.Append("</ul>");
                            sb.Append("</div>");
                            sb.Append("</div>");
                        }
                        ///////////////////////////////

                        //////////////////////////////////////
                        //
                        sb.Append("<div class=\"day_desc\">" + routelist[i].contents + "</div>");
                        sb.Append("</div>");
                        sb.Append("</div>");
                        sb.Append("</div>");
                    }
                    J_nbox_0.InnerHtml = sb.ToString();
                    comlist = comment.GetList(id);
                    CommentList(comlist);
                }
            }
            if (gd == null) { gd = new TourGuide(); Response.Redirect("/Opr.aspx?t=error&msg=opr"); }
            if (tt == null) { tt = new TourGuideTemp(); Response.Redirect("/Opr.aspx?t=error&msg=opr"); }
            if (user == null) { user = new Club(); Response.Redirect("/Opr.aspx?t=error&msg=opr"); }
        }

        private void CommentList(List<TourComment> clist) { 
            StringBuilder sb=new StringBuilder();
            sb.Append("<div class=\"comment_list\">");
            
            for(int i=0;i<clist.Count;i++){
                TourComment tc=clist[i];
                sb.Append("<div class=\"comment_content\">");
                sb.Append(" <div class=\"comment_info\">");
                sb.Append(" <div class=\"floor_info\">");
                sb.Append(" <p class=\"floor_info_p\">");
                sb.Append(" <a href=\"#\">"+tc.nickname+"</a>");
                sb.Append("</p>");
                sb.Append("<div class=\"floor_content\">");
                sb.Append("  <div class=\"inner_floor_content\">");
                sb.Append(" <blockquote>");
                sb.Append(" <p>"+tc.contents+"</p>");
                sb.Append("</blockquote>");
                sb.Append("<div class=\"quote_info\">");
                sb.Append("<span class=\"quote_time\">发表于 "+tc.create_time.ToString("yyyy-MM-dd HH:mm:ss")+"</span>");
                sb.Append("</div>");
                sb.Append("</div>");
                sb.Append("</div>");
                sb.Append(" <div class=\"blank15\"></div>");
                sb.Append("</div>");
                sb.Append("</div>");
                sb.Append("<div class=\"comment_portait\">");
                sb.Append("<a href=\"#\"><img class=\"GUID\" uid=\"11\" src=\"../member/images/clubpic.gif\" style=\"width:50;height:50;\"></a>");
                sb.Append("</div>");
                sb.Append("</div>");
                //sb.Append("");
                //sb.Append("</div>");
            }
            
            sb.Append("</div>");
            show_comment.InnerHtml = sb.ToString();
            
        }


    }
}