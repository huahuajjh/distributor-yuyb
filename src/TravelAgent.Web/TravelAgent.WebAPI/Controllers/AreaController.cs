using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TravelAgent.IService;
using TravelAgent.Model;
using TravelAgent.Tool;

namespace TravelAgent.WebAPI.Controllers
{
    
    public class AreaController : ControllerBase
    {
        public HttpResponseMessage Get(int pid)
        {
            IList<Area> list = GetService<IAreaService>("AreaService").GetByParent(pid);
            return ToJsonp(list);
        }

        public HttpResponseMessage GetByPage(int index,int count)
        {
            int total = 0;
            IList<Area> list = GetService<IAreaService>("AreaService").GetByPage(index,count,out total);
            return ToJsonp(list,total:total);

        }
    }
}
