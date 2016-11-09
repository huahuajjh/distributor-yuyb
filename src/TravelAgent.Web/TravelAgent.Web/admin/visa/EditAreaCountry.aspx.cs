using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TravelAgent.Web.admin.visa
{
    public partial class EditAreaCountry : TravelAgent.Web.UI.BasePage
    {
        private static readonly TravelAgent.BLL.VisaCountry bll = new TravelAgent.BLL.VisaCountry();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                DataBindNav();
                if (Request.QueryString["id"] != null)
                { 
                    int id=Convert.ToInt32(Request.QueryString["id"]);
                    TravelAgent.Model.VisaCountry model = bll.GetModel(id);
                    if (model != null)
                    {
                        this.hidId.Value = id.ToString();
                        this.ddlAreaCountry.SelectedValue = model.ParentId.ToString();
                        this.txtName.Text = model.Name;
                        this.txtTips.Value = model.Tips;
                        this.txtImgUrl.Text = model.PicUrl;
                        this.txtEnglishName.Text = model.EnglishName;
                        this.txtFristWord.Text = model.FirstWord;
                        this.txtSort.Text = model.Sort.ToString();
                        this.chkState.Checked = model.isLock == 1;
                    }
                }
                else
                {
                    this.txtSort.Text = (bll.GetMaxID("Sort") + 1).ToString();
                }
            }
        }
        /// <summary>
        /// 绑定导航归属
        /// </summary>
        private void DataBindNav()
        {
            DataTable dt = bll.GetList(0,"");

            this.ddlAreaCountry.Items.Clear();
            this.ddlAreaCountry.Items.Add(new ListItem("根目录", "0"));
            foreach (DataRow dr in dt.Rows)
            {
                int ClassLayer = Convert.ToInt32(dr["ClassLayer"]);
                string Id = dr["Id"].ToString().Trim();
                string Name = dr["Name"].ToString().Trim();

                if (ClassLayer == 1)
                {
                    Name = "├ " + Name;
                    this.ddlAreaCountry.Items.Add(new ListItem(Name, Id));

                }
                else
                {
                    Name = "├ " + Name;
                    Name = TravelAgent.Tool.StringPlus.StringOfChar(ClassLayer - 1, "　") + Name;

                    this.ddlAreaCountry.Items.Add(new ListItem(Name, Id));
                }
            }
        }
    }
}
