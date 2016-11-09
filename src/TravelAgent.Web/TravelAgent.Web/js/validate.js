/*
* Translated default messages for the jQuery validation plugin.
* Locale: CN
*/
jQuery.extend(jQuery.validator.messages, {
    required: "必填项",
    remote: "请修正该项",
    email: "请输入正确格式的电子邮件",
    url: "请输入合法的域名网址",
    date: "请输入合法的日期",
    dateISO: "请输入合法的日期 (ISO).",
    number: "请输入合法的数字",
    digits: "只能输入整数",
    creditcard: "请输入合法的信用卡号",
    equalTo: "请再次输入相同的值",
    accept: "请输入拥有合法后缀名的字符串",
    maxlength: jQuery.validator.format("请输入一个长度最多是 {0} 的字符串"),
    minlength: jQuery.validator.format("请输入一个长度最少是 {0} 的字符串"),
    rangelength: jQuery.validator.format("请输入一个长度介于 {0} 和 {1} 之间的字符串"),
    range: jQuery.validator.format("请输入一个介于 {0} 和 {1} 之间的值"),
    max: jQuery.validator.format("请输入一个最大为 {0} 的值"),
    min: jQuery.validator.format("请输入一个最小为 {0} 的值")
});
function same(pwd) {
    return $("#txtOPass").val() != pwd;
}
$(function() {
    jQuery.validator.addMethod("mobile", function(value, element) {
        var length = value.length;
        var mobile = /^(((13[0-9]{1})|(15[0-9]{1})|(18[0-9]{1}))+\d{8})$/
        return this.optional(element) || (length == 11 && mobile.test(value));
    }, "手机号码格式错误");
    jQuery.validator.addMethod("same", function(value, element) {
        return this.optional(element) || same(value);
    }, "新密码不能与原密码重复"); 
    
    $(".input,.login_input,.textarea").focus(function() {
        $(this).addClass("focus");
    }).blur(function() {
        $(this).removeClass("focus");
    });

    //输入框提示,获取拥有HintTitle,HintInfo属性的对象
    $("[HintTitle],[HintInfo]").focus(function(event) {
        $("*").stop(); //停止所有正在运行的动画
        $("#HintMsg").remove(); //先清除，防止重复出错
        var HintHtml = "<ul id=\"HintMsg\"><li class=\"HintTop\"></li><li class=\"HintInfo\"><b>" + $(this).attr("HintTitle") + "</b>" + $(this).attr("HintInfo") + "</li><li class=\"HintFooter\"></li></ul>"; //设置显示的内容
        var offset = $(this).offset(); //取得事件对象的位置
        $("body").append(HintHtml); //添加节点
        $("#HintMsg").fadeTo(0, 0.85); //对象的透明度
        var HintHeight = $("#HintMsg").height(); //取得容器高度
        $("#HintMsg").css({ "top": offset.top - HintHeight + "px", "left": offset.left + "px" }).fadeIn(500);
    }).blur(function(event) {
        $("#HintMsg").remove(); //删除UL
    });
});
(function($){
    $.getUrlParam = function(name)
    {
    var reg = new RegExp("(^|&)"+ name +"=([^&]*)(&|$)");
    var r = window.location.search.substr(1).match(reg);
    if (r!=null) return unescape(r[2]); return null;
    }
})(jQuery);
