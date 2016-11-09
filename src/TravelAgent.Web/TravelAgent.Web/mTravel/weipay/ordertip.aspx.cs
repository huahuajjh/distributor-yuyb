using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using System.Web;
using System.Text;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using TravelAgent.WeiPay;
using Newtonsoft.Json;

namespace TravelAgent.Web.mTravel.weipay
{
    public partial class ordertip : TravelAgent.Web.UI.mBasePage
    {
        public string orderno;
        public TravelAgent.Model.Order order;
        private static readonly TravelAgent.BLL.Category CateBll = new TravelAgent.BLL.Category();
        private static readonly TravelAgent.BLL.Order OrderBll = new TravelAgent.BLL.Order();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["o"]))
            {
                orderno = Request.QueryString["o"];
                order = OrderBll.GetModelByCode(orderno);
                if (order != null)
                {
                    this.ltproname.Text = order.proName;
                    this.ltdate.Text = order.TravelDate;
                    this.ltadult.Text = order.adultNumber.ToString();
                    this.ltchild.Text = order.childNumber.ToString();
                    this.ltorderprice.Text = (order.orderPrice + order.attachPrice - order.usePoints + order.subPrice).ToString();

                    if (order.dealType == 0)
                    {
                        this.lnkConfirm.Visible = false;
                    }
                }
                else
                { 
                    Response.Redirect("../MOrderMsg.aspx?msg=系统错误&class=error", false);
                }
            }
            if (!this.IsPostBack)
            {
                string redirect_uri = webinfo.WebDomain + "/mTravel/weipay/ordertip.aspx?o=" + orderno;
                this.GetUserOpenId(redirect_uri);
            }
        }
        /// <summary>
        /// 获取当前用户的微信 OpenId，如果知道用户的OpenId请不要使用该函数
        /// </summary>
        private void GetUserOpenId(string redirect_uri)
        {
            TravelAgent.Model.WebInfo webinfo = new TravelAgent.BLL.WebInfo().loadConfig(Server.MapPath(ConfigurationManager.AppSettings["WebInfoConfig"].ToString()));

            string code = Request.QueryString["code"];
            LogUtil.WriteLog("Code：" + code);
            if (string.IsNullOrEmpty(code))
            {
                string code_url = string.Format("https://open.weixin.qq.com/connect/oauth2/authorize?appid={0}&redirect_uri={1}&response_type=code&scope=snsapi_base&state=lk#wechat_redirect", webinfo.AppID, redirect_uri);
                Response.Redirect(code_url);
            }
            else
            {
                LogUtil.WriteLog(" ============ 开始 获取微信用户相关信息 =====================");

                #region 获取支付用户 OpenID================
                string url = string.Format("https://api.weixin.qq.com/sns/oauth2/access_token?appid={0}&secret={1}&code={2}&grant_type=authorization_code", webinfo.AppID, webinfo.AppSecret, code);
                string returnStr = HttpUtil.Send("", url);
                LogUtil.WriteLog("Send 页面  returnStr 第一个：" + returnStr);

                var obj = JsonConvert.DeserializeObject<OpenModel>(returnStr);

                url = string.Format("https://api.weixin.qq.com/sns/oauth2/refresh_token?appid={0}&grant_type=refresh_token&refresh_token={1}", webinfo.AppID, obj.refresh_token);
                returnStr = HttpUtil.Send("", url);
                obj = JsonConvert.DeserializeObject<OpenModel>(returnStr);

                LogUtil.WriteLog("Send 页面  access_token：" + obj.access_token);
                LogUtil.WriteLog("Send 页面  openid=" + obj.openid);

                url = string.Format("https://api.weixin.qq.com/sns/userinfo?access_token={0}&openid={1}", obj.access_token, obj.openid);
                returnStr = HttpUtil.Send("", url);
                LogUtil.WriteLog("Send 页面  returnStr：" + returnStr);

                //this.UserOpenId = obj.openid;
                if (obj.openid != "")
                {
                    this.hdopenid.Value = obj.openid;
                }

                LogUtil.WriteLog(" ============ 结束 获取微信用户相关信息 =====================");
                #endregion
            }
        }
        /// <summary>
        /// 绑定底部导航
        /// </summary>
        /// <param name="top"></param>
        /// <returns></returns>
        public string BindBottonNav(int top, int parentid)
        {
            StringBuilder sbBottomNav = new StringBuilder();
            DataSet dsNav = CateBll.GetChannelListByParentId(parentid, top);
            for (int i = 0; i < dsNav.Tables[0].Rows.Count; i++)
            {
                sbBottomNav.Append("<a href=\"Article.aspx?id=" + dsNav.Tables[0].Rows[i]["Id"] + "\">" + dsNav.Tables[0].Rows[i]["Title"] + "</a>|");
            }
            return sbBottomNav.ToString().Remove(sbBottomNav.Length - 1);
        }
        /// <summary>
        /// 微信支付
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lnkConfirm_Click(object sender, EventArgs e)
        {
            //设置支付数据
            PayModel model = new PayModel();
            //model.OrderSN = this.ltorderno.Text;
            //model.TotalFee = int.Parse(this.ltorderprice.Text);
            //model.Body = this.ltproname.Text;

            model.OrderSN = orderno;
            model.TotalFee = int.Parse(this.ltorderprice.Text);
            model.Body = this.ltproname.Text+"-"+this.ltdate.Text;

            model.Attach = ""; //不能有中文
            model.OpenId = this.hdopenid.Value;

            //跳转到 WeiPay.aspx 页面，请设置函数中WeiPay.aspx的页面地址
            this.Response.Redirect(model.ToString());
        }
    }
}
