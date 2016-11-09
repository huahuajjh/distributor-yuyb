using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgent.Model;
using TravelAgent.Tool;

namespace Test.JsonTest
{
    [TestClass]
    public class TestJson
    {
        [TestMethod]
        public void ToJson()
        { 
            //References r = new References(){ Id=1, Name="zs", SchoolId=12, Tel="12121212121"};
            //Console.WriteLine(JsonUtil.ToJson(r));

            IList<References> list = new List<References>();

            for (int i = 0; i < 10; i++)
            {
                References o = new References(){ Id=i, Name="zs"+i, SchoolId=i+1, Tel="a"+i};
                list.Add(o);
            }

            Console.WriteLine(JsonUtil.ToJson(list));
        }

        [TestMethod]
        public void ToObj()
        {
            string json = "[{'Id':0,'Name':'zs0','Tel':'a0','SchoolId':1},{'Id':1,'Name':'zs1','Tel':'a1','SchoolId':2},{'Id':2,'Name':'zs2','Tel':'a2','SchoolId':3},{'Id':3,'Name':'zs3','Tel':'a3','SchoolId':4},{'Id':4,'Name':'zs4','Tel':'a4','SchoolId':5},{'Id':5,'Name':'zs5','Tel':'a5','SchoolId':6},{'Id':6,'Name':'zs6','Tel':'a6','SchoolId':7},{'Id':7,'Name':'zs7','Tel':'a7','SchoolId':8},{'Id':8,'Name':'zs8','Tel':'a8','SchoolId':9},{'Id':9,'Name':'zs9','Tel':'a9','SchoolId':10}]";
            IList<References> list = JsonUtil.ToObj<IList<References>>(json);
            foreach (References item in list)
            {
                Console.WriteLine(item.Name);
            }

        }

        [TestMethod]
        public void ToObj1()
        {
            string json = "{'Id':0,'Name':'zs0','Tel':'a0','SchoolId':1}";
            References r = JsonUtil.ToObj<References>(json);
            Console.WriteLine(r.Name);
        }
        
        [TestMethod]
        public void TestSchoolJson()
        {
            Console.WriteLine(JsonUtil.ToJson(new School{ AreaId=1,ShortName="学校简称", Id=2, Name="学校名称"}));
        }

        [TestMethod]
        public void TestRefJson()
        {
            Console.WriteLine(JsonUtil.ToJson(new References { Tel="推荐人电话", SchoolId=11, Id=1, Name="推荐人姓名"}));
        }

    }
}
