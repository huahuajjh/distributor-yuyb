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
    public class AdminList:IAdminList
    {
        /// <summary>
        /// 取得最新插入的ID
        /// </summary>
        public int GetMaxID(string FieldName)
        {
            return DbHelperSQL.GetMaxID(FieldName, "AdminList");
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(TravelAgent.Model.AdminList model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into AdminList(");
            strSql.Append("UserName,UserPwd,ReadName,RoleId,IsLock)");
            strSql.Append(" values (");
            strSql.Append("@UserName,@UserPwd,@ReadName,@RoleId,@IsLock)");
            SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.VarChar),
                    new SqlParameter("@UserPwd", SqlDbType.VarChar),
                    new SqlParameter("@ReadName", SqlDbType.VarChar),
                                          new SqlParameter("@RoleId", SqlDbType.Int),
                                          new SqlParameter("@IsLock", SqlDbType.Int)};
            parameters[0].Value = model.UserName;
            parameters[1].Value = model.UserPwd;
            parameters[2].Value = model.ReadName;
            parameters[3].Value = model.RoleId;
            parameters[4].Value = model.IsLock;
            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(TravelAgent.Model.AdminList model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update AdminList set ");
            strSql.Append("UserName=@UserName,");
            strSql.Append("UserPwd=@UserPwd,");
            strSql.Append("ReadName=@ReadName,");
            strSql.Append("RoleId=@RoleId,");
            strSql.Append("IsLock=@IsLock");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
				new SqlParameter("@UserName", SqlDbType.VarChar),
                new SqlParameter("@UserPwd", SqlDbType.VarChar),
                    new SqlParameter("@ReadName", SqlDbType.VarChar),
                    new SqlParameter("@RoleId", SqlDbType.Int),
                    new SqlParameter("@IsLock", SqlDbType.Int),
                    new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters[0].Value = model.UserName;
            parameters[1].Value = model.UserPwd;
            parameters[2].Value = model.ReadName;
            parameters[3].Value = model.RoleId;
            parameters[4].Value = model.IsLock;
            parameters[5].Value = model.Id;

            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 删除数据
        /// </summary>
        public int Delete(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from AdminList ");
            strSql.Append(" where Id=" + Id);

            return DbHelperSQL.ExecuteSql(strSql.ToString());
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public TravelAgent.Model.AdminList GetModel(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from AdminList ");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters[0].Value = Id;

            TravelAgent.Model.AdminList model = new TravelAgent.Model.AdminList();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Id"].ToString() != "")
                {
                    model.Id = int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
                }
                model.UserName = ds.Tables[0].Rows[0]["UserName"].ToString();
                model.UserPwd = ds.Tables[0].Rows[0]["UserPwd"].ToString();
                model.ReadName = ds.Tables[0].Rows[0]["ReadName"].ToString();
                model.RoleId = Convert.ToInt32(ds.Tables[0].Rows[0]["RoleId"].ToString());
                model.IsLock = Convert.ToInt32(ds.Tables[0].Rows[0]["IsLock"].ToString());
                return model;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public TravelAgent.Model.AdminList GetAccountByUser(string username, string password)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from AdminList ");
            strSql.Append(" where UserName=@UserName and UserPwd=@UserPwd");
            SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.VarChar),
                    new SqlParameter("@UserPwd", SqlDbType.VarChar)};
            parameters[0].Value = username;
            parameters[1].Value = password;

            TravelAgent.Model.AdminList model = new TravelAgent.Model.AdminList();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Id"].ToString() != "")
                {
                    model.Id = int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
                }
                model.UserName = ds.Tables[0].Rows[0]["UserName"].ToString();
                model.UserPwd = ds.Tables[0].Rows[0]["UserPwd"].ToString();
                model.ReadName = ds.Tables[0].Rows[0]["ReadName"].ToString();
                model.RoleId = Convert.ToInt32(ds.Tables[0].Rows[0]["RoleId"].ToString());
                model.IsLock = Convert.ToInt32(ds.Tables[0].Rows[0]["IsLock"].ToString());
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
            strSql.Append("select *,(select roleName from AdminRole where Id=RoleId) as RoleName ");
            strSql.Append(" FROM AdminList ");
            return DbHelperSQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select *,(select roleName from AdminRole where Id=RoleId) as RoleName ");
            strSql.Append(" FROM AdminList ");
            if (strWhere != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
    }
}
