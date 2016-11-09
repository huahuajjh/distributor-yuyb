using System;
using System.IO;
using System.Text;
using System.Web;

namespace TravelAgent.WeiPay
{

    /**
    * 
    * ���ã����ڵ���΢��֧����ʱ��дtxt��־
    * ���ߣ��ٳ����  QQ:89708707
    * ��д���ڣ�2014-12-25
    * ��ע��������Ŀ¼��д��Ȩ��
    * 
    * */
    public class LogUtil
    {
        private static readonly object writeFile = new object();
        
        /// <summary>
        /// �ڱ���д�������־
        /// </summary>
        /// <param name="exception"></param> 
        public static void WriteLog(string debugstr)
        {
            lock (writeFile)
            {
                FileStream fs = null;
                StreamWriter sw = null;

                try
                {
                    string filename = DateTime.Now.ToString("yyyy-MM-dd") + ".txt";
                    //����������־Ŀ¼
                    string folder = HttpContext.Current.Server.MapPath("~/log");
                    if (!Directory.Exists(folder))
                        Directory.CreateDirectory(folder);
                    fs = new FileStream(folder + "/" + filename, System.IO.FileMode.Append, System.IO.FileAccess.Write);
                    sw = new StreamWriter(fs, Encoding.UTF8);
                    sw.WriteLine( DateTime.Now.ToString() + "     " + debugstr + "\r\n");
                }
                finally
                {
                    if (sw != null)
                    {
                        sw.Flush();
                        sw.Dispose();
                        sw = null;
                    }
                    if (fs != null)
                    {
                        //     fs.Flush();
                        fs.Dispose();
                        fs = null;
                    }
                }
            }
        }

    }
}