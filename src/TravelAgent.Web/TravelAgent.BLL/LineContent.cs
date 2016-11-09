using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TravelAgent.IDAL;
using TravelAgent.DALFactory;
namespace TravelAgent.BLL
{
    public class LineContent
    {
        private static readonly ILineContent dal = DALBuild.CreateLineContent();

         /// <summary>
        /// 先删除再批量添加
        /// </summary>
        /// <param name="strsqllist"></param>
        public void InsertContents(ArrayList strsqllist,int lineid)
        {
            int intAffectNumber = dal.Delete(lineid);
            if (intAffectNumber >= 0)
            {
                dal.InsertContents(strsqllist);
            }
        }
        /// <summary>
        /// 根据编号获得集合
        /// </summary>
        /// <param name="lineid"></param>
        /// <returns></returns>
        public List<TravelAgent.Model.LineContent> GetlstLineContentByLineId(int lineid)
        {
            return dal.GetlstLineContentByLineId(lineid);
        }
    }
}
