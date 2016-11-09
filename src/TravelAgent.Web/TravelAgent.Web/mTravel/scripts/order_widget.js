var codeReg = new RegExp(/^(\d{15}$|^\d{18}$|^\d{17}(\d|X|x))$/);
function checkout_totalprice(notBX){
	var adult_price = $('#adult_price').val();
	var child_price = $('#child_price').val();

	var baoxian_price = $("#bx_price").val();
	
	var adult_num = $('#pr_d_num').val();
	var child_num = $('#pr_child_num').val();
	if (notBX) $("#pr_bx_num").val(parseInt(adult_num) + parseInt(child_num));
	var baoxian_num = $("#pr_bx_num").val();
	//var dingjin = $('#dingjin').val();
	var total_price = Number(adult_price * adult_num) + Number(child_price * child_num) + Number(baoxian_price*baoxian_num);
	//var total_dingjin = Number(dingjin * adult_num);
	$('#total_price').text(total_price);
	//$('#total_dingjin').text(total_dingjin);
	$('#totalprice').val(total_price);

}
function checkout_totalprice1() {
    var adult_price = $('#adult_price').val();
    var child_price = $('#child_price').val();
    var baoxian_price = $("#bx_price").val();

    var adult_num = $('#pr_d_num').val();
    var child_num = $('#pr_child_num').val();
    var baoxian_num = $("#pr_bx_num").val();
    //var dingjin = $('#dingjin').val();
    var total_price = Number(adult_price * adult_num) + Number(child_price * child_num) + Number(baoxian_price * baoxian_num);
    //var total_dingjin = Number(dingjin * adult_num);
    $('#total_price').text(total_price);
    //$('#total_dingjin').text(total_dingjin);
    $('#totalprice').val(total_price);

}
document.addEventListener('touchend',function(e){
	if(e.target.className.match(/plus-active/)){
		var ty = e.target.getAttribute('data-type');
		if(ty == 'adults'){
			var $ele = $('#pr_d_num');
			$ele.val(Number($ele.val())+1);
			checkout_totalprice(true);
		}else if(ty == 'teens'){
			var $ele = $('#pr_child_num');
			$ele.val(Number($ele.val())+1);
			checkout_totalprice(true);
		} else if (ty == 'baox') {
		    var $ele = $('#pr_bx_num');
		    $ele.val(Number($ele.val()) + 1);
		    checkout_totalprice();
		}
		
	}else if(e.target.className.match(/minus-active/)){
		var ty = e.target.getAttribute('data-type');
		if(ty == 'adults'){
			var $ele = $('#pr_d_num');
			if($ele.val()<=0)return;
			$ele.val(Number($ele.val())-1);
			checkout_totalprice(true);
		}else if(ty == 'teens'){
			var $ele = $('#pr_child_num');
			if($ele.val()<=0)return;
			$ele.val(Number($ele.val())-1);
			checkout_totalprice(true);
        }
        else if (ty == 'baox') {
            var $ele = $('#pr_bx_num');
            if ($ele.val() <= 0) return;
            $ele.val(Number($ele.val()) - 1);
            checkout_totalprice();
        }
	}
},false);

//$("#pr_d_num").bind('input',function(){
//	var adult_num = $('#pr_d_num').val();
//	//if(adult_num>0)$("#pr_d_num").prev('.minus').removeClass('minus-disabled').addClass('minus-active');
//	//if(adult_num<=0)$("#pr_d_num").prev('.minus').removeClass('minus-active').addClass('minus-disabled');
//	checkout_totalprice(true);

//});

//$("#pr_child_num").bind('input',function(){
//	var child_num = $('#pr_child_num').val();
//	//if(child_num>0)$("#pr_child_num").prev('.minus').removeClass('minus-disabled').addClass('minus-active');
//	//if(child_num<=0)$("#pr_child_num").prev('.minus').removeClass('minus-active').addClass('minus-disabled');
//	checkout_totalprice(true);
//});

//$("#pr_bx_num").bind('input', function() {
//    var child_num = $('#pr_bx_num').val();
//    //if (child_num > 0) $("#pr_bx_num").prev('.minus').removeClass('minus-disabled').addClass('minus-active');
//    //if (child_num <= 0) $("#pr_bx_num").prev('.minus').removeClass('minus-active').addClass('minus-disabled');
//    checkout_totalprice();
//});
/*
根据出发日期价钱相应变化
*/
$('#calendar').on('click','a.valuable',function(e){
    var price = e.currentTarget.getAttribute('data_price_d'),
	    child_price = e.currentTarget.getAttribute('data_price_child_d'),
	    date = e.currentTarget.getAttribute('data_date');
	$('#adult_price').val(price);
	$('#adult_price_span').html('￥'+price);
	$('#child_price').val(child_price);
	$('#child_price_span').html('￥'+child_price);
	$('#start_time').val(date);
	$('#start_date').html(date);
	location.hash = '';
	checkout_totalprice();
});
$(".order-xuyao li a").click(function(){
	$(this).toggleClass('xuyao-active');
})
$("#save").click(function() {
    var regexp = /^1[3,4,5,8,7][0-9]\d{8}$/;
    if ($("#total_price").text() == "0") {
        alert("订单金额为0！");
        return false;
    }
    else if ($("#ordertime").val() == '') {
        $(".error_tip").text("游玩日期为必须填写项！");
        $(".error_tip").show();
        return false;
    }
    else if ($("#user").val() == '') {
        $(".error_tip").text("联系人为必须填写项！");
        $(".error_tip").show();
        return false;
    }
    else if ($("#user").val().length < 2) {
        $(".error_tip").text("联系人过短，请重新输入！");
        $(".error_tip").show();
        return false;
    }
    else if ($("#phone").val() == '') {
        $(".error_tip").text("手机号码为必须填写项！");
        $(".error_tip").show();
        return false;
    }
    else if ($("#user").val().length > 10) {
        $(".error_tip").text("联系人长度仅限10个字符，请重新输入！");
        $(".error_tip").show();
        return false;
    }
    else if ($("#phone").val().length != 11 || !regexp.test($("#phone").val())) {
        $(".error_tip").text("手机号码不正确，请重新输入！");
        $(".error_tip").show();
        return false;
    }
    else if (!codeReg.test($("#IDcard").val())) {
        $(".error_tip").text("请正确填写身份证号码！");
        $(".error_tip").show();
        return false;
    }
    else if ($("#tuijianren").val().length < 2) {
        $(".error_tip").text("请填写推荐人！");
        $(".error_tip").show();
        return false;
    }
})
$(function(){
    var or_pr_n=$(".order-txt-m");
    var xz_d=$(".order-xuanz");
    xz_d.click(function(){
    	xz_d.hide();
    	or_pr_n.show().val(" ");
    })
    or_pr_n.bind({
        blur:function(){
        	var xz_d_val=or_pr_n.val();
        	xz_d.html('￥ <span></span> / 人');
        	xz_d.find('span').html(xz_d_val);
        	or_pr_n.hide();
        	xz_d.show();
        }
    })
    checkout_totalprice();
})