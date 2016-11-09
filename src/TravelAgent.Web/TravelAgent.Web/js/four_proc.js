

function oncontract() {
    $("#formpay").submit();
}
function checkPayType(obj) {
    $("#hdPayType").val(obj.value);
    //微信扫码支付
    if (obj.value == "8") {
        $("#formpay").attr("action", "/wxpay/StaticNative.aspx");
    }
    else {
        $("#formpay").attr("action", "/PayApi/Submit.aspx");
    }
}
function selectTag(showContent, selfObj) {
        // 操作标签
        var tag = document.getElementById("tags").getElementsByTagName("li");
        var taglength = tag.length;
        for (i = 0; i < taglength; i++) {
                tag[i].className = "";
        }
        selfObj.parentNode.className = "nowa_sll";
        // 操作内容
        for (i = 0; j = document.getElementById("tagContent" + i); i++) {
                j.style.display = "none";
        }
        document.getElementById(showContent).style.display = "block";
}
function GetPayGoto(method, t, oid) {
    //var payUrl = "/Order4.aspx?t=" + t + "&oid=" + oid;
    //urlrewrite
    var payUrl = "/Order4.aspx?t=" + t + "&oid=" + oid;
    var orderUrl = "/member/";
    if (t == "line") {
        orderUrl += "LineOrder.aspx";
    }
    else if (t == "visa") {
        orderUrl += "VisaOrder.aspx";
    }
    if (method == "Y") {
        window.location.href = orderUrl;
    }
    else if (method == "N") {
        window.location.href = payUrl;
    }
}

function GetPayStatus(method, orderId) {
        var payUrl = "/book/proc_four/" + orderId;
        var orderUrl = "";
        if (orderId !== "") {
                $.ajax({
                        url: "/Line/GetPayStatus/id/" + orderId,
                        method: "post",
                        error: function(e) {
                                window.location.href = payUrl; //出现错误重新刷新支付页面，让客人重新选择支付方式
                        },
                        success: function(msg) {
                                /*******************************************/
                                //客户选择支付成功
                                if (method === "Y") {
                                        if (msg === "1") {//已支付成功
                                                window.location.href = orderUrl;
                                        } else if (msg === "0") { //实际未支付成功
                                                alert("该订单未支付成功！");
                                                 window.location.href = payUrl;
                                        } else {//订单id参数不正确，重新刷新支付页面
                                                window.location.href = payUrl;
                                        }

                                }
                                /*******************************************/
                                //客户选择支付不成功，重新支付
                                if (method === "N") {
                                        if (msg === "0") { //未支付成功
                                                $("#formpay").submit();
                                        } else if (msg === "1") { //实际已支付成功,导入订单列表
                                                alert("该订单已支付成功！");
                                                window.location.href = orderUrl;
                                        } else {//订单id参数不正确，重新刷新支付页面
                                                window.location.href = payUrl;
                                        }
                                }
                        }
                });
        } else {
                window.location.href = payUrl;
        }

}

function uzOrderPay() {
        $('.bankLogo').each(function(i) {
                $(this).click(function() {
                        var o = $(this);
                        var op = o.parents('td');
                        var ops = op.prev('td.padleft5_sll');
                        $('.bankLogo').removeClass("on").removeAttr("style");
                        o.addClass('on'); //添加外框
                        ops.find('input').click();
                });
        });
        $('.quickBank table tr td input').click(function() {
                var o = $(this);
                var op = o.parent('td');
                var optb = op.parents('.quickBank');
                optb.find('img').removeClass('on').removeAttr("style");
                op.next('td').find('img').addClass('on'); //添加外框
        });
//        $("#channel_amount").blur(function() {
//                var value = parseInt($(this).val());
//                if (isNaN(value) || value <= 0 || value > $("#hdPayMoney").val()) {
//                        $(this).val($("#hdPayMoney").val());
//                } else {
//                        $(this).val(value);
//                }
//        });
        $("#formpay").submit(function() {
            if ($("#hdPayType").val()=="") {
                alert("请选择支付方式！");
                return false;
            }
            //$("#channel_amount").blur();
            $('#OrderStatusPop').jqmShow(); //防错层
            //$("#hdPayMoney").val($("#channel_amount").val());
        });
}

$(function() {
    uzOrderPay();
    $("#chkUsePoints").click(function() {
        if ($(this).attr("checked")) {
            $("#trPoints").show();
        }
        else {
            $("#trPoints").hide();
        }
    })
    $("#txt_points").blur(function() {
        var maxp = parseInt($("#spanMaxPoints").text());
        var curp = parseInt($("#spanCurrentPoints").text());
        if (parseInt($(this).val()) > maxp) {
            alert("输入的积分已经超出当前订单的最高使用积分！");
            $(this).val("");
            return false;
        }
        if (parseInt($(this).val()) > curp) {
            alert("输入的积分已经超出您的积分余额！");
            $(this).val("");
            return false;
        }
        if ($.trim($(this).val()) == "") {
            $(this).val("0");
        }
        $("#spanPointCost").text($(this).val());
        $("#channel_amount").val(parseInt($("#bprice").text()) - parseInt($(this).val()));
    })
});