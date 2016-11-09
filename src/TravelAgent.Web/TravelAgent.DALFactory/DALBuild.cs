using System.Reflection;
using System.Configuration;
using System;

namespace TravelAgent.DALFactory
{
    public sealed class DALBuild
    {
        //链接数据访问层的程序集名称
        private static readonly string AssemblyName = ConfigurationManager.AppSettings["DAL"];

        private DALBuild()
        { 

        }
        /// <summary>
        /// 返回程序集中实体名称
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        
        #region old
        private static string GetObjectName(string name)
        {
            return AssemblyName + "." + name;
        }

        /// <summary>
        /// 返回程序集中网站信息的实体
        /// </summary>
        /// <returns></returns>
        public static TravelAgent.IDAL.IWebInfo CreateWebInfo()
        {
            return (TravelAgent.IDAL.IWebInfo)Assembly.Load(AssemblyName).CreateInstance(GetObjectName("WebInfo"));
        }
        /// <summary>
        /// 返回程序集中网站导航的实体
        /// </summary>
        /// <returns></returns>
        public static TravelAgent.IDAL.IWebNav CreateWebNav()
        {
            return (TravelAgent.IDAL.IWebNav)Assembly.Load(AssemblyName).CreateInstance(GetObjectName("WebNav"));
        }

        /// <summary>
        /// 返回程序集中目的地的实体
        /// </summary>
        /// <returns></returns>
        public static TravelAgent.IDAL.IDestination CreateDestination()
        {
            return (TravelAgent.IDAL.IDestination)Assembly.Load(AssemblyName).CreateInstance(GetObjectName("Destination"));
        }
        /// <summary>
        /// 返回程序集中参团性质实体
        /// </summary>
        /// <returns></returns>
        public static TravelAgent.IDAL.IJoinProperty CreateJoinProperty()
        {
            return (TravelAgent.IDAL.IJoinProperty)Assembly.Load(AssemblyName).CreateInstance(GetObjectName("JoinProperty"));
        }
        /// <summary>
        /// 返回程序集中出发城市实体
        /// </summary>
        /// <returns></returns>
        public static TravelAgent.IDAL.IDepartureCity CreateDepartureCity()
        {
            return (TravelAgent.IDAL.IDepartureCity)Assembly.Load(AssemblyName).CreateInstance(GetObjectName("DepartureCity"));
        }
        /// <summary>
        /// 返回程序集中供应商实体
        /// </summary>
        /// <returns></returns>
        public static TravelAgent.IDAL.ISupply CreateSupply()
        {
            return (TravelAgent.IDAL.ISupply)Assembly.Load(AssemblyName).CreateInstance(GetObjectName("Supply"));
        }
        /// <summary>
        /// 返回程序集中线路主题
        /// </summary>
        /// <returns></returns>
        public static TravelAgent.IDAL.ILineTheme CreateLineTheme()
        {
            return (TravelAgent.IDAL.ILineTheme)Assembly.Load(AssemblyName).CreateInstance(GetObjectName("LineTheme"));
        }
        /// <summary>
        /// 返回程序集中节日特惠
        /// </summary>
        /// <returns></returns>
        public static TravelAgent.IDAL.ILineHoliday CreateLineHoliday()
        {
            return (TravelAgent.IDAL.ILineHoliday)Assembly.Load(AssemblyName).CreateInstance(GetObjectName("LineHoliday"));
        }
        /// <summary>
        /// 返回程序集中新闻分类
        /// </summary>
        /// <returns></returns>
        public static TravelAgent.IDAL.ICategory CreateCategory()
        {
            return (TravelAgent.IDAL.ICategory)Assembly.Load(AssemblyName).CreateInstance(GetObjectName("Category"));
        }
        /// <summary>
        /// 返回程序集中新闻
        /// </summary>
        /// <returns></returns>
        public static TravelAgent.IDAL.IArticle CreateArticle()
        {
            return (TravelAgent.IDAL.IArticle)Assembly.Load(AssemblyName).CreateInstance(GetObjectName("Article"));
        }
        /// <summary>
        /// 返回程序集中广告
        /// </summary>
        /// <returns></returns>
        public static TravelAgent.IDAL.IAdbanner CreateAdbanner()
        {
            return (TravelAgent.IDAL.IAdbanner)Assembly.Load(AssemblyName).CreateInstance(GetObjectName("Adbanner"));
        }
        /// <summary>
        /// 返回程序集中广告
        /// </summary>
        /// <returns></returns>
        public static TravelAgent.IDAL.IAdvertising CreateAdvertising()
        {
            return (TravelAgent.IDAL.IAdvertising)Assembly.Load(AssemblyName).CreateInstance(GetObjectName("Advertising"));
        }
        /// <summary>
        /// 返回程序集中友情链接
        /// </summary>
        /// <returns></returns>
        public static TravelAgent.IDAL.ILinks CreateLinks()
        {
            return (TravelAgent.IDAL.ILinks)Assembly.Load(AssemblyName).CreateInstance(GetObjectName("Links"));
        }
        /// <summary>
        /// 返回程序集中签证领区
        /// </summary>
        /// <returns></returns>
        public static TravelAgent.IDAL.IVisaCity CreateVisaCity()
        {
            return (TravelAgent.IDAL.IVisaCity)Assembly.Load(AssemblyName).CreateInstance(GetObjectName("VisaCity"));
        }
        /// <summary>
        /// 返回程序集中签证国家区域
        /// </summary>
        /// <returns></returns>
        public static TravelAgent.IDAL.IVisaCountry CreateVisaCountry()
        {
            return (TravelAgent.IDAL.IVisaCountry)Assembly.Load(AssemblyName).CreateInstance(GetObjectName("VisaCountry"));
        }
        /// <summary>
        /// 返回程序集中签证类型
        /// </summary>
        /// <returns></returns>
        public static TravelAgent.IDAL.IVisaType CreateVisaType()
        {
            return (TravelAgent.IDAL.IVisaType)Assembly.Load(AssemblyName).CreateInstance(GetObjectName("VisaType"));
        }
        /// <summary>
        /// 返回程序集中签证品牌优势
        /// </summary>
        /// <returns></returns>
        public static TravelAgent.IDAL.IVisaBrand CreateVisaBrand()
        {
            return (TravelAgent.IDAL.IVisaBrand)Assembly.Load(AssemblyName).CreateInstance(GetObjectName("VisaBrand"));
        }
        /// <summary>
        /// 返回程序集中信息设置
        /// </summary>
        /// <returns></returns>
        public static TravelAgent.IDAL.IInfoSetting CreateInfoSetting()
        {
            return (TravelAgent.IDAL.IInfoSetting)Assembly.Load(AssemblyName).CreateInstance(GetObjectName("InfoSetting"));
        }
        /// <summary>
        /// 返回程序集中签证列表
        /// </summary>
        /// <returns></returns>
        public static TravelAgent.IDAL.IVisaList CreateVisaList()
        {
            return (TravelAgent.IDAL.IVisaList)Assembly.Load(AssemblyName).CreateInstance(GetObjectName("VisaList"));
        }
        /// <summary>
        /// 返回程序集中线路
        /// </summary>
        /// <returns></returns>
        public static TravelAgent.IDAL.ILine CreateLine()
        {
            return (TravelAgent.IDAL.ILine)Assembly.Load(AssemblyName).CreateInstance(GetObjectName("Line"));
        }
        /// <summary>
        /// 返回程序集中线路行程
        /// </summary>
        /// <returns></returns>
        public static TravelAgent.IDAL.ILineContent CreateLineContent()
        {
            return (TravelAgent.IDAL.ILineContent)Assembly.Load(AssemblyName).CreateInstance(GetObjectName("LineContent"));
        }
        /// <summary>
        /// 返回程序集中线路行程的特殊日期价格
        /// </summary>
        /// <returns></returns>
        public static TravelAgent.IDAL.ILineSpePrice CreateLineSpePrice()
        {
            return (TravelAgent.IDAL.ILineSpePrice)Assembly.Load(AssemblyName).CreateInstance(GetObjectName("LineSpePrice"));
        }
        /// <summary>
        /// 返回程序集中会员
        /// </summary>
        /// <returns></returns>
        public static TravelAgent.IDAL.IClub CreateClub()
        {
            return (TravelAgent.IDAL.IClub)Assembly.Load(AssemblyName).CreateInstance(GetObjectName("Club"));
        }
        /// <summary>
        /// 返回程序集中保险
        /// </summary>
        /// <returns></returns>
        public static TravelAgent.IDAL.IInsure CreateInsure()
        {
            return (TravelAgent.IDAL.IInsure)Assembly.Load(AssemblyName).CreateInstance(GetObjectName("Insure"));
        }
        /// <summary>
        /// 返回程序集中线路订单
        /// </summary>
        /// <returns></returns>
        public static TravelAgent.IDAL.IOrder CreateLineOrder()
        {
            return (TravelAgent.IDAL.IOrder)Assembly.Load(AssemblyName).CreateInstance(GetObjectName("Order"));
        }
        /// <summary>
        /// 返回程序集中线路订单游客
        /// </summary>
        /// <returns></returns>
        public static TravelAgent.IDAL.ILineOrderTourist CreateLineOrderTourist()
        {
            return (TravelAgent.IDAL.ILineOrderTourist)Assembly.Load(AssemblyName).CreateInstance(GetObjectName("LineOrderTourist"));
        }
        /// <summary>
        /// 返回程序集中线路收藏
        /// </summary>
        /// <returns></returns>
        public static TravelAgent.IDAL.IClubLineCollect CreateLineCollect()
        {
            return (TravelAgent.IDAL.IClubLineCollect)Assembly.Load(AssemblyName).CreateInstance(GetObjectName("ClubLineCollect"));
        }
        /// <summary>
        /// 返回程序集中积分
        /// </summary>
        /// <returns></returns>
        public static TravelAgent.IDAL.IClubPoints CreateClubPoints()
        {
            return (TravelAgent.IDAL.IClubPoints)Assembly.Load(AssemblyName).CreateInstance(GetObjectName("ClubPoints"));
        }
        /// <summary>
        /// 返回程序集中操作用户角色
        /// </summary>
        /// <returns></returns>
        public static TravelAgent.IDAL.IAdminRole CreateAdminRole()
        {
            return (TravelAgent.IDAL.IAdminRole)Assembly.Load(AssemblyName).CreateInstance(GetObjectName("AdminRole"));
        }
        /// <summary>
        /// 返回程序集中操作用户
        /// </summary>
        /// <returns></returns>
        public static TravelAgent.IDAL.IAdminList CreateAdminList()
        {
            return (TravelAgent.IDAL.IAdminList)Assembly.Load(AssemblyName).CreateInstance(GetObjectName("AdminList"));
        }
        /// <summary>
        /// 返回程序集中线路咨询
        /// </summary>
        /// <returns></returns>
        public static TravelAgent.IDAL.ILineConsult CreateLineConsult()
        {
            return (TravelAgent.IDAL.ILineConsult)Assembly.Load(AssemblyName).CreateInstance(GetObjectName("LineConsult"));
        }
        /// <summary>
        /// 返回程序集中定制需求订单
        /// </summary>
        /// <returns></returns>
        public static TravelAgent.IDAL.ICustomOrder CreateCustomOrder()
        {
            return (TravelAgent.IDAL.ICustomOrder)Assembly.Load(AssemblyName).CreateInstance(GetObjectName("CustomOrder"));
        }
        /// <summary>
        /// 返回程序集中租车城市
        /// </summary>
        /// <returns></returns>
        public static TravelAgent.IDAL.ICarCity CreateCarCity()
        {
            return (TravelAgent.IDAL.ICarCity)Assembly.Load(AssemblyName).CreateInstance(GetObjectName("CarCity"));
        }
        /// <summary>
        /// 返回程序集中租车品牌
        /// </summary>
        /// <returns></returns>
        public static TravelAgent.IDAL.ICarBrand CreateCarBrand()
        {
            return (TravelAgent.IDAL.ICarBrand)Assembly.Load(AssemblyName).CreateInstance(GetObjectName("CarBrand"));
        }
        /// <summary>
        /// 返回程序集中车辆级别
        /// </summary>
        /// <returns></returns>
        public static TravelAgent.IDAL.ICarClass CreateCarClass()
        {
            return (TravelAgent.IDAL.ICarClass)Assembly.Load(AssemblyName).CreateInstance(GetObjectName("CarClass"));
        }
        /// <summary>
        /// 返回程序集中汽车厢数
        /// </summary>
        /// <returns></returns>
        public static TravelAgent.IDAL.ICarNumber CreateCarNumber()
        {
            return (TravelAgent.IDAL.ICarNumber)Assembly.Load(AssemblyName).CreateInstance(GetObjectName("CarNumber"));
        }
        /// <summary>
        /// 返回程序集中租车列表
        /// </summary>
        /// <returns></returns>
        public static TravelAgent.IDAL.ICarList CreateCarList()
        {
            return (TravelAgent.IDAL.ICarList)Assembly.Load(AssemblyName).CreateInstance(GetObjectName("CarList"));
        }
        /// <summary>
        /// 返回程序集中租车价格
        /// </summary>
        /// <returns></returns>
        public static TravelAgent.IDAL.ICarPrice CreateCarPrice()
        {
            return (TravelAgent.IDAL.ICarPrice)Assembly.Load(AssemblyName).CreateInstance(GetObjectName("CarPrice"));
        }
        
        /// <summary>
        /// 返回程序集中的游记列表
        /// 
        /// </summary>
        /// <returns></returns>
        public static TravelAgent.IDAL.ITourGuide CreateTourGuide()
        {
            return (TravelAgent.IDAL.ITourGuide)Assembly.Load(AssemblyName).CreateInstance(GetObjectName("TourGuide"));
        }

        public static TravelAgent.IDAL.ITourGuideConf CreateTourGuideConf()
        {
            return (TravelAgent.IDAL.ITourGuideConf)Assembly.Load(AssemblyName).CreateInstance(GetObjectName("TourGuideConf"));
        }
        public static TravelAgent.IDAL.ITourGuideGallery CreateTourGuideGallery()
        {
            return (TravelAgent.IDAL.ITourGuideGallery)Assembly.Load(AssemblyName).CreateInstance(GetObjectName("TourGuideGallery"));
        }
        public static TravelAgent.IDAL.ITourGuideRoute CreateTourGuideRoute()
        {
            return (TravelAgent.IDAL.ITourGuideRoute)Assembly.Load(AssemblyName).CreateInstance(GetObjectName("TourGuideRoute"));
        }
        public static TravelAgent.IDAL.ITourGuideSpot CreateTourGuideSpot()
        {
            return (TravelAgent.IDAL.ITourGuideSpot)Assembly.Load(AssemblyName).CreateInstance(GetObjectName("TourGuideSpot"));
        }

        public static TravelAgent.IDAL.ITourGuideTemp CreateTourGuideTemp()
        {
            return (TravelAgent.IDAL.ITourGuideTemp)Assembly.Load(AssemblyName).CreateInstance(GetObjectName("TourGuideTemp"));
        }
        public static TravelAgent.IDAL.ITourComment CreateTourComment()
        {
            return (TravelAgent.IDAL.ITourComment)Assembly.Load(AssemblyName).CreateInstance(GetObjectName("TourComment"));
        }
        #endregion

        /// <summary>
        /// DI方法，根据类名实例化对象
        /// </summary>
        /// <typeparam name="T">实例化类型参数</typeparam>
        /// <param name="className">类名</param>
        /// <returns>实例对象</returns>
        public static T GetObj<T>(string className)
        {
            if (string.IsNullOrEmpty(className))
            {
                throw new NullReferenceException("初始化DLL失败，类名参数className为null，或者错误的className值");
            }
            else
            {
                return (T)Assembly.Load(AssemblyName).CreateInstance(GetObjectName(className));
            }
        }

        /// <summary>
        /// DI方法，根据dll+class name创建实例
        /// </summary>
        /// <typeparam name="T">实例类型参数</typeparam>
        /// <param name="dll">dll名称</param>
        /// <param name="class_name">类名称</param>
        /// <returns>实例</returns>
        public static T GetObj<T>(string dll,string class_name)
        {
            if (string.IsNullOrEmpty(class_name))
            {
                throw new NullReferenceException("初始化DLL失败，类名参数className为null，或者错误的className值");
            }
            else
            {
                string s = ConfigurationManager.AppSettings[dll] + "." + class_name;
                return (T)Assembly.Load(ConfigurationManager.AppSettings[dll]).CreateInstance(ConfigurationManager.AppSettings[dll] + "." + class_name);
            }
        }
    }
}
