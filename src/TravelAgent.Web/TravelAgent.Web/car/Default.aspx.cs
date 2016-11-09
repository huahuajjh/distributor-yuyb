using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TravelAgent.Web.car
{
    public partial class Default :  TravelAgent.Web.UI.mBasePage
    {
        private static readonly TravelAgent.BLL.CarBrand BrandBll = new TravelAgent.BLL.CarBrand();
        private static readonly TravelAgent.BLL.CarCity CityBll = new TravelAgent.BLL.CarCity();
        private static readonly TravelAgent.BLL.CarClass ClassBll = new TravelAgent.BLL.CarClass();
        private static readonly TravelAgent.BLL.Article ArticleBll = new TravelAgent.BLL.Article();
        private static readonly TravelAgent.BLL.VisaBrand BrandInfoBll = new TravelAgent.BLL.VisaBrand();
        private static readonly TravelAgent.BLL.CarList CarBll = new TravelAgent.BLL.CarList();
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Title = "租车_汽车租赁_自驾租车_代驾租车-" + Master.webinfo.WebName;
        }
        /// <summary>
        /// 绑定品牌
        /// </summary>
        /// <param name="top"></param>
        public string BindBrand(int top)
        {
            DataSet dsBrand = BrandBll.GetList();
            DataRow row = null;
            StringBuilder sbBrand = new StringBuilder();
            int count=dsBrand.Tables[0].Rows.Count>top?top:dsBrand.Tables[0].Rows.Count;
            for (int i = 0; i < dsBrand.Tables[0].Rows.Count; i++)
            {
                row = dsBrand.Tables[0].Rows[i];
                sbBrand.Append("<li>");
                sbBrand.Append("<a href=\"\">");
                sbBrand.Append("<img width=\"60\" height=\"60\" alt=\"" + row["BrandName"] + "\" src=\"" + row["BrandPic"] + "\" style=\"display: inline;\">");
                sbBrand.Append("<div>" + row["BrandName"] + "</div>");
                sbBrand.Append("</a>");
                sbBrand.Append("</li>");
            }
            return sbBrand.ToString();
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
                sbCity.Append("<dd val=\"" + row["Id"] + "\">" + row["CityName"] + "</dd>");
            }
            return sbCity.ToString();
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
                sbClass.Append("<dd val=\"" + row["Id"] + "\">" + row["ClassName"] + "</dd>");
            }
            return sbClass.ToString();
        }
        /// <summary>
        /// 绑定新闻
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public string BindNews(int type, int top)
        {
            StringBuilder sbNews = new StringBuilder();
            DataSet dsNews = ArticleBll.GetList(top, "ClassId=" + type, "Click asc,AddTime desc");
            foreach (DataRow row in dsNews.Tables[0].Rows)
            {
                //sbNews.Append("<li>·<a href=\"/New.aspx?nav=" + type + "&id=" + row["Id"] + "\" target=\"_blank\">" + row["Title"] + "</a></li>");
                //urlrewrite
                sbNews.Append("<li>·<a href=\"/new/" + type + "/" + row["Id"] + ".html\" target=\"_blank\">" + row["Title"] + "</a></li>");
            }
            return sbNews.ToString();
        }
        /// <summary>
        /// 绑定基本信息设置
        /// </summary>
        /// <param name="type"></param>
        /// <param name="top"></param>
        /// <returns></returns>
        public string BindBrandInfo(int type, int top)
        {
            StringBuilder sbBrand = new StringBuilder();
            DataSet dsBrand = BrandInfoBll.GetList(top, "isLock=0 and Type=" + type, "Sort asc");
            DataRow row = null;
            for (int i = 0; i < dsBrand.Tables[0].Rows.Count; i++)
            {
                row = dsBrand.Tables[0].Rows[i];
                sbBrand.Append("<dl class=\"d"+(i+1)+"\">");
                sbBrand.Append("<dt>" + row["Title"] + "</dt>");
                sbBrand.Append("<dd>" + row["SubTitle"] + "</dd>");
                sbBrand.Append("<dd class=\"icon\"></dd>");
                sbBrand.Append("</dl>");
            }
            return sbBrand.ToString();
        }
        /// <summary>
        /// 绑定列表
        /// </summary>
        /// <returns></returns>
        public string BindCarList()
        {
            StringBuilder sbCarList = new StringBuilder();
            DataSet dsCarList = CarBll.GetList(9, "IsLock=0", "Sort asc,AddDate desc");
            if (dsCarList.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in dsCarList.Tables[0].Rows)
                {
                    sbCarList.Append("<li>");
                    sbCarList.Append("<dl class=\"clearfix\">");
                    sbCarList.Append("<dt>");
                    sbCarList.Append("<a href=\"CarDetail.aspx?id="+row["Id"]+"\"><img style=\"display: inline;\" src=\"" + row["CarPic"] + "\"></a>");
                    sbCarList.Append("</dt>");
                    sbCarList.Append("<dd><span>" + getBasicPrice(Convert.ToInt32(row["Id"])) + "</span><a href=\"CarDetail.aspx?id=" + row["Id"] + "\" title=\"" + row["CarName"] + "\">" + row["CarName"] + "</a></dd>");
                    sbCarList.Append("</dl>");
                    sbCarList.Append("</li>");
                }
            }
            else
            {
                sbCarList.Append("<li>无</li>");
            }
            return sbCarList.ToString();
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
                price = "<em>¥" + dsdata.Tables[0].Rows[0]["XiaoshuPrice"].ToString() + "</em>起";
            }

            return price;
        }
    }
}
