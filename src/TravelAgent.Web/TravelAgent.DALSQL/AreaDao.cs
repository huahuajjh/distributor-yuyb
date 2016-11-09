using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using TravelAgent.IDAL;
using TravelAgent.Tool;

namespace TravelAgent.DALSQL
{
    public class AreaDao:IAreaDao
    {
        public AreaDao() {}

        public void Add(Model.Area r)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("insert into Area values({0},{1},{2},{3},{4},{5},{6},{7},{8})","@Id","@Latitude","@Level","@Longitude","@Name","@Pid","@Position","@ShortName","@Sort");

            SqlParameter[] parameters = {
                new SqlParameter("@Id",SqlDbType.Int,4),
                new SqlParameter("@Latitude",SqlDbType.Char,15),
                new SqlParameter("@Level",SqlDbType.Int,4),
                new SqlParameter("@Longitude",SqlDbType.Char,15),
                new SqlParameter("@Name",SqlDbType.VarChar,50),
                new SqlParameter("@Pid",SqlDbType.Int,4),
                new SqlParameter("@Position",SqlDbType.VarChar,100),
                new SqlParameter("@ShortName",SqlDbType.VarChar,50),
                new SqlParameter("@Sort",SqlDbType.Int,4)
            };

            parameters[0].Value = r.Id;
            parameters[1].Value = r.Latitude;
            parameters[2].Value = r.Level;
            parameters[3].Value = r.Longitude;
            parameters[4].Value = r.Name;
            parameters[5].Value = r.Pid;
            parameters[6].Value = r.Position;
            parameters[7].Value = r.ShortName;
            parameters[8].Value = r.Sort;

            DbHelperSQL.ExecuteSql(sb.ToString(),parameters);
        }

        public void AddRange(IList<Model.Area> rs)
        {
            if(null == rs)
            { 
                throw new NullReferenceException("null obj,the parameter rs is null");
            }
            foreach (var item in rs)
            {
                this.Add(item);
            }
        }

        public int Update(Model.Area r)
        {
            if(null == r)
            {
                throw new NullReferenceException("null obj,the parameter rs is null");
            }

            StringBuilder sb = new StringBuilder();
            sb.Append("update Area set Name=@Name,Pid=@Pid,Latitude=@Latitude,Longitude=@Longitude,Level=@Level,Position=@Position,ShortName=@ShortName,Sort=@Sort");
            sb.Append(" where Id=@Id");

            SqlParameter[] parameters = {
                new SqlParameter("@Id",SqlDbType.Int,4),
                new SqlParameter("@Latitude",SqlDbType.Char,15),
                new SqlParameter("@Level",SqlDbType.Int,4),
                new SqlParameter("@Longitude",SqlDbType.Char,15),
                new SqlParameter("@Name",SqlDbType.VarChar,50),
                new SqlParameter("@Pid",SqlDbType.Int,4),
                new SqlParameter("@Position",SqlDbType.VarChar,100),
                new SqlParameter("@ShortName",SqlDbType.VarChar,50),
                new SqlParameter("@Sort",SqlDbType.Int,4)
            };

            parameters[0].Value = r.Id;
            parameters[1].Value = r.Latitude;
            parameters[2].Value = r.Level;
            parameters[3].Value = r.Longitude;
            parameters[4].Value = r.Name;
            parameters[5].Value = r.Pid;
            parameters[6].Value = r.Position;
            parameters[7].Value = r.ShortName;
            parameters[8].Value = r.Sort;

            return DbHelperSQL.ExecuteSql(sb.ToString(),parameters);

        }

        public int Del(int id)
        {
            throw new NotImplementedException();
        }

        public Model.Area Get(int id)
        {
            throw new NotImplementedException();
        }

        public IList<Model.Area> Get(string where, params string[] parameters)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("select Id,Level,Name,Pid,Position,ShortName,Sort from Area ");
            if(!string.IsNullOrEmpty(where))
            {
                sb.Append("where ").Append(where);
            }

            DataSet set = DbHelperSQL.Query(sb.ToString());
            return DbHelperSQL.DT2List<Model.Area>(set.Tables[0]);
        }

        public IList<Model.Area> Get(string where, int page_index, int page_count, out int total_page, params string[] parameters)
        {
            total_page = DbHelperSQL.Count("Area");
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT Id,Level,Name,Pid,Position,ShortName,Sort from Area ");
            if (!string.IsNullOrEmpty(where))
            {
                sb.Append("where ").Append(where);
            }
            sb.AppendFormat("ORDER BY Id OFFSET {0} ROW FETCH NEXT {1} ROWS ONLY ", (page_index - 1) * page_count, page_count);

            DataSet ds = DbHelperSQL.Query(sb.ToString());
            return DbHelperSQL.DT2List<Model.Area>(ds.Tables[0]);
        }

        public IList<Model.Area> Get(int id, int page_index, int page_count, out int total_page)
        {
            throw new NotImplementedException();
        }
    }
}
