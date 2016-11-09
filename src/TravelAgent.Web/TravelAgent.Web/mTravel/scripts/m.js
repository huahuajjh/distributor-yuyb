$(function(){
     $("#close").click(function(){
        $("#suggestion").slideUp();
    });
    //首页图片滚动
    var len  = $("#m_num > a").length;
    var index = 0;
    var adTimer;
    $("#m_num > a").mouseover(function(){
        index  =   $("#m_num > a").index(this);
        showImg(index);
    });
    //鼠标事件绑定
    $('#focus_pic').hover(function(){
        clearInterval(adTimer);
    },function(){
        adTimer = setInterval(function(){
            showImg(index)
            index++;
            if(index==len){
                index=0;
            }
        } , 20000);
    }).trigger("mouseleave");
    //获取焦点图滚动
    function showImg(index){
        //var adHeight = $("#focus_pic").height();
        $("#focus_pic").attr("class","m_sloder m_s_show_"+index).stop(true,false);
        $("#focus_pic > ul > li").eq(index).attr("class","m_s_li_"+index).siblings().removeClass();
        $("#m_num > a").removeClass("on").eq(index).addClass("on");
        $(".m_sloder_tit").html($("#focus_pic > ul > li").eq(index).find("img").attr("alt"))
    }
    //栏目固定
    var fixTop = function() {
        var st = $(document).scrollTop();
		if(st > 200){
                        $("#des_w").addClass("topfix");
                    }
                    else{
                        $("#des_w").removeClass("topfix");
                    }
        };
    $(window).bind("scroll", fixTop);
    //$(function() {fixTop();});
    //首页搜索类型切换
    $('#m_change_type').click(function(){
        if($(this).parent().attr('class')=='m_search_l'){
            $(this).parent().addClass('m_search_on');
        }else{
            $(this).parent().removeClass('m_search_on');
        }
    })
    $('#m_ct_con > a').click(function(){
        $('#m_change_type').html($(this).html());
        $("#m_h_v").val($(this).attr("index"));
        $('#m_change_type').parent().removeClass('m_search_on');
    })
    //各栏目切换
    $.myPlugin = {
        tab : function(control,show,_class){
            $(control + "> li").each(function(){
                $(this).click(function(){
                    var c = $(control + "> li").index($(this));
                    $(this).addClass(_class).siblings().removeClass(_class);
                    $(show + "> div").eq(c).show().siblings().hide();
                })
            })
        },
        tab_other : function(control,show,_class){
            $(control + "> li").each(function(){
                $(this).click(function(){
                    var c = $(control + "> li").index($(this));
                    $(this).addClass(_class).siblings().removeClass(_class);
                        $(show + "> div").eq(c).find('li').each(function(i){
                            if(i>2){$(show + " > div").eq(c).find('li').eq(i).hide();}
                        })
                    $(show + "> div").eq(c).show().siblings().hide();
                    if($(".m_jd_more").css('display')=='none'){$(".m_jd_more").show()}
                })
            })
        }
    }
    $.myPlugin.tab("#m_des_w","#m_des_cont","on");
    $.myPlugin.tab_other("#m_des_w_other","#m_des_cont_other","on");
    
    //更多资讯
    $(".m_jd_more a").click(function(){
        $('#m_des_cont_other > div').each(function(){
            if($(this).css('display')=='none'){
                $(this).siblings().find("li").each(function(){$(this).css("display",'-webkit-box')})
            }
        })
        $('.m_jd_more').hide();
    })
    var transition =function(){};
    transition.prototype = {
        height : function(id,uid){//touchstart
            $(id+" > li").bind('click',function(){
              $('body,html').animate({scrollTop:0},500);
                var h = $(document).height();
                var c = $(id+" > li").index($(this));
                $('.pop_bg').bind('click',function(){
                    $(id+" > li").eq(c).removeClass('on');
                    $(uid+" > div").eq(c).css('height','0');
                    $(this).hide();
                })
                if($(uid+" > div").eq(c).css('height')=='0px'){
                    $('.pop_bg').css({height:h+45}).show();
                    $(this).addClass('on').siblings().removeClass('on');
                    $(uid+" > div").eq(c).css('height',$(uid+" > div").eq(c).find('p').length*55).siblings().css('height','0');
            }
                else{
                    $(this).removeClass('on');
                    $(uid+" > div").eq(c).css('height','0');
                    $('.pop_bg').hide();
                }
            })
        },
        heightM : function(id,uid){//touchstart
            $(id+" > li").bind('click',function(){
              $('body,html').animate({scrollTop:0},500);
                var h = $(document).height();
                var c = $(id+" > li").index($(this));
                if(c<3){return}
                $('.pop_bg').bind('click',function(){
                    $(id+" > li").eq(c).removeClass('on');
                    $(uid+" > div").eq(c).css('height','0');
                    $(this).hide();
                })
                if($(uid+" > div").eq(c).css('height')=='0px'){
                    $('.pop_bg').css({height:h+45}).show();
                    $(this).addClass('on').siblings().removeClass('on');
                    $(uid+" > div").eq(c).css('height',$(uid+" > div").eq(c).find('p').length*55).siblings().css('height','0');
            }
                else{
                    $(this).removeClass('on');
                    $(uid+" > div").eq(c).css('height','0');
                    $('.pop_bg').hide();
                }
            })
        }
    }
    var tran = new transition();
    tran.height('#des_w',"#des_con");
    tran.heightM('#des_w_m',"#des_con_gl_m");

    //根据类型选择相应变化日期价钱
    $('#type_id').change(function(){
        var type_id = $('#type_id').val();
        var r_url = $(this).parents("form").attr('ajax-requet-url')+'&type_id='+type_id;
        $.ajax({
            type: "get",
            dataType: "json",
            url: r_url,
            success: function(data){
                $('#start_time').empty();
                for(var i in data.price){
                    $('<option>').attr('value',i).attr('price_d',data.price[i].price_d).attr('price_child_d',data.price[i].price_child_d).text(i+'(￥'+data.price[i].price_d+')').appendTo('#start_time');
                }
                $("#adult_price").html("成人<em>"+data.price[i].price_d+"</em>元/人 ");
                $("#child_price").html("儿童<em>"+data.price[i].price_child_d+"</em>元/人")
            }
        })
    })
    //根据出发日期价钱相应变化
    $('#start_time').change(function(){
            var pr_d = $(this).find("option:selected").attr('price_d');
            var pr_child_d = $(this).find("option:selected").attr('price_child_d');
            $("#adult_price").html("成人<em>"+pr_d+"</em>元/人 ");
            if(pr_child_d =='0'){
                return false;
            }
            else{
                $("#child_price").html("儿童<em>"+pr_child_d+"</em>元/人");
            }
    })

    $("#pr_d_num").bind('input',function(){
        var num = $("#pr_d_num").val();
        var num_child = $("#pr_child_num").val();
        var pr_d = $('#start_time').find("option:selected").attr('price_d');
        var pr_child_d = $('#start_time').find("option:selected").attr('price_child_d');
        var all = Number(pr_d*num)+Number(pr_child_d*num_child);
        $("#get_price").attr('value',all);
        $(".price").html("总计：<em>"+all+"</em>");
    })
    $("#pr_child_num").bind('input',function(){
        var num = $("#pr_d_num").val();
        var num_child = $("#pr_child_num").val();
        var pr_d = $('#start_time').find("option:selected").attr('price_d');
        var pr_child_d = $('#start_time').find("option:selected").attr('price_child_d');
        var all = Number(pr_d*num)+Number(pr_child_d*num_child);
        $("#get_price").attr('value',all);
        $(".price").html("总计：<em>"+all+"</em>元");
    })

    //报价下一步
    $("#order-next").click(function(){
       if( $("#pr_d_num").val()=='' &&  $("#pr_child_num").val()==''){
           alert('参团人数没有填写！')
       }
       else{
           $("#order-next-m").hide();
           //setTimeout(function(){$("#order-con").show();alert(1)},2000);
           $("#order-con").show();
       }
    })
    //返回订单
    $("#backPrice").click(function(){
        $("#order-con").hide();
        $("#order-next-m").show();
    })
    //验证
//    function pos(id,msg){
//        $(id).addClass('error');
//        var _div = $('<div class="error-tit" id="error"></div>')
//        $(_div).appendTo($(id).parents('.order-m')).html(msg);
//        var _pos = $(id).parents('li').position();
//        var h = $(id).parents('li').height();
//        $(_div).css('top',_pos.top+h+20);
//        $(_div).css("left",'0').show();
//        setTimeout(function(){$(_div).remove();$(id).removeClass('error')},5000);
//    }

    $("#save").click(function(){
        var regexp = /^1[3|4|5|8][0-9]\d{8}$/;
        if($("#user").val() ==''){
            alert("联系人为必须填写项");
           // pos("#user",'联系人为必须填写项');
			return false;
        }
        else if($("#user").val().length <2){
            alert("联系人过短，请重新输入");
           // pos("#user",'联系人过短，请重新输入');
			return false;
        }
        else if($("#phone").val() ==''){
            alert("手机号码为必须填写项");
            //pos("#phone",'手机号码为必须填写项');
			return false;
        }
        else if($("#user").val().length>10){
            alert("联系人长度仅限10个字符，请重新输入");
           // pos("#user",'联系人长度仅限10个字符，请您重新输入');
			return false;
        }
        else if($("#phone").val().length!=11 || !regexp.test($("#phone").val())){
            alert("手机号码不正确，请重新输入");
            //pos("#phone",'手机号码不正确，请您重新输入');
			return false;
        }
        else if(! new RegExp(/^([a-zA-Z0-9_-])+@([a-zA-Z0-9_-])+(.[a-zA-Z0-9_-])+/).test($("#mail").val()) && $("#mail").val()!=''){
            alert("邮箱格式不正确，请重新输入");
            //pos("#mail",'邮箱格式不正确，请重新输入');
			return false;
        }
        else if(new RegExp(/[^\d]/g).test($("#qq").val()) && $("#qq").val()!=''){
            alert("QQ号码不正确，请重新输入");
            //pos("#qq",'QQ号码不正确，请重新输入');
			return false;
        }
        else if(new RegExp(/[^0-9\-,， ]+/).test($("#tell").val()) && $("#tell").val()!=''){
            alert("电话号码不正确，请重新输入");
            //pos("#tell",'电话号码不正确，请重新输入');
			return false;
        }
        //window.loading_dialog.loadingDialogOnAndroid()
    })

    
    //线路闲情默认第一个打开
     $(".line-i-c").eq(0).css("height",'auto');
     $(".J_line_w").eq(0).find('.roat').addClass("on");
    //线路详情
    //touchstart
    $(".J_line_w").bind('click',function(){
        if($(this).siblings().css('height')=='0px'){
            $(this).find('img.roat').addClass('on');
            var siblings_h = $(this).siblings().find('div.line-i-c-h').height()+20;
            $(this).siblings().css('height',siblings_h);
            //alert($(document).scrollTop())
            $('body,html').animate({scrollTop:$(this).offset().top},500);
    }
        else{
            $(this).find('img.roat').removeClass('on');
            $(this).siblings().css('height','0px');
        }
    });
    
    
    
	//ajax 加载页面
	$("#for-ajax").live('click', function() {
        $(".load_more").show();
        var page = parseInt($('.J_page_num').val(),10);
        page=page+1;
		var r_url = 'line/channel_list_ajax?typeid=1&page='+page;
        $('.J_page_num').val(page);
        console.log(page)
		$("#for-ajax").hide();
		$.get(r_url, function(data){
        	if(data==''){
            	alert("网络连接错误");
                $(".load_more").hide();
            }else{
				$(".load_more").remove();
                // $("#for-ajax").replaceWith('<div class="load_more"><img src="../imgs/loading.gif" /> 正在载入中</div>');
				$("#for-ajax").replaceWith(data);
            
                $(".load_more").hide();
            }
        });
	})
	
	//操作结果提示
	$("#for-check-status").fadeOut(2000);
	
	$("#add_fav").click(function(){
		var r_url = $(this).attr("index");
		$.get(r_url, function(data){
			if(data=='1'){
				alert("收藏成功");
			}else if(data=='-3'){
				alert("您已经收藏过了");
			}else if(data=='-1'){
				alert("请先登录");
				var ihref = encodeURIComponent(document.URL);
				location.href = "/?c=account&m=login&forward="+ihref;
			}
		});		
	})
	
	$("#for-logout").live('click', function() {
		var r_url = $(this).attr("index");
		$.get(r_url, function(data){
			location.href="/?c=account&m=login";
		});		
	})
	
	$(".cancel-fav").live('click', function() {
		var current  = $(this);
		var r_url = $(this).attr("index");
		$.get(r_url, function(data){
			if(data=='1'){
				alert("取消成功");
				current.parents(".fav-m").remove();
			}else if(data=='-2'){
				alert("取消失败");
			}else if(data=='-1'){
				alert("请先登录");
				var ihref = encodeURIComponent(document.URL);
				location.href = "/?c=account&m=login&forward="+ihref;
			}
		});		
	})
        //订单取消
	$(".cancel-order").live('click', function() {
		if (confirm("您确定要取消订单吗？")) {
                    var current = $(this);
                    var r_url = $(this).attr("index");
                    $.get(r_url, function(data){
                            if (data == '1') {
                                    alert("取消成功");
                                    $(".for-status").html("已取消");
                                    if ($(".for-status").hasClass("order-status-0")) {
                                            $(".for-status").removeClass("order-status-0");
                                            $(".for-status").addClass("order-status-4");
                                    }
                                    current.remove();
                            }else if (data == '-2') {
                                    alert("取消失败");
                            }else if (data == '-1') {
                                    alert("请先登录");
                                    var ihref = encodeURIComponent(document.URL);
                                    location.href = "/?c=account&m=login&forward=" + ihref;
                            }
                    });
		}
      //window.dialog.dialogOnAndroid($(".cancel-order"));
	})
//        function cancelOrder(t){
//                    var current = t;
//                    var r_url = current.getAttribute('index');
//                    $.get(r_url, function(data){
//                            if (data == '1') {
//                                    alert("取消成功");
//                                    $(".for-status").html("已取消");
//                                    if ($(".for-status").hasClass("order-status-0")) {
//                                            $(".for-status").removeClass("order-status-0");
//                                            $(".for-status").addClass("order-status-4");
//                                    }
//                                    current.remove();
//                            }else if (data == '-2') {
//                                    alert("取消失败");
//                            }else if (data == '-1') {
//                                    alert("请先登录");
//                                    var ihref = encodeURIComponent(document.URL);
//                                    location.href = "/?c=account&m=login&forward=" + ihref;
//                            }
//                    });
//        }
//        $("#cancel_order").live('click', function() {
//
//            window.dialog.dialogOnAndroid();
//	})
        
        $('.order-txt').click(function(){
            $(this).css('border','none');
        })


        $("#mobiletel").bind("input",function(){
            if($(this).val().length==11){
                $('#getcode').removeClass('no-disable').addClass("get-code").attr('disabled',false);
            }
            else{
                $('#getcode').removeClass('get-code').addClass("no-disable").attr('disabled',true);
            }
        })
	$("#codeform #getcode").click(function(){
		var tel = $("#codeform #mobiletel").val();
                var idtype = $("#codeform #idtype").val();
		if(tel==''){
			alert("请先输入手机号码");
			return false;
		}
		var partten = /^1[3|4|5|8][0-9]\d{8}$/;
		if (tel.length != 11 || !partten.test(tel)) {
			alert("手机号码不正确，请您重新输入");
			return false
		}
		r_url = "/?c=account&m=getcode&inajax=1&mobiletel="+tel+"&idtype="+idtype;
		$.get(r_url, function(data){
			if(data=='1'){alert("短信已发送，请查看");}
			else if(data=='-1'){alert("获取失败，手机号码不能为空");}
			else if(data=='-2'){alert("获取失败，手机号码错误");}
			else if(data=='-3'){alert("获取失败，该手机已被注册");}
			else if(data=='-4'){alert("您的操作太频繁，请稍候再试");}
            else if(data=='-5'){alert("该手机用户不存在");}
			else{alert("获取失败");}
			//这里做六十秒倒计时
		});
	})
    //
   	$("#loginform").click(function(){
		var ajaxurl = $(this).parents("form").attr("ajaxurl");
		var username = $("input[name='username']").val();
		var password = $("input[name='password']").val();
		var forward = $("input[name='forward']").val();
		if(username==''){
			alert("用户名和密码不能为空");
			$("input[name='username']").focus();
			return false;
		}
		if(password==''){
			alert("用户名和密码不能为空");
			$("input[name='password']").focus();
			return false;
		}
	    
            $.post(ajaxurl, {
	        username: username,
	        password: password
	    }, function(data){
			if(data=='5'){
                //window.loading_dialog.dialogOnAndroid("正在登录，请稍候");
                alert("登录成功");
				if(forward==''){
					location.href="/?c=account&m=account";
					return;
				}else{
					location.href=decodeURIComponent(forward);
					return;
				}
			}else if(data=='4'){
				alert("用户名和密码不能为空");
			}else if(data=='1'){
				alert("用户名不存在");
			}else if(data=='2'){
                                alert("密码不正确");
			}else if(data=='3'){
				alert("登录失败");
			}else{
				alert("登录失败");
			}
	    });
	})

	$("#editpwdform").click(function(){
		var ajaxurl = $(this).parents("form").attr("ajaxurl");
		var oldpwd = $("input[name='oldpwd']").val();
		var password = $("input[name='password']").val();
		var password2 = $("input[name='password2']").val();
		if(oldpwd==''){
			alert("请输入旧密码");return false;
		}
		if(password==''){
			alert("请输入新密码");return false;
		}
		if(password2==''){
			alert("请再次输入新密码");return false;
		}
		if(password.length<6||password.length>16){
			alert("密码长度应为6~16个字符");return false;
		}
		if(password!=password2){
			alert("两次输入的密码不相同");return false;
		}
	    $.post(ajaxurl, {
	        oldpwd: oldpwd,
	        password: password,
	        password2: password2
	    }, function(data){
			if(data=='1'){
				alert("修改成功");
				location.href="/?c=account&m=account";
			}else if(data=='2'){
				alert("输入的旧密码有误");
			}else if(data=='3'){
				alert("Email格式有误");
			}else if(data=='4'){
				alert("不允许注册");
			}else if(data=='5'){
				alert("该 Email已经被注册 ");
			}else if(data=='6'){
				alert("填写不完整");
			}else if(data=='7'){
				alert("两次输入的密码不相同");
			}else if(data=='8'){
				alert("密码长度应为6~16个字符");
			}else if(data=='9'){
				alert("密码不合法");
			}else if(data=='10'){
				alert("请先登录");
				location.href="/?c=account&m=login";
			}else{
				alert("修改失败");
			}
	    });
	})

	$("#regform").click(function(){
		var ajaxurl = $(this).parents("form").attr("ajaxurl");
		var mobiletel = $("input[name='mobiletel']").val();
		var password = $("input[name='password']").val();
		var code = $("input[name='code']").val();
		var forward = $("input[name='forward']").val();
		if(mobiletel==''){
			alert("请输入手机号码");return false;
		}
		if(password==''){
			alert("请输入密码");return false;
		}
		if(code==''){
			alert("请输入6位验证码");return false;
		}
		if(password.length<6||password.length>16){
			alert("密码长度应为6~16个字符");return false;
		}
		var partten = /^1[3|4|5|8][0-9]\d{8}$/;
		if (mobiletel.length != 11 || !partten.test(mobiletel)) {
			alert("请输入正确的手机号码");
			return false
		}
	    $.post(ajaxurl, {
	        mobiletel: mobiletel,
	        password: password,
	        code: code
	    }, function(data){
			if(data==14){
				alert("恭喜您，您已经成功注册为欣欣会员");
				if(forward==''){
					location.href="/?c=account&m=account";
					return;
				}else{
					location.href=decodeURIComponent(forward);
					return;
				}
			}else if(data=='1'){
				alert("请输入正确的手机号码 ");
			}else if(data=='2'){
				alert("密码长度应为6~16个字符");
			}else if(data=='3'){
				alert("密码不合法");
			}else if(data=='4'){
				alert("密码不一致 ");
			}else if(data=='5'){
				alert("邮箱不正确 ");
			}else if(data=='6'){
				alert("邮箱被使用");
			}else if(data=='7'){
				alert("用已个IP一天只能注册一个帐号");
			}else if(data=='8'){
				alert("注册失败");
			}else if(data=='9'){
				alert("邮箱禁止注册");
			}else if(data=='10'){
				alert("手机号码已被使用");
			}else if(data=='11'){
				alert("不允许注册的词语");
			}else if(data=='12'){
				alert("手机号码不能为空");
			}else if(data=='13'){
				alert("验证码错误");
			}else if(data=='16'){
				alert("未知请求");
				location.href="/?c=account&m=login";
			}else if(data=='15'){
				alert("您已经有帐户了");
				if(forward==''){
					location.href="/?c=account&m=account";
					return;
				}else{
					location.href=decodeURIComponent(forward);
					return;
				}
			}else{
				alert("注册失败");
			}
		})
	});

	$("#forgetform").click(function(){
		var ajaxurl = $(this).parents("form").attr("ajaxurl");
		var mobiletel = $("input[name='mobiletel']").val();
		var password = $("input[name='password']").val();
		var password2 = $("input[name='password2']").val();
		var code = $("input[name='code']").val();
		if(mobiletel==''){
			alert("请输入手机号码");return false;
		}
		if(password==''){
			alert("请输入新密码");return false;
		}
		if(password2==''){
			alert("请再次输入新密码");return false;
		}
		if(password.length<6||password.length>16){
			alert("密码长度应为6~16个字符");return false;
		}
		if(password!=password2){
			alert("两次输入的密码不相同");return false;
		}
		if(code==''){
			alert("请输入6位验证码");return false;
		}
		var partten = /^1[3|4|5|8][0-9]\d{8}$/;
		if (mobiletel.length != 11 || !partten.test(mobiletel)) {
			alert("请输入正确的手机号码");
			return false
		}
	    $.post(ajaxurl, {
	        mobiletel: mobiletel,
	        password: password,
	        password2: password2,
	        code: code
	    }, function(data){
			if(data=='8'){
				alert("密码重置成功");
				location.href="/?c=account&m=login";
			}else if(data=='1'){
				alert("手机号码格式不对");
			}else if(data=='2'){
				alert("密码长度应为6~16个字符");
			}else if(data=='3'){
				alert("密码不合法 ");
			}else if(data=='4'){
				alert("两次输入密码不一致");
			}else if(data=='5'){
				alert("该手机号码不存在");
			}else if(data=='6'){
				alert("填写不完整");
			}else if(data=='7'){
				alert("旧密码不正确");
			}else if(data=='9'){
				alert("不允许注册");
			}else if(data=='10'){
				alert("该 Email已经被注册");
			}else if(data=='11'){
				alert("Email格式有误");
			}else if(data=='12'){
				alert("手机号码格不能为空");
			}else if(data=='13'){
				alert("验证码错误 ");
			}else if(data=='14'){
				alert("您已登录，请通过密码修改进行操作");
				location.href="/?c=account&m=editpwd";
			}else{
				alert("密码重置失败");
			}
		})
	})
	
	$("#m_jianyi").click(function(){
		var contact = $("#contact").val();
		var content = $("#content").val();
		var referer = $("#referer").val();
		if(content==''){alert("意见不能为空");return false;}
        if(contact==''){alert("联系方式不能为空");return false;}
	    $.post('/?c=account&m=guestbook&inajax=1', {
	        contact: contact,
			title:"m.cncn.com",
	        content: content,
	        referer: referer
	    }, function(data){
			if(data=='1'){
				alert("提交成功");
				location.reload();
			}else if(data=='3'){
				alert("您刚刚提交过");
			}else{
				alert("提交失败");
			}
		})	
	})
	
	$("#profileform").click(function(){
		var ajaxurl = $(this).parents("form").attr("ajaxurl");
		var mobiletel = '';
		var user_email = '';
		if($("input[name='mobiletel']").length > 0){
			var mobiletel = $("input[name='mobiletel']").val();

			if(mobiletel==''){
				alert("请输入手机号码");
				return false;				
			}
			
			var partten = /^1[3|4|5|8][0-9]\d{8}$/;
			if (mobiletel.length != 11 || !partten.test(mobiletel)) {
				alert("请输入正确的手机号码");
				return false;
			}			
		}
		if($("input[name='user_email']").length > 0){
			var user_email = $("input[name='user_email']").val();
			
			/*
			if(user_email==''){
				alert("请输入邮箱地址");
				return false;				
			}
			*/
			if (user_email != '') {
				if (!new RegExp(/^([a-zA-Z0-9_-])+@([a-zA-Z0-9_-])+(.[a-zA-Z0-9_-])+/).test(user_email)) {
					alert("邮箱格式不正确");
					return false;
				}
			}
		}
		var contact_name = $("input[name='contact_name']").val();
		var sex = $("select[name='sex']").val();
		var province = $("select[name='province']").val();
		var zone = $("select[name='zone']").val();

		if(contact_name==''){
			//alert("请输入真实姓名");
			//return false;				
		}
				
	    $.post(ajaxurl, {
	    	mobiletel: mobiletel,
	    	user_email: user_email,
	    	contact_name: contact_name,
	    	sex: sex,
	    	province: province,
	    	zone: zone
	    }, function(data){
			if(data=='1'){
				alert("修改成功");
			}else if(data=="-1"){
				alert("修改失败，手机号码不正确");
			}else if (data=='-2'){
				alert("修改失败，手机号码已被使用");
			}else if (data=='-3'){
				alert("修改失败，邮箱已被使用");
			}else if (data=='-4'){
				alert("修改失败，邮箱不正确");
			}else if (data=="9"){
				alert("请先登录");
				location.href="/?c=account&m=login";
			}else if (data=="10"){
				alert("地区错误");
			}else{
				alert("修改失败");
			}
		})		
	})
    
	$('#search-t').change(function(){
		search_t();
	})
	
	search_t();
	$("#saaa").attr("checked","checked");
})

function search_t(){
	var sv = $("#search-t").val();
	$(".sh").each(function(){
		if($(this).hasClass(sv)){
			$(this).show();
		}else{
			$(this).hide();
		}
	})
}
$.myPlush ={
tab: function(control,show,class1,i){
		$(control + "> a").click(function(){
			var c = $(control + "> a").index($(this));
			if(c==i){
				return false;
			}
			$(this).addClass(class1).siblings().removeClass(class1);
			$(show + "> div").eq(c).show().siblings().hide();
		})
	}
}
$.myPlush.tab("#nav_down_layer","#layer_m_download","on","3")
//返回顶部
$("#backTop").click(function() {
            $("html, body").animate({
                scrollTop: 0
            }, 120);
        })
function shareTSina(title,rLink,site,pic){
    window.open('http://service.weibo.com/share/mobile.php?title='+encodeURIComponent(title)+'&url='+encodeURIComponent(rLink)+'&appkey='+encodeURIComponent(site)+'&pic='+encodeURIComponent(pic),'_blank','scrollbars=no,width=400,height=250,left=75,top=20,status=no,resizable=yes')        
}	

function xx_event(n) {
    var xx = document.createElement('script');xx.async = true;
    xx.src = 'http://stat.cncn.com/event.php?n='+n;
    var s = document.getElementsByTagName('script')[0]; s.parentNode.insertBefore(xx, s);
}

//条件筛选，加载更多

$('.J_load_more').click(function(){

    var class_id = $('#class_id').val();
    var total_page = $('#total_page').val();
    var page = parseInt($('.J_page_num').val(),10);
    var page_type = $('.J_page_type').val();
    
    switch(page_type){
        case "line":
            var daynum = $('#daynum').val();
            var typeid2 = $('#typeid2').val();
            var typeid = $('#typeid').val();
            var orderby = $('#orderby').val();
            
            var m_data = {ajax:1, daynum:daynum, typeid2:typeid2, class_id:class_id, typeid:typeid, orderby:orderby, page:page};
            var m_url='/line/channel';
            break;
        case "hotel":
            var sub_id = $('#sub_id').val();
            var price = $('#price').val();
            
            var m_data = {ajax:1, sub_id:sub_id, price:price, class_id:class_id, page:page};
            var m_url='/hotel';
            break;
        case "ticket":
            var sub_id = $('#sub_id').val();
            
            var m_data = {ajax:1, sub_id:sub_id, class_id:class_id, page:page};
            var m_url='/ticket';
            break;
        case "zuche":
            var sub_id = $('#sub_id').val();
            var zone_id = $('#zone_id').val();
            
            var m_data = {ajax:1, sub_id:sub_id, zone_id:zone_id, class_id:class_id, page:page};
            var m_url='/zuche';
            break;
        case "qianzheng":
            var sub_id = $('#sub_id').val();
            var zone_id = $('#zone_id').val();
            
            var m_data = {ajax:1, sub_id:sub_id, zone_id:zone_id, class_id:class_id, page:page};
            var m_url='/qianzheng';
            break;
    }
  
    $.ajax({
        type:'post',
        url:m_url,
        data:m_data,
        success:function(data){
        	$('.J_fex_ajax').append(data);
        	if(page < total_page) {
        		page += 1;
        		$('.J_page_num').val(page);
        	}else{
                $('.J_load_more').hide();
            }
        }
    });
})

//后退按钮
$('header a.fl').click(function(){
    history.go(-1);
});

//$('#des_con a,.J_load_more').click(function(){
//    var class_id,daynum,typeid2,orderby,_url,sub_id,price,_self=this;
//    var desc=$(this).parents('.change-type-c').attr('id');
//    var sort_num=$(this).parents('.change-type-c').index();
//    var text=$(this).html();
//    var typeid=$('.J_meun').attr('typeid');
//    var page=parseInt($('.J_page_num').val(),10);
//    var total_page=parseInt($('.J_total_page').val(),10);
//    var page_type=$('.J_page_type').val();
//    
//    if(desc==undefined){
//        $(".load_more").show();
//        page=page+1;
//        $('.J_page_num').val(page);
//        $(".J_load_more").hide();
//    }else{
//        attr_val=$(this).attr(desc);
//        $('.J_meun li').eq(sort_num).find('a').attr(desc,attr_val);
//        $('.J_meun li').eq(sort_num).find('a').html(text);
//        page=1;
//        $('.J_page_num').val("1");
//    }
//    class_id=$('#des a').attr('class_id');
//    daynum=$('#des-day a').attr('daynum');
//    typeid2=$('#des-type a').attr('typeid2');
//    orderby=$('#des-by a').attr('orderby');
//    price=$('#des-price a').attr('price');
//    sub_id=$('#des-sub a').attr('sub_id');
//    
//    switch(page_type){
//         case 'search':
//            _url="/search";
//            var key=$(".J_search_key").val();
//            var parm="'key':'"+key+"','type':'line','ajax':'1','page':"+page;
//            
//            if(daynum!=0){
//                parm = parm +",'daynum':"+daynum;
//            }
//            if(typeid2!="no"){
//                parm = parm +",'typeid2':"+typeid2;
//            }
//            if(orderby!=0){
//                parm = parm +",'orderby':"+orderby;
//            }
//            break;
//        case 'line':
//            _url="/line/channel_list_ajax";
//            parm="'typeid2':'"+typeid2+"','class_id':"+class_id+",'daynum':"+daynum+",'orderby':"+orderby+",'page':"+page+",'typeid':"+typeid;
//            break;
//        case 'hotel':
//             _url="/hotel";
//            var parm="'type':'hotel','ajax':'1','page':"+page;
//            
//            if(class_id!=0){
//                parm = parm +",'class_id':"+class_id;
//            }
//            if(price!=0){
//                parm = parm +",'price':"+price;
//            }
//            if(sub_id!=0){
//                parm = parm +",'sub_id':"+sub_id;
//            }
//            break;
//    }
//    
//    parm="{"+parm+"}";
//    var json_parm = eval('(' + parm + ')'); 
//    $.ajax({
//        type:'post',
//        url:_url,
//        data:json_parm,
//        success:function(data){
//            if(page<=1){
//                $('.J_fex_ajax').html(data);
//                var t_page = $('#t_page').val();
//                $('#total_page').val(t_page);
//                if(t_page == 0) {
//                    $(".J_load_more").hide();
//                }else{
//                    $(".J_load_more").show();
//                }
//                $('#des_con div').animate({'height':'0px'},100);
//                $('#t_page').remove();
//            }else{
//                $(".load_more").hide();
//                $('.J_fex_ajax').append(data);
//                var total_page=parseInt($('.J_total_page').val(),10);
//                if(page<total_page){
//                    $(".J_load_more").show();
//                }
//            };
//        }
//    });
//})