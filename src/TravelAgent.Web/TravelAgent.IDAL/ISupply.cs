using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TravelAgent.IDAL
{
    public interface ISupply
    {
        /// <summary>
        /// 取得最新插入的ID
        /// </summary>
        int GetMaxID(string FieldName);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        void Add(TravelAgent.Model.Supplier model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        void Update(TravelAgent.Model.Supplier model);
        /// <summary>
        /// 删除数据
        /// </summary>
        void Delete(int Id);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        TravelAgent.Model.Supplier GetModel(int Id);
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
