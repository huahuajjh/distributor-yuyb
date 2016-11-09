<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="404.aspx.cs" Inherits="TravelAgent.Web._04" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
        <head id="Head1" runat="server">
                <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
                <title>您访问的页面不存在-404错误</title>
                <link href="/css/style.css" rel="stylesheet" type="text/css" />
                <link href="/css/error.css" rel="stylesheet" type="text/css" />
        </head>
        <body>
                <div class="box">
                	<div class="error_ico"></div>
                    <div class="text_content">
                    	<p>404错误-您访问的页面不存在！</p>
                        <span><em>※ 您还可以进行如下操作：</em></span>
                        <span><a href="/">返回首页</a><a href="javascript:history.back(-1);">返回上一页</a></span>
                        <!--<span class="text_right"><b id="wait">3</b>秒钟后自动跳转，如不想等待请<a id="href" href="javascript:history.back(-1);">点击这里</a></span>-->
                    </div>
                </div>
                
        </body>
</html>
