using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TravelAgent.Web.admin.data
{
    public partial class Visa : System.Web.UI.Page
    {
        private static readonly TravelAgent.BLL.VisaCity CityBll = new TravelAgent.BLL.VisaCity();
        private static readonly TravelAgent.BLL.VisaCountry CountryBll = new TravelAgent.BLL.VisaCountry();
        private static readonly TravelAgent.BLL.VisaType TypeBll = new TravelAgent.BLL.VisaType();
        private static readonly TravelAgent.BLL.VisaList VisaBll = new TravelAgent.BLL.VisaList();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (Request["tag"] != null)
                {
                    string strTag = Request["tag"];
                    if (strTag == "city_save")//领区城市
                    {
                        int city_editid = Convert.ToInt32(Request["hidId"]);
                        TravelAgent.Model.VisaCity model = new TravelAgent.Model.VisaCity();
                        model.CityName = Request["txtCityName"];
                        model.Tips = Request["txtTips"];
                        model.Sort = Convert.ToInt32(Request["txtSort"]);
                        model.isLock =Request["chkState"]==null?0:1;
                        try
                        {
                            if (city_editid != 0)
                            {
                                model.Id = city_editid;
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
                    else if (strTag == "country")//签证国家区域管理
                    {
                        int c_editid = Convert.ToInt32(Request["hidId"]);
                        int cId;
                        int parentId = Convert.ToInt32(Request["ddlAreaCountry"]);       //上一级目录
                        int Layer = 1;                                         //栏目深度
                        string List = "";
                        TravelAgent.Model.VisaCountry country = new TravelAgent.Model.VisaCountry();
                        country.Name = Request["txtName"];
                        country.ParentId = parentId;
                        country.PicUrl = Request["txtImgUrl"];
                        country.Tips = Request["txtTips"];
                        country.EnglishName = Request["txtEnglishName"];
                        country.FirstWord = Request["txtFristWord"];
                        country.ClassList = "";
                        country.Sort = Convert.ToInt32(Request["txtSort"]);
                        country.isLock = Request["chkState"]==null?0:1;
                        if (c_editid == 0)
                        {
                            //添加
                            cId = CountryBll.Add(country);
                        }
                        else
                        {
                            cId = c_editid;
                        }
                        //修改
                        if (parentId > 0)
                        {
                            DataSet ds = CountryBll.GetListByClassId(parentId);

                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                DataRow dr = ds.Tables[0].Rows[0];
                                List = dr["ClassList"].ToString().Trim() + cId + ",";
                                Layer = Convert.ToInt32(dr["ClassLayer"]) + 1;
                            }
                        }
                        else
                        {
                            List = "," + cId + ",";
                            Layer = 1;
                        }
                        country.Id = cId;
                        country.ClassList = List;
                        country.ClassLayer =Layer;

                        try
                        {
                            CountryBll.Update(country);
                            Response.Write("true");
                        }
                        catch
                        {
                            Response.Write("false");
                        }
                    }
                    else if (strTag == "country_delete")//删除
                    {
                        int destid = Convert.ToInt32(Request["countryid"]);
                        try
                        {
                            CountryBll.Delete(destid);
                            Response.Write("true");
                        }
                        catch
                        {
                            Response.Write("false");
                        }
                    }
                    else if (strTag == "type_save")//签证类型保存
                    {
                        int type_editid = Convert.ToInt32(Request["hidId"]);
                        TravelAgent.Model.VisaType model = new TravelAgent.Model.VisaType();
                        model.Name = Request["txtName"];
                        model.Sort = Convert.ToInt32(Request["txtSort"]);
                        model.isLock = Request["chkState"]==null?0:1;
                        try
                        {
                            if (type_editid != 0)
                            {
                                model.Id = type_editid;
                                TypeBll.Update(model);
                            }
                            else
                            {
                                TypeBll.Add(model);
                            }
                            Response.Write("true");
                        }
                        catch
                        {
                            Response.Write("false");
                        }
                    }
                    else if (strTag == "type_delete")//签证类型删除
                    {
                        int cityid = Convert.ToInt32(Request["typeid"]);
                        try
                        {
                            TypeBll.Delete(cityid);
                            Response.Write("true");
                        }
                        catch
                        {
                            Response.Write("false");
                        }
                    }
                    else if (strTag == "visa_delete")//签证删除
                    {
                        int visaid = Convert.ToInt32(Request["visaid"]);
                        try
                        {
                            VisaBll.Delete(visaid);
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
