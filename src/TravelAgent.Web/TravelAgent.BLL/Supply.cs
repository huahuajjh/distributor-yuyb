using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TravelAgent.IDAL;
using TravelAgent.DALFactory;

namespace TravelAgent.BLL
{
    public class Supply
    {
        private static readonly ISupply SupplyDAL = DALBuild.CreateSupply();

        /// <summary>
        /// 取得最新插入的ID
        /// </summary>
        public int GetMaxID(string FieldName)
        {
            return SupplyDAL.GetMaxID(FieldName);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(TravelAgent.Model.Supplier model)
        {
            SupplyDAL.Add(model);
            return SupplyDAL.GetMaxID("Id");
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(TravelAgent.Model.Supplier model)
        {
            SupplyDAL.Update(model);
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        public void Delete(int Id)
        {
            SupplyDAL.Delete(Id);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public TravelAgent.Model.Supplier GetModel(int Id)
        {
            return SupplyDAL.GetModel(Id);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList()
        {
            return SupplyDAL.GetList();
        }
         /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return SupplyDAL.GetList(strWhere);
        }
    }
}
