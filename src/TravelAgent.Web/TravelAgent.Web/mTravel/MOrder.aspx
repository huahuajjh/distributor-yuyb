<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MOrder.aspx.cs" Inherits="TravelAgent.Web.mTravel.MOrder" %>

<!doctype html>
<html>
<head>
<meta charset="utf-8" />
<title>手机订单信息填写_<%= webinfo.WebName %></title>
<meta name="viewport" content="width=device-width, initial-scale=1.0, user-scalable=0, minimum-scale=1.0, maximum-scale=1.0">
<link type="text/css" rel="stylesheet" href="css/style.css" />
<link type="text/css" rel="stylesheet" href="css/yuding.css" />
<link  rel="stylesheet" type="text/css" href="css/fullcalendar.css" />
<link href="css/mAutocomplete.css" type="text/css" rel="stylesheet" />
<link href="font-awesome-4.6.3/css/font-awesome.css" rel="stylesheet" />
    <style>
        .order-btn {
                background: #008857;
            text-align: center;
            color: white;
            font-size: 20px;
            line-height: 1.4;
            width:40px;
        }
    </style>
<script src="scripts/jquery.min.js"></script>
<script src="/js/url.js" type="text/javascript"></script>
<script type="text/javascript" src="scripts/date.js" ></script>
<script type="text/javascript" src="scripts/iscroll.js" ></script>
<script type="text/javascript" src="scripts/fullcalendar.js"></script>
<script src="scripts/mAutocomplete.js" type="text/javascript"></script>
<script type="text/javascript">
    $(function() {
        //$("#tuijianren").bindAddress({
        //    addressUrl: apiURL.AreaGet,
        //    schoolUrl: apiURL.SchoolGet,
        //    personUrl: apiURL.ReferencesSchoolGetBySchId
        //});
        $('#tuijianren').autocomplete({
            url: apiURL.ReferencesSchoolGetByFuzzy,
            width: 300,
            height: 30,
        });
        //$('#shijian').date();
        $("#ordertime").val("");
        $("#ordertime").change(function() {

            var price = $(this).find("option:selected").attr("tag");
            $("#shijian1").val($(this).find("option:selected").attr("value"));

            var arryprice = price.split(',');
            $("#adult_price").val(arryprice[0]);
            $("#child_price").val(arryprice[1]);

            $("#adult_price_span").text("￥" + arryprice[0]);
            $("#child_price_span").text("￥" + arryprice[1]);

            checkout_totalprice();
        })
    });
</script>
</head>
<body>
       
<div class = "page_first">
<header class="header"> <a href="javascript:window.history.go(-1);" class="ic_back"></a>
  <h2>在线预订</h2>
  <a href="javascript:;" class="navbtn"><span></span><span></span><span></span></a> </header>

<div id="page_1">
  <div class="m-main">
<form action="data/addorder.aspx" enctype="multipart/form-data" method="post">
<input type="hidden" name="action" value="post" />
<input type="hidden" name="lineid" value="<%=LineModel.Id %>" />
<input type="hidden" name="linename" value="<%=LineModel.LineName %>" />
<input type="hidden" name="deal_type" value="<%=LineModel.DealType %>" />
<input type="hidden" name="order_type" value="1" />
<input type="hidden" id="shijian1" name="shijian1" value="" />
<input type='hidden' id="adult_price" name="adult_price" value="0" />
<input type='hidden' id="child_price" name="child_price" value="0" />
<input type='hidden' id="bx_price" name="bx_price" value="<%=LineModel.Insure!=null?LineModel.Insure.InsurePrice.ToString():"0" %>" />
<input type="hidden" name="totalprice" id="totalprice" value="0" />
      <section class="main" id="order-next-m">
        <div class="plr10">
          <p class="order-tit-x mb10px"><i>1</i>填写出游信息</p>
          <div class="order-m">
            <ul>
              <li>
                <label  style="line-height:30px;">线路名称</label>
                <span class="long_name"><%=LineModel.LineName %></span>
                </li>
                <li>
                    <div id="price_calendar_lt"  align="center"></div>
                </li>
				<%--<li> 
				        <label>游玩日期</label>
				        <span class="t1">
				            <select id="ordertime" name="ordertime">
                                    <option value="">请选择出发日期</option>
                                    <%=ShowDate()%>                                                                       
                             </select>
				        </span>
				</li>--%>
              <li> 
                <label>成人</label>
                <span class="t2" id="adult_price_span">￥0</span> <span class="t3" id="adult_num"> <span class="j-linkage order-btn minus minus-active fa fa-minus" data-type="adults"></span>
                <input type='number' id="pr_d_num" min="0" max="100" class="order-txt-n" name="renshu1" value="0" />
                <span class="j-linkage order-btn plus plus-active fa fa-plus" data-type="adults"></span> </span>  </li>
              <li>
                <label>儿童</label>
                <span class="t2" id="child_price_span"> ￥0 </span> <span class="t3" id="child_num"> <span class="j-linkage order-btn minus minus-active fa fa-minus" data-type="teens"></span>
                <input type='number' min="0" max="100" id="pr_child_num" class="order-txt-n" name="renshu2" value="0" />
                <span class="j-linkage order-btn plus plus-active fa fa-plus" data-type="teens"></span> </span> </li>
              <li>
                <label>保险</label>
                <span class="t2" id="baoxian"> ￥<%=LineModel.Insure!=null?LineModel.Insure.InsurePrice.ToString():"0" %> </span> <span class="t3" id="baoxian_num"> <span class="j-linkage order-btn minus minus-active fa fa-minus" data-type="baox"></span>
                <input type='number' min="0" max="100" id="pr_bx_num" class="order-txt-n" name="renshu3" value="0" />
                <span class="j-linkage order-btn plus plus-active fa fa-plus" data-type="baox"></span> </span> 
              </li>
              <li> 
                <label>订单总额</label>
                <span class="price t1" style="width:auto;right:16px;top:5px;color:#f60;">￥ <span id="total_price" style="font-weight:bold;font-size:22px;color:#f60;"></span> </span> </li>
            </ul>
          </div>
        </div>
      </section>

      <section class="main" id="order-con">
        <div class="plr10">
          <p class="order-tit-x mb10px"><i>2</i>填写联系人信息</p>
          <div class = "error_tip">错误提示</div>
          <div class="order-m">
            <ul>
              <li> 
                <label class = "label_hd">联&nbsp;系&nbsp;人</label>
                <span class="t2">
                <input type='text' id="user" placeholder="真实姓名（必填）" class="order-txt" name="xingming" value="" />
                </span> </li>
              <li> 
                <label class = "label_hd">手机号码</label>
                <span class="t2">
                <input type='text' id="phone" placeholder="常用联系号码（必填）" class="order-txt" name="dianhua" maxlength="11" value="" />
                </span></li>
                 <li> 
                <label class = "label_hd">身份证号</label>
                <span class="t2">
                <input type='text' id="IDcard" placeholder="身份证号（必填）" class="order-txt" name="IDcard" maxlength="50" value="" />
                </span></li>
                 <li> 
                <label class = "label_hd">推荐人</label>
                <span class="t2">
                <input type='text' id="tuijianren" placeholder="请输入本校名称或者推荐人姓名即可查找推荐人信息，无推荐人输入学校名称即可" class="order-txt" name="tuijianren" maxlength="50" value="" />
                </span></li>
                 <li> 
                <label class = "label_hd"></label>
                <span class="t2">
                说明：推荐人请填写本校校园经理或代理姓名，或学校名称
                </span></li>
            </ul>
          </div>
          <p class="mt10">
            <button type="submit" id="save" class="btn btn-block btn_1" style="border:none">提 交</button>
          </p>
        </div>
      </section>
    </form>
  </div>

</div>
<div id="datePlugin"></div>
<!--foot-->
<footer class="copyright">
	<p>
		<%=BindBottonNav(3,3)%>
	</p>
	<p>Copyright &copy; 2015-<%=DateTime.Now.Year %></p>
	<p>技术支持：约游约呗</p>
</footer>
<script type="text/javascript" src="scripts/script1.js"></script>
<div class="zhedang"></div>
<div class="roboxs">
<div class="roboxs_tit"> 
<a href="../M_Default.aspx" class="homebtn"></a>
<a href="javascript:;" class="closebtn">×</a>
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
<script src="scripts/order_widget.js"></script>
<script type="text/javascript">
    $(function() { 
        if ($('#price_calendar_lt').size() > 0) {
                            $('#price_calendar_lt').fullCalendar({
                                aspectRatio: 1.4,
                                events: "/mTravel/data/LoadwapCalendar.aspx?id="+<%=LineModel.Id %>,
                                loading: function(isLoading, view) {
                                    if (isLoading) {
                                        $("#loading").show();
                                    } else {
                                        $("#loading").hide();
                                    }
                                },
                                header: {
                                    left: 'prev',
                                    center: 'title',
                                    right: 'next'
                                },
                                selectable: false,
                                eventClick: function(calEvent, jsEvent, view) {
                                    if (calEvent.allDay) {
                                               $("#adult_price_span").text("￥" + calEvent.adultprice);
                                               $("#child_price_span").text("￥" + calEvent.childprice);
                                               $("#adult_price").val(calEvent.adultprice);
                                               $("#child_price").val(calEvent.childprice);
                                               $("#shijian1").val($.fullCalendar.formatDate(calEvent.start,"yyyy-MM-dd"));
//                                            $("#hidden_div").css({ top: jsEvent.pageY + 10, left: jsEvent.pageX - 160 }).show();
//                                            $("#hidden_div").find(".J_datetxt").html(calEvent.info);
//                                            $("#hidden_div").find("input[name='ordertime']").val($.fullCalendar.formatDate(calEvent.start,"yyyy-MM-dd"));
                                               //$(this).css('background-color', '#f60');
                                               $("#price_calendar_lt").fullCalendar('select',calEvent.start,calEvent.end,true);
                                     }
                                     return false;
                                }
//                                dayClick:function(date, allDay, jsEvent, view){
//                                    //$(this).css('background-color', '#f60');
//                                    alert("a");
//                                }
                            });
                         }
    })
</script>
</body>
</html>
