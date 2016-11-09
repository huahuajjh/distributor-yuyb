using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TravelAgent.Tool;
using TravelAgent.IDAL;
namespace TravelAgent.DALSQL
{
    public class LineHoliday : ILineHoliday
    {
        /// <summary>
        /// 取得最新插入的ID
        /// </summary>
        public int GetMaxID(string FieldName)
        {
            return DbHelperSQL.GetMaxID(FieldName, "LineHoliday");
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(TravelAgent.Model.LineHoliday model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into LineHoliday(");
            strSql.Append("holidayName,holidaybgurl)");
            strSql.Append(" values (");
            strSql.Append("@holidayName,@holidaybgurl)");
            SqlParameter[] parameters = {
					new SqlParameter("@holidayName", SqlDbType.NVarChar,50),
                    new SqlParameter("@holidaybgurl", SqlDbType.NVarChar,255)};
            parameters[0].Value = model.holidayName;
            parameters[1].Value = model.holidaybgurl;
            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(TravelAgent.Model.LineHoliday model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update LineHoliday set ");
            strSql.Append("holidayName=@holidayName,");
            strSql.Append("holidaybgurl=@holidaybgurl");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@holidayName", SqlDbType.NVarChar,50),
                    new SqlParameter("@holidaybgurl", SqlDbType.NVarChar,255),
                    new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters[0].Value = model.holidayName;
            parameters[1].Value = model.holidaybgurl;
            parameters[2].Value = model.Id;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 删除数据
        /// </summary>
        public void Delete(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from LineHoliday ");
            strSql.Append(" where Id=" + Id);

            DbHelperSQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public TravelAgent.Model.LineHoliday GetModel(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Id,holidayName,holidaybgurl from LineHoliday ");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters[0].Value = Id;

            TravelAgent.Model.LineHoliday model = new TravelAgent.Model.LineHoliday();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Id"].ToString() != "")
                {
                    model.Id = int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
                }
                model.holidayName = ds.Tables[0].Rows[0]["holidayName"].ToString();
                model.holidaybgurl = ds.Tables[0].Rows[0]["holidaybgurl"].ToString();

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
            strSql.Append("select Id,holidayName,holidaybgurl ");
            strSql.Append(" FROM LineHoliday ");
            return DbHelperSQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Id,holidayName,holidaybgurl ");
            strSql.Append(" FROM LineHoliday ");
            if (!strWhere.Equals(""))
            {
                strSql.Append(" where " + strWhere);
            }

            return DbHelperSQL.Query(strSql.ToString());
        }
    }
}
