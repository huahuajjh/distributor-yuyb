using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.InteropServices;
namespace TravelAgent.Web
{
    public class CSMS
    {
        public CSMS() { }
        public static string GetError(int iError)
        {
            switch (iError)
            {
                case 0: return "正常";
                case -1: return "账户被停用";
                case -2: return "用户名不存在，或者密码错误";
                case -3: return "数据库错误";
                case -4: return "余额不足";
                case -5: return "账户被锁";
                case -10: return "内容超长";
                case -9: return "手机号码错误";
                case -11: return "连接失败";
                case -999: return "未知错误";
                default: return "未知错误";
            }
        }
        /// <summary>
        /// 提交用户信息，获取用户返回句柄。登录函数是必须要调用的；
        /// </summary>
        /// <param name="strHost">主机名或IP地址</param>
        /// <param name="iPort">服务器端口号</param>
        /// <param name="strUserId">用户名</param>
        /// <param name="strPasswrod">用户密码</param>
        /// <param name="pHandle">返回句柄（一个void类型指针(整型指针)，操作其他函数时要用到）</param>
        /// <returns>成功返回：0，失败返回：小于0的错误码</returns>
        [DllImport("SMS.dll", EntryPoint = "_Login")]
        public static extern int Login(string strHost, int iPort, string strUserId, string strPasswrod, ref int pHandle);

        /// <summary>
        /// 注销登录
        /// </summary>
        /// <param name="pHandle">登录返回句柄（由登录函数获得）</param>
        /// <returns>成功返回：0，失败返回：0的错误码</returns>
        [DllImport("SMS.dll", EntryPoint = "_Logout")]
        public static extern int Logout(int pHandle);

        /// <summary>
        /// 通过代理服务器提交用户信息，获取用户返回句柄。登录函数是必须要调用的。
        /// </summary>
        /// <param name="strHost">主机名或IP地址</param>
        /// <param name="nPort">服务器端口号</param>
        /// <param name="ProxyIP">代理服务器IP地址</param>
        /// <param name="ProxyPort">代理服务器端口</param>
        /// <param name="ProxyUserName">代理服务器登录用户名（如果设置了的话）</param>
        /// <param name="ProxyPassWord">代理服务器登录密码（如果设置了的话）</param>
        /// <param name="strUserId">用户名</param>
        /// <param name="strPassword">用户密码</param>
        /// <param name="pHandle">返回句柄（一个void类型指针(整型指针)，操作其他函数时要用到）</param>
        /// <returns></returns>
        [DllImport("SMS.dll", EntryPoint = "_ProxyLogin")]
        public static extern int ProxyLogin(string strHost, int nPort, string ProxyIP, int ProxyPort,
                                            string ProxyUserName, string ProxyPassWord, string strUserId,
                                            string strPassword, ref int pHandle);

        /// <summary>
        /// 提交短信内容
        /// </summary>
        /// <param name="pHandle">登录返回句柄（由登录函数获得）</param>
        /// <param name="strContent">信息内容，长度限制：中文或中英混合字符，
        ///         按字计算最多70个字、纯英文或数字等单字节最多140个字节；
        ///         如果是电信小灵通号码，相应的长度分别是58和116。</param>
        /// <param name="strSendTime">定时发送时间（格式：yyyy-mm-dd hh:nn:ss）， 为空表示立即发送</param>
        /// <param name="nSendCount">本条短信将提交的号码总数（校验参数，用于服务端校验）</param>
        /// <returns>成功返回一个大于0的整数，表示该内容在服务器上的编号，失败返回小于0的错误码</returns>
        [DllImport("SMS.dll", EntryPoint = "_SendText")]
        public static extern int SendText(int pHandle, string strContent, string strSendTime, int nSendCount);

        /// <summary>
        /// 提交号码
        /// </summary>
        /// <param name="pHandle">登录返回句柄（由登录函数获得）</param>
        /// <param name="nBatchNo">短信批次编号（_SendText函数的返回值，传入时请判断是否>0，否则会调用出错）</param>
        /// <param name="strToPhone">目的手机号码，如果有多个号码，用逗号进行分隔，
        ///         如：13900000000,13911111111,13922222222 但一批最多只能发100个号码，
        ///         如超过100个则应用循环调用该函数提交。</param>
        /// <returns>成功返回0，失败返回小于0的错误码</returns>
        [DllImport("SMS.dll", EntryPoint = "_SendPhones")]
        public static extern int SendPhones(int pHandle, int nBatchNo, string strToPhone);

        /// <summary>
        /// 查询帐户余额
        /// </summary>
        /// <param name="pHandle">登录返回句柄（由登录函数获得）</param>
        /// <param name="fBalance">float型变量的指针，返回短信剩余条数</param>
        /// <returns></returns>
        [DllImport("SMS.dll", EntryPoint = "_Balance")]
        public static extern int Balance(int pHandle, ref float fBalance);

        /// <summary>
        /// 修改用户密码
        /// </summary>
        /// <param name="pHandle">登录返回句柄（由登录函数获得）</param>
        /// <param name="strNewPassword">新的密码</param>
        /// <returns>成功返回0，失败返回小于0的错误码</returns>
        [DllImport("SMS.dll", EntryPoint = "_UpdatePsw")]
        public static extern int UpdatePsw(int pHandle, string strNewPassword);
    }
}
