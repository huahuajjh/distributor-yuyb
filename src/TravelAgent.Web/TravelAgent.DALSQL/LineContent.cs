using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using TravelAgent.Tool;
using TravelAgent.IDAL;
namespace TravelAgent.DALSQL
{
   public class LineContent:ILineContent
    {
        /// <summary>
        /// 删除数据
        /// </summary>
        public int Delete(int lineid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from LineContent ");
            strSql.Append(" where lineId=" + lineid);

            return DbHelperSQL.ExecuteSql(strSql.ToString());
        }
        /// <summary>
        /// 批量添加
        /// </summary>
        /// <param name="strsqllist"></param>
        public void InsertContents(ArrayList strsqllist)
        {
            DbHelperSQL.ExecuteSqlTran(strsqllist);
        }

        /// <summary>
        /// 根据编号获得集合
        /// </summary>
        /// <param name="lineid"></param>
        /// <returns></returns>
        public List<TravelAgent.Model.LineContent> GetlstLineContentByLineId(int lineid)
        {
            string strsql = "select * from LineContent where lineId=" + lineid+" order by daySort asc";

            List<TravelAgent.Model.LineContent> lstLineContent = new List<TravelAgent.Model.LineContent>();

            using (SqlDataReader odr = DbHelperSQL.ExecuteReader(strsql))
            {
                TravelAgent.Model.LineContent content = null;

                while (odr.Read())
                {
                    content = new TravelAgent.Model.LineContent();
                    content.Id = odr.GetInt32(0);
                    content.Title = odr.GetString(1);
                    content.Morn = odr.GetInt32(2);
                    content.Noon = odr.GetInt32(3);
                    content.Night = odr.GetInt32(4);
                    content.Accom = odr.GetString(5);
                    content.Content = odr.GetString(6);
                    content.DaySort = odr.GetInt32(7);
                    content.LineId = odr.GetInt32(8);
                    lstLineContent.Add(content);
                }
            }
            return lstLineContent;
        }
    }
}
