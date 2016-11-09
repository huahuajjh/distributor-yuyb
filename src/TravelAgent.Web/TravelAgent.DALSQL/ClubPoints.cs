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
    public class ClubPoints:IClubPoints
    {
        #region  成员方法
        /// <summary>
        /// 取得最新插入的ID
        /// </summary>
        public int GetMaxID(string FieldName)
        {
            return DbHelperSQL.GetMaxID(FieldName, "ClubPoints");
        }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from ClubPoints");
            strSql.Append(" where id=@Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters[0].Value = Id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 返回长查询数据总数 （分页用到）
        /// </summary>
        public int GetCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(*) as H ");
            strSql.Append(" from ClubPoints ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return Convert.ToInt32(DbHelperSQL.GetSingle(strSql.ToString()));
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(TravelAgent.Model.ClubPoints model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into ClubPoints(");
            strSql.Append("clubid,Content,points,remark,pType,adddate)");
            strSql.Append(" values (");
            strSql.Append("@clubid,@Content,@points,@remark,@pType,@adddate)");
            SqlParameter[] parameters = {
					new SqlParameter("@clubid", SqlDbType.Int),
					new SqlParameter("@Content", SqlDbType.VarChar),
					new SqlParameter("@points", SqlDbType.Int),
					new SqlParameter("@remark", SqlDbType.VarChar),
                                          new SqlParameter("@pType", SqlDbType.Int),
                                          new SqlParameter("@adddate", SqlDbType.DateTime)};
            parameters[0].Value = model.clubid;
            parameters[1].Value = model.Content;
            parameters[2].Value = model.points;
            parameters[3].Value = model.remark;
            parameters[4].Value = model.pType;
            parameters[5].Value = model.adddate;
            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from ClubPoints ");
            strSql.Append(" where id=@Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters[0].Value = Id;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public TravelAgent.Model.ClubPoints GetModel(int Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from ClubPoints ");
            strSql.Append(" where id=@Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters[0].Value = Id;

            TravelAgent.Model.ClubPoints model = new TravelAgent.Model.ClubPoints();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    model.id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["clubid"].ToString() != "")
                {
                    model.clubid = int.Parse(ds.Tables[0].Rows[0]["clubid"].ToString());
                }

                model.Content = ds.Tables[0].Rows[0]["Content"].ToString();
                if (ds.Tables[0].Rows[0]["points"].ToString() != "")
                {
                    model.points = int.Parse(ds.Tables[0].Rows[0]["points"].ToString());
                }
                model.remark = ds.Tables[0].Rows[0]["remark"].ToString();
                if (ds.Tables[0].Rows[0]["pType"].ToString() != "")
                {
                    model.pType = int.Parse(ds.Tables[0].Rows[0]["pType"].ToString());
                }
                model.adddate = DateTime.Parse(ds.Tables[0].Rows[0]["adddate"].ToString());
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
            strSql.Append(" * ");
            strSql.Append(" FROM ClubPoints ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 获得查询分页数据
        /// </summary>
        public DataSet GetPageList(int pageSize, int currentPage, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            if (currentPage > 0)
            {
                int topNum = pageSize * currentPage;
                strSql.Append("select top " + pageSize + " * from ClubPoints");
                strSql.Append(" where Id not in(select top " + topNum + " id from ClubPoints");
                if (strWhere.Trim() != "")
                {
                    strSql.Append(" where " + strWhere);
                }
                strSql.Append(" order by " + filedOrder + ")");
                if (strWhere.Trim() != "")
                {
                    strSql.Append(" and " + strWhere);
                }
                //5%1+a+s+p+x
                strSql.Append(" order by " + filedOrder);
            }
            else
            {
                strSql.Append("select top " + pageSize + " * from ClubPoints");
                if (strWhere.Trim() != "")
                {
                    strSql.Append(" where " + strWhere);
                }
                strSql.Append(" order by " + filedOrder);
            }

            return DbHelperSQL.Query(strSql.ToString());
        }

        #endregion  成员方法
    }
}
