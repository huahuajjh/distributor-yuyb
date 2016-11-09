<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Opr.aspx.cs" Inherits="TravelAgent.Web.Opr" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
        <head runat="server">
                <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
                <title></title>
                <link href="/css/style.css" rel="stylesheet" type="text/css" />
                <link href="/css/error.css" rel="stylesheet" type="text/css" />
        </head>
        <body>
                <div class="box">
                	<div class="<%=strcss %>"><asp:Literal ID="ltTag" runat="server"></asp:Literal></div>
                    <div class="text_content">
                    	<p><asp:Literal ID="ltMsg" runat="server"></asp:Literal></p>
                        <span><em>※ 您还可以进行如下操作：</em></span>
                        <span><a href="/">返回首页</a><a href="javascript:history.back(-1);">返回上一页</a><a href="/member/Index.aspx">去我的个人中心</a></span>
                        <span class="text_right"><b id="wait">3</b>秒钟后自动跳转，如不想等待请<a id="href" href="javascript:history.back(-1);">点击这里</a></span>
                    </div>
                </div>
                <script type="text/javascript">
                        (function() {
                            var wait = document.getElementById('wait'), href = document.getElementById('href').href;
                            var interval = setInterval(function() {
                                var time = --wait.innerHTML;
                                if (time <= 0) {
                                    //                                    if (href.indexOf('?') > -1) {
                                    //                                        location.href = href + "&date=" + new Date().toUTCString();
                                    //                                    }
                                    //                                    else {
                                    //                                        location.href = href + "?date=" + new Date().toUTCString();
                                    //                                    }
                                    location.href = href;
                                    clearInterval(interval);
                                }
                                ;
                            }, 1000);
                        })();
                </script>
        </body>
</html>
