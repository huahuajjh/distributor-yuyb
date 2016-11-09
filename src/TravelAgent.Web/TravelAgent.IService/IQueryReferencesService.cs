using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgent.Model;

namespace TravelAgent.IService
{
    /// <summary>
    /// 查询推荐人接口，涉及两个领域实体，将该业务设定为服务
    /// </summary>
    public  interface IQueryReferencesService
    {
        IList<References> GetRefsBySchoolName(string school_name);
    }
}
