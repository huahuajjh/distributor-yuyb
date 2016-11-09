var mobileReg = new RegExp(/^((\(\d{3}\))|(\d{3}\-))?((13|14)[0-9]|15[0-9]|18[0-9])\d{8}$/); //手机
var emailReg = new RegExp(/^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$/); //邮箱
var phoneReg = new RegExp(/^((\(\d{3}\))|(\d{3}\-))?(\(0\d{2,3}\)|0\d{2,3}-)?[1-9]\d{6,7}$/); //固定电话
var numsReg = new RegExp(/^[0-9]\d*$/); //正整数
var taitouReg = new RegExp(/^[(a-zA-Z0-9_\u4e00-\u9fa5 )]+$/);
$(function () {

    //**出发地点选择**//
    $("input[name=rad_UpTrainPlace]").eq(0).attr("checked", true);    //默认选择第一个
    $("a[id^='radspan_']").click(function () {
        var radId = $(this).attr("id").substr($(this).attr("id").lastIndexOf("_") + 1); //关系Id，不重复
        $("input[name=rad_UpTrainPlace][id='rad_" + radId + "']").attr("checked", true);
    });

    //升级方案选择
    $("input[name='case_id']").click(function () {
        $("#txtHiddenAdultPrice").val($(this).data('adult'));
        $("#txtHiddenChildPrice").val($(this).data('child'));
        $("#b_adult").text($(this).data('adult'));
        $("#b_child").text($(this).data('child'));
        sumAll();
    });
    $("input[name='case_id']").eq(0).attr("checked", true).click();    //默认选择第一个

    //**所有附加产品的备注隐藏和展示**//
    toggle_table();
    //**份数的改变事件**//
    ddlnumsChange();
    //**调用默认选择产品**//
    DefaultProductSet();
    //**调用默认选择份数**//
    DefaultNumsSet();
    //调用计算原价的函数
    sumAll();
    //*************联系人验证******************//
    //姓名
    $("#txt_name").blur(function () {
        $(this).next().text("");
        if ($.trim($(this).val()) == "") {
            $(this).next().text("必填");
        }
    });
    //手机
    $("#txt_mobile").blur(function () {
        $(this).next().text("");
        if ($.trim($(this).val()) == "") {
            $(this).next().text("必填");
        } else {
            if (!mobileReg.test($.trim($(this).val()))) {
                $(this).next().text("格式错误");
            }
        }
    });
    //Email
    $("#txt_email").blur(function () {
        $(this).next().text("");
        if ($.trim($(this).val()) == "") {
            if ($("#txtHiddenIsPay").val() == "True") {
                $(this).next().text("必填");
            }
        }
        else {
            if (!emailReg.test($.trim($(this).val()))) {
                $(this).next().text("格式错误");
            }
        }
    });
    //固定电话
    $("#txt_start_phone,#txt_end_phone").blur(function () {
        $("#span_phone").text("");
        var start = $.trim($("#txt_start_phone").val());
        var end = $.trim($("#txt_end_phone").val());
        var phone = (start != "") ? start + "-" + end : end;
        if (phone != "" && !phoneReg.test(phone)) {
            $("#span_phone").text("格式错误");
        }
    });
    //订单备注字数限制
    $("#txtDes").keyup(function () {
        var des = $(this).val();
        if (des.length <= 200) {
            //$("#eCodeLeft").text(parseInt(200 - des.length));
        } else {
            $(this).val($(this).val().substr(0, 200));
        }
    });
    //修改游客人数
    $("input[id='txtPersonNums'],input[id='txtChildNums']").focus(function () {
        $(this).val("");
    }).blur(function () {
        if ($(this).val() == "") {
            if ($(this).get(0).id.indexOf("txtPersonNums") >= 0) {
                $(this).val($("#txtHiddenPersonNum").val());
            }
            else if ($(this).get(0).id.indexOf("txtChildNums") >= 0) {
                $(this).val($("#txtHiddenChildNum").val());
            }
        }
    });
    //**成人数、儿童数与起订人数的判断**//
    $("input[id='txtPersonNums']").keyup(function () {
        var nums = $(this).val();
        if (nums == "") {
            $(this).val($("#txtHiddenPersonNum").val());
        } else {
            if (!numsReg.test(nums)) {
                $(this).val($("#txtHiddenPersonNum").val());
            }
        }
    });
    $("input[id='txtChildNums']").keyup(function () {
        var nums = $(this).val();
        if (nums == "") {
            $(this).val($("#txtHiddenChildNum").val());
        } else {
            if (!numsReg.test(nums)) {
                $(this).val($("#txtHiddenChildNum").val());
            }
        }
    });
    //**成人数、儿童数变动时**//
    $("input[id='txtPersonNums'],input[id='txtChildNums']").blur(function () {
        var person = parseInt($("#txtPersonNums").val()); //成人数
        var child = parseInt($("#txtChildNums").val()); //儿童数
        if (person + child < 1) {
            $("#txtPersonNums").val(1);
            person = 1;
        }
        //人数有了改变
        $("#txtHiddenPersonNum").val(person); //成人数
        $("#txtHiddenChildNum").val(child); //儿童数
        $("#txtHiddenNums").val(person + child); //总数
        DefaultProductSet(); //可以选择的附加产品的显示列表
        DefaultNumsSet(); //设置份数
        //SafetySortAndDefautNums(); //保险产品的排序并选中
        ControlleTable(); //附加产品的显示和隐藏
        sumAll(); //计算
        safetyDisplay(); //买保险提示
    });
    //**页面提交**//
    $("input[id='btn_Next'],input[id='btn_Next_2']").click(function () {
        /*****************判断联系人信息*******************/
        var flag = false;
        var link_name = $.trim($("#txt_name").val());
        var link_mobile = $.trim($("#txt_mobile").val());
        var link_email = $.trim($("#txt_email").val());
        var strat_phone = $.trim($("#txt_start_phone").val());
        var end_phone = $.trim($("#txt_end_phone").val());
        var des = $.trim($("#txtDes").val());
        var tuijianren = $.trim($("#txt_tuijianren").val());

        //联系人姓名
        if (link_name == "") {
            $("#txt_name").next().text("必填");
            flag = true;
        }
        //联系人手机
        if (link_mobile == "") {
            $("#txt_mobile").next().text("必填");
            flag = true;
        } else {
            if (!mobileReg.test(link_mobile)) {
                $("#txt_mobile").next().text("格式错误");
                flag = true;
            }
        }
        //联系人邮箱
        if (link_email == "") {
            if ($("#txtHiddenIsPay").val() == "True") {
                $("#txt_email").next().text("必填");
                flag = true;
            }
        } else {
            if (!emailReg.test(link_email)) {
                $("#txt_email").next().text("格式错误");
                flag = true;
            }
        }
        //联系人的固定电话
        var phone = (strat_phone != "") ? strat_phone + "-" + end_phone : end_phone;
        if (phone != "" && !phoneReg.test(phone)) {
            $("#span_phone").text("格式错误");
            flag = true;
        }
        //推荐人
        if (tuijianren.length < 2) {
            $("#span_tuijianren").text("请输入推荐人");
            flag = true;
        }
        if (flag) {
            /*定位焦点*/
            $(".userTypeContact table").find("span").each(function () {
                if ($.trim($(this).text()) == "必填" || $.trim($(this).text()) == "格式错误") {
                    $(this).prevAll("input").focus();
                    return false; //跳出循环
                }
            });
            /*定位焦点 End*/
            return;
        }
        /****************************上车地点***********************************/
        if ($('input[name=rad_UpTrainPlace]').length > 0 && $('input[name=rad_UpTrainPlace]:checked').val() != '') {
            $("#txtSubmitHiddenUpTrain").val($.trim($('input[name=rad_UpTrainPlace]:checked').val())); //上车地点
        }
        $("#txtHiddenLinker").val(link_name + "^" + link_mobile + "^" + link_email + "^" + phone); //放在隐藏域中
        /****************************附加产品***********************************/
        if (des != '' && des != "仅限输入200字") {
            $("#txtHiddenDes").val(des);
        }

        if (tuijianren != '' && tuijianren != null) {

            $("#txtHiddentuijianren").val(tuijianren);

        }
        if ($.cookie('uid') !== null) {
            //提交表单
            $.md({ modal: "#xs2" });
            $("#one_form").submit();
        } else {
            editWidget("/member/QuickLogin.aspx?actionName=buySubmit&tel=" + link_mobile);
        }
    });
    //当页面都加载完才显示下面的提交按钮
    $("#gl_return").css("display", "block");
    $("#btn_Next_2").css("display", "inline");

});

//**计算原价和优惠价等信息**//
function sumAll() {
        $("#AddPList").html("");
        $("#AddPList").show();
        var person = $("#txtHiddenPersonNum").val(); //成人数
        var child = $("#txtHiddenChildNum").val(); //儿童数
        var person_price = $("#txtHiddenAdultPrice").val(); //成人价
        var child_price = $("#txtHiddenChildPrice").val(); //儿童价
        var hotel_total = $("#txtHiddenHotelTotal").val()?$("#txtHiddenHotelTotal").val():0; //酒店差价
        /**线路产品 Start**/
        $("#b_personnums").text(person);
        $("#b_childnums").text(child);
        $("#s_personall").text(parseFloat(person * person_price)+ parseFloat(hotel_total));
        $("#s_childall").text(parseFloat(child * child_price));
        /**线路产品 Start**/

        /**附加产品 Start**/
        var html = "";
        var addProTotal = 0; //附加产品的总金额
        if (!$(".attach").is(":hidden")) {
            $("div[id^='dd_travel_'] select[id^='ddl_nums_'][value!='0']").each(function(i) {
                if ($(this).val() != 0) {
                    var relationId = $(this).attr("id").substr($(this).attr("id").lastIndexOf("_") + 1);
                    var title = $("#a_" + relationId).text(); //附加产品名称
                    var gounum = document.getElementById("ddl_nums_" + relationId).value; //附加产品购买份数
                    var price = $.trim($("#td_price_" + relationId).text()); //附加产品单价
                    var total = $.trim($("#td_total_" + relationId).text()); //总价
                    if ($("div[id^='dd_travel_'] select[id^='ddl_nums_'][value!='0']").length - 1 == i) {
                        //最后一行加样式
                        html += "<div class=\"last\"><p>" + title + "</p><p><b>￥<s>" + total + "</s></b>" + gounum + "份×￥" + price + "</p></div>";
                    } else {
                        html += "<div><p>" + title + "</p><p><b>￥<s>" + total + "</s></b>" + gounum + "份×￥" + price + "</p></div>";
                    }
                    addProTotal += parseFloat(total);
                }
            });
            $("#txtHiddenAttachPrice").val(addProTotal);//附加费用总和
        }
        else {
            html += "<div class=\"last\"><p>赠送保险</p></div>";
        }
       
        if (html != "") {
                $("#AddPList").append("<p class=\"p1\">附加产品</p>" + html);
        }
        /**附加产品 End**/

        //应付金额
        var all = parseFloat(person * person_price) + parseFloat(child * child_price) + parseFloat(addProTotal) + parseFloat(hotel_total) ;
        if (all < 0) {
                $("#offerPrice").text(0);
                $("#hiddenPrepayMent").val(0);
        }
        else {
                $("#offerPrice").text(all);
                $("#hiddenPrepayMent").val(all);
        }
        //线路总价
        $("#proTotal").text(parseFloat(person * person_price) + parseFloat(child * child_price));
}

//**如果附加产品中保险一个都没有选择**//
function safetyDisplay() {
        var safety = 0;
        var ii = 0;
        //**所有附加产品的类型**//
        $("div[id^='dd_travel_'] input[id^='txtHiddenAddProductTypeId_']").each(function() {
                var id = $(this).attr("id");
                var relationId = id.substr(id.lastIndexOf("_") + 1); //关系Id，不重复
                var type = $(this).val(); //附加产品类型
                if (type == 3) {
                        ii++;
                        var nums = $("#ddl_nums_" + relationId).val();
                        safety = parseInt(safety) + parseInt(nums);
                }
        });
        //有保险可以选择，但是没有购买保险
        if (ii > 0 && safety == 0) {
                if ("div[class='notice_2']") {
                        $("div[class='notice_2']").remove();
                }
                $("div[id^='dd_travel_'] input[id^='txtHiddenAddProductTypeId_'][value='3']").eq(0).parents("div").eq(0).append("<div class=\"notice_2\">旅游保险能够给您的出行安全带来更多保障，所以建议您务必购买旅游保险。如您放弃购买，则行程中的风险和损失将由您自行承担。</div>");
        } else {
                if ("div[class='notice_2']") {
                        $("div[class='notice_2']").remove();
                }
        }
}
/*初始化附加产品默认值（选择分数）及是否显示的控制*/
function DefaultProductSet() {
        var person = parseInt($("#txtHiddenPersonNum").val()); //成人数
        var child = parseInt($("#txtHiddenChildNum").val()); //儿童数
        //循环的是适用人群
        $("table[id^='table_']").each(function() {
                var id = $(this).attr("id");
                var relationId = id.substr(id.lastIndexOf("_") + 1); //关系Id，不重复
                var default_nums = person + child;

                //将默认值保存到隐藏域中
                $("#txtHiddenDefaultNums_" + relationId).val(default_nums);
        });
}
//**初始化所有的份数都从0开始到出行人数及默认值**//
function DefaultNumsSet() {
        $("div[id^='dd_travel_'] select[id^='ddl_nums_']").each(function() {
                var id = $(this).attr("id");
                var relationId = id.substr(id.lastIndexOf("_") + 1); //关系Id，不重复
                //清除原来的
                $(this).find("option").remove();
                var defaultNums = $("#txtHiddenDefaultNums_" + relationId).val(); //按照行人数的默认值

                if (defaultNums > 0) {
                        for (var i = 0; i <= defaultNums; i++) {
                                //$(this).append("<option value=\"" + i + "\">" + i + "</option>");//这句IE6不兼容，所以换成下面的方式。
                                var obj = document.getElementById($(this).attr("id"));
                                var op = new Option(i, i);
                                obj.options.add(op);
                        }
                } else {
                        $("#ddl_nums_" + relationId).append("<option value=\"0\">0</option>");
                        $("#tr_" + relationId).css("display", "none"); //隐藏
                }
                $(this).val(defaultNums);
                $(this).change();
        });
}

//**份数的改变事件**//
function ddlnumsChange() {
        $("div[id^='dd_travel_'] select[id^='ddl_nums_']").each(function() {
                $(this).change(function() {
                        var id = $(this).attr("id");
                        var relationId = id.substr(id.lastIndexOf("_") + 1); //关系Id，不重复
                        var personNums = $(this).val(); //购买份数
                        var price = $("#td_price_" + relationId).text(); //附加产品单价

                        $("#td_total_" + relationId).text(parseFloat(personNums * price)); //显示总价

                        //调用计算原价的函数
                        sumAll();
                        safetyDisplay(); //买保险提示
                });
        });
}

//**所有附加产品的备注隐藏和展示**//
function toggle_table() {
        $('div[id^="dd_travel_"] table tr td.lt a[id^="atoggle_"]').live("click", function() {
                var o = $(this);
                var hd = o.parents('tr').next('tr.trhide');
                if ($.trim(hd.html()).length <= 0) {
                        return false;
                }
                if (hd.css('display') === 'none') {
                        o.find('span.arrowFlag').text('▲');
                        hd.show();
                } else {
                        o.find('span.arrowFlag').text('▼');
                        hd.hide();
                }
        });
}

//**控制附加产品表头和类别名称是否显示**//
function ControlleTable() {
        $("div[id^='dd_travel_'] table[id^='table_']").each(function() {
                var count = 0;
                $(this).find("tr[class!='trhide']").each(function() {
                        if ($(this).css("display") == "none") {
                                count++;
                        }
                });
                if (count + 1 == $(this).find("tr[class!='trhide']").length) {
                        //如果除去第一行显示（block）那么则隐藏这个模块
                        var ddl_travel_id = $(this).parent().attr("id");
                        $("#" + ddl_travel_id).prev().css("display", "none"); //table外面的附加产品标题也一起隐藏
                        $("#" + ddl_travel_id).css("display", "none"); //隐藏掉
                }
                else {
                        var ddl_travel_id = $(this).parent().attr("id");
                        $("#" + ddl_travel_id).prev().css("display", "block"); //table外面的附加产品标题也一起隐藏
                        $("#" + ddl_travel_id).css("display", "block"); //隐藏掉
                }
        });
        //附加产品选项消失
        var j = 0;
        $("div[id^='dd_travel_']").each(function() {
                if ($(this).css("display") == "none") {
                        j++;
                }
        });
        if ($("div[id^='dd_travel_']").length == j) {
                $("#h2_proadd").css("display", "none"); //删除“附加产品”标题
        }
        else {
                $("#h2_proadd").css("display", "block"); //删除“附加产品”标题
        }
}

//***提交表单，供给”快速登录“回来调用***//
function buySubmit() {
        //提交表单
        $.md({modal: "#xs2"});
        $("#one_form").submit();
}
