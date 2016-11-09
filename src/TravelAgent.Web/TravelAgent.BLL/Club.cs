using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using TravelAgent.IDAL;
using TravelAgent.DALFactory;

namespace TravelAgent.BLL
{
    public class Club
    {
        private static readonly IClub dal = DALBuild.CreateClub();
        #region  成员方法
        /// <summary>
        /// 取得最新插入的ID
        /// </summary>
        public int GetMaxID(string FieldName)
        {
            return dal.GetMaxID(FieldName);
        }
        /// <summary>
        /// 返回长查询数据总数
        /// </summary>
        /// <param name="strWhere">条件</param>
        /// <returns></returns>
        public int GetCount(string strWhere)
        {
            return dal.GetCount(strWhere);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(TravelAgent.Model.Club model)
        {
            int clubid = 0;
            if (dal.Add(model) > 0)
            {
                clubid = dal.GetMaxID("Id");
            }
            return clubid;
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(TravelAgent.Model.Club model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(int Id)
        {
            return dal.Delete(Id);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public TravelAgent.Model.Club GetModel(int Id)
        {
            return dal.GetModel(Id);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public TravelAgent.Model.Club GetModel(string strName, string strPwd)
        {
            return dal.GetModel(strName, strPwd);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得查询分页数据
        /// </summary>
        public DataSet GetPageList(int pageSize, int currentPage, string strWhere, string filedOrder)
        {
            return dal.GetPageList(pageSize, currentPage, strWhere, filedOrder);
        }

        #endregion  成员方法
    }
}
