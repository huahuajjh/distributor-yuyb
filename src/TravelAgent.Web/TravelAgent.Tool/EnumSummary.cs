using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TravelAgent.Tool
{
    public class EnumSummary
    {
        /// <summary>
        /// 状态
        /// </summary>
        public enum State
        {
            推荐=1,
            特价=2,
            热卖=3,
            新品=4
        }
        /// <summary>
        /// 状态
        /// </summary>
        public enum ClubClass
        {
            普通会员 = 0,
            铜牌会员 = 1,
            银牌会员 = 2,
            金牌会员 = 3
        }
        /// <summary>
        /// 订单状态
        /// </summary>
        public enum OrderState
        {
            已取消=0,
            填写信息=1,
            核对订单=2,
            处理中=3,
            待付款= 4,
            已付款=5,
            预订成功=6
        }
        /// <summary>
        /// 游客类型
        /// </summary>
        public enum TouristType
        { 
            成人=0,
            儿童=3
        }
        /// <summary>
        /// 性别
        /// </summary>
        public enum TouristSex
        { 
            女=0,
            男=1
        }
        /// <summary>
        /// 证件类型
        /// </summary>
        public enum PapersType
        { 
            身份证=0,
            护照=4,
            军官证=2,
            台胞证=6,
            回乡证=7
        }
        /// <summary>
        /// 处理方式
        /// </summary>
        public enum DealType
        { 
            人工处理=0,
            自动处理=1
        }
        /// <summary> 
        /// 密码强度 
        /// </summary> 
        public enum Strength
        {
            Invalid = 0, //无效密码     
            Weak = 1,    //低强度密码     
            Normal = 2,  //中强度密码     
            Strong = 3//强度密码
        }
        /// <summary>
        /// 积分类型
        /// </summary>
        public enum PointsType
        { 
            注册=1,
            手机验证=2,
            邮箱验证=3,
            产品预订=4,
            赠送积分=5,
            其他=8
        }
        /// <summary>
        /// 付款方式
        /// </summary>
        public enum PayType
        {
            银行转账 = 1,
            现金 = 2,
            支票 = 3,
            支付宝 = 4,
            网银在线 = 5,
            退款 = 6,
            其他 = 7,
            微信支付=8
        }
        /// <summary>
        /// 签证类型
        /// </summary>
        public enum OrderType
        { 
            线路=1,
            签证=2,
            租车=3
        }
        /// <summary>
        /// 订单来源
        /// </summary>
        public enum SourceType
        {
            PC网页 = 1,
            移动WAP = 2
        }
        /// <summary>
        /// 业务类型
        /// </summary>
        public enum CustomBusinessType
        {
            私人包团=1,
            公司旅游=2,
            高级定制=3
        }
        /// <summary>
        /// 变速器
        /// </summary>
        public enum CarBSQ
        { 
            手动挡=0,
            自动挡=1,
            混合挡=2
        }
    }
}
