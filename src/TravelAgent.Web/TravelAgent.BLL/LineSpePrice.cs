using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TravelAgent.IDAL;
using TravelAgent.DALFactory;

namespace TravelAgent.BLL
{
    public class LineSpePrice
    {
        private static readonly ILineSpePrice dal = DALBuild.CreateLineSpePrice();
        /// <summary>
        /// 批量添加
        /// </summary>
        /// <param name="strsqllist"></param>
        public void InsertContents(ArrayList strsqllist)
        {
            dal.InsertContents(strsqllist);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(TravelAgent.Model.LineSpePrice model)
        {
            TravelAgent.Tool.CacheHelper.Clear("speprice");
            return dal.Add(model);
        }
         /// <summary>
        /// 删除数据
        /// </summary>
        public int Delete(int lineid)
        {
            TravelAgent.Tool.CacheHelper.Clear("speprice");
            return dal.Delete(lineid);
        }
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="lineid"></param>
        /// <param name="pricedate"></param>
        public int Delete(int lineid, string date)
        {
            TravelAgent.Tool.CacheHelper.Clear("speprice");
            return dal.Delete(lineid, date);
        }
        /// <summary>
        /// 根据编号获得集合
        /// </summary>
        /// <param name="lineid"></param>
        /// <returns></returns>
        public List<TravelAgent.Model.LineSpePrice> GetlstSpePriceByLineId(int lineid)
        {
            return dal.GetlstSpePriceByLineId(lineid);
        }
    }
}
