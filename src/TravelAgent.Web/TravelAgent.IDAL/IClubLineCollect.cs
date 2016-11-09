using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
namespace TravelAgent.IDAL
{
    public interface IClubLineCollect
    {
        /// <summary>
        /// 返回长查询数据总数 （分页用到）
        /// </summary>
        int GetCount(string strWhere);
        /// <summary>
        /// 增加一条数据
        /// </summary>
         int Add(TravelAgent.Model.ClubLineCollect model);
        /// <summary>
        /// 删除数据
        /// </summary>
         int Delete(int Id);
         /// <summary>
        /// 获得查询分页数据
        /// </summary>
         DataSet GetPageList(int pageSize, int currentPage, string strWhere, string filedOrder);
    }
}
