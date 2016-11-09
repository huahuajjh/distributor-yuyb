using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TravelAgent.IDAL;
using TravelAgent.DALFactory;

namespace TravelAgent.BLL
{
    public class JoinProperty
    {
        private static readonly IJoinProperty  PropertyDAL = DALBuild.CreateJoinProperty();

         /// <summary>
        /// 取得最新插入的ID
        /// </summary>
        public int GetMaxID(string FieldName)
        {
            return PropertyDAL.GetMaxID(FieldName);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(TravelAgent.Model.JoinProperty model)
        {
            PropertyDAL.Add(model);
            return PropertyDAL.GetMaxID("Id");
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(TravelAgent.Model.JoinProperty model)
        {
            PropertyDAL.Update(model);
        }

         /// <summary>
        /// 删除数据
        /// </summary>
        public void Delete(int Id)
        {
            PropertyDAL.Delete(Id);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public TravelAgent.Model.JoinProperty GetModel(int Id)
        {
            return PropertyDAL.GetModel(Id);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList()
        {
            return PropertyDAL.GetList();
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return PropertyDAL.GetList(strWhere);
        }
    }
}
