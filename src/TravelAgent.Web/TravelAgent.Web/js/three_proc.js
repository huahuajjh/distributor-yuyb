//var url_u = "/buy";
var mobileReg = new RegExp(/^((\(\d{3}\))|(\d{3}\-))?((13|14)[0-9]|15[0-9]|18[0-9])\d{8}$/); //手机
var emailReg = new RegExp(/^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$/); //邮箱
var phoneReg = new RegExp(/^((\(\d{3}\))|(\d{3}\-))?(\(0\d{2,3}\)|0\d{2,3}-)?[1-9]\d{6,7}$/); //固定电话
var numsReg = new RegExp(/^[0-9]\d*$/); //正整数
var taitouReg = new RegExp(/^[(a-zA-Z0-9_\u4e00-\u9fa5 )]+$/);
$(function() {

        //发票
        var objinvoice = new invoice();
        objinvoice.getInvoice();
        //提交表单
        $("#btn_Next").click(function() {
                $("#txtHiddenFlag").val("next");
                if (!$("#agree_check").is(":checked")) {
                        $("#commonTip").show();
                        return;
                }
                if (!objinvoice.bindInvoice()) {
                        return;
                }
                document.getElementById("three_form").submit();
        });
        $("#but_Pay").click(function() {
                $("#txtHiddenFlag").val("pay");
                //表单提交
                if (!$("#agree_check").is(":checked")) {
                        $("#commonTip").show();
                        return;
                }
                if (!objinvoice.bindInvoice()) {
                        return;
                }
                document.getElementById("three_form").submit();
        });
});

function invoice() {
        //chnage concatuser
        $("input.J_changeType").bind("click", function() {
                var that = $(this);
                if (that.attr("data_value") == 1) {
                        $("dd.J_changeCon").hide();
                } else {
                        $("dd.J_changeCon").show();
                }
        });

        $("input.J_selYouHomeBtn").bind("click", function() {
                var that = $(this);
                if (that.attr("checked")) {
                        $(".J_selYouHome").show();
                } else {
                        $(".J_selYouHome").hide();
                }
        });

        //placeholder
        $.fn.extend({
                placeholder: function() {
                        var that = $(this);
                        if (that && !("placeholder" in document.createElement("input"))) {
                                that.bind("focus", function() {
                                        var placeholder = $(this).attr("placeholder");
                                        if ($(this).val() === placeholder) {
                                                $(this).val("");
                                                $(this).css("color", "");
                                        }
                                }).bind("blur", function() {
                                        var placeholder = $(this).attr("placeholder");
                                        if ($(this).val() === "") {
                                                $(this).val(placeholder);
                                                $(this).css("color", "#aaa");
                                        }
                                })
                                that.each(function() {
                                        var placeholder = $(this).attr("placeholder");
                                        if ($(this).val() === "") {
                                                $(this).val(placeholder);
                                                $(this).css("color", "#aaa");
                                        }
                                });
                        }
                },
                placeholderClear: function() {
                        var that = $(this);
                        that.each(function() {
                                var placeholder = $(this).attr("placeholder");
                                if ($(this).val() === placeholder) {
                                        $(this).val("");
                                        $(this).css("color", "");
                                }
                        });
                }
        });
        $("input.J_place").placeholder();
        //提交的时候调用$("input.J_place").placeholderClear();

        //获取发票信息
        this.getInvoice = function() {
                var invoiceInfo = $.trim($("#hiddenInvoice").val());
                if (invoiceInfo != "") {
                        invoiceInfoArr = invoiceInfo.split("^");
                        var isInvoice = invoiceInfoArr[0];
                        var taitou = invoiceInfoArr[1];
                        var type = invoiceInfoArr[2];
                        var Consignee = invoiceInfoArr[3];
                        var Address = invoiceInfoArr[4];
                        var PostCode = invoiceInfoArr[5];
                        var Mobile = invoiceInfoArr[6];

                        if (parseInt(isInvoice) > 0) {
                                $("#cbInvoice").attr("checked", true);
                                $(".J_selYouHome").show();
                                var userName = $.trim($("#hiddenUserName").val());
                                var mobile = $.trim($("#hiddenMobile").val());
                                $("#txtTaitou").val(taitou);
                                if (Consignee == userName && Mobile == mobile) {
                                        $("input[name='addtype']").eq(0).attr("checked", true);
                                }
                                else {
                                        $("input[name='addtype']").eq(1).attr("checked", true);
                                        $("#txtConsigneeName").val(Consignee);
                                        $("#txtConsigneeMobile").val(Mobile);
                                        $(".add_user").show();
                                }
                                $("#txtPostCode").val(PostCode);
                                $("#txtDetailAddress").val(Address);
                        } else {
                                $("#cbInvoice").attr("checked", false);
                        }
                }
        };

        //绑定发票信息
        this.bindInvoice = function() {
                if ($("#cbInvoice").attr("checked")) {
                        $(".J_selYouHome").find("span").hide();
                        var txtTaitou = $.trim($("#txtTaitou").val());
                        var selectInvoiceContent = $.trim($("#selectInvoiceContent").val());
                        var txtConsigneeName = $.trim($("#txtConsigneeName").val());
                        var txtConsigneeMobile = $.trim($("#txtConsigneeMobile").val());
                        if ($("input[name='addtype']").eq(0).attr("checked")) {
                                txtConsigneeName = $.trim($("#hiddenUserName").val());
                                txtConsigneeMobile = $.trim($("#hiddenMobile").val());
                        }
                        var province = $.trim($("dd.add_area").children("select").eq(0).val());
                        var city = $.trim($("dd.add_area").children("select").eq(1).val());
                        var area = $.trim($("dd.add_area").children("select").eq(2).val());

                        var address = province + city + area
                                + $.trim($("#txtDetailAddress").val());
                        var txtPostCode = $.trim($("#txtPostCode").val());
                        var invoicePrice = $.trim($("#txtHiddenPrePayMent").val());

                        if (!txtTaitou || txtTaitou == "") {
                                $("#txtTaitou").next("span").text("必填");
                                $(window).scrollTop($("#fapiao").offset().top - 20);
                                $("#txtTaitou").next("span").show();
                                return false;
                        }
                        else if (!taitouReg.test(txtTaitou)) {
                                $("#txtTaitou").next("span").text("输入内容不能包含特殊字符");
                                $(window).scrollTop($("#fapiao").offset().top - 20);
                                $("#txtTaitou").next("span").show();
                                return false;
                        }


                        if ($("input[name='addtype']").eq(1).attr("checked") && (!txtConsigneeName || txtConsigneeName == "" || txtConsigneeName == "姓名")) {
                                $("#txtConsigneeName").next("span").show();
                                $(window).scrollTop($("#fapiao").offset().top);
                                return false;
                        }

                        if ($("input[name='addtype']").eq(1).attr("checked") && (!txtConsigneeMobile || txtConsigneeMobile == "" || txtConsigneeMobile == "手机号码")) {
                                $("#txtConsigneeMobile").next("span").text("必填");
                                $("#txtConsigneeMobile").next("span").show();
                                $(window).scrollTop($("#fapiao").offset().top - 20);
                                return false;
                        }
                        if ($("input[name='addtype']").eq(1).attr("checked") && !(mobileReg.test(txtConsigneeMobile))) {
                                $("#txtConsigneeMobile").next("span").text("格式错误");
                                $("#txtConsigneeMobile").next("span").show();
                                $(window).scrollTop($("#fapiao").offset().top - 20);
                                return false;
                        }

                        if (province == "" || city == "" || area == "") {
                                $("#txtDetailAddress").next("span").text("请选择省市区");
                                $("#txtDetailAddress").next("span").show();
                                $(window).scrollTop($("#fapiao").offset().top - 20);
                                return false;
                        }

                        if (!$("#txtDetailAddress") || $.trim($("#txtDetailAddress").val()) == "" || $.trim($("#txtDetailAddress").val()) == "详细街道地址") {
                                $("#txtDetailAddress").next("span").text("必填");
                                $("#txtDetailAddress").next("span").show();
                                $(window).scrollTop($("#fapiao").offset().top - 20);
                                return false;
                        }

                        if (txtPostCode == "邮编（选填）") {
                                txtPostCode = "";
                        }

                        var invoiceStr = txtTaitou + "^" + selectInvoiceContent + "^" + txtConsigneeName + "^" + txtConsigneeMobile
                                + "^" + address + "^" + txtPostCode + "^" + invoicePrice;

                        $("#hiddenInvoice").val(invoiceStr);
                } else {
                        $("#hiddenInvoice").val("");
                }
                return true;
        };
}
;