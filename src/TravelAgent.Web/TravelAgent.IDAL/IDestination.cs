using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace TravelAgent.IDAL
{
    public interface IDestination
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
        string GetDestTitle(int classId);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        void Add(TravelAgent.Model.Destination model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        void Update(TravelAgent.Model.Destination model);
        /// <summary>
        /// 删除该目的地及所有属下分类数据
        /// </summary>
        void Delete(int Id);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        TravelAgent.Model.Destination GetModel(int Id);
        /// <summary>
        /// 取得所有目的地列表
        /// </summary>
        /// <param name="PId">父ID</param>
        /// <param name="KId">种类ID</param>
        /// <returns></returns>
        DataTable GetList(int PId, int? KId);
        /// <summary>
        /// 取得该目的地下的所有子目的地的ID
        /// </summary>
        /// <param name="classId"></param>
        /// <returns></returns>
        DataSet GetDestListByClassId(int classId);
        /// <summary>
        /// 取得目的地集合
        /// </summary>
        /// <param name="classId"></param>
        /// <returns></returns>
        DataSet GetDestListByParentId(int parentId, int? top);
         /// <summary>
        /// 通过层级获得集合
        /// </summary>
        /// <param name="layer"></param>
        /// <returns></returns>
        DataSet GetDestListByLayer(int layer);
        /// <summary>
        /// 通过层级获得集合
        /// </summary>
        /// <param name="layer"></param>
        /// <returns></returns>
        DataSet GetDestListByLayer(int layer, string strWhere);
    }
}
