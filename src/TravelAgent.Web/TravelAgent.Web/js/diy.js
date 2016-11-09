//保存目的地
var EditOrder = function() {
    $("#__VIEWSTATE").remove(); //这两句最重要
    $("#__EVENTVALIDATION").remove();
    $(this).attr("disabled", "disabled");
    $(this).val("正在提交中...");
    var options = {
        url: "/dataDeal/AddDiy.aspx?date=" + new Date().toUTCString(),
        type: 'POST',
        //beforeSubmit: Validate,
        success: function(responseText, statusText) {
            $("#btnSave").attr("disabled", "");
            $("#btnSave").removeAttr("disabled");
            $("#btnSave").val("确定提交");
            if (responseText.indexOf("true") >= 0) {
                location.href = "/DiyResult.aspx";
                return false;
            }
            else {
                alert("提交失败，可能是网站原因，请直接联系网站客服直接咨询！");
                return false;
            }
        }
    };
    $("#form1").ajaxSubmit(options);
}
$("#save").click(function() {
    var regexp = /^1[3|4|5|8][0-9]\d{8}$/;
    var regexpa = /^[0-9]*[1-9][0-9]*$/;
    if ($("#jingdian").val() == '') {
        $(".error_tip").text("景点城市为必须填写项！");
        $(".error_tip").show();
        return false;
    }
    else if ($("#days").val() == '') {
        $(".error_tip").text("行程天数必须填写项！");
        $(".error_tip").show();
        return false;
    }
    else if (!regexpa.test($("#days").val())) {
        $(".error_tip").text("行程天数不正确，只能为整数！");
        $(".error_tip").show();
        return false;
    }
    else if ($("#renshu").val() == '') {
        $(".error_tip").text("出游人数必须填写项！");
        $(".error_tip").show();
        return false;
    }
    else if (!regexpa.test($("#renshu").val())) {
        $(".error_tip").text("行程天数不正确，只能为整数！");
        $(".error_tip").show();
        return false;
    }
    else if ($("#price").val() == '') {
        $(".error_tip").text("单人预算必须填写项！");
        $(".error_tip").show();
        return false;
    }
    else if (!regexpa.test($("#price").val())) {
        $(".error_tip").text("行程天数不正确，只能为整数！");
        $(".error_tip").show();
        return false;
    }
    else if ($("#shijian").val() == '') {
        $(".error_tip").text("游玩时间必须填写项！");
        $(".error_tip").show();
        return false;
    }
    else if ($("#xingming").val() == '') {
        $(".error_tip").text("联系人为必须填写项！");
        $(".error_tip").show();
        return false;
    }
    else if ($("#xingming").val().length < 2) {
        $(".error_tip").text("联系人过短，请重新输入！");
        $(".error_tip").show();
        return false;
    }
    else if ($("#dianhua").val() == '') {
        $(".error_tip").text("手机号码为必须填写项！");
        $(".error_tip").show();
        return false;
    }
    else if ($("#xingming").val().length > 10) {
        $(".error_tip").text("联系人长度仅限10个字符，请重新输入！");
        $(".error_tip").show();
        return false;
    }
    else if ($("#dianhua").val().length != 11 || !regexp.test($("#dianhua").val())) {
        $(".error_tip").text("手机号码不正确，请重新输入！");
        $(".error_tip").show();
        return false;
    }
    EditOrder();
})