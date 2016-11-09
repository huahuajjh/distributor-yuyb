using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace TravelAgent.IDAL
{
    public interface IWebNav
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
        /// 返回导航名称
        /// </summary>
        /// <param name="classId"></param>
        /// <returns></returns>
        string GetNavTitle(int classId);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        void Add(TravelAgent.Model.WebNav model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        void Update(TravelAgent.Model.WebNav model);
         /// <summary>
        /// 删除该导航及所有属下分类导航数据
        /// </summary>
        void Delete(int Id);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        TravelAgent.Model.WebNav GetModel(int Id);
        /// <summary>
        /// 取得所有导航列表
        /// </summary>
        /// <param name="PId">父ID</param>
        /// <param name="KId">种类ID</param>
        /// <returns></returns>
        DataTable GetList(int PId, int? KId);
        /// <summary>
        /// 取得该导航下的所有子导航的ID
        /// </summary>
        /// <param name="classId"></param>
        /// <returns></returns>
        DataSet GetNavListByClassId(int classId);
        /// <summary>
        /// 取得导航集合
        /// </summary>
        /// <param name="classId"></param>
        /// <returns></returns>
        DataSet GetNavListByParentId(int parentId, int? top);

    }
}
