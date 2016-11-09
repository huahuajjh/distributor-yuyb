using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.SessionState;
using System.IO;
using TravelAgent.Model;

namespace TravelAgent.Web.guide
{
    /// <summary>
    /// upload 的摘要说明
    /// </summary>
    /// 
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]

    public class upload : IHttpHandler, IRequiresSessionState
    {
        TravelAgent.BLL.TourGuideTemp tgt = new BLL.TourGuideTemp();
        TravelAgent.BLL.TourGuideRoute tre = new BLL.TourGuideRoute();
        TravelAgent.BLL.TourGuideSpot spot = new BLL.TourGuideSpot();
        TravelAgent.BLL.TourGuideGallery tgy = new BLL.TourGuideGallery();
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Charset = "utf-8";

            HttpPostedFile file = context.Request.Files["Filedata"];
            string uploadPath = context.Server.MapPath("..\\uploads\\");
            string temp = DateTime.Now.ToString("yyyyMMddhhmmss");
            if (file != null)
            {
                if (!Directory.Exists(uploadPath))
                {
                    Directory.CreateDirectory(uploadPath);
                }
                file.SaveAs(uploadPath + temp + file.FileName);
                context.Response.Write("uploads/"+ temp + file.FileName);
                Add_pics(Convert.ToInt32(context.Request["rid"]), Convert.ToInt32(context.Request["sid"]), "uploads/" + temp + file.FileName);
                //生成缩略图  
                //MakeThumbnail(uploadPath + file.FileName, uploadPath + "\\s\\" + file.FileName, 80, 80);
            }
        }
        private void Add_pics(int routeid,int spotid,string fileimage) {
            TourGuideRoute routes=tre.GetModel(routeid);
            int guideid = routes.guideid;
            TourGuideGallery gallery = new TourGuideGallery();
            gallery.guideid = guideid;
            gallery.image = fileimage;
            gallery.routetime = DateTime.Now;
            gallery.areaname = "";
            gallery.routeid = routeid;
            gallery.spotid = spotid;
            gallery.width = 100;
            gallery.height = 100;
            tgy.Add(gallery);

        }
        private void MakeThumbnail(string sourcePath, string newPath, int width, int height)
        {
            System.Drawing.Image ig = System.Drawing.Image.FromFile(sourcePath);
            int towidth = width;
            int toheight = height;
            int x = 0;
            int y = 0;
            int ow = ig.Width;
            int oh = ig.Height;
            if ((double)ig.Width / (double)ig.Height > (double)towidth / (double)toheight)
            {
                oh = ig.Height;
                ow = ig.Height * towidth / toheight;
                y = 0;
                x = (ig.Width - ow) / 2;

            }
            else
            {
                ow = ig.Width;
                oh = ig.Width * height / towidth;
                x = 0;
                y = (ig.Height - oh) / 2;
            }
            System.Drawing.Image bitmap = new System.Drawing.Bitmap(towidth, toheight);
            System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(bitmap);
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            g.Clear(System.Drawing.Color.Transparent);
            g.DrawImage(ig, new System.Drawing.Rectangle(0, 0, towidth, toheight), new System.Drawing.Rectangle(x, y, ow, oh), System.Drawing.GraphicsUnit.Pixel);
            try
            {
                bitmap.Save(newPath, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                ig.Dispose();
                bitmap.Dispose();
                g.Dispose();
            }

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