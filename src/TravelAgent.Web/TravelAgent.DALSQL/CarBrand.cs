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
    public class CarBrand:ICarBrand
    {
        /// <summary>
        /// 取得最新插入的ID
        /// </summary>
        public int GetMaxID(string FieldName)
        {
            return DbHelperSQL.GetMaxID(FieldName, "CarBrand");
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(TravelAgent.Model.CarBrand model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into CarBrand(");
            strSql.Append("BrandName,BrandPic,Sort)");
            strSql.Append(" values (");
            strSql.Append("@BrandName,@BrandPic,@Sort)");
            SqlParameter[] parameters = {
					new SqlParameter("@BrandName", SqlDbType.NVarChar,50),
                    new SqlParameter("@BrandPic", SqlDbType.NVarChar,200),
					new SqlParameter("@Sort", SqlDbType.Int,4)};
            parameters[0].Value = model.BrandName;
            parameters[1].Value = model.BrandPic;
            parameters[2].Value = model.Sort;
            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(TravelAgent.Model.CarBrand model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update CarBrand set ");
            strSql.Append("BrandName=@BrandName,");
            strSql.Append("BrandPic=@BrandPic,");
            strSql.Append("Sort=@Sort");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@BrandName", SqlDbType.NVarChar,50),
                    new SqlParameter("@BrandPic", SqlDbType.NVarChar,200),
					new SqlParameter("@Sort", SqlDbType.Int,4),
                    new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters[0].Value = model.BrandName;
            parameters[1].Value = model.BrandPic;
            parameters[2].Value = model.Sort;
            parameters[3].Value = model.Id;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 删除数据
        /// </summary>
        public void Delete(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from CarBrand ");
            strSql.Append(" where Id=" + Id);

            DbHelperSQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public TravelAgent.Model.CarBrand GetModel(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from CarBrand ");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters[0].Value = Id;

            TravelAgent.Model.CarBrand model = new TravelAgent.Model.CarBrand();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Id"].ToString() != "")
                {
                    model.Id = int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
                }
                model.BrandName = ds.Tables[0].Rows[0]["BrandName"].ToString();
                model.BrandPic = ds.Tables[0].Rows[0]["BrandPic"].ToString();
                if (ds.Tables[0].Rows[0]["Sort"].ToString() != "")
                {
                    model.Sort = int.Parse(ds.Tables[0].Rows[0]["Sort"].ToString());
                }

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
            strSql.Append("select Id,BrandName,BrandPic,Sort ");
            strSql.Append(" FROM CarBrand ");
            strSql.Append(" order by Sort asc");
            return DbHelperSQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Id,BrandName,BrandPic,Sort ");
            strSql.Append(" FROM CarBrand ");
            strSql.Append(" where " + strWhere);
            strSql.Append(" order by Sort asc");
            return DbHelperSQL.Query(strSql.ToString());
        }
    }
}
