using System;
using System.Collections.Generic;
using System.Text;

namespace TravelAgent.Model
{
    public class WebInfo
    {
        private string _webname = "";
        private string _webdomain = "";
        private string _weblogo = "";
        private string _webicp = "";
        private int _weblock= 1;
        private string _webcompanyname = "";
        private string _weblicence = "";
        private string _webemail = "";
        private string _webtel = "";
        private string _webqq = "";
        private string _webaddress = "";
        private int _qqservicestate = 0;
        private string _qqservices = "";
        private string _seotitle = "";
        private string _seokeywords = "";
        private string _seodescription = "";
        private string _webfilepath = "";
        private string _webfiletype = "";
        private int _webfilesize = 0;
        private int _isthumbnail = 0;
        private int _prowidth = 0;
        private int _prohight = 0;
        private int _iswatermark = 0;
        private int _watermarkstatus = 0;
        private int _imgquality = 80;
        private string _imgwaterpath = "";
        private int _imgwatertransparency = 0;
        private string _watertext = "";
        private string _waterfont = "";
        private int _fontsize = 12;
        private int _myd = 0;
        private string _searchKey = "";
        private string _worktime = "";
        private int _FristReg = 0;
        private int _MobileValidate = 0;
        private int _EmailValidate = 0;

        private string _alipayaccount = "";//支付宝账号
        private string _alipaypid = "";//支付宝合作者ID
        private string _alipaykey = "";//支付宝安全校验码
        private string _alipaysiyue = "";//商户私钥
        private string _alipaygongyue = "";//支付宝公钥
        private int _alipayislock = 1;//支付宝是否开启

        private string _chinabankaccount = "";//网银在线商户号
        private string _chinabankkey = "";//网银在线密钥
        private int _chinabankislock = 1;//网银在线是否开启

        private string _emailusername = "";//用户名
        private string _emailpassword = "";//密码
        private string _emailaccount = "";//邮箱
        private string _emailsmtp = "";//smtp服务器
        private string _emailport = "";//端口
        private int _emailislock = 1;//是否开启

        private string _smshostname = "";//主机名
        private string _smsusername = "";//用户名
        private string _smspassword = "";//密码
        private int _smsislock = 1;//是否开启
        private int _holiday = 0;//默认为没有设置节日推广

        private string _wxname = "";//微信公共号
        private string _wxM = "";//微信二维码
        private string _xlwbname = "";//新浪微博名称
        private string _xlwbM = "";//新浪微博二维码
        private string _xlwburl = "";//新浪微博地址
        private string _txwburl = "";//腾讯微博地址

        private string _appId = "";//公众号ID
        private string _appSecret = "";//公众号密钥
        private string _mchid = "";//商户号
        private string _key = "";//32位API密钥
        private int _wxpayIsLock = 1;//默认开启
        /// <summary>
        ///  网站名称
        /// </summary>
        public string WebName
        {
            set { _webname = value; }
            get { return _webname; }
        }

        /// <summary>
        ///  网站域名
        /// </summary>
        public string WebDomain
        {
            set { _webdomain = value; }
            get { return _webdomain; }
        }

        /// <summary>
        ///  网站Logo
        /// </summary>
        public string WebLogo
        {
            set { _weblogo = value; }
            get { return _weblogo; }
        }

        /// <summary>
        ///  网站ICP备案
        /// </summary>
        public string WebICP
        {
            set { _webicp = value; }
            get { return _webicp; }
        }

        /// <summary>
        ///  网站是否开启
        /// </summary>
        public int WebLock
        {
            set { _weblock = value; }
            get { return _weblock; }
        }

        /// <summary>
        ///  企业名称
        /// </summary>
        public string WebCompanyName
        {
            set { _webcompanyname = value; }
            get { return _webcompanyname; }
        }
        /// <summary>
        ///  网站许可证
        /// </summary>
        public string WebLicence
        {
            set { _weblicence = value; }
            get { return _weblicence; }
        }
        /// <summary>
        ///  联系邮箱
        /// </summary>
        public string WebEmail
        {
            set { _webemail = value; }
            get { return _webemail; }
        }

        /// <summary>
        ///  联系电弧
        /// </summary>
        public string WebTel
        {
            set { _webtel = value; }
            get { return _webtel; }
        }

        /// <summary>
        ///  联系QQ
        /// </summary>
        public string WebQQ
        {
            set { _webqq = value; }
            get { return _webqq; }
        }
        /// <summary>
        ///  联系地址
        /// </summary>
        public string WebAddress
        {
            set { _webaddress = value; }
            get { return _webaddress; }
        }/// <summary>
        ///  QQ客服启用状态
        /// </summary>
        public int QQServiceState
        {
            set { _qqservicestate = value; }
            get { return _qqservicestate; }
        }
        /// <summary>
        ///  QQ客服列表
        /// </summary>
        public string QQServices
        {
            set { _qqservices = value; }
            get { return _qqservices; }
        }
        /// <summary>
        /// SEO关健字
        /// </summary>
        public string SEOTitle
        {
            set { _seotitle = value; }
            get { return _seotitle; }
        }
        /// <summary>
        /// SEO关健字
        /// </summary>
        public string SEOKeywords
        {
            set { _seokeywords = value; }
            get { return _seokeywords; }
        }

        /// <summary>
        ///  网站描述
        /// </summary>
        public string SEODescription
        {
            set { _seodescription = value; }
            get { return _seodescription; }
        }

        /// <summary>
        /// 文件上传目录
        /// </summary>
        public string WebFilePath
        {
            set { _webfilepath = value; }
            get { return _webfilepath; }
        }

        /// <summary>
        /// 允许文件上传类型
        /// </summary>
        public string WebFileType
        {
            set { _webfiletype = value; }
            get { return _webfiletype; }
        }

        /// <summary>
        /// 允许文件上传大小
        /// </summary>
        public int WebFileSize
        {
            set { _webfilesize = value; }
            get { return _webfilesize; }
        }

        /// <summary>
        /// 是否生成产品缩略图
        /// </summary>
        public int IsThumbnail
        {
            set { _isthumbnail = value; }
            get { return _isthumbnail; }
        }

        /// <summary>
        /// 产品缩略图宽
        /// </summary>
        public int ProWidth
        {
            set { _prowidth = value; }
            get { return _prowidth; }
        }

        /// <summary>
        /// 产品缩略图高
        /// </summary>
        public int ProHight
        {
            set { _prohight = value; }
            get { return _prohight; }
        }

        /// <summary>
        /// 是否开启图片水印
        /// </summary>
        public int IsWatermark
        {
            set { _iswatermark = value; }
            get { return _iswatermark; }
        }

        /// <summary>
        /// 图片水印位置
        /// </summary>
        public int WatermarkStatus
        {
            set { _watermarkstatus = value; }
            get { return _watermarkstatus; }
        }

        /// <summary>
        /// 图片生成质量
        /// </summary>
        public int ImgQuality
        {
            set { _imgquality = value; }
            get { return _imgquality; }
        }

        /// <summary>
        /// 图片型水印文件
        /// </summary>
        public string ImgWaterPath
        {
            set { _imgwaterpath = value; }
            get { return _imgwaterpath; }
        }

        /// <summary>
        /// 图片水印透明度
        /// </summary>
        public int ImgWaterTransparency
        {
            set { _imgwatertransparency = value; }
            get { return _imgwatertransparency; }
        }

        /// <summary>
        /// 文字水印内容
        /// </summary>
        public string WaterText
        {
            set { _watertext = value; }
            get { return _watertext; }
        }

        /// <summary>
        /// 文字水印字体
        /// </summary>
        public string WaterFont
        {
            set { _waterfont = value; }
            get { return _waterfont; }
        }

        /// <summary>
        /// 文字水印字体大小
        /// </summary>
        public int FontSize
        {
            set { _fontsize = value; }
            get { return _fontsize; }
        }
        /// <summary>
        /// 固定满意度
        /// </summary>
        public int MYD
        {
            set { _myd = value; }
            get { return _myd; }
        }
        /// <summary>
        /// 搜索关键字
        /// </summary>
        public string SearchKey
        {
            set { _searchKey = value; }
            get { return _searchKey; }
        }
        /// <summary>
        /// 工作时间
        /// </summary>
        public string WorkTime
        {
            set { _worktime = value; }
            get { return _worktime; }
        }

        /// <summary>
        /// 注册积分
        /// </summary>
        public int FristReg
        {
            set { _FristReg = value; }
            get { return _FristReg; }
        }
        /// <summary>
        /// 手机验证积分
        /// </summary>
        public int MobileValidate
        {
            set { _MobileValidate = value; }
            get { return _MobileValidate; }
        }
        /// <summary>
        /// 邮箱验证积分
        /// </summary>
        public int EmailValidate
        {
            set { _EmailValidate = value; }
            get { return _EmailValidate; }
        }

        /// <summary>
        /// 支付宝账号
        /// </summary>
        public string AlipayAccount
        {
            set { _alipayaccount = value; }
            get { return _alipayaccount; }
        }
        /// <summary>
        /// 支付宝合作者ID
        /// </summary>
        public string AlipayPid
        {
            set { _alipaypid = value; }
            get { return _alipaypid; }
        }
        /// <summary>
        /// 支付宝安全校验码
        /// </summary>
        public string AlipayKey
        {
            set { _alipaykey = value; }
            get { return _alipaykey; }
        }
        /// <summary>
        /// 商户私钥
        /// </summary>
        public string AlipaySiyue
        {
            set { _alipaysiyue = value; }
            get { return _alipaysiyue; }
        }
        /// <summary>
        /// 支付宝公钥
        /// </summary>
        public string AlipayGongyue
        {
            set { _alipaygongyue = value; }
            get { return _alipaygongyue; }
        }
        /// <summary>
        /// 支付宝是否开启
        /// </summary>
        public int AlipayIslock
        {
            set { _alipayislock = value; }
            get { return _alipayislock; }
        }

        /// <summary>
        /// 网银在线商户号
        /// </summary>
        public string ChinabankAccount
        {
            set { _chinabankaccount = value; }
            get { return _chinabankaccount; }
        }
        /// <summary>
        /// 网银在线密钥
        /// </summary>
        public string ChinabankKey
        {
            set { _chinabankkey = value; }
            get { return _chinabankkey; }
        }
        /// <summary>
        /// 网银在线是否开启
        /// </summary>
        public int ChinabankIslock
        {
            set { _chinabankislock = value; }
            get { return _chinabankislock; }
        }

        /// <summary>
        ///  用户名
        /// </summary>
        public string EmailUsername
        {
            set { _emailusername = value; }
            get { return _emailusername; }
        }
        /// <summary>
        ///  密码
        /// </summary>
        public string EmailPassword
        {
            set { _emailpassword = value; }
            get { return _emailpassword; }
        }
        /// <summary>
        ///  邮箱
        /// </summary>
        public string EmailAccount
        {
            set { _emailaccount = value; }
            get { return _emailaccount; }
        }
        /// <summary>
        ///  SMTP服务器
        /// </summary>
        public string EmailSmtp
        {
            set { _emailsmtp = value; }
            get { return _emailsmtp; }
        }
        /// <summary>
        ///  端口
        /// </summary>
        public string EmailPort
        {
            set { _emailport = value; }
            get { return _emailport; }
        }
        /// <summary>
        /// 邮箱是否开启
        /// </summary>
        public int EmailIslock
        {
            set { _emailislock = value; }
            get { return _emailislock; }
        }

        /// <summary>
        /// 短信主机名
        /// </summary>
        public string SmsHostname
        {
            set { _smshostname = value; }
            get { return _smshostname; }
        }
        /// <summary>
        /// 用户名
        /// </summary>
        public string SmsUsername
        {
            set { _smsusername = value; }
            get { return _smsusername; }
        }
        /// <summary>
        /// 密码
        /// </summary>
        public string SmsPassword
        {
            set { _smspassword = value; }
            get { return _smspassword; }
        }
        /// <summary>
        /// 短信是否开启
        /// </summary>
        public int SmsIslock
        {
            set { _smsislock = value; }
            get { return _smsislock; }
        }
        /// <summary>
        /// 节日推广
        /// </summary>
        public int Holiday
        {
            set { _holiday = value; }
            get { return _holiday; }
        }

        /// <summary>
        /// 微信公共号
        /// </summary>
        public string WXName
        {
            set { _wxname = value; }
            get { return _wxname; }
        }
        /// <summary>
        /// 微信二维码
        /// </summary>
        public string WXM
        {
            set { _wxM = value; }
            get { return _wxM; }
        }
        /// <summary>
        /// 新浪微博名称
        /// </summary>
        public string XLWBName
        {
            set { _xlwbname = value; }
            get { return _xlwbname; }
        }
        /// <summary>
        /// 新浪微博二维码
        /// </summary>
        public string XLWBM
        {
            set { _xlwbM = value; }
            get { return _xlwbM; }
        }
        /// <summary>
        /// 新浪微博地址
        /// </summary>
        public string XLWBUrl
        {
            set { _xlwburl = value; }
            get { return _xlwburl; }
        }
        /// <summary>
        /// 腾讯微博地址
        /// </summary>
        public string TXWBUrl
        {
            set { _txwburl = value; }
            get { return _txwburl; }
        }
        /// <summary>
        /// 公众号ID
        /// </summary>
        public string AppID
        {
            set { _appId = value; }
            get { return _appId; }
        }
        /// <summary>
        /// 公众号密钥
        /// </summary>
        public string AppSecret
        {
            set { _appSecret = value; }
            get { return _appSecret; }
        }
        /// <summary>
        /// 商户号
        /// </summary>
        public string Mchid
        {
            set { _mchid = value; }
            get { return _mchid; }
        }
        /// <summary>
        /// 商户32位API密钥
        /// </summary>
        public string Key
        {
            set { _key = value; }
            get { return _key; }
        }
        /// <summary>
        /// 是否开启微信支付
        /// </summary>
        public int WxpayIsLock
        {
            set { _wxpayIsLock = value; }
            get { return _wxpayIsLock; }
        }
    }
}
