<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditClub.aspx.cs" Inherits="TravelAgent.Web.admin.club.EditClub" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title></title>
    <link href="../css/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="/js/jquery-1.3.2.min.js"></script>
    <script type="text/javascript" src="/js/jquery.validate.min.js"></script>
    <script type="text/javascript" src="/js/validate.js"></script>
    <script type="text/javascript" src="/js/jquery.form.js"></script>
    <script type="text/javascript" src="../js/select-ui.min.js"></script>
    <script type="text/javascript" src="/js/calendar.js"  ></script>
    <script type="text/javascript">
        //保存目的地
        var EditClub = function() {
            $("#__VIEWSTATE").remove(); //这两句最重要
            $("#__EVENTVALIDATION").remove();
            $(this).attr("disabled", "disabled");
            $(this).val("正在保存中...");
            var options = {
                url: "../data/Club.aspx?id="+<%=clubid %>+"&date=" + new Date().toUTCString(),
                type: 'POST',
                //beforeSubmit: Validate,
                success: function(responseText, statusText) {
                    $("#btnSave").attr("disabled", "");
                    $("#btnSave").removeAttr("disabled");
                    $("#btnSave").val("确定保存");
                    if (responseText.indexOf("true") >= 0) {
                        // 如果父页面重载或者关闭其子对话框全部会关闭
                        parent.location.reload();
                        return false;
                    }
                    else {
                        parent.art.dialog.alert("保存失败！");
                    }
                }
            };
            $("#form1").ajaxSubmit(options);
        }
        $(function() {
            $(".select1").uedSelect({
                width: 100
            });
            //表单验证JS
            $("#form1").validate({
                //出错时添加的标签
                errorElement: "span",
                submitHandler: function() {
                    EditClub();
                    return false;
                },
                success: function(label) {
                    //正确时的样式
                    label.text(" ").addClass("success");
                }
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table border="0" cellpadding="0" cellspacing="0" style="width:100%;" class="formtable">
            <tr>
                <td style="text-align:right; color:#056dae;background: #F5F5F5; width:80px; ">会员名 <span class="red">*</span>：</td>
                <td style=" padding-top:10px;">
                    <asp:TextBox ID="txtClubName" runat="server" CssClass="dfinput required" Width="100px" Enabled="false"></asp:TextBox>
                </td>
                <td style="text-align:right; color:#056dae;background: #F5F5F5;width:80px;  ">手机号：</td>
                <td><asp:TextBox ID="txtMobile" runat="server" CssClass="dfinput mobile" Width="100px"></asp:TextBox></td>
                <td style="text-align:right; color:#056dae;background: #F5F5F5;width:80px;  ">邮箱：</td>
                <td><asp:TextBox ID="txtEmail" runat="server" CssClass="dfinput email" Width="150px"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="text-align:right; color:#056dae;background: #F5F5F5; ">密码 <span class="red">*</span>：</td>
                <td style=" padding-top:10px;">
                    <asp:TextBox ID="txtPassword" runat="server" CssClass="dfinput" Width="100px" TextMode="Password" minlength="6" ReadOnly="true"></asp:TextBox>
                </td>
                <td style="text-align:right; color:#056dae;background: #F5F5F5; ">会员级别：</td>
                <td><asp:DropDownList ID="ddlClass" runat="server" CssClass="select1">
                    </asp:DropDownList></td>
                <td style="text-align:right; color:#056dae;background: #F5F5F5; ">当前积分：</td>
                <td>
                    <asp:TextBox ID="txtPoints" runat="server" CssClass="dfinput digits" Width="100px" Enabled="false"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="text-align:right; color:#056dae;background: #F5F5F5; ">真实姓名：</td>
                <td style=" padding-top:10px;">
                    <asp:TextBox ID="txtName" runat="server" CssClass="dfinput" Width="100px"></asp:TextBox>
                </td>
                <td style="text-align:right; color:#056dae;background: #F5F5F5; ">性别：</td>
                <td>
                    <asp:DropDownList ID="ddlSex" runat="server" CssClass="select1">
                        <asp:ListItem Value="男">男</asp:ListItem>
                        <asp:ListItem Value="女">女</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td style="text-align:right; color:#056dae;background: #F5F5F5; ">生日：</td>
                <td><asp:TextBox ID="txtBirthday" runat="server" CssClass="dfinput" Width="100px" onclick="return Calendar('txtBirthday');"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="text-align:right; color:#056dae;background: #F5F5F5;">审核状态：</td>
                <td colspan="5">
                    <asp:DropDownList ID="ddlLock" runat="server" CssClass="select1">
                        <asp:ListItem Value="0">正常</asp:ListItem>
                        <asp:ListItem Value="1">锁定</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="text-align:right; color:#056dae;background: #F5F5F5; height:50px;"></td>
                <td colspan="5"><asp:Button ID="btnSave" runat="server" Text="确定保存" CssClass="btn" /></td>
            </tr>
     </table>
    </div>
    <input id="hidId" name="hidtId" type="hidden" runat="server" value="0" />
    <input id="hidState" name="hidState" type="hidden" value="" />
    </form>
</body>
</html>
