<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VisaList.aspx.cs" Inherits="TravelAgent.Web.mTravel.VisaList" %>

<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <meta name="viewport" id="viewport" content="width=device-width, initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no" />
    <%--<link rel="stylesheet" type="text/css" href="css/mobile_xnxw.css" />--%>
<link rel="stylesheet" type="text/css" href="css/index.css" />
<link rel="stylesheet" type="text/css" href="css/header.css" />
<link rel="stylesheet" type="text/css" href="css/global.css" />
<script type="text/javascript" src="scripts/jquery.js"></script>
<title><%=strTypeName %>-<%=webinfo.WebName %></title>
    <script type="text/javascript" src="scripts/base.js"></script>

</head>
<body>
<header class="header">
		<a href="javascript:window.history.go(-1);" class="ic_back"></a>
		<h2><%=strTypeName%></h2>
		<a href="javascript:;" class="navbtn"><span></span><span></span><span></span></a>
</header>
<div class="wraper">
    <div class="wrap">
        <div id="content" class="hl_bd">
                           
                           <!--线路列表-->
<div class="fex mt_20" style="margin-top:20px">
           <div class="m-list">
                <ul>
                 <%=BindVisaList() %>
                 </ul>
           </div>
        </div>
<div class="fanye">
    </div>
        </div>
        <footer class="copyright">
	<p>
		<%=BindBottonNav(3,3)%>
	</p>
	<p>Copyright &copy; 2015-<%=DateTime.Now.Year %></p>
	<p>技术支持：约游约呗</p>
</footer>
    </div>
</div>
<script type="text/javascript" src="scripts/script.js"></script>
<!--遮挡层-->
<div class="zhedang"></div>

<!--导航窗口一-->
<div class="navbox">
	<div class="navbox_on">
		<a href="../M_Default.aspx">
			<span class="ic_1"></span>
			<em>首页</em>
		</a>
		<a href="javascript:;" class="nav_btn_1">
			<span class="ic_2"></span>
			<em>分类</em>
		</a>
		<a href="javascript:;" class="nav_btn_2">
			<span class="ic_3"></span>
			<em>搜索</em>
		</a>
		<a href="tel:<%=webinfo.WebTel %>" >
			<span class="ic_4"></span>
			<em>客服</em>
		</a>
	</div>
</div>

<!--搜索窗口-->
<div class="nav_search" id="navboxs">
        <div class="nav_search_tit">
                <a href="javascript:;" class="closebtn">×</a>
                <h3>产品搜索</h3>
        </div>
        <div class="nav_search_on">
                <div class="searchbox">
                        <div class="searchbox_top">
                                <form method="get" name="form1" action="SearchResult.aspx">
                                        <input name="keyword" type="text" class="s_ipt" onclick="this.value = '';" value="请输入关键词" />
                                        <input type="submit" value="搜索" class="d_ico" />
                                </form>
                                <div class="x_ico"></div>
                        </div>
                </div>
        </div>
</div> 


<div class="roboxs">
	<div class="roboxs_tit">
                <a href="javascript:;" class="closebtn2">×</a>
                <h3>产品分类</h3>
        </div>
	  <ul class="rolinList" id="rolin" >
				<%=BindNav()%>
		   </ul>
		</div>
</body>
</html>
