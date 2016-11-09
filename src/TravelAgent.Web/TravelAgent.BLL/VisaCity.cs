using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using TravelAgent.IDAL;
using TravelAgent.DALFactory;

namespace TravelAgent.BLL
{
    public class VisaCity
    {
        private static readonly IVisaCity CityDAL = DALBuild.CreateVisaCity();

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
        public int Add(TravelAgent.Model.VisaCity model)
        {
            CityDAL.Add(model);
            return CityDAL.GetMaxID("Id");
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(TravelAgent.Model.VisaCity model)
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
        public TravelAgent.Model.VisaCity GetModel(int Id)
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
