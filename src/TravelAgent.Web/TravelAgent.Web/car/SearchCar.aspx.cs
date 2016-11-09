using System;
using System.Text;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TravelAgent.Web.car
{
    public partial class SearchCar : TravelAgent.Web.UI.mBasePage
    {
        private static readonly TravelAgent.BLL.CarBrand BrandBll = new TravelAgent.BLL.CarBrand();
        private static readonly TravelAgent.BLL.CarClass ClassBll = new TravelAgent.BLL.CarClass();
        private static readonly TravelAgent.BLL.CarNumber NumberBll = new TravelAgent.BLL.CarNumber();
        private static readonly TravelAgent.BLL.CarCity CityBll = new TravelAgent.BLL.CarCity();
        private static readonly TravelAgent.BLL.CarList CarBll = new TravelAgent.BLL.CarList();
        private static readonly TravelAgent.BLL.CarPrice PriceBll = new TravelAgent.BLL.CarPrice();
        public int cid = 0;//城市
        public int tid = 0;//车辆级别
        public int t = 0;//租车类型
        public int b = 0;//车辆品牌
        public int o = 0;//筛选
        public int x = 0;//车辆厢数
        public int s1 = 0;//车辆座位
        public int s2 = 0;//车辆座位
        public string cm1="";
        public string cm2="";
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Title = "租车_汽车租赁_自驾租车_代驾租车_"+Master.webinfo.WebName;
            if (Request.QueryString["cid"] != null)
            {
                cid = Convert.ToInt32(Request.QueryString["cid"]);
            }
            if (Request.QueryString["tid"] != null)
            {
                tid = Convert.ToInt32(Request.QueryString["tid"]);
            }
            if (Request.QueryString["t"] != null)
            {
                t = Convert.ToInt32(Request.QueryString["t"]);
            }
            if (Request.QueryString["b"] != null)
            {
                b = Convert.ToInt32(Request.QueryString["b"]);
            }
            if (Request.QueryString["o"] != null)
            {
                o = Convert.ToInt32(Request.QueryString["o"]);
            }
            if (Request.QueryString["x"] != null)
            {
                x = Convert.ToInt32(Request.QueryString["x"]);
            }
            if (Request.QueryString["s1"] != null)
            {
                s1 = Convert.ToInt32(Request.QueryString["s1"]);
            }
            if (Request.QueryString["s2"] != null)
            {
                s2 = Convert.ToInt32(Request.QueryString["s2"]);
            }
            if (Request.QueryString["cm1"] != null)
            {
                cm1 = Request.QueryString["cm1"];
            }
            if (Request.QueryString["cm2"] != null)
            {
                cm2 = Request.QueryString["cm2"];
            }
        }
        /// <summary>
        /// 绑定列表
        /// </summary>
        /// <returns></returns>
        public string BindCarList()
        {
            StringBuilder sbList = new StringBuilder();
            string strsql = "select * from (";
            strsql += "select a.CarName,a.CarPic,a.BrandId,a.ClassId,a.Seat,a.CarDesc,a.CarOrderTip,a.State,a.Sort,a.AddDate,b.*,(select BrandName from CarBrand where Id=a.BrandId) as BrandName,(select ClassName from CarClass where Id=a.ClassId) as ClassName,row_number() over(partition by b.CarId order by b.XiaoshuPrice asc) rn from CarList as a,CarPrice as b where a.Id=b.CarId and ";
            if (cid > 0)
            {
                strsql += " b.CarCityId=" + cid+" and ";
            }
            if (tid > 0)
            {
                strsql += " a.ClassId=" + tid + " and ";
            }
            if (t > 0)
            {
                strsql += " b.CarTypeID=" + t + " and ";
            }
            if (b > 0)
            {
                strsql += " a.BrandId=" + b + " and ";
            }
            if (x > 0)
            {
                strsql += " b.NumberId=" + x + " and ";
            }
            if (s1 > 0)
            {
                strsql += " a.Seat>=" + s1 + " and ";
            }
            if (s2 > 0)
            {
                strsql += " a.Seat<=" + s2 + " and ";
            }
            if (cm1 != "")
            {
                strsql += "cast(b.StartDate as datetime) <='"+Convert.ToDateTime(cm1)+"' and ";
            }
            if (cm2 != "")
            {
                strsql += "cast(b.EndDate as datetime) >='"+Convert.ToDateTime(cm2)+"' and ";
            }

            strsql += " a.IsLock=0 and b.IsLock=0";
            
            strsql += ") t where t.rn <=1";
            DataSet dsList = TravelAgent.Tool.DbHelperSQL.Query(strsql);
            if (o == 2)
            {
                dsList.Tables[0].DefaultView.Sort = "XiaoshuPrice asc";
            }
            if (o == 3)
            {
                dsList.Tables[0].DefaultView.Sort = "XiaoshuPrice desc";
            }
            if (dsList.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in dsList.Tables[0].Rows)
                {
                    sbList.Append("<dl class=\"clearfix\" ctid=\"" + dr["CarId"] + "\" t=\"1\">");
                    sbList.Append("<dt><a href=\"/CarDetail.aspx?id=" + dr["CarId"] + "\" target=\"_blank\" title=\"" + dr["CarName"] + "\"><img src=\"" + dr["CarPic"] + "\" /></a></dt>");
                    sbList.Append("<dd class=\"info\">");
                    sbList.Append("<h2><a href=\"/CarDetail.aspx?id=" + dr["CarId"] + "\" target=\"_blank\" title=\"" + dr["CarName"] + "\">" + dr["CarName"] + "</a></h2>");
                    sbList.Append("<p><span class=\"first\">"+dr["BrandName"]+"</span>|<span>"+dr["ClassName"]+"</span>|<span>"+dr["Seat"]+"座</span></p>");
                    sbList.Append("<p class=\"text\">" + TravelAgent.Tool.StringPlus.LeftTrueLen(dr["CarDesc"].ToString(),220,"...") + "</p>");
                    sbList.Append("</dd>");
                    sbList.Append("<dd class=\"right\">");
                    sbList.Append("<div class=\"price\"><em><i>&yen;</i>" + dr["XiaoshuPrice"] + "</em>起</div>");
                    sbList.Append("<div class=\"btn\"><a href=\"/car/CarDetail.aspx?id=" + dr["CarId"] + "\" target=\"_blank\">查看详情</a></div>");
                    sbList.Append("</dd>");
                    sbList.Append("</dl>");
                }
            }
            else
            {
                sbList.Append("<div class=\"noContent\">");
                sbList.Append("<div class=\"content\">");
                sbList.Append("非常抱歉，没有找到符合您条件的车辆");
                sbList.Append("<p>您可以更换搜索条件或改订其他车辆 <a href=\"/car/SearchCar.aspx\">清除筛选条件</a></p>");
                sbList.Append("</div>");
                sbList.Append("</div>");
            }
            
            return sbList.ToString();
        }
        /// <summary>
        /// 绑定城市
        /// </summary>
        /// <returns></returns>
        public string BindCity()
        {
            DataSet dsCity = CityBll.GetList();
            StringBuilder sbCity = new StringBuilder();
            foreach (DataRow row in dsCity.Tables[0].Rows)
            {
                sbCity.Append("<li><a id=\"cid_" + row["Id"] + "\" href=\"javascript:;\" onClick=\"ListUrl(this.id);return false;\">" + row["CityName"] + "</a></li>");
            }
            return sbCity.ToString();
        }
        /// <summary>
        /// 绑定品牌
        /// </summary>
        /// <returns></returns>
        public string BindBrand()
        {
            DataSet dsBrand = BrandBll.GetList();
            StringBuilder sbBrand = new StringBuilder();
            foreach (DataRow row in dsBrand.Tables[0].Rows)
            {
                sbBrand.Append("<li><a id=\"b_"+row["Id"]+"\" href=\"javascript:;\" onClick=\"ListUrl(this.id);return false;\">" + row["BrandName"] + "</a></li>");
            }
            return sbBrand.ToString();
        }
        /// <summary>
        /// 绑定级别
        /// </summary>
        /// <returns></returns>
        public string BindClass()
        {
            DataSet dsClass = ClassBll.GetList();
            StringBuilder sbClass = new StringBuilder();
            foreach (DataRow row in dsClass.Tables[0].Rows)
            {
                sbClass.Append("<li><a id=\"tid_"+row["Id"]+"\" href=\"javascript:;\" onClick=\"ListUrl(this.id);return false;\">"+row["ClassName"]+"</a></li>");
            }
            return sbClass.ToString();
        }
        /// <summary>
        /// 绑定类型
        /// </summary>
        /// <returns></returns>
        public string BindNumber()
        {
            DataSet dsNumber = NumberBll.GetList();
            StringBuilder sbNumber = new StringBuilder();
            foreach (DataRow row in dsNumber.Tables[0].Rows)
            {
                sbNumber.Append("<li><a id=\"x_"+row["Id"]+"\" href=\"javascript:;\" onClick=\"ListUrl(this.id);return false;\">" + row["NumName"] + "</a></li>");
            }
            return sbNumber.ToString();
        }
        /// <summary>
        /// 绑定推荐
        /// </summary>
        /// <param name="top"></param>
        /// <returns></returns>
        public string BindTJCar(int top)
        {
            StringBuilder sbTJ = new StringBuilder();
            DataSet dsTJ = CarBll.GetList(top, "CHARINDEX('," + Convert.ToInt32(TravelAgent.Tool.EnumSummary.State.推荐) + ",',State)>0 and isLock=0", "Sort asc,AddDate desc");
            foreach (DataRow row in dsTJ.Tables[0].Rows)
            {
                sbTJ.Append("<dl class=\"clearfix\">");
                sbTJ.Append("<dt><a href=\"CarDetail.aspx?id=" + row["Id"] + "\" target=\"_blank\" title=\"" + row["CarName"] + "\"><img src=\"" + row["CarPic"] + "\" style=\"display: inline;\"></a></dt>");
                sbTJ.Append("<dd>");
                sbTJ.Append("<span>" + getBasicPrice(Convert.ToInt32(row["Id"])) + "</span><a href=\"CarDetail.aspx?id=" + row["Id"] + "\" target=\"_blank\" title=\"" + row["CarName"] + "\">" + row["CarName"] + "</a>");
                sbTJ.Append("</dd>");
                sbTJ.Append("</dl>");
            }
            return sbTJ.ToString();
        }
        /// <summary>
        /// 获得最基本的价格
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private string getBasicPrice(int id)
        {
            string price = "<em>电议</em>";
            string strsql = "select top 1 * from CarPrice where IsLock=0 and cast(EndDate as datetime) >='" + DateTime.Now + "' and cast(StartDate as datetime) <='" + DateTime.Now + "' and CarId=" + id + " order by XiaoshuPrice asc";

            DataSet dsdata = TravelAgent.Tool.DbHelperSQL.Query(strsql);

            if (dsdata.Tables[0].Rows.Count > 0)
            {
                price = "<em>¥" + dsdata.Tables[0].Rows[0]["XiaoshuPrice"].ToString() + "</em> 起";
            }

            return price;
        }
    }
}
