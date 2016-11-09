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
    public partial class CarDetail : TravelAgent.Web.UI.mBasePage
    {
        private static readonly TravelAgent.BLL.CarList CarBll = new TravelAgent.BLL.CarList();
        private static readonly TravelAgent.BLL.CarPrice PriceBll = new TravelAgent.BLL.CarPrice();
        public TravelAgent.Model.CarList car;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!this.IsPostBack)
            {
                 if (Request.QueryString["Id"] != null)
                {
                    car = CarBll.GetModel(Convert.ToInt32(Request.QueryString["Id"]));
                    if (car == null)
                    {
                        Response.Redirect("/404.aspx");
                    }

                    this.Title = car.CarName + "出租_" + car.CarName + "租赁_" + car.CarName + "租车_"+Master.webinfo.WebName;
                }
            }
           
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
        /// <summary>
        /// 绑定价格列表
        /// </summary>
        /// <param name="top"></param>
        /// <returns></returns>
        public string BindPrice(int top)
        {
            StringBuilder sbPrice = new StringBuilder();
            DataSet dsPrice = PriceBll.GetList(top, "IsLock=0 and CarId=" + car.Id + "and cast(EndDate as datetime) >='" + DateTime.Now + "' and cast(StartDate as datetime) <='" + DateTime.Now + "'", "XiaoshuPrice asc");
            foreach (DataRow row in dsPrice.Tables[0].Rows)
            {
                sbPrice.Append("<dl class=\"clearfix\">");
                sbPrice.Append("<dd class=\"row1\">");
                sbPrice.Append("<a class=\"closed\" href=\"javascript:;\">" + row["PriceName"] + "</a>");
                sbPrice.Append("</dd>");
                sbPrice.Append("<dd class=\"row2\"><del>¥" + row["MemshiPrice"] + "</del></dd>");
                sbPrice.Append("<dd class=\"row3\">");
                sbPrice.Append("<em price=\"" + row["XiaoshuPrice"] + "\">¥" + row["XiaoshuPrice"] + "</em>");
                sbPrice.Append("</dd>");
                sbPrice.Append("<dd class=\"row5\">");
                sbPrice.Append("一趟<a class=\"btn\" title=\"立即预订\" target=\"_blank\" href=\"/car/CarOrder1.aspx?cid=" + row["CarId"] + "&pcid=" + row["Id"] + "&t=" + row["CarTypeID"] + "\">预订</a></dd>");
                sbPrice.Append("</dl>");
            }
            return sbPrice.ToString();
        }
    }
}
