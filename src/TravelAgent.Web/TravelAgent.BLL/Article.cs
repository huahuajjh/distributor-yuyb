using System;
using System.Data;
using System.Collections.Generic;
using TravelAgent.Model;
using TravelAgent.IDAL;
using TravelAgent.DALFactory;
namespace TravelAgent.BLL
{
	/// <summary>
	/// ҵ���߼���Article ��ժҪ˵����
	/// </summary>
	public class Article
	{
        //private readonly TravelAgent.DAL.Article dal = new TravelAgent.DAL.Article();
        private static readonly IArticle dal = DALBuild.CreateArticle();
		public Article()
		{}
		#region  ��Ա����
		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool Exists(int Id)
		{
			return dal.Exists(Id);
		}

        /// <summary>
        /// ���س���ѯ��������
        /// </summary>
        /// <param name="strWhere">����</param>
        /// <returns></returns>
        public int GetCount(string strWhere)
        {
            return dal.GetCount(strWhere);
        }
		/// <summary>
		/// ����һ������
		/// </summary>
		public void Add(TravelAgent.Model.Article model)
		{
			dal.Add(model);
		}

        /// <summary>
        /// �޸�һ������
        /// </summary>
        public void UpdateField(int Id, string strValue)
        {
            dal.UpdateField(Id, strValue);
        }

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(TravelAgent.Model.Article model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(int Id)
		{
			
			dal.Delete(Id);
		}
          /// <summary>
        /// ���������¼
        /// </summary>
        /// <param name="curId"></param>
        /// <returns></returns>
        public TravelAgent.Model.Article GetSpeModel(int curId, string type, int classid)
        {
            return dal.GetSpeModel(curId, type,classid);
        }
		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public TravelAgent.Model.Article GetModel(int Id)
		{
			
			return dal.GetModel(Id);
		}

		/// <summary>
		/// ��������б�
		/// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
		{
			return dal.GetList(Top, strWhere, filedOrder);
		}

		/// <summary>
		/// ���ָ������µ�ǰ��������
		/// </summary>
        public DataSet GetList(int classId, int kindId, int Top, string strWhere, string filedOrder)
		{
			return dal.GetList(classId, kindId, Top, strWhere, filedOrder);
		}

        /// <summary>
        /// ��ò�ѯ��ҳ����
        /// </summary>
        public DataSet GetPageList(int pageSize, int currentPage, string strWhere, string filedOrder)
        {
            return dal.GetPageList(pageSize, currentPage, strWhere, filedOrder);
        }

		#endregion  ��Ա����
	}
}

