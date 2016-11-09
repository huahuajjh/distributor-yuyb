using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace TravelAgent.IDAL
{
    public interface ILineConsult
    {
        /// <summary>
        /// 取得最新插入的ID
        /// </summary>
        int GetMaxID(string FieldName);
         /// <summary>
        /// 返回长查询数据总数 （分页用到）
        /// </summary>
        int GetCount(string strWhere);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        void Add(TravelAgent.Model.LineConsult model);
        /// <summary>
        /// 删除数据
        /// </summary>
        int Delete(int Id);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        TravelAgent.Model.LineConsult GetModel(int Id);
        /// <summary>
        /// 获得数据列表
        /// </summary>
        DataSet GetList();
        /// <summary>
        /// 获得数据列表
        /// </summary>
        DataSet GetList(string strWhere);
        /// <summary>
        /// 获得查询分页数据
        /// </summary>
        DataSet GetPageList(int pageSize, int currentPage, string strWhere, string filedOrder);
    }
}
