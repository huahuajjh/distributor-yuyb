using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TravelAgent.IDAL;
using System.Data.SqlClient;
using System.Data;
using TravelAgent.Tool;

namespace TravelAgent.DALSQL
{
    public class TourGuideGallery : ITourGuideGallery
    {
        /// <summary>
        /// 取得最新插入的ID
        /// </summary>
        public int GetMaxID(string FieldName) {

            return DbHelperSQL.GetMaxID(FieldName, "TourGuideGallery");
        }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int Id) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from TourGuideGallery");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters[0].Value = Id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(TravelAgent.Model.TourGuideGallery model) {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into TourGuideGallery(");
            strSql.Append("guideid,image,routetime,areaname,routeid,spotid,width,height)");
            strSql.Append(" values (");
            strSql.Append("@guideid,@image,@routetime,@areaname,@routeid,@spotid,@width,@height)");
            SqlParameter[] parameters = {
					new SqlParameter("@guideid", SqlDbType.Int),
					new SqlParameter("@image", SqlDbType.VarChar,500),
					new SqlParameter("@routetime", SqlDbType.Date),
					new SqlParameter("@areaname", SqlDbType.VarChar,500),
					new SqlParameter("@routeid", SqlDbType.Int),
                    new SqlParameter("@spotid",SqlDbType.Int),
					new SqlParameter("@width", SqlDbType.Int),
					new SqlParameter("@height", SqlDbType.Int)
                  
                                        };
            parameters[0].Value = model.guideid;
            parameters[1].Value = model.image;
            parameters[2].Value = model.routetime;
            parameters[3].Value = model.areaname;
            parameters[4].Value = model.routeid;
            parameters[5].Value = model.spotid;
            parameters[6].Value = model.width;
            parameters[7].Value = model.height;
           
            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(TravelAgent.Model.TourGuideGallery model) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update TourGuideGallery ");
            strSql.Append(" set guideid=@guideid,image=@image,routetime=@routetime,areaname=@areaname,routeid=@routeid,spotid=@spotid,width=@width,height=@height ");
            strSql.Append(" where");
            strSql.Append(" id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@guideid", SqlDbType.Int),
					new SqlParameter("@image", SqlDbType.VarChar,500),
					new SqlParameter("@routetime", SqlDbType.Date),
					new SqlParameter("@areaname", SqlDbType.VarChar,500),
					new SqlParameter("@routeid", SqlDbType.Int),
                    new SqlParameter("@spotid",SqlDbType.Int),
					new SqlParameter("@width", SqlDbType.Int),
					new SqlParameter("@height", SqlDbType.Int),
                    new SqlParameter("@id",SqlDbType.Int)
                                        };
            parameters[0].Value = model.guideid;
            parameters[1].Value = model.image;
            parameters[2].Value = model.routetime;
            parameters[3].Value = model.areaname;
            parameters[4].Value = model.routeid;
            parameters[5].Value = model.spotid;
            parameters[6].Value = model.width;
            parameters[7].Value = model.height;
            parameters[8].Value = model.id;
            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int Id) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from TourGuideGallery ");
            strSql.Append(" where");
            strSql.Append(" id=@id ");
            SqlParameter[] parameters = { new SqlParameter("@id", SqlDbType.Int) };
            parameters[0].Value = Id;
            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public TravelAgent.Model.TourGuideGallery GetModel(int Id) {
            TravelAgent.Model.TourGuideGallery tg = new Model.TourGuideGallery();
            string sql = string.Format("select * from TourGuideGallery where id='{0}'",Id);
            DataTable dt = DbHelperSQL.Query(sql).Tables[0];
            if (dt.Rows.Count > 0)
            {
                tg.id = Convert.ToInt32(dt.Rows[0]["id"]);
                tg.guideid = Convert.ToInt32(dt.Rows[0]["guideid"]);
                tg.image = dt.Rows[0]["image"].ToString();
                tg.routetime = Convert.ToDateTime(dt.Rows[0]["routetime"]);
                tg.areaname = dt.Rows[0]["areaname"].ToString();
                tg.routeid = Convert.ToInt32(dt.Rows[0]["routeid"]);
                tg.spotid = Convert.ToInt32(dt.Rows[0]["spotid"]);
                tg.width = Convert.ToInt32(dt.Rows[0]["width"]);
                tg.height = Convert.ToInt32(dt.Rows[0]["height"]);
                
            }
            return tg;
        }
        /// <summary>
        /// 取得所有游记配置列表
        /// </summary>
        /// <param name="PId">父ID</param>
        /// <param name="KId">种类ID</param>
        /// <returns></returns>
        public List<TravelAgent.Model.TourGuideGallery> GetList() {
            List<TravelAgent.Model.TourGuideGallery> dt = new List<Model.TourGuideGallery>();
            string sql = "select * from TourGuideGallery ";
            DataTable dts = DbHelperSQL.Query(sql).Tables[0];
            for (int i = 0; i < dts.Rows.Count; i++)
            {
                int sid = Convert.ToInt32(dts.Rows[i]["id"]);
                TravelAgent.Model.TourGuideGallery ty = GetModel(sid);
                dt.Add(ty);
            }
            return dt;
        }
        public List<TravelAgent.Model.TourGuideGallery> GetList(int pid) {
            List<TravelAgent.Model.TourGuideGallery> dt = new List<Model.TourGuideGallery>();
            string sql = string.Format("select * from TourGuideGallery where spotid='{0}'", pid);
            DataTable dts = DbHelperSQL.Query(sql).Tables[0];
            for (int i = 0; i < dts.Rows.Count; i++) {
                int sid = Convert.ToInt32(dts.Rows[i]["id"]);
                TravelAgent.Model.TourGuideGallery ty = GetModel(sid);
                dt.Add(ty);
            }

                return dt;
        }
        public List<TravelAgent.Model.TourGuideGallery> GetListByguideid(int pid) {
            List<TravelAgent.Model.TourGuideGallery> dt = new List<Model.TourGuideGallery>();
            string sql = string.Format("select * from TourGuideGallery where guideid='{0}'", pid);
            DataTable dts = DbHelperSQL.Query(sql).Tables[0];
            for (int i = 0; i < dts.Rows.Count; i++)
            {
                int sid = Convert.ToInt32(dts.Rows[i]["id"]);
                TravelAgent.Model.TourGuideGallery ty = GetModel(sid);
                dt.Add(ty);
            }

            return dt;
        }
    }
}
