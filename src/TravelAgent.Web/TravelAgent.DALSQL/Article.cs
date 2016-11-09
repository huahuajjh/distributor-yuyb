using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using TravelAgent.Tool;//请先添加引用
using TravelAgent.IDAL;
namespace TravelAgent.DALSQL
{
	/// <summary>
	/// 数据访问类Article。
	/// </summary>
	public class Article:IArticle
	{
		public Article()
		{}
		#region  成员方法
        /// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int Id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Article");
			strSql.Append(" where Id=@Id ");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)};
			parameters[0].Value = Id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}

        /// <summary>
        /// 返回长查询数据总数 （分页用到）
        /// </summary>
        public int GetCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(*) as H ");
            strSql.Append(" from Article ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return Convert.ToInt32(DbHelperSQL.GetSingle(strSql.ToString()));
        }
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(TravelAgent.Model.Article model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Article(");
            strSql.Append("Title,Author,Form,Keyword,Zhaiyao,ClassId,ImgUrl,Daodu,Content,Click,IsMsg,IsTop,IsRed,IsHot,IsSlide,IsLock,AddTime,LinkUrl,DestId,Dest)");
			strSql.Append(" values (");
            strSql.Append("@Title,@Author,@Form,@Keyword,@Zhaiyao,@ClassId,@ImgUrl,@Daodu,@Content,@Click,@IsMsg,@IsTop,@IsRed,@IsHot,@IsSlide,@IsLock,@AddTime,@LinkUrl,@DestId,@Dest)");
			SqlParameter[] parameters = {
					new SqlParameter("@Title", SqlDbType.NVarChar,200),
					new SqlParameter("@Author", SqlDbType.NVarChar,50),
					new SqlParameter("@Form", SqlDbType.NVarChar,100),
					new SqlParameter("@Keyword", SqlDbType.NVarChar,100),
					new SqlParameter("@Zhaiyao", SqlDbType.NVarChar,250),
					new SqlParameter("@ClassId", SqlDbType.Int,4),
					new SqlParameter("@ImgUrl", SqlDbType.NVarChar,250),
					new SqlParameter("@Daodu", SqlDbType.NVarChar,250),
					new SqlParameter("@Content", SqlDbType.NVarChar),
					new SqlParameter("@Click", SqlDbType.Int,4),
					new SqlParameter("@IsMsg", SqlDbType.Int,4),
					new SqlParameter("@IsTop", SqlDbType.Int,4),
					new SqlParameter("@IsRed", SqlDbType.Int,4),
					new SqlParameter("@IsHot", SqlDbType.Int,4),
					new SqlParameter("@IsSlide", SqlDbType.Int,4),
					new SqlParameter("@IsLock", SqlDbType.Int,4),
					new SqlParameter("@AddTime", SqlDbType.DateTime),
                    new SqlParameter("@LinkUrl", SqlDbType.NVarChar,250),
                                        new SqlParameter("@DestId", SqlDbType.VarChar,50),
                                        new SqlParameter("@Dest", SqlDbType.VarChar,100)};
			parameters[0].Value = model.Title;
			parameters[1].Value = model.Author;
			parameters[2].Value = model.Form;
			parameters[3].Value = model.Keyword;
			parameters[4].Value = model.Zhaiyao;
			parameters[5].Value = model.ClassId;
			parameters[6].Value = model.ImgUrl;
			parameters[7].Value = model.Daodu;
			parameters[8].Value = model.Content;
			parameters[9].Value = model.Click;
			parameters[10].Value = model.IsMsg;
			parameters[11].Value = model.IsTop;
			parameters[12].Value = model.IsRed;
			parameters[13].Value = model.IsHot;
			parameters[14].Value = model.IsSlide;
			parameters[15].Value = model.IsLock;
			parameters[16].Value = model.AddTime;
            parameters[17].Value = model.LinkUrl;
            parameters[18].Value = model.DestId;
            parameters[19].Value = model.Dest;
            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
		}
        /// <summary>
        /// 修改一条数据
        /// </summary>
        public void UpdateField(int Id, string strValue)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Article set " + strValue);
            strSql.Append(" where Id=" + Id);
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(TravelAgent.Model.Article model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Article set ");
			strSql.Append("Title=@Title,");
			strSql.Append("Author=@Author,");
			strSql.Append("Form=@Form,");
			strSql.Append("Keyword=@Keyword,");
			strSql.Append("Zhaiyao=@Zhaiyao,");
			strSql.Append("ClassId=@ClassId,");
			strSql.Append("ImgUrl=@ImgUrl,");
			strSql.Append("Daodu=@Daodu,");
			strSql.Append("Content=@Content,");
			strSql.Append("Click=@Click,");
			strSql.Append("IsMsg=@IsMsg,");
			strSql.Append("IsTop=@IsTop,");
			strSql.Append("IsRed=@IsRed,");
			strSql.Append("IsHot=@IsHot,");
			strSql.Append("IsSlide=@IsSlide,");
			strSql.Append("IsLock=@IsLock,");
			strSql.Append("AddTime=@AddTime,");
            strSql.Append("LinkUrl=@LinkUrl,");
            strSql.Append("DestId=@DestId,");
            strSql.Append("Dest=@Dest");
			strSql.Append(" where Id=@Id ");
			SqlParameter[] parameters = {
					new SqlParameter("@Title", SqlDbType.NVarChar,200),
					new SqlParameter("@Author", SqlDbType.NVarChar,50),
					new SqlParameter("@Form", SqlDbType.NVarChar,100),
					new SqlParameter("@Keyword", SqlDbType.NVarChar,100),
					new SqlParameter("@Zhaiyao", SqlDbType.NVarChar,250),
					new SqlParameter("@ClassId", SqlDbType.Int,4),
					new SqlParameter("@ImgUrl", SqlDbType.NVarChar,250),
					new SqlParameter("@Daodu", SqlDbType.NVarChar,250),
					new SqlParameter("@Content", SqlDbType.NVarChar),
					new SqlParameter("@Click", SqlDbType.Int,4),
					new SqlParameter("@IsMsg", SqlDbType.Int,4),
					new SqlParameter("@IsTop", SqlDbType.Int,4),
					new SqlParameter("@IsRed", SqlDbType.Int,4),
					new SqlParameter("@IsHot", SqlDbType.Int,4),
					new SqlParameter("@IsSlide", SqlDbType.Int,4),
					new SqlParameter("@IsLock", SqlDbType.Int,4),
					new SqlParameter("@AddTime", SqlDbType.DateTime),
                    new SqlParameter("@LinkUrl", SqlDbType.NVarChar,250),
                    new SqlParameter("@DestId", SqlDbType.VarChar,50),
                    new SqlParameter("@Dest", SqlDbType.VarChar,100),
                    new SqlParameter("@Id", SqlDbType.Int,4)};
			parameters[0].Value = model.Title;
			parameters[1].Value = model.Author;
			parameters[2].Value = model.Form;
			parameters[3].Value = model.Keyword;
			parameters[4].Value = model.Zhaiyao;
			parameters[5].Value = model.ClassId;
			parameters[6].Value = model.ImgUrl;
			parameters[7].Value = model.Daodu;
			parameters[8].Value = model.Content;
			parameters[9].Value = model.Click;
			parameters[10].Value = model.IsMsg;
			parameters[11].Value = model.IsTop;
			parameters[12].Value = model.IsRed;
			parameters[13].Value = model.IsHot;
			parameters[14].Value = model.IsSlide;
			parameters[15].Value = model.IsLock;
			parameters[16].Value = model.AddTime;
            parameters[17].Value = model.LinkUrl;
            parameters[18].Value = model.DestId;
            parameters[19].Value = model.Dest;
            parameters[20].Value = model.Id;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int Id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Article ");
			strSql.Append(" where Id=@Id ");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)};
			parameters[0].Value = Id;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public TravelAgent.Model.Article GetModel(int Id)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select  top 1 * from Article ");
			strSql.Append(" where Id=@Id ");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)};
			parameters[0].Value = Id;

			TravelAgent.Model.Article model=new TravelAgent.Model.Article();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["Id"].ToString()!="")
				{
					model.Id=int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
				}
				model.Title=ds.Tables[0].Rows[0]["Title"].ToString();
				model.Author=ds.Tables[0].Rows[0]["Author"].ToString();
				model.Form=ds.Tables[0].Rows[0]["Form"].ToString();
				model.Keyword=ds.Tables[0].Rows[0]["Keyword"].ToString();
				model.Zhaiyao=ds.Tables[0].Rows[0]["Zhaiyao"].ToString();
				if(ds.Tables[0].Rows[0]["ClassId"].ToString()!="")
				{
					model.ClassId=int.Parse(ds.Tables[0].Rows[0]["ClassId"].ToString());
				}
				model.ImgUrl=ds.Tables[0].Rows[0]["ImgUrl"].ToString();
				model.Daodu=ds.Tables[0].Rows[0]["Daodu"].ToString();
				model.Content=ds.Tables[0].Rows[0]["Content"].ToString();
				if(ds.Tables[0].Rows[0]["Click"].ToString()!="")
				{
					model.Click=int.Parse(ds.Tables[0].Rows[0]["Click"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsMsg"].ToString()!="")
				{
					model.IsMsg=int.Parse(ds.Tables[0].Rows[0]["IsMsg"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsTop"].ToString()!="")
				{
					model.IsTop=int.Parse(ds.Tables[0].Rows[0]["IsTop"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsRed"].ToString()!="")
				{
					model.IsRed=int.Parse(ds.Tables[0].Rows[0]["IsRed"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsHot"].ToString()!="")
				{
					model.IsHot=int.Parse(ds.Tables[0].Rows[0]["IsHot"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsSlide"].ToString()!="")
				{
					model.IsSlide=int.Parse(ds.Tables[0].Rows[0]["IsSlide"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsLock"].ToString()!="")
				{
					model.IsLock=int.Parse(ds.Tables[0].Rows[0]["IsLock"].ToString());
				}
				if(ds.Tables[0].Rows[0]["AddTime"].ToString()!="")
				{
					model.AddTime=DateTime.Parse(ds.Tables[0].Rows[0]["AddTime"].ToString());
				}
                model.LinkUrl = ds.Tables[0].Rows[0]["LinkUrl"].ToString();
                model.DestId = ds.Tables[0].Rows[0]["DestId"].ToString();
                model.Dest = ds.Tables[0].Rows[0]["Dest"].ToString();
				return model;
			}
			else
			{
				return null;
			}
		}
        /// <summary>
        /// 获得上一条记录
        /// </summary>
        /// <param name="curId"></param>
        /// <returns></returns>
        public TravelAgent.Model.Article GetSpeModel(int curId,string type,int classid)
        {
            StringBuilder strSql = new StringBuilder();
            if (type == "p")
            {
                strSql.Append("select  top 1 Id,Title,Author,Form,Keyword,Zhaiyao,ClassId,ImgUrl,Daodu,Content,Click,IsMsg,IsTop,IsRed,IsHot,IsSlide,IsLock,AddTime,LinkUrl from Article ");
                strSql.Append(" where Id<@Id and ClassId=" + classid + " order by Id desc");
            }
            else if (type == "n")
            {
                strSql.Append("select  top 1 Id,Title,Author,Form,Keyword,Zhaiyao,ClassId,ImgUrl,Daodu,Content,Click,IsMsg,IsTop,IsRed,IsHot,IsSlide,IsLock,AddTime,LinkUrl from Article ");
                strSql.Append(" where Id>@Id and ClassId=" + classid + " order by Id desc");
            }
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters[0].Value = curId;

            TravelAgent.Model.Article model = new TravelAgent.Model.Article();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Id"].ToString() != "")
                {
                    model.Id = int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
                }
                model.Title = ds.Tables[0].Rows[0]["Title"].ToString();
                model.Author = ds.Tables[0].Rows[0]["Author"].ToString();
                model.Form = ds.Tables[0].Rows[0]["Form"].ToString();
                model.Keyword = ds.Tables[0].Rows[0]["Keyword"].ToString();
                model.Zhaiyao = ds.Tables[0].Rows[0]["Zhaiyao"].ToString();
                if (ds.Tables[0].Rows[0]["ClassId"].ToString() != "")
                {
                    model.ClassId = int.Parse(ds.Tables[0].Rows[0]["ClassId"].ToString());
                }
                model.ImgUrl = ds.Tables[0].Rows[0]["ImgUrl"].ToString();
                model.Daodu = ds.Tables[0].Rows[0]["Daodu"].ToString();
                model.Content = ds.Tables[0].Rows[0]["Content"].ToString();
                if (ds.Tables[0].Rows[0]["Click"].ToString() != "")
                {
                    model.Click = int.Parse(ds.Tables[0].Rows[0]["Click"].ToString());
                }
                if (ds.Tables[0].Rows[0]["IsMsg"].ToString() != "")
                {
                    model.IsMsg = int.Parse(ds.Tables[0].Rows[0]["IsMsg"].ToString());
                }
                if (ds.Tables[0].Rows[0]["IsTop"].ToString() != "")
                {
                    model.IsTop = int.Parse(ds.Tables[0].Rows[0]["IsTop"].ToString());
                }
                if (ds.Tables[0].Rows[0]["IsRed"].ToString() != "")
                {
                    model.IsRed = int.Parse(ds.Tables[0].Rows[0]["IsRed"].ToString());
                }
                if (ds.Tables[0].Rows[0]["IsHot"].ToString() != "")
                {
                    model.IsHot = int.Parse(ds.Tables[0].Rows[0]["IsHot"].ToString());
                }
                if (ds.Tables[0].Rows[0]["IsSlide"].ToString() != "")
                {
                    model.IsSlide = int.Parse(ds.Tables[0].Rows[0]["IsSlide"].ToString());
                }
                if (ds.Tables[0].Rows[0]["IsLock"].ToString() != "")
                {
                    model.IsLock = int.Parse(ds.Tables[0].Rows[0]["IsLock"].ToString());
                }
                if (ds.Tables[0].Rows[0]["AddTime"].ToString() != "")
                {
                    model.AddTime = DateTime.Parse(ds.Tables[0].Rows[0]["AddTime"].ToString());
                }
                model.LinkUrl = ds.Tables[0].Rows[0]["LinkUrl"].ToString();
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
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
            strSql.Append(" Id,Title,Author,Form,Keyword,Zhaiyao,ClassId,ImgUrl,Daodu,Content,Click,IsMsg,IsTop,IsRed,IsHot,IsSlide,IsLock,AddTime,LinkUrl ");
			strSql.Append(" FROM Article ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

        /// <summary>
        /// 获得指定的类别下所有文章
        /// </summary>
        public DataSet GetList(int classId, int kindId, int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" Id,Title,Author,Form,Keyword,Zhaiyao,ClassId,ImgUrl,Daodu,Content,Click,IsMsg,IsTop,IsRed,IsHot,IsSlide,IsLock,AddTime,LinkUrl ");
            strSql.Append(" FROM Article");
            strSql.Append(" where ClassId in(select Id from Channel where KindId=" + kindId + " and ClassList like '%," + classId + ",%')");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" and " + strWhere);
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
                strSql.Append("select top " + pageSize + " Id,Title,Author,Form,Keyword,Zhaiyao,ClassId,ImgUrl,Daodu,Content,Click,IsMsg,IsTop,IsRed,IsHot,IsSlide,IsLock,AddTime,LinkUrl from Article");
                strSql.Append(" where Id not in(select top " + topNum + " Id from Article");
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
                strSql.Append("select top " + pageSize + " Id,Title,Author,Form,Keyword,Zhaiyao,ClassId,ImgUrl,Daodu,Content,Click,IsMsg,IsTop,IsRed,IsHot,IsSlide,IsLock,AddTime,LinkUrl from Article");
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