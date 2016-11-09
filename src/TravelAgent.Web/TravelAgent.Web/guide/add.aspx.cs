using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using TravelAgent.Model;

namespace TravelAgent.Web.guide
{
    public partial class add : System.Web.UI.Page
    {
        public string htmlstr = "";
        TravelAgent.BLL.TourGuideTemp tgt = new BLL.TourGuideTemp();
        TravelAgent.BLL.TourGuideRoute tre = new BLL.TourGuideRoute();
        TravelAgent.BLL.TourGuideSpot spot = new BLL.TourGuideSpot();
        TravelAgent.BLL.TourGuideGallery tgy = new BLL.TourGuideGallery();
        public int guid = 0;
        public TourGuideTemp temp1;
        protected void Page_Load(object sender, EventArgs e)
        {
           
            Response.Cache.SetNoStore();
            if (!IsPostBack) {
                string userid = TravelAgent.Tool.CookieHelper.GetCookieValue("uid");
                if (userid == "" || userid == null) {
                    Response.Redirect("../member/Login.aspx");
                }
                string username = TravelAgent.Tool.CookieHelper.GetCookieValue("username");
                //
                TourGuideTemp tg= tgt.GetModelByUser(userid);
                tourid.Value = tg.Id.ToString();
                int id = tg.Id;
                guid = id;
                if (tg != null && tg.Id!=null)
                {
                    
                    //TourGuideTemp tg = tgt.GetModel(id);
                    List<TourGuideRoute> routelist = tre.GetList(id);
                    List<TourGuideGallery> gallerylist = tgy.GetList(id);
                    StringBuilder sb = new StringBuilder();
                    for (int i = 0; i < routelist.Count; i++) {
                        int sid = routelist[i].id;
                        sb.Append(getTempstr(id,sid,(i+1)));
                    }
                    htmlstr = sb.ToString();
                }else{
                    //TourGuideTemp tg = new TourGuideTemp();
                    StringBuilder sb = new StringBuilder();

                    tg.userid = userid;
                    tg.nickname = username;
                    tg.createtime = DateTime.Now;
                    tg.updatetime = DateTime.Now;
                    tgt.Add(tg);
                    int sid = tgt.GetMaxID("id");
                    guid = sid;
                    tg = tgt.GetModel(sid);
                    List<TourGuideRoute> routelist = tre.GetList(sid);
                    TourGuideRoute route = new TourGuideRoute();
                    if (routelist.Count == 0) {                        
                        route.guideid = sid;
                        route.routetime = DateTime.Now;
                        tre.Add(route);
                    }

                    routelist = tre.GetList(sid);

                    List<TourGuideGallery> gallerylist = tgy.GetList(sid);

                    for (int i = 0; i < routelist.Count; i++)
                    {
                        int pid = routelist[i].id;
                        sb.Append(getTempstr(id, sid,(i+1)));
                    }
                    htmlstr = sb.ToString();
                    
                }
                 temp1 = tgt.GetModel(guid);
                 if (temp1.tourrange == null) {
                     temp1.tourrange = 1;
                 }
                 if (temp1.tourtype == null) {
                     temp1.tourtype = 1;
                 }
                show_guide.InnerHtml = htmlstr;
                
            }
            

        }
        /// <summary>
        /// 加载模板
        /// </summary>
        /// <param name="guideid">guideid</param>
        /// <param name="routeid">routeid</param>
        /// <param name="index"></param>
        /// <returns></returns>
        private string getTempstr(int guideid, int routeid, int index)
        {
            
            TourGuideRoute route1 = tre.GetModel(routeid);
            StringBuilder sb = new StringBuilder();
            sb.Append("<div class=\"guide_day_item guide_day_item_route_id_" + routeid + "\" data_route_id=\"" + routeid + "\">");
            sb.Append("<div class=\"blank20\"></div>");
            sb.Append("<div class=\"t_day\">");
            sb.Append("<div class=\"day_num\">");
            sb.Append("第 <span>" + index + "</span> 天");
            sb.Append("</div>");
            sb.Append("<div class=\"day_date\">");
            string datestr = route1.routetime.ToString("MM/dd/yyyy");
            if (datestr == "") {
                datestr = "请选择日期";
            }
            sb.Append("<input class=\"begin_date route_time route_time_" + routeid + "\" id=\"begin_date_" + routeid + "\" data_route=\"" + routeid + "\" type=\"text\" readonly=\"true\" value=\"" + datestr + "\" title=\"\" ></div>");
            sb.Append("<div>");
            sb.Append("<a class=\"t_edit\" title=\"修改行程日期\" href=\"javascript:void(0);\" onclick=\"Show_Datepicker(" + routeid + ")\"></a>");
            sb.Append("<a class=\"t_delete\" title=\"删除行程\" href=\"javascript:void(0);\" onclick=\"deleteroute(" + routeid + ")\"></a>");
            sb.Append("</div>");
            sb.Append("</div>");
            sb.Append("<div class=\"t_day_box\">");
            sb.Append("<div class=\"write_box\">");
            sb.Append("<div class=\"input_item\">");
            sb.Append("<input class=\"input_limit input_data\" id=\"route_title_" + routeid + "\" data_type=\"route_title\" date_route=\"" + routeid + "\" hide_data=\"\" maxlength=\"30\" max_data=\"30\" type=\"text\" holder=\"输入当日标题\" value=\"" + route1.title + "\" /><span >还可以输入<i class=\"limit_num\">30</i>字</span>");
            sb.Append("</div>");
            sb.Append("<!--POI列表-->");
            sb.Append("<div class=\"poi_box ui-sortable poi_box_route_" + routeid + "\" data_route_id=\"" + routeid + "\">");

            /////////////////
           
            //sid
            List<TourGuideSpot> spotlist = spot.GetList(routeid);
            for (int i = 0; i < spotlist.Count; i++) {
                sb.Append("<div class=\"poi_dot default_poi poi_dot_spot_" + spotlist[i].id + " poi_dot_route_" + routeid + "\" data_route_id=\"" + routeid + "\" data_spot_id=\"" + spotlist[i].id + "\" onmouseover=\"thismouseover('" + spotlist[i].id + "'); \" onmouseout=\"thismouseout('" + spotlist[i].id + "');\" onclick=\"clickspot('" + spotlist[i].id + "','" + routeid + "');\" >");
                sb.Append("<p class=\"spot_area_name\">" + spotlist[i].areaname + "</p>");
                sb.Append("<p class=\"spot_action\" style=\"display: none;\" id=\"p_data_spot_id_" + spotlist[i].id + "\">");
                sb.Append("<a class=\"edit_spot\" href=\"javascript:void(0);\" data_route_id=\"" + routeid + "\" data_spot_id=\"" + spotlist[i].id + "\"></a>");
                sb.Append("<a class=\"del_spot\" href=\"javascript:void(0);\" data_route_id=\"" + routeid + "\" data_spot_id=\"" + spotlist[i].id + "\" onclick=\"delete_spots('" + spotlist[i].id + "')\"></a>");
                sb.Append("</p>");
                //根据spotid，查找gallery
                List<TourGuideGallery> gallerylist = tgy.GetList(spotlist[i].id);
                sb.Append("<p class=\"spot_gallery_num\" style=\"display: block;\"><span>" + gallerylist.Count+ "</span>张</p>");
                sb.Append("<div class=\"arr_r\">········</div>");
                sb.Append("</div>");
            }
                ////////////////////////////

            sb.Append("<div class=\"poi_dot add_poi\" data_route_id=\"" + routeid + "\" onclick=\"add_spots(" + guideid + "," + routeid + ");\"></div>");
            sb.Append("</div>");
            sb.Append("<!--POI列表 end-->");
            sb.Append("<!--图片列表-->");
            sb.Append("<div class=\"photo_content_box_route_" + routeid + " clearfix \" >");
            ////////////////////////
            if (spotlist.Count > 0)
            {
                int spotid = spotlist[0].id;
                List<TourGuideGallery> list = tgy.GetList(Convert.ToInt32(spotid));
                if (list.Count > 0)
                {
                    for (int i = 0; i < list.Count; i++)
                    {
                        TourGuideGallery gy = list[i];
                        sb.Append("<div class=\"photo_item f_l\" >");

                        sb.Append("<div class=\"img_box\"><img src=\"../" + gy.image + "\" data=\"" + gy.image + "\"></div>");
                        sb.Append("<div class=\"img_action\">");
                        sb.Append("<a href=\"javascript:void(0)\" class=\"del_img\" data_route_id=\"" + gy.routeid + "\" data_spot_id=\"" + gy.spotid + "\" data_gallery_id=\"" + gy.id + "\">删除</a>");
                        sb.Append("</div>");

                        sb.Append("</div>");
                    }
                }
                else {
                    sb.Append("<div class=\"photo_null f_l\" style=\"\"><i></i><span>这一天没有照片，请<a class=\"add_pic_btn\" href=\"javascript:void(0);\" guideid=\"" + guideid + "\" routeid=\"" + routeid + "\" id=\"img_add_"+guideid+"_"+routeid+"\" \">添加照片</a></span></div>");
                }
            }
            else {
                sb.Append("<div class=\"photo_null f_l\" style=\"\"><i></i><span>这一天没有照片，请<a class=\"add_pic_btn\" href=\"javascript:void(0);\" guideid=\"" + guideid + "\" routeid=\"" + routeid + "\" id=\"img_add_" + guideid + "_" + routeid + "\" >添加照片</a></span></div>");
            }
            
            
            ////------------------
           

            //////----------------

            ///////////////////////
            sb.Append("</div>");
            sb.Append("<!--图片列表 end-->");
            sb.Append("<div class=\"blank10\"></div>");
            sb.Append("<div class=\"write_box\">");
            sb.Append("<div class=\"textarea_item\">");
            sb.Append("<textarea  class=\"input_limit input_data\" id=\"route_content_" + routeid + "\" data_type=\"route_content\" date_route=\"" + routeid + "\" hide_data=\"\"   maxlength=\"1000\"  placeholder=\"记录旅途的点点滴滴\">" + route1.contents + "</textarea>");
            sb.Append("<span >还可以输入<i class=\"limit_num\">1000</i>字</span>");
            sb.Append("</div>");
            sb.Append("</div>");
            sb.Append("</div>");
            sb.Append("</div>");
            sb.Append("<div class=\"blank20\"></div>");                           
            sb.Append("<div class=\"blank20\"></div>");
            sb.Append("</div>");
            /////////////
            sb.Append("<script>");
            sb.Append("$(\"#begin_date_" + routeid + "\").datepicker({");
            sb.Append("format: 'Y-m-d',");
            sb.Append("numberOfMonths: 2,");
            sb.Append("maxDate: 0");
            sb.Append("});");
            sb.Append("</script>");

            //////////
             
            return sb.ToString();
        }
    }
}