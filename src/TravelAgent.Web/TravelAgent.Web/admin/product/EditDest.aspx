<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditDest.aspx.cs" Inherits="TravelAgent.Web.admin.product.EditDest" %>

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
        var EditNav = function() {
            $("#__VIEWSTATE").remove(); //这两句最重要
            $("#__EVENTVALIDATION").remove();
            $(this).attr("disabled", "disabled");
            $(this).val("正在保存中...");
            var options = {
                url: "../data/Product_Line.aspx?tag=dest&date=" + new Date().toUTCString(),
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
            $("#ddlDest").uedSelect({
                width: 150
            });

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
            $("#chkState").click(function() {
                var valuelist = ""; //保存checkbox选中值        
                //遍历name以listTest开头的checkbox
                $("input[name^='chkState']").each(function() {
                    if (this.checked) {
                        //$(this):当前checkbox对象;               
                        //$(this).parent("span"):checkbox父级span对象                
                        valuelist += $(this).parent("span").attr("alt") + ",";
                    }
                });
                if (valuelist.length > 0) {
                    //得到选中的checkbox值序列,结果为400,398
                    //valuelist = valuelist.substring(0, valuelist.length - 1);
                    valuelist = "," + valuelist;
                }
                $("#hidState").val(valuelist);
            })
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table border="0" cellpadding="0" cellspacing="0" style="width:100%;" class="formtable">
            <tr>
                <td style="text-align:right; color:#056dae;background: #F5F5F5; ">目的地归属 <span class="red">*</span>：</td>
                <td style=" padding-top:10px;">
                    <asp:DropDownList ID="ddlDest" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="text-align:right; color:#056dae;background: #F5F5F5; ">目的地名称 <span class="red">*</span>：</td>
                <td><asp:TextBox ID="txtDestName" runat="server" CssClass="dfinput required" Width="200px"></asp:TextBox>
                        <span>至少1个字符，多个目的地以英文逗号,间隔。</span>
                </td>
            </tr>
            <tr>
                <td style="text-align:right; color:#056dae;background: #F5F5F5; ">目的地链接 <span class="red">*</span>：</td>
                <td><asp:TextBox ID="txtDestURL" runat="server" CssClass="dfinput required" Width="200px" Text="/"></asp:TextBox>
                        <span>以'/'或者'http://'开头。</span>
                </td>
            </tr>
            <tr>
                <td style="text-align:right; color:#056dae;background: #F5F5F5; ">序号 <span class="red">*</span>：</td>
                <td><asp:TextBox ID="txtSort" runat="server" CssClass="dfinput required digits" MaxLength="25" Width="100px" Text="0" onkeyup="this.value=this.value.replace(/\D/g,&#39;&#39;);"></asp:TextBox>
                        <span>必须是整数数字。</span>
                </td>
            </tr>
            <tr>
                <td style="text-align:right; color:#056dae;background: #F5F5F5; ">属性：</td>
                <td>
        <asp:CheckBoxList ID="chkState" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
        </asp:CheckBoxList>
                </td>
            </tr>
            <tr>
                <td style="text-align:right; color:#056dae;background: #F5F5F5; ">是否隐藏：</td>
                <td>
                    <asp:CheckBox ID="chkLock" runat="server" Text="隐藏" />
                </td>
            </tr>
            <tr>
                <td style="text-align:right; color:#056dae;background: #F5F5F5; width:150px; height:80px;"></td>
                <td><asp:Button ID="btnSave" runat="server" Text="确定保存" CssClass="btn" /></td>
            </tr>
     </table>
    </div>
    <input id="hidId" name="hidtId" type="hidden" runat="server" value="0" />
    <input id="hidState" name="hidState" type="hidden" value="" />
    </form>
</body>
</html>
