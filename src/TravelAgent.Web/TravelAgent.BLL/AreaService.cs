using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgent.IDAL;
using TravelAgent.IService;
using TravelAgent.Model;

namespace TravelAgent.BLL
{
    public class AreaService:ServiceBase<IAreaDao>,IAreaService
    {
        public IList<Area> GetByParent(int pid)
        {
            IAreaDao dao = GetDao("AreaDao");
            return dao.Get("Pid="+pid+" and Show=1");
        }
        public IList<Area> GetByPage(int index, int count, out int total)
        {
            IAreaDao dao = GetDao("AreaDao");
            return dao.Get(" Show=1 ",index,count,out total);
        }
    }
}
