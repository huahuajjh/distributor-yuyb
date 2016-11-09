using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgent.BLL;
using TravelAgent.DALFactory;
using TravelAgent.IService;
using TravelAgent.Model;

namespace Test.BLL
{
    [TestClass]
    public class BLLTest
    {
        [TestMethod]
        public void TestRS()
        {
            IQueryReferencesService service = DALBuild.GetObj<IQueryReferencesService>("BLL", "QueryReferencesService");
            IList<References> list = service.GetRefsBySchoolName("四川大学");
            ((List<References>)list).ForEach(o=>{
                Console.WriteLine(o.Name);
            });
        }

        [TestMethod]
        public void TestGetById()
        {
            IReferencesService service = DALBuild.GetObj<IReferencesService>("BLL", "ReferencesService");
            Console.WriteLine(service.GetById(2).SchoolName);
        }
    }
}
