using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TravelAgent.Tool;
namespace TravelAgent.Web.admin.data
{
    public partial class Product_Line : System.Web.UI.Page
    {
        public int kindId; 
        private static readonly TravelAgent.BLL.Destination DestBll = new TravelAgent.BLL.Destination();
        private static readonly TravelAgent.BLL.JoinProperty PropertyBll = new TravelAgent.BLL.JoinProperty();
        private static readonly TravelAgent.BLL.DepartureCity CityBll = new TravelAgent.BLL.DepartureCity();
        private static readonly TravelAgent.BLL.Supply SupplyBll = new TravelAgent.BLL.Supply();
        private static readonly TravelAgent.BLL.LineTheme ThemeBll = new TravelAgent.BLL.LineTheme();
        private static readonly TravelAgent.BLL.Line LineBll = new TravelAgent.BLL.Line();
        private static readonly TravelAgent.BLL.Insure InsureBll = new TravelAgent.BLL.Insure();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (Request["tag"] != null)
                {
                    string strTag = Request["tag"];
                    if (strTag == "dest")//目的地设置
                    {
                        int nav_editid = Convert.ToInt32(Request["hidId"]);
                        int navId;
                        int parentId = Convert.ToInt32(Request["ddlDest"]);       //上一级目录
                        int navLayer = 1;                                         //栏目深度
                        string navList = "";
                        TravelAgent.Model.Destination dest = new TravelAgent.Model.Destination();
                        dest.navName = Request["txtDestName"];
                        dest.navParentId = parentId;
                        dest.navURL = Request["txtDestURL"];
                        dest.navList = "";
                        dest.navSort = Convert.ToInt32(Request["txtSort"]);
                        dest.kindId = this.kindId;
                        dest.State = Request["hidState"];
                        dest.isLock = Request["chkLock"] == null ? 0 : 1;
                        if (nav_editid == 0)
                        {
                            //添加导航
                            navId = DestBll.Add(dest);
                            CacheHelper.Clear("dest");
                        }
                        else
                        {
                            navId = nav_editid;
                        }
                        //修改导航的下属导航ID列表
                        if (parentId > 0)
                        {
                            DataSet ds = DestBll.GetDestListByClassId(parentId);

                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                DataRow dr = ds.Tables[0].Rows[0];
                                navList = dr["navList"].ToString().Trim() + navId + ",";
                                navLayer = Convert.ToInt32(dr["navLayer"]) + 1;
                            }
                        }
                        else
                        {
                            navList = "," + navId + ",";
                            navLayer = 1;
                        }
                        dest.Id = navId;
                        dest.navList = navList;
                        dest.navLayer = navLayer;

                        try
                        {
                            DestBll.Update(dest);
                            CacheHelper.Clear("dest");
                            Response.Write("true");
                        }
                        catch
                        {
                            Response.Write("false");
                        }
                    }
                    else if (strTag == "dest_delete")//删除目的地
                    {
                        int destid = Convert.ToInt32(Request["destid"]);
                        try
                        {
                            DestBll.Delete(destid);
                            CacheHelper.Clear("dest");
                            Response.Write("true");
                        }
                        catch
                        {
                            Response.Write("false");
                        }
                    }
                    else if (strTag == "property_save")//参团性质保存
                    {
                        int property_editid = Convert.ToInt32(Request["hidId"]);
                        TravelAgent.Model.JoinProperty model = new TravelAgent.Model.JoinProperty();
                        model.joinName = Request["txtPropertyName"];
                        model.joinSort = Convert.ToInt32(Request["txtSort"]);
                        model.isLock = Request["chkIsLock"]==null?0:1;
                        try
                        {
                            if (property_editid != 0)
                            {
                                model.id = property_editid;
                                PropertyBll.Update(model);
                            }
                            else
                            {
                                PropertyBll.Add(model);
                            }
                            Response.Write("true");
                        }
                        catch
                        {
                            Response.Write("false");
                        }
                    }
                    else if (strTag == "property_delete")//参团性质删除
                    {
                        int proid = Convert.ToInt32(Request["proid"]);
                        try
                        {
                            PropertyBll.Delete(proid);
                            Response.Write("true");
                        }
                        catch
                        {
                            Response.Write("false");
                        }
                    }
                    else if (strTag == "city_save")//出发城市保存
                    {
                        int city_editid = Convert.ToInt32(Request["hidId"]);
                        TravelAgent.Model.DepartureCity model = new TravelAgent.Model.DepartureCity();
                        model.CityName = Request["txtCityName"];
                        model.Sort = Convert.ToInt32(Request["txtSort"]);
                        model.isLock = Request["chkIsLock"]==null?0:1;
                        try
                        {
                            if (city_editid != 0)
                            {
                                model.id = city_editid;
                                CityBll.Update(model);
                            }
                            else
                            {
                                CityBll.Add(model);
                            }
                            Response.Write("true");
                        }
                        catch
                        {
                            Response.Write("false");
                        }
                    }
                    else if (strTag == "city_delete")//出发城市删除
                    {
                        int cityid = Convert.ToInt32(Request["cityid"]);
                        try
                        {
                            CityBll.Delete(cityid);
                            Response.Write("true");
                        }
                        catch
                        {
                            Response.Write("false");
                        }
                    }
                    else if (strTag == "supply_delete")//删除供应商
                    {
                        int supplyid = Convert.ToInt32(Request["supplyid"]);
                        try
                        {
                            SupplyBll.Delete(supplyid);
                            Response.Write("true");
                        }
                        catch
                        {
                            Response.Write("false");
                        }
                    }
                    else if (strTag == "theme_save")//主题保存
                    {
                        int theme_editid = Convert.ToInt32(Request["hidId"]);
                        TravelAgent.Model.LineTheme model = new TravelAgent.Model.LineTheme();
                        model.themeName = Request["txtThemeName"];
                        model.themeTopPic = Request["txtImgUrl"];
                        model.themeTopBgPic = "";
                        model.Sort = Convert.ToInt32(Request["txtSort"]);
                        model.isLock = Request["chkIsLock"]==null?0:1;
                        try
                        {
                            if (theme_editid != 0)
                            {
                                model.Id = theme_editid;
                                ThemeBll.Update(model);
                            }
                            else
                            {
                                ThemeBll.Add(model);
                            }
                            Response.Write("true");
                        }
                        catch
                        {
                            Response.Write("false");
                        }
                    }
                    else if (strTag == "theme_delete")//出发城市删除
                    {
                        int themeid = Convert.ToInt32(Request["themeid"]);
                        try
                        {
                            ThemeBll.Delete(themeid);
                            Response.Write("true");
                        }
                        catch
                        {
                            Response.Write("false");
                        }
                    }
                    else if (strTag == "insure_save")//保险
                    {
                        int insure_editid = Convert.ToInt32(Request["hidId"]);
                        TravelAgent.Model.Insure model = new TravelAgent.Model.Insure();
                        model.InsureName = Request["txtInsureName"];
                        model.InsurePrice = Convert.ToInt32(Request["txtPrice"]);
                        model.InsureContent = Request["txtContent"];
                        model.AddDate = DateTime.Now;
                        model.IsLock = Request["chkIsLock"] == null ? 0 : 1;
                        try
                        {
                            if (insure_editid != 0)
                            {
                                model.Id = insure_editid;
                                InsureBll.Update(model);
                            }
                            else
                            {
                                InsureBll.Add(model);
                            }
                            Response.Write("true");
                        }
                        catch
                        {
                            Response.Write("false");
                        }
                    }
                    else if (strTag == "insure_delete")//保险删除
                    {
                        int insureid = Convert.ToInt32(Request["insureid"]);
                        try
                        {
                            if (LineBll.GetCount("insureid=" + insureid) == 0)
                            {
                                InsureBll.Delete(insureid);
                                Response.Write("true");
                            }
                            else
                            {
                                Response.Write("exsit");
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
}
