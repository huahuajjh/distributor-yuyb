using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace TravelAgent.IDAL
{
    public interface ICarPrice
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
        /// 删除数据
        /// </summary>
        int Delete(int id);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(TravelAgent.Model.CarPrice model);
        /// <summary>
        /// 修改数据
        /// </summary>
        /// <param name="strsql"></param>
        /// <returns></returns>
        int Update(string strsql);
        /// <summary>
        /// 修改数据
        /// </summary>
        /// <param name="strsql"></param>
        /// <returns></returns>
        void Update(ArrayList strsqllist);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        int Update(TravelAgent.Model.CarPrice model);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        TravelAgent.Model.CarPrice GetModel(int Id);
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
