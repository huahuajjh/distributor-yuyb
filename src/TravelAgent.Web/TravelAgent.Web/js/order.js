function initPage() {
        uzTab("orderProtocol"); //TAB协议
        uzOrderUserNameDrop(); //用户名下拉
        uzOrderCloseAllTips(); //关于用户名下拉列表，日历
        uzOrderTip();
        uzOrderPay();
        uzOrderRemark()//备注文字
        uzOrderStep2Submit();
        uzOrderList(); //预订清单
        closeNote();
        if ($('#OrderStatusPop').get(0) != null) {
                $('#OrderStatusPop').jqm({modal: true, overlay: 30}); //防错层
        }
}

//浮动提示
function uzOrderInputTipReady() {
        //页面初始化
        var floatInput = $('.floatTip').prev('input');
        $.each(floatInput, function(k, v) {
                var o = $(this);
                if (o.val() == '') {
                        o.next('.floatTip').show();
                }
                else {
                        o.next('.floatTip').hide();
                }
        });


        $('.floatTip').prev('input').blur(function() {
                var o = $(this);
                if (o.val() == '') {
                        o.next('.floatTip').show();
                }
        });

        $('.floatTip').click(function() {
                var o = $(this);
                o.hide();
                o.prev('input').focus();
        });

        $('.floatDiv').click(function() {
                $(this).find('.floatTip').hide();
        });

}

function uzOrderTip() {

        if ($('.tip') != null) {
                $('.tip').ToolTip({
                        xOffset: -10, //左偏移量
                        yOffset: 0, //上偏移量
                        defaultHtml: null, //默认html节点
                        speed: 300, //显示速度
                        trigger: 'hover', //触发事件hover/click
                        mousemove: true, //是否触发mousemove事件
                        arrow: false, //是否显示箭头 bLeft,bRight
                        popWinID: "#Tooltip"   //popWinID
                });
        }
}

//右侧订单列表
function uzOrderList() {

        $('.orderList>.hd>span').click(function() {
                var o = $(this);
                var p = o.parent('.hd').next('.bd').find('ul');
                if (p.css('display') == 'block') {
                        o.addClass('close');
                        p.slideUp('slow');
                }
                else {
                        o.removeClass('close');
                        p.slideDown('slow');
                }
        });

        //去除原先的scrollfllow.js  new
        if ($('div.orderList').get(0) != null) {
                window.onscroll = function() {
                        var w = $("body").width() / 2 + 248;
                        var orderlist = $('div.orderList');
                        var pos = $(document).scrollTop();
                        var binfo = "";
                        var postop = 180;
                        if (pos > postop) {
                                orderlist.css({'position': 'fixed', 'top': 0, 'z-index': '1', 'left': w});
                        }
                        else if (pos <= postop) {
                                orderlist.css({'position': 'relative', 'top': 0, 'left': 0});
                        }
                }
        }

}


//Tab
function uzTab(obj) {
        $("." + obj + ">.hd>ul>li").click(function() {
                var o = $(this);
                var objPa = o.parent('ul');
                var objSib = objPa.find('li');
                var index = objSib.index(o);
                objSib.removeClass('on');
                o.addClass('on');

                var objItemList = objPa.parent('.hd').siblings('.bd');
                objItemList.find('.item').hide();
                objItemList.find('.item').eq(index).show();

                $(this).find('a').blur();
                return false;
        });
}



function uzOrderUserNameDrop() {

        if ($('.guestInputList').find('ul').find('li').size() <= 0) {
                $('.guestInputList').find('ul').remove();
        }

        $('.guestInputList').find('input').val('');


        $('.guestInputList').click(function() {
                $(this).find('ul').show();
        });

        $('.guestInputList>ul>li>a').click(function() {
                var o = $(this);
                var oT = o.parents('ul').siblings('input.input1');
                //var oV = o.text();
                var oV = $.trim(o.attr("username"));
                oT.val($.trim(oV));
                o.parents('ul').hide().siblings('.floatTip').hide();
                return false;
        });
}


function uzOrderCloseAllTips() {
        $(document).click(function(e) {
                var t = $(e.target);
                var v1 = ".guestInputList,.guestInputList *";
                if (!t.is(v1)) {
                        $('.guestInputList').find('ul').hide();
                }
        });
}

function uzOrderPay() {
        $('.zftable_sll table tr td img').click(function() {
                var o = $(this);
                var op = o.parent('td');
                var optb = op.parents('table');
                var ops = op.prev('td.padleft5_sll');
                optb.find('img').removeClass('on');
                o.addClass('on'); //添加外框
                ops.find('input').click();
        });
        $('#imgCMB').click(function() {
                $('.zftable_sll table tr td img').removeClass('on');
                $(this).addClass('on');
                $('#bankradio_CMB').click();
        });

        $('.zftable_sll table tr td input').click(function() {
                var o = $(this);
                var op = o.parent('td');
                var optb = op.parents('table');
                optb.find('img').removeClass('on');
                op.next('td').find('img').addClass('on'); //添加外框
        });
}


function uzOrderStep2Submit() {
        $('.userInfoBtn input').click(function() {

        });
}

function uzOrderRemark() {
        _uzaiDP.review.dpInit();
}

_uzaiDP = {};
_uzaiDP.review = {
        t: 0,
        dpCheck: function() {
                var o = $("#txtReview");
                var oVal = o.val();
                var oValTrim = $.trim(oVal);
                if (oVal.length > 200) {
                        $("#lbCode").text("已经超过");
                        $("#eCodeLeft").removeClass().addClass('disable').text((oValTrim.length) - 200);
                        $("#reviewSubmit").removeClass().addClass('disable');
                        return false;
                        //alert('标识：超过');
                }
                else {
                        $("#lbCode").text("还可以输入");
                        $("#eCodeLeft").removeClass().addClass('enable').text(200 - (oValTrim.length));
                        $("#reviewSubmit").removeClass().addClass('enable');
                }
        },
        clearTime: function() {
                clearTimeout(this.t);
        },
        runTime: function() {
                _uzaiDP.review.dpCheck();
                this.t = setTimeout("_uzaiDP.review.runTime()", 1 * 10);
        },
        dpInit: function() {
                $("#txtReview").val('');
                $("#txtReview").bind("blur", function() {
                        if ($('#txtReview').val().length >= 1) {
                                $('#initReview').hide();
                        }
                        else {
                                $('#initReview').show();
                        }
                        _uzaiDP.review.clearTime();
                });
                $("#txtReview").bind("focus", function() {
                        $('#initReview').hide();
                        _uzaiDP.review.runTime();
                });
        }
}


function closeNote() {
        $('#closeNotice').click(function() {
                var o = $(this);
                var oP = $(o).parent();
                $(oP).hide();
        });
}
;

initPage();

$(function() {
        $("#ImageButton1_Ali_ZFQR").html("");
        $(".zhxx_sll a").html("");
});