<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LineDetail.aspx.cs" Inherits="TravelAgent.Web.mTravel.LineDetail" %>

<html>
        <head>
                <meta charset="utf-8" />
                <title><%=Line.LineName%></title>
                <meta name="viewport" id="viewport" content="width=device-width, initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no">
            <link type="text/css" rel="stylesheet" href="css/style.css">
                <link rel="stylesheet" type="text/css" href="css/mobile-style.css" />
		        <link rel="stylesheet" type="text/css" href="css/mobile-line.css" />
                <script src="scripts/jquery.min.js"></script>
        </head>
        <body>		
                <header class="header">
                        <a href="javascript:window.history.go(-1);" class="ic_back"></a>
                        <h2>产品详情</h2>
                        <a href="javascript:;" class="navbtn"><span></span><span></span><span></span></a>
                </header>
                <!--详细内容-->
                <div class="linedetail">
                        <!--图片及标题-->
                        <div class="linedetail_box">                               
                                <div class="linedetail_pic">
                                        <img src="<%=Line.LinePic%>" alt="<%=Line.LineName%>" />
                                        <div class="linedetail_tit"><h1><%=Line.LineName%></h1></div>                    
                                </div>
                                <div class="linedetail_pre">
                                        <span><%=ShowJoinName(Line.ProIds)%></span>
                                        <span><%=Line.DayNumber %>日游</span>
                                        <strong><%=ShowPrice(Line.PriceCommon.ToString())%></strong>
                                </div>
                        </div>
			                        <!--出发日期及余位-->
                        <div class="linedetail_box">
                                <div class="linedetail_date">
                                        <p>提前报名：<%=Line.AheadNumber %>天</p>
                                        <p class="noborder">出发城市：<%=ShowCityName()%>，往返交通：<%=Line.TrafficIds.TrimStart(',').TrimEnd(',') %></p>					
                                </div>
                        </div>

			<!--出发日期-->
                        <div class="linedetail_box">
                                <div class="linedetail_xin_tit">出发日期及报价</div>
                                <div class="linedetail_xin_con" id="line_xinbox2">
											<%=ShowDate() %>                                
											<div class="linedetail_xin_btn2"><span><s></s></span></div>
                                </div>
                        </div>

                        <!--行程特色-->
                        <div class="linedetail_box">
                                <div class="linedetail_xin_tit">行程特色</div>
                                <div class="linedetail_xin_con" id="line_xinbox">
                                 <%=Line.LineFeature %>
<p>
	<strong></strong> 
</p>                                        <div class="linedetail_xin_btn"><span><s></s></span></div>
                                </div>
                        </div>
                        <!--详细行程-->
                        <div class="linedetail_box">
                                <div class="linedetail_xin_tit">行程参考【共&nbsp;<%=Line.DayNumber %>&nbsp;天】</div>
				<div class="linetrip">
					<div class="linetrip_top">
						<%=ShowLine(Line.Id) %>
					</div>
					<div class="linetrip_bot">
						<a href="LineXC.aspx?id=<%=Line.Id %>" class="linedatail_xiangxi">
							<div style="text-align: center; color: #f60;">查看行程详情</div>
							<div class="linedetail_xin_btn3"><span></span><span></span><span></span><span></span><span></span><span></span><span></span></div>
						</a>
					</div>
				</div>

                        </div>

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
	<div class="theme-popbod-one">
			<div class="m_more_des">				
				<span><a href="LineList.aspx">特价产品</a></span>
				<span><a href="LineList.aspx?d=1">出境旅游</a></span>
				<span><a href="LineList.aspx?d=2">国内旅游</a></span>
				<span><a href="LineList.aspx?d=3">周边旅游</a></span>
			</div>
		</div>
		</div>
        <div style="display: block; width: 100%; height: 50px;"></div>

        <!--预订按钮-->
        <div class="yuding_btn">
                <a href="tel:<%=webinfo.WebTel %>" class="yuding_tel">电话咨询</a>
                <a href="MOrder.aspx?id=<%=Line.Id %>" class="yuding_onclik">在线预订</a>
        </div>

	<script type="text/javascript">
		$(".linedetail_xin_btn span").click(function () {
			$("#line_xinbox").toggleClass("line_xinbox_down");
		});
		$(".linedetail_xin_btn2 span").click(function () {
			$("#line_xinbox2").toggleClass("line_xinbox_down2");
		});
		$(".zhedang").click(function () { $(".zhedang,.navbox").css("display", "none"); });
        </script>
</body>
</html>