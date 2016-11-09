//tab 导航
$(document).ready(function() {
	jQuery.jqtab = function(tabtit,tab_conbox,shijian) {
		$(tab_conbox).find("li").hide();
		$(tabtit).find("li:first").addClass("thistab").show(); 
		$(tab_conbox).find("li:first").show();
	
		$(tabtit).find("li").bind(shijian,function(){
		  $(this).addClass("thistab").siblings("li").removeClass("thistab"); 
			var activeindex = $(tabtit).find("li").index(this);
			$(tab_conbox).children().eq(activeindex).show().siblings().hide();
			return false;
		});
	
	};
	/*调用方法如下：*/
	
	$.jqtab("#tabs1","#tab_conbox1","mouseenter");
	$.jqtab("#tabs2","#tab_conbox2","mouseenter");
	$.jqtab("#tabs3","#tab_conbox3","mouseenter");
	$.jqtab("#tabs4","#tab_conbox4","click");
});