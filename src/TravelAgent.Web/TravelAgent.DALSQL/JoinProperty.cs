using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TravelAgent.IDAL;
using TravelAgent.Tool;
namespace TravelAgent.DALSQL
{
    public class JoinProperty:IJoinProperty
    {
        /// <summary>
        /// 取得最新插入的ID
        /// </summary>
        public int GetMaxID(string FieldName)
        {
            return DbHelperSQL.GetMaxID(FieldName, "JoinProperty");
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(TravelAgent.Model.JoinProperty model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into JoinProperty(");
            strSql.Append("joinName,joinSort,isLock)");
            strSql.Append(" values (");
            strSql.Append("@joinName,@joinSort,@isLock)");
            SqlParameter[] parameters = {
					new SqlParameter("@joinName", SqlDbType.NVarChar,50),
					new SqlParameter("@joinSort", SqlDbType.Int,4),
					new SqlParameter("@isLock", SqlDbType.Int,4)};
            parameters[0].Value = model.joinName;
            parameters[1].Value = model.joinSort;
            parameters[2].Value = model.isLock;
            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(TravelAgent.Model.JoinProperty model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update JoinProperty set ");
            strSql.Append("joinName=@joinName,");
            strSql.Append("joinSort=@joinSort,");
            strSql.Append("isLock=@isLock");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@joinName", SqlDbType.NVarChar,50),
					new SqlParameter("@joinSort", SqlDbType.Int,4),
                    new SqlParameter("@isLock", SqlDbType.Int,4),
                    new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters[0].Value = model.joinName;
            parameters[1].Value = model.joinSort;
            parameters[2].Value = model.isLock;
            parameters[3].Value = model.id;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 删除数据
        /// </summary>
        public void Delete(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from JoinProperty ");
            strSql.Append(" where Id=" + Id);

            DbHelperSQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public TravelAgent.Model.JoinProperty GetModel(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Id,joinName,joinSort,isLock from JoinProperty ");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters[0].Value = Id;

            TravelAgent.Model.JoinProperty model = new TravelAgent.Model.JoinProperty();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Id"].ToString() != "")
                {
                    model.id = int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
                }
                model.joinName = ds.Tables[0].Rows[0]["joinName"].ToString();
                if (ds.Tables[0].Rows[0]["joinSort"].ToString() != "")
                {
                    model.joinSort = int.Parse(ds.Tables[0].Rows[0]["joinSort"].ToString());
                }
                model.isLock = int.Parse(ds.Tables[0].Rows[0]["isLock"].ToString());
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Id,joinName,joinSort,isLock ");
            strSql.Append(" FROM JoinProperty ");
            strSql.Append(" order by joinSort asc");
            return DbHelperSQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Id,joinName,joinSort,isLock ");
            strSql.Append(" FROM JoinProperty ");
            strSql.Append(" where "+strWhere);
            strSql.Append(" order by joinSort asc");
            return DbHelperSQL.Query(strSql.ToString());
        }
    }
}
