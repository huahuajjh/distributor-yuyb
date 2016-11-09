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
    public class CarList:ICarList
    {
        /// <summary>
        /// 取得最新插入的ID
        /// </summary>
        public int GetMaxID(string FieldName)
        {
            return DbHelperSQL.GetMaxID(FieldName, "CarList");
        }
        /// <summary>
        /// 返回长查询数据总数 （分页用到）
        /// </summary>
        public int GetCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(*) as H ");
            strSql.Append(" from CarList ");
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
            strSql.Append("delete from CarList ");
            strSql.Append(" where Id=" + id);

            return DbHelperSQL.ExecuteSql(strSql.ToString());
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(TravelAgent.Model.CarList model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into CarList(");
            strSql.Append("CarName,CarPic,BrandId,ClassId,Seat,CarDesc,CarOrderTip,State,IsLock,Sort)");
            strSql.Append(" values (");
            strSql.Append("@CarName,@CarPic,@BrandId,@ClassId,@Seat,@CarDesc,@CarOrderTip,@State,@IsLock,@Sort)");
            SqlParameter[] parameters = {
					new SqlParameter("@CarName", SqlDbType.VarChar,200),
					new SqlParameter("@CarPic", SqlDbType.NVarChar,200),
					new SqlParameter("@BrandId", SqlDbType.Int),
					new SqlParameter("@ClassId", SqlDbType.Int),
					new SqlParameter("@Seat", SqlDbType.Int),
					new SqlParameter("@CarDesc", SqlDbType.Text),
					new SqlParameter("@CarOrderTip", SqlDbType.Text),
					new SqlParameter("@State", SqlDbType.VarChar,50),
					new SqlParameter("@IsLock", SqlDbType.Int),
                    new SqlParameter("@Sort", SqlDbType.Int)
		    };
            parameters[0].Value = model.CarName;
            parameters[1].Value = model.CarPic;
            parameters[2].Value = model.BrandId;
            parameters[3].Value = model.ClassId;
            parameters[4].Value = model.Seat;
            parameters[5].Value = model.CarDesc;
            parameters[6].Value = model.CarOrderTip;
            parameters[7].Value = model.State;
            parameters[8].Value = model.IsLock;
            parameters[9].Value = model.Sort;

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
        public TravelAgent.Model.CarList GetModel(int Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * ,(select BrandName from CarBrand where Id=BrandId) as BrandName,(select ClassName from CarClass where Id=ClassId) as ClassName from CarList ");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters[0].Value = Id;

            TravelAgent.Model.CarList model = new TravelAgent.Model.CarList();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Id"].ToString() != "")
                {
                    model.Id = int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
                }
                model.CarName = ds.Tables[0].Rows[0]["CarName"].ToString();
                model.CarPic = ds.Tables[0].Rows[0]["CarPic"].ToString();
                model.BrandId = int.Parse(ds.Tables[0].Rows[0]["BrandId"].ToString());
                model.ClassId = int.Parse(ds.Tables[0].Rows[0]["ClassId"].ToString());
                model.Seat = int.Parse(ds.Tables[0].Rows[0]["Seat"].ToString());
                model.CarDesc = ds.Tables[0].Rows[0]["CarDesc"].ToString();
                model.CarOrderTip = ds.Tables[0].Rows[0]["CarOrderTip"].ToString();
                model.State = ds.Tables[0].Rows[0]["State"].ToString();
                model.IsLock = int.Parse(ds.Tables[0].Rows[0]["IsLock"].ToString());
                model.Sort = int.Parse(ds.Tables[0].Rows[0]["Sort"].ToString());
                model.AddDate = DateTime.Parse(ds.Tables[0].Rows[0]["AddDate"].ToString());
                model.BrandName = ds.Tables[0].Rows[0]["BrandName"].ToString();
                model.ClassName = ds.Tables[0].Rows[0]["ClassName"].ToString();
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
            strSql.Append(" FROM CarList ");
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
                strSql.Append("select top " + pageSize + " *,(select  BrandName from CarBrand where Id=BrandId) as BrandName,(select ClassName from CarClass where Id=ClassId) as ClassName from CarList");
                strSql.Append(" where Id not in(select top " + topNum + " Id from CarList");
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
                strSql.Append("select top " + pageSize + " *,(select  BrandName from CarBrand where Id=BrandId) as BrandName,(select ClassName from CarClass where Id=ClassId) as ClassName from CarList");
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

