﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace TravelAgent.IDAL
{
    public interface ITourGuideRoute
    {
        /// <summary>
        /// 取得最新插入的ID
        /// </summary>
        int GetMaxID(string FieldName);
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(int Id);

        /// <summary>
        /// 增加一条数据
        /// </summary>
        void Add(TravelAgent.Model.TourGuideRoute model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        void Update(TravelAgent.Model.TourGuideRoute model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        void Delete(int Id);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        TravelAgent.Model.TourGuideRoute GetModel(int Id);
        /// <summary>
        /// 取得所有游记配置列表
        /// </summary>
        /// <param name="PId">父ID</param>
        /// <param name="KId">种类ID</param>
        /// <returns></returns>
        List<TravelAgent.Model.TourGuideRoute> GetList();
        List<TravelAgent.Model.TourGuideRoute> GetList(int pid);
    }
}
