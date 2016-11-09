using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgent.DALSQL;
using TravelAgent.IDAL;
using TravelAgent.Model;

namespace Test.DALTest
{
    [TestClass]
    public class TestReferencesSchoolDao
    {
        [TestMethod]
        public void TestFuzzyQuery()
        {
            IReferencesSchoolDao dao = new ReferencesSchoolDao();
            //IList<ReferencesSchool> list = dao.GetByFuzzyName("川大");
            //IList<ReferencesSchool> list = dao.GetByFuzzyName("  ");
            //IList<ReferencesSchool> list = dao.GetByFuzzyName(null);
            //IList<ReferencesSchool> list = dao.GetByFuzzyName("三");
            IList<ReferencesSchool> list = dao.GetByFuzzyName("北京大");
            if(list != null)
            { 
                ((List<ReferencesSchool>)list).ForEach(r=>{
                    Console.WriteLine(r.FullName);
                });
            }
        }

        [TestMethod]
        public void TestGetBySchId()
        {
            IReferencesSchoolDao dao = new ReferencesSchoolDao();
            IList<ReferencesSchool> list = dao.GetBySchoolId(12);
            if(list != null)
            {
                ((List<ReferencesSchool>)list).ForEach(o=>{
                    Console.WriteLine(o.FullName);
                });
            }
        }

        [TestMethod]
        public void TestGetByPage()
        {
            IReferencesSchoolDao dao = new ReferencesSchoolDao();
            int r = 0;
            IList<ReferencesSchool> list = dao.GetBySchoolId(12,1,10,out r);
            if(list != null)
            {
                ((List<ReferencesSchool>)list).ForEach(o=>{
                    Console.WriteLine(o.FullName);
                });
            }
        }

    }
}
