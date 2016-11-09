using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using TravelAgent.IDAL;
using TravelAgent.DALFactory;

namespace TravelAgent.BLL
{
   public class WebNav
    {
       private static readonly IWebNav WebNavDAL = DALBuild.CreateWebNav();

       /// <summary>
        /// 取得最新插入的ID
        /// </summary>
       public int GetMaxID(string FieldName)
       {
           return WebNavDAL.GetMaxID(FieldName);
       }

       /// <summary>
        /// 是否存在该记录
        /// </summary>
       public bool Exists(int Id)
       {
           return WebNavDAL.Exists(Id);
       }

       /// <summary>
        /// 返回导航名称
        /// </summary>
        /// <param name="classId"></param>
        /// <returns></returns>
       public string GetNavTitle(int classId)
       {
           return WebNavDAL.GetNavTitle(classId);
       }

        /// <summary>
        /// 增加一条数据
        /// </summary>
       public int Add(TravelAgent.Model.WebNav model)
       {
           WebNavDAL.Add(model);
           return WebNavDAL.GetMaxID("Id");
       }

       /// <summary>
        /// 更新一条数据
        /// </summary>
       public void Update(TravelAgent.Model.WebNav model)
       {
           WebNavDAL.Update(model);
       }

       /// <summary>
        /// 删除该导航及所有属下分类导航数据
        /// </summary>
       public void Delete(int Id)
       {
           WebNavDAL.Delete(Id);
       }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
       public TravelAgent.Model.WebNav GetModel(int Id)
       {
           return WebNavDAL.GetModel(Id);
       }

        /// <summary>
        /// 取得所有导航列表
        /// </summary>
        /// <param name="PId">父ID</param>
        /// <param name="KId">种类ID</param>
        /// <returns></returns>
       public DataTable GetList(int PId, int? KId)
       {
           return WebNavDAL.GetList(PId, KId);
       }

        /// <summary>
        /// 取得该导航下的所有子导航的ID
        /// </summary>
        /// <param name="classId"></param>
        /// <returns></returns>
       public DataSet GetNavListByClassId(int classId)
       {
           return WebNavDAL.GetNavListByClassId(classId);
       }

        /// <summary>
        /// 取得导航集合
        /// </summary>
        /// <param name="classId"></param>
        /// <returns></returns>
       public DataSet GetNavListByParentId(int parentId, int? top)
       {
           return WebNavDAL.GetNavListByParentId(parentId, top);
       }
    }
}
