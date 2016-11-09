/*弹出登陆回调*/
function AlertLoginReturn() {
    checklogin();
    HideWindow();
    if (rlogin == 0 && typeof (votetype) != "undefined") {
        votetype.click();
    } else if (rlogin == 1) {
        getvote();
    }

    if (typeof (top.frames["carReviews"]) != "undefined") {
        top.frames["carReviews"].location.reload();
        top.frames["carQuestions"].location.reload();
    }
}

function cbooking(url) {
    if (GetCookie('username') != '') { location = url; return; }
    ShowWindow('', '', webpath + 'BookingLogin.aspx?Page=' + URLencode(url));
}
function GetCar(Obj, cm1, cm2) {
    if (!Obj) { Obj = Container; } else { Container = Obj } //容器
    if (!cm1) { cm1 = ''; } //取车时间
    if (!cm2) { cm2 = ''; } //还车时间
    var SL = parseInt(Obj.attr('s'));
    if (SL == NaN) SL = 0; //显示列数
    //拼写租车ID
    var ctid = '';
    $(Obj).each(function () {
        ctid += ',' + $(this).attr('ctid');
//        $(this).html('<dl><dt>载入中...</dt></dl>');
    });
    if (ctid == '') return;
    if (ctid != '') ctid = ctid.substring(1);
    var ajaxpath = webpath + 'sys/ajax/GetCar.ashx?ctid=' + ctid + '&cm1=' + cm1 + '&cm2=' + cm2 + $('#searchwhere').val();
    $.ajax({
        type: 'GET', cache: false,
        url: ajaxpath,
        dataType: 'xml',
        success: function (xml) {
            $(Obj).each(function () {
                var t = $(this).attr("t");
                t = typeof (t) == "undefined" ? "0" : t;
                var thisctid = $(this).attr('ctid'), te = '', children;
                $(xml).find('cars>car[c_cartypeid="' + thisctid + '"]').each(function () {
//                    if (t == 0) {
//                        te += '<dl class="clearfix">';
//                        te += '<dt>' + $(this).attr('c_name') + '</dt>';
//                        te += '<dd><em class="org">¥' + $(this).attr('c_rackrate') + '</em></dd>';
//                        te += '<dd><em>¥' + $(this).attr('c_price') + '</em></dd>';
//                        te += '<dd>' + $(this).attr('c_unit') + '</dd>';
//                        te += '<dd><a href="javascript:void(0);" ';
//                        if ($(this).attr('averageprice') == '0') {
//                            te += 'class="order" title="已满">已满';
//                        } else if ($(this).attr('day') != $(this).attr('days')) {
//                            te += 'onclick="cbooking(\'' + $(this).attr('bookingurl') + '\');" title="部分满" class="order">部分满';
//                        } else {
//                            te += 'onclick="cbooking(\'' + $(this).attr('bookingurl') + '\');" title="预订" class="order">';
//                        }
//                        te += '</a></dd></dl>';
//                    } else {
                        te = $(this).attr('c_price');
//                    }
                });
//                if (t == 0) {
//                    if (te == '') te = '<dl><dt>暂无</dt></dl>';
//                    $(this).html(te);
//                } else {
                    $(this).find(".price").html('<em><i>&yen;</i>' + te + '</em>起');
//                }
            });
        }, error: function (XMLHttpRequest, textStatus, errorThrown) { alert(XMLHttpRequest.responseText); }
    });
}
function checkPos(fobj, fpos) {
    if ('undefined' == typeof (document.body.style.maxHeight)) {
        var scTop = $(window).scrollTop();
        if (scTop > fpos.top) {
            fobj.css({ 'position': 'absolute', 'z-index': 3, 'top': scTop - fpos.top });
        }
        else {
            fobj.attr('style', '');
        }
        //scTop > fpos.top ? fobj.css({'position': 'absolute', 'z-index': 3, 'top': scTop - fpos.top}) : fobj.attr('style', '');
    }
    else {
        if ($(window).scrollTop() > fpos.top) {
            fobj.css({ 'position': 'fixed', 'z-index': 3, 'top': 0 });
            //$(".zhankuai").show();
            //$(".order").show();
        }
        else {
            fobj.css({ 'position': 'static' });
            //$(".zhankuai").hide();
            //$(".order").hide();
        }
        // ($(window).scrollTop() > fpos.top) ? fobj.css({'position': 'fixed', 'z-index': 3, 'top': 0}) : fobj.css({'position': 'static'});

    }
}
$(document).ready(function() {
    var fobj = $('.pin-wrapper').eq(0);
    var fpos = fobj.offset();
    //$('#total_pirce').html(fpos.top);
    $(window).scroll(function() {
        checkPos(fobj, fpos);
    });

    var tab_a = $('.pin-wrapper .navBox a');
    tab_a.click(function() {
        $(this).addClass('cur').parent().siblings().children(0).removeClass('cur');
        //$(this).siblings().children(0).removeClass('cur');
    });
    
    $(window).scroll(function() {
    var Scroll_tab = $('.pin-wrapper').offset().top; //滚动切换
        $('.itemBox').each(function(i, n) {
            var tab_infor = $(n).offset().top;
            if (tab_infor > 0 && Scroll_tab >= tab_infor - 20) {
                $('.pin-wrapper .navBox a').eq(i).addClass('cur').parent().siblings().children(0).removeClass('cur');
            }
        });
    });
})

function ListUrl(id) {
    var url = location.href;
    var a = id.split('_');
    var tmp;
    if (a[0] == 'tid') {
        if (!url.match(/(\d+)\-(\d+)\.html/ig) == false) {
            location.href = url.replace(/(\d+)\-(\d+)\.html/ig, a[1] + "-$2.html");
            return
        }
    }
    else if (a[0] == 'cid') {
    if (!url.match(/(\d+)\-(\d+)\-(\d+)\.html/ig) == false) {
        location.href = url.replace(/(\d+)\-(\d+)\-(\d+)\.html/ig, a[1] + "-$2-$3.html");
        return
    }
  }
var s = url.indexOf("?");
var Par = s == -1 ? '&' : '&' + url.substring(s + 1) + '&';
for (var i = 0; i < a.length; i += 2) {
    tmp = Par.match(new RegExp("\&" + a[i] + "\=-?(\\d+)?", 'i'));
    if (!tmp) {
        Par += a[i] + '=' + a[i + 1] + '&'
    } else {
    Par = Par.replace(tmp[0] + '&', '&' + a[i] + '=' + a[i + 1] + '&')
  }
}
Par = Par.substring(1, Par.length - 1);
if (s == -1) {
    url += '?' + Par 
}
else {
    url = url.substring(0, s + 1) + Par
}
location = url
}; 
String.prototype.Trim = function() { return this.replace(/^\s+/g, "").replace(/\s+$/g, "") }
