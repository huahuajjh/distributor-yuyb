using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgent.IService;
using TravelAgent.Model;

namespace Test.BLL
{
    [TestClass]
    public class TestSchool
    {
        [TestMethod]
        public void TestSchoolExport()
        {
            ISchoolService service = TravelAgent.DALFactory.DALBuild.GetObj<ISchoolService>("BLL","SchoolService");
            IList<School> list = service.GetSchoolCode();
            if(list != null)
            { 
                ((List<School>)list).ForEach(s=>{
                    Console.WriteLine(s.Id+":"+s.Name);
                });
            }
        }
    }
}
