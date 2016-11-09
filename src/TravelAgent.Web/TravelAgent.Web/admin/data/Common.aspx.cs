using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace TravelAgent.Web.admin.data
{
    public partial class Common : System.Web.UI.Page
    {
        public int kindId;
        private static readonly TravelAgent.BLL.Category CategoryBll = new TravelAgent.BLL.Category();
        private static readonly TravelAgent.BLL.Article ArticleBll = new TravelAgent.BLL.Article();
        private static readonly TravelAgent.BLL.Advertising AdvBll = new TravelAgent.BLL.Advertising();
        private static readonly TravelAgent.BLL.Adbanner BarBll = new TravelAgent.BLL.Adbanner();
        private static readonly TravelAgent.BLL.Links linkBll = new TravelAgent.BLL.Links();
        private static readonly TravelAgent.BLL.VisaBrand BrandBll = new TravelAgent.BLL.VisaBrand();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (Request["tag"] != null)
                {
                    string strTag = Request["tag"];
                    if (strTag == "category")//新闻分类设置
                    {
                        int nav_editid = Convert.ToInt32(Request["hidId"]);
                        int navId;
                        int parentId = Convert.ToInt32(Request["ddlCategory"]);       //上一级目录
                        int navLayer = 1;                                         //栏目深度
                        string navList = "";
                        TravelAgent.Model.Category category = new TravelAgent.Model.Category();
                        category.Title = Request["txtName"];
                        category.ParentId = parentId;
                        category.PageUrl = Request["txtURL"];
                        category.ClassList = "";
                        category.ClassOrder = Convert.ToInt32(Request["txtSort"]);
                        category.KindId = this.kindId;
                        category.State = Request["chkState"]==null?"0":"1";
                        category.Css = "";
                        if (nav_editid == 0)
                        {
                            //添加导航
                            navId = CategoryBll.Add(category);
                        }
                        else
                        {
                            navId = nav_editid;
                        }
                        //修改导航的下属导航ID列表
                        if (parentId > 0)
                        {
                            DataSet ds = CategoryBll.GetChannelListByClassId(parentId);

                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                DataRow dr = ds.Tables[0].Rows[0];
                                navList = dr["ClassList"].ToString().Trim() + navId + ",";
                                navLayer = Convert.ToInt32(dr["ClassLayer"]) + 1;
                            }
                        }
                        else
                        {
                            navList = "," + navId + ",";
                            navLayer = 1;
                        }
                        category.Id = navId;
                        category.ClassList = navList;
                        category.ClassLayer = navLayer;

                        try
                        {
                            CategoryBll.Update(category);
                            Response.Write("true");
                        }
                        catch
                        {
                            Response.Write("false");
                        }
                    }
                    else if (strTag == "category_delete")//删除新闻分类
                    {
                        int categoryid = Convert.ToInt32(Request["categoryid"]);
                        try
                        {
                            CategoryBll.Delete(categoryid);
                            Response.Write("true");
                        }
                        catch
                        {
                            Response.Write("false");
                        }
                    }
                    else if (strTag == "new_delete")//删除内容
                    {
                        int categoryid = Convert.ToInt32(Request["newid"]);
                        try
                        {
                            ArticleBll.Delete(categoryid);
                            Response.Write("true");
                        }
                        catch
                        {
                            Response.Write("false");
                        }
                    }
                    else if (strTag == "adv")//广告位
                    {
                        int adv_Id;
                        int advid = Convert.ToInt32(Request["hidId"]);
                        TravelAgent.Model.Advertising model = new TravelAgent.Model.Advertising();
                        model.Title = Request["txtTitle"];
                        model.AdType = Convert.ToInt32(Request["rblAdType"]);
                        model.AdRemark = Request["txtAdRemark"];
                        model.AdNum = Convert.ToInt32(Request["txtAdNum"]);
                        model.AdPrice = 0;
                        model.AdWidth = Convert.ToInt32(Request["txtAdWidth"]);
                        model.AdHeight = Convert.ToInt32(Request["txtAdHeight"]);
                        model.AdTarget = Request["rblAdTarget"];
                        model.AdChannel = 0;
                        int parentId = Convert.ToInt32(Request["ddlAdv"]);       //上一级目录
                        model.ParentID = parentId;
                        model.ClassList = "";
                        int Layer = 1;                                         //栏目深度
                        string List = "";
                        if (advid == 0)
                        {
                            //添加导航
                            adv_Id = AdvBll.Add(model);
                        }
                        else
                        {
                            adv_Id = advid;
                        }
                        //修改导航的下属导航ID列表
                        if (parentId > 0)
                        {
                            DataSet ds = CategoryBll.GetChannelListByClassId(parentId);

                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                DataRow dr = ds.Tables[0].Rows[0];
                                List = dr["ClassList"].ToString().Trim() + adv_Id + ",";
                                Layer = Convert.ToInt32(dr["ClassLayer"]) + 1;
                            }
                        }
                        else
                        {
                            List = "," + adv_Id + ",";
                            Layer = 1;
                        }
                        model.Id = adv_Id;
                        model.ClassList = List;
                        model.ClassLayer = Layer;
                        try
                        {
                            AdvBll.Update(model);
                            Response.Write("true");
                        }
                        catch
                        {
                            Response.Write("false");
                        }
                    }
                    else if (strTag == "adv_delete")//删除广告位
                    {
                        int advid = Convert.ToInt32(Request["advid"]);
                        try
                        {
                            AdvBll.Delete(advid);//删除广告位
                            BarBll.DeleteByAID(advid);//同时删除广告位下面的广告
                            Response.Write("true");
                        }
                        catch
                        {
                            Response.Write("false");
                        }
                    }
                    else if (strTag == "bar")//广告内容
                    {
                        int barid = Convert.ToInt32(Request["hidId"]);
                        TravelAgent.Model.Adbanner model = new TravelAgent.Model.Adbanner();
                        model.Title = Request["txtTitle"];
                        model.StartTime = DateTime.Parse(Request["txtStartTime"]);
                        model.EndTime = DateTime.Parse(Request["txtEndTime"]);
                        model.AdUrl = Request["txtImgUrl"];
                        model.LinkUrl = Request["txtLinkUrl"];
                        model.AdRemark = TravelAgent.Tool.StringPlus.ToHtml(Request["txtAdRemark"]);
                        model.IsLock = int.Parse(Request["rblIsLock"]);
                        model.AddTime = DateTime.Now;
                        model.Aid = int.Parse(Request["hidaId"]);
                        try
                        {
                            if (barid != 0)
                            {
                                model.Id = barid;
                                BarBll.Update(model);
                            }
                            else
                            {
                                BarBll.Add(model);
                            }
                            Response.Write("true");
                        }
                        catch
                        {
                            Response.Write("false");
                        }
                    }
                    else if (strTag == "bar_delete")
                    {
                        int barid = Convert.ToInt32(Request["barid"]);
                        try
                        {
                            BarBll.Delete(barid);

                            Response.Write("true");
                        }
                        catch
                        {
                            Response.Write("false");
                        }
                    }
                    else if (strTag == "links")//友情链接
                    {
                        int linkid = Convert.ToInt32(Request["hidId"]);
                        TravelAgent.Model.Links model = new TravelAgent.Model.Links();
                        model.Title = Request["txtName"];
                        model.WebUrl = Request["txtURL"];
                        model.UserName = Request["txtContactName"];
                        model.UserTel = Request["txtLinkContent"];
                        model.UserMail = Request["txtEmail"];
                        model.SortId = Convert.ToInt32(Request["txtSort"]);
                        model.IsLock = Request["chkState"]==null?0:1;
                        model.AddTime = DateTime.Now;
                        model.IsImage = 0;
                        model.IsRed = 1;
                        model.ImgUrl = "";
                        try
                        {
                            if (linkid != 0)
                            {
                                model.Id = linkid;
                                linkBll.Update(model);
                            }
                            else
                            {
                                linkBll.Add(model);
                            }
                            Response.Write("true");
                        }
                        catch
                        {
                            Response.Write("false");
                        }
                    }
                    else if (strTag == "link_delete")//友情链接
                    {
                        int linkid = Convert.ToInt32(Request["linkid"]);
                        try
                        {
                            linkBll.Delete(linkid);

                            Response.Write("true");
                        }
                        catch
                        {
                            Response.Write("false");
                        }
                    }
                    else if (strTag == "brand_save")//网站优势
                    {
                        int brandid = Convert.ToInt32(Request["hidId"]);
                        TravelAgent.Model.VisaBrand model = new TravelAgent.Model.VisaBrand();
                        model.Title = Request["txtTitle"];
                        model.SubTitle = Request["txtSubTitle"];
                        model.PicUrl = "";
                        model.Type = Convert.ToInt32(Request["ddlType"]);
                        model.Sort = Convert.ToInt32(Request["txtSort"]);
                        model.isLock = Request["chkState"] == null ? 0 : 1;
                        try
                        {
                            if (brandid != 0)
                            {
                                model.Id = brandid;
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
                    else if (strTag == "brand_delete")//网站优势
                    {
                        int brandid = Convert.ToInt32(Request["brandid"]);
                        try
                        {
                            BrandBll.Delete(brandid);

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
