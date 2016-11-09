using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace TravelAgent.Web.admin.club
{
    public partial class EditClub : System.Web.UI.Page
    {
        public int clubid;
        private static readonly TravelAgent.BLL.Club ClubBll = new TravelAgent.BLL.Club();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                DataBindClass();
                if (Request.QueryString["id"] != null)
                {
                    clubid = Convert.ToInt32(Request.QueryString["id"]);
                    TravelAgent.Model.Club model = ClubBll.GetModel(clubid);
                    if (model != null)
                    {
                        this.txtClubName.Text = model.clubName;
                        this.txtMobile.Text = model.clubMobile;
                        this.txtEmail.Text = model.clubEmail;
                        //this.txtPassword.Text = model.clubPwd;
                        this.txtPassword.Attributes.Add("value", model.clubPwd);
                        this.ddlClass.SelectedValue = model.classId.ToString();
                        this.txtPoints.Text = model.currentPoints.ToString();
                        this.txtName.Text = model.trueName;
                        this.ddlSex.SelectedValue = model.clubSex;
                        this.txtBirthday.Text = model.clubBirthday;
                        this.ddlLock.SelectedValue = model.isLock.ToString();
                    }
                }
            }
           
        }
        /// <summary>
        /// 绑定会员级别
        /// </summary>
        private void DataBindClass()
        {
            Hashtable ht = TravelAgent.Tool.EnumHelper.GetMemberKeyValue<TravelAgent.Tool.EnumSummary.ClubClass>();//数据源
            this.ddlClass.DataSource = ht;
            this.ddlClass.DataTextField = "Key";
            this.ddlClass.DataValueField = "Value";
            this.ddlClass.DataBind();
            this.ddlClass.Items.Insert(0, new ListItem("选择会员级别", ""));
        }
    }
}
