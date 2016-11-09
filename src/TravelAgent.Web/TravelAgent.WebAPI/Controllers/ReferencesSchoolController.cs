using eh.impls;
using eh.impls.configurations;
using eh.impls.errs;
using eh.interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;
using TravelAgent.IService;
using TravelAgent.Model;
using TravelAgent.WebAPI.Models;

namespace TravelAgent.WebAPI.Controllers
{
    public class ReferencesSchoolController:ControllerBase
    {
        public IReferencesSchoolService Service
        {
            get
            {
                return GetService<IReferencesSchoolService>("ReferencesSchoolService");
            }
            set
            { }
        }

        [HttpGet]
        public HttpResponseMessage GetByFuzzy()
        { 
            string fuzzy = HttpContext.Current.Request.QueryString["fuzzy"];
            return  ToJsonp(Service.GetByFuzzyName(fuzzy));
        }

        [HttpGet]
        public HttpResponseMessage GetBySchId(int sid)
        { 
            return ToJsonp(Service.GetBySchoolId(sid));
        }

        [HttpGet]
        public HttpResponseMessage GetByPage(int sid,int index,int count)
        { 
            int total = 0;
            return ToJsonp(Service.GetBySchoolId(sid, index, count, out total),total:total);
        }
    
        [HttpGet]
        public HttpResponseMessage Download()
        {
            IList<ReferencesSchool> list = Service.GetAll();
            IList<RefsFileDto> dtos = RefsFileDto.ToDtos(list);
            
            ErrMsg msg = new ErrMsg();
            ExcelConfiguration cfg = new ExcelConfiguration();
            cfg.TemplatePath = ConfigurationManager.AppSettings["refsDataPath"];
            cfg.TemplateRowIndex = 1;
            IExport export = ExcelFactory.Instance().GetExcelExporter(cfg, msg);
            byte[] data = export.Export<RefsFileDto>(dtos);
            MemoryStream ms = new MemoryStream(data);
            HttpResponseMessage res = new HttpResponseMessage(HttpStatusCode.OK);
            res.Content = new StreamContent(ms);
            res.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
            res.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment") { FileName = "refs_file.xlsx" };
            return res;
        }


    }
}