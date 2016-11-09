using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using TravelAgent.Tool;
using TravelAgent.IDAL;
using System.Collections.Generic;

namespace TravelAgent.DALSQL
{
    /// <summary>
    /// 数据访问类Advertising。
    /// </summary>
    public class Advertising:IAdvertising
    {
        public Advertising()
        { }
        #region  成员方法
        /// <summary>
        /// 取得最新插入的ID
        /// </summary>
        public int GetMaxID(string FieldName)
        {
            return DbHelperSQL.GetMaxID(FieldName, "Advertising");
        }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Advertising");
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
            strSql.Append(" from Advertising ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return Convert.ToInt32(DbHelperSQL.GetSingle(strSql.ToString()));
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(TravelAgent.Model.Advertising model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Advertising(");
            strSql.Append("Title,AdType,AdRemark,AdNum,AdPrice,AdWidth,AdHeight,AdTarget,AdChannel,ParentId,ClassList,ClassLayer)");
            strSql.Append(" values (");
            strSql.Append("@Title,@AdType,@AdRemark,@AdNum,@AdPrice,@AdWidth,@AdHeight,@AdTarget,@AdChannel,@ParentId,@ClassList,@ClassLayer)");
            SqlParameter[] parameters = {
                                              new SqlParameter("@Title", SqlDbType.NVarChar, 100),
                                              new SqlParameter("@AdType", SqlDbType.Int, 4),
                                              new SqlParameter("@AdRemark", SqlDbType.NVarChar, 0),
                                              new SqlParameter("@AdNum", SqlDbType.Int, 4),
                                              new SqlParameter("@AdPrice", SqlDbType.Decimal, 9),
                                              new SqlParameter("@AdWidth", SqlDbType.Int, 4),
                                              new SqlParameter("@AdHeight", SqlDbType.Int, 4),
                                              new SqlParameter("@AdTarget", SqlDbType.NVarChar, 50),
                                              new SqlParameter("@AdChannel", SqlDbType.Int, 4),
                                              new SqlParameter("@ParentId", SqlDbType.Int,4),
					                            new SqlParameter("@ClassList", SqlDbType.NVarChar,300),
					                            new SqlParameter("@ClassLayer", SqlDbType.Int,4)
                                          };
            parameters[0].Value = model.Title;
            parameters[1].Value = model.AdType;
            parameters[2].Value = model.AdRemark;
            parameters[3].Value = model.AdNum;
            parameters[4].Value = model.AdPrice;
            parameters[5].Value = model.AdWidth;
            parameters[6].Value = model.AdHeight;
            parameters[7].Value = model.AdTarget;
            parameters[8].Value = model.AdChannel;
            parameters[9].Value = model.ParentID;
            parameters[10].Value = model.ClassList;
            parameters[11].Value = model.ClassLayer;
            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(TravelAgent.Model.Advertising model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Advertising set ");
            strSql.Append("Title=@Title,");
            strSql.Append("AdType=@AdType,");
            strSql.Append("AdRemark=@AdRemark,");
            strSql.Append("AdNum=@AdNum,");
            strSql.Append("AdPrice=@AdPrice,");
            strSql.Append("AdWidth=@AdWidth,");
            strSql.Append("AdHeight=@AdHeight,");
            strSql.Append("AdTarget=@AdTarget,");
            strSql.Append("AdChannel=@AdChannel,");
            strSql.Append("ParentId=@ParentId,");
            strSql.Append("ClassList=@ClassList,");
            strSql.Append("ClassLayer=@ClassLayer");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@Title", SqlDbType.NVarChar,100),
					new SqlParameter("@AdType", SqlDbType.Int,4),
					new SqlParameter("@AdRemark", SqlDbType.NVarChar,0),
					new SqlParameter("@AdNum", SqlDbType.Int,4),
					new SqlParameter("@AdPrice", SqlDbType.Decimal,9),
					new SqlParameter("@AdWidth", SqlDbType.Int,4),
					new SqlParameter("@AdHeight", SqlDbType.Int,4),
					new SqlParameter("@AdTarget", SqlDbType.NVarChar,50),
                    new SqlParameter("@AdChannel", SqlDbType.Int,4),
                    new SqlParameter("@ParentId", SqlDbType.Int,4),
                    new SqlParameter("@ClassList", SqlDbType.NVarChar,300),
                    new SqlParameter("@ClassLayer", SqlDbType.Int,4),
                    new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters[0].Value = model.Title;
            parameters[1].Value = model.AdType;
            parameters[2].Value = model.AdRemark;
            parameters[3].Value = model.AdNum;
            parameters[4].Value = model.AdPrice;
            parameters[5].Value = model.AdWidth;
            parameters[6].Value = model.AdHeight;
            parameters[7].Value = model.AdTarget;
            parameters[8].Value = model.AdChannel;
            parameters[9].Value = model.ParentID;
            parameters[10].Value = model.ClassList;
            parameters[11].Value = model.ClassLayer;
            parameters[12].Value = model.Id;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Advertising ");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters[0].Value = Id;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            //删除该广告位下所有的广告
            DelChildAll(Id);
        }

        /// <summary>
        /// 删除该广告位下所有的广告
        /// </summary>
        /// <param name="Pid"></param>
        private void DelChildAll(int Pid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Adbanner ");
            strSql.Append(" where Aid=@Pid ");
            SqlParameter[] parameters = {
					new SqlParameter("@Pid", SqlDbType.Int,4)};
            parameters[0].Value = Pid;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public TravelAgent.Model.Advertising GetModel(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Id,Title,AdType,AdRemark,AdNum,AdPrice,AdWidth,AdHeight,AdTarget,AdChannel,ParentId,ClassList,ClassLayer from Advertising ");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters[0].Value = Id;

            TravelAgent.Model.Advertising model = new TravelAgent.Model.Advertising();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Id"].ToString() != "")
                {
                    model.Id = int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
                }
                model.Title = ds.Tables[0].Rows[0]["Title"].ToString();
                if (ds.Tables[0].Rows[0]["AdType"].ToString() != "")
                {
                    model.AdType = int.Parse(ds.Tables[0].Rows[0]["AdType"].ToString());
                }
                model.AdRemark = ds.Tables[0].Rows[0]["AdRemark"].ToString();
                if (ds.Tables[0].Rows[0]["AdNum"].ToString() != "")
                {
                    model.AdNum = int.Parse(ds.Tables[0].Rows[0]["AdNum"].ToString());
                }
                if (ds.Tables[0].Rows[0]["AdPrice"].ToString() != "")
                {
                    model.AdPrice = int.Parse(ds.Tables[0].Rows[0]["AdPrice"].ToString());
                }
                if (ds.Tables[0].Rows[0]["AdWidth"].ToString() != "")
                {
                    model.AdWidth = int.Parse(ds.Tables[0].Rows[0]["AdWidth"].ToString());
                }
                if (ds.Tables[0].Rows[0]["AdHeight"].ToString() != "")
                {
                    model.AdHeight = int.Parse(ds.Tables[0].Rows[0]["AdHeight"].ToString());
                }
                model.AdTarget = ds.Tables[0].Rows[0]["AdTarget"].ToString();
                if (ds.Tables[0].Rows[0]["AdChannel"].ToString() != "")
                {
                    model.AdChannel = int.Parse(ds.Tables[0].Rows[0]["AdChannel"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ParentId"].ToString() != "")
                {
                    model.ParentID = int.Parse(ds.Tables[0].Rows[0]["ParentId"].ToString());
                }
                model.ClassList = ds.Tables[0].Rows[0]["ClassList"].ToString();
                if (ds.Tables[0].Rows[0]["ClassLayer"].ToString() != "")
                {
                    model.ClassLayer = int.Parse(ds.Tables[0].Rows[0]["ClassLayer"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Id,Title,AdType,AdRemark,AdNum,AdPrice,AdWidth,AdHeight,AdTarget,AdChannel,ParentId,ClassList,ClassLayer ");
            strSql.Append(" FROM Advertising ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
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
            strSql.Append(" Id,Title,AdType,AdRemark,AdNum,AdPrice,AdWidth,AdHeight,AdTarget,AdChannel,ParentId,ClassList,ClassLayer ");
            strSql.Append(" FROM Advertising ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        #endregion  成员方法
        /// <summary>
        /// 取得所有栏目列表
        /// </summary>
        /// <param name="PId">父ID</param>
        /// <param name="KId">种类ID</param>
        /// <returns></returns>
        public DataTable GetTableList(int PId)
        {
            DataTable data = new DataTable();
            //创建列
            DataColumn Id = new DataColumn("Id", typeof(int));
            DataColumn Title = new DataColumn("Title", typeof(string));
            DataColumn AdType = new DataColumn("AdType", typeof(int));
            DataColumn AdRemark = new DataColumn("AdRemark", typeof(string));
            DataColumn AdNum = new DataColumn("AdNum", typeof(int));
            DataColumn AdPrice = new DataColumn("AdPrice", typeof(int));
            DataColumn AdWidth = new DataColumn("AdWidth", typeof(int));
            DataColumn AdHeight = new DataColumn("AdHeight", typeof(int));
            DataColumn AdTarget = new DataColumn("AdTarget", typeof(string));
            DataColumn AdChannel = new DataColumn("AdChannel", typeof(int));
            DataColumn ParentId = new DataColumn("ParentId", typeof(int));
            DataColumn ClassList = new DataColumn("ClassList", typeof(string));
            DataColumn ClassLayer = new DataColumn("ClassLayer", typeof(int));
            //添加列
            data.Columns.Add(Id);
            data.Columns.Add(Title);
            data.Columns.Add(AdType);
            data.Columns.Add(AdRemark);
            data.Columns.Add(AdNum);
            data.Columns.Add(AdPrice);
            data.Columns.Add(AdWidth);
            data.Columns.Add(AdHeight);
            data.Columns.Add(AdTarget);
            data.Columns.Add(AdChannel);
            data.Columns.Add(ParentId);
            data.Columns.Add(ClassList);
            data.Columns.Add(ClassLayer);
            List<int> ids = new List<int>();
            //调用迭代组合成DAGATABLE
            GetChannelChild(data, PId, ids);
            return data;
        }

        /// <summary>
        /// 取得该栏目的所有下级栏目列表
        /// </summary>
        /// <param name="data">DATATABLE名</param>
        /// <param name="PId">父栏目ID</param>
        /// <param name="KId">种类ID</param>
        private void GetChannelChild(DataTable data, int PId, List<int> ids)
        {
            if (ids.Contains(PId)) return;
            ids.Add(PId);
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Id,Title,AdType,AdRemark,AdNum,AdPrice,AdWidth,AdHeight,AdTarget,AdChannel,ParentId,ClassList,ClassLayer from Advertising");
            
            strSql.Append(" where ParentId=" + PId + " order by Id asc");

            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    DataRow dr = ds.Tables[0].Rows[i];
                    //添加一行数据
                    DataRow row = data.NewRow();
                    row[0] = int.Parse(dr["Id"].ToString());
                    row[1] = dr["Title"].ToString();
                    row[2] = int.Parse(dr["AdType"].ToString());
                    row[3] = dr["AdRemark"].ToString();
                    row[4] = int.Parse(dr["AdNum"].ToString());
                    row[5] = int.Parse(dr["AdPrice"].ToString());
                    row[6] = int.Parse(dr["AdWidth"].ToString());
                    row[7] = int.Parse(dr["AdHeight"].ToString());
                    row[8] = dr["AdTarget"].ToString();
                    row[9] = int.Parse(dr["AdChannel"].ToString());
                    row[10] = int.Parse(dr["ParentId"].ToString());
                    row[11] = dr["ClassList"].ToString();
                    row[12] = int.Parse(dr["ClassLayer"].ToString());
                    data.Rows.Add(row);
                    //调用自身迭代
                    this.GetChannelChild(data, int.Parse(dr["Id"].ToString()), ids);
                }
            }
        }
    }
}