using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    [TestClass]
    public class TestList
    {
        [TestMethod]
        public void TestL()
        {
            string ids = "";
            for (int i = 0; i < 10; i++)
            {
                if(string.IsNullOrEmpty(ids))
                { 
                    ids += i;
                }
                else
                { 
                    ids += ("."+i);
                }
            }

            Console.WriteLine(ids);

        }
    }
}
