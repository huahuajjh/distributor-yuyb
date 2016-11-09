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
    public class LineTheme:ILineTheme
    {
        /// <summary>
        /// 取得最新插入的ID
        /// </summary>
        public int GetMaxID(string FieldName)
        {
            return DbHelperSQL.GetMaxID(FieldName, "LineTheme");
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(TravelAgent.Model.LineTheme model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into LineTheme(");
            strSql.Append("themeName,themeTopPic,themeTopBgPic,Sort,isLock)");
            strSql.Append(" values (");
            strSql.Append("@themeName,@themeTopPic,@themeTopBgPic,@Sort,@isLock)");
            SqlParameter[] parameters = {
					new SqlParameter("@themeName", SqlDbType.NVarChar,50),
                    new SqlParameter("@themeTopPic", SqlDbType.NVarChar,255),
                    new SqlParameter("@themeTopBgPic", SqlDbType.NVarChar,255),
					new SqlParameter("@Sort", SqlDbType.Int,4),
					new SqlParameter("@isLock", SqlDbType.Int)};
            parameters[0].Value = model.themeName;
            parameters[1].Value = model.themeTopPic;
            parameters[2].Value = model.themeTopBgPic;
            parameters[3].Value = model.Sort;
            parameters[4].Value = model.isLock;
            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(TravelAgent.Model.LineTheme model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update LineTheme set ");
            strSql.Append("themeName=@themeName,");
            strSql.Append("themeTopPic=@themeTopPic,");
            strSql.Append("themeTopBgPic=@themeTopBgPic,");
            strSql.Append("Sort=@Sort,");
            strSql.Append("isLock=@isLock");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@themeName", SqlDbType.NVarChar,50),
                    new SqlParameter("@themeTopPic", SqlDbType.NVarChar,255),
                    new SqlParameter("@themeTopBgPic", SqlDbType.NVarChar,255),
					new SqlParameter("@Sort", SqlDbType.Int,4),
                    new SqlParameter("@isLock", SqlDbType.Int),
                    new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters[0].Value = model.themeName;
            parameters[1].Value = model.themeTopPic;
            parameters[2].Value = model.themeTopBgPic;
            parameters[3].Value = model.Sort;
            parameters[4].Value = model.isLock;
            parameters[5].Value = model.Id;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 删除数据
        /// </summary>
        public void Delete(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from LineTheme ");
            strSql.Append(" where Id=" + Id);

            DbHelperSQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public TravelAgent.Model.LineTheme GetModel(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Id,themeName,themeTopPic,themeTopBgPic,Sort,isLock from LineTheme ");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters[0].Value = Id;

            TravelAgent.Model.LineTheme model = new TravelAgent.Model.LineTheme();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Id"].ToString() != "")
                {
                    model.Id = int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
                }
                model.themeName= ds.Tables[0].Rows[0]["themeName"].ToString();
                model.themeTopPic = ds.Tables[0].Rows[0]["themeTopPic"].ToString();
                model.themeTopBgPic = ds.Tables[0].Rows[0]["themeTopBgPic"].ToString();
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
            strSql.Append("select Id,themeName,themeTopPic,themeTopBgPic,Sort,isLock ");
            strSql.Append(" FROM LineTheme ");
            strSql.Append(" order by Sort asc");
            return DbHelperSQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Id,themeName,themeTopPic,themeTopBgPic,Sort,isLock ");
            strSql.Append(" FROM LineTheme ");
            strSql.Append(" where "+strWhere);
            strSql.Append(" order by Sort asc");
            return DbHelperSQL.Query(strSql.ToString());
        }
    }
}
