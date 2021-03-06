﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LineTheme.aspx.cs" Inherits="TravelAgent.Web.mTravel.LineTheme" %>

<!DOCTYPE html>
<html>
        <head>
                <meta charset="utf-8" />
	<title>主题旅游-<%=webinfo.SEOTitle %></title>
		<meta name="keywords" content="<%=webinfo.SEOKeywords%>" />
		<meta name="description" content="<%=webinfo.SEODescription%>" />
		
	<meta name="viewport" id="viewport" content="width=device-width, initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no" />
	<link rel="stylesheet" type="text/css" href="/mTravel/css/mobile-style.css" />
	<link rel="stylesheet" type="text/css" href="/mTravel/css/mobile-index.css" />
	<script src="/mTravel/scripts/jquery.min.js" type="text/javascript"></script>
	<script type="text/javascript" src="/mTravel/scripts/jquery.event.drag-1.5.min.js"></script>
	<script type="text/javascript" src="/mTravel/scripts/jquery.touchSlider.js"></script>
</head>
<body>		

<header class="header">
		<a href="javascript:window.history.go(-1);" class="ic_back"></a>
		<h2>主题旅游</h2>
		<a href="javascript:;" class="navbtn"><span></span><span></span><span></span></a>
	</header>
<!--导航区-->
<nav class="home_link">
	<%--<div class="home_link_li">                                
		<a href="LineList.aspx" class="home_link_a">
			<div class="home_link_box mgrt tj">
				<em>Special offer</em>
				<span>特价产品</span>
			</div>
		</a>
		<a href="LineList.aspx?d=1" class="home_link_a">
			<div class="home_link_box mglt hg">
				<em>Outbound tourism</em>
				<span>出境旅游</span>
			</div>
		</a>
	</div>
	<div class="home_link_li">				
		<a href="LineList.aspx?d=2" class="home_link_a">
			<div class="home_link_box mgrt hb">
				<em>Domestic tourism</em>
				<span>国内旅游</span>
			</div>
		</a>
		<a href="LineList.aspx?d=3" class="home_link_a">
			<div class="home_link_box mglt rb">
				<em>Travel around</em>
				<span>周边旅游</span>
			</div>
		</a>  
	</div>
	<div class="home_link_li">           
		<a href="LineTheme.aspx" class="home_link_a">
			<div class="home_link_box mgrt zy">
				<em>Island tourism</em>
				<span>主题旅游</span>
			</div>
		</a>
		<a href="VisaList.aspx" class="home_link_a">
			<div class="home_link_box mglt qz">
				<em>Island tourism</em>
				<span>签证服务</span>
			</div>
		</a>
	</div>--%>
	<%=BindTheme()%>
</nav>
<!--页脚-->
<footer class="copyright">
	<p>
		<%=BindBottonNav(3,3)%>
	</p>
	<p>Copyright &copy; 2015-<%=DateTime.Now.Year %></p>
	<p>技术支持：约游约呗</p>
</footer>
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
	<div class="theme-popbod-one" id="popbod">
			<div class="m_more_des">				
				<span><a href="LineList.aspx">特价产品</a></span>
				<span><a href="LineList.aspx?d=1">出境旅游</a></span>
				<span><a href="LineList.aspx?d=2">国内旅游</a></span>
				<span><a href="LineList.aspx?d=3">周边旅游</a></span>
			</div>
		</div>
		</div>
<script src="scripts/slide.js"></script>
</body>
</html>