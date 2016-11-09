using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace TravelAgent.IDAL
{
    public interface IInfoSetting
    {
        /// <summary>
        /// 获得数据列表
        /// </summary>
       DataSet GetList();
          /// <summary>
        /// 修改
        /// </summary>
        /// <param name="ht"></param>
        /// <returns></returns>
        void UpdateValue(Hashtable ht);
    }
}
