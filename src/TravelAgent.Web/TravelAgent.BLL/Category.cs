using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using TravelAgent.IDAL;
using TravelAgent.DALFactory;

namespace TravelAgent.BLL
{
    public  class Category
    {
        private static readonly ICategory CategoryDAL = DALBuild.CreateCategory();

        /// <summary>
        /// 取得最新插入的ID
        /// </summary>
        public int GetMaxID(string FieldName)
        {
            return CategoryDAL.GetMaxID(FieldName);
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int Id)
        {
            return CategoryDAL.Exists(Id);
        }

        /// <summary>
        /// 返回目的地名称
        /// </summary>
        /// <param name="classId"></param>
        /// <returns></returns>
        public string GetDestTitle(int classId)
        {
            return CategoryDAL.GetChannelTitle(classId);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(TravelAgent.Model.Category model)
        {
            CategoryDAL.Add(model);
            return CategoryDAL.GetMaxID("Id");
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(TravelAgent.Model.Category model)
        {
            CategoryDAL.Update(model);
        }

        /// <summary>
        /// 删除该新闻分类及所有属下分类数据
        /// </summary>
        public void Delete(int Id)
        {
            CategoryDAL.Delete(Id);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public TravelAgent.Model.Category GetModel(int Id)
        {
            return CategoryDAL.GetModel(Id);
        }

        /// <summary>
        /// 取得所有新闻分类列表
        /// </summary>
        /// <param name="PId">父ID</param>
        /// <param name="KId">种类ID</param>
        /// <returns></returns>
        public DataTable GetList(int PId, int? KId)
        {
            return CategoryDAL.GetList(PId, KId);
        }

        /// <summary>
        /// 取得该新闻分类下的所有子分类的ID
        /// </summary>
        /// <param name="classId"></param>
        /// <returns></returns>
        public DataSet GetChannelListByClassId(int classId)
        {
            return CategoryDAL.GetChannelListByClassId(classId);
        }

        /// <summary>
        /// 取得新闻分类集合
        /// </summary>
        /// <param name="classId"></param>
        /// <returns></returns>
        public DataSet GetChannelListByParentId(int parentId, int? top)
        {
            return CategoryDAL.GetChannelListByParentId(parentId, top);
        }
    }
}
