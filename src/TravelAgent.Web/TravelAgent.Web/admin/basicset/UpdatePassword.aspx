<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdatePassword.aspx.cs" Inherits="TravelAgent.Web.admin.basicset.UpdatePassword" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1">
    <title></title>
    <link href="../css/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../../js/jquery-1.3.2.min.js"></script>
    <script type="text/javascript" src="../../js/jquery.validate.min.js"></script>
    <script type="text/javascript" src="../../js/jquery.validate.extend.js"></script>
    <%--<script type="text/javascript" src="/js/validate.js"></script>--%>
    <script type="text/javascript">
        function oksubmit() {
            $.ajax({
                type: "POST",
                url: "/admin/data/UpdatePassword.ashx",
                cache: false,
                dataType: "text",
                data: { pwd: $("#txtNPass2").val() },
                success: function(msg) {
                    //提示修改成功
                    if (msg == "true") {
                        //location.href = location.href;
                        alert('密码修改成功');
                        location.href = "../Admin_Center.aspx";
                        return false;
                    }
                    else {
                        alert('密码修改失败');
                        return false;
                    }
                }
            })
        }
        $.validator.setDefaults({   
          submitHandler: function() { alert("submitted!");return false; }   
        });
        $(function() {
            //表单验证JS
            $("#form1").validate({
                rules: {
                    txtOPass: {
                        required: true,
                        remote: {
                            type: "post",
                            url: "/admin/data/ValidatePassword.ashx",
                            data: {
                                password: function() {
                                    return $("#txtOPass").val();
                                }
                            },
                            dataType: "text",
                            dataFilter: function(data, type) {
                                if (data == "true")
                                    return true;
                                else
                                    return false;
                            }
                        }
                    },
                    txtNPass: {
                        required: true,
                        minlength: 6,
                        maxlength: 26,
                        same: true
                    },
                    txtNPass2: {
                        required: true,
                        minlength: 6,
                        maxlength: 26,
                        equalTo: "#txtNPass"
                    }
                },
                messages: {
                    txtOPass: {
                        required: "请输入原密码",
                        remote: "原密码错误"
                    },
                    txtNPass: {
                        required: "请输入新密码",
                        minlength: jQuery.format("密码不能小于{0}个字符"),
                        maxlength: jQuery.format("密码不能大于{0}个字符"),
                        same: '新密码不能与原密码一样'
                    },
                    txtNPass2: {
                        required: "请重复输入新密码",
                        minlength: "不能小于6个字符",
                        equalTo: "两次输入密码不一致"
                    }
                },
                //出错时添加的标签
                errorElement: "span",
                submitHandler: function(form) {
                    oksubmit();
                    return false;
                },
                success: function(label) {
                    //正确时的样式
                    label.text(" ").addClass("success");
                }
            });
        })
    </script>
</head>
<body>
    <form id="form1">
    <div style="text-align:center; vertical-align:middle">
    <table border="0" cellpadding="0" cellspacing="0" style="width:500px; margin-left:auto; margin-right:auto; margin-top:100px;" class="formtable">
             
            <tr>
                <td style="text-align:right; color:#056dae;background: #F5F5F5; width:20%;">原密码 <span class="red">*</span>：</td>
                <td style="text-align:left">
                    <input id="txtOPass" name="txtOPass" type="password" class="dfinput required" style="width:150px"  /></td>
            </tr>
            <tr>
                <td style="text-align:right; color:#056dae;background: #F5F5F5; ">新密码 <span class="red">*</span>：</td>
                <td style="text-align:left"><input id="txtNPass" name="txtNPass" type="password" class="dfinput required" style="width:150px"  />
                        &nbsp;</td>
            </tr>
            <tr>
                <td style="text-align:right; color:#056dae;background: #F5F5F5; ">确认新密码 <span class="red">*</span>：</td>
                <td style="text-align:left"><input id="txtNPass2" name="txtNPass2" type="password" class="dfinput required" style="width:150px"  />
            </tr>
         
            <tr>
                <td style="text-align:right; color:#056dae;background: #F5F5F5; height:80px;"></td>
                <td style="text-align:left">
                    <input id="btnSave" type="submit" value="确定保存" class="btn" /></td>
            </tr>
     </table>
    </div>
    </form>
</body>
</html>
