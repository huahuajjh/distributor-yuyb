<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin_Default.aspx.cs" Inherits="TravelAgent.Web.admin.Admin_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title><%=webinfo.WebName%> - 后台管理</title>
    <link href="css/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../js/jquery-1.3.2.min.js"></script>
    <script type="text/javascript" src="js/adminCommon.js"></script>
    <script type="text/javascript" src="../js/genneral.js"></script>
    <style>
        #form1 { overflow:hidden; }
    </style>

    <script>
        $(function () {
            var window_height = $(document).height();
            $("#mainRight").css("height", window_height);
        })
    </script>
</head>
<body>
<form id="form1" runat="server">
<table border="0" cellpadding="0" cellspacing="0" height="100%" width="100%" style="background:#EBF5FC; table-layout:auto">
<tbody>
  <tr>
    <td height="88" colspan="3" style="background:url(images/topbg.gif) repeat-x;">
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
      <tr>
        <td class="topleft"><img src="images/logo.png" width="274" height="71" alt=""></td>
        <td valign="bottom">
	  <!--导航菜单,与下面的相关联,修改时注意参数-->
            <ul class="nav">
    <%=ShowTopNav()%>
    <li onclick="Navs(5,'系统首页','index');Tabs('Admin_Center.aspx')"><a href="javascript:void(0);" class="selected"><img src="images/index.png" title="系统首页" /><h2>系统首页</h2></a></li>
    </ul>
        </td>
        <td width="400">
        <div class="topright">    
    <ul>
    <li><a href="/Default.aspx" target="_blank">网站首页</a></li>
    <li><a href="javascript:void(0);" onclick="Tabs('basicset/UpdatePassword.aspx')">密码修改</a></li>
    </ul>
     
    <div class="user">
    <span><%=Admin.UserName %></span>
    <i>欢迎使用TravelCMS！[<a href="QuitLogin.aspx" target="_parent" style="color:Yellow">退出系统</a>]</i>
    </div>    
    
    </div>
        </td>
      </tr>
    </table>
    </td>
  </tr>
  <tr>
    <td id="mainLeft" valign="top" style="background-color:#f0f9fd; width:187px;">
       <div class="lefttop"><span></span><label id="lblNavTitle">系统首页</label></div>
        <dl class="leftmenu">
     <dd class="index">
            <ul class="menuson show">
        <%=ShowLeftNav()%>
        </ul>   
     </dd>  
    <dd class="sys noshow">
    	<ul class="menuson">
        <%=ShowSysNav()%>
        </ul>    
    </dd> 
    <%=ShowProNav() %>
    <dd class="order noshow">
    <ul class="menuson show">
        <%=ShowOrderNav()%>
    </ul>
    </dd> 
    <dd class="club noshow">
    <ul class="menuson show">
        <%=ShowClubNav()%>
    </ul>
    </dd> 
    <dd class="common noshow">
    <ul class="menuson show">
        <%=ShowCommonNav()%>
    </ul>
    </dd> 
    
    </dl>
	</td>
	<td valign="middle" style="width:8px;background:url(images/main_cen_bg.gif) repeat-x;">
      <div id="sysBar" style="cursor:pointer;width:8px"><img id="barImg" src="images/butClose.gif" alt="关闭/打开左栏" /></div>
	</td>
	<td id="mainRight" style="" valign="top">
      <iframe frameborder="0" id="sysMain" name="sysMain" scrolling="yes" src="Admin_Center.aspx" style="height:100%;visibility:inherit; width:100%;z-index:1;"></iframe>
	</td>
  </tr>
  <tr>
    <td height="28" colspan="3" bgcolor="#EBF5FC" style="padding:0px 10px;font-size:10px;color:#2C89AD;background:url(images/foot_bg.gif) repeat-x;"></td>
  </tr>
  </tbody>
</table>
</form>
</body>
</html>
