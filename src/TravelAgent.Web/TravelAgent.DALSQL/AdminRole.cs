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
    public class AdminRole:IAdminRole
    {
        /// <summary>
        /// 取得最新插入的ID
        /// </summary>
        public int GetMaxID(string FieldName)
        {
            return DbHelperSQL.GetMaxID(FieldName, "AdminRole");
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(TravelAgent.Model.AdminRole model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into AdminRole(");
            strSql.Append("roleName,roleAuth,roleInfo)");
            strSql.Append(" values (");
            strSql.Append("@roleName,@roleAuth,@roleInfo)");
            SqlParameter[] parameters = {
					new SqlParameter("@roleName", SqlDbType.VarChar),
                    new SqlParameter("@roleAuth", SqlDbType.VarChar),
                    new SqlParameter("@roleInfo", SqlDbType.VarChar)};
            parameters[0].Value = model.roleName;
            parameters[1].Value = model.roleAuth;
            parameters[2].Value = model.roleInfo;
            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(TravelAgent.Model.AdminRole model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update AdminRole set ");
            strSql.Append("roleName=@roleName,");
            strSql.Append("roleAuth=@roleAuth,");
            strSql.Append("roleInfo=@roleInfo");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
				new SqlParameter("@roleName", SqlDbType.VarChar),
                    new SqlParameter("@roleAuth", SqlDbType.VarChar),
                    new SqlParameter("@roleInfo", SqlDbType.VarChar),
                    new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters[0].Value = model.roleName;
            parameters[1].Value = model.roleAuth;
            parameters[2].Value = model.roleInfo;
            parameters[3].Value = model.Id;

            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 删除数据
        /// </summary>
        public int Delete(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from AdminRole ");
            strSql.Append(" where Id=" + Id);

            return DbHelperSQL.ExecuteSql(strSql.ToString());
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public TravelAgent.Model.AdminRole GetModel(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from AdminRole ");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters[0].Value = Id;

            TravelAgent.Model.AdminRole model = new TravelAgent.Model.AdminRole();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Id"].ToString() != "")
                {
                    model.Id = int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
                }
                model.roleName = ds.Tables[0].Rows[0]["roleName"].ToString();
                model.roleAuth = ds.Tables[0].Rows[0]["roleAuth"].ToString();
                model.roleInfo = ds.Tables[0].Rows[0]["roleInfo"].ToString();
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
            strSql.Append("select * ");
            strSql.Append(" FROM AdminRole ");
            return DbHelperSQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM AdminRole ");
            if (strWhere != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
    }
}
