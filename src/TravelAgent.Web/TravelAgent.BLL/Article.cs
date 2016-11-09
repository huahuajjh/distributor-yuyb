using System;
using System.Data;
using System.Collections.Generic;
using TravelAgent.Model;
using TravelAgent.IDAL;
using TravelAgent.DALFactory;
namespace TravelAgent.BLL
{
	/// <summary>
	/// 业务逻辑类Article 的摘要说明。
	/// </summary>
	public class Article
	{
        //private readonly TravelAgent.DAL.Article dal = new TravelAgent.DAL.Article();
        private static readonly IArticle dal = DALBuild.CreateArticle();
		public Article()
		{}
		#region  成员方法
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int Id)
		{
			return dal.Exists(Id);
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
		public void Add(TravelAgent.Model.Article model)
		{
			dal.Add(model);
		}

        /// <summary>
        /// 修改一条数据
        /// </summary>
        public void UpdateField(int Id, string strValue)
        {
            dal.UpdateField(Id, strValue);
        }

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(TravelAgent.Model.Article model)
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
        /// 获得条件记录
        /// </summary>
        /// <param name="curId"></param>
        /// <returns></returns>
        public TravelAgent.Model.Article GetSpeModel(int curId, string type, int classid)
        {
            return dal.GetSpeModel(curId, type,classid);
        }
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public TravelAgent.Model.Article GetModel(int Id)
		{
			
			return dal.GetModel(Id);
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
		{
			return dal.GetList(Top, strWhere, filedOrder);
		}

		/// <summary>
		/// 获得指定类别下的前几行数据
		/// </summary>
        public DataSet GetList(int classId, int kindId, int Top, string strWhere, string filedOrder)
		{
			return dal.GetList(classId, kindId, Top, strWhere, filedOrder);
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

