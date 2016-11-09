using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
namespace TravelAgent.IDAL
{
    public interface IClubPoints
    {
        /// <summary>
        /// 取得最新插入的ID
        /// </summary>
        int GetMaxID(string FieldName);
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(int Id);
        /// <summary>
        /// 返回长查询数据总数 （分页用到）
        /// </summary>
        int GetCount(string strWhere);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        void Add(TravelAgent.Model.ClubPoints model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        void Delete(int Id);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        TravelAgent.Model.ClubPoints GetModel(int Id);
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        DataSet GetList(int Top, string strWhere, string filedOrder);
        /// <summary>
        /// 获得查询分页数据
        /// </summary>
        DataSet GetPageList(int pageSize, int currentPage, string strWhere, string filedOrder);
    }
}
