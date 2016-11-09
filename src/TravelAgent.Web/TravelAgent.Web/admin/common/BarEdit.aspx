<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BarEdit.aspx.cs" Inherits="TravelAgent.Web.admin.common.BarEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title></title>
    <link href="../css/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="/js/jquery-1.3.2.min.js"></script>
    <script type="text/javascript" src="/js/jquery.validate.min.js"></script>
    <script type="text/javascript" src="/js/validate.js"></script>
    <script type="text/javascript" src="/js/jquery.form.js"></script>
    <script type="text/javascript" src="/js/calendar.js"></script>
    <script type="text/javascript" src="../js/singleupload.js"></script>
    <script type="text/javascript">
        //保存目的地
        var EditCategory = function() {
            $("#__VIEWSTATE").remove(); //这两句最重要
            $("#__EVENTVALIDATION").remove();
            $(this).attr("disabled", "disabled");
            $(this).val("正在保存中...");
            var options = {
                url: "../data/Common.aspx?tag=bar&date=" + new Date().toUTCString(),
                type: 'POST',
                //beforeSubmit: Validate,
                success: function(responseText, statusText) {
                    $("#btnSave").attr("disabled", "");
                    $("#btnSave").removeAttr("disabled");
                    $("#btnSave").val("确定保存");
                    if (responseText.indexOf("true") >=0) {
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
                <td style="text-align:right; color:#056dae;background: #F5F5F5;">所属广告位 ：</td>
                <td style=" padding-top:10px; padding-left:15px;">
                    <asp:Label ID="lblAdTitle" runat="server" Text="" Font-Bold="true"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="text-align:right; color:#056dae;background: #F5F5F5;">广告名称 <span class="red">*</span>：</td>
                <td>
                    <asp:TextBox ID="txtTitle" runat="server" CssClass="dfinput required" MaxLength="50" Width="200px" ></asp:TextBox>
                    <span>至少1个字符，小于50个字符。</span>
                </td>
            </tr>
            <tr>
                <td style="text-align:right; color:#056dae;background: #F5F5F5; ">投放时间 <span class="red">*</span>：</td>
                <td>
                        <asp:TextBox ID="txtStartTime" runat="server" CssClass="dfinput required dateISO" size="20" maxlength="20"
            onclick="return Calendar('txtStartTime');"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="text-align:right; color:#056dae;background: #F5F5F5; ">到期时间 <span class="red">*</span>：</td>
                <td>
                <asp:TextBox ID="txtEndTime" runat="server" CssClass="dfinput required dateISO" size="20" maxlength="20"
           onclick="return Calendar('txtEndTime');"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="text-align:right; color:#056dae;background: #F5F5F5; ">上传文件：</td>
                <td style="padding-left:15px;">
                <asp:TextBox ID="txtImgUrl" runat="server" CssClass="dfinput left required" Width="200px"></asp:TextBox>
                    <a href="javascript:void(0);" class="files"><input type="file" id="FileUpload" name="FileUpload" />浏览上传图片</a>
                    <span class="uploading">正在上传，请稍候...</span>
                    <span></span>
                </td>
            </tr>
            <tr>
                <td style="text-align:right; color:#056dae;background: #F5F5F5; ">链接地址：</td>
                <td>
                   <asp:TextBox ID="txtLinkUrl" runat="server" CssClass="dfinput url" 
            maxlength="250" HintTitle="广告链接的网址"  Width="300px"
                 HintInfo="请填写广告要链接的网站，选填项，只对文字、图片广告有效，请以“http://”为开头，URL地址长度不可大于250位字符。"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="text-align:right; color:#056dae;background: #F5F5F5; ">备注(代码)：</td>
                <td style=" padding-left:15px;">
               <asp:TextBox ID="txtAdRemark" runat="server" style="width:300px;height:80px;border:solid 1px #787a7b" 
            HintTitle="备注(代码)" HintInfo="选填项，如果该广告位类别是代码，请务必将内容填写在这里，如果该广告位类别是文字、图片、幻灯片、动画、视频，该项可以为空。" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="text-align:right; color:#056dae;background: #F5F5F5; ">状态：</td>
                <td>
                <asp:RadioButtonList ID="rblIsLock" runat="server" 
                 RepeatDirection="Horizontal" RepeatLayout="Flow">
                 <asp:ListItem Selected="True" Value="0">正常 </asp:ListItem>
                 <asp:ListItem Value="1">暂停</asp:ListItem>
             </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td style="text-align:right; color:#056dae;background: #F5F5F5; width:150px; height:80px;"></td>
                <td>
                    <input id="btnSave" type="submit" value="确定保存" class="btn" /><%--<asp:Button ID="btnSave" runat="server" Text="确定保存" CssClass="btn" />--%></td>
            </tr>
     </table>
    </div>
    <input id="hidId" name="hidtId" type="hidden" runat="server" value="0" />
    <input id="hidaId" name="hidaId" runat="server" type="hidden" value="0" />
    </form>
</body>
</html>
