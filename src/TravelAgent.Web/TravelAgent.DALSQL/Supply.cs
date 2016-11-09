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
    public class Supply:ISupply
    {
        /// <summary>
        /// 取得最新插入的ID
        /// </summary>
        public int GetMaxID(string FieldName)
        {
            return DbHelperSQL.GetMaxID(FieldName, "Supplier");
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(TravelAgent.Model.Supplier model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Supplier(");
            strSql.Append("supplyName,contactName,telephone,mobilephone,email,remark,isLock)");
            strSql.Append(" values (");
            strSql.Append("@supplyName,@contactName,@telephone,@mobilephone,@email,@remark,@isLock)");
            SqlParameter[] parameters = {
					new SqlParameter("@supplyName", SqlDbType.NVarChar,50),
					new SqlParameter("@contactName", SqlDbType.VarChar,250),
                    new SqlParameter("@telephone", SqlDbType.VarChar,250),
					new SqlParameter("@mobilephone", SqlDbType.VarChar,250),
                    new SqlParameter("@email", SqlDbType.VarChar,250),
					new SqlParameter("@remark", SqlDbType.Text,500),
					new SqlParameter("@isLock", SqlDbType.Int,4)};
            parameters[0].Value = model.supplyName;
            parameters[1].Value = model.contactName;
            parameters[2].Value = model.telephone;
            parameters[3].Value = model.mobilephone;
            parameters[4].Value = model.email;
            parameters[5].Value = model.remark;
            parameters[6].Value = model.isLock;
            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(TravelAgent.Model.Supplier model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Supplier set ");
            strSql.Append("supplyName=@supplyName,");
            strSql.Append("contactName=@contactName,");
            strSql.Append("telephone=@telephone,");
            strSql.Append("mobilephone=@mobilephone,");
            strSql.Append("email=@email,");
            strSql.Append("remark=@remark,");
            strSql.Append("isLock=@isLock");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@supplyName", SqlDbType.NVarChar,50),
					new SqlParameter("@contactName", SqlDbType.VarChar,250),
                    new SqlParameter("@telephone", SqlDbType.VarChar,250),
					new SqlParameter("@mobilephone", SqlDbType.VarChar,250),
                    new SqlParameter("@email", SqlDbType.VarChar,250),
					new SqlParameter("@remark", SqlDbType.Text,500),
					new SqlParameter("@isLock", SqlDbType.Int),
                    new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters[0].Value = model.supplyName;
            parameters[1].Value = model.contactName;
            parameters[2].Value = model.telephone;
            parameters[3].Value = model.mobilephone;
            parameters[4].Value = model.email;
            parameters[5].Value = model.remark;
            parameters[6].Value = model.isLock;
            parameters[7].Value = model.Id;
            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 删除数据
        /// </summary>
        public void Delete(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Supplier ");
            strSql.Append(" where Id=" + Id);

            DbHelperSQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public TravelAgent.Model.Supplier GetModel(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Id,supplyName,contactName,telephone,mobilephone,email,remark,isLock from Supplier ");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters[0].Value = Id;

            TravelAgent.Model.Supplier model = new TravelAgent.Model.Supplier();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Id"].ToString() != "")
                {
                    model.Id = int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
                }
                model.supplyName = ds.Tables[0].Rows[0]["supplyName"].ToString();
                model.contactName = ds.Tables[0].Rows[0]["contactName"].ToString();
                model.telephone = ds.Tables[0].Rows[0]["telephone"].ToString();
                model.mobilephone = ds.Tables[0].Rows[0]["mobilephone"].ToString();
                model.email = ds.Tables[0].Rows[0]["email"].ToString();
                model.remark = ds.Tables[0].Rows[0]["remark"].ToString();
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
            strSql.Append("select Id,supplyName,contactName,telephone,mobilephone,email,remark,isLock ");
            strSql.Append(" FROM Supplier ");
            return DbHelperSQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Id,supplyName,contactName,telephone,mobilephone,email,remark,isLock ");
            strSql.Append(" FROM Supplier ");
            strSql.Append(" where "+strWhere);
            return DbHelperSQL.Query(strSql.ToString());
        }
    }
}
