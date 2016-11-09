using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using TravelAgent.IDAL;
using TravelAgent.DALFactory;

namespace TravelAgent.BLL
{
    public class VisaCountry
    {
        private static readonly IVisaCountry VCDAL = DALBuild.CreateVisaCountry();

        /// <summary>
        /// 取得最新插入的ID
        /// </summary>
        public int GetMaxID(string FieldName)
        {
            return VCDAL.GetMaxID(FieldName);
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int Id)
        {
            return VCDAL.Exists(Id);
        }

        /// <summary>
        /// 返回名称
        /// </summary>
        /// <param name="classId"></param>
        /// <returns></returns>
        public string GetTitle(int classId)
        {
            return VCDAL.GetTitle(classId);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(TravelAgent.Model.VisaCountry model)
        {
            VCDAL.Add(model);
            return VCDAL.GetMaxID("Id");
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(TravelAgent.Model.VisaCountry model)
        {
            VCDAL.Update(model);
        }

        /// <summary>
        /// 删除所有属下分类数据
        /// </summary>
        public void Delete(int Id)
        {
            VCDAL.Delete(Id);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public TravelAgent.Model.VisaCountry GetModel(int Id)
        {
            return VCDAL.GetModel(Id);
        }

        /// <summary>
        /// 取得所有列表
        /// </summary>
        /// <param name="PId">父ID</param>
        /// <param name="KId">种类ID</param>
        /// <returns></returns>
        public DataTable GetList(int PId, string strWhere)
        {
            return VCDAL.GetList(PId,strWhere);
        }

        /// <summary>
        /// 取得该分类下所有集合
        /// </summary>
        /// <param name="classId"></param>
        /// <returns></returns>
        public DataSet GetListByClassId(int classId)
        {
            return VCDAL.GetListByClassId(classId);
        }

        /// <summary>
        /// 取得集合
        /// </summary>
        /// <param name="classId"></param>
        /// <returns></returns>
        public DataSet GetListByParentId(int parentId, int? top)
        {
            return VCDAL.GetListByParentId(parentId, top);
        }
    }
}
