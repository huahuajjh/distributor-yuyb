using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using TravelAgent.IDAL;
using TravelAgent.DALFactory;

namespace TravelAgent.BLL
{
    public class ClubLineCollect
    {
        private static readonly IClubLineCollect dal = DALBuild.CreateLineCollect();
        /// <summary>
        /// 返回长查询数据总数 （分页用到）
        /// </summary>
        public int GetCount(string strWhere)
        {
            return dal.GetCount(strWhere);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(TravelAgent.Model.ClubLineCollect model)
        {
            return dal.Add(model);
        }
        /// <summary>
        /// 删除数据
        /// </summary>
        public int Delete(int Id)
        {
            return dal.Delete(Id);
        }
        /// <summary>
        /// 获得查询分页数据
        /// </summary>
        public DataSet GetPageList(int pageSize, int currentPage, string strWhere, string filedOrder)
        {
            return dal.GetPageList(pageSize,currentPage,strWhere,filedOrder);
        }
    }
}
