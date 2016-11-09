using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web;
using System.Web.Http;
using TravelAgent.DALFactory;
using TravelAgent.Tool;
using TravelAgent.WebAPI.Models;

namespace TravelAgent.WebAPI.Controllers
{
    public abstract class ControllerBase : ApiController
    {
        protected T GetService<T>(string class_name)
        {
            return DALBuild.GetObj<T>("BLL",class_name);
        }

        protected HttpResponseMessage ToJson(object o,int status_code=1,string msg="success",int total=0)
        {               
            JsonFormat jf = new JsonFormat(){ Code=status_code, Data=o, Msg=msg, TotalCount=total};
            string json = JsonUtil.ToJson(jf);
            HttpResponseMessage res = new HttpResponseMessage{ Content=new StringContent(json,Encoding.GetEncoding("UTF-8"),"application/json")};
            return res;
        }

        protected HttpResponseMessage DownloadFile(string filename)
        { 
            HttpResponseMessage res = new HttpResponseMessage(HttpStatusCode.OK);
            using (FileStream fs = new FileStream(filename,FileMode.Open))
            {
                res.Content = new StreamContent(fs);
                res.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment"){ FileName="school.xls"};
                res.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                res.Content.Headers.ContentLength = new FileInfo(filename).Length;
                return res;
            }
        }

        protected HttpResponseMessage ToJsonp(object o, int status_code = 1, string msg = "success", int total = 0)
        {
            string callback =  HttpContext.Current.Request.QueryString["callback"];

            if(!string.IsNullOrEmpty(callback))
            {
                JsonFormat jf = new JsonFormat() { Code = status_code, Data = o, Msg = msg, TotalCount = total };
                string json = JsonUtil.ToJson(jf);
                string script = callback+"("+json+")";
                HttpResponseMessage res = new HttpResponseMessage { Content = new StringContent(script, Encoding.GetEncoding("UTF-8"), "application/json") };
                return res;
            }
            else 
            { 
                return new HttpResponseMessage { Content = new StringContent("not jsonp", Encoding.GetEncoding("UTF-8"), "application/json") };;
            }
        }

    }
}