using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace TravelAgent.IDAL
{
    public interface IAdbanner
    {
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
        void Add(TravelAgent.Model.Adbanner model);
        /// <summary>
		/// 更新一条数据
		/// </summary>
        void Update(TravelAgent.Model.Adbanner model);
        /// <summary>
		/// 删除一条数据
		/// </summary>
        void Delete(int Id);
         /// <summary>
        /// 删除一条数据
        /// </summary>
        void DeleteByAID(int Aid);
        /// <summary>
		/// 得到一个对象实体
		/// </summary>
        TravelAgent.Model.Adbanner GetModel(int Id);
        /// <summary>
		/// 获得数据列表
		/// </summary>
        DataSet GetList(string strWhere);
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        DataSet GetList(int Top, string strWhere, string filedOrder);
    }
}
