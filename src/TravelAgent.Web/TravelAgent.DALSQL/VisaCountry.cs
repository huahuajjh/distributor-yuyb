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
    public class VisaCountry:IVisaCountry
    {
        #region  成员方法
        /// <summary>
        /// 取得最新插入的ID
        /// </summary>
        public int GetMaxID(string FieldName)
        {
            return DbHelperSQL.GetMaxID(FieldName, "VisaCountry");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from VisaCountry");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters[0].Value = Id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 返回名称
        /// </summary>
        /// <param name="classId"></param>
        /// <returns></returns>
        public string GetTitle(int classId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 Title from VisaCountry");
            strSql.Append(" where Id=" + classId);
            return Convert.ToString(DbHelperSQL.GetSingle(strSql.ToString()));
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(TravelAgent.Model.VisaCountry model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into VisaCountry(");
            strSql.Append("Name,PicUrl,Tips,EnglishName,FirstWord,Sort,isLock,ParentId,ClassList,ClassLayer)");
            strSql.Append(" values (");
            strSql.Append("@Name,@PicUrl,@Tips,@EnglishName,@FirstWord,@Sort,@isLock,@ParentId,@ClassList,@ClassLayer)");
            SqlParameter[] parameters = {
					new SqlParameter("@Name", SqlDbType.NVarChar,50),
					new SqlParameter("@PicUrl", SqlDbType.VarChar,50),
					new SqlParameter("@Tips", SqlDbType.Text),
					new SqlParameter("@EnglishName", SqlDbType.VarChar,50),
					new SqlParameter("@FirstWord", SqlDbType.VarChar,50),
                    new SqlParameter("@Sort",SqlDbType.Int,4),
					new SqlParameter("@isLock", SqlDbType.Int,4),
                    new SqlParameter("@ParentId", SqlDbType.Int,4),
                    new SqlParameter("@ClassList", SqlDbType.VarChar,50),
					new SqlParameter("@ClassLayer", SqlDbType.Int,4)};
            parameters[0].Value = model.Name;
            parameters[1].Value = model.PicUrl;
            parameters[2].Value = model.Tips;
            parameters[3].Value = model.EnglishName;
            parameters[4].Value = model.FirstWord;
            parameters[5].Value = model.Sort;
            parameters[6].Value = model.isLock;
            parameters[7].Value = model.ParentId;
            parameters[8].Value = model.ClassList;
            parameters[9].Value = model.ClassLayer;
            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(TravelAgent.Model.VisaCountry model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update VisaCountry set ");
            strSql.Append("Name=@Name,");
            strSql.Append("PicUrl=@PicUrl,");
            strSql.Append("Tips=@Tips,");
            strSql.Append("EnglishName=@EnglishName,");
            strSql.Append("FirstWord=@FirstWord,");
            strSql.Append("Sort=@Sort,");
            strSql.Append("isLock=@isLock,");
            strSql.Append("ParentId=@ParentId,");
            strSql.Append("ClassList=@ClassList,");
            strSql.Append("ClassLayer=@ClassLayer");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@Name", SqlDbType.NVarChar,50),
					new SqlParameter("@PicUrl", SqlDbType.VarChar,50),
					new SqlParameter("@Tips", SqlDbType.Text),
					new SqlParameter("@EnglishName", SqlDbType.VarChar,50),
					new SqlParameter("@FirstWord", SqlDbType.VarChar,50),
                    new SqlParameter("@Sort",SqlDbType.Int,4),
					new SqlParameter("@isLock", SqlDbType.Int,4),
                    new SqlParameter("@ParentId", SqlDbType.Int,4),
                    new SqlParameter("@ClassList", SqlDbType.VarChar,50),
                    new SqlParameter("@ClassLayer", SqlDbType.Int,4),
                    new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters[0].Value = model.Name;
            parameters[1].Value = model.PicUrl;
            parameters[2].Value = model.Tips;
            parameters[3].Value = model.EnglishName;
            parameters[4].Value = model.FirstWord;
            parameters[5].Value = model.Sort;
            parameters[6].Value = model.isLock;
            parameters[7].Value = model.ParentId;
            parameters[8].Value = model.ClassList;
            parameters[9].Value = model.ClassLayer;
            parameters[10].Value = model.Id;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除该所有属下分类数据
        /// </summary>
        public void Delete(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from VisaCountry ");
            strSql.Append(" where ClassList like '%," + Id + ",%' ");

            DbHelperSQL.Query(strSql.ToString());
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public TravelAgent.Model.VisaCountry GetModel(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Id,Name,PicUrl,Tips,EnglishName,FirstWord,Sort,isLock,ParentId,ClassList,ClassLayer from VisaCountry ");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters[0].Value = Id;

            TravelAgent.Model.VisaCountry model = new TravelAgent.Model.VisaCountry();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Id"].ToString() != "")
                {
                    model.Id = int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
                }
                model.Name= ds.Tables[0].Rows[0]["Name"].ToString();
                model.PicUrl = ds.Tables[0].Rows[0]["PicUrl"].ToString();
                model.Tips = ds.Tables[0].Rows[0]["Tips"].ToString();
                model.EnglishName = ds.Tables[0].Rows[0]["EnglishName"].ToString();
                model.FirstWord = ds.Tables[0].Rows[0]["FirstWord"].ToString();
                if (ds.Tables[0].Rows[0]["Sort"].ToString() != "")
                {
                    model.Sort = int.Parse(ds.Tables[0].Rows[0]["Sort"].ToString());
                }
                if (ds.Tables[0].Rows[0]["isLock"].ToString() != "")
                {
                    model.isLock = int.Parse(ds.Tables[0].Rows[0]["isLock"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ParentId"].ToString() != "")
                {
                    model.ParentId = int.Parse(ds.Tables[0].Rows[0]["ParentId"].ToString());
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
        /// 取得所有列表
        /// </summary>
        /// <param name="PId">父ID</param>
        /// <param name="KId">种类ID</param>
        /// <returns></returns>
        public DataTable GetList(int PId,string strWhere)
        {
            DataTable data = new DataTable();
            //创建列
            DataColumn Id = new DataColumn("Id", typeof(int));
            DataColumn Name = new DataColumn("Name", typeof(string));
            DataColumn PicUrl = new DataColumn("PicUrl", typeof(string));
            DataColumn Tips = new DataColumn("Tips", typeof(string));
            DataColumn EnglishName = new DataColumn("EnglishName", typeof(string));
            DataColumn FirstWord = new DataColumn("FirstWord", typeof(string));
            DataColumn Sort = new DataColumn("Sort", typeof(int));
            DataColumn isLock = new DataColumn("isLock", typeof(int));
            DataColumn ParentId = new DataColumn("ParentId", typeof(int));
            DataColumn ClassList = new DataColumn("ClassList", typeof(string));
            DataColumn ClassLayer = new DataColumn("ClassLayer", typeof(int));
            DataColumn subcount = new DataColumn("subcount", typeof(string));
            //添加列
            data.Columns.Add(Id);
            data.Columns.Add(Name);
            data.Columns.Add(PicUrl);
            data.Columns.Add(Tips);
            data.Columns.Add(EnglishName);
            data.Columns.Add(FirstWord);
            data.Columns.Add(Sort);
            data.Columns.Add(isLock);
            data.Columns.Add(ParentId);
            data.Columns.Add(ClassList);
            data.Columns.Add(ClassLayer);
            data.Columns.Add(subcount);
            //调用迭代组合成DAGATABLE
            List<int> ids = new List<int>();
            GetChild(data, PId, strWhere, ids);
            return data;
        }

        /// <summary>
        /// 取得该所有下级列表
        /// </summary>
        /// <param name="data">DATATABLE名</param>
        /// <param name="PId">父栏目ID</param>
        /// <param name="KId">种类ID</param>
        private void GetChild(DataTable data, int PId,string strWhere, List<int> ids)
        {
            if (ids.Contains(PId)) return;
            ids.Add(PId);
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Id,Name,PicUrl,Tips,EnglishName,FirstWord,Sort,isLock,ParentId,ClassList,ClassLayer from VisaCountry");
           
            strSql.Append(" where ParentId=" + PId + "");
            if (!string.IsNullOrEmpty(strWhere))
            {
                strSql.Append(" and "+strWhere);
            }
            strSql.Append(" order by Sort asc,Id desc");
            DataSet ds = DbHelperSQL.Query(strSql.ToString());

            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    DataRow dr = ds.Tables[0].Rows[i];
                    //添加一行数据
                    DataRow row = data.NewRow();
                    row[0] = int.Parse(dr["Id"].ToString());
                    row[1] = dr["Name"].ToString();
                    row[2] = dr["PicUrl"].ToString();
                    row[3] = dr["Tips"].ToString();
                    row[4] = dr["EnglishName"].ToString();
                    row[5] = dr["FirstWord"].ToString();
                    row[6] = int.Parse(dr["Sort"].ToString());
                    row[7] = int.Parse(dr["isLock"].ToString());
                    row[8] = int.Parse(dr["ParentId"].ToString());
                    row[9] = dr["ClassList"].ToString();
                    row[10] = int.Parse(dr["ClassLayer"].ToString());

                    data.Rows.Add(row);
                    //调用自身迭代
                    this.GetChild(data, int.Parse(dr["Id"].ToString()), strWhere, ids);
                }
            }
        }

        /// <summary>
        /// 取得该类别下的集合
        /// </summary>
        /// <param name="classId"></param>
        /// <returns></returns>
        public DataSet GetListByClassId(int classId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 ClassList,ClassLayer from VisaCountry");
            strSql.Append(" where Id=" + classId + " ");
            return DbHelperSQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 取得目的地集合
        /// </summary>
        /// <param name="classId"></param>
        /// <returns></returns>
        public DataSet GetListByParentId(int parentId, int? top)
        {
            StringBuilder strSql = new StringBuilder();
            if (top != null)
            {
                strSql.Append("select top " + top + " * from VisaCountry");
            }
            else
            {
                strSql.Append("select * from VisaCountry");
            }
            strSql.Append(" where ParentId=" + parentId + " order by Sort asc");
            return DbHelperSQL.Query(strSql.ToString());
        }
        #endregion  成员方法
    }
}
