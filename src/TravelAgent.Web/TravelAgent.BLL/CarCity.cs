using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using TravelAgent.IDAL;
using TravelAgent.DALFactory;

namespace TravelAgent.BLL
{
    public class CarCity
    {
        private static readonly ICarCity CityDAL = DALBuild.CreateCarCity();

        /// <summary>
        /// 取得最新插入的ID
        /// </summary>
        public int GetMaxID(string FieldName)
        {
            return CityDAL.GetMaxID(FieldName);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(TravelAgent.Model.CarCity model)
        {
            CityDAL.Add(model);
            return CityDAL.GetMaxID("Id");
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(TravelAgent.Model.CarCity model)
        {
            CityDAL.Update(model);
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        public void Delete(int Id)
        {
            CityDAL.Delete(Id);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public TravelAgent.Model.CarCity GetModel(int Id)
        {
            return CityDAL.GetModel(Id);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList()
        {
            return CityDAL.GetList();
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return CityDAL.GetList(strWhere);
        }
    }
}
