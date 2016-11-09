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
    public class LineConsult:ILineConsult
    {
        /// <summary>
        /// 取得最新插入的ID
        /// </summary>
        public int GetMaxID(string FieldName)
        {
            return DbHelperSQL.GetMaxID(FieldName, "LineConsult");
        }
        /// <summary>
        /// 返回长查询数据总数 （分页用到）
        /// </summary>
        public int GetCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(*) as H ");
            strSql.Append(" from LineConsult as a,Line as b");
            strSql.Append(" where a.LineId=b.Id");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" and " + strWhere);
            }
            return Convert.ToInt32(DbHelperSQL.GetSingle(strSql.ToString()));
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(TravelAgent.Model.LineConsult model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into LineConsult(");
            strSql.Append("LineId,LinkTel,LinkEmail,ConsultContent,ConsultDate)");
            strSql.Append(" values (");
            strSql.Append("@LineId,@LinkTel,@LinkEmail,@ConsultContent,@ConsultDate)");
            SqlParameter[] parameters = {
					new SqlParameter("@LineId", SqlDbType.Int),
                    new SqlParameter("@LinkTel", SqlDbType.VarChar),
                    new SqlParameter("@LinkEmail", SqlDbType.VarChar),
					new SqlParameter("@ConsultContent", SqlDbType.VarChar),
                      new SqlParameter("@ConsultDate", SqlDbType.DateTime)};
            parameters[0].Value = model.LineId;
            parameters[1].Value = model.LinkTel;
            parameters[2].Value = model.LinkEmail;
            parameters[3].Value = model.ConsultContent;
            parameters[4].Value = model.ConsultDate;
            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 删除数据
        /// </summary>
        public int Delete(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from LineConsult ");
            strSql.Append(" where Id=" + Id);

            return DbHelperSQL.ExecuteSql(strSql.ToString());
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public TravelAgent.Model.LineConsult GetModel(int Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from LineConsult ");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters[0].Value = Id;

            TravelAgent.Model.LineConsult model = new TravelAgent.Model.LineConsult();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Id"].ToString() != "")
                {
                    model.Id = int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
                }
                model.LineId = int.Parse(ds.Tables[0].Rows[0]["LineId"].ToString());
                model.LinkTel = ds.Tables[0].Rows[0]["LinkTel"].ToString();
                model.LinkEmail = ds.Tables[0].Rows[0]["LinkEmail"].ToString();
                model.ConsultContent = ds.Tables[0].Rows[0]["ConsultContent"].ToString();
                model.ConsultDate = Convert.ToDateTime(ds.Tables[0].Rows[0]["ConsultDate"].ToString());
                model.ReplyContent = ds.Tables[0].Rows[0]["ReplyContent"].ToString();
                if (!ds.Tables[0].Rows[0]["ReplyUserId"].ToString().Equals(""))
                {
                    model.ReplyUserId = int.Parse(ds.Tables[0].Rows[0]["ReplyUserId"].ToString());
                }
                if (!ds.Tables[0].Rows[0]["ReplyDate"].ToString().Equals(""))
                {
                    model.ReplyDate = Convert.ToDateTime(ds.Tables[0].Rows[0]["ReplyDate"].ToString());
                }
                
                model.IsReply = int.Parse(ds.Tables[0].Rows[0]["IsReply"].ToString());
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
            strSql.Append(" FROM LineConsult ");
            strSql.Append(" order by ConsultDate desc");
            return DbHelperSQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM LineConsult ");
            strSql.Append(" where " + strWhere);
            strSql.Append(" order by ConsultDate desc");
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
                strSql.Append("select top " + pageSize + " a.*,b.lineName from LineConsult a,Line as b ");
                strSql.Append(" where a.LineId=b.Id and a.Id not in(select top " + topNum + " a.Id from LineConsult as a,Line as b ");
                if (strWhere.Trim() != "")
                {
                    strSql.Append(" where a.LineId=b.Id and " + strWhere);
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
                strSql.Append("select top " + pageSize + " a.*,b.lineName from LineConsult a,Line as b ");
                strSql.Append(" where a.LineId=b.Id");
                if (strWhere.Trim() != "")
                {
                    strSql.Append(" and " + strWhere);
                }
                strSql.Append(" order by " + filedOrder);
            }

            return DbHelperSQL.Query(strSql.ToString());
        }
    }
}
