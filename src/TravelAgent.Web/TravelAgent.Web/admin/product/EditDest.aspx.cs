using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TravelAgent.Web.admin.product
{
    public partial class EditDest : TravelAgent.Web.UI.BasePage
    {
        public readonly int kindId = 0; //类别种类
        private static readonly TravelAgent.BLL.Destination DestBll = new TravelAgent.BLL.Destination();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                DataBindNav();
                DataBindCheckBoxList();

                if (Request.QueryString["destid"] != null)
                {
                    int navid = Convert.ToInt32(Request.QueryString["destid"]);
                    TravelAgent.Model.Destination dest = DestBll.GetModel(navid);

                    if (dest != null)
                    {
                        this.hidId.Value = dest.Id.ToString();
                        this.ddlDest.SelectedValue = dest.navParentId.ToString();
                        this.txtDestName.Text = dest.navName;
                        this.txtDestURL.Text = dest.navURL;
                        this.txtSort.Text = dest.navSort.ToString();
                        this.chkLock.Checked = dest.isLock > 0;
                        foreach (ListItem item in chkState.Items)
                        {
                            //if (TravelAgent.Tool.CommonOprate.IsContainValue(item.Value, dest.State))
                            //{
                            //    item.Selected = true;
                            //}
                            if (dest.State.Contains("," + item.Value + ","))
                            {
                                item.Selected = true;
                            }
                        }
                    }
                }
                else
                {
                    this.txtSort.Text = (DestBll.GetMaxID("navSort") + 1).ToString();
                }
            }
        }
        /// <summary>
        /// 绑定导航归属
        /// </summary>
        private void DataBindNav()
        {
            DataTable dt = DestBll.GetList(0, this.kindId);

            this.ddlDest.Items.Clear();
            this.ddlDest.Items.Add(new ListItem("目的地根目录", "0"));
            foreach (DataRow dr in dt.Rows)
            {
                int ClassLayer = Convert.ToInt32(dr["navLayer"]);
                string Id = dr["Id"].ToString().Trim();
                string Name = dr["navName"].ToString().Trim();

                if (ClassLayer == 1)
                {
                    Name = "├ " + Name;
                    this.ddlDest.Items.Add(new ListItem(Name, Id));

                }
                else
                {
                    Name = "├ " + Name;
                    Name = TravelAgent.Tool.StringPlus.StringOfChar(ClassLayer - 1, "　") + Name;

                    this.ddlDest.Items.Add(new ListItem(Name, Id));
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
            foreach (DictionaryEntry de in ht)
            {
                ListItem item = new ListItem(de.Key.ToString(), de.Value.ToString());
                item.Attributes.Add("alt", item.Value);
                chkState.Items.Add(item);
            }  
        }
    }
}
