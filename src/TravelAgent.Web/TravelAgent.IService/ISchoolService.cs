using System.Collections.Generic;
using System.IO;
using TravelAgent.Model;

namespace TravelAgent.IService
{
    public interface ISchoolService
    {
        IList<School> GetByAreaId(int area_id);
        IList<School> GetByPage(int page_index,int page_count,out int total_page);
        School GetById(int id);
        void Add(School s);
        void Add(IList<School> list);
        void Update(School s);
        void UploadExcelFile(Stream file);
        IList<School> GetByFuzzyName(string name);
        IList<School> GetSchoolCode();
        void Del(int id);
        void Del(int[] id);
    }
}
