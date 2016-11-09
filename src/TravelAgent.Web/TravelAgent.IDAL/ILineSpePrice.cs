using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TravelAgent.IDAL
{
    public interface ILineSpePrice
    {
        /// <summary>
        /// 批量添加
        /// </summary>
        /// <param name="strsqllist"></param>
        void InsertContents(ArrayList strsqllist);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(TravelAgent.Model.LineSpePrice model);
        /// <summary>
        /// 删除数据
        /// </summary>
        int Delete(int lineid);
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="lineid"></param>
        /// <param name="pricedate"></param>
        int Delete(int lineid, string date);
         /// <summary>
        /// 根据编号获得集合
        /// </summary>
        /// <param name="lineid"></param>
        /// <returns></returns>
        List<TravelAgent.Model.LineSpePrice> GetlstSpePriceByLineId(int lineid);
    }
}
