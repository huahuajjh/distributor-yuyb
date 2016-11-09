using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TravelAgent.Tool;
using TravelAgent.IDAL;

namespace TravelAgent.DALSQL
{
    public class InfoSetting:IInfoSetting
    {
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Id,Name,Value ");
            strSql.Append(" FROM InfoSetting ");
            return DbHelperSQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="ht"></param>
        /// <returns></returns>
        public void UpdateValue(Hashtable ht)
        {
            ArrayList sqlList = new ArrayList();
            foreach (DictionaryEntry de in ht)
            {
                sqlList.Add("update InfoSetting set [Value]='" + de.Value + "' where [Name]='" + de.Key+"'");
            }

            DbHelperSQL.ExecuteSqlTran(sqlList);
        }
    }
}
