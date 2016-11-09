using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TravelAgent.BLL;

namespace TravelAgent.Web.admin.basicset
{
    public partial class EditNav : TravelAgent.Web.UI.BasePage
    {
        public readonly int kindId = 0; //类别种类
        private static readonly TravelAgent.BLL.WebNav WebNavBll = new TravelAgent.BLL.WebNav();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                DataBindNav();
                DataBindCheckBoxList();

                if (Request.QueryString["navid"] != null)
                {
                    int navid = Convert.ToInt32(Request.QueryString["navid"]);
                    TravelAgent.Model.WebNav nav = WebNavBll.GetModel(navid);

                    if (nav != null)
                    {
                        this.hidNavId.Value = nav.Id.ToString();
                        this.ddlNav.SelectedValue = nav.navParentId.ToString();
                        this.txtNavName.Text = nav.navName;
                        this.txtNavURL.Text = nav.navURL;
                        this.txtSort.Text = nav.navSort.ToString();

                        foreach (ListItem item in chkState.Items)
                        {
                            if (TravelAgent.Tool.CommonOprate.IsContainValue(item.Value, nav.State))
                            {
                                item.Selected = true;
                            }
                        }
                    }
                }
                else
                {
                    this.txtSort.Text = (WebNavBll.GetMaxID("navSort")+1).ToString();
                }
            }
        }
        /// <summary>
        /// 绑定导航归属
        /// </summary>
        private void DataBindNav()
        {
            TravelAgent.BLL.WebNav navbll = new TravelAgent.BLL.WebNav();
            DataTable dt = navbll.GetList(0, this.kindId);

            this.ddlNav.Items.Clear();
            this.ddlNav.Items.Add(new ListItem("导航根目录", "0"));
            foreach (DataRow dr in dt.Rows)
            {
                int ClassLayer = Convert.ToInt32(dr["navLayer"]);
                string Id = dr["Id"].ToString().Trim();
                string Name = dr["navName"].ToString().Trim();

                if (ClassLayer == 1)
                {
                    Name = "├ " + Name;
                    this.ddlNav.Items.Add(new ListItem(Name, Id));

                }
                else
                {
                    Name = "├ " + Name;
                    Name = TravelAgent.Tool.StringPlus.StringOfChar(ClassLayer - 1, "　") + Name;

                    this.ddlNav.Items.Add(new ListItem(Name, Id));
                }
            }
        }
        /// <summary>
        /// 绑定状态列表
        /// </summary>
        private void DataBindCheckBoxList()
        {
            //this.chkState.DataSource = TravelAgent.Tool.EnumHelper.GetMemberKeyValue<TravelAgent.Tool.EnumSummary.State>();//数据源
            //this.chkState.DataTextField = "key";//显示的名称
            //this.chkState.DataValueField = "value";//返回的值
            //this.chkState.DataBind();
            Hashtable ht = TravelAgent.Tool.EnumHelper.GetMemberKeyValue<TravelAgent.Tool.EnumSummary.State>();//数据源
             foreach(DictionaryEntry de in ht)  
            {
                 ListItem item=new ListItem(de.Key.ToString(), de.Value.ToString());
                 item.Attributes.Add("alt", item.Value);
                 chkState.Items.Add(item);
            }  
        }
    }
}
