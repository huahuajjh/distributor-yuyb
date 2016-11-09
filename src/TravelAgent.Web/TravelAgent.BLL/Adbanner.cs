using System;
using System.Data;
using TravelAgent.DALFactory;
namespace TravelAgent.BLL
{
    /// <summary>
    /// 业务逻辑类Adbanner 的摘要说明。
    /// </summary>
    public class Adbanner
    {
        //private readonly TravelAgent.DAL.Adbanner dal = new TravelAgent.DAL.Adbanner();
        private readonly TravelAgent.IDAL.IAdbanner dal = DALBuild.CreateAdbanner();
        public Adbanner()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int Id)
        {
            return dal.Exists(Id);
        }

        /// <summary>
        /// 返回查询数据总数（分页用到）
        /// </summary>
        public int GetCount(string strWhere)
        {
            return dal.GetCount(strWhere);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(TravelAgent.Model.Adbanner model)
        {
            dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(TravelAgent.Model.Adbanner model)
        {
            dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int Id)
        {
            dal.Delete(Id);
        }
         /// <summary>
        /// 删除一条数据
        /// </summary>
        public void DeleteByAID(int Aid)
        {
            dal.DeleteByAID(Aid);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public TravelAgent.Model.Adbanner GetModel(int Id)
        {
            return dal.GetModel(Id);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }

        #endregion  成员方法
    }
}
