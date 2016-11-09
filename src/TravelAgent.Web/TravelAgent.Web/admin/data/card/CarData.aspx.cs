using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TravelAgent.Web.admin.data.card
{
    public partial class CarData : System.Web.UI.Page
    {
        private static readonly TravelAgent.BLL.CarCity CityBll = new TravelAgent.BLL.CarCity();
        private static readonly TravelAgent.BLL.CarBrand BrandBll = new TravelAgent.BLL.CarBrand();
        private static readonly TravelAgent.BLL.CarClass ClassBll = new TravelAgent.BLL.CarClass();
        private static readonly TravelAgent.BLL.CarNumber NumBll = new TravelAgent.BLL.CarNumber();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (Request["tag"] != null)
                {
                    string strTag = Request["tag"];
                    if (strTag == "city_save")//租车城市保存
                    {
                        int city_editid = Convert.ToInt32(Request["hidId"]);
                        TravelAgent.Model.CarCity model = new TravelAgent.Model.CarCity();
                        model.CityName = Request["txtCityName"];
                        model.Sort = Convert.ToInt32(Request["txtSort"]);
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
                    else if (strTag == "city_delete")//租车城市删除
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
                    else if (strTag == "brand_save")//租车品牌保存
                    {
                        int brand_editid = Convert.ToInt32(Request["hidId"]);
                        TravelAgent.Model.CarBrand model = new TravelAgent.Model.CarBrand();
                        model.BrandName = Request["txtBrandName"];
                        model.BrandPic = Request["txtImgUrl"];
                        model.Sort = Convert.ToInt32(Request["txtSort"]);
                        try
                        {
                            if (brand_editid != 0)
                            {
                                model.Id = brand_editid;
                                BrandBll.Update(model);
                            }
                            else
                            {
                                BrandBll.Add(model);
                            }
                            Response.Write("true");
                        }
                        catch
                        {
                            Response.Write("false");
                        }
                    }
                    else if (strTag == "brand_delete")//租车品牌删除
                    {
                        int themeid = Convert.ToInt32(Request["brandid"]);
                        try
                        {
                            BrandBll.Delete(themeid);
                            Response.Write("true");
                        }
                        catch
                        {
                            Response.Write("false");
                        }
                    }
                    else if (strTag == "class_save")//车辆级别保存
                    {
                        int city_editid = Convert.ToInt32(Request["hidId"]);
                        TravelAgent.Model.CarClass model = new TravelAgent.Model.CarClass();
                        model.ClassName = Request["txtClassName"];
                        model.Sort = Convert.ToInt32(Request["txtSort"]);
                        try
                        {
                            if (city_editid != 0)
                            {
                                model.Id = city_editid;
                                ClassBll.Update(model);
                            }
                            else
                            {
                                ClassBll.Add(model);
                            }
                            Response.Write("true");
                        }
                        catch
                        {
                            Response.Write("false");
                        }
                    }
                    else if (strTag == "class_delete")//车辆级别删除
                    {
                        int cityid = Convert.ToInt32(Request["classid"]);
                        try
                        {
                            ClassBll.Delete(cityid);
                            Response.Write("true");
                        }
                        catch
                        {
                            Response.Write("false");
                        }
                    }
                    else if (strTag == "num_save")//汽车厢数保存
                    {
                        int city_editid = Convert.ToInt32(Request["hidId"]);
                        TravelAgent.Model.CarNumber model = new TravelAgent.Model.CarNumber();
                        model.NumName = Request["txtNumName"];
                        model.Sort = Convert.ToInt32(Request["txtSort"]);
                        try
                        {
                            if (city_editid != 0)
                            {
                                model.Id = city_editid;
                                NumBll.Update(model);
                            }
                            else
                            {
                                NumBll.Add(model);
                            }
                            Response.Write("true");
                        }
                        catch
                        {
                            Response.Write("false");
                        }
                    }
                    else if (strTag == "num_delete")//汽车厢数删除
                    {
                        int cityid = Convert.ToInt32(Request["numid"]);
                        try
                        {
                            NumBll.Delete(cityid);
                            Response.Write("true");
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
