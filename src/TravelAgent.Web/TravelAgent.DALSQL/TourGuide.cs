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
    public class TourGuide : ITourGuide
    {
        public TourGuide()
        {
        }
        /// <summary>
        /// 取得最新插入的ID
        /// </summary>
        public int GetMaxID(string FieldName)
        {
            return DbHelperSQL.GetMaxID(FieldName, "TourGuide");
        }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from TourGuide");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters[0].Value = Id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(TravelAgent.Model.TourGuide model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into TourGuide(");
            strSql.Append("userid,nickname,title,createtime,imagelist,imagecount,commentcount,areamatch,areamathrow,istuijian,ispublish,tourdays,browsecount,updatetime,prasecount,ishot,isindex,tourrange,tourtype,temp_id)");
            strSql.Append(" values (");
            strSql.Append(" @userid,@nickname,@title,@createtime,@imagelist,@imagecount,@commentcount,@areamatch,@areamathrow,@istuijian,@ispublish,@tourdays,@browsecount,@updatetime,@prasecount,@ishot,@isindex,@tourrange,@tourtype,@temp_id)");
            SqlParameter[] parameters = {
					new SqlParameter("@userid", SqlDbType.VarChar,100),
					new SqlParameter("@nickname", SqlDbType.VarChar,100),
					new SqlParameter("@title", SqlDbType.VarChar,100),
					new SqlParameter("@createtime", SqlDbType.DateTime),
					new SqlParameter("@imagelist", SqlDbType.Text),
                    new SqlParameter("@imagecount",SqlDbType.Int,10),
					new SqlParameter("@commentcount", SqlDbType.Int,10),
					new SqlParameter("@areamatch", SqlDbType.Text),
                    new SqlParameter("@areamathrow",SqlDbType.Text),
                    new SqlParameter("@istuijian",SqlDbType.TinyInt,4),
                    new SqlParameter("@ispublish",SqlDbType.TinyInt,4),
                    new SqlParameter("@tourdays",SqlDbType.Int,10),
                    new SqlParameter("@browsecount",SqlDbType.Int,10),
                    new SqlParameter("@updatetime",SqlDbType.DateTime),
                    new SqlParameter("@prasecount",SqlDbType.Int,10),
                    new SqlParameter("@ishot",SqlDbType.TinyInt,4),//@ishot,@isindex,@tourrange,@tourtype
                    new SqlParameter("@isindex",SqlDbType.TinyInt,4),
                    new SqlParameter("@tourrange",SqlDbType.TinyInt,4),
                    new SqlParameter("@tourtype",SqlDbType.TinyInt,4),
                    new SqlParameter("@temp_id",SqlDbType.Int,11)};
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
            parameters[10].Value = model.ispublish;
            parameters[11].Value = model.tourdays;
            parameters[12].Value = model.browsecount;
            parameters[13].Value = model.updatetime;
            parameters[14].Value = model.prasecount;
            parameters[15].Value = model.ishot;
            parameters[16].Value = model.isindex;
            parameters[17].Value = model.tourrange;
            parameters[18].Value = model.tourtype;
            parameters[19].Value = model.temp_id;
            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(TravelAgent.Model.TourGuide model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update TourGuide set ");
            strSql.Append("userid=@userid,");
            strSql.Append("nickname=@nickname,");
            strSql.Append("title=@title,");
            strSql.Append("createtime=@createtime,");
            strSql.Append("imagelist=@imagelist,");
            strSql.Append("imagecount=@imagecount,");
            strSql.Append("commentcount=@commentcount,");
            strSql.Append("areamatch=@areamatch,");
            strSql.Append("areamathrow=@areamathrow,");
            strSql.Append("istuijian=@istuijian,");
            strSql.Append("ispublish=@ispublish,");
            strSql.Append("tourdays=@tourdays,");
            strSql.Append("browsecount=@browsecount,");
            strSql.Append("updatetime=@updatetime,");
            strSql.Append("prasecount=@prasecount,");
            strSql.Append("ishot=@ishot,");
            strSql.Append("isindex=@isindex,");
            strSql.Append("tourrange=@tourrange,");
            strSql.Append("tourtype=@tourtype");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@userid", SqlDbType.VarChar,100),
					new SqlParameter("@nickname", SqlDbType.VarChar,100),
					new SqlParameter("@title", SqlDbType.VarChar,100),
					new SqlParameter("@createtime", SqlDbType.DateTime),
					new SqlParameter("@imagelist", SqlDbType.Text),
                    new SqlParameter("@imagecount",SqlDbType.Int,10),
					new SqlParameter("@commentcount", SqlDbType.Int,10),
					new SqlParameter("@areamatch", SqlDbType.Text),
                    new SqlParameter("@areamathrow",SqlDbType.Text),
                    new SqlParameter("@istuijian",SqlDbType.Int,4),
                    new SqlParameter("@ispublish",SqlDbType.Int,4),
                    new SqlParameter("@tourdays",SqlDbType.Int,10),
                    new SqlParameter("@browsecount",SqlDbType.Int,10),
                    new SqlParameter("@updatetime",SqlDbType.DateTime),
                    new SqlParameter("@prasecount",SqlDbType.Int,10),
                    new SqlParameter("@ishot",SqlDbType.Int,4),
                    new SqlParameter("@isindex",SqlDbType.Int,4),
                    new SqlParameter("@tourrange",SqlDbType.Int,4),
                    new SqlParameter("@tourtype",SqlDbType.Int,4),
                                        new SqlParameter("@Id",SqlDbType.Int,10)};
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
            parameters[10].Value = model.ispublish;
            parameters[11].Value = model.tourdays;
            parameters[12].Value = model.browsecount;
            parameters[13].Value = model.updatetime;
            parameters[14].Value = model.prasecount;
            parameters[15].Value = model.ishot;
            parameters[16].Value = model.isindex;
            parameters[17].Value = model.tourrange;
            parameters[18].Value = model.tourtype;
            parameters[19].Value = model.Id;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from TourGuide ");
            strSql.Append(" where id like '" + Id + "' ");

            DbHelperSQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public TravelAgent.Model.TourGuide GetModel(int Id)
        {
            TravelAgent.Model.TourGuide tg = null;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from TourGuide ");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters[0].Value = Id;
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                DataRow dr = dt.Rows[0];
                tg = new Model.TourGuide();
                tg.Id = Convert.ToInt32(dt.Rows[0]["Id"]);
                tg.userid = dt.Rows[0]["userid"].ToString();
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
                tg.ispublish = Convert.ToInt32(dt.Rows[0]["ispublish"]);
                tg.tourdays = Convert.ToInt32(dt.Rows[0]["tourdays"]);
                tg.browsecount = Convert.ToInt32(dt.Rows[0]["browsecount"]);
                tg.commentcount = Convert.ToInt32(dt.Rows[0]["commentcount"]);
                tg.ishot = Convert.ToInt32(dt.Rows[0]["ishot"]);
                tg.isindex = Convert.ToInt32(dt.Rows[0]["isindex"]);
                tg.tourrange = Convert.ToInt32(dt.Rows[0]["tourrange"]);
                tg.tourtype = Convert.ToInt32(dt.Rows[0]["tourtype"]);
                tg.temp_id = Convert.ToInt32(dt.Rows[0]["temp_id"]);
            }
            return tg;
        }
        /// <summary>
        /// 取得所有游记列表
        /// </summary>
        /// <param name="PId">父ID</param>
        /// <param name="KId">种类ID</param>
        /// <returns></returns>
        public List<TravelAgent.Model.TourGuide> GetList()
        {
            List<TravelAgent.Model.TourGuide> dt = new List<Model.TourGuide>();
            string sql = "select * from TourGuide ";
            DataTable dts = DbHelperSQL.Query(sql).Tables[0];
            for (int i = 0; i < dts.Rows.Count; i++)
            {
                int sid = Convert.ToInt32(dts.Rows[i]["id"]);
                TravelAgent.Model.TourGuide ty = GetModel(sid);
                dt.Add(ty);
            }
            return dt;
        }
        public List<TravelAgent.Model.TourGuide> GetListPublis()
        {
            List<TravelAgent.Model.TourGuide> dt = new List<Model.TourGuide>();
            string sql = "select * from TourGuide where ispublish=1 order by id desc";
            DataTable dts = DbHelperSQL.Query(sql).Tables[0];
            for (int i = 0; i < dts.Rows.Count; i++)
            {
                int sid = Convert.ToInt32(dts.Rows[i]["id"]);
                TravelAgent.Model.TourGuide ty = GetModel(sid);
                dt.Add(ty);
            }
            return dt;
        }
        public DataSet GetPageList(int pageSize, int currentPage, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            if (currentPage > 0)
            {
                int topNum = pageSize * currentPage;
                strSql.Append("select top " + pageSize + " * from TourGuide");
                strSql.Append(" where Id not in(select top " + topNum + " Id from TourGuide");
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
                strSql.Append("select top " + pageSize + " * from TourGuide");
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
