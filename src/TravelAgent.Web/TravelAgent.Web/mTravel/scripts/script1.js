jQuery(document).ready(function ($) {
	//导航
	$(".navbtn").click(function () {
		$(".zhedang").fadeIn(200);
		$('.roboxs').slideDown(200);
	});
	//目的地
	$(".nav_btn_1").click(function () {
		$('.navbox').slideUp(200);
		$('.roboxs').slideDown(200);
	});
	//关闭按钮
	$(".closebtn").click(function () {
		$(".roboxs").slideUp(200);		
		$(".zhedang").fadeOut(200);
	});
	$("#rolin").rolinTab();

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