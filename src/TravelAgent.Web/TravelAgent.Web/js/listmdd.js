// JavaScript Document
$(function(){
        $("#rolin").rolinTab();
})
$.fn.rolinTab = function() {
        var $that = $(this);
        //var $first = $(this).find("li em").eq(0);
        //$first.addClass("open");
        //$first.siblings("dl.rocon").show();
        $(this).find("li em").click(function() {
                if ($(this).hasClass('open'))
                        return;
                $that.find("dl.rocon").slideUp("fast");
                $that.find("li em").removeClass("open");
                $(this).addClass("open");
                $(this).siblings("dl.rocon").slideDown("fast");
        });
        $(this).find("li em a").click(function(e) {
                e.stopPropagation();
        });
    };
    //图文转换
    var show_king_id = 1;
    function show_king_list(e, k) {
        if (show_king_id == k) return true;
        o = document.getElementById("a" + show_king_id);
        o.className = "bg";
        e.className = " ";
        show_king_id = k;
    }
    var show_kinga_id = 1;
    function show_kinga_list(f, l) {
        if (show_kinga_id == l) return true;
        o = document.getElementById("b" + show_kinga_id);
        o.className = "bg";
        f.className = " ";
        show_kinga_id = l;
    }