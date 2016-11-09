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
    public class TourGuideSpot : ITourGuideSpot
    {
        /// <summary>
        /// 取得最新插入的ID
        /// </summary>
        public int GetMaxID(string FieldName) {
            return DbHelperSQL.GetMaxID(FieldName, "TourGuideSpot");
        }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int Id) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from TourGuideSpot");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters[0].Value = Id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(TravelAgent.Model.TourGuideSpot model) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into TourGuideSpot(");
            strSql.Append("guideid,areaname,routetime,gallery,sort,routeid)");
            strSql.Append(" values (");
            strSql.Append("@guideid,@areaname,@routetime,@gallery,@sort,@routeid)");
            SqlParameter[] parameters = {
					new SqlParameter("@guideid", SqlDbType.Int),
					new SqlParameter("@areaname", SqlDbType.VarChar,500),
					new SqlParameter("@routetime", SqlDbType.DateTime),
					new SqlParameter("@gallery", SqlDbType.VarChar,500),
                    new SqlParameter("@sort", SqlDbType.Int),
                    new SqlParameter("@routeid", SqlDbType.Int)
                  
                                        };
            parameters[0].Value = model.guideid;
            parameters[1].Value = model.areaname;
            parameters[2].Value = model.routetime;
            parameters[3].Value = model.gallery;
            parameters[4].Value = model.sort;
            parameters[5].Value = model.routeid;


            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(TravelAgent.Model.TourGuideSpot model) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update TourGuideSpot ");
            strSql.Append(" set guideid=@guideid,areaname=@areaname,routetime=@routetime,gallery=@gallery,sort=@sort,routeid=@routeid)");
            strSql.Append(" where id=@id ");

            SqlParameter[] parameters = {
					new SqlParameter("@guideid", SqlDbType.Int),
					new SqlParameter("@areaname", SqlDbType.VarChar,500),
					new SqlParameter("@routetime", SqlDbType.DateTime),
					new SqlParameter("@gallery", SqlDbType.VarChar,500),
                    new SqlParameter("@sort", SqlDbType.Int),
                    new SqlParameter("@routeid", SqlDbType.Int),
                    new SqlParameter("@id", SqlDbType.Int)
                  
                                        };
            parameters[0].Value = model.guideid;
            parameters[1].Value = model.areaname;
            parameters[2].Value = model.routetime;
            parameters[3].Value = model.gallery;
            parameters[4].Value = model.sort;
            parameters[5].Value = model.routeid;
            parameters[6].Value = model.id;


            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int Id) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from TourGuideSpot ");
            strSql.Append(" where");
            strSql.Append(" id=@id ");
            SqlParameter[] parameters = { new SqlParameter("@id", SqlDbType.Int) };
            parameters[0].Value = Id;
            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public TravelAgent.Model.TourGuideSpot GetModel(int Id) {
            TravelAgent.Model.TourGuideSpot tg = new Model.TourGuideSpot();
            string sql = string.Format("select * from TourGuideSpot where id='{0}'", Id);
            DataTable dt = DbHelperSQL.Query(sql).Tables[0];
            if (dt.Rows.Count > 0)
            {
                tg.id = Convert.ToInt32(dt.Rows[0]["id"]);
                tg.guideid = Convert.ToInt32(dt.Rows[0]["guideid"]);
                tg.areaname = dt.Rows[0]["areaname"].ToString();
                tg.routetime = Convert.ToDateTime(dt.Rows[0]["routetime"]);
                tg.gallery = dt.Rows[0]["gallery"].ToString();
                tg.sort =Convert.ToInt32( dt.Rows[0]["sort"]);
                tg.routeid =Convert.ToInt32( dt.Rows[0]["routeid"]);


            }
            return tg;
        }
        /// <summary>
        /// 取得所有游记配置列表
        /// </summary>
        /// <param name="PId">父ID</param>
        /// <param name="KId">种类ID</param>
        /// <returns></returns>
        public List<TravelAgent.Model.TourGuideSpot> GetList() {
            List<TravelAgent.Model.TourGuideSpot> dt = new List<Model.TourGuideSpot>();
            string sql = "select * from TourGuideSpot ";
            DataTable dts = DbHelperSQL.Query(sql).Tables[0];
            for (int i = 0; i < dts.Rows.Count; i++)
            {
                int sid = Convert.ToInt32(dts.Rows[i]["id"]);
                TravelAgent.Model.TourGuideSpot ty = GetModel(sid);
                dt.Add(ty);
            }
            return dt;
        }
        public List<TravelAgent.Model.TourGuideSpot> GetList(int pid) {
            List<TravelAgent.Model.TourGuideSpot> dt = new List<Model.TourGuideSpot>();
            string sql = string.Format("select * from TourGuideSpot where routeid='{0}'", pid);
            DataTable dts = DbHelperSQL.Query(sql).Tables[0];
            for (int i = 0; i < dts.Rows.Count; i++)
            {
                int sid = Convert.ToInt32(dts.Rows[i]["id"]);
                TravelAgent.Model.TourGuideSpot ty = GetModel(sid);
                dt.Add(ty);
            }

            return dt;
        }
    }
}
