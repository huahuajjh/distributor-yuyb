$(function() {
    $("#sysMain").css("width", $(window).width() - 200);
    //关闭打开左栏目
    $("#sysBar").toggle(function() {
        $("#mainLeft").hide();
        $("#barImg").attr("src", "images/butOpen.gif");
        $("#sysMain").css("width", $(window).width()-10);
    }, function() {
        $("#mainLeft").show();
        $("#barImg").attr("src", "images/butClose.gif");
        $("#sysMain").css("width", $(window).width() - 200);
    });
    //导航切换
    $(".menuson li").click(function() {
        $(".menuson li.active").removeClass("active")
        $(this).addClass("active");
    });
    $('.title').click(function() {
        var $ul = $(this).next('ul');
        $('dd').find('ul').slideUp();
        if ($ul.is(':visible')) {
            $ul.slideUp();
        } else {
            $ul.slideDown();
        }
    });
});
//切换选项卡
function Tabs(src) {
    var myFrame = document.getElementById("sysMain");
    if (myFrame != null) {
        myFrame.contentWindow.document.write("<div style='width:100%;text-align:center;'><table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" style='font-size:12px'><tr><td><img src='images/loading.gif'/></td><td>&nbsp;&nbsp;正在加载，请稍等。。。</td></tr></table></div>");
        myFrame.contentWindow.document.close();
        if (src != "") {
            myFrame.src = src + "?date=" + new Date().toUTCString();
        }
    }
}
//后台主菜单控制函数
function Navs(tabNum,titleName, funType) {
    $("#lblNavTitle").text(titleName);
    //设置点击后的切换样式
    $("ul.nav li a").removeClass("selected");
    $("ul.nav li a").eq(tabNum).addClass("selected");
    //根据参数决定显示子菜单
    $("." + funType).removeClass("noshow");
    $("." + funType).show();
    $("dd[class!='" + funType + "']").hide();
}
