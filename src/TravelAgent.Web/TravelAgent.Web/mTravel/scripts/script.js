jQuery(document).ready(function ($) {
	//导航
	$(".navbtn").click(function () {
		$(".zhedang").fadeIn(200);
		$('.navbox').slideDown(200);
	});

	//搜索窗口
	$(".nav_btn_2").click(function () {
		$(".nav_search").slideDown(200);
		$('.navbox').slideUp(200);
	});

	//关闭按钮
	$(".closebtn").click(function () {
		$(".nav_search").slideUp(200);
		$(".zhedang").fadeOut(200);
	});
	//目的地
	$(".nav_btn_1").click(function () {
		$('.navbox').slideUp(200);
		$('.roboxs').slideDown(200);
	});
	$(".closebtn2").click(function () {
		$(".roboxs").slideUp(200);		
		$(".zhedang").fadeOut(200);
	});
	$("#rolin").rolinTab();
	$(".zhedang").click(function () { $(".zhedang,.navbox").css("display", "none"); });
});

$.fn.rolinTab = function () {
	var $that = $(this);
	$(this).find("li em").click(function () {
		if ($(this).hasClass('open'))
			return;
		$that.find(".rocon").slideUp("fast");
		$that.find("li em").removeClass("open");
		$(this).addClass("open");
		$(this).siblings(".rocon").slideDown("fast");
	});
	$(this).find("li em a").click(function (e) {
		e.stopPropagation();
	});
};