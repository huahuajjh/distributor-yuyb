//Descript：找回密码
//DateTime：2011-05-22
//Author：迟美欢
$(function() {
    $("#aRetrieved").click(function() {
        //弹出登录窗体,并且将参数传递
        editWidget_2("/getpwd");
    });
});
//******遮罩层
function editWidget_2(targeturl) {
    window.scrollTo(0, 0);
    var width = document.documentElement.clientWidth + document.documentElement.scrollLeft;
    var height = document.documentElement.clientHeight + document.documentElement.scrollTop;
    var layer = document.createElement('div');
    layer.style.zIndex = 2;
    layer.id = 'layer_3';
    layer.style.position = 'absolute';
    layer.style.top = '0px';
    layer.style.left = '0px';
    layer.style.height = document.documentElement.scrollHeight + 'px';
    layer.style.width = width + 'px';
    layer.style.backgroundColor = 'black';
    layer.style.opacity = '.3';
    layer.style.filter += ("progid:DXImageTransform.Microsoft.Alpha(opacity=30)");
    document.body.style.position = 'static';
    document.body.appendChild(layer);

    var size = { 'height': 350, 'width': 320 };
    var iframe = document.createElement('iframe');
    iframe.name = 'Widget Editor_3';
    iframe.id = 'WidgetEditor_3';
    iframe.scrolling = "no";
    iframe.src = targeturl;
    iframe.style.height = size.height + 'px';
    iframe.style.width = size.width + 'px';
    iframe.style.position = 'absolute';
    iframe.style.zIndex = 3;
    iframe.style.border = "2px";
    iframe.frameBorder = "0px";
    iframe.marginwidth = "0";
    iframe.marginheight = "0";
    iframe.style.top = ((height + document.documentElement.scrollTop) / 2) - (size.height / 2) + 'px';
    iframe.style.left = (width / 2) - (size.width / 2) + 'px';
    document.body.appendChild(iframe);
    $("#WidgetEditor_3").attr("src", targeturl);
}
function closeEditor_2() {
    var we = document.getElementById("WidgetEditor_3");
    var la = document.getElementById("layer_3");
    document.body.removeChild(we);
    document.body.removeChild(la);
    document.body.style.position = '';
}

