using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using TravelAgent.IDAL;
using TravelAgent.DALFactory;

namespace TravelAgent.BLL
{
    public class Line
    {
        private static readonly ILineSpePrice pricedal = DALBuild.CreateLineSpePrice();
        private static readonly ILineContent contentdal = DALBuild.CreateLineContent();
        private static readonly ILine dal = DALBuild.CreateLine();
        /// <summary>
        /// 返回长查询数据总数 （分页用到）
        /// </summary>
        public int GetCount(string strWhere)
        {
            return dal.GetCount(strWhere);
        }
        /// <summary>
        /// 删除数据
        /// </summary>
        public void Delete(int id)
        {
            pricedal.Delete(id);
            contentdal.Delete(id);
            dal.Delete(id);
        }
         /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(TravelAgent.Model.Line model)
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
        /// 修改数据
        /// </summary>
        /// <param name="strsql"></param>
        /// <returns></returns>
        public void Update(ArrayList strsqllist)
        {
            dal.Update(strsqllist);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public TravelAgent.Model.Line GetModel(int Id)
        {
            return dal.GetModel(Id);
        }
        /// <summary>
        /// 获得前几行数据
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
    }
}
