using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgent.Tool
{
    /// <summary>
    /// sms send component | copy from tms by jjh
    /// </summary>
    public class SMSUtil
    {
        public static bool Send(string mobile, string content)
        {

            string url = ConfigurationManager.AppSettings["SMS.PostUrl"];
            string acc = ConfigurationManager.AppSettings["SMS.Account"];
            string pwd = ConfigurationManager.AppSettings["SMS.Password"];
            string parameter = "account={0}&pswd={1}&mobile={2}&msg={3}&needstatus=true&product=&extno=";

            UTF8Encoding encoding = new UTF8Encoding();
            byte[] postData = encoding.GetBytes(string.Format(parameter, acc, pwd, mobile, content));
            HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(url);
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
                string stateVal = reader.ReadToEnd();
                string[] stateArr = stateVal.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
                if (stateArr.Length <= 0) return false;
                stateArr = stateArr[0].Split(',');
                if (stateArr.Length < 2) return false;
                return stateArr[1] == "0";
            }
            else
            {
                return false;
            }
        }
    }
}
