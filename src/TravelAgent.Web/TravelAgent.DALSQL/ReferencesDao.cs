using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using TravelAgent.IDAL;
using TravelAgent.Model;
using TravelAgent.Tool;

namespace TravelAgent.DALSQL
{
    public class ReferencesDao:IReferencesDao
    {
        public void Add(References r)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("insert into [References](Name,SchoolId,Tel) values({0},{1},{2})", "@Name", "@SchoolId", "@Tel");

            SqlParameter[] parameters = {
                new SqlParameter("@Name",SqlDbType.Char,15),
                new SqlParameter("@SchoolId",SqlDbType.Int,4),
                new SqlParameter("@Tel",SqlDbType.Char,11)
            };

            parameters[0].Value = r.Name;
            parameters[1].Value = r.SchoolId;
            parameters[2].Value = r.Tel;

            DbHelperSQL.ExecuteSql(sb.ToString(), parameters);
        }

        public void AddRange(IList<References> rs)
        {
            if (null == rs)
            {
                throw new NullReferenceException("null obj,the parameter rs is null");
            }
            foreach (var item in rs)
            {
                this.Add(item);
            }
        }

        public int Update(References r)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("update [References] set Name={0},SchoolId={1},Tel={2} where Id={3}", "@Name", "@SchoolId", "@Tel", "@Id");

            SqlParameter[] parameters = {
                new SqlParameter("@Name",SqlDbType.Char,15),
                new SqlParameter("@SchoolId",SqlDbType.Int,4),
                new SqlParameter("@Tel",SqlDbType.Char,11),
                new SqlParameter("@Id",SqlDbType.Int,4)
            };

            parameters[0].Value = r.Name;
            parameters[1].Value = r.SchoolId;
            parameters[2].Value = r.Tel;
            parameters[3].Value = r.Id;

            return DbHelperSQL.ExecuteSql(sb.ToString(), parameters);
        }

        public int Del(int id)
        {
            return DbHelperSQL.ExecuteSql("delete from [References] where Id="+id);
        }

        public References Get(int id)
        {
            throw new NotImplementedException();
        }

        public IList<References> Get(string where, params string[] parameters)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("select  Id,Name,Tel,SchoolId from [References] ");
            if (!string.IsNullOrEmpty(where))
            {
                sb.Append("where ").Append(where);
            }

            DataSet set = DbHelperSQL.Query(sb.ToString());
            return DbHelperSQL.DT2List<References>(set.Tables[0]);
        }

        public IList<References> Get(string where, int page_index, int page_count, out int total_page, params string[] parameters)
        {
            total_page = DbHelperSQL.Count("[References]");
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT Id,Name,Tel,SchoolId FROM [References] ");
            if (!string.IsNullOrEmpty(where))
            {
                sb.Append("where ").Append(where);
            }
            sb.AppendFormat("ORDER BY Id OFFSET {0} ROW FETCH NEXT {1} ROWS ONLY ", (page_index - 1) * page_count, page_count);

            DataSet ds = DbHelperSQL.Query(sb.ToString());
            return DbHelperSQL.DT2List<References>(ds.Tables[0]);
        }
        
        public References GetById(int id)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("select r.*,s.Name as SchoolName from [References] r left join School s on r.SchoolId=s.Id where r.Id={0}",id);
            DataSet set = DbHelperSQL.Query(sb.ToString());
            IList<References> list = DbHelperSQL.DT2List<References>(set.Tables[0]);
            if (list == null || list.Count <= 0)
            {
                return References.NullReferences();
            }
            return list[0];
        }

        void IReferencesDao.Del(int id)
        {            
            SqlParameter[] ps = { new SqlParameter("@Id",SqlDbType.Int)};
            ps[0].Value = id;
            DbHelperSQL.ExecuteSql("DELETE FROM [References] WHERE Id=@Id",ps);
        }

        public void Del(int[] ids)
        {
            if(ids !=null && ids.Length>0)
            {
                foreach (int id in ids)
                {
                    Del(id);
                }
            }
        }
    }
}
