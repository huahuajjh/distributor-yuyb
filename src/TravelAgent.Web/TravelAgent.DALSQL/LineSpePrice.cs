using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using TravelAgent.IDAL;
using TravelAgent.Tool;
namespace TravelAgent.DALSQL
{
    public class LineSpePrice:ILineSpePrice
    {
        /// <summary>
        /// 批量添加
        /// </summary>
        /// <param name="strsqllist"></param>
        public void InsertContents(ArrayList strsqllist)
        {
            DbHelperSQL.ExecuteSqlTran(strsqllist);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(TravelAgent.Model.LineSpePrice model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into LineSpePrice(");
            strSql.Append("lineId,lineDate,linePrice,tag)");
            strSql.Append(" values (");
            strSql.Append("@lineId,@lineDate,@linePrice,@tag)");
            SqlParameter[] parameters = {
					new SqlParameter("@lineId", SqlDbType.Int,4),
					new SqlParameter("@lineDate", SqlDbType.VarChar,50),
					new SqlParameter("@linePrice", SqlDbType.VarChar,250),
                    new SqlParameter("@tag", SqlDbType.Int)};
            parameters[0].Value = model.lineId;
            parameters[1].Value = model.lineDate;
            parameters[2].Value = model.linePrice;
            parameters[3].Value = model.tag;
            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 删除数据
        /// </summary>
        public int Delete(int lineid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from LineSpePrice ");
            strSql.Append(" where lineId=" + lineid);

            return DbHelperSQL.ExecuteSql(strSql.ToString());
        }
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="lineid"></param>
        /// <param name="pricedate"></param>
        public int Delete(int lineid, string date)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from LineSpePrice ");
            strSql.Append(" where lineId=" + lineid + " and lineDate='"+date+"'");

            return DbHelperSQL.ExecuteSql(strSql.ToString());
        }
        /// <summary>
        /// 根据编号获得集合
        /// </summary>
        /// <param name="lineid"></param>
        /// <returns></returns>
        public List<TravelAgent.Model.LineSpePrice> GetlstSpePriceByLineId(int lineid)
        {
            string strsql = "select * from LineSpePrice where lineId="+lineid;

            List<TravelAgent.Model.LineSpePrice> lstSpePrice = new List<TravelAgent.Model.LineSpePrice>();

            using (SqlDataReader odr = DbHelperSQL.ExecuteReader(strsql))
            {
                TravelAgent.Model.LineSpePrice price = null;

                while (odr.Read())
                {
                    price = new TravelAgent.Model.LineSpePrice();
                    price.Id = odr.GetInt32(0);
                    price.lineId = odr.GetInt32(1);
                    price.lineDate = odr.GetString(2);
                    price.linePrice = odr.GetString(3);
                    price.tag = odr.GetInt32(4);
                    lstSpePrice.Add(price);
                }
            }
            return lstSpePrice;
        }
    }
}
