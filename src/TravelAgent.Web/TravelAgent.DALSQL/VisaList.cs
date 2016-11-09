using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TravelAgent.IDAL;
using TravelAgent.Tool;

namespace TravelAgent.DALSQL
{
    public class VisaList:IVisaList
    {
        #region  成员方法
        /// <summary>
        /// 取得最新插入的ID
        /// </summary>
        public int GetMaxID(string FieldName)
        {
            return DbHelperSQL.GetMaxID(FieldName, "VisaList");
        }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from VisaList");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters[0].Value = Id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 返回长查询数据总数 （分页用到）
        /// </summary>
        public int GetCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(*) as H ");
            strSql.Append(" from VisaList ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return Convert.ToInt32(DbHelperSQL.GetSingle(strSql.ToString()));
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(TravelAgent.Model.VisaList model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into VisaList(");
            strSql.Append("visaName,typeId,signId,countryId,price,usePoints,donatePoints,dealTime,stayTime,enterNumber,interview,expiryDate,dealType,State,tips,needMaterial,adddate,Sort,isLock)");
            strSql.Append(" values (");
            strSql.Append("@visaName,@typeId,@signId,@countryId,@price,@usePoints,@donatePoints,@dealTime,@stayTime,@enterNumber,@interview,@expiryDate,@dealType,@State,@tips,@needMaterial,@adddate,@Sort,@isLock)");
            SqlParameter[] parameters = {
					new SqlParameter("@visaName", SqlDbType.NVarChar,50),
					new SqlParameter("@typeId", SqlDbType.Int,4),
					new SqlParameter("@signId", SqlDbType.Int,4),
					new SqlParameter("@countryId", SqlDbType.Int,4),
					new SqlParameter("@price", SqlDbType.Int,50),
					new SqlParameter("@usePoints", SqlDbType.Int,4),
					new SqlParameter("@donatePoints", SqlDbType.Int,4),
					new SqlParameter("@dealTime", SqlDbType.VarChar,50),
					new SqlParameter("@stayTime", SqlDbType.VarChar,50),
					new SqlParameter("@enterNumber", SqlDbType.VarChar,50),
					new SqlParameter("@interview", SqlDbType.VarChar,50),
					new SqlParameter("@expiryDate", SqlDbType.VarChar,50),
					new SqlParameter("@dealType", SqlDbType.Int,4),
					new SqlParameter("@State", SqlDbType.VarChar,50),
					new SqlParameter("@tips", SqlDbType.Text),
					new SqlParameter("@needMaterial", SqlDbType.Text),
					new SqlParameter("@adddate", SqlDbType.DateTime),
                    new SqlParameter("@Sort", SqlDbType.Int,4),
                                          new SqlParameter("@isLock", SqlDbType.Int,4)};
            parameters[0].Value = model.visaName;
            parameters[1].Value = model.typeId;
            parameters[2].Value = model.signId;
            parameters[3].Value = model.countryId;
            parameters[4].Value = model.price;
            parameters[5].Value = model.usePoints;
            parameters[6].Value = model.donatePoints;
            parameters[7].Value = model.dealTime;
            parameters[8].Value = model.stayTime;
            parameters[9].Value = model.enterNumber;
            parameters[10].Value = model.interview;
            parameters[11].Value = model.expiryDate;
            parameters[12].Value = model.dealType;
            parameters[13].Value = model.State;
            parameters[14].Value = model.tips;
            parameters[15].Value = model.needMaterial;
            parameters[16].Value = model.adddate;
            parameters[17].Value = model.Sort;
            parameters[18].Value = model.isLock;
            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 修改一条数据
        /// </summary>
        public void UpdateField(int Id, string strValue)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update VisaList set " + strValue);
            strSql.Append(" where Id=" + Id);
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(TravelAgent.Model.VisaList model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update VisaList set ");
            strSql.Append("visaName=@visaName,");
            strSql.Append("typeId=@typeId,");
            strSql.Append("signId=@signId,");
            strSql.Append("countryId=@countryId,");
            strSql.Append("price=@price,");
            strSql.Append("usePoints=@usePoints,");
            strSql.Append("donatePoints=@donatePoints,");
            strSql.Append("dealTime=@dealTime,");
            strSql.Append("stayTime=@stayTime,");
            strSql.Append("enterNumber=@enterNumber,");
            strSql.Append("interview=@interview,");
            strSql.Append("expiryDate=@expiryDate,");
            strSql.Append("dealType=@dealType,");
            strSql.Append("State=@State,");
            strSql.Append("tips=@tips,");
            strSql.Append("needMaterial=@needMaterial,");
            strSql.Append("adddate=@adddate,");
            strSql.Append("Sort=@Sort,");
            strSql.Append("isLock=@isLock ");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
				new SqlParameter("@visaName", SqlDbType.NVarChar,50),
					new SqlParameter("@typeId", SqlDbType.Int,4),
					new SqlParameter("@signId", SqlDbType.Int,4),
					new SqlParameter("@countryId", SqlDbType.Int,4),
					new SqlParameter("@price", SqlDbType.Int,50),
					new SqlParameter("@usePoints", SqlDbType.Int,4),
					new SqlParameter("@donatePoints", SqlDbType.Int,4),
					new SqlParameter("@dealTime", SqlDbType.VarChar,50),
					new SqlParameter("@stayTime", SqlDbType.VarChar,50),
					new SqlParameter("@enterNumber", SqlDbType.VarChar,50),
					new SqlParameter("@interview", SqlDbType.VarChar,50),
					new SqlParameter("@expiryDate", SqlDbType.VarChar,50),
					new SqlParameter("@dealType", SqlDbType.Int,4),
					new SqlParameter("@State", SqlDbType.VarChar,50),
					new SqlParameter("@tips", SqlDbType.Text),
					new SqlParameter("@needMaterial", SqlDbType.Text),
                    new SqlParameter("@adddate", SqlDbType.DateTime),
                    new SqlParameter("@Sort", SqlDbType.Int,4),
                    new SqlParameter("@isLock", SqlDbType.Int,4),
                    new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters[0].Value = model.visaName;
            parameters[1].Value = model.typeId;
            parameters[2].Value = model.signId;
            parameters[3].Value = model.countryId;
            parameters[4].Value = model.price;
            parameters[5].Value = model.usePoints;
            parameters[6].Value = model.donatePoints;
            parameters[7].Value = model.dealTime;
            parameters[8].Value = model.stayTime;
            parameters[9].Value = model.enterNumber;
            parameters[10].Value = model.interview;
            parameters[11].Value = model.expiryDate;
            parameters[12].Value = model.dealType;
            parameters[13].Value = model.State;
            parameters[14].Value = model.tips;
            parameters[15].Value = model.needMaterial;
            parameters[16].Value = model.adddate;
            parameters[17].Value = model.Sort;
            parameters[18].Value = model.isLock;
            parameters[19].Value = model.id;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from VisaList ");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters[0].Value = Id;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public TravelAgent.Model.VisaList GetModel(int Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 *,(select PicUrl from VisaCountry where Id=countryId) as PicUrl,(select Name from VisaCountry where Id=countryId) as cname from VisaList ");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters[0].Value = Id;

            TravelAgent.Model.VisaList model = new TravelAgent.Model.VisaList();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Id"].ToString() != "")
                {
                    model.id = int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
                }
                model.visaName = ds.Tables[0].Rows[0]["visaName"].ToString();
                if (ds.Tables[0].Rows[0]["typeId"].ToString() != "")
                {
                    model.typeId = int.Parse(ds.Tables[0].Rows[0]["typeId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["signId"].ToString() != "")
                {
                    model.signId = int.Parse(ds.Tables[0].Rows[0]["signId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["countryId"].ToString() != "")
                {
                    model.countryId = int.Parse(ds.Tables[0].Rows[0]["countryId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["price"].ToString() != "")
                {
                    model.price = int.Parse(ds.Tables[0].Rows[0]["price"].ToString());
                }
                if (ds.Tables[0].Rows[0]["usePoints"].ToString() != "")
                {
                    model.usePoints = int.Parse(ds.Tables[0].Rows[0]["usePoints"].ToString());
                }
                if (ds.Tables[0].Rows[0]["donatePoints"].ToString() != "")
                {
                    model.donatePoints = int.Parse(ds.Tables[0].Rows[0]["donatePoints"].ToString());
                }
                model.dealTime = ds.Tables[0].Rows[0]["dealTime"].ToString();
                model.stayTime = ds.Tables[0].Rows[0]["stayTime"].ToString();
                model.enterNumber = ds.Tables[0].Rows[0]["enterNumber"].ToString();
                model.interview = ds.Tables[0].Rows[0]["interview"].ToString();
                model.expiryDate = ds.Tables[0].Rows[0]["expiryDate"].ToString();
                if (ds.Tables[0].Rows[0]["dealType"].ToString() != "")
                {
                    model.dealType = int.Parse(ds.Tables[0].Rows[0]["dealType"].ToString());
                }
                model.State = ds.Tables[0].Rows[0]["State"].ToString();
                model.tips = ds.Tables[0].Rows[0]["tips"].ToString();
                model.needMaterial = ds.Tables[0].Rows[0]["needMaterial"].ToString();

                if (ds.Tables[0].Rows[0]["adddate"].ToString() != "")
                {
                    model.adddate = DateTime.Parse(ds.Tables[0].Rows[0]["adddate"].ToString());
                }
                model.Sort = int.Parse(ds.Tables[0].Rows[0]["Sort"].ToString());
                model.isLock = int.Parse(ds.Tables[0].Rows[0]["isLock"].ToString());
                model.picurl = ds.Tables[0].Rows[0]["PicUrl"].ToString();
                model.countryName = ds.Tables[0].Rows[0]["cname"].ToString();
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
            strSql.Append(" *,(select PicUrl from VisaCountry where Id=countryId) as PicUrl ");
            strSql.Append(" FROM VisaList ");
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
                strSql.Append("select top " + pageSize + " Id,visaName,typeId,signId,countryId,price,usePoints,donatePoints,dealTime,stayTime,enterNumber,interview,expiryDate,dealType,State,tips,needMaterial,adddate,Sort,isLock from VisaList");
                strSql.Append(" where Id not in(select top " + topNum + " Id from VisaList");
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
                strSql.Append("select top " + pageSize + " Id,visaName,typeId,signId,countryId,price,usePoints,donatePoints,dealTime,stayTime,enterNumber,interview,expiryDate,dealType,State,tips,needMaterial,adddate,Sort,isLock from VisaList");
                if (strWhere.Trim() != "")
                {
                    strSql.Append(" where " + strWhere);
                }
                strSql.Append(" order by " + filedOrder);
            }

            return DbHelperSQL.Query(strSql.ToString());
        }

        #endregion  成员方法
    }
}
