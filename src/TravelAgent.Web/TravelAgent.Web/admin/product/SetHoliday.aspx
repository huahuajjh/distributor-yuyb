<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SetHoliday.aspx.cs" Inherits="TravelAgent.Web.admin.product.SetHoliday" %>

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
    <script type="text/javascript">
        //保存导航
        $(function() {
            $("#ddlHoliday").uedSelect({
                width: 150
            });
            $("#btnSave").click(function() {
                $("#__VIEWSTATE").remove(); //这两句最重要
                $("#__EVENTVALIDATION").remove();
                $(this).attr("disabled", "disabled");
                $(this).val("正在保存中...");
                var options = {
                    url: "../data/Holiday.aspx?date=" + new Date().toUTCString(),
                    type: 'POST',
                    //beforeSubmit: Validate,
                    success: function(responseText, statusText) {
                        $("#btnSave").attr("disabled", "");
                        $("#btnSave").removeAttr("disabled");
                        $("#btnSave").val("确定保存");
                        if (responseText.indexOf("true") > -1) {
                            // 如果父页面重载或者关闭其子对话框全部会关闭
                            alert("设置成功！");
                            parent.location.reload();
                            return false;
                        }
                        else {
                            parent.art.dialog.alert("保存失败！");
                        }
                    }
                };
                $("#form1").ajaxSubmit(options);
            })
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table border="0" cellpadding="0" cellspacing="0" style="line-height:50px;  width:100%" class="formtable">
            <tr>
                <td style="text-align:right; color:#056dae; background: #F5F5F5; width:100px">选择推广 <span class="red">*</span>：</td>
                <td >
                    <asp:DropDownList ID="ddlHoliday" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="text-align:right; color:#056dae; background: #F5F5F5; ">备注信息 <span class="red">*</span>：</td>
                <td>选择推广节日后，首页会调用节日显示的线路。
                </td>
            </tr>
            <tr>
                <td style="text-align:right; color:#056dae;background: #F5F5F5; height:80px;"></td>
                <td><asp:Button ID="btnSave" runat="server" Text="确定保存" CssClass="btn" /></td>
            </tr>
     </table>
    </div>
    </form>
</body>
</html>

