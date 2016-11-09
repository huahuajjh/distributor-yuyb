using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TravelAgent.Model
{
    public class CustomOrder
    {
        /// <summary>
        /// 自动编号
        /// </summary>
        public int Id;
        /// <summary>
        /// 城市景点
        /// </summary>
        public string Jindians;
        /// <summary>
        /// 业务类型
        /// </summary>
        public int CustomType;
        /// <summary>
        /// 行程天数
        /// </summary>
        public int LineDay;
        /// <summary>
        /// 出游人数
        /// </summary>
        public int LinePeopleNumber;
        /// <summary>
        /// 单人预算
        /// </summary>
        public int PeoplePrice;
        /// <summary>
        /// 出游日期
        /// </summary>
        public string TravelDate;
        /// <summary>
        /// 联系人
        /// </summary>
        public string LinkName;
        /// <summary>
        /// 联系电话
        /// </summary>
        public string LinkTelephone;
        /// <summary>
        /// 其他需求
        /// </summary>
        public string OtherMsg;
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime AddDate;
    }
}
