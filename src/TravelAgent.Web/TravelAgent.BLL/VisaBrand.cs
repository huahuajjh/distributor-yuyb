using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using TravelAgent.IDAL;
using TravelAgent.DALFactory;
namespace TravelAgent.BLL
{
    public class VisaBrand
    {
        private static readonly IVisaBrand BrandDAL = DALBuild.CreateVisaBrand();

        /// <summary>
        /// 取得最新插入的ID
        /// </summary>
        public int GetMaxID(string FieldName)
        {
            return BrandDAL.GetMaxID(FieldName);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(TravelAgent.Model.VisaBrand model)
        {
            BrandDAL.Add(model);
            return BrandDAL.GetMaxID("Id");
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(TravelAgent.Model.VisaBrand model)
        {
            BrandDAL.Update(model);
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        public void Delete(int Id)
        {
            BrandDAL.Delete(Id);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public TravelAgent.Model.VisaBrand GetModel(int Id)
        {
            return BrandDAL.GetModel(Id);
        }
         /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return BrandDAL.GetList(Top, strWhere, filedOrder);
        }
    }
}
