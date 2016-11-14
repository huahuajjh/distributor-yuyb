using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TravelAgent.Web.admin
{
    public partial class Admin_Default : TravelAgent.Web.UI.BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 显示顶部导航
        /// </summary>
        /// <returns></returns>
        public string ShowTopNav()
        {
            StringBuilder sbNav = new StringBuilder();
            if (Admin.Role.roleAuth.IndexOf(",sys,")>-1)
            {
                sbNav.Append("<li onclick=\"Navs(0,'系统设置','sys');\"><a href=\"javascript:void(0);\" ><img src=\"images/sys.png\" title=\"系统设置\" /><h2>系统设置</h2></a></li>");
            }
            if (Admin.Role.roleAuth.IndexOf(",pro,") > -1)
            {
                sbNav.Append("<li onclick=\"Navs(1,'产品管理','product');\"><a href=\"javascript:void(0);\"><img src=\"images/line.png\" title=\"产品管理\" /><h2>产品管理</h2></a></li>");
            }
            if (Admin.Role.roleAuth.IndexOf(",order,") > -1)
            {
                sbNav.Append("<li onclick=\"Navs(2,'订单管理','order');\"><a href=\"javascript:void(0);\"><img src=\"images/order.png\" title=\"订单管理\" /><h2>订单管理</h2></a></li>");
            }
            if (Admin.Role.roleAuth.IndexOf(",club,") > -1)
            {
                sbNav.Append("<li onclick=\"Navs(3,'会员管理','club');\"><a href=\"javascript:void(0);\"><img src=\"images/club.png\" title=\"会员管理\" /><h2>会员管理</h2></a></li>");
            }
            if (Admin.Role.roleAuth.IndexOf(",common,") > -1)
            {
                sbNav.Append("<li onclick=\"Navs(4,'通用管理','common');\"><a href=\"javascript:void(0);\"><img src=\"images/common.png\" title=\"通用模块\" /><h2>通用模块</h2></a></li>");
            }
            return sbNav.ToString();
        }
        /// <summary>
        /// 显示左边导航
        /// </summary>
        /// <returns></returns>
        public string ShowLeftNav()
        {
            StringBuilder sbNav = new StringBuilder();
            if (Admin.Role.roleAuth.IndexOf(",sys,") > -1)
            {
                sbNav.Append("<li onclick=\"Navs(0,'系统设置','sys');\"><cite></cite><a href=\"javascript:void(0);\">系统设置</a><i></i></li>");
            }
            if (Admin.Role.roleAuth.IndexOf(",pro,") > -1)
            {
                sbNav.Append("<li onclick=\"Navs(1,'产品管理','product');\"><cite></cite><a href=\"javascript:void(0);\">产品管理</a><i></i></li>");
            }
            if (Admin.Role.roleAuth.IndexOf(",order,") > -1)
            {
                sbNav.Append("<li onclick=\"Navs(2,'订单管理','order');\"><cite></cite><a href=\"javascript:void(0);\">订单管理</a><i></i></li>");
            }
            if (Admin.Role.roleAuth.IndexOf(",club,") > -1)
            {
                sbNav.Append("<li onclick=\"Navs(3,'会员管理','club');\"><cite></cite><a href=\"javascript:void(0);\">会员管理</a><i></i></li>");
            }
            if (Admin.Role.roleAuth.IndexOf(",common,") > -1)
            {
                sbNav.Append("<li onclick=\"Navs(4,'通用管理','common');\"><cite></cite><a href=\"javascript:void(0);\">通用模块</a><i></i></li>");
            }
            return sbNav.ToString();
        }
        /// <summary>
        /// 显示系统设置列表
        /// </summary>
        /// <returns></returns>
        public string ShowSysNav()
        {
            StringBuilder sbNav = new StringBuilder();
            if (Admin.Role.roleAuth.IndexOf(",sysbase,") > -1)
            {
                sbNav.Append("<li><cite></cite><a href=\"javascript:void(0);\" onclick=\"Tabs('basicset/WebBasicInfo.aspx')\">网站基本设置</a><i></i></li>");
            }
            if (Admin.Role.roleAuth.IndexOf(",sysnav,") > -1)
            {
                sbNav.Append("<li><cite></cite><a href=\"javascript:void(0);\" onclick=\"Tabs('basicset/WebNav.aspx')\">网站导航设置</a><i></i></li>");
            }
            if (Admin.Role.roleAuth.IndexOf(",sysbrand,") > -1)
            {
                sbNav.Append("<li><cite></cite><a href=\"javascript:void(0);\" onclick=\"Tabs('basicset/WebBrand.aspx')\">网站品牌设置</a><i></i></li>");
            }

            if (Admin.Role.roleAuth.IndexOf(",sysinterface,") > -1)
            {
                sbNav.Append("<li><cite></cite><a href=\"javascript:void(0);\" onclick=\"Tabs('basicset/PayInterface.aspx')\">网站接口设置</a><i></i></li>");
            }

            if (Admin.Role.roleAuth.IndexOf(",sysother,") > -1)
            {
                sbNav.Append("<li><cite></cite><a href=\"javascript:void(0);\" onclick=\"Tabs('basicset/WebOther.aspx')\">网站其他设置</a><i></i></li>");
            }

            if (Admin.Role.roleAuth.IndexOf(",sysclub,") > -1)
            {
                sbNav.Append("<li><cite></cite><a href=\"javascript:void(0);\" onclick=\"Tabs('basicset/ClubSysSetting.aspx')\">会员系统设置</a><i></i></li>");
            }
            if (Admin.Role.roleAuth.IndexOf(",sysrole,") > -1)
            {
                sbNav.Append("<li><cite></cite><a href=\"javascript:void(0);\" onclick=\"Tabs('basicset/RoleList.aspx')\">角色权限设置</a><i></i></li>");
            }
            if (Admin.Role.roleAuth.IndexOf(",sysuser,") > -1)
            {
                sbNav.Append("<li><cite></cite><a href=\"javascript:void(0);\" onclick=\"Tabs('basicset/AdminList.aspx')\">操作用户管理</a><i></i></li>");
            }
            return sbNav.ToString();
        }
        /// <summary>
        /// 显示产品管理列表
        /// </summary>
        /// <returns></returns>
        public string ShowProNav()
        {
            StringBuilder sbNav = new StringBuilder();
            //线路产品
            if (Admin.Role.roleAuth.IndexOf(",proline,") > -1)
            {
                sbNav.Append("<dd class=\"product noshow\">");
                sbNav.Append("<div class=\"title\"><span><img src=\"images/leftico01.png\" /></span>线路产品</div>");
                sbNav.Append("<ul class=\"menuson show\">");
                if (Admin.Role.roleAuth.IndexOf(",linelist,") > -1)
                {
                    sbNav.Append("<li><cite></cite><a href=\"javascript:void(0);\" onclick=\"Tabs('product/LineList.aspx')\">线路列表</a><i></i></li>");
                }
                if (Admin.Role.roleAuth.IndexOf(",linesupply,") > -1)
                {
                    sbNav.Append("<li><cite></cite><a href=\"javascript:void(0);\" onclick=\"Tabs('product/SupplyList.aspx')\">线路供应商</a><i></i></li>");
                }
                if (Admin.Role.roleAuth.IndexOf(",linedest,") > -1)
                {
                    sbNav.Append("<li><cite></cite><a href=\"javascript:void(0);\" onclick=\"Tabs('product/ProductDest.aspx')\">目的地分类</a><i></i></li>");
                }
                if (Admin.Role.roleAuth.IndexOf(",linetheme,") > -1)
                {
                    sbNav.Append("<li><cite></cite><a href=\"javascript:void(0);\" onclick=\"Tabs('product/ThemeList.aspx')\">线路主题</a><i></i></li>");
                }
                if (Admin.Role.roleAuth.IndexOf(",lineholiday,") > -1)
                {
                    sbNav.Append("<li><cite></cite><a href=\"javascript:void(0);\" onclick=\"Tabs('product/LineHoliday.aspx')\">节日推荐</a><i></i></li>");
                }
                if (Admin.Role.roleAuth.IndexOf(",linecity,") > -1)
                {
                    sbNav.Append("<li><cite></cite><a href=\"javascript:void(0);\" onclick=\"Tabs('product/DepartureCity.aspx')\">出发城市</a><i></i></li>");
                }
                if (Admin.Role.roleAuth.IndexOf(",linejoin,") > -1)
                {
                    sbNav.Append("<li><cite></cite><a href=\"javascript:void(0);\" onclick=\"Tabs('product/JoinProperty.aspx')\">参团性质</a><i></i></li>");
                }
                if (Admin.Role.roleAuth.IndexOf(",lineinsure,") > -1)
                {
                    sbNav.Append("<li><cite></cite><a href=\"javascript:void(0);\" onclick=\"Tabs('product/InsureList.aspx')\">保险列表</a><i></i></li>");
                }
                if (Admin.Role.roleAuth.IndexOf(",linezixun,") > -1)
                {
                    sbNav.Append("<li><cite></cite><a href=\"javascript:void(0);\" onclick=\"Tabs('product/LineZixunList.aspx')\">线路咨询</a><i></i></li>");
                }
                sbNav.Append("</ul>");
                sbNav.Append("</dd>");
            }
            //签证产品
            if (Admin.Role.roleAuth.IndexOf(",provisa,") > -1)
            {
                sbNav.Append("<dd class=\"product noshow\">");
                sbNav.Append("<div class=\"title\"><span><img src=\"images/leftico01.png\" /></span>签证产品</div>");
                sbNav.Append("<ul class=\"menuson noshow\">");
                if (Admin.Role.roleAuth.IndexOf(",visalist,") > -1)
                {
                    sbNav.Append("<li><cite></cite><a href=\"javascript:void(0);\" onclick=\"Tabs('visa/VisaList.aspx')\">签证列表</a><i></i></li>");
                }
                if (Admin.Role.roleAuth.IndexOf(",lingqu,") > -1)
                {
                    sbNav.Append("<li><cite></cite><a href=\"javascript:void(0);\" onclick=\"Tabs('visa/VisaCityList.aspx')\">领区管理</a><i></i></li>");
                }
                if (Admin.Role.roleAuth.IndexOf(",area,") > -1)
                {
                    sbNav.Append("<li><cite></cite><a href=\"javascript:void(0);\" onclick=\"Tabs('visa/VisaAreaCountry.aspx')\">签证国家区域</a><i></i></li>");
                }
                if (Admin.Role.roleAuth.IndexOf(",visatype,") > -1)
                {
                    sbNav.Append("<li><cite></cite><a href=\"javascript:void(0);\" onclick=\"Tabs('visa/VistTypeList.aspx')\">签证类型</a><i></i></li>");
                }
                if (Admin.Role.roleAuth.IndexOf(",visaset,") > -1)
                {
                    sbNav.Append("<li><cite></cite><a href=\"javascript:void(0);\" onclick=\"Tabs('visa/VisaSetting.aspx')\">签证基本设置</a><i></i></li>");
                }
            
                sbNav.Append("</ul>");
                sbNav.Append("</dd>");
            }

            #region old code
            //租车产品，记得要改
            //if (Admin.Role.roleAuth.IndexOf(",provisa,") > -1)
            //{
            //    sbNav.Append("<dd class=\"product noshow\">");
            //    sbNav.Append("<div class=\"title\"><span><img src=\"images/leftico01.png\" /></span>租车产品</div>");
            //    sbNav.Append("<ul class=\"menuson noshow\">");
            //    if (Admin.Role.roleAuth.IndexOf(",visalist,") > -1)
            //    {
            //        sbNav.Append("<li><cite></cite><a href=\"javascript:void(0);\" onclick=\"Tabs('car/CarList.aspx')\">租车列表</a><i></i></li>");
            //    }
            //    if (Admin.Role.roleAuth.IndexOf(",lingqu,") > -1)
            //    {
            //        sbNav.Append("<li><cite></cite><a href=\"javascript:void(0);\" onclick=\"Tabs('car/CarCity.aspx')\">租车城市</a><i></i></li>");
            //    }
            //    if (Admin.Role.roleAuth.IndexOf(",area,") > -1)
            //    {
            //        sbNav.Append("<li><cite></cite><a href=\"javascript:void(0);\" onclick=\"Tabs('car/CarNumber.aspx')\">汽车厢数</a><i></i></li>");
            //    }
            //    if (Admin.Role.roleAuth.IndexOf(",visatype,") > -1)
            //    {
            //        sbNav.Append("<li><cite></cite><a href=\"javascript:void(0);\" onclick=\"Tabs('car/CarBrand.aspx')\">汽车品牌</a><i></i></li>");
            //    }
            //    if (Admin.Role.roleAuth.IndexOf(",visaset,") > -1)
            //    {
            //        sbNav.Append("<li><cite></cite><a href=\"javascript:void(0);\" onclick=\"Tabs('car/CarClass.aspx')\">车辆级别</a><i></i></li>");
            //    }
            //
            //    sbNav.Append("</ul>");
            //    sbNav.Append("</dd>");
            //}
            #endregion
            
            return sbNav.ToString();
        }
        /// <summary>
        /// 显示订单列表
        /// </summary>
        /// <returns></returns>
        public string ShowOrderNav()
        {
            StringBuilder sbNav = new StringBuilder();
            if (Admin.Role.roleAuth.IndexOf(",lineorder,") > -1)
            {
                sbNav.Append("<li><cite></cite><a href=\"javascript:void(0);\" onclick=\"Tabs('product/LineOrderList.aspx')\">线路订单</a><i></i></li>");
            }
            if (Admin.Role.roleAuth.IndexOf(",visaorder,") > -1)
            {
                sbNav.Append("<li><cite></cite><a href=\"javascript:void(0);\" onclick=\"Tabs('visa/VisaOrderList.aspx')\">签证订单</a><i></i></li>");
            }
            #region useless code
            //if (Admin.Role.roleAuth.IndexOf(",carorder,") > -1)
            //{
            //    sbNav.Append("<li><cite></cite><a href=\"javascript:void(0);\" onclick=\"Tabs('car/CarOrder.aspx')\">租车订单</a><i></i></li>");
            //}
            #endregion
            
            if (Admin.Role.roleAuth.IndexOf(",customerorder,") > -1)
            {
                sbNav.Append("<li><cite></cite><a href=\"javascript:void(0);\" onclick=\"Tabs('product/CusomerOrderList.aspx')\">定制列表</a><i></i></li>");
            }
            
            return sbNav.ToString();
        }
        /// <summary>
        /// 显示会员列表
        /// </summary>
        /// <returns></returns>
        public string ShowClubNav()
        {
            StringBuilder sbNav = new StringBuilder();
            if (Admin.Role.roleAuth.IndexOf(",clublist,") > -1)
            {
                sbNav.Append("<li><cite></cite><a href=\"javascript:void(0);\" onclick=\"Tabs('club/ClubList.aspx')\">会员列表</a><i></i></li>");
            }
            if (Admin.Role.roleAuth.IndexOf(",sms,") > -1)
            {
                sbNav.Append("<li><cite></cite><a href=\"javascript:void(0);\" onclick=\"Tabs('club/GroupSMS.aspx')\">短信群发</a><i></i></li>");
            }
            if (Admin.Role.roleAuth.IndexOf(",email,") > -1)
            {
                sbNav.Append("<li><cite></cite><a href=\"javascript:void(0);\" onclick=\"Tabs('club/GroupEmail.aspx')\">邮件群发</a><i></i></li>");
            }
            return sbNav.ToString();
        }
        /// <summary>
        /// 显示通用模块列表
        /// </summary>
        /// <returns></returns>
        public string ShowCommonNav()
        {
            StringBuilder sbNav = new StringBuilder();
            if (Admin.Role.roleAuth.IndexOf(",article,") > -1)
            {
                sbNav.Append("<li><cite></cite><a href=\"javascript:void(0);\" onclick=\"Tabs('common/CategoryList.aspx')\">内容分类</a><i></i></li>");
            }
            if (Admin.Role.roleAuth.IndexOf(",articlelst,") > -1)
            {
                sbNav.Append("<li><cite></cite><a href=\"javascript:void(0);\" onclick=\"Tabs('common/NewList.aspx')\">内容列表</a><i></i></li>");
            }
            if (Admin.Role.roleAuth.IndexOf(",adv,") > -1)
            {
                sbNav.Append("<li><cite></cite><a href=\"javascript:void(0);\" onclick=\"Tabs('common/AdvList.aspx')\">广告列表</a><i></i></li>");
            }
            if (Admin.Role.roleAuth.IndexOf(",linkk,") > -1)
            {
                sbNav.Append("<li><cite></cite><a href=\"javascript:void(0);\" onclick=\"Tabs('common/LinkList.aspx')\">友情链接</a><i></i></li>");
            }
            sbNav.Append("<li><cite></cite><a href=\"javascript:void(0);\" onclick=\"Tabs('guide/CheckList.aspx')\">游记列表</a><i></i></li>");
            return sbNav.ToString();
        }
    }
}
