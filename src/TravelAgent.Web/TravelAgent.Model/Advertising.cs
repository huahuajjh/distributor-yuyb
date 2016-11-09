using System;
namespace TravelAgent.Model
{
    /// <summary>
    /// 广告位实体类Advertising
    /// </summary>
    [Serializable]
    public class Advertising
    {
        public Advertising()
        { }
        #region Model
        private int _id;
        private string _title;
        private int _adtype;
        private string _adremark;
        private int _adnum;
        private decimal _adprice;
        private int _adwidth;
        private int _adheight;
        private string _adtarget;
        private int _adchannel;
        private int _parentid;
        private string _classlist;
        private int _classlayer;
        /// <summary>
        /// 自增ID PK
        /// </summary>
        public int Id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 广告位名称
        /// </summary>
        public string Title
        {
            set { _title = value; }
            get { return _title; }
        }
        /// <summary>
        /// 广告位类型
        /// </summary>
        public int AdType
        {
            set { _adtype = value; }
            get { return _adtype; }
        }
        /// <summary>
        /// 广告位说明
        /// </summary>
        public string AdRemark
        {
            set { _adremark = value; }
            get { return _adremark; }
        }
        /// <summary>
        /// 显示广告数
        /// </summary>
        public int AdNum
        {
            set { _adnum = value; }
            get { return _adnum; }
        }
        /// <summary>
        /// 广告位价格
        /// </summary>
        public decimal AdPrice
        {
            set { _adprice = value; }
            get { return _adprice; }
        }
        /// <summary>
        /// 广告位宽度
        /// </summary>
        public int AdWidth
        {
            set { _adwidth = value; }
            get { return _adwidth; }
        }
        /// <summary>
        /// 广告位高度
        /// </summary>
        public int AdHeight
        {
            set { _adheight = value; }
            get { return _adheight; }
        }
        /// <summary>
        /// 链接目标，新窗口、原窗口
        /// </summary>
        public string AdTarget
        {
            set { _adtarget = value; }
            get { return _adtarget; }
        }

        /// <summary>
        /// 所在频道
        /// </summary>
        public int AdChannel
        {
            set { _adchannel = value; }
            get { return _adchannel; }
        }
        /// <summary>
        /// 父编号
        /// </summary>
        public int ParentID
        {
            set { _parentid = value; }
            get { return _parentid; }
        }
        /// <summary>
        /// 路径
        /// </summary>
        public string ClassList
        {
            set { _classlist = value; }
            get { return _classlist; }
        }
        /// <summary>
        /// 层级编号
        /// </summary>
        public int ClassLayer
        {
            set { _classlayer = value; }
            get { return _classlayer; }
        }
        #endregion Model

    }
}