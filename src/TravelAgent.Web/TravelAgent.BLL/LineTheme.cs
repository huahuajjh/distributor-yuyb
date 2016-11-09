using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TravelAgent.IDAL;
using TravelAgent.DALFactory;

namespace TravelAgent.BLL
{
    public class LineTheme
    {
        private static readonly ILineTheme ThemeDAL = DALBuild.CreateLineTheme();

        /// <summary>
        /// 取得最新插入的ID
        /// </summary>
        public int GetMaxID(string FieldName)
        {
            return ThemeDAL.GetMaxID(FieldName);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(TravelAgent.Model.LineTheme model)
        {
            ThemeDAL.Add(model);
            return ThemeDAL.GetMaxID("Id");
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(TravelAgent.Model.LineTheme model)
        {
            ThemeDAL.Update(model);
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        public void Delete(int Id)
        {
            ThemeDAL.Delete(Id);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public TravelAgent.Model.LineTheme GetModel(int Id)
        {
            return ThemeDAL.GetModel(Id);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList()
        {
            return ThemeDAL.GetList();
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return ThemeDAL.GetList(strWhere);
        }
    }
}
