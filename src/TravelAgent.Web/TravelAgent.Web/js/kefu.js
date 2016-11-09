$(function() {
    onlineService();
})
//var webconfigdata= null;
//function webconfig(e) {
//    if (webconfigdata == null)
//    {
//        $.ajax({
//            type: "POST",
//            url: "/dataDeal/dataConfig.ashx",
//            cache: false,
//            dataType: "text",
//            data: {para:e},
//            success: function(msg) {
//                webconfigdata=msg;
//            }
//        })
//    }
//    return webconfigdata;
// }
/*在线客服开始*/
function onlineService() {
    var kefustate = $("#hfkefustate").val();
    var kefuvalue = $("#hfkefudata").val();

    if (kefustate==""||kefustate=="0") return;
    var qqkefus = kefuvalue.split('|');
    //var qqone;

    //var HotLine = webconfig('hotline');
    //var HH = HotLine.split('|');
    //var Hot;
    var kefudetail;
    var kefuqqdetail;
    var h=0;
    var html = '<div id="fixedService" class="rides-cs">';
    html += '  	<div class="floatL">';
    html += ' 	<a style="display:block;" id="aFloatTools_Show" class="btnOpen" title="查看在线客服" href="javascript:void(0);">展开</a>';
    html += ' 	<a style="display:none;" id="aFloatTools_Hide" class="btnCtn" title="关闭在线客服" href="javascript:void(0);">收缩</a>';
    html += '   </div>';
    html += '   <div id="divFloatToolsView" class="floatR" style="display:none;">';
    html += ' 	<div class="cn">';
    if (qqkefus.length > 0) {
        for (var j = 0; j < qqkefus.length; j++) {
            kefudetail = qqkefus[j].split(':');
            if (kefudetail.length > 0) {
                html += ' 	  <h3 class="titZx titQq">' + kefudetail[0] + '</h3>';
                html += ' 	  <ul class="qq">';
                kefuqqdetail = kefudetail[1].split(',');
                if (kefuqqdetail.length > 0) {
                    for (var i = 0; i < kefuqqdetail.length; i++) {
                        h = h + 1;
                        html += '<li><a target="_blank" rel="nofollow" href="http://wpa.qq.com/msgrd?v=3&uin=' + kefuqqdetail[i] + '&site=qq&menu=yes" rel="nofollow"><img border="0" src="http://wpa.qq.com/pa?p=2:' + kefuqqdetail[i] + ':52" alt="在线客服" /><span>客服' + h + '</span></a></li>';
                    }
                }
                html += ' 	  </ul>';
            }
        }
    }
      //html += ' 	  <h3 class="btom"></h3>';
//    html += ' 	  <h3 class="titZx">咨询热线</h3>';
//    html += ' 	  <ul>';
//    if (HH.length > 0) {
//        for (var i = 0; i < HH.length; i++) {
//            Hot = HH[i].split(':');
//            html += ' 		<li><span>' + Hot[0] + '：</span><em>' + Hot[1] + '</em></li>';
//        }
//    }
//    html += ' 	  </ul>';
    html += ' 	</div>';
    html += '   </div>';
    html += ' </div>';
    $(html).appendTo('body');

    $("#aFloatTools_Show").click(function() {
        $('#divFloatToolsView').animate({ width: 'show', opacity: 'show' }, 500, function() { $('#divFloatToolsView').show(); });
        $('#aFloatTools_Show').hide();
        $('#aFloatTools_Hide').show();
    });
    $("#aFloatTools_Hide").click(function() {
        $('#divFloatToolsView').animate({ width: 'hide', opacity: 'hide' }, 500, function() { $('#divFloatToolsView').hide(); });
        $('#aFloatTools_Show').show();
        $('#aFloatTools_Hide').hide();
    });
}
/*在线客服结束*/