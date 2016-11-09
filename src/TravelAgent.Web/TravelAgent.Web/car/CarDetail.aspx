<%@ Page Title="" Language="C#" MasterPageFile="~/Common.Master" AutoEventWireup="true" CodeBehind="CarDetail.aspx.cs" Inherits="TravelAgent.Web.car.CarDetail" %>
<%@ MasterType VirtualPath="~/Common.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<link rel="stylesheet" type="text/css" href="/css/style.css" />
<link rel="stylesheet" type="text/css" href="/car/css/car.css" />
<script type="text/javascript" src="/car/scripts/jquery.js"> </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="show" id="main">
		<div class="wrapper">
			<div class="crumbs">您所在位置：<a title="首页" href="/">首页</a> &gt; <a title="租车" href="/car/Default.aspx">租车</a> &gt; <%=car.CarName %></div>
			<div class="topMod">
				<div class="showInfo clearfix">
					<div class="picBox">
						<img alt="" src="<%=car.CarPic %>">
					</div>
					<div class="infoText">
						<h2><%=car.CarName %></h2>
						<ul class="basic clearfix">
							<li><b>所属品牌：</b><a target="_blank" href="?SearchCar.aspx"><%=car.BrandName %></a></li>
							<li><b>车辆级别：</b><%=car.ClassName %></li>
							<li><b>可乘人数/座位：</b><%=car.Seat %></li>
						</ul>
						<div class="desc">
							<label>车辆描述：</label>
							<p><%=TravelAgent.Tool.StringPlus.LeftTrueLen(car.CarDesc,200,"......")%></p>
						</div>
				        <div class="itemBox booking" id="booking">
							<div class="itemList">
								<dl class="title clearfix">
									<dd class="row1">类型</dd>
									<dd class="row2">门市价</dd>
									<dd class="row3">优惠价</dd>
									<dd class="row5">单位</dd>
								</dl>
								<%=BindPrice(3)%>
							</div>
						</div>
					</div>
				</div>
			</div>
			<div class="infoMain clearfix">
				<div class="leftBox">
					<div class="mainCon">
						<div class="pin-wrapper" style="height: 48px;">
						    <ul class="navBox clearfix" style="width: 950px;">
							    <li><a rel="nofollow" class="cur" href="#introduction">租车介绍</a></li>
							    <li><a rel="nofollow" href="#instructions">预订须知</a></li>
						    </ul>
						</div>
						
						<!--租车介绍-->
						<div id="introduction" class="itemBox introduction">
							<div class="hd"><span>租车介绍</span><i></i><b></b></div>
							<div class="content reset">
								<%=car.CarDesc %>
							</div>
						</div>
						<!--租车介绍结束-->
						<!--预订须知-->
						<div id="instructions" class="itemBox instructions">
							<div class="hd"><span>预订须知</span><i></i><b></b></div>
							<div class="content reset">
								<%=car.CarOrderTip %>
							</div>
						</div>
						<!--预订须知结束-->
						
					</div>
				</div>
				<div class="rightBox">
					<div class="pin-wrapper" style="height: 776px;">
					    <div class="bCity" style="width: 232px;">
						    <h3>租车推荐</h3>
						    <div class="content">
								    <%=BindTJCar(5)%>
						    </div>
					    </div>
					</div>
				</div>
			</div>
		</div>
	</div>
	<script type="text/javascript" src="/car/scripts/jquery.pin.js"></script>
	<script type="text/javascript" src="/car/scripts/car.js"></script>
</asp:Content>
