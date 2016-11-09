using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgent.IDAL;
using TravelAgent.IService;

namespace TravelAgent.BLL
{
    public class ReferencesSchoolService:ServiceBase<IReferencesSchoolDao>,IReferencesSchoolService
    {
        public IReferencesSchoolDao Dao
        {
            get
            {
                return GetDao("ReferencesSchoolDao");
            }

            set
            {
            }
        }

        public IList<Model.ReferencesSchool> GetByFuzzyName(string fuzzy)
        {
            return Dao.GetByFuzzyName(fuzzy);
        }

        public IList<Model.ReferencesSchool> GetBySchoolId(int schId)
        {
            return Dao.GetBySchoolId(schId);
        }

        public IList<Model.ReferencesSchool> GetBySchoolId(int schId, int index, int count, out int total)
        {
            return Dao.GetBySchoolId(schId,index,count,out total);
        }


        public IList<Model.ReferencesSchool> GetAll()
        {
            return Dao.GetAll();
        }
    }
}
