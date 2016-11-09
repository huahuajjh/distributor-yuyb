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
    public class Line:ILine
    {
        /// <summary>
        /// 取得最新插入的ID
        /// </summary>
        public int GetMaxID(string FieldName)
        {
            return DbHelperSQL.GetMaxID(FieldName, "Line");
        }
        /// <summary>
        /// 返回长查询数据总数 （分页用到）
        /// </summary>
        public int GetCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(*) as H ");
            strSql.Append(" from Line ");
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
            strSql.Append("delete from Line ");
            strSql.Append(" where Id=" + id);

            return DbHelperSQL.ExecuteSql(strSql.ToString());
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(TravelAgent.Model.Line model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Line(");
            strSql.Append("lineName,lineSubName,linePic,seoTitle,seoKey,seoDisc,cityId,dayNumber,aheadNumber,supplyId,destId,dest,proIds,themeIds,trafficIds,Sort,");
            strSql.Append("lineFeature,lineCost,orderTips,travelNotice,State,editModel,lineContent,usePoints,donatePoints,adddate,priceSdate,priceEdate,priceEditModel,priceContent,dealType,priceSetting,isLock,gzd,priceCommon,insureid,holiday)");
            strSql.Append(" values (");
            strSql.Append("@lineName,@lineSubName,@linePic,@seoTitle,@seoKey,@seoDisc,@cityId,@dayNumber,@aheadNumber,@supplyId,@destId,@dest,@proIds,@themeIds,@trafficIds,@Sort,");
            strSql.Append("@lineFeature,@lineCost,@orderTips,@travelNotice,@State,@editModel,@lineContent,@usePoints,@donatePoints,@adddate,@priceSdate,@priceEdate,@priceEditModel,@priceContent,@dealType,@priceSetting,@isLock,@gzd,@priceCommon,@insureid,@holiday)");
            SqlParameter[] parameters = {
					new SqlParameter("@lineName", SqlDbType.VarChar,100),
					new SqlParameter("@lineSubName", SqlDbType.VarChar,200),
					new SqlParameter("@linePic", SqlDbType.VarChar,200),
					new SqlParameter("@seoTitle", SqlDbType.VarChar,100),
					new SqlParameter("@seoKey", SqlDbType.VarChar,100),
					new SqlParameter("@seoDisc", SqlDbType.VarChar,250),
					new SqlParameter("@cityId", SqlDbType.Int,4),
					new SqlParameter("@dayNumber", SqlDbType.Int,4),
					new SqlParameter("@aheadNumber", SqlDbType.Int,4),
					new SqlParameter("@supplyId", SqlDbType.Int,4),
					new SqlParameter("@destId", SqlDbType.Int,4),
					new SqlParameter("@dest", SqlDbType.VarChar,250),
					new SqlParameter("@proIds", SqlDbType.VarChar,200),
					new SqlParameter("@themeIds", SqlDbType.VarChar,200),
					new SqlParameter("@trafficIds", SqlDbType.VarChar,50),
					new SqlParameter("@Sort", SqlDbType.Int,4),
					new SqlParameter("@lineFeature", SqlDbType.Text),
                    new SqlParameter("@lineCost", SqlDbType.Text),
                    new SqlParameter("@orderTips", SqlDbType.Text),
                    new SqlParameter("@travelNotice", SqlDbType.Text),
                    new SqlParameter("@State", SqlDbType.VarChar,50),
                    new SqlParameter("@editModel", SqlDbType.Int,4),
                    new SqlParameter("@lineContent", SqlDbType.Text),
                    new SqlParameter("@usePoints", SqlDbType.Int),
                    new SqlParameter("@donatePoints", SqlDbType.Int),
                    new SqlParameter("@adddate", SqlDbType.DateTime),
                    new SqlParameter("@priceSdate", SqlDbType.VarChar),
                    new SqlParameter("@priceEdate", SqlDbType.VarChar),
                    new SqlParameter("@priceEditModel", SqlDbType.Int),
                    new SqlParameter("@priceContent", SqlDbType.VarChar,200),
                    new SqlParameter("@dealType", SqlDbType.Int),
                    new SqlParameter("@priceSetting", SqlDbType.VarChar,250),
                                          new SqlParameter("@isLock", SqlDbType.Int),
                                          new SqlParameter("@gzd", SqlDbType.Int),
                                          new SqlParameter("@priceCommon", SqlDbType.Int),
                                          new SqlParameter("@insureid", SqlDbType.Int),
                                          new SqlParameter("@holiday", SqlDbType.NVarChar,250)};
            parameters[0].Value = model.LineName;
            parameters[1].Value = model.LineSubName;
            parameters[2].Value = model.LinePic;
            parameters[3].Value = model.SeoTitle;
            parameters[4].Value = model.SeoKey;
            parameters[5].Value = model.SeoDisc;
            parameters[6].Value = model.CityId;
            parameters[7].Value = model.DayNumber;
            parameters[8].Value = model.AheadNumber;
            parameters[9].Value = model.SupplyId;
            parameters[10].Value = model.DestId;
            parameters[11].Value = model.Dest;
            parameters[12].Value = model.ProIds;
            parameters[13].Value = model.ThemeIds;
            parameters[14].Value = model.TrafficIds;
            parameters[15].Value = model.Sort;
            parameters[16].Value = model.LineFeature;
            parameters[17].Value = model.LineCost;
            parameters[18].Value = model.OrderTips;
            parameters[19].Value = model.TravelNotice;
            parameters[20].Value = model.State;
            parameters[21].Value = model.EditModel;
            parameters[22].Value = model.LineContent;
            parameters[23].Value = model.UsePoints;
            parameters[24].Value = model.DonatePoints;
            parameters[25].Value = model.Adddate;
            parameters[26].Value = model.PriceSDate;
            parameters[27].Value = model.PriceEDate;
            parameters[28].Value = model.PriceEditModel;
            parameters[29].Value = model.PriceContent;
            parameters[30].Value = model.DealType;
            parameters[31].Value = model.PriceSetting;
            parameters[32].Value = model.IsLock;
            parameters[33].Value = model.GZD;
            parameters[34].Value = model.PriceCommon;
            parameters[35].Value = model.InsureId;
            parameters[36].Value = model.Holiday;
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
        public void Update(ArrayList  strsqllist)
        {
            DbHelperSQL.ExecuteSqlTran(strsqllist);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public TravelAgent.Model.Line GetModel(int Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from Line ");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters[0].Value = Id;

            TravelAgent.Model.Line model = new TravelAgent.Model.Line();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Id"].ToString() != "")
                {
                    model.Id = int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
                }
                model.LineName = ds.Tables[0].Rows[0]["lineName"].ToString();
                model.LineSubName = ds.Tables[0].Rows[0]["lineSubName"].ToString();
                model.LinePic = ds.Tables[0].Rows[0]["linePic"].ToString();
                model.SeoTitle = ds.Tables[0].Rows[0]["seoTitle"].ToString();
                model.SeoKey = ds.Tables[0].Rows[0]["seoKey"].ToString();
                model.SeoDisc = ds.Tables[0].Rows[0]["seoDisc"].ToString();
                if (ds.Tables[0].Rows[0]["cityId"].ToString() != "")
                {
                    model.CityId = int.Parse(ds.Tables[0].Rows[0]["cityId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["dayNumber"].ToString() != "")
                {
                    model.DayNumber = int.Parse(ds.Tables[0].Rows[0]["dayNumber"].ToString());
                }
                if (ds.Tables[0].Rows[0]["aheadNumber"].ToString() != "")
                {
                    model.AheadNumber = int.Parse(ds.Tables[0].Rows[0]["aheadNumber"].ToString());
                }
                if (ds.Tables[0].Rows[0]["supplyId"].ToString() != "")
                {
                    model.SupplyId = int.Parse(ds.Tables[0].Rows[0]["supplyId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["destId"].ToString() != "")
                {
                    model.DestId = int.Parse(ds.Tables[0].Rows[0]["destId"].ToString());
                }
                model.Dest = ds.Tables[0].Rows[0]["dest"].ToString();
                model.ProIds = ds.Tables[0].Rows[0]["proIds"].ToString();
                model.ThemeIds = ds.Tables[0].Rows[0]["themeIds"].ToString();
                model.TrafficIds = ds.Tables[0].Rows[0]["trafficIds"].ToString();
                if (ds.Tables[0].Rows[0]["Sort"].ToString() != "")
                {
                    model.Sort = int.Parse(ds.Tables[0].Rows[0]["Sort"].ToString());
                }

                model.LineFeature = ds.Tables[0].Rows[0]["lineFeature"].ToString();
                model.LineCost = ds.Tables[0].Rows[0]["lineCost"].ToString();
                model.OrderTips = ds.Tables[0].Rows[0]["orderTips"].ToString();
                model.TravelNotice = ds.Tables[0].Rows[0]["travelNotice"].ToString();
                model.State = ds.Tables[0].Rows[0]["State"].ToString();
                if (ds.Tables[0].Rows[0]["editModel"].ToString() != "")
                {
                    model.EditModel = int.Parse(ds.Tables[0].Rows[0]["editModel"].ToString());
                }
                model.LineContent = ds.Tables[0].Rows[0]["lineContent"].ToString();
                if (ds.Tables[0].Rows[0]["usePoints"].ToString() != "")
                {
                    model.UsePoints = int.Parse(ds.Tables[0].Rows[0]["usePoints"].ToString());
                }
                if (ds.Tables[0].Rows[0]["donatePoints"].ToString() != "")
                {
                    model.DonatePoints = int.Parse(ds.Tables[0].Rows[0]["donatePoints"].ToString());
                }
                model.Adddate = DateTime.Parse(ds.Tables[0].Rows[0]["adddate"].ToString());
                if (ds.Tables[0].Rows[0]["priceSdate"].ToString() != "")
                {
                    model.PriceSDate = ds.Tables[0].Rows[0]["priceSdate"].ToString();
                }
                if (ds.Tables[0].Rows[0]["priceEdate"].ToString() != "")
                {
                    model.PriceEDate = ds.Tables[0].Rows[0]["priceEdate"].ToString();
                }
                if (ds.Tables[0].Rows[0]["priceEditModel"].ToString() != "")
                {
                    model.PriceEditModel = int.Parse(ds.Tables[0].Rows[0]["priceEditModel"].ToString());
                }

                model.PriceContent = ds.Tables[0].Rows[0]["priceContent"].ToString();
                if (ds.Tables[0].Rows[0]["dealType"].ToString() != "")
                {
                    model.DealType = int.Parse(ds.Tables[0].Rows[0]["dealType"].ToString());
                }
                model.PriceSetting = ds.Tables[0].Rows[0]["priceSetting"].ToString();
                if (ds.Tables[0].Rows[0]["isLock"].ToString() != "")
                {
                    model.IsLock = int.Parse(ds.Tables[0].Rows[0]["isLock"].ToString());
                }
                model.GZD = int.Parse(ds.Tables[0].Rows[0]["gzd"].ToString());
                model.PriceCommon = int.Parse(ds.Tables[0].Rows[0]["priceCommon"].ToString());
                if (ds.Tables[0].Rows[0]["insureid"].ToString() != "")
                {
                    model.InsureId = int.Parse(ds.Tables[0].Rows[0]["insureid"].ToString());
                }
                model.Holiday = ds.Tables[0].Rows[0]["holiday"].ToString();
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
            strSql.Append(" FROM Line ");
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
                strSql.Append("select top " + pageSize + " * from Line");
                strSql.Append(" where Id not in(select top " + topNum + " Id from Line");
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
                strSql.Append("select top " + pageSize + " * from Line");
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
