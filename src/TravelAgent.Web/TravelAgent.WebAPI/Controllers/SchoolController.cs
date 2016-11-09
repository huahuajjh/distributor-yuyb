using eh.impls;
using eh.impls.configurations;
using eh.impls.errs;
using eh.interfaces;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using TravelAgent.IService;
using TravelAgent.Model;
using TravelAgent.Tool;
using TravelAgent.WebAPI.Models;

namespace TravelAgent.WebAPI.Controllers
{
    public class SchoolController : ControllerBase
    {
        private ISchoolService Service 
        {
            get 
            {
                return GetService<ISchoolService>("SchoolService");
            }
            set 
            {
                
             }
        }
        public HttpResponseMessage Get(int area_id)
        { 
            return ToJsonp(Service.GetByAreaId(area_id));
        }

        public HttpResponseMessage GetByPage(int index,int count)
        { 
            int total = 0;
            IList<School> list = Service.GetByPage(index,count,out total);
            return ToJsonp(list,total:total);
        }

        [HttpGet]
        public HttpResponseMessage Add(string school)
        {
            School s = JsonUtil.ToObj<School>(school);
            try
            {
                Service.Add(s);
                return ToJsonp("success");
            }
            catch (System.Exception ex)
            {
                return ToJsonp(ex.Message, status_code: 0, msg: ex.Message);
            }
        }

        [HttpPost]
        public HttpResponseMessage Upload()
        {
            HttpPostedFile file = HttpContext.Current.Request.Files["school"];

            ErrMsg msg = new ErrMsg();
            IImport import = ExcelFactory.Instance().GetExcelImporter(new eh.impls.configurations.ExcelConfiguration(1, 0, 0), msg);
            IList<School> list = SchoolDto.ToList(import.Import<SchoolDto>(file.InputStream));
            
            if(msg.Count!=0)
            {
                return ToJson(msg.GetErrors(), status_code: 0, msg: "fail");
            }
            else
            {
                try
                {
                    Service.Add(list);
                    return ToJson("success");
                }
                catch (SqlException ex)
                {
                    msg.AddErrMsg(ex.Message);
                    return ToJson(msg.GetErrors(), status_code: 0, msg: "fail");
                }
            }
        }

        [HttpGet]
        public HttpResponseMessage Update()
        {
            string school = HttpContext.Current.Request.QueryString["school"];
            try
            {
                School s = JsonUtil.ToObj<School>(school);
                Service.Update(s);
                return ToJsonp("success");
            }
            catch (System.Exception ex)
            {
                return ToJsonp(ex.Message, status_code: 0, msg: ex.Message);
            }
        }

        public HttpResponseMessage GetById(int id)
        {
            return ToJsonp(Service.GetById(id));
        }

        public HttpResponseMessage GetByFuzzyName(string name)
        {
            return ToJsonp(Service.GetByFuzzyName(name));
        }

        [HttpGet]
        public HttpResponseMessage DownSchoolCodeFile()
        { 
            IList<School> list = Service.GetSchoolCode();
            IList<SchoolCodeFileDto> dto_list = SchoolCodeFileDto.ToList(list);

            ErrMsg msg = new ErrMsg();
            ExcelConfiguration cfg = new ExcelConfiguration();
            cfg.TemplatePath = ConfigurationManager.AppSettings["schoolDataPath"];
            cfg.TemplateRowIndex = 1;
            IExport export = ExcelFactory.Instance().GetExcelExporter(cfg, msg);
            byte[] data = export.Export<SchoolCodeFileDto>(dto_list);
            MemoryStream ms = new MemoryStream(data);
            HttpResponseMessage res = new HttpResponseMessage(HttpStatusCode.OK);
            res.Content = new StreamContent(ms);
            res.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
            res.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment") { FileName="school_codefile.xlsx" };
            return res;
        }

        [HttpGet]
        public HttpResponseMessage Del(int id)
        { 
            Service.Del(id);
            return ToJsonp("success");
        }

        [HttpGet]
        public HttpResponseMessage DelRange()
        {
            string ids = HttpContext.Current.Request.QueryString["ids"];
            if (!string.IsNullOrWhiteSpace(ids))
            {
                string[] temp = ids.Split(',');
                int[] temp2 = new int[temp.Length];
                for (int i = 0; i < temp.Length; i++)
                {
                    temp2[i] = int.Parse(temp[i]);
                }
                Service.Del(temp2);
            }
            return ToJsonp("success");
        }

    }
    
}
