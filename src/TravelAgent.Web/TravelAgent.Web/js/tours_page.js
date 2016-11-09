//滚动导航
$(function() {
        var fobj = $('.pkg-detail-tab').eq(0);
        var fpos = fobj.offset();
        //$('#total_pirce').html(fpos.top);
        $(window).scroll(function() {
                checkPos(fobj, fpos);
        });
});

function checkPos(fobj, fpos)
{
        if ('undefined' == typeof(document.body.style.maxHeight))
        {
                var scTop = $(window).scrollTop();
                if (scTop > fpos.top)
                {
                    fobj.css({ 'position': 'absolute', 'z-index': 3, 'top': scTop - fpos.top });
                }
                else
                {
                    fobj.attr('style', '');
                }
                //scTop > fpos.top ? fobj.css({'position': 'absolute', 'z-index': 3, 'top': scTop - fpos.top}) : fobj.attr('style', '');
        }
        else {
            if ($(window).scrollTop() > fpos.top) {
                fobj.css({ 'position': 'fixed', 'z-index': 3, 'top': 0 });
                //$(".zhankuai").show();
                $(".order").show();
            }
            else {
                fobj.css({ 'position': 'static' });
                //$(".zhankuai").hide();
                $(".order").hide();
            }
           // ($(window).scrollTop() > fpos.top) ? fobj.css({'position': 'fixed', 'z-index': 3, 'top': 0}) : fobj.css({'position': 'static'});
                
        }
}


$(function() {
        var tab_a = $('.pkg-detail-tab-bd a');
        tab_a.click(function() {
                $(this).addClass('current').siblings().removeClass('current');
        });
        $(window).scroll(function() {
                var Scroll_tab = $('.pkg-detail-tab-bd').offset().top;//滚动切换
                $('.pkg-detail-infor').each(function(i, n) {
                        var tab_infor = $(n).offset().top;
                        if (tab_infor > 0 && Scroll_tab >= tab_infor - 20) {
                                $('.pkg-detail-tab-bd a').eq(i).addClass('current').siblings().removeClass('current');
                        }
                });
        });
});

// 起价说明
function priceinfo() {
        var top = $("#show_priceinfo").offset().top;
        var left = $("#show_priceinfo").offset().left;
        var html = "<div style='width:240px; border:1px solid #815A30; background:#ffffff; text-align:left; padding:8px; line-height:20px; color:#815A30'>";
        html += "本起价是可选出发日期中，按双人出行共住一间房核算的最低单人价格。产品价格会根据您所选择的出发日期、出行人数、入住酒店房型、航班或交通以及所选附加服务的不同而有所差别。具体价格请咨询：" + $("#show_priceinfo").attr('telephone');
        html += "</div>";
        var div = document.createElement('div');
        div.id = 'div_show_info';
        div.style.position = 'absolute';
        div.style.zIndex = 3000;
        div.style.top = (top + 18) + 'px';
        div.style.left = (left + -50) + 'px';
        div.innerHTML = html;
        document.body.appendChild(div);
}
function priceinfoclose() {
        $("#div_show_info").remove();
}

function priceinfo2() {
        var top = $("#text_priceinfo").offset().top;
        var left = $("#text_priceinfo").offset().left;
        var html = "<div style='width:240px; border:1px solid #815A30; background:#ffffff; text-align:left; padding:8px; line-height:20px; color:#815A30'>";
        html +=  $("#text_priceinfo").attr('telephone');
        html += "</div>";
        var div = document.createElement('div');
        div.id = 'div_text_info';
        div.style.position = 'absolute';
        div.style.zIndex = 3000;
        div.style.top = (top + 18) + 'px';
        div.style.left = (left + -50) + 'px';
        div.innerHTML = html;
        document.body.appendChild(div);
}
function priceinfo2close() {
        $("#div_text_info").remove();
}