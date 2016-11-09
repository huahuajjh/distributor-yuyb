using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgent.Model;

namespace TravelAgent.IDAL
{
    public interface IReferencesSchoolDao
    {
        /// <summary>
        /// 模糊查询推荐人信息，包含推荐人所属学校信息
        /// </summary>
        /// <param name="fuzzy">学校名称或者推荐人名字模糊字符串</param>
        /// <returns>ReferencesSchool</returns>
        IList<ReferencesSchool> GetByFuzzyName(string fuzzy);

        /// <summary>
        /// 根据学校id查询推荐人信息
        /// </summary>
        /// <param name="schId">学校id</param>
        /// <returns>ReferencesSchool</returns>
        IList<ReferencesSchool> GetBySchoolId(int schId);

        /// <summary>
        /// 根据学校id查询推荐人信息，分页获取
        /// </summary>
        /// <param name="schId">学校id</param>
        /// <param name="index">起始页，从1开始</param>
        /// <param name="count">每页显示数量</param>
        /// <param name="total">总记录数</param>
        /// <returns>ReferencesSchool</returns>
        IList<ReferencesSchool> GetBySchoolId(int schId,int index,int count,out int total);

        IList<ReferencesSchool> GetAll();

    }
}
