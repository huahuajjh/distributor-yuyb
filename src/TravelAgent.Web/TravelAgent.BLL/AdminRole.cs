using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using TravelAgent.IDAL;
using TravelAgent.DALFactory;
namespace TravelAgent.BLL
{
    public class AdminRole
    {
        private static readonly IAdminRole RoleDAL = DALBuild.CreateAdminRole();

        /// <summary>
        /// 取得最新插入的ID
        /// </summary>
        public int GetMaxID(string FieldName)
        {
            return RoleDAL.GetMaxID(FieldName);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(TravelAgent.Model.AdminRole model)
        {
            RoleDAL.Add(model);
            return RoleDAL.GetMaxID("Id");
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(TravelAgent.Model.AdminRole model)
        {
            return RoleDAL.Update(model);
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        public int Delete(int Id)
        {
            return RoleDAL.Delete(Id);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public TravelAgent.Model.AdminRole GetModel(int Id)
        {
            return RoleDAL.GetModel(Id);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList()
        {
            return RoleDAL.GetList();
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return RoleDAL.GetList(strWhere);
        }
    }
}
