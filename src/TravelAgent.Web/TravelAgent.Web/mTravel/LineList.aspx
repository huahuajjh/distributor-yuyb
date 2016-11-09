<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LineList.aspx.cs" Inherits="TravelAgent.Web.mTravel.LineList" %>

<!DOCTYPE html>
<html>
        <head>
                <meta charset="utf-8" />
		<title><%= strNavName %>-<%=webinfo.WebName %></title>
                <meta name="keywords" content="<%=webinfo.SEOKeywords%>" />
                <meta name="description" content="<%=webinfo.SEODescription%>" />
                <meta name="viewport" id="viewport" content="width=device-width, initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no" />
                <link rel="stylesheet" type="text/css" href="css/mobile-style.css" />
		        <link rel="stylesheet" type="text/css" href="css/mobile-channel.css" />
                <script src="scripts/jquery.min.js"></script>
                <script type="text/javascript">
                    //获取URL中参数的值
                    function request(paras) {
                        var url = location.href;
                        var paraString = url.substring(url.indexOf("?") + 1, url.length).split("&");
                        var paraObj = {}
                        for (i = 0; j = paraString[i]; i++) {
                            paraObj[j.substring(0, j.indexOf("=")).toLowerCase()] = j.substring(j.indexOf("=") + 1, j.length);
                        }
                        var returnValue = paraObj[paras.toLowerCase()];
                        if (typeof (returnValue) == "undefined") {
                            return "";
                        } else {
                            return returnValue;
                        }
                    }
                    $(function () {
                        $(".zhedang").click(function () { $(".zhedang,.navbox").css("display", "none"); });
                        var id = request("d");
                        if (id == "") {
                            $("#popbod").show();
                            $("#rolin").hide();
                        }
                        else {
                            $("#popbod").hide();
                            $("#rolin").show();
                        }
                    })
                </script>
        </head>
        <body>
		<header class="header">
		<a href="javascript:window.history.go(-1);" class="ic_back"></a>
		<h2><%=strNavName %></h2>
		<a href="javascript:;" class="navbtn"><span></span><span></span><span></span></a>
	</header>
	<!--搜索-->
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
	<div class="gy_tit">
				<em>目的地推荐</em>
			</div>
			<ul class="hotmdd">
				<%=BindPageNav()%>			
		    </ul>

	<!--产品部分-->
	<div class="gy_tit">
		<em>推荐产品</em>
	</div>

	<div class="show_line">
		   <%=BindLine(0)%>
	   </div>

	<!--页脚-->
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
			<ul class="rolinList" id="rolin" >
				<%=BindNav()%>
		   </ul>
		</div>
</body>
</html>
