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
    public class Insure:IInsure
    {
        /// <summary>
        /// 取得最新插入的ID
        /// </summary>
        public int GetMaxID(string FieldName)
        {
            return DbHelperSQL.GetMaxID(FieldName, "Insure");
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(TravelAgent.Model.Insure model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Insure(");
            strSql.Append("InsureName,InsurePrice,InsureContent,AddDate,IsLock)");
            strSql.Append(" values (");
            strSql.Append("@InsureName,@InsurePrice,@InsureContent,@AddDate,@IsLock)");
            SqlParameter[] parameters = {
					new SqlParameter("@InsureName", SqlDbType.VarChar),
                    new SqlParameter("@InsurePrice", SqlDbType.Int),
                    new SqlParameter("@InsureContent", SqlDbType.NVarChar),
					new SqlParameter("@AddDate", SqlDbType.DateTime),
                                          new SqlParameter("@IsLock", SqlDbType.Int)};
            parameters[0].Value = model.InsureName;
            parameters[1].Value = model.InsurePrice;
            parameters[2].Value = model.InsureContent;
            parameters[3].Value = model.AddDate;
            parameters[4].Value = model.IsLock;
            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(TravelAgent.Model.Insure model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Insure set ");
            strSql.Append("InsureName=@InsureName,");
            strSql.Append("InsurePrice=@InsurePrice,");
            strSql.Append("InsureContent=@InsureContent,");
            strSql.Append("AddDate=@AddDate,");
            strSql.Append("IsLock=@IsLock");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
				new SqlParameter("@InsureName", SqlDbType.VarChar),
                    new SqlParameter("@InsurePrice", SqlDbType.Int),
                    new SqlParameter("@InsureContent", SqlDbType.NVarChar),
					new SqlParameter("@AddDate", SqlDbType.DateTime),
                    new SqlParameter("@IsLock", SqlDbType.Int),
                    new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters[0].Value = model.InsureName;
            parameters[1].Value = model.InsurePrice;
            parameters[2].Value = model.InsureContent;
            parameters[3].Value = model.AddDate;
            parameters[4].Value = model.IsLock;
            parameters[5].Value = model.Id;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 删除数据
        /// </summary>
        public int Delete(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Insure ");
            strSql.Append(" where Id=" + Id);

            return DbHelperSQL.ExecuteSql(strSql.ToString());
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public TravelAgent.Model.Insure GetModel(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from Insure ");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters[0].Value = Id;

            TravelAgent.Model.Insure model = new TravelAgent.Model.Insure();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Id"].ToString() != "")
                {
                    model.Id = int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
                }
                model.InsureName = ds.Tables[0].Rows[0]["InsureName"].ToString();
                model.InsurePrice = int.Parse(ds.Tables[0].Rows[0]["InsurePrice"].ToString());
                model.InsureContent = ds.Tables[0].Rows[0]["InsureContent"].ToString();
                model.AddDate = Convert.ToDateTime(ds.Tables[0].Rows[0]["AddDate"].ToString());
                model.IsLock = int.Parse(ds.Tables[0].Rows[0]["IsLock"].ToString());
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
            strSql.Append(" FROM Insure ");
            strSql.Append(" order by AddDate desc");
            return DbHelperSQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM Insure ");
            strSql.Append(" where " + strWhere);
            strSql.Append(" order by AddDate desc");
            return DbHelperSQL.Query(strSql.ToString());
        }
    }
}
