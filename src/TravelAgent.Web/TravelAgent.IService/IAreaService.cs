using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgent.Model;

namespace TravelAgent.IService
{
    public interface IAreaService
    {
        IList<Area> GetByParent(int pid);
        IList<Area> GetByPage(int index,int count,out int total);
    }
}
