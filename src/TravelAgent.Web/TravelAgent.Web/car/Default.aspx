<%@ Page Title="" Language="C#" MasterPageFile="~/Common.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TravelAgent.Web.car.Default" %>
<%@ MasterType VirtualPath="~/Common.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<link rel="stylesheet" type="text/css" href="/css/style.css" />
<link rel="stylesheet" type="text/css" href="/car/css/car.css" />
<link type="text/css" href="/car/css/jquery-ui.css" rel="stylesheet" />
<script src="/My97DatePicker/WdatePicker.js" type="text/javascript"></script>
<script type="text/javascript" src="/js/default.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="index" id="main">
		<div class="wrapper">
			<div class="topMod clearfix">
				<!--搜索-->
                <div class="searchBoxc">
	<div class="hd">
        <input type="hidden" value="" name="ct_1" id="ct_1">
		<ul class="clearfix">	
			<li val="2" class="on">自驾租车</li>	
			<li val="1">旅游租车</li>	
		</ul>
	</div>
	<div class="bd">
		<div class="conWrap">
			<div class="con">
				<ul class="clearfix">
					<li style="z-index:19;">
						<label>城市</label>
                        <input type="hidden" value="0" data-city="{clevel:0,cpid:0,cid:0,carcity:0}" id="scid_1">
						<input type="text" class="inputText inputDrop" value="不限" placeholder="目的地城市">
						<div class="dropDown city">
							<h2>请选择目的地城市</h2>
							<dl>
                                <dd val="0">不限</dd>
                                <%=BindCity()%>
							</dl>
						</div>
					</li>
					<li style="z-index:18;">
						<label>车辆级别</label>
                        <input type="hidden" value="0" id="stid_1">
						<input type="text" class="inputText inputDrop" value="不限" readonly="" placeholder="车辆级别">
						<div style="display: none;" class="dropDown">
							<dl>    
                                <dd val="0">不限</dd>
								<%=BindClass()%>
							</dl>
						</div>
					</li>
					<li><label>租车日期</label><input id="cm1_0" name="cm1" type="text" class="inputText inputCalendar Wdate" value="" onfocus="WdatePicker({doubleCalendar:true,dateFmt:'yyyy-MM-dd'})"></li>
					<li><label>还车日期</label><input id="cm2_0" name="cm2" type="text" class="inputText inputCalendar Wdate" value="" onfocus="WdatePicker({doubleCalendar:true,dateFmt:'yyyy-MM-dd'})"></li>
					<li class="butbox"><input type="button" onclick="Search(this,'cid=scid_1,tid=stid_1,t=ct_1,cm1=cm1_0,cm2=cm2_0');" url="SearchCar.aspx" class="but" value="立即搜索"></li>
				</ul>
			</div>
			<div class="con" style="display: none;">
				<ul class="clearfix">
					<li style="z-index:19;">
						<label>城市</label>
                        <input type="hidden" value="0" data-city="{clevel:0,cpid:0,cid:0,carcity:0}" id="scid_2">
						<input type="text" class="inputText inputDrop" value="不限" placeholder="目的地城市">
						<div class="dropDown city">
							<h2>请选择目的地城市</h2>
							<dl>
                                <dd val="0">不限</dd>
								<%=BindCity()%>
							</dl>
						</div>
					</li>
					<li style="z-index:18;">
						<label>车辆级别</label>
                        <input type="hidden" value="0" id="stid_2">
						<input type="text" class="inputText inputDrop" value="不限" readonly="" placeholder="车辆级别">
						<div style="display: none;" class="dropDown">
							<dl>    
                                <dd val="0">不限</dd>
								<%=BindClass()%>		
							</dl>
						</div>
					</li>
					<li><label>租车日期</label><input id="cm1_1" name="cm1" type="text" class="inputText inputCalendar Wdate" value="" name="cm1" id="cm1_1" onfocus="WdatePicker({doubleCalendar:true,dateFmt:'yyyy-MM-dd'})"></li>
					<li class="butbox"><input type="button" onclick="Search(this,'cid=scid_2,tid=stid_2,t=ct_1,cm1=cm1_1');" url="SearchCar.aspx" class="but" value="立即搜索"></li>
				</ul>
			</div>
		</div>
	</div>
</div>
				<!--搜索结束-->
				<!--焦点图-->
				<div class="focusPic">	
					<script type="text/javascript" src="/Tools/Advert_js.ashx?id=22&class=focusPic2"></script>                                       
                    <a class="prev" href="javascript:void(0)"></a>
                    <a class="next" href="javascript:void(0)"></a>
                    <div class="num"><ul></ul></div>
				</div>
				<!--焦点图结束-->
				<!--服务承若-->
				<div class="service">
					<h2>服务承若</h2>
					<%=BindBrandInfo(0,3) %>
				</div>
				<!--服务承若结束-->
			</div>
			<div class="modes clearfix">
				<div class="leftBox">
					<div class="carMode">
						<h2>旅游租车推荐</h2>
						<div class="content">
							<ul class="clearfix">
							        <%=BindCarList() %>
							</ul>
						</div>
					</div>
				</div>
				<div class="rightBox">
				     <!--汽车品牌-->
				<div class="brand">
					<h2>汽车品牌</h2>
					<div class="content">
						<ul class="clearfix">
							<%=BindBrand(8)%>
							<li class="end">
								<a href="SearchCar.aspx">更多...</a>
							</li>
						</ul>
					</div>
				</div>
				<!--汽车品牌结束-->
					<div class="question">
						<div class="hd">常见问题</div>
						<ul class="questionList">
							<%=BindNews(50, 5)%> 
						</ul>
					</div>
					<div class="banner">
					</div>
				</div>
			</div>
		</div>
	</div>
	<script type="text/javascript" src="scripts/jquery.js"> </script>
        <script type="text/javascript" src="/js/jquery-ui.js"> </script>
		<script type="text/javascript" src="/js/jquery.SuperSlide.js"></script>
		<script type="text/javascript" src="scripts/carcommon.js"></script>
		<script type="text/javascript">
		    $(document).ready(function () {
		        $(".focusBox").slide({ titCell: ".num li", mainCell: ".pic", effect: "fold", autoPlay: true, trigger: "click",
		            //下面startFun代码用于控制文字上下切换
		            startFun: function (i) {
		                $(".focusBox .txt li").eq(i).animate({ "bottom": 0 }).siblings().animate({ "bottom": -36 });
		            }
		        });
		        $('.headNav').find('#car').addClass('cur');
		        //租车推荐
		        $(".recommended").slide({ titCell: ".hd ul", mainCell: ".bd ul", autoPage: true, effect: "left", autoPlay: true, vis: 4, pnLoop: false });
		        $('.brand li a').hover( //品牌鼠标效果
				    function () { $(this).find('div').show().animate({ bottom: 0 }); },
				    function () { $(this).find('div').hide().animate({ bottom: -30 }); }
			    );
		        $(".searchBoxc").slide({ mainCell: ".conWrap", trigger: "click", delayTime: 0, endFun: function (i) {
		            var val=$(".searchBoxc").find(".hd").find('li[class="on"]').attr("val");
		            if(!val)val=2;
		            $("#ct_1").val(val);
		        } 
		        });
		        dropDown();
		    });
		    function dropDown() { // 搜索下拉
		        $('.inputDrop').click(function (event) { //下拉框下拉
		            event.stopPropagation(); //取消事件冒泡
		            $(this).parents('li').find('.dropDown').slideDown();
		        });
		        $('.dropDown dd').click(function (event) { //赋值
		            $(this).parents('li').find('input[type="text"]').val($(this).html());
		            $(this).parents('li').find('input[type="hidden"]').val($(this).attr('val'));
		        });
		        $(document).click(function (event) { //点击空白处或者自身隐藏下拉层
		            $('.dropDown').fadeOut();
		        });
		    }
		</script>
</asp:Content>
