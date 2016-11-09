<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdvEdit.aspx.cs" Inherits="TravelAgent.Web.admin.common.AdvEdit" %>

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
        //保存目的地
        var EditCategory = function() {
            $("#__VIEWSTATE").remove(); //这两句最重要
            $("#__EVENTVALIDATION").remove();
            $(this).attr("disabled", "disabled");
            $(this).val("正在保存中...");
            var options = {
                url: "../data/Common.aspx?tag=adv&date=" + new Date().toUTCString(),
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
            $("#ddlAdv").uedSelect({
                width: 150
            });
            //表单验证JS
            $("#form1").validate({
                //出错时添加的标签
                errorElement: "span",
                submitHandler: function() {
                    EditCategory();
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
                <td style="text-align:right; color:#056dae;background: #F5F5F5;">广告位归属 <span class="red">*</span>：</td>
                <td style=" padding-top:10px; padding-left:15px;">
                    <asp:DropDownList ID="ddlAdv" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="text-align:right; color:#056dae;background: #F5F5F5;">广告位名称 <span class="red">*</span>：</td>
                <td>
                    <asp:TextBox ID="txtTitle" runat="server" CssClass="dfinput required" MaxLength="50" Width="200px"></asp:TextBox>
                    <span>至少1个字符，小于50个字符。</span>
                </td>
            </tr>
            <tr>
                <td style="text-align:right; color:#056dae;background: #F5F5F5; ">广告位类型 <span class="red">*</span>：</td>
                <td>
                        <asp:RadioButtonList ID="rblAdType" runat="server" RepeatDirection="Horizontal" 
                     RepeatLayout="Flow">
                     <asp:ListItem Value="1">文字 </asp:ListItem>
                     <asp:ListItem Selected="True" Value="2">图片 </asp:ListItem>
                     <asp:ListItem Value="3">幻灯片 </asp:ListItem>
                     <asp:ListItem Value="4">动画 </asp:ListItem>
                     <asp:ListItem Value="5">FLV视频 </asp:ListItem>
                     <asp:ListItem Value="6">代码 </asp:ListItem>
                 </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td style="text-align:right; color:#056dae;background: #F5F5F5; ">备注说明：</td>
                <td><asp:TextBox ID="txtAdRemark" runat="server" CssClass="dfinput" Width="300px" MaxLength="100"></asp:TextBox>
                        <span>至少1个字符，小于100个字符</span>
                </td>
            </tr>
            <tr>
                <td style="text-align:right; color:#056dae;background: #F5F5F5; ">广告数<span class="red">*</span> ：</td>
                <td><asp:TextBox ID="txtAdNum" runat="server" CssClass="dfinput required digits" MaxLength="10" Width="50px" Text="0" onkeyup="this.value=this.value.replace(/\D/g,&#39;&#39;);"></asp:TextBox>
                        <span>必须是整数数字。</span>
                </td>
            </tr>
            <tr>
                <td style="text-align:right; color:#056dae;background: #F5F5F5; ">宽度*高度：</td>
                <td>
                    <asp:TextBox ID="txtAdWidth" runat="server" CssClass="dfinput required digits" size="5" 
            maxlength="10" onkeyup="this.value=this.value.replace(/\D/g,&#39;&#39;);" Width="50px"></asp:TextBox>px*<asp:TextBox ID="txtAdHeight" runat="server" CssClass="dfinput required digits" size="5" 
            maxlength="10" onkeyup="this.value=this.value.replace(/\D/g,&#39;&#39;);" Width="50px"></asp:TextBox>px
                </td>
            </tr>
            <tr>
                <td style="text-align:right; color:#056dae;background: #F5F5F5; ">链接目标<span class="red">*</span> ：</td>
                <td>
                <asp:RadioButtonList ID="rblAdTarget" runat="server" 
                 RepeatDirection="Horizontal" RepeatLayout="Flow">
                 <asp:ListItem Selected="True" Value="_blank">新窗口 </asp:ListItem>
                 <asp:ListItem Value="_self">原窗口 </asp:ListItem>
             </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td style="text-align:right; color:#056dae;background: #F5F5F5; width:150px; height:80px;"></td>
                <td><asp:Button ID="btnSave" runat="server" Text="确定保存" CssClass="btn" /></td>
            </tr>
     </table>
    </div>
    <input id="hidId" name="hidtId" type="hidden" runat="server" value="0" />
    </form>
</body>
</html>
