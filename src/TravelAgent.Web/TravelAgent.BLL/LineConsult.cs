using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using TravelAgent.IDAL;
using TravelAgent.DALFactory;

namespace TravelAgent.BLL
{
    public class LineConsult
    {
        private static readonly ILineConsult DAL = DALBuild.CreateLineConsult();

        /// <summary>
        /// 取得最新插入的ID
        /// </summary>
        public int GetMaxID(string FieldName)
        {
            return DAL.GetMaxID(FieldName);
        }
         /// <summary>
        /// 返回长查询数据总数 （分页用到）
        /// </summary>
        public int GetCount(string strWhere)
        {
            return DAL.GetCount(strWhere);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(TravelAgent.Model.LineConsult model)
        {
            DAL.Add(model);
            return DAL.GetMaxID("Id");
        }
        /// <summary>
        /// 删除数据
        /// </summary>
        public int Delete(int Id)
        {
            return DAL.Delete(Id);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public TravelAgent.Model.LineConsult GetModel(int Id)
        {
            return DAL.GetModel(Id);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList()
        {
            return DAL.GetList();
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return DAL.GetList(strWhere);
        }
        /// <summary>
        /// 获得查询分页数据
        /// </summary>
        public DataSet GetPageList(int pageSize, int currentPage, string strWhere, string filedOrder)
        {
            return DAL.GetPageList(pageSize, currentPage, strWhere, filedOrder);
        }
    }
}
