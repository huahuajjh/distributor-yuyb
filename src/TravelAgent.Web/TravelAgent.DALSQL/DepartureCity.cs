using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TravelAgent.IDAL;
using TravelAgent.Tool;
namespace TravelAgent.DALSQL
{
    public class DepartureCity:IDepartureCity
    {
        /// <summary>
        /// 取得最新插入的ID
        /// </summary>
        public int GetMaxID(string FieldName)
        {
            return DbHelperSQL.GetMaxID(FieldName, "DepartureCity");
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(TravelAgent.Model.DepartureCity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into DepartureCity(");
            strSql.Append("CityName,Sort,isLock)");
            strSql.Append(" values (");
            strSql.Append("@CityName,@Sort,@isLock)");
            SqlParameter[] parameters = {
					new SqlParameter("@CityName", SqlDbType.NVarChar,50),
					new SqlParameter("@Sort", SqlDbType.Int,4),
					new SqlParameter("@isLock", SqlDbType.Int,4)};
            parameters[0].Value = model.CityName;
            parameters[1].Value = model.Sort;
            parameters[2].Value = model.isLock;
            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(TravelAgent.Model.DepartureCity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update DepartureCity set ");
            strSql.Append("CityName=@CityName,");
            strSql.Append("Sort=@Sort,");
            strSql.Append("isLock=@isLock");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@CityName", SqlDbType.NVarChar,50),
					new SqlParameter("@Sort", SqlDbType.Int,4),
                    new SqlParameter("@isLock", SqlDbType.Int,4),
                    new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters[0].Value = model.CityName;
            parameters[1].Value = model.Sort;
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
            strSql.Append("delete from DepartureCity ");
            strSql.Append(" where Id=" + Id);

            DbHelperSQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public TravelAgent.Model.DepartureCity GetModel(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Id,CityName,Sort,isLock from DepartureCity ");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters[0].Value = Id;

            TravelAgent.Model.DepartureCity model = new TravelAgent.Model.DepartureCity();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Id"].ToString() != "")
                {
                    model.id = int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
                }
                model.CityName = ds.Tables[0].Rows[0]["CityName"].ToString();
                if (ds.Tables[0].Rows[0]["Sort"].ToString() != "")
                {
                    model.Sort = int.Parse(ds.Tables[0].Rows[0]["Sort"].ToString());
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
            strSql.Append("select Id,CityName,Sort,isLock ");
            strSql.Append(" FROM DepartureCity ");
            strSql.Append(" order by Sort asc");
            return DbHelperSQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Id,CityName,Sort,isLock ");
            strSql.Append(" FROM DepartureCity ");
            strSql.Append(" where "+strWhere);
            strSql.Append(" order by Sort asc");
            return DbHelperSQL.Query(strSql.ToString());
        }
    }
}
