var votetype, rlogin = 0, voteobj, votea = ['citydxq', 'citydqg', 'cityxq', 'cityqg', 'travelstj', 'travelstj2', 'travels', 'travels2', 'visa'];
var editor = new Array();
//添加编辑器
function AddEditor(id, tool, RanNum) {
    //$.include([webpath + 'sys/webedit/ueditor.config.js', webpath + 'sys/webedit/ueditor.all.js']);
    var config = {
        imageUrl: webpath + "sys/ajax/editorImageUp.ashx?r=" + RanNum,     //图片上传地址
        imagePath: upfolder,                                   //图片修正地址，引用了fixedImagePath,如有特殊需求，可自行配置
        scrawlUrl: webpath + "sys/ajax/editorScrawlImgUp.ashx?r=" + RanNum, //涂鸦上传地址
        scrawlPath: upfolder,                                          //图片修正地址，同imagePath
        catcherUrl: webpath + "sys/ajax/editorGetRemoteImage.ashx?r=" + RanNum, //处理远程图片抓取的地址
        catcherPath: upfolder,                         //图片修正地址，同imagePath
        snapscreenHost: 'ueditor.baidu.com',                            //屏幕截图的server端文件所在的网站地址或者ip，请不要加http://
        snapscreenServerUrl: webpath + "sys/ajax/editorImageUp.ashx?r=" + RanNum, //屏幕截图的server端保存程序，UEditor的范例代码为“URL +"server/upload/net/snapImgUp.ashx"”
        snapscreenPath: upfolder,

        wordImageUrl: webpath + "sys/ajax/editorImageUp.ashx?r=" + RanNum, //word转存提交地址
        wordImagePath: upfolder, //
        getMovieUrl: webpath + "sys/ajax/editorGetMovie.ashx",    //视频数据获取地址
        initialFrameWidth: '100%',
        focus: false,
        toolbars: [
                ['fullscreen', 'source', '|', 'undo', 'redo', '|',
                    'bold', 'italic', 'underline', 'fontborder', 'strikethrough', 'superscript', 'subscript', 'removeformat', 'formatmatch', 'autotypeset', 'blockquote', 'pasteplain', '|', 'forecolor', 'backcolor', 'insertorderedlist', 'insertunorderedlist', 'selectall', 'cleardoc', '|',
                    'rowspacingtop', 'rowspacingbottom', 'lineheight', '|',
                    'customstyle', 'paragraph', 'fontfamily', 'fontsize', '|',
                    'directionalityltr', 'directionalityrtl', 'indent', '|',
                    'justifyleft', 'justifycenter', 'justifyright', 'justifyjustify', '|', 'touppercase', 'tolowercase', '|',
                    'link', 'unlink', 'anchor', '|', 'imagenone', 'imageleft', 'imageright', 'imagecenter', '|',
                    'insertimage', 'emotion', 'scrawl', 'insertvideo', 'music', 'attachment', 'insertframe', 'insertcode', 'webapp', 'pagebreak', 'template', 'background', '|',
                    'horizontal', 'date', 'time', 'spechars', 'snapscreen', 'wordimage', '|',
                    'inserttable', 'deletetable', 'insertparagraphbeforetable', 'insertrow', 'deleterow', 'insertcol', 'deletecol', 'mergecells', 'mergeright', 'mergedown', 'splittocells', 'splittorows', 'splittocols', '|',
                    'print', 'preview', 'searchreplace', 'help']
            ]
    };
    if (!tool) tool = 'full';
    if (tool == 'simple') {
        config.toolbars[0] = [ 'source', '|', 'undo', 'redo', '|',
            'bold', 'italic', 'underline', 'fontborder', 'strikethrough', 'superscript', 'subscript', 'removeformat', 'formatmatch', 'autotypeset', 'blockquote', 'pasteplain', '|', 'forecolor', 'backcolor', 'insertorderedlist', 'insertunorderedlist', 'selectall', 'cleardoc', '|',
            'rowspacingtop', 'rowspacingbottom', 'lineheight'];
    } else if (tool != 'full') {
        config.toolbars[0] = $.map(config.toolbars[0], function (n) {
            return n != 'pagebreak' ? n : null;
        });
    }
    editor[id] = UE.getEditor(id, config);
}

$(document).ready(function () {
    mySearch();
    onlineService();
    goToTop();
    subNav();
    $('img[data-original]').lazyload({ threshold: 100 }); //图片延时加载
    $('.headSearch .sInput').focus(function () { //头部搜索
        $('.headSearch .defaultKey').hide();
    }).blur(function () {
        if (!$.trim($(this).val())) {
            $('.headSearch .defaultKey').show();
            $(this).val('');
        }
    });
    $(".drop").hover(function () {//头部下拉
        $(this).find('.dropDown').show();
        $(this).addClass('hover');

    }, function () {
        $(this).find('.dropDown').hide();
        $(this).removeClass('hover');
    });

    $('#loginout').click(function () {
        $.get(webpath + 'sys/ajax/login.ashx', { act: "out" }, function () {
            checklogin(); getvote();
        });
    });
    $('#login').click(function () {
        rlogin = 2;
        ShowWindow('', 'alertlogin', webpath + 'alertlogin.aspx');
    });
    $('#logins').click(function () {
        rlogin = 2;
        ShowWindow('', 'alertlogin', webpath + 'alertlogin.aspx');
    });
    checklogin();
    voteobj = $('[id^="citydxq_"],[id^="citydqg_"],[id^="cityxq_"],[id^="cityqg_"],[id^="travelstj_"],[id^="travels_"],[id^="travelstj2_"],[id^="travels2_"],[id^="visa_"]');
    if (voteobj.length > 0) {
        voteobj.click(function () {
            rlogin = 1;
            var id = $(this).attr('id').split('_');
            if ($(this).attr('status') == 1) {
                if (id[0] == 'visa') {
                    alert('您已经收藏过!');
                }
                return;
            }
            if ((id[0] != 'travelstj' && id[0] != 'travelstj2') && GetCookie('username') == '') {
                votetype = $(this);
                rlogin = 0;
                ShowWindow('', 'alertlogin', webpath + 'alertlogin.aspx'); return;
            }
            favorites(
				id[0],
				id[1],
				function () {
				    if (arguments[0] == 'true') {
				        if (id[0] == "citydxq" || id[0] == "citydqg") {
				            $('#' + id[0] + '_' + id[1]).removeClass('cur').addClass('cur');
				        } else {
				            $('#' + id[0] + '_' + id[1]).removeClass('voteyes').addClass('voteno');
				        }
				        $('#' + id[0] + 'text_' + id[1]).text((parseInt($('#' + id[0] + 'text_' + id[1]).text()) + 1));
				        if (id[0] == 'visa') {
				            alert('恭喜您收藏成功!');
				        }
				    }
				});
        });
        getvote();
    }

    $(".headNav .navList li").each(function () {
        if ($(this).find(".subnav .list a").length == 0) {
            $(this).removeClass("on");
            $(this).unbind("mouseover");
        }
    });
});

//会员中心左侧
$(".userNavTit1").click(function () { 
    if ($(this).find('div').hasClass("mores")) {
        $(".curUNav").addClass("mores");
        $(".more").removeClass("curUNav");
        $(this).find('div').removeClass('mores').addClass("curUNav");
    } else {
        if ($(this).find('div').hasClass("curUNav")) {
            return;
        }

        $(this).find('div').addClass('mores');
    }
    $('.userNavText').hide();
    $(this).next('.userNavText').slideToggle("slow");
});


//头部搜索切换
function mySearch() {
    $('#optChange').hover(
		function () {
		    $(this).find('dl').show();
		    $(this).addClass('hover');
		},
		function () {
		    $(this).find('dl').hide();
		    $(this).removeClass('hover');
		}
	);

    $('#optChange dd').hover(
		function () { $(this).addClass('cur'); },
		function () { $(this).removeClass('cur'); }
	).click(
		function () {
		    $('.optionCur').html($(this).attr('text'));
		    $('#defaultKey').text($(this).attr('defaultkey'));
		    $('#optChange').removeClass('hover').find('dl').hide();
		    $('#searchform').attr('action', $(this).attr('url'));
		    if (!$.trim($('#s_input').val())) {
		        $('#defaultKey').show();
		        $('#s_input').val('');
		    }
		}
	).first().click();
}


//二级导航
function subNav(){
	$('.headNav').find('li').hover(
		function(){
			if($(this).hasClass('on')){
				$(this).addClass('up');
				$('.navBg').show().stop().animate({ height: 39}, 300 );
				$(this).find('.subnav').show().stop().animate({ height: 39}, 500 );
				
				var subL = $(this).position().left; //一级菜单相对父级的距离
				var subW = $(this).find('.list').width();//二级菜单的宽度
				var navWidth = $(this).width();//当前菜单的宽度
				var w = subL + navWidth/2 - subW/2;
				var wc = subW + w - 1200;
				if( wc > 0){
					$(this).find('.list').css("padding-left",w - wc - 10);
				}else{
					$(this).find('.list').css("padding-left",w);
				}
			}
		},
		function(){
			if($(this).hasClass('on')){
				$(this).removeClass('up');
				$('.navBg').show().hide().stop().animate({ height: 0}, 300 );
				$(this).find('.subnav').hide().stop().animate({ height: 0}, 500 );
			}
		}
	);
}


/*在线客服开始*/
function onlineService() {
    if (webconfig('onlineswitch') == 0) return;
    var onlineqqs = webconfig('onlineqq');
    var qq = onlineqqs.split('|');
    var qqone;

    var HotLine = webconfig('hotline');
    var HH = HotLine.split('|');
    var Hot;

	var html = '<div id="fixedService" class="rides-cs">';
	html += '  	<div class="floatL">';
	html += ' 	<a style="display:block;" id="aFloatTools_Show" class="btnOpen" title="查看在线客服" href="javascript:void(0);">展开</a>';
	html += ' 	<a style="display:none;" id="aFloatTools_Hide" class="btnCtn" title="关闭在线客服" href="javascript:void(0);">收缩</a>';
	html += '   </div>';
	html += '   <div id="divFloatToolsView" class="floatR" style="display:none;">';
	html += ' 	<div class="cn">';
	html += ' 	  <h3 class="titZx titQq">在线客服</h3>';
	html += ' 	  <ul class="qq clearfix">';
	if (qq.length > 0) {
	    for (var i = 0; i < qq.length; i++) {
	        qqone = qq[i].split(',');
	        html += '				<li><a target="_blank" rel="nofollow" href="tencent://message/?uin=' + qqone[1] + '&site=qq&menu=yes" rel="nofollow"><img border="0" src="http://wpa.qq.com/pa?p=2:' + qqone[1] + ':52" alt="在线客服" title="' + qqone[0] + '"/><span>' + qqone[0] + '</span></a></li>';
	    }
	}
	html += ' 	  </ul>';
	html += ' 	  <h3 class="titZx">咨询热线</h3>';
	html += ' 	  <ul>';
	if (HH.length > 0) {
	    for (var i = 0; i < HH.length; i++) {
	        Hot = HH[i].split(':');
	        html += ' 		<li><span>' + Hot[0] + '：</span><em>' + Hot[1] + '</em></li>';
	    }
	}
	html += ' 	  </ul>';
	html += ' 	</div>';
	html += '   </div>';
	html += ' </div>';
	$(html).appendTo('body');
	
	$("#aFloatTools_Show").click(function(){
			$('#divFloatToolsView').animate({width:'show',opacity:'show'},500,function(){$('#divFloatToolsView').show();});
			$('#aFloatTools_Show').hide();
			$('#aFloatTools_Hide').show();				
		});
		$("#aFloatTools_Hide").click(function(){
			$('#divFloatToolsView').animate({width:'hide', opacity:'hide'},500,function(){$('#divFloatToolsView').hide();});
			$('#aFloatTools_Show').show();
			$('#aFloatTools_Hide').hide();	
		});
}
/*在线客服结束*/


//返回顶部
function goToTop() { 
   webconfig('wapcode');
   webconfig('wxCode');
   var tophtml="<div id='izl_rmenu' class='izl-rmenu'><div class='btn btn-wx'><img class='pic' src='" + webpath + webconfig('wxCode') + "'></div><div class='btn btn-phone'><img class='pic' src='" + webpath + webconfig('wapcode') + "'></div><div class='btn btn-top'></div></div>";
	$(tophtml).appendTo('body');
	$("#izl_rmenu").each(function(){
		$(this).find(".btn-wx").mouseenter(function(){
			$(this).find(".pic").fadeIn("fast");
		});
		$(this).find(".btn-wx").mouseleave(function(){
			$(this).find(".pic").fadeOut("fast");
		});
		$(this).find(".btn-phone").mouseenter(function(){
			$(this).find(".pic").fadeIn("fast");
		});
		$(this).find(".btn-phone").mouseleave(function(){
			$(this).find(".pic").fadeOut("fast");
		});
		$(this).find(".btn-top").click(function(){
			$("html, body").animate({
				"scroll-top":0
			},"fast");
		});
	});
	var lastRmenuStatus=false;
	$(window).scroll(function(){//bug
		var _top=$(window).scrollTop();
		if(_top>200){
			$("#izl_rmenu").data("expanded",true);
		}else{
			$("#izl_rmenu").data("expanded",false);
		}
		if($("#izl_rmenu").data("expanded")!=lastRmenuStatus){
			lastRmenuStatus=$("#izl_rmenu").data("expanded");
			if(lastRmenuStatus){
				$("#izl_rmenu .btn-top").slideDown();
			}else{
				$("#izl_rmenu .btn-top").slideUp();
			}
		}
	});
}

/*弹出登陆回调*/
function AlertLoginReturn() {
    checklogin();
    HideWindow();
    if (rlogin == 0) {
        votetype.click();
    } else if (rlogin == 1) {
        getvote();
    }
}

/*检测登陆*/
function checklogin() {
    if (GetCookie('username') == '') {
        $('#logined').hide();
        $('#unlogin').show();
    } else {
        $('#unlogin').hide();
        $('#logined_name').text(GetCookie('realname') == '' ? GetCookie('username') : GetCookie('realname'));
        $('#logined').show();
        $.ajax({
            type: "GET",
            url: webpath + 'sys/Ajax/GetUserInfoCount.ashx',
            cache: false,
            dataType: "json",
            success: function (json) {
                if (json.CountSMS > 0) {
                    if ($(".sitemsg").length > 0) {
                        $('.sitemsg').html('站内信:<a href="' + json.url + '" >未读(' + json.CountSMS + ')</a>');
                    } else {
                        $('#logined').append('<span class="sitemsg">站内信:<a href="' + json.url + '" >未读(' + json.CountSMS + ')</a></span>');
                    }
                }
            }
        });
    }
}
//投票与收藏
function getvote() {
    if (voteobj.length == 0) return;
    var url = webpath + 'sys/ajax/getvote.ashx?t=', adid = '', f, f1 = '';
    for (var i = 0; i < votea.length; i++) {
        f = voteobj.filter('[id^="' + votea[i] + '_"]');
        if (f.length != 0) {
            url += votea[i] + ',';
            f1 += '&' + votea[i] + 'id=';
            f.each(function () {
                f1 += $(this).attr('id').replace(votea[i] + '_', '') + ',';
            });
            f1 = f1.substring(0, f1.length - 1);
        }
    }
    url = url.substring(0, url.length - 1) + f1 + '&callback=?';
    $.getJSON(url,
		 function (json) {
		     for (var i = 0; i < json.length; i++) {
		         for (var j = 0; j < json[i].item.length; j++) {
		             var t = json[i].item[j];
		             $('#' + json[i].type + 'text_' + t.adid).text(t.votes);
		             $('#' + json[i].type + '_' + t.adid).attr('status', t.status);
		             if (t.status == 1) {
		                 if (json[i].type == "citydxq" || json[i].type == "citydqg") {
		                     $('#' + json[i].type + '_' + t.adid).addClass('cur');
		                     $('#' + json[i].type + 'text_' + t.adid).text(t.votes);
		                 } else {
		                     $('#' + json[i].type + '_' + t.adid).removeClass('voteyes').addClass('voteno');
		                     $('#' + json[i].type + 'text_' + t.adid).text(t.votes);
		                 }
		             } else {
		                 if (json[i].type == "citydxq" || json[i].type == "citydqg") {
		                     $('#' + json[i].type + '_' + t.adid).removeClass('cur');
		                     $('#' + json[i].type + 'text_' + t.adid).text(t.votes);


		                 } else {
		                     $('#' + json[i].type + '_' + t.adid).removeClass('voteno').addClass('voteyes');

		                     $('#' + json[i].type + 'text_' + t.adid).text(t.votes);
		                 }
		             }
		         }
		     }
		     $('[id^="cityxq_"]').each(function () {
		         var adid = $(this).attr('id').split('_')[1];
		         if (parseInt($('#cityxqtext_' + adid).text()) + parseInt($('#cityxqtext_' + adid).text()) < 10) {
		             $('#cityvotelevel_' + adid).removeClass().addClass('s3');
		         }
		     });
		 }
	);
};