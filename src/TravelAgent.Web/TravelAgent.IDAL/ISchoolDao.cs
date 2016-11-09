using System.Collections.Generic;
using TravelAgent.Model;

namespace TravelAgent.IDAL
{
    public interface ISchoolDao
    {
        void Add(School s);
        void AddRange(IList<School> ss);
        int Update(School s);
        School Get(int id);
        IList<School> Get(string where, params string[] parameters);
        IList<School> Get(string where, int page_index, int page_count, out int total_page, params string[] parameters);
        IList<School> GetBySql(string sql);
        void Del(int id);
        void Del(int[] ids);
    }
}
