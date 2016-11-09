using TravelAgent.IService;
using System.Collections.Generic;
using TravelAgent.Model;
using System.IO;
using TravelAgent.IDAL;

namespace TravelAgent.BLL
{
    public class SchoolService:ServiceBase<ISchoolDao>,ISchoolService
    {
        public ISchoolDao Dao { 
            get
            {
                return GetDao("SchoolDao");
            } 

            set
            {
            } 
        }
        public IList<School> GetByAreaId(int area_id)
        {
            return Dao.Get("AreaId="+area_id);
        }

        public IList<School> GetByPage(int page_index, int page_count, out int total_page)
        {
            return Dao.Get("",page_index,page_count,out total_page);
        }

        public void Add(School s)
        {
            Dao.Add(s);
        }

        public void Add(IList<School> list)
        {
            Dao.AddRange(list);
        }

        public void Update(School s)
        {
            Dao.Update(s);
        }

        public void UploadExcelFile(Stream file)
        {
            
        }

        public School GetById(int id)
        {
            return Dao.Get(id);
        }


        public IList<School> GetByFuzzyName(string name)
        {
            return Dao.Get("Name like '%"+name+"%'");
        }


        public IList<School> GetSchoolCode()
        {
            return Dao.GetBySql("select Id,Name from School");
        }


        public void Del(int id)
        {
            Dao.Del(id);
        }

        public void Del(int[] ids)
        {
            Dao.Del(ids);
        }
    }
}
