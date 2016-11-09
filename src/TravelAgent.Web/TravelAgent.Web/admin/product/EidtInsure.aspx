<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EidtInsure.aspx.cs" Inherits="TravelAgent.Web.admin.product.EidtInsure" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title></title>
    <link href="../css/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="/js/jquery-1.3.2.min.js"></script>
    <script type="text/javascript" src="/js/jquery.validate.min.js"></script>
    <script type="text/javascript" src="/js/validate.js"></script>
    <script type="text/javascript" src="/js/jquery.form.js"></script>
    <script type="text/javascript" charset="utf-8" src="/ueditor/ueditor.all.js"></script>
    <script type="text/javascript" charset="utf-8" src="/ueditor/ueditor.config.js"></script>
    <%--<script src="/ueditor/lang/zh-cn/zh-cn.js" type="text/javascript"></script>--%>
    <script type="text/javascript" src="/ueditor/editorconfig.js"></script>
    <script type="text/javascript">
        //保存目的地
        var EditNav = function() {
            $("#__VIEWSTATE").remove(); //这两句最重要
            $("#__EVENTVALIDATION").remove();
            $(this).attr("disabled", "disabled");
            $(this).val("正在保存中...");
            var options = {
                url: "../data/Product_Line.aspx?tag=insure_save&date=" + new Date().toUTCString(),
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
            CreateEditor('txtContent', 'simple');
            //表单验证JS
            $("#form1").validate({
                //出错时添加的标签
                errorElement: "span",
                submitHandler: function() {
                    EditNav();                 
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
                <td style="text-align:right; color:#056dae;background: #F5F5F5; ">保险名称 <span class="red">*</span>：</td>
                <td><asp:TextBox ID="txtInsureName" runat="server" CssClass="dfinput required" Width="200px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="text-align:right; color:#056dae;background: #F5F5F5; ">保险价格 <span class="red">*</span>：</td>
                <td><asp:TextBox ID="txtPrice" runat="server" CssClass="dfinput required digits" MaxLength="25" Width="100px" Text="0" onkeyup="this.value=this.value.replace(/\D/g,&#39;&#39;);"></asp:TextBox>
                        元/人，<span>销售价必须是整数数字。</span>
                </td>
            </tr>
            <tr>
                <td style="text-align:right; color:#056dae;background: #F5F5F5; ">保险内容 <span class="red">*</span>：</td>
                <td>
                <textarea id="txtContent" name="txtContent" cols="100" rows="4" style="width:500px; height:100px;" runat="server"></textarea>
                </td>
            </tr>
            <tr>
                 <td style="text-align:right; color:#056dae;background: #F5F5F5; ">是否隐藏 <span class="red">*</span>：</td>
                <td>
                    <asp:CheckBox ID="chkIsLock" runat="server" />
                </td>
            </tr>
            <tr>
                <td style="text-align:right; color:#056dae;background: #F5F5F5; width:100px; height:80px;"></td>
                <td><asp:Button ID="btnSave" runat="server" Text="确定保存" CssClass="btn" /></td>
            </tr>
     </table>
    </div>
    <input id="hidId" name="hidId" type="hidden" runat="server" value="0" />
    </form>
</body>
</html>
