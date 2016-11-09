using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace TravelAgent.IDAL
{
    public interface IVisaCountry
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
        /// 返回名称
        /// </summary>
        /// <param name="classId"></param>
        /// <returns></returns>
        string GetTitle(int classId);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        void Add(TravelAgent.Model.VisaCountry model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        void Update(TravelAgent.Model.VisaCountry model);
        /// <summary>
        /// 删除该所有属下分类数据
        /// </summary>
        void Delete(int Id);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        TravelAgent.Model.VisaCountry GetModel(int Id);
        /// <summary>
        /// 取得所有列表
        /// </summary>
        /// <param name="PId">父ID</param>
        /// <param name="KId">种类ID</param>
        /// <returns></returns>
        DataTable GetList(int PId, string strWhere);
        /// <summary>
        /// 取得该分类下所有集合
        /// </summary>
        /// <param name="classId"></param>
        /// <returns></returns>
        DataSet GetListByClassId(int classId);
        /// <summary>
        /// 取得集合
        /// </summary>
        /// <param name="classId"></param>
        /// <returns></returns>
        DataSet GetListByParentId(int parentId, int? top);
    }
}
