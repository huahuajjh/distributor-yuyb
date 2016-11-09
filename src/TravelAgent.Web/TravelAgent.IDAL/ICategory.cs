using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace TravelAgent.IDAL
{
    public interface ICategory
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
        /// 返回目的地名称
        /// </summary>
        /// <param name="classId"></param>
        /// <returns></returns>
        string GetChannelTitle(int classId);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        void Add(TravelAgent.Model.Category model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        void Update(TravelAgent.Model.Category model);
        /// <summary>
        /// 删除该新闻分类及所有属下分类数据
        /// </summary>
        void Delete(int Id);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        TravelAgent.Model.Category GetModel(int Id);
        /// <summary>
        /// 取得所有新闻分类列表
        /// </summary>
        /// <param name="PId">父ID</param>
        /// <param name="KId">种类ID</param>
        /// <returns></returns>
        DataTable GetList(int PId, int? KId);
        /// <summary>
        /// 取得该新闻分类下的所有子分类的ID
        /// </summary>
        /// <param name="classId"></param>
        /// <returns></returns>
        DataSet GetChannelListByClassId(int classId);
        /// <summary>
        /// 取得新闻分类集合
        /// </summary>
        /// <param name="classId"></param>
        /// <returns></returns>
        DataSet GetChannelListByParentId(int parentId, int? top);
    }
}
