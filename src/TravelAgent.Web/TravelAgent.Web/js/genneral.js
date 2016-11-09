//可以自动关闭的提示
function jsprint(msgtitle, url, msgcss) {
    $("#msgprint").remove();
    var cssname = "";
    switch (msgcss) {
        case "Success":
            cssname = "pcent correct";
            break;
        case "Error":
            cssname = "pcent disable";
            break;
        default:
            cssname = "pcent warning";
            break;
    }
    var str = "<div id=\"msgprint\" class=\"" + cssname + "\">" + msgtitle + "</div>";
    $("body").append(str);
    $("#msgprint").show();
    if (url == "back") {
        sysMain.history.back(-1);
    } else if (url != "") {
        sysMain.location.href = url;
    }
    //3秒后清除提示
    setTimeout(function() {
        $("#msgprint").fadeOut(500);
        //如果动画结束则删除节点
        if (!$("#msgprint").is(":animated")) {
            $("#msgprint").remove();
        }
    }, 3000);
}