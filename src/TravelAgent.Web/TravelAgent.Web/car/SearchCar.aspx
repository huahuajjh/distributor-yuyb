<%@ Page Title="" Language="C#" MasterPageFile="~/Common.Master" AutoEventWireup="true" CodeBehind="SearchCar.aspx.cs" Inherits="TravelAgent.Web.car.SearchCar" %>
<%@ MasterType VirtualPath="~/Common.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="/css/style.css" />
<link rel="stylesheet" type="text/css" href="/car/css/car.css" />
<link type="text/css" href="/car/css/jquery-ui.css" rel="stylesheet" />
<script type="text/javascript" src="/car/scripts/jquery.js"> </script>
<script type="text/javascript" src="/js/jquery.extendfun.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!--主体开始-->
	<div id="main" class="list">
		<div class="wrapper">
			<div class="crumbs">您所在位置：<a href="/" title="首页">首页</a> > <a href="/car/Default.aspx" title="租车">租车 </a> > 自驾租车</div>
			<div class="areaBox">
				<div class="filtersPanel"><!--没有筛选条件时不显示-->
					<dl class="clearfix">
						<dt><em>0</em> 个车型符合您已选择的条件：</dt>
						<dd class="clearfix">
						</dd>
					</dl>
				</div>
				<div class="inner">
					<div class="innerInfo">
						<dl class="clearfix">
							<dt>类型：</dt>
							<dd>
								<ul class="clearfix">
                                    <li style="display:none"><a id="t_0" t="1" link="0" href="javascript:;" onClick="ListUrl(this.id);return false;">不限</a></li>
									<li><a id="t_1" href="javascript:;" onClick="ListUrl(this.id);return false;">旅游租车</a></li>
									<li><a id="t_2" href="javascript:;" onClick="ListUrl(this.id);return false;">自驾租车</a></li>
								</ul>
							</dd>
						</dl>
						<dl class="clearfix">
							<dt>城市：</dt>
							<dd>
								<ul class="clearfix">
                                    <li style="display:none"><a id="cid_0" t="1" link="0" href="javascript:;" onClick="ListUrl(this.id);return false;">不限</a></li>
								    <%=BindCity()%>
								</ul>
							</dd>
						</dl>
						<dl class="clearfix">
							<dt>车辆品牌：</dt>
							<dd>
								<ul class="clearfix">
									<li style="display:none"><a id="b_0" t="1" link="0" href="javascript:;" onClick="ListUrl(this.id);return false;">不限</a></li>
									<%=BindBrand()%>
								</ul>
							</dd>
						</dl>
						<dl class="clearfix">
							<dt>车辆级别：</dt>
							<dd>
								<ul class="clearfix">
									<li style="display:none"><a id="tid_0" t="1" link="0" href="javascript:;" onClick="ListUrl(this.id);return false;">不限</a></li>
									<%=BindClass()%>
								</ul>
							</dd>
						</dl>    
						<dl class="clearfix">
							<dt>车辆厢数：</dt>
							<dd>
								<ul class="clearfix">
									<li style="display:none"><a id="x_0" t="1" link="0" href="javascript:;" onClick="ListUrl(this.id);return false;">不限</a></li>
									<%=BindNumber()%>
								</ul>
							</dd>
						</dl>
						<%--<dl class="clearfix">
							<dt>价格范围：</dt>
							<dd>
								<ul class="clearfix">
									<li style="display:none"><a id="p1_0_p2_0" t="1" link="0" href="javascript:;" onClick="ListUrl(this.id);return false;">不限</a></li>
									<li><a id="p1_0_p2_100" href="javascript:;" onClick="ListUrl(this.id);return false;">0~100元/日</a></li>
									<li><a id="p1_100_p2_300" href="javascript:;" onClick="ListUrl(this.id);return false;">100~300元/日</a></li>
									<li><a id="p1_301_p2_500" href="javascript:;" onClick="ListUrl(this.id);return false;">301~500元/日</a></li>
									<li><a id="p1_501_p2_1000" href="javascript:;" onClick="ListUrl(this.id);return false;">501~1000元/日</a></li>
									<li><a id="p1_1001_p2_0" href="javascript:;" onClick="ListUrl(this.id);return false;">1000元以上/日</a></li>
								</ul>
							</dd>
						</dl>--%>
						<dl class="clearfix bNone">
							<dt>车辆座位：</dt>
							<dd class="checked">
								<ul class="clearfix">
									<li style="display:none"><a id="s1_0_s2_0" t="1" link="0" href="javascript:;" onClick="ListUrl(this.id);return false;">不限</a></li>
								    <li><a id="s1_5_s2_7" href="javascript:;" onClick="ListUrl(this.id);return false;">5~7座</a></li>
								    <li><a id="s1_8_s2_11" href="javascript:;" onClick="ListUrl(this.id);return false;">8~11座</a></li>
								    <li><a id="s1_12_s2_25" href="javascript:;" onClick="ListUrl(this.id);return false;">12~25座</a></li>
								    <li><a id="s1_26_s2_34" href="javascript:;" onClick="ListUrl(this.id);return false;">26~34座</a></li>
								    <li><a id="s1_35_s2_45" href="javascript:;" onClick="ListUrl(this.id);return false;">35~45座</a></li>
								    <li><a id="s1_46_s2_0" href="javascript:;" onClick="ListUrl(this.id);return false;">46座以上</a></li>
								</ul>
							</dd>
						</dl>
					</div>
				</div>
				
			</div>
			<!--条件筛选-->
			<div class="listWrapper clearfix">
				<div class="leftBox">
					<!--租车列表-->
					<div class="sort clearfix">
						<a id="o_0" href="javascript:void(0)" class="default" onClick="ListUrl(this.id);return false;">推荐</a>
						<!--<a href="javascript:void(0)" class="asc cur">价格<i></i></a>
						<a href="javascript:void(0)" class="desc">价格<i></i></a>
						<a href="javascript:void(0)" class="asc">销量<i></i></a>
						<a href="javascript:void(0)" class="desc">销量<i></i></a>-->
                        <a id="o_2" href="javascript:void(0)" onClick="ListUrl(this.id);return false;">价格从低到高</a>
						<a id="o_3" href="javascript:void(0)" onClick="ListUrl(this.id);return false;">价格从高到低</a>
						<div class="topPages clearfix">
						</div>
					</div>
					<div class="carList">
                        <%=BindCarList()%>
                    </div>
					<!--租车列表结束-->
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
	<script type="text/javascript">
	    $(function() {
	        $("#cid_" + $.getUrlParam("cid") + ",#tid_" + $.getUrlParam("tid") + ",#b_" + $.getUrlParam("b") + ",#o_" + $.getUrlParam("o") + ",#s1_" + $.getUrlParam("s1") + "_s2_" + $.getUrlParam("s2") + ",#t_" + $.getUrlParam("t") + ",#x_" + $.getUrlParam("x") + "").addClass('cur');
	        if ($.getUrlParam("o")==null) {
	            $('[id="o_0"]').addClass('cur');
	        }
	        //	        if (0 == 2) $('#cid_0').addClass('cur');
	        $(".innerInfo dl").each(function() {
	            var cur = $(this).find("a.cur");
	            if (typeof (cur) != "undefined" && (typeof (cur.attr("t")) == "undefined" || $.trim(cur.attr("t")) == "") && $.trim(cur.text()) != "") {
	                $(".filtersPanel").find("dd").append('<a href="javascript:void(0)" tag="' + cur.attr("id") + '" para="' + cur.attr("para") + '" class="item">' + cur.text() + '</a>');
	            }
	            cur = $(this).find('input:checked');
	            for (var i = 0; i < cur.length; i++) {
	                var name = cur.text();
	                if ($.trim(name) == '' && $('label[for="' + cur.attr("id") + '"]').length > 0) {
	                    name = $('label[for="' + cur.attr("id") + '"]').text();
	                }
	                if (typeof (cur) != "undefined" && (typeof (cur.attr("t")) == "undefined" || $.trim(cur.attr("t")) == "") && $.trim(name) != "") {
	                    $(".filtersPanel").find("dd").append('<a href="javascript:void(0)" tag="' + cur.attr("id") + '" para="' + cur.attr("para") + '" class="item">' + name + '</a>');
	                }
	            }
	        });
	        $(".filtersPanel").find("a").click(function() {
	            var tag = $(this).attr("tag").toLowerCase();
	            var first = $("#" + tag).parent().parent().find("li").first().find("a");
	            if (typeof (first.attr("link")) != "undefined" && $.trim(first.attr("link")) == "0") {
	                first.click();
	                return;
	            }
	            var url = first.attr("href");
	            if (typeof (first.attr("url")) != "undefined" && $.trim(first.attr("url")) != "") {
	                url = first.attr("url");
	            }
	            window.location.href = url;
	        });
	    })
	</script>
</asp:Content>
