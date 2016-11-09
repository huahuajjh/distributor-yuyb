using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using TravelAgent.IDAL;
using TravelAgent.DALFactory;


namespace TravelAgent.BLL
{
    public class CarClass
    {
        private static readonly ICarClass DAL = DALBuild.CreateCarClass();

        /// <summary>
        /// 取得最新插入的ID
        /// </summary>
        public int GetMaxID(string FieldName)
        {
            return DAL.GetMaxID(FieldName);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(TravelAgent.Model.CarClass model)
        {
            DAL.Add(model);
            return DAL.GetMaxID("Id");
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(TravelAgent.Model.CarClass model)
        {
            DAL.Update(model);
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        public void Delete(int Id)
        {
            DAL.Delete(Id);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public TravelAgent.Model.CarClass GetModel(int Id)
        {
            return DAL.GetModel(Id);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList()
        {
            return DAL.GetList();
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return DAL.GetList(strWhere);
        }
    }
}
