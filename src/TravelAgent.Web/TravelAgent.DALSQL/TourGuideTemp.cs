using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TravelAgent.IDAL;
using System.Data;
using TravelAgent.Tool;
using System.Data.SqlClient;

namespace TravelAgent.DALSQL
{
    public class TourGuideTemp : ITourGuideTemp
    {
        public TourGuideTemp() { 
        
        }
        /// <summary>
        /// 取得最新插入的ID
        /// </summary>
        public int GetMaxID(string FieldName)
        {
            return DbHelperSQL.GetMaxID(FieldName, "TourGuideTemp");
        }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from TourGuideTemp");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters[0].Value = Id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(TravelAgent.Model.TourGuideTemp model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into TourGuideTemp(");
            strSql.Append("userid,nickname,title,createtime,imagelist,imagecount,commentcount,areamatch,areamathrow,istuijian,ispublish,tourdays,browsecount,updatetime)");
            strSql.Append(" values (");
            strSql.Append("@userid,@nickname,@title,@createtime,@imagelist,@imagecount,@commentcount,@areamatch,@areamathrow,@istuijian,0,1,0,@update_time)");
            SqlParameter[] parameters = {
					new SqlParameter("@userid", SqlDbType.VarChar,100),
					new SqlParameter("@nickname", SqlDbType.VarChar,100),
					new SqlParameter("@title", SqlDbType.VarChar,100),
					new SqlParameter("@createtime", SqlDbType.DateTime),
					new SqlParameter("@imagelist", SqlDbType.Text),
                    new SqlParameter("@imagecount",SqlDbType.Int,4),
					new SqlParameter("@commentcount", SqlDbType.Int,4),
					new SqlParameter("@areamatch", SqlDbType.Text),
                    new SqlParameter("@areamathrow",SqlDbType.Text),
                    new SqlParameter("@istuijian",SqlDbType.TinyInt),
                    new SqlParameter("@update_time",SqlDbType.DateTime)
                                        };
            parameters[0].Value = model.userid;
            parameters[1].Value = model.nickname;
            parameters[2].Value = model.title;
            parameters[3].Value = model.createtime;
            parameters[4].Value = model.imagelist;
            parameters[5].Value = model.imagecount;
            parameters[6].Value = model.commentcount;
            parameters[7].Value = model.areamatch;
            parameters[8].Value = model.areamathrow;
            parameters[9].Value = model.istuijian;
            parameters[10].Value = model.updatetime;
            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(TravelAgent.Model.TourGuideTemp model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update TourGuideTemp ");
            strSql.Append(@" set userid=@userid,
                                 nickname=@nickname,
                                 title=@title,
                                 imagelist=@imagelist,
                                 imagecount=@imagecount,
                                 commentcount=@commentcount,
                                 areamatch=@areamatch,
                                 areamathrow=@areamathrow,
                                 istuijian=@istuijian,
                                 ispublish=@ispublish,
                                 tourdays=@tourdays,
                                 browsecount=@browsecount,
                                 updatetime=@update_time,
                                 prasecount=@prasecount,
                                 ishot=@ishot,
                                 isindex=@isindex,
                                 tourrange=@tourrange,
                                 tourtype=@tourtype ");
            strSql.Append(" where");
            strSql.Append(" id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@userid", SqlDbType.VarChar,100),//0
					new SqlParameter("@nickname", SqlDbType.VarChar,100),//1
					new SqlParameter("@title", SqlDbType.VarChar,100),//2
					new SqlParameter("@imagelist", SqlDbType.Text),//3
                    new SqlParameter("@imagecount",SqlDbType.Int,11),//4
					new SqlParameter("@commentcount", SqlDbType.Int,11),//5
					new SqlParameter("@areamatch", SqlDbType.Text),//6
                    new SqlParameter("@areamathrow",SqlDbType.Text),//7
                    new SqlParameter("@istuijian",SqlDbType.TinyInt),//8
                    new SqlParameter("@ispublish",SqlDbType.TinyInt),//9
                    new SqlParameter("@tourdays",SqlDbType.TinyInt),//10
                    new SqlParameter("@browsecount",SqlDbType.Int,11),//11
                    new SqlParameter("@update_time",SqlDbType.DateTime),//12
                    new SqlParameter("@prasecount",SqlDbType.Int),//13
                    new SqlParameter("@ishot",SqlDbType.TinyInt),//14
                    new SqlParameter("@isindex",SqlDbType.TinyInt),//15
                    new SqlParameter("@tourrange",SqlDbType.TinyInt),//16
                    new SqlParameter("@tourtype",SqlDbType.TinyInt),//17
                    new SqlParameter("@id",SqlDbType.Int)//18
                                        };
            parameters[0].Value = model.userid;
            parameters[1].Value = model.nickname;
            parameters[2].Value = model.title;          ;
            parameters[3].Value = model.imagelist;
            parameters[4].Value = model.imagecount;
            parameters[5].Value = model.commentcount;
            parameters[6].Value = model.areamatch;
            parameters[7].Value = model.areamathrow;
            parameters[8].Value = model.istuijian;
            parameters[9].Value = model.ispublish;
            parameters[10].Value = model.tourdays;
            parameters[11].Value = model.browsecount;
            parameters[12].Value = model.updatetime;
            parameters[13].Value = model.prasecount;
            parameters[14].Value = model.ishot;
            parameters[15].Value = model.isindex;
            parameters[16].Value = model.tourrange;
            parameters[17].Value = model.tourtype;
            parameters[18].Value = model.Id;
            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from TourGuideTemp ");            
            strSql.Append(" where");
            strSql.Append(" id=@id ");
            SqlParameter[] parameters = { new SqlParameter("@id", SqlDbType.Int) };
                                         parameters[0].Value = Id;
           DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public TravelAgent.Model.TourGuideTemp GetModel(int Id)
        {
            TravelAgent.Model.TourGuideTemp tg = new Model.TourGuideTemp();
            string sql =string.Format( "select * from TourGuideTemp where id='{0}'",Id);
            DataTable dt = DbHelperSQL.Query(sql).Tables[0];
            if (dt.Rows.Count > 0) {
                tg.Id =Convert.ToInt32( dt.Rows[0]["id"]);
                tg.userid = dt.Rows[0]["userid"].ToString();
                tg.nickname = dt.Rows[0]["nickname"].ToString();
                tg.title = dt.Rows[0]["title"].ToString();
                tg.createtime = Convert.ToDateTime(dt.Rows[0]["createtime"]);
                tg.imagelist = dt.Rows[0]["imagelist"].ToString();
                tg.imagecount = Convert.ToInt32(dt.Rows[0]["imagecount"]);
                tg.areamatch = dt.Rows[0]["areamatch"].ToString();
                tg.areamathrow = dt.Rows[0]["areamathrow"].ToString();
                tg.istuijian = Convert.ToInt32(dt.Rows[0]["istuijian"]);
                tg.updatetime = Convert.ToDateTime(dt.Rows[0]["updatetime"]);
                tg.ispublish = Convert.ToInt32(dt.Rows[0]["ispublish"]);
                tg.tourdays = Convert.ToInt32(dt.Rows[0]["tourdays"]);
                tg.browsecount = Convert.ToInt32(dt.Rows[0]["browsecount"]);
                tg.commentcount = Convert.ToInt32(dt.Rows[0]["commentcount"]);
                tg.ishot = Convert.ToInt32(dt.Rows[0]["ishot"]);
                tg.isindex = Convert.ToInt32(dt.Rows[0]["isindex"]);
                tg.tourrange = Convert.ToInt32(dt.Rows[0]["tourrange"]);
                tg.tourtype = Convert.ToInt32(dt.Rows[0]["tourtype"]);
            }
            return tg;
        }
        public TravelAgent.Model.TourGuideTemp GetModelByUser(string Id) {
            TravelAgent.Model.TourGuideTemp tg = new Model.TourGuideTemp();
            string sql = string.Format("select * from TourGuideTemp where userid='{0}'", Id);
            DataTable dt = DbHelperSQL.Query(sql).Tables[0];
            if (dt.Rows.Count > 0)
            {
                tg.Id = Convert.ToInt32(dt.Rows[0]["id"]);
                tg.userid = dt.Rows[0]["userid"].ToString();
                tg.nickname = dt.Rows[0]["nickname"].ToString();
                tg.title = dt.Rows[0]["title"].ToString();
                tg.createtime = Convert.ToDateTime(dt.Rows[0]["createtime"]);
                tg.imagelist = dt.Rows[0]["imagelist"].ToString();
                tg.imagecount = Convert.ToInt32(dt.Rows[0]["imagecount"]);
                tg.areamatch = dt.Rows[0]["areamatch"].ToString();
                tg.areamathrow = dt.Rows[0]["areamathrow"].ToString();
                tg.istuijian = Convert.ToInt32(dt.Rows[0]["istuijian"]);
                tg.updatetime = Convert.ToDateTime(dt.Rows[0]["updatetime"]);

            }
            return tg;
        }
        /// <summary>
        /// 取得所有游记列表
        /// </summary>
        /// <param name="PId">父ID</param>
        /// <param name="KId">种类ID</param>
        /// <returns></returns>
        public List<TravelAgent.Model.TourGuideTemp> GetList()
        {
            List<TravelAgent.Model.TourGuideTemp> dt = new List<Model.TourGuideTemp>();
            string sql = "select * from TourGuideTemp ";
            DataTable dts = DbHelperSQL.Query(sql).Tables[0];
            for (int i = 0; i < dts.Rows.Count; i++)
            {
                int sid = Convert.ToInt32(dts.Rows[i]["id"]);
                TravelAgent.Model.TourGuideTemp ty = GetModel(sid);
                dt.Add(ty);
            }
            return dt;
        }
        public List<TravelAgent.Model.TourGuideTemp> GetList(int pid)
        {
            List<TravelAgent.Model.TourGuideTemp> dt = new List<Model.TourGuideTemp>();

            return dt;
        }
    }
}
