using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TravelAgent.WeiPay;
using Newtonsoft.Json;

namespace TravelAgent.Web.mTravel.weipay
{
    /**
  * 
  * 作用：模拟填写支付信息页面
  * 作者：付闯
  * 编写日期：2015-12-08
  * 备注：请正确输入支付的信息，部分参数不能为空。具体请查看 WeiPay类库中PayModel类。
  * 
  * */
    public partial class Send : System.Web.UI.Page
    {
        private string UserOpenId = ""; //微信用户openid；
        public TravelAgent.Model.WebInfo webinfo;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                webinfo = new TravelAgent.BLL.WebInfo().loadConfig(Server.MapPath(ConfigurationManager.AppSettings["WebInfoConfig"].ToString()));
                if (webinfo == null)
                {
                    Response.Write("配置信息获取错误！");
                    Response.End();
                }
                //获取当前用户的OpenId，如果可以通过系统获取用户Openid就不用调用该函数
                this.GetUserOpenId();
                LogUtil.WriteLog("数据0" + Request["o"]);
                LogUtil.WriteLog("数据total_fee" + Request["total_fee"]);
                LogUtil.WriteLog("数据subject" + Request["subject"]);
                //设置支付数据
                PayModel model = new PayModel();
                model.OrderSN = Request.QueryString["o"];
                model.TotalFee = int.Parse(Request.QueryString["total_fee"]);
                model.Body = Request.QueryString["subject"];
                model.Attach = ""; //不能有中午
                model.OpenId = this.UserOpenId;

                //跳转到 WeiPay.aspx 页面，请设置函数中WeiPay.aspx的页面地址
                this.Response.Redirect(model.ToString());
            }
        }
        /// <summary>
        /// 获取当前用户的微信 OpenId，如果知道用户的OpenId请不要使用该函数
        /// </summary>
        private void GetUserOpenId()
        {

            string code = Request.QueryString["code"];
            if (string.IsNullOrEmpty(code))
            {
                string code_url = string.Format("https://open.weixin.qq.com/connect/oauth2/authorize?appid={0}&redirect_uri={1}&response_type=code&scope=snsapi_base&state=lk#wechat_redirect", webinfo.AppID, webinfo.WebDomain + "/mTravel/weipay/Send.aspx");
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

                this.UserOpenId = obj.openid;

                LogUtil.WriteLog(" ============ 结束 获取微信用户相关信息 =====================");
                #endregion
            }
        }
    }
}
