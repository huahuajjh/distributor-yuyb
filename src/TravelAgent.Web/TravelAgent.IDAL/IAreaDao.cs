using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TravelAgent.Model;

namespace TravelAgent.IDAL
{
    public interface IAreaDao
    {
        void Add(Area r);
        void AddRange(IList<Area> rs);
        int Update(Area r);
        int Del(int id);
        Area Get(int id);
        IList<Area> Get(string where, params string[] parameters);
        IList<Area> Get(string where, int page_index, int page_count, out int total_page, params string[] parameters);
        IList<Area> Get(int id, int page_index, int page_count, out int total_page);
    }
}
