using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TravelAgent.Model
{
    public class Line
    {
        private int _Id = 0;
        private string _linename = "";
        private string _linesubname = "";
        private string _linepic = "";
        private string _seotitle = "";
        private string _seokey = "";
        private string _seodisc = "";
        private int _cityId = 0;
        private int _daynumber = 0;
        private int _aheadnumber = 0;
        private int _supplyid = 0;
        private int _destid = 0;
        private string _dest = "";
        private string _proids = "";
        private string _themeids = "";
        private string _trafficids = "";
        private int _sort = 0;
        private string _linefeature = "";
        private string _linecost = "";
        private string _ordertips = "";
        private string _travelnotice = "";
        private string _state = "";
        private int _editmodel = 0;
        private string _linecontent = "";
        private int _usepoints = 0;
        private int _donatepoints = 0;
        private DateTime _adddate = DateTime.Now;
        private string _pricesdate="";
        private string _priceedate="";
        private int _priceeditmodel = 0;
        private string _pricecontent = "";
        private int _dealtype = 0;
        private string _pricesetting = "";
        private int _islock = 0;
        private int _gzd = 0;
        private int _priceCommon = 0;
        private int _insureid;
        private string _holiday = "";

        public int MarketPrice {
            get
            {
                if (string.IsNullOrEmpty(PriceContent))
                {
                    return int.Parse(PriceContent.Split(',')[0]);
                }
                return -1;
            }
            set
            {

            }
        }
        public int PurchasePrice {
            get
            {
                if (string.IsNullOrEmpty(PriceContent))
                {
                    return int.Parse(PriceContent.Split(',')[2]);
                }
                return -1;
            }
            set
            {

            }
        }

        private TravelAgent.Model.Insure _insure;
        /// <summary>
        /// 线路编号
        /// </summary>
        public int Id
        {
            set { _Id = value; }
            get { return _Id; }
        }
        /// <summary>
        /// 线路标题
        /// </summary>
        public string LineName
        {
            set { _linename = value; }
            get { return _linename; }
        }
        /// <summary>
        /// 线路副标题
        /// </summary>
        public string LineSubName
        {
            set { _linesubname = value; }
            get { return _linesubname; }
        }
        /// <summary>
        /// 缩略图
        /// </summary>
        public string LinePic
        {
            set { _linepic = value; }
            get { return _linepic; }
        }
        /// <summary>
        /// SEO标题
        /// </summary>
        public string SeoTitle
        {
            set { _seotitle = value; }
            get { return _seotitle; }
        }
        /// <summary>
        /// SEO关键字
        /// </summary>
        public string SeoKey
        {
            set { _seokey = value; }
            get { return _seokey; }
        }
        /// <summary>
        /// SEO描述
        /// </summary>
        public string SeoDisc
        {
            set { _seodisc = value; }
            get { return _seodisc; }
        }
        /// <summary>
        /// 出发城市编号
        /// </summary>
        public int CityId
        {
            set { _cityId = value; }
            get { return _cityId; }
        }
        /// <summary>
        /// 行程天数
        /// </summary>
        public int DayNumber
        {
            set { _daynumber = value; }
            get { return _daynumber; }
        }
        /// <summary>
        /// 提前几天报名
        /// </summary>
        public int AheadNumber
        {
            set { _aheadnumber = value; }
            get { return _aheadnumber; }
        }
        /// <summary>
        /// 供应商编号
        /// </summary>
        public int SupplyId
        {
            set { _supplyid = value; }
            get { return _supplyid; }
        }
        /// <summary>
        /// 目的地类型编号
        /// </summary>
        public int DestId
        {
            set { _destid = value; }
            get { return _destid; }
        }
        /// <summary>
        /// 目的地
        /// </summary>
        public string Dest
        {
            set { _dest = value; }
            get { return _dest; }
        }
        /// <summary>
        /// 参团性质编号
        /// </summary>
        public string ProIds
        {
            set { _proids = value; }
            get { return _proids; }
        }
        /// <summary>
        /// 主题编号
        /// </summary>
        public string ThemeIds
        {
            set { _themeids = value; }
            get { return _themeids; }
        }
        /// <summary>
        /// 往返交通
        /// </summary>
        public string TrafficIds
        {
            set { _trafficids = value; }
            get { return _trafficids; }
        }
        /// <summary>
        /// 序号
        /// </summary>
        public int Sort
        {
            set { _sort = value; }
            get { return _sort; }
        }
        /// <summary>
        /// 线路特色
        /// </summary>
        public string LineFeature
        {
            set { _linefeature = value; }
            get { return _linefeature; }
        }
        /// <summary>
        /// 费用说明
        /// </summary>
        public string LineCost
        {
            set { _linecost = value; }
            get { return _linecost; }
        }
        /// <summary>
        /// 预定须知
        /// </summary>
        public string OrderTips
        {
            set { _ordertips = value; }
            get { return _ordertips; }
        }
        /// <summary>
        /// 出游提醒
        /// </summary>
        public string TravelNotice
        {
            set { _travelnotice = value; }
            get { return _travelnotice; }
        }
        /// <summary>
        /// 状态
        /// </summary>
        public string State
        {
            set { _state = value; }
            get { return _state; }
        }
        /// <summary>
        /// 行程编辑模式
        /// </summary>
        public int EditModel
        {
            set { _editmodel = value; }
            get { return _editmodel; }
        }
        /// <summary>
        /// 可视化编辑内容
        /// </summary>
        public string LineContent
        {
            set { _linecontent = value; }
            get { return _linecontent; }
        }
        /// <summary>
        /// 最多使用积分
        /// </summary>
        public int UsePoints
        {
            set { _usepoints = value; }
            get { return _usepoints; }
        }

        /// <summary>
        /// 赠送积分
        /// </summary>
        public int DonatePoints
        {
            set { _donatepoints = value; }
            get { return _donatepoints; }
        }
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime Adddate
        {
            set { _adddate = value; }
            get { return _adddate; }
        }
        /// <summary>
        /// 价格有效期的开始日期
        /// </summary>
        public string PriceSDate
        {
            set { _pricesdate = value; }
            get { return _pricesdate; }
        }
        /// <summary>
        /// 价格有效期的结束日期
        /// </summary>
        public string PriceEDate
        {
            set { _priceedate = value; }
            get { return _priceedate; }
        }
        /// <summary>
        /// 价格选择模式
        /// </summary>
        public int PriceEditModel
        {
            set { _priceeditmodel = value; }
            get { return _priceeditmodel; }
        }
        /// <summary>
        /// 价格内容
        /// </summary>
        public string PriceContent
        {
            set { _pricecontent = value; }
            get { return _pricecontent; }
        }
        /// <summary>
        /// 线路处理方式
        /// </summary>
        public int DealType
        {
            set { _dealtype = value; }
            get { return _dealtype; }
        }
        /// <summary>
        /// 价格设置内容
        /// </summary>
        public string PriceSetting
        {
            set { _pricesetting = value; }
            get { return _pricesetting; }
        }
        /// <summary>
        /// 是否显示
        /// </summary>
        public int IsLock
        {
            set { _islock = value; }
            get { return _islock; }
        }
        /// <summary>
        /// 关注度
        /// </summary>
        public int GZD
        {
            set { _gzd = value; }
            get { return _gzd; }
        }
        /// <summary>
        /// 普通价格
        /// </summary>
        public int PriceCommon
        {
            set { _priceCommon = value; }
            get { return _priceCommon; }
        }
        /// <summary>
        /// 保险编号
        /// </summary>
        public int InsureId
        {
            set { _insureid = value; }
            get { return _insureid; }
        }
        /// <summary>
        /// 保险
        /// </summary>
        public TravelAgent.Model.Insure Insure
        {
            set { _insure = value; }
            get { return _insure; }
        }
        /// <summary>
        /// 节假日
        /// </summary>
        public string Holiday
        {
            set { _holiday = value; }
            get { return _holiday; }
        }

        /// <summary>
        /// get a shop price
        /// written by jjh
        /// </summary>
        /// <returns></returns>
        public int GetShopPrice()
        {
            if (string.IsNullOrWhiteSpace(PriceContent))
            {
                return 0;
            }
            else
            {
                string[] prices_list = PriceContent.Split(',');
                if (prices_list == null || prices_list.Length == 0)
                {
                    return 0;
                }
                else
                {
                    int temp = 0;
                    int.TryParse(prices_list[0],out temp);
                    return temp;
                }
            }
        }

    }
}
