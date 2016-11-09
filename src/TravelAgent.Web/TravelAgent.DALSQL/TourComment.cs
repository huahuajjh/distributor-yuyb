using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TravelAgent.IDAL;
using TravelAgent.Tool;
using System.Data.SqlClient;
using System.Data;

namespace TravelAgent.DALSQL
{
    public class TourComment : ITourComment
    {
        public TourComment() { 
        
        }
        public int GetMaxID(string FieldName)
        {
            return DbHelperSQL.GetMaxID(FieldName, "TourComment");
        }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from TourComment");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters[0].Value = Id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(TravelAgent.Model.TourComment model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into TourComment(");
            strSql.Append(" contents,comment_type,comment_rel_id,user_id,nickname,create_time)");
            strSql.Append(" values (");
            strSql.Append("  @contents,@comment_type,@comment_rel_id,@user_id,@nickname,@create_time)");
            SqlParameter[] parameters = {
					new SqlParameter("@contents", SqlDbType.VarChar,100),
					new SqlParameter("@comment_type", SqlDbType.Int,11),
					new SqlParameter("@comment_rel_id", SqlDbType.Int,11),
					new SqlParameter("@user_id", SqlDbType.Int,11),
					new SqlParameter("@nickname", SqlDbType.VarChar,100),
                    new SqlParameter("@create_time",SqlDbType.DateTime)};
					
            parameters[0].Value = model.contents;
            parameters[1].Value = model.comment_type;
            parameters[2].Value = model.comment_rel_id;
            parameters[3].Value = model.user_id;
            parameters[4].Value = model.nickname;
            parameters[5].Value = model.create_time;
           
            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(TravelAgent.Model.TourComment model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update TourComment set ");
            strSql.Append(" contents=@contents,comment_type=@comment_type,comment_rel_id=@comment_rel_id,user_id=@user_id,nickname=@nickname,create_time=@create_time");

            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@contents", SqlDbType.VarChar,100),
					new SqlParameter("@comment_type", SqlDbType.Int,11),
					new SqlParameter("@comment_rel_id", SqlDbType.Int,11),
					new SqlParameter("@user_id", SqlDbType.Int,11),
					new SqlParameter("@nickname", SqlDbType.VarChar,100),
                    new SqlParameter("@create_time",SqlDbType.DateTime),
                    new SqlParameter("@id",SqlDbType.Int,10)
                                        };
            parameters[0].Value = model.contents;
            parameters[1].Value = model.comment_type;
            parameters[2].Value = model.comment_rel_id;
            parameters[3].Value = model.user_id;
            parameters[4].Value = model.nickname;
            parameters[5].Value = model.create_time;
            parameters[6].Value = model.id;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from TourComment ");
            strSql.Append(" where id = '" + Id + "' ");

            DbHelperSQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public TravelAgent.Model.TourComment GetModel(int Id)
        {
            TravelAgent.Model.TourComment tg = new Model.TourComment();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from TourComment ");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters[0].Value = Id;
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables.Count >= 0)
            {
                DataTable dt = ds.Tables[0];
                DataRow dr = dt.Rows[0];
                tg.id = Convert.ToInt32(dt.Rows[0]["Id"]);
                tg.contents = dt.Rows[0]["contents"].ToString();
                tg.comment_type = Convert.ToInt32(dt.Rows[0]["comment_type"]);
                tg.comment_rel_id = Convert.ToInt32(dt.Rows[0]["comment_rel_id"]);
                tg.user_id = Convert.ToInt32(dt.Rows[0]["user_id"]);
                tg.nickname = dt.Rows[0]["nickname"].ToString();
                tg.create_time =Convert.ToDateTime( dt.Rows[0]["create_time"]);
            }
            return tg;
        }
        /// <summary>
        /// 取得所有游记列表
        /// </summary>
        /// <param name="PId">父ID</param>
        /// <param name="KId">种类ID</param>
        /// <returns></returns>
        public List<TravelAgent.Model.TourComment> GetList()
        {
            List<TravelAgent.Model.TourComment> dt = new List<Model.TourComment>();
            string sql = "select * from TourComment ";
            DataTable dts = DbHelperSQL.Query(sql).Tables[0];
            for (int i = 0; i < dts.Rows.Count; i++)
            {
                int sid = Convert.ToInt32(dts.Rows[i]["id"]);
                TravelAgent.Model.TourComment ty = GetModel(sid);
                dt.Add(ty);
            }
            return dt;
        }
        public List<TravelAgent.Model.TourComment> GetList(int comment_rel_id)
        {
            List<TravelAgent.Model.TourComment> dt = new List<Model.TourComment>();
            string sql =string.Format( "select * from TourComment where comment_rel_id='{0}' order by id desc ",comment_rel_id);
            DataTable dts = DbHelperSQL.Query(sql).Tables[0];
            for (int i = 0; i < dts.Rows.Count; i++)
            {
                int sid = Convert.ToInt32(dts.Rows[i]["id"]);
                TravelAgent.Model.TourComment ty = GetModel(sid);
                dt.Add(ty);
            }
            return dt;
        }
    }
}
