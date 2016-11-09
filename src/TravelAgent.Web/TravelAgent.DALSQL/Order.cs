using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using TravelAgent.Tool;
using TravelAgent.IDAL;

namespace TravelAgent.DALSQL
{
    public class Order:IOrder
    {
        /// <summary>
        /// 取得最新插入的ID
        /// </summary>
        public int GetMaxID(string FieldName)
        {
            return DbHelperSQL.GetMaxID(FieldName, "[Order]");
        }
        /// <summary>
        /// 返回长查询数据总数 （分页用到）
        /// </summary>
        public int GetCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(*) as H ");
            strSql.Append(" from [Order] ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return Convert.ToInt32(DbHelperSQL.GetSingle(strSql.ToString()));
        }
        /// <summary>
        /// 返回长查询数据总数 （分页用到）
        /// </summary>
        public int GetCount2(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(*) as H ");
            strSql.Append(" from [Order] as a ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return Convert.ToInt32(DbHelperSQL.GetSingle(strSql.ToString()));
        }
        /// <summary>
        /// 返回长查询数据总数 （分页用到）
        /// </summary>
        public int GetLineOrderCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(*) as H ");
            strSql.Append(" from [Order] as a,Line as b ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where a.lineid=b.Id  and " + strWhere);
            }
            return Convert.ToInt32(DbHelperSQL.GetSingle(strSql.ToString()));
        }
        /// <summary>
        /// 返回长查询数据总数 （分页用到）
        /// </summary>
        public int GetVisaOrderCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(*) as H ");
            strSql.Append(" from [Order] as a,VisaList as b ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where a.lineid=b.Id  and " + strWhere);
            }
            return Convert.ToInt32(DbHelperSQL.GetSingle(strSql.ToString()));
        }
        /// <summary>
        /// 返回长查询数据总数 （分页用到）
        /// </summary>
        public int GetCarOrderCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(*) as H ");
            strSql.Append(" from [Order] as a,CarList as b ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where a.lineid=b.Id  and " + strWhere);
            }
            return Convert.ToInt32(DbHelperSQL.GetSingle(strSql.ToString()));
        }
        /// <summary>
        /// 删除数据
        /// </summary>
        public int Delete(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from [Order] ");
            strSql.Append(" where Id=" + id);

            return DbHelperSQL.ExecuteSql(strSql.ToString());
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(TravelAgent.Model.Order model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into [Order] (");
            strSql.Append("lineId,ordercode,peopleNumber,adultNumber,childNumber,orderDate,TravelDate,orderPrice,attachPrice,usePoints,donatePoints,");
            strSql.Append("contactName,contactMobile,contactEmail,contactTelephone,orderRemark,operRemark,orderState,clubid,adultPrice,childPrice,payType,subPrice,orderType,contactSex,sourceType,usedate,timedot,huandate,account,tuijianren,IDcard)");
            strSql.Append(" values (");
            strSql.Append("@lineId,@ordercode,@peopleNumber,@adultNumber,@childNumber,@orderDate,@TravelDate,@orderPrice,@attachPrice,@usePoints,@donatePoints,");
            strSql.Append("@contactName,@contactMobile,@contactEmail,@contactTelephone,@orderRemark,@operRemark,@orderState,@clubid,@adultPrice,@childPrice,@payType,@subPrice,@orderType,@contactSex,@sourceType,@usedate,@timedot,@huandate,@account,@tuijianren,@IDcard)");
            SqlParameter[] parameters = {
					new SqlParameter("@lineId", SqlDbType.Int),
					new SqlParameter("@ordercode", SqlDbType.VarChar),
					new SqlParameter("@peopleNumber", SqlDbType.Int),
					new SqlParameter("@adultNumber", SqlDbType.Int),
					new SqlParameter("@childNumber", SqlDbType.Int),
					new SqlParameter("@orderDate", SqlDbType.DateTime),
					new SqlParameter("@TravelDate", SqlDbType.VarChar),
					new SqlParameter("@orderPrice", SqlDbType.Int),
					new SqlParameter("@attachPrice", SqlDbType.Int),
					new SqlParameter("@usePoints", SqlDbType.Int),
					new SqlParameter("@donatePoints", SqlDbType.Int),
					new SqlParameter("@contactName", SqlDbType.VarChar),
					new SqlParameter("@contactMobile", SqlDbType.VarChar),
					new SqlParameter("@contactEmail", SqlDbType.VarChar),
					new SqlParameter("@contactTelephone", SqlDbType.VarChar),
					new SqlParameter("@orderRemark", SqlDbType.VarChar),
					new SqlParameter("@operRemark", SqlDbType.VarChar),
                    new SqlParameter("@orderState", SqlDbType.Int),
                    new SqlParameter("@clubid", SqlDbType.Int),
                    new SqlParameter("@adultPrice", SqlDbType.Int),
                    new SqlParameter("@childPrice", SqlDbType.Int),
                    new SqlParameter("@payType",SqlDbType.Int),
                    new SqlParameter("@subPrice",SqlDbType.Int),
                    new SqlParameter("@orderType",SqlDbType.Int),
                    new SqlParameter("@contactSex",SqlDbType.VarChar),
                    new SqlParameter("@sourceType",SqlDbType.Int),
                    new SqlParameter("@usedate",SqlDbType.VarChar),
                    new SqlParameter("@timedot",SqlDbType.Int),
                    new SqlParameter("@huandate",SqlDbType.VarChar),
                    new SqlParameter("@account",SqlDbType.Int),
                    new SqlParameter("@tuijianren",SqlDbType.VarChar),
                    new SqlParameter("@IDcard",SqlDbType.VarChar)
                };
            parameters[0].Value = model.lineId;
            parameters[1].Value = model.ordercode;
            parameters[2].Value = model.peopleNumber;
            parameters[3].Value = model.adultNumber;
            parameters[4].Value = model.childNumber;
            parameters[5].Value = model.orderDate;
            parameters[6].Value = model.TravelDate;
            parameters[7].Value = model.orderPrice;
            parameters[8].Value = model.attachPrice;
            parameters[9].Value = model.usePoints;
            parameters[10].Value = model.donatePoints;
            parameters[11].Value = model.contactName;
            parameters[12].Value = model.contactMobile;
            parameters[13].Value = model.contactEmail;
            parameters[14].Value = model.contactTelephone;
            parameters[15].Value = model.orderRemark;
            parameters[16].Value = model.operRemark;
            parameters[17].Value = model.orderState;
            parameters[18].Value = model.clubid;
            parameters[19].Value = model.adultPrice;
            parameters[20].Value = model.childPrice;
            parameters[21].Value = model.payType;
            parameters[22].Value = model.subPrice;
            parameters[23].Value = model.orderType;
            parameters[24].Value = model.contactSex;
            parameters[25].Value = model.sourceType;

            parameters[26].Value = model.usedate;
            parameters[27].Value = model.timedot;
            parameters[28].Value = model.huandate;
            parameters[29].Value = model.account;
            parameters[30].Value = model.tuijianren;
            parameters[31].Value = model.IDcard;
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
        /// 通过订单编号获得实体
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public TravelAgent.Model.Order GetModelByCode(string code)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 *,(select lineName from Line where Id=lineId) as proName,(select dealType from Line where Id=lineId) as dealType from [Order] ");
            strSql.Append(" where ordercode=@ordercode ");
            SqlParameter[] parameters = {
					new SqlParameter("@ordercode", SqlDbType.NVarChar,50)};
            parameters[0].Value = code;

            TravelAgent.Model.Order model = new TravelAgent.Model.Order();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Id"].ToString() != "")
                {
                    model.Id = int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
                }
                model.lineId = int.Parse(ds.Tables[0].Rows[0]["lineId"].ToString());
                model.ordercode = ds.Tables[0].Rows[0]["ordercode"].ToString();
                model.peopleNumber = int.Parse(ds.Tables[0].Rows[0]["peopleNumber"].ToString());
                model.adultNumber = int.Parse(ds.Tables[0].Rows[0]["adultNumber"].ToString());
                model.childNumber = int.Parse(ds.Tables[0].Rows[0]["childNumber"].ToString());
                model.orderDate = Convert.ToDateTime(ds.Tables[0].Rows[0]["orderDate"].ToString());

                model.TravelDate = ds.Tables[0].Rows[0]["TravelDate"].ToString();
                model.orderPrice = int.Parse(ds.Tables[0].Rows[0]["orderPrice"].ToString());
                model.attachPrice = int.Parse(ds.Tables[0].Rows[0]["attachPrice"].ToString());
                model.usePoints = int.Parse(ds.Tables[0].Rows[0]["usePoints"].ToString());

                model.donatePoints = int.Parse(ds.Tables[0].Rows[0]["donatePoints"].ToString());
                model.contactName = ds.Tables[0].Rows[0]["contactName"].ToString();
                model.contactMobile = ds.Tables[0].Rows[0]["contactMobile"].ToString();
                model.contactEmail = ds.Tables[0].Rows[0]["contactEmail"].ToString();
                model.contactTelephone = ds.Tables[0].Rows[0]["contactTelephone"].ToString();

                model.orderRemark = ds.Tables[0].Rows[0]["orderRemark"].ToString();

                model.operRemark = ds.Tables[0].Rows[0]["operRemark"].ToString();

                model.orderState = int.Parse(ds.Tables[0].Rows[0]["orderState"].ToString());

                model.clubid = int.Parse(ds.Tables[0].Rows[0]["clubid"].ToString());

                model.adultPrice = int.Parse(ds.Tables[0].Rows[0]["adultPrice"].ToString());
                model.childPrice = int.Parse(ds.Tables[0].Rows[0]["childPrice"].ToString());
                if (ds.Tables[0].Rows[0]["payType"].ToString() != "")
                {
                    model.payType = int.Parse(ds.Tables[0].Rows[0]["payType"].ToString());
                }
                model.subPrice = int.Parse(ds.Tables[0].Rows[0]["subPrice"].ToString());
                model.orderType = int.Parse(ds.Tables[0].Rows[0]["orderType"].ToString());
                model.contactSex = ds.Tables[0].Rows[0]["contactSex"].ToString();
                model.sourceType = int.Parse(ds.Tables[0].Rows[0]["sourceType"].ToString());

                model.usedate = ds.Tables[0].Rows[0]["usedate"].ToString();
                model.timedot = int.Parse(ds.Tables[0].Rows[0]["timedot"].ToString());
                model.huandate = ds.Tables[0].Rows[0]["huandate"].ToString();
                model.account = int.Parse(ds.Tables[0].Rows[0]["account"].ToString());

                model.proName = ds.Tables[0].Rows[0]["proName"].ToString();
                model.dealType = int.Parse(ds.Tables[0].Rows[0]["dealType"].ToString());
                model.tuijianren = ds.Tables[0].Rows[0]["tuijianren"].ToString();
                model.IDcard = ds.Tables[0].Rows[0]["IDcard"].ToString();
                return model;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 通过订单编号获得实体
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public TravelAgent.Model.Order GetModelByCode1(string code)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from [Order] ");
            strSql.Append(" where ordercode=@ordercode ");
            SqlParameter[] parameters = {
					new SqlParameter("@ordercode", SqlDbType.NVarChar,50)};
            parameters[0].Value = code;

            TravelAgent.Model.Order model = new TravelAgent.Model.Order();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Id"].ToString() != "")
                {
                    model.Id = int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
                }
                model.lineId = int.Parse(ds.Tables[0].Rows[0]["lineId"].ToString());
                model.ordercode = ds.Tables[0].Rows[0]["ordercode"].ToString();
                model.peopleNumber = int.Parse(ds.Tables[0].Rows[0]["peopleNumber"].ToString());
                model.adultNumber = int.Parse(ds.Tables[0].Rows[0]["adultNumber"].ToString());
                model.childNumber = int.Parse(ds.Tables[0].Rows[0]["childNumber"].ToString());
                model.orderDate = Convert.ToDateTime(ds.Tables[0].Rows[0]["orderDate"].ToString());

                model.TravelDate = ds.Tables[0].Rows[0]["TravelDate"].ToString();
                model.orderPrice = int.Parse(ds.Tables[0].Rows[0]["orderPrice"].ToString());
                model.attachPrice = int.Parse(ds.Tables[0].Rows[0]["attachPrice"].ToString());
                model.usePoints = int.Parse(ds.Tables[0].Rows[0]["usePoints"].ToString());

                model.donatePoints = int.Parse(ds.Tables[0].Rows[0]["donatePoints"].ToString());
                model.contactName = ds.Tables[0].Rows[0]["contactName"].ToString();
                model.contactMobile = ds.Tables[0].Rows[0]["contactMobile"].ToString();
                model.contactEmail = ds.Tables[0].Rows[0]["contactEmail"].ToString();
                model.contactTelephone = ds.Tables[0].Rows[0]["contactTelephone"].ToString();

                model.orderRemark = ds.Tables[0].Rows[0]["orderRemark"].ToString();

                model.operRemark = ds.Tables[0].Rows[0]["operRemark"].ToString();

                model.orderState = int.Parse(ds.Tables[0].Rows[0]["orderState"].ToString());

                model.clubid = int.Parse(ds.Tables[0].Rows[0]["clubid"].ToString());

                model.adultPrice = int.Parse(ds.Tables[0].Rows[0]["adultPrice"].ToString());
                model.childPrice = int.Parse(ds.Tables[0].Rows[0]["childPrice"].ToString());
                if (ds.Tables[0].Rows[0]["payType"].ToString() != "")
                {
                    model.payType = int.Parse(ds.Tables[0].Rows[0]["payType"].ToString());
                }
                model.subPrice = int.Parse(ds.Tables[0].Rows[0]["subPrice"].ToString());
                model.orderType = int.Parse(ds.Tables[0].Rows[0]["orderType"].ToString());
                model.contactSex = ds.Tables[0].Rows[0]["contactSex"].ToString();
                model.sourceType = int.Parse(ds.Tables[0].Rows[0]["sourceType"].ToString());

                model.usedate = ds.Tables[0].Rows[0]["usedate"].ToString();
                model.timedot = int.Parse(ds.Tables[0].Rows[0]["timedot"].ToString());
                model.huandate = ds.Tables[0].Rows[0]["huandate"].ToString();
                model.account = int.Parse(ds.Tables[0].Rows[0]["account"].ToString());

                model.tuijianren = ds.Tables[0].Rows[0]["tuijianren"].ToString();
                model.IDcard = ds.Tables[0].Rows[0]["IDcard"].ToString();
                //model.proName = ds.Tables[0].Rows[0]["proName"].ToString();
                //model.dealType = int.Parse(ds.Tables[0].Rows[0]["dealType"].ToString());
                return model;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 得到线路一个对象实体
        /// </summary>
        public TravelAgent.Model.Order GetModel(int Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 *,(select lineName from Line where Id=lineId) as proName from [Order] ");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters[0].Value = Id;

            TravelAgent.Model.Order model = new TravelAgent.Model.Order();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Id"].ToString() != "")
                {
                    model.Id = int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
                }
                model.lineId = int.Parse(ds.Tables[0].Rows[0]["lineId"].ToString());
                model.ordercode = ds.Tables[0].Rows[0]["ordercode"].ToString();
                model.peopleNumber = int.Parse(ds.Tables[0].Rows[0]["peopleNumber"].ToString());
                model.adultNumber = int.Parse(ds.Tables[0].Rows[0]["adultNumber"].ToString());
                model.childNumber = int.Parse(ds.Tables[0].Rows[0]["childNumber"].ToString());
                model.orderDate = Convert.ToDateTime(ds.Tables[0].Rows[0]["orderDate"].ToString());

                model.TravelDate = ds.Tables[0].Rows[0]["TravelDate"].ToString();
                model.orderPrice = int.Parse(ds.Tables[0].Rows[0]["orderPrice"].ToString());
                model.attachPrice = int.Parse(ds.Tables[0].Rows[0]["attachPrice"].ToString());
                model.usePoints = int.Parse(ds.Tables[0].Rows[0]["usePoints"].ToString());

                model.donatePoints = int.Parse(ds.Tables[0].Rows[0]["donatePoints"].ToString());
                model.contactName = ds.Tables[0].Rows[0]["contactName"].ToString();
                model.contactMobile = ds.Tables[0].Rows[0]["contactMobile"].ToString();
                model.contactEmail = ds.Tables[0].Rows[0]["contactEmail"].ToString();
                model.contactTelephone = ds.Tables[0].Rows[0]["contactTelephone"].ToString();

                model.orderRemark = ds.Tables[0].Rows[0]["orderRemark"].ToString();

                model.operRemark = ds.Tables[0].Rows[0]["operRemark"].ToString();

                model.orderState = int.Parse(ds.Tables[0].Rows[0]["orderState"].ToString());

                model.clubid = int.Parse(ds.Tables[0].Rows[0]["clubid"].ToString());

                model.adultPrice = int.Parse(ds.Tables[0].Rows[0]["adultPrice"].ToString());
                model.childPrice = int.Parse(ds.Tables[0].Rows[0]["childPrice"].ToString());
                if (ds.Tables[0].Rows[0]["payType"].ToString() != "")
                {
                    model.payType = int.Parse(ds.Tables[0].Rows[0]["payType"].ToString());
                }
                model.subPrice = int.Parse(ds.Tables[0].Rows[0]["subPrice"].ToString());
                model.orderType = int.Parse(ds.Tables[0].Rows[0]["orderType"].ToString());
                model.contactSex = ds.Tables[0].Rows[0]["contactSex"].ToString();
                model.sourceType = int.Parse(ds.Tables[0].Rows[0]["sourceType"].ToString());

                model.usedate = ds.Tables[0].Rows[0]["usedate"].ToString();
                model.timedot = int.Parse(ds.Tables[0].Rows[0]["timedot"].ToString());
                model.huandate = ds.Tables[0].Rows[0]["huandate"].ToString();
                model.account = int.Parse(ds.Tables[0].Rows[0]["account"].ToString());

                model.proName = ds.Tables[0].Rows[0]["proName"].ToString();
                model.tuijianren = ds.Tables[0].Rows[0]["tuijianren"].ToString();
                model.IDcard = ds.Tables[0].Rows[0]["IDcard"].ToString();
                return model;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 得到线路一个对象实体
        /// </summary>
        public TravelAgent.Model.Order GetModel2(int Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 *,(select visaName from VisaList where Id=lineId) as proName from [Order] ");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters[0].Value = Id;

            TravelAgent.Model.Order model = new TravelAgent.Model.Order();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Id"].ToString() != "")
                {
                    model.Id = int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
                }
                model.lineId = int.Parse(ds.Tables[0].Rows[0]["lineId"].ToString());
                model.ordercode = ds.Tables[0].Rows[0]["ordercode"].ToString();
                model.peopleNumber = int.Parse(ds.Tables[0].Rows[0]["peopleNumber"].ToString());
                model.adultNumber = int.Parse(ds.Tables[0].Rows[0]["adultNumber"].ToString());
                model.childNumber = int.Parse(ds.Tables[0].Rows[0]["childNumber"].ToString());
                model.orderDate = Convert.ToDateTime(ds.Tables[0].Rows[0]["orderDate"].ToString());

                model.TravelDate = ds.Tables[0].Rows[0]["TravelDate"].ToString();
                model.orderPrice = int.Parse(ds.Tables[0].Rows[0]["orderPrice"].ToString());
                model.attachPrice = int.Parse(ds.Tables[0].Rows[0]["attachPrice"].ToString());
                model.usePoints = int.Parse(ds.Tables[0].Rows[0]["usePoints"].ToString());

                model.donatePoints = int.Parse(ds.Tables[0].Rows[0]["donatePoints"].ToString());
                model.contactName = ds.Tables[0].Rows[0]["contactName"].ToString();
                model.contactMobile = ds.Tables[0].Rows[0]["contactMobile"].ToString();
                model.contactEmail = ds.Tables[0].Rows[0]["contactEmail"].ToString();
                model.contactTelephone = ds.Tables[0].Rows[0]["contactTelephone"].ToString();

                model.orderRemark = ds.Tables[0].Rows[0]["orderRemark"].ToString();

                model.operRemark = ds.Tables[0].Rows[0]["operRemark"].ToString();

                model.orderState = int.Parse(ds.Tables[0].Rows[0]["orderState"].ToString());

                model.clubid = int.Parse(ds.Tables[0].Rows[0]["clubid"].ToString());

                model.adultPrice = int.Parse(ds.Tables[0].Rows[0]["adultPrice"].ToString());
                model.childPrice = int.Parse(ds.Tables[0].Rows[0]["childPrice"].ToString());
                if (ds.Tables[0].Rows[0]["payType"].ToString() != "")
                {
                    model.payType = int.Parse(ds.Tables[0].Rows[0]["payType"].ToString());
                }
                model.subPrice = int.Parse(ds.Tables[0].Rows[0]["subPrice"].ToString());
                model.orderType = int.Parse(ds.Tables[0].Rows[0]["orderType"].ToString());
                model.contactSex = ds.Tables[0].Rows[0]["contactSex"].ToString();
                model.sourceType = int.Parse(ds.Tables[0].Rows[0]["sourceType"].ToString());

                model.usedate = ds.Tables[0].Rows[0]["usedate"].ToString();
                model.timedot = int.Parse(ds.Tables[0].Rows[0]["timedot"].ToString());
                model.huandate = ds.Tables[0].Rows[0]["huandate"].ToString();
                model.account = int.Parse(ds.Tables[0].Rows[0]["account"].ToString());

                model.proName = ds.Tables[0].Rows[0]["proName"].ToString();
                model.tuijianren = ds.Tables[0].Rows[0]["tuijianren"].ToString();
                model.IDcard = ds.Tables[0].Rows[0]["IDcard"].ToString();
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
        public DataSet GetList0(int Top, string strWhere, string filedOrder)
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
            strSql.Append(" FROM [Order] ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 获得线路前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            #region old damn code
            //strSql.Append(" *,(select b.lineName from Line b where a.lineId=b.Id) as ProName,(select linePic from Line b where a.lineId=b.Id) as LinePic");            
            //strSql.Append(" Id,lineName,lineSubName,linePic,seoTitle,seoKey,seoDisc,cityId,dayNumber,aheadNumber,supplyId,destId,dest,proIds,themeIds,trafficIds,Sort,");
            //strSql.Append("lineFeature,lineCost,orderTips,travelNotice,State,editModel,lineContent,usePoints,donatePoints,adddate,priceSdate,priceEdate,priceEditModel,priceContent,dealType,priceSetting,isLock,gzd");
            //strSql.Append(" FROM [Order] a");
            #endregion

            strSql.Append(" a.*,b.lineName AS ProName,b.linePic AS LinePic FROM [Order] a LEFT JOIN Line b ON a.lineId=b.Id ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 获得签证前几行数据
        /// </summary>
        public DataSet GetList2(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" *,(select visaName from VisaList where lineId=Id) as ProName");
            //strSql.Append(" Id,lineName,lineSubName,linePic,seoTitle,seoKey,seoDisc,cityId,dayNumber,aheadNumber,supplyId,destId,dest,proIds,themeIds,trafficIds,Sort,");
            //strSql.Append("lineFeature,lineCost,orderTips,travelNotice,State,editModel,lineContent,usePoints,donatePoints,adddate,priceSdate,priceEdate,priceEditModel,priceContent,dealType,priceSetting,isLock,gzd");
            strSql.Append(" FROM [Order] ");
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
                strSql.Append("select top " + pageSize + " * from [Order] ");
                strSql.Append(" where Id not in(select top " + topNum + " Id from [Order] ");
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
                strSql.Append("select top " + pageSize + " * from [Order] ");
                if (strWhere.Trim() != "")
                {
                    strSql.Append(" where " + strWhere);
                }
                strSql.Append(" order by " + filedOrder);
            }

            return DbHelperSQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 获得线路查询分页数据
        /// </summary>
        public DataSet GetPageList2(int pageSize, int currentPage, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            if (currentPage > 0)
            {
                int topNum = pageSize * currentPage;
                strSql.Append("select top " + pageSize + " a.*,b.lineName from [Order] as a,Line as b");
                strSql.Append(" where a.lineId=b.Id and a.Id not in(select top " + topNum + " a.Id from [Order] as a,Line as b");
                if (strWhere.Trim() != "")
                {
                    strSql.Append(" where a.lineId=b.Id and " + strWhere);
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
                strSql.Append("select top " + pageSize + " a.*,b.lineName from [Order] as a,Line as b");
                strSql.Append(" where a.lineId=b.Id");
                if (strWhere.Trim() != "")
                {
                    strSql.Append(" and " + strWhere);
                }
                strSql.Append(" order by " + filedOrder);
            }

            return DbHelperSQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 获得签证查询分页数据
        /// </summary>
        public DataSet GetPageList3(int pageSize, int currentPage, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            if (currentPage > 0)
            {
                int topNum = pageSize * currentPage;
                strSql.Append("select top " + pageSize + " a.*,b.visaName from [Order] as a,VisaList as b");
                strSql.Append(" where a.lineId=b.Id and a.Id not in(select top " + topNum + " a.Id from [Order] as a,VisaList as b");
                if (strWhere.Trim() != "")
                {
                    strSql.Append(" where a.lineId=b.Id and " + strWhere);
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
                strSql.Append("select top " + pageSize + " a.*,b.visaName from [Order] as a,VisaList as b");
                strSql.Append(" where a.lineId=b.Id");
                if (strWhere.Trim() != "")
                {
                    strSql.Append(" and " + strWhere);
                }
                strSql.Append(" order by " + filedOrder);
            }

            return DbHelperSQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 获得线路查询分页数据
        /// </summary>
        public DataSet GetPageList4(int pageSize, int currentPage, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            if (currentPage > 0)
            {
                int topNum = pageSize * currentPage;
                strSql.Append("select top " + pageSize + " a.*,b.CarName from [Order] as a,CarList as b");
                strSql.Append(" where a.lineId=b.Id and a.Id not in(select top " + topNum + " a.Id from [Order] as a,CarList as b");
                if (strWhere.Trim() != "")
                {
                    strSql.Append(" where a.lineId=b.Id and " + strWhere);
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
                strSql.Append("select top " + pageSize + " a.*,b.CarName from [Order] as a,CarList as b");
                strSql.Append(" where a.lineId=b.Id");
                if (strWhere.Trim() != "")
                {
                    strSql.Append(" and " + strWhere);
                }
                strSql.Append(" order by " + filedOrder);
            }

            return DbHelperSQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 获得线路前几行数据
        /// </summary>
        public DataSet GetCarList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" *,(select CarName from CarList where Id=lineId) as CarName,(select CarPic from CarList where Id=lineId) as CarPic");
            //strSql.Append(" Id,lineName,lineSubName,linePic,seoTitle,seoKey,seoDisc,cityId,dayNumber,aheadNumber,supplyId,destId,dest,proIds,themeIds,trafficIds,Sort,");
            //strSql.Append("lineFeature,lineCost,orderTips,travelNotice,State,editModel,lineContent,usePoints,donatePoints,adddate,priceSdate,priceEdate,priceEditModel,priceContent,dealType,priceSetting,isLock,gzd");
            strSql.Append(" FROM [Order] ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }
    }
}
