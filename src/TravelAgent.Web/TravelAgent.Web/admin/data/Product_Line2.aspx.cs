using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TravelAgent.Web.admin.data
{
    public partial class Product_Line2 : System.Web.UI.Page
    {
        private static readonly TravelAgent.BLL.Line LineBll = new TravelAgent.BLL.Line();
        private static readonly TravelAgent.BLL.LineSpePrice SpePriceBll = new TravelAgent.BLL.LineSpePrice();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["lineid"] != null)
            {
                int lineid=Convert.ToInt32(Request.QueryString["lineid"]);
                string content = Request["txtMenshi_adult"] + "," + Request["txtMenshi_child"] + ",";
                         content += Request["txtPrice_adult"] + "," + Request["txtPrice_child"] + ",";
                         content+=Request["txtUsePoints_adult"]+","+Request["txtUsePoints_child"]+",";
                         content += Request["txtDoPoints_adult"] + "," + Request["txtDoPoints_child"] + ",";
                         content += Request["txtCheng_adult"] + "," + Request["txtCheng_child"] + ",";
                         content += Request["txtDFC"] + ",";
                         content += Request["txtNumber"];
                         string strsetting="";
                         if(Request["rbtnPlanType"].ToString().Equals("1"))
                         {
                            strsetting=Request["hidweek"];
                         }
                        else if(Request["rbtnPlanType"].ToString().Equals("2"))
                         {
                            strsetting=Request["hidday"];
                        }
                         string strsql = "update Line set priceSdate='" + Request["txtStartDate"] + "',priceEdate='" + Request["txtEndDate"] + "',";
                         strsql += "priceEditModel=" + Request["rbtnPlanType"] + ",priceContent='"+content+"',";
                         strsql += "dealType='" + Request["rbtnDealType"] + "',priceSetting='" + strsetting + "',priceCommon='" + Request["txtPrice_adult"] + "' where Id=" + lineid;
                         try
                         {
                             if (LineBll.Update(strsql) > 0)
                             {
                                 if (Request["chkClearPrice"] != null)
                                 {
                                     //清除特殊价格
                                     SpePriceBll.Delete(lineid);
                                 }
                                 Response.Write("true");
                             }
                             else
                             {
                                 Response.Write("false");
                             }
                         }
                         catch
                         {
                             Response.Write("false");
                         }
            }
            if (Request.QueryString["line_id"] != null)
            {
                int line_id = Convert.ToInt32(Request.QueryString["line_id"]);
                string content = Request["menshi_adult"] + "," + Request["menshi_child"] + ",";
                content += Request["price_adult"] + "," + Request["price_child"] + ",";
                content += Request["points_use_adult"] + "," + Request["points_use_child"] + ",";
                content += Request["points_do_adult"] + "," + Request["points_do_child"] + ",";
                content += Request["jsprice_adult"] + "," + Request["jsprice_child"] + ",";
                content += Request["dfc"] + ",";
                content += Request["num"];
                //string strprice = Request["hidPrice"];
                string strDate = Request["hidDate"];
                //先删除后增加
                SpePriceBll.Delete(line_id, strDate);
                TravelAgent.Model.LineSpePrice price = new TravelAgent.Model.LineSpePrice();
                price.lineId = line_id;
                price.linePrice = content;
                price.lineDate = strDate;
                price.tag = 1;
                if (SpePriceBll.Add(price) > 0)
                {
                    Response.Write("true");
                }
                else
                {
                    Response.Write("false");
                }
            }
            if (Request["line_id_delete"]!=null)
            {
                int line_id_delete = Convert.ToInt32(Request["line_id_delete"]);
                string strDate = Request["line_date"];
                SpePriceBll.Delete(line_id_delete, strDate);
                TravelAgent.Model.LineSpePrice price = new TravelAgent.Model.LineSpePrice();
                price.lineId = line_id_delete;
                price.linePrice = "";
                price.lineDate = strDate;
                price.tag = 0;
                if (SpePriceBll.Add(price) > 0)
                {
                    Response.Write("true");
                }
                else
                {
                    Response.Write("false");
                }
            }
        }
    }
}
