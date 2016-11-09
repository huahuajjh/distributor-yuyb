<%@ WebHandler  Language="C#"  Class="getContent" %>

using System;
using System.Web;

public class getContent : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/html";

        //获取数据
        string content = context.Server.HtmlEncode(context.Request.Form["myEditor"]);

        
        //存入数据库或者其他操作
        //-------------

        //显示
        context.Response.Write("<script src='../ueditor.parse.js' type='text/javascript'></script>");
        context.Response.Write(
            "<script>uParse('.content',{"+
                  "'highlightJsUrl':'../third-party/SyntaxHighlighter/shCore.js',"+
                  "'highlightCssUrl':'../third-party/SyntaxHighlighter/shCoreDefault.css'"+
              "})"+
            "</script>");

        context.Response.Write("第1个编辑器的值");
        context.Response.Write("<div class='content'>" + context.Server.HtmlDecode(content) + "</div>");

    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}