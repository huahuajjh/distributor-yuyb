
namespace TravelAgent.Tool
{
    public class Javascript
    {
        public Javascript()
        {
        }
        #region 枚举
        /// <summary>
        /// 注入客户端脚本方式
        /// </summary>
        public enum JavascriptType
        {
            /// <summary>
            ///  功能：在客户端注册一块脚本语言,在Page对象的"form runat= server"元素的开始标记前发出该脚本
            /// </summary>
            FormStatrJavascript,
            /// <summary>
            /// 功能：在客户端注册一块脚本语言,在Page对象的"form runat= server"元素的开始标记后立即发出该脚本
            /// </summary>
            FormEndJavascript,
            /// <summary>
            /// 功能：在客户端注册一块脚本语言,在文件流的最前端注入
            /// </summary>
            WriteJavascript

        }
        #endregion


        #region 私有方法
        /// <summary>
        /// 功能：在客户端注册一块脚本语言,在Page对象的"form runat= server"元素的结束标记之前发出该脚本
        /// </summary>
        /// <param name="script">script 欲注册的JavaScript脚本，需要包括"script language=javascript"等标签</param>
        private static void RegisterStartupScript(string script)
        {
            string strKey;
            int i;      //注册脚本块的Key        
            strKey = System.DateTime.Now.ToString();
            System.Web.UI.Page page = (System.Web.UI.Page)System.Web.HttpContext.Current.Handler;
            //循环，直至找到某个没被注册过的Key
            for (i = 0; i < 100; i++)
            {
                if (!page.ClientScript.IsStartupScriptRegistered(page.GetType(), strKey + i.ToString()))
                {
                    break;
                }
            }
            page.ClientScript.RegisterStartupScript(page.GetType(), strKey + i.ToString(), script, true);
        }

        /// <summary>
        /// 功能：在客户端注册一块脚本语言,在Page对象的"form runat= server"元素的开始标记后立即发出该脚本
        /// </summary>
        /// <param name="script">script 欲注册的JavaScript脚本，需要包括"script language=javascript"等标签</param>
        private static void RegisterClientScriptBlock(string script)
        {
            string strKey;
            int i;        //注册脚本块的Key
            strKey = System.DateTime.Now.ToString();
            System.Web.UI.Page page = (System.Web.UI.Page)System.Web.HttpContext.Current.Handler;
            //循环，直至找到某个没被注册过的Key
            for (i = 0; i < 100; i++)
            {
                if (!page.ClientScript.IsClientScriptBlockRegistered(strKey + i.ToString()))
                {
                    break;
                }
            }

            page.ClientScript.RegisterClientScriptBlock(page.GetType(), strKey + i.ToString(), script, true);
        }

        //注册脚本
        private static void SwichType(string script, JavascriptType scriptType)
        {
            JavascriptType jt = scriptType;
            switch (jt)
            {
                case JavascriptType.FormEndJavascript:
                    RegisterStartupScript(script);
                    break;
                case JavascriptType.FormStatrJavascript:
                    RegisterClientScriptBlock(script);
                    break;
                case JavascriptType.WriteJavascript:
                    System.Web.HttpContext.Current.Response.Write("<script type=\"text/javascript\">" + script + "</script>");
                    break;
            }
        }


        #endregion

        #region 共有方法
        /// <summary>
        /// 向客户端注入脚本
        /// </summary>
        /// <param name="logic">语法逻辑</param>
        /// <param name="scriptType">注入脚本的方式（枚举）</param>
        public static void JsUser_defined(string logic, JavascriptType scriptType)
        {
            SwichType(logic, scriptType);
        }


        /// <summary>
        /// 客户端提示框
        /// </summary>
        /// <param name="Msg">提示语</param>
        /// <param name="JavascriptType">注入脚本的方式（枚举）</param>    
        public static void JsAlert(string Msg, JavascriptType scriptType)
        {
            string output = "alert('" + Msg + "');";
            SwichType(output, scriptType);
        }
        /// <summary>
        /// 客户端提示框
        /// </summary>
        /// <param name="Msg">提示语</param>   
        public static void JsAlert(string Msg)
        {
            string output = "alert('" + Msg + "');";
            SwichType(output, JavascriptType.FormEndJavascript);
        }

        /// <summary>
        /// 客户端提示框加跳转
        /// </summary>
        /// <param name="Msg">提示语</param>
        /// <param name="URL">要跳转的页面</param>
        /// <param name="JavascriptType">注入脚本的方式（枚举）</param>   
        public static void JsAlertURL(string Msg, string URL, JavascriptType scriptType)
        {
            string output = "alert('" + Msg + "');" + "document.location.href" + " = '" + URL + "';";
            SwichType(output, scriptType);
        }
        /// <summary>
        /// 客户端提示框加跳转
        /// </summary>
        /// <param name="Msg">提示语</param>
        /// <param name="URL">要跳转的页面</param>  
        public static void JsAlertURL(string Msg, string URL)
        {
            string output = "alert('" + Msg + "');" + "document.location.href" + " = '" + URL + "';";
            SwichType(output, JavascriptType.FormEndJavascript);
        }

        /// <summary>
        /// 客户端提示框加再返回历史页面
        /// </summary>
        /// <param name="Msg">提示语</param>
        /// <param name="Number">返回的历史点</param>
        /// <param name="scriptType">注入脚本的方式（枚举）</param>
        public static void JsAlertHistory(string Msg, string Number, JavascriptType scriptType)
        {
            string output = "alert('" + Msg + "');" + "history.go(" + Number + ");";
            SwichType(output, scriptType);
        }
        /// <summary>
        /// 客户端提示框加再返回历史页面
        /// </summary>
        /// <param name="Msg">提示语</param>
        /// <param name="Number">返回的历史点</param>
        public static void JsAlertHistory(string Msg, string Number)
        {
            string output = "alert('" + Msg + "');" + "history.go(" + Number + ");";
            SwichType(output, JavascriptType.FormEndJavascript);
        }

        /// <summary>
        /// 客户端页面跳转
        /// </summary>
        /// <param name="URL">要跳转的地址</param>
        /// <param name="IsTop">是否整页跳转（针对框架页）</param>
        /// <param name="scriptType">注入脚本的方式（枚举）</param>
        public static void JsGoToURL(string URL, bool IsTop, JavascriptType scriptType)
        {
            string output = ((IsTop) ? "window.top.location" : "document.location") + " = '" + URL + "';";
            SwichType(output, scriptType);
        }
        /// <summary>
        /// 客户端页面跳转
        /// </summary>
        /// <param name="URL">要跳转的地址</param>
        /// <param name="IsTop">是否整页跳转（针对框架页）</param>
        public static void JsGoToURL(string URL, bool IsTop)
        {
            string output = ((IsTop) ? "window.top.location" : "document.location") + " = '" + URL + "';";
            SwichType(output, JavascriptType.FormEndJavascript);
        }

        /// <summary>
        /// 客户端对话框跳转地址
        /// </summary>
        /// <param name="Msg">提示语</param>
        /// <param name="YesURL">yes要跳转的地址</param>
        /// <param name="NoURL">no要跳转的地址</param>
        /// <param name="IsTop">是否整页跳转（针对框架页）</param>
        /// <param name="scriptType">注入脚本的方式（枚举）</param>
        public static void JsConfirmUrl(string Msg, string YesURL, string NoURL, bool IsTop, JavascriptType scriptType)
        {
            string urlType = ((IsTop) ? "window.top.location" : "document.location") + " = '";
            string url_yes = urlType + YesURL + "';";
            string url_no = urlType + NoURL + "';";
            string output = "if(window.confirm(\"" + Msg + "\")){ " + url_yes + "; } else { " + url_no + "; }";
            SwichType(output, scriptType);
        }
        /// <summary>
        /// 客户端对话框跳转地址
        /// </summary>
        /// <param name="Msg">提示语</param>
        /// <param name="YesURL">yes要跳转的地址</param>
        /// <param name="NoURL">no要跳转的地址</param>
        /// <param name="IsTop">是否整页跳转（针对框架页）</param>
        public static void JsConfirmUrl(string Msg, string YesURL, string NoURL, bool IsTop)
        {
            string urlType = ((IsTop) ? "window.top.location" : "document.location") + " = '";
            string url_yes = urlType + YesURL + "';";
            string url_no = urlType + NoURL + "';";
            string output = "if(window.confirm(\"" + Msg + "\")){ " + url_yes + "; } else { " + url_no + "; }";
            SwichType(output, JavascriptType.FormEndJavascript);
        }

        /// <summary>
        /// 客户端对话框
        /// </summary>
        /// <param name="Msg">提示语</param>
        /// <param name="YesAction">选择是要执行的JS事件</param>
        /// <param name="NoAction">选择否要执行的JS事件</param>
        /// <param name="scriptType">注入脚本的方式（枚举）</param>
        public static void JsConfirm(string Msg, string YesAction, string NoAction, JavascriptType scriptType)
        {
            string output = "if(window.confirm(\"" + Msg + "\")){ " + YesAction + "; } else { " + NoAction + "; }";
            SwichType(output, scriptType);
        }
        /// <summary>
        /// 客户端对话框
        /// </summary>
        /// <param name="Msg">提示语</param>
        /// <param name="YesAction">选择是要执行的JS事件</param>
        /// <param name="NoAction">选择否要执行的JS事件</param>
        public static void JsConfirm(string Msg, string YesAction, string NoAction)
        {
            string output = "if(window.confirm(\"" + Msg + "\")){ " + YesAction + "; } else { " + NoAction + "; }";
            SwichType(output, JavascriptType.FormEndJavascript);
        }

        /// <summary>
        /// 关闭浏览器
        /// </summary>
        /// <param name="scriptType">注入脚本的方式（枚举）</param>
        public static void JsClose(JavascriptType scriptType)
        {
            string output = "window.close();";
            SwichType(output, scriptType);
        }
        /// <summary>
        /// 关闭浏览器
        /// </summary>
        public static void JsClose()
        {
            string output = "window.close();";
            SwichType(output, JavascriptType.FormEndJavascript);
        }

        /// <summary>
        /// 给个对话框再无提示关闭浏览器
        /// </summary>
        /// <param name="Msg">提示语</param>
        /// <param name="scriptType">注入脚本的方式（枚举）</param>
        public static void JsAlertClose(string Msg)
        {
            string output = "alert('" + Msg + "');window.opener=null;window.open('','_self');window.close();";
            SwichType(output, JavascriptType.WriteJavascript);
        }
        /// <summary>
        /// 向页面注入脚本
        /// </summary>
        /// <param name="script"></param>
        /// <param name="scriptType"></param>
        public static void WriteScript(string script, JavascriptType scriptType)
        {
            SwichType(script, JavascriptType.WriteJavascript);
        }
        #endregion

    }
}
