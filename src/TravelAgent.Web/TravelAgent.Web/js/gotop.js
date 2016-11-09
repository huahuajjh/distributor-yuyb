$(function() {
    var mddNav2 = document.getElementById("mddNav2");
    if (mddNav2) {
        var sfEls = mddNav2.getElementsByTagName("em");
        if (!$("#mddNav2").is(":hidden")) {
            for (var i = 0; i < sfEls.length; i++) {
                sfEls[i].onmouseover = function() {
                    this.className += (this.className.length > 0 ? " " : "") + "sfhover";
                }
                sfEls[i].onmouseout = function() {
                    this.className = this.className.replace(new RegExp("( ?|^)sfhover\\b"), "");
                }
            }
        }
    };

    $(".chanpin_nav").each(function() {
        var sfEls = $(this)[0].getElementsByTagName("dt");
        for (var i = 0; i < sfEls.length; i++) {
            sfEls[i].onmouseover = function() {
                this.className += (this.className.length > 0 ? " " : "") + "sfhover";
            }
            sfEls[i].onmouseout = function() {
                this.className = this.className.replace(new RegExp("( ?|^)sfhover\\b"),
                  "");
            }
        }
    })
    //var nav = $.getUrlParam("nav");
    //urlrewrite
    if (location.href.indexOf('_') > -1) {
        var nav = location.href.substring(location.href.lastIndexOf('/')+1, location.href.indexOf('_'));
        if (nav != null) {
            $(".memuNav li[id='nav_li" + nav + "']").addClass("current");
        }
    }
    else {
        $(".memuNav li[id='nav_li1']").addClass("current");
    }
});
//加入收藏
function addfavorite(url,text) {
        try {
            window.external.addFavorite(url, text);
        }
        catch (e) {
            try {
                        window.sidebar.addPanel(text, url, "");
                }
                catch (e) {
                        alert("请使用快捷键Ctrl+D一键收藏");
                }
        }
}

$(function() {

    //登录
    if ($.cookie('uid') > 0) {
        var username = $.cookie('username');
        var html =
                        '<div class="toplg">' +
                        '您好,<a target="_self" rel="nofollow" href="/member/MyInfo.aspx" id="username" style="color:#F60">' + username + '</a>,' +
                        '</div>';
        $("#topleftclub").html(html);

    } else {
    var html = "请  <a href=\"/member/Login.aspx\" rel=\"nofollow\" style=\"color:#F60\">登录</a>|<a href=\"/member/Register.aspx\" rel=\"nofollow\" style=\"color:#F60\">免费注册</a>"; 
        //'<i class="topLine"></i>';
        $("#topLogin").html(html);
    }

    //hover 背景切换
    $.fn.extend({
        hoverClass: function(className, speed) {
            var _className = className || "hover";
            return this.each(function() {
                var $this = $(this), mouseOutTimer;
                $this.hover(function() {
                    if (mouseOutTimer)
                        clearTimeout(mouseOutTimer);
                    $this.addClass(_className);
                }, function() {
                    mouseOutTimer = setTimeout(function() {
                        $this.removeClass(_className);
                    }, speed || 10);
                });
            });
        },
        focusClass: function(className, speed) {
            var _className = className || "focus";
            return this.each(function() {
                var $this = $(this), mouseOutTimer;

                $this.focusin(function() {
                    if (mouseOutTimer)
                        clearTimeout(mouseOutTimer);
                    $this.addClass(_className);

                });
                $this.focusout(function() {
                    mouseOutTimer = setTimeout(function() {
                        $this.removeClass(_className);
                    }, speed || 10);

                });

            });
        }
    });
    //hover背景切换
    $(".tj_con").hoverClass("tj_con_hover");
    $(".tab_pic_box").hoverClass("tab_pic_box_hover");
    $(".gljd1").hoverClass("gljd1_hover");
    $(".gljd2").hoverClass("gljd2_hover");
    $(".linelist").hoverClass("linelist_hover");
});

//固定头
$(function() {
    //当滚动条的位置处于距顶部200像素以下时，顶部导航出现，否则消失 
    $(function() {
        $(window).scroll(function() {
            if ($(window).scrollTop() > 150) {

                //$("#topmenu").fadeIn(100);
                $("#divheadmenu").show();
                $("#divheadmenu").html($(".header").html());
            }
            else {
                //$("#topmenu").fadeOut(100);
                $("#divheadmenu").hide();
            }
        });
    });
});

$(function() {
        //导航
        $(".munecon2 li,.munecon2 .child").hover(function() {
                $(this).children(".child").show();
        }, function() {
                $(this).children(".child").hide();

        });

        //关闭展开

        $(".munebox2").on("click", ".anniu_hand.open", function() {

                $(".munebox2").animate({left: "-36px"});
                $(this).removeClass("open").addClass("close");
        });

        $(".munebox2").on("click", ".anniu_hand.close", function() {

                $(".munebox2").animate({left: "0px"});
                $(this).removeClass("close").addClass("open");
        });

        $("input").focusClass("input_focus");
        $('.soft li').hover(function() {
            $(this).children('div').fadeIn();
            $(this).addClass('on');
        }, function() {
            $(this).children('div').fadeOut();
            $(this).removeClass('on');
        });
});


//自动提示
  function lookup(text_tours) {
        if (text_tours.length == 0) {
                $('#suggestions').hide();
        } else if (text_tours.length > 1) {
                $.post("", {queryString: "" + text_tours + ""}, function(data) {
                        if (data.length > 2) {
                                $('#suggestions').show();
                                $('#autoSuggestionsList').html(data);
                        } 
                });
        }
    }
   //加载底部广告
    window.onload = function() {
        var floatobj = document.getElementById("float_mask");
        if (floatobj != null) {
            if (getCookie("footad") == 0) {
                document.getElementById("float_mask").style.display = "none";
            } else {
                document.getElementById("float_mask").style.display = "block";
            }
        }
    }
    //关闭底部广告
    function closeFootAd() {
        document.getElementById("float_mask").style.display = "none";
        setCookie("footad", "0");
    }

    //设置cookie 
    function setCookie(name, value) {
        var exp = new Date();
        exp.setTime(exp.getTime() + 1 * 60 * 60 * 1000); //有效期1小时 
        document.cookie = name + "=" + escape(value) + ";expires=" + exp.toGMTString();
    }
    //取cookies函数 
    function getCookie(name) {
        var arr = document.cookie.match(new RegExp("(^| )" + name + "=([^;]*)(;|$)"));
        if (arr != null) return unescape(arr[2]); return null;
    } 
