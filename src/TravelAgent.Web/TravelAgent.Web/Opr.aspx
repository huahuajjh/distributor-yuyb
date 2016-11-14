<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Opr.aspx.cs" Inherits="TravelAgent.Web.Opr" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <meta http-equiv="Refresh" content="5; url=/member/Index.aspx"/>
    <link href="/css/style.css" rel="stylesheet" type="text/css" />
    <link href="/css/error.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <div class="box">
        <div class="<%=strcss %>"><asp:Literal ID="ltTag" runat="server"></asp:Literal></div>
        <div class="text_content">
            <p><asp:Literal ID="ltMsg" runat="server"></asp:Literal></p>
            <p>咨询热线：<font color="red">028-87306550</font> 赶快成为分销商吧！</p>
            <span><em>※ 您还可以进行如下操作：</em></span>
            <span><a href="/">返回首页</a><a href="javascript:history.back(-1);">返回上一页</a><a href="/member/Login.aspx">去我的个人中心</a></span>
            <span class="text_right"><b id="wait">5</b>秒钟后自动跳转，如不想等待请<a id="href" href="javascript:history.back(-1);">点击这里</a></span>
        </div>
    </div>
</body>
</html>
