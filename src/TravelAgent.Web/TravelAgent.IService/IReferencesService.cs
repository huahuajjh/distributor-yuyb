using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgent.Model;

namespace TravelAgent.IService
{
    public interface IReferencesService
    {
        void Add(References r);
        void Add(IList<References> list);
        void Update(References r);
        IList<References> GetByPage(int page_index,int page_count,out int total_page);
        IList<References> GetBySchoolId(int school_id);
        void UploadExcelFile(Stream file);        
        References GetById(int id);
        void Del(int id);
        void Del(int[] ids);
    }
}
