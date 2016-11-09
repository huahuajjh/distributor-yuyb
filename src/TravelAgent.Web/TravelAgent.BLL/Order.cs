using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using TravelAgent.IDAL;
using TravelAgent.DALFactory;

namespace TravelAgent.BLL
{
    public class Order
    {
        private static readonly IOrder dal = DALBuild.CreateLineOrder();
        /// <summary>
        /// 返回长查询数据总数 （分页用到）
        /// </summary>
        public int GetCount(string strWhere)
        {
            return dal.GetCount(strWhere);
        }
        /// <summary>
        /// 返回长查询数据总数 （分页用到）
        /// </summary>
        public int GetCount2(string strWhere)
        {
            return dal.GetCount2(strWhere);
        }
         /// <summary>
        /// 返回长查询数据总数 （分页用到）
        /// </summary>
        public int GetLineOrderCount(string strWhere)
        {
            return dal.GetLineOrderCount(strWhere);
        }
         /// <summary>
        /// 返回长查询数据总数 （分页用到）
        /// </summary>
        public int GetVisaOrderCount(string strWhere)
        {
            return dal.GetVisaOrderCount(strWhere);
        }
          /// <summary>
        /// 返回长查询数据总数 （分页用到）
        /// </summary>
        public int GetCarOrderCount(string strWhere)
        {
            return dal.GetCarOrderCount(strWhere);
        }
        /// <summary>
        /// 删除数据
        /// </summary>
        public int Delete(int id)
        {
            return dal.Delete(id);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(TravelAgent.Model.Order model)
        {
            int lineid = 0;
            if (dal.Add(model) > 0)
            {
                lineid = dal.GetMaxID("Id");
            }
            return lineid;
        }
        /// <summary>
        /// 修改数据
        /// </summary>
        /// <param name="strsql"></param>
        /// <returns></returns>
        public int Update(string strsql)
        {
            return dal.Update(strsql);
        }
        /// <summary>
        /// 得到线路一个对象实体
        /// </summary>
        public TravelAgent.Model.Order GetModel(int Id)
        {
            return dal.GetModel(Id);
        }
         /// <summary>
        /// 得到签证一个对象实体
        /// </summary>
        public TravelAgent.Model.Order GetModel2(int Id)
        {
            return dal.GetModel2(Id);
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList0(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList0(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得签证前几行数据
        /// </summary>
        public DataSet GetList2(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList2(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得查询分页数据
        /// </summary>
        public DataSet GetPageList(int pageSize, int currentPage, string strWhere, string filedOrder)
        {
            return dal.GetPageList(pageSize, currentPage, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得线路查询分页数据
        /// </summary>
        public DataSet GetPageList2(int pageSize, int currentPage, string strWhere, string filedOrder)
        {
            return dal.GetPageList2(pageSize, currentPage, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得签证查询分页数据
        /// </summary>
        public DataSet GetPageList3(int pageSize, int currentPage, string strWhere, string filedOrder)
        {
            return dal.GetPageList3(pageSize, currentPage, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得线路查询分页数据
        /// </summary>
        public DataSet GetPageList4(int pageSize, int currentPage, string strWhere, string filedOrder)
        {
            return dal.GetPageList4(pageSize, currentPage, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得线路前几行数据
        /// </summary>
        public DataSet GetCarList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetCarList(Top,strWhere,filedOrder);
        }
         /// <summary>
        /// 通过订单编号获得实体
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public TravelAgent.Model.Order GetModelByCode(string code)
        {
            return dal.GetModelByCode(code);
        }
         /// <summary>
        /// 通过订单编号获得实体
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public TravelAgent.Model.Order GetModelByCode1(string code)
        {
            return dal.GetModelByCode1(code); 
        }
    }
}
