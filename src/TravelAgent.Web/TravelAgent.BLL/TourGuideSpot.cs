﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TravelAgent.IDAL;
using TravelAgent.DALFactory;

namespace TravelAgent.BLL
{
    public class TourGuideSpot
    {
        private static readonly ITourGuideSpot TourGuideTempDAL = DALBuild.CreateTourGuideSpot();

        /// <summary>
        /// 取得最新插入的ID
        /// </summary>
        public int GetMaxID(string FieldName)
        {
            return TourGuideTempDAL.GetMaxID(FieldName);
        }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int Id)
        {
            return TourGuideTempDAL.Exists(Id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(TravelAgent.Model.TourGuideSpot model)
        {
            TourGuideTempDAL.Add(model);
            return TourGuideTempDAL.GetMaxID("Id");
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(TravelAgent.Model.TourGuideSpot model)
        {
            TourGuideTempDAL.Update(model);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int Id)
        {
            TourGuideTempDAL.Delete(Id);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public TravelAgent.Model.TourGuideSpot GetModel(int Id)
        {
            return TourGuideTempDAL.GetModel(Id);
        }
        /// <summary>
        /// 取得所有游记列表
        /// </summary>
        /// <param name="PId">父ID</param>
        /// <param name="KId">种类ID</param>
        /// <returns></returns>
        public List<TravelAgent.Model.TourGuideSpot> GetList()
        {
            List<TravelAgent.Model.TourGuideSpot> dt = new List<Model.TourGuideSpot>();
            dt = TourGuideTempDAL.GetList();
            return dt;
        }
        public List<TravelAgent.Model.TourGuideSpot> GetList(int pid)
        {
            List<TravelAgent.Model.TourGuideSpot> dt = new List<Model.TourGuideSpot>();
            dt = TourGuideTempDAL.GetList(pid);
            return dt;
        }
    }
}
