using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using TravelAgent.Tool;
namespace TravelAgent.Web
{
    public partial class RandomImage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Random rand = new Random();

            //获取随机字符
            string str = TravelAgent.Tool.StringPlus.GetRandString(4);
            CookieHelper.ClearCookie("yzm");
            CookieHelper.SetCookie("yzm", str);
            //创建画板
            Bitmap image = new Bitmap(80, 25);
            Graphics g = Graphics.FromImage(image);
            //g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.InterpolationMode = InterpolationMode.Low;
            //g.CompositingMode = CompositingMode.SourceOver;
            //g.CompositingQuality = CompositingQuality.HighQuality;
            g.CompositingQuality = CompositingQuality.HighSpeed;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            //绘制渐变背景
            Rectangle rect = new Rectangle(0, 0, image.Width, image.Height);
            Brush brushBack = new LinearGradientBrush(rect, Color.FromArgb(rand.Next(150, 256), 255, 255), Color.FromArgb(255, rand.Next(150, 256), 255), rand.Next(90));
            g.FillRectangle(brushBack, rect);

            //绘制干扰曲线
            for (int i = 0; i < 2; i++)
            {
                Point p1 = new Point(0, rand.Next(image.Height));
                Point p2 = new Point(rand.Next(image.Width), rand.Next(image.Height));
                Point p3 = new Point(rand.Next(image.Width), rand.Next(image.Height));
                Point p4 = new Point(image.Width, rand.Next(image.Height));
                Point[] p = { p1, p2, p3, p4 };
                Pen pen = new Pen(Color.Gray, 1);
                g.DrawBeziers(pen, p);
            }

            //逐个绘制文字
            for (int i = 0; i < str.Length; i++)
            {
                string strChar = str.Substring(i, 1);
                int deg = rand.Next(-15, 15);
                float x = (image.Width / str.Length / 2) + (image.Width / str.Length) * i;
                float y = image.Height / 2;
                //随机字体大小
                Font font = new Font("Consolas", rand.Next(16, 24), FontStyle.Regular);
                SizeF size = g.MeasureString(strChar, font);
                Matrix m = new Matrix();
                //旋转
                m.RotateAt(deg, new PointF(x, y), MatrixOrder.Append);
                //扭曲
                m.Shear(rand.Next(-10, 10) * 0.03f, 0);
                g.Transform = m;
                //随机渐变画笔
                Brush brushPen = new LinearGradientBrush(rect, Color.FromArgb(rand.Next(0, 256), 0, 0), Color.FromArgb(0, 0, rand.Next(0, 256)), rand.Next(90));
                g.DrawString(str.Substring(i, 1), font, brushPen, new PointF(x - size.Width / 2, y - size.Height / 2));

                g.Transform = new Matrix();
            }

            g.Save();
            Response.ContentType = "image/jpeg";
            Response.Clear();
            Response.BufferOutput = true;
            image.Save(Response.OutputStream, ImageFormat.Jpeg);
            g.Dispose();
            image.Dispose();
            Response.Flush();
        }
        
    }
}
