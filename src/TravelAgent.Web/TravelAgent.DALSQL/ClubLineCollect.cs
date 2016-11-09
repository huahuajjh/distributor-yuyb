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
    public class ClubLineCollect:IClubLineCollect
    {
        /// <summary>
        /// 返回长查询数据总数 （分页用到）
        /// </summary>
        public int GetCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(*) as H ");
            strSql.Append(" from ClubLineCollect ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return Convert.ToInt32(DbHelperSQL.GetSingle(strSql.ToString()));
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(TravelAgent.Model.ClubLineCollect model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into ClubLineCollect(");
            strSql.Append("LineId,ClubId,CollectDate)");
            strSql.Append(" values (");
            strSql.Append("@LineId,@ClubId,@CollectDate)");
            SqlParameter[] parameters = {
					new SqlParameter("@LineId", SqlDbType.Int),
					new SqlParameter("@ClubId", SqlDbType.Int),
					new SqlParameter("@CollectDate", SqlDbType.DateTime)};
            parameters[0].Value = model.LineId;
            parameters[1].Value = model.ClubId;
            parameters[2].Value = model.CollectDate;
            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 删除数据
        /// </summary>
        public int Delete(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from ClubLineCollect ");
            strSql.Append(" where Id=" + Id);

            return DbHelperSQL.ExecuteSql(strSql.ToString());
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
                strSql.Append("select top " + pageSize + " * from ClubLineCollect");
                strSql.Append(" where Id not in(select top " + topNum + " Id from ClubLineCollect");
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
                strSql.Append("select top " + pageSize + " * from ClubLineCollect");
                if (strWhere.Trim() != "")
                {
                    strSql.Append(" where " + strWhere);
                }
                strSql.Append(" order by " + filedOrder);
            }

            return DbHelperSQL.Query(strSql.ToString());
        }
    }
}
