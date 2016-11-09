using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TravelAgent.IDAL;
using TravelAgent.Tool;
namespace TravelAgent.DALSQL
{
    public class WebNav:IWebNav
    {
        public WebNav()
		{}
        #region  成员方法
        /// <summary>
        /// 取得最新插入的ID
        /// </summary>
        public int GetMaxID(string FieldName)
        {
            return DbHelperSQL.GetMaxID(FieldName, "WebNav");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from WebNav");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters[0].Value = Id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 返回导航名称
        /// </summary>
        /// <param name="classId"></param>
        /// <returns></returns>
        public string GetNavTitle(int classId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 Title from WebNav");
            strSql.Append(" where Id=" + classId);
            return Convert.ToString(DbHelperSQL.GetSingle(strSql.ToString()));
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(TravelAgent.Model.WebNav model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into WebNav(");
            strSql.Append("navName,navParentId,navList,navLayer,navSort,navURL,kindId,State)");
            strSql.Append(" values (");
            strSql.Append("@navName,@navParentId,@navList,@navLayer,@navSort,@navURL,@kindId,@State)");
            SqlParameter[] parameters = {
					new SqlParameter("@navName", SqlDbType.NVarChar,50),
					new SqlParameter("@navParentId", SqlDbType.Int,4),
					new SqlParameter("@navList", SqlDbType.NVarChar,300),
					new SqlParameter("@navLayer", SqlDbType.Int,4),
					new SqlParameter("@navSort", SqlDbType.Int,4),
                    new SqlParameter("@navURL",SqlDbType.NVarChar,250),
					new SqlParameter("@kindId", SqlDbType.Int,4),
					new SqlParameter("@State", SqlDbType.VarChar,100)};
            parameters[0].Value = model.navName;
            parameters[1].Value = model.navParentId;
            parameters[2].Value = model.navList;
            parameters[3].Value = model.navLayer;
            parameters[4].Value = model.navSort;
            parameters[5].Value = model.navURL;
            parameters[6].Value = model.kindId;
            parameters[7].Value = model.State;
            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(TravelAgent.Model.WebNav model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update WebNav set ");
            strSql.Append("navName=@navName,");
            strSql.Append("navParentId=@navParentId,");
            strSql.Append("navList=@navList,");
            strSql.Append("navLayer=@navLayer,");
            strSql.Append("navSort=@navSort,");
            strSql.Append("navURL=@navURL,");
            strSql.Append("kindId=@kindId,");
            strSql.Append("State=@State");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@navName", SqlDbType.NVarChar,50),
					new SqlParameter("@navParentId", SqlDbType.Int,4),
					new SqlParameter("@navList", SqlDbType.NVarChar,300),
					new SqlParameter("@navLayer", SqlDbType.Int,4),
					new SqlParameter("@navSort", SqlDbType.Int,4),
                    new SqlParameter("@navURL", SqlDbType.NVarChar,250),
					new SqlParameter("@kindId", SqlDbType.Int,4),
                    new SqlParameter("@State", SqlDbType.VarChar,100),
                    new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters[0].Value = model.navName;
            parameters[1].Value = model.navParentId;
            parameters[2].Value = model.navList;
            parameters[3].Value = model.navLayer;
            parameters[4].Value = model.navSort;
            parameters[5].Value = model.navURL;
            parameters[6].Value = model.kindId;
            parameters[7].Value = model.State;
            parameters[8].Value = model.Id;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除该导航及所有属下分类导航数据
        /// </summary>
        public void Delete(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from WebNav ");
            strSql.Append(" where navList like '%," + Id + ",%' ");

            DbHelperSQL.Query(strSql.ToString());
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public TravelAgent.Model.WebNav GetModel(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Id,navName,navParentId,navList,navLayer,navSort,navURL,kindId,State from WebNav ");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters[0].Value = Id;

            TravelAgent.Model.WebNav model = new TravelAgent.Model.WebNav();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Id"].ToString() != "")
                {
                    model.Id = int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
                }
                model.navName = ds.Tables[0].Rows[0]["navName"].ToString();
                if (ds.Tables[0].Rows[0]["navParentId"].ToString() != "")
                {
                    model.navParentId = int.Parse(ds.Tables[0].Rows[0]["navParentId"].ToString());
                }
                model.navList = ds.Tables[0].Rows[0]["navList"].ToString();
                if (ds.Tables[0].Rows[0]["navLayer"].ToString() != "")
                {
                    model.navLayer = int.Parse(ds.Tables[0].Rows[0]["navLayer"].ToString());
                }
                if (ds.Tables[0].Rows[0]["navSort"].ToString() != "")
                {
                    model.navSort = int.Parse(ds.Tables[0].Rows[0]["navSort"].ToString());
                }
                model.navURL = ds.Tables[0].Rows[0]["navURL"].ToString();
                if (ds.Tables[0].Rows[0]["kindId"].ToString() != "")
                {
                    model.kindId = int.Parse(ds.Tables[0].Rows[0]["kindId"].ToString());
                }
                model.State =ds.Tables[0].Rows[0]["State"].ToString();
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 取得所有导航列表
        /// </summary>
        /// <param name="PId">父ID</param>
        /// <param name="KId">种类ID</param>
        /// <returns></returns>
        public DataTable GetList(int PId, int? KId)
        {
            DataTable data = new DataTable();
            //创建列
            DataColumn Id = new DataColumn("Id", typeof(int));
            DataColumn navName = new DataColumn("navName", typeof(string));
            DataColumn navParentId = new DataColumn("navParentId", typeof(int));
            DataColumn navList = new DataColumn("navList", typeof(string));
            DataColumn navLayer = new DataColumn("navLayer", typeof(int));
            DataColumn navSort = new DataColumn("navSort", typeof(int));
            DataColumn navURL = new DataColumn("navURL", typeof(string));
            DataColumn kindId = new DataColumn("kindId", typeof(int));
            DataColumn state = new DataColumn("State", typeof(string));
            DataColumn subcount = new DataColumn("subcount", typeof(string));
            //添加列
            data.Columns.Add(Id);
            data.Columns.Add(navName);
            data.Columns.Add(navParentId);
            data.Columns.Add(navList);
            data.Columns.Add(navLayer);
            data.Columns.Add(navSort);
            data.Columns.Add(navURL);
            data.Columns.Add(kindId);
            data.Columns.Add(state);
            data.Columns.Add(subcount);
            //调用迭代组合成DAGATABLE
            List<int> ids = new List<int>();
            GetNavChild(data, PId, KId, ids);
            return data;
        }

        /// <summary>
        /// 取得该导航的所有下级导航列表
        /// </summary>
        /// <param name="data">DATATABLE名</param>
        /// <param name="PId">父栏目ID</param>
        /// <param name="KId">种类ID</param>
        private void GetNavChild(DataTable data, int PId, int? KId, List<int> ids)
        {
            if (ids.Contains(PId)) return;
            ids.Add(PId);
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Id,navName,navParentId,navList,navLayer,navSort,navURL,kindId,State from WebNav");
            if (KId != null)
            {
                strSql.Append(" where navParentId=" + PId + " and kindId=" + KId + "   order by navSort asc,Id desc");
            }
            else
            {
                strSql.Append(" where navParentId=" + PId + " order by navSort asc,Id desc");
            }
            DataSet ds = DbHelperSQL.Query(strSql.ToString());

            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    DataRow dr = ds.Tables[0].Rows[i];
                    //添加一行数据
                    DataRow row = data.NewRow();
                    row[0] = int.Parse(dr["Id"].ToString());
                    row[1] = dr["navName"].ToString();
                    row[2] = int.Parse(dr["navParentId"].ToString());
                    row[3] = dr["navList"].ToString();
                    row[4] = int.Parse(dr["navLayer"].ToString());
                    row[5] = int.Parse(dr["navSort"].ToString());
                    row[6] = dr["navURL"].ToString();
                    row[7] = int.Parse(dr["kindId"].ToString());
                    row[8] = dr["State"].ToString();

                    data.Rows.Add(row);
                    //调用自身迭代
                    this.GetNavChild(data, int.Parse(dr["Id"].ToString()), KId, ids);
                }
            }
        }

        /// <summary>
        /// 取得该导航下的所有子导航的ID
        /// </summary>
        /// <param name="classId"></param>
        /// <returns></returns>
        public DataSet GetNavListByClassId(int classId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 navList,navLayer from WebNav");
            strSql.Append(" where Id=" + classId + " ");
            return DbHelperSQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 取得导航集合
        /// </summary>
        /// <param name="classId"></param>
        /// <returns></returns>
        public DataSet GetNavListByParentId(int parentId, int? top)
        {
            StringBuilder strSql = new StringBuilder();
            if (top != null)
            {
                strSql.Append("select top " + top + " * from WebNav");
            }
            else
            {
                strSql.Append("select * from WebNav");
            }
            strSql.Append(" where navParentId=" + parentId + " order by navSort asc");
            return DbHelperSQL.Query(strSql.ToString());
        }
        #endregion  成员方法
    }
}
