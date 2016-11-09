var mobileReg = new RegExp(/^((\(\d{3}\))|(\d{3}\-))?((13|14)[0-9]|15[0-9]|18[0-9])\d{8}$/); //手机
var codeReg = new RegExp(/^(\d{15}$|^\d{18}$|^\d{17}(\d|X|x))$/); //身份证
var hzhaoReg = new RegExp(/^[A-Za-z\d]*$/); //护照
var gangaoReg = new RegExp(/^[A-Za-z]{1,2}\d{7,10}$/); //港澳通行证
var emailReg = new RegExp(/^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$/); //邮箱
var phoneReg = new RegExp(/^((\(\d{3}\))|(\d{3}\-))?(\(0\d{2,3}\)|0\d{2,3}-)?[1-9]\d{6,7}$/); //固定电话
var dataeReg = new RegExp(/^((((19|20)\d{2})-(0?(1|[3-9])|1[012])-(0?[1-9]|[12]\d|30))|(((19|20)\d{2})-(0?[13578]|1[02])-31)|(((19|20)\d{2})-0?2-(0?[1-9]|1\d|2[0-8]))|((((19|20])([13579][26]|[2468][048]|0[48]))|(2000))-0?2-29))$/); //日期
var nameReg = new RegExp(/^[A-Za-z\u4E00-\u9FA5\_\＿\/]+$/); //姓名【字母，中文，下划线，反斜线】
$(function() {
        $(".b_date").mask("9999-99-99"); //控制日期输入格式
        //************国内成人自动补全************//
        $("ul[id^='ul_ch_person_']").find("a").click(function() {
                var des = $(this).attr("des"); //游客的详细信息，以逗号隔开
                if (des.length > 0) {
                        var ul_Id = $(this).parents("ul").attr("id");
                        var ii = ul_Id.substr(ul_Id.lastIndexOf("_") + 1);
                        $("#txt_ch_person_UserId_" + ii).val(des.split(',')[0]); //隐藏域 游客Id
                        $("#txt_ch_person_Phone_" + ii).val(des.split(',')[7]); //手机
                        $("#ddl_ch_person_CodeType_" + ii).val(des.split(',')[4]); //证件类别
                        $("#txt_ch_person_Code_" + ii).val(des.split(',')[5]); //证件号码
                        $("#ddl_ch_person_Sex_" + ii).val(des.split(',')[3]); //性别
                        $("#txt_ch_person_Birthday_" + ii).val(des.split(',')[6]); //生日
                        $("#ddl_ch_person_CodeType_" + ii).change(); //触发证件类别的事件
                        $("#txt_ch_person_RealName_" + ii).focus(); //触发真实姓名获取焦点事件
                }
        });
        //************国内儿童自动补全************//
        $("ul[id^='ul_ch_child_']").find("a").click(function() {
                var des = $(this).attr("des"); //游客的详细信息，以逗号隔开
                if (des.length > 0) {
                        var ul_Id = $(this).parents("ul").attr("id");
                        var ii = ul_Id.substr(ul_Id.lastIndexOf("_") + 1);
                        $("#txt_ch_child_UserId_" + ii).val(des.split(',')[0]); //隐藏域 游客Id
                        $("#ddl_ch_child_Sex_" + ii).val(des.split(',')[3]); //性别
                        $("#txt_ch_child_Birthday_" + ii).val(des.split(',')[6]); //出生年月
                        $("#txt_ch_child_RealName_" + ii).focus(); //触发真实姓名获取焦点事件
                }
        });
        //************出境成人自动补全************//
        $("ul[id^='ul_en_person_']").find("a").click(function() {
                var des = $(this).attr("des"); //游客的详细信息，以逗号隔开
                if (des.length > 0) {
                        var ul_Id = $(this).parents("ul").attr("id");
                        var ii = ul_Id.substr(ul_Id.lastIndexOf("_") + 1);
                        $("#txt_en_person_UserId_" + ii).val(des.split(',')[0]); //隐藏域 游客Id
                        $("#ddl_en_person_Sex_" + ii).val(des.split(',')[3]); //性别
                        $("#txt_en_person_Nationality_" + ii).val(des.split(',')[4]); //国籍
                        $("#ddl_en_person_Type_" + ii).val(des.split(',')[5]); //证件类别
                        $("#txt_en_person_Birthday_" + ii).val(des.split(',')[9]); //出生年月
                        $("#txt_en_person_Code_" + ii).val(des.split(',')[6]); //证件号码
                        $("#txt_en_person_Valiad_" + ii).val(des.split(',')[7]); //证件有效期    
                        $("#txt_en_person_CodeAddress_" + ii).val(des.split(',')[8]); //签发地
                        $("#txt_en_person_Phone_" + ii).val(des.split(',')[10]); //手机
                        $("#ddl_en_person_Type_" + ii).change(); //触发证件类别事件
                        $("#txt_en_person_RealName_" + ii).focus(); //触发真实姓名获取焦点事件
                }
        });
        //************出境儿童自动补全************//
        $("ul[id^='ul_en_child_']").find("a").click(function() {
                var des = $(this).attr("des"); //游客的详细信息，以逗号隔开
                if (des.length > 0) {
                        var ul_Id = $(this).parents("ul").attr("id");
                        var ii = ul_Id.substr(ul_Id.lastIndexOf("_") + 1);
                        $("#txt_en_child_UserId_" + ii).val(des.split(',')[0]); //隐藏域 游客Id
                        $("#ddl_en_child_Sex_" + ii).val(des.split(',')[3]); //性别
                        $("#txt_en_child_Nationality_" + ii).val(des.split(',')[4]); //国籍
                        $("#ddl_en_child_Type_" + ii).val(des.split(',')[5]); //证件类别
                        $("#txt_en_child_Birthday_" + ii).val(des.split(',')[9]); //出生年月
                        $("#txt_en_child_Code_" + ii).val(des.split(',')[6]); //证件号码
                        $("#txt_en_child_Valiad_" + ii).val(des.split(',')[7]); //证件有效期    
                        $("#txt_en_child_CodeAddress_" + ii).val(des.split(',')[8]); //签发地
                        $("#ddl_en_child_Type_" + ii).change(); //触发证件类别事件
                        $("#txt_en_child_RealName_" + ii).focus(); //触发真实姓名获取焦点事件
                }
        });
        //如果不是选择下拉列表中的常用游客，而是输入的则调用这个方法
        inputUserNameFillOtherInfo();
        //*************国内成人证件类别的选择******************//
        $("select[id^='ddl_ch_person_CodeType_']").change(function() {
                var type = $(this).val(); //证件类型
                var ii = $(this).attr("id").substr($(this).attr("id").lastIndexOf("_") + 1);
                if (type == 0) {//身份证
                        //证件号码显示
                        $("#td_ch_person_CodeTitle_" + ii).show();
                        $("#td_ch_person_CodeInput_" + ii).show();
                        //生日和性别隐藏
                        $("#tr_ch_person_sexandbirthday_" + ii).hide();
                }
                else if (type == "5") {//稍后提供
                        //证件号码隐藏
                        $("#td_ch_person_CodeTitle_" + ii).hide();
                        $("#td_ch_person_CodeInput_" + ii).hide();
                        //生日和性别隐藏
                        $("#tr_ch_person_sexandbirthday_" + ii).hide();
                }
                else {
                        //证件号码显示
                        $("#td_ch_person_CodeTitle_" + ii).show();
                        $("#td_ch_person_CodeInput_" + ii).show();
                        //生日和性别显示
                        $("#tr_ch_person_sexandbirthday_" + ii).show();
                }
        });

        //*************出境成人证件类别的选择******************//
        $("select[id^='ddl_en_person_Type_']").change(function() {
                var type = $(this).val(); //证件类型
                var ii = $(this).attr("id").substr($(this).attr("id").lastIndexOf("_") + 1);
                if (type == "-1") {//稍后提供
                        $(".tr_en_person_Code_" + ii).hide();
                }
                else {

                        $(".tr_en_person_Code_" + ii).show();
                }
        });
        //*************出境儿童证件类别的选择******************//
        $("select[id^='ddl_en_child_Type_']").change(function() {
                var type = $(this).val(); //证件类型
                var ii = $(this).attr("id").substr($(this).attr("id").lastIndexOf("_") + 1);
                if (type == "-1") {//稍后提供
                        //证件号码隐藏
                        $("#tr_en_child_Code_" + ii).hide();
                        $("#tr_en_child_CodeTitle_" + ii).hide();
                        $("#tr_en_child_CodeInput_" + ii).hide();
                }
                else {
                        //证件号码显示
                        $("#tr_en_child_Code_" + ii).show();
                        $("#tr_en_child_CodeTitle_" + ii).show();
                        $("#tr_en_child_CodeInput_" + ii).show();
                }
        });
        //*************国内成人、儿童验证******************//
        //成人、儿童真实姓名验证
        $("input[id^='txt_ch_person_RealName_'],input[id^='txt_ch_child_RealName_']").blur(function() {
                $(this).parent("div").find("span").text("");
                if ($.trim($(this).val()) == "") {
                        $(this).parent("div").find("span").text("必填");
                } else {
                        //判断姓名的格式
                        if (!nameReg.test($.trim($(this).val()))) {
                                $(this).parent("div").find("span").text("格式错误");
                        }
                }
        });
        //手机验证
        $("input[id^='txt_ch_person_Phone_']").blur(function() {
                $(this).next().text("");
                if ($.trim($(this).val()) == "") {
                        $(this).next().text("必填");
                }
                else {
                        if (!mobileReg.test($.trim($(this).val()))) {
                                $(this).next().text("格式错误");
                        }
                }
        });
        //证件号码验证
        $("input[id^='txt_ch_person_Code_']").blur(function() {
                var ii = $(this).attr("id").substr($(this).attr("id").lastIndexOf("_") + 1);
                var type = $("#ddl_ch_person_CodeType_" + ii).val(); //选择证件类型
                $(this).next().text("");
                $("#divwrongId_" + ii).hide();
                if ($.trim($(this).val()) == "") {
                        $(this).next().text("必填");
                } else {
                        if (type == "0") {//选择了省份证
                                if (!codeReg.test($.trim($(this).val()))) {
                                        $(this).next().text("格式错误");
                                } else {
                                        if ($.trim($("#txtHiddenMType").val()) == "2") {
                                                var sfcode = $.trim($(this).val());
                                                var bday = "";
                                                var godate = $.trim($("#hiddenGodate").val()).replace("-", "/").replace("-", "/");
                                                if (sfcode.length == 18) {
                                                        bday = sfcode.substr(6, 4) + "/" + sfcode.substr(10, 2) + "/" + sfcode.substr(12, 2);
                                                }
                                                else if (sfcode.length == 15) {
                                                        bday = "19" + sfcode.substr(6, 2) + "/" + sfcode.substr(8, 2) + "/" + sfcode.substr(10, 2);
                                                }
                                                var dateday = new Date(bday);
                                                //成人
                                                var comdate = new Date(godate).setFullYear(new Date(godate).getFullYear() - 12);
                                                if (dateday > comdate) {
                                                        $(this).next().text("×");
                                                        $("#divwrongId_" + ii).show();
                                                }

                                        }
                                }
                        }
                }
        });
        //儿童生日验证
        $("input[id^='txt_ch_child_Birthday_'],input[id^='txt_ch_person_Birthday_']").blur(function() {
                var ii = $(this).attr("id").substr($(this).attr("id").lastIndexOf("_") + 1);
                $(this).next().text("");
                if ($(this).attr("id").indexOf("txt_ch_child_Birthday_") >= 0) {//表示儿童
                        $("#divwrongbdays_" + ii).hide();
                } else { //表示成人            
                        $("#divwrongId_" + ii).hide();
                }
                if ($.trim($(this).val()) == "") {
                        $(this).next().text("必填");
                } else {
                        if (!dataeReg.test($.trim($(this).val()))) {
                                $(this).next().text("格式错误");
                        }
                        else {
                                if ($.trim($("#txtHiddenMType").val()) == "2") {
                                        var bday = $.trim($(this).val()).replace("-", "/").replace("-", "/");
                                        var godate = $.trim($("#hiddenGodate").val()).replace("-", "/").replace("-", "/");
                                        var dateday = new Date(bday);
                                        if ($(this).attr("id").indexOf("txt_ch_child_Birthday_") >= 0) {//表示儿童
                                                var comdateMin = new Date(godate).setFullYear(new Date(godate).getFullYear() - 12);
                                                var comdateMax = new Date(godate).setFullYear(new Date(godate).getFullYear() - 2);
                                                if (dateday < comdateMin || dateday > comdateMax) {
                                                        $(this).next().text("×");
                                                        $("#divwrongbdays_" + ii).show();
                                                }
                                        } else {//表示成人
                                                //国内12岁以下算儿童，以上算成人
                                                var comdate = new Date(godate).setFullYear(new Date(godate).getFullYear() - 12);
                                                if (dateday > comdate) {
                                                        $(this).next().text("×");
                                                        $("#divwrongId_" + ii).show();
                                                }
                                        }
                                }
                        }
                }
        });
        //*************出境成人、儿童验证******************//
        //成人、儿童的中文名称验证
        $("input[id^='txt_en_person_RealName_'],input[id^='txt_en_child_RealName_']").blur(function() {
                $(this).parent("div").find("span").text("");
                if ($.trim($(this).val()) == "") {
                        $(this).parent("div").find("span").text("必填");
                }
        });
        //成人、儿童的国籍验证
        $("input[id^='txt_en_person_Nationality_'],input[id^='txt_en_child_Nationality_']").blur(function() {
                $(this).next().text("");
                if ($.trim($(this).val()) == "") {
                        $(this).next().text("必填");
                }
        });
        //成人、儿童的生日验证
        $("input[id^='txt_en_child_Birthday_'],input[id^='txt_en_person_Birthday_']").blur(function() {
                $(this).next().text("");
                if ($.trim($(this).val()) == "") {
                        $(this).next().text("必填");
                } else {
                        if (!dataeReg.test($.trim($(this).val()))) {
                                $(this).next().text("格式错误");
                        }
                }
        });
        //成人的证件号码验证
        $("input[id^='txt_en_person_Code_']").blur(function() {
                var ii = $(this).attr("id").substr($(this).attr("id").lastIndexOf("_") + 1);
                var type = $("#ddl_en_person_Type_" + ii).val(); //选择证件类型
                $(this).next().text("");
                if ($.trim($(this).val()) == "") {
                        $(this).next().text("必填");
                }
                else {
                        if (type == "0") {//护照
                                if (!hzhaoReg.test($.trim($(this).val()))) {
                                        $(this).next().text("格式错误");
                                }
                        }
                        if (type == "1") {//港澳通行证
                                if (!gangaoReg.test($.trim($(this).val()))) {
                                        $(this).next().text("格式错误");
                                }
                        }
                }
        });
        //儿童的证件号码验证
        $("input[id^='txt_en_child_Code_']").blur(function() {
                var ii = $(this).attr("id").substr($(this).attr("id").lastIndexOf("_") + 1);
                var type = $("#ddl_en_child_Type_" + ii).val(); //选择证件类型
                $(this).next().text("");
                if ($.trim($(this).val()) == "") {
                        $(this).next().text("必填");
                }
                else {
                        if (type == "0") {//护照
                                if (!hzhaoReg.test($.trim($(this).val()))) {
                                        $(this).next().text("格式错误");
                                }
                        }
                        if (type == "1") {//港澳通行证
                                if (!gangaoReg.test($.trim($(this).val()))) {
                                        $(this).next().text("格式错误");
                                }
                        }
                }
        });
        //成人、儿童的证件有效期验证
        $("input[id^='txt_en_person_Valiad_'],input[id^='txt_en_child_Valiad_']").blur(function() {
                $(this).next().text("");
                if ($.trim($(this).val()) == "") {
                        $(this).next().text("必填");
                }
                else {
                        if (!dataeReg.test($.trim($(this).val()))) {
                                $(this).next().text("格式错误");
                        }
                }
        });
        //成人的手机验证
        $("input[id^='txt_en_person_Phone_']").blur(function() {
                $(this).next().text("");
                if ($.trim($(this).val()) == "") {
                        $(this).next().text("必填");
                }
                else {
                        if (!mobileReg.test($.trim($(this).val()))) {
                                $(this).next().text("格式错误");
                        }
                }
        });
        //*************提交下一步表单******************//
        $("#btn_Next,#btn_Next_2").click(function() {
                $(".userInfo table").find("span").text("");
                var clientArr = "";
                var flag = false;
                var otherUserNameArray = new Array(); //名称集合
                var otherUserPassCodeArray = new Array(); //证件集合
                //******国内 成人*****//
                $("div[id^='div_ch_person_']").each(function() {
                        var ii = $(this).attr("id").substr($(this).attr("id").lastIndexOf("_") + 1);
                        var ch_person_RealName = $.trim($("#txt_ch_person_RealName_" + ii).val());
                        var ch_person_Phone = $.trim($("#txt_ch_person_Phone_" + ii).val());
                        var ch_person_CodeType = $("#ddl_ch_person_CodeType_" + ii).val();
                        var ch_person_Code = $.trim($("#txt_ch_person_Code_" + ii).val());
                        var ch_person_sex = $.trim($("#ddl_ch_person_Sex_" + ii).val()); //性别
                        var ch_person_birthday = $.trim($("#txt_ch_person_Birthday_" + ii).val()); //生日
                        $("#txt_ch_person_RealName_" + ii).parent("div").find("span").text("");
                        $("#txt_ch_person_Phone_" + ii).next().text("");
                        $("#txt_ch_person_Code_" + ii).next().text("");
                        $("#txt_ch_person_Birthday_" + ii).next().text("");
                        $("#divwrongId_" + ii).hide();
                        //真实姓名
                        if (ch_person_RealName == "") {
                                $("#txt_ch_person_RealName_" + ii).parent("div").find("span").text("必填");
                                flag = true;
                        } else {
                                //判断姓名的格式
                                if (!nameReg.test(ch_person_RealName)) {
                                        $("#txt_ch_person_RealName_" + ii).parent("div").find("span").text("格式错误");
                                        flag = true;
                                } else {
                                        otherUserNameArray.push(ch_person_RealName); //追加用户名，用于判断不能重复，放入集合
                                }
                        }
                        //手机 必须输入手机号 2012-04-24
                        if (ch_person_Phone == "") {
                                $("#txt_ch_person_Phone_" + ii).next().text("必填");
                                flag = true;
                        }
                        else {
                                if (!mobileReg.test(ch_person_Phone)) {
                                        $("#txt_ch_person_Phone_" + ii).next().text("格式错误");
                                        flag = true;
                                }
                        }
                        //生日 判断
                        if (ch_person_CodeType != "0" && ch_person_CodeType != "5") {
                                if (ch_person_birthday == "") {
                                        $("#txt_ch_person_Birthday_" + ii).next().text("必填");
                                        flag = true;
                                }
                                else {
                                        if (!dataeReg.test(ch_person_birthday)) {
                                                $("#txt_ch_person_Birthday_" + ii).next().text("格式错误");
                                                flag = true;
                                        }
                                }
                        }
                        //证件号码
                        if (ch_person_CodeType != "5") {//不选择稍后提供就判断
                                if (ch_person_Code == "") {
                                        $("#txt_ch_person_Code_" + ii).next().text("必填");
                                        flag = true;
                                }
                                else {
                                        var bday = "";
                                        if (ch_person_CodeType == "0") {//选择了身份证
                                                if (!codeReg.test(ch_person_Code)) {
                                                        $("#txt_ch_person_Code_" + ii).next().text("格式错误");
                                                        flag = true;
                                                } else {
                                                        otherUserPassCodeArray.push(ch_person_Code); //追加用户名，用于判断不能重复，放入集合
                                                        //判断性别
                                                        if (ch_person_Code.length == 18) {
                                                                var n = ch_person_Code.substring(ch_person_Code.length - 2, ch_person_Code.length - 1);
                                                                if (n % 2 == 0) {
                                                                        //偶数为女
                                                                        ch_person_sex = 0;
                                                                }
                                                                else {
                                                                        //奇数为男
                                                                        ch_person_sex = 1;
                                                                }
                                                                //生日截取
                                                                ch_person_birthday = ch_person_Code.substr(6, 4) + "-" + ch_person_Code.substr(10, 2) + "-" + ch_person_Code.substr(12, 2); //从省份证中读取出生年月
                                                                bday = ch_person_Code.substr(6, 4) + "/" + ch_person_Code.substr(10, 2) + "/" + ch_person_Code.substr(12, 2);
                                                        } else if (ch_person_Code.length == 15) {
                                                                var n = ch_person_Code.substr(ch_person_Code.length - 1);
                                                                if (n % 2 == 0) {
                                                                        //偶数为女
                                                                        ch_person_sex = 0;
                                                                }
                                                                else {
                                                                        //奇数为男
                                                                        ch_person_sex = 1;
                                                                }
                                                                //生日截取
                                                                ch_person_birthday = "19" + ch_person_Code.substr(6, 2) + "-" + ch_person_Code.substr(8, 2) + "-" + ch_person_Code.substr(10, 2); //从省份证中读取出生年月
                                                                bday = "19" + ch_person_Code.substr(6, 2) + "/" + ch_person_Code.substr(8, 2) + "/" + ch_person_Code.substr(10, 2);
                                                        }
                                                }
                                        } else {//选择其他的只要是非空就要封装
                                                otherUserPassCodeArray.push(ch_person_Code); //追加证件号，用于判断不能重复，放入集合
                                        }
                                        /******国内线路成人判断年龄是否在符合条件范围内 start*****/
                                        if ($.trim($("#txtHiddenMType").val()) == "2") {
                                                var godate = $.trim($("#hiddenGodate").val()).replace("-", "/").replace("-", "/");
                                                var isBirthday = 0; //是否为生日输入的
                                                if (bday == "") {
                                                        //输入生日的情况
                                                        bday = $.trim(ch_person_birthday).replace("-", "/").replace("-", "/");
                                                        isBirthday = 1;
                                                }
                                                var dateday = new Date(bday);
                                                var comdate = new Date(godate).setFullYear(new Date(godate).getFullYear() - 12);
                                                if (dateday > comdate) {
                                                        if (isBirthday == 1) {
                                                                $("#txt_ch_person_Birthday_" + ii).next().text("×");
                                                        } else {
                                                                $("#txt_ch_person_Code_" + ii).next().text("×");
                                                        }
                                                        $("#divwrongId_" + ii).show();
                                                        flag = true;
                                                }
                                        }
                                        /******国内线路成人判断年龄是否在符合条件范围内 end*****/
                                }
                        }
                        if (!flag) {
                                var userType = "0"; //0成人3儿童
                                var selectUserId = $.trim($("#txt_ch_person_UserId_" + ii).val()); //游客Id
                                if (selectUserId == "") {
                                        selectUserId = "0";
                                }
                                var cnIsAddorUp = $("#chk_ch_person_" + ii).attr("checked"); //是否保存游客信息
                                cnIsAddorUp = cnIsAddorUp ? '1' : '0';
                                clientArr += ch_person_RealName + "^" + ch_person_CodeType + "^" + ch_person_Code + "^" + ch_person_sex + "^" + ch_person_birthday + "^" + ch_person_Phone + "^" + selectUserId + "^" + cnIsAddorUp + "^" + userType + "$";
                        }
                });
                //******国内 儿童*****//
                $("div[id^='div_ch_child_']").each(function() {
                        var ii = $(this).attr("id").substr($(this).attr("id").lastIndexOf("_") + 1);
                        var ch_child_RealName = $.trim($("#txt_ch_child_RealName_" + ii).val());
                        var ch_child_Birthday = $.trim($("#txt_ch_child_Birthday_" + ii).val());
                        var ch_child_Sex = $("#ddl_ch_child_Sex_" + ii).val();
                        $("#txt_ch_child_RealName_" + ii).parent("div").find("span").text("");
                        $("#txt_ch_child_Birthday_" + ii).next().text("");
                        $("#divwrongbdays_" + ii).hide();
                        //真实姓名
                        if (ch_child_RealName == "") {
                                $("#txt_ch_child_RealName_" + ii).parent("div").find("span").text("必填");
                                flag = true;
                        } else {
                                //判断姓名的格式
                                if (!nameReg.test(ch_child_RealName)) {
                                        $("#txt_ch_child_RealName_" + ii).parent("div").find("span").text("格式错误");
                                        flag = true;
                                } else {
                                        otherUserNameArray.push(ch_child_RealName); //追加用户名，用于判断不能重复，放入集合
                                }
                        }
                        //生日 判断
                        if (ch_child_Birthday == "") {
                                $("#txt_ch_child_Birthday_" + ii).next().text("必填");
                                flag = true;
                        } else {
                                if (!dataeReg.test(ch_child_Birthday)) {
                                        $("#txt_ch_child_Birthday_" + ii).next().text("格式错误");
                                        flag = true;
                                }
                                /******国内线路儿童判断年龄是否在符合条件范围内 start*****/
                                if ($.trim($("#txtHiddenMType").val()) == "2") {
                                        var godate = $.trim($("#hiddenGodate").val()).replace("-", "/").replace("-", "/");
                                        //输入生日的情况
                                        var bday = $.trim(ch_child_Birthday).replace("-", "/").replace("-", "/");

                                        var dateday = new Date(bday);
                                        var comdateMin = new Date(godate).setFullYear(new Date(godate).getFullYear() - 12);
                                        var comdateMax = new Date(godate).setFullYear(new Date(godate).getFullYear() - 2);
                                        if (dateday < comdateMin || dateday > comdateMax) {
                                                $("#txt_ch_child_Birthday_" + ii).next().text("×");
                                                $("#divwrongbdays_" + ii).show();
                                                flag = true;
                                        }
                                }
                                /******国内线路儿童判断年龄是否在符合条件范围内 end*****/
                        }

                        if (!flag) {
                                //提取信息
                                var ch_child_Phone = ""; //手机
                                var userType = "3"; //0成人3儿童
                                var ch_child_CodeType = "";
                                var ch_child_Code = "";
                                var selectUserId = $.trim($("#txt_ch_child_UserId_" + ii).val()); //游客Id
                                if (selectUserId == "") {
                                        selectUserId = "0";
                                }
                                var cnIsAddorUp = $("#chk_ch_child_" + ii).attr("checked"); //是否保存游客信息
                                cnIsAddorUp = cnIsAddorUp ? '1' : '0';
                                clientArr += ch_child_RealName + "^" + ch_child_CodeType + "^" + ch_child_Code + "^" + ch_child_Sex + "^" + ch_child_Birthday + "^" + ch_child_Phone + "^" + selectUserId + "^" + cnIsAddorUp + "^" + userType + "$";
                        }
                });
                //******出境 成人*****//
                $("div[id^='div_en_person_']").each(function() {
                        var ii = $(this).attr("id").substr($(this).attr("id").lastIndexOf("_") + 1);
                        var en_person_RealName = $.trim($("#txt_en_person_RealName_" + ii).val());
                        var en_person_Nationality = $.trim($("#txt_en_person_Nationality_" + ii).val());
                        var en_person_Birthday = $.trim($("#txt_en_person_Birthday_" + ii).val());
                        var en_person_Phone = $.trim($("#txt_en_person_Phone_" + ii).val());
                        var en_person_Type = $.trim($("#ddl_en_person_Type_" + ii).val());
                        var en_person_Code = $.trim($("#txt_en_person_Code_" + ii).val());
                        var en_person_Valiad = $.trim($("#txt_en_person_Valiad_" + ii).val());
                        var en_person_Sex = $("#ddl_en_person_Sex_" + ii).val();
                        var en_person_CodeAddress = $.trim($("#txt_en_person_CodeAddress_" + ii).val()); //签发地
                        $("#txt_en_person_RealName_" + ii).parent("div").find("span").text("");
                        $("#txt_en_person_Nationality_" + ii).next().text("");
                        $("#txt_en_person_Birthday_" + ii).next().text("");
                        $("#txt_en_person_Phone_" + ii).next().text("");
                        $("#txt_en_person_Code_" + ii).next().text("");
                        $("#txt_en_person_Valiad_" + ii).next().text("");
                        //中文姓名
                        if (en_person_RealName == "") {
                                $("#txt_en_person_RealName_" + ii).parent("div").find("span").text("必填");
                                flag = true;
                        }
                        //国籍
                        if (en_person_Nationality == "") {
                                $("#txt_en_person_Nationality_" + ii).next().text("必填");
                                flag = true;
                        }
                        //出生日期
                        if (en_person_Birthday == "") {
                                $("#txt_en_person_Birthday_" + ii).next().text("必填");
                                flag = true;
                        } else {
                                if (!dataeReg.test(en_person_Birthday)) {
                                        $("#txt_en_person_Birthday_" + ii).next().text("格式错误");
                                        flag = true;
                                }
                        }
                        //手机
                        if (en_person_Phone == "") {
                                $("#txt_en_person_Phone_" + ii).next().text("必填");
                                flag = true;
                        }
                        else {
                                if (!mobileReg.test(en_person_Phone)) {
                                        $("#txt_en_person_Phone_" + ii).next().text("格式错误");
                                        flag = true;
                                }
                        }
                        //证件号码
                        if (en_person_Type != "-1") {//不选择稍后提供就判断
                                if (en_person_Code == "") {
                                        $("#txt_en_person_Code_" + ii).next().text("必填");
                                        flag = true;
                                } else {
                                        if (en_person_Type == "0") {//选择了护照
                                                if (!hzhaoReg.test(en_person_Code)) {
                                                        $("#txt_en_person_Code_" + ii).next().text("格式错误");
                                                        flag = true;
                                                }
                                        }
                                        if (en_person_Type == "1") {//选择了港澳通行证
                                                if (!gangaoReg.test(en_person_Code)) {
                                                        $("#txt_en_person_Code_" + ii).next().text("格式错误");
                                                        flag = true;
                                                }
                                        }
                                }
                        }
                        //证件有效期
                        if (en_person_Type != "-1") {//不选择稍后提供就判断
                                if (en_person_Valiad == "") {
                                        $("#txt_en_person_Valiad_" + ii).next().text("必填");
                                        flag = true;
                                } else {
                                        if (!dataeReg.test(en_person_Valiad)) {
                                                $("#txt_en_person_Valiad_" + ii).next().text("格式错误");
                                                flag = true;
                                        }
                                }
                        }
                        if (!flag) {
                                //提取信息                
                                var userType = "0"; //0成人3儿童
                                var selectUserId = $.trim($("#txt_en_person_UserId_" + ii).val()); //游客Id
                                if (selectUserId == "") {
                                        selectUserId = "0";
                                }
                                var cnIsAddorUp = $("#chk_en_person_" + ii).attr("checked"); //是否保存游客信息
                                cnIsAddorUp = cnIsAddorUp ? '1' : '0';
                                clientArr += en_person_RealName + "^" + en_person_Type + "^" + en_person_Nationality + "^" + en_person_Code + "^" + en_person_Sex + "^" +
                                        en_person_Valiad + "^" + en_person_Birthday + "^" + en_person_CodeAddress + "^" + en_person_Phone + "^" + selectUserId + "^" + cnIsAddorUp + "^" + userType + "$";
                        }
                });
                //******出境 儿童*****//
                $("div[id^='div_en_child_']").each(function() {
                        var ii = $(this).attr("id").substr($(this).attr("id").lastIndexOf("_") + 1);
                        var en_child_RealName = $.trim($("#txt_en_child_RealName_" + ii).val());
                        var en_child_Nationality = $.trim($("#txt_en_child_Nationality_" + ii).val());
                        var en_child_Birthday = $.trim($("#txt_en_child_Birthday_" + ii).val());
                        var en_child_Type = $.trim($("#ddl_en_child_Type_" + ii).val());
                        var en_child_Code = $.trim($("#txt_en_child_Code_" + ii).val());
                        var en_child_Valiad = $.trim($("#txt_en_child_Valiad_" + ii).val());
                        var en_child_Sex = $("#ddl_en_child_Sex_" + ii).val();
                        var en_child_CodeAddress = $.trim($("#txt_en_child_CodeAddress_" + ii).val()); //签发地
                        $("#txt_en_child_RealName_" + ii).parent("div").find("span").text("");
                        $("#txt_en_child_Nationality_" + ii).next().text("");
                        $("#txt_en_child_Birthday_" + ii).next().text("");
                        $("#txt_en_child_Code_" + ii).next().text("");
                        $("#txt_en_child_Valiad_" + ii).next().text("");
                        //中文姓名
                        if (en_child_RealName == "") {
                                $("#txt_en_child_RealName_" + ii).parent("div").find("span").text("必填");
                                flag = true;
                        }
                        //国籍
                        if (en_child_Nationality == "") {
                                $("#txt_en_child_Nationality_" + ii).next().text("必填");
                                flag = true;
                        }
                        //出生日期
                        if (en_child_Birthday == "") {
                                $("#txt_en_child_Birthday_" + ii).next().text("必填");
                                flag = true;
                        } else {
                                if (!dataeReg.test(en_child_Birthday)) {
                                        $("#txt_en_child_Birthday_" + ii).next().text("格式错误");
                                        flag = true;
                                }
                        }
                        //证件号码
                        if (en_child_Type != "-1") {//不选择稍后提供就判断
                                if (en_child_Code == "") {
                                        $("#txt_en_child_Code_" + ii).next().text("必填");
                                        flag = true;
                                } else {
                                        if (en_child_Type == "0") {//选择了护照
                                                if (!hzhaoReg.test(en_child_Code)) {
                                                        $("#txt_en_child_Code_" + ii).next().text("格式错误");
                                                        flag = true;
                                                }
                                        }
                                        if (en_child_Type == "1") {//选择了港澳通行证
                                                if (!gangaoReg.test(en_child_Code)) {
                                                        $("#txt_en_child_Code_" + ii).next().text("格式错误");
                                                        flag = true;
                                                }
                                        }
                                }
                        }
                        //证件有效期
                        if (en_child_Type != "-1") {//不选择稍后提供就判断
                                if (en_child_Valiad == "") {
                                        $("#txt_en_child_Valiad_" + ii).next().text("必填");
                                        flag = true;
                                } else {
                                        if (!dataeReg.test(en_child_Valiad)) {
                                                $("#txt_en_child_Valiad_" + ii).next().text("格式错误");
                                                flag = true;
                                        }
                                }
                        }
                        if (!flag) {
                                //提取信息                
                                var userType = "3"; //0成人3儿童
                                var selectUserId = $.trim($("#txt_en_child_UserId_" + ii).val()); //游客Id
                                if (selectUserId == "") {
                                        selectUserId = "0";
                                }
                                var cnIsAddorUp = $("#chk_en_child_" + ii).attr("checked"); //是否保存游客信息
                                cnIsAddorUp = cnIsAddorUp ? '1' : '0';
                                var en_person_Phone = ""; //手机
                                clientArr += en_child_RealName + "^" + en_child_Type + "^" + en_child_Nationality + "^" + en_child_Code + "^" + en_child_Sex +
                                        "^" + en_child_Valiad + "^" + en_child_Birthday + "^" + en_child_CodeAddress + "^" + en_person_Phone +
                                        "^" + selectUserId + "^" + cnIsAddorUp + "^" + userType + "$";


                        }
                });
                //******在线支付游客信息重复判断【姓名、证件号码】*****//
                //姓名
                var personandchild = $("input[id^='txt_ch_person_RealName_'],input[id^='txt_ch_child_RealName_']").length; //成人加儿童的总数
                if (personandchild == otherUserNameArray.length) {//姓名都输入正确值了之后再判断
                        $("input[id^='txt_ch_person_RealName_'],input[id^='txt_ch_child_RealName_']").each(function() {
                                var vl = $.trim($(this).val());
                                var usernamecount = 0;
                                for (var i = 0; i < otherUserNameArray.length; i++) {
                                        if (otherUserNameArray[i] == vl) {
                                                usernamecount++;
                                        }
                                }
                                if (usernamecount > 1) {//说明有重复的
                                        $(this).parent("div").find("span").text("不能重复");
                                        flag = true;
                                        return false;
                                }
                        });
                }
                //证件号码
                var personcodecount = $("input[id^='txt_ch_person_Code_'],input[id^='txt_ch_child_Code_']").length; //成人证件号码总数
                if (otherUserPassCodeArray.length == personcodecount) {//证件号码都输入正确值了之后再判断
                        $("input[id^='txt_ch_person_Code_'],input[id^='txt_ch_child_Code_']").each(function() {
                                var vl = $.trim($(this).val());
                                var codecount = 0;
                                for (var i = 0; i < otherUserPassCodeArray.length; i++) {
                                        if (otherUserPassCodeArray[i] == vl) {
                                                codecount++;
                                        }
                                }
                                if (codecount > 1) {//说明有重复的
                                        $(this).next().text("不能重复");
                                        flag = true;
                                        return false;
                                }
                        });
                }
                if (flag) {
                        /*定位焦点*/
                        $(".userInfo table").find("span").each(function() {
                                if ($.trim($(this).text()) == "必填" || $.trim($(this).text()) == "格式错误" || $.trim($(this).text()) == "不能重复") {
                                        $(this).prevAll("input").focus();
                                        return false;
                                }
                        });
                        /*定位焦点 End*/
                        return;
                } else {
                        if (clientArr && clientArr.length >= 1) {
                                clientArr = clientArr.substr(0, clientArr.length - 1);
                        }
                        $("#txtHiddenUList").val(clientArr); //游客、用户信息
                        //表单提交
                        document.getElementById("two_form").submit();
                }
        });
        //*************显示上一步、下一步按钮******************//
        $("#gl_submit").css("display", "block");
        $("#btn_Next_2").css("display", "block");
});

//***********************输入用户填充***************************//

function inputUserNameFillOtherInfo() {
        $("input[id*='_RealName_']").blur(function() {
                //关系id
                var ii = $(this).attr("id").substr($(this).attr("id").lastIndexOf("_") + 1);
                //填写姓名
                var userName = $.trim($(this).val());
                if (userName && userName != "" && $(this).next("ul").children("li").length > 0) {
                        for (var i = 1; i <= ($(this).next("ul").children("li").length - 1); i++) {
                                //隐藏域游客信息
                                var li_userInfo = $.trim($(this).next("ul").children("li").eq(i).children("a").attr("des"));
                                var li_userName = "";
                                if (li_userInfo && li_userInfo != "") {
                                        if (li_userInfo.split(',').length > 2 && nameReg.test(li_userInfo.split(',')[1])) {
                                                //隐藏域游客姓名
                                                li_userName = li_userInfo.split(',')[1];
                                        }
                                }
                                if (userName == li_userName) {
                                        //填充内容
                                        fillOtherInfo($(this).attr("id"), ii, li_userInfo);
                                        break;
                                }
                        } //for
                } //if(userName)
        });
}

function fillOtherInfo(classId, ii, des) {
        if (classId.indexOf("ch_person") > 0) {
                $("#txt_ch_person_UserId_" + ii).val(des.split(',')[0]); //隐藏域 游客Id
                $("#txt_ch_person_Phone_" + ii).val(des.split(',')[7]); //手机
                $("#ddl_ch_person_CodeType_" + ii).val(des.split(',')[4]); //证件类别
                $("#txt_ch_person_Code_" + ii).val(des.split(',')[5]); //证件号码
                $("#ddl_ch_person_Sex_" + ii).val(des.split(',')[3]); //性别
                $("#txt_ch_person_Birthday_" + ii).val(des.split(',')[6]); //生日
                $("#ddl_ch_person_CodeType_" + ii).change(); //触发证件类别的事件
        } else if (classId.indexOf("ch_child") > 0) {
                $("#txt_ch_child_UserId_" + ii).val(des.split(',')[0]); //隐藏域 游客Id
                $("#ddl_ch_child_Sex_" + ii).val(des.split(',')[3]); //性别
                $("#txt_ch_child_Birthday_" + ii).val(des.split(',')[6]); //出生年月
        } else if (classId.indexOf("en_person") > 0) {
                $("#txt_en_person_UserId_" + ii).val(des.split(',')[0]); //隐藏域 游客Id
                $("#ddl_en_person_Sex_" + ii).val(des.split(',')[3]); //性别
                $("#txt_en_person_Nationality_" + ii).val(des.split(',')[4]); //国籍
                $("#ddl_en_person_Type_" + ii).val(des.split(',')[5]); //证件类别
                $("#txt_en_person_Birthday_" + ii).val(des.split(',')[9]); //出生年月
                $("#txt_en_person_Code_" + ii).val(des.split(',')[6]); //证件号码
                $("#txt_en_person_Valiad_" + ii).val(des.split(',')[7]); //证件有效期     
                $("#txt_en_person_CodeAddress_" + ii).val(des.split(',')[8]); //签发地
                $("#txt_en_person_Phone_" + ii).val(des.split(',')[10]); //手机
                $("#ddl_en_person_Type_" + ii).change(); //触发证件类别事件
        } else if (classId.indexOf("en_child") > 0) {
                $("#txt_en_child_UserId_" + ii).val(des.split(',')[0]); //隐藏域 游客Id
                $("#ddl_en_child_Sex_" + ii).val(des.split(',')[3]); //性别
                $("#txt_en_child_Nationality_" + ii).val(des.split(',')[4]); //国籍
                $("#ddl_en_child_Type_" + ii).val(des.split(',')[5]); //证件类别
                $("#txt_en_child_Birthday_" + ii).val(des.split(',')[9]); //出生年月
                $("#txt_en_child_Code_" + ii).val(des.split(',')[6]); //证件号码
                $("#txt_en_child_Valiad_" + ii).val(des.split(',')[7]); //证件有效期    
                $("#txt_en_child_CodeAddress_" + ii).val(des.split(',')[8]); //签发地
                $("#ddl_en_child_Type_" + ii).change(); //触发证件类别事件
        }
}

//***********************输入用户填充 END***********************//
