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
    public class TourGuideRoute : ITourGuideRoute
    {
        /// <summary>
        /// 取得最新插入的ID
        /// </summary>
        public int GetMaxID(string FieldName) {
            return DbHelperSQL.GetMaxID(FieldName, "TourGuideRoute");
        }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from TourGuideRoute");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters[0].Value = Id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(TravelAgent.Model.TourGuideRoute model) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into TourGuideRoute(");
            strSql.Append("guideid,routetime,title,contents)");
            strSql.Append(" values (");
            strSql.Append("@guideid,@routetime,@title,@contents)");
            SqlParameter[] parameters = {
					new SqlParameter("@guideid", SqlDbType.Int),
					new SqlParameter("@routetime", SqlDbType.DateTime),
					new SqlParameter("@title", SqlDbType.VarChar,500),
					new SqlParameter("@contents", SqlDbType.Text)
                  
                                        };
            parameters[0].Value = model.guideid;
            parameters[1].Value = model.routetime;
            parameters[2].Value = model.title;
            parameters[3].Value = model.contents;
           

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(TravelAgent.Model.TourGuideRoute model) {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update TourGuideRoute ");
            strSql.Append(" set guideid=@guideid,routetime=@routetime,title=@title,contents=@contents ");
            strSql.Append(" where id=@id ");
            
            SqlParameter[] parameters = {
					new SqlParameter("@guideid", SqlDbType.Int),
					new SqlParameter("@routetime", SqlDbType.DateTime),
					new SqlParameter("@title", SqlDbType.VarChar,500),
					new SqlParameter("@contents", SqlDbType.Text),
                    new SqlParameter("@id", SqlDbType.Int)
                  
                                        };
            parameters[0].Value = model.guideid;
            parameters[1].Value = model.routetime;
            parameters[2].Value = model.title;
            parameters[3].Value = model.contents;
            parameters[4].Value = model.id;


            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int Id) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from TourGuideRoute ");
            strSql.Append(" where");
            strSql.Append(" id=@id ");
            SqlParameter[] parameters = { new SqlParameter("@id", SqlDbType.Int) };
            parameters[0].Value = Id;
            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public TravelAgent.Model.TourGuideRoute GetModel(int Id) {
            TravelAgent.Model.TourGuideRoute tg = new Model.TourGuideRoute();
            string sql = string.Format("select * from TourGuideRoute where id='{0}'", Id);
            DataTable dt = DbHelperSQL.Query(sql).Tables[0];
            if (dt.Rows.Count > 0)
            {
                tg.id = Convert.ToInt32(dt.Rows[0]["id"]);
                tg.guideid = Convert.ToInt32(dt.Rows[0]["guideid"]);
                tg.title = dt.Rows[0]["title"].ToString();
                tg.routetime = Convert.ToDateTime(dt.Rows[0]["routetime"]);
                tg.contents = dt.Rows[0]["contents"].ToString();
               

            }
            return tg;
        }
        /// <summary>
        /// 取得所有游记配置列表
        /// </summary>
        /// <param name="PId">父ID</param>
        /// <param name="KId">种类ID</param>
        /// <returns></returns>
        public List<TravelAgent.Model.TourGuideRoute> GetList() {
            List<TravelAgent.Model.TourGuideRoute> dt = new List<Model.TourGuideRoute>();
            string sql = "select * from TourGuideRoute ";
            DataTable dts = DbHelperSQL.Query(sql).Tables[0];
            for (int i = 0; i < dts.Rows.Count; i++)
            {
                int sid = Convert.ToInt32(dts.Rows[i]["id"]);
                TravelAgent.Model.TourGuideRoute ty = GetModel(sid);
                dt.Add(ty);
            }
            return dt;
        }
        public List<TravelAgent.Model.TourGuideRoute> GetList(int pid) {
            List<TravelAgent.Model.TourGuideRoute> dt = new List<Model.TourGuideRoute>();
            string sql = string.Format("select * from TourGuideRoute where guideid='{0}'", pid);
            DataTable dts = DbHelperSQL.Query(sql).Tables[0];
            for (int i = 0; i < dts.Rows.Count; i++)
            {
                int sid = Convert.ToInt32(dts.Rows[i]["id"]);
                TravelAgent.Model.TourGuideRoute ty = GetModel(sid);
                dt.Add(ty);
            }

            return dt;
        }
    }
}
