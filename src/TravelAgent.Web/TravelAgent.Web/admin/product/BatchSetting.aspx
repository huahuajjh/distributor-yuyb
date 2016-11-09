<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BatchSetting.aspx.cs" Inherits="TravelAgent.Web.admin.product.BatchSetting" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title></title>
    <link href="../css/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="/js/jquery-1.3.2.min.js"></script>
    <script type="text/javascript" src="/js/jquery.form.js"></script>
    <script type="text/javascript">
        $(function() {
            $("input[name^='chkTheme']").click(function() {
                var value = "";
                $("input[name^='chkTheme']").each(function() {
                    if ($(this).attr("checked")) {
                        value = value + $(this).parent().attr("alt") + ","
                    }
                })
                if (value != "") {
                    $("#hidtheme").val("," + value);
                }
            })
            $("input[name^='chkState']").click(function() {
                var states = "";
                $("input[name^='chkState']").each(function() {
                    if ($(this).attr("checked")) {
                        states = states + $(this).parent().attr("alt") + ","
                    }
                })
                if (states != "") {
                    $("#hidstate").val("," + states);
                }
            })
            $("input[name^='chkHoliday']").click(function() {
                var hol = "";
                $("input[name^='chkHoliday']").each(function() {
                    if ($(this).attr("checked")) {
                        hol = hol + $(this).parent().attr("alt") + ","
                    }
                })
                if (hol != "") {
                    $("#hidholiday").val("," + hol);
                }
            })
            $("#btnSave").click(function() {
                if ($("input[name^='chkis']:checked").length == 0) {
                    alert("请至少选择一项修改项！");
                    return false;
                }
                $("#__VIEWSTATE").remove(); //这两句最重要
                $("#__EVENTVALIDATION").remove();
                $(this).attr("disabled", "disabled");
                $(this).val("正在保存中...");
                var options = {
                    url: "../data/SettingProperty.aspx?date=" + new Date().toUTCString(),
                    type: 'POST',
                    //beforeSubmit: Validate,
                    success: function(responseText, statusText) {
                        $("#btnSave").attr("disabled", "");
                        $("#btnSave").removeAttr("disabled");
                        $("#btnSave").val("确定保存");
                        if (responseText.indexOf("true") >= 0) {
                            // 如果父页面重载或者关闭其子对话框全部会关闭
                            alert("设置成功！");
                            parent.document.getElementById("btnQuery").click();
                            return false;
                        }
                        else if (responseText.indexOf("false") >= 0) {
                            parent.art.dialog.alert("保存失败！");
                        }
                        else if (responseText.indexOf("empty") >= 0) {
                            parent.art.dialog.alert("请选择需要批量设置的项！");
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
    <table border="0" cellpadding="0" cellspacing="0" style="width:100%;" class="formtable">
            <tr>
                <td style="text-align:right; color:#056dae;background: #F5F5F5; ">线路主题 <input id="chkisTheme" name="chkisTheme" type="checkbox" />：</td>
                <td><asp:CheckBoxList ID="chkTheme" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
        </asp:CheckBoxList>
                </td>
            </tr>
            <tr>
                <td style="text-align:right; color:#056dae;background: #F5F5F5; ">状态属性 <input id="chkisState" name="chkisState" type="checkbox" />：</td>
                <td><asp:CheckBoxList ID="chkState" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
        </asp:CheckBoxList>
                </td>
            </tr>
            <tr>
                <td style="text-align:right; color:#056dae;background: #F5F5F5; ">节日推广 <input id="chkisHoliday" name="chkisHoliday" type="checkbox" />：</td>
                <td> <asp:CheckBoxList ID="chkHoliday" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                    </asp:CheckBoxList>
                </td>
            </tr>
            <tr>
                <td style="text-align:right; color:#056dae;background: #F5F5F5; ">是否隐藏 <input id="chkishidden" name="chkishidden" type="checkbox" />：</td>
                <td>
                    <asp:CheckBox ID="chkIsLock" runat="server" /> 隐藏
                </td>
            </tr>
            <tr>
                <td style="text-align:right; color:#056dae;background: #F5F5F5; width:120px; height:80px; color:Red">选中即修改该项&nbsp;</td>
                <td><asp:Button ID="btnSave" runat="server" Text="确定保存" CssClass="btn" /></td>
            </tr>
     </table>
    </div>
    <asp:HiddenField ID="hidlineids" runat="server" Value="" />
    <input id="hidtheme" name="hidtheme" type="hidden" value="" />
    <input id="hidholiday" name="hidholiday" type="hidden" value="" />
    <input id="hidstate" name="hidstate" type="hidden" value="" />
    </form>
</body>
</html>
