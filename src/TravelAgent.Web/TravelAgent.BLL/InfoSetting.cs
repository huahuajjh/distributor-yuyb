using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using TravelAgent.IDAL;
using TravelAgent.DALFactory;

namespace TravelAgent.BLL
{
    public class InfoSetting
    {
        private static readonly IInfoSetting InfoDAL = DALBuild.CreateInfoSetting();
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList()
        {
            return InfoDAL.GetList();
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="ht"></param>
        /// <returns></returns>
        public void UpdateValue(Hashtable ht)
        {
             InfoDAL.UpdateValue(ht);
        }
    }
}
