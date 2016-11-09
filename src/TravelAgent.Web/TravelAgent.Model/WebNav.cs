using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TravelAgent.Model
{
    public class WebNav
    {
        public int Id { get; set; }
        /// <summary>
        /// 导航名称
        /// </summary>
        public string navName { get; set; }
        /// <summary>
        /// 父ID
        /// </summary>
        public int navParentId { get; set; }
        /// <summary>
        /// 层级列表
        /// </summary>
        public string navList { get; set; }
        /// <summary>
        /// 层级编号
        /// </summary>
        public int navLayer { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public int navSort { get; set; }
        /// <summary>
        /// 导航链接
        /// </summary>
        public string navURL { get; set; }
        /// <summary>
        /// 分类编号
        /// </summary>
        public int kindId { get; set; }
        /// <summary>
        /// 导航状态: 隐藏、推荐、特价、热卖、新品
        /// </summary>
        public string State { get; set; }
    }
}
