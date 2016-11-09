using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
namespace TravelAgent.IDAL
{
    public interface IArticle
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
        void Add(TravelAgent.Model.Article model);
         /// <summary>
        /// 修改一条数据
        /// </summary>
        void UpdateField(int Id, string strValue);
        /// <summary>
		/// 更新一条数据
		/// </summary>
        void Update(TravelAgent.Model.Article model);
        /// <summary>
		/// 删除一条数据
		/// </summary>
        void Delete(int Id);
        /// <summary>
		/// 得到一个对象实体
		/// </summary>
        TravelAgent.Model.Article GetModel(int Id);
         /// <summary>
        /// 获得上一条记录
        /// </summary>
        /// <param name="curId"></param>
        /// <returns></returns>
        TravelAgent.Model.Article GetSpeModel(int curId, string type, int classid);
        /// <summary>
		/// 获得前几行数据
		/// </summary>
        DataSet GetList(int Top, string strWhere, string filedOrder);
         /// <summary>
        /// 获得指定的类别下所有文章
        /// </summary>
        DataSet GetList(int classId, int kindId, int Top, string strWhere, string filedOrder);
        /// <summary>
        /// 获得查询分页数据
        /// </summary>
        DataSet GetPageList(int pageSize, int currentPage, string strWhere, string filedOrder);
    }
}
