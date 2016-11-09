using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using Gma.QrCodeNet.Encoding;
using Gma.QrCodeNet.Encoding.Windows.Render;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using System.Web.Configuration;
namespace TravelAgent.WxPay
{
    public class Utils
    {
        public static string GetUnifyUrlXml<T>(T t,string key,out string url,out string _sign)
        {
            Type type = typeof (T);
            Dictionary<string,string> dic = new Dictionary<string, string>();
            PropertyInfo[] pis = type.GetProperties();
            #region 组合url参数到字典里
            foreach (PropertyInfo pi in pis)
            {
                object val = pi.GetValue(t, null);
                if (val != null)
                {
                    dic.Add(pi.Name, val.ToString());
                }
            }
            #endregion
            //字典排序
            var dictemp = dic.OrderBy(d => d.Key);
            #region 生成url字符串
            StringBuilder str = new StringBuilder();
            foreach (var item in dictemp)
            {
                str.AppendFormat("{0}={1}&", item.Key, item.Value);
            }
            #endregion
            var ourl= str.ToString().Trim('&');
            //加上key
            string tempsign = ourl + "&key="+key;
            //md5加密后，转换成大写
            string sign = MD5(tempsign).ToUpper();
            //将签名添加到字典中
            dic.Add("sign", sign);
            _sign = sign;
            url = str.AppendFormat("sign={0}",sign).ToString();
            //生成请求的内容，并返回
            return parseXML(dic);
        }

        public static string parseXML(Dictionary<string, string> parameters)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<xml>");
            foreach (string k in parameters.Keys)
            {
                string v = (string)parameters[k];
                if (Regex.IsMatch(v, @"^[0-9.]$"))
                {

                    sb.Append("<" + k + ">" + v + "</" + k + ">");
                }
                else
                {
                    sb.Append("<" + k + "><![CDATA[" + v + "]]></" + k + ">");
                }

            }
            sb.Append("</xml>");
            return sb.ToString();
        }
        /// <summary>
        /// 获取32位随机数（GUID）
        /// </summary>
        /// <returns></returns>
        public static string GetRandom()
        {
            return Guid.NewGuid().ToString("N");
        }
        /// <summary>
        /// 获取微信版本
        /// </summary>
        /// <param name="ua"></param>
        /// <returns></returns>
        public static string GetWeiXinVersion(string ua)
        {
            int Last = ua.LastIndexOf("MicroMessenger");
            string[] wxversion = ua.Remove(0, Last).Split(' ');
            return wxversion[0].Split('/')[1].Substring(0, 3);
        }

        #region MD5加密
        public static string MD5(string pwd)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] data = System.Text.Encoding.UTF8.GetBytes(pwd);
            byte[] md5data = md5.ComputeHash(data);
            md5.Clear();
            string str = "";
            for (int i = 0; i < md5data.Length; i++)
            {
                str += md5data[i].ToString("x").PadLeft(2, '0');
            }
            return str;
        }

        
        #endregion

        public static string HttpPost(string url, string param)
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.Accept = "*/*";
            request.Timeout = 15000;
            request.AllowAutoRedirect = false;

            StreamWriter requestStream = null;
            WebResponse response = null;
            string responseStr = null;

            try
            {
                requestStream = new StreamWriter(request.GetRequestStream());
                requestStream.Write(param);
                requestStream.Close();

                response = request.GetResponse();
                if (response != null)
                {
                    StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                    responseStr = reader.ReadToEnd();
                    reader.Close();
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                request = null;
                requestStream = null;
                response = null;
            }

            return responseStr;
        }
        public static string HttpPostSSL(string url, string param)
        {
 
            String result = "";
            String strPost = param;
            StreamWriter myWriter = null;
            HttpWebRequest objRequest = (HttpWebRequest)WebRequest.Create(url);
            objRequest.Method = "POST";
            objRequest.ContentLength = strPost.Length;
            objRequest.ContentType = "application/x-www-form-urlencoded";
            string PfxFile = WebConfigurationManager.AppSettings["PfxFile"].ToString();
            string PfxKey = WebConfigurationManager.AppSettings["PfxKey"].ToString();
            objRequest.ClientCertificates.Add(new X509Certificate2(PfxFile, PfxKey));
            try
            {
                myWriter = new StreamWriter(objRequest.GetRequestStream());
                myWriter.Write(strPost);
            }
            catch (Exception ex)
            {
                HttpContext.Current.Response.Write(ex.Message);
            }
            finally
            {
                myWriter.Close();
            }
            HttpWebResponse objResponse = (HttpWebResponse)objRequest.GetResponse();
            using (StreamReader sr = new  StreamReader(objResponse.GetResponseStream()))
            {
             result = sr.ReadToEnd();
            // Close and clean up the StreamReader
              sr.Close();
            }
             return result;

           
        }
        /// <summary>
        /// datetime转换为unixtime
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static int ConvertDateTimeInt(System.DateTime time)
        {
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
            return (int)(time - startTime).TotalSeconds;
        }
        public static bool WriteTxt(string str)
        {
            string debug = WebConfigurationManager.AppSettings["debug"].ToString();
            if (debug == "1")
            {
                try
                {
                    FileStream fs = new FileStream(HttpContext.Current.Request.MapPath("./Log.txt"), FileMode.Append);
                    StreamWriter sw = new StreamWriter(fs);
                    //开始写入
                    sw.WriteLine(str);
                    //清空缓冲区
                    sw.Flush();
                    //关闭流
                    sw.Close();
                    fs.Close();
                }
                catch (Exception)
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 生成二维码流
        /// </summary>
        /// <param name="qrcontent"></param>
        /// <returns></returns>
        public static MemoryStream GetQrCodeStream(string qrcontent)
        {
            //误差校正水平
            ErrorCorrectionLevel ecLevel = ErrorCorrectionLevel.M;
            //空白区域
            QuietZoneModules quietZone = QuietZoneModules.Zero;
            int ModuleSize = 120;//大小
            QrCode qrCode;
            var encoder = new QrEncoder(ecLevel);
            //对内容进行编码，并保存生成的矩阵
            if (encoder.TryEncode(qrcontent,out qrCode))
            {
                var render = new GraphicsRenderer(new FixedCodeSize(ModuleSize, quietZone));
                MemoryStream stream = new MemoryStream();
                render.WriteToStream(qrCode.Matrix, ImageFormat.Jpeg,stream);
                return stream;
            }
            return null;
        }

        public static void GetQrCode(string qrcontent)
        {
            //HttpContext.Current.Response.Write(qrcontent);
            MemoryStream ms = GetQrCodeStream(qrcontent);
            HttpContext.Current.Response.ClearContent();
            HttpContext.Current.Response.ContentType = "image/Png";
            HttpContext.Current.Response.BinaryWrite(ms.ToArray());

        }

        public static bool ValidateServerCertificate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {

            if (sslPolicyErrors == SslPolicyErrors.None)

                return true;

            return false;

        }

        public static string GetOrderNumber()
        {
            string Number = DateTime.Now.ToString("yyyyMMddHHmmss");//yyyyMMddHHmmssms
            return Number + Next(1000, 1).ToString();
        }
        private static int Next(int numSeeds, int length)
        {
            // Create a byte array to hold the random value.  
            byte[] buffer = new byte[length];
            // Create a new instance of the RNGCryptoServiceProvider.  
            System.Security.Cryptography.RNGCryptoServiceProvider Gen = new System.Security.Cryptography.RNGCryptoServiceProvider();
            // Fill the array with a random value.  
            Gen.GetBytes(buffer);
            // Convert the byte to an uint value to make the modulus operation easier.  
            uint randomResult = 0x0;//这里用uint作为生成的随机数  
            for (int i = 0; i < length; i++)
            {
                randomResult |= ((uint)buffer[i] << ((length - 1 - i) * 8));
            }
            // Return the random number mod the number  
            // of sides. The possible values are zero-based  
            return (int)(randomResult % numSeeds);
        }
        
    }
}
