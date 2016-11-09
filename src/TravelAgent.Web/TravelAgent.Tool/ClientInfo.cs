using System.Web;
using System.Net;

namespace TravelAgent.Tool
{
    public class ClientInfo
    {
        /// <summary>
        /// 获取客户端ip
        /// </summary>
        /// <returns></returns>
        public static string GetIp()
        {
            string ipAddress = "";
            if (System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] == null)
            {
                //内网IP
                ipAddress = System.Web.HttpContext.Current.Request.ServerVariables["Remote_Addr"];
            }
            else
            {
                //外网IP
                ipAddress = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            }
            return ipAddress;
        }
        /// <summary>
        /// 获取当前访问页面地址
        /// </summary>
        public static string GetScriptName
        {
            get
            {
                return HttpContext.Current.Request.ServerVariables["SCRIPT_NAME"].ToString();
            }
        }
        /// <summary>
        /// 获取当前访问页面地址参数
        /// </summary>
        public static string GetScriptNameQueryString
        {
            get
            {
                return HttpContext.Current.Request.ServerVariables["QUERY_STRING"].ToString();
            }
        }

        /// <summary>
        /// 获取当前访问页面Url
        /// </summary>
        public static string GetScriptUrl
        {
            get
            {
                return GetScriptNameQueryString == "" ? GetScriptName : string.Format("{0}?{1}", GetScriptName,GetScriptNameQueryString);
            }
        }
        /// <summary>
        ///  获取客户端当前用户电脑名称
        /// </summary>
        /// <returns></returns>
        public static string GetHostName()
        {
            return Dns.GetHostName();
        }
        /// <summary>
        /// 获取客户端电脑所属网域
        /// </summary>
        /// <returns></returns>
        public static string GetUserDomainName()
        {
            return System.Environment.UserDomainName;
        }
        /// <summary>
        /// 获取客户端当前用户电浏览器类型
        /// </summary>
        /// <returns></returns>
        public static string GetBrowser()
        {
            return HttpContext.Current.Request.Browser.Browser;
        }
        /// <summary>
        /// 获取客户端浏览器标识
        /// </summary>
        /// <returns></returns>
        public string GetBrowserId()
        {
            return HttpContext.Current.Request.Browser.Id;
        }
        /// <summary>
        /// 获取客户端浏览器浏览器版本号
        /// </summary>
        /// <returns></returns>
        public static string GetBrowserVersion()
        {
            return HttpContext.Current.Request.Browser.Version;
        }
        /// <summary>
        /// 获取客户端浏览器浏览器是不是测试版本
        /// </summary>
        /// <returns></returns>
        public static bool GetBrowserBeta()
        {
            return HttpContext.Current.Request.Browser.Beta;
        }
        /// <summary>
        /// 客户端的操作系
        /// </summary>
        /// <returns></returns>
        public static string GetPlatform()
        {
            return HttpContext.Current.Request.Browser.Platform;
        }
        public static string GetCustomerMac(string IP) //para IP is the client's IP 
        {
            string dirResults = "";
            System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo();
            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            psi.FileName = "nbtstat";
            psi.RedirectStandardInput = false;
            psi.RedirectStandardOutput = true;
            psi.Arguments = "-A " + IP;
            psi.UseShellExecute = false;
            proc = System.Diagnostics.Process.Start(psi);
            dirResults = proc.StandardOutput.ReadToEnd();
            proc.WaitForExit();
            dirResults = dirResults.Replace("\r", "").Replace("\n", "").Replace("\t", "");

            System.Text.RegularExpressions.Regex reg = new System.Text.RegularExpressions.Regex("Mac[ ]{0,}Address[ ]{0,}=[ ]{0,}(?<key>((.)*?)) __MAC", System.Text.RegularExpressions.RegexOptions.IgnoreCase | System.Text.RegularExpressions.RegexOptions.Compiled);
            System.Text.RegularExpressions.Match mc = reg.Match(dirResults + "__MAC");

            if (mc.Success)
            {
                return mc.Groups["key"].Value;
            }
            else
            {
                reg = new System.Text.RegularExpressions.Regex("Host not found", System.Text.RegularExpressions.RegexOptions.IgnoreCase | System.Text.RegularExpressions.RegexOptions.Compiled);
                mc = reg.Match(dirResults);
                if (mc.Success)
                {
                    return "Host not found!";
                }
                else
                {
                    return "";
                }
            }
        }
        //验证终端
        public static bool CheckIsMobile(string userAgent)
        {
            if (userAgent.IndexOf("Noki") > -1 || // Nokia phones and emulators     
                     userAgent.IndexOf("Eric") > -1 || // Ericsson WAP phones and emulators     
                     userAgent.IndexOf("WapI") > -1 || // Ericsson WapIDE 2.0     
                     userAgent.IndexOf("MC21") > -1 || // Ericsson MC218     
                     userAgent.IndexOf("AUR") > -1 || // Ericsson R320     
                     userAgent.IndexOf("R380") > -1 || // Ericsson R380     
                     userAgent.IndexOf("UP.B") > -1 || // UP.Browser     
                     userAgent.IndexOf("WinW") > -1 || // WinWAP browser     
                     userAgent.IndexOf("UPG1") > -1 || // UP.SDK 4.0     
                     userAgent.IndexOf("upsi") > -1 || //another kind of UP.Browser     
                     userAgent.IndexOf("QWAP") > -1 || // unknown QWAPPER browser     
                     userAgent.IndexOf("Jigs") > -1 || // unknown JigSaw browser     
                     userAgent.IndexOf("Java") > -1 || // unknown Java based browser     
                     userAgent.IndexOf("Alca") > -1 || // unknown Alcatel-BE3 browser (UP based)    


                     userAgent.IndexOf("MITS") > -1 || // unknown Mitsubishi browser     
                     userAgent.IndexOf("MOT-") > -1 || // unknown browser (UP based)     
                     userAgent.IndexOf("My S") > -1 ||//  unknown Ericsson devkit browser      
                     userAgent.IndexOf("WAPJ") > -1 ||//Virtual WAPJAG www.wapjag.de     
                     userAgent.IndexOf("fetc") > -1 ||//fetchpage.cgi Perl script from www.wapcab.de 


                     userAgent.IndexOf("ALAV") > -1 || //yet another unknown UP based browser     
                     userAgent.IndexOf("Wapa") > -1 || //another unknown browser (Web based "Wapalyzer")    
                     userAgent.IndexOf("UCWEB") > -1 || //another unknown browser (Web based "Wapalyzer")    
                     userAgent.IndexOf("BlackBerry") > -1 || //another unknown browser (Web based "Wapalyzer")                     
                     userAgent.IndexOf("J2ME") > -1 || //another unknown browser (Web based "Wapalyzer")              
                     userAgent.IndexOf("Oper") > -1 ||
                     userAgent.IndexOf("Android") > -1 ||
                     userAgent.IndexOf("mozilla") > -1 ||
                     userAgent.IndexOf("Mobile") > -1 ||
                     userAgent.IndexOf("iPad") > -1 ||
                     userAgent.IndexOf("iPod") > -1 ||
                     userAgent.IndexOf("iPhone") > -1 ||
                     userAgent.IndexOf("Windows Phone") > -1 ||
                     userAgent.IndexOf("Symbian") > -1
                   )
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
