<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LineOrder.aspx.cs" Inherits="TravelAgent.Web.mTravel.LineOrder" %>

<html>
        <head>
                <meta charset="utf-8" />
                <title>产品预订-<%=webinfo.WebName %></title>                
                <meta name="viewport" id="viewport" content="width=device-width, initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no">
                <link rel="stylesheet" type="text/css" href="css/mobile-style.css" />
		        <link rel="stylesheet" type="text/css" href="css/mobile-line.css" />
                <script src="scripts/jquery.min.js"></script>
                
        </head>
        <body>
                <header class="header">
                        <a href="javascript:window.history.go(-1);" class="ic_back"></a>
                        <h2>产品预订</h2>
                        <a href="javascript:;" class="navbtn"><span></span><span></span><span></span></a>
                </header>
                <!--详细内容-->
                <div class="threeBox">
                        <div class="threeBox_book">
                                <h1><%=pname%></h1>
                                <form id="step1">
                                        <input type="hidden" id="lineid" name="lineid" value="<%=pid %>" />
					                    <input type="hidden" id="orderType" name="orderType" value="<%=orderType %>" />
					                    <div class="threeBox_book_box">
                                                <p class="theleft">联&nbsp;&nbsp;系&nbsp;人</p>
                                                <p class="theright">
                                                        <input type="text" id="line_name" name="line_name" class="inputbox" value="" />
                                                </p>
                                        </div>

                                        <div class="threeBox_book_box">
                                                <p class="theleft">预订人数</p>
                                                <p class="theright">
                                                        <input type="text" id="line_ren" name="line_ren" class="inputbox" value=""> 
                                                </p>
                                        </div>

                                        <div class="threeBox_book_box">
                                                <p class="theleft">联系方式</p>
                                                <p class="theright">
                                                        <input type="text" id="line_phone" name="line_phone" class="inputbox" value=""> 
                                                </p>
                                        </div>

                                        <div class="threeBox_btn">
                                                <a href="javascript:window.history.go(-1);" class="threeBox_btn_back">返回上一步</a>
                                                <a href="javascript:void(0);"  id="send-btn" class="threeBox_btn_tijiao">提交订单</a>
                                        </div>
                                </form>
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

        <script type="text/javascript">
            $(function() {
                $('#send-btn').click(function() {
                    var line_id = $('input[name=lineid]').val();
                    var ordertype = $('input[name=orderType]').val();
                    var line_ren = $('input[name=line_ren]').val();
                    var line_name = $('input[name=line_name]').val();
                    var line_phone = $('input[name=line_phone]').val();
                    if (line_name == '') {
                        alert('请输入联系人信息！');
                        line_name.focus();
                        return;
                    }
                    if (line_ren== '') {
                        alert('请填写出游人数！');
                        line_ren.focus();
                        return;
                    }
                    if (!(/^1[3|5|4|8][0-9]\d{4,8}$/.test(line_phone))) {
                        alert("不是完整的11位手机号或者不正确的手机号");
                        return false;
                    }
                    $.ajax({
                        type: "POST",
                        url: "data/order.ashx",
                        cache: false,
                        dataType: "text",
                        data: { line_id: line_id, order_type: ordertype, line_ren: line_ren, line_name: line_name, line_phone: line_phone },
                        success: function(msg) {
                            //提示删除成功消息
                            if (msg.indexOf("true") >= 0) {
                                alert('您的询单已成功提交，稍后会有客服会与您联系，请耐心等候，或者直接拨打客服电话！');
                                //window.location.href = "../M_Default.aspx";
                                window.history.go(-1);
                                return false;
                            }
                            else {
                                alert('操作失败');
                                return false;
                            }
                        },
                        error: function(msg) {
                            alert(msg);
                        }

                    })
                    //				$.post("data/waporder.aspx", {
                    //					line_id: lineid.val(),
                    //					order_type: ordertype.val(),
                    //					line_ren: line_ren.val(),
                    //					line_name: line_name.val(),
                    //					line_phone: line_phone.val()
                    //				}, function (data) {
                    //					if (data.status) {
                    //						alert('您的询单已成功提交！');
                    //						window.location.href = "Default.aspx";
                    //					} else {
                    //						alert('操作失败');
                    //					}
                    //				}, 'json');
                });
            });
        </script>

</body>
</html>
