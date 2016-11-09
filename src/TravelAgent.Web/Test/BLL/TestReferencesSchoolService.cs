using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgent.DALFactory;
using TravelAgent.IService;
using TravelAgent.Model;

namespace Test.BLL
{
    [TestClass]
    public class TestReferencesSchoolService
    {
        [TestMethod]
        public void TestByFuzzy()
        {
            IList<ReferencesSchool> list = Service.GetByFuzzyName("三");
            if(list != null)
            {
                foreach (var item in list)
                {
                    Console.WriteLine(item.FullName);
                }
            }
        }

        [TestMethod]
        public void TestBySId()
        {
            IList<ReferencesSchool> list = Service.GetBySchoolId(12);
            if(list != null)
            {
                foreach (var item in list)
                {
                    Console.WriteLine(item.FullName);
                }
            }
        }

        [TestMethod]
        public void TestByPage()
        {
            int r = 0;
            IList<ReferencesSchool> list = Service.GetBySchoolId(12,1,3,out r);
            if (list != null)
            {
                foreach (var item in list)
                {
                    Console.WriteLine(item.FullName);
                }
            }
        }

        public IReferencesSchoolService Service
         { 
            get
             {
                 return DALBuild.GetObj<IReferencesSchoolService>("BLL", "ReferencesSchoolService");
             }

            set
             {
              
             }
         }

        [TestMethod]
        public void TestGetAll()
        {
            IList<ReferencesSchool> list = Service.GetAll();
            foreach (var item in list)
            {
                Console.WriteLine(item.RName);
            }
        }
    }
}
