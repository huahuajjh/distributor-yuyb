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
    public class CustomOrder:ICustomOrder
    {
        /// <summary>
        /// 取得最新插入的ID
        /// </summary>
        public int GetMaxID(string FieldName)
        {
            return DbHelperSQL.GetMaxID(FieldName, "CustomOrder");
        }
        /// <summary>
        /// 返回长查询数据总数 （分页用到）
        /// </summary>
        public int GetCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(*) as H ");
            strSql.Append(" from CustomOrder ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return Convert.ToInt32(DbHelperSQL.GetSingle(strSql.ToString()));
        }
        /// <summary>
        /// 删除数据
        /// </summary>
        public int Delete(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from CustomOrder ");
            strSql.Append(" where Id=" + id);

            return DbHelperSQL.ExecuteSql(strSql.ToString());
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(TravelAgent.Model.CustomOrder model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into CustomOrder(");
            strSql.Append("Jindians,CustomType,LineDay,LinePeopleNumber,PeoplePrice,TravelDate,LinkName,LinkTelephone,OtherMsg)");
            strSql.Append(" values (");
            strSql.Append("@Jindians,@CustomType,@LineDay,@LinePeopleNumber,@PeoplePrice,@TravelDate,@LinkName,@LinkTelephone,@OtherMsg)");
            SqlParameter[] parameters = {
					new SqlParameter("@Jindians", SqlDbType.NVarChar,500),
					new SqlParameter("@CustomType", SqlDbType.Int),
					new SqlParameter("@LineDay", SqlDbType.Int),
					new SqlParameter("@LinePeopleNumber", SqlDbType.Int),
					new SqlParameter("@PeoplePrice", SqlDbType.Int),
					new SqlParameter("@TravelDate", SqlDbType.VarChar,50),
					new SqlParameter("@LinkName", SqlDbType.VarChar,50),
					new SqlParameter("@LinkTelephone", SqlDbType.VarChar,50),
					new SqlParameter("@OtherMsg", SqlDbType.Text)
				};
            parameters[0].Value = model.Jindians;
            parameters[1].Value = model.CustomType;
            parameters[2].Value = model.LineDay;
            parameters[3].Value = model.LinePeopleNumber;
            parameters[4].Value = model.PeoplePrice;
            parameters[5].Value = model.TravelDate;
            parameters[6].Value = model.LinkName;
            parameters[7].Value = model.LinkTelephone;
            parameters[8].Value = model.OtherMsg;
       
            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 修改数据
        /// </summary>
        /// <param name="strsql"></param>
        /// <returns></returns>
        public int Update(string strsql)
        {
            return DbHelperSQL.ExecuteSql(strsql);
        }
        /// <summary>
        /// 修改数据
        /// </summary>
        /// <param name="strsql"></param>
        /// <returns></returns>
        public void Update(ArrayList strsqllist)
        {
            DbHelperSQL.ExecuteSqlTran(strsqllist);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public TravelAgent.Model.CustomOrder GetModel(int Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from CustomOrder ");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters[0].Value = Id;

            TravelAgent.Model.CustomOrder model = new TravelAgent.Model.CustomOrder();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Id"].ToString() != "")
                {
                    model.Id = int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
                }
                model.Jindians = ds.Tables[0].Rows[0]["Jindians"].ToString();
                model.CustomType =  int.Parse(ds.Tables[0].Rows[0]["CustomType"].ToString());
                model.LineDay =  int.Parse(ds.Tables[0].Rows[0]["LineDay"].ToString());
                model.LinePeopleNumber =  int.Parse(ds.Tables[0].Rows[0]["LinePeopleNumber"].ToString());
                model.PeoplePrice =  int.Parse(ds.Tables[0].Rows[0]["PeoplePrice"].ToString());
                model.TravelDate = ds.Tables[0].Rows[0]["TravelDate"].ToString();
                model.LinkName = ds.Tables[0].Rows[0]["LinkName"].ToString();
                model.LinkTelephone = ds.Tables[0].Rows[0]["LinkTelephone"].ToString();
                model.AddDate = Convert.ToDateTime(ds.Tables[0].Rows[0]["AddDate"].ToString());
                return model;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" * ");
            //strSql.Append(" Id,lineName,lineSubName,linePic,seoTitle,seoKey,seoDisc,cityId,dayNumber,aheadNumber,supplyId,destId,dest,proIds,themeIds,trafficIds,Sort,");
            //strSql.Append("lineFeature,lineCost,orderTips,travelNotice,State,editModel,lineContent,usePoints,donatePoints,adddate,priceSdate,priceEdate,priceEditModel,priceContent,dealType,priceSetting,isLock,gzd");
            strSql.Append(" FROM CustomOrder ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 获得查询分页数据
        /// </summary>
        public DataSet GetPageList(int pageSize, int currentPage, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            if (currentPage > 0)
            {
                int topNum = pageSize * currentPage;
                strSql.Append("select top " + pageSize + " * from CustomOrder");
                strSql.Append(" where Id not in(select top " + topNum + " Id from CustomOrder");
                if (strWhere.Trim() != "")
                {
                    strSql.Append(" where " + strWhere);
                }
                strSql.Append(" order by " + filedOrder + ")");
                if (strWhere.Trim() != "")
                {
                    strSql.Append(" and " + strWhere);
                }
                //5%1+a+s+p+x
                strSql.Append(" order by " + filedOrder);
            }
            else
            {
                strSql.Append("select top " + pageSize + " * from CustomOrder");
                if (strWhere.Trim() != "")
                {
                    strSql.Append(" where " + strWhere);
                }
                strSql.Append(" order by " + filedOrder);
            }

            return DbHelperSQL.Query(strSql.ToString());
        }
    }
}
