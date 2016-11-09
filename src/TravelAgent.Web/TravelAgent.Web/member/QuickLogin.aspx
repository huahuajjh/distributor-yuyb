<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="QuickLogin.aspx.cs" Inherits="TravelAgent.Web.member.QuickLogin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title></title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
                <link rel="stylesheet" type="text/css" href="/member/css/style.css" />
                <link rel="stylesheet" type="text/css" href="/member/css/user.css" />
                <script type="text/javascript" src="/js/jquery-1.7.2.min.js"></script>
</head>
<body>
    <div id="loading" style="text-align:center; z-index: 2; height:100%; width:100%; background-color: black; position:absolute; top:45px; left:0; filter:alpha(opacity=30);-moz-opacity:0.3; opacity: 0.3;">
                        <img src="/images/loading.gif" />
                </div>
                <!----------------------------------------------------快速登录 注册 预订 部分-------------------------------------------------------------->
                <div class="quicklogin">
                        <div class="quick_tit">
                                <h3>快速预订/登录</h3>
                                <a href="javascript:" onclick="parent.closeEditor();"></a>
                        </div>
                        <div id="span_error" class="span_error"></div>
                        <div class="quicklogin_block" id="quicklogin_block" runat="server">
                                        <!--left-->
                                        <div class="quick_left">
                                                <h4>第一次预订：</h4>
                                                <form action="" method="post" id="register">
                                                        <input type="hidden" name="actionName" value="buySubmit" />
                                                        <div class="quickfrom">
                                                                <span class="quickfrom_tit">手机号：</span>
                                                                <input name="mobile" maxlength="11" type="text" value="<%=strTel %>" id="txtPhone" class="quickfrom_con1"  />
                                                        </div>
                                                        <div class="quickfrom">
                                                                <button type='submit' class="quick_btn1" id="btn_QuitLogin" title="快速预订">快速预订</button>  
                                                        </div>
                                                </form>
                                                <div class="quick_txt1">为方便您进行预订后的相关操作，我们将为您注册成为网站会员！</div>
                                        </div>
                                        <!--right-->
                                        <div class="quick_right">
                                                <h4>已注册会员：</h4>
                                                <form action="" method="post" id="login">
                                                        <input type="hidden" name="actionName" value="buySubmit" />
                                                        <input type="hidden" name="txtLaiYuan" value="" />
                                                        <div class="quickfrom">
                                                                <span class="quickfrom_tit">账 号：</span> 
                                                                <input name="txtName" type="text" id="txtName"  value="用户名/手机号/邮箱" class="quickfrom_con2" onfocus="if ($.trim($(this).val()) == '用户名/手机号/邮箱') { $(this).val('').css('color', 'black'); }" onblur="if ($.trim($(this).val()) == '') {$(this).val('用户名/手机号/邮箱').css('color', '#C0C0C0');};" />
                                                        </div>                                                
                                                        <div class="quickfrom">
                                                                <span class="quickfrom_tit">密 码：</span> 
                                                                <input name="txtPwd" type="password" id="txtPwd" class="quickfrom_con1" />
                                                        </div>
                                                        <div class="quickfrom">
                                                                <button type="submit" class="quick_btn2" id="btn_Login">登录，继续预订</button> 
                                                        </div>                                                
                                                </form>
                                                <div class="quick_txt2">
                                                        <a href="/member/Register.aspx" target="_blank">免费注册</a>
                                                        <a href="/member/GetPassword.aspx" target="_blank" >找回密码</a>
                                                </div>
                                        </div>
                        </div>
                      <div class="quicklogin_next" id="quicklogin_next" runat="server">
                                <div class="quicktishi">
                                        <p>温馨提示：</p>
                                        <p>为便于您进行相关操作，我们已为您注册成为本网站会员，账号及密码如下：</p>
                                        <p style="color: #EE6611;">登录账号：<font style='font: 700 14px/25px Verdana, Arial, "宋体"; color: #F20;'><%=strTel %></font></p>
                                        <p style="color: #EE6611;">初始密码：<font style='font: 700 14px/25px Verdana, Arial, "宋体"; color: #F20;'><%=strPwd %></font></p>
                                        <p>以上账号是本网站的重要凭据，<font style='color: #754;'>【请您务必牢记】</font>。您可在预订完成后进入会员中心查看个人订单状态或<font style='color: #754;'>在会员中心修改个人账号、密码，以及【绑定邮箱】，以便忘记密码时顺利找回</font>。</p>
                                </div>
                               <%-- <form action="/Order2.aspx" method="post" id="Form1">                                                
                                        <input type="hidden" name="actionName" value="buySubmit" />--%> 
                                        <%=strBtnContent %>                                               
                                        <%--<button type='button' class="quicklogin_nextbtn" id="btn_QuitLogin_next" onclick="parent.document.getElementById('btn_Next_2').click();">已记住密码，下一步</button>--%>
                                <%--</form>--%>
                        </div>
  
                        <span class="field-validation-error" style="display: none;"><%=strError %></span>
                </div>
                
                <!----------------------------------------------------js部分-------------------------------------------------------------->
                <script src="/member/js/formValidatorRegex.js" type="text/javascript"></script> 
                <script type="text/javascript">
                    $(function () {
                        $(".field-validation-error").css("display", "none"); //提示信息永远都是隐藏的
                        setVistable("true");
                        init_orderlogin();
                        /**快速预订**/
                        $("#btn_QuitLogin").click(function () {
                            $("#span_error").text("");
                            var mobileReg = new RegExp(regexEnum.mobile);
                            if (!mobileReg.test($.trim($("#txtPhone").val()))) {
                                $("#span_error").text("输入手机号格式错误！");
                                $("#txtPhone").focus();
                                return false;
                            }
                            setVistable("false");
                        });
                        /**登录**/
                        $("#btn_Login").click(function () {
                            $("#span_error").text("");
                            var name = $("#txtName").val();
                            var pwd = $("#txtPwd").val();
                            if ($.trim(name) == "" || $.trim(name) == "会员名/手机号/邮箱") {
                                $("#span_error").text("帐号不能为空！");
                                $("#txtName").focus();
                                return false;
                            }
                            if ($.trim(pwd) == "") {
                                $("#span_error").text("密码不能为空！");
                                $("#txtPwd").focus();
                                return false;
                            }
                            setVistable("false");
                        });
                        /*登录用户名点击事件*/
                        $("#txtName").click(function () {
                            var name = $("#txtName").val();
                            if (name == "会员名/手机号/邮箱") {
                                $("#txtName").val("");
                                $("#txtName").css("color", "#000");
                            }
                        });
                    });
                    /*设置层的显示和隐藏*/
                    function setVistable(flag) {
                        if (flag == "true") {
                            $("#loading").css("display", "none");
                            $("#content").css("display", "block");
                        }
                        else {
                            $("#loading").css("display", "block");
                            $("#content").css("display", "none");
                        }
                    }
                    //**报错提示信息**//
                    function init_orderlogin() {
                        var flag = $(".field-validation-error").text();
                        var userName = "";
                        if (flag != "") {
                            var userName = flag.substr(flag.lastIndexOf("_") + 1);
                        }
                        if (flag.indexOf("exits") >= 0) {
                            $("#span_error").text('您已经是约游约呗会员，请在右侧登录！');
                            $("#txtName").val(userName).css("color", "#000");
                        }
                        if (flag.indexOf("regerror") >= 0) {
                            $("#span_error").text('用户注册失败！');
                            $("#txtPhone").val(userName).css("color", "#000");
                        }
                        if (flag.indexOf("loginerror") >= 0) {
                            $("#span_error").text('用户名或密码错误！');
                            $("#txtName").val(userName).css("color", "#000");
                        }
                    }
                </script>

</body>
</html>
