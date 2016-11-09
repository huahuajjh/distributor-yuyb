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
    public class LineOrderTourist:ILineOrderTourist
    {
        /// <summary>
        /// 取得最新插入的ID
        /// </summary>
        public int GetMaxID(string FieldName)
        {
            return DbHelperSQL.GetMaxID(FieldName, "LineOrderTourist");
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(TravelAgent.Model.LineOrderTourist model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into LineOrderTourist(");
            strSql.Append("orderId,touristName,touristSex,mobile,papersType,papersNo,birthDate,touristType)");
            strSql.Append(" values (");
            strSql.Append("@orderId,@touristName,@touristSex,@mobile,@papersType,@papersNo,@birthDate,@touristType)");
            SqlParameter[] parameters = {
					new SqlParameter("@orderId", SqlDbType.Int),
                    new SqlParameter("@touristName", SqlDbType.VarChar),
                    new SqlParameter("@touristSex", SqlDbType.VarChar),
					new SqlParameter("@mobile", SqlDbType.VarChar),
                    new SqlParameter("@papersType", SqlDbType.Int),
                    new SqlParameter("@papersNo", SqlDbType.VarChar),
                                          new SqlParameter("@birthDate", SqlDbType.VarChar),
                                          new SqlParameter("@touristType", SqlDbType.Int)};
            parameters[0].Value = model.orderId;
            parameters[1].Value = model.touristName;
            parameters[2].Value = model.touristSex;
            parameters[3].Value = model.mobile;
            parameters[4].Value = model.papersType;
            parameters[5].Value = model.papersNo;
            parameters[6].Value = model.birthDate;
            parameters[7].Value = model.touristType;
            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(TravelAgent.Model.LineOrderTourist model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update LineOrderTourist set ");
            strSql.Append("orderId=@orderId,");
            strSql.Append("touristName=@touristName,");
            strSql.Append("touristSex=@touristSex,");
            strSql.Append("mobile=@mobile,");
            strSql.Append("papersType=@papersType,");
            strSql.Append("papersNo=@papersNo,");
            strSql.Append("birthDate=@birthDate,");
            strSql.Append("touristType=@touristType");
            strSql.Append(" where id=@Id ");
            SqlParameter[] parameters = {
				new SqlParameter("@orderId", SqlDbType.Int),
                    new SqlParameter("@touristName", SqlDbType.VarChar),
                    new SqlParameter("@touristSex", SqlDbType.VarChar),
					new SqlParameter("@mobile", SqlDbType.VarChar),
                    new SqlParameter("@papersType", SqlDbType.Int),
                    new SqlParameter("@papersNo", SqlDbType.VarChar),
                                          new SqlParameter("@birthDate", SqlDbType.VarChar),
                                          new SqlParameter("@touristType", SqlDbType.Int),
                    new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters[0].Value = model.orderId;
            parameters[1].Value = model.touristName;
            parameters[2].Value = model.touristSex;
            parameters[3].Value = model.mobile;
            parameters[4].Value = model.papersType;
            parameters[5].Value = model.papersNo;
            parameters[6].Value = model.birthDate;
            parameters[7].Value = model.touristType;
            parameters[8].Value = model.id;
            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 删除数据
        /// </summary>
        public void Delete(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from LineOrderTourist ");
            strSql.Append(" where id=" + Id);

            DbHelperSQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public TravelAgent.Model.LineOrderTourist GetModel(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from LineOrderTourist ");
            strSql.Append(" where id=@Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters[0].Value = Id;

            TravelAgent.Model.LineOrderTourist model = new TravelAgent.Model.LineOrderTourist();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Id"].ToString() != "")
                {
                    model.id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }
                model.orderId = int.Parse(ds.Tables[0].Rows[0]["orderId"].ToString());
                model.touristName = ds.Tables[0].Rows[0]["touristName"].ToString();
                model.touristSex = ds.Tables[0].Rows[0]["touristSex"].ToString();
                model.mobile = ds.Tables[0].Rows[0]["mobile"].ToString();
                model.papersType = int.Parse(ds.Tables[0].Rows[0]["papersType"].ToString());
                model.papersNo = ds.Tables[0].Rows[0]["papersNo"].ToString();
                model.birthDate = ds.Tables[0].Rows[0]["birthDate"].ToString();
                model.touristType = int.Parse(ds.Tables[0].Rows[0]["touristType"].ToString());
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
            strSql.Append(" FROM LineOrderTourist ");
            return DbHelperSQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM LineOrderTourist ");
            if (!string.IsNullOrEmpty(strWhere))
            { 
                strSql.Append(" where " + strWhere);
            }
            
            return DbHelperSQL.Query(strSql.ToString());
        }
    }
}
