using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using TravelAgent.IDAL;
using TravelAgent.DALFactory;
namespace TravelAgent.BLL
{
    public class Destination
    {
        private static readonly IDestination DestDAL = DALBuild.CreateDestination();

        /// <summary>
        /// 取得最新插入的ID
        /// </summary>
        public int GetMaxID(string FieldName)
        {
            return DestDAL.GetMaxID(FieldName);
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int Id)
        {
            return DestDAL.Exists(Id);
        }

        /// <summary>
        /// 返回目的地名称
        /// </summary>
        /// <param name="classId"></param>
        /// <returns></returns>
        public string GetDestTitle(int classId)
        {
            return DestDAL.GetDestTitle(classId);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(TravelAgent.Model.Destination model)
        {
            DestDAL.Add(model);
            return DestDAL.GetMaxID("Id");
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(TravelAgent.Model.Destination model)
        {
            DestDAL.Update(model);
        }

        /// <summary>
        /// 删除该目的地及所有属下分类数据
        /// </summary>
        public void Delete(int Id)
        {
            DestDAL.Delete(Id);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public TravelAgent.Model.Destination GetModel(int Id)
        {
            return DestDAL.GetModel(Id);
        }

        /// <summary>
        /// 取得所有目的地列表
        /// </summary>
        /// <param name="PId">父ID</param>
        /// <param name="KId">种类ID</param>
        /// <returns></returns>
        public DataTable GetList(int PId, int? KId)
        {
            return DestDAL.GetList(PId, KId);
        }

        /// <summary>
        /// 取得该目的地下的所有子目的地的ID
        /// </summary>
        /// <param name="classId"></param>
        /// <returns></returns>
        public DataSet GetDestListByClassId(int classId)
        {
            return DestDAL.GetDestListByClassId(classId);
        }

        /// <summary>
        /// 取得目的地集合
        /// </summary>
        /// <param name="classId"></param>
        /// <returns></returns>
        public DataSet GetDestListByParentId(int parentId, int? top)
        {
            return DestDAL.GetDestListByParentId(parentId, top);
        }
         /// <summary>
        /// 通过层级获得集合
        /// </summary>
        /// <param name="layer"></param>
        /// <returns></returns>
        public DataSet GetDestListByLayer(int layer)
        {
            return DestDAL.GetDestListByLayer(layer);
        }
        /// <summary>
        /// 通过层级获得集合
        /// </summary>
        /// <param name="layer"></param>
        /// <returns></returns>
        public DataSet GetDestListByLayer(int layer, string strWhere)
        {
            return DestDAL.GetDestListByLayer(layer, strWhere);
        }
    }
}
