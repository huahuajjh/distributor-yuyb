using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgent.Tool;

namespace Test.SMS
{
    [TestClass]
    public class TestSMS
    {
        [TestMethod]
        public void TestS()
        {
            Console.WriteLine(SMSUtil.Send("18817676235", "hello,回复【TD】退订"));
        }
    }
}
