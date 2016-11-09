using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TravelAgent.DALSQL;
using TravelAgent.IDAL;
using System.Collections.Generic;
using System.Configuration;
using TravelAgent.DALFactory;
using TravelAgent.IService;

namespace Test.DALTest
{
    [TestClass]
    public class TestArea
    {
        [TestMethod]
        public void Add()
        {
            IAreaDao area = new AreaDao();
            IList<TravelAgent.Model.Area> list = area.Get("Pid = 510000");
            //Assert.IsNotNull(list);
            foreach (TravelAgent.Model.Area item in list)
            {
                Console.WriteLine(item.Name);
            }
        }

        [TestMethod]
        public void TestWebConfig()
        {
            Console.WriteLine(ConfigurationManager.ConnectionStrings["ConnectionSQLString"].ConnectionString);
        }

        [TestMethod]
        public void TestGetPage()
        {
            IAreaDao area = new AreaDao();
            int count = 0;
            IList<TravelAgent.Model.Area> list = area.Get("",2,10,out count);
            foreach (TravelAgent.Model.Area item in list)
            {
                Console.WriteLine(item.ShortName);
            }
        }

        [TestMethod]
        public void TestGetByPid()
        {
            IAreaDao dao = DALBuild.GetObj<IAreaDao>("Area");
            IList<TravelAgent.Model.Area> list = dao.Get("Pid=510000");
            Console.WriteLine(list[0].Name);
        }

        [TestMethod]
        public void TestBLL()
        {
            IAreaService service = DALBuild.GetObj<IAreaService>("BLL", "AreaService");
            IList<TravelAgent.Model.Area> list = service.GetByParent(510000);
            Console.WriteLine(list[0].Name);
        }

        [TestMethod]
        public void TestDal()
        { 
            IAreaDao dao = DALBuild.GetObj<IAreaDao>("Area");
            Console.WriteLine(dao.Get("Pid=510000")[0].Name);
        }
    }
}
