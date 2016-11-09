﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
namespace TravelAgent.IDAL
{
    public interface IAdminList
    {
        /// <summary>
        /// 取得最新插入的ID
        /// </summary>
        int GetMaxID(string FieldName);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        void Add(TravelAgent.Model.AdminList model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        int Update(TravelAgent.Model.AdminList model);
        /// <summary>
        /// 删除数据
        /// </summary>
        int Delete(int Id);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        TravelAgent.Model.AdminList GetModel(int Id);
         /// <summary>
        /// 得到一个对象实体
        /// </summary>
       TravelAgent.Model.AdminList GetAccountByUser(string username, string password);
        /// <summary>
        /// 获得数据列表
        /// </summary>
        DataSet GetList();
        /// <summary>
        /// 获得数据列表
        /// </summary>
        DataSet GetList(string strWhere);
    }
}
