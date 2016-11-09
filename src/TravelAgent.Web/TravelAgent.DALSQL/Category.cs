using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using TravelAgent.Tool;//请先添加引用
using TravelAgent.IDAL;
using System.Collections.Generic;

namespace TravelAgent.DALSQL
{
    public class Category:ICategory
    {
        public Category()
		{}
		#region  成员方法
        /// <summary>
        /// 取得最新插入的ID
        /// </summary>
        public int GetMaxID(string FieldName)
        {
            return DbHelperSQL.GetMaxID(FieldName, "Category");
        }

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int Id)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select count(1) from Category");
			strSql.Append(" where Id=@Id ");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)};
			parameters[0].Value = Id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}
        
        /// <summary>
        /// 返回栏目名称
        /// </summary>
        /// <param name="classId"></param>
        /// <returns></returns>
        public string GetChannelTitle(int classId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 Title from Category");
            strSql.Append(" where Id=" + classId);
            return Convert.ToString(DbHelperSQL.GetSingle(strSql.ToString()));
        }


		/// <summary>
		/// 增加一条数据
		/// </summary>
        public void Add(TravelAgent.Model.Category model)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("insert into Category(");
            strSql.Append("Title,ParentId,ClassList,ClassLayer,ClassOrder,PageUrl,KindId,css,State)");
			strSql.Append(" values (");
            strSql.Append("@Title,@ParentId,@ClassList,@ClassLayer,@ClassOrder,@PageUrl,@KindId,@css,@State)");
			SqlParameter[] parameters = {
					new SqlParameter("@Title", SqlDbType.NVarChar,50),
					new SqlParameter("@ParentId", SqlDbType.Int,4),
					new SqlParameter("@ClassList", SqlDbType.NVarChar,300),
					new SqlParameter("@ClassLayer", SqlDbType.Int,4),
					new SqlParameter("@ClassOrder", SqlDbType.Int,4),
                    new SqlParameter("@PageUrl",SqlDbType.NVarChar,250),
					new SqlParameter("@KindId", SqlDbType.Int,4),
                    new SqlParameter("@css",SqlDbType.NVarChar,50),
					new SqlParameter("@State", SqlDbType.NVarChar,50)};
			parameters[0].Value = model.Title;
			parameters[1].Value = model.ParentId;
			parameters[2].Value = model.ClassList;
			parameters[3].Value = model.ClassLayer;
            parameters[4].Value = model.ClassOrder;
            parameters[5].Value = model.PageUrl;
			parameters[6].Value = model.KindId;
            parameters[7].Value = model.Css;
            parameters[8].Value = model.State;
            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
        public void Update(TravelAgent.Model.Category model)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("update Category set ");
			strSql.Append("Title=@Title,");
			strSql.Append("ParentId=@ParentId,");
			strSql.Append("ClassList=@ClassList,");
			strSql.Append("ClassLayer=@ClassLayer,");
			strSql.Append("ClassOrder=@ClassOrder,");
            strSql.Append("PageUrl=@PageUrl,");
			strSql.Append("KindId=@KindId,");
            strSql.Append("css=@css,");
            strSql.Append("State=@State");
			strSql.Append(" where Id=@Id ");
			SqlParameter[] parameters = {
					new SqlParameter("@Title", SqlDbType.NVarChar,50),
					new SqlParameter("@ParentId", SqlDbType.Int,4),
					new SqlParameter("@ClassList", SqlDbType.NVarChar,300),
					new SqlParameter("@ClassLayer", SqlDbType.Int,4),
					new SqlParameter("@ClassOrder", SqlDbType.Int,4),
                    new SqlParameter("@PageUrl", SqlDbType.NVarChar,250),
					new SqlParameter("@KindId", SqlDbType.Int,4),
                    new SqlParameter("@css", SqlDbType.NVarChar,50),
                    new SqlParameter("@State", SqlDbType.NVarChar,50),
                    new SqlParameter("@Id", SqlDbType.Int,4)};
			parameters[0].Value = model.Title;
			parameters[1].Value = model.ParentId;
			parameters[2].Value = model.ClassList;
			parameters[3].Value = model.ClassLayer;
			parameters[4].Value = model.ClassOrder;
            parameters[5].Value = model.PageUrl;
			parameters[6].Value = model.KindId;
            parameters[7].Value = model.Css;
            parameters[8].Value = model.State;
            parameters[9].Value = model.Id;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除该类别及所有属下分类数据
		/// </summary>
		public void Delete(int Id)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("delete from Category ");
            strSql.Append(" where ClassList like '%,"+Id+",%' ");

			DbHelperSQL.Query(strSql.ToString());
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
        public TravelAgent.Model.Category GetModel(int Id)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select  top 1 Id,Title,ParentId,ClassList,ClassLayer,ClassOrder,PageUrl,KindId,css,State from Category ");
			strSql.Append(" where Id=@Id ");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)};
			parameters[0].Value = Id;

            TravelAgent.Model.Category model = new TravelAgent.Model.Category();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["Id"].ToString()!="")
				{
					model.Id=int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
				}
				model.Title=ds.Tables[0].Rows[0]["Title"].ToString();
				if(ds.Tables[0].Rows[0]["ParentId"].ToString()!="")
				{
					model.ParentId=int.Parse(ds.Tables[0].Rows[0]["ParentId"].ToString());
				}
				model.ClassList=ds.Tables[0].Rows[0]["ClassList"].ToString();
				if(ds.Tables[0].Rows[0]["ClassLayer"].ToString()!="")
				{
					model.ClassLayer=int.Parse(ds.Tables[0].Rows[0]["ClassLayer"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ClassOrder"].ToString()!="")
				{
					model.ClassOrder=int.Parse(ds.Tables[0].Rows[0]["ClassOrder"].ToString());
				}
                model.PageUrl = ds.Tables[0].Rows[0]["PageUrl"].ToString();
				if(ds.Tables[0].Rows[0]["KindId"].ToString()!="")
				{
					model.KindId=int.Parse(ds.Tables[0].Rows[0]["KindId"].ToString());
				}
                model.Css = ds.Tables[0].Rows[0]["css"].ToString();
                model.State =ds.Tables[0].Rows[0]["State"].ToString();
				return model;
			}
			else
			{
				return null;
			}
		}

        /// <summary>
        /// 取得所有栏目列表
        /// </summary>
        /// <param name="PId">父ID</param>
        /// <param name="KId">种类ID</param>
        /// <returns></returns>
        public DataTable GetList(int PId, int? KId)
        {
            DataTable data = new DataTable();
            //创建列
            DataColumn Id = new DataColumn("Id", typeof(int));
            DataColumn Title = new DataColumn("Title", typeof(string));
            DataColumn ParentId = new DataColumn("ParentId", typeof(int));
            DataColumn ClassList = new DataColumn("ClassList", typeof(string));
            DataColumn ClassLayer = new DataColumn("ClassLayer", typeof(int));
            DataColumn ClassOrder = new DataColumn("ClassOrder", typeof(int));
            DataColumn PageUrl = new DataColumn("PageUrl", typeof(string));
            DataColumn KindId = new DataColumn("KindId", typeof(int));
            DataColumn Css = new DataColumn("Css", typeof(string));
            DataColumn State = new DataColumn("State", typeof(string));
            //添加列
            data.Columns.Add(Id);
            data.Columns.Add(Title);
            data.Columns.Add(ParentId);
            data.Columns.Add(ClassList);
            data.Columns.Add(ClassLayer);
            data.Columns.Add(ClassOrder);
            data.Columns.Add(PageUrl);
            data.Columns.Add(KindId);
            data.Columns.Add(Css);
            data.Columns.Add(State);
            //调用迭代组合成DAGATABLE
            List<int> ids = new List<int>();
            GetChannelChild(data, PId, KId, ids);
            return data;
        }

        /// <summary>
        /// 取得该栏目的所有下级栏目列表
        /// </summary>
        /// <param name="data">DATATABLE名</param>
        /// <param name="PId">父栏目ID</param>
        /// <param name="KId">种类ID</param>
        private void GetChannelChild(DataTable data, int PId, int? KId, List<int> ids)
        {
            if (ids.Contains(PId)) return;
            ids.Add(PId);
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Id,Title,ParentId,ClassList,ClassLayer,ClassOrder,PageUrl,KindId,css,State from Category");
            if(KId!=null)
            {
                strSql.Append(" where ParentId=" + PId + " and KindId=" + KId + "   order by ClassOrder asc,Id desc");
            }
            else
            {
                strSql.Append(" where ParentId=" + PId + " order by ClassOrder asc,Id desc");
            }
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    DataRow dr = ds.Tables[0].Rows[i];
                    //添加一行数据
                    DataRow row = data.NewRow();
                    row[0] = int.Parse(dr["Id"].ToString());
                    row[1] = dr["Title"].ToString();
                    row[2] = int.Parse(dr["ParentId"].ToString());
                    row[3] = dr["ClassList"].ToString();
                    row[4] = int.Parse(dr["ClassLayer"].ToString());
                    row[5] = int.Parse(dr["ClassOrder"].ToString());
                    row[6] = dr["PageUrl"].ToString();
                    row[7] = int.Parse(dr["KindId"].ToString());
                    row[8] = dr["css"].ToString();
                    row[9] = dr["State"].ToString();
                    data.Rows.Add(row);
                    //调用自身迭代
                    this.GetChannelChild(data, int.Parse(dr["Id"].ToString()), KId, ids);
                }
            }
        }

        /// <summary>
        /// 取得该栏目下的所有子栏目的ID
        /// </summary>
        /// <param name="classId"></param>
        /// <returns></returns>
        public DataSet GetChannelListByClassId(int classId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 ClassList,ClassLayer from Category");
            strSql.Append(" where Id=" + classId + " ");
            return DbHelperSQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 取得栏目集合
        /// </summary>
        /// <param name="classId"></param>
        /// <returns></returns>
        public DataSet GetChannelListByParentId(int parentId,int? top)
        {
            StringBuilder strSql = new StringBuilder();
            if(top!=null)
            {
                strSql.Append("select top " + top + " * from Category");
            }
            else
            {
                strSql.Append("select * from Category");
            }
            strSql.Append(" where ParentId=" + parentId + " and State='0' order by ClassOrder asc");
            return DbHelperSQL.Query(strSql.ToString());
        }
		#endregion  成员方法
    }
}
