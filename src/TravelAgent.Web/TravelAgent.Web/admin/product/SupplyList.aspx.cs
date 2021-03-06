﻿using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TravelAgent.Web.admin.product
{
    public partial class SupplyList : TravelAgent.Web.UI.BasePage
    {
        private static readonly TravelAgent.BLL.Supply SupplyBll = new TravelAgent.BLL.Supply();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                DataBindRpt();
            }
        }
        /// <summary>
        /// 显示添加
        /// </summary>
        /// <returns></returns>
        public string ShowAdd()
        {
            StringBuilder sbButton = new StringBuilder();
            if (Admin.Role.roleAuth.IndexOf(",linesupply_add,") > -1)
            {
                sbButton.Append("<ul class=\"toolbar\">");
                sbButton.Append("<li class=\"click\"><a href=\"EditSupply.aspx\" title=\"添加供应商\"><span><img src=\"../images/t01.png\" /></span>添加供应商</a></li>");
                sbButton.Append("</ul>");
            }
            return sbButton.ToString();
        }
        /// <summary>
        /// 绑定供应商
        /// </summary>
        private void DataBindRpt()
        {
            DataSet ds = SupplyBll.GetList();
            this.rptSupply.DataSource = ds.Tables[0].DefaultView;
            this.DataBind();
            divNoRecord.Style["display"] = ds.Tables[0].Rows.Count == 0 ? "" : "none";
        }

        /// <summary>
        /// 显示编辑按钮
        /// </summary>
        /// <param name="id"></param>
        /// <param name="title"></param>
        /// <returns></returns>
        public string ShowEdit(string id, string title)
        {
            StringBuilder sbEdit = new StringBuilder();
            if (Admin.Role.roleAuth.IndexOf(",linesupply_update,") > -1)
            {
                sbEdit.Append("<a href=\"EditSupply.aspx?supplyid="+id+"\" class=\"tablelink\">修改</a>  ");
            }
            if (Admin.Role.roleAuth.IndexOf(",linesupply_delete,") > -1)
            {
                sbEdit.Append("<a id=\""+id+"\" name=\""+title+"\" href=\"#\" class=\"tablelink supply_delete\">删除</a>");
            }
            return sbEdit.ToString();
        }
    }
}
