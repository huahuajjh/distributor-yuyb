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
    public class SchoolDao:ISchoolDao
    {
        public void Add(School s)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("insert into School(AreaId,Name,ShortName) values({0},{1},{2})", "@AreaId", "@Name", "@ShortName");

            SqlParameter[] parameters = {
                new SqlParameter("@AreaId",SqlDbType.Int,4),
                new SqlParameter("@Name",SqlDbType.Char,15),
                new SqlParameter("@ShortName",SqlDbType.Char,5),
            };

            parameters[0].Value = s.AreaId;
            parameters[1].Value = s.Name;
            parameters[2].Value = s.ShortName;

            DbHelperSQL.ExecuteSql(sb.ToString(), parameters);
        }

        public void AddRange(IList<School> ss)
        {
            if (null == ss)
            {
                throw new NullReferenceException("null obj,the parameter ss is null");
            }
            foreach (var item in ss)
            {
                this.Add(item);
            }
        }

        public int Update(School s)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("update School set AreaId={0},Name={1},ShortName={2} where Id={3}", "@AreaId", "@Name", "@ShortName","@Id");

            SqlParameter[] parameters = {
                new SqlParameter("@AreaId",SqlDbType.Int,4),
                new SqlParameter("@Name",SqlDbType.Char,15),
                new SqlParameter("@ShortName",SqlDbType.Char,5),
                new SqlParameter("@Id",SqlDbType.Int,4)
            };

            parameters[0].Value = s.AreaId;
            parameters[1].Value = s.Name;
            parameters[2].Value = s.ShortName;
            parameters[3].Value = s.Id;

            return DbHelperSQL.ExecuteSql(sb.ToString(), parameters);
        }


        public School Get(int id)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("select s.*,a.Name as AreaName from School s left join Area a on s.AreaId=a.Id where s.Id={0}",id);
            DataSet set = DbHelperSQL.Query(sb.ToString());
            IList<School> list = DbHelperSQL.DT2List<School>(set.Tables[0]);
            if(list == null || list.Count <= 0)
            { 
                return School.NullSchool();
            }
            return list[0];
        }

        public IList<School> Get(string where, params string[] parameters)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("select  Id,Name,ShortName,AreaId from School ");
            if (!string.IsNullOrEmpty(where))
            {
                sb.Append("where ").Append(where);
            }

            DataSet set = DbHelperSQL.Query(sb.ToString());
            return DbHelperSQL.DT2List<School>(set.Tables[0]);
        }

        public IList<School> Get(string where, int page_index, int page_count, out int total_page, params string[] parameters)
        {
            total_page = DbHelperSQL.Count("School");
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT Id,AreaId,Name,ShortName FROM School ");
            if (!string.IsNullOrEmpty(where))
            {
                sb.Append("where ").Append(where);
            }
            sb.AppendFormat("ORDER BY Id OFFSET {0} ROW FETCH NEXT {1} ROWS ONLY ", (page_index - 1)*page_count, page_count);
            
            DataSet ds = DbHelperSQL.Query(sb.ToString());
            if (ds == null || ds.Tables.Count <= 0)
            {
                return new List<School>() { School.NullSchool() };
            }
            return DbHelperSQL.DT2List<School>(ds.Tables[0]);
        }

        public IList<School> GetBySql(string sql)
        {
            if(string.IsNullOrEmpty(sql))
            { 
                throw new NullReferenceException("null err,parameter sql is null");
            }
            DataSet set = DbHelperSQL.Query(sql);

            if(set == null || set.Tables.Count <= 0)
            { 
                return new List<School>(){School.NullSchool()};
            }

           return DbHelperSQL.DT2List<School>(set.Tables[0]);
        }


        public void Del(int id)
        {
            //事务操作，推荐人SchoolId关联学校Id，先查询推荐人数据，删除之
            DbHelperSQL.ExecuteSql("DELETE FROM [References] WHERE SchoolId =@Id", new SqlParameter("@Id", id));

            SqlParameter[] ps = { new SqlParameter("@Id", SqlDbType.Int) };
            ps[0].Value = id;
            DbHelperSQL.ExecuteSql("DELETE FROM [School] WHERE Id=@Id", ps);
        }

        public void Del(int[] ids)
        {
            if (ids != null && ids.Length > 0)
            {
                foreach (int id in ids)
                {
                    Del(id);
                }
            }
        }
    }
}
