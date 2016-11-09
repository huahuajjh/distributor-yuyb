using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TravelAgent.IDAL
{
    public interface ILineContent
    {
        /// <summary>
        /// 删除数据
        /// </summary>
        int Delete(int lineid);
        /// <summary>
        /// 批量添加
        /// </summary>
        /// <param name="strsqllist"></param>
        void InsertContents(ArrayList strsqllist);
         /// <summary>
        /// 根据编号获得集合
        /// </summary>
        /// <param name="lineid"></param>
        /// <returns></returns>
        List<TravelAgent.Model.LineContent> GetlstLineContentByLineId(int lineid);
    }
}
