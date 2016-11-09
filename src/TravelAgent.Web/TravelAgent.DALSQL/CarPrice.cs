using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TravelAgent.IDAL;
using TravelAgent.Tool;

namespace TravelAgent.DALSQL
{
   public class CarPrice:ICarPrice
    {
        /// <summary>
        /// 取得最新插入的ID
        /// </summary>
        public int GetMaxID(string FieldName)
        {
            return DbHelperSQL.GetMaxID(FieldName, "CarPrice");
        }
        /// <summary>
        /// 返回长查询数据总数 （分页用到）
        /// </summary>
        public int GetCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(*) as H ");
            strSql.Append(" from CarPrice ");
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
            strSql.Append("delete from CarPrice ");
            strSql.Append(" where Id=" + id);

            return DbHelperSQL.ExecuteSql(strSql.ToString());
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(TravelAgent.Model.CarPrice model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into CarPrice(");
            strSql.Append("CarId,PriceName,Unit,CarTypeID,CarCityId,TranDisc,NumberId,MemshiPrice,XiaoshuPrice,JiesuanPrice,UsePoints,DonatePoints,StartDate,EndDate,DealType,IsLock,BSQ,SpeXiaoshuPrice)");
            strSql.Append(" values (");
            strSql.Append("@CarId,@PriceName,@Unit,@CarTypeID,@CarCityId,@TranDisc,@NumberId,@MemshiPrice,@XiaoshuPrice,@JiesuanPrice,@UsePoints,@DonatePoints,@StartDate,@EndDate,@DealType,@IsLock,@BSQ,@SpeXiaoshuPrice)");
            SqlParameter[] parameters = {
					new SqlParameter("@CarId", SqlDbType.Int),
					new SqlParameter("@PriceName", SqlDbType.VarChar,200),
					new SqlParameter("@Unit", SqlDbType.VarChar,50),
					new SqlParameter("@CarTypeID", SqlDbType.Int),
					new SqlParameter("@CarCityId", SqlDbType.Int),
					new SqlParameter("@TranDisc", SqlDbType.VarChar,50),
					new SqlParameter("@NumberId", SqlDbType.Int,4),
					new SqlParameter("@MemshiPrice", SqlDbType.Int,4),
					new SqlParameter("@XiaoshuPrice", SqlDbType.Int,4),
					new SqlParameter("@JiesuanPrice", SqlDbType.Int,4),
					new SqlParameter("@UsePoints", SqlDbType.Int,4),
					new SqlParameter("@DonatePoints", SqlDbType.VarChar,250),
					new SqlParameter("@StartDate", SqlDbType.VarChar,200),
					new SqlParameter("@EndDate", SqlDbType.VarChar,200),
					new SqlParameter("@DealType", SqlDbType.VarChar,50),
					new SqlParameter("@IsLock", SqlDbType.Int,4),
                    new SqlParameter("@BSQ", SqlDbType.Int,4),
                    new SqlParameter("@SpeXiaoshuPrice", SqlDbType.NVarChar,500)
			};
            parameters[0].Value = model.CarId;
            parameters[1].Value = model.PriceName;
            parameters[2].Value = model.Unit;
            parameters[3].Value = model.CarTypeID;
            parameters[4].Value = model.CarCityId;
            parameters[5].Value = model.TranDisc;
            parameters[6].Value = model.NumberId;
            parameters[7].Value = model.MemshiPrice;
            parameters[8].Value = model.XiaoshuPrice;
            parameters[9].Value = model.JiesuanPrice;
            parameters[10].Value = model.UsePoints;
            parameters[11].Value = model.DonatePoints;
            parameters[12].Value = model.StartDate;
            parameters[13].Value = model.EndDate;
            parameters[14].Value = model.DealType;
            parameters[15].Value = model.IsLock;
            parameters[16].Value = model.BSQ;
            parameters[17].Value = model.SpeXiaoshuPrice;
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
        /// 更新一条数据
        /// </summary>
        public int Update(TravelAgent.Model.CarPrice model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update CarPrice set ");
            strSql.Append("PriceName=@PriceName,");
            strSql.Append("Unit=@Unit,");
            strSql.Append("CarTypeID=@CarTypeID,");
            strSql.Append("CarCityId=@CarCityId,");
            strSql.Append("TranDisc=@TranDisc,");
            strSql.Append("NumberId=@NumberId,");
            strSql.Append("MemshiPrice=@MemshiPrice,");
            strSql.Append("XiaoshuPrice=@XiaoshuPrice,");
            strSql.Append("JiesuanPrice=@JiesuanPrice,");
            strSql.Append("UsePoints=@UsePoints,");
            strSql.Append("DonatePoints=@DonatePoints,");
            strSql.Append("StartDate=@StartDate,");
            strSql.Append("EndDate=@EndDate,");
            strSql.Append("DealType=@DealType,");
            strSql.Append("IsLock=@IsLock,");
            strSql.Append("BSQ=@BSQ,");
            strSql.Append("SpeXiaoshuPrice=@SpeXiaoshuPrice");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
			new SqlParameter("@PriceName", SqlDbType.VarChar,200),
					new SqlParameter("@Unit", SqlDbType.VarChar,50),
					new SqlParameter("@CarTypeID", SqlDbType.Int),
					new SqlParameter("@CarCityId", SqlDbType.Int),
					new SqlParameter("@TranDisc", SqlDbType.VarChar,50),
					new SqlParameter("@NumberId", SqlDbType.Int),
					new SqlParameter("@MemshiPrice", SqlDbType.Int),
					new SqlParameter("@XiaoshuPrice", SqlDbType.Int),
					new SqlParameter("@JiesuanPrice", SqlDbType.Int),
					new SqlParameter("@UsePoints", SqlDbType.Int),
					new SqlParameter("@DonatePoints", SqlDbType.Int),
					new SqlParameter("@StartDate", SqlDbType.VarChar,10),
					new SqlParameter("@EndDate", SqlDbType.VarChar,10),
                    new SqlParameter("@DealType", SqlDbType.Int),
					new SqlParameter("@IsLock", SqlDbType.Int),
                    new SqlParameter("@BSQ", SqlDbType.Int),
					new SqlParameter("@SpeXiaoshuPrice", SqlDbType.NVarChar,500),
                    new SqlParameter("@Id", SqlDbType.Int)};
            parameters[0].Value = model.PriceName;
            parameters[1].Value = model.Unit;
            parameters[2].Value = model.CarTypeID;
            parameters[3].Value = model.CarCityId;
            parameters[4].Value = model.TranDisc;
            parameters[5].Value = model.NumberId;
            parameters[6].Value = model.MemshiPrice;
            parameters[7].Value = model.XiaoshuPrice;
            parameters[8].Value = model.JiesuanPrice;
            parameters[9].Value = model.UsePoints;
            parameters[10].Value = model.DonatePoints;
            parameters[11].Value = model.StartDate;
            parameters[12].Value = model.EndDate;
            parameters[13].Value = model.DealType;
            parameters[14].Value = model.IsLock;
            parameters[15].Value = model.BSQ;
            parameters[16].Value = model.SpeXiaoshuPrice;
            parameters[17].Value = model.Id;

            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
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
        public TravelAgent.Model.CarPrice GetModel(int Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 *,(select NumName from CarNumber where Id=NumberId) as NumName  from CarPrice ");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters[0].Value = Id;

            TravelAgent.Model.CarPrice model = new TravelAgent.Model.CarPrice();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Id"].ToString() != "")
                {
                    model.Id = int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CarId"].ToString() != "")
                {
                    model.CarId = int.Parse(ds.Tables[0].Rows[0]["CarId"].ToString());
                }
                model.PriceName = ds.Tables[0].Rows[0]["PriceName"].ToString();
                model.Unit = ds.Tables[0].Rows[0]["Unit"].ToString();

                if (ds.Tables[0].Rows[0]["CarTypeID"].ToString() != "")
                {
                    model.CarTypeID = int.Parse(ds.Tables[0].Rows[0]["CarTypeID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CarCityId"].ToString() != "")
                {
                    model.CarCityId = int.Parse(ds.Tables[0].Rows[0]["CarCityId"].ToString());
                }
                model.TranDisc = ds.Tables[0].Rows[0]["TranDisc"].ToString();
                if (ds.Tables[0].Rows[0]["NumberId"].ToString() != "")
                {
                    model.NumberId = int.Parse(ds.Tables[0].Rows[0]["NumberId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["MemshiPrice"].ToString() != "")
                {
                    model.MemshiPrice = int.Parse(ds.Tables[0].Rows[0]["MemshiPrice"].ToString());
                }
                if (ds.Tables[0].Rows[0]["XiaoshuPrice"].ToString() != "")
                {
                    model.XiaoshuPrice = int.Parse(ds.Tables[0].Rows[0]["XiaoshuPrice"].ToString());
                }
                if (ds.Tables[0].Rows[0]["JiesuanPrice"].ToString() != "")
                {
                    model.JiesuanPrice = int.Parse(ds.Tables[0].Rows[0]["JiesuanPrice"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UsePoints"].ToString() != "")
                {
                    model.UsePoints = int.Parse(ds.Tables[0].Rows[0]["UsePoints"].ToString());
                }
                if (ds.Tables[0].Rows[0]["DonatePoints"].ToString() != "")
                {
                    model.DonatePoints = int.Parse(ds.Tables[0].Rows[0]["DonatePoints"].ToString());
                }
                model.StartDate = ds.Tables[0].Rows[0]["StartDate"].ToString();
                model.EndDate = ds.Tables[0].Rows[0]["EndDate"].ToString();

                if (ds.Tables[0].Rows[0]["DealType"].ToString() != "")
                {
                    model.DealType = int.Parse(ds.Tables[0].Rows[0]["DealType"].ToString());
                }

                if (ds.Tables[0].Rows[0]["IsLock"].ToString() != "")
                {
                    model.IsLock = int.Parse(ds.Tables[0].Rows[0]["IsLock"].ToString());
                }
                if (ds.Tables[0].Rows[0]["BSQ"].ToString() != "")
                {
                    model.BSQ = int.Parse(ds.Tables[0].Rows[0]["BSQ"].ToString());
                }
                model.SpeXiaoshuPrice = ds.Tables[0].Rows[0]["SpeXiaoshuPrice"].ToString();
                model.NumName = ds.Tables[0].Rows[0]["NumName"].ToString();
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
            strSql.Append(" FROM CarPrice ");
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
                strSql.Append("select top " + pageSize + " * from CarPrice");
                strSql.Append(" where Id not in(select top " + topNum + " Id from CarPrice");
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
                strSql.Append("select top " + pageSize + " * from CarPrice");
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
