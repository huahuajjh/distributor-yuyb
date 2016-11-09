using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using TravelAgent.IDAL;
using TravelAgent.DALFactory;

namespace TravelAgent.BLL
{
    public class AdminList
    {
        private static readonly IAdminList AdminDAL = DALBuild.CreateAdminList();
        private static readonly IAdminRole RoleDAL = DALBuild.CreateAdminRole();
        /// <summary>
        /// 取得最新插入的ID
        /// </summary>
        public int GetMaxID(string FieldName)
        {
            return AdminDAL.GetMaxID(FieldName);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(TravelAgent.Model.AdminList model)
        {
            AdminDAL.Add(model);
            return AdminDAL.GetMaxID("Id");
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(TravelAgent.Model.AdminList model)
        {
            return AdminDAL.Update(model);
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        public int Delete(int Id)
        {
            return AdminDAL.Delete(Id);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public TravelAgent.Model.AdminList GetModel(int Id)
        {
            return AdminDAL.GetModel(Id);
        }
         /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public TravelAgent.Model.AdminList GetAccountByUser(string username, string password)
        {
            TravelAgent.Model.AdminList admin=AdminDAL.GetAccountByUser(username, password);
            if(admin!=null)
            {
                admin.Role=RoleDAL.GetModel(admin.RoleId);
            }
            return admin;
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList()
        {
            return AdminDAL.GetList();
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return AdminDAL.GetList(strWhere);
        }
    }
}
