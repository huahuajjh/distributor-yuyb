using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TravelAgent.WebAPI.Models
{
    public class JsonFormat
    {
        //0-失败 1-成功 2-异常 3-无权访问
        public int Code { get; set; }
        public int TotalCount { get; set; }
        public object Data { get; set; }
        public string Msg { get; set; }

    }
}