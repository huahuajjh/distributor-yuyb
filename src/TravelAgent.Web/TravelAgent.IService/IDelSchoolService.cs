using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgent.IService
{
    /// <summary>
    /// 删除学校数据服务，这是一个技术性业务删除，学校数据与推荐人数据有关联，删除学校数据，必须先删除关联的推荐人数据
    /// </summary>
    public interface IDelSchoolService
    {

        /// <summary>
        /// 删除学校数据服务，这是一个技术性业务删除，学校数据与推荐人数据有关联，删除学校数据，必须先删除关联的推荐人数据
        /// </summary>
        /// <param name="id"></param>
        void Del(int id);

        /// <summary>
        /// 删除学校数据服务，这是一个技术性业务删除，学校数据与推荐人数据有关联，删除学校数据，必须先删除关联的推荐人数据
        /// </summary>
        /// <param name="ids"></param>
        void Del(int[] ids);
    }
}
