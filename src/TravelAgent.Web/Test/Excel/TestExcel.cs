using eh.attributes;
using eh.attributes.enums;
using eh.impls;
using eh.impls.configurations;
using eh.impls.errs;
using eh.interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Excel
{
    [TestClass]
    public class TestExcel
    {
        [TestMethod]
        public void TestImport()
        { 
            ErrMsg msg = new ErrMsg();
            IImport import = ExcelFactory.Instance().GetExcelImporter(new ExcelConfiguration(1, 0, 0), msg);
            FileStream fs = new FileStream(@"D:\projects\yueyouyuebei\src\TravelAgent.Web\TravelAgent.WebAPI\template\school.xls", FileMode.Open);
            IList<School> list = import.Import<School>(fs);

            if(msg.Count!=0)
            {
                msg.GetErrors().ForEach(s => { Console.WriteLine(s); });
                return;
            }

            foreach (School item in list)
            {
                Console.WriteLine(item.ToString());
            }

        }
    }

    public class School
    {
        public int Id { get; set; }

        [Col("A")]
        [ColDataConstraint(ConstraintsEnum.NOTNULL)]
        public string Name { get; set; }

        [Col("B")]
        [ColDataConstraint(ConstraintsEnum.NULL)]
        public string ShortName { get; set; }

        [Col("C")]
        [ColDataValid(DataTypeEnum.INT)]
        [ColDataConstraint(ConstraintsEnum.NOTNULL)]
        public int AreaId { get; set; }

        public override string ToString()
        {
            return string.Format("name={0},shortname={1},areaid={2}",Name,ShortName,AreaId);
        }

    }
}
