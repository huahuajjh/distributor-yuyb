using System;
using System.Data;
using System.Collections.Generic;
using TravelAgent.Model;
using TravelAgent.DALFactory;

namespace TravelAgent.BLL
{
	/// <summary>
	/// ҵ���߼���Links ��ժҪ˵����
	/// </summary>
	public class Links
	{
		//private readonly TravelAgent.DAL.Links dal=new TravelAgent.DAL.Links();
        private readonly TravelAgent.IDAL.ILinks dal = DALBuild.CreateLinks();
		public Links()
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
        /// ���ز�ѯ������������ҳ�õ���
        /// </summary>
        public int GetCount(string strWhere)
        {
            return dal.GetCount(strWhere);
        }

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Add(TravelAgent.Model.Links model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(TravelAgent.Model.Links model)
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
		/// �õ�һ������ʵ��
		/// </summary>
		public TravelAgent.Model.Links GetModel(int Id)
		{
			
			return dal.GetModel(Id);
		}

		/// <summary>
		/// ��������б�
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// ���ǰ��������
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
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

