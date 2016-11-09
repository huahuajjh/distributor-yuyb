using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TravelAgent.DALFactory;
using TravelAgent.IDAL;
using NLog;

namespace Test
{
    [TestClass]
    public class TestNLog
    {
        [TestMethod]
        public void TestNLogInit()
        {
            ILogger logger = LogManager.GetLogger("NLog.config");
            logger.Info("nlog");
        }
    }
}
