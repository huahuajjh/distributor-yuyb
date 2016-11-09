using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using TravelAgent.IDAL;
using TravelAgent.DALFactory;

namespace TravelAgent.BLL
{
    public class VisaType
    {
        private static readonly IVisaType TypeDAL = DALBuild.CreateVisaType();

        /// <summary>
        /// 取得最新插入的ID
        /// </summary>
        public int GetMaxID(string FieldName)
        {
            return TypeDAL.GetMaxID(FieldName);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(TravelAgent.Model.VisaType model)
        {
            TypeDAL.Add(model);
            return TypeDAL.GetMaxID("Id");
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(TravelAgent.Model.VisaType model)
        {
            TypeDAL.Update(model);
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        public void Delete(int Id)
        {
            TypeDAL.Delete(Id);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public TravelAgent.Model.VisaType GetModel(int Id)
        {
            return TypeDAL.GetModel(Id);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList()
        {
            return TypeDAL.GetList();
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return TypeDAL.GetList(strWhere);
        }
    }
}
