using System;
using System.Collections.Generic;
using TravelAgent.IDAL;
using TravelAgent.IService;
using TravelAgent.Model;

namespace TravelAgent.BLL
{
    public class QueryReferencesService:ServiceBase<Int32>,IQueryReferencesService
    {
        public IList<Model.References> GetRefsBySchoolName(string school_name)
        {
            ISchoolDao schDao = GetDao<ISchoolDao>("SchoolDao");
            IReferencesDao refsDao = GetDao<IReferencesDao>("ReferencesDao");

            IList<School> schs = schDao.Get(string.Format("Name like '%{0}%'",school_name));

            if(schs == null || schs.Count <= 0)
            {
                return new List<References>();
            }

            string ids =  "";
            ((List<School>)schs).ForEach(s=>{
                if(string.IsNullOrEmpty(ids))
                { 
                    ids += s.Id;
                }
                else
                { 
                    ids += (","+s.Id);
                }
            });

            IList<References> refs = refsDao.Get(string.Format("SchoolId in({0})",ids));
            return refs;
        }
    }
}
