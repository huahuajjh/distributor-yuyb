using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using TravelAgent.DALSQL;
using TravelAgent.IDAL;
using TravelAgent.Model;

namespace Test.DALTest
{
    [TestClass]
    public class TestSchool
    {
        [TestMethod]
        public void TestAdd()
        { 
            ISchoolDao dao = new SchoolDao();
            School s = new School(){ ShortName="st", Name="s", AreaId=123};
            dao.Add(s);
        }

        [TestMethod]        
        public void TestGet()
        {
            ISchoolDao dao = new SchoolDao();
            IList<School> list = dao.Get("");
            foreach (School item in list)
            {
                Console.WriteLine(item.Name);
            }
        }

        [TestMethod]
        public void TestCount()
        {
            Console.WriteLine(TravelAgent.Tool.DbHelperSQL.Count("Area"));
        }

        [TestMethod]
        public void TestGetById()
        {
            School s = new SchoolDao().Get(2);
            Console.WriteLine(s.AreaName);
        }

    }
}
