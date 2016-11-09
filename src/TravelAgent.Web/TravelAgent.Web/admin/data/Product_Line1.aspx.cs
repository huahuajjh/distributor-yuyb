using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TravelAgent.Web.admin.data
{
    public partial class Product_Line1 : System.Web.UI.Page
    {
        private static readonly TravelAgent.BLL.Line LineBll = new TravelAgent.BLL.Line();
        private static readonly TravelAgent.BLL.LineSpePrice SpePriceBll = new TravelAgent.BLL.LineSpePrice();
        private static readonly TravelAgent.BLL.LineContent LineContentBll = new TravelAgent.BLL.LineContent();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["daycount"] != null)
            {
                int lineid = Convert.ToInt32(Request["hidlineid"]);
                int editmodel = Convert.ToInt32(Request["rbtnEditModel"]);
                ArrayList allist = new ArrayList();
                allist.Add("update Line set editModel=" + editmodel + " where Id=" + lineid + ";");
                if (editmodel == 0)
                {
                    int count = Convert.ToInt32(Request["daycount"]);
                    string strsql = "";
                    for (int i = 1; i <= count; i++)
                    {
                        strsql="insert into LineContent(title,morn,noon,night,accom,content,daySort,lineId) ";
                        strsql+="values('" + Request["txt_BT_D" + i] + "',";
                        if (Request["chk_morn_D" + i] == null)
                        {
                            strsql+="0,";
                        }
                        else
                        {
                            strsql+="1,";
                        }
                        if (Request["chk_noon_D" + i] == null)
                        {
                            strsql+="0,";
                        }
                        else
                        {
                            strsql+="1,";
                        }
                        if (Request["chk_night_D" + i] == null)
                        {
                            strsql+="0,";
                        }
                        else
                        {
                            strsql+="1,";
                        }
                        strsql+="'" + Request["txt_ZS_D" + i] + "',";
                        strsql+="'" + Request["txt_Content_D" + i] + "',";
                        strsql+="" + i + ",";
                        strsql+="" + lineid + ")";
                        allist.Add(strsql);
                    }
                }
                else if (editmodel == 1)
                {
                    allist.Add("update Line set lineContent='" + Request["txtContent"] + "' where Id=" + lineid);
                }

                try
                {
                    LineContentBll.InsertContents(allist,lineid);
                    Response.Write("true");
                }
                catch
                {
                    Response.Write("false");
                }
            }
            else
            {
                Response.Write("false");
            }
            //删除线路
            if (Request["tag"] != null)
            {
                string strtag = Request["tag"];
                int lineid = Convert.ToInt32(Request["lineid"]);
                if (strtag.Equals("linelist_delete"))
                {
                    try
                    {
                        LineBll.Delete(lineid);
                        Response.Write("true");
                    }
                    catch
                    {
                        Response.Write("false");
                    }
                }
                else if (strtag.Equals("linelist_copy"))
                {
                    TravelAgent.Model.Line Line = LineBll.GetModel(lineid);
                    Line.LineName = "[复制]" + Line.LineName;
                    Line.Adddate = DateTime.Now;
                    try
                    {
                        int newLineid = LineBll.Add(Line);
                        if (newLineid > 0)
                        {
                            ArrayList allist = new ArrayList();
                            List<TravelAgent.Model.LineContent> lstLineContent = LineContentBll.GetlstLineContentByLineId(lineid);
                            foreach (TravelAgent.Model.LineContent content in lstLineContent)
                            {
                                allist.Add("insert into LineContent(title,morn,noon,night,accom,content,daySort,lineId) values ('" + content.Title + "','" + content.Morn + "','" + content.Noon + "','"
                                               + content.Night + "','" + content.Accom + "','" + content.Content + "','" + content.DaySort + "','" + newLineid + "') ");
                            }
                            if (allist.Count > 0)
                            {
                                LineContentBll.InsertContents(allist, newLineid);
                            }

                            allist.Clear();
                            List<TravelAgent.Model.LineSpePrice> lstSpePrice = SpePriceBll.GetlstSpePriceByLineId(lineid);
                            foreach (TravelAgent.Model.LineSpePrice price in lstSpePrice)
                            {
                                allist.Add("insert into LineSpePrice(lineId,lineDate,linePrice,tag) values ('" + newLineid + "','" + price.lineDate + "','" + price.linePrice + "','" + price.tag + "')");
                            }
                            if (allist.Count > 0)
                            {
                                SpePriceBll.InsertContents(allist);
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
            }
        }
    }
}
