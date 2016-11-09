using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgent.IDAL;
using TravelAgent.IService;

namespace TravelAgent.BLL
{
    class ReferencesService:ServiceBase<IReferencesDao>,IReferencesService
    {
        public IReferencesDao Dao
        {
            get
            {
                return GetDao("ReferencesDao");
            }

            set
            {
            }
        }
        public void Add(Model.References r)
        {
            Dao.Add(r);
        }

        public void Add(IList<Model.References> list)
        {
            Dao.AddRange(list);
        }

        public void Update(Model.References r)
        {
            Dao.Update(r);
        }

        public IList<Model.References> GetByPage(int page_index, int page_count, out int total_page)
        {
            return Dao.Get("",page_index,page_count,out total_page);
        }

        public IList<Model.References> GetBySchoolId(int school_id)
        {
            return Dao.Get("SchoolId="+school_id);
        }

        public void UploadExcelFile(System.IO.Stream file)
        {
            
        }
        
        public Model.References GetById(int id)
        {
            return Dao.GetById(id);
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
