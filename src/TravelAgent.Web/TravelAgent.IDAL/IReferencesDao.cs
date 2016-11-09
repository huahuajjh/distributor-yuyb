using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TravelAgent.Model;

namespace TravelAgent.IDAL
{
    public interface IReferencesDao
    {
        void Add(References r);
        void AddRange(IList<References> rs);
        int Update(References r);
        References Get(int id);
        IList<References> Get(string where,params string[] parameters);
        IList<References> Get(string where,int page_index,int page_count,out int total_page, params string[] parameters);
        References GetById(int id);
        void Del(int id);
        void Del(int[] ids);
    }
}
