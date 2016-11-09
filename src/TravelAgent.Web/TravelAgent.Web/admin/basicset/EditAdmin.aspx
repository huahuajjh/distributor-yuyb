<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditAdmin.aspx.cs" Inherits="TravelAgent.Web.admin.basicset.EditAdmin" %>

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
    <script type="text/javascript" src="../js/singleupload.js"></script>
    <script type="text/javascript">
        //保存
        var EditAdmin = function() {
            $("#__VIEWSTATE").remove(); //这两句最重要
            $("#__EVENTVALIDATION").remove();
            $(this).attr("disabled", "disabled");
            $(this).val("正在保存中...");
            var options = {
                url: "../data/User.aspx?date=" + new Date().toUTCString(),
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
        $("#ddlRole").uedSelect({
                width: 120
            });
            //表单验证JS
            $("#form1").validate({
                //出错时添加的标签
                errorElement: "span",
                submitHandler: function() {
                    EditAdmin();
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
                <td style="text-align:right; color:#056dae;background: #F5F5F5; ">角色 <span class="red">*</span>：</td>
                <td style=" padding-top:10px;">
                    <asp:DropDownList ID="ddlRole" runat="server" CssClass="required">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="text-align:right; color:#056dae;background: #F5F5F5; ">用户名 <span class="red">*</span>：</td>
                <td><asp:TextBox ID="txtUsername" runat="server" CssClass="dfinput required" MaxLength="15" Width="180px"></asp:TextBox>
                        &nbsp;</td>
            </tr>
            <tr>
                <td style="text-align:right; color:#056dae;background: #F5F5F5; ">密码 <span class="red">*</span>：</td>
                <td><asp:TextBox ID="txtPassword" runat="server" CssClass="dfinput required" MaxLength="50" Width="200px"  TextMode="Password"></asp:TextBox>
                </td>
            </tr>
          <%--  <tr>
                <td style="text-align:right; color:#056dae;background: #F5F5F5; ">缩略图 <span class="red">*</span>：</td>
                <td style="padding-left:15px"> <asp:TextBox ID="txtImgUrl" runat="server" CssClass="dfinput left required" Width="200px"></asp:TextBox>
                    <a href="javascript:void(0);" class="files"><input type="file" id="FileUpload" name="FileUpload" />浏览上传图片</a>
                    <span class="uploading">正在上传，请稍候...</span>
                </td>
            </tr>--%>
            <tr>
                <td style="text-align:right; color:#056dae;background: #F5F5F5; ">真实姓名 <span class="red">*</span>：</td>
                <td><asp:TextBox ID="txtTrueName" runat="server" CssClass="dfinput required" MaxLength="25" Width="100px" ></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="text-align:right; color:#056dae;background: #F5F5F5; ">是否锁定：</td>
                <td>
                    <asp:CheckBox ID="chkIsLock" runat="server" Text="" />
                </td>
            </tr>
            <tr>
                <td style="text-align:right; color:#056dae;background: #F5F5F5; width:150px; height:80px;"></td>
                <td><asp:Button ID="btnSave" runat="server" Text="确定保存" CssClass="btn" /></td>
            </tr>
     </table>
    </div>
    <input id="hidId" name="hidId" type="hidden" runat="server" value="0" />
    </form>
</body>
</html>
