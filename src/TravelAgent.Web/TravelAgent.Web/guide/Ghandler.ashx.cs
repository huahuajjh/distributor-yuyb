using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TravelAgent.Model;
using System.Text.RegularExpressions;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using System.Data;
using System.Net;

namespace TravelAgent.Web.guide
{
    /// <summary>
    /// Ghandler 的摘要说明
    /// </summary>
    public class Ghandler : IHttpHandler, System.Web.SessionState.IRequiresSessionState
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

            string cmd = context.Request["cmd"];
            switch (cmd)
            {
                case "AddRoute":
                    AddRoute(context);
                    break;
                case "DelRoute":
                    DelRoute(context);
                    break;
                case "AddSpot":
                    AddSpot(context);
                    break;
                case "DelSpot":
                    DelSpot(context);
                    break;
                case "GetGallery":
                    GetGallery(context);
                    break;
                case "upload":
                    break;
                case "savetemp":
                    savetemp(context);
                    break;
                case "saveroute":
                    saveroute(context);
                    break;
                case "save_guide":
                    save_guide(context);
                    break;
                case "comment":
                    comment(context);
                    break;
                case "guidelist":
                    string str = guidelist(context);
                    context.Response.Write(str);
                    break;
                case "sendcode":
                    sendcode(context);
                    break;
            }
        }
        public void sendcode(HttpContext context)
        {
            string ccode = Str_char(4, false);
            context.Session["ccode"] = ccode;
            string mobile = context.Request["mobile"];

            string account = "HCCF123";
            string password = "Vason168168";
            string PostUrl = "http://222.73.117.169/msg/HttpBatchSendSM";
            string content = ccode;
            //string postStrTpl = string.Format("account={0}&pswd={1}&mobile={2}&msg={3}&needstatus=true&product=&extno=", account, password, mobile, content);
            string postStrTpl = "account={0}&pswd={1}&mobile={2}&msg={3}&needstatus=true&product=&extno=";
            UTF8Encoding encoding = new UTF8Encoding();
            byte[] postData = encoding.GetBytes(string.Format(postStrTpl, account, password, mobile, content));

            HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(PostUrl);
            myRequest.Method = "POST";
            myRequest.ContentType = "application/x-www-form-urlencoded";
            myRequest.ContentLength = postData.Length;

            Stream newStream = myRequest.GetRequestStream();
            // Send the data.
            newStream.Write(postData, 0, postData.Length);
            newStream.Flush();
            newStream.Close();

            HttpWebResponse myResponse = (HttpWebResponse)myRequest.GetResponse();
            if (myResponse.StatusCode == HttpStatusCode.OK)
            {
                StreamReader reader = new StreamReader(myResponse.GetResponseStream(), Encoding.UTF8);
                string str = reader.ReadToEnd();
                context.Response.Write(str);
                //反序列化upfileMmsMsg.Text
                //实现自己的逻辑
            }
            else
            {
                context.Response.Write(myResponse.StatusCode);
                //访问失败
            }

        }
        public string Str_char(int Length, bool Sleep)
        {
            if (Sleep) System.Threading.Thread.Sleep(3);
            char[] Pattern = new char[] { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };
            string result = "";
            int n = Pattern.Length;
            System.Random random = new Random(~unchecked((int)DateTime.Now.Ticks));
            for (int i = 0; i < Length; i++)
            {
                int rnd = random.Next(0, n);
                result += Pattern[rnd];
            }
            return result;
        }
        public string guidelist(HttpContext context)
        {
            int id;
            int.TryParse(context.Request["id"], out id);
            TourGuide gde = guide.GetModel(id);
            if (gde != null)
            {
                TourGuideRoute route = tre.GetModel(gde.temp_id);
                List<TourGuideSpot> sp = spot.GetList(gde.temp_id);
                List<TourGuideGallery> gylist = tgy.GetListByguideid(gde.temp_id);
                gde.routetitle = route.title;
                gde.routecontent = route.contents;
                if (gylist.Count > 0)
                {
                    gde.image = gylist[0].image;
                }
                else
                {
                    gde.image = "";
                }
            }
            return JsonConvert.SerializeObject(gde);
            //StringBuilder sb = new StringBuilder();

            //sb.Append("<div class=\"item\">");
            //sb.Append("<div class=\"notes_title\">");
            //sb.Append("<a href=\"show.aspx?id=\" class=\"title_pic\"><img src=\"\"></a> <a href=\"\" class=\"title_content\">上海东方明珠塔</a>");
            //sb.Append("</div>");
            //sb.Append("<div class=\"notes_count\">");
            //sb.Append("<span class=\"reply_count\">0</span>");
            //sb.Append("<span class=\"view_count\">2</span>");
            //sb.Append("</div>");
            //sb.Append("<div class=\"notes_info\">");
            //sb.Append("<a href=\"\"><img class=\"GUID\" uid=\"1\" src=\"\"></a>");
            //sb.Append("<span><a href=\"\">fanwe</a></span>");
            //sb.Append("<div><a href=\"\" class=\"notes_info_content\">匙、二是做消费凭证（每张卡可关联自己信用卡，并每卡有三百美元消费额度）…</a></div>");
            //sb.Append("</div>");
            //sb.Append("</div>");


            //return "";
        }
        public void comment(HttpContext context)
        {
            string user_id = TravelAgent.Tool.CookieHelper.GetCookieValue("uid");
            string msg = "";
            if (string.Empty == user_id)
            {
                msg = "{\"result\":\"false\",\"reason\":\"needlogin\"}";
                context.Response.Write(msg);
                return;
            }
            string contents = context.Request["contents"];
            int comment_type = Convert.ToInt32(context.Request["comment_type"]);
            int comment_rel_id = Convert.ToInt32(context.Request["comment_rel_id"]);
            Club user = club.GetModel(Convert.ToInt32(user_id));
            TourComment comm = new TourComment();
            comm.contents = contents;
            comm.comment_type = comment_type;
            comm.comment_rel_id = comment_rel_id;
            comm.user_id = user.id;
            comm.nickname = user.clubMobile;
            comm.create_time = DateTime.Now;
            comments.Add(comm);

            //更新评论数
            TourGuide tg = guide.GetModel(comment_rel_id);
            List<TourComment> tclist = comments.GetList(comment_rel_id);
            tg.commentcount = (tclist.Count);
            guide.Update(tg);
            msg = "{\"result\":\"true\",\"reason\":\"true\"}";
            context.Response.Write(msg);
        }
        public void save_guide(HttpContext context)
        {
            int id = Convert.ToInt32(context.Request["id"]);
            string title = context.Request["title"];
            int tourrange = Convert.ToInt32(context.Request["tourrange"]);
            int tourtype = Convert.ToInt32(context.Request["tourtype"]);

            TourGuideTemp temp = tgt.GetModel(id);
            TourGuide gde = new TourGuide();
            gde.userid = temp.userid;
            gde.nickname = temp.nickname;
            gde.title = temp.title;
            gde.createtime = temp.createtime;
            gde.imagelist = temp.imagelist;
            gde.imagecount = temp.imagecount;
            gde.commentcount = temp.commentcount;
            gde.areamatch = temp.areamatch;
            gde.areamathrow = temp.areamathrow;
            gde.istuijian = temp.istuijian;
            gde.ispublish = 0;
            gde.tourdays = temp.tourdays;
            gde.browsecount = 0;
            gde.updatetime = temp.updatetime;
            gde.prasecount = temp.prasecount;
            gde.ishot = temp.ishot;
            gde.isindex = temp.isindex;
            gde.tourrange = temp.tourrange;
            gde.tourtype = temp.tourtype;
            gde.temp_id = temp.Id;
            guide.Add(gde);
        }
        public void savetemp(HttpContext context)
        {
            int id = Convert.ToInt32(context.Request["id"]);
            string title = context.Request["title"];
            int tourrange = Convert.ToInt32(context.Request["tourrange"]);
            int tourtype = Convert.ToInt32(context.Request["tourtype"]);

            TourGuideTemp temp = tgt.GetModel(id);
            temp.title = title;
            temp.tourrange = tourrange;
            temp.tourtype = tourtype;
            tgt.Update(temp);
        }
        public void saveroute(HttpContext context)
        {

            int id = Convert.ToInt32(context.Request["id"]);
            DateTime dates = Convert.ToDateTime(context.Request["date"]);
            string title = context.Request["title"];
            string content = context.Request["content"];
            TourGuideRoute route = tre.GetModel(id);
            route.title = title;
            route.routetime = dates;
            route.contents = content;
            tre.Update(route);
        }
        public void AddRoute(HttpContext context)
        {
            int id = Convert.ToInt32(context.Request["gid"]);
            TourGuideTemp temp = tgt.GetModel(id);
            TourGuideRoute route = new TourGuideRoute();
            route.guideid = id;
            route.routetime = DateTime.Now;
            route.title = "";
            route.contents = "";
            tre.Add(route);
        }
        public void DelRoute(HttpContext context)
        {
            int id = Convert.ToInt32(context.Request["rid"]);
            tre.Delete(id);
        }
        public void AddSpot(HttpContext context)
        {
            int gid = Convert.ToInt32(context.Request["gid"]);
            int rid = Convert.ToInt32(context.Request["rid"]);
            string areaname = context.Request["areaname"];
            TourGuideSpot spots = new TourGuideSpot();
            spots.guideid = gid;
            spots.routeid = rid;
            spots.areaname = areaname;
            spots.routetime = DateTime.Now;
            spots.gallery = "";
            spots.sort = spot.GetMaxID("id") + 1;
            spot.Add(spots);
            int id = spot.GetMaxID("id");
            TourGuideSpot tgs = spot.GetModel(id);

            context.Response.Write(Newtonsoft.Json.JsonConvert.SerializeObject(tgs));
        }
        public void DelSpot(HttpContext context)
        {
            int id = Convert.ToInt32(context.Request["rid"]);
            spot.Delete(id);
        }

        public void GetGallery(HttpContext context)
        {
            string spotid = context.Request["spotid"];
            List<TourGuideGallery> list = tgy.GetList(Convert.ToInt32(spotid));
            context.Response.Write(Newtonsoft.Json.JsonConvert.SerializeObject(list));
            //return Newtonsoft.Json.JsonConvert.;
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