$(function(){
     $("#close").click(function(){
        $("#suggestion").slideUp();
    });
    //��ҳͼƬ����
    var len  = $("#m_num > a").length;
    var index = 0;
    var adTimer;
    $("#m_num > a").mouseover(function(){
        index  =   $("#m_num > a").index(this);
        showImg(index);
    });
    //����¼���
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
    //��ȡ����ͼ����
    function showImg(index){
        //var adHeight = $("#focus_pic").height();
        $("#focus_pic").attr("class","m_sloder m_s_show_"+index).stop(true,false);
        $("#focus_pic > ul > li").eq(index).attr("class","m_s_li_"+index).siblings().removeClass();
        $("#m_num > a").removeClass("on").eq(index).addClass("on");
        $(".m_sloder_tit").html($("#focus_pic > ul > li").eq(index).find("img").attr("alt"))
    }
    //��Ŀ�̶�
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
    //��ҳ���������л�
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
    //����Ŀ�л�
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
    
    //������Ѷ
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

    //��������ѡ����Ӧ�仯���ڼ�Ǯ
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
                    $('<option>').attr('value',i).attr('price_d',data.price[i].price_d).attr('price_child_d',data.price[i].price_child_d).text(i+'(��'+data.price[i].price_d+')').appendTo('#start_time');
                }
                $("#adult_price").html("����<em>"+data.price[i].price_d+"</em>Ԫ/�� ");
                $("#child_price").html("��ͯ<em>"+data.price[i].price_child_d+"</em>Ԫ/��")
            }
        })
    })
    //���ݳ������ڼ�Ǯ��Ӧ�仯
    $('#start_time').change(function(){
            var pr_d = $(this).find("option:selected").attr('price_d');
            var pr_child_d = $(this).find("option:selected").attr('price_child_d');
            $("#adult_price").html("����<em>"+pr_d+"</em>Ԫ/�� ");
            if(pr_child_d =='0'){
                return false;
            }
            else{
                $("#child_price").html("��ͯ<em>"+pr_child_d+"</em>Ԫ/��");
            }
    })

    $("#pr_d_num").bind('input',function(){
        var num = $("#pr_d_num").val();
        var num_child = $("#pr_child_num").val();
        var pr_d = $('#start_time').find("option:selected").attr('price_d');
        var pr_child_d = $('#start_time').find("option:selected").attr('price_child_d');
        var all = Number(pr_d*num)+Number(pr_child_d*num_child);
        $("#get_price").attr('value',all);
        $(".price").html("�ܼƣ�<em>"+all+"</em>");
    })
    $("#pr_child_num").bind('input',function(){
        var num = $("#pr_d_num").val();
        var num_child = $("#pr_child_num").val();
        var pr_d = $('#start_time').find("option:selected").attr('price_d');
        var pr_child_d = $('#start_time').find("option:selected").attr('price_child_d');
        var all = Number(pr_d*num)+Number(pr_child_d*num_child);
        $("#get_price").attr('value',all);
        $(".price").html("�ܼƣ�<em>"+all+"</em>Ԫ");
    })

    //������һ��
    $("#order-next").click(function(){
       if( $("#pr_d_num").val()=='' &&  $("#pr_child_num").val()==''){
           alert('��������û����д��')
       }
       else{
           $("#order-next-m").hide();
           //setTimeout(function(){$("#order-con").show();alert(1)},2000);
           $("#order-con").show();
       }
    })
    //���ض���
    $("#backPrice").click(function(){
        $("#order-con").hide();
        $("#order-next-m").show();
    })
    //��֤
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
            alert("��ϵ��Ϊ������д��");
           // pos("#user",'��ϵ��Ϊ������д��');
			return false;
        }
        else if($("#user").val().length <2){
            alert("��ϵ�˹��̣�����������");
           // pos("#user",'��ϵ�˹��̣�����������');
			return false;
        }
        else if($("#phone").val() ==''){
            alert("�ֻ�����Ϊ������д��");
            //pos("#phone",'�ֻ�����Ϊ������д��');
			return false;
        }
        else if($("#user").val().length>10){
            alert("��ϵ�˳��Ƚ���10���ַ�������������");
           // pos("#user",'��ϵ�˳��Ƚ���10���ַ���������������');
			return false;
        }
        else if($("#phone").val().length!=11 || !regexp.test($("#phone").val())){
            alert("�ֻ����벻��ȷ������������");
            //pos("#phone",'�ֻ����벻��ȷ��������������');
			return false;
        }
        else if(! new RegExp(/^([a-zA-Z0-9_-])+@([a-zA-Z0-9_-])+(.[a-zA-Z0-9_-])+/).test($("#mail").val()) && $("#mail").val()!=''){
            alert("�����ʽ����ȷ������������");
            //pos("#mail",'�����ʽ����ȷ������������');
			return false;
        }
        else if(new RegExp(/[^\d]/g).test($("#qq").val()) && $("#qq").val()!=''){
            alert("QQ���벻��ȷ������������");
            //pos("#qq",'QQ���벻��ȷ������������');
			return false;
        }
        else if(new RegExp(/[^0-9\-,�� ]+/).test($("#tell").val()) && $("#tell").val()!=''){
            alert("�绰���벻��ȷ������������");
            //pos("#tell",'�绰���벻��ȷ������������');
			return false;
        }
        //window.loading_dialog.loadingDialogOnAndroid()
    })

    
    //��·����Ĭ�ϵ�һ����
     $(".line-i-c").eq(0).css("height",'auto');
     $(".J_line_w").eq(0).find('.roat').addClass("on");
    //��·����
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
    
    
    
	//ajax ����ҳ��
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
            	alert("�������Ӵ���");
                $(".load_more").hide();
            }else{
				$(".load_more").remove();
                // $("#for-ajax").replaceWith('<div class="load_more"><img src="../imgs/loading.gif" /> ����������</div>');
				$("#for-ajax").replaceWith(data);
            
                $(".load_more").hide();
            }
        });
	})
	
	//���������ʾ
	$("#for-check-status").fadeOut(2000);
	
	$("#add_fav").click(function(){
		var r_url = $(this).attr("index");
		$.get(r_url, function(data){
			if(data=='1'){
				alert("�ղسɹ�");
			}else if(data=='-3'){
				alert("���Ѿ��ղع���");
			}else if(data=='-1'){
				alert("���ȵ�¼");
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
				alert("ȡ���ɹ�");
				current.parents(".fav-m").remove();
			}else if(data=='-2'){
				alert("ȡ��ʧ��");
			}else if(data=='-1'){
				alert("���ȵ�¼");
				var ihref = encodeURIComponent(document.URL);
				location.href = "/?c=account&m=login&forward="+ihref;
			}
		});		
	})
        //����ȡ��
	$(".cancel-order").live('click', function() {
		if (confirm("��ȷ��Ҫȡ��������")) {
                    var current = $(this);
                    var r_url = $(this).attr("index");
                    $.get(r_url, function(data){
                            if (data == '1') {
                                    alert("ȡ���ɹ�");
                                    $(".for-status").html("��ȡ��");
                                    if ($(".for-status").hasClass("order-status-0")) {
                                            $(".for-status").removeClass("order-status-0");
                                            $(".for-status").addClass("order-status-4");
                                    }
                                    current.remove();
                            }else if (data == '-2') {
                                    alert("ȡ��ʧ��");
                            }else if (data == '-1') {
                                    alert("���ȵ�¼");
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
//                                    alert("ȡ���ɹ�");
//                                    $(".for-status").html("��ȡ��");
//                                    if ($(".for-status").hasClass("order-status-0")) {
//                                            $(".for-status").removeClass("order-status-0");
//                                            $(".for-status").addClass("order-status-4");
//                                    }
//                                    current.remove();
//                            }else if (data == '-2') {
//                                    alert("ȡ��ʧ��");
//                            }else if (data == '-1') {
//                                    alert("���ȵ�¼");
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
			alert("���������ֻ�����");
			return false;
		}
		var partten = /^1[3|4|5|8][0-9]\d{8}$/;
		if (tel.length != 11 || !partten.test(tel)) {
			alert("�ֻ����벻��ȷ��������������");
			return false
		}
		r_url = "/?c=account&m=getcode&inajax=1&mobiletel="+tel+"&idtype="+idtype;
		$.get(r_url, function(data){
			if(data=='1'){alert("�����ѷ��ͣ���鿴");}
			else if(data=='-1'){alert("��ȡʧ�ܣ��ֻ����벻��Ϊ��");}
			else if(data=='-2'){alert("��ȡʧ�ܣ��ֻ��������");}
			else if(data=='-3'){alert("��ȡʧ�ܣ����ֻ��ѱ�ע��");}
			else if(data=='-4'){alert("���Ĳ���̫Ƶ�������Ժ�����");}
            else if(data=='-5'){alert("���ֻ��û�������");}
			else{alert("��ȡʧ��");}
			//��������ʮ�뵹��ʱ
		});
	})
    //
   	$("#loginform").click(function(){
		var ajaxurl = $(this).parents("form").attr("ajaxurl");
		var username = $("input[name='username']").val();
		var password = $("input[name='password']").val();
		var forward = $("input[name='forward']").val();
		if(username==''){
			alert("�û��������벻��Ϊ��");
			$("input[name='username']").focus();
			return false;
		}
		if(password==''){
			alert("�û��������벻��Ϊ��");
			$("input[name='password']").focus();
			return false;
		}
	    
            $.post(ajaxurl, {
	        username: username,
	        password: password
	    }, function(data){
			if(data=='5'){
                //window.loading_dialog.dialogOnAndroid("���ڵ�¼�����Ժ�");
                alert("��¼�ɹ�");
				if(forward==''){
					location.href="/?c=account&m=account";
					return;
				}else{
					location.href=decodeURIComponent(forward);
					return;
				}
			}else if(data=='4'){
				alert("�û��������벻��Ϊ��");
			}else if(data=='1'){
				alert("�û���������");
			}else if(data=='2'){
                                alert("���벻��ȷ");
			}else if(data=='3'){
				alert("��¼ʧ��");
			}else{
				alert("��¼ʧ��");
			}
	    });
	})

	$("#editpwdform").click(function(){
		var ajaxurl = $(this).parents("form").attr("ajaxurl");
		var oldpwd = $("input[name='oldpwd']").val();
		var password = $("input[name='password']").val();
		var password2 = $("input[name='password2']").val();
		if(oldpwd==''){
			alert("�����������");return false;
		}
		if(password==''){
			alert("������������");return false;
		}
		if(password2==''){
			alert("���ٴ�����������");return false;
		}
		if(password.length<6||password.length>16){
			alert("���볤��ӦΪ6~16���ַ�");return false;
		}
		if(password!=password2){
			alert("������������벻��ͬ");return false;
		}
	    $.post(ajaxurl, {
	        oldpwd: oldpwd,
	        password: password,
	        password2: password2
	    }, function(data){
			if(data=='1'){
				alert("�޸ĳɹ�");
				location.href="/?c=account&m=account";
			}else if(data=='2'){
				alert("����ľ���������");
			}else if(data=='3'){
				alert("Email��ʽ����");
			}else if(data=='4'){
				alert("������ע��");
			}else if(data=='5'){
				alert("�� Email�Ѿ���ע�� ");
			}else if(data=='6'){
				alert("��д������");
			}else if(data=='7'){
				alert("������������벻��ͬ");
			}else if(data=='8'){
				alert("���볤��ӦΪ6~16���ַ�");
			}else if(data=='9'){
				alert("���벻�Ϸ�");
			}else if(data=='10'){
				alert("���ȵ�¼");
				location.href="/?c=account&m=login";
			}else{
				alert("�޸�ʧ��");
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
			alert("�������ֻ�����");return false;
		}
		if(password==''){
			alert("����������");return false;
		}
		if(code==''){
			alert("������6λ��֤��");return false;
		}
		if(password.length<6||password.length>16){
			alert("���볤��ӦΪ6~16���ַ�");return false;
		}
		var partten = /^1[3|4|5|8][0-9]\d{8}$/;
		if (mobiletel.length != 11 || !partten.test(mobiletel)) {
			alert("��������ȷ���ֻ�����");
			return false
		}
	    $.post(ajaxurl, {
	        mobiletel: mobiletel,
	        password: password,
	        code: code
	    }, function(data){
			if(data==14){
				alert("��ϲ�������Ѿ��ɹ�ע��Ϊ������Ա");
				if(forward==''){
					location.href="/?c=account&m=account";
					return;
				}else{
					location.href=decodeURIComponent(forward);
					return;
				}
			}else if(data=='1'){
				alert("��������ȷ���ֻ����� ");
			}else if(data=='2'){
				alert("���볤��ӦΪ6~16���ַ�");
			}else if(data=='3'){
				alert("���벻�Ϸ�");
			}else if(data=='4'){
				alert("���벻һ�� ");
			}else if(data=='5'){
				alert("���䲻��ȷ ");
			}else if(data=='6'){
				alert("���䱻ʹ��");
			}else if(data=='7'){
				alert("���Ѹ�IPһ��ֻ��ע��һ���ʺ�");
			}else if(data=='8'){
				alert("ע��ʧ��");
			}else if(data=='9'){
				alert("�����ֹע��");
			}else if(data=='10'){
				alert("�ֻ������ѱ�ʹ��");
			}else if(data=='11'){
				alert("������ע��Ĵ���");
			}else if(data=='12'){
				alert("�ֻ����벻��Ϊ��");
			}else if(data=='13'){
				alert("��֤�����");
			}else if(data=='16'){
				alert("δ֪����");
				location.href="/?c=account&m=login";
			}else if(data=='15'){
				alert("���Ѿ����ʻ���");
				if(forward==''){
					location.href="/?c=account&m=account";
					return;
				}else{
					location.href=decodeURIComponent(forward);
					return;
				}
			}else{
				alert("ע��ʧ��");
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
			alert("�������ֻ�����");return false;
		}
		if(password==''){
			alert("������������");return false;
		}
		if(password2==''){
			alert("���ٴ�����������");return false;
		}
		if(password.length<6||password.length>16){
			alert("���볤��ӦΪ6~16���ַ�");return false;
		}
		if(password!=password2){
			alert("������������벻��ͬ");return false;
		}
		if(code==''){
			alert("������6λ��֤��");return false;
		}
		var partten = /^1[3|4|5|8][0-9]\d{8}$/;
		if (mobiletel.length != 11 || !partten.test(mobiletel)) {
			alert("��������ȷ���ֻ�����");
			return false
		}
	    $.post(ajaxurl, {
	        mobiletel: mobiletel,
	        password: password,
	        password2: password2,
	        code: code
	    }, function(data){
			if(data=='8'){
				alert("�������óɹ�");
				location.href="/?c=account&m=login";
			}else if(data=='1'){
				alert("�ֻ������ʽ����");
			}else if(data=='2'){
				alert("���볤��ӦΪ6~16���ַ�");
			}else if(data=='3'){
				alert("���벻�Ϸ� ");
			}else if(data=='4'){
				alert("�����������벻һ��");
			}else if(data=='5'){
				alert("���ֻ����벻����");
			}else if(data=='6'){
				alert("��д������");
			}else if(data=='7'){
				alert("�����벻��ȷ");
			}else if(data=='9'){
				alert("������ע��");
			}else if(data=='10'){
				alert("�� Email�Ѿ���ע��");
			}else if(data=='11'){
				alert("Email��ʽ����");
			}else if(data=='12'){
				alert("�ֻ��������Ϊ��");
			}else if(data=='13'){
				alert("��֤����� ");
			}else if(data=='14'){
				alert("���ѵ�¼����ͨ�������޸Ľ��в���");
				location.href="/?c=account&m=editpwd";
			}else{
				alert("��������ʧ��");
			}
		})
	})
	
	$("#m_jianyi").click(function(){
		var contact = $("#contact").val();
		var content = $("#content").val();
		var referer = $("#referer").val();
		if(content==''){alert("�������Ϊ��");return false;}
        if(contact==''){alert("��ϵ��ʽ����Ϊ��");return false;}
	    $.post('/?c=account&m=guestbook&inajax=1', {
	        contact: contact,
			title:"m.cncn.com",
	        content: content,
	        referer: referer
	    }, function(data){
			if(data=='1'){
				alert("�ύ�ɹ�");
				location.reload();
			}else if(data=='3'){
				alert("���ո��ύ��");
			}else{
				alert("�ύʧ��");
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
				alert("�������ֻ�����");
				return false;				
			}
			
			var partten = /^1[3|4|5|8][0-9]\d{8}$/;
			if (mobiletel.length != 11 || !partten.test(mobiletel)) {
				alert("��������ȷ���ֻ�����");
				return false;
			}			
		}
		if($("input[name='user_email']").length > 0){
			var user_email = $("input[name='user_email']").val();
			
			/*
			if(user_email==''){
				alert("�����������ַ");
				return false;				
			}
			*/
			if (user_email != '') {
				if (!new RegExp(/^([a-zA-Z0-9_-])+@([a-zA-Z0-9_-])+(.[a-zA-Z0-9_-])+/).test(user_email)) {
					alert("�����ʽ����ȷ");
					return false;
				}
			}
		}
		var contact_name = $("input[name='contact_name']").val();
		var sex = $("select[name='sex']").val();
		var province = $("select[name='province']").val();
		var zone = $("select[name='zone']").val();

		if(contact_name==''){
			//alert("��������ʵ����");
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
				alert("�޸ĳɹ�");
			}else if(data=="-1"){
				alert("�޸�ʧ�ܣ��ֻ����벻��ȷ");
			}else if (data=='-2'){
				alert("�޸�ʧ�ܣ��ֻ������ѱ�ʹ��");
			}else if (data=='-3'){
				alert("�޸�ʧ�ܣ������ѱ�ʹ��");
			}else if (data=='-4'){
				alert("�޸�ʧ�ܣ����䲻��ȷ");
			}else if (data=="9"){
				alert("���ȵ�¼");
				location.href="/?c=account&m=login";
			}else if (data=="10"){
				alert("��������");
			}else{
				alert("�޸�ʧ��");
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
//���ض���
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

//����ɸѡ�����ظ���

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

//���˰�ť
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