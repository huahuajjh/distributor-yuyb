$(function() {
    $("#FileUpload1").bind("change", function() {
        //开始提交
        $("#form1").ajaxSubmit({
            beforeSubmit: function(formData, jqForm, options) {
                //隐藏上传按钮
                $(".files1").hide();
                //显示LOADING图片
                $(".uploading1").show();
            },
            success: function(data, textStatus) {
                debugger;
                if (data.msg == 1) {
                    $("#txtImgUrl1").val(data.msbox);
                } else {
                    alert(data.msbox);
                }
                $(".files1").show();
                $(".uploading1").hide();
            },
            error: function(data, status, e) {
                alert("上传失败，错误信息：" + e);
                $(".files1").show();
                $(".uploading1").hide();
            },
            url: "/Tools/SingleUpload1.ashx",
            type: "post",
            dataType: "json",
            timeout: 600000
        });
    });
});