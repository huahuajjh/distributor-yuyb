using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TravelAgent.Tool
{
    public class BusinessOprate
    {
        /// <summary>
        /// 判断当前行是否有子集
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="row"></param>
        /// <returns></returns>
        public static bool isContainSubNav(DataTable dt, DataRowView row)
        {
            return dt.Select("navParentId = '"+row["Id"]+"'").ToList().Count> 0;
        }
        /// <summary>
        /// 判断当前行是否有子集
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="row"></param>
        /// <returns></returns>
        public static bool isContainSub(DataTable dt, DataRowView row)
        {
            return dt.Select("ParentId = '" + row["Id"] + "'").ToList().Count > 0;
        }
    }
}
