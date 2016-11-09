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
    public class VisaBrand:IVisaBrand
    {
        /// <summary>
        /// 取得最新插入的ID
        /// </summary>
        public int GetMaxID(string FieldName)
        {
            return DbHelperSQL.GetMaxID(FieldName, "VisaBrand");
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(TravelAgent.Model.VisaBrand model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into VisaBrand(");
            strSql.Append("PicUrl,Title,SubTitle,Sort,isLock,Type)");
            strSql.Append(" values (");
            strSql.Append("@PicUrl,@Title,@SubTitle,@Sort,@isLock,@Type)");
            SqlParameter[] parameters = {
					new SqlParameter("@PicUrl", SqlDbType.NVarChar,200),
                    new SqlParameter("@Title", SqlDbType.VarChar,50),
                    new SqlParameter("@SubTitle", SqlDbType.VarChar,50),
					new SqlParameter("@Sort", SqlDbType.Int,4),
					new SqlParameter("@isLock", SqlDbType.Int,4),
                    new SqlParameter("@Type", SqlDbType.Int,4)};
            parameters[0].Value = model.PicUrl;
            parameters[1].Value = model.Title;
            parameters[2].Value = model.SubTitle;
            parameters[3].Value = model.Sort;
            parameters[4].Value = model.isLock;
            parameters[5].Value = model.Type;
            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(TravelAgent.Model.VisaBrand model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update VisaBrand set ");
            strSql.Append("PicUrl=@PicUrl,");
            strSql.Append("Title=@Title,");
            strSql.Append("SubTitle=@SubTitle,");
            strSql.Append("Sort=@Sort,");
            strSql.Append("isLock=@isLock,");
            strSql.Append("Type=@Type");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@PicUrl", SqlDbType.NVarChar,200),
                    new SqlParameter("@Title", SqlDbType.VarChar,50),
                    new SqlParameter("@SubTitle", SqlDbType.VarChar,50),
					new SqlParameter("@Sort", SqlDbType.Int,4),
                    new SqlParameter("@isLock", SqlDbType.Int,4),
                    new SqlParameter("@Type", SqlDbType.Int,4),
                    new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters[0].Value = model.PicUrl;
            parameters[1].Value = model.Title;
            parameters[2].Value = model.SubTitle;
            parameters[3].Value = model.Sort;
            parameters[4].Value = model.isLock;
            parameters[5].Value = model.Type;
            parameters[6].Value = model.Id;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 删除数据
        /// </summary>
        public void Delete(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from VisaBrand ");
            strSql.Append(" where Id=" + Id);

            DbHelperSQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public TravelAgent.Model.VisaBrand GetModel(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Id,PicUrl,Title,SubTitle,Sort,isLock,Type from VisaBrand ");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters[0].Value = Id;

            TravelAgent.Model.VisaBrand model = new TravelAgent.Model.VisaBrand();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Id"].ToString() != "")
                {
                    model.Id = int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
                }
                model.PicUrl= ds.Tables[0].Rows[0]["PicUrl"].ToString();
                model.Title = ds.Tables[0].Rows[0]["Title"].ToString();
                model.SubTitle = ds.Tables[0].Rows[0]["SubTitle"].ToString();
                if (ds.Tables[0].Rows[0]["Sort"].ToString() != "")
                {
                    model.Sort = int.Parse(ds.Tables[0].Rows[0]["Sort"].ToString());
                }
                if (ds.Tables[0].Rows[0]["isLock"].ToString() != "")
                {
                    model.isLock = int.Parse(ds.Tables[0].Rows[0]["isLock"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Type"].ToString() != "")
                {
                    model.Type = int.Parse(ds.Tables[0].Rows[0]["Type"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" Id,PicUrl,Title,SubTitle,Sort,isLock,Type ");
            strSql.Append(" FROM VisaBrand ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }
    }
}
