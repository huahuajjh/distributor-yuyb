using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TravelAgent.DALFactory;
using TravelAgent.IDAL;
using System.Data;

namespace TravelAgent.BLL
{
    public class TourGuide
    {
        private static readonly ITourGuide TourGuideDAL = DALBuild.CreateTourGuide();

        /// <summary>
        /// 取得最新插入的ID
        /// </summary>
        public int GetMaxID(string FieldName) {
            return TourGuideDAL.GetMaxID(FieldName);
        }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int Id) {
            return TourGuideDAL.Exists(Id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(TravelAgent.Model.TourGuide model) {
            TourGuideDAL.Add(model);
            return TourGuideDAL.GetMaxID("Id");
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(TravelAgent.Model.TourGuide model) {
            TourGuideDAL.Update(model);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int Id) {
            TourGuideDAL.Delete(Id);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public TravelAgent.Model.TourGuide GetModel(int Id) {
            return TourGuideDAL.GetModel(Id);
        }
        /// <summary>
        /// 取得所有游记列表
        /// </summary>
        /// <param name="PId">父ID</param>
        /// <param name="KId">种类ID</param>
        /// <returns></returns>
        public List<TravelAgent.Model.TourGuide> GetList()
        {
            List<TravelAgent.Model.TourGuide> dt = new List<TravelAgent.Model.TourGuide>();
            dt = TourGuideDAL.GetList();
            return dt;
        }
        public List<TravelAgent.Model.TourGuide> GetListPublis() {
            List<TravelAgent.Model.TourGuide> dt = new List<TravelAgent.Model.TourGuide>();
            dt = TourGuideDAL.GetListPublis();
            return dt;
        }
        public DataSet GetPageList(int pageSize, int currentPage, string strWhere, string filedOrder) {
            return TourGuideDAL.GetPageList(pageSize,currentPage,strWhere,filedOrder);
        }
    }
}
