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
    public class Club:IClub
    {
        /// <summary>
        /// 取得最新插入的ID
        /// </summary>
        public int GetMaxID(string FieldName)
        {
            return DbHelperSQL.GetMaxID(FieldName, "Club");
        }
        /// <summary>
        /// 返回长查询数据总数 （分页用到）
        /// </summary>
        public int GetCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(*) as H ");
            strSql.Append(" from Club ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return Convert.ToInt32(DbHelperSQL.GetSingle(strSql.ToString()));
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public TravelAgent.Model.Club GetModel(int Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from Club ");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters[0].Value = Id;

            TravelAgent.Model.Club model = new TravelAgent.Model.Club();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Id"].ToString() != "")
                {
                    model.id = int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
                }
                model.clubName = ds.Tables[0].Rows[0]["clubName"].ToString();
                model.clubMobile = ds.Tables[0].Rows[0]["clubMobile"].ToString();
                model.clubEmail = ds.Tables[0].Rows[0]["clubEmail"].ToString();
                model.clubPwd = ds.Tables[0].Rows[0]["clubPwd"].ToString();
                model.trueName = ds.Tables[0].Rows[0]["trueName"].ToString();
                model.clubSex = ds.Tables[0].Rows[0]["clubSex"].ToString();
                model.clubBirthday = ds.Tables[0].Rows[0]["clubBirthday"].ToString();
                if (ds.Tables[0].Rows[0]["currentPoints"].ToString() != "")
                {
                    model.currentPoints = int.Parse(ds.Tables[0].Rows[0]["currentPoints"].ToString());
                }
                if (ds.Tables[0].Rows[0]["isLock"].ToString() != "")
                {
                    model.isLock = int.Parse(ds.Tables[0].Rows[0]["isLock"].ToString());
                }
                if (ds.Tables[0].Rows[0]["regDate"].ToString() != "")
                {
                    model.regDate = DateTime.Parse(ds.Tables[0].Rows[0]["regDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["emailIsValid"].ToString() != "")
                {
                    model.emailIsValid = int.Parse(ds.Tables[0].Rows[0]["emailIsValid"].ToString());
                }
                if (ds.Tables[0].Rows[0]["mobileIsValid"].ToString() != "")
                {
                    model.mobileIsValid = int.Parse(ds.Tables[0].Rows[0]["mobileIsValid"].ToString());
                }
                if (ds.Tables[0].Rows[0]["classId"].ToString() != "")
                {
                    model.classId= int.Parse(ds.Tables[0].Rows[0]["classId"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public TravelAgent.Model.Club GetModel(string strName,string strPwd)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from Club ");
            strSql.Append(" where (clubName=@Name or clubMobile=@Name or clubEmail=@Name) and clubPwd=@Pwd");
            SqlParameter[] parameters = {
					new SqlParameter("@Name", SqlDbType.VarChar),
                    new SqlParameter("@Pwd", SqlDbType.VarChar)};
            parameters[0].Value = strName;
            parameters[1].Value = strPwd;

            TravelAgent.Model.Club model = new TravelAgent.Model.Club();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Id"].ToString() != "")
                {
                    model.id = int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
                }
                model.clubName = ds.Tables[0].Rows[0]["clubName"].ToString();
                model.clubMobile = ds.Tables[0].Rows[0]["clubMobile"].ToString();
                model.clubEmail = ds.Tables[0].Rows[0]["clubEmail"].ToString();
                model.clubPwd = ds.Tables[0].Rows[0]["clubPwd"].ToString();
                model.trueName = ds.Tables[0].Rows[0]["trueName"].ToString();
                model.clubSex = ds.Tables[0].Rows[0]["clubSex"].ToString();
                model.clubBirthday = ds.Tables[0].Rows[0]["clubBirthday"].ToString();
                if (ds.Tables[0].Rows[0]["currentPoints"].ToString() != "")
                {
                    model.currentPoints = int.Parse(ds.Tables[0].Rows[0]["currentPoints"].ToString());
                }
                if (ds.Tables[0].Rows[0]["isLock"].ToString() != "")
                {
                    model.isLock = int.Parse(ds.Tables[0].Rows[0]["isLock"].ToString());
                }
                if (ds.Tables[0].Rows[0]["regDate"].ToString() != "")
                {
                    model.regDate = DateTime.Parse(ds.Tables[0].Rows[0]["regDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["emailIsValid"].ToString() != "")
                {
                    model.emailIsValid = int.Parse(ds.Tables[0].Rows[0]["emailIsValid"].ToString());
                }
                if (ds.Tables[0].Rows[0]["mobileIsValid"].ToString() != "")
                {
                    model.mobileIsValid = int.Parse(ds.Tables[0].Rows[0]["mobileIsValid"].ToString());
                }
                if (ds.Tables[0].Rows[0]["classId"].ToString() != "")
                {
                    model.classId = int.Parse(ds.Tables[0].Rows[0]["classId"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(TravelAgent.Model.Club model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Club(");
            strSql.Append("clubName,clubMobile,clubEmail,clubPwd,trueName,clubSex,clubBirthday,currentPoints,isLock,regDate,emailIsValid,mobileIsValid,classId)");
            strSql.Append(" values (");
            strSql.Append("@clubName,@clubMobile,@clubEmail,@clubPwd,@trueName,@clubSex,@clubBirthday,@currentPoints,@isLock,@regDate,@emailIsValid,@mobileIsValid,@classId)");
            SqlParameter[] parameters = {
					new SqlParameter("@clubName", SqlDbType.VarChar,50),
					new SqlParameter("@clubMobile", SqlDbType.VarChar,11),
					new SqlParameter("@clubEmail", SqlDbType.VarChar,50),
					new SqlParameter("@clubPwd", SqlDbType.VarChar,50),
					new SqlParameter("@trueName", SqlDbType.VarChar,50),
					new SqlParameter("@clubSex", SqlDbType.VarChar,1),
					new SqlParameter("@clubBirthday", SqlDbType.VarChar,10),
					new SqlParameter("@currentPoints", SqlDbType.Int),
					new SqlParameter("@isLock", SqlDbType.Int),
					new SqlParameter("@regDate", SqlDbType.DateTime),
					new SqlParameter("@emailIsValid", SqlDbType.Int),
					new SqlParameter("@mobileIsValid", SqlDbType.Int),
					new SqlParameter("@classId", SqlDbType.Int,4)};
            parameters[0].Value = model.clubName;
            parameters[1].Value = model.clubMobile;
            parameters[2].Value = model.clubEmail;
            parameters[3].Value = model.clubPwd;
            parameters[4].Value = model.trueName;
            parameters[5].Value = model.clubSex;
            parameters[6].Value = model.clubBirthday;
            parameters[7].Value = model.currentPoints;
            parameters[8].Value = model.isLock;
            parameters[9].Value = model.regDate;
            parameters[10].Value = model.emailIsValid;
            parameters[11].Value = model.mobileIsValid;
            parameters[12].Value = model.classId;
           
            return Convert.ToInt32(DbHelperSQL.ExecuteSql(strSql.ToString(), parameters));
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(TravelAgent.Model.Club model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Club set ");
            strSql.Append("clubName=@clubName,");
            strSql.Append("clubMobile=@clubMobile,");
            strSql.Append("clubEmail=@clubEmail,");
            strSql.Append("clubPwd=@clubPwd,");
            strSql.Append("trueName=@trueName,");
            strSql.Append("clubSex=@clubSex,");
            strSql.Append("clubBirthday=@clubBirthday,");
            strSql.Append("currentPoints=@currentPoints,");
            strSql.Append("isLock=@isLock,");
            strSql.Append("regDate=@regDate,");
            strSql.Append("emailIsValid=@emailIsValid,");
            strSql.Append("mobileIsValid=@mobileIsValid,");
            strSql.Append("classId=@classId");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
			new SqlParameter("@clubName", SqlDbType.VarChar,50),
					new SqlParameter("@clubMobile", SqlDbType.VarChar,11),
					new SqlParameter("@clubEmail", SqlDbType.VarChar,50),
					new SqlParameter("@clubPwd", SqlDbType.VarChar,50),
					new SqlParameter("@trueName", SqlDbType.VarChar,50),
					new SqlParameter("@clubSex", SqlDbType.VarChar),
					new SqlParameter("@clubBirthday", SqlDbType.VarChar),
					new SqlParameter("@currentPoints", SqlDbType.Int),
					new SqlParameter("@isLock", SqlDbType.Int),
					new SqlParameter("@regDate", SqlDbType.DateTime),
					new SqlParameter("@emailIsValid", SqlDbType.Int),
					new SqlParameter("@mobileIsValid", SqlDbType.Int),
					new SqlParameter("@classId", SqlDbType.Int),
                    new SqlParameter("@Id", SqlDbType.Int)};
            parameters[0].Value = model.clubName;
            parameters[1].Value = model.clubMobile;
            parameters[2].Value = model.clubEmail;
            parameters[3].Value = model.clubPwd;
            parameters[4].Value = model.trueName;
            parameters[5].Value = model.clubSex;
            parameters[6].Value = model.clubBirthday;
            parameters[7].Value = model.currentPoints;
            parameters[8].Value = model.isLock;
            parameters[9].Value = model.regDate;
            parameters[10].Value = model.emailIsValid;
            parameters[11].Value = model.mobileIsValid;
            parameters[12].Value = model.classId;
            parameters[13].Value = model.id;

            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Club ");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters[0].Value = Id;

            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
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
            strSql.Append(" FROM Club ");
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
                strSql.Append("select top " + pageSize + " * from Club");
                strSql.Append(" where Id not in(select top " + topNum + " Id from Club");
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
                strSql.Append("select top " + pageSize + " * from Club");
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
